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
- بيانات تعريف المستند
- تحرير بيانات التعريف
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides for .NET وقم بتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---
## **المقدمة**

Aspose.Slides for .NET يدعم الخصائص **المدمجة** والخصائص **المخصصة** للمستند. استخدم هذه الخصائص لقراءة وتحديث بيانات تعريف العرض التقديمي، مثل المؤلف والعنوان والقيم المعرفة من قبل المستخدم.

يسمح Aspose.Slides لك بالعمل مع خصائص مستند العرض التقديمي عبر واجهة [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) . يتم إرجاع مثال من هذه الواجهة بواسطة [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). توضح الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
يدير Aspose.Slides بيانات التعريف الخاصة بالتطبيق والمنتج عند حفظ العروض التقديمية؛ هذه الحقول تحدد البرنامج الذي أنشأ الناتج.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية إلى جانب محتوى العرض التقديمي. وتنقسم إلى فئتين:

- **الخصائص المدمجة** تحتوي على بيانات تعريف قياسية، مثل العنوان والمؤلف وإحصاءات المستند.
- **الخصائص المخصصة** تخزن أزواج اسم/قيمة يُعرفها المستخدم.

يوفر Aspose.Slides for .NET إمكانية الوصول إلى كلتا الفئتين. في PowerPoint، اختر **File → Info → Properties → Advanced Properties** لفحص بيانات تعريف المستند. تقوم النافذة بتجميع المعلومات في تبويبات مثل **Summary** و **Statistics** و **Contents** و **Custom**. استخدم تبويب **Custom** لإدارة الخصائص المعرفة من قبل المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما يحمي كلمة مرور الفتح كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير عرض تقديمي باستخدام [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) مع تعيين القيمة إلى `false`، تبقى خصائص المستند عامة. يمكن للتطبيق حينها تعيين [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) إلى `true` وقراءة البيانات العامة دون تقديم كلمة مرور الفتح.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) يتحكم فيما يقوم Aspose.Slides بتحميله؛ ولا يقوم بفك أي تشفير. إذا كانت الخصائص مشمولة في التشفير، فإن تحميلها بدون كلمة المرور سيفشل. إذا لم يكن العرض التقديمي مُشفّرًا، يتم تجاهل الخيار ويتم تحميل العرض بالكامل.

يتطلب المثال عرضًا تقديميًا مُشفّرًا تكون خصائص المستند العامة. يتحقق من وضع التحميل عبر [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) ثم يقرأ الخصائص المدمجة عبر [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا التحقق من [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) قبل تنفيذ عملية تتطلب نموذج الكائن الكامل للعرض.

{{% alert color="warning" title="Security" %}}
قد تكشف البيانات العامة عن أسماء المؤلفين والعناوين والمواضيع والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما تكون هناك حاجة في أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات للوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة لملف PPTX مُشفّر، يُقصد من العرض الذي يُحمَّل باستخدام [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) قراءة البيانات العامة فقط. لا يستطيع Aspose.Slides حفظ الخصائص المتغيّرة من كائن يحتوي على البيانات العامة فقط لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض المشفر. لذلك يتطلب تحديثها كلمة مرور الفتح الصحيحة وتحميلًا كاملاً.

يتطلب المثال عرضًا تقديميًا PPTX مُشفّرًا يضم خصائص مستند عامة وكلمة مرور فتح معروفة. يفتح العرض الكامل باستخدام [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/)، يحدّث الخصائص المدمجة العامة، ويحفظ النتيجة. ثم يستخدم [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) للتحقق من بقاء التشفير، ويعيد فتح البيانات العامة بدون كلمة مرور للتحقق من القيم الجديدة:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

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

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض، يجب أن يعامل الخصائص العامة لملف PPTX مُشفّر كقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

تُظهر واجهة [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) البيانات المدمجة عبر خصائص ذات نوع محدد، بما في ذلك [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)، [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/)، و[CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/). يفتح هذا المثال عرضًا تقديميًا موجودًا ويطبع البيانات المخزنة في وحدة التحكم. تعتمد القيم على العرض المُدخل؛ قد تكون بعض الحقول فارغة.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

## **تعديل الخصائص المدمجة**

لتحديث البيانات المدمجة، عيّن قيمًا للخصائص القابلة للكتابة التي تُظهرها [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). يفتح هذا المثال عرضًا تقديميًا موجودًا، يحدد [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)، [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), و[Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/)، ثم يحفظ العرض المحدث باستخدام [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). يحتوي ملف PPTX المحفوظ على البيانات الجديدة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **إدارة أساس الارتباط التشعبي**

يخزن [IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) الأساس على مستوى المستند للارتباطات التشعبية النسبية. يكون هذا مفيدًا عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. وهو منفصل عن [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/): تغيير الأساس لا يعيد كتابة عناوين الروابط المخزنة ولا يغيّر الوجهات المطلقة.

يتطلب المثال عرضًا تقديميًا يحتوي على رابط نسبي، مثل `target.html`، ورابط مطلق، مثل `https://example.org/absolute.html`. يقرأ الأساس الحالي، يعيّن عنوان أساس جديد، ثم يحفظ ويعيد فتح العرض للتحقق من القيمة. بعد ذلك يزيل الأساس باستخدام `string.Empty` ويتحقق من القيمة الفارغة في ملف محفوظ منفصل. استبدل عنوان الأساس في المثال بموقع ملفاتك المرتبطة.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

يجب أن تطبع رسالتي التحقق القيمتين `True`. يؤدي إزالة الأساس إلى إبقاء عناوين الروابط الفردية دون تغيير.

فتح رابط نسبي إلى `target.pptx` ملف `old/target.pptx` عندما كان الأساس يشير إلى المجلد `old`. بعد تغيير الأساس إلى المجلد `new`، وحفظ وإعادة فتح العرض، فتح نفس الرابط `new/target.pptx`. استمر الرابط المطلق في فتح نفس الملف. اختبر روابطك النسبية في PowerPoint قبل وبعد نقل العرض أو تغيير أسسه.

## **إضافة خصائص عرض تقديمي مخصصة**

تخزن الخصائص المخصصة بيانات تعريف لا توجد لها حقل مدمج مماثل. يتيح لك [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) تعيين قيمة حسب اسم الخاصية. يخلق هذا المثال عرضًا تقديميًا، يضيف قيمتين نصيتين وقيمة إصدار عددية صحيحة، ويحفظ العرض باستخدام [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **الوصول إلى الخصائص المخصصة وتعديلها**

يفتح هذا المثال عرضًا تقديميًا يحتوي على خصائص مخصصة ويستخدم [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) للتنقل بينها. تستقبل [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) فهرسًا يبدأ من الصفر وتُرجع الاسم المستخدم في [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/). يطبع المثال كل اسم أصلي وقيمته، يستبدل كل قيمة بسلسلة مرقّمة بغض النظر عن نوعها الأصلي، ويحفظ التغييرات. إذا لم توجد خصائص مخصصة، لا يقوم الحلقة بأي تغييرات.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **مثال حي**

جرّب التطبيق عبر الإنترنت [**عرض وتعديل بيانات تعريف PowerPoint**](https://products.aspose.app/slides/metadata) لتتعرف على كيفية العمل مع خصائص المستند باستخدام واجهة برمجة تطبيقات Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة هي جزء أساسي من العرض التقديمي ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كفارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقًا؟**

إذا أضفت خاصية مخصصة موجودة مسبقًا، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميله بالكامل؟**

نعم. استخدم [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) ثم [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) لقراءة بيانات تعريف المستند المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) . راجع [Build a Lightweight Presentation Inventory](/slides/ar/net/examine-presentation/) للحصول على مثال تقارير كامل وقيود خاصة بالصيغة.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفر دون كلمة مرور الفتح الخاصة به؟**

نعم. يجب أن يكون العرض قد تم تشفيره باستخدام [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) مع تعيين القيمة إلى `false`، ويجب تحميله باستخدام [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) مع تعيين القيمة إلى `true`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع خصائص-المستند-فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض بالكامل مع كلمة مرور الفتح الصحيحة.