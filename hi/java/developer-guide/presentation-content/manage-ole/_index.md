---
title: "Java का उपयोग करके प्रस्तुतियों में OLE प्रबंधित करें"
linktitle: "OLE प्रबंधन"
type: docs
weight: 40
url: /hi/java/manage-ole/
keywords:
- OLE ऑब्जेक्ट
- ऑब्जेक्ट लिंकिंग और एम्बेडिंग
- OLE जोड़ें
- OLE एम्बेड करें
- ऑब्जेक्ट जोड़ें
- ऑब्जेक्ट एम्बेड करें
- फ़ाइल जोड़ें
- फ़ाइल एम्बेड करें
- लिंक्ड ऑब्जेक्ट
- लिंक्ड फ़ाइल
- OLE बदलें
- OLE आयकन
- OLE शीर्षक
- OLE निकालें
- ऑब्जेक्ट निकालें
- फ़ाइल निकालें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert color="info" title="Note" %}}

OLE (ऑब्जेक्ट लिंकिंग और एम्बेडिंग) Microsoft की तकनीक है जो एक एप्लिकेशन में बनाए गए डेटा और ऑब्जेक्ट्स को लिंकिंग या एम्बेडिंग के माध्यम से किसी अन्य एप्लिकेशन में रखने की अनुमति देती है।

{{% /alert %}} 

MS Excel में बनाया गया एक चार्ट विचार करें। यह चार्ट फिर PowerPoint स्लाइड में रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है।

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन पर दो बार क्लिक करते हैं, तो चार्ट अपने सम्बंधित एप्लिकेशन (Excel) में खुल जाता है, या आपको ऑब्जेक्ट खोलने या संपादित करने के लिए एक एप्लिकेशन चुनने के लिए कहा जाता है।
- एक OLE ऑब्जेक्ट अपनी वास्तविक सामग्री, जैसे कि चार्ट की सामग्री, प्रदर्शित कर सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट के डेटा को संशोधित कर सकते हैं।

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) आपको OLE ऑब्जेक्ट्स को स्लाइड्स में OLE ऑब्जेक्ट फ्रेम्स ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)) के रूप में सम्मिलित करने की अनुमति देता है।

## **OLE ऑब्जेक्ट फ्रेम्स को स्लाइड्स में जोड़ना**

मान लीजिए आपने Microsoft Excel में पहले से एक चार्ट बना लिया है और इसे Aspose.Slides for Java का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में किसी स्लाइड में एम्बेड करना चाहते हैं, तो आप इसे इस प्रकार कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. स्लाइड की इंडेक्स के माध्यम से उसका रेफ़रेंस प्राप्त करें।
3. Excel फ़ाइल को बाइट ऐरे के रूप में पढ़ें।
4. स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) जोड़ें जिसमें बाइट ऐरे और OLE ऑब्जेक्ट के अन्य जानकारी शामिल हो।
5. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे के उदाहरण में, हमने Excel फ़ाइल से एक चार्ट को Aspose.Slides for Java का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में जोड़ा है।  
**नोट** यह है कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) कंस्ट्रक्टर दूसरा पैरामीटर के रूप में एक एम्बेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से समझने और इस OLE ऑब्जेक्ट को खोलने के लिए सही एप्लिकेशन चुनने में सक्षम बनाता है।

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम्स जोड़ना**

Aspose.Slides for Java आपको डेटा एम्बेड किए बिना केवल फ़ाइल के लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) जोड़ने की अनुमति देता है।

यह Java कोड आपको दिखाता है कि कैसे एक लिंक्ड Excel फ़ाइल के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) को स्लाइड में जोड़ें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// लिंक्ड Excel फ़ाइल के साथ एक OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ्रेम्स तक पहुंच**

यदि एक OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इसे इस तरह आसानी से ढूंढ़ या एक्सेस कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाली प्रेजेंटेशन लोड करें।
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
3. [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) शेप को एक्सेस करें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक शेप है। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) में *cast* किया। यह वह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया जाना था।
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा को एक्सेस किया गया है।

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // एम्बेडेड फ़ाइल डेटा प्राप्त करें।
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // एम्बेडेड फ़ाइल का एक्सटेंशन प्राप्त करें।
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम प्रॉपर्टीज़ तक पहुंच**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम प्रॉपर्टीज़ तक पहुंचने की अनुमति देता है।

यह Java कोड आपको दिखाता है कि कैसे जांचें कि कोई OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पथ प्राप्त करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // जांचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
    if (oleFrame.isObjectLink()) {
        // लिंक्ड फ़ाइल का पूर्ण पथ प्रिंट करें।
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेटिव पथ प्रिंट करें।
        // केवल PPT प्रेजेंटेशन में रिलेटिव पथ हो सकता है।
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="info" title="Note" %}}

इस अनुभाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for Java](https://docs.aspose.com/cells/java/) का उपयोग करता है।

{{% /alert %}}

यदि एक OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इस तरह आसानी से उस ऑब्जेक्ट को एक्सेस कर सकते हैं और उसके डेटा को संशोधित कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाली प्रेजेंटेशन लोड करें।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. OLE ऑब्जेक्ट फ्रेम शेप को एक्सेस करें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक ही शेप है। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) में *cast* किया। यह वह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया जाना था।
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।
5. `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा को एक्सेस करें।
6. इच्छित `Worksheet` को एक्सेस करें और डेटा में संशोधन करें।
7. अपडेटेड `Workbook` को एक स्ट्रीम में सेव करें।
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा बदलें।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) को एक्सेस किया गया है, और उसके फ़ाइल डेटा को चार्ट डेटा को अपडेट करने के लिए संशोधित किया गया है।

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE ऑब्जेक्ट डेटा को Workbook ऑब्जेक्ट के रूप में पढ़ें।
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // वर्कबुक डेटा को संशोधित करें।
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLE फ्रेम ऑब्जेक्ट डेटा बदलें।
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **स्लाइड्स में अन्य फ़ाइल प्रकार एम्बेड करें**

Excel चार्ट्स के अलावा, Aspose.Slides for Java आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के तौर पर, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर दो बार क्लिक करता है, तो यह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उचित प्रोग्राम चुनने के लिए प्रेरित किया जाता है।

यह Java कोड आपको दिखाता है कि कैसे HTML और ZIP को स्लाइड में एम्बेड करें:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए फ़ाइल प्रकार सेट करें**

प्रेजेंटेशन्स पर काम करते समय, आपको पुराने OLE ऑब्जेक्ट्स को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना पड़ सकता है। Aspose.Slides for Java आपको एक एम्बेडेड ऑब्जेक्ट के लिए फ़ाइल प्रकार सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसके एक्सटेंशन को अपडेट कर सकते हैं।

यह Java कोड आपको दिखाता है कि कैसे एम्बेडेड OLE ऑब्जेक्ट के फ़ाइल प्रकार को `zip` सेट करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// फ़ाइल प्रकार को ZIP में बदलें।
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज़ और टाइटल सेट करें**

OLE ऑब्जेक्ट को एम्बेड करने के बाद, एक आइकन इमेज़ से बनी प्रीव्यू स्वचालित रूप से जोड़ी जाती है। यह प्रीव्यू वह है जिसे उपयोगकर्ता OLE ऑब्जेक्ट को एक्सेस या खोलने से पहले देखते हैं। यदि आप प्रीव्यू में विशिष्ट इमेज़ और टेक्स्ट को तत्वों के रूप में उपयोग करना चाहते हैं, तो आप Aspose.Slides for Java का उपयोग करके आइकन इमेज़ और टाइटल सेट कर सकते हैं।

यह Java कोड आपको दिखाता है कि कैसे एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज़ और टाइटल सेट करें:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// प्रस्तुति संसाधनों में एक छवि जोड़ें।
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ्रेम को आकार बदलने और स्थान बदलने से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेजेंटेशन स्लाइड में जोड़ते हैं, और PowerPoint में प्रेजेंटेशन खोलते हैं, तो आपको लिंक अपडेट करने के लिए एक संदेश दिख सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को रिफ्रेश करता है। PowerPoint को ऑब्जेक्ट डेटा अपडेट करने के लिए प्रॉम्प्ट करने से रोकने के लिए, [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) इंटरफ़ेस की [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) मेथड को `false` के साथ कॉल करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for Java आपको इस प्रकार स्लाइड्स में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में निकालने की अनुमति देता है:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं जिसमें आप निकालने वाले OLE ऑब्जेक्ट्स शामिल हों।
2. प्रेजेंटेशन में सभी शेप्स पर लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) शेप्स को एक्सेस करें।
3. OLE ऑब्जेक्ट फ्रेम्स से एम्बेडेड फ़ाइलों का डेटा एक्सेस करें और उसे डिस्क पर लिखें।

यह Java कोड आपको दिखाता है कि कैसे एक स्लाइड में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में एक्सट्रैक्ट करें:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

**क्या स्लाइड्स को PDF/छवियों में एक्स्पोर्ट करने पर OLE सामग्री रेंडर होगी?**

स्लाइड पर दिखाई देने वाली चीज़ रेंडर की जाती है—आइकन/विकल्प इमेज (प्रीव्यू)। "लाइव" OLE सामग्री रेंडरिंग के दौरान निष्पादित नहीं होती। यदि आवश्यक हो, तो निर्यातित PDF में अपेक्षित दिखावट सुनिश्चित करने के लिए अपना स्वयं का प्रीव्यू इमेज सेट करें।  
एम्बेडेड फ़ाइल को PDF अटैचमेंट के रूप में भी संरक्षित करने के लिए, [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) को `true` के साथ कॉल करें। यह विकल्प डिफ़ॉल्ट रूप से निष्क्रिय है। उदाहरण और अटैचमेंट की जाँच के निर्देशों के लिए, देखें [Preserve Embedded OLE Files as PDF Attachments](/slides/hi/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)।

**मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक कर सकता हूँ ताकि उपयोगकर्ता इसे PowerPoint में नहीं ले जा सकें/संपादित न कर सकें?**

शेप को लॉक करें: Aspose.Slides [shape-level locks](/slides/hi/java/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह आकस्मिक संपादन और स्थानांतरित होने से प्रभावी रूप से रोकता है।

**जब मैं प्रेजेंटेशन खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट "जंप" क्यों करता है या आकार बदलता है?**

PowerPoint लिंक्ड OLE के प्रीव्यू को रीफ़्रेश कर सकता है। स्थिर दिखावट के लिए, [Working Solution for Worksheet Resizing](/slides/hi/java/working-solution-for-worksheet-resizing/) प्रैक्टिस का पालन करें—या तो फ्रेम को रेंज के अनुसार फिट करें, या रेंज को एक निश्चित फ्रेम में स्केल करें और उचित सब्स्टिट्यूट इमेज सेट करें।

**क्या PPTX फ़ॉर्मेट में लिंक्ड OLE ऑब्जेक्ट्स के लिए रिलेटिव पाथ्स संरक्षित रहेंगे?**

PPTX में, "relative path" जानकारी उपलब्ध नहीं है—केवल पूर्ण पथ मौजूद है। रिलेटिव पाथ्स पुराने PPT फ़ॉर्मेट में पाए जाते हैं। पोर्टेबिलिटी के लिए, विश्वसनीय एब्सोल्यूट पाथ्स/पहुंच योग्य URIs या एम्बेडिंग को प्राथमिकता दें।