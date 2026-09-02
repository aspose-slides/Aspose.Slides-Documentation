---
title: إدارة العلامات والبيانات المخصصة في العروض التقديمية في .NET
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
- قيم مزدوجة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرف على كيفية إدارة العلامات والبيانات XML المخصصة في عروض PowerPoint باستخدام Aspose.Slides لـ .NET، بما في ذلك الإضافة والقراءة والتحديث والتدقيق وإزالة أجزاء XML المخصصة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية عمل Aspose.Slides مع العلامات (tags) والبيانات المخصصة في عروض PowerPoint. يمكن تخزين البيانات الخاصة بالعرض كعلامات أو كأجزاء XML مخصصة. العلامات هي أزواج بسيطة من السلاسل المفتاح‑القيمة، بينما يمكن لأجزاء XML المخصصة تخزين بيانات وصفية منظمة وحمولات XML خاصة بالتطبيق.

توفر Aspose.Slides واجهات برمجة تطبيقات لإضافة، قراءة، تحديث، تدقيق، وإزالة أجزاء XML المخصصة على مستوى العرض، الشريحة، والكيان (shape). تُعد أجزاء XML المخصصة مفيدة للتكاملات التي تخزن معلومات مثل معرّفات إدارة المستندات، حالة سير العمل، البيانات الوصفية للامتثال، بيانات ربط القوالب، أو أي بيانات تطبيقية منظمة أخرى داخل العرض.

## **تخزين البيانات في ملفات العرض**

ملفات PPTX — الملفات ذات الامتداد `.pptx` — تُخزن بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. تُعرّف Office Open XML بنية الحزمة والعلاقات المستخدمة لتخزين محتوى العرض والبيانات المرتبطة.

يحتوي العرض على عدة أجزاء متصلة بواسطة علاقات. على سبيل المثال، يحتوي جزء الشريحة على محتوى شريحة واحدة ويمكن أن يمتلك علاقات صريحة إلى أجزاء أخرى وفقًا للمواصفات ISO/IEC 29500.

يمكن تخزين البيانات المخصصة كعلامات ([ITagCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/itagcollection)) أو كأجزاء XML مخصصة ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpartcollection)). كلاهما متاح عبر واجهة [`ICustomData`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomdata/) .

{{% alert color="primary" %}}
تخزن العلامات أزواج مفتاح‑قيمة نصية بسيطة. تخزن أجزاء XML المخصصة بيانات XML منظمة ويمكن ربطها بعرض، شريحة، أو كيان.
{{% /alert %}}

## **العمل مع أجزاء XML المخصصة**

خاصية [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomdata/customxmlparts/) تُعيد مجموعة أجزاء XML المخصصة المرتبطة بكائن عرض معين. على سبيل المثال:

- `presentation.CustomData.CustomXmlParts` يحتوي على أجزاء XML المخصصة المرتبطة بالعرض ذاته.
- `slide.CustomData.CustomXmlParts` يحتوي على أجزاء XML المخصصة المرتبطة بشريحة محددة.
- `shape.CustomData.CustomXmlParts` يحتوي على أجزاء XML المخصصة المرتبطة بكائن (shape) محدد.

استخدم [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/allcustomxmlparts/) عندما تحتاج إلى فحص جميع أجزاء XML المخصصة في العرض بغض النظر عن مكان ارتباطها.

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

// Add يعين معرفًا تلقائيًا. عيّن GUID محدد فقط عند الضرورة.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

يمكن للطريقة `Add` أيضًا قبول XML كمصفوفة بايت أو دفق، وهو مفيد عندما يكون محتوى XML متوفرًا بالفعل بصيغة ثنائية.

### **إضافة جزء XML مخصص إلى شريحة أو كيان**

يمكن ربط بيانات XML مخصصة بشريحة أو كيان محدد بدلاً من كامل العرض. يكون ذلك مفيدًا عندما تصف البيانات الوصفية كائنًا واحدًا فقط، مثل مفتاح القالب، معرف سجل خارجي، أو معلومات ربط.

المثال التالي يضيف جزء XML مخصص إلى شريحة وآخر إلى كيان:

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

المستوى الذي يُضاف فيه الجزء يحدد أي مجموعة `CustomData.CustomXmlParts` يحتوي على العلاقة إلى ذلك الجزء. تُعد البيانات على مستوى العرض مناسبة للبيانات الوصفية على مستوى المستند بأكمله، والبيانات على مستوى الشريحة للمعلومات الخاصة بشريحة معينة، والبيانات على مستوى الكيان للبيانات المرتبطة بكيان فردي.

### **قائمة وتدقيق جميع أجزاء XML المخصصة**

استخدم [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/allcustomxmlparts/) لاسترجاع جميع أجزاء XML المخصصة من العرض. كل كائن [`ICustomXmlPart`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpart/) يُظهر المعرف، محتوى XML، ومخططات النطاقات (namespace schemas) المرتبطة.

المثال التالي يسرد جميع أجزاء XML المخصصة ومخططات نطاقاتها:

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

تُعيد الخاصية [`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpart/namespaceschemas/) مخططات XML المرتبطة بالجزء المخصص. يمكن أن تكون هذه المعلومات مفيدة عند تدقيق عروض تحتوي على XML تم إنشاؤه بواسطة أنظمة خارجية.

### **قراءة وتحديث محتوى XML ومعرف العنصر (ItemId)**

استخدم [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpart/xmlasstring/) للعمل مع XML كسلسلة UTF‑8، أو [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpart/xmldata/) للعمل مع بايتات XML الخام. يمكن قراءة كلا الخصيتين وتحديثهما.

خاصية [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpart/itemid/) تحتوي على GUID يحدد الجزء المخصص داخل مستند Office Open XML. يمكن أيضًا تغييره عندما يتطلب التكامل معرفًا جديدًا.

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

// XmlData توفر نفس محتوى XML كبايتات خام.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// استبدال المعرف عندما يتطلب التكامل.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

عند تعيين `XmlAsString` أو `XmlData`، قدّم XML صالحًا وغير فارغ. استخدم تمثيلًا أو الآخر حسب ما إذا كان التطبيق يعمل أساسًا مع سلاسل نصية أو بيانات بايت.

### **إزالة جزء XML مخصص**

توفر Aspose.Slides عدة طرق لإزالة بيانات XML مخصصة:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpart/remove/) يزيل الجزء المخصص من العرض.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpartcollection/remove/) يزيل جزءًا محددًا من مجموعة الأجزاء المخصصة.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpartcollection/removeat/) يزيل الجزء عند الفهرس المحدد في المجموعة.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpartcollection/clear/) يزيل جميع الأجزاء من مجموعة معينة.

المثال التالي يزيل جزء XML مخصص على مستوى العرض عن طريق الإشارة:

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

إذا كان لديك `ICustomXmlPart` وتريد إزالة ذلك الجزء من العرض بدلاً من معالجة مجموعة معينة، فاستدعِ `customXmlPart.Remove()`.

يمكنك أيضًا إزالة عنصر حسب الفهرس:

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

`Clear` يؤثر فقط على المجموعة المختارة. على سبيل المثال، مسح مجموعة شريحة لا يمسح المجموعات على مستوى العرض أو الكيان.

لإزالة كل جزء XML مخصص في العرض، قم بالتكرار عبر `AllCustomXmlParts` وأزل كل جزء:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **معالجة الأجزاء XML المخصصة المرتبطة أو المشتركة**

في عرض Office Open XML، يمكن الإشارة إلى نفس جزء XML المخصص من أكثر من كائن عرض. على سبيل المثال، قد يحتوي ملف موجود على علاقات من عدة شرائح أو كائنات إلى نفس الجزء الأساسي.

يجب معالجة الجزء المشترك ككائن بيانات واحد مع مراجع متعددة:

- تحديث `XmlAsString` أو `XmlData` أو `ItemId` يغيّر الجزء الأساسي، وبالتالي ينعكس التغيير أينما تم الإشارة إليه.
- يمكن استخدام `ItemId` لتحديد نفس جزء XML المخصص أثناء تدقيق مجموعات المستوى الكائني.
- إزالة جزء من مجموعة `CustomXmlParts` معينة يزيله فقط من تلك المجموعة. استخدم `ICustomXmlPart.Remove()` عندما يجب حذف الجزء نفسه من العرض.
- قبل حذف أو استبدال جزء مشترك، افحص مجموعات المستوى الكائني لتحديد ما إذا كانت شرائح أو كائنات أخرى لا تزال تشير إليه.

إنّ التحميل الزائد `Add` يُنشئ جزء XML مخصص جديد من محتوى XML؛ ولا يقبل `ICustomXmlPart` موجود مسبقًا. لذا تُظهر العلاقات المشتركة غالبًا عند تحميل عروض تحتوي عليها بالفعل.

المثال التالي يدقق مجموعات العرض، الشريحة، والكائن حسب `ItemId` ويُبلغ عن الأجزاء التي تُشير إليها أكثر من موقع:

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

هذا النوع من التدقيق مفيد قبل تعديل أو حذف بيانات XML مخصصة في عروض تم إنشاؤها بواسطة أنظمة خارجية، لأن الجزء الوصفي نفسه قد يشارك في علاقات متعددة.

## **الحصول على قيم العلامات**

في الشرائح، تُطابق العلامة الخاصية `IDocumentProperties.Keywords`. يوضح هذا الكود كيفية الحصول على قيمة علامة باستخدام Aspose.Slides for .NET لـ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **إضافة علامات إلى العروض**

تتيح لك Aspose.Slides إضافة علامات إلى العروض. تتكون العلامة عادةً من عنصرين:

- اسم الخاصية المخصصة، على سبيل المثال `MyTag`؛
- قيمة الخاصية المخصصة، على سبيل المثال `My Tag Value`.

إذا احتجت إلى تصنيف العروض بناءً على قاعدة أو خاصية معينة، يمكنك إضافة علامات لهذا الغرض. على سبيل المثال، إذا أردت تصنيف العروض حسب دول أمريكا الشمالية، يمكنك إنشاء علامة "NorthAmerican" وتعيين الدولة المعنية كقيمة لها.

يعرض هذا الكود كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) باستخدام Aspose.Slides for .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

يمكن أيضًا تعيين العلامات لـ [Slide](https://reference.aspose.com/slides/ar/net/aspose.slides/slide):

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

العلامات التي تُضاف عبر مجموعة `CustomData.Tags` تُخزن فقط في ملف PowerPoint. فهي **لا** تُنقل إلى بنية العلامات في ملف PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرجاع معرف مخصص تم تعيينه كعلامة من ملف PDF الموسوم.

**الحل**: يمكنك تخزين معرف مخصص في **النص البديل** للكائن (مثال، `shape.AlternativeText = "MyId"`). بعد التصدير إلى PDF، قد يظهر النص البديل في بنية العلامات في PDF.

## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض أو شريحة أو كيان في عملية واحدة؟**

نعم. تدعم مجموعة [tag collection](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/) عملية [Clear](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة دفعة واحدة.

**كيف أحذف علامة واحدة باستخدام اسمها دون التIterate عبر المجموعة بالكامل؟**

استخدم [Remove(name)](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو الفلترة؟**

استخدم [GetNamesOfTags](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/getnamesoftags/) على [tag collection](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/)؛ تُعيد مصفوفة تحتوي على جميع أسماء العلامات.

**كيف يمكنني العثور على جميع أجزاء XML المخصصة بغض النظر عن موقع تخزينها؟**

استخدم [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/allcustomxmlparts/) لاسترجاع جميع أجزاء XML المخصصة في العرض.

**هل يجب أن أستخدم `XmlAsString` أم `XmlData` لتحديث جزء XML مخصص؟**

استخدم `XmlAsString` عندما يعمل التطبيق مع نص XML بترميز UTF‑8. استخدم `XmlData` عندما يكون XML متوفرًا بالفعل كمصفوفة بايت أو عندما يكون المعالجة الثنائية أكثر ملاءمة. كلا الخصيتين يمثلان محتوى XML لنفس الجزء المخصص.