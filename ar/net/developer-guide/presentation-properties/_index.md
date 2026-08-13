---
title: إدارة خصائص العرض في .NET
linktitle: خصائص العرض
type: docs
weight: 70
url: /ar/net/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض
- خصائص المستند
- خصائص مضمنة
- خصائص مخصصة
- خصائص متقدمة
- إدارة الخصائص
- تعديل الخصائص
- بيانات المستند الوصفية
- تحرير البيانات الوصفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض
- .NET
- C#
- Aspose.Slides
description: "اتقن خصائص العرض في Aspose.Slides for .NET وسهّل البحث والعلامة التجارية وتدفق العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **المقدمة**

Aspose.Slides for .NET يدعم نوعين من خصائص المستند: **المضمنة** و **المخصصة**. يمكن الوصول إلى كلا النوعين وإدارتهما بسهولة باستخدام API الخاص بـ Aspose.Slides for .NET.

Aspose.Slides يتيح لك العمل مع خصائص مستند العرض من خلال واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/) . يتم إرجاع كائن من هذه الواجهة عبر الخاصية [Presentation.DocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/documentproperties/) . توضح الأمثلة التالية كيفية قراءة وتعديل وإدارة هذه الخصائص.

{{% alert color="info" %}} 

يرجى ملاحظة أنه لا يمكن تعديل حقلي **Application** و **Producer**، حيث سيظهر دائمًا "Aspose Ltd." و "Aspose.Slides for .NET x.x.x".

{{% /alert %}} 

## **إدارة خصائص العرض**

يوفر Microsoft PowerPoint ميزة لإضافة خصائص إلى ملفات العروض. تسمح هذه الخصائص بتخزين معلومات مفيدة مع الملفات. هناك نوعان من خصائص المستند:

- خصائص معرفة بالنظام (مضمنة)
- خصائص معرفة من قبل المستخدم (مخصصة)

تحتوي الخصائص **المضمنة** على معلومات عامة عن المستند، مثل عنوان المستند، اسم المؤلف، إحصاءات المستند، وأكثر.

تُعرّف الخصائص **المخصصة** من قبل المستخدم كأزواج **اسم/قيمة**، حيث يكون كل من الاسم والقيمة محددين من قبل المستخدم.

باستخدام Aspose.Slides for .NET، يمكن للمطورين الوصول إلى كل من الخصائص المضمنة والمخصصة وتعديلها.

يسمح Microsoft PowerPoint للمستخدمين بإدارة خصائص المستند بالنقر على أيقونة Office، ثم اختيار **File → Info → Properties**. بعد اختيار **Advanced Properties**، يظهر حوار يمكنك من خلاله إدارة جميع خصائص المستند للملف العرض.

في حوار **Properties**، توجد عدة علامات تبويب، مثل **General**, **Summary**, **Statistics**, **Contents**, و **Custom**. كل تبويب يوفر خيارات لتكوين أنواع محددة من المعلومات المتعلقة بملف PowerPoint. تُستخدم تبويب **Custom** لإدارة الخصائص المعرفة من قبل المستخدم.

## **الوصول إلى الخصائص المضمنة**

هذه الخصائص، كما تُظهرها واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/) ، تشمل: **Creator** (المؤلف)، **Description**, **Keywords**, **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ آخر طباعة)، **LastModifiedBy**, **SharedDoc** (يشير إلى ما إذا كان المستند مشتركًا بين منتجين مختلفين)، **PresentationFormat**, **Subject**, **Title**, والمزيد.

```cs
using Aspose.Slides;

// إنشاء فئة Presentation التي تمثل ملف عرض.
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

تعديل الخصائص المضمنة لملفات العرض سهل بقدر الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية مرغوبة، وسيتم تحديث قيمة الخاصية. في المثال أدناه، نوضح كيفية تعديل خصائص المستند المضمنة لملف عرض.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء فئة Presentation التي تمثل ملف عرض.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// الحصول على مرجع لكائن من النوع IDocumentProperties المرتبط بالعرض.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// تعيين الخصائص المضمنة.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// حفظ العرض إلى ملف.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **إضافة خصائص عرض مخصصة**

تمكن خصائص العرض المخصصة المطورين من تخزين بيانات وصفية إضافية أو معلومات محددة داخل ملف العرض. يجعل Aspose.Slides إنشاء وإدارة هذه الخصائص المخصصة برمجيًا أمرًا سهلًا. توضح الأمثلة التالية كيفية إضافة خصائص مخصصة إلى عروضك.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء فئة Presentation.
using Presentation presentation = new Presentation();

// الحصول على مرجع لكائن من النوع IDocumentProperties المرتبط بالعرض.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// إضافة خصائص مخصصة.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// حفظ العرض إلى ملف.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides أيضًا للمطورين بالوصول إلى الخصائص المخصصة الموجودة وتعديل قيمها بسهولة. تساعد هذه الوظيفة في الحفاظ على بيانات وصفية دقيقة وتدعم التحديثات الديناميكية بناءً على إدخال المستخدم أو منطق الأعمال. توضح الأمثلة أدناه كيفية استرجاع وتحديث قيم الخصائص المخصصة داخل عرض.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء فئة Presentation التي تمثل ملف PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// الحصول على مرجع للكائن من النوع IDocumentProperties المرتبط بالعرض.
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

// حفظ العرض إلى ملف.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **مثال حي**

جرّب التطبيق الإلكتروني [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/ar/metadata) لتعرف كيف تعمل مع خصائص المستند باستخدام API الخاص بـ Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## ***الأسئلة الشائعة**

### كيف يمكنني إزالة خاصية مضمَّنة من عرض؟

الخصائص المضمنة هي جزء أساسي من العرض ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها إلى فارغ إذا سمحت الخاصية المحددة بذلك.

### ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقًا؟

إذا أضفت خاصية مخصصة موجودة مسبقًا، سيُستبدل قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

### هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟

نعم، يمكنك الوصول إلى خصائص العرض دون تحميل العرض بالكامل باستخدام طريقة `GetPresentationInfo` من فئة [PresentationFactory](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/). ثم، استخدم طريقة `ReadDocumentProperties` المقدمة من واجهة [IPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/) لقراءة الخصائص بكفاءة، مما يوفر الذاكرة ويحسن الأداء.