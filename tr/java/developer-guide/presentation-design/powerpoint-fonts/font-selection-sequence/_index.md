---
title: Aspose.Slides for Java'da Yazı Tipi Seçim Sırası
linktitle: Yazı Tipi Seçimi
type: docs
weight: 80
url: /tr/java/font-selection-sequence/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'ın PPT, PPTX ve ODP dosyalarını net, tutarlı bir şekilde sunmasını sağlayan yazı tipi seçim sürecini keşfedin—slaytlarınızı şimdi geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, işleme alındığında veya başka bir formata dönüştürüldüğünde, Aspose.Slides sunumda kullanılan yazı tiplerinin işletim sisteminde mevcut olup olmadığını kontrol eder. Gerekli bir yazı tipi eksikse, Aspose.Slides PowerPoint'in kullanacağı yazı tipine mümkün olduğunca yakın bir yedek yazı tipi seçer.

Aspose.Slides önce seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa kullanılır. Bulunmazsa uygun bir yedek uygulanır. `FontSubstRule` aracılığıyla tanımlanan yazı tipi ikame kuralları da göz önünde bulundurulur.

Uygulama çalışma zamanında yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF dosyaları gibi çıktı belgeleri için harici yazı tiplerini yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Bir sunum yüklendiğinde, işleme alındığında veya başka bir formata dönüştürüldüğünde, sunumdaki yazı tiplerine belirli kurallar uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, seçilen yazı tiplerinin işletim sisteminde mevcut olup olmadığı kontrol edilir. Yazı tiplerinin eksik olduğu doğrulanırsa, bunlar yedeklenir — [**Yazı Tipi Değiştirme**](https://docs.aspose.com/slides/tr/java/font-replacement/) ve [**Yazı Tipi İkamesi**](https://docs.aspose.com/slides/tr/java/font-substitution/) bakınız.

Aspose.Slides'in yazı tipleriyle çalışırken izlediği süreç şudur:

1. Aspose.Slides, sunumun seçtiği yazı tipine uyan yazı tipini bulmak için işletim sistemindeki yazı tiplerini arar. 
2. Seçilen yazı tipi bulunursa Aspose.Slides onu kullanır. Aksi takdirde, Aspose.Slides PowerPoint'in kullanacağına mümkün olduğunca yakın bir yedek yazı tipi kullanır.
3. Yazı tipi değiştirme kuralları [FontSubstRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsubstrule/) aracılığıyla ayarlandıysa, uygulama yapılır. 

Aspose.Slides, uygulama çalışma zamanına yazı tipleri eklemenize ve ardından bu yazı tiplerini kullanmanıza izin verir. [**Özel yazı tipleri**](https://docs.aspose.com/slides/tr/java/custom-font/) bakınız. 

Ek yazı tipleri bir sunuma yerleştirildiğinde, bunlara [**Gömülü yazı tipleri**](https://docs.aspose.com/slides/tr/java/embedded-font/) denir.

Aspose.Slides, yalnızca çıktı belgelerine uygulanacak yazı tipleri eklemenize olanak tanır. Örneğin, PDF'ye dönüştürmek istediğiniz bir sunum, sisteminizde ve gömülü yazı tiplerinde eksik olan yazı tipleri içeriyorsa, gerekli yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz.

{{% alert title="Note" color="primary" %}} 
Biz hiçbir yazı tipini, ister ücretli ister ücretsiz, dağıtmıyoruz. API’miz harici yazı tiplerini yüklemenize ve belgeler içinde gömmenize izin verir, ancak bunu yalnızca kendi takdiriniz ve sorumluluğunuzla yaparsınız.
{{% /alert %}}

## **SSS**

**Sunumu dönüştürmeden önce gerçekte hangi yazı tiplerinin kullanıldığını nasıl belirleyebilirim?**

Aspose.Slides, [font manager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/) aracılığıyla kullanılan yazı tiplerini incelemenizi sağlar, böylece [gömme](/slides/tr/java/embedded-font/), [değiştirme](/slides/tr/java/font-replacement/) ya da [harici kaynaklar](/slides/tr/java/custom-font/) ekleme kararını verebilirsiniz. Bu, işleme ve dışa aktarım sırasında istenmeyen ikameleri önlemenize yardımcı olur.

**Yazı tiplerini işletim sistemine kurmadan ek font dizinleri ekleyebilir miyim?**

Evet. İşleme ve dışa aktarım için klasörler veya bellek içi akışlar gibi [harici font kaynaklarını](/slides/tr/java/custom-font/) kaydedebilirsiniz. Bu, host sistem yazı tiplerine bağımlılığı ortadan kaldırır ve düzenin öngörülebilir kalmasını sağlar.

**Bir glif eksik olduğunda uygunsuz bir yedekleme (fallback) sesiz olarak gerçekleşmesini nasıl önleyebilirim?**

Önceden açık [yazı tipi değiştirme](/slides/tr/java/font-replacement/) ve yazı tipi [yedekleme kuralları](/slides/tr/java/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz ederek ve ikameler için kontrollü bir öncelik belirleyerek tutarlı tipografi sağlarsınız ve beklenmeyen sonuçların önüne geçersiniz.