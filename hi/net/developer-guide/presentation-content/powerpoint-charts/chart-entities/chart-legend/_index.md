---
title: .NET में प्रस्तुतियों में चार्ट लीजन को अनुकूलित करें
linktitle: चार्ट लीजन
type: docs
url: /hi/net/chart-legend/
keywords:
- चार्ट लीजन
- लीजन स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ चार्ट लीजन को कस्टमाइज़ करके PowerPoint प्रस्तुतियों को अनुकूलित करें, विशेष लीजन फ़ॉर्मेटिंग के साथ।"
---
## **समीक्षा**

Aspose.Slides for .NET PowerPoint प्रस्तुतियों में चार्ट लीजन को अनुकूलित करने के विकल्प प्रदान करता है। यह लेख दर्शाता है कि लीजन को कैसे स्थान दें और आकार निर्धारित करें, पूरे लीजन के फ़ॉन्ट आकार को सेट करें, एक व्यक्तिगत लीजन प्रविष्टि को फ़ॉर्मेट करें, तथा चयनित प्रविष्टियों को छुपाएँ या पुनर्स्थापित करें।

FAQ संबंधित व्यवहारों को कवर करता है, जिसमें लीजन के लिए स्थान आरक्षित करना, बहु‑पंक्ति लेबल प्रदर्शित करना, और प्रस्तुति थीम से फ़ॉर्मेटिंग विरासत में लेना शामिल है।

## **लीजेंड स्थिति**

लीजन की [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/), और [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) गुणों का उपयोग करके उसकी स्थिति और आकार को चार्ट के आयामों के अंश के रूप में निर्दिष्ट करें।

यह उदाहरण एक प्रस्तुति बनाता है और पहले स्लाइड में डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ता है। वांछित लीजन ऑफ़सेट और आकार को चार्ट की चौड़ाई और ऊँचाई से विभाजित करने से वे सापेक्ष मान बन जाते हैं: लीजन चार्ट के शीर्ष‑बाएँ कोने से 50 पॉइंट से अलग है और 100 × 100 पॉइंट में आकारित है।

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// चार्ट के सापेक्ष लीजन की स्थिति और आकार व्यक्त करें.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **लीजेंड का फ़ॉन्ट आकार सेट करें**

लीजन की [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) का उपयोग करके उसके टेक्स्ट फ़ॉर्मेटिंग तक पहुँचें और [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) को पॉइंट्स में सेट करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाता है और लीजन टेक्स्ट को 20 पॉइंट सेट करता है। यह वर्टिकल एक्सिस के लिए स्वचालित बाउंड्स को भी अक्षम करता है और उसकी रेंज को -5 से 10 तक सेट करता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **व्यक्तिगत लीजन प्रविष्टि का फ़ॉन्ट आकार सेट करें**

लीजन की [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) संग्रह का उपयोग करके किसी विशिष्ट प्रविष्टि के फ़ॉर्मेटिंग तक पहुँचें। प्रविष्टि सूचकांक शून्य‑आधारित होते हैं, इसलिए सूचकांक `1` दूसरी प्रविष्टि को दर्शाता है।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ कम से कम दो सीरीज़ वाले एक क्लस्टर्ड कॉलम चार्ट बनाता है। यह दूसरी लीजन प्रविष्टि को बोल्ड, इटैलिक और 20‑पॉइंट नीले टेक्स्ट के साथ फ़ॉर्मेट करता है।

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **व्यक्तिगत लीजन प्रविष्टियाँ छुपाएँ**

किसी सहायक सीरीज़ को लीजन में दिखाए बिना उसका डेटा दृश्यमान रखने के लिए, [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) को `true` सेट करें, यह [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/) के माध्यम से किया जाता है। यह केवल चयनित लीजन प्रविष्टि को छुपाता है; यह सीरीज़ या उसके डेटा पॉइंट्स को हटाता नहीं है। इसके विपरीत, [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) को `false` सेट करने से पूरी लीजन छुप जाती है।

निम्न उदाहरण डिफ़ॉल्ट डेटा के साथ कई सीरीज़ वाले एक क्लस्टर्ड कॉलम चार्ट बनाता है। यह दूसरी सीरीज़ की लीजन प्रविष्टि (सूचकांक `1`) को छुपाता है और प्रस्तुति को सहेजता है। फिर `Hide` को `false` करके प्रविष्टि को पुनर्स्थापित करता है और दूसरी प्रतिलिपि सहेजता है। दोनों फ़ाइलों में कॉलम दिखाई देते हैं।

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// चार्ट डेटा को बदले बिना वही प्रविष्टि पुनर्स्थापित करें.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

नीचे किया गया तुलना दिखाती है कि सभी प्रविष्टियों के दृश्यमान होने पर तथा दूसरी प्रविष्टि को छुपाने पर चार्ट समान रहता है। दूसरी सीरीज़ के कॉलम अपरिवर्तित रहते हैं।

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

कॉलम, बार और लाइन चार्ट में, लीजन प्रविष्टियाँ सीरीज़ को दर्शाती हैं। पाई चार्ट में, वे व्यक्तिगत डेटा पॉइंट (स्लाइस) को दर्शाती हैं, इसलिए चयनित स्लाइस पर [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) का उपयोग करें। API इस डेटा‑पॉइंट प्रॉपर्टी को `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, और `BarOfPie` चार्ट प्रकारों के लिए दस्तावेज़ करता है। डोनट चार्ट के लिए इसे मानना न करें, क्योंकि यह सूची में शामिल नहीं है।

## **FAQ**

**क्या मैं चार्ट को लीजन के लिए स्थान आरक्षित करने के लिए कॉन्फ़िगर कर सकता हूँ instead of overlaying it?**

हाँ। लीजन को प्लॉट एरिया के ऊपर ओवरले होने की बजाय स्थान आरक्षित करने के लिए [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) को `false` सेट करें।

**क्या मैं बहु‑पंक्ति लीजन लेबल बना सकता हूँ?**

हाँ। जब उपलब्ध चौड़ाई अपर्याप्त हो तो लंबे लेबल लपेटे जा सकते हैं। आप सीरीज़ नामों में न्यूलाइन कैरेक्टर डालकर भी लाइन ब्रेक का अनुरोध कर सकते हैं।

**मैं कैसे सुनिश्चित करूँ कि लीजन प्रस्तुति थीम के रंग योजना का अनुसरण करे?**

लीजन के रंग, फ़िल और फ़ॉन्ट को अनसेट रखें ताकि वह थीम फ़ॉर्मेटिंग को विरासत में ले सके। स्पष्ट फ़ॉर्मेटिंग थीम सेटिंग को ओवरराइड कर देता है।