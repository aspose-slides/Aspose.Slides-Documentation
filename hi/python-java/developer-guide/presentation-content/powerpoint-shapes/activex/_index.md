---
title: Python का उपयोग करके प्रस्तुतियों में ActiveX नियंत्रण प्रबंधित करना
linktitle: ActiveX
type: docs
weight: 80
url: /hi/python-java/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX प्रबंधन
- ActiveX जोड़ना
- ActiveX संशोधित करना
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "जानिए कैसे Aspose.Slides for Python via Java ActiveX का उपयोग करके PowerPoint प्रस्तुतियों को स्वचालित और उन्नत करता है, जिससे विकसकों को स्लाइड्स पर शक्तिशाली नियंत्रण मिलता है।"
---
## **परिचय**

ActiveX नियंत्रण प्रस्तुतियों में उपयोग किए जाते हैं। Aspose.Slides for Python via Java आपको ActiveX नियंत्रण जोड़ने और प्रबंधित करने की अनुमति देता है, लेकिन वे सामान्य प्रस्तुति आकारों की तुलना में थोड़ा जटिल होते हैं। Aspose.Slides Media Player ActiveX नियंत्रण जोड़ने का समर्थन करता है। ध्यान दें कि ActiveX नियंत्रण आकार नहीं होते; वे प्रस्तुति के [ShapeCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/) का हिस्सा नहीं हैं। वे इसके बजाय अलग [ControlCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/controlcollection/) का हिस्सा होते हैं। इस विषय में, हम आपको दिखाएंगे कि उनके साथ कैसे काम किया जाए।

## **स्लाइड में Media Player ActiveX नियंत्रण जोड़ें**

ActiveX Media Player नियंत्रण जोड़ने के लिए, निम्न कार्य करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं और एक खाली प्रस्तुति इंस्टेंस उत्पन्न करें।  
2. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) में लक्षित स्लाइड तक पहुंचें।  
3. [ControlCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/controlcollection/) द्वारा प्रदत्त [addControl](https://reference.aspose.com/slides/hi/python-java/aspose.slides/controlcollection/#addControl) मेथड का उपयोग कर Media Player ActiveX नियंत्रण जोड़ें।  
4. Media Player ActiveX नियंत्रण तक पहुंचें और उसकी प्रॉपर्टीज़ का उपयोग करके वीडियो पथ सेट करें।  
5. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह नमूना कोड, ऊपर बताए गए चरणों पर आधारित, स्लाइड में Media Player ActiveX नियंत्रण जोड़ने का तरीका दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# एक खाली प्रस्तुति बनाएँ।
presentation = Presentation()
try:
    # Media Player ActiveX नियंत्रण जोड़ें।
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # वीडियो पथ सेट करें।
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # प्रस्तुति सहेजें।
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ActiveX नियंत्रण को संशोधित करें**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java ActiveX नियंत्रणों के प्रबंधन के लिए घटक प्रदान करता है। आप अपनी प्रस्तुति में पहले से जोड़े गए ActiveX नियंत्रण तक पहुंच सकते हैं और उसकी प्रॉपर्टीज़ के माध्यम से उसे संशोधित या हटाया जा सकता है।
{{% /alert %}}

स्लाइड पर टेक्स्ट बॉक्स और साधारण कमांड बटन जैसे सरल ActiveX नियंत्रण को प्रबंधित करने के लिए, निम्न कार्य करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं और उसमें ActiveX नियंत्रणों वाली प्रस्तुति लोड करें।  
2. उसका इंडेक्स द्वारा स्लाइड संदर्भ प्राप्त करें।  
3. स्लाइड में [ControlCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/controlcollection/) तक पहुंचकर ActiveX नियंत्रणों तक पहुंचें।  
4. [Control](https://reference.aspose.com/slides/hi/python-java/aspose.slides/control/) ऑब्जेक्ट का उपयोग करके TextBox1 ActiveX नियंत्रण तक पहुंचें।  
5. TextBox1 ActiveX नियंत्रण की प्रॉपर्टीज़ जैसे टेक्स्ट, फ़ॉन्ट, फ़ॉन्ट ऊँचाई और फ्रेम स्थिति बदलें।  
6. CommandButton1 नामक दूसरे ActiveX नियंत्रण तक पहुंचें।  
7. बटन का शीर्षक, फ़ॉन्ट और स्थिति बदलें।  
8. ActiveX नियंत्रणों के फ्रेम की स्थिति को स्थानांतरित करें।  
9. संशोधित प्रस्तुति को PPTM फ़ाइल के रूप में लिखें।

यह नमूना कोड, ऊपर बताए गए चरणों पर आधारित, एक सरल ActiveX नियंत्रण के प्रबंधन का तरीका दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# ActiveX नियंत्रणों के साथ प्रस्तुति लोड करें।
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # पहली स्लाइड तक पहुंचें।
        slide = presentation.getSlides().get_Item(0)

        # टेक्स्ट बॉक्स का टेक्स्ट बदलें।
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # प्रतिस्थापन छवि बदलें। PowerPoint ActiveX सक्रियण के दौरान इसे बदल देता है,
            # इसलिए यह कभी-कभी जैसा का तैसा रह सकता है।
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # बटन का शीर्षक बदलें।
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # प्रतिस्थापन छवि बदलें।
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # नियंत्रणों को 100 पॉइंट नीचे ले जाएँ।
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # नियंत्रणों को हटाएँ।
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides सक्रिय नियंत्रणों को पढ़ते और पुनः‑सहेजते समय संरक्षित रखता है यदि उन्हें Python रनटाइम में निष्पादित नहीं किया जा सकता?**

हाँ। Aspose.Slides उन्हें प्रस्तुति का हिस्सा मानता है और उनकी प्रॉपर्टीज़ और फ्रेम को पढ़/संशोधित कर सकता है; नियंत्रनों को स्वयं निष्पादित करना इनको संरक्षित रखने के लिए आवश्यक नहीं है।

**ActiveX नियंत्रण प्रस्तुति में OLE ऑब्जेक्ट्स से कैसे भिन्न होते हैं?**

ActiveX नियंत्रण इंटरैक्टिव प्रबंधित नियंत्रण होते हैं (बटन, टेक्स्ट बॉक्स, मीडिया प्लेयर), जबकि [OLE](/slides/hi/python-java/manage-ole/) एम्बेडेड एप्लिकेशन ऑब्जेक्ट्स को दर्शाता है (उदाहरण के लिए, एक Excel वर्कशीट)। वे अलग तरीके से संग्रहीत और संभाले जाते हैं और उनकी प्रॉपर्टी मॉडल अलग होती है।

**यदि फ़ाइल को Aspose.Slides द्वारा संशोधित किया गया हो तो क्या ActiveX इवेंट्स और VBA मैक्रो काम करते हैं?**

Aspose.Slides मौजूदा मार्कअप और मेटाडेटा को संरक्षित रखता है; हालांकि, इवेंट्स और मैक्रो केवल Windows पर PowerPoint में ही चलाते हैं जब सुरक्षा अनुमति देती है। यह लाइब्रेरी VBA को निष्पादित नहीं करती।