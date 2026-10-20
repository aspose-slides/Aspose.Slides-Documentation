---
title: PPTX में चार्ट आकार बदलने के लिए कार्य समाधान
type: docs
weight: 60
url: /hi/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- चार्ट आकार बदलना
- Excel चार्ट
- OLE ऑब्जेक्ट
- चार्ट एम्बेड करें
- PowerPoint
- प्रस्तुति
- Python via .NET
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ एम्बेडेड Excel OLE ऑब्जेक्ट का उपयोग करने पर PPTX में अप्रत्याशित चार्ट आकार बदलने की समस्या को ठीक करें। चार्ट और OLE फ्रेम के आकार को सुसंगत रखने के लिए निश्चित चार्ट आयाम सेट करें।"
---
## **समीक्षा**

Aspose घटकों का उपयोग करके PowerPoint प्रस्तुतियों में OLE ऑब्जेक्ट्स के रूप में सम्मिलित Excel चार्ट पहली बार सक्रिय करने के बाद आकार बदल सकते हैं। इससे सक्रिय करने से पहले और बाद में चार्ट की उपस्थिति में स्पष्ट अंतर हो सकता है। यह लेख समझाता है कि आकार परिवर्तन क्यों होता है और OLE फ्रेम के साथ निश्चित चार्ट आयामों को मिलाकर इसे रोकने का तरीका दिखाता है।

हमने [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hi/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) में बताया था कि Aspose.Cells for Python via .NET का उपयोग करके Excel चार्ट कैसे बनाएं और Aspose.Slides for Python via .NET का उपयोग करके उसे PowerPoint प्रस्तुति में कैसे सम्मिलित करें। [object preview issue](/slides/hi/python-net/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए, हमने चार्ट छवि को चार्ट के OLE ऑब्जेक्ट फ्रेम में सौंपा। आउटपुट प्रस्तुति में, जब आप चार्ट छवि दिखाने वाले OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करते हैं, तो Excel चार्ट सक्रिय हो जाता है। उपयोगकर्ता एम्बेड किए गए Excel वर्कबुक को संपादित कर सकते हैं और सक्रिय वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर वापस आने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाता है, और आकार परिवर्तन कारक दोनों OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के मूल आकारों पर निर्भर करता है।

## **आकार बदलने का कारण**

एंबेडेड Excel वर्कबुक की अपनी विंडो आयाम होते हैं, जिन्हें Excel वस्तु को पहली बार सक्रिय करने पर बनाए रखने की कोशिश करता है। स्लाइड पर OLE फ्रेम के आयाम स्वतंत्र रूप से परिभाषित होते हैं। जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint वस्तु के आकार पर बातचीत करते हैं ताकि एम्बेडिंग प्रक्रिया के भाग के रूप में उसके अनुपात बरकरार रहें। वर्कबुक विंडो और OLE फ्रेम के बीच अंतर वस्तु के आकार बदलने का कारण बन सकता है।

## **समाधान**

चार्ट के आकार को स्लाइड पर OLE फ्रेम के साथ मिलाएँ और चार्ट के आयामों को वर्कबुक विंडो से स्वतंत्र रखें। यह समाधान नई प्रस्तुति या मौजूदा टेम्पलेट दोनों के साथ काम करता है।

उदाहरण को Aspose.Cells for Python via .NET और Aspose.Slides for Python via .NET की आवश्यकता है। यह सक्रिय चार्ट शीट पर एक सरल कॉलम चार्ट बनाता है और वर्कबुक को XLS स्वरूप में एम्बेड करता है। कोई चार्ट प्रीव्यू छवि असाइन नहीं की गई है; PowerPoint में OLE ऑब्जेक्ट सक्रिय होने पर चार्ट दिखाई देता है।

उदाहरण 9.5 × 4‑इंच के OLE फ्रेम के साथ नई प्रस्तुति बनाता है जो बाएँ किनारे से 0.5 इंच और शीर्ष से 1 इंच की दूरी पर स्थित है। स्लाइड निर्देशांक और आयाम पॉइंट में होते हैं (प्रति इंच 72 पॉइंट)। मौजूदा प्रस्तुति के लिए, देखें [Use a Template](#use-a-template)।

## **निश्चित चार्ट आकार सेट करें**

[size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) को false सेट करें ताकि चार्ट आयामों को वर्कबुक विंडो से स्वतंत्र रखा जा सके। [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) के आयामों को [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) और [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/) के माध्यम से सेट करें, पॉइंट को पिक्सेल में बदलते हुए 96 पिक्सेल प्रति इंच का उपयोग करें: 684 × 288 पॉइंट के फ्रेम का अर्थ 912 × 384 पिक्सेल के चार्ट से है। [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) को [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/) के CUSTOM मान पर सेट करें। उदाहरण में [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) का उपयोग करके वर्कबुक को एम्बेड किया गया है और 9.5 × 4‑इंच के OLE फ्रेम वाली प्रस्तुति सहेजी गई है।

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # स्लाइड निर्देशांक और आयाम पॉइंट में हैं (प्रति इंच 72 पॉइंट)।
    width = 684.0  # 9.5 इंच।
    height = 288.0  # 4 इंच।

    chart.size_with_window = False
    # पॉइंट को चार्ट पिक्सेल में बदलें, 96 पिक्सेल प्रति इंच का उपयोग करके।
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **टेम्पलेट का उपयोग करें**

एक मौजूदा प्रस्तुति के लिए आकार निर्धारण तर्क समान रहता है। उदाहरण को अनुकूलित करने के लिए:

1. एक खाली प्रस्तुति बनाने के बजाय टेम्पलेट प्रस्तुति लोड करें।
2. पहली स्लाइड में कम से कम तीन आकार हों, यह जाँचें, फिर इंडेक्स 2 पर स्थित आकार को प्लेसहोल्डर के रूप में उपयोग करें।
3. फ्रेम की चौड़ाई और ऊँचाई उस आकार से प्राप्त करें, न कि स्थिर मान 684 और 288 का उपयोग करें। आकार गणनाओं को जैसा है वैसा रखें।
4. स्थिर निर्देशांक 36 और 72 के बजाय प्लेसहोल्डर की स्थिति पर OLE फ्रेम जोड़ें।
5. प्रस्तुति सहेजने से पहले प्लेसहोल्डर को हटाएँ।

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में सक्रिय करने के बाद मेरा एम्बेडेड Excel चार्ट आकार क्यों बदलता है?**

यह इसलिए होता है क्योंकि जब पहली बार सक्रिय किया जाता है, तो Excel मूल विंडो आकार को पुनर्स्थापित करने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम की अपनी आयाम होते हैं। PowerPoint और Excel अनुपात बनाए रखने के लिए आकार पर बातचीत करते हैं, जिससे आकार परिवर्तन हो सकता है।

**मैं चार्ट और OLE फ्रेम के आकार को सुसंगत कैसे रख सकता हूँ?**

OLE फ्रेम के साथ मेल खाने वाले निश्चित चार्ट आयाम सेट करें और वर्कबुक को एम्बेड करने से पहले कस्टम चार्ट प्रिंट साइज़ का उपयोग करें। ऊपर दिया गया उदाहरण आवश्यक सेटिंग्स और इकाई परिवर्तनों को दर्शाता है।

**क्या वर्कबुक विंडो आकार को मिलाना पर्याप्त है?**

केवल वर्कबुक विंडो आकार को मिलाना सक्रिय करने के बाद OLE फ्रेम के आकार बदलने को विश्वसनीय रूप से रोकता नहीं है। उदाहरण में दिखाए गए अनुसार निश्चित चार्ट आयामों का उपयोग करें।

**क्या यह समाधान टेम्पलेट-आधारित प्रस्तुतियों और नई प्रस्तुतियों दोनों के साथ काम करता है?**

हाँ। टेम्पलेट के लिए, प्लेसहोल्डर के आयाम और स्थिति का उपयोग करें। नई प्रस्तुति के लिए, फ्रेम के आयाम और स्थिति सीधे निर्दिष्ट करें।

**क्या मैं इस उदाहरण को अन्य स्प्रेडशीट प्रोग्रामों में बने चार्ट के साथ उपयोग कर सकता हूँ?**

उदाहरण Aspose.Cells द्वारा बनाई गई Excel वर्कबुक का उपयोग करता है। यह अन्य स्प्रेडशीट प्रोग्रामों के लिए सक्रियता व्यवहार नहीं दिखाता है।

## **संबंधित अनुभाग**

- [Excel चार्ट बनाना और उन्हें OLE ऑब्जेक्ट्स के रूप में प्रस्तुतियों में एम्बेड करना](/slides/hi/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [PowerPoint ऐड‑इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वचालित रूप से अपडेट करना](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)