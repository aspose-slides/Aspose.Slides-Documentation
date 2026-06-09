---
title: Aspose.Slides for Node.js via Java'da Yazı Tipi Seçim Sırası
linktitle: Yazı Tipi Seçimi
type: docs
weight: 80
url: /tr/nodejs-java/font-selection-sequence/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'ın yazı tiplerini nasıl seçtiğini keşfedin, PPT, PPTX ve ODP dosyalarının net ve tutarlı sunumunu sağlayarak slaytlarınızı şimdi geliştirin."
---
## **Genel Bakış**

Bir sunum yüklendiğinde, işlendığında veya başka bir biçime dönüştürüldüğünde, Aspose.Slides sunumda kullanılan yazı tiplerinin işletim sisteminde mevcut olup olmadığını kontrol eder. Gerekli bir yazı tipi eksikse, Aspose.Slides PowerPoint'in kullanacağı yazı tipine mümkün olduğunca yakın bir yedek yazı tipi seçer.

Aspose.Slides önce seçilen yazı tipini işletim sisteminde arar. Yazı tipi bulunursa kullanılır. Bulunmazsa uygun bir yedek uygulanır. `FontSubstRule` aracılığıyla tanımlanan yazı tipi ikame kuralları da dikkate alınır.

Uygulama çalışma zamanında yazı tipleri ekleyebilir, bir sunumdan gömülü yazı tiplerini kullanabilir veya PDF dosyaları gibi çıktı belgeleri için harici yazı tipleri yükleyebilirsiniz.

## **Yazı Tipi Seçimi**

Bir sunum yüklendiğinde, işlendiğinde veya başka bir biçime dönüştürüldüğünde belli kurallar yazı tiplerine uygulanır. Örneğin, bir sunumu (slaytlarını) görüntülere dönüştürmeye çalıştığınızda, seçilen yazı tiplerinin işletim sisteminde mevcut olup olmadığı kontrol edilir. Yazı tiplerinin eksik olduğu doğrulanırsa, bunlar **[**Yazı Tipi Değiştirme**](https://docs.aspose.com/slides/tr/nodejs-java/font-replacement/)** ve **[**Yazı Tipi İkamesi**](https://docs.aspose.com/slides/tr/nodejs-java/font-substitution/)** bölümünde açıklandığı gibi değiştirilir.

Aspose.Slides'in yazı tipleriyle ilgili izlediği süreç şudur:

1. Aspose.Slides, sunumun seçilen yazı tipine uyan yazı tipini bulmak için işletim sisteminde arama yapar.  
2. Seçilen yazı tipi bulunursa Aspose.Slides onu kullanır. Aksi takdirde, PowerPoint'in kullanacağı yazı tipine olabildiğince yakın bir yedek yazı tipi kullanılır.  
3. [FontSubstRule](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsubstrule/) aracılığıyla ayarlanmış yazı tipi ikame kuralları uygulanır.

Aspose.Slides, uygulama çalışma zamanına yazı tipleri eklemenize ve bu yazı tiplerini kullanmanıza olanak tanır. **[**Özel yazı tipleri**](https://docs.aspose.com/slides/tr/nodejs-java/custom-font/)** bölümüne bakın.

Ek yazı tipleri bir sunuma yerleştirildiğinde bunlara **[**Gömülü yazı tipleri**](https://docs.aspose.com/slides/tr/nodejs-java/embedded-font/)** denir.

Aspose.Slides, yalnızca çıktı belgelerine uygulanacak yazı tiplerini eklemenize izin verir. Örneğin, PDF’ye dönüştürmek istediğiniz bir sunum sisteminizde ve gömülü yazı tiplerinde eksik yazı tipleri içeriyorsa, gerekli yazı tiplerini **harici yazı tipleri** olarak ekleyebilir veya yükleyebilirsiniz.

{{% alert title="Not" color="primary" %}} 
Hiçbir yazı tipini dağıtmıyoruz; ister ücretli ister ücretsiz olsun. API’miz harici yazı tiplerini yüklemenize ve belgelerde gömmenize olanak tanır, ancak bunu yalnızca kendi takdiriniz ve sorumluluğunuz dahilinde yaparsınız.
{{% /alert %}}

## **SSS**

**Dönüştürmeden önce bir sunumda gerçekten hangi yazı tiplerinin kullanıldığını nasıl belirleyebilirim?**

Aspose.Slides, [yazı tipi yöneticisi](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getfontsmanager/) aracılığıyla kullanılan yazı tiplerini incelemenize olanak tanır; böylece [gömme](/slides/tr/nodejs-java/embedded-font/), [değiştirme](/slides/tr/nodejs-java/font-replacement/) veya [harici kaynak ekleme](/slides/tr/nodejs-java/custom-font/) kararını verebilirsiniz. Bu, işleme ve dışa aktarım sırasında istenmeyen ikameleri önlemenize yardımcı olur.

**Yazı tiplerini işletim sistemine kurmadan ekstra yazı tipi dizinleri ekleyebilir miyim?**

Evet. İşleme ve dışa aktarım için klasörler veya bellek içi akışlar gibi [harici yazı tipi kaynaklarını](/slides/tr/nodejs-java/custom-font/) kaydedebilirsiniz. Bu, host sistem yazı tiplerine bağımlılığı ortadan kaldırır ve düzenin öngörülebilir kalmasını sağlar.

**Bir karakter eksik olduğunda uygun olmayan bir yedek yazı tipine sessizce geçişi nasıl önleyebilirim?**

Önceden açıkça [yazı tipi değiştirme](/slides/tr/nodejs-java/font-replacement/) ve yazı tipi [fallback kurallarını](/slides/tr/nodejs-java/fallback-font/) tanımlayın. Kullanılan yazı tiplerini analiz edip ikameler için kontrollü bir öncelik belirleyerek tutarlı tipografi sağlarsınız ve beklenmedik sonuçların önüne geçersiniz.