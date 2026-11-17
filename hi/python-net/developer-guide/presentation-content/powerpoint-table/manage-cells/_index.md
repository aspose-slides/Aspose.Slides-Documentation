---
title: Python के साथ प्रस्तुतियों में तालिका कोशिकाओं का प्रबंधन
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/python-net/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं को मिलाएँ
- किनारा हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python में PowerPoint तालिका कोशिकाओं का प्रबंधन: मर्ज्ड कोशिकाओं की पहचान करें, किनारे हटाएँ, कोशिकाओं को विभाजित करें, और Aspose.Slides for Python के साथ .NET के माध्यम से पृष्ठभूमि रंग और छवियाँ सेट करें।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका सेल तक पहुंचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख यह बताता है कि मर्ज्ड तालिका सेल की पहचान कैसे करें, सेल किनारों को हटाएँ, सेल को मर्ज या स्प्लिट करने के बाद क्रमांक कैसे काम करता है, सेल की पृष्ठभूमि रंग कैसे बदलें, और तालिका सेल के भीतर एक छवि कैसे जोड़ें। उदाहरण दिखाते हैं कि प्रस्तुति कैसे बनाएँ या खोलें, स्लाइड से तालिका कैसे प्राप्त करें, सेल गुणों के माध्यम से सेल स्वरूपण कैसे अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides शून्य-आधारित अनुक्रमणिकाओं का उपयोग करता है। इस लेख में निर्देशांक को `(column, row)` के रूप में लिखा गया है।

## **विलीन किए गए तालिका सेल की पहचान**

यह उदाहरण मौजूदा प्रस्तुति को खोलता है और पहले स्लाइड पर पहले आकार को तालिका के रूप में एक्सेस करता है। यह मानता है कि स्लाइड और आकार मौजूद हैं और आकार एक तालिका है। फिर यह सभी पंक्तियों और स्तंभों को इटरित करता है और [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) का उपयोग करके मर्ज्ड क्षेत्रों में सेल की पहचान करता है। प्रत्येक मेल के लिए, यह सेल निर्देशांक को `row;column` क्रम में, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), और क्षेत्र के शुरूआती निर्देशांक, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) तथा [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) को प्रिंट करता है।

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

## **तालिका सेल किनारे हटाएँ**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) बनाकर उसकी पहली स्लाइड पर [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) द्वारा एक तालिका जोड़ें। स्तंभ की चौड़ाई, पंक्ति की ऊँचाई, तथा तालिका की स्थिति पॉइंट में निर्दिष्ट की गई है। उदाहरण सभी चार सेल किनारों को [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) सेट करता है, जिससे वे अदृश्य हो जाते हैं।

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

## **विकर्ण सेल किनारे जोड़ें**

[border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) का उपयोग करके ऊपर-बाएँ कोने से नीचे‑दाएँ कोने तक एक रेखा बनाएं, और [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) का उपयोग करके नीचे‑बाएँ कोने से ऊपर‑दाएँ कोने तक रेखा बनाएं। एक विकर्ण कोने के शीर्षक को चिह्नित कर सकता है; दोनों विकर्ण मिलकर X बनाते हैं जिससे सेल को अनुपयुक्त दर्शाया जा सकता है।

प्रत्येक विकर्ण एक [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/) है। उसकी [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) में, [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) को [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) सेट करें और एक [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) चुनें। रेखा की [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) को पॉइंट में सेट करें।

उदाहरण एक पंक्ति में तीन सेल बनाता है: एक लाल नीचे‑विकर्ण, एक नीला ऊपर‑विकर्ण, और दोनों विकर्ण। यह ऊपर, नीचे, बाएँ और दाएँ किनारों को अपरिवर्तित रखता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

एक विकर्ण स्वरूपण गुण है, न कि सेल का विभाजन। प्रत्येक सेल में एक ही [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) रहता है; विकर्ण के दोनों पक्षों के क्षेत्रों को स्वतंत्र रूप से संपादित नहीं किया जा सकता।

सहेजी गई तालिका, Microsoft PowerPoint में रेंडर की गई:

![तीन तालिका सेल दिखाते हैं एक लाल विकर्ण ऊपर‑बाएँ से नीचे‑दाएँ, एक नीला विकर्ण नीचे‑बाएँ से ऊपर‑दाएँ, तथा दोनों विकर्ण मिलकर X बनाते हैं.](diagonal-cell-borders.png)

*बाएँ से दाएँ: नीचे‑विकर्ण (लाल, 3 pt), ऊपर‑विकर्ण (नीला, 5 pt), तथा दोनों विकर्ण.*

## **तालिका सेल को मर्ज करें**

[merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) का उपयोग करके तालिका सेल की आयताकार श्रेणी को एक ही सेल में मिलाएँ। श्रेणी के ऊपर‑बाएँ और नीचे‑दाएँ कोने के सेल निर्दिष्ट करें। अंतिम तर्क नियंत्रित करता है कि मर्ज में निर्दिष्ट सीमा से बाहर के सेल शामिल हों या नहीं; `False` मर्ज को केवल उस सीमा में रखता है।

उदाहरण 70‑पॉइंट स्तंभों और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है, फिर `(1, 1)` से `(2, 2)` तक के चार मध्य सेल को मर्ज करता है। resulting सेल दो स्तंभ और दो पंक्तियों को कवर करता है, जबकि तालिका की अंतर्निहित ग्रिड चार स्तंभ और चार पंक्तियों को बरकरार रखती है। मर्ज्ड सेल की सामग्री या स्वरूपण तक पहुँचने के लिए, उसके ऊपर‑बाएँ स्थान का उपयोग करें: `table.rows[1][1]`। मर्ज्ड श्रेणी के अन्य स्थान तालिका ग्रिड का हिस्सा बने रहते हैं, इसलिए सीमा के बाहर के सेल के अनुक्रमणिकाएँ नहीं बदलतीं।

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

## **तालिका सेल को विभाजित करें**

पिछले उदाहरण में सेल मर्ज करने से तालिका ग्रिड बना रहता है। किसी सेल को विभाजित करने से नई ग्रिड स्तंभ जोड़ सकता है और दाएँ स्थित सेल के स्तंभ अनुक्रमणिकाएँ बदल सकती हैं। Aspose.Slides PowerPoint की तालिका ग्रिड मॉडल का पालन करता है।

यह उदाहरण 70‑पॉइंट स्तंभों और पंक्तियों वाली 4‑बाय‑4 तालिका बनाता है और सेल `(1, 1)` पर [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) को कॉल करता है। 70‑पॉइंट की आधी चौड़ाई दो समान‑चौड़ाई वाले सेल बनाने के लिए पास की जाती है।

इस विभाजन के बाद, दो आधे भाग `table.rows[1][1]` और `table.rows[1][2]` के रूप में एक्सेस किए जाते हैं। तालिका ग्रिड अब पाँच स्तम्भ रखती है: मूलतः स्तम्भ 2 और 3 में स्थित सेल क्रमशः स्तम्भ 3 और 4 में स्थानांतरित हो जाते हैं। पंक्ति अनुक्रमणिकाएँ अपरिवर्तित रहती हैं। विभाजन के बाद सेल तक पहुँचते समय इन अद्यतन स्तम्भ अनुक्रमणिकाओं का उपयोग करें।

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


<!-- visual-explanation:manage-cells:start -->
[![एक अनमर्ज्ड 70‑पॉइंट सेल दो 35‑पॉइंट सेल में विभाजित होता है, जिससे पाँचवाँ ग्रिड स्तम्भ जुड़ता है और दाएँ की अनुक्रमणिकाएँ शिफ्ट होती हैं.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*चौड़ाई विभाजन (1, 1) सेल को प्रभावित करता है, शून्य‑आधारित (column, row) अनुक्रमणिका का उपयोग करते हुए। अन्य पंक्तियों में सेल दोनों नई स्तम्भ स्थितियों को कवर करता रहता है.*
<!-- visual-explanation:manage-cells:end -->

### **पंक्ति या स्तम्भ स्पैन द्वारा मर्ज्ड सेल विभाजित करें**

डेटा पॉपुलेशन के लिए मर्ज्ड टेम्पलेट सेल को तैयार करने हेतु, मौजूदा पंक्ति सीमा पर विभाजन के लिए [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) या स्तम्भ सीमा पर विभाजन के लिए [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) का उपयोग करें।

`index` तर्क विभाजन के ऊपरी भाग में पंक्तियों या बाएँ भाग में स्तम्भों की संख्या गिनता है; यह मर्ज्ड क्षेत्र के सापेक्ष है:

- पंक्ति विभाजन: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)।
- स्तम्भ विभाजन: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)।

उदाहरण मानता है कि प्रस्तुति की पहली स्लाइड पर पहला आकार एक तालिका है, जिसमें `(1, 2)` और `(1, 3)` ऊर्ध्वाधर रूप से मर्ज्ड हैं। निचली स्थिति से शुरू करके यह [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) और [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) का उपयोग करके मूल स्थिति ढूँढता है और दोनों स्पैन की जाँच करता है। `split_by_row_span` को इंडेक्स 1 के साथ उपयोग करने से पंक्ति 2 और 3 अलग हो जाती हैं जिससे उत्पाद नाम मिलते हैं। क्षैतिज दो‑स्तम्भ मर्ज के लिए, `split_by_col_span` को इंडेक्स 1 के साथ उपयोग करें।

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

        # विभाजन के बाद तालिका से प्राप्त हुए कोशिकाओं को प्राप्त करें।
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

तालिका ग्रिड और आसपास के सेल अनुक्रमणिकाएँ अपरिवर्तित रहती हैं। परिणामी सेल को उनके निर्देशांक द्वारा प्राप्त करें; यहाँ दोनों की स्पैन 1 है और [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) `False` प्रिंट करता है। एक विभाजन के बाद भी बड़े क्षेत्रों का कुछ हिस्सा मर्ज्ड रह सकता है।

मूल पाठ और उसका स्वरूपण ऊपर (या बाएँ) सेल में बना रहता है; नया सेल खाली होता है लेकिन सेल की स्वरूपण जैसे भराव, किनारे और मार्जिन विरासत में लेता है। विभाजन के बाद सेल को भरें और आवश्यक पाठ स्वरूपण स्पष्ट रूप से सेट करें।

सहेजा गया प्रस्तुति अलग "Product A" और "Product B" सेल दिखाता है, जहाँ टेम्प्लेट का सेल स्वरूपण बरकरार रहता है। विवरण के लिए देखें [सेल API संदर्भ](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)।

### **निर्दिष्ट ऊँचाई पर सेल विभाजित करें**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) ऊपरी भाग की ऊँचाई को पॉइंट में लेता है। [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) ऊपरी भाग में मौजूद ग्रिड पंक्तियों की संख्या लेता है। दाएँ स्तम्भ में 40‑पॉइंट सेल को लंबवत केंद्रित करने के लिए, सेल की वास्तविक ऊँचाई में से 40 घटाएँ और शेष स्थान को बराबर ऊपर और नीचे विभाजित करें।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

पहला विभाजन एक ग्रिड पंक्ति जोड़ता है, जिससे नीचे की 90 पॉइंट `table.rows[1][1]` में रहती है। दूसरा विभाजन उस सेल को 40‑पॉइंट मध्य सेल और 50‑पॉइंट नीचे वाले सेल में बाँटता है। दाएँ स्तम्भ में अब तीन सेल क्रमशः 50, 40 और 50 पॉइंट ऊँचाई के हैं। बायाँ सेल सभी तीन पंक्तियों को अपनी मूल 140‑पॉइंट ऊँचाई में कवर करता है।

![बायाँ सेल पूरी तालिका की ऊँचाई को कवर करता है, बगल में तीन सेल हैं जिनमें मध्य में "Middle" स्थित है.](split-by-height.png)

## **तालिका सेल की पृष्ठभूमि रंग बदलें**

यह उदाहरण 150‑पॉइंट स्तंभों और 50‑पॉइंट पंक्तियों वाली तालिका बनाता है। यह सेल `(2, 3)` (तीसरे स्तम्भ और चौथे पंक्ति) के लिए [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) को solid और [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) को लाल सेट करता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका सेल के भीतर एक छवि जोड़ें**

इस उदाहरण को चलाने से पहले इनपुट छवि को कार्य‑डायरेक्टरी में रखें। यह छवि को [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) से लोड करता है और प्रस्तुति की इमेज कलेक्शन में [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) से जोड़ता है। फिर यह छवि को सेल `(0, 0)` (पहला सेल) के पिक्चर फिल में असाइन करता है।

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) छवि को सेल में भरने के लिए स्ट्रेच करता है, जिससे इसका पहलू अनुपात बदल सकता है। स्तंभ की चौड़ाई और पंक्ति की ऊँचाई पॉइंट में हैं। लोड की गई छवि उसके `with` ब्लॉक के समाप्त होते ही स्वचालित रूप से डिस्पोज़ हो जाती है।

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

**क्या मैं एक ही सेल के विभिन्न किनारों के लिए अलग‑अलग रेखा मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) किनारे अलग‑अलग गुण रखते हैं, इसलिए प्रत्येक किनारे की मोटाई और शैली अलग हो सकती है।

**यदि मैं सेल की पृष्ठभूमि में चित्र सेट करने के बाद स्तम्भ/पंक्ति का आकार बदलूँ तो छवि क्या होती है?**

व्यवहार [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेचिंग के साथ, छवि नए सेल के अनुसार समायोजित हो जाती है; टाइलिंग के साथ, टाइलें पुनः गणना की जाती हैं।

**क्या मैं सेल की पूरी सामग्री पर हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/python-net/manage-hyperlinks/) सेल की टेक्स्ट (portion) स्तर पर या संपूर्ण तालिका/shape स्तर पर सेट होते हैं। व्यवहार में, आप लिंक को एक भाग या सेल के सभी टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही सेल के भीतर विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। सेल के टेक्स्ट फ्रेम में [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (रन) समर्थित हैं, जिनमें फ़ॉन्ट फैमिली, शैली, आकार और रंग जैसी स्वतंत्र स्वरूपण हो सकती है।