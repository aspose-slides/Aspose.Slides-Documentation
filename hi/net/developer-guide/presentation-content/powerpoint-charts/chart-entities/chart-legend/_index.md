---
title: Presentations में .NET में चार्ट लेजेंड को कस्टमाइज़ करें
linktitle: चार्ट लेजेंड
type: docs
url: /hi/net/chart-legend/
keywords:
- चार्ट लेजेंड
- लेजेंड स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ चार्ट लेजेंड को कस्टमाइज़ करके PowerPoint प्रस्तुतियों को अनुकूलित करें, विशेष लेजेंड फ़ॉर्मेटिंग के साथ."
---
## **सारांश**

Aspose.Slides PowerPoint प्रस्तुतियों में चार्ट लेजेंड को कस्टमाइज़ करने के विकल्प प्रदान करती है। यह लेख लेजेंड की स्थिति और आकार सेट करने, पूरे लेजेंड के फ़ॉन्ट आकार को निर्धारित करने, और व्यक्तिगत लेजेंड प्रविष्टि पर फ़ॉर्मेटिंग लागू करने का तरीका दिखाता है।

यह अक्सर पूछे जाने वाले प्रश्नों (FAQ) में कई संबंधित व्यवहारों को भी कवर करता है, जिसमें ओवरले मोड को निष्क्रिय करके प्लॉट एरिया को लेजेंड के लिए जगह बनाने, लंबे लेजेंड लेबल्स को रैप या लाइन ब्रेक्स का उपयोग करने, और जब स्पष्ट टेक्स्ट और फ़िल सेटिंग्स लागू न हों तो लेजेंड फ़ॉर्मेटिंग को प्रस्तुति थीम से विरासत में लेने शामिल है।

## **लेजेंड पोजिशनिंग**
लेजेंड गुण सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
- स्लाइड का रेफ़रेंस प्राप्त करें।
- स्लाइड पर एक चार्ट जोड़ें।
- लेजेंड के गुण सेट करें।
- प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में हमने चार्ट लेजेंड की स्थिति और आकार सेट किया है।

```c#
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation presentation = new Presentation();

// स्लाइड का रेफ़रेंस प्राप्त करें
ISlide slide = presentation.Slides[0];

// स्लाइड पर क्लस्टर्ड कॉलम चार्ट जोड़ें
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// लेजेंड गुण सेट करें
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// प्रस्तुति को डिस्क पर लिखें
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```



## **लेजेंड के फ़ॉन्ट आकार को सेट करें**
Aspose.Slides for .NET डेवलपर्स को लेजेंड के फ़ॉन्ट आकार को सेट करने की अनुमति देता है। नीचे दिए गए चरणों का पालन करें:

- `Presentation` क्लास का इंस्टेंस बनाएं।
- डिफ़ॉल्ट चार्ट बनाएं।
- फ़ॉन्ट आकार सेट करें।
- न्यूनतम एक्सिस मान सेट करें।
- अधिकतम एक्सिस मान सेट करें।
- प्रस्तुति को डिस्क पर लिखें।

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **व्यक्तिगत लेजेंड का फ़ॉन्ट आकार सेट करें**
Aspose.Slides for .NET डेवलपर्स को व्यक्तिगत लेजेंड प्रविष्टियों के फ़ॉन्ट आकार को सेट करने की अनुमति देता है। नीचे दिए गए चरणों का पालन करें:

- `Presentation` क्लास का इंस्टेंस बनाएं।
- डिफ़ॉल्ट चार्ट बनाएं।
- लेजेंड प्रविष्टि तक पहुंचें।
- फ़ॉन्ट आकार सेट करें।
- न्यूनतम एक्सिस मान सेट करें।
- अधिकतम एक्सिस मान सेट करें।
- प्रस्तुति को डिस्क पर लिखें।

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**क्या मैं लेजेंड को इस तरह सक्षम कर सकता हूँ कि चार्ट स्वचालित रूप से उसके लिए जगह आवंटित करे बजाय ओवरले करने के?**

हाँ। गैर‑ओवरले मोड का उपयोग करें ([Overlay](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/legend/overlay/) = `false`); इस स्थिति में प्लॉट एरिया लेजेंड को समायोजित करने के लिए छोटा हो जाएगा।

**क्या मैं मल्टी‑लाइन लेजेंड लेबल बना सकता हूँ?**

हाँ। जब स्थान अपर्याप्त हो तो लंबे लेबल स्वतः रैप हो जाते हैं; मजबूरन लाइन ब्रेक्स श्रृंखला नाम में नई पंक्ति अक्षरों के द्वारा समर्थित हैं।

**मैं कैसे लेजेंड को प्रस्तुति थीम के रंग योजना के अनुसार बना सकता हूँ?**

लेजेंड या उसके टेक्स्ट के लिए स्पष्ट रंग/फ़िल/फ़ॉन्ट सेट न करें। वे तब थीम से विरासत में ले लेंगे और डिज़ाइन बदलने पर सही ढंग से अपडेट हो जाएंगे।