---
title: PowerPoint प्रस्तुतियों में Python का उपयोग करके SmartArt प्रबंधित करें
linktitle: SmartArt प्रबंधित करें
type: docs
weight: 10
url: /hi/python-net/manage-smartart/
keywords:
- स्मार्टआर्ट
- SmartArt से पाठ
- लेआउट प्रकार
- छिपी हुई प्रॉपर्टी
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके स्पष्ट कोड नमूनों के साथ PowerPoint SmartArt को बनाना और संपादित करना सीखें, जो स्लाइड डिजाइन और ऑटोमेशन को तेज़ करता है।"
---
## **अवलोकन**

SmartArt एक PowerPoint आकृति है जो नोड्स, नोड आकार और लेआउट से बनी होती है। Aspose.Slides for Python via .NET के साथ, आप SmartArt बना सकते हैं, उसके नोड्स से टेक्स्ट पढ़ सकते हैं, उसका लेआउट बदल सकते हैं, छिपे हुए नोड्स की जाँच कर सकते हैं, संगठन चार्ट लेआउट को कॉन्फ़िगर कर सकते हैं, और चित्र संगठन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से टेक्स्ट प्राप्त करें**

एक SmartArt नोड में एक या अधिक आकार हो सकते हैं। दृश्यमान टेक्स्ट पढ़ने के लिए, [SmartArt.all_nodes](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartart/all_nodes/) के माध्यम से इटरेट करें, फिर [SmartArtShape.text_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartartshape/text_frame/) द्वारा लौटाए गए [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) को पढ़ें।

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **SmartArt ऑब्जेक्ट के लेआउट प्रकार को बदलें**

SmartArt लेआउट यह नियंत्रित करता है कि नोड्स कैसे व्यवस्थित और जुड़े हों। निम्न उदाहरण एक SmartArt ऑब्जेक्ट बनाता है जिसमें [SmartArtLayoutType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartartlayouttype/) का `BASIC_BLOCK_LIST` मान होता है, इसे `BASIC_PROCESS` मान में बदलता है, और प्रस्तुतीकरण को सहेजता है।

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **जाँचें कि SmartArt नोड छिपा है या नहीं**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartartnode/is_hidden/) यह दर्शाता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। चयनित लेआउट इन नोड्स को दृश्यमान आकृति तत्वों के रूप में नहीं दिखा भी सकता है, फिर भी छिपे हुए नोड्स संरचना में मौजूद हो सकते हैं।

निम्न उदाहरण एक SmartArt ऑब्जेक्ट में नोड जोड़ता है जो [SmartArtLayoutType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartartlayouttype/) का `RADIAL_CYCLE` मान उपयोग करता है और नोड की छिपी स्थिति की जाँच करता है।

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **संगठन चार्ट लेआउट प्राप्त करें या सेट करें**

उन SmartArt आरेखों के लिए जो संगठन चार्ट लेआउट का उपयोग करते हैं, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) यह निर्धारित करता है कि चाइल्ड नोड्स पैरेंट नोड के तहत कैसे व्यवस्थित होते हैं। उदाहरण के लिए, आप चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/organizationchartlayouttype/) के आधार पर चाइल्ड नोड्स को बाएं, दाएं या दोनों ओर लटकाने के लिए सेट कर सकते हैं।

निम्न उदाहरण एक संगठन चार्ट बनाता है और पहले नोड के लिए लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/organizationchartlayouttype/) का `LEFT_HANGING` मान सेट करता है।

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **एक चित्र संगठन चार्ट बनाएं**

एक चित्र संगठन चार्ट एक SmartArt लेआउट है जो छवि प्लेसहोल्डर वाले पदानुक्रम आरेखों के लिए बनाया गया है। स्लाइड में SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartartlayouttype/) का `PICTURE_ORGANIZATION_CHART` मान उपयोग करें।

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हाँ। जब चयनित SmartArt लेआउट रिवर्सल का समर्थन करता है, तब [SmartArt.is_reversed](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartart/is_reversed/) प्रॉपर्टी आरेख की दिशा बाएं-से-दाएँ से दाएं-से-बाएं या वापस बदल देती है।

**मैं फ़ॉर्मेटिंग को बनाए रखते हुए SmartArt को उसी स्लाइड या किसी अन्य प्रस्तुति में कैसे कॉपी कर सकता हूँ?**

आप [SmartArt shape को क्लोन कर सकते हैं](/slides/hi/python-net/shape-manipulations/) [ShapeCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_clone/) के साथ या उस स्लाइड को क्लोन कर सकते हैं जिसमें SmartArt है [clone the whole slide](/slides/hi/python-net/clone-slides/) से। दोनों उपाय आकार, स्थिति और फ़ॉर्मेटिंग को बनाए रखते हैं।

**मैं प्रीव्यू या वेब एक्सपोर्ट के लिए SmartArt को रास्टर इमेज में कैसे रेंडर करूँ?**

[स्लाइड को रेंडर करें](/slides/hi/python-net/convert-powerpoint-to-png/) या पूरी प्रस्तुति को PNG या JPEG में रेंडर करें। SmartArt स्लाइड का हिस्सा के रूप में रेंडर होता है।

**यदि कई SmartArt ऑब्जेक्ट हैं तो मैं स्लाइड पर एक विशिष्ट SmartArt ऑब्जेक्ट को कैसे खोजूँ?**

SmartArt shape पर एक विशिष्ट [Shape.alternative_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/alternative_text/) या [Shape.name](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/name/) मूल्य सेट करें, फिर [Slide.shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/shapes/) में उस मूल्य को खोजें, और यह सुनिश्चित करें कि मिलती-जुलती shape एक [SmartArt](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartart/) है।