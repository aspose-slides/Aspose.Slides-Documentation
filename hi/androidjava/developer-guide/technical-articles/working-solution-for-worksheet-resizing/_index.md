---
title: "वर्कशीट रीसेज़िंग के लिए कार्यशील समाधान"
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
description: "प्रेजेंटेशन में Excel वर्कशीट OLE रीसेज़िंग को ठीक करें: दो तरीके जिससे ऑब्जेक्ट फ्रेम को स्थिर रखें—फ़्रेम को स्केल करें या शीट को—PPT और PPTX फ़ॉर्मैट में।"
---
{{% alert color="info" %}}

यह देखा गया है कि Aspose घटकों के माध्यम से PowerPoint प्रस्तुति में OLE वस्तु के रूप में एम्बेड किए गए Excel कार्यपत्रकों को पहली सक्रियता के बाद अनजान स्केल में रीसेज़ किया जाता है। यह व्यवहार OLE वस्तु की पूर्व-और-पर-क्रिया स्थिति के बीच एक स्पष्ट दृश्य अंतर बनाता है। हमने इस समस्या की गहन जांच की है और एक समाधान प्रस्तुत किया है, जिसका विवरण इस लेख में दिया गया है।

{{% /alert %}}

## **पृष्ठभूमि**

लेख में [Manage OLE](/slides/hi/androidjava/manage-ole/) हमने बताया था कि Aspose.Slides for Android via Java का उपयोग करके PowerPoint प्रस्तुति में OLE फ़्रेम कैसे जोड़ें। [object preview issue](/slides/hi/androidjava/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए हमने चयनित कार्यपत्रक क्षेत्र की छवि को OLE वस्तु फ़्रेम में असाइन किया। आउटपुट प्रस्तुति में, जब आप कार्यपत्रक छवि दिखाने वाले OLE वस्तु फ़्रेम पर डबल‑क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाता है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में इच्छित परिवर्तन कर सकता है और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकता है। उपयोगकर्ता के स्लाइड पर लौटने पर OLE वस्तु फ़्रेम का आकार बदल जाता है। रीसेज़िंग फ़ैक्टर OLE वस्तु फ़्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करता है।

## **रीसेज़िंग का कारण**

चूंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपना मूल आकार बनाए रखने का प्रयास करती है। दूसरी ओर, OLE वस्तु फ़्रेम का अपना आकार होता है। Microsoft के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार का समन्वय करते हैं ताकि एम्बेडिंग प्रक्रिया के भाग के रूप में सही अनुपात बना रहे। रीसेज़िंग Excel विंडो आकार और OLE वस्तु फ़्रेम के आकार व स्थिति के बीच अंतर के आधार पर होती है।

## **कार्यशील समाधान**

रीसेज़िंग प्रभाव से बचने के दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ़्रेम का आकार उस वांछित पंक्तियों और कॉलमों की ऊँचाई व चौड़ाई से मेल करने के लिए स्केल करें।
- OLE फ़्रेम का आकार स्थिर रखें और भाग लेने वाली पंक्तियों व कॉलमों का आकार चयनित OLE फ़्रेम के भीतर फिट करने के लिए स्केल करें।

### **OLE फ़्रेम आकार स्केल करें**

इस दृष्टिकोण में हम सीखेंगे कि एम्बेडेड Excel वर्कबुक के OLE फ़्रेम का आकार Excel कार्यपत्रक में भाग लेने वाली पंक्तियों और कॉलमों के संचयी आकार के अनुसार कैसे सेट करें।

मान लें कि हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ़्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में, OLE वस्तु फ़्रेम का आकार पहले वर्कबुक में भाग लेने वाली पंक्तियों की ऊँचाइयों और कॉलमों की चौड़ाई के संचयी मान के आधार पर गणना किया जाएगा। फिर हम OLE फ़्रेम का आकार इस गणना किए गए मान पर सेट करेंगे। PowerPoint में OLE फ़्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए हम वर्कबुक में वांछित भागों की छवि भी कैप्चर करेंगे और उसे OLE फ़्रेम छवि के रूप में सेट करेंगे।

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// PowerPoint में OLE ऑब्जेक्ट के रूप में वर्कबुक फ़ाइल उपयोग होने पर प्रदर्शित आकार सेट करें।
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE छवि की चौड़ाई और ऊँचाई को बिंदुओं में प्राप्त करें।
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

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

// OLE ऑब्जेक्ट फ़्रेम बनाएं।
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

### **सेल रेंज आकार स्केल करें**

इस दृष्टिकोण में हम सीखेंगे कि भाग लेने वाली पंक्तियों की ऊँचाइयों और भाग लेने वाले कॉलमों की चौड़ाई को एक कस्टम OLE फ़्रेम आकार से मेल कराने के लिए कैसे स्केल किया जाए।

मान लें कि हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ़्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस परिदृश्य में, हम OLE फ़्रेम का आकार सेट करेंगे और उस क्षेत्र में भाग लेने वाली पंक्तियों और कॉलमों के आकार को स्केल करेंगे। फिर हम वर्कबुक को एक स्ट्रीम में सहेजेंगे ताकि परिवर्तन लागू हों और उसे बाइट एरे में बदलकर OLE फ़्रेम में जोड़ें। PowerPoint में OLE फ़्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए हम वर्कबुक में वांछित भागों की छवि भी कैप्चर करेंगे और उसे OLE फ़्रेम छवि के रूप में सेट करेंगे।

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

// PowerPoint में OLE ऑब्जेक्ट के रूप में वर्कबुक फ़ाइल उपयोग होने पर प्रदर्शित आकार सेट करें।
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// फ़्रेम आकार में फिट होने के लिए सेल रेंज को स्केल करें।
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// हमें संशोधित वर्कबुक का उपयोग करना है।
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE छवि को प्रस्तुति संसाधनों में जोड़ें।
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE ऑब्जेक्ट फ़्रेम बनाएं।
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
 * @param width     अपेक्षित चौड़ाई बिंदुओं में।
 * @param height    अपेक्षित ऊँचाई बिंदुओं में।
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

वर्कशीट रीसेज़िंग समस्या को ठीक करने के दो दृष्टिकोण हैं। उचित दृष्टिकोण का चयन विशेष आवश्यकताओं और उपयोग केस पर निर्भर करता है। दोनों ही तरीकों का कार्य समान है, चाहे प्रस्तुति टेम्पलेट से बनाई गई हो या शून्य से। इसके अतिरिक्त इस समाधान में OLE वस्तु फ़्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### पहली बार PowerPoint में सक्रिय होने पर एम्बेडेड Excel कार्यपत्रक आकार क्यों बदलता है?

यह इसलिए होता है क्योंकि Excel सक्रिय होने पर मूल विंडो आकार बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE वस्तु फ़्रेम का अपना आकार होता है। PowerPoint और Excel आकार का समायोजन करते हैं ताकि अनुपात बना रहे, जिससे रीसेज़िंग हो सकती है।

### क्या इस रीसेज़िंग समस्या को पूरी तरह रोकना संभव है?

हां। OLE फ़्रेम को Excel सेल रेंज आकार के अनुसार फिट करके या सेल रेंज को वांछित OLE फ़्रेम आकार के अनुसार स्केल करके आप अनचाहे रीसेज़िंग को रोक सकते हैं।

### मुझे कौन सी स्केलिंग विधि चुननी चाहिए, OLE फ़्रेम स्केलिंग या सेल रेंज स्केलिंग?

यदि आप मूल Excel पंक्तियों और कॉलमों के आकार को बनाए रखना चाहते हैं तो **OLE फ़्रेम स्केलिंग** चुनें। यदि आप अपनी प्रस्तुति में OLE फ़्रेम का निश्चित आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

### क्या ये समाधान तब भी काम करेंगे जब मेरी प्रस्तुति टेम्पलेट पर आधारित हो?

हां। दोनों समाधान टेम्पलेट से बनाई गई प्रस्तुति और शून्य से बनाई गई प्रस्तुति दोनों पर काम करते हैं।

### इन विधियों का उपयोग करते समय OLE फ़्रेम के आकार पर कोई सीमा है क्या?

नहीं। आप OLE वस्तु फ़्रेम का आकार जितना चाहें सेट कर सकते हैं, बशर्ते आप स्केल को उचित रूप से निर्धारित करें।

### PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट से कैसे बचें?

हां। लक्ष्य Excel सेल रेंज की स्नैपशॉट लेकर उसे OLE फ़्रेम की प्लेसहोल्डर छवि के रूप में सेट करके आप डिफ़ॉल्ट प्लेसहोल्डर की जगह एक कस्टम पूर्वावलोकन छवि प्रदर्शित कर सकते हैं।