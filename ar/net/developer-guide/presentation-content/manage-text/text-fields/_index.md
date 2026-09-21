---
title: إدارة حقول النص في عروض PowerPoint التقديمية باستخدام .NET
linktitle: حقول النص
type: docs
weight: 52
url: /ar/net/text-fields/
keywords:
- حقل نص
- نص تلقائي
- رقم الشريحة
- التاريخ والوقت
- رأس
- تذييل
- جزء نص
- PowerPoint
- PPT
- PPTX
- C#
- Aspose.Slides
description: "إنشاء، فحص، تعديل وإزالة حقول النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ .NET. الحفاظ على التنسيق والتحقق من ملفات PPTX و PPT المحفوظة."
---
## **نظرة عامة**

يتكون فقرة نصية من أجزاء. يحتوي [IPortion](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/) عادي على نص حرفي؛ يحتوي جزء الحقل أيضًا على [IField](https://reference.aspose.com/slides/ar/net/aspose.slides/ifield/) حيث يحدد النوع قيمة يتم تحديثها تلقائيًا، مثل رقم الشريحة أو التاريخ. يمكن لجزئين عرض نفس الأحرف بينما يحتوي أحدهما فقط على حقل.

استخدم [IPortion.Field](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/field/) للتمييز بينهما: تكون `null` للنص العادي. تقوم [IPortion.AddField](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/addfield/) بتحويل جزء موجود إلى حقل. احفظ التسمية والقيمة الديناميكية في أجزاء منفصلة حتى لا يؤدي تحويل القيمة إلى استبدال التسمية.

يغطي هذا الدليل الحقول داخل النص، وتنسيقها، وحفظها بصيغتي PPTX و PPT. للحصول على إطارات النص والفقرات، انظر [Manage Text](/slides/ar/net/manage-text/).

## **إنشاء حقل رقم الشريحة**

المثال الكامل التالي ينشئ مربع نص يحتوي على تسمية حرفية `Slide ` تليها رقم يتم تحديثه تلقائيًا. يضبط حجم الرقم ووزنه ولونه قبل إضافة الحقل، ثم يعيد فتح العرض التقديمي المحفوظ ويتحقق من نوع الحقل والنص وتنسيقه. لا يلزم ملف إدخال.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

يبدأ العرض التقديمي الجديد برقم الشريحة 1، لذا يكون النص `Slide 1`، وكلا الفحصين يطبعان `True`. يظل الرقم حقلًا بعد إعادة الفتح؛ فهو ليس حرفيًا `1`. التحويلات والفهارس في التحقق تشير إلى الشكل والأجزاء التي أنشأها هذا المثال.

## **اختر نوع الحقل**

[FieldType](https://reference.aspose.com/slides/ar/net/aspose.slides/fieldtype/) يطبق [IFieldType](https://reference.aspose.com/slides/ar/net/aspose.slides/ifieldtype/) ويوفر القيم المعرّفة مسبقًا التالية. مرر القيمة المناسبة إلى [AddField](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/addfield/).

| القيمة | الغرض |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/ar/net/aspose.slides/fieldtype/slidenumber/) | رقم الشريحة الحالي. |
| [DateTime](https://reference.aspose.com/slides/ar/net/aspose.slides/fieldtype/datetime/) | التاريخ/الوقت بصيغة التطبيق العارض الافتراضية. |
| [DateTime1](https://reference.aspose.com/slides/ar/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/ar/net/aspose.slides/fieldtype/datetime9/) | صيغ تاريخ محددة مسبقًا أو صيغ تاريخ/وقت مركبة. |
| [DateTime10](https://reference.aspose.com/slides/ar/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/ar/net/aspose.slides/fieldtype/datetime13/) | صيغ وقت محددة مسبقًا، مع خيارات للثواني وساعة 12 ساعة. |
| [Header](https://reference.aspose.com/slides/ar/net/aspose.slides/fieldtype/header/) | حقل رأس؛ انظر قيود العنصر النائب والتنسيق أدناه. |
| [Footer](https://reference.aspose.com/slides/ar/net/aspose.slides/fieldtype/footer/) | حقل تذييل. |

على سبيل المثال، يمثل [DateTime3](https://reference.aspose.com/slides/ar/net/aspose.slides/fieldtype/datetime3/) اليوم واسم الشهر بالكامل والسنة باللغة الإنجليزية. هذه صيغ حقول محددة مسبقًا، ليست سلاسل تنسيق تاريخ .NET عشوائية. يمكن أن يؤثر [LanguageId](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/languageid/) الخاص بالجزء والتطبيق الذي يعالج العرض التقديمي على النتيجة المعروضة.

## **إنشاء حقل من سلسلة داخلية**

إصدار السلسلة من [AddField](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/addfield/) يقبل معرف حقل داخلي. استخدمه عند الحفاظ على معرف مقدم من تطبيق آخر لا يملك قيمة محددة مسبقًا. يمكنك أيضًا إنشاء [FieldType](https://reference.aspose.com/slides/ar/net/aspose.slides/fieldtype/fieldtype/) من المعرف. [IFieldType.InternalString](https://reference.aspose.com/slides/ar/net/aspose.slides/ifieldtype/internalstring/) يُظهر ذلك المعرف للتفحص.

يحفظ هذا المثال حقلًا خاصًا بالتطبيق `custom-report-id` مع النص الاحتياطي `Report-042`. المعرف لا يُسجِّل حسابًا: Aspose.Slides لا يولد معرفات تقارير لنوع غير معروف. يجب على التطبيق الذي يفهم هذا المعرف توفير معناه وتحديث قيمته.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

بعد هذه الدورة لمستند PPTX، يكون النوع `custom-report-id` والنص `Report-042`. تمرير سلسلة مثل `yyyy-MM-dd` سيُسمّي نوع حقل؛ لن يُكوّن تنسيق تاريخ مخصص. للحصول على تاريخ ثابت بصيغة عشوائية، استخدم نصًا عاديًا.

## **تفحص، تعديل وإزالة حقول التاريخ/الوقت**

اقرأ وغيّر حقلًا موجودًا عبر [IField.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/ifield/type/). تأكد من وجود الحقل قبل الوصول إلى نوعه. لإيقاف التحديثات التلقائية، استدعِ [IPortion.RemoveField](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/removefield/). هذا يحتفظ بالجزء ونصه الحالي بينما يزيل ارتباط الحقل. إذا كنت بحاجة إلى قيمة ثابتة محددة، عيّن ذلك النص بعد إزالة الحقل.

لإعداد API المتعلق بمعالجة حقول التاريخ/الوقت، انظر [Presentation.CurrentDateTime](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/currentdatetime/). المثال أدناه يستخدم تاريخ موافقة صريح عند تحويل حقل إلى نص عادي.

نزّل [sample.pptx](sample.pptx) وضعه في دليل العمل. يحتوي على شكلين نصيين مسميين، `UpdatedAt` و `ApprovedDate`، كل منهما يحتوي على حقل تاريخ/وقت، بالإضافة إلى تسميات نصية عادية. المثال التالي يستعرض أشكال النص المستوى الأعلى في الشرائح العادية. يغيّر حقول التاريخ/الوقت إلى صيغة تاريخ طويلة ويجعلها مائلة، مع الحفاظ على تنسيقاتها الأخرى. فقط الحقول في `ApprovedDate` تصبح نصًا ثابتًا.

العينة تُعرّف المعرفات الداخلية المدمجة `datetime` و `datetime1` إلى `datetime13`. المجموعات والجداول والملاحظات والتصميمات والماسترات تحتاج إلى استعراض حاويات النص الخاصة بها وهذا خارج نطاق هذا المثال.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

بعد إعادة الفتح، يكون لـ `UpdatedAt` النوع `datetime3` ويبقى ديناميكيًا. لا يحتوي `ApprovedDate` على حقل ويحتوي على `05 April 2030`. كلا جزئي التاريخ مائلان، وحجم الخط الأصلي وإعداد السُمك واللون يبقى كما هو. تسميات النص العادية لم تتغير. التحقق يقرأ الجزء الأول من الشكلين المعروفين في العينة المقدمة.

## **حافظ على تنسيق النص**

اعمل مع الجزء الحالي عند إضافة حقل، أو تغيير نوعه، أو إزالته. تحتفظ هذه العمليات بتنسيق ذلك الجزء. استخدم [IPortion.PortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/portionformat/) لتغيير الخصائص المطلوبة فقط، كما تفعل الأمثلة للون أو الميلان.

تجنّب إعادة بناء إطار نص كامل فقط لتحديث حقل واحد: قد يؤدي ذلك إلى فقدان حدود الأجزاء الأصلية وتنسيقها الفردي. كذلك، فرق بين التنسيق المحدد صراحةً والتنسيق الموروث من الفقرة أو التخطيط أو السمة. انظر [Text Formatting](/slides/ar/net/text-formatting/) للحصول على خيارات تنسيق أوسع.

## **الحقول وعناصر النائب للرأس/التذييل**

الحقل هو جزء من جزء نص. العنصر النائب هو شكل له دور في العرض التقديمي، مثل تذييل أو رقم الشريحة. إضافة حقل إلى مربع نص عادي لا يحول هذا الشكل إلى عنصر نائب.

تتحكم مديرات الرأس/التذييل في نص العنصر النائب وعلى رؤيته في الشرائح والتصميمات والماسترات، بما في ذلك النشر إلى الشرائح التابعة. لذا يمكن أن يكون حقل رقم في مربع نص مخصص مفيدًا حتى إذا لم تكن تستخدم عنصر نائب رقم الشريحة. وعلى العكس، تغيير رؤية العنصر النائب لا يزيل حقلًا من مربع نص غير مرتبط.

أنواع الرأس والتذييل المعرّفة مسبقًا لا تنشئ العناصر النائبة المقابلة ولا تزودها بالمحتوى. على وجه الخصوص، لا تحتوي الشريحة العادية في PowerPoint على عنصر نائب رأس؛ فإن الرؤوس تخص صفحات الملاحظات والنشرات. لا تفترض أن حقل رأس أو تذييل في شكل عشوائي سيحصل تلقائيًا على النص المكوّن عبر مدير العنصر النائب. لهذا التدفق، انظر [Presentation Headers and Footers](/slides/ar/net/presentation-header-and-footer/).

## **قيود PPTX و PPT**

تحقق من كل من نوع الحقل والنص الناتج بعد الحفظ وإعادة الفتح. الحفاظ على معرف لا يثبت أن التطبيق يستطيع حساب أو عرض قيمته.

| التنسيق | سلوك الحقل والقيود |
|---|---|
| PPTX | يخزن معرّفات الحقول الداخلية مع نص الحقل. في فحوصات دورة الإغلاق، نجت الأنواع المعرّفة مسبقًا والمعرف المخصص المستخدم أعلاه من الحفظ وإعادة الفتح. احتفظ النوع المخصص غير المعروف بالنص الاحتياطي الخاص به؛ لم يحصل على منطق حساب تلقائي. قد يتعامل تطبيق آخر مع المعرفات غير المدعومة بشكل مختلف. |
| PPT | يستخدم تمثيلات حقول قديمة وله توافقية محدودة أكثر. في فحوصات دورة الإغلاق، نجت حقول رقم الشريحة والحقول المعرّفة مسبقًا للتاريخ/الوقت من الحفظ وإعادة الفتح. أعيد فتح حقل مخصص في مربع نص شريحة عادي بمعرفه لكن بنص `*`؛ كما أن حقل رأس في نفس السياق أنتج `*`. لا تعتمد على احتفاظ الحقول المخصصة أو السياقات غير المدعومة بنصها الظاهر. |

للحصول على مخرجات ثابتة قابلة للنقل، حوِّل الحقول غير المدعومة إلى نص عادي وعيّن صراحةً القيمة التي تريدها قبل الحفظ. هذا يحافظ على النص المختار لكنه يوقف التحديثات التلقائية عمدًا. اختبر التطبيق الهدف أيضًا عندما يكون إعادة حساب حقوله جزءًا من سير عملك.

## **الأسئلة الشائعة**

**كيف يمكنني معرفة ما إذا كان الرقم أو التاريخ المعروض هو حقل؟**

تحقق من [IPortion.Field](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/field/). قيمة غير فارغة تحدد وجود حقل؛ النص المعروض وحده لا يمكنه إخبارك بذلك.

**هل إزالة الحقل تزيل نصه أو تنسيقه؟**

لا. [RemoveField](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/removefield/) يُحوِّل الجزء الحالي إلى نص عادي. عيّن قيمة صريحة بعد ذلك إذا كنت بحاجة إلى تاريخ ثابت أو قيمة احتياطية محددة.

**هل يمكن لسلسلة داخلية تعريف تنسيق تاريخ جديد أو صيغة؟**

لا. إنها تُحدد نوع الحقل. معرف غير معروف لا يوفر مُقَيِّمًا أو نمط تنسيق تاريخ .NET. استخدم نوعًا معرّفًا مسبقًا مدعومًا أو صغِّ قيمة بنفسك كنص عادي.

**لماذا يتم فحص العرض التقديمي مرة أخرى بعد حفظه؟**

معرفات الحقول والنص المحسوب والتنسيق هي أشياء منفصلة يجب التحقق منها. يمكن أن يغيّر تحويل الصيغة النتيجة الظاهرة حتى وإن ظل معرف الحقل موجودًا.