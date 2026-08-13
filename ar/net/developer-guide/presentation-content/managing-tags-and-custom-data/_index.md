---
title: إدارة العلامات والبيانات المخصصة في العروض التقديمية بـ .NET
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/net/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- XML مخصص
- جزء XML مخصص
- بيانات وصفية XML
- ItemId
- إضافة علامة
- قيم أزواج
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرف على كيفية إدارة العلامات والبيانات XML المخصصة في عروض PowerPoint باستخدام Aspose.Slides للـ .NET، بما في ذلك الإضافة، والقراءة، والتحديث، والتدقيق، وإزالة أجزاء XML المخصصة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية عمل Aspose.Slides مع العلامات والبيانات المخصصة في عروض PowerPoint. يمكن تخزين البيانات الخاصة بالعرض كعلامات أو كأجزاء XML مخصصة. العلامات هي أزواج بسيطة من السلسلة المفتاح‑القيمة، بينما يمكن لأجزاء XML المخصصة تخزين بيانات وصفية منظمة وحُمولات XML خاصة بالتطبيق.

توفر Aspose.Slides واجهات برمجة تطبيقات لإضافة وقراءة وتحديث وتدقيق وإزالة أجزاء XML المخصصة على مستوى العرض أو الشريحة أو الشكل. تُعد أجزاء XML المخصصة مفيدة للتكاملات التي تخزن معلومات مثل معرفات إدارة المستندات، حالة سير العمل، بيانات التعريف للامتثال، بيانات ربط القوالب، أو أي بيانات تطبيقية منظمة أخرى داخل العرض.

## **تخزين البيانات في ملفات العرض**

تُخزن ملفات PPTX — الملفات ذات الامتداد `.pptx` — بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد Office Open XML بنية الحزمة والعلاقات المستخدمة لتخزين محتوى العرض والبيانات المرتبطة به.

يتكون العرض من عدة أجزاء مترابطة عبر علاقات. على سبيل المثال، يحتوي جزء الشريحة على محتوى شريحة واحدة ويمكن أن يكون له علاقات صريحة مع أجزاء أخرى معرفة وفقًا لـ ISO/IEC 29500.

يمكن تخزين البيانات المخصصة كعلامات ([ITagCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/itagcollection)) أو كأجزاء XML مخصصة ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpartcollection)). كلاهما متاح عبر الواجهة [`ICustomData`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomdata/) .

{{% alert color="info"%}}
العلامات تخزن أزواج مفتاح‑قيمة نصية بسيطة. أما أجزاء XML المخصصة فتخزن بيانات XML منظمة ويمكن ربطها بالعرض أو الشريحة أو الشكل.
{{% /alert %}}

## **العمل مع أجزاء XML المخصصة**

خاصية [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomdata/customxmlparts/) تُعيد مجموعة أجزاء XML المخصصة المرتبطة بكائن عرض معين. على سبيل المثال:

- `presentation.CustomData.CustomXmlParts` يحتوي على أجزاء XML المخصصة المرتبطة بالعرض نفسه.
- `slide.CustomData.CustomXmlParts` يحتوي على أجزاء XML المخصصة المرتبطة بشريحة محددة.
- `shape.CustomData.CustomXmlParts` يحتوي على أجزاء XML المخصصة المرتبطة بشكل معين.

استخدم [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/allcustomxmlparts/) عندما تحتاج إلى فحص جميع أجزاء XML المخصصة في العرض بغض النظر عن موقع ارتباطها.

### **إضافة جزء XML مخصص إلى عرض**

استخدم [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpartcollection/add/) لإضافة بيانات XML إلى مجموعة أجزاء XML المخصصة. يجب أن يكون XML صالحًا وغير فارغ.

المثال التالي يضيف بيانات وصفية منظمة إلى مجموعة البيانات المخصصة على مستوى العرض:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// يضيف معرفًا تلقائيًا. قم بتعيين GUID محدد فقط عند الحاجة.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

يمكن أن تقبل طريقة `Add` أيضًا XML كمصفوفة بايت أو تدفق، وهو مفيد عندما يكون محتوى XML متاحًا بالفعل بصيغة ثنائية.

### **إضافة جزء XML مخصّص إلى شريحة أو شكل**

يمكن ربط بيانات XML مخصصة بشريحة أو شكل محدد بدلاً من العرض بأكمله. يكون هذا مفيدًا عندما تصف البيانات الوصفية كائنًا واحدًا فقط، مثل مفتاح القالب أو معرف سجل خارجي أو معلومات ربط.

المثال التالي يضيف جزء XML مخصص إلى شريحة وآخر إلى شكل:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

المستوى الذي يُضاف فيه الجزء يحدد مجموعة `CustomData.CustomXmlParts` للكائن التي تحتوي على العلاقة إلى هذا الجزء. تُناسب البيانات على مستوى العرض للبيانات الوصفية العامة للمستند، وعلى مستوى الشريحة للمعلومات التي تخص شريحة معينة، وعلى مستوى الشكل للبيانات المرتبطة بشكل فردي.

### **قائمة وتدقيق جميع أجزاء XML المخصصة**

استخدم [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/allcustomxmlparts/) لاسترداد جميع أجزاء XML المخصصة من العرض. كل كائن [`ICustomXmlPart`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpart/) يوضح المعرف ومحتوى XML ومخططات الفضاء الاسمي المرتبطة.

المثال التالي يسرد جميع أجزاء XML المخصصة ومخططات الفضاء الاسمي الخاصة بها:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

تُعيد الخاصية [`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpart/namespaceschemas/) مخططات XML المرتبطة بالجزء. يمكن أن تكون هذه المعلومات مفيدة عند تدقيق عروض تحتوي على XML تم إنتاجه بواسطة أنظمة خارجية.

### **قراءة وتحديث محتوى XML ومعرف العنصر (ItemId)**

استخدم [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpart/xmlasstring/) للعمل مع XML كنص UTF‑8، أو استخدم [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpart/xmldata/) للعمل مع بايتات XML الخام. يمكن قراءة وتحديث الخاصيتين.

تحتوي الخاصية [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpart/itemid/) على GUID الذي يحدد جزء XML المخصص داخل مستند Office Open XML. يمكن أيضًا تغييره عندما تتطلب إحدى التكاملات معرفًا جديدًا.

المثال التالي يُحدّث محتوى XML والمعرف:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// قراءة XML الحالي كنص.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// تحديث XML كسلسلة UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData يوفر نفس محتوى XML كبايتات خام.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// استبدال المعرف عند الحاجة من قبل التكامل.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

عند تعيين `XmlAsString` أو `XmlData`، قدم XML صالحًا وغير فارغ. استخدم إحدى الطريقتين حسب ما إذا كان التطبيق يتعامل أساسًا مع سلاسل نصية أو بيانات بايت.

### **إزالة جزء XML مخصص**

توفر Aspose.Slides عدة طرق لإزالة بيانات XML المخصصة:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpart/remove/) يزيل الجزء من العرض.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpartcollection/remove/) يزيل جزءًا محددًا من مجموعة أجزاء XML المخصصة.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpartcollection/removeat/) يزيل الجزء عند فهرس مجموعة محدد.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpartcollection/clear/) يزيل جميع الأجزاء من مجموعة معينة.

المثال التالي يزيل جزء XML مخصص على مستوى العرض عبر الإشارة إليه:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

إذا كان لديك كائن `ICustomXmlPart` وتريد إزالة ذلك الجزء من العرض بدلاً من معالجة مجموعة معينة، استدعِ `customXmlPart.Remove()`.

يمكنك أيضًا إزالة عنصر وفق الفهرس:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **مسح جميع أجزاء XML المخصصة من مجموعة**

استخدم `Clear` عندما يجب إزالة جميع أجزاء XML المخصصة المرتبطة بكائن عرض معين.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

تؤثر `Clear` فقط على المجموعة المحددة. على سبيل المثال، مسح مجموعة شريحة لا يمسح مجموعات العرض أو الشكل.

لإزالة كل جزء XML مخصص في العرض، يمكنك تكرار `AllCustomXmlParts` وإزالة كل جزء:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **معالجة الأجزاء XML المخصصة المربوطة أو المشتركة**

في عرض Office Open XML، يمكن الإشارة إلى نفس جزء XML المخصص من أكثر من كائن عرض. على سبيل المثال، قد يحتوي ملف موجود على علاقات من عدة شرائح أو أشكال إلى نفس الجزء الأساسي.

يجب اعتبار الجزء المشترك ككائن بيانات واحد مع عدة مراجع:

- تحديث `XmlAsString` أو `XmlData` أو `ItemId` يغيّر الجزء الأساسي، وبالتالي ينطبق التغيير في كل موضع يُشار إليه.
- يمكن استخدام `ItemId` لتحديد نفس جزء XML المخصص أثناء تدقيق مجموعات على مستوى الكائن.
- إزالة جزء من مجموعة `CustomXmlParts` معينة يزيله فقط من تلك المجموعة. استخدم `ICustomXmlPart.Remove()` عندما يُراد حذف الجزء نفسه من العرض.
- قبل حذف أو استبدال جزء مشترك، افحص مجموعات مستوى الكائن لتحدد ما إذا كانت شرائح أو أشكال أخرى لا تزال تشير إليه.

إنّ تحميل أوزان `Add` ينشئ جزء XML مخصص جديد من محتوى XML؛ ولا يقبل جزءًا موجودًا من النوع `ICustomXmlPart`. لذا تُلاحظ العلاقات المشتركة غالبًا عند تحميل عروض تحتوي عليها مسبقًا.

المثال التالي يُجري تدقيقًا لمجموعات العرض، الشريحة، والشكل عبر `ItemId` ويُظهر الأجزاء التي يُشار إليها من أكثر من موضع:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

هذا النوع من التدقيق مفيد قبل تعديل أو حذف بيانات XML المخصصة في عروض أنشأتها أنظمة خارجية، لأن الجزء الوصفي نفسه قد يشارك في علاقات متعددة.

## **الحصول على قيم العلامات**

في الشرائح، تمثل العلامة الخاصية `IDocumentProperties.Keywords`. يظهر هذا المثال البرمجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides للـ .NET مع [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **إضافة علامات إلى العروض**

تسمح لك Aspose.Slides بإضافة علامات إلى العروض. تتكون العلامة عادةً من عنصرين:

- اسم الخاصية المخصصة، على سبيل المثال `MyTag`؛
- قيمة الخاصية المخصصة، على سبيل المثال `My Tag Value`.

إذا كنت بحاجة إلى تصنيف العروض وفق قاعدة أو خاصية معينة، يمكنك إضافة علامات لهذا الغرض. على سبيل المثال، إذا أردت تصنيف عروض البلدان الأمريكية الشمالية، يمكنك إنشاء علامة “North American” وتعيين البلد المناسب كقيمة لها.

يعرض المثال التالي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) باستخدام Aspose.Slides للـ .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

يمكن أيضًا تعيين العلامات لِـ [Slide](https://reference.aspose.com/slides/ar/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

أو لكائن [Shape](https://reference.aspose.com/slides/ar/net/aspose.slides/shape) فردي:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **القيود**

العلامات التي تُضاف عبر مجموعة `CustomData.Tags` تُخزن فقط في ملف PowerPoint. **لا** تُنقل إلى بنية العلامات في ملف PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرداد معرف مخصص تم تعيينه كعلامة من PDF المُوسوم.

**حل بديل**: يمكنك تخزين معرف مخصص في **النص البديل** للكائن (مثال، `shape.AlternativeText = "MyId"`). بعد تصدير إلى PDF، قد يظهر النص البديل في بنية العلامات في PDF.

## **الأسئلة الشائعة**

**هل يمكنني إزالة جميع العلامات من عرض أو شريحة أو شكل بعملية واحدة؟**

نعم. تدعم [tag collection](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/) عملية [Clear](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة مرة واحدة.

**كيف أحذف علامة واحدة باسمها دون التجول عبر المجموعة بأكملها؟**

استخدم [Remove(name)](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف أسترجع القائمة الكاملة لأسماء العلامات للتحليل أو الفلترة؟**

استخدم [GetNamesOfTags](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/getnamesoftags/) على [tag collection](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/)؛ تُعيد مصفوفة بجميع أسماء العلامات.

**كيف يمكنني العثور على جميع أجزاء XML المخصصة بغض النظر عن موقع تخزينها؟**

استخدم [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/allcustomxmlparts/) لاسترجاع جميع أجزاء XML المخصصة في العرض.

**هل يجب أن أستخدم `XmlAsString` أم `XmlData` لتحديث جزء XML مخصص؟**

استخدم `XmlAsString` عندما يعمل التطبيق مع نص XML بصيغة UTF‑8. استخدم `XmlData` عندما يكون XML متاحًا بالفعل كمصفوفة بايت أو عندما يكون المعالجة الثنائية أكثر ملاءمة. كلا الخاصيتين تمثلان محتوى XML لنفس الجزء المخصص.