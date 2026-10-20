---
title: वर्कशीट आकार बदलने के लिए कार्य समाधान
type: docs
weight: 40
url: /hi/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- पूर्वावलोकन छवि
- छवि आकार बदलना
- Excel
- वर्कशीट
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "प्रस्तुतियों में Excel वर्कशीट OLE आकार बदलने की समस्या को ठीक करें: वस्तु फ़्रेम को स्थिर रखने के दो तरीके—फ़्रेम को स्केल करें या शीट को—PPT और PPTX फ़ॉर्मैट्स में।"
---
{{% alert color="info" title="Note" %}}

Aspose घटकों का उपयोग करके PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड किए गए Excel कार्यपत्रक पहली सक्रियता के बाद अप्रत्याशित रूप से आकार बदल सकते हैं। यह व्यवहार OLE ऑब्जेक्ट के सक्रियण से पहले और बाद के बीच एक स्पष्ट दृश्य अंतर बनाता है। यह लेख इस समस्या को समझाता है और इसे हल करने के दो तरीकों का वर्णन करता है।

{{% /alert %}} 

## **पृष्ठभूमि**

लेख [OLE प्रबंधन](/slides/hi/net/manage-ole/) में हमने बताया कि Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुति में OLE फ़्रेम कैसे जोड़ें। [ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/net/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए, हमने चयनित कार्यपत्रक क्षेत्र की एक छवि को OLE ऑब्जेक्ट फ़्रेम को सौंपा। आउटपुट प्रस्तुति में, जब आप कार्यपत्रक छवि दिखाने वाले OLE ऑब्जेक्ट फ़्रेम पर दो बार क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाती है। उपयोगकर्ता वास्तविक Excel वर्कबुक में आवश्यक परिवर्तन कर सकते हैं और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर लौट सकते हैं। उपयोगकर्ता स्लाइड पर लौटने पर OLE ऑब्जेक्ट फ़्रेम का आकार बदल जाएगा। आकार बदलने का अनुपात OLE ऑब्जेक्ट फ़्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करेगा।

## **आकार बदलने का कारण**

चूंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपना मूल आकार बनाए रखने का प्रयास करता है। दूसरी ओर, OLE ऑब्जेक्ट फ़्रेम का अपना आकार होता है। माइक्रोसॉफ्ट के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर बातचीत करते हैं ताकि एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बनाए रखा जा सके। आकार बदलना Excel विंडो आकार और OLE ऑब्जेक्ट फ़्रेम के आकार व स्थिति के बीच के अंतर के आधार पर होता है।

## **कार्यशील समाधान**

आकार बदलने के प्रभाव को टालने के दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ़्रेम को चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के अनुसार स्केल करें।
- OLE फ़्रेम का आकार स्थिर रखें और चयनित पंक्तियों और स्तंभों को उसके भीतर फिट होने के लिए स्केल करें।

### **OLE फ़्रेम आकार स्केल करें**

यह विधि एम्बेडेड Excel कार्यपत्रक में चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के अनुसार OLE फ़्रेम का आकार सेट करती है।

उदाहरण मौजूदा Excel वर्कबुक को लोड करता है और शून्य-आधारित इंडेक्स का उपयोग करके उसकी पहली कार्यपत्रक की पहली 10 पंक्तियों और 13 स्तंभों का चयन करता है। [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) प्रदर्शित रेंज को निर्धारित करता है। प्रीव्यू 96 DPI पर रेंडर किया जाता है, और उसके पिक्सेल आयामों को 72 पॉइंट प्रति इंच का उपयोग करके पॉइंट में परिवर्तित किया जाता है। [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) संशोधित वर्कबुक को उन आयामों वाले फ़्रेम में एम्बेड करता है। प्रीव्यू को [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) के माध्यम से असाइन किया जाता है ताकि सहेजी गई प्रस्तुति में "EMBEDDED OLE OBJECT" प्लेसहोल्डर को बदल सके।

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

// जब वर्कबुक फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है तो प्रदर्शित आकार सेट करें।
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// OLE छवि की चौड़ाई और ऊँचाई को पॉइंट में प्राप्त करें।
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// हमें संशोधित वर्कबुक का उपयोग करना है।
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// प्रस्तुति संसाधनों में OLE छवि जोड़ें।
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// OLE ऑब्जेक्ट फ़्रेम बनाएं।
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

प्रीव्यू हेल्पर चयनित रेंज के लिए [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) सेट करता है और मार्जिन, हेडर और फुटर को हटाता है। [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) सक्षम होने पर, [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) रेंज को PNG छवि के रूप में रेंडर करता है। हेल्पर प्रस्तुति में उपयोग के लिए लौटाने से पहले इमेज स्ट्रीम को रीवाइंड करता है।

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

यह विधि चयनित पंक्तियों की ऊँचाई और चयनित स्तंभों की चौड़ाई को एक कस्टम OLE फ़्रेम आकार के अनुसार स्केल करती है।

उदाहरण मौजूदा Excel वर्कबुक को लोड करता है और शून्य-आधारित इंडेक्स का उपयोग करके उसकी पहली कार्यपत्रक की पहली 10 पंक्तियों और 13 स्तंभों का चयन करता है। [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) प्रदर्शित रेंज को निर्धारित करता है, और नीचे दिया गया हेल्पर उस रेंज को 400 पॉइंट चौड़ी और 100 पॉइंट ऊँची फ़्रेम में फिट होने के लिए स्केल करता है। संशोधित वर्कबुक को स्ट्रीम में सहेजने के बाद, [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) निर्दिष्ट आकार पर एम्बेड किया जाता है। 96 DPI पर रेंडर किया गया प्रीव्यू [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) के माध्यम से असाइन किया जाता है, ताकि सहेजी गई प्रस्तुति चयनित कोशिकाओं को डिफ़ॉल्ट प्लेसहोल्डर के बजाय दिखाए।

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

// जब वर्कबुक फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है तो प्रदर्शित आकार सेट करें।
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// फ़्रेम आकार में फिट होने के लिए सेल रेंज को स्केल करें।
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// हमें संशोधित वर्कबुक का उपयोग करना है।
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// प्रस्तुति संसाधनों में OLE छवि जोड़ें।
var oleImage = presentation.Images.AddImage(imageStream);

// OLE ऑब्जेक्ट फ़्रेम बनाएं।
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

स्केलिंग हेल्पर चयनित रेंज के लिए अलग-अलग चौड़ाई और ऊँचाई अनुपात गणना करता है, जिससे उसके स्तंभों की सापेक्ष चौड़ाई और पंक्तियों की सापेक्ष ऊँचाई बनी रहे। यह गणना किए गए आयामों को पॉइंट से इंच में परिवर्तित करता है और फिर उन्हें [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) और [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/) के साथ लागू करता है। चयनित रेंज का चौड़ाई और ऊँचाई दोनों शून्य से अधिक होना चाहिए।

```cs
/// <param name="width">सेल रेंज की अपेक्षित चौड़ाई पॉइंट में।</param>
/// <param name="height">सेल रेंज की अपेक्षित ऊँचाई पॉइंट में।</param>
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

यह प्रीव्यू हेल्पर [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) का उपयोग करके बदलिए हुए रेंज को रेंडर करता है। यह [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) को उस रेंज तक सीमित करता है, मार्जिन, हेडर और फुटर को हटाता है, और शुरुआत में स्थित PNG स्ट्रीम लौटाता है।

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

{{% alert color="info" title="Note" %}}

वर्कशीट आकार बदलने की समस्या को ठीक करने के दो तरीके हैं। अपनी आवश्यकताओं और उपयोग केस के अनुसार सबसे उपयुक्त तरीका चुनें। दोनों तरीके समान रूप से काम करते हैं, चाहे प्रस्तुतियों को टेम्पलेट से बनाया गया हो या शुरुआत से। अतिरिक्त रूप से, इस समाधान में OLE ऑब्जेक्ट फ़्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**एक्सेल कार्यपत्रक पहली बार PowerPoint में सक्रिय होने पर आकार क्यों बदलता है?**

यह इसलिए होता है क्योंकि Excel सक्रियण के समय अपने मूल विंडो आकार को बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ़्रेम का अपना आकार होता है। आकार बनाए रखने के लिए PowerPoint और Excel अनुपात को समायोजित करने के लिए बातचीत करते हैं, जिससे आकार बदलना उत्पन्न होता है।

**क्या इस आकार बदलने की समस्या को पूरी तरह रोकना संभव है?**

हाँ। OLE फ़्रेम को Excel सेल रेंज आकार के अनुसार स्केल करके या सेल रेंज को इच्छित OLE फ़्रेम आकार में स्केल करके आप अनचाहे आकार बदलने से बच सकते हैं।

**कौन सा स्केलिंग तरीका उपयोग करना चाहिए, OLE फ़्रेम स्केलिंग या सेल रेंज स्केलिंग?**

यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं तो **OLE फ़्रेम स्केलिंग** चुनें। यदि आप प्रस्तुति में OLE फ़्रेम के लिए एक निश्चित आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

**क्या ये समाधान मेरे टेम्पलेट-आधारित प्रस्तुति पर भी काम करेंगे?**

हाँ। दोनों समाधान टेम्पलेट से बनाई गई प्रस्तुतियों और शून्य से शुरू की गई प्रस्तुतियों दोनों में काम करते हैं।

**इन तरीकों का उपयोग करते समय OLE फ़्रेम के आकार पर कोई सीमा है क्या?**

नहीं। आप OLE ऑब्जेक्ट फ़्रेम को किसी भी आकार का बना सकते हैं, बशर्ते आप स्केल को उचित रूप से सेट करें।

**PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट से बचने का कोई तरीका है?**

हाँ। लक्ष्य Excel सेल रेंज की एक स्नैपशॉट लेकर उसे OLE फ़्रेम के प्लेसहोल्डर चित्र के रूप में सेट करके आप डिफ़ॉल्ट प्लेसहोल्डर के बजाय कस्टम प्रीव्यू छवि दिखा सकते हैं।

## **संबंधित लेख**

[एक्सेल चार्ट बनाना और उसे प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड करना](/slides/hi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint ऐड-इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वचालित रूप से अपडेट करना](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)