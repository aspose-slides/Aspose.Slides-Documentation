---
title: "Aspose.Slides for .NET'te Yazı Tipi Seçim Sırası"
linktitle: "Yazı Tipi Seçimi"
type: docs
weight: 80
url: /tr/net/font-selection-sequence/
keywords:
- "yazı tipi seçimi"
- "yazı tipi ikamesi"
- "yazı tipi değişimi"
- "ikame kuralı"
- "mevcut yazı tipi"
- "eksik yazı tipi"
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in nasıl yazı tipleri seçtiğini keşfedin, PPT, PPTX ve ODP dosyalarının net ve tutarlı sunumunu sağlayarak slaytlarınızı şimdi geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, işlenirken veya başka bir formata dönüştürüldüğünde, Aspose.Slides gömülü yazı tiplerini ve uygulama tarafından kullanılabilir yazı tiplerini dikkate alır. Gerekli bir yazı tipi mevcut değilse, Aspose.Slides PowerPoint'in kullanacağı yazı tipine mümkün olduğunca yakın bir yedek yazı tipi seçer.

Mevcut yazı tipleri sistem yazı tiplerini, uygulama tarafından yüklenen yazı tiplerini ve sunuma gömülü yazı tiplerini içerebilir. Aşağıda açıklanan .NET 26.11 tercihinin kontrol ettiği eşleşen gömülü ve kayıtlı yazı tiplerinden hangisinin öncelikli olacağını belirler. [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) aracılığıyla tanımlanan yazı tipi ikame kuralları ayrı bir mekanizmadır.

Uygulama çalışma zamanında da yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF dosyaları gibi çıktı belgeleri için harici yazı tipleri yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Metin, açık bir aile adı yerine `+mn-lt` gibi bir tema yazı tipine başvurabilir. Uygulanabilir tema tarafından belirtilen aileyi elde etmek için [Tema Yazı Tipi Referanslarını Çöz](/slides/tr/net/presentation-theme/#resolve-theme-font-references) sayfasına bakın. Bu referansı çözmek, yazı tipi kullanılabilirliğini kontrol etmek ve işleme zamanı ikamesi ya da glif geri dönüşümü uygulamaktan ayrı bir işlemdir; metni oluşturmak için sonunda kullanılan yazı tipi dosyasını tanımlamaz.

Slaytları işlerken veya bir sunumu dönüştürürken, istenen yazı tiplerinin gömülü olduğundan veya kayıtlı kaynaklardan temin edilebildiğinden emin olun. Eksik yazı tipleri değiştirme veya ikame gerektirebilir; [**Yazı Tipi Değiştirme**](/slides/tr/net/font-replacement/) ve [**Yazı Tipi İkamesi**](/slides/tr/net/font-substitution/) sayfalarına bakın.

Yazı tipi seçiminde araştırma yaparken:
1. Talep edilen aile ve stili, tema referansı dahil, çözün.
2. Gömülü yazı tiplerini ve kayıtlı kaynakları, sistem yazı tipleri ve uygulama tarafından yüklenen yazı tipleri dahil, kontrol edin. Eşleşen gömülü ve kayıtlı sürümler rekabet ederken aşağıdaki tercihi kullanın.
3. Talep edilen yazı tipi veya karakterler mevcut değilse [yazı tipi ikame kuralları](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) ve glif geri dönüşümünü inceleyin.

Aspose.Slides, uygulama çalışma zamanına yazı tipleri eklemenize ve ardından bu yazı tiplerini kullanmanıza olanak tanır. [**Özel Yazı Tipleri**](/slides/tr/net/custom-font/) sayfasına bakın.

Sunuma ek yazı tipleri yerleştirildiğinde, bunlara [**Gömülü Yazı Tipleri**](/slides/tr/net/embedded-font/) denir.

Aspose.Slides yalnızca çıktı belgelerine uygulanacak yazı tipleri eklemenize olanak tanır. Örneğin, PDF'ye dönüştürmek istediğiniz bir sunum sisteminizde ve gömülü yazı tiplerinde eksik yazı tipleri içeriyorsa, gerekli yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz.

{{% alert title="Note" color="info" %}} 
Biz herhangi bir yazı tipi dağıtmıyoruz, ister ücretli ister ücretsiz. API'miz, harici yazı tiplerini yüklemenize ve belgelerde gömmenize izin verir, fakat bunu yazı tiplerini kendi takdiriniz ve sorumluluğunuz dahilinde yaparsınız.
{{% /alert %}}

## **Kayıtlı Yazı Tiplerini Gömülü Yazı Tiplerine Üstün Tut**

.NET 26.11'den itibaren, [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) eşleşen bir kayıtlı yazı tipinin dışa aktarım sırasında gömülü bir yazı tipine göre öncelik almasını sağlar. Varsayılan değer `false`'tır. Eşleşme, yazı tipi adı ve stilini kullanır; farklı bir aile adı değiştirme eşleşmesi değildir. Kayıtlı yazı tipleri sistemden veya [açıkça yüklenen yazı tipi kaynakları](/slides/tr/net/custom-font/) gelerek yüklenebilir.

**Aspose.Slides.NET6.CrossPlatform 26.11** paketini .NET 8 üzerinde kullanır. Ortamınız için [kurulum kılavuzu](/slides/tr/net/installation/) sayfasını izleyin. `embedded-fonts.pptx` dosyasını gömülü bir yazı tipiyle ve aynı aile adı ve stili olan `preferred.ttf` dosyasını sağlayın. Çıktıyı karşılaştırmak istiyorsanız iki yazı tipi dosyası görünür şekilde farklı olmalıdır.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

Bu ayar, dışa aktarım sırasında yazı tipi önceliğini değiştirir; metnin yazı tipini yeniden adlandırmaz, gömülü yazı tipi verisini kaldırmaz veya kayıtlı dosyayı yeniden gömme yapmaz. Bu çalışma zamanı ayarıdır: bir sunumu yeniden açtıktan sonra tekrar ayarlayın. Eşleşen bir kayıtlı yazı tipi mevcut değilse, tercihi etkinleştirmek bir yazı tipi sağlamaz; hedef ortamınızda ortaya çıkan yazı tipini ve yerleşimi doğrulayın.

Yukarıdaki yapılandırma için açıkça yüklenmiş normal yazı tipleriyle PNG ve PDF çıktısı kontrol edildi. Aynı sonuçlara güvenmeden önce kendi yazı tipi dosyalarınızı, stillerinizi, SDK derlemenizi ve çıktı formatlarınızı kontrol edin. Yazı tipi ölçümleri satır sonlarını ve konumlandırmayı değiştirebilir. Farklı bir aileye ihtiyacınız olduğunda [yazı tipi değiştirme](/slides/tr/net/font-replacement/) veya [ikame](/slides/tr/net/font-substitution/) kullanın ve sunumda depolanan yazı tiplerini değiştirmeniz gerektiğinde [gömülü yazı tipi işlemleri](/slides/tr/net/embedded-font/) kullanın.

## **SSS**

**Sunumda dönüştürmeden önce gerçekte hangi yazı tiplerinin kullanıldığını nasıl belirleyebilirim?**

Aspose.Slides, kullanılan yazı tiplerini [yazı tipi yöneticisi](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) aracılığıyla incelemenizi sağlar, böylece [göm](/slides/tr/net/embedded-font/), [değiştir](/slides/tr/net/font-replacement/) veya [harici kaynaklar](/slides/tr/net/custom-font/) eklemeye karar verebilirsiniz. Bu, işleme ve dışa aktarım sırasında istenmeyen ikameleri önlemenize yardımcı olur.

**Ekstra yazı tipi dizinlerini işletim sistemine kurmadan ekleyebilir miyim?**

Evet. Klasörler veya bellek içi akışlar gibi [harici yazı tipi kaynakları](/slides/tr/net/custom-font/) kaydedebilir ve bunları işleme ve dışa aktarım için kullanabilirsiniz. Bu, ana sistem yazı tiplerine bağımlılığı ortadan kaldırır ve yerleşimin öngörülebilir olmasını sağlar.

**Bir glif eksik olduğunda uygun olmayan bir yazı tipine sessiz geri dönüşümünü nasıl önleyebilirim?**

Önceden açık [yazı tipi değiştirme](/slides/tr/net/font-replacement/) ve yazı tipi [geri dönüşüm kuralları](/slides/tr/net/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz edip ikameler için kontrol edilen bir öncelik belirleyerek tutarlı tipografi sağlarsınız ve beklenmedik sonuçların önüne geçersiniz.