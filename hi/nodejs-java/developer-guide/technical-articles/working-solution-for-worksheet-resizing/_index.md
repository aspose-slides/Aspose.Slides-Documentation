---
title: वर्कशीट आकार बदलने के लिए कार्य समाधान
type: docs
weight: 20
url: /hi/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- प्रीव्यू छवि
- छवि आकार बदलना
- Excel
- वर्कशीट
- PowerPoint
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "प्रेजेंटेशन में Excel वर्कशीट OLE आकार बदलने को ठीक करें: दो तरीके जिससे ऑब्जेक्ट फ्रेम स्थिर रहें—फ़्रेम या शीट को स्केल करें—PPT और PPTX फ़ॉर्मैट्स में।"
---
{{% alert color="info" title="Note" %}}

Aspose घटकों का उपयोग करके PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड की गई Excel वर्कशीट्स पहली बार सक्रिय होने के बाद अनपेक्षित रूप से आकार बदल सकती हैं। यह व्यवहार OLE ऑब्जेक्ट के सक्रिय होने से पहले और बाद में एक स्पष्ट दृश्य अंतर बनाता है। इस लेख में समस्या की व्याख्या की गई है और इसे समाधान करने के दो तरीके बताए गए हैं।

{{% /alert %}}

## **पृष्ठभूमि**

लेख [OLE प्रबंधन](/slides/hi/nodejs-java/manage-ole/) में हमने बताया कि Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ें। [ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए, हमने चयनित वर्कशीट क्षेत्र की छवि को OLE ऑब्जेक्ट फ्रेम को सौंपा। आउटपुट प्रस्तुति में, जब आप वर्कशीट छवि प्रदर्शित करने वाले OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाती है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में वांछित परिवर्तन कर सकते हैं और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर लौटने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। पुनःआकार कारक OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के आकार के आधार पर बदलता रहेगा।

## **आकार बदलने का कारण**

क्योंकि Excel वर्कबुक का अपना विंडो आकार होता है, वह पहली बार सक्रिय होने पर अपना मूल आकार बनाए रखने की कोशिश करता है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। Microsoft के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर बातचीत करते हैं ताकि एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बना रहे। पुनःआकार Excel विंडो के आकार और OLE ऑब्जेक्ट फ्रेम के आकार और स्थिति के अंतर के आधार पर होता है।

## **काम करने वाला समाधान**

आकार बदलने के प्रभाव से बचने के लिए दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम को स्केल करके चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के समान बनाएं।
- OLE फ्रेम का आकार स्थिर रखें और चयनित पंक्तियों और स्तंभों को उसके भीतर फिट होने के लिए स्केल करें।

### **OLE फ्रेम के आकार को स्केल करना**

यह विधि एम्बेडेड Excel वर्कशीट में चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के समान OLE फ्रेम का आकार सेट करती है।

उदाहरण एक मौजूदा Excel वर्कबुक को लोड करता है और शून्य‑आधारित इंडेक्स का उपयोग करके उसकी पहली वर्कशीट की पहली 10 पंक्तियों और 13 स्तंभों का चयन करता है। [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) प्रदर्शित रेंज को定义 करता है। प्रीव्यू 96 DPI पर रेंडर किया जाता है, और उसके पिक्सेल आयामों को 72 पॉइंट्स प्रति इंच का उपयोग करके पॉइंट्स में परिवर्तित किया जाता है। [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) संशोधित वर्कबुक को उन आयामों वाले फ्रेम में एम्बेड करता है। प्रीव्यू को [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) के माध्यम से असाइन किया जाता है ताकि सहेजी गई प्रस्तुति में "EMBEDDED OLE OBJECT" प्लेसहोल्डर को बदल दिया जा सके।

`aspose.cells`, `aspose.slides.via.java` और `java` पैकेज स्थापित करें और कार्य निर्देशिका में `sample.xlsx` रखें। प्रत्येक विधि के लिए, पहले तैयारी स्क्रिप्ट चलाएँ, फिर उसी निर्देशिका में एक अलग Node.js प्रक्रिया में एम्बेडिंग स्क्रिप्ट चलाएँ। दोनों Aspose पैकेज जावा ब्रिज को अलग‑अलग प्रारंभ करते हैं।

`prepare-frame-scaled.js` को तैयार करने वाली स्क्रिप्ट के रूप में सहेजें और इसे `node prepare-frame-scaled.js` के साथ चलाएँ। यह `frame-scaled.xlsx` और `frame-scaled.png` लिखती है।

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// सभी समकालिक कार्य पूर्ण हो गए हैं; Java ब्रिज प्रक्रिया को रोकें।
process.exit(0);
```

`embed-frame-scaled.js` को एम्बेडिंग स्क्रिप्ट के रूप में सहेजें और इसे `node embed-frame-scaled.js` के साथ चलाएँ। यह उन फ़ाइलों को पढ़ता है और `frame-scaled.pptx` लिखता है।

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// सभी समकालिक कार्य पूर्ण हो गए हैं; Java ब्रिज प्रक्रिया को रोकें।
process.exit(0);
```

प्रीव्यू हेल्पर [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) को चयनित रेंज पर सेट करता है और मार्जिन, हेडर, तथा फुटर को हटा देता है। [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) सक्षम होने पर, [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) रेंज को PNG छवि के रूप में रेंडर करता है। हेल्पर प्रस्तुति में उपयोग के लिए PNG छवि को फ़ाइल में सहेजता है।

### **सेल रेंज आकार को स्केल करना**

यह विधि चयनित पंक्तियों की ऊँचाइयों और चयनित स्तंभों की चौड़ाइयों को कस्टम OLE फ्रेम आकार के अनुरूप स्केल करती है।

उदाहरण एक मौजूदा Excel वर्कबुक को लोड करता है और शून्य‑आधारित इंडेक्स का उपयोग करके उसकी पहली वर्कशीट की पहली 10 पंक्तियों और 13 स्तंभों का चयन करता है। [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) प्रदर्शित रेंज को निर्धारित करता है, और हेल्पर उस रेंज को 400 पॉइंट चौड़ा और 100 पॉइंट ऊँचा फ्रेम में फिट करने के लिए स्केल करता है। संशोधित वर्कबुक को फ़ाइल में सहेजने के बाद, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) इसे निर्दिष्ट आकार में एम्बेड करता है। 96 DPI पर रेंडर किया गया प्रीव्यू [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) के माध्यम से असाइन किया जाता है, इसलिए सहेजी गई प्रस्तुति में चयनित सेल्स डिफ़ॉल्ट प्लेसहोल्डर के बजाय प्रदर्शित होते हैं।

`prepare-cells-scaled.js` को तैयारी स्क्रिप्ट के रूप में सहेजें और इसे `node prepare-cells-scaled.js` के साथ चलाएँ। यह `cells-scaled.xlsx` और `cells-scaled.png` लिखती है।

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// सभी समकालिक कार्य पूर्ण हो गए हैं; Java ब्रिज प्रक्रिया को रोकें।
process.exit(cellsPrepared ? 0 : 1);
```

`embed-cells-scaled.js` को एम्बेडिंग स्क्रिप्ट के रूप में सहेजें और इसे `node embed-cells-scaled.js` के साथ चलाएँ। यह उन फ़ाइलों को पढ़ता है और `cells-scaled.pptx` लिखता है।

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// सभी समकालिक कार्य पूर्ण हो गए हैं; Java ब्रिज प्रक्रिया को रोकें।
process.exit(0);
```

स्केलिंग हेल्पर चयनित रेंज के लिए अलग‑अलग चौड़ाई और ऊँचाई अनुपात गणना करता है, जिससे उसके स्तंभों की सापेक्ष चौड़ाई और पंक्तियों की सापेक्ष ऊँचाई संरक्षित रहती है। यह गणना किए गए आयामों को पॉइंट्स से इंच में बदलता है और फिर [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) और [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch) के साथ लागू करता है। चयनित रेंज की चौड़ाई और ऊँचाई शून्य नहीं होनी चाहिए।

यह प्रीव्यू हेल्पर पुनःआकारित रेंज को [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) का उपयोग करके रेंडर करता है। यह [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) को उस रेंज तक सीमित करता है, मार्जिन, हेडर और फुटर को हटाता है, और PNG छवि को फ़ाइल में सहेजता है।

## **निष्कर्ष**

{{% alert color="info" title="Note" %}}

वर्कशीट आकार बदलने की समस्या को ठीक करने के दो तरीके हैं। वह तरीका चुनें जो आपकी आवश्यकताओं और उपयोग केस के अनुकूल हो। दोनों तरीके समान रूप से कार्य करते हैं, चाहे प्रस्तुति टेम्पलेट से बनाई गई हो या शून्य से। इसके अतिरिक्त, इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में पहली बार सक्रिय होने पर एम्बेडेड Excel वर्कशीट का आकार क्यों बदल जाता है?**

यह इसलिए होता है क्योंकि Excel सक्रिय होने पर मूल विंडो आकार को बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आयाम होता है। PowerPoint और Excel आकार पर बातचीत करती हैं ताकि अनुपात बनाए रखा जा सके, जो आकार बदलने का कारण बनता है।

**क्या इस आकार बदलने की समस्या को पूरी तरह रोकना संभव है?**

हाँ। OLE फ्रेम को Excel सेल रेंज आकार के अनुसार स्केल करके या सेल रेंज को वांछित OLE फ्रेम आकार में फिट करने के लिए स्केल करके आप अनचाहे आकार बदलने को रोक सकते हैं।

**मैं कौन सी स्केलिंग विधि उपयोग करूँ, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?**

यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप अपनी प्रस्तुति में OLE फ्रेम के लिए एक निश्चित आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

**क्या ये समाधान मेरे टेम्पलेट‑आधारित प्रस्तुति में काम करेंगे?**

हाँ। दोनों समाधान टेम्पलेट से बनाई गई और शून्य से बनाई गई प्रस्तुतियों दोनों में कार्य करते हैं।

**इन विधियों का उपयोग करते समय OLE फ्रेम के आकार पर कोई सीमा है?**

नहीं। आप OLE ऑब्जेक्ट फ्रेम को कोई भी आकार दे सकते हैं, बशर्ते आप स्केल को उचित रूप से सेट करें।

**PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट से बचने का तरीका है?**

हाँ। लक्ष्य Excel सेल रेंज का स्नैपशॉट लेकर उसे OLE फ्रेम के प्लेसहोल्डर इमेज के रूप में सेट करके, आप डिफ़ॉल्ट प्लेसहोल्डर के बजाय एक कस्टम प्रीव्यू इमेज दिखा सकते हैं।

## **संबंधित लेख**

[एक Excel चार्ट बनाना और उसे प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड करना](/slides/hi/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint ऐड‑इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वतः अपडेट करना](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)