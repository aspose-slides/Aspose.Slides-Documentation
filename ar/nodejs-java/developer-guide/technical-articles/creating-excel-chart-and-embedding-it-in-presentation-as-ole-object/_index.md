---
title: إنشاء مخططات Excel وتضمينها في العروض التقديمية ككائنات OLE
type: docs
weight: 30
url: /ar/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- مخطط Excel
- تضمين مخطط
- كائن OLE
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء مخطط Excel باستخدام Aspose.Cells for Node.js عبر Java وتضمين دفتر العمل في عرض PowerPoint باستخدام Aspose.Slides، بما في ذلك معاينة للمخطط."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء مخطط أعمدة Excel باستخدام Aspose.Cells for Node.js عبر Java وتضمين دفتر العمل الخاص به في عرض PowerPoint بواسطة Aspose.Slides for Node.js عبر Java. يحتوي دفتر العمل المضمن على كل من بيانات المصدر والمخطط. يعرض معاينة PNG منفصلة المخطط على الشريحة قبل تنشيط كائن OLE.

النتيجة هي كائن Excel مدمج، وليس مخطط PowerPoint أصلي. يتطلب تحرير دفتر العمل عبر OLE وجود تطبيق سطح مكتب يدعم تنشيط OLE وتثبيت Excel متوافق.

## **المتطلبات المسبقة**

قم بتثبيت حزم Node.js `aspose.cells` و `aspose.slides.via.java` و `java`. شغِّل الأمثلة كسكريبتات CommonJS منفصلة في عمليتي Node.js مختلفتين: أولاً `create-chart.js`، ثم `embed-chart.js`، باستخدام نفس دليل العمل. تقوم حزم Aspose بتهيئة جسر Java أثناء التحميل، لذا تُبقى هذه الأمثلة في عمليات منفصلة. لا يلزم وجود Microsoft Office لتوليد العرض باستخدام هذه المكتبات.

لا يلزم وجود دفتر عمل أو صورة مسبقة. ينشئ السكريبت الأول `ChartWorkbook.xlsx` و `ChartPreview.png`؛ الثاني يقرأ هذين الملفين ويكتب `OutputChart.pptx` في دليل العمل الحالي. طبّق تراخيص كلا المنتجين عند التشغيل خارج وضع التقييم.

## **كيف يعمل التضمين**

1. أنشئ دفتر عمل يحتوي على ورقة بيانات وورقة مخطط.  
2. اجعل ورقة المخطط نشطة بحيث يفتح دفتر العمل على المخطط.  
3. عيّن نطاق عرض OLE لدفتر العمل وقم بتحويل المخطط إلى PNG.  
4. احفظ دفتر العمل كملف XLSX وضمّ بايتاته في شريحة في عملية Node.js منفصلة.  
5. عيّن PNG كمعاينة لكائن OLE واحفظ العرض كملف PPTX.

نطاق عرض دفتر العمل والإطار على الشريحة لهما أدوار مختلفة. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) يستخدم مؤشرات الصف والعمود بدءًا من الصفر. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) يستخدم بدلاً من ذلك الصف العلوي، العمود الأيسر، الصف السفلي، والعمود الأيمن. يستخدم المثال الفهرس 55 للصف و25 للعمود كحدود سفلية‑يمنى؛ هذه القيم اختيارات تخطيط، ليست عدد الصفوف أو الأعمدة الفعلية.

يستخدم إطار الشريحة نقاط. يضمن المثال ملاءمته داخل الشريحة ويُوسّطها مع الحفاظ على نسبة أبعاد PNG، بدلاً من تمديد المعاينة لملء الشريحة.

## **إنشاء وتضمين المخطط**

احفظ المثال الأول باسم `create-chart.js`. يقوم بملء `DataSheet` بأربعة صفوف وخمسة أعمدة من القيم. يصبح كل صف سلسلة مخطط. يتم اختيار `ChartSheet` كورقة نشطة قبل حفظ دفتر العمل.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // تجسيد معاينة المخطط وتسلسل دفتر العمل القابل للتعديل بشكل منفصل.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// اكتمل كل العمل المتزامن؛ أوقف عملية جسر Java.
process.exit(0);
```

احفظ المثال التالي باسم `embed-chart.js`. شغِّله بعد أن ينشئ `create-chart.js` كلا ملفي الإدخال. يُوسّط إطار OLE ويحافظ على نسبة أبعاد صورة المعاينة.

يقوم السكريبت الثاني بضم دفتر العمل المحفوظ ويستخدم PNG كمعاينته. يُحفظ دفتر العمل صراحةً كملف XLSX، متطابقًا مع الامتداد `xlsx` الممرّر إلى [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). يتم تحميل PNG مباشرةً من بايتاته دون تحويل بوايت ماب وسيط. يتطلب جسر Java مصفوفات بايت صريحة للصور وبيانات دفتر العمل، وقيم عائمة Java لإحداثيات إطار الشريحة. استبدالها عبر [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) يستبدل العنصر النائب الافتراضي لـ OLE.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // ملاءمة المعاينة داخل الشريحة دون تغيير نسبة أبعادها.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// انتهى كل العمل المتزامن؛ أوقف عملية جسر Java.
process.exit(0);
```

## **النتيجة المتوقعة**

`OutputChart.pptx` يحتوي على شريحة واحدة بها دفتر عمل Excel مدمج ومعاينة مخطط. يحتوي دفتر العمل على البيانات الأصلية ومخطط أعمدة بأربع سلاسل. المعاينة مُوسَّطة على الشريحة وتحتفظ بنسبة أبعادها.

![مخطط أعمدة Excel معروض كمعاينة لدفتر عمل مدمج](excel-chart-ole-preview.png)

في بيئة PowerPoint سطح مكتب متوافقة وتتوفر فيها Excel، انقر نقرة مزدوجة على الكائن لتنشيطه وتحرير دفتر العمل المدمج. يعتمد التنشيط والتحرير على دعم OLE في التطبيق المضيف وإعدادات الأمان.

## **الأسئلة المتكررة**

**لماذا نحتاج إلى صورة معاينة؟**

دفتر العمل المدمج ومعاينة الشريحة منفصلان. قدّم صورة مخطط حتى تُظهر الشريحة المخطط بدلاً من العنصر النائب الافتراضي "EMBEDDED OLE OBJECT". اطلع على [Object Preview Issue when Adding OleObjectFrame](/slides/ar/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**هل تتحدث المعاينة تلقائيًا عند تعديل دفتر العمل في الكود؟**

اعتبر المعاينة لقطة ثابتة. عند تحديث بيانات دفتر العمل برمجيًا، أعد توليد صورة المخطط واستبدل المعاينة وكذلك بيانات دفتر العمل المدمج.

**هل يمكنني استخدام XLS بدلاً من XLSX؟**

نعم. احفظ دفتر العمل بتنسيق XLS واستخدم `xls` كامتداد البيانات المدمجة. يجب أن يتطابق الامتداد مع تنسيق دفتر العمل الفعلي؛ تعديل الامتداد دون تحويل البيانات لا يكفي.

**لماذا قد يتغير حجم الكائن بعد التنشيط؟**

قد يقوم التطبيق المضيف بتحديث عرض كائن OLE عند تنشيط دفتر العمل. كلا من نطاق عرض OLE لدفتر العمل وأبعاد إطار الشريحة يؤثران. راجع [Working Solution for Chart Resizing in PPTX](/slides/ar/java/working-solution-for-chart-resizing-in-pptx/).

## **الأقسام ذات الصلة**

- [Working Solution for Chart Resizing in PPTX](/slides/ar/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/ar/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)