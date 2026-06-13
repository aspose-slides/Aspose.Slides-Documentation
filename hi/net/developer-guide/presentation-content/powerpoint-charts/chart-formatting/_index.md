---
title: .NET में प्रस्तुति चार्ट फ़ॉर्मेट करें
linktitle: चार्ट फ़ॉर्मेटिंग
type: docs
weight: 60
url: /hi/net/chart-formatting/
keywords:
- चार्ट फ़ॉर्मेट
- चार्ट फ़ॉर्मेटिंग
- चार्ट इकाई
- चार्ट गुण
- चार्ट सेटिंग्स
- चार्ट विकल्प
- फ़ॉन्ट गुण
- गोल किनारा
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में चार्ट फ़ॉर्मेटिंग सीखें और अपने PowerPoint प्रस्तुति को पेशेवर, आकर्षक शैली के साथ उन्नत बनाएं।"
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फॉर्मेट करने का तरीका समझाता है। यह अक्ष, ग्रिड रेखाएँ, शीर्षक, लीजेंड, प्लॉट क्षेत्र और दीवार भराव जैसे प्रमुख चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता को बेहतर बनाने को दर्शाता है।

यह चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण सेट करने, चार्ट डेटा पर पूर्वनिर्धारित और कस्टम संख्यात्मक फ़ॉर्मेट लागू करने, तथा चार्ट क्षेत्र के लिए गोल किनारे सक्रिय करने का भी प्रदर्शन करता है। ये उदाहरण मिलकर प्रस्तुति में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने का तरीका दिखाते हैं।

## **चार्ट इकाइयों को फॉर्मेट करें**
Aspose.Slides for .NET डेवलपर्स को शून्य से उनके स्लाइड्स में कस्टम चार्ट जोड़ने की अनुमति देता है। यह लेख विभिन्न चार्ट इकाइयों को फॉर्मेट करने के बारे में बताता है, जिसमें चार्ट श्रेणी और मान अक्ष शामिल हैं।

Aspose.Slides for .NET विभिन्न चार्ट इकाइयों को प्रबंधित करने और उन्हें कस्टम मानों के साथ फॉर्मेट करने के लिए एक सरल API प्रदान करता है:

1. **Presentation** क्लास की एक इंस्टेंस बनाएँ।
1. सूचकांक द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. किसी भी वांछित प्रकार (इस उदाहरण में हम ChartType.LineWithMarkers का प्रयोग करेंगे) के साथ डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. चार्ट के मान अक्ष तक पहुँचें और निम्नलिखित गुण सेट करें:
   1. मान अक्ष प्रमुख ग्रिड रेखाओं के लिए **Line format** सेट करना
   1. मान अक्ष उप-ग्रिड रेखाओं के लिए **Line format** सेट करना
   1. मान अक्ष के लिए **Number Format** सेट करना
   1. मान अक्ष के लिए **Min, Max, Major and Minor units** सेट करना
   1. मान अक्ष डेटा के लिए **Text Properties** सेट करना
   1. मान अक्ष के लिए **Title** सेट करना
   1. मान अक्ष के लिए **Line Format** सेट करना
1. चार्ट श्रेणी अक्ष तक पहुँचें और निम्नलिखित गुण सेट करें:
   1. श्रेणी अक्ष प्रमुख ग्रिड रेखाओं के लिए **Line format** सेट करना
   1. श्रेणी अक्ष उप-ग्रिड रेखाओं के लिए **Line format** सेट करना
   1. श्रेणी अक्ष डेटा के लिए **Text Properties** सेट करना
   1. श्रेणी अक्ष के लिए **Title** सेट करना
   1. श्रेणी अक्ष के लिए **Label Positioning** सेट करना
   1. श्रेणी अक्ष लेबल्स के लिए **Rotation Angle** सेट करना
1. चार्ट लेजेंड तक पहुँचें और उनके लिए **Text Properties** सेट करें
1. चार्ट लेजेंड को चार्ट के ओवरलैप के बिना दिखाएँ
1. चार्ट **Secondary Value Axis** तक पहुँचें और निम्नलिखित गुण सेट करें:
   1. द्वितीयक **Value Axis** को सक्षम करना
   1. द्वितीयक मान अक्ष के लिए **Line Format** सेट करना
   1. द्वितीयक मान अक्ष के लिए **Number Format** सेट करना
   1. द्वितीयक मान अक्ष के लिए **Min, Max, Major and Minor units** सेट करना
1. अब द्वितीयक मान अक्ष पर पहला चार्ट श्रृंखला प्लॉट करें
1. चार्ट बैक वॉल फाइल रंग सेट करें
1. चार्ट प्लॉट एरिया फाइल रंग सेट करें
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें

```c#
// प्रेजेंटेशन को इंस्टैंसिएट करना// प्रेजेंटेशन को इंस्टैंसिएट करना
Presentation pres = new Presentation();

// Accessing the first slide
// पहले स्लाइड तक पहुंचना
ISlide slide = pres.Slides[0];

// Adding the sample chart
// नमूना चार्ट जोड़ना
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Setting Chart Titile
// चार्ट शीर्षक सेट करना
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Major grid lines format for value axis
// मान अक्ष के लिए प्रमुख ग्रिड रेखाओं का फ़ॉर्मेट सेट करना
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Setting Minor grid lines format for value axis
// मान अक्ष के लिए गौण ग्रिड रेखाओं का फ़ॉर्मेट सेट करना
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting value axis number format
// मान अक्ष का संख्या फ़ॉर्मेट सेट करना
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Setting chart maximum, minimum values
// चार्ट अधिकतम, न्यूनतम मान सेट करना
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Setting Value Axis Text Properties
// मान अक्ष टेक्स्ट गुण सेट करना
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Setting value axis title
// मान अक्ष शीर्षक सेट करना
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Value Axis line format : Now Obselete
// मान अक्ष रेखा फ़ॉर्मेट सेट करना : अब अप्रचलित
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Setting Major grid lines format for Category axis
// श्रेणी अक्ष के लिए प्रमुख ग्रिड रेखाओं का फ़ॉर्मेट सेट करना
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Setting Minor grid lines format for Category axis
// श्रेणी अक्ष के लिए गौण ग्रिड रेखाओं का फ़ॉर्मेट सेट करना
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting Category Axis Text Properties
// श्रेणी अक्ष टेक्स्ट गुण सेट करना
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Setting Category Titile
// श्रेणी शीर्षक सेट करना
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting category axis lable position
// श्रेणी अक्ष लेबल स्थिति सेट करना
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Setting category axis lable rotation angle
// श्रेणी अक्ष लेबल घूर्णन कोण सेट करना
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Setting Legends Text Properties
// लीजेंड टेक्स्ट गुण सेट करना
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Set show chart legends without overlapping chart
// लीजेंड को चार्ट के साथ ओवरलैप हुए बिना दिखाएँ
chart.Legend.Overlay = true;
            
// Ploting first series on secondary value axis
// दूसरे मान अक्ष पर पहली श्रृंखला प्लॉट करना
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Setting chart back wall color
// चार्ट बैक वॉल रंग सेट करना
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```



## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**
Aspose.Slides for .NET चार्ट के लिए फ़ॉन्ट से संबंधित गुण सेट करने का समर्थन प्रदान करता है। कृपया चार्ट के फ़ॉन्ट गुण सेट करने के लिए नीचे दिए गए चरणों का पालन करें।

- **Presentation** क्लास ऑब्जेक्ट को इंस्टैंशिएट करें।
- स्लाइड पर चार्ट जोड़ें।
- फ़ॉन्ट ऊँचाई सेट करें।
- संशोधित प्रस्तुति को सहेजें।

नीचे एक नमूना उदाहरण दिया गया है।

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```




## **संख्यात्मक फ़ॉर्मेट सेट करें**
Aspose.Slides for .NET चार्ट डेटा फ़ॉर्मेट को प्रबंधित करने के लिए एक सरल API प्रदान करता है:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएँ।
1. सूचकांक द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. किसी भी वांछित प्रकार (यह उदाहरण **ChartType.ClusteredColumn** का उपयोग करता है) के साथ डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. उपलब्ध पूर्वनिर्धारित मानों में से प्रीसेट नंबर फ़ॉर्मेट सेट करें।
1. प्रत्येक चार्ट श्रृंखला में चार्ट डेटा कोशिका के माध्यम से पार करें और चार्ट डेटा नंबर फ़ॉर्मेट सेट करें।
1. प्रस्तुति को सहेजें।
1. कस्टम नंबर फ़ॉर्मेट सेट करें।
1. प्रत्येक चार्ट श्रृंखला में चार्ट डेटा कोशिका के माध्यम से पार करें और अलग-अलग चार्ट डेटा नंबर फ़ॉर्मेट सेट करें।
1. प्रस्तुति को सहेजें।

```c#
// प्रेजेंटेशन को इंस्टैंसिएट करें// प्रेजेंटेशन को इंस्टैंसिएट करें
Presentation pres = new Presentation();

// पहले प्रेजेंटेशन स्लाइड तक पहुंचें
ISlide slide = pres.Slides[0];

// डिफ़ॉल्ट क्लस्टर्ड कॉलम चार्ट जोड़ना
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// चार्ट सीरीज़ कलेक्शन तक पहुंचना
IChartSeriesCollection series = chart.ChartData.Series;

// प्रीसेट नंबर फ़ॉर्मेट सेट करना
// प्रत्येक चार्ट सीरीज़ के माध्यम से पार करना
foreach (ChartSeries ser in series)
{
    // सीरीज़ में प्रत्येक डेटा सेल के माध्यम से पार करना
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // नंबर फ़ॉर्मेट सेट करना
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// प्रेजेंटेशन सहेजना
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

उपलब्ध पूर्वनिर्धारित नंबर फ़ॉर्मेट मान, उनके इंडेक्स और उपयोग के साथ नीचे दिए गए हैं:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **चार्ट क्षेत्र के गोल किनारे सेट करें**
Aspose.Slides for .NET चार्ट क्षेत्र को सेट करने का समर्थन प्रदान करता है। **IChart.HasRoundedCorners** और **Chart.HasRoundedCorners** गुण Aspose.Slides में जोड़े गए हैं।

1. `Presentation` क्लास ऑब्जेक्ट को इंस्टैंशिएट करें।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट का फ़िल टाइप और फ़िल रंग सेट करें
1. गोल किनारे गुण को True सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

नीचे एक नमूना उदाहरण दिया गया है।

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/एरिया के लिए अर्ध-पारदर्शी फ़िल सेट कर सकता हूँ जबकि सीमा अपारदर्शी रहे?**

हां। फ़िल पारदर्शिता और आउटलाइन को अलग-अलग कॉन्फ़िगर किया जाता है। यह घने दृश्यात्मक उपस्थापनों में ग्रिड और डेटा की पठनीयता सुधारने में उपयोगी है।

**डेटा लेबल्स ओवरलैप होने पर मैं कैसे निपटूँ?**

फ़ॉन्ट आकार घटाएँ, गैर‑आवश्यक लेबल घटकों (उदाहरण के लिए, श्रेणियाँ) को निष्क्रिय करें, लेबल ऑफ़सेट/स्थिति सेट करें, आवश्यक होने पर केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या फ़ॉर्मेट को “value + legend” में बदलें।

**क्या मैं श्रृंखला पर ग्रेडिएंट या पैटर्न फ़िल लागू कर सकता हूँ?**

हां। ठोस तथा ग्रेडिएंट/पैटर्न फ़िल दोनों आमतौर पर उपलब्ध होते हैं। व्यावहारिक रूप से, ग्रेडिएंट का सीमित उपयोग करें और उन संयोजनों से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट घटा दें।