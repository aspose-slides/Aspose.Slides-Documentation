---
title: Python के साथ प्रस्तुतियों में 3D चार्ट अनुकूलित करें
linktitle: 3D चार्ट
type: docs
url: /hi/python-net/3d-chart/
keywords:
- 3D चार्ट
- घुमाव
- गहराई
- PowerPoint
- प्रस्तुतीकरण
- Python
- Aspose.Slides
description: Aspose.Slides for Python via .NET का उपयोग करके PowerPoint प्रस्तुतियों में 3D चार्ट बनाएं। Python उदाहरणों के साथ घुमाव, ऊँचाई अनुपात, चार्ट की गहराई और श्रृंखला के बीच की दूरी को समायोजित करें।
---
## **अवलोकन**

Aspose.Slides for Python via .NET आपको 3D चार्ट के दृश्य को [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) प्रॉपर्टी के माध्यम से अनुकूलित करने देती है। यह लेख दिखाता है कि कैसे घुमाव, ऊँचाई अनुपात, गहराई, समकोण अक्ष, और श्रृंखला के बीच की दूरी को समायोजित करें, फिर प्रस्तुति को PPTX स्वरूप में सहेजें।

## **3D चार्ट के घुमाव और गहराई सेट करें**

नीचे दिया गया उदाहरण एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) बनाता है और [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) का उपयोग करके अपने पहले स्लाइड में एक stacked 3D column chart जोड़ता है। यह डिफ़ॉल्ट श्रृंखला और श्रेणियों को दो श्रृंखलाओं में बदल देता है, जिनमें प्रत्येक में तीन मान होते हैं। वर्कशीट सूचकांक `0` चार्ट की पहली डेटा वर्कशीट को पहचानता है; पंक्ति `0` श्रृंखला नाम रखती है, और कॉलम `0` श्रेणी लेबल रखता है।

[rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) और [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) प्रॉपर्टी क्रमशः चार्ट का घुमाव 40 और 270 डिग्री पर सेट करती हैं। [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) इसकी गहराई को उसकी चौड़ाई के 150% पर सेट करता है, जबकि [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) पर्सपेक्टिव के बजाय समकोण अक्ष सक्षम करता है। परिणामी प्रस्तुति में इन 3D दृश्य सेटिंग्स वाले भरपूर चार्ट शामिल हैं।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **3D चार्ट सतह पर चित्र भराव लागू करें**

आप 3D चार्ट की [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/), और [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) को स्वतंत्र रूप से भर सकते हैं। सतह के [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) को `PICTURE` पर सेट करें और एक छवि असाइन करें। सतह पर छवि की एक ही प्रति फिट करने के लिए, दोनों [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) और सतह के [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) को `STRETCH` पर सेट करें।

कार्यशील डायरेक्टरी में [arrow.png](arrow.png) को सहेजें। उदाहरण चार्ट को घुमाता है और लंबवत अक्ष पर अधिकतम मान बढ़ाता है ताकि फ़्लोर कॉलम के बीच दिखाई दे। यह स्लाइड को दो बार क्लोन करता है, फिर प्रत्येक स्लाइड पर अलग सतह पर तीर लागू करता है। सभी तीन चार्ट समान डेटा, दृश्य कोण, और पृष्ठभूमि साझा करते हैं।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint तीन स्लाइड्स को निम्नानुसार दर्शाता है।

| साइड वॉल | बैक वॉल | फ़्लोर |
| --- | --- | --- |
| ![साइड वॉल के साथ चार्ट में इशारा करता तीर](side-wall.png) | ![बैक वॉल के पार दाएं इशारा करता तीर](back-wall.png) | ![कॉलमों के बीच फ़्लोर पर दाएं इशारा करता तीर](floor.png) |

## **3D चार्ट की ऊँचाई अनुपात समायोजित करें**

[Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) का उपयोग करके 3D चार्ट की ऊँचाई को उसकी चौड़ाई के प्रतिशत के रूप में सेट करें। यह स्लाइड पर चार्ट ऑब्जेक्ट का आकार बदले बिना 3D दृश्य के अनुपात बदलता है।

निम्न उदाहरण एक [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) चार्ट को डिफ़ॉल्ट डेटा (तीन श्रृंखला और चार श्रेणियाँ) के साथ बनाता है। यह 50 %, 100 % और 200 % ऊँचाई अनुपात के साथ तीन प्रस्तुतियाँ सहेजता है। चार्ट की स्थिति, चौड़ाई और ऊँचाई स्थिर रहती है। डेटा, घुमाव, गहराई, श्रृंखला दूरी, और स्वरूपण सभी तीन फ़ाइलों में समान हैं; केवल ऊँचाई प्रतिशत बदलता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

निम्न छवियाँ Microsoft PowerPoint का उपयोग करके निर्मित प्रस्तुतियों से निर्यात की गई हैं। छोटी प्रतिशत एक समतल दृश्य उत्पन्न करती है, जबकि बड़ी प्रतिशत उसी चार्ट ऑब्जेक्ट के भीतर एक ऊँचा दृश्य उत्पन्न करती है। PowerPoint दृश्य के अनुसार अक्ष टिक अंतराल और लेबल प्लेसमेंट को भी समायोजित कर सकता है।

| ऊँचाई: 50% | ऊँचाई: 100% | ऊँचाई: 200% |
| --- | --- | --- |
| ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 50 % पर सेट है](height_percent_50.png) | ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 100 % पर सेट है](height_percent_100.png) | ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 200 % पर सेट है](height_percent_200.png) |

इन प्रॉपर्टी चार्ट के विभिन्न पहलुओं को नियंत्रित करती हैं:

| प्रॉपर्टी | प्रभाव |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | 3D दृश्य की ऊँचाई को उसकी चौड़ाई के प्रतिशत के रूप में। |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | स्लाइड पर चार्ट ऑब्जेक्ट की ऊँचाई, पॉइंट्स में। |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | 3D दृश्य की गहराई को उसकी चौड़ाई के प्रतिशत के रूप में। |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | गहराई अक्ष पर श्रृंखलाओं के बीच की दूरी, मार्कर चौड़ाई के प्रतिशत के रूप में। |

ऊँचाई सेटिंग 3D कॉलम और बार चार्ट, जिसमें सिलेंडर, कोन, और पिरामिड प्रकार शामिल हैं, साथ ही 3D लाइन, एरिया, पाई और सतह चार्ट को प्रभावित करती है। उपर्युक्त तुलना सत्यापित `COLUMN_3D` प्रकार का उपयोग करती है। सेटिंग 2D `CLUSTERED_COLUMN` चार्ट या `BUBBLE_WITH_3D` चार्ट की उपस्थिति नहीं बदलती; ये नाम [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) एन्यूमरेशन के सदस्य हैं। अन्य चार्ट स्वरूप सेटिंग्स के लिए देखें [Chart Formatting](/slides/hi/python-net/chart-formatting/)।

## **श्रृंखलाओं के बीच की दरार समायोजित करें**

[ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) का उपयोग करके 3D चार्ट में डेटा श्रृंखलाओं के बीच गहराई अक्ष पर दूरी को मार्कर चौड़ाई के प्रतिशत के रूप में नियंत्रित करें। **0 से 500** तक के मान उपयोग करें, दोनों सहित: `0` गैप हटा देता है, जबकि बड़े मान दूरी बढ़ाते हैं। स्थिर चार्ट गहराई के साथ, गैप बढ़ाने से मार्कर गहराई अक्ष पर पतले हो जाते हैं।

समूह को [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) के माध्यम से एक्सेस करें। यह सेटिंग उस समूह की प्रत्येक श्रृंखला पर लागू होती है, न कि केवल उस श्रृंखला पर जिसका उपयोग करके इसे एक्सेस किया गया था। [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) केवल पढ़ने योग्य है और माता समूह की सेटिंग को दर्शाता है।

यह सेटिंग 3D कॉलम और बार चार्ट, उनके सिलेंडर, कोन, और पिरामिड रूपों सहित, तथा 3D लाइन और एरिया चार्ट को प्रभावित करती है। उपस्थिति इस पर निर्भर करती है कि श्रृंखलाएँ गहराई में व्यवस्थित हैं, क्लस्टर्ड हैं या स्टैक्ड हैं। अलग-अलग श्रृंखलाओं के बीच गैप की स्पष्ट तुलना के लिए, [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) एन्यूमरेशन से `ChartType.COLUMN_3D` का उपयोग करें।

इन प्रॉपर्टी चार्ट के विभिन्न पहलुओं को नियंत्रित करती हैं:

| प्रॉपर्टी | प्रभाव |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | गहराई अक्ष पर श्रृंखलाओं के बीच की दूरी, मार्कर चौड़ाई के प्रतिशत के रूप में। |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | सन्निहित बार या कॉलम क्लस्टर के बीच की दूरी, बार या कॉलम चौड़ाई के प्रतिशत के रूप में। |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | कुल चार्ट गहराई, चार्ट चौड़ाई के प्रतिशत के रूप में। |

निम्न स्वनिर्भर उदाहरण डिफ़ॉल्ट चार्ट डेटा (तीन श्रृंखला और चार श्रेणियाँ) का उपयोग करता है। यह दो प्रस्तुतियाँ सहेजता है जिनमें डेटा, घुमाव, गैप चौड़ाई और चार्ट गहराई समान हैं; केवल गैप गहराई बदलती है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

निम्न छवियाँ Microsoft PowerPoint का उपयोग करके निर्मित प्रस्तुतियों से निर्यात की गई हैं।

| गैप गहराई: 0% | गैप गहराई: 500% |
| --- | --- |
| ![गहराई अक्ष पर श्रृंखलाओं के बीच कोई गैप नहीं वाला 3D कॉलम चार्ट](gap_depth_0.png) | ![गहराई अक्ष पर श्रृंखलाओं के बीच 500 % गैप वाला 3D कॉलम चार्ट](gap_depth_500.png) |

## **3D श्रृंखला प्रकार और बार आकार बदलें**

एक क्लस्टर्ड सिलेंडर चार्ट में, पहली श्रृंखला सिलेंड्रिकल बार से शुरू होती है। उदाहरण प्रत्येक परिवर्तन से पहले और बाद में [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) और [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) को पढ़ता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| पहली श्रृंखला में परिवर्तन | `type` | `bar_3d_shape` |
| --- | --- | --- |
| चार्ट बनाएं | `CLUSTERED_CYLINDER` | `CYLINDER` |
| `type` को `CLUSTERED_CONE` पर सेट करें | `CLUSTERED_CONE` | `CONE` |
| `bar_3d_shape` को `BOX` पर सेट करें | `CLUSTERED_COLUMN_3D` | `BOX` |

`BOX` आकार सेट करने से श्रृंखला प्रकार भी `CLUSTERED_COLUMN_3D` में बदल जाता है। यदि आपका कोड श्रृंखला प्रकार के आधार पर शाखा बनाता है, तो आकार बदलने के बाद `series.type` पढ़ें। असाइनमेंट से पहले कैश किया गया मान अभी भी `CLUSTERED_CONE` शाखा का चयन करेगा।

![PowerPoint तुलना जिसमें पहली श्रृंखला बाएँ से दाएँ सिलेंडर, कोन और आयताकार कॉलम के रूप में दिखती है](series-shapes.png)

## **FAQ**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D वैरिएंट, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D, और 100 % Stacked Column 3D शामिल हैं, के साथ-साथ संबंधित 3D प्रकारों का समर्थन करता है, जो [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) एन्यूमरेशन में उजागर हैं। सटीक, अद्यतन सूची के लिए, स्थापित संस्करण के API रेफ़रेंस में [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) के सदस्यों को देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर छवि प्राप्त कर सकता हूँ?**

हां। आप [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) या [संपूर्ण स्लाइड को रेंडर करें](/slides/hi/python-net/convert-powerpoint-to-png/) का उपयोग करके चार्ट को PNG या JPEG जैसी फॉर्मेट में निर्यात कर सकते हैं। यह तब उपयोगी होता है जब आपको रास्टर पूर्वावलोकन चाहिए या PowerPoint की आवश्यकता के बिना दस्तावेज़, डैशबोर्ड या वेब पेज में चार्ट एम्बेड करना हो।

**बड़े 3D चार्ट बनाने और रेंडर करने की प्रदर्शन क्षमता कैसी है?**

प्रदर्शन डेटा मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणाम के लिए 3D प्रभाव न्यूनतम रखें, दीवारों और प्लॉट एरिया पर भारी टेक्सचर से बचें, संभव हो तो प्रत्येक श्रृंखला में डेटा पॉइंट की संख्या सीमित रखें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं से मेल खाने के लिए उपयुक्त रिज़ॉल्यूशन और आयामों के साथ आउटपुट रेंडर करें।