---
title: Python का उपयोग करके PowerPoint तालिकाओं में पंक्तियों और स्तंभों का प्रबंधन
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
- पंक्ति प्रतिलिपि
- स्तंभ प्रतिलिपि
- पंक्ति हटाएँ
- स्तंभ हटाएँ
- पंक्ति पाठ स्वरूपण
- स्तंभ पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint में तालिका पंक्तियों और स्तंभों का प्रबंधन करें और प्रस्तुति संपादन व डेटा अद्यतन को तेज़ बनाएं।"
---
## **परिचय**

Aspose.Slides for Python via .NET आपको PowerPoint प्रस्तुतियों में तालिका संरचना और स्वरूपण को [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) क्लास के माध्यम से प्रबंधित करने देता है। आप हेडर पंक्ति निर्धारित कर सकते हैं, पंक्तियों और स्तंभों को क्लोन या हटाकर सकते हैं, और पूरी पंक्ति या स्तंभ पर पाठ स्वरूपण लागू कर सकते हैं।

यह लेख इन कार्यों को Python उदाहरणों के साथ समझाता है। यह यह भी दिखाता है कि कैसे तालिका की शैली प्रीसेट को प्राप्त किया जा सके ताकि आप इसे पुनः उपयोग कर सकें। तालिका पंक्ति और स्तंभ संकेतांक शून्य-आधारित होते हैं।

## **पंक्ति की ऊँचाई नियंत्रित करें**

पंक्ति की न्यूनतम ऊँचाई पॉइंट में सेट करने के लिए [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) का उपयोग करें। यह एक निचली सीमा है, न कि निश्चित ऊँचाई। [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) वास्तविक ऊँचाई लौटाता है और केवल पढ़ने योग्य है। पंक्ति तक पहुँचने के लिए [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/) का उपयोग करें।

उदाहरण [row-height-input.pptx](row-height-input.pptx) लोड करता है, जिसमें पहले स्लाइड पर पहली आकृति के रूप में तालिका है। इसकी पहली पंक्ति 70 पॉइंट से शुरू होती है। सेल्स 18-पॉइंट Arial पाठ, रैपिंग, और 6-पॉइंट शीर्ष तथा निचले मार्जिन का उपयोग करते हैं; दूसरे स्तंभ के लंबे पाठ कई पंक्तियों में रैप होते हैं। उदाहरण न्यूनतम को 100 पॉइंट बढ़ाता है, फिर उसे 20 पॉइंट घटाता है, प्रत्येक परिवर्तन के बाद वास्तविक ऊँचाई प्रिंट करता है, और दोनों परिणाम सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

प्रदान की गई प्रस्तुति के साथ, न्यूनतम बढ़ाने से पंक्ति में जगह जोड़ती है। घटाने से वह अतिरिक्त जगह हट जाती है, लेकिन वास्तविक ऊँचाई 20 पॉइंट से अधिक रहती है क्योंकि पाठ और सेल मार्जिन को अधिक जगह की आवश्यकता होती है। केवल न्यूनतम को घटाने से पंक्ति को उसकी सामग्री द्वारा आवश्यक स्थान से नीचे नहीं धकेला जा सकता।

वास्तविक ऊँचाई को कई कारक प्रभावित करते हैं:

- **पाठ और फ़ॉन्ट आकार:** लंबा पाठ, स्पष्ट लाइन ब्रेक, या बड़ा फ़ॉन्ट अधिक ऊँची जगह की आवश्यकता कर सकता है।
- **रैपिंग और स्तंभ चौड़ाई:** रैपिंग सक्रिय होने पर, संकरी [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) अधिक पंक्तियों का उत्पादन कर सकती है। विस्तृत स्तंभ लंबवत आवश्यक जगह को कम कर सकता है।
- **सेल मार्जिन:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) और [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) ऊर्ध्वाधर जगह जोड़ते हैं। [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) और [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) पाठ के लिए उपलब्ध चौड़ाई को घटाते हैं और अतिरिक्त रैपिंग का कारण बन सकते हैं।

बिना मिलाए गए सेल वाली इस तालिका में, सबसे अधिक ऊर्ध्वाधर जगह की आवश्यकता वाला सेल पूरी पंक्ति के लिए सामग्री-आधारित निचली सीमा निर्धारित करता है। पंक्ति को छोटा करने के लिए, आपको पाठ को छोटा करना, फ़ॉन्ट आकार या मार्जिन घटाना, या स्तंभ को चौड़ा करना भी आवश्यक हो सकता है।

नीचे की छवियाँ समान तालिका को समान स्केल पर दिखाती हैं। इस रन में वास्तविक ऊँचाइयाँ 70, 100 और 55.2 पॉइंट थीं: अंतिम पंक्ति अपने 20‑पॉइंट न्यूनतम से अधिक ऊँची रही। सटीक पाठ माप आपके पर्यावरण में उपलब्ध फ़ॉन्ट के अनुसार बदल सकते हैं। सहेजे गए परिणाम डाउनलोड करें: [increased minimum](row-height-increased.pptx) और [decreased minimum](row-height-decreased.pptx).

| मूल: न्यूनतम 70 pt, वास्तविक 70 pt | वृद्धि: न्यूनतम 100 pt, वास्तविक 100 pt | कमी: न्यूनतम 20 pt, वास्तविक 55.2 pt |
| --- | --- | --- |
| ![मूल तालिका जिसमें 70‑पॉइंट पहली पंक्ति है।](row-height-before.png) | ![पहली पंक्ति का न्यूनतम 100 पॉइंट बढ़ाने के बाद तालिका।](row-height-increased.png) | ![पहली पंक्ति का न्यूनतम 20 पॉइंट घटाने के बाद तालिका; रैप्ड टेक्स्ट पंक्ति को न्यूनतम से अधिक ऊँचा रखता है।](row-height-decreased.png) |

## **पहली पंक्ति को हेडर के रूप में सेट करें**

[first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) प्रॉपर्टी का उपयोग करके पहली पंक्ति को हेडर स्वरूपण के लिए चिह्नित करें। इसकी उपस्थिति तालिका पर लागू शैली पर निर्भर करती है।

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास के साथ प्रस्तुति लोड करें।
2. पहली स्लाइड तक पहुँचें।
3. स्लाइड पर पहली आकृति के रूप में संग्रहीत तालिका तक पहुँचें।
4. उसकी पहली पंक्ति के लिए हेडर स्वरूपण सक्रिय करें।
5. संशोधित प्रस्तुति को सहेजें।

उदाहरण को `table.pptx` की आवश्यकता है जिसमें पहली स्लाइड पर पहली आकृति के रूप में तालिका है। यह पहली पंक्ति के लिए हेडर स्वरूपण सक्रिय करता है और `First_row_header.pptx` सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका की पंक्ति या स्तंभ को क्लोन करें**

सामग्री और स्वरूपण को पुनः उपयोग करने के लिए पंक्तियों या स्तंभों को क्लोन करें। आप कॉपी को तालिका के अंत में जोड़ सकते हैं या किसी विशिष्ट स्थिति पर सम्मिलित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास के साथ प्रस्तुति लोड करें।
2. पहली स्लाइड तक पहुँचें।
3. स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
4. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) मेथड के साथ तालिका जोड़ें।
5. आवश्यक पंक्तियों को क्लोन करें।
6. आवश्यक स्तंभों को क्लोन करें।
7. संशोधित प्रस्तुति को सहेजें।

उदाहरण को `Test.pptx` की आवश्यकता है जिसमें कम से कम एक स्लाइड हो। यह तीन स्तंभ और पाँच पंक्तियों वाली तालिका बनाता है, आयाम पॉइंट में निर्दिष्ट होते हैं। यह पहली पंक्ति और स्तंभ की प्रतियाँ जोड़ता है, फिर इंडेक्स 3 (चौथा स्थान) पर दूसरी पंक्ति और स्तंभ की प्रतियाँ सम्मिलित करता है। परिणामी तालिका में सात पंक्तियाँ और पाँच स्तंभ होते हैं। `False` आर्ग्युमेंट सन्निकट मिलाए गए पंक्तियों या स्तंभों में क्लोनिंग को अक्षम करता है; इस तालिका में कोई मिलाए गए सेल नहीं हैं।

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका से पंक्ति या स्तंभ हटाएँ**

तालिका में अब आवश्यक नहीं रही पंक्तियों या स्तंभों को हटाएँ। एक आइटम हटाने से उसके बाद की पंक्तियों या स्तंभों के संकेतांक शिफ्ट हो जाते हैं।

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास के साथ प्रस्तुति बनाएं।
2. पहली स्लाइड तक पहुँचें।
3. स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
4. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) मेथड के साथ तालिका जोड़ें।
5. दूसरी पंक्ति और दूसरा स्तंभ हटाएँ।
6. संशोधित प्रस्तुति को सहेजें।

यह उदाहरण तीन‑बाई‑तीन तालिका बनाता है और इंडेक्स 1 पर पंक्ति और स्तंभ हटाता है, जिससे `TestTable_out.pptx` में दो‑बाई‑दो तालिका बचती है। आयाम पॉइंट में हैं। `False` आर्ग्युमेंट सन्निकट मिलाए गए पंक्तियों या स्तंभों के हटाने को अक्षम करता है; इस तालिका में कोई मिलाए गए सेल नहीं हैं।

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

## **तालिका पंक्ति स्तर पर पाठ स्वरूपण सेट करें**

पूरी पंक्ति पर पाठ स्वरूपण लागू करें ताकि उसकी सभी कोशिकाएँ समान रहें। आप फ़ॉन्ट गुण, पैराग्राफ स्वरूपण और पाठ दिशा सेट कर सकते हैं बिना प्रत्येक सेल को अलग‑अलग स्वरूपित किए।

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास के साथ प्रस्तुति लोड करें।
2. पहली स्लाइड पर तालिका तक पहुँचें।
3. पहली पंक्ति के लिए [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) सेट करें।
4. पहली पंक्ति के लिए [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) और [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) सेट करें।
5. दूसरी पंक्ति के लिए [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) सेट करें।
6. संशोधित प्रस्तुति को सहेजें।

उदाहरण को `table.pptx` की आवश्यकता है जिसमें पहली स्लाइड पर पहली आकृति के रूप में तालिका है और कम से कम दो पंक्तियाँ हों। यह पहली पंक्ति पर 25‑पॉइंट पाठ, दायां संरेखण और 20‑पॉइंट दायां पैराग्राफ मार्जिन लागू करता है, फिर दूसरी पंक्ति में लंबवत पाठ सेट करता है।

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका स्तंभ स्तर पर पाठ स्वरूपण सेट करें**

पूरी स्तंभ पर पाठ स्वरूपण लागू करें ताकि उसकी सभी कोशिकाएँ समान रहें। आप फ़ॉन्ट गुण, पैराग्राफ स्वरूपण और पाठ दिशा सेट कर सकते हैं बिना प्रत्येक सेल को अलग‑अलग स्वरूपित किए।

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास के साथ प्रस्तुति लोड करें।
2. पहली स्लाइड पर तालिका तक पहुँचें।
3. पहले स्तंभ के लिए [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) सेट करें।
4. पहले स्तंभ के लिए [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) और [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) सेट करें।
5. दूसरे स्तंभ के लिए [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) सेट करें।
6. संशोधित प्रस्तुति को सहेजें।

उदाहरण को `table.pptx` की आवश्यकता है जिसमें पहली स्लाइड पर पहली आकृति के रूप में तालिका है और कम से कम दो स्तंभ हों। यह पहले स्तंभ पर 25‑पॉइंट पाठ, दायां संरेखण और 20‑पॉइंट दायां पैराग्राफ मार्जिन लागू करता है, फिर दूसरे स्तंभ में लंबवत पाठ सेट करता है।

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका शैली गुण प्राप्त करें**

[style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) प्रॉपर्टी का उपयोग करके तालिका पर लागू प्रीसेट को प्राप्त करें और उसे दूसरी तालिका पर पुनः उपयोग करें। यह व्यक्तिगत सेल स्वरूपण ओवरराइड के बजाय प्रीसेट की पहचान करता है।

उदाहरण एक तालिका बनाता है, [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) लागू करता है, और प्रीसेट को वापस पढ़ता है। यह `True` प्रिंट करता है जब प्राप्त प्रीसेट लागू किए गए प्रीसेट से मेल खाता है और तालिका को `table.pptx` में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पहले से बनाई गई तालिका पर PowerPoint थीम/शैलियां लागू कर सकता हूँ?**

हाँ। तालिका स्लाइड/लेआउट/मास्टर थीम को विरासत में मिलती है, और आप अभी भी उस थीम के ऊपर भराव, किनारों और पाठ रंगों को ओवरराइड कर सकते हैं।

**क्या मैं Excel की तरह तालिका पंक्तियों को सॉर्ट कर सकता हूँ?**

नहीं, Aspose.Slides तालिकाओं में बिल्ट‑इन सॉर्टिंग या फ़िल्टर नहीं होते। पहले मेमोरी में डेटा को सॉर्ट करें, फिर उस क्रम में तालिका पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (धारीदार) स्तंभ रख सकते हैं जबकि विशिष्ट कोशिकाओं पर कस्टम रंग बनाए रखें?**

हाँ। बैंडेड कॉलम सक्रिय करें, फिर विशिष्ट कोशिकाओं को स्थानीय स्वरूपण से ओवरराइड करें; कोशिका‑स्तर का स्वरूपण तालिका शैली पर प्रमुखता रखता है।