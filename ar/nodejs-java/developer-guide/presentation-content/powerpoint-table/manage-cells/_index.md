---
title: إدارة الخلايا
type: docs
weight: 30
url: /ar/nodejs-java/manage-cells/
keywords: "جدول, خلايا مدمجة, خلايا منفصلة, صورة في خلية الجدول, Java, Aspose.Slides لـ Node.js عبر Java"
description: "خلايا الجدول في عروض PowerPoint التقديمية باستخدام JavaScript"
---

## **تحديد خلية جدول مدمجة**
1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. احصل على الجدول من الشريحة الأولى.
3. التكرار عبر صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
4. طباعة رسالة عندما يتم العثور على خلايا مدمجة.

يعرض لك هذا الكود JavaScript كيفية تحديد الخلايا المدمجة في جدول ضمن عرض تقديمي:
```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// افتراض أن Slide#0.Shape#0 هو جدول
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إزالة حدود خلايا الجدول**
1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرستها.
3. تحديد مصفوفة الأعمدة مع العرض.
4. تحديد مصفوفة الصفوف مع الارتفاع.
5. أضف جدولًا إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. التكرار عبر كل خلية لإزالة الحدود العلوية والسفلية واليمينية واليسارية.
7. احفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود JavaScript كيفية إزالة الحدود من خلايا الجدول:
```javascript
// ينشئ كلاس Presentation الذي يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // تحديد الأعمدة بعرضها والصفوف بارتفاعها
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // إضافة شكل جدول إلى الشريحة
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // تعيين تنسيق الحدود لكل خلية
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // كتابة ملف PPTX إلى القرص
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الترقيم في الخلايا المدمجة**
إذا دمجنا زوجين من الخلايا (1, 1) × (2, 1) و (1, 2) × (2, 2)، سيصبح الجدول الناتج مرقمًا. يوضح لك هذا الكود JavaScript العملية:
```javascript
// ينشئ كلاس Presentation الذي يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يصل إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // يحدد الأعمدة بعرضها والصفوف بارتفاعها
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // يضيف شكل جدول إلى الشريحة
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // يضبط تنسيق الحدود لكل خلية
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // يدمج الخلايا (1, 1) × (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // يدمج الخلايا (1, 2) × (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


ثم ندمج الخلايا أكثر بدمج (1, 1) و (1, 2). النتيجة هي جدول يحتوي على خلية مدمجة كبيرة في مركزه:
```javascript
// ينشئ كلاس Presentation الذي يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يصل إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // يعرّف الأعمدة بعرضها والصفوف بارتفاعها
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // يضيف شكل جدول إلى الشريحة
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // يضبط تنسيق الحدود لكل خلية
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // يدمج الخلايا (1, 1) × (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // يدمج الخلايا (1, 2) × (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // يدمج الخلايا (1, 1) × (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // يكتب ملف PPTX إلى القرص
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الترقيم في الخلية المقسمة**
في الأمثلة السابقة، عندما تم دمج خلايا الجدول، لم يتغير نظام الترقيم في الخلايا الأخرى.

هذه المرة نأخذ جدولًا عاديًا (جدول بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1,1) للحصول على جدول خاص. قد ترغب في الانتباه إلى ترقيم هذا الجدول، والذي قد يبدو غريبًا. ومع ذلك، هذه هي الطريقة التي يرقم بها Microsoft PowerPoint خلايا الجداول و Aspose.Slides تقوم بالمثل.

يظهر لك هذا الكود JavaScript العملية التي وصفناها:
```javascript
// ينشئ كلاس Presentation الذي يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يصل إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // يحدد الأعمدة بعرضها والصفوف بارتفاعها
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // يضيف شكل جدول إلى الشريحة
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // يضبط تنسيق الحدود لكل خلية
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // يدمج الخلايا (1, 1) × (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // يدمج الخلايا (1, 2) × (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // يقسّم الخلية (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // يكتب ملف PPTX إلى القرص
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تغيير لون خلفية خلية الجدول**
يعرض لك هذا الكود JavaScript كيفية تغيير لون خلفية خلية الجدول:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // إنشاء جدول جديد
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // تعيين لون الخلفية للخلية
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **إضافة صورة داخل خلية جدول**
1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرستها.
3. تحديد مصفوفة الأعمدة مع العرض.
4. تحديد مصفوفة الصفوف مع الارتفاع.
5. أضف جدولًا إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. إنشاء كائن `Images` لاحتواء ملف الصورة.
7. إضافة صورة `IImage` إلى كائن `PPImage`.
8. تعيين `FillFormat` لخلية الجدول إلى `Picture`.
9. إضافة الصورة إلى الخلية الأولى في الجدول.
10. احفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود JavaScript كيفية وضع صورة داخل خلية جدول عند إنشاء الجدول:
```javascript
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يصل إلى الشريحة الأولى
    var islide = pres.getSlides().get_Item(0);
    // يحدد الأعمدة بعرضها والصفوف بارتفاعها
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // يضيف شكل جدول إلى الشريحة
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // إنشاء كائن PPImage باستخدام ملف الصورة
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // يضيف الصورة إلى الخلية الأولى في الجدول
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // يحفظ ملف PPTX على القرص
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**هل يمكنني تعيين سماكات وأنماط خطوط مختلفة لجوانب الخلية الواحدة؟**

نعم. الحدود [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) لها خصائص منفصلة، لذلك يمكن أن يختلف السماك والأسلوب لكل جانب. وهذا يتبع من التحكم في الحدود لكل جانب للخلية كما هو موضح في المقال.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

يعتمد السلوك على [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (تمدد/بلاط). عند التمدد، تتكيف الصورة مع الخلية الجديدة؛ عند التبليط، تُعاد حساب البلاط. يذكر المقال أوضاع عرض الصورة في الخلية.

**هل يمكنني إرفاق ارتباط تشعبي لكل محتوى الخلية؟**

يتم تعيين [Hyperlinks](/slides/ar/nodejs-java/manage-hyperlinks/) على مستوى النص (الجزء) داخل إطار النص للخلية أو على مستوى الجدول/الشكل بالكامل. عمليًا، يمكنك إرفاق الرابط إلى جزء أو إلى كل النص داخل الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (تشغيلات) بتنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.