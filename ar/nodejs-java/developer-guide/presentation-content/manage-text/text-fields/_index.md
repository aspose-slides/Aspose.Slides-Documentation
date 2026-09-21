---
title: إدارة حقول النص في عروض PowerPoint التقديمية باستخدام JavaScript
linktitle: حقول النص
type: docs
weight: 52
url: /ar/nodejs-java/text-fields/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء، فحص، تعديل وإزالة حقول النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ Node.js عبر Java. الحفاظ على التنسيق والتحقق من ملفات PPTX و PPT المحفوظة."
---
## **نظرة عامة**

يتكون فقرة نصية من أجزاء. يحتوي [Portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/) العادي على نص حرفي؛ يحتوي جزء الحقل أيضًا على [Field](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/field/) الذي يحدد نوع قيمة يتم تحديثها تلقائيًا، مثل رقم الشريحة أو التاريخ. يمكن لجزأين عرض نفس الأحرف بينما يحتوي أحدهما فقط على حقل.

استخدم [Portion.getField](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/#getField) للتمييز بينهما: تكون القيمة `null` للنص العادي. يقوم [Portion.addField](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/#addField) بتحويل جزء موجود إلى حقل. احتفظ بالعلامة والقيمة الديناميكية في أجزاء منفصلة حتى لا يستبدل تحويل القيمة العلامة أيضًا.

يغطي هذا الدليل الحقول داخل النص، وتنسيقها، وحفظها في PPTX و PPT. لإطارات النص والفقرات، راجع [إدارة النص](/slides/ar/nodejs-java/manage-text/).

## **إنشاء حقل رقم الشريحة**

المثال الكامل التالي ينشئ مربع نص يحتوي على تسمية حرفية `Slide ` تليها رقم يتم تحديثه تلقائيًا. يحدد حجم الرقم ووزنه ولونه قبل إضافة الحقل، ثم يعيد فتح العرض التقديمي المحفوظ ويفحص نوع الحقل والنص والتنسيق. لا يلزم ملف إدخال.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

يبدأ العرض التقديمي الجديد برقم شريحة 1، لذا يكون النص `Slide 1`، وكلا الفحصين يطبعان `true`. يظل الرقم حقلًا بعد إعادة الفتح؛ فهو ليس حرفيًا `1`. تشير الفهارس في التحقق إلى الشكل والأجزاء التي أنشأها هذا المثال.

## **اختيار نوع الحقل**

[FieldType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fieldtype/) يوفر الطرق التالية للحصول على قيم مسبقة. مرّر القيمة المناسبة إلى [addField](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/#addField).

| الطريقة | الغرض |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | رقم الشريحة الحالي. |
| [getDateTime](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fieldtype/#getDateTime) | التاريخ/الوقت بصيغة التطبيق الافتراضية عند العرض. |
| [getDateTime1](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | تاريخ مسبق أو صيغ تاريخ/وقت مركبة. |
| [getDateTime10](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | صيغ وقت مسبقة، مع خيارات للثواني وساعة 12 ساعة. |
| [getHeader](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fieldtype/#getHeader) | حقل رأس؛ راجع عنصر العنصر النائب وقيود التنسيق أدناه. |
| [getFooter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fieldtype/#getFooter) | حقل تذييل. |

على سبيل المثال، [getDateTime3](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fieldtype/#getDateTime3) يمثل يومًا، اسم شهر كامل، وسنة باللغة الإنجليزية. هذه صيغ حقل مسبقة، ليست سلاسل تنسيق تاريخ عشوائية. اللغة المحددة بـ [setLanguageId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) والتطبيق المعالج للعرض قد يؤثران على النتيجة المعروضة.

## **إنشاء حقل من سلسلة داخلية**

التحميل الزائد للسلسلة لـ [addField](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/#addField) يقبل معرف حقل داخلي. استخدمه عند الحفاظ على معرف مقدم من تطبيق آخر لا يحتوي على قيمة مسبقة. يمكنك أيضًا إنشاء [FieldType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fieldtype/) من المعرف. يفضح [FieldType.getInternalString](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fieldtype/#getInternalString) ذلك المعرف للفحص.

هذا المثال يخزن حقلًا مخصصًا لتطبيق معين `custom-report-id` مع النص الاحتياطي `Report-042`. المعرف لا يُسجل حسابًا: Aspose.Slides لا يولد معرفات تقارير لنوع غير معروف. يجب على التطبيق الذي يفهم هذا المعرف توفير معناه وتحديث قيمته.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

بعد هذه الجولة في PPTX، يكون النوع `custom-report-id` والنص `Report-042`. تمرير سلسلة مثل `yyyy-MM-dd` سيُسمي نوع حقل؛ لن يكوّن تنسيق تاريخ مخصص. للحصول على تاريخ ثابت بصيغة عشوائية، استخدم نصًا عاديًا.

## **فحص، تعديل، وإزالة حقول التاريخ/الوقت**

قم بتغيير حقل موجود عبر [Field.setType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/field/#setType). تأكد من وجود الحقل قبل الوصول إلى نوعه. لإيقاف التحديثات التلقائية، استدعِ [Portion.removeField](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/#removeField). هذا يحتفظ بالجزء ونصه الحالي مع إزالة ارتباط الحقل. إذا كنت تحتاج قيمة ثابتة معينة، عيّن ذلك النص بعد إزالة الحقل.

لإعداد API المتعلق بمعالجة حقول التاريخ/الوقت، راجع [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). المثال أدناه يستخدم تاريخ موافقة صريح عند تحويل حقل إلى نص عادي.

حمّل [sample.pptx](sample.pptx) وضعه في دليل العمل. يحتوي على شكلين نصيين مسمين، `UpdatedAt` و `ApprovedDate`، كلٌ به حقل تاريخ/وقت، بالإضافة إلى تسميات نصية عادية. المثال التالي يتجول في أشكال النص المستوى العلوي على الشرائح العادية. يغيّر حقول التاريخ/الوقت إلى صيغة تاريخ طويل ويجعلها مائلة، مع الحفاظ على تنسيقها الآخر. فقط الحقول في `ApprovedDate` تتحول إلى نص ثابت.

تاريخ الموافقة هو 5 أبريل 2030؛ فهارس الأشهر في JavaScript تبدأ من الصفر، لذا أبريل هو `3`. يُستخدم UTC لكل من الإنشاء والتنسيق للحفاظ على أن يكون التاريخ مستقلاً عن المنطقة الزمنية المحلية.

العينة تتعرف على المعرفات الداخلية المدمجة `datetime` و `datetime1` إلى `datetime13`. المجموعات، الجداول، الملاحظات، التخطيطات، والماستر تتطلب استعراض حاويات النص الخاصة بها وهي خارج نطاق هذا المثال.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

بعد إعادة الفتح، يكون لـ `UpdatedAt` النوع `datetime3` ويبقى ديناميكيًا. لا يحتوي `ApprovedDate` على حقل ويحتوي على `05 April 2030`. كلا الجزءين التاريخيين مائلان، ويظل حجم الخط الأصلي، وإعداد الغامق، واللون كما هو. تسميات النص العادية لم تتغير. يقرأ التحقق الجزء الأول من الشكلين المعروفين في العينة المقدمة.

## **حفظ تنسيق النص**

اعمل مع الجزء الموجود عند إضافة حقل، أو تغيير نوعه، أو إزالته. هذه العمليات تحتفظ بتنسيق ذلك الجزء. استخدم [Portion.getPortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/#getPortionFormat) لتغيير الخصائص المطلوبة فقط، كما تفعل الأمثلة للون أو الميلان.

تجنب إعادة بناء إطار نص كامل لمجرد تحديث حقل واحد: قد يؤدي ذلك إلى فقدان حدود الجزء الأصلية وتنسيقها الفردي. كذلك ميز بين التنسيق المحدد صراحةً والتنسيق الموروث من الفقرة أو التخطيط أو السمة. راجع [تنسيق النص](/slides/ar/nodejs-java/text-formatting/) للحصول على خيارات تنسيق أوسع.

## **الحقول وعناصر العنصر النائب للرأس/التذييل**

الحقل هو جزء من جزء نص. العنصر النائب هو شكل له دور عرض، مثل تذييل أو رقم شريحة. إضافة حقل إلى مربع نص عادي لا يحول ذلك الشكل إلى عنصر نائب.

يدير مديرو الرأس/التذييل نص العنصر النائب والرؤية على الشرائح، التخطيطات، والماسترس، بما في ذلك الانتشار إلى الشرائح التابعة. لذا قد يكون حقل رقم في مربع نص مخصص مفيدًا حتى إذا لم تكن تستخدم العنصر النائب لرقم الشريحة. على العكس، تغيير رؤية العنصر النائب لا يزيل الحقل من مربع نص غير متعلق.

أنواع الرأس والتذييل المسبقة لا تُنشئ العناصر النائبة المقابلة ولا تزودها بالمحتوى. على وجه الخصوص، لا تحتوي شريحة PowerPoint عادية على عنصر نائب للرأس؛ الرؤوس تخص صفحات الملاحظات والنشرات. لا تفترض أن حقل رأس أو تذييل في شكل عشوائي سيحصل تلقائيًا على النص المُكوَّن عبر مدير العنصر النائب. لهذا التدفق، راجع [رؤوس وتذييلات العرض](/slides/ar/nodejs-java/presentation-header-and-footer/).

## **قيود PPTX و PPT**

تحقق من كل من نوع الحقل والنص الناتج بعد الحفظ وإعادة الفتح. حفظ معرف لا يثبت أن التطبيق يمكنه حساب أو عرض قيمته.

| الصيغة | سلوك الحقل والقيود |
|---|---|
| PPTX | يخزن معرّفات الحقول الداخلية بجانب نص الحقل. في فحوصات الجولة، نجت الأنواع المسبقة والمعرف المخصص المستخدم أعلاه من الحفظ وإعادة الفتح. احتفظ النوع المخصص غير المعروف بنصه الاحتياطي؛ لم يكتسب منطق حساب تلقائي. قد يتعامل تطبيق آخر مع المعرفات غير المدعومة بصورة مختلفة. |
| PPT | يستخدم تمثيلات حقول قديمة ويملك توافقًا محدودًا أكثر. في فحوصات الجولة، نجت حقول رقم الشريحة والحقول التاريخ/الوقت المسبقة من الحفظ وإعادة الفتح. حقل مخصص في مربع نص شريحة عادي أعيد فتحه بمعرفه لكن بنص `*`؛ حقل رأس في نفس السياق أنتج أيضًا `*`. لا تعتمد على بقاء النص الظاهر للحقول المخصصة أو سياقات الحقول غير المدعومة. |

لإنتاج ثابت ومحمول، حوِّل الحقول غير المدعومة إلى نص عادي وعين القيمة المطلوبة صراحةً قبل الحفظ. هذا يحفظ النص المختار لكنه يوقف التحديثات التلقائية عن قصد. اختبر التطبيق المستهدف أيضًا عندما تكون عملية إعادة حساب الحقول الخاصة به جزءًا من سير العمل.

## **الأسئلة المتكررة**

**كيف يمكنني معرفة ما إذا كان الرقم أو التاريخ المعروض هو حقل؟**

افحص [Portion.getField](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/#getField). قيمة غير `null` تُحدد وجود حقل؛ لا يمكن للنص المعروض وحده أن يخبرك بذلك.

**هل إزالة حقل تُزيل نصه أو تنسيقه؟**

لا. تُحوِّل [removeField](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/#removeField) الجزء الموجود إلى نص عادي. عيّن قيمة صريحة بعد ذلك إذا كنت تحتاج تاريخًا مجمَّدًا أو نصًا احتياطيًا.

**هل يمكن لسلسلة داخلية تعريف تنسيق تاريخ جديد أو صيغة؟**

لا. هي مجرد معرف لنوع حقل. المعرف غير المعروف لا يوفر مُقيِّمًا أو نمط تنسيق تاريخ. استخدم نوعًا مسبقًا مدعومًا أو نسّق القيمة كنص عادي.

**لماذا أتحقق من العرض مرة أخرى بعد حفظه؟**

معرّفات الحقول، النص المحسوب، والتنسيق أمور منفصلة تحتاج إلى تحقق. قد يغيّر تحويل الصيغة النتيجة المرئية حتى عندما يبقى معرف الحقل موجودًا.