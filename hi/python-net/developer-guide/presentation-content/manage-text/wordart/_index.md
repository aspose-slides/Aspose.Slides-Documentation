---
title: Python में WordArt इफ़ेक्ट बनाना और लागू करना
linktitle: WordArt
type: docs
weight: 110
url: /hi/python-net/wordart/
keywords:
  - WordArt
  - WordArt बनाना
  - WordArt टेम्प्लेट
  - WordArt इफ़ेक्ट
  - छाया इफ़ेक्ट
  - डिस्प्ले इफ़ेक्ट
  - ग्लो इफ़ेक्ट
  - WordArt ट्रांसफ़ॉर्मेशन
  - 3D इफ़ेक्ट
  - आउटर शैडो इफ़ेक्ट
  - इनर शैडो इफ़ेक्ट
  - Python
  - Aspose.Slides
description: "Aspose.Slides for Python via .NET में WordArt इफ़ेक्ट बनाना और अनुकूलित करना सीखें। यह चरण‑दर‑चरण मार्गदर्शिका डेवलपर्स को Python में स्टाइलिश, पेशेवर टेक्स्ट के साथ प्रस्तुतियों को बेहतर बनाने में मदद करती है।"
---
## **सारांश**

WordArt इफ़ेक्ट आपको PowerPoint प्रस्तुतियों में दृश्यात्मक रूप से आकर्षक, शैलीबद्ध टेक्स्ट जोड़ने की अनुमति देता है। Aspose.Slides के साथ, डेवलपर्स प्रोग्रामेटिक रूप से WordArt बना, अनुकूलित और प्रबंधित कर सकते हैं, ठीक Microsoft PowerPoint की तरह—बिना Office इंस्टॉल किए। यह लेख WordArt के साथ काम करने का एक अवलोकन प्रदान करता है, जिसमें टेक्स्ट ट्रांसफ़ॉर्मेशन, फ़िल स्टाइल, आउटलाइन, शैडो और अन्य फ़ॉर्मेटिंग विकल्पों को लागू करके आपकी प्रस्तुति सामग्री को अधिक अभिव्यक्तिपूर्ण और आकर्षक बनाया जाता है। WordArt आपको टेक्स्ट को एक ग्राफ़िकल ऑब्जेक्ट के रूप में व्यवहार करने देता है। यह टेक्स्ट पर लागू किए गए इफ़ेक्ट या विशेष संशोधनों का समूह है जिससे वह अधिक आकर्षक या ध्यान देने योग्य बनता है।

**Microsoft PowerPoint में WordArt**

Microsoft PowerPoint में WordArt का उपयोग करने के लिए, आपको पूर्वनिर्धारित WordArt टेम्प्लेट में से एक चुनना होगा। एक WordArt टेम्प्लेट प्रभावों का सेट होता है जो टेक्स्ट या उसकी आकृति पर लागू किया जाता है।

**Aspose.Slides में WordArt**

Aspose.Slides for Python via .NET 20.10 में हमने WordArt के समर्थन को लागू किया और बाद की Aspose.Slides for Python via .NET रिलीज़ में इस फीचर में सुधार किया।

Aspose.Slides for Python via .NET के साथ, आप Python में अपना स्वयं का WordArt टेम्प्लेट (एक प्रभाव या कई प्रभावों का संयोजन) आसानी से बना सकते हैं और इसे टेक्स्ट पर लागू कर सकते हैं।

## सरल WordArt टेम्प्लेट बनाना और इसे पाठ पर लागू करना

**Aspose.Slides का उपयोग करना** 

पहले, हम इस Python कोड का उपयोग करके सरल टेक्स्ट बनाते हैं:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
अब, हम इस कोड के माध्यम से प्रभाव को अधिक स्पष्ट बनाने के लिए टेक्स्ट का फ़ॉन्ट ऊँचाई बड़ा सेट करते हैं:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Microsoft PowerPoint का उपयोग करना**

Microsoft PowerPoint में WordArt इफ़ेक्ट मेनू पर जाएँ:

![todo:image_alt_text](image-20200930113926-1.png)

दाएँ मेनू से आप पूर्वनिर्धारित WordArt इफ़ेक्ट चुन सकते हैं। बाएँ मेनू से आप नई WordArt के लिए सेटिंग्स निर्दिष्ट कर सकते हैं।

यहाँ कुछ उपलब्ध पैरामीटर या विकल्प हैं:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides का उपयोग करना**

यहाँ, हम टेक्स्ट पर SmallGrid पैटर्न रंग लागू करते हैं और इस कोड के साथ 1‑पिक्सेल चौड़ाई का काला टेक्स्ट बॉर्डर जोड़ते हैं:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

परिणामी टेक्स्ट:

![todo:image_alt_text](image-20200930114108-4.png)

## अन्य WordArt प्रभाव लागू करना

**Microsoft PowerPoint का उपयोग करना**

प्रोग्राम के इंटरफ़ेस से आप यह इफ़ेक्ट टेक्स्ट, टेक्स्ट ब्लॉक, शैप या समान तत्व पर लागू कर सकते हैं:

![todo:image_alt_text](image-20200930114129-5.png)

उदाहरण के तौर पर, Shadow, Reflection और Glow इफ़ेक्ट टेक्स्ट पर लागू किए जा सकते हैं; 3D Format और 3D Rotation इफ़ेक्ट टेक्स्ट ब्लॉक पर लागू किए जा सकते हैं; Soft Edges प्रॉपर्टी Shape ऑब्जेक्ट पर लागू की जा सकती है (यदि 3D Format प्रॉपर्टी सेट नहीं है तो भी इसका असर रहता है)।

### छाया प्रभाव लागू करना

यहाँ, हम केवल टेक्स्ट से संबंधित गुण सेट करने का इरादा रखते हैं। हम Python में इस कोड का उपयोग करके टेक्स्ट पर शैडो इफ़ेक्ट लागू करते हैं:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Aspose.Slides API तीन प्रकार की शैडोज़ का समर्थन करता है: OuterShadow, InnerShadow, और PresetShadow।

PresetShadow के साथ, आप प्रीसैट मानों का उपयोग करके टेक्स्ट पर शैडो लागू कर सकते हैं।

**Microsoft PowerPoint का उपयोग करना**

PowerPoint में आप केवल एक प्रकार की शैडो का उपयोग कर सकते हैं। यहाँ एक उदाहरण है:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides का उपयोग करना**

Aspose.Slides वास्तव में एक साथ दो प्रकार की शैडोज़ लागू करने देता है: InnerShadow और PresetShadow।

**नोट्स:**

- जब OuterShadow और PresetShadow को एक साथ उपयोग किया जाता है, तो केवल OuterShadow इफ़ेक्ट लागू होता है।  
- यदि OuterShadow और InnerShadow एक साथ उपयोग किए जाते हैं, तो लागू इफ़ेक्ट PowerPoint संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में इफ़ेक्ट दो गुना हो जाता है। लेकिन PowerPoint 2007 में OuterShadow इफ़ेक्ट लागू होता है।

### टेक्स्ट पर डिस्प्ले लागू करना

हम इस Python कोड नमूने के माध्यम से टेक्स्ट पर डिस्प्ले जोड़ते हैं:

```py 
    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5 
    portion.portion_format.effect_format.reflection_effect.distance = 4.72 
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0 
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90 
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100 
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT  
```

### टेक्स्ट पर ग्लो प्रभाव लागू करना

हम इस कोड का उपयोग करके टेक्स्ट पर ग्लो इफ़ेक्ट लागू करते हैं जिससे वह चमके या बाहर निकलें:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

ऑपरेशन का परिणाम:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
आप शैडो, डिस्प्ले और ग्लो के पैरामीटर बदल सकते हैं। प्रभावों के गुण प्रत्येक टेक्स्ट हिस्से पर अलग‑अलग सेट होते हैं। 
{{% /alert %}} 

### WordArt में ट्रांसफ़ॉर्मेशन का उपयोग करना

हम इस कोड के द्वारा पूरे टेक्स्ट ब्लॉक में निहित Transform प्रॉपर्टी का उपयोग करते हैं:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

परिणाम:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint और Aspose.Slides for Python via .NET दोनों कुछ पूर्वनिर्धारित ट्रांसफ़ॉर्मेशन प्रकार प्रदान करते हैं। 
{{% /alert %}} 

**PowerPoint का उपयोग करना**

प्रीडिफाइनड ट्रांसफ़ॉर्मेशन प्रकार तक पहुँचने के लिए: **Format** -> **TextEffect** -> **Transform**।

**Aspose.Slides का उपयोग करना**

ट्रांसफ़ॉर्मेशन प्रकार चुनने के लिए, TextShapeType enum का उपयोग करें।

### टेक्स्ट और शैप्स पर 3D इफ़ेक्ट लागू करना

हम इस नमूना कोड का उपयोग करके टेक्स्ट शैप पर 3D इफ़ेक्ट सेट करते हैं:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

परिणामी टेक्स्ट और उसकी शैप:

![todo:image_alt_text](image-20200930114816-9.png)

हम इस Python कोड के साथ टेक्स्ट पर 3D इफ़ेक्ट लागू करते हैं:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

ऑपरेशन का परिणाम:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
टेक्स्ट या उनकी शैप्स पर 3D इफ़ेक्ट्स के लागू करने और इफ़ेक्ट्स के बीच इंटरैक्शन कुछ नियमों पर आधारित होते हैं। 

एक टेक्स्ट और उसे सम्मिलित करने वाली शैप के लिए सीन को विचार करें। 3D इफ़ेक्ट में 3D ऑब्जेक्ट प्रतिनिधित्व और वह सीन होता है जिस पर ऑब्जेक्ट रखा गया है। 

- जब दोनों फ़िगर और टेक्स्ट दोनों के लिए सीन सेट किया जाता है, तो फ़िगर सीन को अधिक प्राथमिकता मिलती है—टेक्स्ट सीन को नजरअंदाज़ किया जाता है।  
- जब फ़िगर के पास अपना सीन नहीं होता लेकिन 3D प्रतिनिधित्व है, तो टेक्स्ट सीन का उपयोग किया जाता है।  
- अन्यथा—जब शैप मूलतः 3D इफ़ेक्ट नहीं रखता, तो शैप फ्लैट रहता है और 3D इफ़ेक्ट केवल टेक्स्ट पर लागू होता है।  

विवरण [ThreeDFormat.LightRig](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/) और [ThreeDFormat.Camera](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/) प्रॉपर्टीज़ से जुड़े हैं। 
{{% /alert %}} 

## **टेक्स्ट पर आउटर शैडो इफ़ेक्ट लागू करना**
Aspose.Slides for Python via .NET नीचे दिए गए [**IOuterShadow**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/ioutershadow/) और [**IInnerShadow**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/iinnershadow/) क्लासेज़ प्रदान करता है जो TextFrame द्वारा रखे टेक्स्ट पर शैडो इफ़ेक्ट लागू करने की अनुमति देते हैं। इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टैंस बनाएँ।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड में Rectangle प्रकार का एक AutoShape जोड़ें।  
4. AutoShape से जुड़े TextFrame तक पहुँचें।  
5. AutoShape का FillType NoFill पर सेट करें।  
6. OuterShadow क्लास का इंस्टैंस बनाएँ।  
7. शैडो का BlurRadius सेट करें।  
8. शैडो की Direction सेट करें।  
9. शैडो की Distance सेट करें।  
10. RectanglelAlign को TopLeft पर सेट करें।  
11. शैडो का PresetColor Black पर सेट करें।  
12. प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह Python नमूना कोड—ऊपर दिए गए चरणों का कार्यान्वयन—आपको टेक्स्ट पर आउटर शैडो इफ़ेक्ट लागू करने का तरीका दिखाता है:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # स्लाइड का संदर्भ प्राप्त करें
    sld = pres.slides[0]

    # Rectangle प्रकार का AutoShape जोड़ें
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Rectangle में TextFrame जोड़ें
    ashp.add_text_frame("Aspose TextBox")

    # यदि हम टेक्स्ट की शैडो प्राप्त करना चाहते हैं तो शैप फ़िल को अक्षम करें
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # बाहरी शैडो जोड़ें और सभी आवश्यक पैरामीटर सेट करें
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Write the presentation to disk
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **शेप्स पर इनर शैडो इफ़ेक्ट लागू करना**
इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टैंस बनाएँ।  
2. स्लाइड का रेफ़रेंस प्राप्त करें।  
3. Rectangle प्रकार का एक AutoShape जोड़ें।  
4. InnerShadowEffect को सक्षम करें।  
5. सभी आवश्यक पैरामीटर सेट करें।  
6. ColorType को Scheme पर सेट करें।  
7. Scheme Color सेट करें।  
8. प्रेजेंटेशन को [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  

यह नमूना कोड (उपर्युक्त चरणों पर आधारित) आपको Python में दो शैप्स के बीच कनेक्टर जोड़ने की विधि दर्शाता है:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # स्लाइड का संदर्भ प्राप्त करें
    slide = presentation.slides[0]

    # Rectangle प्रकार का AutoShape जोड़ें
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Rectangle में TextFrame जोड़ें
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # inner_shadow_effect सक्षम करें    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # सभी आवश्यक पैरामीटर सेट करें
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # ColorType को Scheme के रूप में सेट करें
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Scheme Color सेट करें
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # प्रस्तुति सहेजें
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं WordArt इफ़ेक्ट विभिन्न फ़ॉन्ट्स या स्क्रिप्ट्स (जैसे अरबी, चीनी) के साथ उपयोग कर सकता हूँ?**  
हाँ, Aspose.Slides Unicode का समर्थन करता है और सभी प्रमुख फ़ॉन्ट्स और स्क्रिप्ट्स के साथ काम करता है। Shadow, Fill और Outline जैसे WordArt इफ़ेक्ट भाषा की परवाह किए बिना लागू किए जा सकते हैं, हालांकि फ़ॉन्ट उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट्स पर निर्भर हो सकती है।

**क्या मैं WordArt इफ़ेक्ट स्लाइड मास्टर एलिमेंट्स पर लागू कर सकता हूँ?**  
हाँ, आप मास्टर स्लाइड्स पर स्थित शैप्स, जैसे टाइटल प्लेसहोल्डर, फुटर या बैकग्राउंड टेक्स्ट, पर WordArt इफ़ेक्ट लागू कर सकते हैं। मास्टर लेआउट में किए गए बदलाव सभी सम्बद्ध स्लाइड्स में परिलक्षित होंगे।

**क्या WordArt इफ़ेक्ट प्रेजेंटेशन फ़ाइल साइज़ को प्रभावित करते हैं?**  
हद तक। शैडो, ग्लो और ग्रेडिएंट फ़िल जैसे WordArt इफ़ेक्ट थोड़ा फ़ाइल साइज बढ़ा सकते हैं क्योंकि अतिरिक्त फ़ॉर्मेटिंग मेटाडेटा जुड़ती है, लेकिन अंतर आमतौर पर नगण्य होता है।

**क्या मैं प्रेजेंटेशन सहेजे बिना WordArt इफ़ेक्ट का परिणाम पूर्वावलोकन कर सकता हूँ?**  
हाँ, आप [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) या [Slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) क्लास के `get_image` मेथड का उपयोग करके WordArt युक्त स्लाइड्स को छवियों (जैसे PNG, JPEG) में रेंडर कर सकते हैं। यह आपको पूरे प्रेजेंटेशन को सहेजने या एक्सपोर्ट करने से पहले इन‑मेमोरी या स्क्रीन पर परिणाम का पूर्वावलोकन करने देता है।