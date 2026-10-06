---
title: PowerPoint प्रस्तुतियों में Python का उपयोग करके SmartArt प्रबंधित करें
linktitle: SmartArt प्रबंधित करें
type: docs
weight: 10
url: /hi/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt पाठ
- लेआउट प्रकार
- छिपी गुण
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके स्पष्ट कोड नमूनों के साथ PowerPoint SmartArt बनाना और संपादित करना सीखें, जो स्लाइड डिजाइन और स्वचालन को तेज़ बनाते हैं।"
---
## **अवलोकन**

SmartArt एक PowerPoint आरेख है जो नोड्स, नोड शैलियों और लेआउट से निर्मित होता है। Aspose.Slides for Python via .NET के साथ, आप SmartArt बना सकते हैं, उसकी नोड्स से पाठ पढ़ सकते हैं, उसका लेआउट बदल सकते हैं, छिपे हुए नोड्स की जाँच कर सकते हैं, ऑर्गनाइज़ेशन चार्ट लेआउट को कॉन्फ़िगर कर सकते हैं, और पिक्चर ऑर्गनाइज़ेशन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से पाठ प्राप्त करें**

एक SmartArt नोड में एक या अधिक शैलियाँ हो सकती हैं। नोड शैलियों से पाठ पढ़ने के लिए, [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/) पर पुनरावृत्ति करें, फिर [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/) द्वारा लौटाए गए [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) को पढ़ें।

उदाहरण के लिए एक प्रस्तुति चाहिए जिसमें कम से कम एक स्लाइड हो और उस स्लाइड पर पहला आकार SmartArt ऑब्जेक्ट हो। यह प्रत्येक उपलब्ध टेक्स्ट फ्रेम को कंसोल पर प्रिंट करता है।

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **SmartArt ऑब्जेक्ट का लेआउट प्रकार बदलें**

SmartArt लेआउट यह नियंत्रित करता है कि नोड्स कैसे व्यवस्थित और जुड़े होते हैं। निम्न उदाहरण एक SmartArt ऑब्जेक्ट बनाता है जिसमें [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` मान है, इसे `BASIC_PROCESS` मान में बदलता है, और प्रस्तुति को सहेजता है। [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) को पास किया गया स्थिति और आकार पॉइंट्स में मापा जाता है। लेआउट बदलने के लिए [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) सेट करें।

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **जाँचें कि SmartArt नोड छिपा है या नहीं**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) बताता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। चयनित लेआउट इन नोड्स को दृश्यमान डायग्राम तत्वों के रूप में नहीं दिखा सकता, फिर भी छिपे हुए नोड्स संरचना में मौजूद रह सकते हैं।

निम्न उदाहरण एक SmartArt ऑब्जेक्ट में नोड जोड़ता है जो [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` मान का उपयोग करता है और जोड़े गए नोड की छिपी स्थिति की जाँच करता है। यदि नोड छिपा है तो यह एक संदेश प्रिंट करता है और डायग्राम को सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑर्गनाइज़ेशन चार्ट लेआउट प्राप्त करें या सेट करें**

उन SmartArt आरेखों के लिए जो ऑर्गनाइज़ेशन चार्ट लेआउट का उपयोग करते हैं, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) निर्धारित करता है कि चाइल्ड नोड्स पैरेंट नोड के तहत कैसे व्यवस्थित होते हैं। उदाहरण के लिए, चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) के आधार पर आप चाइल्ड नोड्स को बाएँ, दाएँ या दोनों ओर लटकाने के लिए सेट कर सकते हैं।

निम्न उदाहरण एक ऑर्गनाइज़ेशन चार्ट बनाता है और पहले नोड के लिए लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` मान पर सेट करता है। शून्य-आधारित सूचकांक `0` पहला टॉप-लेवल नोड चुनता है; उसके चाइल्ड नोड्स चयनित व्यवस्था का उपयोग करते हैं। संशोधित प्रस्तुति फिर सहेजी जाती है।

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **पिक्चर ऑर्गनाइज़ेशन चार्ट बनाएं**

पिक्चर ऑर्गनाइज़ेशन चार्ट एक SmartArt लेआउट है जो छवि प्लेसहोल्डर वाले पदानुक्रमिक आरेखों के लिए बनाया गया है। जब स्लाइड में SmartArt ऑब्जेक्ट जोड़ रहे हों तो [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` मान का उपयोग करें। यह उदाहरण छवि प्लेसहोल्डर वाले एक आरेख को सहेजता है; यह प्लेसहोल्डर को छवियों से भरता नहीं है।

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **लेगसी डायग्राम को शैलियों के समूह में बदलें**

जब किसी मौजूदा प्रस्तुति को आधुनिक बनाते हैं, तो आपको PowerPoint 97–2003 में मूल रूप से बनाए गए ऑर्गनाइज़ेशन चार्ट को अपडेट करने की आवश्यकता हो सकती है। Aspose.Slides इन लेगसी डायग्राम को [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) ऑब्जेक्ट के रूप में दर्शाता है। डायग्राम को शैलियों के समूह में बदलने के लिए [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) का उपयोग करें, ताकि आप व्यक्तिगत दृश्य तत्वों को संपादित कर सकें। विवरण के लिए [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) देखें।

परिवर्तन शैलियों के संग्रह में एक नया समूह जोड़ता है बिना मूल डायग्राम को हटाए। सफल परिवर्तन के बाद, डुप्लिकेट सामग्री से बचने के लिए मूल को [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) से हटाएँ। परिवर्तन से पहले लेगसी डायग्राम को एक सूची में एकत्र करें ताकि शैलियों को जोड़ने या हटाने से पुनरावृत्ति में बाधा न आए।

निम्न उदाहरण एक प्रस्तुति खोलता है, प्रत्येक स्लाइड की खोज करता है, डायग्राम को शैलियों के समूह में बदलता है, और अपडेटेड प्रस्तुति को PPTX के रूप में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

सहेजी गई प्रस्तुति में परिवर्तित लेगसी डायग्राम की जगह संपादन योग्य शैलियों के समूह होते हैं, और कोई मूल डायग्राम साथ नहीं रहता। प्रत्येक समूह के भीतर व्यक्तिगत तत्वों जैसे उनका पाठ, भराव या स्थिति, को संपादित करने के लिए PPTX को PowerPoint में खोलें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हां। जब चयनित SmartArt लेआउट रिवर्सल को समर्थन देता है, तो [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) प्रॉपर्टी आरेख की दिशा को बाएं-से-दाएं से दाएं-से-बाएं में या उसके विपरीत बदल देती है।

**मैं SmartArt को समान स्लाइड या किसी अन्य प्रस्तुति में फ़ॉर्मेटिंग संरक्षित रखते हुए कैसे कॉपी कर सकता हूँ?**

आप [clone the SmartArt shape](/slides/hi/python-net/shape-manipulations/) को [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) के साथ उपयोग करके या [clone the whole slide](/slides/hi/python-net/clone-slides/) को उपयोग करके, जो SmartArt को शामिल करता है, कॉपी कर सकते हैं। दोनों तरीकों से आकार, स्थिति और फ़ॉर्मेटिंग संरक्षित रहती है।

**मैं SmartArt को प्रीव्यू या वेब एक्सपोर्ट के लिए रास्टर छवि में कैसे रेंडर करूँ?**

[Render the slide](/slides/hi/python-net/convert-powerpoint-to-png/) या पूरी प्रस्तुति को PNG या JPEG में रेंडर करें। SmartArt स्लाइड का हिस्सा होने के नाते रेंडर होता है।

**यदि स्लाइड पर कई SmartArt ऑब्जेक्ट हैं तो मैं एक विशिष्ट SmartArt ऑब्जेक्ट कैसे खोजूँ?**

SmartArt आकार पर एक विशिष्ट [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) या [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) मान सेट करें, फिर उस मान को [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) में खोजें, और सुनिश्चित करें कि मिलते-जुलेट आकार एक [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) है।