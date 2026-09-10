---
title: Python Kullanarak Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/python-java/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- özel XML
- özel XML parçası
- XML meta verileri
- ItemId
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarında etiketleri ve özel XML verilerini yönetmeyi, eklemeyi, okumayı, güncellemeyi, denetlemeyi ve özel XML parçalarını kaldırmayı öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ın PowerPoint sunumlarında etiketler ve özel verilerle nasıl çalıştığını açıklar. Sunuma özgü veriler etiketler ya da özel XML parçaları olarak depolanabilir. Etiketler basit anahtar-değer dize çiftleridir, özel XML parçaları ise yapılandırılmış meta verileri ve uygulamaya özgü XML yüklerini depolayabilir.

Aspose.Slides, sunum, slayt ve şekil seviyelerinde özel XML parçalarını ekleme, okuma, güncelleme, denetleme ve kaldırma için API'ler sağlar. Özel XML parçaları, belge yönetimi tanımlayıcıları, iş akışı durumu, uyumluluk meta verileri, şablon bağlama verileri veya bir sunum içinde bulunan diğer yapılandırılmış uygulama verileri gibi bilgileri depolayan entegrasyonlar için yararlıdır.

## **Sunum Dosyalarında Veri Depolama**

PPTX dosyaları—`.pptx` uzantısına sahip dosyalar—PresentationML formatında depolanır ve bu, Office Open XML (OOXML) spesifikasyonunun bir parçasıdır. Office Open XML, sunum içeriği ve ilgili verileri depolamak için kullanılan paket yapısını ve ilişkileri tanımlar.

Bir sunum, ilişkilerle bağlanmış birden çok parçadan oluşur. Örneğin, bir slayt parçası tek bir slaytın içeriğini içerir ve ISO/IEC 29500 tarafından tanımlanan diğer parçalara açık ilişkiler sahip olabilir.

Özel veriler etiketler ([TagCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tagcollection/)) veya özel XML parçaları ([CustomXmlPartCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpartcollection/)) olarak depolanabilir. Her ikisi de [CustomData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customdata/) sınıfı aracılığıyla kullanılabilir.

{{% alert color="info" title="Note" %}}
Etiketler basit dize anahtar-değer çiftlerini depolar. Özel XML parçaları yapılandırılmış XML verilerini depolar ve bir sunum, slayt veya şekil ile ilişkilendirilebilir.
{{% /alert %}}

## **Özel XML Parçalarıyla Çalışma**

[CustomData.getCustomXmlParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customdata/#getCustomXmlParts) yöntemi, belirli bir sunum nesnesiyle ilişkili özel XML parçalarının koleksiyonunu döndürür. Örneğin:

- Sunumun [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customdata/#getCustomXmlParts) koleksiyonu, doğrudan sunumla ilişkili özel XML parçalarını içerir.
- Slaydın [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customdata/#getCustomXmlParts) koleksiyonu, belirli bir slaytla ilişkili özel XML parçalarını içerir.
- Şeklin [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customdata/#getCustomXmlParts) koleksiyonu, belirli bir şekille ilişkili özel XML parçalarını içerir.

Sunumda nerede ilişkilendirilmiş olursa olsun tüm özel XML parçalarını incelemeniz gerektiğinde [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getAllCustomXmlParts) kullanın.

### **Bir Sunuma Özel XML Parçası Ekleme**

XML verisini bir özel XML parça koleksiyonuna eklemek için [CustomXmlPartCollection.add](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpartcollection/#add) kullanın. XML geçerli ve boş olmamalıdır.

Aşağıdaki örnek, sunum seviyesindeki özel veri koleksiyonuna yapılandırılmış meta verileri ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add otomatik olarak bir tanımlayıcı atar. Gerekli olduğunda yalnızca belirli bir UUID belirleyin.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[add](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpartcollection/#add) yöntemi ayrıca XML'i bayt dizisi veya giriş akışı olarak kabul edebilir; bu, XML içeriği zaten ikili biçimde mevcut olduğunda faydalıdır.

### **Bir Slayta veya Şekle Özel XML Parçası Ekleme**

Özel XML verileri, tüm sunum yerine belirli bir slayt veya şekille ilişkilendirilebilir. Bu, meta verinin yalnızca bir nesneyi (örneğin bir şablon anahtarı, harici kayıt tanımlayıcısı veya bağlama bilgisi) tanımlaması gerektiğinde faydalıdır.

Aşağıdaki örnek, bir slayta bir özel XML parçası ve bir şekle başka bir özel XML parçası ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bir parçanın eklenme düzeyi, hangi nesnenin [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customdata/#getCustomXmlParts) koleksiyonunun bu parçaya ilişkin ilişkiyi içerdiğini belirler. Sunum seviyesindeki veri, belge genelindeki meta veri için uygundur; slayt seviyesindeki veri, belirli bir slayta ait bilgi için; şekil seviyesindeki veri ise tek bir şekle bağlı meta veri için uygundur.

### **Tüm Özel XML Parçalarını Listeleme ve Denetleme**

Bir sunumdan tüm özel XML parçalarını aldırmak için [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getAllCustomXmlParts) kullanın. Her [CustomXmlPart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/) tanımlayıcısını, XML içeriğini ve ilişkili ad alanı şemalarını gösterir.

Aşağıdaki örnek, tüm özel XML parçalarını ve bunların ad alanı şemalarını listeler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) özel XML parçasıyla ilişkili XML şemalarını döndürür. Bu bilgi, harici sistemler tarafından üretilen XML içeren sunumları denetlerken yararlı olabilir.

### **XML İçeriğini ve ItemId'yi Okuma ve Güncelleme**

XML'i UTF-8 dizesi olarak işlemek için [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#getXmlAsString) ve [setXmlAsString](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#setXmlAsString) kullanın; ham XML baytlarıyla çalışmak için ise [getXmlData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#getXmlData) ve [setXmlData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#setXmlData) kullanın.

[CustomXmlPart.getItemId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#getItemId) yöntemi, Office Open XML belgesindeki özel XML parçasını tanımlayan UUID'yi döndürür. Bir entegrasyon yeni bir tanımlayıcı gerektirdiğinde [setItemId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#setItemId) kullanın.

Aşağıdaki örnek, XML içeriğini ve tanımlayıcıyı günceller:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Mevcut XML'i metin olarak oku.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # XML'i UTF-8 dizesi olarak güncelle.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData, aynı XML içeriğini ham baytlar olarak sağlar.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Entegrasyon tarafından gerektiğinde tanımlayıcıyı değiştir.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

[setXmlAsString](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#setXmlAsString) veya [setXmlData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#setXmlData) çağırırken geçerli ve boş olmayan bir XML sağlayın. Uygulamanın çoğunlukla dizelerle mi yoksa bayt verileriyle mi çalıştığına bağlı olarak bir temsil biçimini kullanın.

### **Bir Özel XML Parçasını Kaldırma**

Aspose.Slides, özel XML verilerini kaldırmak için çeşitli yollar sunar:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#remove) özel XML parçasını sunumdan kaldırır.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpartcollection/#remove) bir özel XML parça koleksiyonundan belirli bir parçayı kaldırır.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpartcollection/#removeAt) belirtilen koleksiyon indeksindeki parçayı kaldırır.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpartcollection/#clear) belirli bir koleksiyondaki tüm parçaları kaldırır.

Aşağıdaki örnek, referans yoluyla bir sunum seviyesindeki özel XML parçasını kaldırır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Eğer zaten bir [CustomXmlPart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/) sahipseniz ve belirli bir koleksiyona yönelmek yerine bu parçayı sunumdan kaldırmak istiyorsanız, [CustomXmlPart.remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#remove) metodunu çağırın.

Bir öğeyi indeksle de kaldırabilirsiniz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Bir Koleksiyondan Tüm Özel XML Parçalarını Temizleme**

Belirli bir sunum nesnesiyle ilişkili tüm özel XML parçaları kaldırılmalıysa [clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpartcollection/#clear) kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpartcollection/#clear) yalnızca seçili koleksiyonu etkiler. Örneğin, bir slaytın koleksiyonunu temizlemek, sunum seviyesindeki veya şekil seviyesindeki koleksiyonları temizlemez.

Sunumdaki tüm özel XML parçalarını kaldırmak için [getAllCustomXmlParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getAllCustomXmlParts) üzerinden döngü oluşturup her parçayı kaldırın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bağlantılı veya Paylaşılan Özel XML Parçalarını Yönetme**

Bir Office Open XML sunumunda, aynı özel XML parçasına birden fazla sunum nesnesinden başvurulabilir. Örneğin, mevcut bir dosya birden çok slayt veya şekilden aynı temel özel XML parçasına ilişkiler içerebilir.

Paylaşılan bir parça, birden çok referansa sahip tek bir veri nesnesi olarak ele alınmalıdır:

- Onu [setXmlAsString](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#setXmlData) veya [setItemId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#setItemId) ile güncellemek, temel özel XML parçasını değiştirir; bu değişiklik parçanın başvurulduğu her yerde geçerli olur.
- [getItemId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#getItemId), nesne seviyesindeki koleksiyonları denetlerken aynı özel XML parçasını tanımlamak için kullanılabilir.
- Belirli bir [getCustomXmlParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customdata/#getCustomXmlParts) koleksiyonundan bir parçayı kaldırmak, o koleksiyondan siler. Parça tümüyle sunumdan kaldırılacaksa [CustomXmlPart.remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/#remove) kullanın.
- Paylaşılan bir parçayı silmeden veya değiştirmeden önce, diğer slaytların veya şekillerin hâlâ ona başvurup başvurmadığını belirlemek için nesne seviyesindeki koleksiyonları inceleyin.

[add](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpartcollection/#add) aşırı yüklemeleri, XML içeriğinden yeni bir özel XML parçası oluşturur; mevcut bir [CustomXmlPart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customxmlpart/) kabul etmez. Bu nedenle, paylaşılan ilişkiler genellikle zaten bu ilişkileri içeren sunumlar yüklendiğinde görülür.

Aşağıdaki örnek, `ItemId` ile sunum, slayt ve şekil seviyesindeki koleksiyonları denetler ve birden fazla yerden başvurulan parçaları raporlar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Bu tür bir denetim, harici sistemler tarafından oluşturulan sunumlarda özel XML verilerini değiştirmeden veya silmeden önce faydalıdır; çünkü aynı meta veri parçası birden fazla ilişkide yer alabilir.

## **Etiket Değerlerini Almak**

Slaytlarda, bir etiket [DocumentProperties.getKeywords](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getKeywords) yöntemine karşılık gelir. Bu örnek kod, Aspose.Slides for Python via Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) için etiket değerinin nasıl alınacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenizi sağlar. Bir etiket genellikle iki öğeden oluşur:

- özel özelliğin adı, örneğin `MyTag`;
- özel özelliğin değeri, örneğin `My Tag Value`.

Sunumları belirli bir kural veya özelliğe göre sınıflandırmanız gerektiğinde bu amaçla etiketler ekleyebilirsiniz. Örneğin, Kuzey Amerika ülkelerinden gelen sunumları sınıflandırmak istiyorsanız, bir Kuzey Amerika etiketi oluşturup ilgili ülkeyi değer olarak atayabilirsiniz.

Bu örnek kod, Aspose.Slides for Python via Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) üzerine etiket eklemenin nasıl yapılacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

Etiketler ayrıca bir [Slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) için de ayarlanabilir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Veya bireysel bir [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) için:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Kısıtlamalar**

[CustomData.getTags](https://reference.aspose.com/slides/tr/python-java/aspose.slides/customdata/#getTags) koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında saklanır. Sunum PDF'ye aktarıldığında bu etiketler PDF etiket yapısına **aktarılmaz**. Sonuç olarak, etiket olarak atanan özel bir tanımlayıcı, etiketli PDF'den alınamaz.

**Geçici Çözüm**: Nesnenin **Alt Text** özelliğinde (örneğin, değer `"MyId"` ile [Shape.setAlternativeText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#setAlternativeText)) özel bir tanımlayıcı depolayabilirsiniz. PDF'ye aktarıldıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**  
Evet. [tag collection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tagcollection/) [clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tagcollection/#clear) işlemini destekler; bu, tüm anahtar-değer çiftlerini bir kerede siler.

**Tüm koleksiyonu döndürmeden, adını bilerek tek bir etiketi nasıl silebilirim?**  
Etiketi anahtarıyla silmek için [tag collection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tagcollection/) üzerindeki [remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tagcollection/#remove) yöntemini kullanın.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**  
[tag collection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tagcollection/) üzerindeki [getNamesOfTags](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tagcollection/#getNamesOfTags) yöntemini kullanın; bu, tüm etiket adlarının bir dizisini döndürür.

**Özel XML parçalarının nerede depolandığına bakılmaksızın hepsini nasıl bulabilirim?**  
Sunumdaki tüm özel XML parçalarını almak için [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getAllCustomXmlParts) kullanın.

**Bir özel XML parçasını güncellemek için [getXmlAsString]/[setXmlAsString] mi yoksa [getXmlData]/[setXmlData] mi kullanmalıyım?**  
Uygulama UTF-8 XML metniyle çalışıyorsa [getXmlAsString] ve [setXmlAsString] kullanın. XML zaten bir bayt dizisi olarak mevcutsa veya ikili odaklı işleme daha uygunsa [getXmlData] ve [setXmlData] kullanın. Her iki temsil biçimi de aynı özel XML parçasının XML içeriğine atıfta bulunur.