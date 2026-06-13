---
title: JavaScript का उपयोग करके प्रस्तुतियों में OLE प्रबंधन करें
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
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert color="primary" %}} 

OLE (ऑब्जेक्ट लिंकिंग & एम्बेडिंग) एक माइक्रोसॉफ्ट तकनीक है जो एक एप्लिकेशन में निर्मित डेटा और वस्तुओं को लिंकिंग या एम्बेडिंग के माध्यम से दूसरे एप्लिकेशन में रखने की अनुमति देती है। 

{{% /alert %}} 

मान लीजिए एक चार्ट MS Excel में बनाया गया है। फिर वह चार्ट PowerPoint स्लाइड के अंदर रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है। 

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन पर डबल‑क्लिक करते हैं, तो चार्ट अपने सम्बंधित एप्लिकेशन (Excel) में खुल जाता है, या आपको ऑब्जेक्ट को खोलने या संपादित करने के लिए एक एप्लिकेशन चयन करने के लिए कहा जाता है। 
- एक OLE ऑब्जेक्ट अपने वास्तविक सामग्री, जैसे कि चार्ट की सामग्री दिखा सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट के डेटा को संशोधित कर सकते हैं। 

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/hi/nodejs-java/) आपको स्लाइड्स में OLE ऑब्जेक्ट्स को OLE ऑब्जेक्ट फ्रेम्स ([OleObjectFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/OleObjectFrame)) के रूप में सम्मिलित करने की अनुमति देता है।

## **स्लाइड्स में OLE ऑब्जेक्ट फ्रेम जोड़ना**

मान लीजिए आपने Microsoft Excel में एक चार्ट पहले ही बना लिया है और Aspose.Slides for Node.js via Java का उपयोग करके उसे एक OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, आप इसे इस तरह कर सकते हैं:

1.  [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।  
2.  इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3.  Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।  
4.  स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/OleObjectFrame) जोड़ें जिसमें बाइट एरे और OLE ऑब्जेक्ट की अन्य जानकारी शामिल हो।  
5.  परिवर्तित प्रस्तुतिकरण को PPTX फ़ाइल के रूप में लिखें।  

नीचे दिए गए उदाहरण में, हमने Excel फ़ाइल से एक चार्ट को Aspose.Slides for Node.js via Java का उपयोग करके एक OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में जोड़ा है।  
**Note** यह है कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/OleEmbeddedDataInfo) कंस्ट्रक्टर दूसरा पैरामीटर के रूप में एक एम्बेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से व्याख्या करने और इस OLE ऑब्जेक्ट को खोलने के लिए उपयुक्त एप्लिकेशन चुनने की अनुमति देता है।

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// OLE ऑब्जेक्ट के लिए डेटा तैयार करें।
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम जोड़ना**

Aspose.Slides for Node.js via Java आपको डेटा एम्बेड किए बिना केवल फ़ाइल के लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/OleObjectFrame) जोड़ने की अनुमति देता है।  

यह JavaScript कोड दिखाता है कि कैसे एक लिंक्ड Excel फ़ाइल के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/OleObjectFrame) स्लाइड में जोड़ा जाए:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ्रेम तक पहुँच**

यदि एक OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेड किया गया है, तो आप इसे इस तरह आसानी से खोज या पहुँच सकते हैं:

1.  [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाली प्रस्तुति लोड करें।  
2.  इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।  
3.  [OleObjectFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/OleObjectFrame) शेप तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया है जिसमें पहली स्लाइड पर केवल एक शेप है।  
4.  एक बार OLE ऑब्जेक्ट फ्रेम तक पहुँचने के बाद, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेड किया गया Excel चार्ट ऑब्जेक्ट) और इसकी फ़ाइल डेटा तक पहुँचाया गया है।

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // एम्बेडेड फ़ाइल डेटा प्राप्त करें।
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // एम्बेडेड फ़ाइल का एक्सटेंशन प्राप्त करें।
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम गुणों तक पहुँचना**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम के गुणों तक पहुँचने की अनुमति देता है।  

यह JavaScript कोड दिखाता है कि कैसे यह जांचा जाए कि OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पाथ प्राप्त किया जाए:

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // जाँचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
    if (oleFrame.isObjectLink()) {
        // लिंक्ड फ़ाइल का पूर्ण पथ प्रिंट करें।
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // यदि मौजूद हो तो लिंक्ड फ़ाइल का सापेक्ष पथ प्रिंट करें।
        // केवल PPT प्रस्तुतियों में सापेक्ष पथ हो सकता है।
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE ऑब्जेक्ट डेटा बदलना**

{{% alert color="primary" %}} 

इस भाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for Java](/cells/java/) का उपयोग करता है।  

{{% /alert %}}

यदि एक OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेड किया गया है, तो आप इस तरह आसानी से उस ऑब्जेक्ट तक पहुँच सकते हैं और उसका डेटा संशोधित कर सकते हैं:

1.  [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाली प्रस्तुति लोड करें।  
2.  इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3.  OLE ऑब्जेक्ट फ्रेम शेप तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक शेप है।  
4.  एक बार OLE ऑब्जेक्ट फ्रेम तक पहुँचने के बाद, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  
5.  `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा तक पहुँचें।  
6.  वांछित `Worksheet` तक पहुँचें और डेटा में बदलाव करें।  
7.  अद्यतित `Workbook` को एक स्ट्रीम में सहेजें।  
8.  स्ट्रीम से OLE ऑब्जेक्ट डेटा बदलें।  

नीचे दिए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेड किया गया Excel चार्ट ऑब्जेक्ट) तक पहुँचा गया है, और इसके फ़ाइल डेटा को चार्ट डेटा को अपडेट करने के लिए संशोधित किया गया है।

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE ऑब्जेक्ट डेटा को Workbook ऑब्जेक्ट के रूप में पढ़ें।
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // वर्कबुक डेटा को संशोधित करें।
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // OLE फ्रेम ऑब्जेक्ट डेटा बदलें।
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **स्लाइड्स में अन्य फ़ाइल प्रकार एम्बेड करना**

Excel चार्ट्स के अलावा, Aspose.Slides for Node.js via Java आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की क्षमता देता है। उदाहरण के लिए, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर डबल‑क्लिक करता है, तो वह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने का संकेत दिया जाता है।  

यह JavaScript कोड दिखाता है कि कैसे HTML और ZIP को एक स्लाइड में एम्बेड किया जाए:

```javascript
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

प्रेजेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट्स को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना पड़ सकता है। Aspose.Slides for Node.js via Java आपको एक एम्बेडेड ऑब्जेक्ट के लिए फ़ाइल प्रकार सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसके एक्सटेंशन को अपडेट कर सकते हैं।  

यह JavaScript कोड दिखाता है कि कैसे एम्बेडेड OLE ऑब्जेक्ट का फ़ाइल प्रकार `zip` पर सेट किया जाए:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Change the file type to ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज और शीर्षक सेट करना**

OLE ऑब्जेक्ट को एम्बेड करने के बाद, एक प्रीव्यू जो आइकन इमेज से बना होता है, स्वचालित रूप से जोड़ा जाता है। यह प्रीव्यू वह है जो उपयोगकर्ता OLE ऑब्जेक्ट तक पहुँचने या खोलने से पहले देखते हैं। यदि आप प्रीव्यू में विशिष्ट छवि और टेक्स्ट को तत्वों के रूप में उपयोग करना चाहते हैं, तो आप Aspose.Slides for Node.js via Java का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।  

यह JavaScript कोड दिखाता है कि कैसे एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट किया जाए:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// प्रेजेंटेशन संसाधनों में एक चित्र जोड़ें।
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE ऑब्जेक्ट फ्रेम को आकार बदलने और पुनःस्थिति देने से रोकना**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेजेंटेशन स्लाइड में जोड़ते हैं, और PowerPoint में प्रेजेंटेशन खोलते हैं, तो आपको लिंक अपडेट करने के लिए एक संदेश दिखाई दे सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को रिफ्रेश करता है। PowerPoint को ऑब्जेक्ट के डेटा को अपडेट करने के लिए प्रेरित करने से रोकने के लिए, [OleObjectFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/oleobjectframe/) क्लास की `setUpdateAutomatic` मेथड को `false` मान के साथ उपयोग करें:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **एम्बेडेड फ़ाइलों को निकालना**

Aspose.Slides for Node.js via Java आपको इस तरह स्लाइड्स में OLE ऑब्जेक्ट्स के रूप में एम्बेडेड फ़ाइलों को निकालने की अनुमति देता है:

1.  [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं जिसमें वे OLE ऑब्जेक्ट्स हों जिन्हें आप निकालना चाहते हैं।  
2.  प्रेजेंटेशन में सभी शेप्स के माध्यम से लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/oleobjectframe) शेप्स तक पहुँचें।  
3.  OLE ऑब्जेक्ट फ्रेम्स से एम्बेडेड फ़ाइलों का डेटा तक पहुँचें और उसे डिस्क पर लिखें।  

यह JavaScript कोड दिखाता है कि कैसे स्लाइड में OLE ऑब्जेक्ट्स के रूप में एम्बेडेड फ़ाइलों को निकाला जाए:

```javascript
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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्लाइड्स को PDF/छवियों में निर्यात करने पर OLE कंटेंट रेंडर होगा?**

स्लाइड पर दिखाई देने वाला भाग रेंडर होता है—आइकन/प्रतिस्थापन छवि (प्रीव्यू)। "लाइव" OLE कंटेंट रेंडरिंग के दौरान निष्पादित नहीं होता। यदि आवश्यक हो, तो निर्यातित PDF में अपेक्षित रूप दिखाने के लिए अपना स्वयं का प्रीव्यू इमेज सेट करें।

**मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक कर सकता हूँ ताकि उपयोगकर्ता PowerPoint में इसे हिले/संपादित न कर सकें?**

शेप को लॉक करें: Aspose.Slides शेप‑स्तर के लॉक प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह आकस्मिक संपादन और स्थान परिवर्तन को प्रभावी रूप से रोकता है।

**क्या PPTX फ़ॉर्मेट में लिंक्ड OLE ऑब्जेक्ट्स के सापेक्ष पाथ संरक्षित रहेंगे?**

PPTX में "relative path" जानकारी उपलब्ध नहीं है—केवल पूर्ण पाथ रहता है। सापेक्ष पाथ्स पुराने PPT फ़ॉर्मेट में उपलब्ध होते हैं। पोर्टेबिलिटी के लिए, विश्वसनीय पूर्ण पाथ/पहुंच योग्य URI या एम्बेडिंग को प्राथमिकता दें।