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
- بيانات وصفية للمستند
- تحرير البيانات الوصفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحكم كامل في خصائص العروض التقديمية باستخدام Aspose.Slides for .NET وسهّل البحث، والعلامة التجارية، وتدفق العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides for .NET نوعين من خصائص المستند: **Built-in** و **Custom**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتهما بسهولة باستخدام Aspose.Slides for .NET API.

يسمح Aspose.Slides لك بالعمل مع خصائص مستند العرض التقديمي من خلال واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/) . يتم إرجاع مثال من هذه الواجهة بواسطة [IPresentation.DocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/documentproperties/). تظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
يرجى ملاحظة أن حقول **Application** و **Producer** لا يمكن تعديلها، حيث ستعرض هذه الحقول دائمًا "Aspose Ltd." و "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

يوفر Microsoft PowerPoint ميزة لإضافة خصائص إلى ملفات العروض التقديمية. تسمح هذه الخصائص بتخزين معلومات مفيدة مع الملفات. هناك نوعان من خصائص المستند:

- خصائص معرفة بالنظام (built-in)
- خصائص معرفة من قبل المستخدم (custom)

تحتوي الخصائص **Built-in** على معلومات عامة عن المستند، مثل عنوان المستند، اسم المؤلف، إحصائيات المستند، وأكثر.

تُعرّف الخصائص **Custom** من قبل المستخدمين كزوج **Name/Value**، حيث يكون كل من الاسم والقيمة محددين من قبل المستخدم.

باستخدام Aspose.Slides for .NET، يمكن للمطورين الوصول إلى كل من الخصائص built-in و custom وتعديلها.

يسمح Microsoft PowerPoint للمستخدمين بإدارة خصائص المستند بالنقر على أيقونة Office، ثم اختيار **File → Info → Properties**. بعد اختيار **Advanced Properties**، يظهر مربع حوار يمكنك من خلاله إدارة جميع خصائص المستند لملف العرض التقديمي.

في مربع حوار **Properties**، هناك عدة علامات تبويب، مثل **General**، **Summary**، **Statistics**، **Contents**، و **Custom**. كل علامة تبويب تقدم خيارات لتكوين أنواع محددة من المعلومات المتعلقة بملف PowerPoint. تُستخدم علامة تبويب **Custom** لإدارة الخصائص المعرفة من قبل المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما يحمي كلمة مرور الفتح كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير عرض تقديمي باستخدام [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) مضبوطًا على `false`، تظل خصائص المستند عامة. يمكن للتطبيق بعد ذلك ضبط [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) على `true` وقراءة البيانات الوصفية العامة دون توفير كلمة مرور الفتح.

`OnlyLoadDocumentProperties` يتحكم فيما يقوم Aspose.Slides بتحميله؛ فهو لا يقوم بفك تشفير أي شيء. إذا كانت الخصائص مشمولة في عملية التشفير، فإن تحميلها بدون كلمة المرور سيفشل. إذا لم يكن العرض التقديمي مشفرًا، يتم تجاهل الخيار ويتم تحميل العرض التقديمي بالكامل.

يتحقق المثال التالي من وضع التحميل عبر [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) ثم يقرأ الخصائص built-in عبر [IPresentation.DocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/documentproperties/):
```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب (masters)، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض التقديمي غير متوفرة. يجب على التطبيقات دائمًا التحقق من `IsOnlyDocumentPropertiesLoaded` قبل تنفيذ عملية تتطلب نموذج كائن العرض التقديمي الكامل.

{{% alert color="warning" title="Security" %}}
قد تكشف البيانات الوصفية العامة عن أسماء المؤلفين والعناوين والموضوعات والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصصة. يجب تشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما تتطلب أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات الوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة لملف PPTX مشفر، يُعد عرض تقديمي تم تحميله باستخدام `OnlyLoadDocumentProperties` مخصصًا لقراءة البيانات الوصفية العامة. لا يمكن لـ Aspose.Slides حفظ الخصائص المعدلة من ذلك الكائن الذي يحتوي فقط على البيانات الوصفية لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض التقديمي المشفر. لذلك يتطلب تحديثها كلمة مرور الفتح الصحيحة وتحميلًا كاملاً.

يفتح المثال التالي العرض التقديمي باستخدام [LoadOptions.Password](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/password/)، ويحدّث الخصائص العامة built-in، ثم يحفظ النتيجة. بعد ذلك يستخدم [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/isencrypted/) للتحقق من الحفاظ على التشفير ويعيد فتح البيانات الوصفية العامة بدون كلمة مرور للتحقق من القيم الجديدة:
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض التقديمي، يجب أن يتعامل مع الخصائص العامة لملف PPTX المشفر كقابلة للقراءة فقط.

## **الوصول إلى الخصائص Built-in**

تشمل هذه الخصائص، كما تُظهرها واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/)،: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **SharedDoc** (يشير إلى ما إذا كان المستند مشتركًا بين منتجين مختلفين)، **PresentationFormat**، **Subject**، **Title**، والمزيد.
```cs
using Aspose.Slides;

// إنشاء كائن من فئة Presentation الذي يمثل ملف عرض تقديمي.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// الحصول على مرجع للكائن من النوع IDocumentProperties المرتبط بالعرض التقديمي.
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

تعديل الخصائص built-in لملفات العرض التقديمي سهل بقدر ما هو الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية تريدها، وسيتم تحديث قيمة الخاصية. في المثال أدناه، نوضح كيفية تعديل خصائص المستند built-in لملف عرض تقديمي.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation الذي يمثل ملف عرض تقديمي.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// الحصول على مرجع للكائن من النوع IDocumentProperties المرتبط بالعرض التقديمي.
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

تمكن الخصائص المخصصة للعرض التقديمي المطورين من تخزين بيانات وصفية إضافية أو معلومات محددة داخل ملف العرض التقديمي. يجعل Aspose.Slides إنشاء وإدارة هذه الخصائص المخصصة برمجيًا أمرًا سهلًا. توضح الأمثلة التالية كيفية إضافة خصائص مخصصة إلى العروض التقديمية الخاصة بك.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation.
using Presentation presentation = new Presentation();

// الحصول على مرجع للكائن من النوع IDocumentProperties المرتبط بالعرض التقديمي.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// إضافة خصائص مخصصة.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// حفظ العرض التقديمي إلى ملف.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides أيضًا للمطورين بالوصول إلى الخصائص المخصصة الموجودة وتعديل قيمها بسهولة. تساعد هذه الوظيفة في الحفاظ على بيانات وصفية دقيقة وتدعم التحديثات الديناميكية بناءً على إدخال المستخدم أو منطق الأعمال. توضح الأمثلة أدناه كيفية استخراج وتحديث قيم الخصائص المخصصة داخل عرض تقديمي.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// الحصول على مرجع للكائن من النوع IDocumentProperties المرتبط بالعرض التقديمي.
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

جرّب التطبيق عبر الإنترنت [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/ar/metadata) لمعرفة كيفية العمل مع خصائص المستند باستخدام واجهة Aspose.Slides API:
[![عرض وتعديل بيانات PowerPoint الوصفية](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية built-in من عرض تقديمي؟**

الخصائص build-in جزء لا يتجزأ من العرض التقديمي ولا يمكن إزالتها تمامًا. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها إلى فارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا قمت بإضافة خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/) ثم [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/readdocumentproperties/) لقراءة بيانات المستند المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/net/examine-presentation/) للحصول على مثال تقرير كامل والقيود الخاصة بالصيغة.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفر دون كلمة مرور الفتح؟**

نعم. يجب أن يكون العرض التقديمي قد تم تشفيره مع ضبط `EncryptDocumentProperties` على `false`، ويجب تحميله مع ضبط `OnlyLoadDocumentProperties` على `true`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع تحميل خصائص المستند فقط؟**

لا. يجب أن تظل البيانات العامة والبيانات المشفرة للخصائص متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض التقديمي بالكامل مع كلمة مرور الفتح الصحيحة.