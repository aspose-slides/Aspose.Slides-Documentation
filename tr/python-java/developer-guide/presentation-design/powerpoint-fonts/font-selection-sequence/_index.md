---
title: Aspose.Slides for Python via Java'da Yazı Tipi Seçim Sırası
linktitle: Yazı Tipi Seçimi
type: docs
weight: 80
url: /tr/python-java/font-selection-sequence/
keywords:
- yazı tipi seçimi
- yazı tipi yerine koyma
- yazı tipi değişimi
- yerine koyma kuralı
- mevcut yazı tipi
- eksik yazı tipi
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'ın yazı tiplerini nasıl seçtiğini keşfedin, PPT, PPTX ve ODP dosyalarının net ve tutarlı sunumunu sağlayarak slaytlarınızı hemen geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, işlendiyinde veya başka bir formata dönüştürüldüğünde, Aspose.Slides sunumda kullanılan yazı tiplerinin işletim sisteminde bulunup bulunmadığını kontrol eder. Gerekli bir yazı tipi eksikse, Aspose.Slides PowerPoint'in kullanacağı yazı tipine mümkün olduğunca yakın bir yedek yazı tipi seçer.

Aspose.Slides önce seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa, kullanılır. Bulunmazsa, uygun bir yedek uygulanır. Yazı tipi yerine koyma kuralları [FontSubstRule](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsubstrule/) aracılığıyla tanımlandığında, bu kurallar da dikkate alınır.

Uygulama çalışma zamanında yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF dosyaları gibi çıktı belgeleri için harici yazı tipleri yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Sunum yüklendiğinde, işlendiğinde veya başka bir formata dönüştürüldüğünde, sunumdaki yazı tiplerine belirli kurallar uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, seçilen yazı tiplerinin işletim sisteminde mevcut olup olmadığı kontrol edilir. Yazı tiplerinin eksik olduğu doğrulanırsa, bunlar değiştirilir — bkz. [Yazı Tipi Değiştirme](/slides/tr/python-java/font-replacement/) ve [Yazı Tipi Yerine Koyma](/slides/tr/python-java/font-substitution/).

Aspose.Slides'ın yazı tipleriyle ilgilenirken izlediği süreç şudur:

1. Aspose.Slides, sunumun seçtiği yazı tipine uyan yazı tipini bulmak için işletim sisteminde yazı tiplerini arar.
2. Seçilen yazı tipi bulunursa, Aspose.Slides onu kullanır. Aksi takdirde, Aspose.Slides PowerPoint'in kullanacağına mümkün olduğunca yakın bir yedek yazı tipini kullanır.
3. Yazı tipi değiştirme kuralları [FontSubstRule](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsubstrule/) aracılığıyla ayarlandıysa, uygulanır.

Aspose.Slides, uygulama çalışma zamanında yazı tipleri eklemenize ve ardından bu yazı tiplerini kullanmanıza olanak tanır. bkz. [Özel Yazı Tipleri](/slides/tr/python-java/custom-font/).

Ek yazı tipleri bir sunuma yerleştirildiğinde, bu yazı tiplerine [Gömülü Yazı Tipleri](/slides/tr/python-java/embedded-font/) denir.

Aspose.Slides, *yalnızca* çıktı belgelerine uygulanacak yazı tipleri eklemenize olanak tanır. Örneğin, PDF'ye dönüştürmek istediğiniz bir sunum, sisteminizde yüklü olmayan ve sunuma gömülmemiş yazı tipleri kullanıyorsa, gerekli yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz.

{{% alert title="Note" color="info" %}}
Herhangi bir yazı tipini, ücretli ya da ücretsiz, dağıtmıyoruz. API'miz harici yazı tiplerini yüklemenize ve belgeler içinde gömmenize olanak tanır, ancak bunu kendi takdiriniz ve sorumluluğunuzda yaparsınız.
{{% /alert %}}

## **SSS**

**Bir sunumu dönüştürmeden önce hangi yazı tiplerinin gerçekten kullanıldığını nasıl belirleyebilirim?**

Aspose.Slides, kullanılan yazı tiplerini [yazı tipi yöneticisi](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/) aracılığıyla incelemenizi sağlar, böylece [gömme](/slides/tr/python-java/embedded-font/), [değiştirme](/slides/tr/python-java/font-replacement/) veya [harici kaynak ekleme](/slides/tr/python-java/custom-font/) işlemlerine karar verebilirsiniz. Bu, işleme ve dışa aktarma sırasında istenmeyen yer değiştirmeleri önlemenize yardımcı olur.

**Yazı tiplerini, işletim sistemine kurmadan ekstra yazı tipi klasörleri ekleyebilir miyim?**

Evet. İşleme ve dışa aktarım için klasörler veya bellek içi akışlar gibi [harici yazı tipi kaynaklarını](/slides/tr/python-java/custom-font/) kaydedebilirsiniz. Bu, ana sistem yazı tiplerine bağımlılığı ortadan kaldırır ve düzenin öngörülebilir kalmasını sağlar.

**Bir glif eksik olduğunda uygunsuz bir yazı tipine sessiz geçişi nasıl önleyebilirim?**

Önceden açık [yazı tipi değiştirme](/slides/tr/python-java/font-replacement/) ve yazı tipi [geri dönüş kurallarını](/slides/tr/python-java/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz edip değiştiriciler için kontrollü bir öncelik belirleyerek tutarlı tipografi sağlar ve beklenmedik sonuçları önlersiniz.