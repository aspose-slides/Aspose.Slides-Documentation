---
title: إدارة جداول العروض التقديمية على Android
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/androidjava/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى جدول
- نسبة العرض إلى الارتفاع
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides لنظام Android. اكتشف أمثلة كود Java بسيطة لتبسيط تدفقات عمل الجداول الخاصة بك."
---
## **المقدمة**

تقوم الجداول في PowerPoint بتنظيم المعلومات في صفوف وأعمدة، مما يسهل قراءتها ومقارنة القيم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) الواجهة [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) الفئة [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) الواجهة [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) وأنواع أخرى لتسمح لك بإنشاء وتحديث وإدارة الجداول في العروض التقديمية.

## **إنشاء جدول من الصفر**

Create a table by specifying its position, column widths, and row heights. After adding it to a slide, you can format cell borders, merge cells, and insert text.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بواسطة فهرسها.
3. تحديد مصفوفة من عرض الأعمدة بالنقاط.
4. تحديد مصفوفة من ارتفاع الصفوف بالنقاط.
5. إضافة كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) .
6. التكرار عبر كل [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) لتطبيق تنسيق الحدود العليا والسفلية واليمنى واليسرى.
7. دمج الخليتين الأوليتين في الصف الأول للجدول.
8. الوصول إلى الخلية المدمجة عبر طريقة [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) .
9. تعيين النص في الخلية المدمجة.
10. حفظ العرض التقديمي المعدل.

المثال أدناه ينشئ جدولًا يحتوي على ثلاثة أعمدة وخمسة صفوف عند (100، 50) نقطة. يطبق حدودًا حمراء بعرض 5 نقاط، يدمج الخليتين الأوليتين في الصف الأول، ويحفظ النتيجة كـ `table.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

في جدول قياسي، تكون مؤشرات الخلايا صفرية وتعتمد ترتيب (العمود، الصف). تُرقم الخلية الأولى كـ (0, 0).

على سبيل المثال، تُرقم خلايا جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

ينشئ هذا المثال الجدول 4 × 4 الموضح أعلاه، بعرض أعمدة وارتفاع صفوف يبلغ 70 نقطة وحدود خلايا حمراء بعرض 5 نقاط. توضح الإحداثيات مؤشرات الخلايا؛ يترك المثال الخلايا فارغة ويحفظ الجدول كـ `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

تُخزن الجداول في مجموعة الأشكال الخاصة بالشريحة. قم بالتكرار عبر الأشكال لتحديد جدول، ثم استخدم الواجهة [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) لقراءة أو تحديث خلاياه.

1. تحميل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول بواسطة فهرسها.
3. التكرار عبر كائنات [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) وإيقاف العملية عند العثور على جدول. إذا احتوت الشريحة على عدة جداول، استخدم [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) لتحديد الجدول المطلوب.
4. تحديث النص في الخلية المستهدفة.
5. حفظ العرض التقديمي المعدل.

المثال أدناه يفتح `UpdateExistingTable.pptx` ويجد أول جدول في الشريحة الأولى. يحدد الخلية في العمود 0، الصف 1 إلى `New` ويحفظ النتيجة كـ `table1_out.pptx`. يجب أن يحتوي الإدخال على شريحة واحدة على الأقل، وأن يحتوي الجدول الأول في تلك الشريحة على عمود واحد على الأقل وصفين على الأقل.

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

لتحجيم صف في جدول موجود وفهم سبب إمكانية ارتفاع الارتفاع الفعلي عن الحد الأدنى المطلوب، راجع [التحكم في ارتفاع الصف](/slides/ar/androidjava/manage-rows-and-columns/#control-row-height).

## **العثور على الخلية التي تمتلك إطار نص**

عند تلقي كود معالجة النصوص العام كائن [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) من جدول، استخدم طريقة [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) لاستعادة [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) المالكة. بالنسبة لإطار نص خلية جدول، تُعيد [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) المالك وتُعيد [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) القيمة `null`، رغم أن الجدول نفسه يعتبر شكلاً.

توفر إحداثيات الخلية عبر الطريقتين القابلتين للقراءة فقط [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) و[ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--). كما توفر [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) تنقلًا للقراءة فقط: تُعيد المالك ولكنها لا تغيّر الملكية. تحقق دائمًا من أن الخلية المرجعة ليست `null` قبل استخدامها.

لمثال كامل يحدد مالكي خلايا الجدول والأشكال، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [البحث والاستبدال النصي](/slides/ar/androidjava/search-and-replace-text/).

## **محاذاة النص في جدول**

يمكنك التحكم في تثبيت النص عموديًا واتجاهه داخل خلايا الجدول الفردية. المثال في هذا القسم يوسّط النص داخل الخلية الأولى ويدورها بزاوية 270 درجة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بواسطة فهرسها.
3. إضافة كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) إلى الشريحة.
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) من الجدول.
5. الوصول إلى أول [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) وتعيين نصه ولونه.
6. تعيين تثبيت النص العمودي واتجاه النص للخلية باستخدام [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) و[setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) .
7. حفظ العرض التقديمي المعدل.

هذا المثال ينشئ جدولًا 4 × 4 بعرض أعمدة 120 نقطة وارتفاع صفوف 100 نقطة. ينسق النص في الخلية (0, 0)، يضيف قيمًا إلى الخلايا المتبقية في الصف الأول، ويحفظ النتيجة كـ `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

استخدم [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) لتطبيق تنسيق النص على جميع خلايا الجدول. تدعم التحميلات تنسيقات الجزء والفقرة وإطار النص، بحيث يمكنك تعيين هذه الخصائص دون الحاجة إلى التكرار عبر الخلايا الفردية.

1. تحميل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بواسطة فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) من الشريحة.
4. تعيين حجم الخط باستخدام [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) للنص.
5. تعيين محاذاة الفقرة والهوامش اليمنى باستخدام [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و[setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. تعيين اتجاه النص باستخدام [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. حفظ العرض التقديمي المعدل.

المثال أدناه يفتح `table.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل. يعيّن حجم الخط إلى 25 نقطة، يضبط محاذاة الفقرات إلى اليمين مع هامش يمين قدره 20 نقطة، ويجعل النص عموديًا. يُحفظ العرض التقديمي المنسق كـ `result.pptx`.

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

استخدم [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) لقراءة النمط المسبق للجدول و[setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) لتعيينه. يطبق هذا المثال [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) على جدول واحد، ويطبع قيمة النمط المسبق، ثم يعيّن نفس النمط لجدول ثانٍ. يتم حفظ كلا الجدولين في `table-style.pptx`.

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

## **قفل نسبة العرض إلى الارتفاع للجدول**

نسبة عرض الجدول إلى ارتفاعه هي نسبة عرضه إلى ارتفاعه. استخدم [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) لقفل هذه النسبة للجدول.

المثال أدناه يفتح `pres.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل. يطبع حالة القفل الحالية، يفعّل قفل نسبة العرض إلى الارتفاع، يطبع الحالة المحدثة (`true`)، ويحفظ النتيجة كـ `pres-out.pptx`.

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

## **الأسئلة الشائعة**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. الجدول يوفر طريقة [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-)، والفقرات لديها الطريقة [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). يضمن استخدام الطريقتين ترتيب RTL الصحيح وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم الجدول في الملف النهائي؟**

استخدم [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) لتعطيل التحريك، وتغيير الحجم، والاختيار، وما إلى ذلك. تُطبق هذه القفل على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمدد أو تجانب).