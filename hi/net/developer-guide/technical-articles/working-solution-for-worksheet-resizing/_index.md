---
title: कार्यपत्रक रिसाइज़िंग के लिए कार्य समाधान
type: docs
weight: 40
url: /hi/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- पूर्वावलोकन छवि
- छवि आकार बदलना
- Excel
- कार्यपत्रक
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "प्रस्तुतियों में Excel कार्यपत्रक OLE रिसाइज़िंग को ठीक करें: वस्तु फ्रेम को सुसंगत रखने के दो तरीके—फ़्रेम या शीट को स्केल करें—PPT और PPTX स्वरूपों में।"
---
{{% alert color="info" %}} 

यह देखा गया है कि Excel कार्यपत्रक को Aspose घटकों के माध्यम से PowerPoint प्रस्तुतिकरण में OLE वस्तु के रूप में एम्बेड करने पर पहली सक्रियता के बाद अनजाने स्केल में बदल जाता है। यह व्यवहार OLE वस्तु की सक्रियता से पहले और बाद की स्थिति के बीच स्पष्ट दृश्य अंतर बनाता है। हमने इस समस्या की विस्तृत जाँच की है और एक समाधान प्रदान किया है, जिसे इस लेख में कवर किया गया है।

{{% /alert %}} 

## **पृष्ठभूमि**

लेख में [Manage OLE](/slides/hi/net/manage-ole/) हमने बताया था कि Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ें। [object preview issue](/slides/hi/net/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए हमने चयनित कार्यपत्रक क्षेत्र की एक छवि को OLE ऑब्जेक्ट फ्रेम को असाइन किया। आउटपुट प्रस्तुति में, जब आप कार्यपत्रक छवि दिखाने वाले OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करते हैं तो Excel वर्कबुक सक्रिय हो जाता है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में कोई भी परिवर्तन कर सकते हैं और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर लौटने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। रिसाइज़िंग फैक्टर OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करेगा। 

## **रिसाइज़िंग का कारण**

क्योंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपने मूल आकार को बरकरार रखने की कोशिश करता है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। Microsoft के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार का समन्वय करते हैं ताकि एम्बेडिंग प्रक्रिया के भाग के रूप में अनुपात सही बना रहे। रिसाइज़िंग Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार एवं स्थिति के अंतर के आधार पर होती है।

## **कार्यान्वित समाधान**

रिसाइज़िंग प्रभाव से बचने के दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम का आकार उन पंक्तियों और स्तंभों की इच्छित संख्या की ऊँचाई और चौड़ाई के अनुसार स्केल करें।
- OLE फ्रेम का आकार स्थिर रखें और भाग ले रही पंक्तियों एवं स्तंभों के आकार को चयनित OLE फ्रेम के भीतर फिट करने के लिए स्केल करें।

### **OLE फ्रेम आकार स्केल करें**

इस दृष्टिकोण में हम सीखेंगे कि एम्बेडेड Excel वर्कबुक का OLE फ्रेम आकार कैसे सेट करें ताकि वह Excel कार्यपत्रक में भाग ले रही पंक्तियों और स्तंभों के संचयी आकार के समान हो।

मान लीजिए हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में, OLE ऑब्जेक्ट फ्रेम का आकार पहले वर्कबुक में भाग ले रही पंक्तियों की ऊँचाई और स्तंभों की चौड़ाई के संचयी मान के आधार पर गणना किया जाएगा। फिर हम OLE फ्रेम का आकार इस गणना किए गए मान पर सेट करेंगे। PowerPoint में OLE फ्रेम के लाल “EMBEDDED OLE OBJECT” संदेश से बचने के लिए, हम वर्कबुक में आवश्यक पंक्तियों और स्तंभों के हिस्सों की एक छवि भी कैप्चर करेंगे और उसे OLE फ्रेम की छवि के रूप में सेट करेंगे।

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// PowerPoint में कार्यपुस्तिका फ़ाइल को OLE वस्तु के रूप में उपयोग करने पर प्रदर्शित आकार सेट करें।
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// OLE छवि की चौड़ाई और ऊँचाई पॉइंट्स में प्राप्त करें।
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// हमें संशोधित कार्यपुस्तिका का उपयोग करना आवश्यक है।
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// OLE छवि को प्रस्तुति संसाधनों में जोड़ें।
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// OLE वस्तु फ्रेम बनाएं।
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **सेल रेंज आकार स्केल करें**

इस दृष्टिकोण में हम सीखेंगे कि भाग ले रही पंक्तियों की ऊँचाई और भाग ले रहे स्तंभों की चौड़ाई को एक कस्टम OLE फ्रेम आकार के अनुरूप कैसे स्केल करें।

मान लीजिए हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में हम OLE फ्रेम का आकार सेट करेंगे और वह पंक्तियों व स्तंभों का आकार स्केल करेंगे जो OLE फ्रेम क्षेत्र में शामिल हैं। फिर हम वर्कबुक को एक स्ट्रीम में सहेजेंगे ताकि किए गए परिवर्तन लागू हों और इसे बाइट एरे में बदलकर OLE फ्रेम में जोड़ें। PowerPoint में OLE फ्रेम के लाल “EMBEDDED OLE OBJECT” संदेश से बचने के लिए, हम वर्कबुक में आवश्यक पंक्तियों और स्तंभों के हिस्सों की एक छवि भी कैप्चर करेंगे और उसे OLE फ्रेम की छवि के रूप में सेट करेंगे।

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// PowerPoint में कार्यपुस्तिका फ़ाइल को OLE वस्तु के रूप में उपयोग करने पर प्रदर्शित आकार सेट करें।
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// फ़्रेम आकार के अनुसार सेल रेंज को स्केल करें।
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// हमें संशोधित कार्यपुस्तिका का उपयोग करना आवश्यक है।
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// OLE छवि को प्रस्तुति संसाधनों में जोड़ें।
var oleImage = presentation.Images.AddImage(imageStream);

// OLE वस्तु फ्रेम बनाएं।
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">सेल रेंज की अपेक्षित चौड़ाई पॉइंट्स में।</param>
/// <param name="height">सेल रेंज की अपेक्षित ऊँचाई पॉइंट्स में।</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **निष्कर्ष**

{{% alert color="info" %}}

वर्कशीट रिसाइज़िंग समस्या को ठीक करने के दो तरीके हैं। उपयुक्त तरीका चयन आपके विशिष्ट आवश्यकताओं और उपयोग केस पर निर्भर करता है। दोनों तरीके उसी तरह काम करते हैं, चाहे प्रस्तुति टेम्पलेट से बनायी गई हो या शून्य से। इसके अतिरिक्त इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### पहली बार PowerPoint में सक्रिय होने पर एम्बेडेड Excel कार्यपत्रक का आकार क्यों बदल जाता है?
यह इसलिए होता है क्योंकि Excel सक्रिय होने पर अपने मूल विंडो आकार को बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। PowerPoint और Excel आकार का समन्वय करके अनुपात बनाये रखते हैं, जिससे रिसाइज़िंग हो सकती है।

### क्या इस रिसाइज़िंग समस्या को पूरी तरह रोकना संभव है?
हां। OLE फ्रेम को Excel सेल रेंज आकार के अनुसार स्केल करके या सेल रेंज को इच्छित OLE फ्रेम आकार के अनुरूप स्केल करके आप अनावश्यक रिसाइज़िंग को रोक सकते हैं।

### कौन सा स्केलिंग метод उपयोग करना चाहिए, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?
यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप अपनी प्रस्तुति में OLE फ्रेम का स्थिर आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

### क्या ये समाधान तब भी काम करेंगे जब मेरी प्रस्तुति टेम्पलेट पर आधारित हो?
हां। दोनों समाधान टेम्पलेट से बनाई गई प्रस्तुतियों और शून्य से बनाई गई प्रस्तुतियों दोनों के लिए काम करते हैं।

### इन विधियों में OLE फ्रेम के आकार पर कोई सीमा है क्या?
नहीं। आप OLE ऑब्जेक्ट फ्रेम को कोई भी आकार दे सकते हैं, बशर्ते आप स्केल को उपयुक्त रूप से सेट करें।

### PowerPoint में “EMBEDDED OLE OBJECT” प्लेसहोल्डर टेक्स्ट से कैसे बचें?
हां। लक्षित Excel सेल रेंज की एक स्नैपशॉट लेकर और उसे OLE फ्रेम की प्लेसहोल्डर इमेज के रूप में सेट करके, आप डिफॉल्ट प्लेसहोल्डर की बजाय कस्टम प्रीव्यू इमेज प्रदर्शित कर सकते हैं।

## **संबंधित लेख**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/hi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)