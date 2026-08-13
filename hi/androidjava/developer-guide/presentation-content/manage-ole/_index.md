---
title: Android पर प्रस्तुतियों में OLE प्रबंधन
linktitle: OLE प्रबंधन
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

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) एक Microsoft तकनीक है जो एक एप्लिकेशन में बनाये गये डेटा और ऑब्जेक्ट्स को लिंकिंग या एम्बेडिंग के द्वारा दूसरे एप्लिकेशन में रखती है। 

{{% /alert %}} 

MS Excel में बनाए गए चार्ट पर विचार करें। वह चार्ट फिर एक PowerPoint स्लाइड के अंदर रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है। 

- एक OLE ऑब्जेक्ट एक आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन पर डबल‑क्लिक करते हैं, तो चार्ट अपने संबद्ध एप्लिकेशन (Excel) में खुल जाता है, या आपको ऑब्जेक्ट खोलने या संपादित करने के लिए एप्लिकेशन चुनने के लिए कहा जाता है। 
- एक OLE ऑब्जेक्ट अपनी वास्तविक सामग्री, जैसे कि चार्ट की सामग्री, प्रदर्शित कर सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट के डेटा को संशोधित कर सकते हैं। 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/hi/androidjava/) आपको OLE ऑब्जेक्ट को स्लाइड्स में OLE ऑब्जेक्ट फ्रेम ([OleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/OleObjectFrame)) के रूप में सम्मिलित करने की अनुमति देता है।

## **स्लाइड्स में OLE ऑब्जेक्ट फ्रेम जोड़ें**

मान लेते हैं कि आपने पहले ही Microsoft Excel में एक चार्ट बना लिया है और आप इसे Aspose.Slides for Android via Java का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, आप इसे इस तरह कर सकते हैं:

1. एक [Presentation] क्लास का एक उदाहरण बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।
3. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।
4. [OleObjectFrame] को स्लाइड में जोड़ें, जिसमें बाइट एरे और OLE ऑब्जेक्ट के बारे में अन्य जानकारी हो।
5. परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने Aspose.Slides for Android via Java का उपयोग करके Excel फ़ाइल से एक चार्ट को OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में जोड़ा है। **ध्यान दें** कि [OleEmbeddedDataInfo] कन्स्ट्रक्टर दूसरा पैरामीटर के रूप में एम्बेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से समझने और इस OLE ऑब्जेक्ट को खोलने के लिए सही एप्लिकेशन चुनने में सक्षम बनाता है।

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

// OLE ऑब्जेक्ट के लिए डेटा तैयार करें।
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम जोड़ें**

Aspose.Slides for Android via Java आपको डेटा एम्बेड किए बिना, केवल फ़ाइल के लिंक के साथ एक [OleObjectFrame] जोड़ने की अनुमति देता है।

यह Java कोड आपको दिखाता है कि कैसे एक लिंक्ड Excel फ़ाइल के साथ एक [OleObjectFrame] को स्लाइड में जोड़ा जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ्रेम तक पहुंचें**

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इसे इस तरह आसानी से खोज या एक्सेस कर सकते हैं:

1. एक [Presentation] क्लास का एक उदाहरण बनाकर एम्बेडेड OLE ऑब्जेक्ट वाली प्रेजेंटेशन लोड करें।
2. इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. [OleObjectFrame] शेप तक पहुंचें। हमारे उदाहरण में, हमने पहले बनाई गई PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक ही शेप है। फिर हमने उस ऑब्जेक्ट को एक [IOleObjectFrame] के रूप में *cast* किया। यह वह इच्छित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया जाना था।
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुंचने के बाद, आप उस पर कोई भी ऑपरेशन कर सकते हैं।

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा तक पहुंचा गया है।

```java 
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

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम गुणों तक पहुंचें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम के गुणों तक पहुंचने की अनुमति देता है।

यह Java कोड दिखाता है कि कैसे यह जांचा जाए कि कोई OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पथ प्राप्त किया जाए:

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
        // केवल PPT प्रेजेंटेशन में रिलेटिव पाथ हो सकता है।
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="info" %}} 

इस अनुभाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for Android via Java](/cells/androidjava/) का उपयोग करता है।

{{% /alert %}}

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इस तरह उस ऑब्जेक्ट को आसानी से एक्सेस करके उसका डेटा संशोधित कर सकते हैं:

1. एक [Presentation] क्लास का उदाहरण बनाकर एम्बेडेड OLE ऑब्जेक्ट वाली प्रेजेंटेशन लोड करें।
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।
3. [OleObjectFrame] शेप तक पहुंचें। हमारे उदाहरण में, हमने पहले बनाई गई PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक ही शेप है। फिर हमने उस ऑब्जेक्ट को एक [IOleObjectFrame] के रूप में *cast* किया। यह इच्छित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया जाना था।
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुंचने के बाद, आप उस पर कोई भी ऑपरेशन कर सकते हैं।
5. `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा एक्सेस करें।
6. इच्छित `Worksheet` तक पहुंचें और डेटा में परिवर्तन करें।
7. अपडेटेड `Workbook` को स्ट्रीम में सहेजें।
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा बदलें।

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) को एक्सेस किया गया है, और उसकी फ़ाइल डेटा को संशोधित करके चार्ट डेटा को अद्यतन किया गया है।

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

Excel चार्ट्स के अलावा, Aspose.Slides for Android via Java आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर डबल‑क्लिक करता है, तो वह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने के लिए कहा जाता है।

यह Java कोड आपको दिखाता है कि कैसे HTML और ZIP को एक स्लाइड में एम्बेड किया जाए:

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

जब प्रेजेंटेशन के साथ काम किया जाता है, तो आपको पुराने OLE ऑब्जेक्ट को नए से बदलना या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना पड़ सकता है। Aspose.Slides for Android via Java आपको एम्बेडेड ऑब्जेक्ट के फ़ाइल प्रकार को सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसकी एक्सटेंशन को अपडेट कर सकते हैं।

यह Java कोड दिखाता है कि कैसे एम्बेडेड OLE ऑब्जेक्ट के फ़ाइल प्रकार को `zip` सेट किया जाए:

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

एक OLE ऑब्जेक्ट को एम्बेड करने के बाद, एक प्रीव्यू जो आइकन इमेज से बना होता है, स्वचालित रूप से जोड़ा जाता है। यह प्रीव्यू वह है जो उपयोगकर्ता OLE ऑब्जेक्ट तक पहुंचने या खोलने से पहले देखते हैं। यदि आप प्रीव्यू में एक विशिष्ट इमेज और टेक्स्ट को तत्वों के रूप में उपयोग करना चाहते हैं, तो आप Aspose.Slides for Android via Java का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह Java कोड दिखाता है कि कैसे एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट किया जाए:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ्रेम को री-साइज़ और री-पोजिशन से बचाएं**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेजेंटेशन स्लाइड में जोड़ते हैं और PowerPoint में प्रेजेंटेशन खोलते हैं, तो आपको लिंक अपडेट करने का संदेश दिख सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और प्रीव्यू को रीफ़्रेश करता है। PowerPoint को ऑब्जेक्ट डेटा अपडेट करने के संकेत से बचाने के लिए, [IOleObjectFrame] इंटरफ़ेस की `setUpdateAutomatic` मेथड को `false` सेट करें:

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

Aspose.Slides for Android via Java आपको स्लाइड्स में OLE ऑब्जेक्ट के रूप में एम्बेडेड फ़ाइलों को इस प्रकार निकालने की अनुमति देता है:

1. [Presentation] क्लास का एक उदाहरण बनाएं जिसमें वह OLE ऑब्जेक्ट्स हों जिन्हें आप निकालना चाहते हैं।
2. प्रेजेंटेशन में सभी शेप्स के माध्यम से लूप करें और [OLEObjectFrame] शेप्स तक पहुंचें।
3. OLE ऑब्जेक्ट फ्रेम से एम्बेडेड फ़ाइलों का डेटा एक्सेस करें और उसे डिस्क पर लिखें।

यह Java कोड दिखाता है कि कैसे एक स्लाइड में OLE ऑब्जेक्ट के रूप में एम्बेडेड फ़ाइलों को निकाला जाए:

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

### क्या स्लाइड्स को PDF/छवियों में एक्सपोर्ट करने पर OLE कंटेंट रेंडर होगा?

स्लाइड पर दिखाई देने वाला भाग रेंडर किया जाता है — आइकन/वैकल्पिक इमेज (प्रीव्यू)। "लाइव" OLE कंटेंट रेंडरिंग के दौरान निष्पादित नहीं होता। यदि आवश्यक हो, तो इच्छित रूप दिखाने के लिए अपना प्रीव्यू इमेज सेट करें ताकि निर्यातित PDF में अपेक्षित रूप दिखे।

### कैसे मैं स्लाइड पर OLE ऑब्जेक्ट को लॉक कर सकता हूँ ताकि उपयोगकर्ता PowerPoint में उसे मूव या एडिट न कर सकें?

शेप को लॉक करें: Aspose.Slides शेप‑स्तर के लॉक प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह अनजाने में संपादन और मूवमेंट को प्रभावी रूप से रोकता है।

### जब मैं प्रेजेंटेशन खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट "जम्प" करता है या आकार बदलता है, क्यों?

PowerPoint लिंक्ड OLE का प्रीव्यू रीफ़्रेश कर सकता है। स्थिर दिखावट के लिए, [Working Solution for Worksheet Resizing](/slides/hi/androidjava/working-solution-for-worksheet-resizing/) के अभ्यासों का पालन करें — या तो फ्रेम को रेंज के साथ फिट करें, या रेंज को निश्चित फ्रेम में स्केल करें और उपयुक्त वैकल्पिक इमेज सेट करें।

### क्या लिंक्ड OLE ऑब्जेक्ट्स के रिलेटिव पाथ PPTX फॉर्मेट में सुरक्षित रहेंगे?

PPTX में, "relative path" जानकारी उपलब्ध नहीं होती — केवल पूर्ण पथ रहता है। रिलेटिव पाथ पुराने PPT फॉर्मेट में मिलते हैं। पोर्टेबिलिटी के लिए विश्वसनीय एब्सोल्यूट पाथ/एक्सेसेबल URIs या एम्बेडिंग को प्राथमिकता दें।