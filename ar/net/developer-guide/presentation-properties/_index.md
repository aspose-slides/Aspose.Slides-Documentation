---
title: إدارة خصائص عرض PowerPoint التقديمي في C#
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
  - الوصول إلى الخصائص
  - تعديل الخصائص
  - إدارة الخصائص
  - بيانات تعريف المستند
  - تحرير البيانات الوصفية
  - لغة التدقيق
  - PowerPoint
  - عرض تقديمي
  - C#
  - Csharp
  - Aspose.Slides for .NET
description: "تعلم كيفية إدارة وقراءة وتحرير خصائص مستندات PowerPoint بسهولة باستخدام Aspose.Slides for .NET في C#. عزز الإنتاجية وأتمت عملك!"
---

## **نظرة عامة**

يدعم Aspose.Slides for .NET نوعين من خصائص المستند: **Built-in** و **Custom**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتهما بسهولة باستخدام API الخاص بـ Aspose.Slides for .NET.

للتعامل مع خصائص المستند، يوفر Aspose.Slides الواجهة [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) التي يمكن الوصول إليها من خلال خاصية [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/documentproperties/). يمكن للمطورين الاستفادة من واجهة [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) لكائن `Presentation` لقراءة، تعديل وإدارة خصائص العرض التقديمي بسهولة، كما هو موضح في الأمثلة أدناه.

{{% alert color="primary" %}} 

يرجى ملاحظة أن حقول **Application** و **Producer** لا يمكن تعديلها، حيث ستظهر دائمًا القيم "Aspose Ltd." و "Aspose.Slides for .NET x.x.x".

{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

يوفر Microsoft PowerPoint ميزة لإضافة خصائص إلى ملفات العروض التقديمية. تسمح هذه الخصائص بتخزين معلومات مفيدة مع الملفات. هناك نوعان من خصائص المستند:

- خصائص معرفة من النظام (built-in)
- خصائص معرفة من المستخدم (custom)

تحتوي الخصائص **Built-in** على معلومات عامة حول المستند، مثل عنوان المستند، اسم المؤلف، إحصائيات المستند، والمزيد.

تُعرّف الخصائص **Custom** من قبل المستخدمين كأزواج **Name/Value**، حيث يكون كل من الاسم والقيمة محددين من قبل المستخدم.

باستخدام Aspose.Slides for .NET، يمكن للمطورين الوصول إلى كل من الخصائص built-in و custom وتعديلها.

يسمح Microsoft PowerPoint للمستخدمين بإدارة خصائص المستند عن طريق النقر على أيقونة Office، ثم اختيار **File → Info → Properties**. بعد اختيار **Advanced Properties**، تظهر نافذة حوارية حيث يمكنك إدارة جميع خصائص المستند لملف العرض التقديمي.

في نافذة الحوار **Properties**، توجد عدة علامات تبويب، مثل **General** و **Summary** و **Statistics** و **Contents** و **Custom**. كل علامة تبويب توفر خيارات لتكوين أنواع محددة من المعلومات المتعلقة بملف PowerPoint. تُستخدم علامة التبويب **Custom** لإدارة الخصائص المعرفة من قبل المستخدم.

## **الوصول إلى الخصائص Built-in**

هذه الخصائص، كما تُظهرها الواجهة [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/)، تشمل: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ آخر طباعة)، **LastModifiedBy**، **SharedDoc** (يشير إلى ما إذا كان المستند مشتركًا بين منتجين مختلفين)، **PresentationFormat**، **Subject**، **Title**، والمزيد.
```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// الحصول على مرجع إلى كائن من النوع IDocumentProperties المرتبط بالعرض التقديمي.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// عرض الخصائص المدمجة.
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


## **تعديل الخصائص Built-in**

تعديل الخصائص built-in لملفات العرض التقديمي سهل بقدر الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية مرغوبة، وسيتم تحديث قيمة الخاصية. في المثال أدناه، نوضح كيفية تعديل خصائص المستند built-in لملف عرض تقديمي.
```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// الحصول على مرجع إلى كائن من النوع IDocumentProperties المرتبط بالعرض التقديمي.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// تعيين الخصائص المدمجة.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// حفظ العرض التقديمي إلى ملف.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```


## **إضافة خصائص عرض تقديمي مخصصة**

تتيح خصائص العرض التقديمي المخصصة للمطورين تخزين بيانات تعريفية إضافية أو معلومات محددة داخل ملف العرض التقديمي. يجعل Aspose.Slides من السهل إنشاء وإدارة هذه الخصائص المخصصة برمجيًا. توضح الأمثلة التالية كيفية إضافة خصائص مخصصة إلى عروضك التقديمية.
```cs
// إنشاء كائن من فئة Presentation.
using Presentation presentation = new Presentation();

// الحصول على مرجع إلى كائن من النوع IDocumentProperties المرتبط بالعرض التقديمي.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// إضافة خصائص مخصصة.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// حفظ العرض التقديمي إلى ملف.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```


## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides أيضًا للمطورين بالوصول إلى الخصائص المخصّصة الموجودة وتعديل قيمها بسهولة. تساعد هذه الوظيفة في الحفاظ على بيانات تعريفية دقيقة وتدعم التحديثات الديناميكية بناءً على مدخلات المستخدم أو منطق العمل. توضح الأمثلة أدناه كيفية استرجاع وتحديث قيم الخصائص المخصّصة داخل عرض تقديمي.
```cs
// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// الحصول على مرجع إلى الكائن من النوع IDocumentProperties المرتبط بالعرض التقديمي.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// الوصول إلى الخصائص المخصصة وتعديلها.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // عرض اسم وقيمة الخاصية المخصصة.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // تعديل قيمة الخاصية المخصصة.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// حفظ العرض التقديمي إلى ملف.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```


## **مثال حي**

جرّب التطبيق عبر الإنترنت [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) لتتعرف على كيفية التعامل مع خصائص المستند باستخدام API الخاص بـ Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية built-in من عرض تقديمي؟**

الخصائص built-in هي جزء لا يتجزأ من العرض التقديمي ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها إلى فارغ إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا قمت بإضافة خاصية مخصصة موجودة بالفعل؟**

إذا قمت بإضافة خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالأخرى الجديدة. لا تحتاج إلى إزالة الخاصية أو فحصها مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميله بالكامل؟**

نعم، يمكنك الوصول إلى خصائص العرض التقديمي دون تحميله بالكامل باستخدام طريقة `GetPresentationInfo` من فئة [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/). ثم، استخدم طريقة `ReadDocumentProperties` المتوفرة عبر الواجهة [IPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/) لقراءة الخصائص بشكل فعال، مما يوفر الذاكرة ويعزز الأداء.