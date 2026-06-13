---
title: Python में प्रस्तुति चार्ट के प्लॉट एरिया को अनुकूलित करें
linktitle: प्लॉट एरिया
type: docs
url: /hi/python-net/chart-plot-area/
keywords:
- चार्ट
- प्लॉट एरिया
- प्लॉट एरिया की चौड़ाई
- प्लॉट एरिया की ऊँचाई
- प्लॉट एरिया का आकार
- लेआउट मोड
- PowerPoint
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument प्रेज़ेंटेशन में चार्ट प्लॉट एरिया को कैसे अनुकूलित करें, यह जानें। अपने स्लाइड दृश्यों को सहजता से सुधारें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट के प्लॉट एरिया के साथ काम करने का तरीका दिखाता है। यह समझाता है कि चार्ट लेआउट को वैलिडेट करके और फिर उसके X, Y, चौड़ाई और ऊँचाई मान पढ़कर प्लॉट एरिया की वास्तविक स्थिति और आकार कैसे प्राप्त किया जाए।

यह भी दर्शाता है कि जब लेआउट मैन्युअल रूप से सेट किया गया हो, तो `LayoutTargetType` का उपयोग करके प्लॉट एरिया का लेआउट मोड कैसे कॉन्फ़िगर किया जाता है, जिससे यह निर्धारित किया जा सके कि प्लॉट एरिया का आकार उसके आंतरिक क्षेत्र या बाहरी region (अक्ष और अक्ष लेबल सहित) द्वारा गणना किया गया है।

## **चार्ट प्लॉट एरिया की चौड़ाई और ऊँचाई प्राप्त करें**
Aspose.Slides for Python via .NET एक सरल API प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. पहली स्लाइड तक पहुँचें।
3. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
4. वास्तविक मान प्राप्त करने के लिए पहले IChart.ValidateChartLayout() मेथड को कॉल करें।
5. चार्ट तत्व का वास्तविक X स्थान (बायाँ) प्राप्त करता है, जो चार्ट के बाएँ ऊपर कोने के सापेक्ष होता है।
6. चार्ट तत्व का वास्तविक शीर्ष प्राप्त करता है, जो चार्ट के बाएँ ऊपर कोने के सापेक्ष होता है।
7. चार्ट तत्व की वास्तविक चौड़ाई प्राप्त करता है।
8. चार्ट तत्व की वास्तविक ऊँचाई प्राप्त करता है।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# चार्ट के साथ प्रस्तुति सहेजें
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट प्लॉट एरिया का लेआउट मोड सेट करें**
Aspose.Slides for Python via .NET एक सरल API प्रदान करता है जिससे चार्ट प्लॉट एरिया का लेआउट मोड सेट किया जा सके। प्रॉपर्टी **LayoutTargetType** को **ChartPlotArea** और **IChartPlotArea** क्लासेज़ में जोड़ा गया है। यदि प्लॉट एरिया का लेआउट मैन्युअल रूप से परिभाषित किया गया है तो यह प्रॉपर्टी दर्शाती है कि प्लॉट एरिया को उसके अंदर (अक्ष और अक्ष लेबल को शामिल नहीं) या बाहर (अक्ष और अक्ष लेबल सहित) क्यों लेआउट किया जाए। दो संभावित मान **LayoutTargetType** enum में परिभाषित हैं।

- **LayoutTargetType.Inner** - यह निर्दिष्ट करता है कि प्लॉट एरिया का आकार प्लॉट एरिया के आकार को निर्धारित करेगा, जिसमें टिक मार्क और अक्ष लेबल शामिल नहीं हैं।
- **LayoutTargetType.Outer** - यह निर्दिष्ट करता है कि प्लॉट एरिया का आकार प्लॉट एरिया, टिक मार्क, और अक्ष लेबल को निर्धारित करेगा।

नीचे नमूना कोड दिया गया है।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**वास्तविक_x, वास्तविक_y, वास्तविक_चौड़ाई, और वास्तविक_ऊँचाई किस इकाइयों में लौटाई जाती हैं?**  
पॉइंट्स में; 1 इंच = 72 पॉइंट्स। ये Aspose.Slides के निर्देशांक इकाइयाँ हैं।

**सामग्री के संदर्भ में प्लॉट एरिया और चार्ट एरिया में क्या अंतर है?**  
प्लॉट एरिया डेटा ड्रॉइंग क्षेत्र है (सिरीज़, ग्रिडलाइन, ट्रेंडलाइन आदि); चार्ट एरिया में आसपास के तत्व शामिल होते हैं (शीर्षक, लीजेंड आदि)। 3D चार्ट्स में, प्लॉट एरिया में दीवारें/फ़्लोर और अक्ष भी शामिल होते हैं।

**जब लेआउट मैन्युअल हो तो प्लॉट एरिया के X, Y, चौड़ाई और ऊँचाई को कैसे समझा जाता है?**  
ये चार्ट के कुल आकार के अंश (0–1) होते हैं; इस मोड में ऑटो‑पोजिशनिंग बंद होती है और आपने जो अंश सेट किए हैं वो उपयोग होते हैं।

**लीजेंड जोड़ने/हटाने के बाद प्लॉट एरिया की स्थिति क्यों बदल गई?**  
लीजेंड प्लॉट एरिया के बाहर चार्ट एरिया में स्थित होता है लेकिन लेआउट और उपलब्ध स्पेस को प्रभावित करता है, इसलिए ऑटो‑पोजिशनिंग के प्रभाव में होने पर प्लॉट एरिया स्थानांतरित हो सकता है। (यह PowerPoint चार्ट्स का सामान्य व्यवहार है।)