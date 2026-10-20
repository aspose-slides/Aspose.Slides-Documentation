---
title: PPTX में चार्ट आकार बदलने के लिए कार्य समाधान
type: docs
weight: 60
url: /hi/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- चार्ट आकार बदलना
- Excel चार्ट
- OLE ऑब्जेक्ट
- चार्ट एम्बेड करना
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ एम्बेड किए गए Excel OLE ऑब्जेक्ट्स का उपयोग करने पर PPTX में अनपेक्षित चार्ट आकार बदलने को ठीक करें। चार्ट और OLE फ्रेम के आकार को स्थिर रखने के लिए निश्चित चार्ट आयाम सेट करें।"
---
## **पृष्ठभूमि**

Aspose घटकों का उपयोग करके PowerPoint प्रस्तुतियों में OLE वस्तुओं के रूप में सम्मिलित Excel चार्ट्स पहली बार सक्रिय करने के बाद आकार बदल सकते हैं। यह सक्रिय करने से पहले और बाद में चार्ट के स्वरूप में स्पष्ट अंतर पैदा कर सकता है। यह लेख समझाता है कि आकार बदलना क्यों होता है और कैसे इसे OLE फ्रेम के साथ निश्चित चार्ट आयाम मिलाकर रोका जा सकता है।

[Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) में हमने बताया कि Aspose.Cells for .NET के साथ Excel चार्ट कैसे बनाया जाए और Aspose.Slides for .NET का उपयोग करके उसे PowerPoint प्रस्तुति में एम्बेड किया जाए। [object preview issue](/slides/hi/net/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए हमने चार्ट छवि को चार्ट के OLE ऑब्जेक्ट फ्रेम में असाइन किया। आउटपुट प्रस्तुति में, जब आप चार्ट छवि प्रदर्शित करने वाले OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करते हैं, तो Excel चार्ट सक्रिय हो जाता है। उपयोगकर्ता एम्बेडेड Excel वर्कबुक को संपादित कर सकते हैं और फिर सक्रिय वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर वापस लौटने पर OLE ऑब्जेक्ट फ्रेम का आकार बदलता है, और पुनः आकार देने का कारक OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक दोनों के मूल आकारों पर निर्भर करता है।

## **आकार बदलने का कारण**

एंबेडेड Excel वर्कबुक की अपनी विंडो आयाम होती हैं, जिन्हें Excel पहली बार ऑब्जेक्ट सक्रिय होने पर बनाए रखने की कोशिश करता है। स्लाइड पर OLE फ्रेम के आयाम स्वतंत्र रूप से परिभाषित होते हैं। जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint ऑब्जेक्ट के आकार को समन्वयित करते हैं ताकि एम्बेडिंग प्रक्रिया के हिस्से के रूप में अनुपात बनाए रखा जा सके। वर्कबुक विंडो और OLE फ्रेम के बीच अंतर के कारण ऑब्जेक्ट का आकार बदल सकता है।

## **काम करने वाला समाधान**

स्लाइड पर OLE फ्रेम के साथ चार्ट आकार मिलाएँ और चार्ट आयाम को वर्कबुक विंडो से स्वतंत्र रखें। यह समाधान नई प्रस्तुति या मौजूदा टेम्पलेट दोनों के साथ काम करता है।

यह उदाहरण Aspose.Cells for .NET और Aspose.Slides for .NET की आवश्यकता रखता है। यह सक्रिय चार्ट शीट पर एक सरल कॉलम चार्ट बनाता है और वर्कबुक को XLS प्रारूप में एम्बेड करता है। कोई चार्ट प्रीव्यू छवि असाइन नहीं की गई; चार्ट PowerPoint में OLE ऑब्जेक्ट सक्रिय होने पर दिखाई देता है।

उदाहरण 9.5 × 4‑इंच OLE फ्रेम के साथ नई प्रस्तुति बनाता है जो बाएँ किनारे से 0.5 इंच और शीर्ष से 1 इंच दूरी पर स्थित है। स्लाइड निर्देशांक और आयाम पॉइंट्स में होते हैं (प्रति इंच 72 पॉइंट)। मौजूदा प्रस्तुति के लिए, देखें [Use a Template](#use-a-template)।

## **स्थिर चार्ट आकार सेट करें**

[SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) को false सेट करें ताकि चार्ट आयाम वर्कबुक विंडो से स्वतंत्र रहें। [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) के आयाम को [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) और [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/) के माध्यम से सेट करें, पॉइंट्स को 96 पिक्सेल प्रति इंच के उपयोग से पिक्सेल में परिवर्तित करें: 684 × 288 पॉइंट्स का फ्रेम 912 × 384 पिक्सेल के चार्ट के बराबर है। [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) को [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/) के Custom मान पर सेट करें। उदाहरण वर्कबुक को [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) के साथ एम्बेड करता है और 9.5 × 4‑इंच OLE फ्रेम वाले प्रस्तुति को सहेजता है।

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// स्लाइड निर्देशांक और आयाम पॉइंट्स में हैं (प्रति इंच 72 पॉइंट्स)।
var width = 684f; // 9.5 इंच।
var height = 288f; // 4 इंच।

chart.SizeWithWindow = false;
// Convert points to chart pixels using 96 pixels per inch.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **टेम्पलेट का उपयोग करें**

मौजूदा प्रस्तुति में आकार निर्धारण तर्क समान है। उदाहरण को अनुकूलित करने के लिए:

1. खाली प्रस्तुति बनाने के बजाय टेम्पलेट प्रस्तुति लोड करें।
1. जांचें कि पहली स्लाइड में कम से कम तीन आकृतियाँ हैं, फिर इंडेक्स 2 की आकृति को प्लेसहोल्डर के रूप में उपयोग करें।
1. निश्चित मान 684 और 288 के बजाय उस आकृति से फ्रेम की चौड़ाई और ऊँचाई लें। आकार गणनाएँ अपरिवर्तित रखें।
1. निश्चित निर्देशांक 36 और 72 के बजाय प्लेसहोल्डर की स्थिति पर OLE फ्रेम जोड़ें।
1. प्रस्तुति सहेजने से पहले प्लेसहोल्डर को हटाएँ।

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में सक्रिय करने के बाद मेरा एम्बेडेड Excel चार्ट आकार क्यों बदलता है?**

यह इसलिए होता है क्योंकि Excel पहली बार सक्रिय होने पर मूल विंडो आकार को पुनर्स्थापित करने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम की अपनी आयाम होती हैं। PowerPoint और Excel अनुपात बनाए रखने के लिए आकार पर बातचीत करते हैं, जिससे आकार बदलना हो सकता है।

**मैं चार्ट और OLE फ्रेम के आकार को स्थिर कैसे रख सकता हूँ?**

स्थिर चार्ट आयाम सेट करें जो OLE फ्रेम से मेल खाते हों और वर्कबुक को एम्बेड करने से पहले कस्टम चार्ट प्रिंट आकार का उपयोग करें। ऊपर दिया उदाहरण आवश्यक सेटिंग्स और इकाई रूपांतरण दिखाता है।

**क्या केवल वर्कबुक विंडो आकार मिलाना पर्याप्त है?**

केवल वर्कबुक विंडो आकार मिलाने से OLE फ्रेम के सक्रिय करने के बाद आकार बदलने को विश्वसनीय रूप से रोका नहीं जा सकता। उदाहरण में दिखाए अनुसार स्थिर चार्ट आयाम का उपयोग करें।

**क्या यह समाधान टेम्पलेट‑आधारित प्रस्तुतियों और नई प्रस्तुतियों दोनों के साथ काम करता है?**

हाँ। टेम्पलेट के लिए प्लेसहोल्डर के आयाम और स्थिति का उपयोग करें। नई प्रस्तुति के लिए सीधे फ्रेम के आयाम और स्थिति निर्दिष्ट करें।

**क्या मैं इस उदाहरण को अन्य स्प्रेडशीट प्रोग्रामों में बनाए गए चार्ट्स के साथ उपयोग कर सकता हूँ?**

उदाहरण Aspose.Cells से बनाए गए Excel वर्कबुक का उपयोग करता है। यह अन्य स्प्रेडशीट प्रोग्रामों के सक्रियण व्यवहार को दर्शाता नहीं है।

## **संबंधित अनुभाग**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)