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
description: "تحت السيطرة على خصائص العرض التقديمي في Aspose.Slides لـ .NET وتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides لإنشاء .NET الخصائص **المدمجة** و **المخصصة**. استخدم هذه الخصائص لقراءة وتحديث بيانات تعريف العرض التقديمي، مثل المؤلف والعنوان والقيم المعرفة من قبل المستخدم.

يتيح Aspose.Slides لك العمل مع خصائص مستند العرض التقديمي عبر الواجهة [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) . تُعيد هذه الواجهة كائنًا من خلال [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) . تُظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
يتعامل Aspose.Slides مع بيانات تعريف التطبيق والناشر عند حفظ العروض التقديمية؛ تُحدد هذه الحقول البرنامج الذي أنشأ المخرجات.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية إلى جانب محتوى العرض التقديمي. وتنقسم إلى فئتين:

- **الخصائص المدمجة** تحتوي على بيانات تعريف قياسية، مثل العنوان والمؤلف وإحصاءات المستند.
- **الخصائص المخصصة** تخزن أزواج اسم/قيمة يحددها المستخدم.

يوفر Aspose.Slides لإنشاء .NET إمكانية الوصول إلى كلا الفئتين. في PowerPoint، اختر **ملف → معلومات → خصائص → خصائص متقدمة** لتفحص بيانات تعريف المستند. يجمع الحوار المعلومات في علامات تبويب مثل **الملخص**، **الإحصاءات**، **المحتويات**، و **مخصص**. استخدم علامة التبويب **مخصص** لإدارة الخصائص المعرفة من قبل المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما يحمي كلمة مرور الفتح كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير العرض باستخدام [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) مع تعيين القيمة إلى `false`، تبقى خصائص المستند عامة. يمكن للتطبيق بعدها ضبط [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) إلى `true` وقراءة البيانات العامة دون تقديم كلمة مرور الفتح.

يتحكم [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) في ما يقوم Aspose.Slides بتحميله؛ لا يقوم بفك تشفير أي شيء. إذا تم تضمين الخصائص ضمن التشفير، فإن تحميلها بدون كلمة المرور سيفشل. إذا لم يكن العرض مشفرًا، يتم تجاهل الخيار ويُحمَّل العرض بالكامل.

يتطلب المثال عرضًا تقديميًا مشفرًا تُركت فيه خصائص المستند عامة. يتحقق من وضع التحميل عبر [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) ثم يقرأ الخصائص المدمجة عبر [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/):
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

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا فحص [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) قبل تنفيذ عملية تتطلب نموذج كائنات العرض الكامل.

{{% alert color="warning" title="Security" %}}
قد تكشف البيانات العامة عن أسماء المؤلفين والعناوين والموضوعات والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما تكون أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات تتطلب الوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

في حالة ملف PPTX مشفر، يُقصد من العرض المحمّل باستخدام [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) قراءة البيانات العامة. لا يمكن لـ Aspose.Slides حفظ الخصائص المعدلة من كائن يقتصر على البيانات العامة لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض المشفر. لذا يتطلب تحديثها كلمة مرور الفتح الصحيحة وتحميلًا كاملًا.

يتطلب المثال عرضًا تقديميًا PPTX مشفرًا مع خصائص مستند عامة وكلمة مرور فتح معروفة. يفتح العرض الكامل باستخدام [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/)، يحدّث الخصائص العامة المدمجة، ثم يحفظ النتيجة. بعد ذلك يستخدم [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) للتحقق من الحفاظ على التشفير ويعيد فتح البيانات العامة بدون كلمة مرور للتحقق من القيم الجديدة:
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

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض، يجب أن يتعامل مع الخصائص العامة لملف PPTX المشفر كقابلة للقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

تُظهر الواجهة [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) البيانات المدمجة عبر خصائص ذات نوع محدد، بما في ذلك [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)، [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/)، و[CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/). يفتح هذا المثال عرضًا تقديميًا موجودًا ويطبع البيانات المخزنة إلى وحدة التحكم. تعتمد القيم على العرض المدخل؛ قد تكون بعض الحقول فارغة.
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

### **الإبلاغ عن رقم المراجعة ووقت التحرير**

للتبليغ عن صفٍ واحد لكل ملف PPTX في مجلد `presentations`، استدعِ [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) لاسترجاع [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) دون تحميل الشرائح للتحرير. يتضمن التنسيق القياسي `c` لـ `TimeSpan` عدد الأيام عندما يصل المدة إلى 24 ساعة.
```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

نموذج إخراج لعرض تقديمي يحتوي على يوم واحد، ساعتين، و5 دقائق من وقت التحرير المسجل:
```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) هو بيانات تعريف قابلة للكتابة. لا يمكن لقيمته وحدها تحديد عدد مرات حفظ العرض التقديمي أو إعادة بناء تاريخ إصداراته.

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) هو مدة التحرير المسجلة في الملف. القيمة `00:00:00` تعني أن المدة المخزنة صفر. هذا لا يثبت أن لا أحد قام بتحرير العرض.

## **تعديل الخصائص المدمجة**

لتحديث البيانات المدمجة، عيّن قيمًا للخصائص القابلة للكتابة التي تُظهرها [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). يفتح هذا المثال عرضًا تقديميًا موجودًا، يضبط [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)، [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), و[Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/)، ثم يحفظ العرض المحدث باستخدام [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). يحتوي ملف PPTX المحفوظ على البيانات الجديدة.
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

## **إدارة قاعدة الارتباط التشعبي**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) يخزن القاعدة على مستوى المستند للارتباطات التشعبية النسبية. هذا مفيد عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. وهو منفصل عن [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) للارتباط التشعبي الفردي: تغيير القاعدة لا يعيد كتابة عناوين الروابط المخزنة ولا يغيّر الوجهات المطلقة.

يتطلب المثال عرضًا يحتوي على رابط نسبي، مثل `target.html`، ورابط مطلق، مثل `https://example.org/absolute.html`. يقرأ القاعدة الحالية، يعيّن عنوان قاعدة جديد، ثم يحفظ العرض ويعيد فتحه للتحقق من القيمة. بعد ذلك يمسح القاعدة باستخدام `string.Empty` ويتحقق من القيمة الفارغة في ملف محفوظ منفصل. استبدل عنوان القاعدة المثال بموقع ملفاتك المرتبطة.
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

يجب أن تطبع رسائل التحقق الاثنين القيمة `True`. مسح القاعدة يترك عناوين الروابط الفردية دون تغيير.

رابط نسبي إلى `target.pptx` كان يفتح `old/target.pptx` عندما كانت القاعدة تشير إلى مجلد `old`. بعد تغيير القاعدة إلى مجلد `new`، وحفظ وإعادة فتح العرض، فتح الرابط نفسه `new/target.pptx`. الرابط المطلق استمر في فتح نفس الملف. اختبر روابطك النسبية في PowerPoint قبل وبعد نقل العرض أو تغيير قاعدته.

## **إضافة خصائص عرض تقديمي مخصصة**

تخزن الخصائص المخصصة بيانات تعريف لا توجد لها حقل مدمج مطابق. يسمح [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) بتعيين قيمة حسب اسم الخاصية. ينشئ هذا المثال عرضًا تقديميًا، يضيف قيمتي نص وإصدار عدد صحيح، ويحفظ العرض باستخدام [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية.
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

يفتح هذا المثال عرضًا تقديميًا يحتوي على خصائص مخصصة ويستخدم [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) للتكرار عليها. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) تقبل فهرسًا يبدأ من الصفر وتعيد الاسم المستخدم من قبل [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/). يطبع المثال كل اسم وقيمة أصليين، يستبدل كل قيمة بسلسلة مرقمة بغض النظر عن نوعها الأصلي، ثم يحفظ التغييرات. إذا لم توجد خصائص مخصصة، لا يقوم الحلقة بأي تغييرات.
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

جرب التطبيق المتاح عبر الإنترنت [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) لترى كيفية العمل مع خصائص المستند باستخدام واجهة برمجة تطبيقات Aspose.Slides:
[![عرض وتحرير بيانات تعريف PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء أساسي من العرض التقديمي ولا يمكن إزالتها تمامًا. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كفارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقًا؟**

إذا أضفت خاصية مخصصة موجودة مسبقًا، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض دون تحميله بالكامل؟**

نعم. استخدم [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) ثم [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) لقراءة بيانات تعريف المستند المخزنة دون إنشاء مثيل [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/net/examine-presentation/) للحصول على مثال تقارير كامل وقيود خاصة بالتنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفر دون كلمة مرور الفتح الخاصة به؟**

نعم. يجب أن يكون العرض قد تم تشفيره باستخدام [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) مع تعيين القيمة إلى `false`، ويجب تحميله باستخدام [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) مع تعيين القيمة إلى `true`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع خصائص-المستند-فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض الكامل مع كلمة مرور الفتح الصحيحة.