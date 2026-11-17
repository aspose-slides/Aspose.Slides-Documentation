---
title: إدارة خلايا الجداول في العروض التقديمية باستخدام JavaScript
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/nodejs-java/manage-cells/
keywords:
- خلية جدول
- دمج الخلايا
- إزالة الحدود
- تقسيم الخلية
- صورة داخل الخلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة خلايا جداول PowerPoint في JavaScript: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

Aspose.Slides يسمح لك بالوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint. يوضح هذا المقال كيفية تحديد الخلايا المدمجة، إزالة حدود الخلايا، التعامل مع ترقيم الخلايا بعد الدمج أو الفتق، تغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تُظهر الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

Aspose.Slides يستخدم فهارس تبدأ من الصفر للوصول إلى خلايا الجداول بالترتيب `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرضًا تقديميًا موجودًا ويصل إلى الشكل الأول على الشريحة الأولى كجدول. يفترض أن الشريحة والشكل موجودان وأن الشكل هو جدول. ثم يتنقل عبر جميع الصفوف والأعمدة ويستخدم [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) لتحديد الخلايا في مناطق مدمجة. لكل مطابقة، يطبع إحداثيات الخلية بترتيب `row;column`، [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)، [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)، وإحداثيات بداية المنطقة، [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) و[getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **إزالة حدود خلية الجدول**

إنشاء [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وإضافة جدول إلى شريحته الأولى باستخدام [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). عرض الأعمدة، ارتفاع الصفوف، وموقع الجدول موضح بالنقاط. يضبط المثال جميع حدود الخلية الأربعة إلى [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)، مما يجعلها غير مرئية.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة حدود خلية مائلة**

استخدم [getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/) لرسم خط من الزاوية العليا اليسرى إلى الزاوية السفلى اليمنى، و[getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/) لرسم خط من الزاوية السفلى اليسرى إلى الزاوية العليا اليمنى. يمكن للخط المائل أن يحدد رأسًا زاويًا؛ يمكن للخطين معًا تشكيل حرف X لتحديد الخلية بأنها غير صالحة.

كل خط مائل هو [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/). في [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/)، استخدم [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) لاختيار [FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) واختر لونًا عبر [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/). اضبط عرض الخط بالنقاط باستخدام [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/).

ينشئ المثال ثلاثة خلايا في صف واحد: قطر مائل سفلي أحمر، قطر مائل صاعد أزرق، وكلا القطرين. يترك حدود الخلية العلوية والسفلية واليسرى واليمنى دون تغيير.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

القطر هو خاصية تنسيق، وليس تقسيمًا للخلية. تحتفظ كل خلية بإطار نص واحد يمكن الوصول إليه عبر [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/); لا يمكن تحرير المناطق على جانبي القطر بشكل مستقل.

الجدول المحفوز، معروض في Microsoft PowerPoint:

![ثلاث خلايا جدول تُظهر قطرًا مائلًا أحمر من أعلى اليسار إلى أسفل اليمين، وقطرًا مائلًا أزرق من أسفل اليسار إلى أعلى اليمين، وكلا القطرين يشكلان حرف X.](diagonal-cell-borders.png)

*من اليسار إلى اليمين: القطر السفلي (أحمر، 3 نقطة)، القطر العلوي (أزرق، 5 نقاط)، وكلا القطرين.*

## **دمج خلايا الجدول**

استخدم [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاوية العلوية اليسرى والسفلية اليمنى للنطاق. يتحكم الوسيط الأخير فيما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `false` يحافظ على الدمج داخل ذلك النطاق.

ينشئ المثال جدولًا 4×4 بأعمدة وصفوف بعرض 70 نقطة، ثم يدمج الأربع خلايا المركزية من `(1, 1)` إلى `(2, 2)`. تمتد الخلية الناتجة على عمودين وصفين، بينما يبقى شبكة الجدول الأساسية بأربعة أعمدة وأربعة صفوف. للوصول إلى محتوى أو تنسيق الخلية المدمجة، استخدم موضعها العلوي الأيسر: `table.get_Item(1, 1)` في هذا المثال. تبقى المواقع الأخرى في النطاق المدمج جزءًا من شبكة الجدول، لذا لا تتغير فهارس الخلايا خارج النطاق.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تقسيم خلايا الجدول**

يُحافظ دمج الخلايا في المثال السابق على شبكة الجدول. قد يُدخل تقسيم خلية عمودًا جديدًا في الشبكة ويُغيّر فهارس الأعمدة للخلايا التي على يمينه. يتبع Aspose.Slides نموذج شبكة الجداول في PowerPoint.

ينشئ هذا المثال جدولًا 4×4 بأعمدة وصفوف بطول 70 نقطة ويستدعي [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) على الخلية `(1, 1)`. يُمرّر نصف عرض الخلية البالغ 70 نقطة لإنشاء خليتين بنفس العرض.

بعد هذا التقسيم، تُستَخدم النصفان كـ `table.get_Item(1, 1)` و`table.get_Item(2, 1)`. الآن تحتوي شبكة الجدول على خمسة أعمدة: تنتقل الخلايا الأصلية في العمودين 2 و3 إلى الأعمدة 3 و4 على التوالي. تُظل مؤشرات الصفوف كما هي. استخدم مؤشرات الأعمدة المحدثة عند الوصول إلى الخلايا بعد التقسيم.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![خلية غير مدمجة بعرض 70 نقطة تنقسم إلى خليتين بعرض 35 نقطة، وتضيف عمودًا شبكيًا خامسًا وتُحرك المؤشرات إلى يمينها.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*تقسيم العرض يؤثر على الخلية (1, 1)، باستخدام فهارس (column, row) التي تبدأ من الصفر. تبقى الصفوف الأخرى تحمل خلية تمتد عبر الموضعين العموديين الجديدين.*
<!-- visual-explanation:manage-cells:end -->

### **تقسيم الخلايا المدمجة حسب امتداد الصف أو العمود**

لتحضير خلايا القالب المدمجة لتعبئة البيانات، استخدم [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) لتقسيمها على حدود صف موجود، أو [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) لتقسيمها على حد عمود.

الوسيط `index` يُعد الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهو نسبة إلى المنطقة المدمجة:

- تقسيم الصف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- تقسيم العمود: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

يفترض المثال وجود عرض تقديمي يحتوي على جدول كأول شكل على الشريحة الأولى، مع دمج الخلايا `(1, 2)` و`(1, 3)` عموديًا. يبدأ من الموضع السفلي، ويستخدم [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) و[getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) لتحديد الأصل ويتحقق من كلا الامتدادين. ثم يفصل `splitByRowSpan(1)` الصفوف 2 و3 لأسماء المنتجات. للدمج الأفقي بعمودين، استخدم `splitByColSpan(1)` بدلاً من ذلك.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // استرجاع الخلايا الناتجة من الجدول بعد التقسيم.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

شبكة الجدول ومؤشرات الخلايا المحيطة تظل دون تغيير. استرجع الخلايا الناتجة حسب إحداثياتها؛ هنا كلاهما يمتد إلى 1 وتُظهر [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) القيمة `false`. قد تبقى المناطق الأكبر مدمجة جزئيًا بعد تقسيم واحد.

يبقى النص الأصلي وتنسيقه في الخلية العلوية (أو اليسرى)؛ الخلية الجديدة فارغة لكنها ترث تنسيق الخلية مثل التعبئة، الحدود، والهوامش. عبئ الخلايا بعد التقسيم وحدد أي تنسيق نصي مطلوب صراحةً.

العرض المحفوظ يحتوي على خلايا "Product A" و"Product B" منفصلة مع الحفاظ على تنسيق خلية القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) للمزيد من التفاصيل.

### **تقسيم خلية بارتفاع محدد**

[splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/) يأخذ ارتفاع الجزء العلوي بالنقاط. [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) يأخذ عدد الصفوف الشبكية الموجودة في الجزء العلوي. لتوسيط خلية بارتفاع 40 نقطة في العمود الأيمن، اطرح 40 من الارتفاع الفعلي للخلية وقسّم المسافة المتبقية بالتساوي فوقها وتحتها.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يقوم التقسيم الأول بإضافة صف شبكي ويترك 90 نقطة سفلية في الخلية `(1, 1)`. التقسيم الثاني يقسم تلك الخلية إلى خلية وسطى بارتفاع 40 نقطة وخلية سفلية بارتفاع 50 نقطة. الآن يحتوي العمود الأيمن على ثلاث خلايا بارتفاعات 50، 40، و50 نقطة من الأعلى إلى الأسفل. الخلية اليسرى تمتد على جميع الثلاث صفوف وتحتفظ بارتفاعها الأصلي البالغ 140 نقطة.

![الخلية اليسرى تمتد طوال ارتفاع الجدول بجانب ثلاث خلايا ذات وسط في المركز.](split-by-height.png)

## **تغيير لون خلفية خلية الجدول**

ينشئ هذا المثال جدولًا بأعمدة بطول 150 نقطة وصفوف بطول 50 نقطة. يستخدم [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) لاختيار تعبئة صلبة ويضبط اللون المعاد من [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) إلى الأحمر للخلية `(2, 3)`, أي العمود الثالث والصف الرابع.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة صورة داخل خلية الجدول**

ضع صورة الإدخال في دليل العمل قبل تشغيل هذا المثال. يقوم بتحميل الصورة عبر [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) ويضيفها إلى مجموعة صور العرض عبر [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). ثم يعين الصورة كملء صورة للخلية `(0, 0)`, الخلية الأولى في الجدول.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) يمدد الصورة لملء الخلية، ما قد يغيّر نسبة أبعادها. عرض الأعمدة وارتفاع الصفوف بالنقاط. تُحرَّر الصورة المحملة في كتلة `finally` بعد إضافتها إلى العرض.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يمكنني تعيين سماكات خطوط وأنماط مختلفة للجوانب المختلفة لخلية واحدة؟**

نعم. حدود [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) لها خصائص منفصلة، لذا يمكن أن تختلف السمك والأسلوب لكل جانب.

**ماذا يحدث للصورة إذا غيرت حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). مع التمدد، تتكيف الصورة مع الخلية الجديدة؛ مع التبعثر، تُعاد حساب القُطَع.

**هل يمكنني تعيين ارتباط تشعبي لكامل محتوى الخلية؟**

[Hyperlinks](/slides/ar/nodejs-java/manage-hyperlinks/) تُضبط على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بالكامل. عمليًا، تُعيّن الرابط لجزء أو لكل النص داخل الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (مقاطع) بتنسيق مستقل — عائلة الخط، النمط، الحجم، واللون.