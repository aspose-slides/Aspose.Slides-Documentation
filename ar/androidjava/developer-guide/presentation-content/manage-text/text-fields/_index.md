---
title: إدارة حقول النص في عروض PowerPoint على Android
linktitle: حقول النص
type: docs
weight: 52
url: /ar/androidjava/text-fields/
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
- Android
- Java
- Aspose.Slides
description: "إنشاء، فحص، تعديل وإزالة حقول النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides لنظام Android عبر Java. الحفاظ على التنسيق والتحقق من ملفات PPTX و PPT المحفوظة."
---
## **نظرة عامة**

فقرة نصية تتكون من أجزاء. الجزء العادي [IPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/) يحتوي على نص حرفي؛ الجزء الحقل يحتوي أيضًا على [IField](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifield/) يحدد نوعه قيمة محدثة تلقائيًا، مثل رقم الشريحة أو التاريخ. يمكن لجزئين عرض نفس الأحرف بينما يحتوي واحد فقط على حقل.

استخدم [IPortion.getField](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#getField--) للتمييز بينهما: تكون قيمته `null` للنص العادي. [IPortion.addField](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) يحول الجزء الموجود إلى حقل. احتفظ بالعلامة والقيمة الديناميكية في أجزاء منفصلة حتى لا يستبدل تحويل القيمة العلامة.

هذا الدليل يغطي الحقول داخل النص، تنسيقها، وحفظها في PPTX و PPT. بالنسبة لإطارات النص والفقرات، راجع [إدارة النص](/slides/ar/androidjava/manage-text/).

## **إنشاء حقل رقم الشريحة**

المثال الكامل التالي ينشئ مربع نص يحتوي على علامة حرفية `Slide ` يتبعها رقم يتم تحديثه تلقائيًا. يضبط حجم الرقم ووزنه ولونه قبل إضافة الحقل، ثم يعيد فتح العرض التقديمي المحفوظ ويتحقق من نوع الحقل والنص والتنسيق. لا يلزم ملف إدخال.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

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

العرض التقديمي الجديد يبدأ برقم شريحة 1، لذا يصبح النص `Slide 1`، وتطبع كلا الفحصين `true`. يبقى الرقم حقلًا بعد إعادة الفتح؛ ليس نصًا حرفيًا `1`. الإحالات والفهارس في التحقق تشير إلى الشكل والأجزاء التي أنشأها هذا المثال.

## **اختيار نوع الحقل**

[FieldType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fieldtype/) ينفذ [IFieldType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifieldtype/) ويوفر الطرق التالية للحصول على قيم معرفة مسبقًا. مرر القيمة المناسبة إلى [addField](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| الطريقة | الغرض |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | رقم الشريحة الحالي. |
| [getDateTime](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | التاريخ/الوقت بالتنسيق الافتراضي لتطبيق العرض. |
| [getDateTime1](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | تواريخ محددة مسبقًا أو تنسيقات مدمجة للتاريخ/الوقت. |
| [getDateTime10](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | تنسيقات وقت محددة مسبقًا، مع خيارات للثواني وساعة 12 ساعة. |
| [getHeader](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fieldtype/#getHeader--) | حقل رأس؛ راجع قيود العنصر النائب والتنسيق أدناه. |
| [getFooter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fieldtype/#getFooter--) | حقل تذييل. |

على سبيل المثال، [getDateTime3](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) يمثل اليوم واسم الشهر بالكامل والسنة بالإنجليزية. هذه تنسيقات حقول معرفة مسبقًا، ليست سلاسل تنسيق تاريخ Java عشوائية. اللغة المحددة بـ [setLanguageId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) والتطبيق المعالج للعرض يمكن أن يؤثرا على النتيجة المعروضة.

## **إنشاء حقل من سلسلة داخلية**

إصدار السلسلة من [addField](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) يقبل معرف حقل داخلي. استخدمه عند الحفاظ على معرف مقدم من تطبيق آخر لا يملك قيمة معرفة مسبقًا. يمكنك أيضًا إنشاء كائن [FieldType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) من المعرف. [IFieldType.getInternalString](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) يكشف عن هذا المعرف للتفحص.

هذا المثال يخزن حقلًا خاصًا بالتطبيق `custom-report-id` مع النص الاحتياطي `Report-042`. المعرف لا يسجل حسابًا: Aspose.Slides لا يولد معرفات تقارير لأنواع غير معروفة. التطبيق الذي يفهم هذا المعرف يجب أن يوفر معناه ويحدث قيمته.

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

بعد هذه الجولة في PPTX، يصبح النوع `custom-report-id` والنص `Report-042`. تمرير سلسلة مثل `yyyy-MM-dd` سيُسَمي نوع حقل؛ لن يضبط تنسيق تاريخ مخصص. لتاريخ ثابت بتنسيق عشوائي استخدم نصًا عاديًا.

## **فحص وتعديل وإزالة حقول التاريخ/الوقت**

غيّر حقلًا موجودًا عبر [IField.setType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). تحقق من وجود الحقل قبل الوصول إلى نوعه. لإيقاف التحديثات التلقائية، استدعِ [IPortion.removeField](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#removeField--). هذا يبقي الجزء ونصيّه الحالي مع إزالة ارتباط الحقل. إذا احتجت إلى قيمة ثابتة محددة، عيّن ذلك النص بعد إزالة الحقل.

للإعداد المتعلق بمعالجة حقول التاريخ/الوقت، راجع [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). المثال أدناه يستخدم تاريخ موافقة صريح عند تحويل حقل إلى نص عادي.

حمِّل [sample.pptx](sample.pptx) وضعه في دليل العمل. يحتوي على شكلين نصيين مُسمّيين، `UpdatedAt` و `ApprovedDate`، كل منهما يحتوي على حقل تاريخ/وقت، بالإضافة إلى علامات نصية عادية. المثال التالي يتجول عبر الأشكال النصية العليا في الشرائح العادية. يغيّر حقول التاريخ/الوقت إلى تنسيق تاريخ طويل ويجعله مائلًا، مع الحفاظ على تنسيقها الآخر. الحقول في `ApprovedDate` فقط تصبح نصًا ثابتًا.

العينة تتعرف على المعرفات الداخلية المدمجة `datetime` و `datetime1` حتى `datetime13`. المجموعات والجداول والملاحظات والتخطيطات والماستر تحتاج إلى استعراض حاويات النص الخاصة بها وهي خارج نطاق هذا المثال.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

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
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
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

بعد إعادة الفتح، يكون لـ `UpdatedAt` النوع `datetime3` ويظل ديناميكيًا. لا يحتوي `ApprovedDate` على حقل ويظهر النص `05 April 2030`. كلا الجزئين التاريخيين مائلان، وحجم الخط الأصلي والإعداد العريض واللون يظلان كما هو. العلامات النصية العادية لم تتغير. التحقق يقرأ الجزء الأول من الشكلين المعروفين في العينة المرفقة.

## **الحفاظ على تنسيق النص**

اعمل مع الجزء الموجود عند إضافة حقل، أو تغيير نوعه، أو إزالته. هذه العمليات تحتفظ بتنسيق ذلك الجزء. استخدم [IPortion.getPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#getPortionFormat--) لتغيير الخصائص المطلوبة فقط، كما تفعل الأمثلة للون أو الميلان.

تجنّب إعادة بناء إطار نص كامل فقط لتحديث حقل واحد: ذلك قد يفقد حدود الأجزاء الأصلية وتنسيقها الفردي. كذلك ميّز بين التنسيق المُحدد صراحةً والتنسيق الموروث من الفقرة أو التخطيط أو السمة. راجع [تنسيق النص](/slides/ar/androidjava/text-formatting/) للحصول على خيارات تنسيق أوسع.

## **الحقول والعناصر النائبة للرأس/التذييل**

الحقل هو جزء من جزء النص. العنصر النائب هو شكل له دور في العرض، مثل تذييل أو رقم شريحة. إضافة حقل إلى مربع نص عادي لا تحول ذلك الشكل إلى عنصر نائب.

مديرو الرأس/التذييل يتحكمون في نص العنصر النائب ورؤيته في الشرائح، التخطيطات، والماستر، بما في ذلك النشر إلى الشرائح التابعة. لذا يمكن أن يكون حقل رقم في مربع نص مخصص مفيدًا حتى إذا لم تستخدم عنصر نائب رقم الشريحة. على العكس، تغيير رؤية العنصر النائب لا يزيل حقلًا من مربع نص غير مرتبط.

الأنواع المسبقة للرأس والتذييل لا تنشئ العناصر النائبة المقابلة ولا تزود محتواها. على وجه الخصوص، الشريحة الاعتيادية في PowerPoint لا تحتوي على عنصر نائب رأس؛ الرؤوس تتبع صفحات الملاحظات والنشرات. لا تفترض أن حقل رأس أو تذييل في شكل عشوائي سيحصل تلقائيًا على النص المكوّن عبر مدير العنصر النائب. لهذا السيناريو راجع [رؤوس وتذييلات العرض التقديمي](/slides/ar/androidjava/presentation-header-and-footer/).

## **قيود PPTX و PPT**

تحقق من كل من نوع الحقل والنص الناتج بعد الحفظ وإعادة الفتح. الحفاظ على المعرف لا يثبت أن التطبيق يستطيع حساب قيمته أو عرضها.

| الصيغة | سلوك الحقل والقيود |
|---|---|
| PPTX | يخزن معرفات الحقول الداخلية جنبًا إلى جنب مع نص الحقل. في فحوصات الجولة، نجت الأنواع المعرفة مسبقًا والمعرف المخصص المستخدم أعلاه بعد الحفظ وإعادة الفتح. احتفظ النوع المخصص بنصه الاحتياطي؛ لم يكتسب منطق حساب تلقائي. قد يتعامل تطبيق آخر مع المعرفات غير المدعومة بشكل مختلف. |
| PPT | يستخدم تمثيلات حقول قديمة وله توافقية محدودة أكثر. في فحوصات الجولة، نجت حقول رقم الشريحة والحقول التاريخية المعرفة مسبقًا بعد الحفظ وإعادة الفتح. حقل مخصص في مربع نص شريحة عادي أعيد فتحه مع معرّفه لكن نصه كان `*`؛ حقل رأس في نفس السياق أيضًا أعطى `*`. لا تعتمد على بقاء النص الظاهر للحقول المخصصة أو غير المدعومة. |

لإنتاج ثابت ومحمول، حوِّل الحقول غير المدعومة إلى نص عادي وعين القيمة التي تريدها صراحةً قبل الحفظ. هذا يحافظ على النص المختار ولكنه يوقف التحديثات التلقائية عن قصد. اختبر التطبيق الهدف أيضًا عندما تكون إعادة حساب الحقول جزءًا من سير عملك.

## **الأسئلة الشائعة**

**كيف يمكنني معرفة ما إذا كان الرقم أو التاريخ المعروض هو حقل؟**  
افحص [IPortion.getField](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#getField--). قيمة غير `null` تحدد وجود حقل؛ لا يمكن للنص المعروض وحده أن يخبرك بذلك.

**هل إزالة حقل يزيل نصه أو تنسيقه؟**  
لا. [removeField](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#removeField--) يحول الجزء الموجود إلى نص عادي. عيّن قيمة صريحة بعد ذلك إذا كنت بحاجة إلى تاريخ ثابت أو قيمة احتياطية.

**هل يمكن لسلسلة داخلية تعريف تنسيق تاريخ جديد أو صيغة؟**  
لا. إنها تحدد نوع الحقل. المعرف غير المعروف لا يقدم مُقيِّمًا ولا نمط تنسيق تاريخ Java. استخدم نوعًا معرفًا مسبقًا أو شكل النص كعادي.

**لماذا أتحقق من العرض التقديمي مرة أخرى بعد حفظه؟**  
معرفات الحقول والنص المحسوب والتنسيق عناصر منفصلة للتحقق. قد يغيّر تحويل الصيغة النتيجة الظاهرة حتى لو ظل معرف الحقل موجودًا.

## **FAQ**

**How can I tell whether a displayed number or date is a field?**  
Inspect [IPortion.getField](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#getField--). A non-null value identifies a field; the displayed text alone cannot tell you.

**Does removing a field remove its text or formatting?**  
No. [removeField](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#removeField--) converts the existing portion to ordinary text. Assign an explicit value afterward if you need a particular frozen date or fallback value.

**Can an internal string define a new date format or formula?**  
No. It identifies a field type. An unknown identifier does not provide an evaluator or a Java date-format pattern. Use a supported predefined type or format a value yourself as ordinary text.

**Why check a presentation again after saving it?**  
Field identifiers, calculated text, and formatting are separate things to verify. Format conversion can change the visible result even when the field identifier is still present.