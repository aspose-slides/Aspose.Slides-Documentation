---
title: Aspose.Slides for Python'da Yazı Tipi Seçim Sırası
linktitle: Yazı Tipi Seçimi
type: docs
weight: 80
url: /tr/python-net/font-selection-sequence/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'in yazı tiplerini nasıl seçtiğini keşfedin, PPT, PPTX ve ODP dosyalarının net ve tutarlı bir şekilde sunulmasını sağlayın—slaytlarınızı şimdi geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, render edildiğinde veya başka bir formata dönüştürüldüğünde, Aspose.Slides sunumda kullanılan yazı tiplerinin işletim sisteminde mevcut olup olmadığını kontrol eder. Gerekli bir yazı tipi eksikse, Aspose.Slides PowerPoint'in kullanacağına en yakın olabilecek bir yedek yazı tipini seçer.

Aspose.Slides önce seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa kullanılır. Bulunmazsa uygun bir yedek yazı tipi uygulanır. `FontSubstRule` aracılığıyla yazı tipi ikame kuralları tanımlandığında, bu kurallar da dikkate alınır.

Uygulama çalışma zamanında yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF dosyaları gibi çıktı belgeleri için harici yazı tiplerini yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Sunum yüklendiğinde, render edildiğinde veya başka bir formata dönüştürüldüğünde, sunumdaki yazı tiplerine bazı kurallar uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, seçilen yazı tiplerinin işletim sisteminde mevcut olup olmadığı kontrol edilir. Yazı tiplerinin eksik olduğu doğrulanırsa, bunlar yedeklenir — bkz. [**Yazı Tipi Değiştirme**](https://docs.aspose.com/slides/tr/python-net/font-replacement/) ve [**Yazı Tipi İkamesi**](https://docs.aspose.com/slides/tr/python-net/font-substitution/).

Aspose.Slides'in yazı tipleriyle çalışma süreci şu şekildedir:

1. Aspose.Slides, sunumun seçtiği yazı tipine uyan yazı tipini bulmak için işletim sisteminde yazı tiplerini arar. 
2. Seçilen yazı tipi bulunursa, Aspose.Slides onu kullanır. Aksi takdirde, Aspose.Slides PowerPoint'in kullanacağına en yakın yedek yazı tipini kullanır.
3. Yazı tipi değiştirme kuralları [FontSubstRule](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsubstrule/) aracılığıyla ayarlandıysa, bunlar uygulanır. 

Aspose.Slides, uygulama çalışma zamanına yazı tipleri eklemenize ve bu yazı tiplerini kullanmanıza olanak tanır. Bakınız [**Özel Yazı Tipleri**](https://docs.aspose.com/slides/tr/python-net/custom-font/). 

Ek yazı tipleri bir sunuma yerleştirildiğinde, bunlara [**Gömülü Yazı Tipleri**](https://docs.aspose.com/slides/tr/python-net/embedded-font/) denir.

Aspose.Slides, yalnızca çıktı belgelerine uygulanacak yazı tipleri eklemenize olanak tanır. Örneğin, PDF'e dönüştürmek istediğiniz bir sunum, sisteminizde ve gömülü yazı tiplerinde eksik olan yazı tipleri içeriyorsa, gerekli yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz. 

{{% alert title="Note" color="primary" %}} 
Biz hiçbir yazı tipini, ücretli ya da ücretsiz, dağıtmıyoruz. API’miz harici yazı tiplerini yüklemenize ve belgelerde gömmenize izin verir, ancak bunu yalnızca kendi takdirinize ve sorumluluğunuza göre yaparsınız.
{{% /alert %}}

## **SSS**

**Bir sunumu dönüştürmeden önce hangi yazı tiplerinin gerçekten kullanıldığını nasıl belirleyebilirim?**

Aspose.Slides, kullanılan yazı tiplerini [yazı tipi yöneticisi](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/fonts_manager/) aracılığıyla incelemenizi sağlar; böylece [göm](/slides/tr/python-net/embedded-font/), [değiştir](/slides/tr/python-net/font-replacement/) veya [harici kaynaklar](/slides/tr/python-net/custom-font/) ekleyip eklemeyeceğinize karar verebilirsiniz. Bu, render ve dışa aktarma sırasında istenmeyen ikameleri önlemeye yardımcı olur.

**İşletim sistemine kurmadan ek yazı tipi dizinleri ekleyebilir miyim?**

Evet. Klasörler veya bellek içi akışlar gibi [harici yazı tipi kaynakları](/slides/tr/python-net/custom-font/) kaydedebilir ve bunları render ve dışa aktarım için kullanabilirsiniz. Bu, ana sistem yazı tiplerine bağımlılığı ortadan kaldırır ve düzenin öngörülebilir olmasını sağlar.

**Bir glif eksik olduğunda sessiz bir geri dönüşün uygunsuz bir yazı tipine yapılmasını nasıl önleyebilirim?**

Önceden açıkça [yazı tipi değiştirme](/slides/tr/python-net/font-replacement/) ve yazı tipi [geri dönüş kuralları](/slides/tr/python-net/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz ederek ve ikameler için kontrollü bir öncelik ayarlayarak tutarlı tipografi sağlarsınız ve beklenmeyen sonuçların önüne geçersiniz.