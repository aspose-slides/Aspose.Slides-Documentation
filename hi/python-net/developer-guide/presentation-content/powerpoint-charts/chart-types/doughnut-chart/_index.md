---
title: Python के साथ प्रस्तुतियों में डोनट चार्ट को कस्टमाइज़ करें
linktitle: डोनट चार्ट
type: docs
weight: 30
url: /hi/python-net/doughnut-chart/
keywords:
- डोनट चार्ट
- केंद्र अंतराल
- छेद आकार
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में डोनट चार्ट बनाना और कस्टमाइज़ करना सीखें, जो गतिशील प्रस्तुतियों के लिए PowerPoint और OpenDocument फ़ॉर्मैट्स का समर्थन करता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides में डोनट चार्ट के साथ काम करना दिखाता है, जिसमें चार्ट को स्लाइड में जोड़ना, उसके केंद्र के छेद का आकार निर्धारित करना, और प्रस्तुति को सहेजना शामिल है। यह `doughnut_hole_size` सेटिंग पर केंद्रित है और कोड में इस चार्ट प्रकार को अनुकूलित करने के लिए आवश्यक मूल चरणों को दर्शाता है।

यह संबंधित डोनट-चार्ट परिदृश्यों को कवर करने वाला एक छोटा FAQ भी शामिल करता है, जैसे कई श्रृंखलाओं का उपयोग करके कई रिंग बनाना, विस्फोटित डोनट चार्ट के साथ काम करना, और चार्ट को रास्टर छवि या SVG के रूप में निर्यात करना।

## **डोनट चार्ट में केंद्र गैप निर्दिष्ट करें**
डोनट चार्ट में छेद का आकार निर्दिष्ट करने के लिए, नीचे दिए गए चरणों का पालन करें।

- Instantiate [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) class.
- Add doughnut chart on the slide.
- Specify the size of the hole in a doughnut chart.
- Write presentation to disk.

नीचे दिए गए उदाहरण में, हमने डोनट चार्ट में छेद का आकार सेट किया है।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation क्लास का एक उदाहरण बनाएं
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # प्रस्तुति को डिस्क पर सहेजें
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**क्या मैं कई रिंग वाले बहु-स्तरीय डोनट बना सकता हूँ?**

हाँ। एक ही डोनट चार्ट में कई श्रृंखलाएँ जोड़ें—प्रत्येक श्रृंखला एक अलग रिंग बनती है। रिंग क्रम श्रृंखलाओं के संग्रह में उनकी क्रमबद्धता द्वारा निर्धारित होता है।

**क्या "विस्फोटित" डोनट (अलग-अलग स्लाइस) समर्थित है?**

हाँ। एक Exploded Doughnut [chart type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/charttype/) मौजूद है और डेटा पॉइंट्स पर एक विस्फोट गुण है; आप व्यक्तिगत स्लाइस को अलग कर सकते हैं।

**मैं रिपोर्ट के लिए डोनट चार्ट की छवि (PNG/SVG) कैसे प्राप्त कर सकता हूँ?**

एक चार्ट एक आकार है; आप इसे एक [raster image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_image/) में रेंडर कर सकते हैं या चार्ट को एक [SVG image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/write_as_svg/) में निर्यात कर सकते हैं।