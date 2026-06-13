---
title: Python के साथ प्रस्तुतियों में ज़ूम प्रबंधित करें
linktitle: ज़ूम
type: docs
weight: 60
url: /hi/python-net/manage-zoom/
keywords:
- ज़ूम
- ज़ूम फ्रेम
- स्लाइड ज़ूम
- सेक्शन ज़ूम
- सारांश ज़ूम
- ज़ूम जोड़ें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ ज़ूम बनाएं और अनुकूलित करें — सेक्शन के बीच कूदें, थंबनेल और ट्रांज़िशन जोड़ें, PPT, PPTX और ODP प्रस्तुतियों में।"
---
## **परिचय**

PowerPoint में ज़ूम आपको प्रस्तुति के विशिष्ट स्लाइड, सेक्शन और हिस्सों के बीच कूदने की सुविधा देता है। प्रस्तुति देते समय, सामग्री के बीच तेज़ नेविगेशन बहुत उपयोगी हो सकता है।

![overview](overview.png)

* पूरी प्रस्तुति को एकल स्लाइड पर सारांशित करने के लिए, [सारांश ज़ूम](#Summary-Zoom) का उपयोग करें।
* केवल चयनित स्लाइड दिखाने के लिए, [स्लाइड ज़ूम](#Slide-Zoom) का उपयोग करें।
* केवल एक सेक्शन दिखाने के लिए, [सेक्शन ज़ूम](#Section-Zoom) का उपयोग करें।

## **स्लाइड ज़ूम**

स्लाइड ज़ूम आपकी प्रस्तुति को अधिक गतिक बनाता है, जिससे आप किसी भी क्रम में स्लाइड्स के बीच स्वतंत्र रूप से नेविगेट कर सकते हैं बिना प्रस्तुति के प्रवाह को बाधित किए। स्लाइड ज़ूम छोटे प्रस्तुतियों के लिए उपयुक्त हैं जिनमें कई सेक्शन नहीं होते, लेकिन आप उन्हें विभिन्न प्रस्तुति परिदृश्यों में भी उपयोग कर सकते हैं।

स्लाइड ज़ूम आपको कई जानकारी के टुकड़ों में गहराई से जाने की अनुमति देते हैं जबकि आप एक ही कैनवास पर होते हुए महसूस करते हैं।

![slidezoomsel](slidezoomsel.png)

स्लाइड ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [ZoomImageType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/zoomimagetype/) enumeration, [ZoomFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/zoomframe/) क्लास, और [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) क्लास में कुछ मेथड्स प्रदान करता है।

### **ज़ूम फ्रेम बनाना**
आप इस प्रकार स्लाइड पर ज़ूम फ्रेम जोड़ सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उन स्लाइड्स को बनाएं जिनसे आप लिंक करना चाहते हैं।
3. बनाई गई स्लाइड्स में पहचान पाठ और पृष्ठभूमि जोड़ें।
4. पहली स्लाइड में ज़ूम फ्रेम (बनाई गई स्लाइड्स के संदर्भ सहित) जोड़ें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह नमूना कोड आपको स्लाइड में ज़ूम फ्रेम बनाने का तरीका दिखाता है:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #प्रस्तुति में नई स्लाइड्स जोड़ें
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # दूसरी स्लाइड के लिए पृष्ठभूमि बनाएं
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # दूसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाएं
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # तृतीय स्लाइड के लिए पृष्ठभूमि बनाएं
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # तृतीय स्लाइड के लिए टेक्स्ट बॉक्स बनाएं
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #ZoomFrame ऑब्जेक्ट जोड़ें
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # प्रस्तुति सहेजें
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **कस्टम इमेज के साथ ज़ूम फ्रेम बनाना**
Aspose.Slides for Python via .NET के साथ, आप स्लाइड प्रीव्यू इमेज के अलावा किसी अन्य इमेज के साथ ज़ूम फ्रेम इस प्रकार बना सकते हैं:
1. `Presentation` क्लास का एक उदाहरण बनाएं।
2. जिस स्लाइड से आप लिंक करना चाहते हैं, उसे बनाएं।
3. बनी हुई स्लाइड में पहचान पाठ और पृष्ठभूमि जोड़ें।
4. [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट बनाकर इमेज को Presentation के Images कलेक्शन में जोड़ें, जो फ्रेम को भरने के लिए उपयोग होगा।
5. पहली स्लाइड में ज़ूम फ्रेम (बनी हुई स्लाइड के संदर्भ सहित) जोड़ें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह python कोड आपको अलग इमेज के साथ ज़ूम फ्रेम बनाने का तरीका दिखाता है:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #प्रस्तुति में नई स्लाइड जोड़ें
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # दूसरी स्लाइड के लिए पृष्ठभूमि बनाएं
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाएं
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # ज़ूम ऑब्जेक्ट के लिए नई इमेज बनाएं
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #ZoomFrame ऑब्जेक्ट जोड़ें
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # प्रस्तुति सहेजें
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **ज़ूम फ्रेम का फॉर्मेटिंग**
पिछले भागों में हमने सरल ज़ूम फ्रेम बनाने का तरीका दिखाया था। अधिक जटिल ज़ूम फ्रेम बनाने के लिए आपको फ्रेम के फॉर्मेट को बदलना होगा। ज़ूम फ्रेम पर कई फॉर्मेटिंग सेटिंग्स लागू की जा सकती हैं।

आप स्लाइड में ज़ूम फ्रेम का फॉर्मेट इस प्रकार नियंत्रित कर सकते हैं:

1. `Presentation` क्लास का एक उदाहरण बनाएं।
2. लिंक करने के लिए नई स्लाइड्स बनाएं।
3. बनी हुई स्लाइड्स में पहचान पाठ और पृष्ठभूमि जोड़ें।
4. पहली स्लाइड में ज़ूम फ्रेम (बनी हुई स्लाइड्स के संदर्भ सहित) जोड़ें।
5. [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट बनाकर इमेज को Presentation के Images कलेक्शन में जोड़ें, जो फ्रेम को भरने के लिए उपयोग होगा।
6. पहले ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
7. दूसरे ज़ूम फ्रेम ऑब्जेक्ट के लिए लाइन फॉर्मेट बदलें।
8. दूसरे ज़ूम फ्रेम ऑब्जेक्ट की इमेज से पृष्ठभूमि हटाएँ।
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह python नमूना कोड आपको ज़ूम फ्रेम के फॉर्मेटिंग को बदलने का तरीका दिखाता है:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #प्रस्तुति में नई स्लाइड्स जोड़ें
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # दूसरी स्लाइड के लिए पृष्ठभूमि बनाएं
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # दूसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाएं
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # तृतीय स्लाइड के लिए पृष्ठभूमि बनाएं
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # तृतीय स्लाइड के लिए टेक्स्ट बॉक्स बनाएं
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #ZoomFrame ऑब्जेक्ट जोड़ें
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # ज़ूम ऑब्जेक्ट के लिए नई इमेज बनाएं
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # zoomFrame1 ऑब्जेक्ट के लिए कस्टम इमेज सेट करें
    zoomFrame1.image = image

    # zoomFrame2 ऑब्जेक्ट के लिए ज़ूम फ्रेम फॉर्मेट सेट करें
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # zoomFrame2 ऑब्जेक्ट के लिए पृष्ठभूमि न दिखाएँ
    zoomFrame2.show_background = False

    # प्रस्तुति सहेजें
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **सेक्शन ज़ूम**

सेक्शन ज़ूम आपके प्रस्तुति में एक सेक्शन का लिंक होता है। आप सेक्शन ज़ूम का उपयोग उन सेक्शनों पर वापस जाने के लिए कर सकते हैं जिन्हें आप विशेष रूप से ज़ोर देना चाहते हैं। या आप इसका उपयोग यह दिखाने के लिए कर सकते हैं कि आपकी प्रस्तुति के विभिन्न हिस्से कैसे आपस में जुड़े हैं।

![seczoomsel](seczoomsel.png)

सेक्शन ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [SectionZoomFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectionzoomframe/) क्लास और [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) क्लास के तहत कुछ मेथड्स प्रदान करता है।

### **सेक्शन ज़ूम फ्रेम बनाना**

आप इस प्रकार स्लाइड पर सेक्शन ज़ूम फ्रेम जोड़ सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. एक नई स्लाइड बनाएं।
3. बनी हुई स्लाइड में पहचान पृष्ठभूमि जोड़ें।
4. एक नया सेक्शन बनाएं जिससे आप ज़ूम फ्रेम लिंक करना चाहते हैं।
5. पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बने हुए सेक्शन के संदर्भ सहित) जोड़ें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह python कोड आपको स्लाइड में ज़ूम फ्रेम बनाने का तरीका दिखाता है:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # प्रस्तुति में नया सेक्शन जोड़ता है
    pres.sections.add_section("Section 1", slide)

    # SectionZoomFrame ऑब्जेक्ट जोड़ता है
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # प्रस्तुति सहेजता है
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **कस्टम इमेज के साथ सेक्शन ज़ूम फ्रेम बनाना**

Aspose.Slides for Python के साथ, आप अलग स्लाइड प्रीव्यू इमेज के साथ सेक्शन ज़ूम फ्रेम इस प्रकार बना सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. एक नई स्लाइड बनाएं।
3. बनी हुई स्लाइड में पहचान पृष्ठभूमि जोड़ें।
4. एक नया सेक्शन बनाएं जिससे आप ज़ूम फ्रेम लिंक करना चाहते हैं।
5. [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट बनाकर इमेज को Presentation के Images कलेक्शन में जोड़ें, जो फ्रेम को भरने के लिए उपयोग होगा।
6. पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बने हुए सेक्शन के संदर्भ सहित) जोड़ें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह python कोड आपको अलग इमेज के साथ ज़ूम फ्रेम बनाने का तरीका दिखाता है:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # प्रस्तुति में नया सेक्शन जोड़ता है
    pres.sections.add_section("Section 1", slide)

    # ज़ूम ऑब्जेक्ट के लिए नई इमेज बनाता है
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # SectionZoomFrame ऑब्जेक्ट जोड़ता है
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # प्रस्तुति सहेजता है
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **सेक्शन ज़ूम फ्रेम का फॉर्मेटिंग**

अधिक जटिल सेक्शन ज़ूम फ्रेम बनाने के लिए आपको सरल फ्रेम के फॉर्मेट को बदलना होगा। सेक्शन ज़ूम फ्रेम पर कई फॉर्मेटिंग विकल्प लागू किए जा सकते हैं।

आप स्लाइड में सेक्शन ज़ूम फ्रेम के फॉर्मेट को इस प्रकार नियंत्रित कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. एक नई स्लाइड बनाएं।
3. बनी हुई स्लाइड में पहचान पृष्ठभूमि जोड़ें।
4. एक नया सेक्शन बनाएं जिससे आप ज़ूम फ्रेम लिंक करना चाहते हैं।
5. पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बने हुए सेक्शन के संदर्भ सहित) जोड़ें।
6. बने हुए सेक्शन ज़ूम ऑब्जेक्ट का आकार और स्थिति बदलें।
7. [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट बनाकर इमेज को Presentation के Images कलेक्शन में जोड़ें, जो फ्रेम को भरने के लिए उपयोग होगा।
8. बने हुए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
9. *लिंक किए गए सेक्शन से मूल स्लाइड पर लौटने* की सुविधा सेट करें।
10. सेक्शन ज़ूम फ्रेम ऑब्जेक्ट की इमेज से पृष्ठभूमि हटाएँ।
11. दूसरे ज़ूम फ्रेम ऑब्जेक्ट की लाइन फॉर्मेट बदलें।
12. ट्रांज़िशन की अवधि बदलें।
13. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह python कोड आपको सेक्शन ज़ूम फ्रेम के फॉर्मेटिंग को बदलने का तरीका दिखाता है:

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # प्रस्तुति में नया सेक्शन जोड़ता है
    pres.sections.add_section("Section 1", slide)

    # SectionZoomFrame ऑब्जेक्ट जोड़ें
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # SectionZoomFrame के लिए फॉर्मेटिंग
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # प्रस्तुति सहेजता है
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **सारांश ज़ूम**

सारांश ज़ूम एक लैंडिंग पेज की तरह है जहाँ आपकी प्रस्तुति के सभी हिस्से एक साथ दिखाए जाते हैं। जब आप प्रस्तुति दे रहे हों, तो आप ज़ूम का उपयोग करके अपनी प्रस्तुति में कहीं से भी किसी अन्य स्थान पर किसी भी क्रम में जा सकते हैं। आप रचनात्मक हो सकते हैं, आगे स्किप कर सकते हैं, या स्लाइड शो के हिस्सों को बिना प्रवाह बाधित किए फिर से देख सकते हैं।

![overview_image](summaryzoom.png)

सारांश ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [SummaryZoomFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/summaryzoomsection/), और [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/summaryzoomsectioncollection/) क्लास और [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) क्लास के तहत कुछ मेथड्स प्रदान करता है।

### **सारांश ज़ूम बनाना**

आप इस प्रकार स्लाइड पर सारांश ज़ूम फ्रेम जोड़ सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. पहचान पृष्ठभूमि और नए सेक्शनों के साथ नई स्लाइड्स बनाएं।
3. पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह python कोड आपको स्लाइड पर सारांश ज़ूम फ्रेम बनाने का तरीका दिखाता है:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Create slides की एरे बनाएं
    for slideNumber in range(5):
        #Add नई स्लाइड्स को प्रस्तुति में जोड़ें
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Create स्लाइड के लिए पृष्ठभूमि बनाएं
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Create स्लाइड के लिए टेक्स्ट बॉक्स बनाएं
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Create पहली स्लाइड में सभी स्लाइड्स के लिए ज़ूम ऑब्जेक्ट बनाएं
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Set ReturnToParent प्रॉपर्टी सेट करें जिससे पहली स्लाइड पर वापस आएँ
        zoomFrame.return_to_parent = True

    # Save प्रस्तुति सहेजें
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **सारांश ज़ूम सेक्शन जोड़ना और हटाना**

सारांश ज़ूम फ्रेम में सभी सेक्शन [SummaryZoomSection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/summaryzoomsection/) ऑब्जेक्ट्स द्वारा प्रतिनिधित्व किए जाते हैं, जो [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/summaryzoomsectioncollection/) ऑब्जेक्ट में संग्रहीत होते हैं। आप इस क्लास के माध्यम से सारांश ज़ूम सेक्शन ऑब्जेक्ट को जोड़ या हटा सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. पहचान पृष्ठभूमि और नए सेक्शन के साथ नई स्लाइड्स बनाएं।
3. पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4. प्रस्तुति में एक नई स्लाइड और सेक्शन जोड़ें।
5. बने हुए सेक्शन को सारांश ज़ूम फ्रेम में जोड़ें।
6. सारांश ज़ूम फ्रेम से पहली सेक्शन हटाएँ।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह python कोड आपको सारांश ज़ूम फ्रेम में सेक्शन जोड़ने और हटाने का तरीका दिखाता है:

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # प्रस्तुति में नया सेक्शन जोड़ता है
    pres.sections.add_section("Section 1", slide)

    #प्रस्तुति में नई 슬ाइड जोड़ता है
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # प्रस्तुति में नया सेक्शन जोड़ता है
    pres.sections.add_section("Section 2", slide)

    # SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # प्रस्तुति में नया सेक्शन जोड़ता है
    section3 = pres.sections.add_section("Section 3", slide)

    # Summary Zoom में सेक्शन जोड़ता है
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Summary Zoom से सेक्शन हटाता है
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # प्रस्तुति सहेजता है
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **सारांश ज़ूम सेक्शन का फॉर्मेटिंग**

अधिक जटिल सारांश ज़ूम सेक्शन ऑब्जेक्ट बनाने के लिए आपको सरल फ्रेम के फॉर्मेट को बदलना होगा। सारांश ज़ूम सेक्शन ऑब्जेक्ट पर कई फॉर्मेटिंग विकल्प लागू किए जा सकते हैं।

आप सारांश ज़ूम फ्रेम में सेक्शन ऑब्जेक्ट के फॉर्मेट को इस प्रकार नियंत्रित कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. पहचान पृष्ठभूमि और नए सेक्शन के साथ नई स्लाइड्स बनाएं।
3. पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4. `SummaryZoomSectionCollection` से पहले ऑब्जेक्ट के लिए सारांश ज़ूम सेक्शन ऑब्जेक्ट प्राप्त करें।
5. [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट बनाकर इमेज को Presentation के Images कलेक्शन में जोड़ें, जो फ्रेम को भरने के लिए उपयोग होगा।
6. बने हुए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
7. *लिंक किए गए सेक्शन से मूल स्लाइड पर लौटने* की सुविधा सेट करें।
8. दूसरे ज़ूम फ्रेम ऑब्जेक्ट की लाइन फॉर्मेट बदलें।
9. ट्रांज़िशन की अवधि बदलें।
10. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह python कोड आपको सारांश ज़ूम सेक्शन ऑब्जेक्ट के फॉर्मेटिंग को बदलने का तरीका दिखाता है:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # प्रस्तुति में नया सेक्शन जोड़ता है
    pres.sections.add_section("Section 1", slide)

    #प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # प्रस्तुति में नया सेक्शन जोड़ता है
    pres.sections.add_section("Section 2", slide)

    # SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # पहले SummaryZoomSection ऑब्जेक्ट प्राप्त करता है
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # SummaryZoomSection ऑब्जेक्ट के लिए फॉर्मेटिंग
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # प्रस्तुति सहेजता है
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**क्या मैं लक्ष्य दिखाने के बाद 'पैरेंट' स्लाइड पर लौटने को नियंत्रित कर सकता हूँ?**

हाँ। [Zoom frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/zoomframe/) या [section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectionzoomframe/) में `return_to_parent` व्यवहार होता है जिसे सक्षम करने पर दर्शक लक्ष्य सामग्री देखने के बाद मूल स्लाइड पर वापस लौटते हैं।

**क्या मैं ज़ूम ट्रांज़िशन की 'स्पीड' या अवधि समायोजित कर सकता हूँ?**

हाँ। ज़ूम `transition_duration` सेट करने का समर्थन करता है जिससे आप एनीमेशन की अवधि को नियंत्रित कर सकते हैं।

**क्या प्रस्तुति में ज़ूम ऑब्जेक्ट्स की संख्या पर कोई सीमा है?**

कोई कठोर API सीमा दस्तावेज़ित नहीं है। व्यावहारिक सीमाएँ कुल प्रस्तुति की जटिलता और दर्शक की प्रदर्शन क्षमता पर निर्भर करती हैं। आप कई ज़ूम फ्रेम जोड़ सकते हैं, लेकिन फ़ाइल आकार और रेंडरिंग समय को ध्यान में रखें।