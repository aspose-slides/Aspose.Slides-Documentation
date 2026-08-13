---
title: जावा का उपयोग करके प्रस्तुतियों में OLE प्रबंधित करें
linktitle: OLE प्रबंधित करें
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
- जुड़ा ऑब्जेक्ट
- जुड़ी फ़ाइल
- OLE बदलें
- OLE आइकन
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

{{% alert color="info" %}} 

OLE (ऑब्जेक्ट लिंकिंग और एम्बेडिंग) एक माइक्रोसॉफ्ट तकनीक है जो एक अनुप्रयोग में निर्मित डेटा और वस्तुओं को लिंकिंग या एम्बेडिंग के माध्यम से दूसरे अनुप्रयोग में रखने की अनुमति देती है। 

{{% /alert %}} 

मान लीजिए एक चार्ट MS Excel में बनाया गया है। फिर वह चार्ट PowerPoint स्लाइड के अंदर रखा जाता है। वह Excel चार्ट OLE ऑब्जेक्ट माना जाता है। 

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन पर डबल‑क्लिक करते हैं, तो चार्ट अपने संबद्ध अनुप्रयोग (Excel) में खुल जाता है, या आपसे ऑब्जेक्ट को खोलने या संपादित करने के लिए एक अनुप्रयोग चुनने को कहा जाता है। 
- एक OLE ऑब्जेक्ट अपनी वास्तविक सामग्री, जैसे कि चार्ट की सामग्री, भी दिखा सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट के डेटा को संशोधित कर सकते हैं। 

[Aspose.Slides for Java](https://products.aspose.com/slides/hi/java/) आपको OLE ऑब्जेक्ट्स को स्लाइड्स में OLE ऑब्जेक्ट फ्रेम्स के रूप में सम्मिलित करने देता है ([OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OleObjectFrame)).

## **स्लाइड्स में OLE ऑब्जेक्ट फ्रेम्स जोड़ें**

मान लीजिए आपने Microsoft Excel में पहले ही एक चार्ट बना लिया है और Aspose.Slides for Java का उपयोग करके इसे OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो आप इसे इस प्रकार कर सकते हैं:

1. यह [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स के द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।  
3. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।  
4. बाइट एरे और OLE ऑब्जेक्ट की अन्य जानकारी सहित [OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OleObjectFrame) को स्लाइड में जोड़ें।  
5. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

नीचे के उदाहरण में, हमने Aspose.Slides for Java का उपयोग करके Excel फ़ाइल से एक चार्ट को OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में जोड़ा है।  
**नोट** यह है कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OleEmbeddedDataInfo) कंस्ट्रक्टर दूसरे पैरामीटर के रूप में एंबेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से समझने और इस OLE ऑब्जेक्ट को खोलने के लिए सही अनुप्रयोग चुनने में मदद करता है।  

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE ऑब्जेक्ट के लिए डेटा तैयार करें।
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **जुड़े हुए OLE ऑब्जेक्ट फ्रेम्स जोड़ें**

Aspose.Slides for Java आपको डेटा को एम्बेड किए बिना केवल फ़ाइल लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OleObjectFrame) जोड़ने की अनुमति देता है।

यह Java कोड दिखाता है कि किस प्रकार एक जुड़ी हुई Excel फ़ाइल के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OleObjectFrame) को स्लाइड में जोड़ें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// एक जुड़े हुए Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ्रेम्स तक पहुँचें**

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इसे इस प्रकार आसानी से खोज या पहुँच सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाले प्रेजेंटेशन को लोड करें।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. [OleObjectFrame] आकार तक पहुँचें। हमारे उदाहरण में, हमने पहले निर्मित PPTX का उपयोग किया है जिसमें पहली स्लाइड पर केवल एक आकार है। फिर हमने उस ऑब्जेक्ट को *cast* करके [IOleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IOleObjectFrame) बनाया। यह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया गया।  
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुँच मिलने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा तक पहुँच प्राप्त की गई है।  

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

### **जुड़े हुए OLE ऑब्जेक्ट फ्रेम गुणों तक पहुँचें**

Aspose.Slides आपको जुड़े हुए OLE ऑब्जेक्ट फ्रेम के गुणों तक पहुँचने की अनुमति देता है।

यह Java कोड दिखाता है कि कैसे यह जांचें कि OLE ऑब्जेक्ट जुड़ा हुआ है और फिर जुड़े फ़ाइल का पाथ प्राप्त करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // जाँचें कि OLE ऑब्जेक्ट लिंक्ड है।
    if (oleFrame.isObjectLink()) {
        // लिंक्ड फ़ाइल का पूर्ण पाथ प्रिंट करें।
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // यदि मौजूद हो तो लिंक्ड फ़ाइल का सापेक्ष पाथ प्रिंट करें।
        // केवल PPT प्रस्तुतियों में सापेक्ष पाथ हो सकता है।
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="info" %}} 

इस अनुभाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for Java](/cells/java/) का उपयोग करता है।  

{{% /alert %}}

यदि कोई OLE ऑब्जेक्ट पहले से स्लाइड में एम्बेडेड है, तो आप इस प्रकार आसानी से उस ऑब्जेक्ट तक पहुँच कर उसका डेटा संशोधित कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाले प्रेजेंटेशन को लोड करें।  
2. इंडेक्स के द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।  
3. OLE ऑब्जेक्ट फ्रेम आकार तक पहुँचें। हमारे उदाहरण में, हमने पहले निर्मित PPTX का उपयोग किया है जिसमें पहली स्लाइड पर एक आकार है। फिर हमने उस ऑब्जेक्ट को *cast* करके [IOleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IOleObjectFrame) बनाया। यह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया गया।  
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुँच मिलने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  
5. `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा तक पहुँचें।  
6. वांछित `Worksheet` तक पहुँचें और डेटा को संशोधित करें।  
7. अपडेटेड `Workbook` को एक स्ट्रीम में सहेजें।  
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा बदलें।  

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) तक पहुँच प्राप्त की गई है, और उसकी फ़ाइल डेटा को बदलकर चार्ट डेटा को अपडेट किया गया है।  

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

    // OLE ऑब्जेक्ट डेटा को एक Workbook ऑब्जेक्ट के रूप में पढ़ें।
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Workbook डेटा को संशोधित करें।
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

Excel चार्ट के अलावा, Aspose.Slides for Java आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर डबल‑क्लिक करता है, तो वह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को खोलने के लिए उपयुक्त प्रोग्राम चुनने के लिए कहा जाता है।  

यह Java कोड दिखाता है कि कैसे HTML और ZIP को स्लाइड में एम्बेड करें:

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

प्रेजेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना पड़ सकता है। Aspose.Slides for Java आपको एम्बेडेड ऑब्जेक्ट के लिए फ़ाइल प्रकार सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसका एक्सटेंशन अपडेट कर सकते हैं।  

यह Java कोड दिखाता है कि कैसे एम्बेडेड OLE ऑब्जेक्ट के फ़ाइल प्रकार को `zip` सेट करें:

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

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज और शीर्षक सेट करें**

OLE ऑब्जेक्ट को एम्बेड करने के बाद, एक प्रीव्यू जो आयकन इमेज से बना होता है, स्वचालित रूप से जोड़ा जाता है। यह प्रीव्यू वह है जो उपयोगकर्ता OLE ऑब्जेक्ट तक पहुँचने या उसे खोलने से पहले देखते हैं। यदि आप प्रीव्यू में एक विशेष इमेज और टेक्स्ट को तत्वों के रूप में उपयोग करना चाहते हैं, तो आप Aspose.Slides for Java का उपयोग करके आयकन इमेज और शीर्षक सेट कर सकते हैं।  

यह Java कोड दिखाता है कि कैसे एम्बेडेड ऑब्जेक्ट के लिए आयकन इमेज और शीर्षक सेट करें:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// प्रस्तुति संसाधनों में एक इमेज जोड़ें।
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ्रेम को रिसाइज़ और पुनः स्थित होने से रोकें**

जब आप प्रस्तुति स्लाइड में एक जुड़ा हुआ OLE ऑब्जेक्ट जोड़ते हैं, और PowerPoint में प्रस्तुति खोलते हैं, तो आपको लिंक अपडेट करने के लिए संदेश दिखाई दे सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थान बदल सकता है क्योंकि PowerPoint जुड़ी हुई OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को रीफ़्रेश करता है। PowerPoint को ऑब्जेक्ट के डेटा को अपडेट करने के लिए प्रॉम्प्ट करने से रोकने के लिए, [IOleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ioleobjectframe/) इंटरफ़ेस की `setUpdateAutomatic` मेथड को `false` सेट करें:

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

1. वह [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं जिसमें आप निकालने वाले OLE ऑब्जेक्ट्स हों।  
2. प्रस्तुति में सभी आकारों पर लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/oleobjectframe) आकारों तक पहुँचें।  
3. OLE ऑब्जेक्ट फ्रेम से एम्बेडेड फ़ाइलों का डेटा प्राप्त करें और उसे डिस्क पर लिखें।  

यह Java कोड दिखाता है कि कैसे एक स्लाइड में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में निकालें:

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

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या स्लाइड्स को PDF/छवियों में एक्सपोर्ट करते समय OLE सामग्री रेंडर होगी?

स्लाइड पर जो दिखाई देता है, वह रेंडर होता है—आइकन/स्थायी इमेज (प्रीव्यू)। "लाइव" OLE सामग्री रेंडरिंग के दौरान निष्पादित नहीं होती। यदि आवश्यक हो, तो निर्यातित PDF में वांछित दिखावट सुनिश्चित करने के लिए अपनी स्वयं की प्रीव्यू इमेज सेट करें।

### मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक करूँ ताकि उपयोगकर्ता PowerPoint में उसे हिला या संपादित न कर सकें?

आकार को लॉक करें: Aspose.Slides [shape-level locks](/slides/hi/java/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह अनजाने संपादन और स्थान परिवर्तन को प्रभावी रूप से रोकता है।

### जब मैं प्रस्तुति खोलता हूँ तो जुड़ी हुई Excel ऑब्जेक्ट "जम्प" क्यों करता है या उसका आकार बदल जाता है?

PowerPoint जुड़ी हुई OLE का प्रीव्यू रीफ़्रेश कर सकता है। स्थिर दिखावट के लिए, [Worksheet Resizing के लिए कार्य समाधान](/slides/hi/java/working-solution-for-worksheet-resizing/) के अभ्यासों का पालन करें—या तो फ्रेम को रेंज के अनुसार फिट करें, या रेंज को एक निश्चित फ्रेम में स्केल करें और उपयुक्त स्थायी इमेज सेट करें।

### क्या PPTX फ़ॉर्मेट में जुड़ी हुई OLE ऑब्जेक्ट्स के सापेक्ष पाथ्स बरकरार रहेंगे?

PPTX में, "relative path" जानकारी उपलब्ध नहीं है—केवल पूर्ण पाथ। सापेक्ष पाथ्स पुराने PPT फ़ॉर्मेट में पाए जाते हैं। पोर्टेबिलिटी के लिए, विश्वसनीय पूर्ण पाथ/सुलभ URIs या एम्बेडिंग को प्राथमिकता दें।