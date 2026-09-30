---
title: Python के साथ प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधन
type: docs
weight: 10
url: /hi/python-net/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुंच
- आस्पेक्ट रेशियो
- पाठ संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument स्लाइड्स में तालिकाओं को बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सरल बनाने के लिए सरल कोड उदाहरणों की खोज करें।"
---
## **परिचय**

PowerPoint में तालिकाएँ जानकारी को पंक्तियों और स्तंभों में व्यवस्थित करती हैं, जिससे मान पढ़ना और तुलना करना आसान हो जाता है।

Aspose.Slides [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) और [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) कक्षाएं तथा अन्य प्रकार प्रदान करता है जिससे आप प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकते हैं।

## **शुरू से तालिका बनाना**

एक तालिका बनाएं जिसमें उसकी स्थिति, कॉलम चौड़ाई और पंक्ति ऊँचाई निर्दिष्ट हों। स्लाइड में जोड़ने के बाद आप सेल की सीमाओं को स्वरूपित कर सकते हैं, कोशिकाओं को मिला सकते हैं, और पाठ डाल सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास की नई इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. पॉइंट्स में कॉलम चौड़ाइयों की सूची निर्धारित करें।
4. पॉइंट्स में पंक्ति ऊँचाइयों की सूची निर्धारित करें।
5. स्लाइड में [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) ऑब्जेक्ट को [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) मेथड के माध्यम से जोड़ें।
6. प्रत्येक [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) पर इटररेट करके ऊपर, नीचे, दाएं और बाएं सीमाओं का स्वरूप लागू करें।
7. तालिका की पहली पंक्ति के पहले दो सेल्स को मर्ज करें।
8. मर्ज किए गए सेल को उसके [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) प्रॉपर्टी के माध्यम से एक्सेस करें।
9. मर्ज किए गए सेल में पाठ सेट करें।
10. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण (100, 50) पॉइंट्स पर तीन कॉलम और पाँच पंक्तियों वाली तालिका बनाता है। यह 5 पॉइंट्स चौड़ाई वाली लाल सीमाएँ लागू करता है, पहली पंक्ति के पहले दो सेल्स को मर्ज करता है, और परिणाम को `table.pptx` के रूप में सहेजता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **मानक तालिका में क्रमांकन**

एक मानक तालिका में, सेल सूचकांक शून्य-आधारित होते हैं और क्रम (स्तंभ, पंक्ति) का उपयोग करते हैं। पहला सेल (0, 0) के रूप में सूचकांकित होता है। Python में, सेल को `table.rows[row_index][column_index]` द्वारा एक्सेस करें; इस अभिव्यक्ति में पंक्ति सूचकांक पहले आता है।

उदाहरण के लिए, 4 कॉलम और 4 पंक्तियों वाली तालिका में सेल्स इस प्रकार क्रमांकित होते हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह उदाहरण ऊपर दर्शाए गए 4 × 4 तालिका को बनाता है, जिसमें कॉलम चौड़ाइयाँ और पंक्ति ऊँचाइयाँ 70 पॉइंट्स हैं और 5 पॉइंट्स चौड़ी लाल सीमाएँ हैं। निर्देशांक सेल सूचकांकों को दर्शाते हैं; यह उदाहरण सेल्स को खाली छोड़ता है और तालिका को `StandardTables_out.pptx` के रूप में सहेजता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **मौजूदा तालिका तक पहुँचें**

तालिकाएँ स्लाइड के shape संग्रह में संग्रहीत होती हैं। आकारों (shapes) को इटररेट करके तालिका खोजें, फिर उसके सेल्स को पढ़ने या अपडेट करने के लिये [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) क्लास का उपयोग करें।

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
2. इंडेक्स द्वारा उस स्लाइड का संदर्भ प्राप्त करें जिसमें तालिका हो।
3. [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) ऑब्जेक्ट्स को इटररेट करें और जब तालिका मिले तो रोकें। यदि स्लाइड में कई तालिकाएँ हैं, तो आवश्यक तालिका पहचानने के लिये [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) का उपयोग करें।
4. लक्ष्य सेल में पाठ को अपडेट करें।
5. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण `UpdateExistingTable.pptx` खोलता है और पहली स्लाइड पर पहली तालिका को खोजता है। यह कॉलम 0, पंक्ति 1 पर सेल को `New` सेट करता है और परिणाम को `table1_out.pptx` के रूप में सहेजता है। इनपुट में कम से कम एक स्लाइड होना चाहिए, और उस स्लाइड की पहली तालिका में कम से कम एक कॉलम और दो पंक्तियाँ होनी चाहिए।

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

मौजूदा तालिका में पंक्ति का आकार बदलने और समझने के लिये कि उसकी वास्तविक ऊँचाई अनुरोधित न्यूनतम से अधिक क्यों हो सकती है, देखें [Control Row Height](/slides/hi/python-net/manage-rows-and-columns/#control-row-height)।

## **टेक्स्ट फ्रेम वाला सेल खोजें**

जब सामान्य टेक्स्ट-प्रोसेसिंग कोड एक तालिका से [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) प्राप्त करता है, तो स्वामित्व वाले [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) को प्राप्त करने के लिये [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) प्रॉपर्टी का उपयोग करें। एक तालिका-सेल टेक्स्ट फ्रेम के लिये, [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) सेट होती है और [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) `None` होती है, हालांकि तालिका स्वयं एक shape होती है।

सेल के निर्देशांक पढ़ने-केवल [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) और [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) प्रॉपर्टीज़ के द्वारा उपलब्ध हैं। [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) भी पढ़ने-केवल है: यह मालिक तक नेविगेशन प्रदान करती है लेकिन स्वामित्व नहीं बदलती। उपयोग करने से पहले हमेशा लौटाए गए सेल को `None` के लिये जांचें।

टेबल-सेल और shape मालिकों को पहचानने वाला पूर्ण उदाहरण, जिसमें SmartArt नोड्स से जुड़े shapes भी शामिल हैं, देखने के लिये देखें [Search and Replace Text](/slides/hi/python-net/search-and-replace-text/)।

## **तालिका में टेक्स्ट संरेखित करें**

आप व्यक्तिगत तालिका कोशिकाओं की ऊर्ध्वाधर एंकरिंग और पाठ दिशा को नियंत्रित कर सकते हैं। इस अनुभाग का उदाहरण पहले सेल के भीतर टेक्स्ट को केंद्रित करता है और उसे 270 डिग्री घुमाता है।

1. एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास की नई इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) ऑब्जेक्ट जोड़ें।
4. तालिका से एक [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) ऑब्जेक्ट एक्सेस करें।
5. पहले [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) को एक्सेस करें और उसका पाठ व रंग सेट करें।
6. सेल की [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) और [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) सेट करें।
7. संशोधित प्रस्तुति को सहेजें।

यह उदाहरण 4 × 4 तालिका को 120 पॉइंट्स की कॉलम चौड़ाई और 100 पॉइंट्स की पंक्ति ऊँचाई के साथ बनाता है। यह सेल (0, 0) में टेक्स्ट स्वरूपित करता है, पहली पंक्ति के बाकी सेल्स में मान जोड़ता है, और परिणाम को `Vertical_Align_Text_out.pptx` के रूप में सहेजता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

सभी तालिका कोशिकाओं में टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिये [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) का उपयोग करें। इसके ओवरलोड भाग, पैराग्राफ और टेक्स्ट फ्रेम फ़ॉर्मेटिंग को स्वीकार करते हैं, जिससे आप व्यक्तिगत कोशिकाओं के माध्यम से इटररेट किए बिना ये प्रॉपर्टीज़ सेट कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड से एक [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) ऑब्जेक्ट एक्सेस करें।
4. टेक्स्ट के लिये [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) सेट करें।
5. [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) और [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) सेट करें।
6. [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) सेट करें।
7. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण `table.pptx` खोलता है, जिसमें कम से कम एक स्लाइड पर प्रथम shape के रूप में तालिका होनी चाहिए। यह फ़ॉन्ट आकार को 25 पॉइंट्स सेट करता है, पैराग्राफ को दाएं संरेखित करता है और दाएं मार्जिन को 20 पॉइंट्स करता है, तथा टेक्स्ट को वर्टिकल बनाता है। स्वरूपित प्रस्तुति को `result.pptx` के रूप में सहेजा जाता है।

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका शैली प्रॉपर्टीज़ प्राप्त करें**

तालिका के प्रीसेट शैली को पढ़ने या असाइन करने के लिये [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) का उपयोग करें। यह उदाहरण एक तालिका पर [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) लागू करता है, प्रीसेट नाम प्रिंट करता है, और वही प्रीसेट दूसरी तालिका को असाइन करता है। दोनों तालिकाएँ `table-style.pptx` में सहेजी जाती हैं।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका का आस्पेक्ट रेशियो लॉक करें**

तालिका का आस्पेक्ट रेशियो उसकी चौड़ाई और ऊँचाई का अनुपात है। तालिका के लिये इस अनुपात को लॉक करने के लिये [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) का उपयोग करें।

नीचे दिया गया उदाहरण `pres.pptx` खोलता है, जिसमें कम से कम एक स्लाइड पर प्रथम shape के रूप में तालिका होनी चाहिए। यह वर्तमान लॉक स्थिति को प्रिंट करता है, आस्पेक्ट रेशियो लॉक को सक्षम करता है, अपडेटेड स्थिति (`True`) को प्रिंट करता है, और परिणाम को `pres-out.pptx` के रूप में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिये दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**

हाँ। तालिका में एक [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) प्रॉपर्टी होती है, और पैराग्राफ में [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/) होता है। दोनों का उपयोग करने से कोशिकाओं के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं अंतिम फ़ाइल में उपयोगकर्ताओं को तालिका को स्थानांतरित या आकार बदलने से कैसे रोकूं?**

[shape locks](/slides/hi/python-net/applying-protection-to-presentation/) का उपयोग करके स्थानांतरित करना, आकार बदलना, चयन इत्यादि को निष्क्रिय करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या किसी सेल के भीतर पृष्ठभूमि के रूप में छवि डालना समर्थित है?**

हाँ। आप सेल के लिये एक [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चयनित मोड (स्ट्रेट्च या टाइल) के अनुसार सेल क्षेत्र को कवर कर देगी।