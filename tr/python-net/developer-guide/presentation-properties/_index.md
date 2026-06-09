---
title: Python ile Sunum Özelliklerini Yönet
linktitle: Sunum Özellikleri
type: docs
weight: 70
url: /tr/python-net/presentation-properties/
keywords:
- PowerPoint özellikleri
- sunum özellikleri
- belge özellikleri
- yerleşik özellikler
- özel özellikler
- gelişmiş özellikler
- özellikleri yönet
- özellikleri değiştir
- belge üstverisi
- üstveri düzenle
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET içinde sunum özelliklerinde uzmanlaşın ve PowerPoint dosyalarınızda arama, marka oluşturma ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türlerinin her ikisine de Aspose.Slides API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [DocumentProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/) sınıfı aracılığıyla çalışmanıza olanak tanır. Bu sınıfın bir örneği, [Presentation.document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/document_properties/) özelliği tarafından döndürülür. Bu örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="primary" %}} 
Lütfen **Application** ve **Producer** alanlarına değer atayamazsınız, çünkü Aspose Ltd. ve Aspose.Slides for Python via .NET x.x.x bu alanlarda görüntülenecektir.
{{% /alert %}} 

## **Sunum Özelliklerini Yönet**

Microsoft PowerPoint, sunum dosyalarına bazı özellikler ekleme özelliği sağlar. Bu belge özellikleri, belgelerle (sunum dosyaları) birlikte bazı yararlı bilgilerin saklanmasına olanak tanır. Aşağıdaki gibi iki tür belge özelliği vardır

- Sistem Tanımlı (Yerleşik) Özellikler
- Kullanıcı Tanımlı (Özel) Özellikler

**Yerleşik** özellikler, belge başlığı, yazar adı, belge istatistikleri vb. gibi genel bilgileri içerir. **Özel** özellikler, kullanıcılar tarafından **Ad/Değer** çiftleri olarak tanımlanan, hem adın hem de değerin kullanıcı tarafından belirlendiği özelliklerdir. Aspose.Slides for Python via .NET kullanılarak, geliştiriciler yerleşik özelliklerin ve özel özelliklerin değerlerine erişebilir ve bunları değiştirebilir. Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye izin verir. Tek yapmanız gereken Office simgesine tıklamak ve ardından Microsoft PowerPoint 2007'de **Prepare | Properties | Advanced Properties** menü öğesini seçmektir. **Advanced Properties** menü öğesini seçtikten sonra, PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu açılır. **Properties Dialog** içinde, **General, Summary, Statistics, Contents ve Custom** gibi birçok sekme sayfası olduğunu görebilirsiniz. Bu sekme sayfalarının tümü, PowerPoint dosyalarıyla ilgili farklı türde bilgileri yapılandırmaya olanak tanır. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

## **Yerleşik Özelliklere Erişim**
Bu özellikler, **IDocumentProperties** nesnesi tarafından ortaya çıkarılan: **Creator(Author)**, **Description**, **Keywords**, **Created** (Oluşturulma Tarihi), **Modified** (Değiştirilme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **Keywords**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title** içerir.
```py
import aspose.slides as slides

# Sunumu temsil eden Presentation sınıfını örnekleyin
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Presentation ile ilişkili nesneye bir referans oluştur
    documentProperties = pres.document_properties

    # Yerleşik özellikleri göster
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Yerleşik Özellikleri Değiştirme**

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe sadece bir dize değeri atayarak özelliğin değeri değiştirilebilir. Aşağıdaki örnekte, sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösterdik.
```py
import aspose.slides as slides

# Sunumu temsil eden Presentation sınıfını örnekleyin
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Presentation ile ilişkili nesneye bir referans oluştur
    documentProperties = presentation.document_properties

    # Yerleşik özellikleri ayarla
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Sunumunuzu bir dosyaya kaydedin
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Özel Sunum Özellikleri Ekleme**

Aspose.Slides for Python via .NET, geliştiricilerin sunum belge özellikleri için özel değerler eklemesine de olanak tanır. Aşağıda bir örnek verilmiştir; bu örnek bir sunum için özel özelliklerin nasıl ayarlanacağını gösterir.
```py
import aspose.slides as slides

# Presentation sınıfını örnekleyin
with slides.Presentation() as presentation:
    # Belge Özelliklerini Alıyor
    documentProperties = presentation.document_properties

    # Özel özellikler ekleniyor
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Belirli bir indeksteki özellik adını alıyor
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Seçilen özelliği kaldırıyor
    documentProperties.remove_custom_property(getPropertyName)

    # Sunumu kaydediyor
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for Python via .NET, geliştiricilerin özel özelliklerin değerlerine erişmesine de olanak tanır. Aşağıda bir örnek verilmiştir; bu örnek bir sunum için tüm bu özel özelliklere nasıl erişileceğini ve nasıl değiştirileceğini gösterir.
```py
import aspose.slides as slides

# PPTX'i temsil eden Presentation sınıfını örnekleyin
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Presentation ile ilişkili document_properties nesnesine bir referans oluştur
    documentProperties = presentation.document_properties

    # Özel özelliklere eriş ve değiştir
    for i in range(documentProperties.count_of_custom_properties):
        # Özel özelliklerin adlarını ve değerlerini göster
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Özel özelliklerin değerlerini değiştir
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # Sunumunuzu bir dosyaya kaydedin
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Düzeltme Dilini Ayarlama**

Aspose.Slides, bir PowerPoint belgesi için düzeltme dilini ayarlamanıza imkan tanıyan `Language_Id` özelliğini ([PortionFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/) sınıfı aracılığıyla) sunar. Düzeltme dili, PowerPoint'te yazım ve dilbilgisi denetiminin yapıldığı dildir.

Bu Python kodu, bir PowerPoint için düzeltme dilini nasıl ayarlayacağınızı gösterir:
```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # bir düzeltme dilinin kimliğini ayarla
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Varsayılan Dili Ayarlama**

Bu Python kodu, tüm bir PowerPoint sunumu için varsayılan dili nasıl ayarlayacağınızı gösterir:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **Canlı Örnek**

Aspose.Slides API aracılığıyla belge özellikleriyle nasıl çalışılacağını görmek için [**Aspose.Slides Metadata**](https://products.aspose.app/slides/tr/metadata) çevrimiçi uygulamayı deneyin:

[![PowerPoint Metaverilerini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli özellik izin veriyorsa değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

**Zaten mevcut olan bir özel özelliği eklersem ne olur?**

Zaten mevcut bir özel özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides özelliğin değerini otomatik olarak günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet, [PresentationFactory](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/) sınıfının [get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) metodunu kullanarak sunumu tamamen yüklemeden sunum özelliklerine erişebilirsiniz. Ardından, [PresentationInfo](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/) sınıfının sağladığı [read_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/read_document_properties/) metodunu kullanarak özellikleri verimli bir şekilde okuyabilir, belleği tasarruf edebilir ve performansı artırabilirsiniz.