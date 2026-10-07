---
title: إدارة خلايا الجداول في العروض باستخدام JavaScript
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/nodejs-java/manage-cells/
keywords:
- خلية جدول
- دمج خلايا
- إزالة حدود
- تقسيم خلية
- صورة في خلية
- لون خلفية
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة خلايا جدول PowerPoint باستخدام JavaScript: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور مع Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

Aspose.Slides يسمح لك بالوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint. يوضح هذا المقال كيفية تحديد الخلايا المدمجة، إزالة حدود الخلية، التعامل مع ترقيم الخلايا بعد الدمج أو التقسيم، تغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تُظهر الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

Aspose.Slides يستخدم فهارس تبدأ من الصفر للوصول إلى خلايا الجداول بالترتيب `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرضًا تقديميًا موجودًا ويصل إلى الشكل الأول في الشريحة الأولى باعتباره جدولًا. يفترض وجود الشريحة والشكل وأن الشكل هو جدول. ثم يت iterates عبر جميع الصفوف والأعمدة ويستخدم [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) لتحديد الخلايا في المناطق المدمجة. لكل تطابق، يطبع إحداثيات الخلية بترتيب `row;column`، [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)، [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)، وإحداثيات بداية المنطقة، [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) و[getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

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

إنشاء [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وإضافة جدول إلى شريحته الأولى باستخدام [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). يتم تحديد عرض الأعمدة، ارتفاع الصفوف، وموقع الجدول بالنقاط. يضبط المثال جميع الحدود الأربعة للخلية إلى [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)، مما يجعلها غير مرئية.

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

## **دمج خلايا الجدول**

استخدم [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاوية العليا اليسرى والزاوية السفلية اليمنى للنطاق. المتغيّر الأخير يتحكم فيما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `false` يبقي الدمج داخل ذلك النطاق.

ينشئ المثال جدولًا 4×4 بأعمدة وصفوف 70 نقطة، ثم يدمج الأربع خلايا المركزية من `(1, 1)` إلى `(2, 2)`. الخلية الناتجة تمتد على عمودين وصفين، بينما يظل شبكة الجدول الأساسية بأربعة أعمدة وأربعة صفوف. للوصول إلى محتوى أو تنسيق الخلية المدمجة، استخدم موقعها العلوي الأيسر: `table.get_Item(1, 1)` في هذا المثال. المواقع الأخرى في النطاق المدمج تظل جزءًا من شبكة الجدول، لذا لا تتغير فهارس الخلايا خارج النطاق.

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

حفظ الدمج في المثال السابق يحافظ على شبكة الجدول. قد يؤدي تقسيم خلية إلى إدخال عمود شبكة جديد وتغيير فهارس الأعمدة للخلايا إلى يمينها. Aspose.Slides يتبع نموذج شبكة جدول PowerPoint.

ينشئ هذا المثال جدولًا 4×4 بأعمدة وصفوف 70 نقطة ويستدعي [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) على الخلية `(1, 1)`. يُمرّر نصف عرض الخلية البالغ 70 نقطة لإنشاء خليتين متساويتين في العرض.

بعد هذا التقسيم، يتم الوصول إلى النصفين كـ `table.get_Item(1, 1)` و`table.get_Item(2, 1)`. أصبحت شبكة الجدول الآن تحتوي على خمسة أعمدة: الخلايا الأصلية في الأعمدة 2 و3 تنتقل إلى الأعمدة 3 و4 على التوالي. تظل فهارس الصفوف دون تغيير. استخدم فهارس الأعمدة المحدثة عند الوصول إلى الخلايا بعد التقسيم.

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

### **تقسيم الخلايا المدمجة حسب الصف أو العمود**

لتحضير خلايا القالب المدمجة لتعبئة البيانات، استخدم [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) للتقسيم على طول حد صف موجود، أو [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) للتقسيم على طول حد عمود.

يحسب المتغيّر `index` الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهو نسبي للمنطقة المدمجة:

- تقسم الصف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- تقسم العمود: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

يفترض المثال وجود عرض تقديمي يحتوي على جدول كالشكل الأول في الشريحة الأولى، مع دمج خلية `(1, 2)` و`(1, 3)` عموديًا. يبدأ من الموضع السفلي، يستخدم [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) و[getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) لتحديد الأصل ويفحص كلا النطاقين. يستدعي `splitByRowSpan(1)` لفصل الصفين 2 و3 لأسماء المنتجات. للدمج الأفقي ذو عمودين، استخدم `splitByColSpan(1)` بدلاً من ذلك.

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

        // استرجع الخلايا الناتجة من الجدول بعد التقسيم.
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

تبقى شبكة الجدول وفهارس الخلايا المحيطة دون تغيير. استرجع الخلايا الناتجة عبر إحداثياتها؛ هنا، كلاهما يمتدان إلى 1 وتُظهر [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) القيمة `false`. يمكن للمناطق الأكبر أن تظل جزئيًا مدمجة بعد تقسيم واحد.

النص الأصلي وتنسيقه يبقى في الخلية العليا (أو اليسرى)؛ الخلية الجديدة تكون فارغة لكنها ترث تنسيق الخلية مثل التعبئة والحدود والهامش. عبّئ الخلايا بعد التقسيم واضبط أي تنسيق نص مطلوب صراحةً.

العرض المحفوظ يحتوي على خلايا "Product A" و"Product B" منفصلة مع الحفاظ على تنسيق خلية القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) للمزيد من التفاصيل.

## **تغيير لون خلفية خلية الجدول**

ينشئ هذا المثال جدولًا بأعمدة 150 نقطة وصفوف 50 نقطة. يستخدم [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) لاختيار تعبئة صلبة ويضبط اللون الذي تُعيده [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) إلى الأحمر للخلية `(2, 3)`, في العمود الثالث والصف الرابع.

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

## **إضافة صورة داخل خلية جدول**

ضع الصورة المدخلة في دليل العمل قبل تشغيل هذا المثال. يقوم بتحميل الصورة باستخدام [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) ويضيفها إلى مجموعة صور العرض باستخدام [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). ثم يعيّن الصورة إلى تعبئة الصورة للخلية `(0, 0)`, الخلية الأولى في الجدول.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) يتمدد الصورة لملء الخلية، مما قد يغيّر نسبة العرض إلى الارتفاع. عرض الأعمدة وارتفاع الصفوف بالنقاط. يتم التخلص من الصورة المحملة في كتلة `finally` بعد إضافتها إلى العرض.

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

**هل يمكنني تعيين سماكات خطوط مختلفة وأنماط مختلفة لجوانب مختلفة من خلية واحدة؟**

نعم. حدود [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) لها خصائص منفصلة، لذا يمكن أن تختلف السماكة والنمط لكل جانب.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [وضع التعبئة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). مع التمدد، تتكيف الصورة مع الخلية الجديدة؛ مع التبليط، تُعاد حساب البلاط.

**هل يمكنني تعيين رابط تشعبي لجميع محتويات الخلية؟**

[الروابط التشعبية](/slides/ar/nodejs-java/manage-hyperlinks/) تُحدد على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بالكامل. عمليًا، تعين الرابط إلى جزء أو إلى كل النص في الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار النص في الخلية [الأجزاء](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (runs) مع تنسيق مستقل—عائلة الخط، الأسلوب، الحجم، واللون.