---
title: "Java का उपयोग करके प्रस्तुतियों में ActiveX नियंत्रणों का प्रबंधन"
linktitle: "ActiveX"
type: docs
weight: 80
url: /hi/java/activex/
keywords:
  - "ActiveX"
  - "ActiveX नियंत्रण"
  - "ActiveX प्रबंधन"
  - "ActiveX जोड़ें"
  - "ActiveX संशोधित करें"
  - "मीडिया प्लेयर"
  - "PowerPoint"
  - "प्रस्तुति"
  - "Java"
  - "Aspose.Slides"
description: "जानें कैसे Aspose.Slides for Java ActiveX का उपयोग करके PowerPoint प्रस्तुतियों को स्वचालित और सुधारता है, जिससे डेवलपर्स को स्लाइड्स पर शक्तिशाली नियंत्रण मिलता है।"
---
## **परिचय**

ActiveX नियंत्रणों का उपयोग प्रस्तुतियों में किया जाता है। Aspose.Slides for Java आपको ActiveX नियंत्रणों को जोड़ने और प्रबंधित करने की सुविधा देता है, लेकिन सामान्य प्रस्तुति आकारों की तुलना में इन्हें प्रबंधित करना थोड़ा कठिन होता है। हमने Aspose.Slides में Media Player Active नियंत्रण जोड़ने का समर्थन लागू किया है। ध्यान रखें कि ActiveX नियंत्रण आकार नहीं होते; वे प्रस्तुति के [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/) का हिस्सा नहीं होते। वे एक अलग [IControlCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icontrolcollection/) का हिस्सा होते हैं। इस विषय में, हम आपको दिखाएंगे कि इनके साथ कैसे काम किया जाता है।

## **स्लाइड में Media Player ActiveX नियंत्रण जोड़ें**
ActiveX Media Player नियंत्रण जोड़ने के लिए नीचे दिए चरणों को अपनाएँ:

1. एक खाली प्रस्तुति का उदाहरण बनाने के लिए [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) वर्ग की एक instance बनाएँ।
1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) में लक्षित स्लाइड तक पहुँचें।
1. [IControlCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icontrolcollection/) द्वारा प्रदान की गई [addControl](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) विधि का उपयोग करके Media Player ActiveX नियंत्रण जोड़ें।
1. Media Player ActiveX नियंत्रण तक पहुँचें और इसकी properties का उपयोग करके वीडियो पथ सेट करें।
1. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

ऊपर दिए चरणों के आधार पर यह नमूना कोड दिखाता है कि स्लाइड में Media Player ActiveX नियंत्रण कैसे जोड़ें:

```java
// खाली प्रस्तुति का उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // Media Player ActiveX नियंत्रण जोड़ना
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Media Player ActiveX नियंत्रण तक पहुंचें और वीडियो पथ सेट करें
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // प्रस्तुति सहेजें
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ActiveX नियंत्रण को संशोधित करें**
{{% alert color="primary" %}} 

Aspose.Slides for Java 7.1.0 और नये संस्करणों में ActiveX नियंत्रणों के प्रबंधन के लिए घटक शामिल हैं। आप अपनी प्रस्तुति में पहले से जोड़े गए ActiveX नियंत्रण तक पहुँच सकते हैं और उसकी properties के माध्यम से उसे संशोधित या हटाया जा सकता है।

{{% /alert %}} 

स्लाइड पर एक साधारण ActiveX नियंत्रण जैसे टेक्स्ट बॉक्स और साधारण कमांड बटन को प्रबंधित करने के लिए नीचे दिए चरणों को अपनाएँ:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) वर्ग की एक instance बनाकर उस प्रस्तुति को लोड करें जिसमें ActiveX नियंत्रण हों।
1. इंडेक्स द्वारा एक स्लाइड संदर्भ प्राप्त करें।
1. स्लाइड में मौजूद ActiveX नियंत्रणों तक पहुँचने के लिए [IControlCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icontrolcollection/) तक पहुँचें।
1. [IControl](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icontrol/) ऑब्जेक्ट का उपयोग करके TextBox1 ActiveX नियंत्रण तक पहुँचें।
1. TextBox1 ActiveX नियंत्रण की properties जैसे टेक्स्ट, फ़ॉन्ट, फ़ॉन्ट ऊँचाई, और फ्रेम स्थिति बदलें।
1. दूसरे नियंत्रण जिसका नाम CommandButton1 है, तक पहुँचें।
1. बटन का कैप्शन, फ़ॉन्ट, और स्थिति बदलें।
1. ActiveX नियंत्रणों के फ्रेम की स्थिति को समायोजित करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

ऊपर दिए चरणों के आधार पर यह नमूना कोड दिखाता है कि एक साधारण ActiveX नियंत्रण को कैसे प्रबंधित किया जाए:

```java
// ActiveX नियंत्रणों के साथ प्रस्तुति को एक्सेस करना
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // प्रस्तुति में पहली स्लाइड तक पहुँच रहे हैं
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox का टेक्स्ट बदल रहे हैं
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // विकल्पी चित्र बदल रहे हैं। PowerPoint इस चित्र को ActiveX सक्रियता के दौरान बदल देगा,
        // इसलिए कभी-कभी इसे जैसा है वैसा छोड़ना ठीक है।
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

    // बटन कैप्शन बदल रहे हैं
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // विकल्पी चित्र बदल रहे हैं
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

            // 100 बिंदु नीचे ले जा रहे हैं
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // नियंत्रणों को हटा रहे हैं
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides Java रनटाइम में निष्पादित नहीं किए जा सकने वाले ActiveX नियंत्रणों को पढ़ने और पुनः सहेजने पर भी बरकरार रखता है?**

हाँ। Aspose.Slides उन्हें प्रस्तुति के भाग के रूप में मानता है और उनकी properties व फ्रेम को पढ़/संशोधित कर सकता है; नियंत्रणों को स्वयं निष्पादित करने की आवश्यकता नहीं है।

**ActiveX नियंत्रण प्रस्तुति में OLE वस्तुओं से कैसे अलग होते हैं?**

ActiveX नियंत्रण इंटरैक्टिव प्रबंधित नियंत्रण हैं (बटन, टेक्स्ट बॉक्स, मीडिया प्लेयर), जबकि [OLE](/slides/hi/java/manage-ole/) एम्बेडेड एप्लिकेशन वस्तुओं को दर्शाता है (जैसे Excel वर्कशीट)। इन्हें अलग तरह से संग्रहीत और संभाला जाता है तथा इनकी property मॉडल भी अलग होती है।

**क्या ActiveX इवेंट्स और VBA मैक्रो Aspose.Slides द्वारा संशोधित फ़ाइल में कार्य करेंगे?**

Aspose.Slides मौजूदा मार्कअप और मेटाडाटा को बरकरार रखता है; हालांकि इवेंट्स और मैक्रो केवल Windows पर PowerPoint में तब चलते हैं जब सुरक्षा अनुमति देती है। यह लाइब्रेरी VBA को निष्पादित नहीं करती।