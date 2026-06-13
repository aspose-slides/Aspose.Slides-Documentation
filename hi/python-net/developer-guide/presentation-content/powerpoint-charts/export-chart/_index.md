---
title: Python के साथ प्रस्तुति चार्ट निर्यात करें
linktitle: चार्ट निर्यात
type: docs
weight: 90
url: /hi/python-net/export-chart/
keywords:
- चार्ट
- चार्ट को छवि में
- चार्ट छवि के रूप में
- चार्ट छवि निकालें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके प्रस्तुति चार्ट निर्यात करने के बारे में जानें, PPT, PPTX और ODP फ़ॉर्मेट को समर्थन देते हुए, और किसी भी कार्यफ़्लो में रिपोर्टिंग को सरल बनाएं।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतिकरण से चार्ट को छवि के रूप में निर्यात करने की अनुमति देता है। यह लेख दिखाता है कि कैसे चार्ट से छवि प्राप्त करें और उसे सहेजें, जो तब उपयोगी है जब आपको PowerPoint प्रस्तुतिकरण के बाहर चार्ट दृश्यों को पुन: उपयोग करना हो।

## **चार्ट छवि प्राप्त करें**

Aspose.Slides for Python via .NET विशिष्ट चार्ट की छवि निकालने के समर्थन प्रदान करता है। नीचे नमूना उदाहरण दिया गया है।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक चार्ट को रास्टर छवि की बजाय वेक्टर (SVG) के रूप में निर्यात कर सकता हूँ?**

हाँ। एक चार्ट एक आकार है, और इसकी सामग्री को SVG में सहेजा जा सकता है, इसके लिए आप [shape-to-SVG saving method](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/write_as_svg/) का उपयोग कर सकते हैं।

**मैं निर्यात किए गए चार्ट का सटीक आकार पिक्सेल में कैसे सेट कर सकता हूँ?**

इमेज-रेंडरिंग ओवरलोड्स का उपयोग करें जो आकार या स्केल निर्दिष्ट करने की अनुमति देते हैं—लाइब्रेरी दी गई आयाम/स्केल के साथ ऑब्जेक्ट रेंडर करने का समर्थन करती है।

**यदि निर्यात के बाद लेबल और लीजेंड में फ़ॉन्ट गलत दिखें तो मुझे क्या करना चाहिए?**

[आवश्यक फ़ॉन्ट लोड करें](/slides/hi/python-net/custom-font/) [FontsLoader](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsloader/) के माध्यम से ताकि चार्ट रेंडरिंग मेट्रिक्स और पाठ की उपस्थिति को संरक्षित रखे।

**क्या निर्यात PowerPoint थीम, शैलियों और प्रभावों का सम्मान करता है?**

हाँ। Aspose.Slides का रेंडरर प्रस्तुतिकरण के फ़ॉर्मेटिंग (थीम, शैलियाँ, भराव, प्रभाव) का पालन करता है, इसलिए चार्ट की उपस्थिति संरक्षित रहती है।

**चार्ट छवियों के अलावा उपलब्ध रेंडरिंग/निर्यात क्षमताएँ कहाँ मिल सकती हैं?**

आउटपुट टार्गेट्स के लिए [API](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/)/[documentation](/slides/hi/python-net/convert-powerpoint/) के निर्यात सेक्शन को देखें ([PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/hi/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/hi/python-net/convert-powerpoint-to-xps/), [HTML](/slides/hi/python-net/convert-powerpoint-to-html/), आदि) और संबंधित रेंडरिंग विकल्प।