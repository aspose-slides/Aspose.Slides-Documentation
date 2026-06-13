---
title: .NET में प्रस्तुति चार्ट में त्रुटि बार को अनुकूलित करें
linktitle: त्रुटि बार
type: docs
url: /hi/net/error-bar/
keywords:
- त्रुटि बार
- कस्टम मान
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ चार्ट में त्रुटि बार को जोड़ना और अनुकूलित करना सीखें—PowerPoint प्रस्तुतियों में डेटा विज़ुअल्स को अनुकूलित करें।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में त्रुटि बार के साथ काम करने के तरीकों को समझाता है। यह दिखाता है कि चार्ट सीरीज़ में त्रुटि बार कैसे जोड़े जाएँ, X और Y त्रुटि बार सेटिंग्स कैसे कॉन्फ़िगर करें, तथा फ़िक्स्ड, प्रतिशत और कस्टम मानों जैसे विभिन्न वैल्यू टाइप कैसे लागू करें।

यह 또한 दर्शाता है कि कैसे सीरीज़ में व्यक्तिगत डेटा पॉइंट्स के लिए कस्टम त्रुटि बार मान निर्दिष्ट किए जाएँ, संबंधित डेटा पॉइंट कलेक्शन का उपयोग करके। इसके अतिरिक्त, लेख में संक्षिप्त नोट्स शामिल हैं कि निर्यात के दौरान त्रुटि बार कैसे व्यवहार करते हैं, उनके मार्कर और डेटा लेबल्स के साथ संगतता, और संबंधित API रेफ़रेंस क्लासेस और एनेम्स कहाँ मिल सकते हैं।

## **त्रुटि बार जोड़ें**
Aspose.Slides for .NET त्रुटि बार मानों को प्रबंधित करने के लिए एक सरल API प्रदान करता है। नमूना कोड कस्टम वैल्यू टाइप के उपयोग पर लागू होता है। मान निर्दिष्ट करने के लिए, सीरीज़ की **DataPoints** कलेक्शन में किसी विशिष्ट डेटा पॉइंट की **ErrorBarCustomValues** प्रॉपर्टी का उपयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।
1. इच्छित स्लाइड पर एक बबल चार्ट जोड़ें।
1. पहले चार्ट सीरीज़ तक पहुंचें और त्रुटि बार X स्वरूप सेट करें।
1. पहले चार्ट सीरीज़ तक पहुंचें और त्रुटि बार Y स्वरूप सेट करें।
1. बार मान और स्वरूप सेट करना।
1. परिवर्तित प्रस्तुति को एक PPTX फ़ाइल में लिखें।

```c#
 // खाली प्रस्तुति बना रहे हैं
 using (Presentation presentation = new Presentation())
 {
     // एक बबल चार्ट बना रहे हैं
     IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

     // त्रुटि बार जोड़ रहे हैं और उसका स्वरूप सेट कर रहे हैं
     IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
     IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
     errBarX.IsVisible = true;
     errBarY.IsVisible = true;
     errBarX.ValueType = ErrorBarValueType.Fixed;
     errBarX.Value = 0.1f;
     errBarY.ValueType = ErrorBarValueType.Percentage;
     errBarY.Value = 5;
     errBarX.Type = ErrorBarType.Plus;
     errBarY.Format.Line.Width = 2;
     errBarX.HasEndCap = true;

     // प्रस्तुति सहेज रहे हैं
     presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
 }
```

## **कस्टम त्रुटि बार मान जोड़ें**
Aspose.Slides for .NET कस्टम त्रुटि बार मानों को प्रबंधित करने के लिए एक सरल API प्रदान करता है। नमूना कोड तब लागू होता है जब **IErrorBarsFormat.ValueType** प्रॉपर्टी **Custom** के बराबर हो। मान निर्दिष्ट करने के लिए, सीरीज़ की **DataPoints** कलेक्शन में किसी विशिष्ट डेटा पॉइंट की **ErrorBarCustomValues** प्रॉपर्टी का उपयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।
1. इच्छित स्लाइड पर एक बबल चार्ट जोड़ें।
1. पहले चार्ट सीरीज़ तक पहुंचें और त्रुटि बार X स्वरूप सेट करें।
1. पहले चार्ट सीरीज़ तक पहुंचें और त्रुटि बार Y स्वरूप सेट करें।
1. चार्ट सीरीज़ के व्यक्तिगत डेटा पॉइंट्स तक पहुंचें और प्रत्येक डेटा पॉइंट के लिए त्रुटि बार मान सेट करें।
1. बार मान और स्वरूप सेट करना।
1. परिवर्तित प्रस्तुति को एक PPTX फ़ाइल में लिखें।

```c#
 // खाली प्रस्तुति बना रहे हैं
 using (Presentation presentation = new Presentation())
 {
     // एक बबल चार्ट बना रहे हैं
     IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

     // कस्टम त्रुटि बार जोड़ रहे हैं और उसका स्वरूप सेट कर रहे हैं
     IChartSeries series = chart.ChartData.Series[0];
     IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
     IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
     errBarX.IsVisible = true;
     errBarY.IsVisible = true;
     errBarX.ValueType = ErrorBarValueType.Custom;
     errBarY.ValueType = ErrorBarValueType.Custom;

     // चार्ट सीरीज़ डेटा पॉइंट तक पहुंच रहे हैं और व्यक्तिगत पॉइंट के लिए त्रुटि बार मान सेट कर रहे हैं
     IChartDataPointCollection points = series.DataPoints;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

     // चार्ट सीरीज़ पॉइंट्स के लिए त्रुटि बार सेट कर रहे हैं
     for (int i = 0; i < points.Count; i++)
     {
         points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
         points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
         points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
         points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
     }

     // प्रस्तुति सहेज रहे हैं
     presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
 }
```

## **FAQ**

**प्रस्तुति को PDF या छवियों में निर्यात करते समय त्रुटि बार का क्या होता है?**

वे चार्ट का हिस्सा बनकर रेंडर होते हैं और रूपांतरण के दौरान चार्ट फ़ॉर्मेटिंग के साथ संरक्षित रहते हैं, बशर्ते कि संगत संस्करण या रेंडरर मौजूद हो।

**क्या त्रुटि बार को मार्कर और डेटा लेबल के साथ मिलाया जा सकता है?**

हां। त्रुटि बार एक अलग तत्व है और मार्कर तथा डेटा लेबल के साथ संगत है; यदि तत्व ओवरलैप हों तो आपको फ़ॉर्मेटिंग समायोजित करनी पड़ सकती है।

**API में त्रुटि बार के साथ काम करने के लिए गुणों और एनेम की सूची कहाँ मिल सकती है?**

API रेफ़रेंस में: [ErrorBarsFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/errorbarsformat/) क्लास और संबंधित एनेम्स [ErrorBarType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/errorbartype/) तथा [ErrorBarValueType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/errorbarvaluetype/)।