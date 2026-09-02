---
title: Python ile Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veriler
type: docs
weight: 300
url: /tr/python-net/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- özel XML
- özel XML bölümü
- XML meta verileri
- ItemId
- etiket ekle
- değer çiftleri
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarında etiketleri ve özel XML verilerini yönetmeyi, ekleme, okuma, güncelleme, denetleme ve özel XML bölümlerini kaldırma dahil olmak üzere öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'in PowerPoint sunumlarında etiketler ve özel verilerle nasıl çalıştığını açıklar. Sunuma özgü veriler etiketler veya özel XML bölümleri olarak depolanabilir. Etiketler basit anahtar-değer dize çiftleridir, özel XML bölümleri ise yapılandırılmış meta verileri ve uygulamaya özgü XML yüklerini saklayabilir.

Aspose.Slides, sunum, slayt ve şekil düzeyinde özel XML bölümlerini ekleme, okuma, güncelleme, denetleme ve kaldırma için API'ler sağlar. Özel XML bölümleri, belge yönetimi kimlikleri, iş akışı durumu, uyumluluk meta verileri, şablon bağlama verileri veya sunum içinde depolanacak diğer yapılandırılmış uygulama verileri gibi bilgileri saklayan bütünleşmeler için faydalıdır.

## **Sunum Dosyalarında Veri Depolama**

`.pptx` uzantılı PPTX dosyaları, Office Open XML spesifikasyonunun bir parçası olan PresentationML formatında saklanır. Office Open XML, sunum içeriği ve ilgili verileri depolamak için kullanılan paket yapısını ve ilişkileri tanımlar.

Bir sunum, ilişkilerle bağlanmış birden çok bölüm içerir. Örneğin, bir slayt bölümü tek bir slaytın içeriğini barındırır ve ISO/IEC 29500 tarafından tanımlanan diğer bölümlere açık ilişkiler içerebilir.

Özel veriler etiketler ([TagCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/tagcollection/)) veya özel XML bölümleri ([CustomXmlPartCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customxmlpartcollection/)) olarak saklanabilir. Her ikisi de [`CustomData`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customdata/) sınıfı üzerinden erişilebilir.

{{% alert color="primary" %}}
Etiketler basit dize anahtar‑değer çiftlerini depolar. Özel XML bölümleri yapılandırılmış XML verilerini depolar ve bir sunuma, slayta veya şekle ilişkilendirilebilir.
{{% /alert %}}

## **Özel XML Bölümleriyle Çalışma**

[`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customdata/custom_xml_parts/) özelliği, belirli bir sunum nesnesiyle ilişkilendirilmiş özel XML bölümlerinin koleksiyonunu döndürür. Örnek:

- `presentation.custom_data.custom_xml_parts` sunumun kendisiyle ilişkilendirilmiş özel XML bölümlerini içerir.
- `slide.custom_data.custom_xml_parts` belirli bir slaytla ilişkilendirilmiş özel XML bölümlerini içerir.
- `shape.custom_data.custom_xml_parts` belirli bir şekille ilişkilendirilmiş özel XML bölümlerini içerir.

Sunumda nerede ilişkilendirilmiş olurlarsa olsunlar tüm özel XML bölümlerini incelemeniz gerektiğinde [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/all_custom_xml_parts/) kullanın.

### **Bir Sunuma Özel XML Bölümü Ekleme**

XML verisini özel XML bölüm koleksiyonuna eklemek için [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customxmlpartcollection/add/) yöntemini kullanın. XML geçerli ve boş olmamalıdır.

Aşağıdaki örnek, sunum düzeyindeki özel veri koleksiyonuna yapılandırılmış meta veri ekler:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # ekleme otomatik olarak bir tanımlayıcı atar. Belirli bir GUID yalnızca gerektiğinde ayarlanır.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

`add` yöntemi ayrıca XML'i bir bayt dizisi veya akış olarak kabul edebilir; bu, XML içeriği zaten ikili formda mevcut olduğunda faydalıdır.

### **Bir Slayt veya Şekle Özel XML Bölümü Ekleme**

Özel XML verisi, tüm sunum yerine belirli bir slayt veya şekille ilişkilendirilebilir. Bu, meta verinin yalnızca tek bir nesneyi (örneğin bir şablon anahtarı, dış kayıt kimliği veya bağlama bilgisi) tanımladığı durumlarda kullanışlıdır.

Aşağıdaki örnek bir slayta bir özel XML bölümü, bir şekle ise başka bir özel XML bölümü ekler:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Bir bölümün eklendiği seviye, `custom_data.custom_xml_parts` koleksiyonunun hangi nesnenin ilişkisini içerdiğini belirler. Sunum‑düzeyi veri, belge geneli meta verileri için uygundur; slayt‑düzeyi veri belirli bir slayta ait bilgiler için; şekil‑düzeyi veri ise tek bir şekle bağlı meta veriler için kullanılır.

### **Tüm Özel XML Bölümlerini Listeleme ve Denetleme**

Sunumdan tüm özel XML bölümlerini almak için [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/all_custom_xml_parts/) kullanın. Her [`CustomXmlPart`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customxmlpart/) kimliğini, XML içeriğini ve ilişkili ad alanı şemalarını sağlar.

Aşağıdaki örnek tüm özel XML bölümlerini ve bunların ad alanı şemalarını listeler:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customxmlpart/namespace_schemas/) yöntemi, özel XML bölümüyle ilişkili XML şemalarını döndürür. Bu bilgi, dış sistemler tarafından üretilen XML içeren sunumların denetlenmesinde yararlı olabilir.

### **XML İçeriğini ve ItemId'yi Okuma ve Güncelleme**

XML ile UTF‑8 dize olarak çalışmak için [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customxmlpart/xml_as_string/), ham XML baytlarıyla çalışmak için ise [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customxmlpart/xml_data/) kullanın. Her iki özellik de okunabilir ve güncellenebilir.

[`CustomXmlPart.item_id`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customxmlpart/item_id/) özelliği, özel XML bölümünü Office Open XML belgesinde tanımlayan GUID'i içerir. Entegrasyon yeni bir kimlik gerektirdiğinde bu değer değiştirilebilir.

Aşağıdaki örnek XML içeriğini ve kimliği günceller:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Mevcut XML'i metin olarak okuyun.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # XML'i UTF-8 dizesi olarak güncelleyin.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data aynı XML içeriğini ham baytlar olarak sağlar.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Entegrasyon tarafından gerektiğinde tanımlayıcıyı değiştirin.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

`xml_as_string` veya `xml_data` atarken geçerli ve boş olmayan XML sağlamalısınız. Uygulamanız temel olarak dizelerle mi yoksa bayt verisiyle mi çalışıyorsa ona göre bir temsil seçin.

### **Bir Özel XML Bölümünü Kaldırma**

Aspose.Slides, özel XML verilerini kaldırmak için çeşitli yöntemler sunar:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customxmlpart/remove/) özel XML bölümünü sunumdan kaldırır.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customxmlpartcollection/remove/) belirli bir bölümü koleksiyondan kaldırır.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customxmlpartcollection/remove_at/) belirtilen koleksiyon indeksindeki bölümü kaldırır.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/customxmlpartcollection/clear/) belirli bir koleksiyondaki tüm bölümleri kaldırır.

Aşağıdaki örnek bir sunum‑düzeyi özel XML bölümünü referansla kaldırır:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Zaten bir `CustomXmlPart` nesneniz varsa ve onu belirli bir koleksiyona yönlendirmek yerine sunumdan kaldırmak istiyorsanız `custom_xml_part.remove()` çağırın.

Ayrıca bir öğeyi indeksle de kaldırabilirsiniz:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Bir Koleksiyondaki Tüm Özel XML Bölümlerini Temizleme**

Belirli bir sunum nesnesiyle ilişkili tüm özel XML bölümleri kaldırılacaksa `clear` yöntemini kullanın.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` yalnızca seçili koleksiyonu etkiler. Örneğin, bir slaytın koleksiyonunu temizlemek, sunum‑düzeyi veya şekil‑düzeyi koleksiyonlarını temizlemez.

Sunumdaki tüm özel XML bölümlerini kaldırmak için `all_custom_xml_parts` üzerinden döngü kurup her bölümü kaldırın:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Bağlantılı veya Paylaşılan Özel XML Bölümlerini Yönetme**

Office Open XML bir sunumunda aynı özel XML bölümü birden çok sunum nesnesi tarafından referans alınabilir. Örneğin, mevcut bir dosya birden çok slayt veya şekilden aynı temel özel XML bölümüne ilişki içerebilir.

Paylaşılan bir bölüm, birden çok referansla tek bir veri nesnesi olarak ele alınmalıdır:

- `xml_as_string`, `xml_data` veya `item_id` güncellenirse temel özel XML bölümü değişir; değişiklik bölümü referans aldıkları her yerde görülür.
- `item_id`, nesne‑düzeyi koleksiyonları denetlerken aynı özel XML bölümünü tanımlamak için kullanılabilir.
- Belirli bir `custom_xml_parts` koleksiyonundan bir bölümü kaldırmak, sadece o koleksiyonu etkiler. Bölümün tamamen sunumdan kaldırılması gerekiyorsa `CustomXmlPart.remove()` kullanın.
- Paylaşılan bir bölümü silmeden veya değiştirmeden önce, diğer slayt veya şekillerin hâlâ referans verip vermediğini belirlemek için nesne‑düzeyi koleksiyonları inceleyin.

`add` aşırı yüklemeleri, XML içeriğinden yeni bir özel XML bölümü oluşturur; mevcut bir `CustomXmlPart` kabul etmez. Bu nedenle paylaşılan ilişkiler genellikle bölümleri zaten içeren sunumlar yüklendiğinde ortaya çıkar.

Aşağıdaki örnek, `item_id` ile sunum, slayt ve şekil düzeyindeki koleksiyonları denetler ve birden çok yerden referans verilen bölümleri raporlar:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Bu tür bir denetim, dış sistemler tarafından oluşturulan sunumlarda özel XML verileri değiştirilmeden veya silinmeden önce faydalıdır; aynı meta veri bölümü birden çok ilişki içinde yer alabilir.

## **Etiket Değerlerini Alma**

Slaytlarda bir etiket, `DocumentProperties.keywords` özelliğine karşılık gelir. Aşağıdaki örnek, .NET üzerinden Python için Aspose.Slides kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) üzerindeki etiket değerini nasıl alacağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenizi sağlar. Bir etiket tipik olarak iki öğeden oluşur:

- özel özelliğin adı, örneğin `MyTag`;
- özel özelliğin değeri, örneğin `My Tag Value`.

Sunumları belirli bir kural veya özelliğe göre sınıflandırmanız gerekiyorsa, bu amaçla etiketler ekleyebilirsiniz. Örneğin, Kuzey Amerika ülkelerinden gelen sunumları sınıflandırmak istiyorsanız bir “North American” etiketi oluşturup ilgili ülkeyi değer olarak atayabilirsiniz.

Aşağıdaki örnek, Aspose.Slides for Python via .NET kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) üzerine etiket eklemeyi gösterir:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Etiketler ayrıca bir [Slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/) için de ayarlanabilir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Veya bireysel bir [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) için:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Sınırlamalar**

`custom_data.tags` koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında depolanır. Sunum PDF’ye dışa aktarıldığında bu etiketler **PDF etiket yapısına** aktarılmaz. Dolayısıyla, bir etikette saklanan özel kimlik PDF’den elde edilemez.

**Çözüm**: Nesnenin **Alt Text** (ör. `shape.alternative_text = "MyId"`) özelliğinde bir özel kimlik saklayabilirsiniz. PDF’ye dışa aktarıldıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**

Evet. [etiket koleksiyonu](https://reference.aspose.com/slides/tr/python-net/aspose.slides/tagcollection/) bir [clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides/tagcollection/clear/) işlemini destekler; bu işlem tüm anahtar‑değer çiftlerini bir anda siler.

**Tüm koleksiyonu dolaşmadan adıyla tek bir etiketi nasıl silerim?**

[TagCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/tagcollection/) üzerinde `remove(name)` metodunu kullanarak etiketi anahtarıyla silebilirsiniz.

**Analitik veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**

[etiket koleksiyonu](https://reference.aspose.com/slides/tr/python-net/aspose.slides/tagcollection/) üzerinde `get_names_of_tags` metodunu kullanın; bu, tüm etiket adlarını bir dizi olarak döndürür.

**Özel XML bölümlerini, nerede depolandıklarından bağımsız olarak nasıl bulabilirim?**

Sunum içindeki tüm özel XML bölümlerini almak için [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/all_custom_xml_parts/) kullanın.

**Bir özel XML bölümünü güncellerken `xml_as_string` mi yoksa `xml_data` mı kullanmalıyım?**

Uygulama UTF‑8 XML metniyle çalışıyorsa `xml_as_string` kullanın. XML zaten bir bayt dizisi olarak mevcutsa veya ikili işlem daha uygunsa `xml_data` kullanın. Her iki özellik de aynı özel XML bölümünün içeriğini temsil eder.