---
title: कार्यपत्रक रिसाइज़िंग के लिए कार्यशील समाधान
type: docs
weight: 40
url: /hi/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- पूर्वावलोकन छवि
- छवि रिसाइज़िंग
- Excel
- कार्यपत्रक
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "प्रस्तुतियों में Excel कार्यपत्रक OLE रिसाइज़िंग को ठीक करें: दो तरीके जिससे ऑब्जेक्ट फ्रेम को सुसंगत रखा जा सके—फ्रेम को स्केल करें या शीट को—PPT और PPTX फ़ॉर्मैट्स में।"
---
{{% alert color="primary" %}} 

यह देखा गया है कि Aspose घटकों के माध्यम से PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड किए गए Excel वर्कशीट को पहली सक्रियता के बाद एक अज्ञात स्केल में बदल दिया जाता है। यह व्यवहार OLE ऑब्जेक्ट की पूर्व और पश्च सक्रियता स्थितियों के बीच एक स्पष्ट दृश्य अंतर उत्पन्न करता है। हमने इस समस्या की विस्तृत जांच की है और एक समाधान प्रदान किया है, जिसका विवरण इस लेख में दिया गया है।

{{% /alert %}} 

## **पृष्ठभूमि**

लेख में[OLE प्रबंधन](/slides/hi/net/manage-ole/) में हमने बताया था कि Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ा जाए।[ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/net/object-preview-issue-when-adding-oleobjectframe/) को दूर करने के लिए हमने OLE ऑब्जेक्ट फ्रेम को चयनित वर्कशीट क्षेत्र की छवि से सेट किया। आउटपुट प्रस्तुति में, जब आप OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करते हैं जो वर्कशीट छवि दिखा रहा है, तो Excel कार्यपुस्तिका सक्रिय हो जाती है। अंतिम उपयोगकर्ता वास्तविक Excel कार्यपुस्तिका में वांछित परिवर्तन कर सकते हैं और फिर सक्रिय Excel कार्यपुस्तिका के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर लौटने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। रिसाइज़िंग कारक OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel कार्यपुस्तिका के आकार पर निर्भर करेगा। 

## **रिसाइज़िंग का कारण**

चूंकि Excel कार्यपुस्तिका की अपनी विंडो आकार होता है, यह पहली सक्रियता पर अपना मूल आकार बनाए रखने की कोशिश करती है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। माइक्रोसॉफ्ट के अनुसार, जब Excel कार्यपुस्तिका सक्रिय होती है, तो Excel और PowerPoint आकार की बातचीत करके एम्बेडिंग प्रक्रिया के हिस्से के रूप में उचित अनुपात बनाए रखते हैं। रिसाइज़िंग Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार तथा स्थिति के अंतर के आधार पर होती है।

## **कार्यशील समाधान**

रिसाइज़िंग प्रभाव से बचने के दो संभावित समाधान हैं।

- OLE फ्रेम का आकार PowerPoint प्रस्तुति में उस वांछित पंक्तियों और स्तंभों की ऊँचाई और चौड़ाई से मेल करने के लिए स्केल करें।
- OLE फ्रेम का आकार स्थिर रखें और चयनित OLE फ्रेम के भीतर फिट होने के लिए भाग लेने वाली पंक्तियों और स्तंभों का आकार स्केल करें।

### **OLE फ्रेम आकार स्केल करें**

इस दृष्टिकोण में हम सीखेंगे कि एम्बेडेड Excel कार्यपुस्तिका का OLE फ्रेम आकार कैसे सेट करें ताकि वह Excel वर्कशीट में भाग लेने वाली पंक्तियों और स्तंभों के सम्मिलित आकार के बराबर हो।

मान लीजिए हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में, OLE ऑब्जेक्ट फ्रेम का आकार पहले कार्यपुस्तिका में भाग लेने वाली पंक्तियों की कुल ऊँचाइयों और स्तंभों की कुल चौड़ाइयों के आधार पर गणना किया जाएगा। फिर हम OLE फ्रेम का आकार इस गणना किए गए मान पर सेट करेंगे। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए, हम कार्यपुस्तिका में पंक्तियों और स्तंभों के वांछित हिस्सों की छवि कैप्चर करेंगे और उसे OLE फ्रेम छवि के रूप में सेट करेंगे।

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// जब कार्यपुस्तिका फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है तो प्रदर्शित आकार निर्धारित करें।
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// OLE छवि की चौड़ाई और ऊँचाई को पॉइंट्स में प्राप्त करें।
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// हमें संशोधित कार्यपुस्तिका का उपयोग करना होगा।
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// प्रस्तुति संसाधनों में OLE छवि जोड़ें।
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// OLE ऑब्जेक्ट फ्रेम बनाएँ।
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

इस दृष्टिकोण में हम सीखेंगे कि भाग लेने वाली पंक्तियों की ऊँचाइयों और भाग लेने वाले स्तंभों की चौड़ाइयों को कैसे स्केल करें ताकि वह एक कस्टम OLE फ्रेम आकार से मेल खाए।

मान लीजिए हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में, हम OLE फ्रेम का आकार सेट करेंगे और OLE फ्रेम क्षेत्र में भाग लेने वाली पंक्तियों और स्तंभों के आकार को स्केल करेंगे। फिर हम परिवर्तनों को लागू करने के लिए कार्यपुस्तिका को स्ट्रीम में सहेजेंगे और OLE फ्रेम में जोड़ने के लिए उसे बाइट ऐरे में बदलेंगे। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए, हम कार्यपुस्तिका में पंक्तियों और स्तंभों के वांछित हिस्सों की छवि कैप्चर करेंगे और उसे OLE फ्रेम छवि के रूप में सेट करेंगे।

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// जब कार्यपुस्तिका फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है तो प्रदर्शित आकार निर्धारित करें।
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// फ्रेम आकार में फिट होने के लिए सेल रेंज को स्केल करें।
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// हमें संशोधित कार्यपुस्तिका का उपयोग करना होगा।
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// प्रस्तुति संसाधनों में OLE छवि जोड़ें।
var oleImage = presentation.Images.AddImage(imageStream);

// OLE ऑब्जेक्ट फ्रेम बनाएं।
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

{{% alert color="primary" %}}

वर्कशीट रिसाइज़िंग समस्या को ठीक करने के दो तरीके हैं। उपयुक्त तरीका चयन विशिष्ट आवश्यकताओं और उपयोग मामले पर निर्भर करता है। दोनों तरीके समान रूप से काम करते हैं, चाहे प्रस्तुति टेम्पलेट से बनाई गई हो या शुरू से। अतिरिक्त रूप से, इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}

## **FAQ**

**पहली सक्रियता के बाद PowerPoint में एम्बेडेड Excel वर्कशीट का आकार क्यों बदलता है?**  
यह इसलिए होता है क्योंकि Excel सक्रिय होने पर अपना मूल विंडो आकार बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। PowerPoint और Excel अनुपात बनाए रखने के लिए आकार पर बातचीत करते हैं, जिससे रिसाइज़िंग हो सकती है।

**क्या इस रिसाइज़िंग समस्या को पूरी तरह रोका जा सकता है?**  
हां। OLE फ्रेम को Excel सेल रेंज आकार के अनुरूप स्केल करके या सेल रेंज को इच्छित OLE फ्रेम आकार के अनुरूप स्केल करके अनचाहे रिसाइज़िंग को रोका जा सकता है।

**कौन‑सा स्केलिंग तरीका अपनाना चाहिए, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?**  
यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप प्रस्तुति में OLE फ्रेम का आकार स्थिर रखना चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

**क्या ये समाधान टेम्पलेट‑आधारित प्रस्तुतियों के लिए भी काम करेंगे?**  
हां। दोनों समाधान टेम्पलेट से निर्मित प्रस्तुतियों और शून्य से निर्मित प्रस्तुतियों दोनों पर कार्य करते हैं।

**इन तरीकों का उपयोग करते समय OLE फ्रेम के आकार पर कोई सीमा है क्या?**  
नहीं। आप OLE ऑब्जेक्ट फ्रेम को किसी भी आकार में बना सकते हैं, बस स्केल को उचित रूप से सेट करना होगा।

**PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट से कैसे बचा जाए?**  
हां। लक्ष्य Excel सेल रेंज की स्नैपशॉट लेकर उसे OLE फ्रेम की प्लेसहोल्डर छवि के रूप में सेट करने से आप डिफ़ॉल्ट प्लेसहोल्डर के स्थान पर एक कस्टम प्रीव्यू छवि प्रदर्शित कर सकते हैं।

## **संबंधित लेख**

[एक Excel चार्ट बनाकर उसे OLE ऑब्जेक्ट के रूप में प्रस्तुति में एम्बेड करना](/slides/hi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint ऐड‑इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वचालित रूप से अपडेट करना](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)