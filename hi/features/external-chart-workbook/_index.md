---
title: बाहरी वर्कबुक से चार्ट लिंक करें
description: चार्ट डेटा को एक बाहरी वर्कबुक से लिंक करें और उसे रिफ्रेश करें।
type: docs
url: /hi/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **परिचय**

एक चार्ट को बाहरी वर्कबुक की ओर इंगित करें बजाय इसके कि सभी स्रोत डेटा प्रस्तुति में एम्बेडेड रहे। आप वर्कबुक पथ सेट कर सकते हैं और यह चुन सकते हैं कि चार्ट को उस फ़ाइल से अपडेट किया जाए या नहीं। सहेजा गया चार्ट कैश्ड डिस्प्ले डेटा भी ले जा सकता है।

## **उपयोग का उदाहरण**

यह C# उदाहरण Aspose.Slides for .NET का उपयोग करता है। उत्तर = 55 और दक्षिण = 40 के साथ एक वैध सेल्स वर्कबुक बनाएं और इसे आउटपुट के बगल में sales.xlsx के रूप में लिखें। चार्ट के उत्तर मान को 20 पर रीसेट करें, फिर चार्ट को वर्कबुक के पूर्ण पथ से लिंक करें और रिफ्रेश करें: उत्तर फिर से 55 हो जाता है। स्पष्ट रेंज हेडर और दो डेटा पंक्तियों को कवर करती है। लिंक्ड चार्ट को पुनः खोलते या अपडेट करते समय sales.xlsx उपलब्ध रखें; प्रस्तुति इस बाहरी फ़ाइल को एम्बेड नहीं करती। कोई इनपुट फ़ाइल आवश्यक नहीं है। यह *external-chart-workbook.pptx* और *external-chart-workbook.png* सहेजता है। लाइब्रेरी स्थापित करने के लिए [स्थापना गाइड](/slides/hi/net/installation/) का उपयोग करें।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **आम प्रश्न**

### **क्या मैं लिंक्ड फ़ाइल के गायब होने पर प्रत्येक कैश्ड मूल्य पढ़ सकता हूँ?**

Aspose.Slides for .NET 26.11 लिंक्ड वर्कबुक को खोले बिना [सुरक्षित चार्ट मानों को सीधे पढ़ें](/slides/hi/net/chart-workbook/#read-cached-chart-values-without-a-workbook) सकता है। इसमें सामान्य मान, X/Y मान, बबल आकार और श्रेणी मान शामिल हैं जब उन कैशों का अस्तित्व हो। कैश्ड डेटा अनुपलब्ध या पुराना हो सकता है; यह एक पूर्ण वर्कबुक नहीं है। स्रोत से रिफ्रेश करने के लिए अभी भी उपलब्ध समर्थित वर्कबुक आवश्यक है। अन्य SDKs और संस्करणों के लिए, उनके संबंधित चार्ट गाइड देखें।

### **बाहरी वर्कबुक को स्थानांतरित करने पर क्या होता है?**

चार्ट के बाहरी वर्कबुक पथ को उसके नए स्थान पर अपडेट करें, और उस फ़ाइल को जहाँ भी प्रस्तुति प्रोसेस की जाती है उपलब्ध कराएँ। जब यह अनुपलब्ध हो तो पूर्ण डेटा एक्सेस संचालन के लिए कैश्ड डेटा पर निर्भर न रहें।

### **क्या मैं लिंकिंग के समय कैश्ड चार्ट डेटा को रिफ्रेश करने का विकल्प चुन सकता हूँ?**

हां। लिंक सेट करते समय तय करें कि चार्ट डेटा को अपडेट किया जाए या नहीं। रिफ्रेश करने के लिए उपलब्ध समर्थित वर्कबुक आवश्यक है; रिफ्रेश को छोड़ने पर लिंक रिकॉर्ड होता है तथा फ़ाइल से नए मान नहीं पढ़े जाते।

## **मार्गदर्शिकाएँ**

- [.NET में प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें](/slides/hi/net/chart-workbook/)

संबंधित सुविधा: [संपादन योग्य चार्ट्स को डेटा से भरें](/slides/hi/features/chart-data-binding/).