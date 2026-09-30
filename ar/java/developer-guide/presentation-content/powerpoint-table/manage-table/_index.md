---
title: إدارة جداول العروض التقديمية في Java
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/java/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى الجدول
- نسبة الجانب
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides للغة Java. اكتشف أمثلة شيفرة بسيطة لتبسيط سير عمل الجداول لديك."
---
## **المقدمة**

تقوم الجداول في PowerPoint بتنظيم المعلومات في صفوف وأعمدة، مما يجعل قراءة القيم ومقارنتها أسهل.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/)، الواجهة [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/)، الفئة [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/)، الواجهة [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) وأنواع أخرى لتتيح لك إنشاء الجداول وتحديثها وإدارتها في العروض التقديمية.

## **إنشاء جدول من الصفر**

إنشاء جدول عن طريق تحديد موضعه وعرض الأعمدة وارتفاع الصفوف. بعد إضافته إلى شريحة، يمكنك تنسيق حدود الخلايا، دمج الخلايا، وإدراج نص.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بحسب الفهرس الخاص بها.
3. تعريف مصفوفة لعروض الأعمدة بوحدات النقاط.
4. تعريف مصفوفة لارتفاعات الصفوف بوحدات النقاط.
5. إضافة كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. المرور على كل عنصر من عناصر [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) لتطبيق تنسيق على الحدود العلوية والسفلية واليمين واليسار.
7. دمج الخليتين الأوليين في الصف الأول للجدول.
8. الوصول إلى الخلية المدموجة عبر طريقة [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) الخاصة بها.
9. تعيين النص في الخلية المدموجة.
10. حفظ العرض التقديمي المعدل.

المثال أدناه ينشئ جدولًا يتألف من ثلاثة أعمدة وخمسة صفوف في الموقع (100، 50) نقطة. يطبق حدودًا حمراء بعرض 5 نقاط، يدمج الخليتين الأوليين في الصف الأول، ويحفظ النتيجة باسم `table.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الترقيم في جدول قياسي**

في جدول قياسي، تكون مؤشرات الخلايا صفرية القاعدة وتُستخدم الصيغة (العمود، الصف). تُرقم الخلية الأولى كـ (0, 0).

على سبيل المثال، تُرقم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف كما يلي:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا المثال ينشئ جدول 4 × 4 الموضح أعلاه، بعرض أعمدة وارتفاع صفوف يبلغ 70 نقطة وحدود خلايا حمراء بعرض 5 نقاط. تُظهر الإحداثيات مؤشرات الخلايا؛ يترك المثال الخلايا فارغة ويحفظ الجدول باسم `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الوصول إلى جدول موجود**

تُخزن الجداول في مجموعة الأشكال الخاصة بالشريحة. قم بالمرور عبر الأشكال لتحديد جدول، ثم استخدم الواجهة [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) لقراءة أو تحديث خلاياه.

1. تحميل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول بحسب الفهرس الخاص بها.
3. المرور عبر كائنات [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) والتوقف عند العثور على جدول. إذا احتوت الشريحة على عدة جداول، استخدم طريقة [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) لتحديد الجدول المطلوب.
4. تحديث النص في الخلية المستهدفة.
5. حفظ العرض التقديمي المعدل.

المثال أدناه يفتح الملف `UpdateExistingTable.pptx` ويجد أول جدول في الشريحة الأولى. يضبط الخلية في العمود 0، الصف 1 إلى القيمة `New` ويحفظ النتيجة باسم `table1_out.pptx`. يجب أن يحتوي الملف المدخل على شريحة واحدة على الأقل، ويجب أن يحتوي أول جدول في تلك الشريحة على عمود واحد على الأقل وصفين.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

لتغيير حجم صف في جدول موجود وفهم لماذا قد يتجاوز ارتفاعه الفعلي الحد الأدنى المطلوب، راجع [Control Row Height](/slides/ar/java/manage-rows-and-columns/#control-row-height).

## **العثور على الخلية التي تملك إطار نص**

عند تلقي كود معالجة نص عام كائن [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) من جدول، استخدم طريقة [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) لاسترداد [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) المالك. بالنسبة لإطار نص خلية جدول، تُعيد [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) المالك وتُعيد [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) القيمة `null`، على الرغم من أن الجدول نفسه يُعتبر شكلًا.

تتوفر إحداثيات الخلية عبر الطريقتين للقراءة فقط [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) و[ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--). كما تُوفر [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) تنقلًا للقراءة فقط: تُعيد المالك دون تغيير الملكية. تحقق دائمًا مما إذا كانت الخلية المرجعية `null` قبل استخدامها.

للحصول على مثال كامل يحدد مالكي خلايا الجدول والشكل، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [Search and Replace Text](/slides/ar/java/search-and-replace-text/).

## **محاذاة النص في جدول**

يمكنك التحكم في تثبيت النص عموديًا واتجاهه داخل خلايا الجدول الفردية. المثال في هذا القسم يُركز النص داخل الخلية الأولى ويُدوِّره بزاوية 270 درجة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بحسب الفهرس الخاص بها.
3. إضافة كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) إلى الشريحة.
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) من الجدول.
5. الوصول إلى أول عنصر [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) وتعيين النص واللون له.
6. تعيين تثبيت عمودي للنص واتجاهه باستخدام [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) و[setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-).
7. حفظ العرض التقديمي المعدل.

هذا المثال ينشئ جدولًا 4 × 4 بعرض أعمدة 120 نقطة وارتفاع صفوف 100 نقطة. ينسق النص في الخلية (0, 0)، يضيف قيمًا إلى الخلايا المتبقية في الصف الأول، ويحفظ النتيجة باسم `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين تنسيق النص على مستوى الجدول**

استخدم [setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) لتطبيق تنسيق النص على جميع خلايا الجدول. تُقبل التَحميلات إما تنسيق الجزء أو الفقرة أو إطار النص، لذا يمكنك ضبط هذه الخصائص دون المرور على كل خلية على حدة.

1. تحميل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بحسب الفهرس الخاص بها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) من الشريحة.
4. تعيين حجم الخط باستخدام [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) للنص.
5. تعيين محاذاة الفقرة والهامش الأيمن باستخدام [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و[setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. تعيين اتجاه النص باستخدام [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. حفظ العرض التقديمي المعدل.

المثال أدناه يفتح الملف `table.pptx`، الذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل لها. يحدد حجم الخط إلى 25 نقطة، يُحاذِى الفقرات إلى اليمين مع هامش أيمن قدره 20 نقطة، ويجعل النص عموديًا. يُحفظ العرض المنسق باسم `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الحصول على خصائص نمط الجدول**

استخدم [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) لقراءة النمط المسبق للجدول و[setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) لتعيينه. يُطبق هذا المثال [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) على جدول واحد، يطبع قيمة النمط المسبق، ويُعيّن نفس النمط لجدول ثانٍ. يُحفظ كلا الجدولين في الملف `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **قفل نسبة الجانب للجدول**

نسبة جانب الجدول هي نسبة عرضه إلى ارتفاعه. استخدم [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) لقفل هذه النسبة للجدول.

المثال أدناه يفتح الملف `pres.pptx`، الذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل لها. يطبع حالة القفل الحالية، يفعّل قفل نسبة الجانب، يطبع الحالة المُحدَّثة (`true`)، ويحفظ النتيجة باسم `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكن تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يُوفر الجدول طريقة [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-)، وتحتوي الفقرات على الطريقة [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). يضمن استخدام الاثنين ترتيب RTL الصحيح وعرضه داخل الخلايا.

**كيف يمكن منع المستخدمين من تحريك أو تغيير حجم جدول في الملف النهائي؟**

استخدم [shape locks](/slides/ar/java/applying-protection-to-presentation/) لتعطيل التحريك، تعديل الحجم، التحديد، إلخ. تنطبق هذه الأقفال على الجداول أيضًا.

**هل يُدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمتد أو تتكرر).