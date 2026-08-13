---
title: जावा का उपयोग करके प्रस्तुतियों में ActiveX नियंत्रण प्रबंधित करें
linktitle: ActiveX
type: docs
weight: 80
url: /hi/java/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX प्रबंधित करें
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- जावा
- Aspose.Slides
description: "जानिए कैसे Aspose.Slides for Java ActiveX का उपयोग करके PowerPoint प्रस्तुतियों को स्वचालित और उन्नत करता है, जिससे डेवलपर्स को स्लाइड्स पर शक्तिशाली नियंत्रण मिलता है।"
---
## **परिचय**

ActiveX नियंत्रण प्रस्तुतियों में उपयोग किए जाते हैं। Aspose.Slides for Java आपको ActiveX नियंत्रण जोड़ने और प्रबंधित करने की सुविधा देता है, लेकिन सामान्य प्रस्तुति आकारों की तुलना में इन्हें प्रबंधित करना थोड़ा कठिन है। हमने Aspose.Slides में Media Player Active नियंत्रण जोड़ने के लिए समर्थन लागू किया है। ध्यान दें कि ActiveX नियंत्रण आकार नहीं हैं; वे प्रस्तुति के [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/) का हिस्सा नहीं हैं। वे इसके बजाय अलग [IControlCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icontrolcollection/) का हिस्सा हैं। इस लेख में, हम आपको दिखाएंगे कि इनसे कैसे काम किया जाए। 

## **स्लाइड में Media Player ActiveX नियंत्रण जोड़ें**
ActiveX Media Player नियंत्रण जोड़ने के लिए, यह करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं और एक खाली प्रस्तुति उदाहरण उत्पन्न करें।
1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) में लक्ष्य स्लाइड तक पहुंचें।
1. [IControlCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icontrolcollection/) द्वारा प्रदान किए गए [addControl](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) मेथड का उपयोग करके Media Player ActiveX नियंत्रण जोड़ें।
1. Media Player ActiveX नियंत्रण तक पहुंचें और उसकी प्रॉपर्टियों का उपयोग करके वीडियो पथ सेट करें।
1. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

ऊपर बताए गए चरणों के आधार पर यह नमूना कोड दिखाता है कि कैसे स्लाइड में Media Player ActiveX नियंत्रण जोड़ा जाए:

```java
import com.aspose.slides.*;

// खाली प्रस्तुति इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // Media Player ActiveX नियंत्रण जोड़ रहे हैं
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
{{% alert color="info" %}} 

Aspose.Slides for Java 7.1.0 और नए संस्करणों में ActiveX नियंत्रणों को प्रबंधित करने के लिए घटक मौजूद हैं। आप अपनी प्रस्तुति में पहले से जोड़े गए ActiveX नियंत्रण तक पहुंच सकते हैं और उसकी प्रॉपर्टियों के माध्यम से उसे संशोधित या हटाया जा सकता है। 

{{% /alert %}} 

एक स्लाइड पर टेक्स्ट बॉक्स और साधारण कमांड बटन जैसे सरल ActiveX नियंत्रण को प्रबंधित करने के लिए, यह करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं और उस प्रस्तुति को लोड करें जिसमें ActiveX नियंत्रण हों।
1. इंडेक्स द्वारा स्लाइड संदर्भ प्राप्त करें।
1. स्लाइड में ActiveX नियंत्रणों तक पहुंचने के लिए [IControlCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icontrolcollection/) तक पहुंचें।
1. [IControl](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icontrol/) ऑब्जेक्ट का उपयोग करके TextBox1 ActiveX नियंत्रण तक पहुंचें।
1. TextBox1 ActiveX नियंत्रण की प्रॉपर्टी बदलें, जिसमें टेक्स्ट, फ़ॉन्ट, फ़ॉन्ट ऊँचाई और फ़्रेम स्थिति शामिल हैं।
1. CommandButton1 नामक दूसरे एक्सेस कंट्रोल तक पहुंचें।
1. बटन के शीर्षक, फ़ॉन्ट और स्थिति बदलें।
1. ActiveX नियंत्रण के फ़्रेम की स्थिति को बदलें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

ऊपर बताए गए चरणों के आधार पर यह नमूना कोड दिखाता है कि सरल ActiveX नियंत्रण को कैसे प्रबंधित किया जाए: 

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// ActiveX नियंत्रणों के साथ प्रस्तुति तक पहुंच रहे हैं
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // प्रस्तुति में पहली स्लाइड तक पहुंच रहे हैं
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox पाठ बदल रहे हैं
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // विकल्प चित्र बदल रहे हैं। PowerPoint सक्रियण के दौरान इस चित्र को बदल देगा,
        // इसलिए कभी-कभी चित्र को अपरिवर्तित छोड़ना ठीक है।
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
        // विकल्प बदल रहे हैं
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

            // 100 प्वाइंट नीचे ले जा रहे हैं
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

### क्या Aspose.Slides Java रनटाइम में निष्पादित नहीं किए जा सकने वाले ActiveX नियंत्रणों को पढ़ते और पुनः सहेजते समय संरक्षित रखता है?

हां। Aspose.Slides उन्हें प्रस्तुति का हिस्सा मानता है और उनकी प्रॉपर्टी और फ्रेम को पढ़/संशोधित कर सकता है; नियंत्रणों को स्वयं निष्पादित करने की आवश्यकता नहीं है उन्हें संरक्षित रखने के लिए।

### प्रस्तुति में ActiveX नियंत्रण OLE ऑब्जेक्ट्स से कैसे अलग होते हैं?

ActiveX नियंत्रण इंटरैक्टिव मैनेज्ड नियंत्रण होते हैं (बटन, टेक्स्ट बॉक्स, मीडिया प्लेयर), जबकि [OLE](/slides/hi/java/manage-ole/) एम्बेडेड एप्लिकेशन ऑब्जेक्ट्स को दर्शाता है (जैसे, Excel वर्कशीट)। इन्हें अलग ढंग से संग्रहीत और संभाला जाता है तथा इनके प्रॉपर्टी मॉडल भी अलग होते हैं।

### क्या Aspose.Slides द्वारा फ़ाइल संशोधित करने पर ActiveX इवेंट्स और VBA मैक्रो काम करते हैं?

Aspose.Slides मौजूदा मार्कअप और मेटाडेटा को संरक्षित रखता है; हालांकि, इवेंट्स और मैक्रो केवल विंडोज़ पर PowerPoint के भीतर चलते हैं जब सुरक्षा इसे अनुमति देती है। लाइब्रेरी VBA को निष्पादित नहीं करती है।