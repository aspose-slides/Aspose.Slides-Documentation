---
title: Manage Chart Data Series in Python
linktitle: Data Series
type: docs
url: /hi/python-net/chart-series/
keywords:
- चार्ट सीरीज़
- सीरीज़ ओवरलैप
- सीरीज़ रंग
- श्रेणी रंग
- सीरीज़ नाम
- डेटा पॉइंट
- सीरीज़ गैप
- PowerPoint
- प्रस्तुतिकरण
- Python
- Aspose.Slides
description: "Python के लिए PowerPoint (PPT/PPTX) में चार्ट डेटा सीरीज़ को प्रबंधित करना सीखें, व्यावहारिक कोड उदाहरणों और सर्वोत्तम प्रथाओं के साथ ताकि आप अपनी डेटा प्रस्तुतिकरण को बेहतर बना सकें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python में [ChartSeries](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/) की भूमिका का वर्णन करता है, यह दर्शाता है कि प्रस्तुतियों में डेटा कैसे संरचित और दृश्यीकृत किया जाता है। ये ऑब्जेक्ट मौलिक तत्व प्रदान करते हैं जो चार्ट में व्यक्तिगत डेटा बिंदुओं, श्रेणियों और रूप‑रंग पैरामीटर को निर्धारित करते हैं। [ChartSeries](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/) के साथ काम करके, डेवलपर्स बेस डेटा स्रोतों को सहजता से एकीकृत कर सकते हैं और यह नियंत्रित कर सकते हैं कि जानकारी कैसे प्रदर्शित होती है, जिससे गतिशील, डेटा‑ड्रिवन प्रस्तुतियां बनती हैं जो अंतर्दृष्टि और विश्लेषण को स्पष्ट रूप से संप्रेषित करती हैं।

एक सीरीज़ चार्ट में प्लॉट किए गए संख्याओं की पंक्ति या कॉलम होती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **सीरीज़ ओवरलैप सेट करें**

[ChartSeries.overlap](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/overlap/) प्रॉपर्टी -100 से 100 की सीमा निर्दिष्ट करके 2D चार्ट में बार और कॉलम के ओवरलैप को नियंत्रित करती है। चूंकि यह प्रॉपर्टी व्यक्तिगत चार्ट सीरीज़ के बजाय सीरीज़ ग्रुप से जुड़ी है, इसलिए यह सीरीज़ स्तर पर केवल-रीड है। ओवरलैप मान को कॉन्फ़िगर करने के लिए, `parent_series_group.overlap` रीड/राइट प्रॉपर्टी का उपयोग करें, जो उस ग्रुप की सभी सीरीज़ पर निर्दिष्ट ओवरलैप लागू करती है।

नीचे एक Python उदाहरण दिया गया है जो दिखाता है कि प्रस्तुतिकरण कैसे बनाएं, क्लस्टर्ड कॉलम चार्ट जोड़ें, पहली चार्ट सीरीज़ तक पहुंचें, ओवरलैप सेटिंग कॉन्फ़िगर करें, और फिर परिणाम को PPTX फ़ाइल के रूप में सहेजें:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # सीरीज़ ओवरलैप सेट करें।
        series.parent_series_group.overlap = series_overlap

    # प्रेजेंटेशन फ़ाइल को डिस्क पर सहेजें।
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![सीरीज़ ओवरलैप](series_overlap.png)

## **सीरीज़ फ़िल रंग बदलें**

Aspose.Slides चार्ट सीरीज़ के फ़िल रंग को अनुकूलित करना आसान बनाता है, जिससे आप विशिष्ट डेटा बिंदुओं को हाइलाइट कर सकते हैं और दृश्यतः आकर्षक चार्ट बना सकते हैं। यह [Format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/format/) ऑब्जेक्ट के माध्यम से संभव होता है, जो विभिन्न फ़िल प्रकार, रंग कॉन्फ़िगरेशन और अन्य उन्नत स्टाइलिंग विकल्पों को सपोर्ट करता है। स्लाइड में चार्ट जोड़ने और इच्छित सीरीज़ तक पहुँचने के बाद, बस सीरीज़ प्राप्त करें और उपयुक्त फ़िल रंग लागू करें। ठोस फ़िल के अलावा, आप ग्रेडिएंट या पैटर्न फ़िल का उपयोग करके डिज़ाइन लचीलापन बढ़ा सकते हैं। आवश्यकतानुसार रंग सेट करने के बाद, अपडेटेड रूप को अंतिम रूप देने के लिए प्रस्तुतिकरण को सहेजें।

निम्नलिखित Python कोड उदाहरण दिखाता है कि पहली सीरीज़ का रंग कैसे बदलें:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # पहली सीरीज़ का रंग सेट करें।
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # प्रेजेंटेशन फ़ाइल को डिस्क पर सहेजें।
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![सीरीज़ का रंग](series_color.png)

## **सीरीज़ का नाम बदलें**

Aspose.Slides चार्ट सीरीज़ के नाम बदलने का एक सरल तरीका प्रदान करता है, जिससे डेटा को स्पष्ट और अर्थपूर्ण रूप से लेबल करना आसान हो जाता है। चार्ट डेटा में संबंधित वर्कशीट सेल तक पहुँचकर, डेवलपर्स डेटा प्रस्तुति को अनुकूलित कर सकते हैं। यह संशोधन तब उपयोगी होता है जब सीरीज़ के नाम को डेटा के संदर्भ के आधार पर अपडेट या स्पष्ट करने की आवश्यकता होती है। सीरीज़ का नाम बदलने के बाद, परिवर्तन को स्थायी करने के लिए प्रस्तुतिकरण को सहेजा जा सकता है।

नीचे एक Python कोड स्निपेट दिया गया है जो इस प्रक्रिया को क्रियान्वित करता है।

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # पहली सीरीज़ का नाम सेट करें।
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # प्रेजेंटेशन फ़ाइल को डिस्क पर सहेजें।
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

निम्नलिखित Python कोड सीरीज़ का नाम बदलने का वैकल्पिक तरीका दिखाता है:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # पहली सीरीज़ का नाम सेट करें।
    series.name.as_cells[0].value = series_name

    # प्रेजेंटेशन फ़ाइल को डिस्क पर सहेजें।
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```

परिणाम:

![सीरीज़ का नाम](series_name.png)

## **स्वचालित सीरीज़ फ़िल रंग प्राप्त करें**

Aspose.Slides for Python आपको प्लॉट एरिया के भीतर चार्ट सीरीज़ के स्वचालित फ़िल रंग प्राप्त करने की अनुमति देता है। [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाने के बाद, आप इंडेक्स द्वारा वांछित स्लाइड का रेफ़रेंस पा सकते हैं, फिर अपनी पसंद के प्रकार (जैसे `ChartType.CLUSTERED_COLUMN`) से एक चार्ट जोड़ सकते हैं। चार्ट में सीरीज़ तक पहुँचकर, आप स्वचालित फ़िल रंग प्राप्त कर सकते हैं।

नीचे दिया गया Python कोड इस प्रक्रिया को विस्तार से दर्शाता है।

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # सीरीज़ का फ़िल रंग प्राप्त करें।
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```

उदाहरण आउटपुट:

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **सीरीज़ के लिए इनवर्ट फ़िल रंग सेट करें**

जब आपका डेटा सीरीज़ दोनों सकारात्मक और नकारात्मक मानों को शामिल करता है, तो सभी कॉलम या बार को एक ही रंग से भरना चार्ट को पढ़ना कठिन बना देता है। Aspose.Slides for Python आपको इनवर्ट फ़िल रंग असाइन करने की सुविधा देता है—एक अलग फ़िल जो शून्य से नीचे गिरने वाले डेटा बिंदुओं पर स्वचालित रूप से लागू होता है—ताकि नकारात्मक मान तुरंत दिखें। इस अनुभाग में आप सीखेंगे कि इस विकल्प को कैसे सक्षम करें, उचित रंग चुनें, और अपडेटेड प्रस्तुतिकरण को सहेजें।

निम्नलिखित कोड उदाहरण इस कार्य को दर्शाता है:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # नई श्रेणियाँ जोड़ें।
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # एक नई सीरीज़ जोड़ें।
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # सीरीज़ डेटा भरें।
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # सीरीज़ के लिए रंग सेटिंग्स निर्धारित करें।
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![इनवर्टेड ठोस फ़िल रंग](inverted_solid_fill_color.png)

आप पूरे सीरीज़ के बजाय एकल डेटा पॉइंट के लिए फ़िल रंग को इनवर्ट कर सकते हैं। बस इच्छित `ChartDataPoint` तक पहुंचें और उसकी `invert_if_negative` प्रॉपर्टी को `True` सेट करें।

निम्नलिखित कोड उदाहरण दिखाता है कि इसे कैसे किया जाए:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **विशिष्ट डेटा पॉइंट्स के लिए डेटा साफ़ करें**

कभी-कभी एक चार्ट में परीक्षण मान, आउटलेयर या अप्रचलित एंट्रीज़ होती हैं जिन्हें आपको पूरी सीरीज़ को पुनर्निर्मित किए बिना हटाना पड़ता है। Aspose.Slides for Python आपको किसी भी डेटा पॉइंट को इंडेक्स द्वारा लक्षित करने, उसकी सामग्री साफ़ करने और तुरंत प्लॉट को रिफ्रेश करने की अनुमति देता है ताकि शेष पॉइंट्स स्थानांतरित हों और एक्सिस स्वचालित रूप से पुन: स्केल हो जाए।

निम्नलिखित कोड उदाहरण इस कार्य को दर्शाता है:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```

## **सीरीज़ गैप चौड़ाई सेट करें**

गैप चौड़ाई समीपस्थ कॉलम या बार के बीच खाली स्थान की मात्रा को नियंत्रित करती है—विस्तृत गैप व्यक्तिगत श्रेणियों को उजागर करते हैं, जबकि संकरी गैप एक घना, अधिक कॉम्पैक्ट लुक बनाते हैं। Aspose.Slides for Python के माध्यम से आप इस पैरामीटर को पूरी सीरीज़ के लिये सूक्ष्म‑समायोजित कर सकते हैं, जिससे आपके प्रस्तुतिकरण को आवश्यक दृश्य संतुलन प्राप्त हो बिना मूल डेटा बदले।

निम्नलिखित कोड उदाहरण दिखाता है कि सीरीज़ के लिए गैप चौड़ाई कैसे सेट करें:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# एक खाली प्रस्तुति बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड तक पहुंचें।
    slide = presentation.slides[0]

    # डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # प्रेजेंटेशन को डिस्क पर सहेजें।
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # gap_width मान सेट करें।
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # प्रेजेंटेशन को डिस्क पर सहेजें।
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![गैप चौड़ाई](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एकल चार्ट में शामिल की जा सकने वाली सीरीज़ की संख्या पर कोई सीमा है?**

Aspose.Slides द्वारा जोड़ी गई सीरीज़ की संख्या पर कोई निश्चित सीमा नहीं लगाई गई है। व्यावहारिक सीमा चार्ट की पठनीयता और आपके एप्लिकेशन की उपलब्ध मेमोरी द्वारा निर्धारित होती है।

**यदि क्लस्टर के भीतर कॉलम बहुत करीब या बहुत दूर हों तो क्या करें?**

उस सीरीज़ (या उसके पैरेंट सीरीज़ ग्रुप) के लिए [gap_width](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/gap_width/) सेटिंग समायोजित करें। मान बढ़ाने से कॉलम के बीच की जगह बढ़ती है, जबकि घटाने से वे एक-दूसरे के करीब आ जाते हैं।