---
title: .NET 6 Desteği
type: docs
weight: 235
url: /tr/net/net6/
keywords:
- .NET 6 desteği
- Bulut çözümü
- AWS Lambda
- Azure Fonksiyonları
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 6'yı modern, çok platformlu C# uygulamalarında PowerPoint PPT, PPTX ve ODP sunumlarını oluşturmak, düzenlemek ve dönüştürmek için yapılandırın."
---
## **Giriş**

Starting in [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) sürümünde, .NET6 için destek uygulanmıştır. Bu desteğin özelliği, .NET6'nın Linux için System.Drawing.Common'ı artık desteklememesidir ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) ve Slides bu grafik alt sistemini bir C++ bileşeni olarak kendisi uygular.

Aspose.Slides for .NET artık GDI/libgdiplus bağımlılıkları olmadan çalışır:
* Windows
* Linux

_MacOS_ desteği devam ediyor.

## **AWS ve Azure'da .NET 6 için Slides Kullanımı**

.NET6, bulutta (AWS, Azure veya diğer bulut çözümleri) kullanılan Aspose.Slides için tercih edilen sürümüdür.

Daha önce, Aspose.Slides bir Linux sunucusunda kullanıldığında, ek bağımlılıklar (libgdiplus) kurulmalıydı ve bu genellikle zahmetli veya uygulanamazdı (örneğin, [AWS Lambda](https://aws.amazon.com/lambda) kullanırken). .NET6 için Slides ile bu bağımlılıklar artık gerekli değil, bu yüzden dağıtım çok daha kolay.

Bir diğer düşünülmesi gereken nokta, Aspose.Slides'ın Windows sunuculu bir bulut çözümünde kullanıldığında ortaya çıkan sorunlardır. Örneğin, [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) süreçte sınırlamalara sahiptir ve PDF dışa aktarımı sırasında sorunlara neden olur (bkz. [this](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). .NET6 için Aspose.Slides kullanımı bu sorunu çözer.

## **System.Drawing.Common Paketi ve .NET 6 için Slides Sınıflarının Kullanımı (CS0433: Tip Hem Slides Hem de System.Drawing.Common içinde Mevcut Hatası)**

Bazen, hem System.Drawing hem de .NET6 için Slides bağımlılıklarının bir projede kullanılması gerekir (örneğin, .NET6 projesi diğer paketlere bağımlıysa ve bu paketler de System.Drawing'e bağımlıysa). Bu, şu tür karmaşık hatalara neden olabilir:

* CS0433: 'Image' tipi hem 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' hem de 'System.Drawing.Common, Version=6.0.0.0 içinde mevcut
* CS0433: 'Graphics' tipi hem 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' hem de 'System.Drawing.Common, Version=6.0.0.0 içinde mevcut

Bu durumda, Aspose.Slides için (24.8'den düşük sürüm) [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) kullanabilirsiniz:
1) Projeye ait bağımlılıklardan Aspose.Slides derlemesini seçin ve ardından **Properties** öğesine tıklayın.  
   ![Aspose Slides paket özellikleri](package_properties.png)
2) Bir alias ayarlayın (örneğin, "Slides").  
   ![Aspose Slides alias](set_alias.png)

Artık System.Drawing.Common'tan gelen tipler varsayılan olarak kullanılacak. Aspose.Slides tiplerinin gerektiği yerlerde dış derleme alias'ı belirtilmelidir.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Tam örnek:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

24.8 sürümünden itibaren, System.Drawing bağımlılıkları içeren eski genel API kaldırılmıştır. Yukarıdaki kod örneğine ilişkin, slayt görüntüsünü aşağıdaki gibi alabilirsiniz.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
Yeni API, [Modern API](/slides/tr/net/modern-api/) içinde daha ayrıntılı olarak açıklanmıştır.