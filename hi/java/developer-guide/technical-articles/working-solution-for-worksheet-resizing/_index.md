---
title: वर्कशीट आकार बदलने के लिए कार्य समाधान
type: docs
weight: 20
url: /hi/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- पूर्वावलोकन छवि
- छवि रिसाइज़िंग
- Excel
- वर्कशीट
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "प्रस्तुति में Excel वर्कशीट OLE रिसाइज़िंग को ठीक करें: दो तरीके जिससे ऑब्जेक्ट फ्रेम स्थिर रहें—फ्रेम को स्केल करें या शीट को स्केल करें—PPT और PPTX फॉर्मेट्स में।"
---
{{% alert color="info" title="Note" %}}

Aspose घटकों का उपयोग करके PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड की गई Excel वर्कशीट्स पहली सक्रियता के बाद अप्रत्याशित रूप से आकार बदल सकती हैं। यह व्यवहार OLE ऑब्जेक्ट के सक्रिय होने से पहले और बाद में स्पष्ट दृश्य अंतर बनाता है। यह लेख समस्या को समझाता है और इसे हल करने के दो तरीके बताता है।

{{% /alert %}}

## **पृष्ठभूमि**

लेख में [OLE प्रबंधन](/slides/hi/java/manage-ole/) हमने बताया कि Aspose.Slides for Java का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ा जाए। [ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/java/object-preview-issue-when-adding-oleobjectframe/) को दूर करने के लिए हमने चयनित वर्कशीट क्षेत्र की एक छवि को OLE ऑब्जेक्ट फ्रेम को सौंपा। आउटपुट प्रस्तुति में, जब आप वर्कशीट छवि दिखाने वाले OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाता है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में इच्छित परिवर्तन कर सकते हैं और सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस लौट सकते हैं। उपयोगकर्ता के स्लाइड पर लौटने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। आकार बदलने का अनुपात OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करता है।

## **आकार बदलने का कारण**

क्योंकि Excel वर्कबुक का अपना विंडो आकार होता है, वह पहली सक्रियता पर अपना मूल आकार बनाए रखने की कोशिश करता है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। Microsoft के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर बातचीत करते हैं ताकि एंबेडिंग प्रक्रिया के हिस्से के रूप में उचित अनुपात बना रहे। आकार परिवर्तन Excel विंडो के आकार और OLE ऑब्जेक्ट फ्रेम के आकार एवं स्थिति के अंतर के आधार पर होता है।

## **कार्यशील समाधान**

आकार बदलने के प्रभाव से बचने के दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम को स्केल करें ताकि वह चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के बराबर हो जाए।
- OLE फ्रेम का आकार स्थिर रखें और चयनित पंक्तियों एवं स्तंभों को उसके भीतर फिट करने के लिए स्केल करें।

### **OLE फ्रेम आकार स्केल करें**

यह विधि एम्बेडेड Excel वर्कशीट में चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई से मेल खाने के लिए OLE फ्रेम का आकार निर्धारित करती है।

उदाहरण मौजूदा Excel वर्कबुक को लोड करता है और शून्य‑आधारित सूचकांकों का उपयोग करके उसकी पहली वर्कशीट की पहली 10 पंक्तियों और 13 स्तंभों को चुनता है। [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) प्रदर्शित रेंज को परिभाषित करता है। प्रीव्यू 96 DPI पर रेंडर किया जाता है, और उसके पिक्सेल आयामों को 72 पॉइंट्स प्रति इंच द्वारा पॉइंट्स में परिवर्तित किया जाता है। [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) संशोधित वर्कबुक को उन आयामों के साथ फ्रेम में एम्बेड करता है। प्रीव्यू को [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) के माध्यम से सौंपा जाता है ताकि सहेजी गई प्रस्तुति में "EMBEDDED OLE OBJECT" प्लेसहोल्डर को बदल सके।

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

// PowerPoint में वर्कबुक फ़ाइल को OLE ऑब्जेक्ट के रूप में उपयोग किए जाने पर प्रदर्शित आकार सेट करें।
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE छवि की चौड़ाई और ऊँचाई पॉइंट्स में प्राप्त करें।
Image image = ImageIO.read(imageStream);
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

प्रीव्यू हेल्पर चयनित रेंज को [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) के साथ सेट करता है और मार्जिन, हेडर और फुटर को हटाता है। [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) सक्षम होने पर, [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) रेंज को PNG छवि के रूप में रेंडर करता है। हेल्पर नया इनपुट स्ट्रीम लौटाता है जिसमें PNG छवि की शुरुआत पर स्थित होता है, जिसे प्रस्तुति में उपयोग किया जा सकता है।

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

यह विधि चयनित पंक्तियों की ऊँचाई और चयनित स्तंभों की चौड़ाई को कस्टम OLE फ्रेम आकार के अनुरूप स्केल करती है।

उदाहरण मौजूदा Excel वर्कबुक को लोड करता है और शून्य‑आधारित सूचकांकों का उपयोग करके उसकी पहली वर्कशीट की पहली 10 पंक्तियों और 13 स्तंभों को चुनता है। [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) प्रदर्शित रेंज को परिभाषित करता है, और नीचे दिया गया हेल्पर उस रेंज को 400 पॉइंट्स चौड़ी और 100 पॉइंट्स ऊँची फ्रेम में फिट करने के लिए स्केल करता है। संशोधित वर्कबुक को एक स्ट्रीम में सहेजने के बाद, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) निर्दिष्ट आकार के साथ फ्रेम में एम्बेड किया जाता है। 96 DPI पर रेंडर किया गया प्रीव्यू [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) के माध्यम से सौंपा जाता है, इसलिए सहेजी गई प्रस्तुति चयनित सेल्स को डिफ़ॉल्ट प्लेसहोल्डर के बजाय दिखाती है।

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

// PowerPoint में वर्कबुक फ़ाइल को OLE ऑब्जेक्ट के रूप में उपयोग किए जाने पर प्रदर्शित आकार सेट करें।
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

// OLE ऑब्जेक्ट फ्रेम बनाएं।
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

स्केलिंग हेल्पर चयनित रेंज के लिए अलग‑अलग चौड़ाई और ऊँचाई अनुपात की गणना करता है, जिससे उसके कॉलमों की सापेक्ष चौड़ाई और पंक्तियों की सापेक्ष ऊँचाई बनी रहती है। यह गणना किए गए आयामों को पॉइंट्स से इंच में बदलता है और फिर [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) तथा [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) के साथ लागू करता है। चयनित रेंज की चौड़ाई और ऊँचाई दोनों शून्य नहीं होनी चाहिए।

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

यह प्रीव्यू हेल्पर [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) का उपयोग करके रिसाइज़ किए गए रेंज को रेंडर करता है। यह [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) को उस रेंज तक सीमित करता है, मार्जिन, हेडर और फुटर को हटाता है, और PNG स्ट्रीम को उसकी शुरुआत पर स्थित करके लौटाता है।

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

वर्कशीट आकार बदलने की समस्या को ठीक करने के दो तरीके हैं। अपनी आवश्यकताओं और उपयोग केस के अनुसार उपयुक्त तरीका चुनें। दोनों तरीके समान रूप से काम करते हैं, चाहे प्रस्तुति टेम्पलेट से बनाई गई हो या शून्य से। इसके अलावा इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**पहली सक्रियता पर PowerPoint में एम्बेडेड Excel वर्कशीट आकार क्यों बदलती है?**

यह इसलिए होता है क्योंकि Excel पहली बार सक्रिय होने पर अपना मूल विंडो आकार बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। PowerPoint और Excel आकार पर बातचीत करके अनुपात बरकरार रखते हैं, जिससे आकार बदलना हो सकता है।

**क्या इस आकार बदलने की समस्या को पूरी तरह रोकना संभव है?**

हाँ। OLE फ्रेम को Excel सेल रेंज आकार के अनुसार स्केल करके या सेल रेंज को इच्छित OLE फ्रेम आकार में फिट करने के लिए स्केल करके आप अनपेक्षित आकार बदलने से बच सकते हैं।

**कौन सी स्केलिंग विधि उपयोग करनी चाहिए, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?**

यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप प्रस्तुति में OLE फ्रेम का आकार स्थिर रखना चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

**क्या ये समाधान मेरे टेम्पलेट‑आधारित प्रस्तुति में काम करेंगे?**

हाँ। दोनों समाधान टेम्पलेट से बनाई गई प्रस्तुतियों और शून्य से बनाई गई प्रस्तुतियों दोनों में काम करते हैं।

**इन विधियों का उपयोग करते हुए OLE फ्रेम के आकार पर कोई सीमा है क्या?**

नहीं। आप OLE ऑब्जेक्ट फ्रेम को कोई भी आकार दे सकते हैं, बशर्ते आप स्केल उपयुक्त रूप से सेट करें।

**PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट से बचने का कोई तरीका है?**

हाँ। लक्षित Excel सेल रेंज की स्नैपशॉट लेकर उसे OLE फ्रेम के प्लेसहोल्डर इमेज के रूप में सेट करने से आप डिफ़ॉल्ट प्लेसहोल्डर के बजाय कस्टम प्रीव्यू छवि दिखा सकते हैं।

## **संबंधित लेख**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/hi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)