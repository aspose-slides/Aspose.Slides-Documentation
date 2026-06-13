---
title: Python के साथ प्रस्तुतियों में ActiveX नियंत्रणों का प्रबंधन
linktitle: ActiveX
type: docs
weight: 80
url: /hi/python-net/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX प्रबंधन
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "जाने कैसे Aspose.Slides for Python via .NET ActiveX का उपयोग करके PowerPoint प्रस्तुतियों को स्वचालित और सुधारता है, जिससे डेवलपर्स को स्लाइड्स पर शक्तिशाली नियंत्रण मिलता है।"
---
## **परिचय**

ActiveX नियंत्रणों का उपयोग प्रस्तुतियों में किया जाता है। Aspose.Slides for Python via .NET आपको ActiveX नियंत्रणों को प्रबंधित करने की अनुमति देता है, लेकिन उनका प्रबंधन थोड़ा अधिक जटिल और सामान्य प्रस्तुति आकारों से अलग होता है। Aspose.Slides for Python via .NET 6.9.0 से, घटक ActiveX नियंत्रणों के प्रबंधन का समर्थन करता है। वर्तमान में, आप अपनी प्रस्तुति में पहले से जोड़े गए ActiveX नियंत्रण तक पहुंच सकते हैं और उसकी विभिन्न गुणों का उपयोग करके उसे संशोधित या हटाई सकते हैं। याद रखें, ActiveX नियंत्रण आकार नहीं होते और प्रस्तुतिकरण की IShapeCollection का हिस्सा नहीं, बल्कि अलग IControlCollection का भाग होते हैं। यह लेख दिखाता है कि इनके साथ कैसे काम किया जाए।

## **ActiveX नियंत्रणों को संशोधित करें**
1. Presentation वर्ग की एक इंस्टेंस बनाएं और उस प्रस्तुति को लोड करें जिसमें ActiveX नियंत्रण हों।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. IControlCollection तक पहुँचकर स्लाइड में ActiveX नियंत्रणों तक पहुँचें।
4. ControlEx ऑब्जेक्ट का उपयोग करके TextBox1 ActiveX नियंत्रण तक पहुँचें।
5. TextBox1 ActiveX नियंत्रण की विभिन्न गुणों जैसे पाठ, फ़ॉन्ट, फ़ॉन्ट ऊँचाई और फ्रेम स्थिति को बदलें।
6. CommandButton1 नामक दूसरे एक्सेस नियंत्रण तक पहुँचें।
7. बटन का कैप्शन, फ़ॉन्ट और स्थिति बदलें।
8. ActiveX नियंत्रण फ्रेमों की स्थिति को शिफ्ट करें।
9. संशोधित प्रस्तुति को एक PPTX फ़ाइल में लिखें।

नीचे दिया गया कोड स्निपेट प्रस्तुति स्लाइडों पर ActiveX नियंत्रणों को नीचे दिखाए अनुसार अपडेट करता है।

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# ActiveX नियंत्रणों के साथ प्रस्तुति तक पहुंचना
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # प्रस्तुति में पहली स्लाइड तक पहुंचना
    slide = presentation.slides[0]

    # changing TextBox text
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # प्रतिस्थापित चित्र बदलना। PowerPoint सक्रियण के दौरान इस चित्र को बदल देगा, इसलिए कभी‑कभी इसे अपरिवर्तित छोड़ना ठीक रहता है।

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # बटन कैप्शन बदलना
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # प्रतिस्थापन बदलना
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # ActiveX फ्रेम को 100 पॉइंट नीचे ले जाना
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # संपादित ActiveX नियंत्रणों के साथ प्रस्तुति सहेजें
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # अब नियंत्रणों को हटा रहे हैं
    slide.controls.clear()

    # साफ़ किए गए ActiveX नियंत्रणों के साथ प्रस्तुति सहेजना
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX मीडिया प्लेयर नियंत्रण जोड़ें**
ActiveX Media Player नियंत्रण जोड़ने के लिए, कृपया निम्नलिखित चरणों को पूरा करें:

1. Presentation वर्ग की एक इंस्टेंस बनाएं और नमूना प्रस्तुति को लोड करें जिसमें Media Player ActiveX नियंत्रण हों।
2. लक्ष्य Presentation वर्ग की एक इंस्टेंस बनाएं और एक खाली प्रस्तुति इंस्टेंस उत्पन्न करें।
3. टेम्पलेट प्रस्तुति में Media Player ActiveX नियंत्रण वाली स्लाइड को लक्ष्य Presentation में क्लोन करें।
4. लक्ष्य Presentation में क्लोन की गई स्लाइड तक पहुँचें।
5. IControlCollection तक पहुँचकर स्लाइड में ActiveX नियंत्रणों तक पहुँचें।
6. Media Player ActiveX नियंत्रण तक पहुँचें और उसकी गुणों का उपयोग करके वीडियो पथ सेट करें।
7. प्रस्तुति को एक PPTX फ़ाइल में सहेजें।

```py
import aspose.slides as slides

# PPTX फ़ाइल का प्रतिनिधित्व करने वाला Presentation वर्ग बनाएं
with slides.Presentation(path + "template.pptx") as presentation:

    # खाली प्रस्तुति इंस्टेंस बनाएं
    with slides.Presentation() as newPresentation:

        # डिफ़ॉल्ट स्लाइड हटाएँ
        newPresentation.slides.remove_at(0)

        # Media Player ActiveX नियंत्रण वाली स्लाइड को क्लोन करें
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Media Player ActiveX नियंत्रण तक पहुंचें और वीडियो पथ सेट करें
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # प्रस्तुति सहेजें
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides पढ़ते और पुनः सहेजते समय ActiveX नियंत्रणों को संरक्षित करता है यदि उन्हें Python रनटाइम में निष्पादित नहीं किया जा सकता?**

हाँ। Aspose.Slides उन्हें प्रस्तुति का हिस्सा मानता है और उनके गुणों और फ्रेमों को पढ़/संशोधित कर सकता है; नियंत्रणों को स्वयं निष्पादित करना उनके संरक्षण के लिए आवश्यक नहीं है।

**ActiveX नियंत्रण प्रस्तुति में OLE वस्तुओं से कैसे अलग होते हैं?**

ActiveX नियंत्रण इंटरैक्टिव प्रबंधित नियंत्रण होते हैं (बटन, टेक्स्ट बॉक्स, मीडिया प्लेयर), जबकि [OLE](/slides/hi/python-net/manage-ole/) एंबेडेड एप्लिकेशन वस्तुओं को दर्शाता है (उदाहरण के लिए, एक Excel वर्कशीट)। इन्हें अलग तरीके से संग्रहित और संभाला जाता है और इनके गुण मॉडल अलग होते हैं।

**क्या फाइल को Aspose.Slides द्वारा संशोधित करने पर ActiveX इवेंट्स और VBA मैक्रो काम करते हैं?**

Aspose.Slides मौजूदा मार्कअप और मेटाडाटा को संरक्षित रखता है; हालांकि, इवेंट्स और मैक्रो केवल Windows पर PowerPoint के भीतर चलते हैं जब सुरक्षा अनुमति देती है। लाइब्रेरी VBA को निष्पादित नहीं करती।