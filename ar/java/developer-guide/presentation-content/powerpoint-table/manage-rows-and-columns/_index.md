---
title: إدارة الصفوف والأعمدة في جداول PowerPoint باستخدام Java
linktitle: الصفوف والأعمدة
type: docs
weight: 20
url: /ar/java/manage-rows-and-columns/
keywords:
- صف الجدول
- عمود الجدول
- الصف الأول
- رأس الجدول
- استنساخ صف
- استنساخ عمود
- نسخ صف
- نسخ عمود
- إزالة صف
- إزالة عمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط الجدول
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجداول في PowerPoint باستخدام Aspose.Slides for Java وتسريع تعديل العروض وتحديث البيانات."
---
## **المقدمة**

Aspose.Slides for Java يتيح لك إدارة بنية الجداول وتنسيقها في عروض PowerPoint من خلال الفئة [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) والواجهة [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). يمكنك تعيين صف رأس، استنساخ أو إزالة الصفوف والأعمدة، وتطبيق تنسيق النص على صف كامل أو عمود كامل.

هذه المقالة تشرح هذه العمليات باستخدام أمثلة Java. كما توضح كيفية استرجاع إعداد نمط الجدول لإعادة استخدامه. مؤشرات الصفوف والأعمدة في الجدول تبدأ من الصفر.

## **التحكم في ارتفاع الصف**

استخدم [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) لتعيين الحد الأدنى لارتفاع الصف بالنقاط. هذا حد أدنى فقط، وليس ارتفاعًا ثابتًا. [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) يُعيد الارتفاع الفعلي. امسك بالصف عبر [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--).

المثال يحمل الملف [row-height-input.pptx](row-height-input.pptx)، الذي يحتوي على جدول كأول شكل في الشريحة الأولى. يبدأ صفه الأول عند 70 نقطة. الخلايا تستخدم نص Arial بحجم 18 نقطة، مع التفاف، وهوامش علوية وسفلية 6 نقاط؛ النص الطويل في العمود الثاني يلتف إلى عدة أسطر. يزيد المثال الحد الأدنى إلى 100 نقطة، ثم يقلله إلى 20 نقطة، ويطبع الارتفاع الفعلي بعد كل تعديل، ثم يحفظ النتيجتين.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مع العرض المرفق، زيادة الحد الأدنى تضيف مساحة إلى الصف. خفضه يزيل تلك المساحة الإضافية، لكن الارتفاع الفعلي يبقى أكبر من 20 نقطة لأن النص وهوامش الخلية تحتاج مساحة أكبر. تقليل الحد الأدنى وحده لا يمكنه إجبار الصف على أن يكون أقل من المساحة المطلوبة لمحتوياته.

عدة عوامل تؤثر على الارتفاع الفعلي:

- **النص وحجم الخط:** النص الطويل، فواصل الأسطر الصريحة، أو الخط الأكبر قد يتطلب مساحة عمودية أكبر.
- **اللف وعرض العمود:** مع تمكين اللف، تقليل عرض العمود عبر [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) يمكن أن ينتج أسطرًا إضافية. العمود الأوسع قد يقلل المساحة العمودية المطلوبة.
- **هوامش الخلية:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) و [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) يضيفان مساحة عمودية. [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) و [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) يقللان عرض النص ويمكن أن يسببوا لفًا إضافيًا.

بالنسبة لهذا الجدول بدون خلايا مدمجة، الخلية التي تحتاج أكبر مساحة عمودية تحدد الحد الأدنى للمحتوى للصف بأكمله. لجعل الصف أقصر، قد تحتاج أيضًا إلى تقصير النص، تقليل حجم الخط أو الهوامش، أو توسيع عمود.

الصور أدناه تظهر نفس الجدول بنفس المقياس. في النتائج الموضحة، كانت الارتفاعات الفعلية 70 و100 و55.2 نقطة: ظل الصف النهائي أعلى من الحد الأدنى البالغ 20 نقطة. قياسات النص الدقيقة قد تختلف حسب الخطوط المتوفرة في بيئتك. حمّل النتائج المحفوظة: [increased minimum](row-height-increased.pptx) و [decreased minimum](row-height-decreased.pptx).

| الأصل: الحد الأدنى 70 نقطة، الفعلي 70 نقطة | الزيادة: الحد الأدنى 100 نقطة، الفعلي 100 نقطة | النقصان: الحد الأدنى 20 نقطة، الفعلي 55.2 نقطة |
| --- | --- | --- |
| ![الجدول الأصلي مع الصف الأول بارتفاع 70 نقطة.](row-height-before.png) | ![الجدول بعد زيادة الحد الأدنى للصف الأول إلى 100 نقطة.](row-height-increased.png) | ![الجدول بعد خفض الحد الأدنى للصف الأول إلى 20 نقطة؛ يبقى النص الملتف يجعل الصف أعلى من الحد الأدنى.](row-height-decreased.png) |

## **تعيين الصف الأول كرأس**

استخدم الطريقة [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) لتحديد الصف الأول لتنسيق الرأس. مظهره يعتمد على نمط الجدول المطبق على الجدول.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. امسك بالشريحة الأولى.
3. امسك بالجدول المخزن كأول شكل في الشريحة.
4. فعّل تنسيق الرأس لصفه الأول.
5. احفظ العرض المعدل.

المثال يتطلب ملف `table.pptx` يحتوي على جدول كأول شكل في الشريحة الأولى. يفعّل تنسيق الرأس للصف الأول ويحفظه كملف `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استنساخ صف أو عمود في الجدول**

استنسخ الصفوف أو الأعمدة لإعادة استخدام محتواها وتنسيقها. يمكنك إلحاق نسخة في نهاية الجدول أو إدراجها في موضع معين.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. امسك بالشريحة الأولى.
3. عرّف أعروض الأعمدة وارتفاعات الصفوف.
4. أضف جدولًا باستخدام الطريقة [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. استنسخ الصفوف المطلوبة.
6. استنسخ الأعمدة المطلوبة.
7. احفظ العرض المعدل.

المثال يتطلب ملف `Test.pptx` يحتوي على شريحة واحدة على الأقل. ينشئ جدولًا بثلاثة أعمدة وخمسة صفوف، بأبعاد محددة بالنقاط. يضيف نسخًا من الصف والعمود الأول، ثم يدرج نسخًا من الصف والعمود الثاني عند الفهرس 3 (الموضع الرابع). يصبح الجدول الناتج يحتوي على سبعة صفوف وخمسة أعمدة. الوسيطة `false` تمنع الاستنساخ في الصفوف أو الأعمدة المدمجة المجاورة؛ لا يحتوي هذا الجدول على خلايا مدمجة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إزالة صف أو عمود من جدول**

إزالة الصفوف أو الأعمدة التي لم تعد بحاجة إليها في جدول. إزالة عنصر تقوم بترحيل مؤشرات الصفوف أو الأعمدة التي تليه.

1. أنشئ عرضًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. امسك بالشريحة الأولى.
3. عرّف أعرض الأعمدة وارتفاعات الصفوف.
4. أضف جدولًا باستخدام الطريقة [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. أزل الصف الثاني والعمود الثاني.
6. احفظ العرض المعدل.

هذا المثال ينشئ جدولًا ثلاثًا في ثلاثة ويزيل الصف والعمود عند الفهرس 1، فينتج جدولًا اثنين في اثنين في الملف `TestTable_out.pptx`. الأبعاد بالنقاط. الوسيطة `false` تمنع إزالة الصفوف أو الأعمدة المدمجة المجاورة؛ لا يحتوي هذا الجدول على خلايا مدمجة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين تنسيق النص على مستوى صف الجدول**

طبق تنسيق النص على صف كامل للحفاظ على تجانس خلاياه. يمكنك ضبط خصائص الخط، تنسيق الفقرة، واتجاه النص دون تنسيق كل خلية على حدة.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. امسك بالجدول في الشريحة الأولى.
3. استخدم [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) للصف الأول.
4. استخدم [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) للصف الأول.
5. استخدم [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) للصف الثاني.
6. احفظ العرض المعدل.

المثال يتطلب ملف `table.pptx` يحتوي على جدول كأول شكل في الشريحة الأولى وعلى الأقل صفين. يطبق نصًا بحجم 25 نقطة، محاذاة إلى اليمين، وهوامش فقرة يمنى 20 نقطة للصف الأول، ثم يعيّن النص عموديًا في الصف الثاني.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين تنسيق النص على مستوى عمود الجدول**

طبق تنسيق النص على عمود كامل للحفاظ على تجانس خلاياه. يمكنك ضبط خصائص الخط، تنسيق الفقرة، واتجاه النص دون تنسيق كل خلية على حدة.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. امسك بالجدول في الشريحة الأولى.
3. استخدم [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) للعمود الأول.
4. استخدم [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) للعمود الأول.
5. استخدم [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) للعمود الثاني.
6. احفظ العرض المعدل.

المثال يتطلب ملف `table.pptx` يحتوي على جدول كأول شكل في الشريحة الأولى وعلى الأقل عمودين. يطبق نصًا بحجم 25 نقطة، محاذاة إلى اليمين، وهوامش فقرة يمنى 20 نقطة للعمود الأول، ثم يعيّن النص عموديًا في العمود الثاني.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الحصول على خصائص نمط الجدول**

استخدم الطريقة [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) لاسترجاع الإعداد المطبق على جدول وإعادة استخدامه في جدول آخر. هذا يحدد الإعداد المسبق بدلاً من تجاوز تنسيقات الخلايا الفردية.

المثال ينشئ جدولًا، يطبق [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1)، ثم يقرأ الإعداد مرة أخرى. يطبع القيمة الرقمية المقابلة لـ `DarkStyle1` ويحفظ الجدول في الملف `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه مسبقًا؟**  
نعم. يرث الجدول سمة الشريحة/التخطيط/القالب، ولا يزال بإمكانك تجاوز التعبئات والحدود وألوان النص فوق هذه السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**  
لا، لا تدعم جداول Aspose.Slides الفرز أو الفلاتر المدمجة. قم بفرز بياناتك في الذاكرة أولاً، ثم أعد ملء صفوف الجدول بالترتيب المطلوب.

**هل يمكنني الحصول على أعمدة متناوبة (مخططة) مع الحفاظ على ألوان مخصصة لخلايا معينة؟**  
نعم. فعّل الأعمدة المتناوبة، ثم تجاوز خلايا محددة بالتنسيق المحلي؛ تنسيق الخلية يأخذ الأسبقية على نمط الجدول.