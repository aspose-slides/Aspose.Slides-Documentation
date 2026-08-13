---
title: Aspose.Slides for C++'de Yazı Tipi Seçim Sırası
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
description: "Aspose.Slides for C++'in yazı tiplerini nasıl seçtiğini keşfedin, PPT, PPTX ve ODP dosyalarının net ve tutarlı sunumunu sağlayın - slaytlarınızı şimdi geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, render edildiğinde veya başka bir formata dönüştürüldüğünde, Aspose.Slides sunumda kullanılan yazı tiplerinin işletim sisteminde mevcut olup olmadığını kontrol eder. Gerekli bir yazı tipi eksikse, Aspose.Slides PowerPoint'in kullanacağına en yakın olan bir yedek yazı tipini seçer.

Aspose.Slides önce seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa, onu kullanır. Bulunamazsa uygun bir yedek uygulanır. `FontSubstRule` aracılığıyla tanımlanan yazı tipi ikame kuralları da dikkate alınır.

Uygulama çalışma zamanında yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF dosyaları gibi çıktı belgeleri için harici yazı tipleri yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Sunum yüklendiğinde, render edildiğinde veya başka bir formata dönüştürüldüğünde sunumdaki yazı tiplerine belirli kurallar uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, seçilen yazı tiplerinin işletim sisteminde mevcut olup olmadığı kontrol edilir. Yazı tiplerinin eksik olduğu doğrulanırsa, bunlar değiştirilir — bakınız [**Yazı Tipi Değiştirme**](https://docs.aspose.com/slides/tr/cpp/font-replacement/) ve [**Yazı Tipi İkamesi**](https://docs.aspose.com/slides/tr/cpp/font-substitution/).

Aspose.Slides'in yazı tipleriyle ilgili izlediği süreç şudur:

1. Aspose.Slides, işletim sisteminde sunumun seçilen yazı tipine eşleşen bir yazı tipi bulmak için arama yapar. 
2. Seçilen yazı tipi bulunursa, Aspose.Slides onu kullanır. Aksi takdirde, Aspose.Slides PowerPoint'in kullanacağına en yakın yedek bir yazı tipini kullanır.
3. [FontSubstRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsubstrule/) aracılığıyla ayarlanmış yazı tipi ikame kuralları uygulanır. 

Aspose.Slides, uygulama çalışma zamanına yazı tipleri eklemenize ve bu yazı tiplerini kullanmanıza izin verir. Bakınız [**Özel yazı tipleri**](https://docs.aspose.com/slides/tr/cpp/custom-font/). 

Ek yazı tipleri bir sunuma yerleştirildiğinde bunlara [**Gömülü yazı tipleri**](https://docs.aspose.com/slides/tr/cpp/embedded-font/) denir.

Aspose.Slides, yalnızca çıktı belgelerine uygulanacak yazı tiplerini eklemenize olanak tanır. Örneğin, PDF'e dönüştürmek istediğiniz bir sunum sisteminizde ve gömülü yazı tiplerinde eksik olan yazı tipleri içeriyorsa, gerekli yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz. 

{{% alert title="Note" color="info" %}} 
Biz herhangi bir yazı tipi dağıtmayız; ister ücretli ister ücretsiz olsun. API'imiz harici yazı tiplerini yüklemenize ve belgelerde gömmenize izin verir, ancak bu işlemi sizin takdiriniz ve sorumluluğunuz dahilinde yaparsınız.
{{% /alert %}}

## **SSS**

### Dönüştürmeden önce bir sunumda gerçekte hangi yazı tiplerinin kullanıldığını nasıl belirleyebilirim?

Aspose.Slides, [yazı tipi yöneticisi](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_fontsmanager/) aracılığıyla kullanılan yazı tiplerini incelemenizi sağlar, böylece [gömme](/slides/tr/cpp/embedded-font/), [değiştirme](/slides/tr/cpp/font-replacement/) veya [harici kaynak ekleme](/slides/tr/cpp/custom-font/) kararını verebilirsiniz. Bu, render ve dışa aktarma sırasında istenmeyen ikameleri önlemenize yardımcı olur.

### Yazı tiplerini işletim sistemine kurmadan ekstra yazı tipi dizinleri ekleyebilir miyim?

Evet. Render ve dışa aktarma için klasörler ya da bellek içi akışlar gibi [harici yazı tipi kaynakları](/slides/tr/cpp/custom-font/) kaydedebilirsiniz. Bu, ana sistem yazı tiplerine bağımlılığı ortadan kaldırır ve düzenin öngörülebilir kalmasını sağlar.

### Bir glif eksik olduğunda uygun olmayan bir yedek yazı tipine sessizce geçişi nasıl önleyebilirim?

Önceden açıkça [yazı tipi değiştirme](/slides/tr/cpp/font-replacement/) ve yazı tipi [fallBack kuralları](/slides/tr/cpp/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz edip yedek yazı tipleri için kontrollü bir öncelik belirleyerek tutarlı tipografi elde eder ve beklenmedik sonuçların önüne geçersiniz.