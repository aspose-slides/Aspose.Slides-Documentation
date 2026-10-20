---
title: वर्कशीट रिसाइज़िंग के लिए कार्यशील समाधान
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
description: "C++ का उपयोग करके PowerPoint प्रस्तुतियों में वर्कशीट रिसाइज़िंग के लिए कार्यशील समाधान"
---
{{% alert color="info" title="Note" %}}
Aspose घटकों का उपयोग करके PowerPoint प्रस्तुति में OLE वस्तुओं के रूप में एम्बेड किए गए Excel वर्कशीट्स पहली सक्रियता के बाद अप्रत्याशित रूप से आकार बदल सकते हैं। यह व्यवहार OLE वस्तु को सक्रिय करने से पहले और बाद में दृश्य अंतर बनाता है। यह लेख इस समस्या की व्याख्या करता है और इसे हल करने के दो तरीके वर्णित करता है।
{{% /alert %}}

## **पृष्ठभूमि**

लेख में [OLE प्रबंधन](/slides/hi/cpp/manage-ole/) में, हमने Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुति में OLE फ़्रेम कैसे जोड़ें, समझाया था। [ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/cpp/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए, हमने चयनित वर्कशीट क्षेत्र की छवि को OLE ऑब्जेक्ट फ़्रेम को सौंपा। आउटपुट प्रस्तुति में, जब आप वर्कशीट छवि दिखाने वाले OLE ऑब्जेक्ट फ़्रेम पर डबल-क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाती है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में इच्छित परिवर्तन कर सकते हैं और फिर सक्रियित Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर लौटने पर OLE ऑब्जेक्ट फ़्रेम का आकार बदल जाएगा। रिसाइज़िंग कारक OLE ऑब्जेक्ट फ़्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करेगा।

## **रिसाइज़िंग का कारण**

चूँकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपने मूल आकार को बनाए रखने का प्रयास करता है। दूसरी ओर, OLE ऑब्जेक्ट फ़्रेम का अपना आकार होता है। माइक्रोसॉफ्ट के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार को इस प्रकार नेगोशिएट करते हैं कि एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बना रहे। रिसाइज़िंग Excel विंडो आकार और OLE ऑब्जेक्ट फ़्रेम के आकार और स्थिति के अंतर के आधार पर होती है।

## **कार्यात्मक समाधान**

रिसाइज़िंग प्रभाव से बचने के दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ़्रेम को स्केल करके चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई से मिलाएँ।
- OLE फ़्रेम का आकार स्थिर रखें और चयनित पंक्तियों और स्तंभों को उसके भीतर फिट होने के लिए स्केल करें।

### **OLE फ़्रेम आकार को स्केल करें**

यह विधि एम्बेडेड Excel वर्कशीट में चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई से मेल खाने के लिये OLE फ़्रेम का आकार सेट करती है।  
उदाहरण एक मौजूदा Excel वर्कबुक को लोड करता है और शून्य-आधारित सूचकांक का उपयोग करके उसकी पहली वर्कशीट की पहली 10 पंक्तियों और 13 स्तंभों का चयन करता है। [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) प्रदर्शित रेंज को निर्धारित करता है। प्रीव्यू को 96 DPI पर रेंडर किया जाता है, और उसके पिक्सेल आयामों को प्रति इंच 72 पॉइंट का उपयोग करके पॉइंट में बदला जाता है। [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) संशोधित वर्कबुक को उन आयामों वाले फ़्रेम में एम्बेड करता है। प्रीव्यू को [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) के माध्यम से असाइन किया जाता है ताकि सहेजी गई प्रस्तुति में "EMBEDDED OLE OBJECT" प्लेसहोल्डर को बदल दिया जाए।

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

// जब कार्यपुस्तिका फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है तो प्रदर्शित आकार सेट करें।
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// OLE छवि की चौड़ाई और ऊँचाई को पॉइंट्स में प्राप्त करें।
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// हमें संशोधित कार्यपुस्तिका का उपयोग करना है।
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// OLE छवि को प्रस्तुति संसाधनों में जोड़ें।
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// OLE ऑब्जेक्ट फ़्रेम बनाएँ।
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

प्रीव्यू हेल्पर [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) का उपयोग करके रेंज का चयन करता है और मार्जिन, हेडर और फुटर को हटाता है। [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) को सक्षम करने पर, [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) रेंज को PNG इमेज के रूप में रेंडर करता है। हेल्पर रेंडर की गई इमेज डेटा को नई मेमोरी स्ट्रीम में उसकी शुरुआत पर स्थित करके प्रस्तुति में उपयोग के लिए कॉपी करता है।

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

### **सेल रेंज आकार को स्केल करें**

यह विधि चयनित पंक्तियों की ऊँचाइयों और चयनित स्तंभों की चौड़ाइयों को एक कस्टम OLE फ़्रेम आकार से मिलाने के लिये स्केल करती है।  
उदाहरण एक मौजूदा Excel वर्कबुक को लोड करता है और शून्य-आधारित सूचकांक का उपयोग करके उसकी पहली वर्कशीट की पहली 10 पंक्तियों और 13 स्तंभों का चयन करता है। [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) प्रदर्शित रेंज को परिभाषित करता है, और नीचे दिया गया हेल्पर उस रेंज को 400 पॉइंट चौड़ी और 100 पॉइंट ऊँची फ़्रेम में फिट करने हेतु स्केल करता है। संशोधित वर्कबुक को बाइट एरे में सहेजने के बाद, [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) इसे निर्दिष्ट आकार पर एम्बेड करता है। 96 DPI पर रेंडर किया गया प्रीव्यू [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) के माध्यम से असाइन किया जाता है, ताकि सहेजी गई प्रस्तुति डिफ़ॉल्ट प्लेसहोल्डर के बजाय चयनित सेल्स दिखाए।

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

// जब कार्यपुस्तिका फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है तो प्रदर्शित आकार सेट करें।
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// फ़्रेम आकार में फिट होने के लिये सेल रेंज को स्केल करें।
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// हमें संशोधित कार्यपुस्तिका का उपयोग करना है।
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// OLE छवि को प्रस्तुति संसाधनों में जोड़ें।
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// OLE ऑब्जेक्ट फ़्रेम बनाएं।
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

स्केलिंग हेल्पर चयनित रेंज के लिए अलग-अलग चौड़ाई और ऊँचाई अनुपात की गणना करता है, जिससे उसके स्तंभों की सापेक्ष चौड़ाई और पंक्तियों की सापेक्ष ऊँचाई बनी रहती है। यह गणना किए गए आयामों को पॉइंट से इंच में बदलता है और फिर उन्हें [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) और [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/) के साथ लागू करता है। चयनित रेंज की चौड़ाई और ऊँचाई शून्य नहीं होनी चाहिए।

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

यह प्रीव्यू हेल्पर रिसाइज़ किए गए रेंज को [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) का उपयोग करके रेंडर करता है। यह [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) का उपयोग करके प्रिंटिंग को उसी रेंज तक सीमित करता है, मार्जिन, हेडर और फुटर को हटाता है, और PNG स्ट्रीम को उसकी शुरुआत पर स्थित करके वापस देता है।

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
{{% alert color="info" title="Note" %}}
वर्कशीट रिसाइज़िंग समस्या को ठीक करने के दो तरीके हैं। वह तरीका चुनें जो आपकी आवश्यकताओं और उपयोग के मामले के लिए सबसे उपयुक्त हो। दोनों तरीके एक ही तरीके से काम करते हैं, चाहे प्रस्तुति टेम्पलेट से बनाई गई हो या शुरू से। अतिरिक्त रूप से, इस समाधान में OLE ऑब्जेक्ट फ़्रेम के आकार पर कोई सीमा नहीं है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में पहली बार सक्रिय होने पर एम्बेडेड Excel वर्कशीट का आकार क्यों बदलता है?**  
यह इसलिए होता है क्योंकि Excel सक्रिय होने पर मूल विंडो आकार को बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ़्रेम का अपना आकार होता है। PowerPoint और Excel अनुपात को बनाए रखने के लिए आकार पर बातचीत करते हैं, जिससे रिसाइज़िंग हो सकता है।

**क्या इस रिसाइज़िंग समस्या को पूरी तरह से रोकना संभव है?**  
हां। OLE फ़्रेम को Excel सेल रेंज आकार में फिट करने के लिए स्केल करके या सेल रेंज को इच्छित OLE फ़्रेम आकार में फिट करने के लिए स्केल करके आप अनचाहे रिसाइज़िंग को रोक सकते हैं।

**मुझे कौन सा स्केलिंग तरीका उपयोग करना चाहिए, OLE फ़्रेम स्केलिंग या सेल रेंज स्केलिंग?**  
यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं तो **OLE frame scaling** चुनें। यदि आप अपनी प्रस्तुति में OLE फ़्रेम का एक स्थिर आकार चाहते हैं तो **cell range scaling** चुनें।

**क्या ये समाधान तब भी काम करेंगे जब मेरी प्रस्तुति टेम्पलेट पर आधारित हो?**  
हां। दोनों समाधान टेम्पलेट से बनाई गई और शून्य से बनाई गई प्रस्तुतियों दोनों के लिए काम करते हैं।

**इन तरीकों का उपयोग करते समय OLE फ़्रेम के आकार पर कोई सीमा है क्या?**  
नहीं। आप OLE ऑब्जेक्ट फ़्रेम को कोई भी आकार दे सकते हैं, जब तक आप स्केल को उचित रूप से सेट करें।

**"EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट को PowerPoint में हटाने का कोई तरीका है क्या?**  
हां। लक्षित Excel सेल रेंज का स्नैपशॉट लेकर उसे OLE फ़्रेम के प्लेसहोल्डर इमेज के रूप में सेट करके आप डिफ़ॉल्ट प्लेसहोल्डर की जगह एक कस्टम प्रीव्यू इमेज दिखा सकते हैं।

## **संबंधित लेख**

[एक Excel चार्ट बनाकर उसे प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड करना](/slides/hi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)