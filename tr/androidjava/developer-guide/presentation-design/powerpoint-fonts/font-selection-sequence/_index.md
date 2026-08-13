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
description: "Aspose.Slides for Android via Java'nin yazı tiplerini nasıl seçtiğini keşfedin, PPT, PPTX ve ODP dosyalarının net ve tutarlı bir şekilde sunulmasını sağlayarak slaytlarınızı şimdi geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, işlendğinde veya başka bir formata dönüştürüldüğünde, Aspose.Slides sunumda kullanılan yazı tiplerinin işletim sisteminde mevcut olup olmadığını kontrol eder. Gerekli bir yazı tipi eksikse, Aspose.Slides PowerPoint'in kullanacağına en yakın olan bir yedek yazı tipini seçer.

Aspose.Slides önce seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa kullanılır. Bulunamazsa uygun bir yedek uygulanır. `FontSubstRule` aracılığıyla tanımlanan yazı tipi ikame kuralları da dikkate alınır.

Ayrıca uygulama çalışma zamanında yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF gibi çıktı belgeleri için dış yazı tiplerini yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Bir sunum yüklendiğinde, işlendğinde veya başka bir formata dönüştürüldüğünde, sunumdaki yazı tiplerine belirli kurallar uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, seçilen yazı tiplerinin işletim sisteminde mevcut olduğu doğrulanmak üzere sunumun yazı tipleri kontrol edilir. Yazı tiplerinin eksik olduğu onaylanırsa, değiştirilir — bakın [**Yazı Tipi Değiştirme**](https://docs.aspose.com/slides/tr/androidjava/font-replacement/) ve [**Yazı Tipi İkamesi**](https://docs.aspose.com/slides/tr/androidjava/font-substitution/).

Aspose.Slides'in yazı tipleriyle ilgili izlediği süreç şu şekildedir:

1. Aspose.Slides, sunumun seçilen yazı tipine uygun bir yazı tipini bulmak için işletim sisteminde yazı tiplerini arar. 
2. Seçilen yazı tipi bulunursa, Aspose.Slides onu kullanır. Aksi takdirde, Aspose.Slides PowerPoint'in kullanacağına en yakın yedek bir yazı tipini kullanır.
3. Eğer [FontSubstRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsubstrule/) aracılığıyla yazı tipi değiştirme kuralları ayarlanmışsa, bunlar uygulanır.

Aspose.Slides, uygulama çalışma zamanına yazı tipleri eklemenize ve bu yazı tiplerini kullanmanıza olanak tanır. Bakınız [**Özel yazı tipleri**](https://docs.aspose.com/slides/tr/androidjava/custom-font/).

Ek yazı tipleri bir sunuma yerleştirildiğinde, bunlar [**Gömülü yazı tipleri**](https://docs.aspose.com/slides/tr/androidjava/embedded-font/) olarak adlandırılır.

Aspose.Slides, yalnızca çıktı belgelerine uygulanacak yazı tipleri eklemenizi sağlar. Örneğin, PDF'ye dönüştürmek istediğiniz bir sunum sisteminizde ve gömülü yazı tiplerinde eksik olan yazı tipleri içeriyorsa, gereken yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz.

{{% alert title="Note" color="info" %}} 
Biz herhangi bir yazı tipi dağıtmıyoruz, ister ücretli ister ücretsiz olsun. API'miz dış yazı tiplerini yüklemenize ve belgelerde gömmenize izin verir, ancak bunu tamamen kendi takdiriniz ve sorumluluğunuzla yaparsınız.
{{% /alert %}}

## **SSS**

### Bir sunumu dönüştürmeden önce hangi yazı tiplerinin gerçekten kullanıldığını nasıl belirleyebilirim?

Aspose.Slides, kullanılan yazı tiplerini [font manager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/) aracılığıyla incelemenizi sağlar, böylece [göm](/slides/tr/androidjava/embedded-font/), [değiştir](/slides/tr/androidjava/font-replacement/) veya [harici kaynakları](/slides/tr/androidjava/custom-font/) ekleyip eklemeyeceğinize karar verebilirsiniz. Bu, işleme ve dışa aktarma sırasında istenmeyen ikameleri önlemenize yardımcı olur.

### İşletim sistemine kurulum yapmadan ek yazı tipi dizinleri ekleyebilir miyim?

Evet. İşleme ve dışa aktarma için klasörler ya da bellek içi akışlar gibi [harici yazı tipi kaynaklarını](/slides/tr/androidjava/custom-font/) kaydedebilirsiniz. Bu, ana sistem yazı tiplerine bağımlılığı ortadan kaldırır ve yerleşimin öngörülebilir kalmasını sağlar.

### Bir glif eksik olduğunda uygunsuz bir yazı tipine sessizce geçişi nasıl önleyebilirim?

Önceden açık [yazı tipi değiştirme](/slides/tr/androidjava/font-replacement/) ve yazı tipi [geri dönüş kuralları](/slides/tr/androidjava/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz ederek ve ikameler için kontrollü bir öncelik belirleyerek tutarlı tipografi sağlar ve beklenmeyen sonuçların önüne geçersiniz.