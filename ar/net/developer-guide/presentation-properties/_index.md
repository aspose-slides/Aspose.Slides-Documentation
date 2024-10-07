---
title: خصائص العرض - الوصول إلى أو تعديل خصائص عرض PowerPoint في C#
linktitle: خصائص العرض
type: docs
weight: 70
url: /net/presentation-properties/
keywords: "كيف أزيل آخر تعديل بواسطة في PowerPoint، خصائص PowerPoint، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "خصائص عرض PowerPoint في C# أو .NET"
---

## **مثال حي**
حاول [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) التطبيق عبر الإنترنت لرؤية كيفية العمل مع خصائص الوثيقة عبر واجهة برمجة تطبيقات Aspose.Slides:

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **حول خصائص العرض**
كما أوضحنا سابقًا، فإن Aspose.Slides لـ .NET يدعم نوعين من خصائص الوثائق، وهما الخصائص **المدمجة** و**المخصصة**. لذا يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام واجهة برمجة تطبيقات Aspose.Slides لـ .NET. توفر Aspose.Slides لـ .NET فئة [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties) التي تمثل خصائص الوثيقة المرتبطة بملف العرض من خلال خاصية [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/properties/index). يمكن للمطورين استخدام خاصية [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties) المعرضة بواسطة كائن **Presentation** للوصول إلى خصائص الوثيقة لملفات العرض كما هو موضح أدناه:

{{% alert color="primary" %}} 

يرجى ملاحظة أنه لا يمكنك تعيين قيم على الحقول **Application** و**Producer**، لأن Aspose Ltd. وAspose.Slides لـ .NET x.x.x ستظهر ضد هذه الحقول.

{{% /alert %}} 

## **إدارة خصائص العرض**
تقدم Microsoft PowerPoint ميزة لإضافة بعض الخصائص لملفات العرض. تتيح هذه الخصائص الوثائق تخزين بعض المعلومات المفيدة إلى جانب الوثائق (ملفات العرض). هناك نوعان من خصائص الوثائق كما يلي:

- خصائص محددة من النظام (مضمنة)
- خصائص محددة من المستخدم (مخصصة)

تحتوي الخصائص **المدمجة** على معلومات عامة حول الوثيقة مثل عنوان الوثيقة واسم المؤلف وإحصائيات الوثيقة وما إلى ذلك. الخصائص **المخصصة** هي تلك التي يتم تعريفها بواسطة المستخدمين كأزواج **اسم/قيمة**، حيث يتم تعريف كل من الاسم والقيمة بواسطة المستخدم. باستخدام Aspose.Slides لـ .NET، يمكن للمطورين الوصول إلى وتعديل قيم الخصائص المدمجة بالإضافة إلى الخصائص المخصصة. يسمح Microsoft PowerPoint 2007 بإدارة خصائص الوثيقة لملفات العرض. كل ما عليك فعله هو النقر على رمز Office ثم على عنصر القائمة **إعداد | الخصائص | الخصائص المتقدمة** في Microsoft PowerPoint 2007. بعد اختيارك عنصر القائمة **الخصائص المتقدمة**، ستظهر لك نافذة حوار تسمح لك بإدارة خصائص الوثيقة لملف PowerPoint. في **نافذة خصائص الحوار**، يمكنك رؤية العديد من صفحات التبويب مثل **العام، الملخص، الإحصائيات، المحتويات والمخصص**. جميع هذه الصفحات السماح بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم علامة **المخصص** لإدارة الخصائص المخصصة لملفات PowerPoint.
## **الوصول إلى الخصائص المدمجة**
تتضمن الخصائص التي تعرضها كائن **IDocumentProperties**: **المؤلف**، **الوصف**، **الكلمات المفتاحية**، **تاريخ الإنشاء**، **تاريخ التعديل**، **تاريخ الطباعة الأخيرة**، **آخر تعديل بواسطة**، **الكلمات المفتاحية**، **مشاركة الوثيقة** (هل تشارك بين منتجين مختلفين؟)، **تنسيق العرض**، **الموضوع** و**العنوان**.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessBuiltinProperties-AccessBuiltinProperties.cs" >}}
## **تعديل الخصائص المدمجة**
تعديل الخصائص المدمجة لملفات العرض سهل مثل الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية مرغوبة وسيتم تعديل قيمة الخاصية. في المثال الموضح أدناه، قمنا بتوضيح كيفية تعديل خصائص الوثيقة المدمجة لملف العرض.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-ModifyBuiltinProperties-ModifyBuiltinProperties.cs" >}}

## **إضافة خصائص عرض مخصصة**
يسمح Aspose.Slides لـ .NET أيضًا للمطورين بإضافة القيم المخصصة لخصائص الوثيقة الخاصة بالعرض. المثال الموضح أدناه يوضح كيف يمكن تعيين الخصائص المخصصة لعرض.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AddCustomDocumentProperties-AddCustomDocumentProperties.cs" >}}

## **الوصول إلى وتعديل الخصائص المخصصة**
يسمح Aspose.Slides لـ .NET أيضًا للمطورين بالوصول إلى قيم الخصائص المخصصة. المثال الموضح أدناه يوضح كيف يمكنك الوصول إلى وتعديل جميع هذه الخصائص المخصصة لعروض تقديمية.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessModifyingProperties-AccessModifyingProperties.cs" >}}

## **تحقق مما إذا كان العرض قد تم تعديله أو إنشاؤه**
يوفر Aspose.Slides لـ .NET وسيلة للتحقق مما إذا كان العرض قد تم تعديله أو إنشاؤه. المثال الموضح أدناه يوضح كيفية التحقق مما إذا كان العرض قد تم إنشاؤه أو تعديله.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-CheckPresentationCreatedorModifed-CheckPresentationCreatedorModifed.cs" >}}

تعيين اللغة الافتراضية

## **تعيين لغة التدقيق**

يوفر Aspose.Slides خاصية [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) (المعرضة من خلال فئة [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)) للسماح لك بتعيين لغة التدقيق لوثيقة PowerPoint. لغة التدقيق هي اللغة التي يتم التحقق من التهجئة والنحو فيها في PowerPoint.

يظهر كود C# أدناه كيفية تعيين لغة التدقيق لوثيقة PowerPoint:

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // تعيين Id للغة تدقيق
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **تعيين اللغة الافتراضية**

يظهر كود C# أدناه كيفية تعيين اللغة الافتراضية لعرض PowerPoint بالكامل: 

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // إضافة شكل مستطيل جديد مع نص
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "نص جديد";
    
    // التحقق من لغة الجزء الأول
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```