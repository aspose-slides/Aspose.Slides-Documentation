---
title: إدارة خلايا الجدول في العروض التقديمية باستخدام Java
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
description: "إدارة خلايا جداول PowerPoint في Java: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides لـ Java."
---
## **نظرة عامة**

Aspose.Slides يتيح لك الوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint. يوضح هذا المقال كيفية التعرف على خلايا الجداول المدمجة، إزالة حدود الخلايا، التعامل مع ترقيم الخلايا بعد الدمج أو الانقسام، تغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تُظهر الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

Aspose.Slides يستخدم فهارس تبدأ من الصفر للوصول إلى خلايا الجداول بالترتيب `(العمود, الصف)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرضًا تقديميًا موجودًا ويصل إلى الشكل الأول في الشريحة الأولى كجدول. يفترض أن الشريحة والشكل موجودان وأن الشكل جدول. ثم يتكرر عبر جميع الصفوف والأعمدة ويستخدم [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) لتحديد الخلايا في المناطق المدمجة. لكل مطابقة، يطبع إحداثيات الخلية بترتيب `row;column`، [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)، [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)، وإحداثيات بداية المنطقة، [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) و[getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

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

## **إزالة حدود خلايا الجدول**

إنشاء [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وإضافة جدول إلى شريحته الأولى باستخدام [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). يتم تحديد عرض الأعمدة، ارتفاع الصفوف، وموقع الجدول بالنقاط. يضبط المثال جميع الحدود الأربعة للخلية إلى [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)، مما يجعلها غير مرئية.

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

## **إضافة حدود قطرية للخلية**

استخدم [getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) لرسم خط من الزاوية العليا اليسرى إلى الزاوية السفلى اليمنى، و[getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) لرسم خط من الزاوية السفلى اليسرى إلى الزاوية العليا اليمنى. يمكن أن يشير القطر إلى عنوان زاوية؛ كلا القطرين يمكن أن يشكلا حرف X لتحديد أن الخلية غير قابلة للتطبيق.

كل قطر هو [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/). في [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) الخاص به، استخدم [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) لاختيار [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) واختر لونًا عبر [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--). اضبط عرض الخط بالنقاط باستخدام [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-).

يخلق المثال ثلاث خلايا في صف واحد: قطري سفلي أحمر، قطري علوي أزرق، وكلا القطرين. يترك حدود الخلية العلوية، السفلية، اليسرى، واليمنى دون تغيير.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

القطر هو خاصية تنسيق، ليس تقسيمًا للخلية. كل خلية تحتفظ بإطار نص واحد، يتم الوصول إليه عبر [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--); لا يمكن تحرير المناطق على جانبي القطر بشكل مستقل.

الجدول المحفوظ، المعروض في Microsoft PowerPoint:

![ثلاث خلايا جدول تظهر قطريًا أحمر من أعلى اليسار إلى أسفل اليمين، قطريًا أزرق من أسفل اليسار إلى أعلى اليمين، وكلا القطرين يشكلان X.](diagonal-cell-borders.png)

*من اليسار إلى اليمين: قطري سفلي (أحمر، 3 نقطة)، قطري علوي (أزرق، 5 نقاط)، وكلا القطرين.*

## **دمج خلايا الجدول**

استخدم [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) لجمع نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاوية العليا اليسرى والزاوية السفلى اليمنى للنطاق. التحكم النهائي يحدد ما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `false` يحافظ على الدمج داخل ذلك النطاق.

ينشئ المثال جدولًا 4×4 بأعمدة وصفوف بارتفاع 70 نقطة، ثم يدمج الأربع خلايا المركزية من `(1, 1)` إلى `(2, 2)`. الخلية الناتجة تمتد عبر عمودين وصفين، بينما يظل شبكة الجدول الأساسية بأربعة أعمدة وأربعة صفوف. للوصول إلى محتوى أو تنسيق الخلية المدمجة، استخدم موضعها الأعلى الأيسر: `table.get_Item(1, 1)` في هذا المثال. تبقى المواقع الأخرى في النطاق المدمج جزءًا من شبكة الجدول، وبالتالي لا تتغير فهارس الخلايا خارج النطاق.

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

يحافظ دمج الخلايا في المثال السابق على شبكة الجدول. يمكن أن يؤدي تقسيم خلية إلى إضافة عمود شبكة جديد وتغيير فهارس الأعمدة للخلايا التي على يمينها. تتبع Aspose.Slides نموذج شبكة جدول PowerPoint.

يخلق هذا المثال جدولًا 4×4 بأعمدة وصفوف بارتفاع 70 نقطة ويستدعي [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) على الخلية `(1, 1)`. يُمرَّر نصف عرض الخلية البالغ 70 نقطة لإنشاء خليتين بعرض متساوٍ.

بعد هذا التقسيم، يتم الوصول إلى النصفين كـ `table.get_Item(1, 1)` و`table.get_Item(2, 1)`. أصبحت شبكة الجدول الآن تحتوي على خمسة أعمدة: الخلايا الأصلية في العمودين 2 و3 تنتقل إلى الأعمدة 3 و4 على التوالي. تبقى فهارس الصفوف دون تغيير. استخدم هذه الفهارس المحدثة عند الوصول إلى الخلايا بعد التقسيم.

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
[![خلية واحدة بعرض 70 نقطة تنقسم إلى خليتين بعرض 35 نقطة، مما يضيف عمود شبكة خامس ويُحرك الفهارس إلى اليمين.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*تقسيم العرض يؤثر على الخلية (1, 1)، باستخدام فهارس صفرية (العمود، الصف). الصفوف الأخرى تحتفظ بخلية تمتد عبر موضع العمودين الجديدين.*
<!-- visual-explanation:manage-cells:end -->

### **تقسيم خلايا مدمجة حسب امتداد الصف أو العمود**

لتحضير خلايا القالب المدمجة لتعبئة البيانات، استخدم [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) للتقسيم على حدود صف موجود، أو [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) للتقسيم على حد عمود.

معامل `index` يعد الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهو نسبي للمنطقة المدمجة:

- تقسيم صف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- تقسيم عمود: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

يفترض المثال وجود عرض تقديمي يحتوي على جدول كأول شكل في أول شريحة، مع دمج رأسي بين `(1, 2)` و`(1, 3)`. بدءًا من الموضع السفلي، يستخدم [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) و[getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) لتحديد الأصل ويتحقق من كلا الامتدادين. ثم `splitByRowSpan(1)` يفصل الصفين 2 و3 لأسماء المنتجات. للدمج الأفقي لعمودين، استخدم `splitByColSpan(1)` بدلاً من ذلك.

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

        // استرجع الخلايا الناتجة من الجدول بعد التقسيم.
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

تظل شبكة الجدول وفهارس الخلايا المحيطة دون تغيير. استرجع الخلايا الناتجة حسب إحداثياتها؛ هنا، كلاهما يمتدان إلى 1 وتطبع [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) `false`. يمكن أن تظل المناطق الأكبر مدمجة جزئيًا بعد تقسم واحد.

يبقى النص الأصلي وتنسيقه في الخلية العليا (أو اليسرى)؛ الخلية الجديدة فارغة لكنها ترث تنسيق الخلية مثل التعبئة، الحدود، والهوامش. ملء الخلايا بعد التقسيم وضبط أي تنسيق نص مطلوب صراحةً.

العرض التقديمي المحفوظ يحتوي على خلايا منفصلة "Product A" و"Product B" مع الحفاظ على تنسيق خلية القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) للمزيد من التفاصيل.

### **تقسيم خلية بارتفاع محدد**

[splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) يأخذ ارتفاع الجزء العلوي بالنقاط. [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) يأخذ عدد الصفوف الموجودة في الجزء العلوي. لتوسيط خلية بارتفاع 40 نقطة في العمود الأيمن، اطرح 40 من ارتفاع الخلية الفعلي وقسِّم المساحة المتبقية بالتساوي فوقها وتحتها.

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

الإضافة الأولى تُضيف صف شبكة وتترك 90 نقطة سفلية في الخلية `(1, 1)`. الإضافة الثانية تقسم تلك الخلية إلى خلية وسطى بارتفاع 40 نقطة وخلية سفلية بارتفاع 50 نقطة. الآن يحتوي العمود الأيمن على ثلاث خلايا بارتفاعات 50، 40، و50 نقطة من الأعلى إلى الأسفل. الخلية اليسرى تمتد عبر جميع الصفوف الثلاث وتحتفظ بارتفاعها الأصلي 140 نقطة.

![الخلية اليسرى تمتد على كامل ارتفاع الجدول بجوار ثلاث خلايا مع "Middle" في المركز.](split-by-height.png)

## **تغيير لون خلفية خلية الجدول**

ينشئ هذا المثال جدولًا بأعمدة 150 نقطة وصفوف 50 نقطة. يستخدم [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) لاختيار تعبئة صلبة ويضبط اللون الذي تُعيده [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) إلى الأحمر للخلية `(2, 3)`, أي العمود الثالث والصف الرابع.

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

ضع الصورة المدخلة في الدليل العامل قبل تشغيل هذا المثال. يتم تحميل الصورة عبر [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) وتضاف إلى مجموعة صور العرض عبر [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). ثم يتم تعيين الصورة إلى تعبئة الصورة للخلية `(0, 0)`, الخلية الأولى في الجدول.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) يمد الصورة لملء الخلية، ما قد يغيّر نسبة أبعادها. عرض الأعمدة وارتفاع الصفوف بالنقاط. يتم التخلص من الصورة المحملة في كتلة `finally` بعد إضافتها إلى العرض.

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

## **الأسئلة المتكررة**

**هل يمكنني تعيين سماكات وأنماط خطوط مختلفة لأوجه مختلفة من نفس الخلية؟**

نعم. حدود [الأعلى](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[السفلى](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[اليسرى](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[اليمنى](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) لها خصائص منفصلة، لذا يمكن أن تختلف السماكة والنمط لكل جانب.

**ماذا يحدث للصورة إذا غيرت حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [وضع التعبئة](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (تمدد/بلاط). مع التمدد، تعدل الصورة لتتناسب مع الخلية الجديدة؛ ومع البلاط، يتم إعادة حساب البلاط.

**هل يمكنني ربط تمامًا كل محتوى الخلية برابط تشعبي؟**

[الروابط التشعبية](/slides/ar/java/manage-hyperlinks/) تُحدد على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بأكمله. عمليًا، يمكنك ربط الجزء أو كل النص داخل الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. إطار نص الخلية يدعم [الأجزاء](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (القطع) مع تنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.