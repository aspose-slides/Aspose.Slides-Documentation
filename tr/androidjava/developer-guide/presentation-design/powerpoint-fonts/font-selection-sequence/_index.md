---
title: Aspose.Slides for Android via Java'da Yazı Tipi Seçim Sırası
linktitle: Yazı Tipi Seçimi
type: docs
weight: 80
url: /tr/androidjava/font-selection-sequence/
keywords:
- yazı tipi seçimi
- yazı tipi ikamesi
- yazı tipi değiştirme
- ikame kuralı
- mevcut yazı tipi
- eksik yazı tipi
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'ın yazı tiplerini nasıl seçtiğini keşfedin, PPT, PPTX ve ODP dosyalarının net ve tutarlı sunumunu sağlayarak slaytlarınızı şimdi geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, işlendğinde veya başka bir formata dönüştürüldüğünde, Aspose.Slides sunumda kullanılan yazı tiplerinin işletim sisteminde mevcut olup olmadığını denetler. Gerekli bir yazı tipi eksikse, Aspose.Slides PowerPoint'in kullanacağı yazı tipine olabildiğince yakın bir yedek yazı tipini seçer.

Aspose.Slides önce seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa kullanılır. Bulunmazsa uygun bir yedek uygulanır. Yazı tipi ikame kuralları `FontSubstRule` aracılığıyla tanımlandığında, bu kurallar da göz önünde bulundurulur.

Uygulama çalışma zamanında ayrıca yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF dosyaları gibi çıktı belgeleri için harici yazı tipleri yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Sunum yüklendiğinde, işlendiğinde veya başka bir formata dönüştürüldüğünde, sunumdaki yazı tiplerine belirli kurallar uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, seçilen yazı tiplerinin işletim sisteminde mevcut olup olmadığı doğrulanmak için sunumun yazı tipleri kontrol edilir. Yazı tiplerinin eksik olduğu onaylanırsa, değiştirilir — bkz. [**Yazı Tipi Değiştirme**](https://docs.aspose.com/slides/tr/androidjava/font-replacement/) ve [**Yazı Tipi İkamesi**](https://docs.aspose.com/slides/tr/androidjava/font-substitution/).

İşte Aspose.Slides'in yazı tipleriyle ilgili izlediği süreç:

1. Aspose.Slides işletim sisteminde yazı tiplerini arayarak, sunumun seçtiği yazı tipine eşleşen bir yazı tipi bulmaya çalışır. 
2. Eğer seçilen yazı tipi bulunursa, Aspose.Slides bunu kullanır. Aksi takdirde, Aspose.Slides PowerPoint'in kullanacağına en yakın yedek bir yazı tipini kullanır.
3. Eğer [FontSubstRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsubstrule/) aracılığıyla yazı tipi değiştirme kuralları belirlenmişse, bunlar uygulanır.

Aspose.Slides, uygulama çalışma zamanına yazı tipleri eklemenize ve ardından bu yazı tiplerini kullanmanıza olanak tanır. Bakınız [**Özel yazı tipleri**](https://docs.aspose.com/slides/tr/androidjava/custom-font/).

Bir sunuma ek yazı tipleri yerleştirildiğinde, bunlara [**Gömülü yazı tipleri**](https://docs.aspose.com/slides/tr/androidjava/embedded-font/) denir.

Aspose.Slides, yalnızca çıktı belgelerine uygulanacak yazı tipleri eklemenize izin verir. Örneğin, PDF'ye dönüştürmek istediğiniz bir sunumda sisteminizde ve gömülü yazı tiplerinde eksik olan yazı tipleri varsa, gereken yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz.

{{% alert title="Note" color="primary" %}} 
Biz herhangi bir yazı tipini, ücretli olsun ya da ücretsiz, dağıtmıyoruz. API'imiz harici yazı tiplerini yüklemenize ve belgelerde gömmenize izin verir, ancak bunu yalnızca kendi takdirinize ve sorumluluğunuza göre yaparsınız.
{{% /alert %}}

## **SSS**

**Dönüştürmeden önce bir sunumda gerçekte hangi yazı tiplerinin kullanıldığını nasıl belirleyebilirim?**

Aspose.Slides, kullanılan yazı tiplerini [font manager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/) aracılığıyla incelemenizi sağlar; böylece [gömme](/slides/tr/androidjava/embedded-font/), [değiştirme](/slides/tr/androidjava/font-replacement/) veya [harici kaynak ekleme](/slides/tr/androidjava/custom-font/) konularında karar verebilirsiniz. Bu, işlemeden ve dışa aktarmadan kaynaklanan istenmeyen ikameleri önlemenize yardımcı olur.

**Yazı tiplerini işletim sistemine kurmadan ekstra yazı tipi dizinleri ekleyebilir miyim?**

Evet. İşleme ve dışa aktarma için klasörler veya bellek içi akışlar gibi [harici yazı tipi kaynaklarını](/slides/tr/androidjava/custom-font/) kaydedebilirsiniz. Bu, ana sistem yazı tiplerine bağımlılığı ortadan kaldırır ve yerleşimin öngörülebilir olmasını sağlar.

**Bir glif eksik olduğunda sessiz bir yedekleme ile uygunsuz bir yazı tipine geçişi nasıl önleyebilirim?**

Önceden açık [yazı tipi değiştirme](/slides/tr/androidjava/font-replacement/) ve yazı tipi [yedekleme kuralları](/slides/tr/androidjava/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz edip değiştiriciler için kontrollü bir öncelik belirleyerek tutarlı tipografi sağlarsınız ve beklenmedik sonuçların önüne geçersiniz.