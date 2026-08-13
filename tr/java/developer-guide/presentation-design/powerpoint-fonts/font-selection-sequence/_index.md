---
title: Aspose.Slides for Java'da Yazı Tipi Seçim Sırası
linktitle: Yazı Tipi Seçimi
type: docs
weight: 80
url: /tr/java/font-selection-sequence/
keywords:
  - yazı tipi seçimi
  - yazı tipi yer değiştirme
  - yazı tipi değiştirme
  - yer değiştirme kuralı
  - mevcut yazı tipi
  - eksik yazı tipi
  - PowerPoint
  - OpenDocument
  - sunum
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Java'ın nasıl yazı tiplerini seçtiğini keşfedin, PPT, PPTX ve ODP dosyalarının net ve tutarlı sunumunu sağlayın—slaytlarınızı şimdi geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, işleme alındığında veya başka bir formata dönüştürüldüğünde, Aspose.Slides sunumda kullanılan yazı tiplerinin işletim sisteminde bulunup bulunmadığını kontrol eder. Gereken bir yazı tipi eksikse, Aspose.Slides PowerPoint'in kullanacağına mümkün olduğunca yakın bir yedek yazı tipini seçer.

Aspose.Slides öncelikle seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa kullanılır. Bulunamazsa uygun bir yedek uygulanır. `FontSubstRule` aracılığıyla yazı tipi yer değiştirme kuralları tanımlandığında, bu kurallar da dikkate alınır.

Uygulama çalışma zamanında yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF dosyaları gibi çıktı belgeleri için harici yazı tipleri yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Sunum yüklendiğinde, işleme alındığında veya başka bir formata dönüştürüldüğünde, sunumdaki yazı tiplerine belirli kurallar uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, seçilen yazı tiplerinin işletim sisteminde mevcut olup olmadığı kontrol edilir. Yazı tiplerinin eksik olduğu doğrulanırsa, onlar değiştirilir — bakınız [**Yazı Tipi Değiştirme**](https://docs.aspose.com/slides/tr/java/font-replacement/) ve [**Yazı Tipi Yer Değiştirme**](https://docs.aspose.com/slides/tr/java/font-substitution/).

Aspose.Slides'in yazı tipleriyle ilgili izlediği süreç şudur:

1. Aspose.Slides, sunumun seçtiği yazı tipine uygun yazı tipini bulmak için işletim sisteminde yazı tiplerini arar. 
2. Seçilen yazı tipi bulunursa Aspose.Slides onu kullanır. Aksi takdirde, Aspose.Slides PowerPoint'in kullanacağına mümkün olduğunca yakın bir yedek yazı tipini kullanır.
3. Yazı tipi değiştirme kuralları [FontSubstRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsubstrule/) aracılığıyla ayarlanmışsa, uygulanır. 

Aspose.Slides, uygulama çalışma zamanına yazı tipleri eklemenize ve bu yazı tiplerini kullanmanıza izin verir. Bkz. [**Özel yazı tipleri**](https://docs.aspose.com/slides/tr/java/custom-font/). 

Ek yazı tipleri bir sunuma yerleştirildiğinde, bunlara [**Gömülü yazı tipleri**](https://docs.aspose.com/slides/tr/java/embedded-font/) denir.

Aspose.Slides, yalnızca çıktı belgelerine uygulanacak yazı tipleri eklemenize olanak tanır. Örneğin, PDF'ye dönüştürmek istediğiniz bir sunum sisteminizde ve gömülü yazı tiplerinde eksik yazı tipleri içeriyorsa, gereken yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz.

{{% alert title="Note" color="info" %}} 
Biz herhangi bir yazı tipini, ücretli olsun ya da ücretsiz, dağıtmıyoruz. API'miz harici yazı tiplerini yüklemenize ve belgelerde gömmenize izin verir, ancak bunu yalnızca kendi takdirinize ve sorumluluğunuza göre yaparsınız.
{{% /alert %}}

## **SSS**

### Dönüştürmeden önce bir sunumda gerçekte hangi yazı tiplerinin kullanıldığını nasıl belirleyebilirim?

Aspose.Slides, kullanılan yazı tiplerini [font manager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/) aracılığıyla incelemenizi sağlar; böylece [gömme](/slides/tr/java/embedded-font/), [değiştirme](/slides/tr/java/font-replacement/) veya [harici kaynaklar](/slides/tr/java/custom-font/) ekleme kararı verebilirsiniz. Bu, işleme ve dışa aktarma sırasında istenmeyen yerine koymaların önlenmesine yardımcı olur.

### Yazı tiplerini işletim sistemine kurmadan ekstra yazı tipi dizinleri ekleyebilir miyim?

Evet. İşleme ve dışa aktarma için klasörler veya bellek içi akışlar gibi [harici yazı tipi kaynaklarını](/slides/tr/java/custom-font/) kaydedebilirsiniz. Bu, host sistem yazı tiplerine bağımlılığı ortadan kaldırır ve düzenin öngörülebilir kalmasını sağlar.

### Bir glif eksik olduğunda sessiz bir geri dönüşün uygun olmayan bir yazı tipine yapılmasını nasıl önleyebilirim?

Önceden açık [yazı tipi değiştirme](/slides/tr/java/font-replacement/) ve yazı tipi [geri dönüş kurallarını](/slides/tr/java/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz edip yerine koymalar için kontrollü bir öncelik belirleyerek tutarlı tipografi sağlarsınız ve beklenmeyen sonuçların önüne geçersiniz.