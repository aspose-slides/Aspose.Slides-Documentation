---
title: Python’da Sunum Bilgilerini Getirme ve Güncelleme
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/python-net/examine-presentation/
keywords:
- sunum formatı
- sunum özellikleri
- belge özellikleri
- özellikleri al
- özellikleri oku
- özellikleri değiştir
- özellikleri düzenle
- özellikleri güncelle
- PPTX incele
- PPT incele
- ODP incele
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin, daha hızlı içgörüler ve akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides’da sunum bilgilerini nasıl inceleyeceğinizi gösterir. Tam dosyayı yüklemeden bir sunumun mevcut biçimini nasıl belirleyeceğinizi, belge özelliklerini okuyacağınızı ve gerektiğinde bu özellikleri nasıl güncelleyeceğinizi açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/) API’lerine dayanmaktadır ve sunum meta verileriyle çalışmak için tipik işlemleri gösterir.

## **Sunum Biçimini Kontrol Et**

Bir sunum üzerinde çalışmadan önce, sunumun şu anda hangi biçimde (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumun biçimini sunumu yüklemeden kontrol edebilirsiniz. Aşağıdaki Python koduna bakın:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Sunum Özelliklerini Al**

Bu Python kodu, sunum özelliklerini (sunum hakkında bilgi) nasıl alacağınızı gösterir:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

DocumentProperties sınıfı altındaki [özellikleri](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/#properties) görmek isteyebilirsiniz.

## **Sunum Özelliklerini Güncelle**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanıza olanak tanıyan [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) metodunu sağlar.

Aşağıda gösterilen belge özelliklerine sahip bir PowerPoint sunumu olduğunu varsayalım.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Bu kod örneği, bazı sunum özelliklerini nasıl düzenleyeceğinizi gösterir:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Belge özelliklerini değiştirme sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

Bir sunum ve güvenlik özellikleri hakkında daha fazla bilgi almak için aşağıdaki bağlantılar faydalı olabilir:

- [Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme](https://docs.aspose.com/slides/tr/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Sunumun Yazma Koruması (salt okunur) olup olmadığını Kontrol Etme](https://docs.aspose.com/slides/tr/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Sunumu Yüklemeden Önce Şifre Koruması Kontrol Etme](https://docs.aspose.com/slides/tr/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Sunumu Korumak için Kullanılan Şifreyi Doğrulama](https://docs.aspose.com/slides/tr/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunum seviyesinde [embedded-font bilgisine](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) bakın, ardından bu girişleri [içerik içinde gerçekten kullanılan yazı tipleri](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_fonts/) kümesiyle karşılaştırarak hangi yazı tiplerinin render için kritik olduğunu belirleyin.

**Dosyada gizli slaytların olup olduğunu ve sayısını hızlıca nasıl öğrenebilirim?**

[slide koleksiyonunu](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) döngüye alın ve her slaytın [görünürlük bayrağını](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/hidden/) inceleyin.

**Özel slayt boyutu ve yöneliminin kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Mevcut [slayt boyutunu](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slide_size/) ve yönelimini standart ön ayarlarla karşılaştırın; bu, yazdırma ve dışa aktarım davranışlarını önceden tahmin etmenize yardımcı olur.

**Grafiklerin dış veri kaynaklarına başvurup başvurmadığını hızlıca görmek için bir yol var mı?**

Evet. Tüm [grafikleri](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/) dolaşın, [veri kaynaklarını](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/data_source_type/) kontrol edin ve verinin içsel mi yoksa bağlantı temelli mi olduğunu, ayrıca kırık bağlantıları da not edin.

**Render ya da PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Her slayt için nesne sayılarını toplayın ve büyük resimler, şeffaflık, gölgeler, animasyonlar ve multimedya gibi öğeleri arayın; olası performans darboğazlarını işaretlemek için kabaca bir karmaşıklık puanı atayın.