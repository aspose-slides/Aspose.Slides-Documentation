---
title: إدارة الصفوف والأعمدة في جداول PowerPoint على Android
linktitle: الصفوف والأعمدة
type: docs
weight: 20
url: /ar/androidjava/manage-rows-and-columns/
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
- Android
- Java
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجدول في PowerPoint باستخدام Aspose.Slides للأندرويد عبر Java وتسريع تحرير العروض وتحديث البيانات."
---
## **المقدمة**

Aspose.Slides for Android عبر Java يتيح لك إدارة بنية الجداول وتنسيقها في عروض PowerPoint من خلال الفئة [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) والواجهة [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). يمكنك تعيين صف عنوان، استنساخ أو إزالة الصفوف والأعمدة، وتطبيق تنسيق النص على صف أو عمود كامل.

تشرح هذه المقالة هذه العمليات مع أمثلة جافا. كما تُظهر كيفية استرداد نمط الجدول المسبق بحيث يمكنك إعادة استخدامه. فهارس صفوف وأعمدة الجدول صفرية الأساس.

## **التحكم في ارتفاع الصف**

استخدم [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) لتعيين الحد الأدنى لارتفاع الصف بالنقاط. هو حد أدنى، ليس ارتفاعًا ثابتًا. [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) يُرجع الارتفاع الفعلي. يمكن الوصول إلى الصف عبر [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--).

يحمِّل المثال الملف [row-height-input.pptx](row-height-input.pptx)، الذي يحتوي على جدول كأول شكل في الشريحة الأولى. يبدأ صفه الأول عند 70 نقطة. الخلايا تستخدم نص Arial بحجم 18 نقطة، مع التفاف، وهامش علوي وسفلي 6 نقاط؛ النص الأطول في العمود الثاني يلتف على عدة أسطر. يزيد المثال الحد الأدنى إلى 100 نقطة، ثم يقللها إلى 20 نقطة، ويطبع الارتفاع الفعلي بعد كل تغيير، ويحفظ النتيجتين.

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

مع العرض المقدم، إضافة الحد الأدنى تزيد المسافة في الصف. تقليله يزيل تلك المسافة الإضافية، لكن الارتفاع الفعلي يبقى أكبر من 20 نقطة لأن النص وهوامش الخلايا تحتاج مساحة أكبر. لا يمكن لتقليل الحد الأدنى وحده أن يجبر الصف على أن يكون أقل من المساحة المطلوبة لمحتوياته.

عدة عوامل تؤثر على الارتفاع الفعلي:

- **النص وحجم الخط:** النص الطويل، فواصل السطر الصريحة، أو الخط الأكبر قد يتطلب مسافة رأسية أكبر.
- **اللف وعرض العمود:** مع تمكين اللف، تقليل عرض العمود باستخدام [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) قد ينتج أسطرًا أكثر. العمود الأعرض قد يقلل المسافة المطلوبة عموديًا.
- **هوامش الخلية:** [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) و[ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) يضيفان مساحة رأسية. [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) و[ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) يقللان العرض المتاح للنص وقد يسببان لفًا إضافيًا.

بالنسبة لهذا الجدول دون خلايا مدمجة، الخلية التي تحتاج أكبر مساحة رأسية تحدد الحد الأدنى المستمد من المحتوى للصف بأكمله. لجعل الصف أقصر، قد تحتاج أيضًا إلى تقصير النص، تقليل حجم الخط أو الهوامش، أو توسيع عمود.

الصور أدناه تُظهر نفس الجدول بنفس المقياس. في النتائج الموضحة، كانت الارتفاعات الفعلية 70، 100، و55.2 نقطة: ظل الصف الأخير أعلى من الحد الأدنى البالغ 20 نقطة. قد تختلف قياسات النص الدقيقة حسب الخطوط المتوفرة في بيئتك. تحميل النتائج المحفوظة: [الحد الأدنى المتزايد](row-height-increased.pptx) و[الحد الأدنى المتناقص](row-height-decreased.pptx).

| الأصل: الحد الأدنى 70 نقطة، الفعلي 70 نقطة | المتزايد: الحد الأدنى 100 نقطة، الفعلي 100 نقطة | المتناقص: الحد الأدنى 20 نقطة، الفعلي 55.2 نقطة |
| --- | --- | --- |
| ![الجدول الأصلي مع صف أول بارتفاع 70 نقطة.](row-height-before.png) | ![الجدول بعد زيادة الحد الأدنى للصف الأول إلى 100 نقطة.](row-height-increased.png) | ![الجدول بعد تقليل الحد الأدنى للصف الأول إلى 20 نقطة؛ النص الملتف يحافظ على ارتفاع الصف أعلى من الحد الأدنى.](row-height-decreased.png) |

## **تعيين الصف الأول كعنوان**

استخدم الطريقة [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) لتحديد الصف الأول لتنسيق العنوان. مظهره يعتمد على نمط الجدول المطبق على الجدول.

1. حمِّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى.
3. الوصول إلى الجدول المخزن كأول شكل في الشريحة.
4. تفعيل تنسيق العنوان للصف الأول.
5. حفظ العرض المعدل.

يتطلب المثال وجود `table.pptx` يحتوي على جدول كأول شكل في الشريحة الأولى. يفعّل تنسيق العنوان للصف الأول ويحفظه كـ `First_row_header.pptx`.

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

استنسخ الصفوف أو الأعمدة لإعادة استخدام محتواها وتنسيقها. يمكنك إلحاق نسخة في نهاية الجدول أو إدخالها في موضع محدد.

1. حمِّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى.
3. تحديد عروص الأعمدة وارتفاعات الصفوف.
4. إضافة جدول باستخدام الطريقة [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. استنسخ الصفوف المطلوبة.
6. استنسخ الأعمدة المطلوبة.
7. حفظ العرض المعدل.

يتطلب المثال وجود `Test.pptx` به شريحة واحدة على الأقل. ينشئ جدولًا بثلاثة أعمدة وخمسة صفوف، بأبعاد محددة بالنقاط. يلحق نسخًا من الصف والعمود الأول، ثم يُدرج نسخًا من الصف والعمود الثاني عند الفهرس 3 (الموضع الرابع). يصبح الجدول الناتج به سبعة صفوف وخمسة أعمدة. المعامل `false` يُعطِّل الاستنساخ في الصفوف أو الأعمدة المدمجة المجاورة؛ هذا الجدول لا يحتوي على خلايا مدمجة.

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

## **إزالة صف أو عمود من الجدول**

أزل الصفوف أو الأعمدة التي لم تعد بحاجة إليها في الجدول. إزالة عنصر تُعيد ترتيب فهارس الصفوف أو الأعمدة التي تليه.

1. أنشئ عرضًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى.
3. تحديد عروص الأعمدة وارتفاعات الصفوف.
4. إضافة جدول باستخدام الطريقة [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. إزالة الصف الثاني والعمود الثاني.
6. حفظ العرض المعدل.

هذا المثال ينشئ جدولًا 3×3 ويزيل الصف والعمود عند الفهرس 1، تاركًا جدولًا 2×2 في `TestTable_out.pptx`. الأبعاد بالنقاط. المعامل `false` يُعطِّل إزالة الصفوف أو الأعمدة المدمجة المجاورة؛ هذا الجدول لا يحتوي على خلايا مدمجة.

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

## **تطبيق تنسيق النص على مستوى صف الجدول**

طبق تنسيق النص على صف كامل للحفاظ على تجانس خلاياه. يمكنك ضبط خصائص الخط، تنسيق الفقرة، واتجاه النص دون تنسيق كل خلية على حدة.

1. حمِّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الجدول في الشريحة الأولى.
3. استخدم [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) للصف الأول.
4. استخدم [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و[setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) للصف الأول.
5. استخدم [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) للصف الثاني.
6. حفظ العرض المعدل.

يتطلب المثال وجود `table.pptx` به جدول كأول شكل في الشريحة الأولى وعلى الأقل صفين. يطبق نصًا بحجم 25 نقطة، محاذاة إلى اليمين، وهامش فقرة يميني 20 نقطة على الصف الأول، ثم يضبط النص عموديًا في الصف الثاني.

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

## **تطبيق تنسيق النص على مستوى عمود الجدول**

طبق تنسيق النص على عمود كامل للحفاظ على تجانس خلاياه. يمكنك ضبط خصائص الخط، تنسيق الفقرة، واتجاه النص دون تنسيق كل خلية على حدة.

1. حمِّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الجدول في الشريحة الأولى.
3. استخدم [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) للعمود الأول.
4. استخدم [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و[setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) للعمود الأول.
5. استخدم [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) للعمود الثاني.
6. حفظ العرض المعدل.

يتطلب المثال وجود `table.pptx` به جدول كأول شكل في الشريحة الأولى وعلى الأقل عمودين. يطبق نصًا بحجم 25 نقطة، محاذاة إلى اليمين، وهامش فقرة يميني 20 نقطة على العمود الأول، ثم يضبط النص عموديًا في العمود الثاني.

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

استخدم الطريقة [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) لاسترداد النمط المسبق المطبق على جدول وإعادة استخدامه على جدول آخر. هذا يُحدد النمط المسبق بدلاً من تجاوز تنسيقات الخلايا الفردية.

ينشئ المثال جدولًا، يطبق [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1)، ويقرأ النمط مرة أخرى. يطبع القيمة العددية المقابلة لـ `DarkStyle1` ويحفظ الجدول في `table.pptx`.

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

## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه مسبقًا؟**

نعم. يرث الجدول سمة الشريحة/التخطيط/الماستر، ولا يزال بإمكانك تجاوز التعبئات والحدود وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**

لا، جداول Aspose.Slides لا تحتوي على فرز أو فلاتر مدمجة. قم بفرز بياناتك في الذاكرة أولاً، ثم أعد ملء صفوف الجدول بترتيبها.

**هل يمكنني الحصول على أعمدة مخططة (مخططة) مع الحفاظ على ألوان مخصصة لخلايا معينة؟**

نعم. فعّل الأعمدة المخططة، ثم تجاوز خلايا معينة بتنسيق محلي؛ تنسيق مستوى الخلية له أولوية على نمط الجدول.