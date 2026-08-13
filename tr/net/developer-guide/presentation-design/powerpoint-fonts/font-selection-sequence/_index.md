---
title: Aspose.Slides for .NET'te Yazı Tipi Seçim Sırası
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
description: "Aspose.Slides for .NET'in yazı tiplerini nasıl seçtiğini keşfedin, PPT, PPTX ve ODP dosyalarının net ve tutarlı sunumunu sağlayın—slaytlarınızı şimdi iyileştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, işlendğinde veya başka bir formata dönüştürüldüğünde, Aspose.Slides, sunumda kullanılan yazı tiplerinin işletim sisteminde mevcut olup olmadığını kontrol eder. Gerekli bir yazı tipi eksikse, Aspose.Slides, PowerPoint'in kullanacağı yazı tipine olabildiğince yakın bir yedek yazı tipi seçer.

Aspose.Slides, önce seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa, kullanılır. Bulunamazsa, uygun bir yedek uygulanır. `FontSubstRule` aracılığıyla tanımlanan yazı tipi yerine koyma kuralları da göz önünde bulundurulur.

Uygulama çalışma zamanında da yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF dosyaları gibi çıktı belgeleri için harici yazı tipleri yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Sunum yüklendiğinde, işlendğinde veya başka bir formata dönüştürüldüğünde, sunumdaki yazı tiplerine belirli kurallar uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, seçilen yazı tiplerinin işletim sisteminde bulunup bulunmadığı kontrol edilir. Yazı tiplerinin eksik olduğu teyit edilirse, bunlar değiştirilir — bakınız [**Yazı Tipi Değiştirme**](https://docs.aspose.com/slides/tr/net/font-replacement/) ve [**Yazı Tipi Yerine Koyma**](https://docs.aspose.com/slides/tr/net/font-substitution/).

Aspose.Slides'in yazı tipleriyle ilgili izlediği süreç şudur:

1. Aspose.Slides, işletim sisteminde yazı tiplerini arayarak sunumun seçtiği yazı tipine uygun olanı bulur. 
2. Seçilen yazı tipi bulunursa, Aspose.Slides onu kullanır. Aksi takdirde, Aspose.Slides, PowerPoint'in kullanacağına en yakın bir yedek yazı tipi kullanır.
3. Eğer yazı tipi değiştirme kuralları [FontSubstRule](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsubstrule/) aracılığıyla belirlenmişse, uygulanır. 

Aspose.Slides, uygulama çalışma zamanına yazı tipleri eklemenize ve ardından bu yazı tiplerini kullanmanıza olanak tanır. Bkz. [**Özel Yazı Tipleri**](https://docs.aspose.com/slides/tr/net/custom-font/). 

Bir sunuma ek yazı tipleri yerleştirildiğinde, bunlara [**Gömülü Yazı Tipleri**](https://docs.aspose.com/slides/tr/net/embedded-font/) denir.

Aspose.Slides, yalnızca çıktı belgelerine uygulanacak yazı tipleri eklemenize izin verir. Örneğin, PDF'ye dönüştürmek istediğiniz bir sunum, sisteminizde ve gömülü yazı tiplerinde eksik olan yazı tiplerini içeriyorsa, gereken yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz.

{{% alert title="Note" color="info" %}} 
Biz hiçbir yazı tipi dağıtmıyoruz, ister ücretli ister ücretsiz. API'miz, harici yazı tiplerini yüklemenize ve belgelerde gömmenize olanak tanır, ancak bunu yazı tipleri konusunda kendi takdirinize ve sorumluluğunuza göre yaparsınız.
{{% /alert %}}

## **SSS**

### Dönüştürmeden önce bir sunumda gerçekte hangi yazı tiplerinin kullanıldığını nasıl belirleyebilirim?

Aspose.Slides, [yazı tipi yöneticisi](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/fontsmanager/) aracılığıyla kullanılan yazı tiplerini incelemenizi sağlar, böylece [gömme](/slides/tr/net/embedded-font/), [değiştirme](/slides/tr/net/font-replacement/) veya [harici kaynak ekleme](/slides/tr/net/custom-font/) yapıp yapmayacağınıza karar verebilirsiniz. Bu, işleme ve dışa aktarma sırasında istenmeyen yer değiştirmeleri önlemenize yardımcı olur.

### Ek yazı tipi dizinlerini işletim sistemine kurmadan ekleyebilir miyim?

Evet. İşleme ve dışa aktarım için klasörler veya bellek içi akışlar gibi [harici yazı tipi kaynaklarını](/slides/tr/net/custom-font/) kaydedebilirsiniz. Bu, ana sistem yazı tiplerine bağımlılığı ortadan kaldırır ve düzenin öngörülebilir kalmasını sağlar.

### Bir glif eksik olduğunda uygun olmayan bir yazı tipine sessizce geçişi nasıl önleyebilirim?

Önceden açıkça [yazı tipi değiştirme](/slides/tr/net/font-replacement/) ve yazı tipi [geri dönüş kuralları](/slides/tr/net/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz edip yedekler için kontrollü bir öncelik belirleyerek tutarlı tipografi sağlamış ve beklenmedik sonuçların önüne geçebilirsiniz.