---
title: Python के साथ समूह प्रस्तुति आकृतियाँ
linktitle: आकृति समूह
type: docs
weight: 40
url: /hi/python-net/group/
keywords:
- समूह आकृति
- आकृति समूह
- समूह जोड़ें
- वैकल्पिक पाठ
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python का उपयोग करके PowerPoint और OpenDocument डेक्स में आकृतियों को समूहित और अससमूह करने के बारे में सीखें—तेज़, चरण-दर-चरण मार्गदर्शिका जिसमें मुफ्त कोड है।"
---
## **अवलोकन**

यह लेख Aspose.Slides में समूह आकृतियों के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि कैसे स्लाइड में एक समूह आकृति जोड़ी जाए, उसके अंदर आकृतियों को रखा जाए, और अपडेटेड प्रस्तुति को सहेजा जाए। यह यह भी दर्शाता है कि समूह के भीतर संग्रहीत आकृतियों तक कैसे पहुँचें और उनके `alternative_text` मान पढ़ें। अतिरिक्त रूप से, लेख संक्षिप्त रूप में संबंधित समूह‑आकृति क्षमताओं जैसे नेस्टेड समूह, z‑order, और लॉकिंग विकल्पों को भी कवर करता है।

## **समूह आकृतियों को जोड़ें**

Aspose.Slides स्लाइड पर समूह आकृतियों के साथ काम करने का समर्थन करता है। यह सुविधा आपको कई आकृतियों को एक ही वस्तु के रूप में मानकर अधिक समृद्ध प्रस्तुतियाँ बनाने देती है। आप नई समूह आकृतियों को जोड़ सकते हैं, मौजूदा को एक्सेस कर सकते हैं, उन्हें चाइल्ड आकृतियों से भर सकते हैं, और उनकी किसी भी प्रॉपर्टी को पढ़ या संशोधित कर सकते हैं। एक समूह आकृति को स्लाइड में जोड़ने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [GroupShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/) जोड़ें।
4. नई समूह आकृति में आकृतियों को जोड़ें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्न उदाहरण दिखाता है कि कैसे स्लाइड में एक समूह आकृति जोड़ी जाए।

```py
import aspose.slides as slides

# Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # स्लाइड में एक समूह आकृति जोड़ें।
    group_shape = slide.shapes.add_group_shape()

    # समूह आकृति के अंदर आकृतियाँ जोड़ें।
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # PPTX फ़ाइल को डिस्क पर लिखें।
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Alt Text प्रॉपर्टी तक पहुँचें**

यह अनुभाग Aspose.Slides का उपयोग करके स्लाइड पर समूह आकृति के भीतर मौजूद आकृतियों के Alt Text को पढ़ने का तरीका समझाता है। आकृतियों के Alt Text तक पहुँचने के लिए:

1. एक PPTX फ़ाइल का प्रतिनिधित्व करने के लिए [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. इंडेक्स के द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड के shapes संग्रह तक पहुँचें।
4. [GroupShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/) तक पहुँचें।
5. Alt Text प्रॉपर्टी पढ़ें।

निम्न उदाहरण समूह आकृतियों में मौजूद आकृतियों का Alt Text प्राप्त करता है।

```py
import aspose.slides as slides

# PPTX फ़ाइल खोलने के लिए Presentation क्लास का उदाहरण बनाएं.
with slides.Presentation("group_shape.pptx") as presentation:
    # पहली स्लाइड प्राप्त करें.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # समूह आकृति तक पहुँचें.
            for child_shape in shape.shapes:
                # Alt Text प्रॉपर्टी तक पहुँचें.
                print(child_shape.alternative_text)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या नेस्टेड ग्रुपिंग (एक समूह के अंदर एक समूह) समर्थित है?**

हां। [GroupShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/) में एक [parent_group](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/parent_group/) प्रॉपर्टी है, जो सीधे पदानुक्रम समर्थन को दर्शाती है (एक समूह दूसरे समूह का चाइल्ड हो सकता है)।

**मैं स्लाइड पर अन्य वस्तुओं के सापेक्ष समूह के z-order को कैसे नियंत्रित करूं?**

डिस्प्ले स्टैक में उसकी स्थिति को जांचने के लिए [GroupShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/) की [z_order_position](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/z_order_position/) प्रॉपर्टी का उपयोग करें।

**क्या मैं स्थानांतरित करने/संपादित करने/असमूह करने से रोक सकता हूँ?**

हां। समूह की लॉक सेक्शन [group_shape_lock](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/group_shape_lock/) के माध्यम से उपलब्ध है, जो आपको वस्तु पर संचालन को प्रतिबंधित करने की अनुमति देती है।