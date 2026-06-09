---
title: Lisanslama
description: "Aspose.Slides for Python via Java, değerlendirme amacıyla Lisanslama ve Abonelik politikalarını kullanarak farklı satın alma planları sunar ve Ücretsiz Deneme ile 30 günlük Geçici Lisans sağlar."
type: docs
weight: 80
url: /tr/python-java/licensing/
---
Bazen, en iyi değerlendirme sonuçları için uygulamalı bir yaklaşım gerekebilir. Bu nedenle, Aspose.Slides farklı satın alma planları sunar ve ayrıca ücretsiz deneme ve değerlendirme için 30 günlük geçici lisans sağlar.

{{% alert color="primary" %}}
Ürünlerimizi nasıl değerlendireceğiniz, doğru lisanslayacağınız ve satın alacağınız konusunda size rehberlik eden çeşitli genel politika ve uygulamaların olduğunu unutmayın. Bunları ["Satın Alma Politikaları ve SSS"](https://purchase.aspose.com/policies) bölümünde bulabilirsiniz.
{{% /alert %}}

## **Aspose.Slides'ı Değerlendirin**
Aspose.Slides'ı kolayca değerlendirme amacıyla indirebilirsiniz. Değerlendirme paketi, satın alınan paketle aynıdır. Değerlendirme sürümü, lisansı uygulamak için birkaç satır kod eklediğinizde basitçe lisanslı hâle gelir.

## **Değerlendirme Sürümü Sınırlamaları**
Aspose.Slides'ın (lisans belirtmeden) değerlendirme sürümü tam ürün işlevselliğini sağlar, ancak belgeyi açtığınızda ve kaydettiğinizde belgenin üst kısmına bir değerlendirme filigranı ekler. Sunum slaytlarından metin çıkarırken ayrıca sadece bir slayt ile sınırlısınız.

{{% alert color="primary" %}} 
Değerlendirme sürümü sınırlamaları olmadan Aspose.Slides'ı test etmek istiyorsanız **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır?](https://purchase.aspose.com/temporary-license) bölümüne bakın.
{{% /alert %}} 

## **Lisans Hakkında**
Aspose.Slides for Python via Java'nin [indirme sayfasından](https://releases.aspose.com/slides/tr/python-java/) kolayca bir değerlendirme sürümünü indirebilirsiniz. Değerlendirme sürümü, Aspose.Slides'ın lisanslı sürümüyle **tamamen aynı yetenekleri** sunar. Ayrıca, bir lisans satın alıp lisansı uygulamak için birkaç satır kod eklediğinizde değerlendirme sürümü basitçe lisanslı hâle gelir.

Lisans, ürün adı, lisanslı geliştirici sayısı, abonelik son tarih gibi detayları içeren düz metin XML dosyasıdır. Dosya dijital olarak imzalanmıştır, bu yüzden dosyayı değiştirmeyin. Dosyanın içeriğine yanlışlıkla ekstra bir satır sonu eklemek bile lisansı geçersiz kılar.

Değerlendirme sürümüyle ilgili sınırlamaları önlemek için **Aspose.Slides** kullanmadan önce bir lisans ayarlamanız gerekir. Lisansı yalnızca uygulama ya da süreç başına bir kez ayarlamanız yeterlidir.

## Satın Alınan Lisans
Satın aldıktan sonra, lisans dosyasını ya da akışını uygulamanız gerekir.

{{% alert color="primary" %}}
Lisansı ayarlamanız gerekir:
* her uygulama alanı için yalnızca bir kez
* diğer Aspose.Slides sınıflarını kullanmadan önce
{{% /alert %}}

{{% alert color="primary" %}}
Fiyatlandırma bilgilerini [“Fiyatlandırma Bilgileri”](https://purchase.aspose.com/pricing/slides/tr/family) sayfasında bulabilirsiniz.
{{% /alert %}}

### **Aspose.Slides for Python via Java'da Lisans Ayarlama**
Lisanslar şu konumlardan uygulanabilir:
* Açık yol
* Akış
* Metrik Lisans olarak – yeni bir lisanslama mekanizması

{{% alert color="primary" %}}
**setLicense** metodunu bir bileşeni lisanslamak için kullanın.

Birden fazla **setLicense** çağrısı zararlı olmasa da, kaynakların (işlemci) israfıdır.
{{% /alert %}}

{{% alert color="warning" %}}
Yeni lisanslar yalnızca 21.4 ve üzeri sürümde Aspose.Slides'ı etkinleştirebilir. Daha eski sürümler farklı bir lisanslama sistemi kullanır ve bu lisansları tanımaz.
{{% /alert %}}

#### **Dosya Kullanarak Lisans Uygulama**
Bu kod parçacığı bir lisans dosyasını ayarlamak için kullanılır:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

setLicense metodunu çağırırken, lisans adı lisans dosyanızın adıyla aynı olmalıdır. Örneğin, lisans dosyasının adını "Aspose.Slides.lic.xml" olarak değiştirebilirsiniz. Ardından, kodunuzda setLicense metoduna yeni lisans adını (Aspose.Slides.lic.xml) geçirmeniz gerekir.

#### **Baytlardan Lisans Uygulama**
Bu kod parçacığı bir bayttan lisans uygulamak için kullanılır:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### **Metrik Lisans Uygulama**
Aspose.Slides, geliştiricilerin metrik bir anahtar uygulamasına izin verir. Bu yeni bir lisanslama mekanizmasıdır.

Yeni lisanslama mekanizması mevcut lisanslama yöntemiyle birlikte kullanılacaktır. API özelliklerinin kullanımına göre faturalandırılmak isteyen müşteriler Metrik Lisanslamayı kullanabilir.

Bu tür bir lisansı elde etmek için gerekli tüm adımları tamamladıktan sonra lisans dosyası yerine anahtarları alacaksınız. Bu metrik anahtar, bu amaçla özel olarak tanıtılan **Metered** sınıfı kullanılarak uygulanabilir.

Aşağıdaki kod örneği, metrik genel ve özel anahtarların nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# CAD Metered sınıfının bir örneğini oluştur
# set_metered_key özelliğine erişin ve ortak ve özel anahtarları parametre olarak geçin
metered = Metered();

# API'yi çağırmadan önce ölçülen veri miktarını al
amountbefore = Metered.getConsumptionQuantity()

# Bilgiyi göster
print("Amount Consumed Before: \" + amountbefore + \"" )

# Belgeyi diskten yükle.
pres = Presentation();

# Belgenin sayfa sayısını al
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# PDF olarak kaydet
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# API'yi çağırdıktan sonra ölçülen veri miktarını al
amountafter = Metered.getConsumptionQuantity()

# Bilgiyi göster
print("Amount Consumed After: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}
Metrik lisansın doğru kullanımı için stabil bir internet bağlantısına sahip olmanız gerektiğini unutmayın, çünkü Metrik mekanizması doğru hesaplamalar için hizmetlerimizle sürekli etkileşim gerektirir. Daha fazla ayrıntı için [“Metrik Lisanslama SSS”](https://purchase.aspose.com/faqs/licensing/metered) bölümüne bakın.
{{% /alert %}}