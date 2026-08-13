---
title: Android पर प्रस्तुतियों में ActiveX नियंत्रण प्रबंधित करें
linktitle: ActiveX
type: docs
weight: 80
url: /hi/androidjava/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX प्रबंधित करें
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "जानिए कैसे Aspose.Slides for Android via Java ActiveX का उपयोग करके PowerPoint प्रस्तुतियों को स्वचालित और उन्नत करता है, जिससे डेवलपर्स को स्लाइड्स पर शक्तिशाली नियंत्रण मिलता है।"
---
## **परिचय**

ActiveX नियंत्रणों का उपयोग प्रस्तुतियों में किया जाता है। Aspose.Slides for Android via Java आपको ActiveX नियंत्रणों को जोड़ने और प्रबंधित करने की अनुमति देता है, लेकिन सामान्य प्रस्तुति आकारों की तुलना में उन्हें प्रबंधित करना थोड़ा कठिन होता है। हमने Aspose.Slides में Media Player Active नियंत्रण को जोड़ने के लिए समर्थन लागू किया है। ध्यान दें कि ActiveX नियंत्रण आकार नहीं हैं; वे प्रस्तुति के [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/) का हिस्सा नहीं हैं। वे अलग [IControlCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icontrolcollection/) का भाग हैं। इस विषय में, हम आपको दिखाएंगे कि उनके साथ कैसे काम करें।

## **स्लाइड में Media Player ActiveX नियंत्रण जोड़ें**
1. एक खाली प्रस्तुति उदाहरण बनाने के लिए [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) वर्ग का एक उदाहरण बनाएं।  
2. लक्ष्य स्लाइड को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) में एक्सेस करें।  
3. [IControlCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icontrolcollection/) द्वारा प्रदान किए गए [addControl](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) मेथड का उपयोग करके Media Player ActiveX नियंत्रण जोड़ें।  
4. Media Player ActiveX नियंत्रण को एक्सेस करें और उसकी प्रॉपर्टीज़ का उपयोग करके वीडियो पथ सेट करें।  
5. प्रस्तुति को PPTX फ़ाइल के रूप में सेव करें।  

```java
import com.aspose.slides.*;

// खाली प्रस्तुति उदाहरण बनाएँ
Presentation pres = new Presentation();
try {
    // Media Player ActiveX नियंत्रण जोड़ना
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Media Player ActiveX नियंत्रण को एक्सेस करें और वीडियो पथ सेट करें
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // प्रस्तुति सहेजें
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ActiveX नियंत्रण को संशोधित करें**
{{% alert color="info" %}} 
Aspose.Slides for Android via Java 7.1.0 और नवीनतम संस्करणों में ActiveX नियंत्रणों के प्रबंधन के लिए घटक शामिल हैं। आप अपनी प्रस्तुति में पहले जोड़े गए ActiveX नियंत्रण को उसकी प्रॉपर्टीज़ के माध्यम से एक्सेस करके संशोधित या हटाना सकते हैं। 
{{% /alert %}} 

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) वर्ग का एक उदाहरण बनाएं और इसमें ActiveX नियंत्रणों वाली प्रस्तुति लोड करें।  
2. इंडेक्स द्वारा स्लाइड संदर्भ प्राप्त करें।  
3. स्लाइड में [IControlCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icontrolcollection/) को एक्सेस करके ActiveX नियंत्रणों तक पहुँचें।  
4. [IControl](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icontrol/) ऑब्जेक्ट का उपयोग करके TextBox1 ActiveX नियंत्रण को एक्सेस करें।  
5. TextBox1 ActiveX नियंत्रण की प्रॉपर्टीज़ बदलें, जिसमें टेक्स्ट, फ़ॉन्ट, फ़ॉन्ट ऊँचाई और फ्रेम स्थिति शामिल हैं।  
6. CommandButton1 नामक दूसरे एक्सेस नियंत्रण को एक्सेस करें।  
7. बटन कैप्शन, फ़ॉन्ट और स्थिति बदलें।  
8. ActiveX नियंत्रण फ्रेम की स्थिति को शिफ्ट करें।  
9. परिवर्तित प्रस्तुति को PPTX फ़ाइल में लिखें।  

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// ActiveX नियंत्रणों के साथ प्रस्तुति तक पहुंचना
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // प्रस्तुति में पहली स्लाइड तक पहुंचना
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox टेक्स्ट बदलना
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // प्रतिस्थापन छवि बदलना। PowerPoint इस छवि को ActiveX सक्रियण के दौरान बदल देगा,
        // इसलिए कभी-कभी छवि को अपरिवर्तित छोड़ देना ठीक है।
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // बटन कैप्शन बदलना
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);

        // प्रतिस्थापन बदलना
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // 100 प्वाइंट नीचे ले जाना
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // नियंत्रण हटाना
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### क्या Aspose.Slides पढ़ते और पुनः सहेजते समय ActiveX नियंत्रणों को संरक्षित रखता है यदि उन्हें Java रनटाइम में चलाया नहीं जा सकता?
हां। Aspose.Slides उन्हें प्रस्तुति का हिस्सा मानता है और उनकी प्रॉपर्टीज़ तथा फ्रेम को पढ़/बदल सकता है; नियंत्रणों को स्वयं चलाना आवश्यक नहीं है उन्हें संरक्षित रखने के लिए।

### एक प्रस्तुति में ActiveX नियंत्रण OLE ऑब्जेक्ट्स से कैसे भिन्न हैं?
ActiveX नियंत्रण इंटरैक्टिव प्रबंधित नियंत्रण होते हैं (बटन, टेक्स्ट बॉक्स, मीडिया प्लेयर), जबकि [OLE](/slides/hi/androidjava/manage-ole/) एम्बेडेड एप्लिकेशन ऑब्जेक्ट्स को दर्शाता है (जैसे, एक Excel कार्यपत्रक)। इन्हें अलग तरीके से संग्रहीत और प्रबंधित किया जाता है और इनके प्रॉपर्टी मॉडल भी अलग होते हैं।

### क्या ActiveX इवेंट्स और VBA मैक्रो काम करते हैं यदि फ़ाइल को Aspose.Slides द्वारा संशोधित किया गया हो?
Aspose.Slides मौजूदा मार्कअप और मेटाडेटा को संरक्षित रखता है; हालांकि, इवेंट्स और मैक्रो केवल Windows पर PowerPoint के भीतर ही चलते हैं जब सुरक्षा अनुमति देती है। लाइब्रेरी VBA को निष्पादित नहीं करती।