---
title: वर्कशीट रिसाइज़िंग के लिए कार्य समाधान
type: docs
weight: 130
url: /hi/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- पूर्वावलोकन छवि
- छवि आकार बदलना
- Excel
- वर्कशीट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides for C++
description: "PowerPoint प्रस्तुतियों में C++ का उपयोग करके वर्कशीट रिसाइज़िंग के लिए कार्य समाधान"
---
{{% alert color="info" %}}

यह देखी गई है कि Aspose घटकों के माध्यम से PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड की गई Excel वर्कशीट्स पहली सक्रियता के बाद एक अज्ञात स्केल में पुनः आकारित हो जाती हैं। यह व्यवहार OLE ऑब्जेक्ट की सक्रियता से पहले और बाद की स्थिति के बीच प्रस्तुति में एक स्पष्ट दृश्य अंतर बनाता है। हमने इस समस्या की विस्तृत जांच की है और एक समाधान प्रदान किया है, जिसके बारे में इस लेख में बताया गया है।

{{% /alert %}}

## **पृष्ठभूमि**

लेख [Manage OLE](/slides/hi/cpp/manage-ole/) में हमने बताया था कि Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ें। [object preview issue](/slides/hi/cpp/object-preview-issue-when-adding-oleobjectframe/) को संबोधित करने के लिए हमने चयनित वर्कशीट क्षेत्र की छवि को OLE ऑब्जेक्ट फ्रेम को सौंपा। आउटपुट प्रस्तुति में, जब आप वर्कशीट छवि दिखाते हुए OLE ऑब्जेक्ट फ्रेम पर डबल-क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाती है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में इच्छित परिवर्तन कर सकते हैं और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर लौट सकते हैं। उपयोगकर्ता के स्लाइड पर लौटने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। री-साइज़िंग कारक OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करेगा।

## **रिसाइज़िंग का कारण**

चूंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपना मूल आकार बनाए रखने की कोशिश करता है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। Microsoft के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर चर्चा करते हैं ताकि एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बना रहे। री-साइज़िंग Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार व स्थिति के अंतर के आधार पर होती है।

## **कार्यशील समाधान**

री-साइज़िंग प्रभाव से बचने के लिए दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम का आकार स्केल करें ताकि OLE फ्रेम में वांछित पंक्तियों और स्तंभों की संख्या की ऊँचाई और चौड़ाई से मिल सके।
- OLE फ्रेम का आकार स्थिर रखें और भाग ले रही पंक्तियों और स्तंभों के आकार को चुने गए OLE फ्रेम आकार में फिट होने के लिए स्केल करें।

### **OLE फ्रेम आकार स्केल करें**

इस दृष्टिकोण में, हम सीखेंगे कि एम्बेडेड Excel वर्कबुक के OLE फ्रेम का आकार कैसे सेट करें ताकि वह Excel वर्कशीट में भाग ले रही पंक्तियों और स्तंभों के संयुक्‍त आकार से मेल खाए।

मान लीजिए हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में, OLE ऑब्जेक्ट फ्रेम का आकार पहले वर्कबुक में भाग ले रही पंक्तियों और स्तंभों की संयुक्त पंक्ति ऊँचाइयों और स्तंभ चौड़ाइयों के आधार पर गणना किया जाएगा। फिर, हम OLE फ्रेम का आकार इस गणना किए गए मान पर सेट करेंगे। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए, हम वर्कबुक में पंक्तियों और स्तंभों के वांछित भाग की छवि भी कैप्चर करेंगे और उसे OLE फ्रेम की छवि के रूप में सेट करेंगे।

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// जब वर्कबुक फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में इस्तेमाल किया जाता है तो प्रदर्शित आकार सेट करें।
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// OLE छवि की चौड़ाई और ऊँचाई को पॉइंट्स में प्राप्त करें।
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// हमें संशोधित वर्कबुक का उपयोग करना आवश्यक है।
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
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"
using namespace System;
using namespace System::IO;

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

### **सेल रेंज आकार स्केल करें**

इस दृष्टिकोण में, हम सीखेंगे कि भाग ले रही पंक्तियों की ऊँचाइयों और भाग ले रहे स्तंभों की चौड़ाई को एक कस्टम OLE फ्रेम आकार से मेल करने के लिए कैसे स्केल किया जाए।

मान लीजिए हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में, हम OLE फ्रेम का आकार सेट करेंगे और OLE फ्रेम क्षेत्र में भाग ले रही पंक्तियों और स्तंभों के आकार को स्केल करेंगे। फिर हम वर्कबुक को एक स्ट्रीम में सहेजेंगे ताकि परिवर्तन लागू हों और उसे बाइट एरे में बदलकर OLE फ्रेम में जोड़ सकें। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए, हम वर्कबुक में पंक्तियों और स्तंभों के वांछित भाग की छवि भी कैप्चर करेंगे और उसे OLE फ्रेम की छवि के रूप में सेट करेंगे।

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// जब वर्कबुक फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है तो प्रदर्शित आकार सेट करें।
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// फ्रेम आकार में फिट होने के लिए सेल रेंज को स्केल करें।
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// हमें संशोधित वर्कबुक का उपयोग करना आवश्यक है।
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// OLE छवि को प्रस्तुति संसाधनों में जोड़ें।
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">सेल रेंज की अपेक्षित चौड़ाई पॉइंट्स में।</param>
/// <param name="height">सेल रेंज की अपेक्षित ऊँचाई पॉइंट्स में।</param>
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
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"
using namespace System;
using namespace System::IO;

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

{{% alert color="info" %}}

वर्कशीट री-साइज़िंग समस्या को ठीक करने के दो तरीके हैं। उपयुक्त तरीके का चयन विशिष्ट आवश्यकताओं और उपयोग केस पर निर्भर करता है। दोनों तरीके एक ही तरह काम करते हैं, चाहे प्रस्तुति टेम्पलेट से बनाई गई हो या शून्य से। अतिरिक्त रूप से, इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### PowerPoint में पहली बार सक्रिय होने पर एम्बेडेड Excel वर्कशीट का आकार क्यों बदलता है?

यह इसलिए होता है क्योंकि सक्रिय होने पर Excel मूल विंडो आकार को बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आयाम होता है। PowerPoint और Excel आकार पर बातचीत करते हैं ताकि अनुपात बना रहे, जिससे री-साइज़िंग हो सकती है।

### क्या इस री-साइज़िंग समस्या को पूरी तरह रोकना संभव है?

हाँ। OLE फ्रेम को Excel सेल रेंज आकार में फिट करने के लिए स्केल करके या सेल रेंज को इच्छित OLE फ्रेम आकार में फिट करने के लिए स्केल करके आप अनचाही री-साइज़िंग से बच सकते हैं।

### कौन सा स्केलिंग तरीका उपयोग करना चाहिए, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?

**OLE फ्रेम स्केलिंग** चुनें यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं। **सेल रेंज स्केलिंग** चुनें यदि आप अपनी प्रस्तुति में OLE फ्रेम के लिए एक निश्चित आकार चाहते हैं।

### क्या ये समाधान काम करेंगे यदि मेरी प्रस्तुति टेम्पलेट पर आधारित है?

हाँ। दोनों समाधान टेम्पलेट से बनाई गई और शून्य से बनाई गई प्रस्तुतियों दोनों में काम करते हैं।

### इन विधियों का उपयोग करते समय OLE फ्रेम के आकार पर कोई सीमा है क्या?

नहीं। आप OLE ऑब्जेक्ट फ्रेम को कोई भी आकार दे सकते हैं, बशर्ते आप स्केल को ठीक से सेट करें।

### PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट से बचने का कोई तरीका है क्या?

हाँ। लक्ष्य Excel सेल रेंज की स्नैपशॉट लेकर और उसे OLE फ्रेम की प्लेसहोल्डर छवि के रूप में सेट करके, आप डिफ़ॉल्ट प्लेसहोल्डर के स्थान पर एक कस्टम प्रीव्यू छवि दिखा सकते हैं।

## **संबंधित लेख**

[एक Excel चार्ट बनाना और उसे प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड करना](/slides/hi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)