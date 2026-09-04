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
- belge üst verileri
- üst verileri düzenle
- denetim dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET içinde sunum özelliklerini yönetin ve PowerPoint dosyalarınızda arama, marka oluşturma ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türlerinin her ikisi de Aspose.Slides API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [DocumentProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/) sınıfı aracılığıyla çalışmanıza olanak tanır. Bu sınıfın bir örneği, [Presentation.document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/document_properties/) özelliği tarafından döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" title="Not" %}}
Lütfen **Application** ve **Producer** alanlarına değer atayamayacağınızı unutmayın, çünkü Aspose Ltd. ve Aspose.Slides for Python via .NET x.x.x bu alanlarda görüntülenecektir.
{{% /alert %}} 

## **Sunum Özelliklerini Yönet**

Microsoft PowerPoint, sunum dosyalarına bazı özellikler ekleme özelliği sağlar. Bu belge özellikleri, belgelerle (sunum dosyaları) birlikte bazı yararlı bilgilerin depolanmasına olanak tanır. Belge özelliklerinin iki türü şunlardır:

- Sistem Tanımlı (Yerleşik) Özellikler
- Kullanıcı Tanımlı (Özel) Özellikler

**Yerleşik** özellikler, belge başlığı, yazarın adı, belge istatistikleri vb. gibi belgeye ilişkin genel bilgileri içerir. **Özel** özellikler, kullanıcılar tarafından **Ad/Değer** çiftleri olarak tanımlanan, hem adın hem de değerin kullanıcı tarafından belirlendiği özellikelerdir. Aspose.Slides for Python via .NET kullanarak, geliştiriciler yerleşik özelliklerin yanı sıra özel özelliklerin değerlerine de erişebilir ve değiştirebilir. Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye olanak tanır. Tek yapmanız gereken Office simgesine tıklamak ve ardından Microsoft PowerPoint 2007'de **Prepare | Properties | Advanced Properties** menü öğesini seçmektir. **Advanced Properties** menü öğesini seçtikten sonra, PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu açılır. **Properties Dialog** içinde **General, Summary, Statistics, Contents ve Custom** gibi birçok sekme sayfası olduğunu görebilirsiniz. Bu sekme sayfaları, PowerPoint dosyalarıyla ilgili farklı türde bilgileri yapılandırmaya izin verir. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

## **Şifreli Bir Sunumdan Genel Özellikleri Okuma**

Açma parolası genellikle hem sunum içeriğini hem de belge özelliklerini korur. Bir sunum, [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) `False` olarak ayarlandığında şifrelenmişse, belge özellikleri genel olarak kalır. Daha sonra bir uygulama, [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/only_load_document_properties/) `True` olarak ayarlayabilir ve açma parolasını sağlamadan genel üst verileri okuyabilir.

`only_load_document_properties`, Aspose.Slides'ın neyi yükleyeceğini kontrol eder; hiçbir şeyi şifre çözmez. Özellikler şifreleme içine dahil edilmişse, parolası olmadan yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yok sayılır ve tüm sunum yüklenir.

Aşağıdaki örnek, [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) üzerinden yükleme modunu doğrular ve ardından [Presentation.document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/document_properties/) aracılığıyla yerleşik özellikleri okur:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Bu modda, slayt içeriği yüklenmez. Slaytlar, ana slaytlar, yerleşimler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman `is_only_document_properties_loaded` kontrol etmelidir.

{{% alert color="warning" title="Güvenlik" %}}
Genel üst veriler, yazar adlarını, başlıkları, konuları, anahtar kelimeleri, şirket bilgilerini, yorumları ve özel değerleri ortaya çıkarabilir. Hassas özellikleri sunumla birlikte şifreleyin. Yalnızca indeksleme, sınıflandırma, arama veya belge yönetim sistemlerinin şifre olmadan erişim gerektirdiği durumlarda genel olarak bırakın.
{{% /alert %}}

## **Şifreli Bir Sunumun Özelliklerini Güncelleme**

Şifrelenmiş bir PPTX dosyası için, `only_load_document_properties` ile yüklenen bir sunum, genel üst verileri okumak için tasarlanmıştır. Aspose.Slides, bu yalnızca üst veri nesnesinden değiştirilen özellikleri kaydedemez çünkü genel özellikler, şifreli sunum içindeki ilgili verilerle tutarlı olmalıdır. Bu özelliklerin güncellenmesi doğru açma parolasını ve tam bir yüklemeyi gerektirir.

Aşağıdaki örnek, sunumu [LoadOptions.password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/password/) ile açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından şifrelemenin korunduğunu doğrulamak için [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/is_encrypted/) kullanır ve yeni değerleri doğrulamak için şifre olmadan genel üst verileri yeniden açar:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Bir uygulamaya sunum içeriğini şifre çözme veya yükleme izni verilmediyse, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okunabilir olarak ele almalıdır.

## **Yerleşik Özelliklere Erişim**

Bu özellikler **IDocumentProperties** nesnesi tarafından ortaya konulan: **Creator(Author)**, **Description**, **Keywords**, **Created** (Oluşturulma Tarihi), **Modified** (Değiştirilme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **Keywords**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**

```py
import aspose.slides as slides

# Sunumu temsil eden Presentation sınıfını örnekle
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Presentation ile ilişkili nesneye bir referans oluştur
    documentProperties = pres.document_properties

    # Yerleşik özellikleri görüntüle
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

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe yalnızca bir dize değeri atayabilir ve özellik değeri değişir. Aşağıda verilen örnekte, sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösterdik.

```py
import aspose.slides as slides

# Presentation'ı temsil eden Presentation sınıfını örnekle
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

Aspose.Slides for Python via .NET, geliştiricilerin sunum belge özellikleri için özel değerler eklemesine de izin verir. Aşağıda bir örnek, bir sunum için özel özelliklerin nasıl ayarlanacağını gösterir.

```py
import aspose.slides as slides

# Presentation sınıfını örnekle
with slides.Presentation() as presentation:
    # Belge özelliklerini alıyor
    documentProperties = presentation.document_properties

    # Özel özellikler ekleme
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Belirli bir indeksteki özellik adını alıyor
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Seçilen özelliği kaldırma
    documentProperties.remove_custom_property(getPropertyName)

    # Sunumu kaydetme
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for Python via .NET, geliştiricilerin özel özelliklerin değerlerine erişmesine de izin verir. Aşağıda bir örnek, bir sunum için bu özel özelliklerin tümüne nasıl erişileceğini ve değiştirileceğini gösterir.

```py
import aspose.slides as slides

# PPTX'i temsil eden Presentation sınıfını örnekle
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Presentation ile ilişkili document_properties nesnesine bir referans oluştur
    documentProperties = presentation.document_properties

    # Özel özelliklere eriş ve değiştir
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Özel özelliklerin adlarını ve değerlerini görüntüle
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Özel özelliklerin değerlerini değiştir
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Sunumunuzu bir dosyaya kaydedin
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value`, ikinci argüman olarak geçirilen tek öğeli liste üzerinden değeri döndürür ve saklanan değer, o listedeki mevcut öğenin tipine dönüştürülür. Yukarıdaki örnek `[""]` kullanır, bu yüzden dize özelliklerini okur; bir sayı olarak saklanan bir özelliği okumak için `[0]` gibi sayısal bir yer tutucu geçirin—aksi takdirde çağrı bir `InvalidCastException` hatası verir.

## **Denetim Dili Ayarlama**

Aspose.Slides, bir PowerPoint belgesi için denetim dilini ayarlamanıza olanak tanıyan `Language_Id` özelliğini ([PortionFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/) sınıfı tarafından sunulur) sağlar. Denetim dili, PowerPoint'te imla ve dilbilgisinin kontrol edildiği dildir.

Bu Python kodu, bir PowerPoint için denetim dilini nasıl ayarlayacağınızı gösterir:

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

    # denetim dilinin kimliğini ayarla
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

Aspose.Slides API'si aracılığıyla belge özellikleriyle nasıl çalışılacağını görmek için çevrimiçi uygulama olan [**Aspose.Slides Metadata**](https://products.aspose.app/slides/tr/metadata) deneyin:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli özellik tarafından izin veriliyorsa, değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

**Zaten var olan bir özel özelliği eklersem ne olur?**

Eğer zaten var olan bir özel özellik eklenirse, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides özelliğin değerini otomatik olarak günceller.

**Sunumu tam olarak yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) kullanın ve ardından [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/read_document_properties/) ile bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturmadan saklanan belge üst verilerini okuyun. Tam bir raporlama örneği ve format‑özel sınırlamalar için [Build a Lightweight Presentation Inventory](/slides/tr/python-net/examine-presentation/) sayfasına bakın.

**Şifreli bir sunumun genel özelliklerini açma parolasını bilmeden okuyabilir miyim?**

Evet. Sunum, `encrypt_document_properties` `False` olarak ayarlanmış şekilde şifrelenmiş olmalı ve `only_load_document_properties` `True` olarak ayarlanarak yüklenmelidir.

**Şifreli bir PPTX dosyasını yalnızca belge‑özellikleri modunda güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır, bu nedenle şifreli bir PPTX dosyasını güncellemek, doğru açma parolasını kullanarak tüm sunumun yüklenmesini gerektirir.