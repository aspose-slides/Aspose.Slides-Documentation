---
title: जावास्क्रिप्ट के माध्यम से प्रस्तुतियों में OLE प्रबंधन
linktitle: OLE प्रबंधन
type: docs
weight: 40
url: /hi/nodejs-java/manage-ole/
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
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint और OpenDocument फाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को बिना रुकावट के एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert color="info" title="Note" %}}
OLE (ऑब्जेक्ट लिंकिंग और एम्बेडिंग) एक माइक्रोसॉफ्ट तकनीक है जो एक अनुप्रयोग में निर्मित डेटा और वस्तुओं को लिंक या एम्बेडिंग के द्वारा दूसरे अनुप्रयोग में रखने की अनुमति देती है।
{{% /alert %}}

MS Excel में बनाया गया एक चार्ट मान लीजिए। यह चार्ट फिर PowerPoint स्लाइड के अंदर रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है।

- एक OLE ऑब्जेक्ट आइकन के रूप में दिख सकता है। इस स्थिति में, आइकन पर डबल‑क्लिक करने पर चार्ट अपने संबंधित अनुप्रयोग (Excel) में खुलता है, या आपको ऑब्जेक्ट को खोलने या संपादित करने के लिए अनुप्रयोग चुनने के लिए कहा जाता है।
- एक OLE ऑब्जेक्ट अपनी वास्तविक सामग्री, जैसे कि चार्ट की सामग्री, प्रदर्शित कर सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट के डेटा को संशोधित कर सकते हैं।

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) आपको स्लाइड्स में OLE ऑब्जेक्ट को OLE ऑब्जेक्ट फ़्रेम के रूप में सम्मिलित करने की अनुमति देता है ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame))।

## **स्लाइड्स में OLE ऑब्जेक्ट फ़्रेम जोड़ना**

मान लेते हैं कि आपने Microsoft Excel में पहले ही एक चार्ट बना लिया है और Aspose.Slides for Node.js via Java का उपयोग करके उसे स्लाइड में OLE ऑब्जेक्ट फ़्रेम के रूप में एम्बेड करना चाहते हैं, आप इसे इस प्रकार कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. स्लाइड का संदर्भ उसके अनुक्रमणिका (इंडेक्स) के माध्यम से प्राप्त करें।
3. Excel फ़ाइल को बाइट ऐरे के रूप में पढ़ें।
4. बाइट ऐरे और OLE ऑब्जेक्ट की अन्य जानकारी के साथ स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) जोड़ें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे के उदाहरण में, हमने Aspose.Slides for Node.js via Java का उपयोग करके Excel फ़ाइल से एक चार्ट को स्लाइड में OLE ऑब्जेक्ट फ़्रेम के रूप में जोड़ा है।

**ध्यान दें** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) कंस्ट्रक्टर दूसरा पैरामीटर के रूप में एम्बेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से व्याख्या करने और इस OLE ऑब्जेक्ट को खोलने के लिए सही अनुप्रयोग चुनने में सक्षम बनाता है।

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **लिंक्ड OLE ऑब्जेक्ट फ़्रेम जोड़ना**

Aspose.Slides for Node.js via Java आपको डेटा एम्बेड किए बिना केवल फ़ाइल के लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) जोड़ने की अनुमति देता है।

यह JavaScript कोड दिखाता है कि कैसे आप एक लिंक्ड Excel फ़ाइल के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) को स्लाइड में जोड़ सकते हैं:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// एक लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ़्रेम जोड़ें.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ़्रेम तक पहुँच**

यदि कोई OLE ऑब्जेक्ट पहले से स्लाइड में एम्बेड किया गया है, तो आप इसे इस तरह आसानी से खोज या पहुँचा सकते हैं:

1. एम्बेडेड OLE ऑब्जेक्ट वाली प्रस्तुति को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) शेप तक पहुँचें। हमारे उदाहरण में, हमने पहले निर्मित PPTX का उपयोग किया है जिसमें पहली स्लाइड पर केवल एक शेप है।
4. एक बार OLE ऑब्जेक्ट फ़्रेम तक पहुँचने के बाद, आप उस पर कोई भी ऑपरेशन कर सकते हैं।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ़्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा तक पहुँच प्राप्त की गई है।

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // एम्बेडेड फ़ाइल डेटा प्राप्त करें।
    // एम्बेडेड फ़ाइल का एक्सटेंशन प्राप्त करें।
    // ...
}
```

### **लिंक्ड OLE ऑब्जेक्ट फ़्रेम गुणों तक पहुँच**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ़्रेम के गुणों तक पहुँचने की अनुमति देता है।

यह JavaScript कोड दिखाता है कि कैसे आप यह जाँच सकते हैं कि कोई OLE ऑब्जेक्ट लिंक्ड है या नहीं और फिर लिंक्ड फ़ाइल का पथ प्राप्त कर सकते हैं:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // जाँचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
    if (oleFrame.isObjectLink()) {
        // लिंक्ड फ़ाइल का पूरा पथ प्रिंट करें।
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेटिव पथ प्रिंट करें।
        // केवल PPT प्रस्तुतियों में रिलेटिव पथ हो सकता है।
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE ऑब्जेक्ट डेटा बदलना**

{{% alert color="info" title="Note" %}}
इस अनुभाग में नीचे का कोड उदाहरण [Aspose.Cells for Java](https://docs.aspose.com/cells/java/) का उपयोग करता है।
{{% /alert %}}

यदि कोई OLE ऑब्जेक्ट पहले से स्लाइड में एम्बेड किया गया है, तो आप उस ऑब्जेक्ट तक आसानी से पहुँच कर उसका डेटा इस प्रकार संशोधित कर सकते हैं:

1. एम्बेडेड OLE ऑब्जेक्ट वाली प्रस्तुति को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें। 
3. OLE ऑब्जेक्ट फ़्रेम शेप तक पहुँचें। हमारे उदाहरण में, हमने पहले निर्मित PPTX का उपयोग किया है जिसमें पहली स्लाइड पर एक शेप है।
4. एक बार OLE ऑब्जेक्ट फ़्रेम तक पहुँचने के बाद, आप उस पर कोई भी ऑपरेशन कर सकते हैं।
5. एक `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा तक पहुँचें।
6. इच्छित `Worksheet` तक पहुँचें और डेटा में संशोधन करें।
7. अपडेटेड `Workbook` को एक स्ट्रीम में सहेजें।
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा को बदलें।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ़्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) तक पहुँचा गया है, और उसके फ़ाइल डेटा को अपडेट करके चार्ट डेटा को संशोधित किया गया है।

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // OLE ऑब्जेक्ट डेटा को एक Workbook ऑब्जेक्ट के रूप में पढ़ें।
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Workbook डेटा में संशोधन करें।
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // OLE फ्रेम ऑब्जेक्ट डेटा बदलें।
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **स्लाइड्स में अन्य फ़ाइल प्रकार एम्बेड करना**

Excel चार्ट के अलावा, Aspose.Slides for Node.js via Java आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर डबल‑क्लिक करता है, तो यह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने के लिए प्रेरित किया जाता है।

यह JavaScript कोड दिखाता है कि कैसे आप HTML और ZIP को स्लाइड में एम्बेड कर सकते हैं:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए फ़ाइल प्रकार सेट करना**

प्रस्तुति के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट को नए से बदलने या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलने की आवश्यकता हो सकती है। Aspose.Slides for Node.js via Java आपको एम्बेडेड ऑब्जेक्ट के लिए फ़ाइल प्रकार सेट करने की अनुमति देता है, जिससे आप OLE फ़्रेम डेटा या उसके एक्सटेंशन को अपडेट कर सकते हैं।

यह JavaScript कोड दिखाता है कि कैसे आप एम्बेडेड OLE ऑब्जेक्ट का फ़ाइल प्रकार `zip` पर सेट कर सकते हैं:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// फ़ाइल प्रकार को ZIP में बदलें।
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज और शीर्षक सेट करना**

एक OLE ऑब्जेक्ट को एम्बेड करने के बाद, स्वचालित रूप से एक आइकन इमेज वाली प्रीव्यू जोड़ी जाती है। यह प्रीव्यू वही है जो उपयोगकर्ता OLE ऑब्जेक्ट को एक्सेस या खोलने से पहले देखते हैं। यदि आप प्रीव्यू में एक विशिष्ट इमेज और टेक्स्ट को तत्व के रूप में उपयोग करना चाहते हैं, तो आप Aspose.Slides for Node.js via Java का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह JavaScript कोड दिखाता है कि कैसे आप एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट कर सकते हैं:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// प्रस्तुति संसाधनों में एक छवि जोड़ें।
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// OLE प्रीव्यू के लिए शीर्षक और छवि सेट करें।
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ़्रेम को आकार बदलने और पुनः स्थिति बदलने से रोकना**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रस्तुति स्लाइड में जोड़ते हैं, तो PowerPoint में प्रस्तुति खोलने पर आपको लिंक अपडेट करने के लिए एक संदेश दिखाई दे सकता है। "Update Links" बटन दबाने से OLE ऑब्जेक्ट फ़्रेम का आकार और स्थान बदल सकता है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को ताज़ा करता है। PowerPoint को ऑब्जेक्ट डेटा अपडेट करने के लिए प्रेरित होने से रोकने के लिए, [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) क्लास के साथ `false` का उपयोग करके [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) मेथड को कॉल करें:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **एम्बेडेड फ़ाइलों को निकालना**

Aspose.Slides for Node.js via Java आपको स्लाइड्स में OLE ऑब्जेक्ट के रूप में एम्बेड की गई फ़ाइलों को इस प्रकार निकालने की अनुमति देता है:

1. उन OLE ऑब्जेक्ट्स को सम्मिलित करने वाली [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं जिन्हें आप निकालना चाहते हैं।
2. प्रस्तुति में सभी शेप्स के माध्यम से लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe) शेप्स तक पहुँचें।
3. OLE ऑब्जेक्ट फ़्रेम से एम्बेडेड फ़ाइलों का डेटा एक्सेस करें और उसे डिस्क पर लिखें।

यह JavaScript कोड दिखाता है कि कैसे आप एक स्लाइड में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट के रूप में निकाल सकते हैं:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **बार‑बार पूछे जाने वाले प्रश्न**

**क्या स्लाइड्स को PDF/छवियों में निर्यात करने पर OLE सामग्री रेंडर की जाएगी?**  
स्लाइड पर दिख रही चीज़ रेंडर की जाती है—आइकन/प्रतिस्थापन इमेज (प्रीव्यू)। "लाइव" OLE सामग्री रेंडरिंग के दौरान निष्पादित नहीं होती। यदि आवश्यक हो, तो निर्यातित PDF में अपेक्षित दिखावट सुनिश्चित करने के लिए अपना स्वयं का प्रीव्यू इमेज सेट करें।  
एम्बेडेड फ़ाइल को PDF अटैचमेंट के रूप में भी संरक्षित करने के लिए, `true` के साथ [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) कॉल करें। यह विकल्प डिफ़ॉल्ट रूप से निष्क्रिय है। उदाहरण और अटैचमेंट चेक करने के निर्देश के लिए देखें [एम्बेडेड OLE फ़ाइलों को PDF अटैचमेंट्स के रूप में संरक्षित करना](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)।

**मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक करूं ताकि उपयोगकर्ता PowerPoint में उसे मूव/एडिट न कर सकें?**  
शेप को लॉक करें: Aspose.Slides शेप‑स्तर के लॉक प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह अनजाने संपादन और मूवमेंट को प्रभावी रूप से रोकता है।

**क्या PPTX प्रारूप में लिंक्ड OLE ऑब्जेक्ट के रिलेटिव पाथ्स को संरक्षित किया जाएगा?**  
PPTX में "रिलेटिव पाथ" जानकारी उपलब्ध नहीं है—केवल पूर्ण पाथ होता है। रिलेटिव पाथ्स पुराने PPT फ़ॉर्मेट में पाए जाते हैं। पोर्टेबिलिटी के लिए विश्वसनीय एब्सॉल्यूट पाथ/एक्सेसेबल URI या एम्बेडिंग को प्राथमिकता दें।