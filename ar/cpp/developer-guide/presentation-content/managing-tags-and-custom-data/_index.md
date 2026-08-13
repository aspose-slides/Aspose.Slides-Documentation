---
title: إدارة العلامات والبيانات المخصصة في العروض باستخدام C++
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/cpp/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- XML مخصص
- جزء XML مخصص
- بيانات وصفية XML
- ItemId
- إضافة علامة
- قيم زوجية
- PowerPoint
- عرض
- C++
- Aspose.Slides
description: "تعرف على كيفية إدارة العلامات وبيانات XML المخصصة في عروض PowerPoint باستخدام Aspose.Slides للغة C++، بما في ذلك الإضافة والقراءة والتحديث والتدقيق وإزالة أجزاء XML المخصصة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية عمل Aspose.Slides مع العلامات (tags) والبيانات المخصصة في عروض PowerPoint. يمكن تخزين البيانات الخاصة بالعرض إما كعلامات أو كأجزاء XML مخصصة. العلامات هي أزواج سلسلة (key-value) بسيطة، بينما يمكن لأجزاء XML المخصصة تخزين بيانات وصفية منظمة وحمولات XML خاصة بالتطبيق.

توفر Aspose.Slides واجهات برمجة تطبيقات لإضافة وقراءة وتحديث وتدقيق وإزالة أجزاء XML المخصصة على مستوى العرض أو الشريحة أو الشكل. تُعد أجزاء XML المخصصة مفيدة للتكاملات التي تخزن معلومات مثل معرفات إدارة المستندات، حالة سير العمل، بيانات التعريف المتوافقة، بيانات ربط القالب، أو أي بيانات تطبيقية منظمة أخرى داخل العرض.

## **تخزين البيانات في ملفات العرض**

ملفات PPTX — الملفات ذات الامتداد `.pptx` — تُخزن بصيغة PresentationML، وهي جزء من مواصفة Office Open XML. تُعرّف Office Open XML هيكل الحزمة والعلاقات المستخدمة لتخزين محتوى العرض والبيانات المرتبطة به.

يتكون العرض من أجزاء متعددة متصلة عبر علاقات. على سبيل المثال، يحتوي جزء الشريحة على محتوى شريحة واحدة ويمكن أن يكون له علاقات صريحة إلى أجزاء أخرى مُعرّفة وفقًا للمعيار ISO/IEC 29500.

يمكن تخزين البيانات المخصصة كعلامات ([ITagCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itagcollection/)) أو كأجزاء XML مخصصة ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomxmlpartcollection/)). كلاهما متاحان عبر واجهة [`ICustomData`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomdata/).

{{% alert color="info" %}}
العلامات تخزن أزواج سلسلة بسيطة (key-value). أما أجزاء XML المخصصة فتخزن بيانات XML منظمة ويمكن ربطها بالعرض أو الشريحة أو الشكل.
{{% /alert %}}

## **العمل مع أجزاء XML مخصصة**

طريقة [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomdata/get_customxmlparts/) تُعيد مجموعة أجزاء XML المخصصة المرتبطة بكائن عرض معين. على سبيل المثال:

- `presentation->get_CustomData()->get_CustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بالعرض نفسه.
- `slide->get_CustomData()->get_CustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بشريحة معينة.
- `shape->get_CustomData()->get_CustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بشكل معين.

استخدم [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_allcustomxmlparts/) عندما تحتاج إلى فحص جميع أجزاء XML المخصصة في العرض بغض النظر عن مكان ربطها.

### **إضافة جزء XML مخصص إلى عرض**

استخدم [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomxmlpartcollection/add/) لإضافة بيانات XML إلى مجموعة أجزاء XML مخصصة. يجب أن يكون XML صالحًا وغير فارغ.

المثال التالي يضيف بيانات وصفية منظمة إلى مجموعة البيانات المخصصة على مستوى العرض:

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

// يُعيّن Add معرفًا تلقائيًا. قم بتعيين GUID محدد فقط عندما يكون مطلوبًا.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

يمكن للطريقة `Add` أيضًا قبول XML كمصفوفة بايت أو تدفق، وهو ما يكون مفيدًا عندما يكون محتوى XML متوفرًا بالفعل بصيغة ثنائية.

### **إضافة جزء XML مخصص إلى شريحة أو شكل**

يمكن ربط بيانات XML مخصصة بشريحة معينة أو شكل معين بدلاً من ربطها بالعرض كاملاً. يكون هذا مفيدًا عندما تصف البيانات الوصفية كائنًا واحدًا فقط، مثل مفتاح قالب، معرف سجل خارجي، أو معلومات ربط.

المثال التالي يضيف جزء XML مخصص إلى شريحة وآخر إلى شكل:

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

المستوى الذي يُضاف فيه الجزء يحدّد أي مجموعة `get_CustomData()->get_CustomXmlParts()` تحتوي على العلاقة إلى ذلك الجزء. تُعتبر البيانات على مستوى العرض مناسبة للبيانات الوصفية على مستوى المستند بأكمله، بينما تكون البيانات على مستوى الشريحة مناسبة للمعلومات التي تخص شريحة معينة، والبيانات على مستوى الشكل مناسبة للبيانات المرتبطة بشكل فردي.

### **قائمة وتدقيق جميع أجزاء XML المخصصة**

استخدم [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_allcustomxmlparts/) لاسترجاع جميع أجزاء XML المخصصة من العرض. كل [`ICustomXmlPart`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomxmlpart/) يكشف عن معرفه، محتوى XML، ومخططات النطاقات المرتبطة.

المثال التالي يسرد جميع أجزاء XML المخصصة ومخططات النطاقات الخاصة بها:

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

طريقة [`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) تُعيد مخططات XML المرتبطة بالجزء المخصص. يمكن أن تكون هذه المعلومات مفيدة عند تدقيق عروض تحتوي على XML مُنتج من أنظمة خارجية.

### **قراءة وتحديث محتوى XML ومعرف العنصر (ItemId)**

استخدم [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) و `set_XmlAsString` للعمل مع XML كسلسلة UTF-8، أو استخدم [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomxmlpart/get_xmldata/) و `set_XmlData` للعمل مع بايتات XML الخام. يمكن قراءة وتحديث كلتا التمثيلات.

طريقة [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomxmlpart/get_itemid/) تُعيد GUID الذي يعرّف الجزء المخصص داخل مستند Office Open XML. يمكن أيضًا تغيير المعرف باستخدام `set_ItemId` عندما يتطلب التكامل معرفًا جديدًا.

المثال التالي يُحدّث محتوى XML والمعرف:

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

// قراءة XML الحالي كنص.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// تحديث XML كسلسلة UTF-8.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData يوفر نفس محتوى XML كبايتات خام.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// استبدال المعرف عندما يتطلب ذلك التكامل.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

عند تعيين XML باستخدام `set_XmlAsString` أو `set_XmlData`، قدم XML صالحًا وغير فارغ. استخدم تمثيلًا واحدًا أو آخر بناءً على ما إذا كان التطبيق يعمل أساسًا مع سلاسل نصية أو بيانات بايت.

### **إزالة جزء XML مخصص**

توفر Aspose.Slides عدة طرق لإزالة بيانات XML مخصصة:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomxmlpart/remove/) يزيل الجزء المخصص من العرض.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomxmlpartcollection/remove/) يزيل جزءًا محددًا من مجموعة أجزاء XML المخصصة.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomxmlpartcollection/removeat/) يزيل الجزء عند فهرس مجموعة محدد.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomxmlpartcollection/clear/) يزيل جميع الأجزاء من مجموعة معينة.

المثال التالي يزيل جزء XML مخصص على مستوى العرض باستخدام مرجع:

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

إذا كان لديك بالفعل `ICustomXmlPart` وتريد إزالة ذلك الجزء من العرض بدلاً من معالجة مجموعة معينة، فاستدعِ `customXmlPart->Remove()`.

يمكنك أيضًا إزالة عنصر حسب الفهرس:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **مسح جميع أجزاء XML المخصصة من مجموعة**

استخدم `Clear` عندما يجب إزالة جميع أجزاء XML المخصصة المرتبطة بكائن عرض معين.

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

`Clear` يؤثر فقط على المجموعة المحددة. على سبيل المثال، مسح مجموعة الشريحة لا يمسح مجموعات العرض أو الشكل.

لإزالة كل جزء XML مخصص في العرض، تكرّر عبر `get_AllCustomXmlParts()` وأزل كل جزء:

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

### **معالجة أجزاء XML مخصصة مرتبطة أو مشتركة**

في عرض Office Open XML، يمكن الإشارة إلى نفس جزء XML المخصص من أكثر من كائن عرض. على سبيل المثال، قد يحتوي ملف موجود على علاقات من عدة شرائح أو أشكال إلى نفس جزء XML المخصص الأساسي.

يجب اعتبار الجزء المشترك ككائن بيانات واحد مع مراجع متعددة:

- تحديثه باستخدام `set_XmlAsString` أو `set_XmlData` أو `set_ItemId` يغيّر الجزء الأساسي، وبالتالي يُطبق التغيير في كل موضع يُشار إليه.
- يمكن استخدام `get_ItemId()` لتحديد نفس جزء XML المخصص أثناء تدقيق مجموعات مستوى الكائن.
- إزالة الجزء من مجموعة `get_CustomXmlParts()` معينة يزيله فقط من تلك المجموعة. استخدم `ICustomXmlPart::Remove()` عندما يجب إزالة الجزء نفسه من العرض.
- قبل حذف أو استبدال جزء مشترك، راجع مجموعات مستوى الكائن لتحديد ما إذا كانت شرائح أو أشكال أخرى لا تزال تشير إليه.

إنّ التحميل الزائد `Add` يُنشئ جزء XML مخصص جديد من محتوى XML؛ لا يقبل جزءًا موجودًا من نوع `ICustomXmlPart`. لذلك، تُواجه العلاقات المشتركة غالبًا عند تحميل عروض تحتوي عليها مسبقًا.

المثال التالي يدقق مجموعات العرض، الشريحة، والشكل وفقًا لـ `ItemId` ويُبلغ عن الأجزاء التي يُشار إليها من أكثر من موضع:

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

هذا النوع من التدقيق مفيد قبل تعديل أو حذف بيانات XML المخصصة في عروض تم إنشاؤها بواسطة أنظمة خارجية، لأن جزء البيانات الوصفية نفسه قد يشارك في أكثر من علاقة.

## **الحصول على قيم العلامات**

في الشرائح، تتوافق العلامة مع خاصية `IDocumentProperties::get_Keywords`. يُظهر هذا المثال كيفية الحصول على قيمة علامة باستخدام Aspose.Slides للـ C++ مع [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **إضافة علامات إلى العروض**

يسمح Aspose.Slides لك بإضافة علامات إلى العروض. تتكوّن العلامة عادةً من عنصرين:

- اسم الخاصية المخصصة، على سبيل المثال `MyTag`؛
- قيمة الخاصية المخصصة، على سبيل المثال `My Tag Value`.

إذا كنت بحاجة إلى تصنيف العروض وفق قاعدة أو خاصية معينة، يمكنك إضافة علامات لهذا الغرض. على سبيل المثال، إذا أردت تصنيف العروض حسب دول أمريكا الشمالية، يمكنك إنشاء علامة أمريكا الشمالية وتعيين الدولة ذات الصلة كقيمتها.

هذا المثال يُظهر كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) باستخدام Aspose.Slides للـ C++:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

يمكن أيضًا تعيين العلامات لـ [Slide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slide/):

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

أو لشكل فردي [Shape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/):

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

### **القيود**

العلامات التي تُضاف عبر مجموعة `get_CustomData()->get_Tags()` تُحفظ فقط في ملف PowerPoint. فهي **لا** تُنقل إلى بنية علامات PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرجاع معرف مخصص تم تعيينه كعلامة من PDF المُمَوس.

**الحل**: يمكنك تخزين معرف مخصص في **النص البديل** للكائن (على سبيل المثال `shape->set_AlternativeText(u"MyId")`). بعد التصدير إلى PDF، قد يظهر النص البديل في بنية علامات PDF.

## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض أو شريحة أو شكل في عملية واحدة؟**

نعم. تدعم مجموعة [tag collection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/tagcollection/) عملية [Clear](https://reference.aspose.com/slides/ar/cpp/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة مرة واحدة.

**كيف أحذف علامة واحدة حسب اسمها دون التكرار عبر المجموعة بأكملها؟**

استخدم [Remove(name)](https://reference.aspose.com/slides/ar/cpp/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/tagcollection/) لحذف العلامة بناءً على مفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [GetNamesOfTags](https://reference.aspose.com/slides/ar/cpp/aspose.slides/tagcollection/getnamesoftags/) على [tag collection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/tagcollection/)؛ تُعيد مصفوفة تحتوي على جميع أسماء العلامات.

**كيف يمكنني العثور على جميع أجزاء XML المخصصة بغض النظر عن مكان تخزينها؟**

استخدم [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_allcustomxmlparts/) لاسترجاع جميع أجزاء XML المخصصة في العرض.

**هل يجب أن أستخدم `get_XmlAsString`/`set_XmlAsString` أم `get_XmlData`/`set_XmlData` لتحديث جزء XML مخصص؟**

استخدم `get_XmlAsString` و `set_XmlAsString` عندما يعمل التطبيق مع نص XML UTF-8. استخدم `get_XmlData` و `set_XmlData` عندما يكون XML متوفرًا بالفعل كمصفوفة بايت أو عندما تكون معالجة البايت أكثر ملاءمة. كلا التمثيلين يشيران إلى محتوى XML لنفس الجزء المخصص.