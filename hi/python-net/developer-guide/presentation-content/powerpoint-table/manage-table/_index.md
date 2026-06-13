---
title: प्रेजेंटेशन तालिकाओं को Python के साथ प्रबंधित करें
linktitle: तालिका प्रबंधित करें
type: docs
weight: 10
url: /hi/python-net/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुँचें
- आश्पेक्ट अनुपात
- पाठ संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument स्लाइड्स में तालिकाओं को बनाएं एवं संपादित करें। अपने तालिका वर्कफ़्लो को सरल बनाने के लिए सरल कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में तालिका जानकारी प्रस्तुत करने का एक कुशल तरीका है। जानकारी को कोशिकाओं (पंक्तियों और स्तंभों) के ग्रिड में व्यवस्थित करना सीधा और समझने में आसान होता है।

Aspose.Slides [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) क्लास, [Cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/) क्लास और अन्य संबंधित प्रकार प्रदान करता है जो आपको किसी भी प्रस्तुति में तालिकाएँ बनाना, अपडेट करना और प्रबंधित करना आसान बनाते हैं।

## **सुरू से तालिकाएँ बनाना**

यह अनुभाग दिखाता है कि Aspose.Slides में स्लाइड में एक तालिका आकार जोड़कर, उसकी पंक्तियों और स्तंभों को परिभाषित करके, और सटीक आकार सेट करके कैसे एक तालिका बनाई जाए। आप देखेंगे कि कोशिकाओं में टेक्स्ट कैसे भरा जाए, संरेखण और सीमाएँ कैसे समायोजित की जाएँ, और तालिका की उपस्थिति कैसे अनुकूलित की जाए।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. उसका इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्तंभ चौड़ाई की एक array परिभाषित करें।
4. पंक्ति ऊँचाई की एक array परिभाषित करें।
5. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) जोड़ें।
6. प्रत्येक [Cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/) पर इटररेट करें और उसकी शीर्ष, नीचे, दाएँ और बाएँ सीमाओं को फॉर्मेट करें।
7. तालिका की पहली पंक्ति में पहले दो कोशिकाओं को मिलाएँ।
8. एक [Cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/) के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुँचें।
9. [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) में टेक्स्ट जोड़ें।
10. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया Python उदाहरण दिखाता है कि प्रस्तुति में तालिका कैसे बनाई जाए:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # स्लाइड में एक तालिका आकार जोड़ें।
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # प्रत्येक कोशिका के लिए बॉर्डर फ़ॉर्मेट सेट करें।
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # (पंक्ति 0, स्तंभ 0) से (पंक्ति 1, स्तंभ 1) तक की कोशिकाओं को मिलाएँ।
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # मिली हुई कोशिका में टेक्स्ट जोड़ें।
    table.rows[0][0].text_frame.text = "Merged Cells"

    # प्रेज़ेंटेशन को डिस्क पर सहेजें।
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **मानक तालिकाओं में क्रमांकन**

एक मानक तालिका में, कोशिका क्रमांकन सरल और शून्य-आधारित होता है। तालिका की पहली कोशिका का सूचकांक (0, 0) (स्तंभ 0, पंक्ति 0) है।

उदाहरण के लिए, 4 स्तंभ और 4 पंक्तियों वाली तालिका में कोशिकाएँ इस प्रकार क्रमांकित हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

नीचे दिया गया Python उदाहरण दिखाता है कि इस शून्य-आधारित क्रमांकन का उपयोग करके कोशिकाओं को कैसे संदर्भित किया जाए:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **मौजूदा तालिका तक पहुँचें**

यह अनुभाग बताता है कि Aspose.Slides का उपयोग करके प्रस्तुति में मौजूदा तालिका को कैसे खोजें और उस पर कार्य करें। आप सीखेंगे कि स्लाइड पर तालिका कैसे खोजें, उसकी पंक्तियों, स्तंभों और कोशिकाओं तक कैसे पहुँचें, और सामग्री या फ़ॉर्मेटिंग को कैसे अपडेट करें।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. तालिका वाली स्लाइड का उसका इंडेक्स द्वारा संदर्भ प्राप्त करें।
3. सभी [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) ऑब्जेक्ट्स पर इटररेट करें जब तक कि आप तालिका न खोजें।
4. तालिका के साथ कार्य करने के लिए [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) ऑब्जेक्ट का उपयोग करें।
5. संशोधित प्रस्तुति को सहेजें।

{{% alert color="info" %}}
यदि स्लाइड में कई तालिकाएँ हैं, तो आप `alternative_text` प्रॉपर्टी के आधार पर आवश्यक तालिका की खोज करना बेहतर होगा।
{{% /alert %}}

नीचे दिया गया Python उदाहरण दिखाता है कि मौजूदा तालिका तक कैसे पहुँचा जाए और उसके साथ कार्य किया जाए:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTX फ़ाइल लोड करने के लिए Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("sample.pptx") as presentation:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    table = None

    # आकारों के माध्यम से इटररेट करें और मिली पहली तालिका का संदर्भ लें।
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # पहली पंक्ति की पहली कोशिका का टेक्स्ट सेट करें।
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # संशोधित प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिकाओं में टेक्स्ट को संरेखित करना**

यह अनुभाग दिखाता है कि Aspose.Slides का उपयोग करके तालिका की कोशिकाओं के भीतर टेक्स्ट संरेखण को कैसे नियंत्रित किया जाए। आप सीखेंगे कि कोशिकाओं के लिए क्षैतिज और_VERTICAL_ संरेखण कैसे सेट किया जाए ताकि आपका कंटेंट स्पष्ट और सुसंगत रहे।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. उसका इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) ऑब्जेक्ट जोड़ें।
4. तालिका से एक [Cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/) ऑब्जेक्ट तक पहुँचें।
5. टेक्स्ट को लंबवत रूप से संरेखित करें।
6. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया Python उदाहरण दिखाता है कि तालिका में टेक्स्ट को कैसे संरेखित किया जाए:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation क्लास का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ परिभाषित करें।
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # स्लाइड में एक तालिका आकार जोड़ें।
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # टेक्स्ट को केंद्रित करें और लंबवत अभिविन्यास सेट करें।
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # प्रेजेंटेशन को डिस्क पर सहेजें।
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करना**

यह अनुभाग दिखाता है कि Aspose.Slides में तालिका स्तर पर टेक्स्ट फ़ॉर्मेटिंग कैसे लागू की जाए ताकि प्रत्येक कोशिका एक समान, एकीकृत शैली प्राप्त करे। आप फ़ॉन्ट आकार, संरेखण, और मार्जिन को वैश्विक रूप से कैसे सेट करें सीखेंगे।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. उसका इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) जोड़ें।
4. टेक्स्ट के लिए फ़ॉन्ट आकार (फ़ॉन्ट ऊँचाई) सेट करें।
5. पैराग्राफ संरेखण और मार्जिन सेट करें।
6. वर्टिकल टेक्स्ट अभिविन्यास सेट करें।
7. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया Python उदाहरण दिखाता है कि तालिका में टेक्स्ट पर आपकी इच्छित फ़ॉर्मेटिंग विकल्प कैसे लागू किए जाएँ:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation क्लास का एक उदाहरण बनाता है
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # सभी तालिका कोशिकाओं के लिए फ़ॉन्ट आकार सेट करें।
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # सभी तालिका कोशिकाओं के लिए दाएँ-संरेखित टेक्स्ट और दाएँ मार्जिन सेट करें।
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # सभी तालिका कोशिकाओं के लिए लंबवत टेक्स्ट अभिविन्यास सेट करें।
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **इनबिल्ट तालिका शैलियों को लागू करें**

Aspose.Slides आपको कोड में सीधे पूर्वनिर्धारित शैलियों का उपयोग करके तालिकाओं को फ़ॉर्मेट करने देता है। यह उदाहरण एक तालिका बनाता है, एक इनबिल्ट शैली लागू करता है, और परिणाम को सहेजता है—एक कुशल तरीका जिससे लगातार, पेशेवर फ़ॉर्मेटिंग सुनिश्चित हो सके।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिकाओं का पहलू अनुपात लॉक करें**

एक आकार का पहलू अनुपात उसकी आयामों का अनुपात होता है। Aspose.Slides `aspect_ratio_locked` प्रॉपर्टी प्रदान करता है, जिसके माध्यम से आप तालिकाओं और अन्य आकारों के लिए पहलू अनुपात को लॉक कर सकते हैं।

नीचे दिया गया Python उदाहरण दिखाता है कि तालिका के लिए पहलू अनुपात कैसे लॉक किया जाए:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**क्या मैं पूरे तालिका और इसकी कोशिकाओं में टेक्स्ट के लिए दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**

हाँ। तालिका में `[right_to_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/right_to_left/)` प्रॉपर्टी उपलब्ध है, और पैराग्राफ़ में `ParagraphFormat.right_to_left` प्रॉपर्टी है। दोनों को एक साथ उपयोग करने से कोशिकाओं के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं अंतिम फ़ाइल में उपयोगकर्ताओं को तालिका को स्थानांतरित या आकार बदलने से कैसे रोकूँ?**

[shape locks](/slides/hi/python-net/applying-protection-to-presentation/) का उपयोग करके स्थानांतरित करने, आकार बदलने, चयन आदि को अक्षम करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या किसी कोशिका के भीतर बैकग्राउंड के रूप में छवि सम्मिलित करना समर्थित है?**

हाँ। आप एक [picture fill](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/) को कोशिका के लिए सेट कर सकते हैं; छवि चयनित मोड (खिंचा हुआ या टाइल) के अनुसार कोशिका क्षेत्र को ढक लेगी।