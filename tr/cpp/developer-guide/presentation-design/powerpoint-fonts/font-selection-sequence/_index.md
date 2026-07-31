---
title: Aspose.Slides for C++ içinde Yazı Tipi Seçim Sırası
linktitle: Yazı Tipi Seçimi
type: docs
weight: 80
url: /tr/cpp/font-selection-sequence/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'nin nasıl yazı tipleri seçtiğini keşfedin, PPT, PPTX ve ODP dosyalarının net ve tutarlı bir şekilde sunulmasını sağlayın—slaytlarınızı şimdi geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, işlendğinde veya başka bir formata dönüştürüldüğünde, Aspose.Slides sunumda kullanılan yazı tiplerinin işletim sisteminde bulunup bulunmadığını kontrol eder. Gerekli bir yazı tipi eksikse, Aspose.Slides PowerPoint'in kullanacağı yazı tipine mümkün olduğunca yakın bir yedek yazı tipi seçer.

Aspose.Slides önce seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa kullanılır. Bulunamazsa uygun bir yedek uygulanır. `FontSubstRule` aracılığıyla tanımlanan yazı tipi ikame kuralları da dikkate alınır.

Uygulama çalışma zamanında yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF gibi çıktı belgeleri için harici yazı tiplerini yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Sunum yüklendiğinde, işlendğinde veya başka bir formata dönüştürüldüğünde belirli kurallar uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, sunumun yazı tipleri işletim sisteminde mevcut olup olmadığını doğrulamak için kontrol edilir. Yazı tipleri eksikse, yerine [**Yazı Tipi Değiştirme**](https://docs.aspose.com/slides/tr/cpp/font-replacement/) ve [**Yazı Tipi İkamesi**](https://docs.aspose.com/slides/tr/cpp/font-substitution/) bölümlerinde açıklandığı gibi yedek yazı tipleri kullanılır.

Aspose.Slides'in yazı tipleriyle ilgili izlediği süreç şudur:

1. Aspose.Slides işletim sisteminde, sunumun seçtiği yazı tipine denk gelen yazı tipini bulmak için arama yapar.  
2. Seçilen yazı tipi bulunursa Aspose.Slides onu kullanır. Aksi takdirde, PowerPoint'in kullanacağına en yakın yedek bir yazı tipi kullanılır.  
3. [FontSubstRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsubstrule/) aracılığıyla ayarlanmış yazı tipi ikame kuralları uygulanır.  

Aspose.Slides, uygulama çalışma zamanına yazı tipleri eklemenize ve ardından bu yazı tiplerini kullanmanıza olanak tanır. Bkz. [**Özel yazı tipleri**](https://docs.aspose.com/slides/tr/cpp/custom-font/).  

Bir sunuma eklenen ek yazı tiplerine [**Gömülü yazı tipleri**](https://docs.aspose.com/slides/tr/cpp/embedded-font/) denir.

Aspose.Slides, yalnızca çıktı belgelerine uygulanacak yazı tipleri eklemenize izin verir. Örneğin, PDF’ye dönüştürmek istediğiniz bir sunum sisteminizde ve gömülü yazı tiplerinde bulunmayan yazı tiplerine sahipse, gerekli yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz.

{{% alert title="Not" color="primary" %}} 
Biz herhangi bir yazı tipi dağıtmayız; ister ücretli ister ücretsiz olsun. API’miz harici yazı tiplerini yüklemenize ve belgelerde gömmenize olanak tanır, ancak bu işlemi kendi takdiriniz ve sorumluluğunuz dahilinde yaparsınız.
{{% /alert %}}

## **SSS**

**Dönüştürmeden önce bir sunumda gerçekte hangi yazı tiplerinin kullanıldığını nasıl belirleyebilirim?**

Aspose.Slides, [yazı tipi yöneticisi](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_fontsmanager/) aracılığıyla kullanılan yazı tiplerini incelemenizi sağlar; böylece [gömme](/slides/tr/cpp/embedded-font/), [değiştirme](/slides/tr/cpp/font-replacement/) veya [harici kaynak ekleme](/slides/tr/cpp/custom-font/) kararını verebilirsiniz. Bu, işleme ve dışa aktarma sırasında istenmeyen ikameleri önlemenize yardımcı olur.

**Yazı tiplerini işletim sistemine kurmadan ekstra yazı tipi dizinleri ekleyebilir miyim?**

Evet. [Harici yazı tipi kaynaklarını](/slides/tr/cpp/custom-font/) klasörler veya bellek içi akışlar gibi kayıt edebilir, işleme ve dışa aktarma sırasında kullanabilirsiniz. Böylece host sistemindeki yazı tiplerine bağımlılık ortadan kalkar ve düzen tahmin edilebilir olur.

**Bir glif eksik olduğunda uygun olmayan bir yedek yazı tipine sessizce geçişi nasıl önleyebilirim?**

Önceden açık [yazı tipi ikame](/slides/tr/cpp/font-replacement/) ve yazı tipi [fallback kuralları](/slides/tr/cpp/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz edip ikameler için kontrollü bir öncelik belirleyerek tutarlı tipografi sağlar ve beklenmedik sonuçların önüne geçersiniz.