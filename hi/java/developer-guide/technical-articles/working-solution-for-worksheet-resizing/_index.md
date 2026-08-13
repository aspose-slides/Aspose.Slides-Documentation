---
title: वर्कशीट रीसेज़िंग के लिए कार्यशील समाधान
type: docs
weight: 20
url: /hi/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- प्रीव्यू छवि
- छवि रीसेज़िंग
- Excel
- वर्कशीट
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "प्रेजेंटेशन में Excel वर्कशीट OLE रीसेज़िंग का समाधान: दो तरीके जिससे ऑब्जेक्ट फ्रेम को सुसंगत रखा जा सके—फ्रेम को स्केल करें या शीट को—PPT और PPTX फॉर्मैट्स में।"
---
{{% alert color="info" %}}

यह देखा गया है कि Aspose घटकों के माध्यम से PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेडेड Excel वर्कशीट पहली सक्रियता के बाद अनजाने स्केल में रीसेज़ हो जाती है। इस व्यवहार के कारण OLE ऑब्जेक्ट की सक्रियता से पहले और बाद की स्थिति में प्रस्तुति में स्पष्ट दृश्य अंतर दिखता है। हमने इस समस्या की विस्तृत जाँच की है और एक समाधान प्रदान किया है, जो इस लेख में दर्शाया गया है।

{{% /alert %}}

## **पृष्ठभूमि**

हमने लेख [OLE प्रबंधन](/slides/hi/java/manage-ole/) में बताया था कि Aspose.Slides for Java का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ा जाए। [ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/java/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए हमने चयनित वर्कशीट क्षेत्र की इमेज को OLE ऑब्जेक्ट फ्रेम में असाइन किया। आउटपुट प्रस्तुति में जब आप वर्कशीट इमेज दिखाते हुए OLE ऑब्जेक्ट फ्रेम पर दो बार क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाता है। उपयोगकर्ता वास्तविक Excel वर्कबुक में कोई भी बदलाव कर सकते हैं और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर लौटने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। रीसेज़िंग कारक OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करेगा।

## **रीसेज़िंग का कारण**

चूँकि Excel वर्कबुक का अपना विंडो आकार होता है, वह पहली सक्रियता पर अपना मूल आकार बनाए रखने की कोशिश करता है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। Microsoft के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर बातचीत करके एम्बेडिंग प्रक्रिया के हिस्से के रूप में उचित अनुपात बनाए रखते हैं। रीसेज़िंग Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार व स्थान के अंतर के आधार पर होती है।

## **कार्यशील समाधान**

रीसेज़िंग प्रभाव से बचने के दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम आकार को स्केल करें ताकि यह OLE फ्रेम में इच्छित पंक्तियों और स्तंभों की ऊँचाई और चौड़ाई से मेल खाए।
- OLE फ्रेम आकार को स्थिर रखें और भाग लेने वाली पंक्तियों और स्तंभों के आकार को स्केल करके चयनित OLE फ्रेम आकार के भीतर फिट करें।

### **OLE फ्रेम आकार को स्केल करें**

इस विधि में हम सीखेंगे कि एम्बेडेड Excel वर्कबुक के OLE फ्रेम आकार को Excel वर्कशीट में भाग लेने वाली पंक्तियों और स्तंभों के कुल आकार से मिलाने के लिए कैसे सेट किया जाए।

मान लीजिए हमारे पास एक टेम्प्लेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में OLE ऑब्जेक्ट फ्रेम का आकार पहले वर्कबुक में भाग लेने वाली पंक्तियों की कुल ऊँचाई और स्तंभों की कुल चौड़ाई के आधार पर गणना किया जाएगा। फिर हम OLE फ्रेम का आकार इस गणना किए गए मान पर सेट करेंगे। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए हम वर्कबुक में आवश्यक पंक्तियों और स्तंभों के हिस्सों की इमेज भी कैप्चर करेंगे और उसे OLE फ्रेम इमेज के रूप में सेट करेंगे।

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// PowerPoint में वर्कबुक फ़ाइल को OLE ऑब्जेक्ट के रूप में उपयोग करने पर प्रदर्शित आकार सेट करें।
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE छवि की चौड़ाई और ऊँचाई पॉइंट में प्राप्त करें।
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// हमें संशोधित वर्कबुक का उपयोग करना होगा।
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// प्रेजेंटेशन संसाधनों में OLE छवि जोड़ें।
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

### **सेल रेंज आकार को स्केल करें**

इस विधि में हम सीखेंगे कि भाग लेने वाली पंक्तियों की ऊँचाई और भाग लेने वाले स्तंभों की चौड़ाई को कस्टम OLE फ्रेम आकार से मिलाने के लिए कैसे स्केल किया जाए।

मान लीजिए हमारे पास एक टेम्प्लेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में हम OLE फ्रेम का आकार सेट करेंगे और उन पंक्तियों और स्तंभों के आकार को स्केल करेंगे जो OLE फ्रेम क्षेत्र में भाग लेते हैं। फिर हम वर्कबुक को एक स्ट्रीम में सहेजेंगे ताकि परिवर्तन लागू हों और उसे बाइट एरे में परिवर्तित करके OLE फ्रेम में जोड़ सकें। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए हम वर्कबुक में आवश्यक पंक्तियों और स्तंभों के हिस्सों की इमेज कैप्चर करेंगे और उसे OLE फ्रेम इमेज के रूप में सेट करेंगे।

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// PowerPoint में वर्कबुक फ़ाइल को OLE ऑब्जेक्ट के रूप में उपयोग करने पर प्रदर्शित आकार सेट करें।
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// सेल रेंज को फ्रेम आकार में फिट होने के लिए स्केल करें।
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// हमें संशोधित वर्कबुक का उपयोग करना होगा।
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// प्रेजेंटेशन संसाधनों में OLE छवि जोड़ें।
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
 * @param width     सेल रेंज की अपेक्षित चौड़ाई पॉइंट में।
 * @param height    सेल रेंज की अपेक्षित ऊँचाई पॉइंट में।
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

{{% alert color="info" %}} 

वर्कशीट रीसेज़िंग समस्या को ठीक करने के दो दृष्टिकोण हैं। उपयुक्त दृष्टिकोण का चयन विशिष्ट आवश्यकताओं और उपयोग केस पर निर्भर करता है। दोनों ही विधियाँ समान रूप से काम करती हैं, चाहे प्रस्तुति टेम्प्लेट से बनायी़ं गयी हो या शून्य से। इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}

## **FAQ**

### पहली बार PowerPoint में सक्रिय होने पर एम्बेडेड Excel वर्कशीट का आकार क्यों बदल जाता है?

Excel सक्रिय होने पर अपना मूल विंडो आकार बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। PowerPoint और Excel आकार पर बातचीत करके अनुपात बनाए रखते हैं, जिससे रीसेज़िंग हो सकती है।

### क्या इस रीसेज़िंग समस्या को पूरी तरह से रोका जा सकता है?

हाँ। OLE फ्रेम को Excel सेल रेंज आकार के अनुसार स्केल करके या सेल रेंज को इच्छित OLE फ्रेम आकार के अनुसार स्केल करके अनचाहे रीसेज़िंग को रोका जा सकता है।

### कौन सा स्केलिंग तरीका उपयोग करना चाहिए, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?

यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप अपनी प्रस्तुति में OLE फ्रेम का स्थिर आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

### क्या ये समाधान तब भी काम करेंगे जब मेरी प्रस्तुति टेम्प्लेट पर आधारित हो?

हाँ। दोनों समाधान टेम्प्लेट से बनाए गए और शून्य से बने दोनों प्रकार की प्रस्तुतियों में काम करेंगे।

### इन विधियों का उपयोग करने पर OLE फ्रेम के आकार पर कोई सीमा है क्या?

नहीं। आप OLE ऑब्जेक्ट फ्रेम को जितना चाहें उतना बड़ा बना सकते हैं, बशर्ते आप स्केल को उचित रूप से सेट करें।

### PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट से कैसे बचें?

लक्ष्य Excel सेल रेंज की स्नैपशॉट लेकर उसे OLE फ्रेम की प्लेसहोल्डर इमेज के रूप में सेट करके आप डिफॉल्ट प्लेसहोल्डर की जगह कस्टम प्रीव्यू इमेज दिखा सकते हैं।

## **Related Articles**

[Excel चार्ट बनाना और इसे OLE ऑब्जेक्ट के रूप में प्रस्तुति में एम्बेड करना](/slides/hi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint ऐड-इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वत: अपडेट करना](/slides/hi/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)