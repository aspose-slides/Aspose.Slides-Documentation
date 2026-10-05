---
title: Android पर प्रस्तुतियों में OLE प्रबंधन करें
linktitle: OLE प्रबंधन करें
type: docs
weight: 40
url: /hi/androidjava/manage-ole/
keywords:
- OLE वस्तु
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
description: "Aspose.Slides for Android via Java के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) माइक्रोसॉफ्ट तकनीक है जो एक अनुप्रयोग में बनाए गए डेटा और वस्तुओं को लिंकिंग या एम्बेडिंग के माध्यम से दूसरे अनुप्रयोग में रखने की अनुमति देती है।
{{% /alert %}} 

MS Excel में बनाया गया एक चार्ट मानिए। फिर वह चार्ट PowerPoint स्लाइड के अंदर रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है। 

- OLE ऑब्जेक्ट एक आइकन के रूप में दिख सकता है। इस स्थिति में, जब आप आइकन पर डबल-क्लिक करते हैं, तो चार्ट अपने संबंधित अनुप्रयोग (Excel) में खुल जाता है, या आपसे पूछा जाता है कि ऑब्जेक्ट को खोलने या संपादित करने के लिए कौन सा अनुप्रयोग चुनना है।
- OLE ऑब्जेक्ट अपने वास्तविक सामग्री, जैसे कि एक चार्ट की सामग्री, दिखा सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट डेटा को संशोधित कर सकते हैं।

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) आपको OLE ऑब्जेक्ट्स को स्लाइड में OLE ऑब्जेक्ट फ्रेम के रूप में डालने की अनुमति देता है ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें**

मान लें कि आपने Microsoft Excel में पहले से ही एक चार्ट बना लिया है और इसे Aspose.Slides for Android via Java का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो आप इसे इस प्रकार कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
1. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।  
1. बाइट एरे और OLE ऑब्जेक्ट की अन्य जानकारी वाली स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) जोड़ें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

नीचे के उदाहरण में, हमने Excel फ़ाइल से एक चार्ट को Aspose.Slides for Android via Java का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में जोड़ा है।  
**नोट** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) कि निर्माता (constructor) दूसरा पैरामीटर के रूप में एक एंबेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से समझने और इस OLE ऑब्जेक्ट को खोलने के लिए उचित अनुप्रयोग चुनने में सक्षम बनाता है।

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम जोड़ें**

Aspose.Slides for Android via Java आपको [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) को डेटा एम्बेड किए बिना केवल फ़ाइल के लिंक के साथ जोड़ने की अनुमति देता है।  

यह Java कोड आपको दिखाता है कि कैसे एक लिंक्ड Excel फ़ाइल के साथ [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) को स्लाइड में जोड़ें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// एक लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ्रेम तक पहुँचें**

यदि एक OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेड किया गया है, तो आप इसे आसानी से इस प्रकार खोज या पहुँच सकते हैं:

1. एम्बेडेड OLE ऑब्जेक्ट वाली प्रस्तुति को [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाकर लोड करें।  
2. उसके इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) आकार तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक आकार (shape) है। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) के रूप में *cast* किया। यह वह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे पहुँचा जाना था।  
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुँचने के बाद, आप उस पर कोई भी ऑपरेशन कर सकते हैं।

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // एंबेडेड फ़ाइल डेटा प्राप्त करें।
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // एंबेडेड फ़ाइल का एक्सटेंशन प्राप्त करें।
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम गुणों तक पहुँचें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम गुणों तक पहुँचने की अनुमति देता है।  

यह Java कोड दिखाता है कि कैसे जांचें कि OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पाथ प्राप्त करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // जांचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
    if (oleFrame.isObjectLink()) {
        // लिंक्ड फ़ाइल का पूर्ण पाथ प्रिंट करें।
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेटिव पाथ प्रिंट करें।
        // केवल PPT प्रस्तुतियों में रिलेटिव पाथ हो सकता है।
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="info" title="Note" %}}
इस भाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/) का उपयोग करता है।
{{% /alert %}}

यदि एक OLE ऑब्जेक्ट पहले से स्लाइड में एम्बेड किया गया है, तो आप आसानी से उस ऑब्जेक्ट तक पहुँच सकते हैं और उसका डेटा इस प्रकार संशोधित कर सकते हैं:

1. एम्बेडेड OLE ऑब्जेक्ट वाली प्रस्तुति को [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाकर लोड करें।  
2. उसके इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. OLE ऑब्जेक्ट फ्रेम आकार तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक आकार है। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) के रूप में *cast* किया। यह वह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे पहुँचा जाना था।  
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुँचने के बाद, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  
5. एक `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा तक पहुँचें।  
6. इच्छित `Worksheet` तक पहुँचें और डेटा में संशोधन करें।  
7. अपडेट किए गए `Workbook` को एक स्ट्रीम में सहेजें।  
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा बदलें।  

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेड किया गया Excel चार्ट ऑब्जेक्ट) तक पहुंचा गया है, और उसके फ़ाइल डेटा को चार्ट डेटा अपडेट करने के लिए संशोधित किया गया है।

```java 
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

    // OLE फ्रेम ऑब्जेक्ट डेटा को बदलें।
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **स्लाइड में अन्य फ़ाइल प्रकार एम्बेड करें**

Excel चार्ट के अलावा, Aspose.Slides for Android via Java आपको स्लाइड में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में डाल सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर डबल-क्लिक करता है, तो यह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने के लिए प्रेरित किया जाता है।  

यह Java कोड दिखाता है कि कैसे HTML और ZIP को स्लाइड में एम्बेड करें:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

## **एम्बेडेड ऑब्जेक्ट्स के फ़ाइल प्रकार सेट करें**

प्रेजेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना पड़ सकता है। Aspose.Slides for Android via Java आपको एम्बेडेड ऑब्जेक्ट के फ़ाइल प्रकार को सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसके एक्सटेंशन को अपडेट कर सकते हैं।  

यह Java कोड दिखाता है कि कैसे एम्बेडेड OLE ऑब्जेक्ट के फ़ाइल प्रकार को `zip` पर सेट करें:

```java
import com.aspose.slides.*;

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

OLE ऑब्जेक्ट को एम्बेड करने के बाद, एक प्रीव्यू जो आइकन इमेज से बना होता है, स्वचालित रूप से जोड़ दिया जाता है। यह प्रीव्यू वह है जो उपयोगकर्ता OLE ऑब्जेक्ट तक पहुँचने या उसे खोलने से पहले देखते हैं। यदि आप प्रीव्यू में एक विशिष्ट इमेज और टेक्स्ट तत्व के रूप में उपयोग करना चाहते हैं, तो आप Aspose.Slides for Android via Java का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।  

यह Java कोड दिखाता है कि कैसे एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट करें:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// प्रस्तुति संसाधनों में एक चित्र जोड़ें।
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ्रेम को आकार बदलने और पुनःस्थित करने से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेजेंटेशन स्लाइड में जोड़ते हैं और PowerPoint में प्रेजेंटेशन खोलते हैं, तो आपको लिंक अपडेट करने के लिए एक संदेश दिख सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को रिफ्रेश करता है। PowerPoint को ऑब्जेक्ट डेटा अपडेट करने के लिए प्रॉम्प्ट करने से रोकने के लिए, [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) इंटरफ़ेस की [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) मेथड को `false` के साथ कॉल करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for Android via Java आपको स्लाइड में OLE ऑब्जेक्ट्स के रूप में एम्बेडेड फ़ाइलों को इस प्रकार निकालने की अनुमति देता है:

1. उस [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं जिसमें आप निकालने वाले OLE ऑब्जेक्ट्स हों।  
2. प्रस्तुति में सभी शैप्स के माध्यम से लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) शैप्स तक पहुँचें।  
3. OLE ऑब्जेक्ट फ्रेम्स से एम्बेडेड फ़ाइलों का डेटा एक्सेस करें और उसे डिस्क पर लिखें।  

यह Java कोड दिखाता है कि कैसे स्लाइड में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में एक्सट्रैक्ट करें:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

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

**क्या स्लाइड को PDF/छवियों में एक्सपोर्ट करने पर OLE सामग्री रेंडर होगी?**  
स्लाइड पर जो दिखाई देता है वह रेंडर किया जाता है—आइकन/स्थानीय इमेज (प्रीव्यू)। "लाइव" OLE सामग्री रेंडरिंग के दौरान निष्पादित नहीं होती। यदि आवश्यक हो, तो निर्यातित PDF में अपेक्षित रूप सुनिश्चित करने के लिए अपना स्वयं का प्रीव्यू इमेज सेट करें।  

एम्बेडेड फ़ाइल को PDF अटैचमेंट के रूप में भी संरक्षित करने के लिए, [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) को `true` के साथ कॉल करें। यह विकल्प डिफ़ॉल्ट रूप से निष्क्रिय है। उदाहरण और अटैचमेंट की जांच के निर्देशों के लिए देखें [Preserve Embedded OLE Files as PDF Attachments](/slides/hi/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).  

**मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक करूँ कि उपयोगकर्ता PowerPoint में इसे नहीं ले जाएँ/संपादित न कर सकें?**  
शेप को लॉक करें: Aspose.Slides शैप-स्तर पर लॉक प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह आकस्मिक संपादन और मूवमेंट को प्रभावी रूप से रोकता है।  

**जब मैं प्रस्तुति खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट "जंप" क्यों करता है या आकार बदलता है?**  
PowerPoint लिंक्ड OLE का प्रीव्यू रिफ्रेश कर सकता है। स्थिर दिखावट के लिए, [Working Solution for Worksheet Resizing](/slides/hi/androidjava/working-solution-for-worksheet-resizing/) प्रैक्टिसेस का पालन करें—या तो फ्रेम को रेंज के अनुरूप फिट करें, या रेंज को स्थिर फ्रेम में स्केल करें और उपयुक्त प्रतिस्थापन इमेज सेट करें।  

**क्या PPTX फ़ॉर्मेट में लिंक्ड OLE ऑब्जेक्ट्स के रिलेटिव पाथ्स संरक्षित रहेंगे?**  
PPTX में "relative path" जानकारी उपलब्ध नहीं है—केवल पूर्ण पाथ। रिलेटिव पाथ्स पुराने PPT फ़ॉर्मेट में मिलते हैं। पोर्टेबलिटी के लिए, विश्वसनीय पूर्ण पाथ/पहुंच योग्य URIs या एम्बेडिंग को प्राथमिकता दें।