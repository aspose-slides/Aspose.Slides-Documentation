---
title: Python via Java का उपयोग करके प्रस्तुतियों में डोनट चार्ट को अनुकूलित करें
linktitle: डोनट चार्ट
type: docs
weight: 30
url: /hi/python-java/doughnut-chart/
keywords:
- डोनट चार्ट
- केंद्र गैप
- छेद का आकार
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में डोनट चार्ट बनाना और अनुकूलित करना सीखें, जो गतिशील प्रस्तुतियों के लिए PowerPoint फॉर्मेट को समर्थन करता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides में डोनट चार्ट के साथ काम करने का तरीका दिखाता है, जिसमें चार्ट को स्लाइड में जोड़ना, उसके केंद्र के छेद का आकार सेट करना, और प्रस्तुति को सहेजना शामिल है। यह [setDoughnutHoleSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) मेथड पर केंद्रित है और कोड में इस चार्ट प्रकार को अनुकूलित करने के लिए आवश्यक बुनियादी चरणों को प्रदर्शित करता है।

यह एक संक्षिप्त FAQ भी शामिल करता है जो संबंधित डोनट-चार्ट परिदृश्यों को कवर करता है, जैसे कई श्रृंखलाओं का उपयोग करके कई रिंग बनाना, एक्सप्लोडेड डोनट चार्ट के साथ काम करना, और चार्ट को रास्टर इमेज या SVG के रूप में निर्यात करना।

## **डोनट चार्ट में केंद्र गैप निर्धारित करें**

{{% alert color="info" title="ध्यान दें" %}}

Aspose.Slides for Python via Java डोनट चार्ट में छेद के आकार को निर्दिष्ट करने का समर्थन करता है। यह अनुभाग एक उदाहरण के साथ छेद के आकार को कैसे निर्दिष्ट किया जाए, दिखाता है।

{{% /alert %}}

डोनट चार्ट में छेद के आकार को निर्दिष्ट करने के लिए निम्नलिखित चरणों का अनुसरण करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट बनाएं।  
1. स्लाइड में एक डोनट चार्ट जोड़ें।  
1. डोनट चार्ट में छेद के आकार को निर्दिष्ट करें।  
1. प्रस्तुति को डिस्क पर लिखें।

निम्नलिखित उदाहरण डोनट चार्ट में छेद के आकार को सेट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Presentation क्लास का एक इंस्टेंस बनाइए।
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # प्रस्तुति को डिस्क पर लिखिए।
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**क्या मैं कई रिंग वाले मल्टी-लेवल डोनट बना सकता हूँ?**

हाँ। एक ही डोनट चार्ट में कई श्रृंखलाएँ जोड़ें—प्रत्येक श्रृंखला एक अलग रिंग बन जाती है। रिंग क्रम श्रृंखलाओं के संग्रह में उनके क्रम से निर्धारित होता है।

**क्या "एक्सप्लोडेड" डोनट (विभाजित स्लाइस) समर्थित है?**

हाँ। एक Exploded Doughnut [chart type](https://reference.aspose.com/slides/hi/python-java/aspose.slides/charttype/) और डेटा पॉइंट्स पर एक्सप्लोजन प्रॉपर्टी उपलब्ध है; आप व्यक्तिगत स्लाइस को अलग कर सकते हैं।

**रिपोर्ट के लिए डोनट चार्ट की इमेज (PNG/SVG) कैसे प्राप्त करूँ?**

एक चार्ट एक [shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) है; आप इसे एक [raster image](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) में रेंडर कर सकते हैं या चार्ट को SVG इमेज के रूप में निर्यात कर सकते हैं।