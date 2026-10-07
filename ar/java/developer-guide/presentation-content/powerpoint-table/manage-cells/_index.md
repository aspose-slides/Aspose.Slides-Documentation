---
title: إدارة خلايا الجداول في العروض التقديمية باستخدام Java
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/java/manage-cells/
keywords:
- خلية جدول
- دمج خلايا
- إزالة الحدود
- تقسيم خلية
- صورة داخل خلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة خلايا جداول PowerPoint في Java: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

تتيح لك Aspose.Slides الوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint التقديمية. توضح هذه المقالة كيفية تحديد خلايا الجدول المدمجة، وإزالة حدود الخلية، والعمل مع ترقيم الخلايا بعد الدمج أو الفصل، وتغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تُظهر الأمثلة كيفية إنشاء عرض تقديمي أو فتحه، والحصول على جدول من شريحة، وتحديث تنسيق الخلية من خلال خصائص الخلية، وحفظ العرض التقديمي المعدل كملف PPTX.

تستخدم Aspose.Slides فهارس تبدأ من الصفر للوصول إلى خلايا الجدول بالترتيب `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرض تقديمي موجودًا ويصل إلى الشكل الأول في الشريحة الأولى باعتبارها جدولًا. يفترض أن الشريحة والشكل موجودان وأن الشكل هو جدول. ثم يتجول عبر جميع الصفوف والأعمدة ويستخدم [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) لتحديد الخلايا في المناطق المدمجة. لكل مطابقة، يطبع إحداثيات الخلية بترتيب `row;column`، [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)، [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)، وإحداثيات بداية المنطقة، [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) و [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **إزالة حدود خلية الجدول**

أنشئ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وأضف جدولًا إلى شريحته الأولى باستخدام [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). يتم تحديد عرض الأعمدة وارتفاع الصفوف وموقع الجدول بالنقاط. يحدد المثال جميع حدود الخلية الأربعة إلى [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)، مما يجعلها غير مرئية.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دمج خلايا الجدول**

استخدم [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاوية العليا اليسرى والزاوية السفلى اليمنى للنطاق. يتحكم الوسيط الأخير فيما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `false` يبقي الدمج داخل ذلك النطاق.

يُنشئ المثال جدولًا 4×4 بأعمدة وصفوف 70 نقطة، ثم يدمج الأربع خلايا المركزية من `(1, 1)` إلى `(2, 2)`. الخلية الناتجة تمتد على عمودين وصفين، بينما يبقى شبكة الجدول الأساسية بأربع أعمدة ورباع صفوف. للوصول إلى محتوى أو تنسيق الخلية المدمجة، استخدم موقعها العلوي الأيسر: `table.get_Item(1, 1)` في هذا المثال. المواقع الأخرى في النطاق المدمج تظل جزءًا من شبكة الجدول، لذلك لا تتغير فهارس الخلايا خارج النطاق.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تقسيم خلايا الجدول**

يحافظ دمج الخلايا في المثال السابق على شبكة الجدول. قد يؤدي تقسيم خلية إلى إدخال عمود شبكة جديد وتغيير فهارس الأعمدة للخلايا التي على يمينها. تتبع Aspose.Slides نموذج شبكة جداول PowerPoint.

ينشئ هذا المثال جدولًا 4×4 بأعمدة وصفوف 70 نقطة ويستدعي [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) على الخلية `(1, 1)`. يتم تمرير نصف عرض الخلية البالغ 70 نقطة لإنشاء خليتين ذات عرض متساوٍ.

بعد هذا التقسيم، يتم الوصول إلى النصفين عبر `table.get_Item(1, 1)` و `table.get_Item(2, 1)`. أصبحت شبكة الجدول الآن تحتوي على خمسة أعمدة: الخلايا التي كانت في الأعمدة 2 و 3 تنتقل إلى الأعمدة 3 و 4 على التوالي. تبقى فهارس الصفوف دون تغيير. استخدم فهارس الأعمدة المحدّثة عند الوصول إلى الخلايا بعد التقسيم.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تقسيم الخلايا المدمجة حسب صف أو عمود**

لتحضير خلايا القالب المدمجة لتعبئة البيانات، استخدم [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) للتقسيم على طول حد صف موجود، أو استخدم [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) للتقسيم على طول حد عمود.

المعامل `index` يحسب الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهو نسبي للمنطقة المدمجة:

- تقسيم الصف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- تقسيم العمود: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

يتوقع المثال وجود عرض تقديمي يحتوي على جدول كأول شكل في أول شريحة، مع دمج رأسي للخلية `(1, 2)` و `(1, 3)`. بدءًا من الموضع السفلي، يستخدم [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) و [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) لتحديد الأصل ويفحص كلا الامتدادين. ثم يفقم `splitByRowSpan(1)` لفصل الصفين 2 و 3 لأسماء المنتجات. بالنسبة لدمج أفقي على عمودين، استخدم `splitByColSpan(1)` بدلاً من ذلك.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // استرجاع الخلايا الناتجة من الجدول بعد التقسيم.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

تبقى شبكة الجدول وفهارس الخلايا المحيطة دون تغيير. استرجع الخلايا الناتجة بإحداثياتها؛ هنا، كلاهما يمتد إلى 1 وتطبع [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) القيمة `false`. يمكن أن تبقى المناطق الأكبر مدمجة جزئيًا بعد تقسيم واحد.

النص الأصلي وتنسيقه يبقى في الخلية العليا (أو اليسرى)؛ الخلية الجديدة فارغة لكنها ترث تنسيق الخلية مثل التعبئة والحدود والهامش. املأ الخلايا بعد التقسيم وحدد أي تنسيق نص مطلوب صراحةً.

العرض التقديمي المحفوظ يحتوي على خلايا "Product A" و "Product B" منفصلة مع الحفاظ على تنسيق خلية القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) للمزيد من التفاصيل.

## **تغيير لون خلفية خلية الجدول**

ينشئ هذا المثال جدولًا بأعمدة 150 نقطة وصفوف 50 نقطة. يستخدم [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) لاختيار تعبئة صلبة ويضبط اللون الذي تُعيده [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) إلى الأحمر للخلية `(2, 3)`, في العمود الثالث والصف الرابع.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة صورة داخل خلية جدول**

ضع الصورة المدخلة في دليل العمل قبل تشغيل هذا المثال. يتم تحميل الصورة باستخدام [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) وإضافتها إلى مجموعة صور العرض التقديمي باستخدام [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). ثم يُعيّن الصورة إلى تعبئة الصورة للخلية `(0, 0)`, أول خلية في الجدول.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) يمد الصورة لملء الخلية، مما قد يغير نسبة أبعادها. عرض الأعمدة وارتفاع الصفوف بالنقاط. يتم تحرير الصورة المحملة في كتلة `finally` بعد إضافتها إلى العرض التقديمي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتداولة**

**هل يمكنني تعيين سماكات خطوط وأنماط مختلفة لجوانب مختلفة من خلية واحدة؟**

نعم. حدود [العلوي](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[السفلي](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[اليساري](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[اليمني](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) لها خصائص منفصلة، لذا يمكن أن تختلف سماكة كل جانب ونمطه.

**ماذا يحدث للصورة إذا غيرت حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [وضع التعبئة](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (تمدد/تلبيس). مع التمدد، تتكيف الصورة مع الخلية الجديدة؛ مع التلبيس، تُعاد حساب البلاط.

**هل يمكنني تعيين ارتباط تشعبي لجميع محتوى الخلية؟**

[الروابط التشعبية](/slides/ar/java/manage-hyperlinks/) تُحدد على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بالكامل. عمليًا، تعيين الرابط إلى جزء أو إلى كل النص في الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [الأجزاء](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (المقاطع) مع تنسيق مستقل — عائلة الخط، النمط، الحجم، واللون.