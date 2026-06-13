---
title: Python के साथ प्रस्तुतियों में तालिका कोशिकाओं का प्रबंधन
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/python-net/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं को मिलाएँ
- सीमा हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python के माध्यम से .NET के ज़रिये PowerPoint और OpenDocument में तालिका कोशिकाओं को आसानी से प्रबंधित करें। शीघ्रता से कोशिकाओं तक पहुँच, संशोधन और शैली सेट करने में निपुण बनें ताकि सुगम स्लाइड ऑटोमेशन प्राप्त हो सके।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और उन्हें संशोधित करने की सुविधा देता है। यह लेख यह समझाता है कि कैसे संयुक्त तालिका कोशिकाओं की पहचान करें, कोशिका सीमाओं को हटाएँ, कोशिका को मर्ज या स्प्लिट करने के बाद उनकी क्रमांकिंग के साथ काम करें, कोशिका की पृष्ठभूमि रंग बदलें, और तालिका कोशिका में छवि जोड़ें। उदाहरण दिखाते हैं कि कैसे प्रस्तुतिकरण बनायें या खोलें, स्लाइड से एक तालिका प्राप्त करें, कोशिका गुणों द्वारा स्वरूपण अपडेट करें, और संशोधित प्रस्तुतिकरण को PPTX फ़ाइल के रूप में सहेजें।

## **संयुक्त तालिका कोशिकाओं की पहचान**

हेडर या संबंधित डेटा को समूहित करने के लिए तालिकाओं में अक्सर संयुक्त कोशिकाएँ होती हैं। इस अनुभाग में आप देखेंगे कि कैसे निर्धारित करें कि कोई विशिष्ट कोशिका संयुक्त क्षेत्र का हिस्सा है और कैसे मास्टर (ऊपरी-बाएँ) कोशिका को संदर्भित करें ताकि आप पूरे ब्लॉक को सुसंगत रूप से पढ़ या स्वरूपित कर सकें।

1. Presentation वर्ग का एक उदाहरण बनाएं।[Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/)
2. पहले स्लाइड से तालिका प्राप्त करें।
3. संयुक्त कोशिकाओं को खोजने के लिए तालिका की पंक्तियों और स्तम्भों पर पुनरावृति करें।
4. जब संयुक्त कोशिकाएँ मिलें तो एक संदेश प्रिंट करें।

निम्नलिखित Python कोड प्रस्तुतिकरण में संयुक्त तालिका कोशिकाओं की पहचान करता है:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # मान लेते हैं कि पहली स्लाइड पर पहली आकृति एक तालिका है।
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **तालिका कोशिका सीमाओं को हटाएँ**

कभी‑कभी तालिका सीमाएँ सामग्री से ध्यान हटाती हैं या दृश्य अव्यवस्था बनाती हैं। यह अनुभाग दिखाता है कि चयनित कोशिकाओं—या किसी कोशिका के विशिष्ट पक्षों—की सीमाएँ कैसे हटाएँ, ताकि आप साफ़ लेआउट प्राप्त कर सकें और अपनी स्लाइड के डिज़ाइन के साथ बेहतर संरेखित हो सकें।

1. Presentation वर्ग का एक उदाहरण बनाएं।[Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/)
2. उसकी अनुक्रमणिका द्वारा स्लाइड प्राप्त करें।
3. स्तम्भ चौड़ाईयों की एक ऐरे निर्धारित करें।
4. पंक्ति ऊँचाइयों की एक ऐरे निर्धारित करें।
5. add_table मेथड का उपयोग करके स्लाइड में एक तालिका जोड़ें।[add_table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_table/)
6. प्रत्येक कोशिका पर पुनरावृति करके ऊपर, नीचे, बाएँ और दाएँ सीमाओं को साफ़ करें।
7. संशोधित प्रस्तुतिकरण को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड दिखाता है कि तालिका कोशिकाओं की सीमाएँ कैसे हटाएँ:

```python
import aspose.slides as slides

# PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation वर्ग का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # कॉलम की चौड़ाइयाँ और पंक्तियों की ऊँचाइयाँ निर्धारित करें।
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # स्लाइड में एक तालिका आकृति जोड़ें।
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # प्रत्येक कोशिका के लिए सीमा भराव को साफ़ करें।
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **संयुक्त कोशिकाओं में क्रमांकिंग**

यदि आप दो जोड़ी कोशिकाओं को मर्ज करते हैं—उदाहरण के लिए, (1, 1) × (2, 1) और (1, 2) × (2, 2)—तो परिणामी तालिका मर्जिंग के बिना तालिका के समान क्रमांकन रखेगी। निम्नलिखित Python कोड इस व्यवहार को प्रदर्शित करता है:

```python
import aspose.slides as slides

# PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation वर्ग का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # कॉलम की चौड़ाइयाँ और पंक्तियों की ऊँचाइयाँ निर्धारित करें।
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # स्लाइड में एक तालिका आकृति जोड़ें।
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # कोशिकाएँ (1,1) और (2,1) को मिलाएँ।
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # कोशिकाएँ (1, 2) और (2, 2) को मिलाएँ।
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # कोशिका सूचकांक प्रिंट करें।
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

आउटपुट:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **विखरी हुई कोशिकाओं में क्रमांकिंग**

पिछले उदाहरण में, जब तालिका कोशिकाएँ मर्ज की गई थीं, तो अन्य कोशिकाओं की क्रमांकिंग नहीं बदली थी। इस बार हम कोई मर्ज नहीं की गई सामान्य तालिका बनाते हैं और फिर कोशिका (1, 1) को स्प्लिट करके एक विशेष तालिका बनाते हैं। इस तालिका की क्रमांकिंग पर ध्यान दें—यह असामान्य दिख सकती है। फिर भी, यही Microsoft PowerPoint तालिका कोशिकाओं को क्रमांकित करता है, और Aspose.Slides उसी व्यवहार का अनुसरण करता है।

निम्नलिखित Python कोड इस व्यवहार को प्रदर्शित करता है:

```python
import aspose.slides as slides

# PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation वर्ग का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड तक पहुँचेँ।
    slide = presentation.slides[0]

    # कॉलम की चौड़ाइयाँ और पंक्तियों की ऊँचाइयाँ निर्धारित करें।
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # स्लाइड में एक तालिका आकृति जोड़ें।
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # कोशिका (1, 1) को विभाजित करें।
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # कोशिका सूचकांक प्रिंट करें।
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

आउटपुट:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **तालिका कोशिका की पृष्ठभूमि रंग बदलें**

निम्नलिखित Python उदाहरण दिखाता है कि तालिका कोशिका की पृष्ठभूमि रंग कैसे बदलें:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # नई तालिका बनाएं।
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # कोशिका के लिए पृष्ठभूमि रंग सेट करें।
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका कोशिकाओं में छवियाँ सम्मिलित करें**

यह अनुभाग Aspose.Slides में तालिका कोशिका में छवि सम्मिलित करने का तरीका दिखाता है। यह लक्ष्य कोशिका पर चित्र भराव लागू करने और डिस्प्ले विकल्पों जैसे स्ट्रेच या टाइल को कॉन्फ़िगर करने को कवर करता है।

1. Presentation वर्ग का एक उदाहरण बनाएं।[Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/)
2. उसकी अनुक्रमणिका द्वारा स्लाइड संदर्भ प्राप्त करें।
3. स्तम्भ चौड़ाईयों की एक ऐरे निर्धारित करें।
4. पंक्ति ऊँचाइयों की एक ऐरे निर्धारित करें।
5. add_table मेथड का उपयोग करके स्लाइड में एक तालिका जोड़ें।[add_table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_table/)
6. फ़ाइल से छवि लोड करें।
7. प्रस्तुति की छवियों में छवि जोड़ें ताकि एक PPImage प्राप्त हो सके।[PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/)
8. तालिका कोशिका के FillType को `PICTURE` सेट करें।[FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/)
9. छवि को तालिका कोशिका पर लागू करें और एक भराव मोड चुनें (जैसे, `STRETCH`)।
10. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड दिखाता है कि तालिका बनाते समय तालिका कोशिका के अंदर छवि कैसे रखें:

```python
import aspose.slides as slides

# Presentation ऑब्जेक्ट का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # कॉलम की चौड़ाइयाँ और पंक्तियों की ऊँचाइयाँ निर्धारित करें।
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # स्लाइड में एक तालिका आकृति जोड़ें।
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # छवि लोड करें और प्रस्तुति में जोड़ें ताकि PPImage प्राप्त हो सके।
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # छवि को पहली तालिका कोशिका पर लागू करें।
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**क्या मैं एक ही कोशिका के विभिन्न पक्षों के लिए अलग‑अलग रेखा मोटाई और शैली निर्धारित कर सकता हूँ?**

हाँ। शीर्ष [border_top](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cellformat/border_top/)/नीचे [border_bottom](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cellformat/border_bottom/)/बाएँ [border_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cellformat/border_left/)/दाएँ [border_right](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cellformat/border_right/) सीमाओं के अलग‑अलग गुण हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली भिन्न हो सकती है। यह लेख में प्रदर्शित स्तरीय सीमा नियंत्रण से तर्कसंगत रूप से अनुसरित है।

**यदि मैं चित्र को कोशिका की पृष्ठभूमि के रूप में सेट करने के बाद स्तम्भ/पंक्ति आकार बदलूँ तो छवि पर क्या प्रभाव पड़ेगा?**

व्यवहार [fill mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेच करने पर, छवि नई कोशिका के अनुसार समायोजित होती है; टाइल करने पर, टाइलें पुनः गणना की जाती हैं। लेख में कोशिका में छवि प्रदर्शन मोड का उल्लेख है।

**क्या मैं कोशिका की पूरी सामग्री को एक हाइपरलिंक असाइन कर सकता हूँ?**

हाइपरलिंक को कोशिका के टेक्स्ट फ़्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरी तालिका/शेप स्तर पर सेट किया जाता है। व्यवहार में, आप लिंक को किसी भाग या पूरी कोशिका के टेक्स्ट पर असाइन कर सकते हैं।[Hyperlinks](/slides/hi/python-net/manage-hyperlinks/)

**क्या मैं एक ही कोशिका के भीतर विभिन्न फ़ॉन्ट रख सकता हूँ?**

हाँ। कोशिका का टेक्स्ट फ़्रेम स्वतंत्र स्वरूपित [portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) (रन) को समर्थन देता है—फ़ॉन्ट परिवार, शैली, आकार, और रंग।