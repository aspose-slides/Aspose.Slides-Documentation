---
title: Excel चार्ट बनाएं और उन्हें प्रस्तुतियों में OLE ऑब्जेक्ट के रूप में एम्बेड करें
type: docs
weight: 50
url: /hi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel चार्ट
- चार्ट एम्बेड करें
- OLE ऑब्जेक्ट
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Cells for .NET के साथ एक Excel चार्ट बनाएं और Aspose.Slides के साथ PowerPoint प्रस्तुति में वर्कबुक को एम्बेड करें, जिसमें चार्ट प्रीव्यू शामिल है।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Cells for .NET के साथ Excel कॉलम चार्ट कैसे बनाएं और इसे Aspose.Slides for .NET के साथ एक PowerPoint प्रस्तुति में वर्कबुक कैसे एम्बेड करें। एम्बेडेड वर्कबुक में स्रोत डेटा और चार्ट दोनों होते हैं। एक अलग PNG प्रीव्यू स्लाइड पर चार्ट को दर्शाता है, इससे पहले कि OLE ऑब्जेक्ट सक्रिय हो।

परिणाम एक एम्बेडेड Excel ऑब्जेक्ट है, मूल PowerPoint चार्ट नहीं। OLE के माध्यम से वर्कबुक को संपादित करने के लिए ऐसे डेस्कटॉप एप्लिकेशन की आवश्यकता होती है जो OLE सक्रियता को सपोर्ट करता हो और संगत Excel इंस्टॉलेशन हो।

## **पूर्वापेक्षाएँ**

अपने C# प्रोजेक्ट में Aspose.Cells for .NET और Aspose.Slides for .NET के रेफ़रेंस जोड़ें। यह उदाहरण टॉप-लेवल स्टेटमेंट्स का उपयोग करता है और C# 9 या इसके बाद का संस्करण आवश्यक है। प्रस्तुति बनाने के लिए Microsoft Office की आवश्यकता नहीं है।

कोई इनपुट फ़ाइल की आवश्यकता नहीं है: उदाहरण डेटा और चार्ट को मेमोरी में बनाता है, फिर `OutputChart.pptx` को वर्तमान कार्य फ़ोल्डर में लिखता है। मूल्यांकन मोड के बाहर चलाते समय दोनों उत्पादों के लाइसेंस लागू करें।

## **एम्बेडिंग कैसे काम करती है**

1. डेटा वर्कशीट और चार्ट शीट के साथ एक वर्कबुक बनाएं।
2. चार्ट शीट को सक्रिय करें ताकि वर्कबुक चार्ट पर खुले।
3. वर्कबुक के OLE डिस्प्ले रेंज को सेट करें और चार्ट को PNG में रेंडर करें।
4. वर्कबुक को मेमोरी में XLSX रूप में सहेजें और उन बाइट्स को स्लाइड में एम्बेड करें।
5. PNG को OLE ऑब्जेक्ट के प्रीव्यू के रूप में असाइन करें और प्रस्तुति को PPTX में सहेजें।

वर्कबुक डिस्प्ले रेंज और स्लाइड पर फ्रेम की अलग-अलग भूमिकाएँ होती हैं। [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) शून्य-आधारित प्रारंभ/समाप्ति पंक्ति और कॉलम इंडेक्स लेता है। [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) इसके बजाय शीर्ष पंक्ति, बाएँ कॉलम, निचली पंक्ति और दाएँ कॉलम लेता है। उदाहरण पंक्ति इंडेक्स 55 और कॉलम इंडेक्स 25 का उपयोग निचले-दाएँ सीमाओं के रूप में करता है; ये मान लेआउट विकल्प हैं, डेटा पंक्तियों या कॉलमों की संख्या नहीं।

स्लाइड फ्रेम पॉइंट्स में मापी जाती है। उदाहरण इसे स्लाइड के भीतर फिट करता है और केंद्रित रखता है, जबकि PNG के अनुपात को बनाए रखता है, बजाय प्रीव्यू को स्लाइड के पूरी तरह भरने के लिए खींचे।

## **चार्ट बनाना और एम्बेड करना**

निम्नलिखित पूर्ण उदाहरण `DataSheet` को चार पंक्तियों और पाँच कॉलम के मानों से भरता है। प्रत्येक पंक्ति एक चार्ट सीरीज़ बनती है। वर्कबुक को सहेजने से पहले `ChartSheet` को सक्रिय शीट के रूप में चयनित किया जाता है।

वर्कबुक को स्पष्ट रूप से XLSX के रूप में सहेजा जाता है, जो `xlsx` एक्सटेंशन से मेल खाता है जो [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) को पास किया जाता है। PNG को उसका स्ट्रीम से सीधे लोड किया जाता है, बिना किसी मध्यवर्ती बिटमैप रूपांतरण के। इसे [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) के माध्यम से असाइन करने से डिफ़ॉल्ट OLE प्लेसहोल्डर बदल जाता है।

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// चार्ट प्रीव्यू को रेंडर करें और संपादन योग्य वर्कबुक को अलग से सीरियलाइज़ करें।
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// प्रीव्यू को स्लाइड के भीतर फिट करें बिना उसके अनुपात को बदले।
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **अपेक्षित परिणाम**

`OutputChart.pptx` एक स्लाइड के साथ आता है जिसमें एम्बेडेड Excel वर्कबुक और चार्ट प्रीव्यू है। वर्कबुक में मूल डेटा और चार सीरीज़ वाला कॉलम चार्ट होता है। प्रीव्यू स्लाइड पर केंद्रित है और अपने अनुपात को बनाए रखता है।

![Excel कॉलम चार्ट जो एम्बेडेड वर्कबुक के प्रीव्यू के रूप में दिखाया गया है](excel-chart-ole-preview.png)

संगत डेस्कटॉप PowerPoint वातावरण में जहाँ Excel उपलब्ध है, ऑब्जेक्ट को डबल‑क्लिक करें ताकि एम्बेडेड वर्कबुक सक्रिय और संपादित हो सके। सक्रियण और संपादन होस्ट एप्लिकेशन की OLE समर्थन और सुरक्षा सेटिंग्स पर निर्भर करता है।

## **बारंबार पूछे जाने वाले प्रश्न**

**प्रीव्यू इमेज की आवश्यकता क्यों है?**

एम्बेडेड वर्कबुक और उसके स्लाइड प्रीव्यू अलग सामग्री हैं। एक चार्ट इमेज प्रदान करें ताकि स्लाइड डिफ़ॉल्ट "EMBEDDED OLE OBJECT" प्लेसहोल्डर के बजाय चार्ट दिखाए। देखें [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/net/object-preview-issue-when-adding-oleobjectframe/)।

**क्या प्रीव्यू कोड में वर्कबुक बदलने पर स्वचालित रूप से अपडेट होता है?**

प्रीव्यू को एक स्नैपशॉट के रूप में देखें। जब प्रोग्रामेटिक रूप से वर्कबुक डेटा अपडेट किया जाता है, तो चार्ट इमेज को फिर से बनाएँ और प्रीव्यू के साथ-साथ एम्बेडेड वर्कबुक डेटा को भी बदलें।

**क्या मैं XLS को XLSX के बजाय इस्तेमाल कर सकता हूँ?**

हाँ। वर्कबुक को XLS फॉर्मेट में सहेजें और एम्बेडेड डेटा एक्सटेंशन के रूप में `xls` उपयोग करें। एक्सटेंशन वास्तविक वर्कबुक फॉर्मेट से मेल खाना चाहिए; केवल एक्सटेंशन बदलने से डेटा परिवर्तित नहीं होता।

**सक्रियकरण के बाद ऑब्जेक्ट का आकार क्यों बदल सकता है?**

होस्ट एप्लिकेशन वर्कबुक को सक्रिय करने पर OLE ऑब्जेक्ट की प्रस्तुति को अपडेट कर सकता है। वर्कबुक की OLE डिस्प्ले रेंज और स्लाइड फ्रेम के आयाम दोनों महत्व रखते हैं। देखें [PPTX में चार्ट री‑साइज़िंग के लिए कार्य समाधान](/slides/hi/net/working-solution-for-chart-resizing-in-pptx/)।

## **संबंधित अनुभाग**

- [PPTX में चार्ट री‑साइज़िंग के लिए कार्य समाधान](/slides/hi/net/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/net/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint ऐड‑इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वचालित रूप से अपडेट करना](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)