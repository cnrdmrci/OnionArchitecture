# Onion Architecture

- [Projede Kullanılan Teknolojiler](#usage)

- [Onion Architecture Nedir?](#what-is-onion-arch)

- [Onion Architecture Katmanları](#layers-of-onion-arch)
  - [Domain Katmanı](#domain-layer)
  - [Application Katmanı](#application-layer)
  - [Infrastructure Katmanı](#infrastructure-layer)
  - [Presentation Katmanı](#presentation-layer)


## <a name="usage">Projede Kullanılan Teknolojiler</a>

- .Net Core 6
- Entity Framework Core 6
- Swagger
- MediatR
- CQRS
- API Versioning
- Exception Handling
- Fluent Validation
- Mapster

## <a name="what-is-onion-arch">Onion Architecture Nedir?</a>

Onion Architecture; Jeffrey Palermo tarafından tasarlanmıştır. Uygulamanın daha iyi test edilebilir olmasını, sürdürülebilirliğini ve güvenirlirliğini sağlamak amaçlanmıştır. Klasik bilinen n katmanlı mimari yapısındaki karşılaşılan zorlukları ele alarak bunlara çözüm sağlamayı amaçlamaktadır. Katmanlar arası gevşek bir bağımlılık kurmayı hedeflemektedir.

Onion Archtitecture, katmanli bir mimariye sahiptir ve bu katmanlar bir soğanı andırmaktadır. Her katmanın bağımlılığı bir alt katman olacak şekilde soğanın iç kısmına doğru olmalıdır. Bu bağımlılık yapısı temel bir ilkedir.

Clean Architecture uygulayabilmek için kullanılan tasarım kalıplarından biridir. Aşağıda mimari tasarımı gösterilmektedir.

![onion-architecture](https://user-images.githubusercontent.com/16361055/149662671-e2fdab14-7bc3-4585-a482-6b13ac289c5e.png)

## <a name="layers-of-onion-arch">Onion Architecture Katmanları</a>

Uygulamadaki kabaca 4 katmandan oluşmaktadır. Application ve Domain katmanı Core katman olarak isimlendirilmektedir.

### <a name="domain-layer">Domain Katmanı</a>

Uygulamanın merkezidir ve tüm uygulamada kullanılacak domain ve veritabanı entitylerini kapsar. Entity, Value Object, Enumeration ve domanin içi Exception sınıflarını içermektedir.

### <a name="application-layer">Application Katmanı</a>

Uygulamanın use case'lerinin bulunduğu ve bu use case'lerin kullandığı arayüzleri içeren katmandır. Custom Exception, Request Response sınıfları, DTO objeleri, Mapping, Validation kontrolleri vb. bu katmanda kullanılmaktadır.

### <a name="infrastructure-layer">Infrastructure Katmanı</a>

Application katmanında oluşturulan arayüzlerin implementasyonlarının bulunduğu ve bir takım ayarlamaların yapıldığı katmandır. DbContext ayarlamaları, bildirim gönderme ve mail gönderimi gibi işlemler gerçekleştirilebilmektedir.

### <a name="presentation-layer">Presentation Katmanı</a>

Uygulamanın en üst katmanında bulunan ve kullanıcının uygulamayla iletişime geçtiği katmandır.

