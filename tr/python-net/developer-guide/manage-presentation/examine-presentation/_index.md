---
title: Python'da Sunum Bilgilerini Al ve Güncelle
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/python-net/examine-presentation/
keywords:
- sunum biçimi
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
description: "Python kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri için."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum bilgilerini nasıl inceleyeceğinizi gösterir. Sunumun tam dosyasını yüklemeden geçerli biçimini nasıl belirleyeceğinizi, belge özelliklerini nasıl okuyacağınızı ve gerektiğinde bu özellikleri nasıl güncelleyeceğinizi açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/) API'lerine dayanmakta ve sunum meta verileriyle çalışmak için tipik operasyonları göstermektedir.

## **Sunum Biçimini Kontrol Et**

Bir sunum üzerinde çalışmaya başlamadan önce, o anki sunumun hangi biçimde (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumu yüklemeden bir sunumun biçimini kontrol edebilirsiniz. Aşağıdaki Python koduna bir göz atın:

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

[özellikleri]https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/#properties sınıfı altında görmek isteyebilirsiniz.

## **Sunum Özelliklerini Güncelle**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanıza izin veren [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) yöntemini sağlar.

Aşağıda gösterilen belge özelliklerine sahip bir PowerPoint sunumu olduğunu varsayalım.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Bu kod örneği, bazı sunum özelliklerini nasıl düzenleyeceğinizi gösterir:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Belge özelliklerini değiştirmenin sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

Bir sunum ve güvenlik nitelikleri hakkında daha fazla bilgi almak isterseniz aşağıdaki bağlantılar yararlı olabilir:

- [Password-Protect Presentations](/slides/tr/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/tr/python-net/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangi yazı tiplerinin gömülü olduğunu nasıl kontrol edebilirim?**  
Sunum seviyesindeki [embedded-font information](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) bölümüne bakın, ardından bu girişleri içerik boyunca kullanılan [fonts actually used across content](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_fonts/) kümesiyle karşılaştırarak hangi yazı tiplerinin render için kritik olduğunu belirleyin.

**Dosyada gizli slaytların olup olmadığını ve kaç tane olduğunu nasıl hızlı bir şekilde öğrenebilirim?**  
[slide collection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) üzerinden döngü kurun ve her bir slaydın [visibility flag](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/hidden/) özelliğini inceleyin.

**Özel slayt boyutu ve yöneliminin kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**  
Evet. Mevcut [slide size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slide_size/) ve yönelimi standart ön ayarlarla karşılaştırın; bu, baskı ve dışa aktarma davranışlarını öngörmeye yardımcı olur.

**Grafiklerin dış veri kaynaklarına başvurup başvurmadığını hızlı bir şekilde görebilir miyim?**  
Evet. Tüm [charts](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/) öğelerini gezinin, [data source](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/data_source_type/) tipini kontrol edin ve verinin dahili mi yoksa bağlantı‑tabanlı mı olduğunu, kırık bağlantılar olup olmadığını not edin.

**Render süresini veya PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**  
Her slayt için nesne sayılarını toplayın, büyük resimler, şeffaflık, gölgeler, animasyonlar ve multimedya öğelerini inceleyin; potansiyel performans sorunlarını işaretlemek için kabaca bir karmaşıklık puanı atayın.