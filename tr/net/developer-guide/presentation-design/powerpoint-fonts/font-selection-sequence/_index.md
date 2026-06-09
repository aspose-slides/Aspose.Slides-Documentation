---
title: Aspose.Slides for .NET'de Yazı Tipi Seçim Sırası
linktitle: Yazı Tipi Seçimi
type: docs
weight: 80
url: /tr/net/font-selection-sequence/
keywords:
- yazı tipi seçimi
- yazı tipi yerine koyma
- yazı tipi değiştirme
- yerine koyma kuralı
- mevcut yazı tipi
- eksik yazı tipi
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in PPT, PPTX ve ODP dosyalarını net ve tutarlı bir şekilde sunmasını sağlayan yazı tipi seçim sürecini keşfedin—slaytlarınızı şimdi geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, işlendğinde veya başka bir biçime dönüştürüldüğünde, Aspose.Slides sunumda kullanılan yazı tiplerinin işletim sisteminde bulunup bulunmadığını kontrol eder. Gerekli bir yazı tipi eksikse, Aspose.Slides PowerPoint'in kullanacağına mümkün olduğunca yakın bir yedek yazı tipini seçer.

Aspose.Slides önce seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa, kullanılır. Bulunamazsa, uygun bir yedek uygulanır. `FontSubstRule` aracılığıyla yazı tipi değiştirme kuralları tanımlandığında, bu kurallar da dikkate alınır.

Uygulama çalışma zamanında da yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF dosyaları gibi çıktı belgeleri için harici yazı tipleri yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Sunum yüklendiğinde, işlendiğinde veya başka bir biçime dönüştürüldüğünde yazı tiplerine belirli kurallar uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, sunumdaki yazı tipleri işletim sisteminde mevcut olup olmadığını doğrulamak için kontrol edilir. Yazı tiplerinin eksik olduğu doğrulanırsa, değiştirilir — bakınız [**Yazı Tipi Değiştirme**](https://docs.aspose.com/slides/tr/net/font-replacement/) ve [**Yazı Tipi Yerine Koyma**](https://docs.aspose.com/slides/tr/net/font-substitution/).

Aspose.Slides'in yazı tipleriyle çalışırken izlediği süreç şudur:

1. Aspose.Slides, sunumun seçtiği yazı tipine uyan yazı tipini bulmak için işletim sisteminde yazı tiplerini arar. 
2. Seçilen yazı tipi bulunursa, Aspose.Slides onu kullanır. Aksi takdirde, Aspose.Slides PowerPoint'in kullanacağına mümkün olduğunca yakın bir yedek yazı tipini kullanır.
3. Yazı tipi değiştirme kuralları [FontSubstRule](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsubstrule/) aracılığıyla ayarlandıysa, uygulanır. 

Aspose.Slides, uygulama çalışma zamanına yazı tipleri eklemenize ve bu yazı tiplerini kullanmanıza olanak tanır. Bkz. [**Özel Yazı Tipleri**](https://docs.aspose.com/slides/tr/net/custom-font/). 

Bir sunuma ek yazı tipleri yerleştirildiğinde, bunlara [**Gömülü Yazı Tipleri**](https://docs.aspose.com/slides/tr/net/embedded-font/) denir.

Aspose.Slides, yalnızca çıktı belgelerine uygulanacak yazı tipleri eklemenize olanak tanır. Örneğin, PDF'ye dönüştürmek istediğiniz bir sunum, sisteminizde ve gömülü yazı tiplerinde eksik olan yazı tipleri içeriyorsa, gerekli yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz.

{{% alert title="Note" color="primary" %}} 
Biz hiçbir yazı tipi dağıtmıyoruz, ister ücretli ister ücretsiz olsun. API'miz harici yazı tiplerini yüklemenize ve belgeler içinde gömmenize izin verir, ancak bunu kendi takdirinize ve sorumluluğunuza göre yaparsınız.
{{% /alert %}}

## **SSS**

**Bir sunumda dönüştürmeden önce hangi yazı tiplerinin gerçekten kullanıldığını nasıl belirleyebilirim?**

Aspose.Slides, [font manager](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/fontsmanager/) aracılığıyla kullanılan yazı tiplerini incelemenizi sağlar, böylece [gömmek](/slides/tr/net/embedded-font/), [değiştirmek](/slides/tr/net/font-replacement/) veya [harici kaynaklar](/slides/tr/net/custom-font/) eklemeye karar verebilirsiniz. Bu, işleme ve dışa aktarma sırasında istenmeyen yerine koymaları önlemenize yardımcı olur.

**Ek yazı tipi dizinlerini işletim sistemine kurmadan ekleyebilir miyim?**

Evet. İşleme ve dışa aktarma için klasörler veya bellek içi akışlar gibi [harici yazı tipi kaynaklarını](/slides/tr/net/custom-font/) kaydedebilirsiniz. Bu, ana sistem yazı tiplerine bağımlılığı ortadan kaldırır ve yerleşimin öngörülebilir olmasını sağlar.

**Bir glif eksik olduğunda uygunsuz bir yazı tipine sessizce gerilemeyi nasıl önleyebilirim?**

Önceden açık [yazı tipi değiştirme](/slides/tr/net/font-replacement/) ve yazı tipi [gerileme kurallarını](/slides/tr/net/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz ederek ve yerine koyucular için kontrollü bir öncelik belirleyerek, tutarlı tipografi sağlayabilir ve beklenmedik sonuçların ortaya çıkmasını önleyebilirsiniz.