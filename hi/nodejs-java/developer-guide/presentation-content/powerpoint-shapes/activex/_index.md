---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में ActiveX नियंत्रण प्रबंधित करें
linktitle: ActiveX
type: docs
weight: 80
url: /hi/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX प्रबंधन
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जानेँ कि कैसे Aspose.Slides for Node.js via Java ActiveX का उपयोग करके PowerPoint प्रस्तुतियों को स्वचालित और उन्नत करता है, जिससे डेवलपर्स को स्लाइड्स पर शक्तिशाली नियंत्रण मिलता है।"
---
## **परिचय**

ActiveX नियंत्रण प्रस्तुति में उपयोग किए जाते हैं। Aspose.Slides for Node.js via Java आपको ActiveX नियंत्रण जोड़ने और प्रबंधित करने की अनुमति देता है, लेकिन वे सामान्य प्रस्तुति शैलियों की तुलना में प्रबंधन में थोड़ा कठिन होते हैं। हमने Aspose.Slides में Media Player Active नियंत्रण जोड़ने का समर्थन लागू किया है। ध्यान दें कि ActiveX नियंत्रण आकार नहीं हैं; वे प्रस्तुति के [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/) का हिस्सा नहीं हैं। वे अलग [ControlCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/controlcollection/) का हिस्सा हैं। इस विषय में, हम आपको दिखाएंगे कि इनके साथ कैसे काम करें।

## **स्लाइड में Media Player ActiveX नियंत्रण जोड़ना**
ActiveX Media Player नियंत्रण जोड़ने के लिए निम्न करें:

1. एक खाली प्रस्तुति का उदाहरण बनाने के लिए [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएँ।
1. लक्ष्य स्लाइड को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) में एक्सेस करें।
1. Media Player ActiveX नियंत्रण को [ControlCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/controlcollection/) द्वारा प्रदान किए गए [addControl](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) मेथड का उपयोग करके जोड़ें।
1. Media Player ActiveX नियंत्रण को एक्सेस करें और उसकी प्रॉपर्टीज़ का उपयोग करके वीडियो पाथ सेट करें।
1. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह नमूना कोड, ऊपर दिए गए चरणों के आधार पर, स्लाइड में Media Player ActiveX नियंत्रण जोड़ने का तरीका दर्शाता है:

```javascript
// खाली प्रस्तुति इंस्टेंस बनाएँ
var pres = new aspose.slides.Presentation();
try {
    // Media Player ActiveX नियंत्रण जोड़ना
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Media Player ActiveX नियंत्रण तक पहुँचें और वीडियो पाथ सेट करें
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // प्रस्तुति सहेजें
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ActiveX नियंत्रण को संशोधित करना**

स्लाइड पर एक टेक्स्ट बॉक्स और एक साधारण कमांड बटन जैसे सरल ActiveX नियंत्रण को प्रबंधित करने के लिए निम्न करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास की इंस्टेंस बनाकर उस प्रस्तुति को लोड करें जिसमें ActiveX नियंत्रण मौजूद हों।
1. इंडेक्स के द्वारा स्लाइड संदर्भ प्राप्त करें।
1. स्लाइड में ActiveX नियंत्रणों को [ControlCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/controlcollection/) तक पहुंचकर एक्सेस करें।
1. [Control](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/control/) ऑब्जेक्ट का उपयोग करके TextBox1 ActiveX नियंत्रण तक पहुंचें।
1. TextBox1 ActiveX नियंत्रण की प्रॉपर्टीज़ जैसे पाठ, फ़ॉन्ट, फ़ॉन्ट ऊँचाई, और फ्रेम स्थिति बदलें।
1. दूसरे नियंत्रण CommandButton1 को एक्सेस करें।
1. बटन का शीर्षक, फ़ॉन्ट, और स्थिति बदलें।
1. ActiveX नियंत्रणों के फ्रेम की स्थिति को शिफ्ट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह नमूना कोड, ऊपर दिए गए चरणों के आधार पर, एक साधारण ActiveX नियंत्रण को प्रबंधित करने का तरीका दर्शाता है:

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// ActiveX नियंत्रणों के साथ प्रस्तुति तक पहुँच रहा है
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // प्रस्तुति में पहले स्लाइड तक पहुँच रहा है
    var slide = pres.getSlides().get_Item(0);
    // TextBox पाठ बदल रहा है
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // प्रतिस्थापन छवि बदल रहा है। PowerPoint सक्रियण के दौरान इस छवि को बदल देगा,
        // इसलिए कभी-कभी छवि को अनछुआ छोड़ना ठीक है।
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // बटन शीर्षक बदल रहा है
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // प्रतिस्थापन बदल रहा है
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // 100 पॉइंट नीचे ले जा रहा है
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // नियंत्रण हटाया जा रहा है
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides उन ActiveX नियंत्रणों को संरक्षित करता है जब पढ़ने और पुनः सहेजने के दौरान वे Python रनटाइम में निष्पादित नहीं हो सकते?**

हाँ। Aspose.Slides उन्हें प्रस्तुति का भाग मानता है और उनकी प्रॉपर्टीज़ और फ्रेम को पढ़ और संशोधित कर सकता है; इन नियंत्रणों को स्वयं निष्पादित करने की आवश्यकता नहीं है उन्हें संरक्षित रखने के लिए।

**ActiveX नियंत्रण प्रस्तुति में OLE वस्तुओं से कैसे भिन्न होते हैं?**

ActiveX नियंत्रण इंटरैक्टिव प्रबंधित नियंत्रण होते हैं (बटन, टेक्स्ट बॉक्स, मीडिया प्लेयर), जबकि [OLE](/slides/hi/nodejs-java/manage-ole/) एम्बेडेड एप्लिकेशन वस्तुओं को दर्शाता है (उदाहरण के लिए, एक Excel वर्कशीट)। इन्हें अलग तरीके से संग्रहीत और प्रबंधित किया जाता है और इनके प्रॉपर्टी मॉडल अलग होते हैं।

**क्या ActiveX इवेंट्स और VBA मैक्रोज़ काम करेंगे यदि फ़ाइल Aspose.Slides द्वारा संशोधित की गई हो?**

Aspose.Slides मौजूदा मार्कअप और मेटाडेटा को संरक्षित रखता है; हालांकि, इवेंट्स और मैक्रोज़ केवल विंडोज़ पर PowerPoint के भीतर तभी चलते हैं जब सुरक्षा अनुमति देती है। यह लाइब्रेरी VBA को निष्पादित नहीं करती।