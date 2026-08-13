---
title: C++ Kullanarak Sunumlarda Etiketler ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veriler
type: docs
weight: 300
url: /tr/cpp/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- özel XML
- özel XML bölümü
- XML üst verileri
- ItemId
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint sunumlarında etiketleri ve özel XML verilerini yönetmeyi, eklemeyi, okumayı, güncellemeyi, denetlemeyi ve özel XML bölümlerini kaldırmayı öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'in PowerPoint sunumlarında etiketler ve özel verilerle nasıl çalıştığını açıklar. Sunuma özgü veriler etiketler veya özel XML bölümleri olarak depolanabilir. Etiketler basit anahtar‑değer dize çiftleridir, özel XML bölümleri ise yapılandırılmış üst verileri ve uygulamaya özgü XML yüklerini saklayabilir.

Aspose.Slides, sunum, slayt ve şekil seviyelerinde özel XML bölümlerini ekleme, okuma, güncelleme, denetleme ve kaldırma için API'ler sunar. Özel XML bölümleri, belge‑yönetim tanımlayıcıları, iş akışı durumu, uyumluluk üst verileri, şablon bağlama verileri veya sunum içinde bulunan diğer yapılandırılmış uygulama verileri gibi bilgileri depolayan bütünleşmeler için yararlıdır.

## **Sunum Dosyalarında Veri Depolama**

`.pptx` uzantılı PPTX dosyaları, Office Open XML spesifikasyonunun bir parçası olan PresentationML formatında saklanır. Office Open XML, sunum içeriği ve ilişkili verilerin depolanması için kullanılan paket yapısını ve ilişkileri tanımlar.

Bir sunum, ilişkilerle bağlanmış birden çok bölüme sahiptir. Örneğin, bir slayt bölümü tek bir slaydın içeriğini barındırır ve ISO/IEC 29500 tarafından tanımlanan diğer bölümlerle açık ilişkiler içerebilir.

Özel veriler etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itagcollection/)) veya özel XML bölümleri ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpartcollection/)) olarak saklanabilir. İkisi de [`ICustomData`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomdata/) arayüzü üzerinden kullanılabilir.

{{% alert color="info" %}}
Etiketler basit dize anahtar‑değer çiftlerini saklar. Özel XML bölümleri yapılandırılmış XML verilerini saklar ve bir sunum, slayt veya şekil ile ilişkilendirilebilir.
{{% /alert %}}

## **Özel XML Bölümleriyle Çalışma**

[`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomdata/get_customxmlparts/) yöntemi, belirli bir sunum nesnesiyle ilişkili özel XML bölümleri koleksiyonunu döndürür. Örneğin:

- `presentation->get_CustomData()->get_CustomXmlParts()` sunumun kendisiyle ilişkili özel XML bölümlerini içerir.
- `slide->get_CustomData()->get_CustomXmlParts()` belirli bir slaytla ilişkili özel XML bölümlerini içerir.
- `shape->get_CustomData()->get_CustomXmlParts()` belirli bir şekille ilişkili özel XML bölümlerini içerir.

Sunumda nerede ilişkilendirilmiş olurlarsa olsunlar tüm özel XML bölümlerini incelemeniz gerektiğinde [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_allcustomxmlparts/) kullanın.

### **Sunuma Özel XML Bölümü Ekleme**

[`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpartcollection/add/) kullanarak XML verisini bir özel XML bölüm koleksiyonuna ekleyin. XML geçerli ve boş olmayan bir içerik olmalıdır.

Aşağıdaki örnek, sunum‑seviyesindeki özel veri koleksiyonuna yapılandırılmış üst veri ekler:

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

// Add otomatik olarak bir tanımlayıcı atar. Yalnızca gerektiğinde belirli bir GUID ayarlayın.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

`Add` yöntemi ayrıca XML'i bayt dizisi ya da akış olarak da kabul edebilir; bu, XML içeriğinin zaten ikili formda mevcut olduğu durumlarda kullanışlıdır.

### **Bir Slayt veya Şekle Özel XML Bölümü Ekleme**

Özel XML verisi, tüm sunum yerine belirli bir slayt veya şekil ile ilişkilendirilebilir. Bu, üst verinin yalnızca bir nesneyi (örneğin şablon anahtarı, dış kayıt tanımlayıcısı veya bağlama bilgisi) tanımlaması gerektiğinde faydalıdır.

Aşağıdaki örnek, bir slayta bir özel XML bölümü, bir şekle de başka bir bölüm ekler:

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

Bir bölümün eklendiği seviye, hangi nesnenin `get_CustomData()->get_CustomXmlParts()` koleksiyonunun o bölüme ilişkin ilişkiyi içerdiğini belirler. Sunum‑seviyesi veri, belge‑geneli üst veriler için, slayt‑seviyesi veri belirli bir slayta ait bilgi için, şekil‑seviyesi veri ise tek bir şekle bağlı üst veriler için uygundur.

### **Tüm Özel XML Bölümlerini Listeleme ve Denetleme**

Tüm özel XML bölümlerini elde etmek için [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_allcustomxmlparts/) kullanın. Her [`ICustomXmlPart`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpart/) kimliğini, XML içeriğini ve ilişkili ad alanı şemalarını sunar.

Aşağıdaki örnek, tüm özel XML bölümlerini ve bunların ad alanı şemalarını listeler:

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

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) yöntemi, özel XML bölümüyle ilişkili XML şemalarını döndürür. Bu bilgi, dış sistemler tarafından üretilen XML içeren sunumları denetlerken yararlı olabilir.

### **XML İçeriğini ve ItemId'yi Okuma ve Güncelleme**

XML'i UTF‑8 dize olarak işlemek için [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) ve `set_XmlAsString` kullanın, ya da ham XML baytlarını işlemek için [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpart/get_xmldata/) ve `set_XmlData` kullanın. Her iki temsil de okunup güncellenebilir.

[`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpart/get_itemid/) yöntemi, Office Open XML belgesindeki özel XML bölümünü tanımlayan GUID'i döndürür. Entegrasyon yeni bir tanımlayıcı gerektirdiğinde `set_ItemId` ile bu tanımlayıcı da değiştirilebilir.

Aşağıdaki örnek XML içeriğini ve tanımlayıcıyı günceller:

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

// Mevcut XML'i metin olarak oku.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// XML'i UTF-8 dizesi olarak güncelle.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData, aynı XML içeriğini ham baytlar olarak sağlar.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Entegrasyonun gerektirdiği durumlarda tanımlayıcıyı değiştir.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

`set_XmlAsString` ya da `set_XmlData` ile XML atarken geçerli, boş olmayan bir XML sağlamalısınız. Uygulamanız çoğunlukla dizeyle mi yoksa bayt verisiyle mi çalışıyorsa ilgili temsili kullanın.

### **Bir Özel XML Bölümünü Kaldırma**

Aspose.Slides, özel XML verisini kaldırmak için çeşitli yollar sunar:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpart/remove/) özel XML bölümünü sunumdan kaldırır.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpartcollection/remove/) belirli bir bölümü koleksiyondan kaldırır.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpartcollection/removeat/) belirtilen indeksdeki bölümü kaldırır.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpartcollection/clear/) belirli bir koleksiyondaki tüm bölümleri kaldırır.

Aşağıdaki örnek, referans yoluyla bir sunum‑seviyesi özel XML bölümünü kaldırır:

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

Eğer bir `ICustomXmlPart` nesnesine zaten sahipseniz ve bölümü belirli bir koleksiyona yönlendirmek yerine doğrudan sunumdan kaldırmak istiyorsanız `customXmlPart->Remove()` çağırın.

Ayrıca bir bölümü indeksle de kaldırabilirsiniz:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Bir Koleksiyondan Tüm Özel XML Bölümlerini Temizleme**

Belirli bir sunum nesnesiyle ilişkili tüm özel XML bölümlerinin kaldırılması gerektiğinde `Clear` metodunu kullanın.

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

`Clear` yalnızca seçilen koleksiyonu etkiler. Örneğin, bir slaytın koleksiyonunu temizlemek, sunum‑seviyesi ya da şekil‑seviyesi koleksiyonlarını temize çıkartmaz.

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

Office Open XML bir sunumunda aynı özel XML bölümü birden fazla nesne tarafından referans alınabilir. Örneğin, var olan bir dosya birden çok slayt ya da şekilden aynı temel özel XML bölümüne ilişki içerebilir.

Paylaşılan bir bölüm, birden çok referansı olan tek bir veri nesnesi olarak ele alınmalıdır:

- `set_XmlAsString`, `set_XmlData` ya da `set_ItemId` ile güncelleme yapmak, temel özel XML bölümünü değiştirir; böylece bölümün referans alındığı her yerde değişiklik yansır.
- `get_ItemId()` aynı özel XML bölümünü nesne‑seviyesi koleksiyonları denetlerken tanımlamak için kullanılabilir.
- Belirli bir `get_CustomXmlParts()` koleksiyonundan bir bölümü kaldırmak, sadece o koleksiyonu etkiler. Bölümü sunumdan tamamen kaldırmak için `ICustomXmlPart::Remove()` kullanın.
- Paylaşılan bir bölümü silmeden ya da değiştirmeden önce, diğer slaytların ya da şekillerin hâlâ ona referans verip vermediğini belirlemek için nesne‑seviyesi koleksiyonları inceleyin.

`Add` aşırı yüklemeleri, XML içeriğinden yeni bir özel XML bölümü oluşturur; mevcut bir `ICustomXmlPart` kabul etmez. Bu nedenle, paylaşılan ilişkiler genellikle bölümler zaten mevcut olan sunumlar yüklendiğinde ortaya çıkar.

Aşağıdaki örnek, `ItemId` üzerinden sunum‑, slayt‑ ve şekil‑seviyesi koleksiyonları denetler ve birden çok yerden referans verilen bölümleri raporlar:

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

Bu tür bir denetim, dış sistemler tarafından oluşturulan sunumlarda özel XML verilerini değiştirmeden ya da silmeden önce yararlıdır; çünkü aynı üst veri bölümü birden fazla ilişki içinde yer alabilir.

## **Etiket Değerlerini Alma**

Slaytlarda bir etiket, `IDocumentProperties::get_Keywords` özelliğine karşılık gelir. Aşağıdaki örnek kod, Aspose.Slides for C++ ile bir **Presentation** üzerindeki etiket değerini nasıl alacağınızı gösterir:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenizi sağlar. Bir etiket genellikle iki öğeden oluşur:

- örnek olarak `MyTag` gibi bir özel özellik adı;
- örnek olarak `My Tag Value` gibi özellik değeri.

Sunumları belirli bir kural ya da özellik temelinde sınıflandırmanız gerektiğinde bu amaçla etiketler ekleyebilirsiniz. Örneğin, Kuzey Amerika ülkelerinden gelen sunumları sınıflandırmak istiyorsanız “North American” adlı bir etiket oluşturup ilgili ülkeyi değer olarak atayabilirsiniz.

Aşağıdaki örnek, Aspose.Slides for C++ kullanarak bir **Presentation**a nasıl etiket ekleneceğini gösterir:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Etiketler bir **Slide** için de ayarlanabilir:

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

Ya da tek bir **Shape** için:

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

### **Kısıtlamalar**

`get_CustomData()->get_Tags()` koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında depolanır. Sunum PDF’ye dışa aktarıldığında bu etiket yapısına **aktarılmaz**. Sonuç olarak, bir etiket olarak atanmış özel tanımlayıcı PDF’de bulunamaz.

**Çözüm**: Özel tanımlayıcıyı nesnenin **Alt Text** alanında saklayabilirsiniz (örn. `shape->set_AlternativeText(u"MyId")`). PDF’ye dışa aktarıldıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemde kaldırabilir miyim?**  
Evet. [Etiket koleksiyonu](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/) **Clear** (https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/clear/) işlemini destekler; bu işlem tüm anahtar‑değer çiftlerini bir anda siler.

**Tüm koleksiyonu dolaşmadan, yalnızca adını bilerek tek bir etiketi nasıl silebilirim?**  
[TagCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/) üzerindeki [Remove(name)](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/remove/) metodunu kullanarak etiketi anahtarına göre silebilirsiniz.

**Analiz veya filtreleme amacıyla etiket adlarının tam listesini nasıl elde edebilirim?**  
Etiket koleksiyonunda [GetNamesOfTags](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/getnamesoftags/) metodunu kullanın; bu metod tüm etiket adlarını içeren bir dizi döndürür.

**Tüm özel XML bölümlerini, nerede depolandıklarına bakılmaksızın nasıl bulabilirim?**  
Sunumdaki tüm özel XML bölümlerini almak için [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_allcustomxmlparts/) metodunu kullanın.

**Bir özel XML bölümünü güncellerken `get_XmlAsString`/`set_XmlAsString` mı yoksa `get_XmlData`/`set_XmlData` mı tercih etmeliyim?**  
Uygulamanız UTF‑8 XML metniyle çalışıyorsa `get_XmlAsString` ve `set_XmlAsString` kullanın. XML zaten bir bayt dizisi olarak mevcutsa ya da ikili‑odaklı işleme ihtiyacınız varsa `get_XmlData` ve `set_XmlData` kullanın. Her iki temsil de aynı özel XML bölümünün içeriğini ifade eder.