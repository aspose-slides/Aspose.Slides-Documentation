---
title: C++ Kullanarak Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/cpp/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- özel XML
- özel XML bölümü
- XML meta verileri
- ItemId
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint sunumlarında etiketleri ve özel XML verilerini yönetmeyi, ekleme, okuma, güncelleme, denetleme ve özel XML bölümlerini kaldırmayı öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'in PowerPoint sunumlarında etiketler ve özel verilerle nasıl çalıştığını açıklar. Sunuma özgü veriler etiketler veya özel XML bölümleri olarak saklanabilir. Etiketler basit anahtar‑değer dize çiftleridir, özel XML bölümleri ise yapılandırılmış meta verileri ve uygulamaya özgü XML yüklerini depolayabilir.

Aspose.Slides, sunum, slayt ve şekil düzeylerinde özel XML bölümlerini ekleme, okuma, güncelleme, denetleme ve kaldırma için API’ler sağlar. Özel XML bölümleri, belge yönetimi kimlikleri, iş akışı durumu, uyumluluk meta verileri, şablon bağlama verileri veya bir sunum içinde saklanan diğer yapılandırılmış uygulama verileri gibi bilgileri depolayan entegrasyonlar için yararlıdır.

## **Sunum Dosyalarında Veri Depolama**

`.pptx` uzantılı PPTX dosyaları, Office Open XML (OOXML) spesifikasyonunun bir parçası olan PresentationML formatında depolanır. Office Open XML, sunum içeriği ve ilgili verilerin saklanması için paket yapısını ve ilişkileri tanımlar.

Bir sunum, ilişkilerle bağlanmış birden çok parçadan oluşur. Örneğin, bir slayt parçası tek bir slaydın içeriğini barındırır ve ISO/IEC 29500 tarafından tanımlanan diğer parçalara açık ilişkileri olabilir.

Özel veriler etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itagcollection/)) veya özel XML bölümleri ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpartcollection/)) olarak saklanabilir. Her ikisi de [`ICustomData`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomdata/) arabirimi üzerinden elde edilir.

{{% alert color="primary" %}}

Etiketler basit dize anahtar‑değer çiftlerini saklar. Özel XML bölümleri yapılandırılmış XML verilerini saklar ve bir sunuma, slayta veya şekle ilişkilendirilebilir.

{{% /alert %}}

## **Özel XML Bölümleriyle Çalışma**

[`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomdata/get_customxmlparts/) yöntemi, belirli bir sunum nesnesiyle ilişkili özel XML bölümleri koleksiyonunu döndürür. Örnek:

- `presentation->get_CustomData()->get_CustomXmlParts()` sunumun kendisiyle ilişkili özel XML bölümlerini içerir.
- `slide->get_CustomData()->get_CustomXmlParts()` belirli bir slaytla ilişkili özel XML bölümlerini içerir.
- `shape->get_CustomData()->get_CustomXmlParts()` belirli bir şekille ilişkili özel XML bölümlerini içerir.

Sunumda nerede olurlarsa olsunlar tüm özel XML bölümlerini incelemeniz gerektiğinde [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_allcustomxmlparts/) yöntemini kullanın.

### **Bir Sunuma Özel XML Bölümü Ekleme**

XML verisini bir özel XML bölümü koleksiyonuna eklemek için [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpartcollection/add/) yöntemini kullanın. XML geçerli ve boş olmamalıdır.

Aşağıdaki örnek, sunum‑düzeyindeki özel veri koleksiyonuna yapılandırılmış meta veri ekler:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add otomatik olarak bir tanımlayıcı atar. Belirli bir GUID yalnızca gerektiğinde ayarlanır.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

`Add` yöntemi ayrıca XML’i byte dizisi veya akış olarak da kabul edebilir; bu, XML içeriği zaten ikili biçimde mevcut olduğunda faydalıdır.

### **Bir Slayta veya Şekle Özel XML Bölümü Ekleme**

Özel XML verisi, tüm sunum yerine belirli bir slayt veya şekille ilişkilendirilebilir. Bu, meta verinin yalnızca bir nesneyi (ör. şablon anahtarı, dış kayıt kimliği veya bağlama bilgisi) tanımlaması gerektiğinde kullanışlıdır.

Aşağıdaki örnek, bir slayta bir özel XML bölümü ve bir şekle bir başka özel XML bölümü ekler:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

Bir parçanın eklendiği seviye, hangi nesnenin `get_CustomData()->get_CustomXmlParts()` koleksiyonunun bu parçayla ilişkili olduğunu belirler. Sunum‑düzeyindeki veri belge‑geneli meta veri için, slayt‑düzeyindeki veri belirli bir slayta ait bilgi için ve şekil‑düzeyindeki veri bireysel bir şekle bağlı meta veri için uygundur.

### **Tüm Özel XML Bölümlerini Listeleme ve Denetleme**

Tüm özel XML bölümlerini elde etmek için [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_allcustomxmlparts/) yöntemini kullanın. Her [`ICustomXmlPart`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpart/) kimliğini, XML içeriğini ve ilişkili ad alanı şemalarını ortaya koyar.

Aşağıdaki örnek, tüm özel XML bölümlerini ve ad alanı şemalarını listeler:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) yöntemi, özel XML bölümüyle ilişkilendirilmiş XML şemalarını döndürür. Bu bilgi, dış sistemler tarafından üretilen XML içeren sunumları denetlerken faydalı olabilir.

### **XML İçeriğini ve ItemId’yi Okuma ve Güncelleme**

XML’i UTF‑8 dize olarak işlemek için [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) ve `set_XmlAsString`; ham XML baytlarıyla çalışmak için ise [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpart/get_xmldata/) ve `set_XmlData` kullanılabilir. Her iki temsili de okunup güncellenebilir.

[`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpart/get_itemid/) yöntemi, özel XML bölümünü Office Open XML belgesinde tanımlayan GUID’i döndürür. Entegrasyon yeni bir kimlik gerektirdiğinde `set_ItemId` ile bu kimlik de değiştirilebilir.

Aşağıdaki örnek, XML içeriğini ve kimliği günceller:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// Mevcut XML'yi metin olarak oku.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// XML'yi UTF-8 dizesi olarak güncelle.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData aynı XML içeriğini ham bayt olarak sağlar.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Entegrasyon gerektirdiğinde tanımlayıcıyı değiştir.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

`set_XmlAsString` ya da `set_XmlData` ile XML atarken geçerli, boş olmayan bir XML sağlamayı unutmayın. Uygulama daha çok metinle mi yoksa bayt verisiyle mi çalışıyorsa uygun temsili seçin.

### **Bir Özel XML Bölümünü Kaldırma**

Aspose.Slides, özel XML verisini kaldırmak için çeşitli yollar sunar:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpart/remove/) özel XML bölümünü sunumdan kaldırır.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpartcollection/remove/) belirli bir bölümü koleksiyondan kaldırır.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpartcollection/removeat/) belirtilen koleksiyon indeksindeki bölümü kaldırır.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpartcollection/clear/) belirli bir koleksiyondaki tüm bölümleri kaldırır.

Aşağıdaki örnek, referans yoluyla bir sunum‑düzeyindeki özel XML bölümünü kaldırır:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

Zaten bir `ICustomXmlPart` nesneniz varsa ve bölümü belirli bir koleksiyondan değil doğrudan sunumdan kaldırmak istiyorsanız `customXmlPart->Remove()` çağrısını yapın.

Ayrıca bir öğeyi indeksle de kaldırabilirsiniz:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Bir Koleksiyondaki Tüm Özel XML Bölümlerini Temizleme**

Belirli bir sunum nesnesiyle ilişkili tüm özel XML bölümleri kaldırılacaksa `Clear` yöntemini kullanın.

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` yalnızca seçili koleksiyonu etkiler. Örneğin, bir slaytın koleksiyonunu temizlemek, sunum‑düzeyindeki veya şekil‑düzeyindeki koleksiyonları temizlemez.

Sunumdaki her özel XML bölümünü kaldırmak için `get_AllCustomXmlParts()` üzerinden döngü kurup her bölümü kaldırın:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **Bağlantılı veya Paylaşılan Özel XML Bölümlerini Yönetme**

Office Open XML sunumunda aynı özel XML bölümü birden çok sunum nesnesi tarafından referans alınabilir. Örneğin, mevcut bir dosya birden çok slayt veya şekilden aynı temel özel XML bölümüne ilişki içerebilir.

Paylaşılan bir bölüm, birden çok referansa sahip tek bir veri nesnesi olarak ele alınmalıdır:

- `set_XmlAsString`, `set_XmlData` veya `set_ItemId` ile güncelleme yapmak, temel özel XML bölümünü değiştirir; değişiklik bu bölümü referans alan her yerde görülür.
- `get_ItemId()` aynı özel XML bölümünü nesne‑düzeyindeki koleksiyonları denetlerken kimliklendirmek için kullanılabilir.
- Belirli bir `get_CustomXmlParts()` koleksiyonundan bir bölümü kaldırmak, sadece o koleksiyondan siler. Bölümün sunumdan tamamen kaldırılması isteniyorsa `ICustomXmlPart::Remove()` kullanılmalıdır.
- Paylaşılan bir bölümü silmeden veya değiştirmeden önce, diğer slayt veya şekillerin hâlâ onu referans alıp almadığını belirlemek için nesne‑düzeyindeki koleksiyonları inceleyin.

`Add` aşırı yüklemeleri, XML içeriğinden yeni bir özel XML bölümü oluşturur; mevcut bir `ICustomXmlPart` kabul etmez. Bu nedenle, paylaşılan ilişkiler genellikle zaten bu bölümleri içeren sunumların yüklenmesi sırasında ortaya çıkar.

Aşağıdaki örnek, `ItemId` bazında sunum‑, slayt‑ ve şekil‑düzeyindeki koleksiyonları denetler ve birden fazla konumdan referans alınan bölümleri raporlar:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

Bu denetim, dış sistemler tarafından oluşturulan sunumlarda özel XML verisi değiştirilmeden veya silinmeden önce faydalıdır; aynı meta veri bölümü birden çok ilişki içinde yer alabilir.

## **Etiket Değerlerini Alma**

Slaytlarda bir etiket, `IDocumentProperties::get_Keywords` özelliğine karşılık gelir. Aşağıdaki örnek kod, C++ için Aspose.Slides kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) üzerindeki etiket değerini nasıl alacağınızı gösterir:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenizi sağlar. Bir etiket tipik olarak iki öğeden oluşur:

- `MyTag` gibi bir özel özellik adı,
- `My Tag Value` gibi o özelliğin değeri.

Sunumları belirli bir kural veya özelliğe göre sınıflandırmanız gerektiğinde bu amaçla etiket ekleyebilirsiniz. Örneğin, Kuzey Amerika ülkelerindeki sunumları sınıflandırmak isterseniz bir “NorthAmerican” etiketi oluşturup ilgili ülkeyi değer olarak atayabilirsiniz.

Aşağıdaki örnek kod, C++ için Aspose.Slides kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) üzerine etiket eklemeyi gösterir:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Etiketler ayrıca bir [Slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/) için de ayarlanabilir:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Ya da tek bir [Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/) için:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Sınırlamalar**

`get_CustomData()->get_Tags()` koleksiyonu üzerinden eklenen etiketler yalnızca PowerPoint dosyasında saklanır. Sunum PDF’ye dışa aktarıldığında bu etiketler PDF etiket yapısına **taşınmaz**. Sonuç olarak, bir etiket olarak atanan özel tanımlayıcı PDF’den okunamaz.

**Çözüm**: Özel tanımlayıcıyı nesnenin **Alt Text** alanına (ör. `shape->set_AlternativeText(u"MyId")`) depolayabilirsiniz. PDF’ye dışa aktarıldıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekildeki tüm etiketleri tek bir işlemle silebilir miyim?**

Evet. [Etiket koleksiyonu](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/) `Clear` (https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/clear/) işlemini destekler; bu işlem tüm anahtar‑değer çiftlerini bir seferde siler.

**Tüm koleksiyonu döngüye sokmadan tek bir etiketin adını kullanarak nasıl silebilirim?**

[TagCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/) üzerindeki `Remove(name)` (https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/remove/) metodunu kullanarak etiketi anahtarıyla silebilirsiniz.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**

[Etiket koleksiyonu](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/) üzerindeki `GetNamesOfTags` (https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/getnamesoftags/) metodunu kullanın; bu metod tüm etiket adlarını içeren bir dizi döndürür.

**Tüm özel XML bölümlerini, nerede saklandıklarından bağımsız olarak nasıl bulabilirim?**

Sunumdaki tüm özel XML bölümlerini almak için [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_allcustomxmlparts/) yöntemini kullanın.

**Bir özel XML bölümünü güncellerken `get_XmlAsString`/`set_XmlAsString` mi yoksa `get_XmlData`/`set_XmlData` mi kullanmalıyım?**

Uygulama UTF‑8 XML metniyle çalışıyorsa `get_XmlAsString` ve `set_XmlAsString` kullanın. XML zaten bir byte dizisi olarak varsa veya ikili‑yönlü işlem daha elverişliyse `get_XmlData` ve `set_XmlData` kullanın. Her iki temsil de aynı özel XML bölümünün içeriğine işaret eder.