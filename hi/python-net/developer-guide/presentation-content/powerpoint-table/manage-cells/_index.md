---
title: Python के साथ प्रस्तुतीकरण में तालिका कोशिकाओं का प्रबंधन
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/python-net/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाएं मिलाएँ
- सीमा हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python में PowerPoint तालिका कोशिकाओं का प्रबंधन: संग्रहीत कोशिकाओं की पहचान करें, सीमाएं हटाएँ, कोशिकाओं को विभाजित करें, और Aspose.Slides for Python के माध्यम से .NET के जरिए पृष्ठभूमि रंग और छवियाँ सेट करें।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुंचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख बताता है कि कैसे संग्रहीत तालिका कोशिकाओं की पहचान करें, कोशिका की सीमाएँ हटाएँ, कोशिकाओं को मिलाने या विभाजित करने के बाद उनकी संख्या के साथ काम करें, कोशिका का पृष्ठभूमि रंग बदलें, और तालिका कोशिका के अंदर एक छवि जोड़ें। उदाहरण दिखाते हैं कि कैसे प्रस्तुति बनाएं या खोलें, स्लाइड से तालिका प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका स्वरूपण अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides शून्य-आधारित सूचकांकों का उपयोग करता है। इस लेख में निर्देशांक को `(column, row)` के रूप में लिखा गया है।

## **एक संग्रहीत तालिका कोशिका की पहचान करें**

उदाहरण मौजूदा प्रस्तुति को खोलता है और पहली स्लाइड पर पहले आकार (shape) को तालिका के रूप में एक्सेस करता है। यह मानता है कि स्लाइड और आकार मौजूद हैं और आकार एक तालिका है। फिर यह सभी पंक्तियों और स्तंभों पर इटरिटेट करता है और [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) का उपयोग करके संग्रहीत क्षेत्रों में कोशिकाओं की पहचान करता है। प्रत्येक मिलान के लिए यह कोशिका निर्देशांक `row;column` क्रम में प्रिंट करता है, साथ ही [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), और क्षेत्र के प्रारंभिक निर्देशांक, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) और [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/)।

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **तालिका कोशिका की सीमाएँ हटाएँ**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) बनाएँ और उसके पहले स्लाइड में [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) का प्रयोग करके एक तालिका जोड़ें। कॉलम की चौड़ाइयाँ, पंक्ति की ऊँचाइयाँ और तालिका की स्थिति पॉइंट्स में निर्दिष्ट होती हैं। उदाहरण सभी चार सेल सीमाओं को [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) पर सेट करता है, जिससे वे अदृश्य हो जाते हैं।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका कोशिकाओं को मिलाएँ**

एक आयताकार सीमा की तालिका कोशिकाओं को एक सेल में मिलाने के लिए [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) का उपयोग करें। सीमा के शीर्ष-बाएँ और निचले-दाएँ कोनों पर स्थित कोशिकाओं को निर्दिष्ट करें। अंतिम तर्क निर्धारित करता है कि क्या मर्ज में निर्दिष्ट सीमा के बाहर की कोशिकाएँ शामिल हो सकती हैं; `False` मर्ज को उसी सीमा के भीतर रखता है।

उदाहरण 70‑पॉइंट कॉलम और पंक्तियों वाली 4‑by‑4 तालिका बनाता है, फिर `(1, 1)` से लेकर `(2, 2)` तक के चार केंद्र कोशिकाओं को मिलाता है। परिणामस्वरूप बनी कोशिका दो कॉलम और दो पंक्तियों को कवर करती है, जबकि तालिका की मूल ग्रिड में अभी भी चार कॉलम और चार पंक्तियां रहती हैं। मिलाई गई कोशिका की सामग्री या स्वरूपण तक पहुँचने के लिए, उसके शीर्ष‑बाएँ स्थान का उपयोग करें: इस उदाहरण में `table.rows[1][1]`। मर्ज रेंज में अन्य स्थितियां तालिका ग्रिड का हिस्सा बनी रहती हैं, इसलिए रेंज के बाहर की कोशिकाओं के सूचकांक नहीं बदलते।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका कोशिकाओं को विभाजित करें**

पिछले उदाहरण में कोशिकाओं को मिलाने से तालिका की ग्रिड बरकरार रहती है। किसी कोशिका को विभाजित करने से नया ग्रिड कॉलम प्रस्तुत हो सकता है और उसके दाईं ओर की कोशिकाओं के कॉलम सूचकांक बदल सकते हैं। Aspose.Slides PowerPoint की तालिका ग्रिड मॉडल का अनुसरण करता है।

यह उदाहरण 70‑पॉइंट कॉलम और पंक्तियों वाली 4‑by‑4 तालिका बनाता है और कोशिका `(1, 1)` पर [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) को कॉल करता है। कोशिका की 70‑पॉइंट चौड़ाई का आधा हिस्सा दो समान‑चौड़ाई वाली कोशिकाओं बनाने के लिए पास किया जाता है।

इस विभाजन के बाद, दोनों भाग `table.rows[1][1]` और `table.rows[1][2]` के रूप में पहुँच सकते हैं। तालिका ग्रिड अब पांच कॉलम रखती है: मूल रूप से कॉलम 2 और 3 में मौजूद कोशिकाएँ क्रमशः कॉलम 3 और 4 में स्थानांतरित हो जाती हैं। पंक्ति सूचकांक अपरिवर्तित रहता है। विभाजन के बाद कोशिकाओं को एक्सेस करते समय इन अपडेटेड कॉलम सूचकांकों का प्रयोग करें।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **पंक्ति या कॉलम स्पैन द्वारा संग्रहीत कोशिकाओं का विभाजन**

डेटा भरने के लिए संग्रहीत टेम्पलेट कोशिकाओं को तैयार करने हेतु, मौजूदा पंक्ति सीमा के साथ विभाजन के लिए [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) का उपयोग करें, या कॉलम सीमा के साथ विभाजन के लिए [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) का उपयोग करें।

`index` तर्क विभाजन के ऊपर भाग में पंक्तियों या बाएँ भाग में कॉलमों की संख्या गिनता है; यह संग्रहीत क्षेत्र के सापेक्ष होता है:

- पंक्ति विभाजन: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)।
- कॉलम विभाजन: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)।

उदाहरण मानता है कि प्रस्तुति की पहली स्लाइड पर पहला आकार एक तालिका है, जिसमें `(1, 2)` और `(1, 3)` को ऊर्ध्वाधर रूप से मिलाया गया है। निचले स्थान से शुरू करते हुए, यह मूल को खोजने के लिए [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) और [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) का उपयोग करता है और दोनों स्पैन की जाँच करता है। `split_by_row_span` को इंडेक्स 1 के साथ प्रयोग करने से उत्पाद नामों के लिए पंक्तियाँ 2 और 3 अलग हो जाती हैं। क्षैतिज दो‑कॉलम मर्ज के लिए, `split_by_col_span` को इंडेक्स 1 के साथ उपयोग करें।

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # विभाजन के बाद तालिका से प्राप्त हुई कोशिकाएँ।
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

तालिका ग्रिड और आसपास की कोशिका सूचकांक अपरिवर्तित रहते हैं। परिणामस्वरूप कोशिकाओं को उनके निर्देशांक द्वारा प्राप्त करें; यहाँ दोनों की स्पैन 1 है और [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) `False` प्रिंट करता है। एक विभाजन के बाद बड़े क्षेत्रों का कुछ भाग अभी भी संग्रहीत रह सकता है।

मूल पाठ और उसका स्वरूपण ऊपर (या बाएँ) वाली कोशिका में बना रहता है; नई कोशिका खाली होती है लेकिन भराव, सीमाएँ और मार्जिन जैसे सेल स्वरूपण को विरासत में प्राप्त करती है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक टेक्स्ट स्वरूपण स्पष्ट रूप से सेट करें।

सहेजी गई प्रस्तुति में "Product A" और "Product B" नाम की अलग‑अलग कोशिकाएँ होती हैं, जिनमें टेम्पलेट की कोशिका स्वरूपण बनी रहती है। विवरण के लिए [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) देखें।

## **तालिका कोशिका के पृष्ठभूमि रंग को बदलें**

यह उदाहरण 150‑पॉइंट कॉलम और 50‑पॉइंट पंक्तियों वाली तालिका बनाता है। यह सेल `(2, 3)` (तीसरा कॉलम और चौथी पंक्ति) के लिए [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) को solid और [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) को लाल सेट करता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका कोशिका के अंदर छवि जोड़ें**

इस उदाहरण को चलाने से पहले इनपुट छवि को कार्य निर्देशिका में रखें। यह छवि को [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) से लोड करता है और [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) द्वारा प्रस्तुति की इमेज कलेक्शन में जोड़ता है। फिर यह छवि को कोशिका `(0, 0)` (तालिका की पहली कोशिका) के चित्र भराव (picture fill) में असाइन करता है।

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) छवि को कोशिका में भरने के लिए विस्तारित करता है, जिससे उसका अनुपात बदल सकता है। कॉलम की चौड़ाइयाँ और पंक्तियों की ऊँचाइयाँ पॉइंट्स में हैं। लोड की गई छवि अपने `with` ब्लॉक के समाप्त होते ही स्वतः नष्ट हो जाती है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही कोशिका के विभिन्न पक्षों के लिए अलग-अलग रेखा मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) सीमाओं की अलग‑अलग प्रॉपर्टीज़ होती हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है।

**यदि मैं चित्र को कोशिका की पृष्ठभूमि के रूप में सेट करने के बाद कॉलम/पंक्ति का आकार बदलूँ तो छवि का क्या होगा?**

व्यवहार [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेच करने पर, छवि नई कोशिका के अनुसार समायोजित हो जाती है; टाइलिंग पर, टाइल्स पुनः गणना की जाती हैं।

**क्या मैं सभी सामग्री को एक कोशिका में हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/python-net/manage-hyperlinks/) को कोशिका के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरी तालिका/shape स्तर पर सेट किया जाता है। वास्तव में, आप लिंक को किसी भाग या पूरी कोशिका के टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही कोशिका में विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। कोशिका के टेक्स्ट फ्रेम में [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (रन) होते हैं जो स्वतंत्र स्वरूपण—फ़ॉन्ट परिवार, शैली, आकार, और रंग—को समर्थन देते हैं।