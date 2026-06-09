---
title: Aspose.Slides for PHP'de Yazı Tipi Seçim Sırası
linktitle: Yazı Tipi Seçimi
type: docs
weight: 80
url: /tr/php-java/font-selection-sequence/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'nin nasıl yazı tiplerini seçtiğini keşfedin, PPT, PPTX ve ODP dosyalarının net ve tutarlı bir şekilde sunulmasını sağlayın — slaytlarınızı şimdi geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, işlendğinde veya başka bir formata dönüştürüldüğünde, Aspose.Slides sunumda kullanılan yazı tiplerinin işletim sisteminde mevcut olup olmadığını kontrol eder. Gerekli bir yazı tipi eksikse, Aspose.Slides PowerPoint'in kullanacağı yazı tipine mümkün olduğunca yakın bir yedek yazı tipi seçer.

Aspose.Slides önce seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa kullanılır. Bulunmazsa uygun bir yedek uygulanır. `FontSubstRule` aracılığıyla yazı tipi ikame kuralları tanımlanmışsa, bu kurallar da dikkate alınır.

Uygulama zamanında yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF dosyaları gibi çıktı belgeleri için dış yazı tipleri yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Bir sunum yüklendiğinde, işlendğinde veya başka bir formata dönüştürüldüğünde, sunumdaki yazı tiplerine belirli kurallar uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, seçilen yazı tiplerinin işletim sisteminde mevcut olup olmadığı kontrol edilir. Yazı tiplerinin eksik olduğu doğrulanırsa, yerlerine [**Yazı Tipi Değiştirme**](https://docs.aspose.com/slides/tr/php-java/font-replacement/) ve [**Yazı Tipi Yerine Koyma**](https://docs.aspose.com/slides/tr/php-java/font-substitution/) bölümlerine bakın.

Aspose.Slides'in yazı tipleriyle ilgili izlediği süreç şudur:

1. Aspose.Slides, sunumun seçilen yazı tipine uyan yazı tipini bulmak için işletim sisteminde arama yapar.  
2. Seçilen yazı tipi bulunursa Aspose.Slides onu kullanır. Aksi takdirde, PowerPoint'in kullanacağıya en yakın yedek bir yazı tipi kullanılır.  
3. [FontSubstRule](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsubstrule/) aracılığıyla ayarlanan yazı tipi ikame kuralları uygulanır.

Aspose.Slides, Aspose çalışma zamanına yazı tipleri eklemenize ve ardından bu yazı tiplerini kullanmanıza olanak tanır. Bkz. [**Özel yazı tipleri**](https://docs.aspose.com/slides/tr/php-java/custom-font/).

Ek yazı tipleri bir sunuma yerleştirildiğinde, bunlar [**Gömülü yazı tipleri**](https://docs.aspose.com/slides/tr/php-java/embedded-font/) olarak adlandırılır.

Aspose.Slides, yalnızca çıktı belgelerine uygulanacak yazı tipleri eklemenize izin verir. Örneğin, PDF'ye dönüştürmek istediğiniz bir sunum sisteminizde ve gömülü yazı tiplerinde eksik yazı tipleri içeriyorsa, bu eksik yazı tiplerini **Dış yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz.  

## **SSS**

**Dönüştürmeden önce bir sunumda hangi yazı tiplerinin gerçekten kullanıldığını nasıl belirleyebilirim?**

Aspose.Slides, [yazı tipi yöneticisi](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/) aracılığıyla kullanılan yazı tiplerini incelemenize olanak tanır; böylece [göm](/slides/tr/php-java/embedded-font/), [değiştir](/slides/tr/php-java/font-replacement/) veya [dış kaynak ekle](/slides/tr/php-java/custom-font/) seçeneklerine karar verebilirsiniz. Bu, işleme ve dışa aktarma sırasında istenmeyen ikameleri önlemenize yardımcı olur.

**Yazı tiplerini işletim sistemine kurmadan ekstra yazı tipi dizinleri ekleyebilir miyim?**

Evet. İşleme ve dışa aktarma için klasörler veya bellek içi akışlar gibi [dış yazı tipi kaynaklarını](/slides/tr/php-java/custom-font/) kaydedebilirsiniz. Bu, ana sistem yazı tiplerine bağımlılığı ortadan kaldırır ve düzenin öngörülebilir kalmasını sağlar.

**Bir glif eksik olduğunda sessiz bir şekilde uygunsuz bir yazı tipine dönüşümü nasıl önleyebilirim?**

Önceden açıkça [yazı tipi değiştirme](/slides/tr/php-java/font-replacement/) ve yazı tipi [geri dönüş kurallarını](/slides/tr/php-java/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz ederek ve ikameler için kontrollü bir öncelik belirleyerek tutarlı tipografi sağlayabilir ve beklenmedik sonuçların önüne geçebilirsiniz.