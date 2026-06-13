---
title: Java का उपयोग करके प्रस्तुतियों में OLE प्रबंधित करें
linktitle: OLE प्रबंधन
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
- OLE आइकन
- OLE शीर्षक
- OLE निकालें
- ऑब्जेक्ट निकालें
- फ़ाइल निकालें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और एक्सपोर्ट करें।"
---
## **परिचय**

{{% alert color="primary" %}} 
OLE (ऑब्जेक्ट लिंकिंग & एम्बेडिंग) एक माइक्रोसॉफ्ट तकनीक है जो एक एप्लिकेशन में निर्मित डेटा और ऑब्जेक्ट्स को लिंकिंग या एम्बेडिंग के माध्यम से दूसरे एप्लिकेशन में रखने की अनुमति देती है। 
{{% /alert %}} 

एक चार्ट पर विचार करें जो MS Excel में बनाया गया है। यह चार्ट फिर PowerPoint स्लाइड में रखा जाता है। वह Excel चार्ट OLE ऑब्जेक्ट माना जाता है। 

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन पर डबल‑क्लिक करते हैं, तो चार्ट अपनी संबंधित एप्लिकेशन (Excel) में खुल जाता है, या आपको ऑब्जेक्ट खोलने या संपादित करने के लिए एक एप्लिकेशन चुनने के लिए कहा जाता है। 
- एक OLE ऑब्जेक्ट अपना वास्तविक सामग्री, जैसे कि चार्ट की सामग्री, प्रदर्शित कर सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट के डेटा को संशोधित कर सकते हैं। 

[Aspose.Slides for Java](https://products.aspose.com/slides/hi/java/) आपको स्लाइड्स में OLE ऑब्जेक्ट्स को OLE ऑब्जेक्ट फ़्रेम ([OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OleObjectFrame)) के रूप में सम्मिलित करने की अनुमति देता है। 

## **स्लाइड्स में OLE ऑब्जेक्ट फ़्रेम जोड़ें**

मान लीजिए आपने Microsoft Excel में एक चार्ट बनाया है और उसे Aspose.Slides for Java का उपयोग करके स्लाइड में OLE ऑब्जेक्ट फ़्रेम के रूप में एम्बेड करना चाहते हैं, आप इसे इस प्रकार कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की एक instance बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
1. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।  
1. बाइट एरे और OLE ऑब्जेक्ट के बारे में अन्य जानकारी के साथ स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OleObjectFrame) जोड़ें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

नीचे दिए गए उदाहरण में, हमने Excel फ़ाइल से एक चार्ट को Aspose.Slides for Java का उपयोग करके OLE ऑब्जेक्ट फ़्रेम के रूप में स्लाइड में जोड़ा है।  
**Note** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OleEmbeddedDataInfo) कंस्ट्रक्टर दूसरे पैरामीटर के रूप में एक एम्बेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से समझने और इस OLE ऑब्जेक्ट को खोलने के लिए सही एप्लिकेशन चुनने में मदद करता है।  

``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE ऑब्जेक्ट के लिए डेटा तैयार करें।
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// स्लाइड में OLE ऑब्जेक्ट फ़्रेम जोड़ें।
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Linked OLE ऑब्जेक्ट फ़्रेम जोड़ें**

Aspose.Slides for Java आपको डेटा एम्बेड किए बिना केवल फ़ाइल लिंक के साथ [OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OleObjectFrame) जोड़ने की सुविधा देता है।  

यह Java कोड दिखाता है कि कैसे आप लिंक्ड Excel फ़ाइल के साथ [OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OleObjectFrame) को स्लाइड में जोड़ सकते हैं:  

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ़्रेम जोड़ें।
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ़्रेम तक पहुँचें**

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेड किया गया है, तो आप इसे इस प्रकार आसानी से खोज या एक्सेस कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की instance बनाकर एम्बेडेड OLE ऑब्जेक्ट के साथ प्रस्तुति लोड करें।  
2. उसके इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. [OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OleObjectFrame) शेप तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक ही शैप था। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IOleObjectFrame) के रूप में *cast* किया। यही वांछित OLE ऑब्जेक्ट फ़्रेम था जिसे एक्सेस करने की आवश्यकता थी।  
4. एक बार OLE ऑब्जेक्ट फ़्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ़्रेम (स्लाइड में एम्बेड किया गया Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा को एक्सेस किया गया है।  

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // एम्बेडेड फ़ाइल डेटा प्राप्त करें।
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // एम्बेडेड फ़ाइल का विस्तार प्राप्त करें।
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Linked OLE ऑब्जेक्ट फ़्रेम प्रॉपर्टीज़ तक पहुँचें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ़्रेम की प्रॉपर्टीज़ तक पहुँचने की सुविधा देता है।  

यह Java कोड दिखाता है कि कैसे आप जांच सकते हैं कि OLE ऑब्जेक्ट लिंक्ड है या नहीं और फिर लिंक्ड फ़ाइल का पाथ प्राप्त कर सकते हैं:  

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // OLE ऑब्जेक्ट लिंक्ड है या नहीं जांचें।
    if (oleFrame.isObjectLink()) {
        // लिंक्ड फ़ाइल का पूरा पाथ प्रिंट करें।
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेटिव पाथ प्रिंट करें।
        // केवल PPT प्रेजेंटेशन में रिलेटिव पाथ हो सकता है।
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="primary" %}} 
इस अनुभाग में नीचे दिया गया कोड उदाहरण [Aspose.Cells for Java](/cells/java/) का उपयोग करता है। 
{{% /alert %}} 

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेड किया गया है, तो आप उस ऑब्जेक्ट तक आसानी से पहुँच सकते हैं और उसके डेटा को इस प्रकार संशोधित कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की instance बनाकर एम्बेडेड OLE ऑब्जेक्ट के साथ प्रस्तुति लोड करें।  
2. उसके इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. OLE ऑब्जेक्ट फ़्रेम शेप तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक शैप था। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IOleObjectFrame) के रूप में *cast* किया। यही वांछित OLE ऑब्जेक्ट फ़्रेम था जिसे एक्सेस करने की आवश्यकता थी।  
4. एक बार OLE ऑब्जेक्ट फ़्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  
5. एक `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा तक पहुँचें।  
6. इच्छित `Worksheet` तक पहुँचें और डेटा को संशोधित करें।  
7. अपडेटेड `Workbook` को स्ट्रीम में सहेजें।  
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा को बदलें।  

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ़्रेम (स्लाइड में एम्बेड किया गया Excel चार्ट ऑब्जेक्ट) को एक्सेस किया गया है, और उसकी फ़ाइल डेटा को संशोधित करके चार्ट डेटा को अपडेट किया गया है।  

``` java 
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

    // OLE फ़्रेम ऑब्जेक्ट डेटा बदलें।
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **स्लाइड्स में अन्य फ़ाइल प्रकार एम्बेड करें**

Excel चार्ट के अलावा, Aspose.Slides for Java आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर डबल‑क्लिक करता है, तो वह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने के लिए प्रेरित किया जाता है।  

यह Java कोड दिखाता है कि कैसे आप HTML और ZIP को स्लाइड में एम्बेड कर सकते हैं:  

```java
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

प्रेजेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट को नए से बदलने या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलने की आवश्यकता हो सकती है। Aspose.Slides for Java आपको एम्बेडेड ऑब्जेक्ट के फ़ाइल प्रकार को सेट करने की अनुमति देता है, जिससे आप OLE फ़्रेम डेटा या उसकी एक्सटेंशन को अपडेट कर सकते हैं।  

यह Java कोड दिखाता है कि कैसे आप एम्बेडेड OLE ऑब्जेक्ट का फ़ाइल प्रकार `zip` पर सेट कर सकते हैं:  

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज और शीर्षक सेट करें**

एक OLE ऑब्जेक्ट को एम्बेड करने के बाद, एक प्रीव्यू जिसमें आइकन इमेज शामिल होती है, स्वचालित रूप से जोड़ी जाती है। यह प्रीव्यू वह है जो उपयोगकर्ता OLE ऑब्जेक्ट तक पहुँचने या उसे खोलने से पहले देखते हैं। यदि आप प्रीव्यू में विशिष्ट इमेज और टेक्स्ट का उपयोग करना चाहते हैं, तो आप Aspose.Slides for Java का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।  

यह Java कोड दिखाता है कि कैसे आप एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट कर सकते हैं:  

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// प्रस्तुति संसाधनों में एक इमेज जोड़ें।
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// OLE प्रीव्यू के लिए शीर्षक और इमेज सेट करें।
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ़्रेम के आकार और स्थिति बदलने से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेजेंटेशन स्लाइड में जोड़ते हैं, तो PowerPoint में प्रस्तुति खोलने पर आप एक संदेश देख सकते हैं जिसमें लिंक अपडेट करने के लिए कहा जाता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ़्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को रीफ़्रेश करता है। PowerPoint को ऑब्जेक्ट डेटा अपडेट करने के लिए प्रेरित होने से रोकने हेतु, [IOleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ioleobjectframe/) इंटरफ़ेस की `setUpdateAutomatic` मेथड को `false` पर सेट करें:  

```java
oleFrame.setUpdateAutomatic(false);
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for Java आपको स्लाइड्स में OLE ऑब्जेक्ट के रूप में एम्बेडेड फ़ाइलें इस प्रकार निकालने की सुविधा देता है:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की एक instance बनाएं जिसमें उन OLE ऑब्जेक्ट्स को शामिल किया गया हो जिन्हें आप निकालना चाहते हैं।  
2. प्रस्तुति में सभी शैप्स के माध्यम से लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/oleobjectframe) शैप्स तक पहुँचें।  
3. OLEObjectFrame से एम्बेडेड फ़ाइलों का डेटा एक्सेस करें और उसे डिस्क पर लिखें।  

यह Java कोड दिखाता है कि कैसे आप एक स्लाइड में OLE ऑब्जेक्ट के रूप में एम्बेडेड फ़ाइलें निकाल सकते हैं:  

```java
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

**क्या स्लाइड्स को PDF/इमेज में एक्सपोर्ट करते समय OLE कंटेंट रेंडर होगा?**  
स्लाइड पर जो दिखता है वह रेंडर होता है — आइकन/सब्स्टीट्यूट इमेज (प्रीव्यू)। "लाइव" OLE कंटेंट रेंडरिंग के दौरान निष्पादित नहीं होता। यदि आवश्यक हो, तो निर्यातित PDF में अपेक्षित दिखावट सुनिश्चित करने के लिए अपना स्वयं का प्रीव्यू इमेज सेट करें।  

**मैं कैसे OLE ऑब्जेक्ट को स्लाइड पर लॉक करूँ ताकि उपयोगकर्ता PowerPoint में उसे हलचल/संपादन न कर सकें?**  
शेप को लॉक करें: Aspose.Slides [shape-level locks](/slides/hi/java/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन आकस्मिक संपादन और मूवमेंट को प्रभावी रूप से रोकता है।  

**जब मैं प्रेजेंटेशन खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट "जम्प" करता है या आकार बदलता है, क्यों?**  
PowerPoint लिंक्ड OLE का प्रीव्यू रीफ़्रेश कर सकता है। स्थिर दिखावट के लिए [Worksheet Resizing समाधान](/slides/hi/java/working-solution-for-worksheet-resizing/) का पालन करें — या तो फ़्रेम को रेंज के अनुसार फिट करें, या रेंज को स्थिर फ़्रेम में स्केल करें और उपयुक्त सब्स्टीट्यूट इमेज सेट करें।  

**क्या PPTX फॉर्मेट में लिंक्ड OLE ऑब्जेक्ट के रिलेटिव पाथ संरक्षित रहते हैं?**  
PPTX में "रिलेटिव पाथ" जानकारी उपलब्ध नहीं होती — सिर्फ पूर्ण पाथ रहता है। रिलेटिव पाथ पुराने PPT फॉर्मेट में पाए जाते हैं। पोर्टेबिलिटी के लिए विश्वसनीय एब्सोल्यूट पाथ/एक्सेसेबिल URI या एम्बेडिंग को प्राथमिकता दें।  