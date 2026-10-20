---
title: कार्यपत्रक आकार बदलने के लिए कार्य समाधान
type: docs
weight: 20
url: /hi/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- पूर्वावलोकन छवि
- छवि आकार बदलना
- Excel
- कार्यपत्रक
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "प्रस्तुतियों में Excel कार्यपत्रक OLE आकार बदलने को ठीक करें: दो तरीकों से ऑब्जेक्ट फ्रेम को सुसंगत रखें—फ़्रेम को स्केल करें या शीट को—PPT और PPTX फ़ॉर्मैट्स में।"
---
{{% alert color="info" title="Note" %}}
Aspose घटकों का उपयोग करके PowerPoint प्रस्तुति में OLE वस्तुओं के रूप में एम्बेड किए गए Excel कार्यपत्रक अपने पहले सक्रियण के बाद अनपेक्षित रूप से आकार बदल सकते हैं। यह व्यवहार OLE वस्तु के सक्रियण से पहले और बाद में स्पष्ट दृश्य अंतर उत्पन्न करता है। यह लेख समस्या को समझाता है और इसे हल करने के दो तरीके वर्णन करता है।
{{% /alert %}}

## **पृष्ठभूमि**

लेख [OLE प्रबंधन](/slides/hi/androidjava/manage-ole/) में, हमने बताया कि Aspose.Slides for Android via Java का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ें। [ऑब्जेक्ट पूर्वावलोकन समस्या](/slides/hi/androidjava/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए, हमने OLE ऑब्जेक्ट फ्रेम को चयनित कार्यपत्रक क्षेत्र की छवि सौंपी। आउटपुट प्रस्तुति में, जब आप कार्यपत्रक छवि प्रदर्शित करने वाले OLE ऑब्जेक्ट फ्रेम पर डबल-क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाती है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में कोई भी इच्छित परिवर्तन कर सकते हैं और फिर सक्रियित Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता स्लाइड पर लौटने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। रिसाइज़िंग कारक OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करेगा।

## **रीसाइज़िंग का कारण**

चूंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहले सक्रियण पर अपने मूल आकार को बनाए रखने की कोशिश करता है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। माइक्रोसॉफ़्ट के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर बातचीत करते हैं ताकि एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बनाए रखा जा सके। रीसाइज़िंग Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार एवं स्थिति के अंतर के आधार पर होती है।

## **कार्यशील समाधान**

रीसाइज़िंग प्रभाव से बचने के लिए दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम को चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के अनुरूप स्केल करें।
- OLE फ्रेम का आकार स्थिर रखें और चयनित पंक्तियों और स्तंभों को उसके भीतर फ़िट करने के लिए स्केल करें।

### **OLE फ्रेम आकार को स्केल करें**

यह दृष्टिकोण एम्बेडेड Excel कार्यपत्रक में चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के अनुसार OLE फ्रेम का आकार सेट करता है।

उदाहरण एक मौजूदा Excel वर्कबुक को लोड करता है और शून्य-आधारित सूचकांक का उपयोग करके उसकी पहली कार्यपत्रक की पहली 10 पंक्तियों और 13 स्तंभों का चयन करता है। [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) प्रदर्शित रेंज को निर्धारित करता है। प्रीव्यू 96 DPI पर रेंडर किया जाता है, और उसके पिक्सेल आयामों को प्रति इंच 72 पॉइंट्स का उपयोग करके पॉइंट्स में परिवर्तित किया जाता है। [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) संशोधित वर्कबुक को उन आयामों के साथ एक फ्रेम में एम्बेड करता है। प्रीव्यू को [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) के माध्यम से सौंपा जाता है ताकि सहेजे गए प्रस्तुति में "EMBEDDED OLE OBJECT" प्लेसहोल्डर को बदल दिया जाए।

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

// जब वर्कबुक फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है, तो प्रदर्शित आकार सेट करें।
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

प्रीव्यू हेल्पर चयनित रेंज के लिए [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) सेट करता है और मार्जिन, हेडर और फूटर को हटा देता है। [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) सक्षम होने पर, [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) रेंज को PNG छवि के रूप में रेंडर करता है। हेल्पर एक नया इनपुट स्ट्रीम लौटाता है जिसमें PNG छवि होती है, जो प्रस्तुति में उपयोग के लिए उसकी शुरुआत में स्थित होती है।

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

यह दृष्टिकोण चयनित पंक्तियों की ऊँचाइयों और चयनित स्तंभों की चौड़ाइयों को एक कस्टम OLE फ्रेम आकार के अनुरूप स्केल करता है।

उदाहरण एक मौजूदा Excel वर्कबुक को लोड करता है और शून्य-आधारित सूचकांक का उपयोग करके उसकी पहली कार्यपत्रक की पहली 10 पंक्तियों और 13 स्तंभों का चयन करता है। [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) प्रदर्शित रेंज को परिभाषित करता है, और नीचे दिया गया हेल्पर उस रेंज को 400 पॉइंट चौड़ी और 100 पॉइंट ऊँची फ्रेम में फिट करने के लिए स्केल करता है। संशोधित वर्कबुक को स्ट्रीम में बचाने के बाद, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) इसे निर्दिष्ट आकार में एम्बेड करता है। 96 DPI पर रेंडर किया गया प्रीव्यू [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) के माध्यम से सौंपा जाता है, जिससे सहेजी गई प्रस्तुति चयनित सेल्स को डिफ़ॉल्ट प्लेसहोल्डर के बजाय प्रदर्शित करती है।

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

// जब वर्कबुक फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है, तो प्रदर्शित आकार सेट करें।
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// फ़्रेम आकार में फिट होने के लिए सेल रेंज को स्केल करें।
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// हमें संशोधित वर्कबुक का उपयोग करना आवश्यक है।
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

स्केलिंग हेल्पर चयनित रेंज के लिए अलग-अलग चौड़ाई और ऊँचाई अनुपात गणना करता है, जिससे उसके स्तंभों की सापेक्ष चौड़ाई और पंक्तियों की सापेक्ष ऊँचाई बनी रहती है। यह गणना किए गए आयामों को पॉइंट्स से इंच में परिवर्तित करता है, फिर उन्हें [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) और [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) के साथ लागू करता है। चयनित रेंज की चौड़ाई और ऊँचाई शून्य नहीं होनी चाहिए।

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

यह प्रीव्यू हेल्पर पुनः आकारित रेंज को [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) का उपयोग करके रेंडर करता है। यह [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) को उस रेंज तक सीमित रखता है, मार्जिन, हेडर और फूटर को हटाता है, और एक PNG स्ट्रीम लौटाता है जो उसकी शुरुआत में स्थित होती है।

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
{{% alert color="info" title="Note" %}}
वर्कशीट रीसाइज़िंग समस्या को ठीक करने के दो तरीके हैं। वह तरीका चुनें जो आपकी आवश्यकताओं और उपयोग के मामलों के लिए सबसे उपयुक्त हो। दोनों तरीके समान रूप से काम करते हैं, चाहे प्रस्तुति टेम्पलेट से बनाई गई हो या शुरू से। इसके अतिरिक्त, इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**एक एम्बेडेड Excel कार्यपत्रक PowerPoint में पहले सक्रिय होने पर आकार क्यों बदलता है?**

यह इसलिए होता है क्योंकि Excel सक्रिय होने पर अपने मूल विंडो आकार को बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम के अपने आयाम होते हैं। PowerPoint और Excel आकार पर बातचीत करते हैं ताकि अनुपात बनाए रखा जा सके, जिससे रीसाइज़िंग हो सकती है।

**क्या इस रीसाइज़िंग समस्या को पूरी तरह से रोकना संभव है?**

हाँ। OLE फ्रेम को Excel सेल रेंज आकार के अनुरूप स्केल करके या सेल रेंज को इच्छित OLE फ्रेम आकार के अनुसार स्केल करके आप अनचाहे रीसाइज़िंग को रोक सकते हैं।

**कौन सी स्केलिंग विधि का उपयोग करूँ, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?**

यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप अपनी प्रस्तुति में OLE फ्रेम के लिए एक निश्चित आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

**क्या ये समाधान तब भी काम करेंगे जब मेरी प्रस्तुति टेम्पलेट पर आधारित हो?**

हाँ। दोनों समाधान टेम्पलेट से बनाई गई और शुरू से बनाई गई प्रस्तुतियों दोनों के लिए काम करते हैं।

**इन विधियों का उपयोग करते समय OLE फ्रेम के आकार पर कोई सीमा है क्या?**

नहीं। आप OLE ऑब्जेक्ट फ्रेम को किसी भी आकार का बना सकते हैं, जब तक आप स्केल को उचित रूप से सेट करें।

**"EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट को PowerPoint में कैसे हटाया जा सकता है?**

हाँ। लक्षित Excel सेल रेंज का स्नैपशॉट लेकर और उसे OLE फ्रेम की प्लेसहोल्डर छवि के रूप में सेट करके आप डिफ़ॉल्ट प्लेसहोल्डर के स्थान पर एक कस्टम प्रीव्यू छवि दिखा सकते हैं।

## **संबंधित लेख**

[Excel चार्ट बनाना और इसे OLE वस्तु के रूप में प्रस्तुति में एम्बेड करना](/slides/hi/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint ऐड-इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वचालित रूप से अपडेट करना](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)