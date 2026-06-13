---
title: Android पर प्रस्तुतियों में OLE को प्रबंधित करें
linktitle: OLE प्रबंधित करें
type: docs
weight: 40
url: /hi/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और एक्सपोर्ट करें।"
---
## **परिचय**

{{% alert color="primary" %}} 
OLE (ऑब्जेक्ट लिंकिंग और एम्बेडिंग) एक Microsoft तकनीक है जो एक एप्लिकेशन में निर्मित डेटा और ऑब्जेक्ट्स को लिंकिंग या एम्बेडिंग के माध्यम से दूसरे एप्लिकेशन में रखने की अनुमति देती है। 
{{% /alert %}} 

MS Excel में बनाए गए चार्ट को देखें। फिर वह चार्ट PowerPoint स्लाइड में रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है। 

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन पर डबल-क्लिक करते हैं, तो चार्ट अपने संबद्ध एप्लिकेशन (Excel) में खुल जाता है, या आपको ऑब्जेक्ट खोलने या संपादित करने के लिए एक एप्लिकेशन चुनने के लिए कहा जाता है। 
- एक OLE ऑब्जेक्ट अपनी वास्तविक सामग्री, जैसे कि चार्ट की सामग्री, प्रदर्शित कर सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट के डेटा को संशोधित कर सकते हैं। 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/hi/androidjava/) आपको OLE ऑब्जेक्ट्स को स्लाइड्स में OLE ऑब्जेक्ट फ्रेम्स ([OleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/OleObjectFrame)) के रूप में सम्मिलित करने की अनुमति देता है।

## **स्लाइड्स में OLE ऑब्जेक्ट फ्रेम्स जोड़ें**

मान लेते हैं कि आपने Microsoft Excel में पहले ही एक चार्ट बना लिया है और आप इसे Aspose.Slides for Android via Java का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो आप इसे इस प्रकार कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।  
4. स्लाइड में बाइट एरे और OLE ऑब्जेक्ट की अन्य जानकारी के साथ [OleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/OleObjectFrame) जोड़ें।  
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

नीचे दिए गए उदाहरण में, हमने Aspose.Slides for Android via Java का उपयोग करके Excel फ़ाइल से एक चार्ट को स्लाइड में OLE ऑब्जेक्ट फ्रेम के रूप में जोड़ा है।  
**ध्यान दें** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/OleEmbeddedDataInfo) कंस्ट्रक्टर दूसरा पैरामीटर के रूप में एम्बेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से व्याख्यायित करने और इस OLE ऑब्जेक्ट को खोलने के लिए उचित एप्लिकेशन चुनने में मदद करता है।  

```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE ऑब्जेक्ट के लिए डेटा तैयार करें।
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम्स जोड़ें**

Aspose.Slides for Android via Java आपको डेटा एम्बेड किए बिना, केवल फ़ाइल के लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/OleObjectFrame) जोड़ने की अनुमति देता है।  

यह Java कोड आपको दिखाता है कि कैसे एक [OleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/OleObjectFrame) लिंक्ड Excel फ़ाइल के साथ स्लाइड में जोड़ा जाए:  

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// लिंक्ड Excel फ़ाइल के साथ एक OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ्रेम्स तक पहुँचें**

यदि एक OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इसे इस तरीके से आसानी से खोज या एक्सेस कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाली प्रस्तुति लोड करें।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. [OleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/OleObjectFrame) आकार तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाई गई PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक आकार है। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioleobjectframe/) के रूप में *cast* किया। यह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस करना था।  
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा तक पहुँच प्राप्त की गई है।  

```java 
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

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम गुणों तक पहुँचें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम गुणों तक पहुँचने की अनुमति देता है।  

यह Java कोड दिखाता है कि कैसे जांचा जाए कि OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पथ प्राप्त किया जाए:  

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // जाँचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
    if (oleFrame.isObjectLink()) {
        // लिंक्ड फ़ाइल का पूर्ण पथ प्रिंट करें।
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेटिव पथ प्रिंट करें।
        // सिर्फ PPT प्रस्तुतियों में रिलेटिव पथ हो सकता है।
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="primary" %}} 
इस सेक्शन में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for Android via Java](/cells/androidjava/) का उपयोग करता है।  
{{% /alert %}}  

यदि एक OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इस तरह आसानी से उस ऑब्जेक्ट तक पहुँच सकते हैं और उसका डेटा संशोधित कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाली प्रस्तुति लोड करें।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. OLE ऑब्जेक्ट फ्रेम आकार तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाई गई PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक आकार है। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioleobjectframe/) के रूप में *cast* किया। यह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया गया।  
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  
5. एक `Workbook` ऑब्जेक्ट बनाकर OLE डेटा तक पहुँचें।  
6. इच्छित `Worksheet` तक पहुँचें और डेटा में संशोधन करें।  
7. अपडेटेड `Workbook` को एक स्ट्रीम में सहेजें।  
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा बदलें।  

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) तक पहुँच प्राप्त की गई है, और उसकी फ़ाइल डेटा को चार्ट डेटा को अपडेट करने के लिए संशोधित किया गया है।  

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE ऑब्जेक्ट डेटा को Workbook ऑब्जेक्ट के रूप में पढ़ें।
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

Excel चार्ट्स के अलावा, Aspose.Slides for Android via Java आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर डबल-क्लिक करता है, तो यह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने के लिए प्रेरित किया जाता है।  

यह Java कोड दिखाता है कि कैसे HTML और ZIP को स्लाइड में एम्बेड किया जाए:  

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए फ़ाइल प्रकार सेट करें**

प्रस्तुति पर काम करते समय, आपको पुराने OLE ऑब्जेक्ट को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना पड़ सकता है। Aspose.Slides for Android via Java आपको एम्बेडेड ऑब्जेक्ट के फ़ाइल प्रकार को सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसके एक्सटेंशन को अपडेट कर सकते हैं।  

यह Java कोड दिखाता है कि कैसे एम्बेडेड OLE ऑब्जेक्ट के फ़ाइल प्रकार को `zip` सेट किया जाए:  

```java
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

OLE ऑब्जेक्ट को एम्बेड करने के बाद, एक आइकन इमेज से बनी प्रीव्यू स्वचालित रूप से जुड़ जाती है। यह प्रीव्यू वह है जो उपयोगकर्ता OLE ऑब्जेक्ट तक पहुँचने या खोलने से पहले देखते हैं। यदि आप प्रीव्यू में विशिष्ट इमेज और टेक्स्ट को तत्वों के रूप में उपयोग करना चाहते हैं, तो आप Aspose.Slides for Android via Java का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।  

यह Java कोड दिखाता है कि कैसे एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट किया जाए:  

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// प्रस्तुति संसाधनों में एक छवि जोड़ें।
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// OLE प्रीव्यू के लिए शीर्षक और छवि सेट करें।
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ्रेम को आकार बदलने और पुन:स्थित करने से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रस्तुति स्लाइड में जोड़ते हैं और PowerPoint में प्रस्तुति खोलते हैं, तो आपको लिंक अपडेट करने के संदेश दिख सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को ताज़ा करता है। PowerPoint को ऑब्जेक्ट के डेटा को अपडेट करने के संकेत से रोकने के लिए, [IOleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioleobjectframe/) इंटरफ़ेस की `setUpdateAutomatic` मेथड को `false` सेट करें:  

```java
oleFrame.setUpdateAutomatic(false);
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for Android via Java आपको इस प्रकार स्लाइड्स में OLE ऑब्जेक्ट के रूप में एम्बेडेड फ़ाइलें निकालने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ जिसमें वे OLE ऑब्जेक्ट हों जिनको आप निकालना चाहते हैं।  
2. प्रस्तुति में सभी आकारों पर लूप चलाएँ और [OLEObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/oleobjectframe) आकारों तक पहुँचें।  
3. OLE ऑब्जेक्ट फ्रेम्स से एम्बेडेड फ़ाइलों का डेटा एक्सेस करें और उसे डिस्क पर लिखें।  

यह Java कोड दिखाता है कि कैसे स्लाइड में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट के रूप में निकाला जाए:  

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्लाइड्स को PDF/इमेज में एक्सपोर्ट करने पर OLE सामग्री रेंडर होगी?**  
स्लाइड पर जो दिखता है, वह रेंडर किया जाता है—आइकन/विकल्प इमेज (प्रीव्यू)। "लाइव" OLE सामग्री रेंडरिंग के दौरान निष्पादित नहीं होती। यदि आवश्यक हो, तो इच्छित प्रीव्यू इमेज सेट करें ताकि निर्यात किए गए PDF में अपेक्षित रूप दिखे।  

**मैं कैसे एक OLE ऑब्जेक्ट को स्लाइड पर लॉक कर सकता हूँ ताकि उपयोगकर्ता PowerPoint में इसे हिला या संपादित न कर सकें?**  
आकार को लॉक करें: Aspose.Slides आकार-स्तर के लॉक प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह आकस्मिक संपादन और गति को प्रभावी रूप से रोकता है।  

**जब मैं प्रस्तुति खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट "जंप" क्यों करता है या आकार बदलता है?**  
PowerPoint लिंक्ड OLE का प्रीव्यू रीफ़्रेश कर सकता है। स्थिर दिखावट के लिए, [Worksheet Resizing के लिए कार्य समाधान](/slides/hi/androidjava/working-solution-for-worksheet-resizing/) के अभ्यासों को अपनाएँ—या तो फ्रेम को रेंज के अनुसार फिट करें, या रेंज को स्थायी फ्रेम में स्केल करें और उपयुक्त विकल्प इमेज सेट करें।  

**क्या लिंक्ड OLE ऑब्जेक्ट्स के रिलेटिव पाथ PPTX फॉर्मेट में संरक्षित रहेंगे?**  
PPTX में, "relative path" जानकारी उपलब्ध नहीं है—सिर्फ पूर्ण पथ होता है। रिलेटिव पाथ पुराने PPT फॉर्मेट में मिलते हैं। पोर्टेबिलिटी के लिए, विश्वसनीय पूर्ण पथ/उपलब्ध URIs या एम्बेडिंग को प्राथमिकता दें।