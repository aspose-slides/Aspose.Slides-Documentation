---
title: Python का उपयोग करके PowerPoint तालिकाओं में पंक्तियों और स्तंभों को प्रबंधित करना
linktitle: पंक्तियाँ और स्तंभ
type: docs
weight: 20
url: /hi/python-net/manage-rows-and-columns/
keywords:
- तालिका पंक्ति
- तालिका स्तंभ
- पहली पंक्ति
- तालिका हेडर
- पंक्ति क्लोन
- स्तंभ क्लोन
- पंक्ति कॉपी
- स्तंभ कॉपी
- पंक्ति हटाएँ
- स्तंभ हटाएँ
- पंक्ति पाठ स्वरूपण
- स्तंभ पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python के माध्यम से .NET पर PowerPoint और OpenDocument में तालिका पंक्तियों और स्तंभों का प्रबंधन करके प्रेजेंटेशन संपादन और डेटा अपडेट को तेज़ करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में तालिका की पंक्तियों और स्तंभों को प्रबंधित करने का तरीका दर्शाता है। आप पंक्तियों या स्तंभों को जोड़ना, सम्मिलित करना, क्लोन करना और हटाना, पहली पंक्ति को हेडर के रूप में चिह्नित करना, आकार और लेआउट समायोजित करना, तथा पंक्ति या स्तंभ स्तर पर पाठ और शैली स्वरूपण लागू करना सीखेंगे। प्रत्येक कार्य को संक्षिप्त, स्वतंत्र कोड स्निपेट्स के साथ दिखाया गया है, जो [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) API पर आधारित हैं, ताकि आप शीघ्रता से स्लाइड में तालिका खोजकर उसकी संरचना को अपने डिज़ाइन के अनुरूप बदल सकें।

## **पहली पंक्ति को हेडर बनाना**

तालिका की पहली पंक्ति को हेडर के रूप में चिह्नित करें ताकि कॉलम शीर्षकों को डेटा से स्पष्ट रूप से अलग किया जा सके। Aspose.Slides for Python में, तालिका की *First Row* विकल्प को सक्षम करने से चयनित तालिका शैली द्वारा परिभाषित हेडर स्वरूपण लागू हो जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ और प्रस्तुति लोड करें।  
1. उसके अनुक्रमणिका द्वारा स्लाइड तक पहुँचें।  
1. सभी [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) वस्तुओं पर इटररेट करके संबंधित तालिका खोजें।  
1. तालिका की पहली पंक्ति को हेडर सेट करें।  

यह Python कोड दिखाता है कि तालिका की पहली पंक्ति को हेडर कैसे सेट करें:

```python
import aspose.slides as slides

# Presentation वर्ग का एक उदाहरण बनाइए।
with slides.Presentation("table.pptx") as presentation:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # आकारों के माध्यम से इटररेट करें और तालिका का संदर्भ प्राप्त करें।
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # तालिका की पहली पंक्ति को हेडर के रूप में सेट करें।
    table.first_row = True
    
    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका पंक्ति या स्तंभ को क्लोन करना**

किसी भी तालिका पंक्ति या स्तंभ को क्लोन करें और कॉपी को तालिका में इच्छित स्थान पर सम्मिलित करें। क्लोन में सेल सामग्री, स्वरूपण और आकार सुरक्षित रहते हैं, जिससे आप लेआउट को जल्दी और सुसंगत रूप से विस्तारित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ और प्रस्तुति लोड करें।  
1. उसके अनुक्रमणिका द्वारा स्लाइड तक पहुँचें।  
1. कॉलम चौड़ाइयों की एक सरणी परिभाषित करें।  
1. पंक्ति ऊँचाइयों की एक सरणी परिभाषित करें।  
1. `add_table(x, y, column_widths, row_heights)` का उपयोग करके स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) जोड़ें।  
1. तालिका पंक्ति को क्लोन करें।  
1. तालिका स्तंभ को क्लोन करें।  
1. संशोधित प्रस्तुति सहेजें।  

यह Python कोड दिखाता है कि PowerPoint तालिका की पंक्ति और स्तंभ को कैसे क्लोन किया जाता है:

```python
 import aspose.slides as slides

# Presentation वर्ग का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड तक पहुंचें।
    slide = presentation.slides[0]

    # कॉलम चौड़ाई और पंक्ति ऊँचाई को परिभाषित करें।
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # स्लाइड में एक तालिका जोड़ें।
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # पंक्ति 1, कॉलम 1 में पाठ जोड़ें।
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # पंक्ति 2, कॉलम 1 में पाठ जोड़ें।
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # तालिका के अंत में पंक्ति 1 को क्लोन करें।
    table.rows.add_clone(table.rows[0], False)

    # पंक्ति 1, कॉलम 2 में पाठ जोड़ें।
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # पंक्ति 2, कॉलम 2 में पाठ जोड़ें।
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # तालिका की 4थी पंक्ति के रूप में पंक्ति 2 को क्लोन करें।
    table.rows.insert_clone(3,table.rows[1], False)

    # अंत में पहला कॉलम क्लोन करें।
    table.columns.add_clone(table.columns[0], False)

    # इंडेक्स 3 (4थी स्थिति) पर दूसरा कॉलम क्लोन करें।
    table.columns.insert_clone(3,table.columns[1], False)
    
    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका से पंक्ति या स्तंभ हटाना**

Aspose.Slides for Python का उपयोग करके अनुक्रमणिका द्वारा किसी भी पंक्ति या स्तंभ को हटाएँ—लेआउट स्वतः पुनः समायोजित हो जाता है जबकि शेष सेल्स का स्वरूपण बरकरार रहता है। यह डेटा ग्रिड को सरल बनाना या प्लेसहोल्डर हटाने के लिए उपयोगी है, बिना तालिका को फिर से बनाने की आवश्यकता के।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ और प्रस्तुति लोड करें।  
1. उसके अनुक्रमणिका द्वारा स्लाइड तक पहुँचें।  
1. कॉलम चौड़ाइयों की एक सरणी परिभाषित करें।  
1. पंक्ति ऊँचाइयों की एक सरणी परिभाषित करें।  
1. `add_table(x, y, column_widths, row_heights)` का उपयोग करके स्लाइड में एक ITable जोड़ें।  
1. तालिका पंक्ति को हटाएँ।  
1. तालिका स्तंभ को हटाएँ।  
1. संशोधित प्रस्तुति सहेजें।  

निम्नलिखित Python कोड दर्शाता है कि तालिका से पंक्ति और स्तंभ को कैसे हटाया जाता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका पंक्ति स्तर पर पाठ स्वरूपण सेट करना**

एक संपूर्ण तालिका पंक्ति पर एक ही चरण में सुसंगत पाठ शैली लागू करें। Aspose.Slides for Python के साथ, आप फ़ॉन्ट परिवार, आकार, वजन, रंग और संरेखण को पंक्ति के सभी सेल्स के लिए एक साथ सेट कर सकते हैं, जिससे शीर्षक या डेटा बैंड समान रहेंगे।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ और प्रस्तुति लोड करें।  
1. उसके अनुक्रमणिका द्वारा स्लाइड तक पहुँचें।  
1. स्लाइड पर संबंधित [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) ऑब्जेक्ट तक पहुँचें।  
1. पहली पंक्ति के सेल्स के लिए फ़ॉन्ट ऊँचाई सेट करें।  
1. पहली पंक्ति के सेल्स के लिए संरेखण और दायाँ मार्जिन सेट करें।  
1. दूसरी पंक्ति के सेल्स के लिए पाठ अनुखिम प्रकार सेट करें।  
1. संशोधित प्रस्तुति सहेजें।  

यह Python कोड इस क्रिया को प्रदर्शित करता है।

```python
import aspose.slides as slides

# Presentation वर्ग का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # पहली पंक्ति के सेल्स के लिए फ़ॉन्ट ऊँचाई सेट करें।
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # पहली पंक्ति के सेल्स की पाठ संरेखण और दायाँ मार्जिन सेट करें।
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # दूसरी पंक्ति के सेल्स की पाठ लम्बवत प्रकार सेट करें।
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
	# प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका स्तंभ स्तर पर पाठ स्वरूपण सेट करना**

एक संपूर्ण तालिका स्तंभ पर एक ही बार में सुसंगत पाठ शैली लागू करें। Aspose.Slides for Python के साथ, आप फ़ॉन्ट परिवार, आकार, वजन, रंग और संरेखण को स्तंभ के सभी सेल्स के लिए सेट कर सकते हैं, जिससे शीर्षक या डेटा के लिए समान ऊर्ध्वाधर बैंड बनेंगे।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ और प्रस्तुति लोड करें।  
1. उसके अनुक्रमणिका द्वारा स्लाइड तक पहुँचें।  
1. स्लाइड पर संबंधित [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) ऑब्जेक्ट तक पहुँचें।  
1. पहली स्तंभ के सेल्स के लिए फ़ॉन्ट ऊँचाई सेट करें।  
1. पहली स्तंभ के सेल्स के लिए संरेखण और दायाँ मार्जिन सेट करें।  
1. दूसरी स्तंभ के सेल्स के लिए पाठ अनुखिम प्रकार सेट करें।  
1. संशोधित प्रस्तुति सहेजें।  

निम्नलिखित Python कोड इस क्रिया को प्रदर्शित करता है:

```python
import aspose.slides as slides

# Presentation वर्ग का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # पहले स्तंभ के सेल्स की फ़ॉन्ट ऊँचाई सेट करें।
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # पहले स्तंभ के सेल्स की पाठ संरेखण और दायाँ मार्जिन सेट करें।
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # दूसरे स्तंभ के सेल्स की पाठ लम्बवत प्रकार सेट करें।
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # प्रेजेंटेशन को डिस्क पर सहेजें।
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका शैली गुण प्राप्त करना**

Aspose.Slides आपको तालिका की शैली गुणों को पुनः प्राप्त करने की अनुमति देता है ताकि आप उन्हें किसी अन्य तालिका या अन्य स्थान पर पुन: उपयोग कर सकें। निम्नलिखित Python कोड दिखाता है कि पूर्वनिर्धारित तालिका शैली से शैली गुणों को कैसे प्राप्त किया जाता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पहले से बनाई गई तालिका पर PowerPoint थीम/शैलियाँ लागू कर सकता हूँ?**

हां। तालिका स्लाइड/लेआउट/मास्टर थीम को विरासत में लेती है, और आप उस थीम के ऊपर भराव, सीमा और पाठ रंगों को अभी भी ओवरराइड कर सकते हैं।

**क्या मैं Excel की तरह तालिका पंक्तियों को सॉर्ट कर सकता हूँ?**

नहीं, Aspose.Slides तालिकाओं में अंतर्निहित सॉर्टिंग या फ़िल्टर नहीं होते। पहले डेटा को मेमोरी में सॉर्ट करें, फिर उस क्रम में तालिका पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (धारीदार) स्तंभ रख सकता हूँ जबकि विशिष्ट सेल्स पर कस्टम रंग बनाए रखूँ?**

हां। बैंडेड स्तंभ सक्षम करें, फिर विशिष्ट सेल्स पर स्थानीय स्वरूपण को ओवरराइड करें; सेल-स्तर स्वरूपण तालिका शैली पर प्राथमिकता लेता है।