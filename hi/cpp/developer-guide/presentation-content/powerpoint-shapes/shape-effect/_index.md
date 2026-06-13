---
title: C++ का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/cpp/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- प्रतिबिंब प्रभाव
- चमक प्रभाव
- नरम किनारे प्रभाव
- प्रभाव प्रारूप
- PowerPoint
- प्रस्तुतीकरण
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें — सेकंडों में प्रभावशाली, पेशेवर स्लाइड्स बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग करके आप किसी आकार को उजागर कर सकते हैं, ये [fills](/slides/hi/cpp/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint प्रभावों के द्वारा आप आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैला सकते हैं, आदि।

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक या अधिक प्रभाव एक आकार पर लागू कर सकते हैं।  

* कुछ प्रभाव संयोजन दूसरों की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint **Preset** के अंतर्गत विकल्प प्रदान करता है। Preset विकल्प मूलतः दो या अधिक प्रभावों के ज्ञात अच्छे संयोजन होते हैं। इस प्रकार, किसी प्रीसेट को चुनकर आपको विभिन्न प्रभावों को आज़माने या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.effect_format/) क्लास के तहत गुण और मेथड प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने की अनुमति देते हैं।

## **छाया प्रभाव लागू करें**

यह C++ कोड दिखाता है कि कैसे आयत पर बाहरी छाया प्रभाव ([OuterShadowEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) लागू किया जाए:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(System::Drawing::Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **प्रतिबिंब प्रभाव लागू करें**

यह C++ कोड दिखाता है कि कैसे किसी आकार पर प्रतिबिंब प्रभाव लागू किया जाए:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(55);
reflectionEffect->set_BlurRadius(4);

pres->Save(u"reflection.pptx", SaveFormat::Pptx);
```

## **चमक प्रभाव लागू करें**

यह C++ कोड दिखाता है कि कैसे किसी आकार पर चमक प्रभाव लागू किया जाए:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(System::Drawing::Color::get_Magenta());
glowEffect->set_Radius(15);

pres->Save(u"glow.pptx", SaveFormat::Pptx);
```

## **सॉफ्ट एजेज़ प्रभाव लागू करें**

यह C++ कोड दिखाता है कि कैसे किसी आकार पर सॉफ्ट एजेज़ लागू किया जाए:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(15);

pres->Save(u"softEdges.pptx", SaveFormat::Pptx);
```

## **FAQ**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर विभिन्न प्रभावों, जैसे छाया, प्रतिबिंब, और चमक, को मिलाकर अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकृतियों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकृतियों पर प्रभाव लागू कर सकते हैं, जिसमें ऑटोशेप, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अन्य शामिल हैं।

**क्या मैं समूहित आकृतियों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकृतियों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरे समूह पर लागू होगा।