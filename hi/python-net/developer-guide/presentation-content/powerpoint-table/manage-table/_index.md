---
title: Python के साथ प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधित करें
type: docs
weight: 10
url: /hi/python-net/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुंचें
- आस्पेक्ट अनुपात
- टेक्स्ट संरेखित करें
- टेक्स्ट फ़ॉर्मेटिंग
- तालिका शैली
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python द्वारा .NET के माध्यम से PowerPoint और OpenDocument स्लाइड्स में तालिकाओं को बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सरल बनाने के लिए सरल कोड उदाहरण देखें।"
---
## **परिचय**

PowerPoint में एक तालिका जानकारी प्रस्तुत करने का एक कुशल तरीका है। कोशिकाओं (पंक्तियों और स्तंभों) के ग्रिड में व्यवस्थित जानकारी सीधी और समझने में आसान होती है।

Aspose.Slides आपके लिए किसी भी प्रस्तुति में तालिकाएँ बनाने, अद्यतन करने और प्रबंधित करने में मदद करने हेतु [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) क्लास, [Cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/) क्लास, और अन्य संबंधित प्रकार प्रदान करता है।

## **शुरुआत से तालिकाएँ बनाना**

यह अनुभाग Aspose.Slides में शुरू से तालिका बनाने का तरीका दर्शाता है, जिसमें स्लाइड में तालिका आकार जोड़ना, उसकी पंक्तियों और स्तंभों को परिभाषित करना, और सटीक आकार सेट करना शामिल है। आप देखेंगे कि कैसे सेल में टेक्स्ट भरें, संरेखण और बॉर्डर समायोजित करें, और तालिका की उपस्थिति को अनुकूलित करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. कॉलम चौड़ाइयों की एक ऐरे परिभाषित करें।
4. पंक्ति ऊँचाइयों की एक ऐरे परिभाषित करें।
5. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) जोड़ें।
6. प्रत्येक [Cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/) पर इटररेट करके उसकी शीर्ष, निचला, दायाँ और बायाँ बॉर्डर फॉर्मेट करें।
7. पहले दो पंक्तियों और पहले दो स्तंभों की कोशिकाओं को एकल सेल में मिलाएँ।
8. एक [Cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/) के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुँचें।
9. [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) में टेक्स्ट जोड़ें।
10. संशोधित प्रस्तुति को सेव करें।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # कॉलम की चौड़ाइयाँ और पंक्तियों की ऊँचाइयाँ परिभाषित करें।
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # स्लाइड पर एक तालिका आकार जोड़ें।
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करें।
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

    # मिलाए गए सेल में टेक्स्ट जोड़ें।
    table.rows[0][0].text_frame.text = "Merged Cells"

    # प्रस्तुति को डिस्क पर सेव करें।
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **मानक तालिकाओं में क्रमांक निर्धारण**

एक मानक तालिका में, सेल क्रमांकन सरल और शून्य-आधारित होता है। तालिका का पहला सेल (0, 0) (स्तंभ 0, पंक्ति 0) के रूप में इंडेक्स किया जाता है।

उदाहरण के तौर पर, 4 स्तंभ और 4 पंक्तियों वाली तालिका में सेल इस प्रकार क्रमांकित होते हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

निम्नलिखित Python उदाहरण दर्शाता है कि इस शून्य-आधारित क्रमांकन का उपयोग करके कोशिकाओं का संदर्भ कैसे दें:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # 4 स्तंभ और 4 पंक्तियों के साथ एक तालिका जोड़ें।
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **मौजूदा तालिका तक पहुंचना**

यह अनुभाग Aspose.Slides का उपयोग करके प्रस्तुति में मौजूदा तालिका को खोजने और उसके साथ कार्य करने का तरीका समझाता है। आप सीखेंगे कि स्लाइड पर तालिका कैसे ढूँढ़ें, उसकी पंक्तियों, स्तंभों और कोशिकाओं तक पहुँचें, और सामग्री या फॉर्मेटिंग को अपडेट करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स द्वारा तालिका वाली स्लाइड का रेफ़रेंस प्राप्त करें।
3. सभी [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) वस्तुओं में इटररेट करें जब तक आप तालिका नहीं पा लेते।
4. तालिका के साथ काम करने के लिए [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) ऑब्जेक्ट का उपयोग करें।
5. संशोधित प्रस्तुति को सेव करें।

{{% alert color="info" title="Note" %}}
यदि स्लाइड में कई तालिकाएँ हैं, तो `alternative_text` प्रॉपर्टी के आधार पर आवश्यक तालिका को खोजना बेहतर रहता है।
{{% /alert %}}

निम्नलिखित Python उदाहरण दर्शाता है कि मौजूदा तालिका तक कैसे पहुँचें और उसके साथ काम करें:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTX फ़ाइल लोड करने के लिये Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("sample.pptx") as presentation:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    table = None

    # शकलों (shapes) के माध्यम से इटररेट करें और मिले पहले तालिका को संदर्भित करें।
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # पहली पंक्ती की पहली कोशिका (cell) का टेक्स्ट सेट करें।
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # संशोधित प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ऐसा सेल खोजें जो टेक्स्ट फ्रेम का मालिक है**

जब सामान्य टेक्स्ट‑प्रोसेसिंग कोड को तालिका से एक [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) प्राप्त होता है, तो वह स्वामित्व वाले [Cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/) को प्राप्त करने के लिए [TextFrame.parent_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_cell/) प्रॉपर्टी का उपयोग करता है। तालिका‑सेल टेक्स्ट फ्रेम के लिए, [TextFrame.parent_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_cell/) सेट होता है और [TextFrame.parent_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_shape/) `None` रहता है, यद्यपि तालिका स्वयं एक Shape है।

सेल के निर्देशांक केवल‑पढ़नीय [Cell.first_column_index](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/first_column_index/) और [Cell.first_row_index](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/first_row_index/) प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं। [TextFrame.parent_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_cell/) भी केवल‑पढ़नीय है: यह स्वामी की ओर नेविगेशन प्रदान करता है लेकिन स्वामित्व नहीं बदलता। उपयोग से पहले हमेशा `None` के लिए जाँच करें।

तालिका‑सेल और Shape स्वामी को पहचानने वाले पूर्ण उदाहरण के लिये, जिसमें SmartArt नोड्स से जुड़े Shape शामिल हैं, देखें [Search and Replace Text](/slides/hi/python-net/search-and-replace-text/)।

## **तालिकाओं में टेक्स्ट को संरेखित करना**

यह अनुभाग Aspose.Slides के माध्यम से तालिका कोशिकाओं के भीतर टेक्स्ट प्लेसमेंट को नियंत्रित करना दर्शाता है। आप सीखेंगे कि कैसे टेक्स्ट को ऊँर्ध्वाधर रूप से एंकर करें और टेक्स्ट की दिशा बदलें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) ऑब्जेक्ट जोड़ें।
4. तालिका से एक [Cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/) ऑब्जेक्ट तक पहुँचें।
5. सेल में टेक्स्ट को ऊँर्ध्वाधर रूप से केंद्रित करें और टेक्स्ट दिशा सेट करें।
6. संशोधित प्रस्तुति को सेव करें।

निम्नलिखित Python उदाहरण दर्शाता है कि तालिका में टेक्स्ट को कैसे संरेखित करें:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation क्लास का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # कॉलम की चौड़ाइयाँ और पंक्तियों की ऊँचाइयाँ परिभाषित करें।
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # स्लाइड पर एक तालिका आकार जोड़ें।
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # टेक्स्ट को केंद्रित करें और ऊर्ध्वाधर अभिविन्यास सेट करें।
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करना**

यह अनुभाग Aspose.Slides में तालिका स्तर पर टेक्स्ट फ़ॉर्मेटिंग लागू करने का तरीका बताता है ताकि प्रत्येक सेल एक समान, एकीकृत शैली प्राप्त करे। आप फ़ॉन्ट आकार, संरेखण और मार्जिन को वैश्विक रूप से सेट करना सीखेंगे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) जोड़ें।
4. टेक्स्ट के फ़ॉन्ट आकार (फ़ॉन्ट ऊँचाई) सेट करें।
5. पैराग्राफ संरेखण और मार्जिन सेट करें।
6. ऊँर्ध्वाधर टेक्स्ट अभिविन्यास सेट करें।
7. संशोधित प्रस्तुति को सेव करें।

निम्नलिखित Python उदाहरण दर्शाता है कि तालिका में टेक्स्ट पर अपनी वांछित फ़ॉर्मेटिंग विकल्प कैसे लागू करें:

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

    # सभी तालिका कोशिकाओं के लिए दाएँ-संरेखित टेक्स्ट और दायाँ मार्जिन सेट करें।
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # सभी तालिका कोशिकाओं के लिए ऊर्ध्वाधर टेक्स्ट अभिविन्यास सेट करें।
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **बिल्ट‑इन तालिका शैली लागू करना**

Aspose.Slides आपको कोड में सीधे पूर्वनिर्धारित शैलियों का उपयोग करके तालिकाओं को फॉर्मेट करने की अनुमति देता है। यह उदाहरण एक तालिका बनाता है, बिल्ट‑इन शैली लागू करता है, और परिणाम को सेव करता है—एक सुसंगत, पेशेवर फॉर्मेटिंग सुनिश्चित करने का कुशल तरीका।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिकाओं का आस्पेक्ट रेशियो लॉक करना**

एक Shape का आस्पेक्ट रेशियो उसकी आयामों का अनुपात होता है। Aspose.Slides `aspect_ratio_locked` प्रॉपर्टी प्रदान करता है, जो आपको तालिकाओं और अन्य Shapes के लिये आस्पेक्ट रेशियो को लॉक करने की अनुमति देती है।

निम्नलिखित Python उदाहरण दर्शाता है कि तालिका के लिये आस्पेक्ट रेशियो कैसे लॉक करें:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिये दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**

हां। तालिका एक [right_to_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/right_to_left/) प्रॉपर्टी उजागर करती है, और पैराग्राफ में [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/right_to_left/) होता है। दोनों का उपयोग करने से सेल के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं उपयोगकर्ताओं को अंतिम फ़ाइल में तालिका को स्थानांतरित या आकार बदलने से कैसे रोकूँ?**

[shape locks](/slides/hi/python-net/applying-protection-to-presentation/) का उपयोग करके मूविंग, रिसाइज़िंग, चयन आदि को निष्क्रिय करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या सेल के भीतर बैकग्राउंड के रूप में छवि डालना समर्थित है?**

हां। आप सेल के लिये एक [picture fill](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/) सेट कर सकते हैं; चयनित मोड (स्ट्रेट या टाइल) के अनुसार छवि सेल क्षेत्र को ढक लेगी।