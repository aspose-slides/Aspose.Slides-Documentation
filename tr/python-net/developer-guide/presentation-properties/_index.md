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
- belge meta verileri
- meta verileri düzenle
- yazım denetimi dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'te sunum özelliklerini ustaca yönetin ve PowerPoint dosyalarınızda aramayı, markalaşmayı ve iş akışını sadeleştirin."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu iki özellik türüne Aspose.Slides API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle **DocumentProperties** sınıfı aracılığıyla çalışmanıza olanak tanır. Bu sınıfın bir örneği, **Presentation.document_properties** özelliği tarafından döndürülür. Aşağıdaki örnekler bu özellikleri okuma, değiştirme ve yönetme yöntemlerini gösterir.

{{% alert color="info" title="Note" %}}
Lütfen **Application** ve **Producer** alanlarına değer atayamayacağınızı unutmayın; çünkü Aspose Ltd. ve Aspose.Slides for Python via .NET x.x.x bu alanlarda görüntülenecektir.
{{% /alert %}} 

## **Sunum Özelliklerini Yönetin**

Microsoft PowerPoint, sunum dosyalarına bazı özellikler ekleme özelliği sunar. Bu belge özellikleri, belgelerle (sunum dosyaları) birlikte kullanılabilecek faydalı bilgiler depolar. Aşağıdaki iki çeşit belge özelliği vardır:

- Sistem Tanımlı (Yerleşik) Özellikler
- Kullanıcı Tanımlı (Özel) Özellikler

**Yerleşik** özellikler, belge başlığı, yazar adı, belge istatistikleri gibi genel bilgileri içerir. **Özel** özellikler ise kullanıcı tarafından **Ad/Değer** çiftleri olarak tanımlanan, hem adın hem de değerin kullanıcı tarafından belirlendiği özelliklerdir. Aspose.Slides for Python via .NET kullanarak geliştiriciler, yerleşik ve özel özelliklerin değerlerine erişebilir ve bu değerleri değiştirebilir. Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye izin verir. Tek yapmanız gereken Office simgesine tıklayıp **Prepare | Properties | Advanced Properties** menü öğesini seçmektir. **Advanced Properties** menü öğesini seçtiğinizde, PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu açılır. **Properties Dialog** içinde **General, Summary, Statistics, Contents ve Custom** gibi birçok sekme sayfası bulunduğunu görebilirsiniz. Bu sekme sayfaları, PowerPoint dosyalarıyla ilgili farklı bilgi türlerini yapılandırmanıza olanak tanır. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

## **Yerleşik Özelliklere Erişme**
**IDocumentProperties** nesnesi tarafından ortaya konan bu özellikler şunlardır: **Creator(Author)**, **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** ve **Title**  
```py
import aspose.slides as slides

# Sunumu temsil eden Presentation sınıfının bir örneğini oluştur
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
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

Sunum dosyalarının yerleşik özelliklerini değiştirmek, bu özelliklere erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe bir dize değeri atayabilirsiniz; böylece özellik değeri güncellenir. Aşağıdaki örnekte, sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimiz gösterilmiştir.

```py
import aspose.slides as slides

# Presentation'ı temsil eden Presentation sınıfının bir örneğini oluştur
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
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

Aspose.Slides for Python via .NET, geliştiricilerin sunum belge özellikleri için özel değerler eklemesine de olanak tanır. Aşağıdaki örnek, bir sunum için özel özelliklerin nasıl ayarlanacağını göstermektedir.

```py
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluştur
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

## **Özel Özelliklere Erişme ve Değiştirme**

Aspose.Slides for Python via .NET, geliştiricilerin özel özelliklerin değerlerine erişmesine de izin verir. Aşağıdaki örnek, bir sunumun tüm özel özelliklerine nasıl erişip bunları değiştirebileceğinizi gösterir.

```py
import aspose.slides as slides

# PPTX'yi temsil eden Presentation sınıfının bir örneğini oluştur
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Presentation ile ilişkili document_properties nesnesine bir referans oluştur
    documentProperties = presentation.document_properties

    # Özel özelliklere eriş ve değiştir
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Özel özelliklerin adlarını ve değerlerini göster
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Özel özelliklerin değerlerini değiştir
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Sunumunuzu bir dosyaya kaydedin
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` ikinci argüman olarak verilen tek öğeli liste üzerinden değeri döndürür ve saklanan değer, listede zaten bulunan öğenin tipine dönüştürülür. Yukarıdaki örnek `[""]` kullanır, bu yüzden dize özellikleri okunur; bir sayısal değer okunacaksa, `[0]` gibi sayısal bir yer tutucu geçirilmelidir—aksi takdirde çağrı bir `InvalidCastException` fırlatır.

## **Yazım Denetimi Dili Ayarlama**

Aspose.Slides, **PortionFormat** sınıfı tarafından ortaya konan **Language_Id** özelliği aracılığıyla bir PowerPoint belgesi için yazım denetimi dilini ayarlamanıza olanak tanır. Yazım denetimi dili, PowerPoint'te imla ve dilbilgisi denetiminin yapılacağı dildir.

Bu Python kodu, bir PowerPoint için yazım denetimi dilinin nasıl ayarlanacağını gösterir:

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # yazım denetimi dilinin kimliğini ayarla
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Varsayılan Dil Ayarlama**

Bu Python kodu, tüm bir PowerPoint sunumu için varsayılan dilin nasıl ayarlanacağını gösterir:

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

Aspose.Slides Metadata çevrimiçi uygulamasını deneyerek Aspose.Slides API'si aracılığıyla belge özellikleriyle nasıl çalışılacağını görebilirsiniz:

[![PowerPoint Meta Verilerini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli bir özellik izin veriyorsa, değerlerini değiştirebilir veya boş bir değere ayarlayabilirsiniz.

**Zaten var olan bir özel özelliği eklersem ne olur?**

Zaten var olan bir özel özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak özelliğin değerini günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. **PresentationFactory.get_presentation_info** kullanıp ardından **PresentationInfo.read_document_properties** ile bir **Presentation** örneği oluşturmadan depolanmış belge meta verilerini okuyabilirsiniz. Tam bir raporlama örneği ve format‑spesifik sınırlamalar için [Build a Lightweight Presentation Inventory](/slides/tr/python-net/examine-presentation/) bölümüne bakın.