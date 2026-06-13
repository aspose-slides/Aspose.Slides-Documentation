---
title: वर्कशीट पुनः आकार के लिए कार्यात्मक समाधान
type: docs
weight: 20
url: /hi/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- पूर्वावलोकन छवि
- छवि आकार बदलना
- Excel
- वर्कशीट
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "प्रस्तुतियों में Excel वर्कशीट OLE आकार बदलना ठीक करें: ऑब्जेक्ट फ्रेम को समान रखने के दो तरीके—फ्रेम या शीट को स्केल करें—PPT और PPTX फ़ॉर्मेट्स में।"
---
{{% alert color="primary" %}}

यह देखा गया है कि Aspose घटकों के माध्यम से PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड किए गए Excel वर्कशीट्स पहली सक्रियता के बाद अनजाने स्केल पर पुनः आकारित हो जाते हैं। यह व्यवहार OLE ऑब्जेक्ट की सक्रियता से पहले और बाद की स्थिति के बीच प्रस्तुति में एक स्पष्ट दृश्य अंतर बनाता है। हमने इस समस्या की विस्तार से जांच की है और एक समाधान प्रदान किया है, जिसका विवरण इस लेख में दिया गया है।

{{% /alert %}}

## **पृष्ठभूमि**

लेख [Manage OLE](/slides/hi/androidjava/manage-ole/) में, हमने बताया कि Aspose.Slides for Android via Java का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ें। [object preview issue](/slides/hi/androidjava/object-preview-issue-when-adding-oleobjectframe/) को संबोधित करने के लिए, हमने चयनित वर्कशीट क्षेत्र की एक छवि को OLE ऑब्जेक्ट फ्रेम को असाइन किया। आउटपुट प्रस्तुति में, जब आप वर्कशीट छवि प्रदर्शित करने वाले OLE ऑब्जेक्ट फ्रेम पर दो बार क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाती है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में इच्छित कोई भी बदलाव कर सकते हैं और फिर सक्रियित Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता स्लाइड पर वापस आने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। पुनः आकार का कारक OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करता है।

## **पुनः आकार का कारण**

चूंकि Excel वर्कबुक की अपनी विंडो आकार होती है, यह पहली सक्रियता पर अपने मूल आकार को बरकरार रखने की कोशिश करता है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। माइक्रोसॉफ्ट के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर बातचीत करते हैं ताकि एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बना रहे। पुनः आकार Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार एवं स्थिति के बीच के अंतर के आधार पर होता है।

## **कार्यात्मक समाधान**

इस प्रभाव से बचने के दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम का आकार स्केल करें ताकि OLE फ्रेम में वांछित पंक्तियों और स्तंभों की ऊँचाई और चौड़ाई से मेल खाए।
- OLE फ्रेम का आकार स्थिर रखें और भाग लेने वाली पंक्तियों तथा स्तंभों के आकार को चुने हुए OLE फ्रेम आकार में फिट करने के लिए स्केल करें।

### **OLE फ्रेम आकार स्केल करें**

इस दृष्टिकोण में, हम सीखेंगे कि एम्बेडेड Excel वर्कबुक के OLE फ्रेम आकार को Excel वर्कशीट की भाग लेती हुई पंक्तियों और स्तंभों के संचयी आकार के साथ मिलाने के लिए कैसे सेट करें।

मान लीजिए हमारे पास एक टेम्प्लेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस परिदृश्य में, OLE ऑब्जेक्ट फ्रेम का आकार पहले वर्कबुक की भाग लेती हुई पंक्तियों की ऊँचाइयों और स्तंभों की चौड़ाइयों के संचयी मान के आधार पर गणना किया जाएगा। फिर हम OLE फ्रेम का आकार इस गणना किए हुए मान पर सेट करेंगे। PowerPoint में OLE फ्रेम के लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए, हम वर्कबुक में पंक्तियों और स्तंभों के इच्छित हिस्सों की एक छवि भी कैप्चर करेंगे और उसे OLE फ्रेम छवि के रूप में सेट करेंगे।

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// जब वर्कबुक फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है, तो प्रदर्शित आकार सेट करें।
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE छवि की चौड़ाई और ऊँचाई पॉइंट्स में प्राप्त करें।
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// हमें संशोधित वर्कबुक का उपयोग करना है।
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

### **सेल रेंज आकार स्केल करें**

इस दृष्टिकोण में, हम सीखेंगे कि भाग लेती हुई पंक्तियों की ऊँचाइयों और भाग लेती हुए स्तंभों की चौड़ाइयों को एक कस्टम OLE फ्रेम आकार के अनुरूप कैसे स्केल करें।

मान लीजिए हमारे पास एक टेम्प्लेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस परिदृश्य में, हम OLE फ्रेम का आकार सेट करेंगे और फिर OLE फ्रेम क्षेत्र में भाग लेती हुई पंक्तियों और स्तंभों के आकार को स्केल करेंगे। इसके बाद हम वर्कबुक को एक स्ट्रीम में सहेजेंगे ताकि परिवर्तन लागू हों और उसे बाइट एरे में परिवर्तित करके OLE फ्रेम में जोड़ सकें। PowerPoint में OLE फ्रेम के लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए, हम वर्कबुक में पंक्तियों और स्तंभों के इच्छित हिस्सों की एक छवि भी कैप्चर करेंगे और उसे OLE फ्रेम छवि के रूप में सेट करेंगे।

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// जब वर्कबुक फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है, तो प्रदर्शित आकार सेट करें।
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// फ्रेम आकार में फिट होने के लिए सेल रेंज को स्केल करें।
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// संशोधित वर्कबुक का उपयोग करना आवश्यक है।
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

वर्कशीट पुनः आकार समस्या को ठीक करने के दो तरीके हैं। उपयुक्त दृष्टिकोण का चयन विशिष्ट आवश्यकताओं और उपयोग केस पर निर्भर करता है। दोनों तरीके समान रूप से काम करते हैं, चाहे प्रस्तुति टेम्प्लेट से बनाई गई हो या शून्य से। इसके अलावा, इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**एक एम्बेडेड Excel वर्कशीट PowerPoint में पहली बार सक्रिय होने पर आकार क्यों बदलता है?**

यह इसलिए होता है क्योंकि Excel सक्रिय होने पर अपना मूल विंडो आकार बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आयाम होता है। PowerPoint और Excel आकार पर बातचीत करते हैं ताकि अनुपात बना रहे, जिससे पुनः आकार हो सकता है।

**क्या इस पुनः आकार समस्या को पूरी तरह रोकना संभव है?**

हां। OLE फ्रेम को Excel सेल रेंज आकार में फिट करने के लिए स्केल करके या सेल रेंज को इच्छित OLE फ्रेम आकार में फिट करने के लिए स्केल करके अनचाहे पुनः आकार को रोका जा सकता है।

**कौन सी स्केलिंग विधि उपयोग करनी चाहिए, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?**

यदि आप मूल Excel पंक्ति और स्तंभ आकार बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप अपनी प्रस्तुति में OLE फ्रेम का एक निश्चित आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

**क्या ये समाधान मेरी प्रस्तुति टेम्प्लेट से बनाये जाने पर भी काम करेंगे?**

हां। दोनों समाधान टेम्प्लेट से बनाई गई प्रस्तुतियों और शून्य से बनाई गई प्रस्तुतियों दोनों के लिए काम करते हैं।

**इन विधियों का उपयोग करने पर OLE फ्रेम के आकार पर कोई सीमा है क्या?**

नहीं। आप OLE ऑब्जेक्ट फ्रेम को कोई भी आकार दे सकते हैं, बस स्केल को उचित रूप से सेट करें।

**PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट से कैसे बचा जाए?**

हां। लक्ष्य Excel सेल रेंज की एक स्नैपशॉट लेकर उसे OLE फ्रेम के प्लेसहोल्डर इमेज के रूप में सेट करके आप डिफ़ॉल्ट प्लेसहोल्डर के स्थान पर एक कस्टम प्रीव्यू इमेज प्रदर्शित कर सकते हैं।