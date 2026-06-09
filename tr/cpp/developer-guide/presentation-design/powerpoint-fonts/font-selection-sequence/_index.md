---
title: Aspose.Slides for C++'da Yazı Tipi Seçim Sırası
linktitle: Yazı Tipi Seçimi
type: docs
weight: 80
url: /tr/cpp/font-selection-sequence/
keywords:
- yazı tipi seçimi
- yazı tipi ikamesi
- yazı tipi değişimi
- ikame kuralı
- mevcut yazı tipi
- eksik yazı tipi
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ın yazı tiplerini nasıl seçtiğini keşfedin, PPT, PPTX ve ODP dosyalarının net ve tutarlı sunumunu sağlayın—slaytlarınızı şimdi geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, işleme alındığında veya başka bir formata dönüştürüldüğünde, Aspose.Slides sunumda kullanılan yazı tiplerinin işletim sisteminde bulunup bulunmadığını kontrol eder. Gerekli bir yazı tipi eksikse, Aspose.Slides PowerPoint'in kullanacağına en yakın olan bir yedek yazı tipini seçer.

Aspose.Slides önce seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa, kullanılır. Bulunmazsa, uygun bir yedek uygulanır. `FontSubstRule` aracılığıyla tanımlanan yazı tipi ikame kuralları da dikkate alınır.

Uygulama çalışma zamanında yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF dosyaları gibi çıktı belgeleri için harici yazı tipleri yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Sunum yüklendiğinde, işleme alındığında veya başka bir formata dönüştürüldüğünde, sunumdaki yazı tiplerine belirli kurallar uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, seçilen yazı tiplerinin işletim sisteminde bulunup bulunmadığı kontrol edilir. Yazı tiplerinin eksik olduğu teyit edilirse, yedeklenir — bkz. [**Yazı Tipi Değiştirme**](https://docs.aspose.com/slides/tr/cpp/font-replacement/) ve [**Yazı Tipi İkamesi**](https://docs.aspose.com/slides/tr/cpp/font-substitution/).

Aspose.Slides'in yazı tipleriyle çalışırken izlediği süreç şudur:

1. Aspose.Slides, sunumun seçtiği yazı tipine eşleşen yazı tipini bulmak için işletim sisteminde yazı tiplerini arar. 
2. Seçilen yazı tipi bulunursa, Aspose.Slides onu kullanır. Aksi takdirde, Aspose.Slides PowerPoint'in kullanacağına en yakın yedek bir yazı tipini kullanır.
3. Yazı tipi değiştirme kuralları [FontSubstRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsubstrule/) aracılığıyla ayarlanmışsa, uygulanır. 

Aspose.Slides, uygulama çalışma zamanına yazı tipleri eklemenize ve bu yazı tiplerini kullanmanıza olanak tanır. Bkz. [**Özel yazı tipleri**](https://docs.aspose.com/slides/tr/cpp/custom-font/). 

Ek yazı tipleri bir sunuma yerleştirildiğinde, bunlara [**Gömülü yazı tipleri**](https://docs.aspose.com/slides/tr/cpp/embedded-font/) denir.

Aspose.Slides, yalnızca çıktı belgelerine uygulanacak yazı tipleri eklemenize olanak tanır. Örneğin, PDF'ye dönüştürmek istediğiniz bir sunum sisteminizde ve gömülü yazı tiplerinde eksik yazı tipleri içeriyorsa, gerekli yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz.

{{% alert title="Not" color="primary" %}} 
Biz herhangi bir yazı tipi dağıtmıyoruz, ücretli ya da ücretsiz. API'miz, harici yazı tiplerini yüklemenize ve belgelerde gömmenize olanak tanır, ancak bu işlemi yazı tiplerini kendi takdiriniz ve sorumluluğunuzla yaparsınız.
{{% /alert %}}

## **SSS**

**Dönüştürmeden önce bir sunumda gerçekte hangi yazı tiplerinin kullanıldığını nasıl belirleyebilirim?**

Aspose.Slides, kullanılan yazı tiplerini [font yöneticisi](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_fontsmanager/) aracılığıyla incelemenizi sağlar, böylece [gömme](/slides/tr/cpp/embedded-font/), [değiştirme](/slides/tr/cpp/font-replacement/) veya [harici kaynaklar](/slides/tr/cpp/custom-font/) ekleme konusunda karar verebilirsiniz. Bu, işleme ve dışa aktarma sırasında istenmeyen ikameleri önlemenize yardımcı olur.

**Yazı tipleri klasörlerini işletim sistemine kurmadan ekleyebilir miyim?**

Evet. İşleme ve dışa aktarım için klasörler veya bellek içi akışlar gibi [harici yazı tipi kaynaklarını](/slides/tr/cpp/custom-font/) kaydedebilirsiniz. Bu, ana sistem yazı tiplerine bağımlılığı ortadan kaldırır ve düzenin öngörülebilir olmasını sağlar.

**Bir glif eksik olduğunda uygun olmayan bir yedek yazı tipine sessiz geçişi nasıl önleyebilirim?**

Önceden açık [yazı tipi değiştirme](/slides/tr/cpp/font-replacement/) ve yazı tipi [yedekleme kurallarını](/slides/tr/cpp/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz ederek ve ikameler için kontrollü bir öncelik belirleyerek tutarlı tipografi sağlarsınız ve beklenmedik sonuçların önüne geçersiniz.