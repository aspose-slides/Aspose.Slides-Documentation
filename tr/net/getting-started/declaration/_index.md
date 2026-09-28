---
title: Güven Seviyesi Gereksinimleri
type: docs
weight: 190
url: /tr/net/declaration/
keywords:
- güven seviyesi
- Tam Güven izni
- kısmi güven
- Orta Güven
- kod erişim güvenliği
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in ihtiyaç duyduğu kod erişim güvenliği güven seviyesi: .NET Framework'te tam güven, .NET 6 ve sonrasında ise güven ayarı yok."
---
## **Genel Bakış**

Kod erişimi güvenliği (CAS) güven seviyeleri yalnızca .NET Framework'te bulunur. Bu makale, Aspose.Slides for .NET için ne anlama geldiklerini açıklar: kütüphane .NET Framework'te tam güven gerektirir ve .NET 6 ve sonraki sürümlerde yapılandırılacak bir güven seviyesi bulunmaz.

## **.NET Framework**

Aspose.Slides, .NET Framework'te tam güven gerekir. Orta Güven (`<trust level="Medium" />`) gibi kısmi güvenle yapılandırılmış bir ASP.NET uygulaması gibi kısmi güven altında çalışmaz: bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) nesnesi oluşturma, bir `SecurityException` hatasıyla başarısız olur.

Microsoft, ASP.NET kısmi güvenini artık uygulamaları birbirinden izole etmenin bir yolu olarak görmemekte ve bunun yerine uygulamaları ayrı uygulama havuzlarında çalıştırmayı önermektedir. Bkz [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 and Later**

Kod erişimi güvenliği, .NET 6 ve sonraki sürümlerde mevcut değildir, bu yüzden verilecek bir güven seviyesi yoktur. Aspose.Slides, uygulamanızı çalıştıran hesabın izinleriyle çalışır. Bir uygulamanın erişebileceğini kısıtlamak için Microsoft, kullanıcı hesapları, konteynerler veya sanal makineler gibi işletim sistemi sınırlarını önermektedir. Bkz [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Orta Güven içinde ASP.NET uygulamaları çalıştıran bir hosting sağlayıcısıyla Aspose.Slides'ı kullanabilir miyim?**

Orta Güven içinde kullanılamaz. .NET Framework'te, Aspose.Slides kullanan uygulama tam güven ile çalışmalıdır.