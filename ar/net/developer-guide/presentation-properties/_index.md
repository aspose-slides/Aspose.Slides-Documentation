---
title: إدارة خصائص العرض التقديمي في .NET
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/net/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض التقديمي
- خصائص المستند
- خصائص مدمجة
- خصائص مخصصة
- خصائص متقدمة
- إدارة الخصائص
- تعديل الخصائص
- بيانات توصيف المستند
- تحرير البيانات الوصفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحكم في خصائص العروض التقديمية باستخدام Aspose.Slides لـ .NET وسهّل البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides for .NET نوعين من خصائص المستند: **مضمنة** و **مخصصة**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتها بسهولة باستخدام Aspose.Slides for .NET API.

يسمح Aspose.Slides لك بالعمل مع خصائص مستند العرض التقديمي عبر واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/). تُرجع خاصية [Presentation.DocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/documentproperties/) نسخة من هذه الواجهة. توضح الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
يرجى ملاحظة أن حقلي **Application** و **Producer** لا يمكن تعديلهما، حيث سيظهر دائمًا هذان الحقلان "Aspose Ltd." و "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

يوفر Microsoft PowerPoint ميزة إضافة خصائص إلى ملفات العروض التقديمية. تسمح هذه الخصائص بتخزين معلومات مفيدة مع الملفات. هناك نوعان من خصائص المستند:

- خصائص معرفة نظاميًا (مضمنة)
- خصائص معرفة من قبل المستخدم (مخصصة)

تحتوي الخصائص **مضمنة** على معلومات عامة عن المستند، مثل عنوان المستند، اسم المؤلف، إحصاءات المستند، وأكثر.

تُعرّف الخصائص **مخصصة** من قبل المستخدمين كأزواج **اسم/قيمة**، حيث يتم تحديد كل من الاسم والقيمة من قبل المستخدم.

باستخدام Aspose.Slides for .NET، يمكن للمطورين الوصول إلى كل من الخصائص المضمنة والمخصصة وتعديلها.

يتيح Microsoft PowerPoint للمستخدمين إدارة خصائص المستند بالنقر على أيقونة Office، ثم اختيار **File → Info → Properties**. بعد اختيار **Advanced Properties**، يظهر حوار يمكنك من خلاله إدارة جميع خصائص المستند لملف العرض التقديمي.

في مربع الحوار **Properties**، توجد عدة علامات تبويب، مثل **General** و **Summary** و **Statistics** و **Contents** و **Custom**. كل تبويب يوفر خيارات لتكوين أنواع معينة من المعلومات المتعلقة بملف PowerPoint. تُستخدم علامة التبويب **Custom** لإدارة الخصائص المعرفة من قبل المستخدم.

## **الوصول إلى الخصائص المضمنة**

هذه الخصائص، كما تظهر في واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/)، تشمل: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **SharedDoc** (يشير إلى ما إذا كان المستند مشتركًا بين منتجين مختلفين)، **PresentationFormat**، **Subject**، **Title**، والمزيد.

```cs
using Aspose.Slides;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **تعديل الخصائص المضمنة**

تعديل الخصائص المضمنة لملفات العروض التقديمية سهل بقدر الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية تريدها، وسيتم تحديث قيمة الخاصية. في المثال أدناه، نوضح كيفية تعديل خصائص المستند المضمنة لملف عرض تقديمي.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// الحصول على مرجع إلى الكائن من النوع IDocumentProperties المرتبط بالعرض التقديمي.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// تعيين الخصائص المدمجة.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Save the presentation to a file.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **إضافة خصائص عرض تقديمي مخصصة**

تتيح الخصائص المخصصة للعرض التقديمي للمطورين تخزين بيانات وصفية إضافية أو معلومات محددة داخل ملف العرض التقديمي. تجعل Aspose.Slides من السهل إنشاء وإدارة هذه الخصائص المخصصة برمجيًا. توضح الأمثلة التالية كيفية إضافة خصائص مخصصة إلى عروضك التقديمية.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation.
using Presentation presentation = new Presentation();

// الحصول على مرجع إلى الكائن من النوع IDocumentProperties المرتبط بالعرض التقديمي.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// إضافة خصائص مخصصة.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// حفظ العرض التقديمي إلى ملف.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **الوصول إلى الخصائص المخصصة وتعديلها**

تسمح Aspose.Slides أيضًا للمطورين بالوصول إلى الخصائص المخصصة الموجودة وتعديل قيمها بسهولة. تساعد هذه الوظيفة في الحفاظ على بيانات وصفية دقيقة وتدعم التحديثات الديناميكية بناءً على مدخلات المستخدم أو منطق الأعمال. توضح الأمثلة أدناه كيفية استرجاع قيم الخصائص المخصصة وتحديثها داخل عرض تقديمي.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// الحصول على مرجع إلى الكائن من النوع IDocumentProperties المرتبط بالعرض التقديمي.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// الوصول إلى الخصائص المخصصة وتعديلها.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // عرض اسم الخاصية المخصصة وقيمتها.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // تعديل قيمة الخاصية المخصصة.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// حفظ العرض التقديمي إلى ملف.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **مثال حي**

جرّب تطبيق الويب [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/ar/metadata) لمعرفة كيفية العمل مع خصائص المستند باستخدام Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة المتداولة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء أساسي من العرض التقديمي ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كفارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقًا؟**

إذا قمت بإضافة خاصية مخصصة موجودة مسبقًا، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث تقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/) ثم [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/readdocumentproperties/) لقراءة البيانات الوصفية المخزنة للمستند دون إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/net/examine-presentation/) للحصول على مثال تقارير كامل والقيود الخاصة بكل تنسيق.