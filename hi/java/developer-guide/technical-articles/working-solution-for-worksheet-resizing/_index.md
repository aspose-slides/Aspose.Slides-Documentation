---
title: कार्यपत्रक आकार परिवर्तन के लिए कार्यशील समाधान
type: docs
weight: 20
url: /hi/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- पूर्वावलोकन छवि
- छवि आकार परिवर्तन
- Excel
- कार्यपत्रक
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "प्रस्तुतियों में Excel कार्यपत्रक OLE आकार परिवर्तन को ठीक करें: ऑब्जेक्ट फ्रेम को सुसंगत रखने के दो तरीके—फ़्रेम या शीट को स्केल करना—PPT और PPTX फ़ॉर्मेट्स में।"
---
{{% alert color="primary" %}}

यह देखा गया है कि Aspose घटकों के माध्यम से PowerPoint प्रस्तुति में OLE वस्तुओं के रूप में एम्बेड किए गए Excel कार्यपत्रकों को पहली सक्रियता के बाद अज्ञात स्केल में पुनः आकार दिया जाता है। यह व्यवहार OLE वस्तु की सक्रियता से पहले और बाद की स्थिति के बीच प्रस्तुति में एक स्पष्ट दृश्य अंतर बनाता है। हमने इस समस्या की विस्तार से जांच की है और एक समाधान प्रदान किया है, जो इस लेख में कवर किया गया है।

{{% /alert %}}

## **पृष्ठभूमि**

लेख [Manage OLE](/slides/hi/java/manage-ole/) में, हमने बताया कि Aspose.Slides for Java का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ें। [object preview issue](/slides/hi/java/object-preview-issue-when-adding-oleobjectframe/) को संबोधित करने के लिए, हमने चयनित कार्यपत्रक क्षेत्र की एक छवि को OLE ऑब्जेक्ट फ्रेम को असाइन किया। आउटपुट प्रस्तुति में, जब आप कार्यपत्रक छवि दिखाने वाले OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाती है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में कोई भी इच्छित परिवर्तन कर सकते हैं और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर वापस आने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। आकार परिवर्तन कारक OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करेगा।

## **आकार परिवर्तन का कारण**

चूँकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपने मूल आकार को बनाए रखने की कोशिश करता है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। Microsoft के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर बातचीत करते हैं ताकि एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बना रहे। आकार परिवर्तन Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार व स्थिति के बीच अंतर के आधार पर होता है।

## **कार्यशील समाधान**

आकार परिवर्तन प्रभाव से बचने के लिए दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम आकार को स्केल करें ताकि यह OLE फ्रेम में वांछित पंक्तियों और स्तंभों की संख्या की ऊँचाई और चौड़ाई से मेल खाए।
- OLE फ्रेम आकार को स्थिर रखें और चयनित OLE फ्रेम आकार के भीतर फिट होने के लिए भाग ले रही पंक्तियों और स्तंभों के आकार को स्केल करें।

### **OLE फ्रेम आकार स्केल करना**

इस दृष्टिकोण में, हम सीखेंगे कि एम्बेडेड Excel वर्कबुक का OLE फ्रेम आकार कैसे सेट करें ताकि यह Excel कार्यपत्रक में भाग ले रही पंक्तियों और स्तंभों के संचयी आकार से मेल खाए।

मान लीजिए हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस परिदृश्य में, OLE ऑब्जेक्ट फ्रेम का आकार पहले वर्कबुक में भाग ले रही पंक्तियों और स्तंभों की संचयी पंक्ति ऊँचाई और स्तंभ चौड़ाई के आधार पर गणना किया जाएगा। फिर, हम OLE फ्रेम का आकार इस गणना किए गए मान पर सेट करेंगे। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए, हम वर्कबुक में पंक्तियों और स्तंभों के वांछित भाग की एक छवि भी कैप्चर करेंगे और इसे OLE फ्रेम की छवि के रूप में सेट करेंगे।

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// PowerPoint में कार्यपुस्तिका फ़ाइल को OLE ऑब्जेक्ट के रूप में उपयोग किए जाने पर प्रदर्शित आकार सेट करें।
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE छवि की चौड़ाई और ऊँचाई को पॉइंट्स में प्राप्त करें।
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// हमें संशोधित कार्यपुस्तिका का उपयोग करना होगा।
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE छवि को प्रस्तुति संसाधनों में जोड़ें।
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE ऑब्जेक्ट फ्रेम बनाएं।
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **सेल रेंज आकार स्केल करना**

इस दृष्टिकोण में, हम सीखेंगे कि भाग ले रही पंक्तियों की ऊँचाइयों और भाग ले रहे स्तंभों की चौड़ाई को कैसे स्केल करें ताकि यह एक अनुकूलित OLE फ्रेम आकार से मेल खाए।

मान लीजिए हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस परिदृश्य में, हम OLE फ्रेम का आकार सेट करेंगे और OLE फ्रेम क्षेत्र में भाग ले रही पंक्तियों और स्तंभों के आकार को स्केल करेंगे। फिर हम वर्कबुक को एक स्ट्रीम में सहेजेंगे ताकि परिवर्तन लागू हों और इसे बाइट एरे में परिवर्तित करेंगे ताकि इसे OLE फ्रेम में जोड़ा जा सके। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए, हम वर्कबुक में पंक्तियों और स्तंभों के वांछित भाग की एक छवि भी कैप्चर करेंगे और इसे OLE फ्रेम की छवि के रूप में सेट करेंगे।

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// PowerPoint में कार्यपुस्तिका फ़ाइल को OLE ऑब्जेक्ट के रूप में उपयोग किए जाने पर प्रदर्शित आकार सेट करें।
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// फ़्रेम आकार में फिट होने के लिए सेल रेंज को स्केल करें।
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// हमें संशोधित कार्यपुस्तिका का उपयोग करना होगा।
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE छवि को प्रस्तुति संसाधनों में जोड़ें।
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE ऑब्जेक्ट फ्रेम बनाएं।
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     सेल रेंज की अपेक्षित चौड़ाई पॉइंट्स में।
 * @param height    सेल रेंज की अपेक्षित ऊँचाई पॉइंट्स में।
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **निष्कर्ष**

{{% alert color="primary" %}} 

कार्यपत्रक आकार परिवर्तन मुद्दे को ठीक करने के दो दृष्टिकोण हैं। उपयुक्त दृष्टिकोण का चयन विशेष आवश्यकताओं और उपयोग केस पर निर्भर करता है। दोनों दृष्टिकोण समान रूप से काम करते हैं, चाहे प्रस्तुतियाँ टेम्पलेट से बनाई गई हों या शून्य से। इसके अतिरिक्त, इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है। 

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**जब PowerPoint में एक एम्बेडेड Excel कार्यपत्रक पहली बार सक्रिय होता है तो उसका आकार क्यों बदलता है?**

यह इसलिए होता है क्योंकि Excel सक्रिय होने पर मूल विंडो आकार को बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम की अपनी आयाम होते हैं। PowerPoint और Excel आकार पर बातचीत करते हैं ताकि अनुपात बना रहे, जिससे आकार परिवर्तन हो सकता है।

**क्या इस आकार परिवर्तन समस्या को पूरी तरह से रोका जा सकता है?**

हाँ। OLE फ्रेम को Excel सेल रेंज आकार में फिट करने के लिए स्केल करके या सेल रेंज को वांछित OLE फ्रेम आकार में फिट करने के लिए स्केल करके, आप अनचाहे आकार परिवर्तन को रोक सकते हैं।

**कौनसी स्केलिंग विधि इस्तेमाल करूँ, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?**

यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप अपनी प्रस्तुति में OLE फ्रेम के लिए एक निश्चित आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

**क्या ये समाधान मेरे प्रस्तुति टेम्पलेट पर आधारित होने पर भी काम करेंगे?**

हाँ। दोनों समाधान टेम्पलेट से बनाई गई प्रस्तुतियों और शून्य से बनाई गई प्रस्तुतियों दोनों के लिए काम करते हैं।

**इन विधियों का उपयोग करते समय OLE फ्रेम के आकार पर कोई सीमा है क्या?**

नहीं। आप OLE ऑब्जेक्ट फ्रेम को कोई भी आकार दे सकते हैं, बस स्केल को उचित रूप से सेट करें।

**क्या PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट से बचने का कोई तरीका है?**

हाँ। लक्ष्य Excel सेल रेंज की_snapshot_ ले कर और उसे OLE फ्रेम के प्लेसहोल्डर इमेज के रूप में सेट करके, आप डिफॉल्ट प्लेसहोल्डर के स्थान पर एक कस्टम प्रीव्यू इमेज दिखा सकते हैं।

## **संबंधित लेख**

[एक Excel चार्ट बनाना और उसे प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड करना](/slides/hi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint ऐड‑इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वतः अपडेट करना](/slides/hi/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)