---
title: "वर्कशीट रीसेज़िंग के लिए कार्यात्मक समाधान"
type: docs
weight: 130
url: /hi/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- प्रिव्यू इमेज
- छवि आकार बदलना
- Excel
- वर्कशीट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides for C++
description: "PowerPoint प्रस्तुतियों में C++ का उपयोग करके वर्कशीट रीसेज़िंग के लिए कार्यात्मक समाधान"
---
{{% alert color="primary" %}}

यह देखा गया है कि Aspose घटकों के माध्यम से PowerPoint प्रस्तुति में OLE वस्तु के रूप में एम्बेड किए गए Excel वर्कशीट्स को पहली सक्रियता के बाद अज्ञात स्केल में पुनः आकार दिया जाता है। यह व्यवहार OLE वस्तु की सक्रियता से पहले और बाद की स्थिति के बीच स्पष्ट दृश्य अंतर उत्पन्न करता है। हमने इस समस्या की विस्तृत जांच की है और एक समाधान प्रदान किया है, जिस पर इस लेख में चर्चा की गई है।

{{% /alert %}}

## **पृष्ठभूमि**

लेख में [Manage OLE](/slides/hi/cpp/manage-ole/) हमने बताया था कि Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ा जाता है। [object preview issue](/slides/hi/cpp/object-preview-issue-when-adding-oleobjectframe/) को दूर करने के लिए हमने चयनित वर्कशीट क्षेत्र की छवि को OLE वस्तु फ्रेम में असाइन किया था। आउटपुट प्रस्तुति में, जब आप OLE वस्तु फ्रेम (जो वर्कशीट छवि दिखा रहा है) पर डबल‑क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाता है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में इच्छित परिवर्तन कर सकते हैं और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर वापस लौटने पर OLE वस्तु फ्रेम का आकार बदल जाएगा। पुनः आकार देने का कारक OLE वस्तु फ्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करता है।

## **पुनः आकार देने का कारण**

क्योंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपने मूल आकार को बरकरार रखने की कोशिश करता है। दूसरी ओर, OLE वस्तु फ्रेम का अपना आकार होता है। माइक्रोसॉफ्ट के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार का समन्वय करते हैं ताकि एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बना रहे। पुनः आकार देना Excel विंडो के आकार और OLE वस्तु फ्रेम के आकार एवं स्थिति के अंतर के आधार पर होता है।

## **कार्यात्मक समाधान**

पुनः आकार प्रभाव से बचने के दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम का आकार उस वांछित पंक्तियों और स्तंभों की ऊँचाई और चौड़ाई के अनुरूप स्केल करें।
- OLE फ्रेम का आकार स्थिर रखें और भाग लेने वाली पंक्तियों और स्तंभों के आकार को चयनित OLE फ्रेम के भीतर फिट करने के लिए स्केल करें।

### **OLE फ्रेम आकार स्केल करना**

इस विधि में हम सीखेंगे कि एम्बेडेड Excel वर्कबुक का OLE फ्रेम आकार कैसे सेट किया जाए ताकि वह Excel वर्कशीट की भाग लेने वाली पंक्तियों और स्तंभों के संचयी आकार के बराबर हो।

मान लीजिए हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में, OLE वस्तु फ्रेम का आकार पहले कार्यपुस्तिका में भाग लेने वाली पंक्तियों की कुल ऊँचाइयों और स्तंभों की कुल चौड़ाइयों के आधार पर गणना किया जाएगा। फिर हम OLE फ्रेम का आकार इस गणना किए मूल्य पर सेट करेंगे। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए, हम कार्यपुस्तिका में आवश्यक पंक्तियों और स्तंभों के हिस्सों की छवि भी कैप्चर करेंगे और उसे OLE फ्रेम छवि के रूप में सेट करेंगे।

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **सेल रेंज आकार स्केल करना**

इस विधि में हम सीखेंगे कि भाग लेने वाली पंक्तियों की ऊँचाइयों और भाग लेने वाले स्तंभों की चौड़ाइयों को कैसे स्केल किया जाए ताकि वे एक कस्टम OLE फ्रेम आकार से मेल खाएँ।

मान लीजिए हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में, हम OLE फ्रेम का आकार सेट करेंगे और OLE फ्रेम क्षेत्र में भाग लेने वाली पंक्तियों और स्तंभों के आकार को स्केल करेंगे। फिर हम परिवर्तन लागू करने के लिए कार्यपुस्तिका को एक स्ट्रीम में सहेजेंगे और उसे बाइट एरे में परिवर्तित करके OLE फ्रेम में जोड़ेंगे। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए, हम कार्यपुस्तिका में आवश्यक पंक्तियों और स्तंभों के हिस्सों की छवि भी कैप्चर करेंगे और उसे OLE फ्रेम छवि के रूप में सेट करेंगे।

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// जब वर्कबुक फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है, तब प्रदर्शित आकार सेट करें।
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// फ़्रेम आकार में फिट होने के लिए सेल रेंज को स्केल करें।
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// हमें संशोधित वर्कबुक का उपयोग करना है।
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// प्रेजेंटेशन संसाधनों में OLE छवि जोड़ें।
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// OLE ऑब्जेक्ट फ्रेम बनाएं।
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
/// <param name="width">सेल रेंज की अपेक्षित चौड़ाई पॉइंट में।</param>
/// <param name="height">सेल रेंज की अपेक्षित ऊँचाई पॉइंट में।</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cpp
SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **निष्कर्ष**

{{% alert color="primary" %}}

वर्कशीट पुनः आकार समस्या को ठीक करने के दो तरीके हैं। उपयुक्त तरीका चयन विशेष आवश्यकताओं और उपयोग के मामले पर निर्भर करता है। दोनों तरीके समान रूप से काम करते हैं, चाहे प्रस्तुति टेम्पलेट से बनाई गई हो या शून्य से। इसके अतिरिक्त, इस समाधान में OLE वस्तु फ्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में पहली सक्रियता पर एम्बेडेड Excel वर्कशीट का आकार क्यों बदल जाता है?**

यह इसलिए होता है क्योंकि Excel सक्रिय होने पर अपना मूल विंडो आकार बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE वस्तु फ्रेम का अपना आयाम होता है। PowerPoint और Excel आकार का समन्वय करके अनुपात बनाए रखते हैं, जिससे पुनः आकार हो सकता है।

**क्या इस पुनः आकार समस्या को पूरी तरह रोकना संभव है?**

हाँ। OLE फ्रेम को Excel सेल रेंज आकार के अनुसार स्केल करके या सेल रेंज को वांछित OLE फ्रेम आकार के अनुसार स्केल करके अनचाहा पुनः आकार रोक सकते हैं।

**कौन सी स्केलिंग विधि उपयोग करनी चाहिए, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?**

यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप अपनी प्रस्तुति में OLE फ्रेम के लिए निश्चित आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

**क्या ये समाधान मेरे टेम्पलेट-आधारित प्रस्तुति में भी काम करेंगे?**

हाँ। दोनों समाधान टेम्पलेट से बनाई गई या शून्य से बनाई गई प्रस्तुतियों में काम करते हैं।

**इन तरीकों का उपयोग करते समय OLE फ्रेम के आकार पर कोई सीमा है क्या?**

नहीं। आप OLE वस्तु फ्रेम को कोई भी आकार दे सकते हैं, बशर्ते आप स्केल उपयुक्त रूप से सेट करें।

**PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट से कैसे बचें?**

हाँ। लक्ष्य Excel सेल रेंज की स्नैपशॉट लेकर उसे OLE फ्रेम की प्लेसहोल्डर छवि के रूप में सेट करके आप डिफ़ॉल्ट प्लेसहोल्डर की जगह कस्टम प्रीव्यू छवि दर्शा सकते हैं।

## **संबंधित लेख**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/hi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)