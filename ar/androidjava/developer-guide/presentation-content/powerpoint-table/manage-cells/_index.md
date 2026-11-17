---
title: إدارة خلايا الجدول في العروض التقديمية على Android
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/androidjava/manage-cells/
keywords:
- خلية جدول
- دمج خلايا
- إزالة الحدود
- تقسيم خلية
- صورة في خلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة خلايا جدول PowerPoint على Android: التعرف على الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides لـ Android عبر Java."
---
## **نظرة عامة**

تتيح Aspose.Slides لك الوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint. يوضح هذا المقال كيفية التعرف على خلايا الجداول المدمجة، إزالة حدود الخلية، التعامل مع ترقيم الخلايا بعد الدمج أو الانقسام، تغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تعرض الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدّل كملف PPTX.

تستخدم Aspose.Slides مؤشرات صفرية للوصول إلى خلايا الجداول بالترتيب `(العمود، الصف)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرضًا تقديميًا موجودًا ويصل إلى الشكل الأول في الشريحة الأولى كجدول. يفترض أن الشريحة والشكل موجودان وأن الشكل جدول. ثم يتنقل عبر جميع الصفوف والأعمدة ويستخدم [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) لتحديد الخلايا في المناطق المدمجة. لكل تطابق، يطبع إحداثيات الخلية بترتيب `row;column`، [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--)، [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--)، وإحداثيات بداية المنطقة، [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) و[getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

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

## **إزالة حدود خليّة الجدول**

إنشاء [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وإضافة جدول إلى شريحته الأولى باستخدام [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). تُحدد عرض الأعمدة، ارتفاع الصفوف، وموقع الجدول بالنقاط. يضبط المثال جميع الحدود الأربعة للخلية إلى [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/)، مما يجعلها غير مرئية.

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

## **إضافة حدود خلايا مائلة**

استخدم [getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) لرسم خط من الزاوية العليا اليسرى إلى الزاوية السفلى اليمنى، و[getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) لرسم خط من الزاوية السفلى اليسرى إلى الزاوية العليا اليمنى. يمكن أن يحدّد القطر رأسًا زاويًا؛ يمكن لكلا القطرين تشكيل حرف X لتحديد الخلية على أنها غير قابلة للتطبيق.

كل قطري هو [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/). في [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--)، استخدم [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) لاختيار [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) واختر لونًا عبر [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--). اضبط عرض الخط بالنقاط باستخدام [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-).

ينشئ المثال ثلاث خلايا في صف واحد: قطري سفلي أحمر، قطري علوي أزرق، وكلا القطرين معًا. يترك حدود الخلية العليا والسفلى واليسرى واليمنى دون تغيير.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

القطري هو خاصية تنسيق، ليس انقسامًا للخلية. كل خلية تحتفظ بإطار نص واحد يُستدعى عبر [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--); لا يمكن تحرير المناطق على جانبي القطر بشكل مستقل.

الجدول المحفوظ، معروض في Microsoft PowerPoint:

![ثلاث خلايا جدول تُظهر قطريًا أحمر من أعلى اليسار إلى أسفل اليمين، قطريًا أزرق من أسفل اليسار إلى أعلى اليمين، وكلا القطرين يشكلان X.](diagonal-cell-borders.png)

*من اليسار إلى اليمين: قطري سفلي (أحمر، 3 pt)، قطري علوي (أزرق، 5 pt)، وكلا القطرين.*

## **دمج خلايا الجدول**

استخدم [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاويتين العليا اليسرى والسفلى اليمنى للنطاق. يتحكم الوسيط النهائي ما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `false` يبقي الدمج داخل ذلك النطاق.

ينشئ المثال جدولًا 4×4 بأعمدة وصفوف 70 نقطة، ثم يدمج الأربع خلايا المركزية من `(1, 1)` إلى `(2, 2)`. الخلية الناتجة تمتد على عمودين وصفين، بينما يظل شبكة الجدول الأساسية بأربع أعمدة وأربع صفوف. للوصول إلى محتوى الخلية المدمجة أو تنسيقها، استخدم موقعها العلوي الأيسر: `table.get_Item(1, 1)` في هذا المثال. تبقى المواقع الأخرى في النطاق المدمج جزءًا من شبكة الجدول، لذا لا تتغيّر مؤشرات الخلايا خارج النطاق.

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

يحافظ دمج الخلايا في المثال السابق على شبكة الجدول. يمكن لتقسيم خلية أن يضيف عمودًا شبكيًا جديدًا ويغيّر مؤشرات الأعمدة للخلايا التي على يمينها. تتبع Aspose.Slides نموذج شبكة الجداول في PowerPoint.

ينشئ هذا المثال جدولًا 4×4 بأعمدة وصفوف 70 نقطة ويستدعي [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) على الخلية `(1, 1)`. يُمرّر نصف عرض الخلية البالغ 70 نقطة لإنشاء خليتين بعرض متساوٍ.

بعد هذا الانقسام، تُستدعى النصفان كـ `table.get_Item(1, 1)` و `table.get_Item(2, 1)`. أصبحت شبكة الجدول الآن تحتوي على خمسة أعمدة: تنتقل الخلايا الأصلية في العمودين 2 و 3 إلى العمودين 3 و 4، على الترتيب. تبقى مؤشرات الصفوف دون تغيير. استخدم هذه المؤشرات المحدثة عند الوصول إلى الخلايا بعد الانقسام.

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

<!-- visual-explanation:manage-cells:start -->
[![خلية غير مدمجة عرضها 70 نقطة تنقسم إلى خليتين عرض كل منهما 35 نقطة، مما يضيف العمود الشبكي الخامس ويُزحّز المؤشرات إلى يمينها.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*انقسام العرض يؤثر على الخلية (1, 1)، باستخدام مؤشرات صفرية (العمود، الصف). تبقى الخلايا الأخرى في الصفوف نفسها تمتد عبر كلا الموضعين الجديدين للعمود.*
<!-- visual-explanation:manage-cells:end -->

### **تقسيم خلايا مدمجة حسب صف أو عمود**

لتحضير خلايا القالب المدمجة لملء البيانات، استخدم [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) لتقسيم على حد صف موجود، أو [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) لتقسيم على حد عمود.

يحسب وسيط `index` الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من الانقسام؛ وهو نسبي للمنطقة المدمجة:

- تقسيم الصف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- تقسيم العمود: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

يفترض المثال أن العرض يحتوي على جدول كأول شكل في الشريحة الأولى، حيث تم دمج الخلايا `(1, 2)` و `(1, 3)` عموديًا. بدءًا من الموضع السفلي، يستخدم [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) و[getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) لتحديد الأصل ويتحقق من كلا الامتدادين. ثم يقوم `splitByRowSpan(1)` بفصل الصفين 2 و 3 لأسماء المنتجات. بالنسبة لدمج أفقي بعمودين، استخدم `splitByColSpan(1)` بدلًا من ذلك.

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

        // استرجاع الخلايا الناتجة من الجدول بعد الانقسام.
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

تظل شبكة الجدول ومؤشرات الخلايا المحيطة دون تغيير. استرجع الخلايا الناتجة عبر إحداثياتها؛ هنا، كلاهما يمتلك امتدادًا مقداره 1 و[isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) يُظهر `false`. يمكن أن تبقى المناطق الكبيرة مدمجة جزئيًا بعد انقسام واحد.

يبقى النص الأصلي وتنسيقه في الخلية العلوية (أو اليسرى)؛ الخلية الجديدة فارغة لكنها ترث تنسيق الخلية مثل التعبئة، الحدود، والهوامش. قم بملء الخلايا بعد الانقسام وحدد أي تنسيق نص مطلوب صراحةً.

يحتوي العرض المحفوظ على خلايا "Product A" و "Product B" منفصلة مع الحفاظ على تنسيق الخلية في القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) للمزيد من التفاصيل.

### **تقسيم خلية بارتفاع محدد**

يأخذ [splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) ارتفاع الجزء العلوي بالنقاط. يخذ [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) عدد الصفوف الشبكية الموجودة في الجزء العلوي. لتوسيط خلية بارتفاع 40 نقطة في العمود الأيمن، اطرح 40 من الارتفاع الفعلي للخلية وقسّم المساحة المتبقية بالتساوي فوقها وتحته.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };

    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يضيف الانقسام الأول صفًا شبكيًا ويترك 90 نقطة سفلية في الخلية `(1, 1)`. يقسم الانقسام الثاني تلك الخلية إلى خلية وسطى بارتفاع 40 نقطة وخلية سفلية بارتفاع 50 نقطة. يصبح العمود الأيمن الآن يحتوي على ثلاث خلايا بارتفاعات 50، 40، و 50 نقطة من الأعلى إلى الأسفل. الخلية اليسرى تمتد عبر الثلاث صفوف وتحافظ على ارتفاعها الأصلي البالغ 140 نقطة.

![الخلية اليسرى تمتد على كامل ارتفاع الجدول بجوار ثلاث خلايا مع النص "Middle" في الوسط.](split-by-height.png)

## **تغيير لون خلفية خلية الجدول**

ينشئ هذا المثال جدولًا بأعمدة 150 نقطة وصفوف 50 نقطة. يستخدم [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) لاختيار تعبئة صلبة ويضبط اللون المرجع من [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) إلى الأحمر للخلية `(2, 3)`، في العمود الثالث والصف الرابع.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

ضع الصورة المدخلة في دليل العمل قبل تشغيل هذا المثال. يقوم بتحميل الصورة باستخدام [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) ويضيفها إلى مجموعة صور العرض باستخدام [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). ثم يعيّن الصورة إلى ملء الصورة للخلية `(0, 0)`, أول خلية في الجدول.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) يتمدد الصورة لتملأ الخلية، مما قد يغير نسبة الأبعاد. عرض الأعمدة وارتفاع الصفوف بالنقاط. يتم تحرير الصورة المحملة في كتلة `finally` بعد إضافتها إلى العرض.

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

## **الأسئلة الشائعة**

**هل يمكنني ضبط سماكات وأنماط خطوط مختلفة لجوانب خلية واحدة؟**

نعم. حدود [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) لها خصائص منفصلة، لذا يمكن أن تختلف السماكة والنمط لكل جانب.

**ماذا يحدث للصورة إذا غيرت حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (تمدد/بلاط). مع التمدد، تتكيف الصورة مع الخلية الجديدة؛ ومع البلاط، يُعاد حساب البلاط.

**هل يمكنني تعيين ارتباط تشعبي لكامل محتوى الخلية؟**

[Hyperlinks](/slides/ar/androidjava/manage-hyperlinks/) تُضبط على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بالكامل. عمليًا، تعيين الرابط إلى جزء أو إلى كل النص في الخلية.

**هل يمكنني ضبط خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (قِطع) بتنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.