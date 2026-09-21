---
title: إدارة حقول النص في عروض PowerPoint التقديمية باستخدام Java
linktitle: حقول النص
type: docs
weight: 52
url: /ar/java/text-fields/
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
- Java
- Aspose.Slides
description: "إنشاء، فحص، تعديل، وإزالة حقول النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Java. الحفاظ على التنسيق والتحقق من ملفات PPTX و PPT المحفوظة."
---
## **نظرة عامة**

يتكوّن فقرة نصية من أجزاء. يحتوي [IPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/) العادي على نص حرفي؛ يحتوي جزء الحقل أيضًا على [IField](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifield/) الذي يحدد نوع قيمة محدثة تلقائيًا، مثل رقم الشريحة أو التاريخ. يمكن لجزأين عرض نفس الأحرف بينما يحتوي أحدهما فقط على حقل.

استخدم [IPortion.getField](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#getField--) للتمييز بينهما: تكون قيمته `null` للنص العادي. يُحوِّل [IPortion.addField](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) جزءًا موجودًا إلى حقل. احتفظ بالملصق والقيمة الديناميكية في أجزاء منفصلة حتى لا يؤدي تحويل القيمة إلى استبدال الملصق.

هذا الدليل يغطي الحقول داخل النص، وتنسيقها، وحفظها في PPTX و PPT. لتعلم المزيد عن إطارات النص والفقرات، راجع [إدارة النص](/slides/ar/java/manage-text/).

## **إنشاء حقل رقم الشريحة**

المثال الكامل التالي ينشئ صندوق نص يحتوي على ملصق حرفي `Slide ` يليه رقم محدث تلقائيًا. يعيّن حجم الرقم ووزنه ولونه قبل إضافة الحقل، ثم يعيد فتح العرض التقديمي المحفوظ ويتحقق من نوع الحقل والنص والتنسيق. لا يلزم ملف إدخال.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

يبدأ العرض التقديمي الجديد برقم شريحة 1، لذا يصبح النص `Slide 1`، وتطبع كلتا المقارنتين `true`. يبقى الرقم حقلًا بعد إعادة الفتح؛ ليس نصًا حرفيًا `1`. الإحالات والفهارس في التحقق تشير إلى الشكل والأجزاء التي أنشأها هذا المثال.

## **اختر نوع الحقل**

[FieldType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fieldtype/) يطبق [IFieldType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifieldtype/) ويوفر الطرق التالية للحصول على قيم محددة مسبقًا. مرّر القيمة المناسبة إلى [addField](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| الطريقة | الغرض |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fieldtype/#getSlideNumber--) | رقم الشريحة الحالي. |
| [getDateTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fieldtype/#getDateTime--) | التاريخ/الوقت بصيغة التطبيق الافتراضية. |
| [getDateTime1](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fieldtype/#getDateTime9--) | تواريخ أو صيغ تاريخ/وقت مسبقة التعريف. |
| [getDateTime10](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fieldtype/#getDateTime13--) | صيغ وقت مسبقة التعريف، مع خيارات للثواني وساعة 12 ساعة. |
| [getHeader](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fieldtype/#getHeader--) | حقل رأس؛ راجع حدود العنصر النائب والتنسيق أدناه. |
| [getFooter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fieldtype/#getFooter--) | حقل تذييل. |

على سبيل المثال، [getDateTime3](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fieldtype/#getDateTime3--) يمثل اليوم واسم الشهر الكامل والسنة بالإنجليزية. هذه صيغ حقول مسبقة التعريف، ليست سلاسل تنسيق تاريخ Java تعسفية. اللغة المحددة بـ [setLanguageId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) والتطبيق الذي يعالج العرض التقديمي قد يؤثران على النتيجة المعروضة.

## **إنشاء حقل من سلسلة داخلية**

تقبل نسخة السلسلة من [addField](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#addField-java.lang.String-) معرّف حقل داخلي. استخدمها عندما تحتاج إلى الحفاظ على معرّف قدمه تطبيق آخر لا يملك قيمة مسبقة التعريف. يمكنك أيضًا إنشاء كائن [FieldType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) من المعرّف. ي expose [IFieldType.getInternalString](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifieldtype/#getInternalString--) هذا المعرّف للفحص.

هذا المثال يخزن حقلًا خاصًا بالتطبيق باسم `custom-report-id` مع نص بديل `Report-042`. المعرّف لا يسجل حسابًا: Aspose.Slides لا يولد معرفات تقارير لأنواع غير معروفة. يجب على التطبيق الذي يفهم هذا المعرّف أن يزود معناها ويحدّث قيمتها.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

بعد جولة حفظ وإعادة فتح PPTX، يكون النوع `custom-report-id` والنص `Report-042`. تمرير سلسلة مثل `yyyy-MM-dd` سيسمِّي نوع حقل؛ ولن يكوّن صيغة تاريخ مخصصة. للحصول على تاريخ ثابت بصيغة تعسفية، استخدم نصًا عاديًا.

## **فحص وتعديل وإزالة حقول التاريخ/الوقت**

غيّر حقلًا موجودًا عبر [IField.setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). تحقق من وجود الحقل قبل الوصول إلى نوعه. لإيقاف التحديثات التلقائية، استدعِ [IPortion.removeField](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#removeField--). هذا يحافظ على الجزء ونصه الحالي مع إزالة ارتباط الحقل. إذا احتجت قيمة ثابتة محددة، عيّن هذا النص بعد إزالة الحقل.

لإعداد API المتعلق بمعالجة حقول التاريخ/الوقت، انظر [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). يستخدم المثال أدناه تاريخ موافقة صريح عند تحويل حقل إلى نص عادي.

حمّل [sample.pptx](sample.pptx) وضعه في دليل العمل. يحتوي على شكلين نصيين مسميين، `UpdatedAt` و `ApprovedDate`، كلٌ به حقل تاريخ/وقت، بالإضافة إلى ملصقات نصية عادية. المثال التالي يتجول بين الأشكال النصية على الشرائح العادية. يغيّر حقول التاريخ/الوقت إلى صيغة تاريخ طويلة ويجعلها مائلة، مع الحفاظ على تنسيقاتها الأخرى. فقط الحقول في `ApprovedDate` تصبح نصًا ثابتًا.

العينة تتعرف على المعرفات الداخلية المدمجة `datetime` و `datetime1` حتى `datetime13`. المجموعات والجداول والملاحظات والتخطيطات والماستر تتطلب استعراض حاويات نصها الخاصة وخارج نطاق هذا المثال.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        String fixedDate = approvalDate.format(dateFormat);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

بعد إعادة الفتح، يكون لـ `UpdatedAt` النوع `datetime3` ويبقى ديناميكيًا. لا يحمل `ApprovedDate` حقلًا ويحتوي على `05 April 2030`. كلا الجزءين التاريخيين مائلان، وتبقى حجم الخط الأصلي وإعداد السميك واللون كما هو. ملصقات النص العادي لم تتغير. يقرأ التحقق الجزء الأول من الشكلين المعروفين في العينة المقدمة.

## **الحفاظ على تنسيق النص**

اعمل مع الجزء الموجود عند إضافة حقل أو تغيير نوعه أو إزالته. هذه العمليات تُبقي تنسيق الجزء. استخدم [IPortion.getPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#getPortionFormat--) لتغيير الخصائص المطلوبة فقط، كما تفعل الأمثلة للون أو الميل.

تجنّب إعادة بناء إطار نص كامل فقط لتحديث حقل واحد: قد يؤدي ذلك إلى فقدان حدود الأجزاء الأصلية وتنسيقها الفردي. كما ينبغي التفريق بين التنسيق المحدد صراحةً والتنسيق الموروث من الفقرة أو التخطيط أو السمة. راجع [تنسيق النص](/slides/ar/java/text-formatting/) لمزيد من خيارات التنسيق.

## **الحقول والعناصر النائبة للرأس/التذييل**

الحقل جزء من جزء نصي. العنصر النائب هو شكل له دور في العرض التقديمي، مثل تذييل أو رقم الشريحة. إضافة حقل إلى صندوق نص عادي لا تحول هذا الشكل إلى عنصر نائب.

تتحكم مديرات الرأس/التذييل في نص العنصر النائب ورؤيته على الشرائح، والتخطيطات، والماستر، بما في ذلك انتشارها إلى الشرائح التابعة. لذا قد يكون حقل رقم في صندوق نص مخصص مفيدًا حتى عندما لا تستخدم عنصر نائب رقم الشريحة. وعلى العكس، تعديل رؤية العنصر النائب لا يزيل حقلًا من صندوق نص غير مرتبط.

أنواع الرأس والتذييل المسبقة لا تنشئ العناصر النائبة المقابلة ولا تزود محتواها. على وجه الخصوص، لا تحتوي شريحة PowerPoint عادية على عنصر نائب رأس؛ الرؤوس تخص صفحات الملاحظات والنشرات. لا تفترض أن حقل رأس أو تذييل في شكل عشوائي سيحصل تلقائيًا على النص المكوّن عبر مدير العناصر النائبة. لهذا السيناريو، انظر [رؤوس وتذييلات العرض التقديمي](/slides/ar/java/presentation-header-and-footer/).

## **قيود PPTX و PPT**

تحقق من نوع الحقل والنص الناتج بعد الحفظ وإعادة الفتح. الحفاظ على معرف لا يثبت أن التطبيق قادر على حساب قيمته أو عرضها.

| الصيغة | سلوك الحقل والقيود |
|---|---|
| PPTX | يخزن معرفات الحقول الداخلية إلى جانب نص الحقل. في فحوصات جولة الحفظ، نجت الأنواع المسبقة ومعرف الحقل المخصص المستخدم أعلاه من الحفظ وإعادة الفتح. احتفظ النوع المخصص غير المعروف بنصه البديل؛ ولم يكتسب منطق حساب تلقائي. قد يتعامل تطبيق آخر مع المعرفات غير المدعومة بشكل مختلف. |
| PPT | يستخدم تمثيلات حقول قديمة ويملك توافقًا محدودًا أكثر. في فحوصات جولة الحفظ، نجت حقول رقم الشريحة والحقول التاريخية المسبقة من الحفظ وإعادة الفتح. يُعاد فتح حقل مخصص في صندوق نص شريحة عادي بمعرفه لكن نصه يصبح `*`؛ ويتسبب حقل رأس في نفس السياق أيضًا في إنتاج `*`. لا تعتمد على بقاء النص الظاهر للحقول المخصصة أو غير المدعومة. |

لإنتاج ثابت وقابل للنقل، حوّل الحقول غير المدعومة إلى نص عادي وعين القيمة التي تريدها صراحةً قبل الحفظ. هذا يحافظ على النص المختار لكنه يوقف التحديثات التلقائية عمدًا. اختبر التطبيق الهدف أيضًا عندما يكون إعادة حساب الحقول جزءًا من سير عملك.

## **الأسئلة الشائعة**

**كيف يمكنني معرفة ما إذا كان الرقم أو التاريخ المعروض حقلًا؟**

افحص [IPortion.getField](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#getField--). القيمة غير `null` تحدد حقلًا؛ لا يمكن للنص المعروض وحده أن يوضح ذلك.

**هل يؤدي إزالة الحقل إلى إزالة نصه أو تنسيقه؟**

لا. [removeField](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#removeField--) يحوّل الجزء الموجود إلى نص عادي. عيّن قيمة صريحة بعد ذلك إذا كنت تحتاج إلى تاريخ ثابت أو نص بديل.

**هل يمكن لسلسلة داخلية تعريف تنسيق تاريخ جديد أو صيغة؟**

لا. هي مجرد معرّف نوع حقل. المعرّف غير المعروف لا يقدم مقيمًا ولا نمط تنسيق تاريخ Java. استخدم نوعًا مسبقًا مدعومًا أو صيّق القيمة كنص عادي.

**لماذا يتم فحص العرض التقديمي مرة أخرى بعد حفظه؟**

معرفات الحقول، والنصوص المحسوبة، والتنسيق أشياء منفصلة يجب التحقق منها. يمكن أن يغيّر تحويل الصيغة النتيجة الظاهرة حتى عندما يبقى معرّف الحقل موجودًا.