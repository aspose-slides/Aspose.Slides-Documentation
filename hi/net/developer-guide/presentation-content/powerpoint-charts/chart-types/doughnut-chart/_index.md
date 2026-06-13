---
title: .NET में प्रस्तुतियों में डोनट चार्ट को अनुकूलित करें
linktitle: डोनट चार्ट
type: docs
weight: 30
url: /hi/net/doughnut-chart/
keywords:
- डोनट चार्ट
- केंद्रीय अंतर
- छेद का आकार
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में डोनट चार्ट बनाना और अनुकूलित करना खोजें, जो गतिशील प्रस्तुतियों के लिए PowerPoint स्वरूपों को समर्थन देता है।"
---
## **सारांश**

यह लेख Aspose.Slides में एक डोनट चार्ट के साथ काम करने का तरीका दिखाता है, जिसमें चार्ट को स्लाइड में जोड़ना, उसके केंद्र छेद का आकार निर्धारित करना, और प्रस्तुति को सहेजना शामिल है। यह `DoughnutHoleSize` सेटिंग पर केंद्रित है और कोड में इस चार्ट प्रकार को अनुकूलित करने के लिए आवश्यक बुनियादी चरणों को प्रदर्शित करता है।

यह एक संक्षिप्त FAQ भी शामिल करता है जो संबंधित डोनट‑चार्ट स्थितियों को कवर करता है, जैसे कई श्रृंखलाओं का उपयोग करके कई रिंग बनाना, विस्फोटित डोनट चार्ट के साथ काम करना, और चार्ट को रास्टर चित्र या SVG के रूप में निर्यात करना।

## **डोनट चार्ट में केंद्र अंतर निर्धारित करें**
डोनट चार्ट में छेद का आकार निर्धारित करने के लिए नीचे दिए गए चरणों का पालन करें:

- Instantiate [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
- Add doughnut chart on the slide.
- Specify the size of the hole in a doughnut chart.
- Write presentation to disk.

निम्नलिखित उदाहरण में, हमने डोनट चार्ट में छेद का आकार निर्धारित किया है।

```c#
// Presentation क्लास का एक उदाहरण बनाएं
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// प्रस्तुति को डिस्क पर सहेजें
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई रिंग वाले मल्टी‑लेवल डोनट बना सकता हूँ?**

हाँ। एक ही डोनट चार्ट में कई श्रृंखलाएँ जोड़ें—प्रत्येक श्रृंखला एक अलग रिंग बनती है। रिंग का क्रम संग्रह में श्रृंखलाओं के क्रम से निर्धारित होता है।

**क्या “विस्फोटित” डोनट (अलग‑अलग स्लाइस) समर्थित है?**

हाँ। एक Exploded Doughnut [chart type](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/charttype/) और डेटा बिंदुओं पर विस्फोट प्रॉपर्टी उपलब्ध है; आप व्यक्तिगत स्लाइस को अलग कर सकते हैं।

**रिपोर्ट के लिए डोनट चार्ट की छवि (PNG/SVG) कैसे प्राप्त करूँ?**

एक चार्ट एक आकृति है; आप इसे एक [raster image](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/getimage/) में रेंडर कर सकते हैं या चार्ट को एक [SVG image](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/writeassvg/) में निर्यात कर सकते हैं।