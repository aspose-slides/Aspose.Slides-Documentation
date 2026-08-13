---
title: Управление тегами и пользовательскими данными в презентациях с использованием C++
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/cpp/managing-tags-and-custom-data/
keywords:
- свойства документа
- тег
- пользовательские данные
- пользовательский XML
- часть пользовательского XML
- XML‑метаданные
- ItemId
- добавить тег
- парные значения
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как управлять тегами и пользовательскими XML‑данными в презентациях PowerPoint с помощью Aspose.Slides для C++, включая добавление, чтение, обновление, аудит и удаление пользовательских XML‑частей."
---
## **Обзор**

В этой статье объясняется, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Данные, специфичные для презентации, могут храниться в виде тегов или пользовательских XML‑частей. Теги представляют собой простые парные строки «ключ‑значение», тогда как пользовательские XML‑части могут хранить структурированные метаданные и XML‑полезные нагрузки, специфичные для приложения.

Aspose.Slides предоставляет API для добавления, чтения, обновления, аудита и удаления пользовательских XML‑частей на уровнях презентации, слайда и фигуры. Пользовательские XML‑части полезны для интеграций, которые сохраняют информацию, такую как идентификаторы управления документами, состояние рабочего процесса, метаданные соответствия, данные привязки шаблона или другие структурированные данные приложения внутри презентации.

## **Хранение данных в файлах презентаций**

Файлы PPTX — файлы с расширением `.pptx` — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Office Open XML определяет структуру пакета и отношения, используемые для хранения содержимого презентации и связанных данных.

Презентация содержит несколько частей, связанных отношениями. Например, часть слайда содержит содержимое одного слайда и может иметь явные связи с другими частями, определёнными в ISO/IEC 29500.

Пользовательские данные могут храниться в виде тегов ([ITagCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itagcollection/)) или пользовательских XML‑частей ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icustomxmlpartcollection/)). Оба доступны через интерфейс [`ICustomData`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icustomdata/).

{{% alert color="info" %}}
Теги хранят простые строковые пары «ключ‑значение». Пользовательские XML‑части хранят структурированные XML‑данные и могут быть связаны с презентацией, слайдом или фигурой.
{{% /alert %}}

## **Работа с пользовательскими XML‑частями**

Метод [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icustomdata/get_customxmlparts/) возвращает коллекцию пользовательских XML‑частей, связанных с конкретным объектом презентации. Например:

- `presentation->get_CustomData()->get_CustomXmlParts()` содержит пользовательские XML‑части, связанные непосредственно с презентацией.
- `slide->get_CustomData()->get_CustomXmlParts()` содержит пользовательские XML‑части, связанные с конкретным слайдом.
- `shape->get_CustomData()->get_CustomXmlParts()` содержит пользовательские XML‑части, связанные с конкретной фигурой.

Используйте [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_allcustomxmlparts/) когда необходимо просмотреть все пользовательские XML‑части в презентации, независимо от того, к чему они привязаны.

### **Добавление пользовательской XML‑части в презентацию**

Используйте [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icustomxmlpartcollection/add/) для добавления XML‑данных в коллекцию пользовательских XML‑частей. XML должен быть корректным и непустым.

В следующем примере добавляются структурированные метаданные в коллекцию пользовательских данных уровня презентации:

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

// Add назначает идентификатор автоматически. Устанавливайте конкретный GUID только при необходимости.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Метод `Add` также может принимать XML в виде массива байтов или потока, что полезно, когда XML‑контент уже доступен в бинарной форме.

### **Добавление пользовательской XML‑части в слайд или фигуру**

Пользовательские XML‑данные могут быть связаны с конкретным слайдом или фигурой вместо всей презентации. Это полезно, когда метаданные описывают только один объект, например ключ шаблона, внешний идентификатор записи или информацию о привязке.

В следующем примере добавляется одна пользовательская XML‑часть в слайд и другая — в фигуру:

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

Уровень, на котором добавлена часть, определяет, в чью коллекцию `get_CustomData()->get_CustomXmlParts()` включено отношение к этой части. Данные уровня презентации подходят для метаданных, охватывающих весь документ, данные уровня слайда — для информации, относящейся к конкретному слайду, а данные уровня фигуры — для метаданных, привязанных к отдельной фигуре.

### **Список и аудит всех пользовательских XML‑частей**

Используйте [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_allcustomxmlparts/) для получения всех пользовательских XML‑частей из презентации. Каждый [`ICustomXmlPart`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icustomxmlpart/) предоставляет свой идентификатор, XML‑содержимое и связанные схемы пространств имён.

В следующем примере перечислены все пользовательские XML‑части и их схемы пространств имён:

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

`ICustomXmlPart::get_NamespaceSchemas` возвращает XML‑схемы, связанные с пользовательской XML‑частью. Эта информация может быть полезна при аудите презентаций, содержащих XML, созданный внешними системами.

### **Чтение и обновление XML‑содержимого и ItemId**

Используйте [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) и `set_XmlAsString` для работы с XML в виде UTF‑8 строки, либо [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icustomxmlpart/get_xmldata/) и `set_XmlData` для работы с необработанными байтами XML. Обе представления могут быть прочитаны и обновлены.

`ICustomXmlPart::get_ItemId` возвращает GUID, идентифицирующий пользовательскую XML‑часть в документе Office Open XML. Идентификатор также можно изменить с помощью `set_ItemId`, когда интеграции требуется новый идентификатор.

В следующем примере обновляется XML‑содержимое и идентификатор:

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

// Прочитать текущий XML как текст.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Обновить XML как строку UTF-8.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData предоставляет тот же XML-контент в виде необработанных байтов.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Заменить идентификатор, если это требуется интеграции.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

При присвоении XML с помощью `set_XmlAsString` или `set_XmlData` необходимо предоставить корректный, непустой XML. Выбирайте одно представление или другое в зависимости от того, работает ли приложение в основном со строками или байтовыми данными.

### **Удаление пользовательской XML‑части**

Aspose.Slides предоставляет несколько способов удаления пользовательских XML‑данных:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icustomxmlpart/remove/) удаляет пользовательскую XML‑часть из презентации.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icustomxmlpartcollection/remove/) удаляет конкретную часть из коллекции пользовательских XML‑частей.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icustomxmlpartcollection/removeat/) удаляет часть по указанному индексу в коллекции.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icustomxmlpartcollection/clear/) удаляет все части из конкретной коллекции.

В следующем примере удаляется одна пользовательская XML‑часть уровня презентации по ссылке:

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

Если у вас уже есть `ICustomXmlPart` и вы хотите удалить эту часть из презентации, а не обращаться к конкретной коллекции, вызовите `customXmlPart->Remove()`.

Также можно удалить элемент по индексу:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Очистка всех пользовательских XML‑частей из коллекции**

Используйте `Clear`, когда необходимо удалить все пользовательские XML‑части, связанные с конкретным объектом презентации.

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

`Clear` влияет только на выбранную коллекцию. Например, очистка коллекции слайда не затрагивает коллекции уровня презентации или уровня фигуры.

Чтобы удалить каждую пользовательскую XML‑часть в презентации, пройдитесь по `get_AllCustomXmlParts()` и удалите каждую часть:

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

### **Работа со связанными или общими пользовательскими XML‑частями**

В презентации Office Open XML одна и та же пользовательская XML‑часть может быть ссылкой из более чем одного объекта презентации. Например, существующий файл может содержать связи от нескольких слайдов или фигур к одной и той же базовой пользовательской XML‑части.

Общую часть следует рассматривать как один объект данных с несколькими ссылками:

- Обновление её с помощью `set_XmlAsString`, `set_XmlData` или `set_ItemId` изменяет базовую пользовательскую XML‑часть, поэтому изменение применяется везде, где эта часть используется.
- `get_ItemId()` можно использовать для идентификации одной и той же пользовательской XML‑части при аудите коллекций на уровне объектов.
- Удаление части из конкретной коллекции `get_CustomXmlParts()` удаляет её только из этой коллекции. Используйте `ICustomXmlPart::Remove()`, когда нужно удалить саму часть из презентации.
- Перед удалением или заменой общей части проверьте коллекции на уровне объектов, чтобы определить, ссылаются ли на неё другие слайды или фигуры.

Перегрузки `Add` создают новую пользовательскую XML‑часть из XML‑контента; они не принимают существующий `ICustomXmlPart`. Поэтому общие связи обычно встречаются при загрузке презентаций, которые уже их содержат.

В следующем примере производится аудит коллекций уровня презентации, слайда и фигуры по `ItemId` и выводятся части, на которые есть ссылки более чем из одного места:

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

Этот тип аудита полезен перед изменением или удалением пользовательских XML‑данных в презентациях, созданных внешними системами, поскольку одна и та же часть метаданных может участвовать более чем в одной связи.

## **Получение значений тегов**

В слайдах тег соответствует свойству `IDocumentProperties::get_Keywords`. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides для C++ для [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Добавление тегов в презентации**

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов:

- имя пользовательского свойства, например, `MyTag`;
- значение пользовательского свойства, например, `My Tag Value`.

Если необходимо классифицировать презентации по определённому правилу или свойству, можно добавить соответствующие теги. Например, если вы хотите сегментировать презентации из стран Северной Америки, можно создать тег North American и присвоить ему соответствующую страну в качестве значения.

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) с помощью Aspose.Slides для C++:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Теги также можно установить для [Slide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/slide/):

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

Или для отдельной [Shape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/):

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

### **Ограничения**

Теги, добавленные через коллекцию `get_CustomData()->get_Tags()`, сохраняются только в файле PowerPoint. При экспорте презентации в PDF они **не** переносятся в структуру тегов PDF. Следовательно, пользовательский идентификатор, назначенный как тег, нельзя получить из PDF с тегами.

**Обходное решение**: Вы можете хранить пользовательский идентификатор в **Alt Text** объекта (например, `shape->set_AlternativeText(u\"MyId\")`). После экспорта в PDF Alt Text может появиться в структуре тегов PDF.

## **FAQ**

**Могу ли я удалить все теги из презентации, слайда или фигуры одной операцией?**  
Да. [Коллекция тегов](https://reference.aspose.com/slides/ru/cpp/aspose.slides/tagcollection/) поддерживает операцию [Clear](https://reference.aspose.com/slides/ru/cpp/aspose.slides/tagcollection/clear/), которая удаляет все парные ключ‑значение одновременно.

**Как удалить отдельный тег по его имени без перебора всей коллекции?**  
Используйте [Remove(name)](https://reference.aspose.com/slides/ru/cpp/aspose.slides/tagcollection/remove/) у [TagCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/tagcollection/) чтобы удалить тег по его ключу.

**Как получить полный список имен тегов для аналитики или фильтрации?**  
Вызовите [GetNamesOfTags](https://reference.aspose.com/slides/ru/cpp/aspose.slides/tagcollection/getnamesoftags/) у [коллекции тегов](https://reference.aspose.com/slides/ru/cpp/aspose.slides/tagcollection/); он возвращает массив всех имен тегов.

**Как найти все пользовательские XML‑части, независимо от места их хранения?**  
Используйте [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_allcustomxmlparts/) чтобы получить все пользовательские XML‑части в презентации.

**Стоит ли использовать `get_XmlAsString`/`set_XmlAsString` или `get_XmlData`/`set_XmlData` для обновления пользовательской XML‑части?**  
Используйте `get_XmlAsString` и `set_XmlAsString`, когда приложение работает с текстовым XML в кодировке UTF‑8. Используйте `get_XmlData` и `set_XmlData`, когда XML уже доступен в виде массива байтов или когда более удобно бинарное обработка. Оба представления относятся к XML‑содержимому одной и той же пользовательской XML‑части.