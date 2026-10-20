---
title: Excel चार्ट बनाएं और उन्हें प्रस्तुतियों में OLE ऑब्जेक्ट्स के रूप में एम्बेड करें
type: docs
weight: 40
url: /hi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel चार्ट
- चार्ट एम्बेड करें
- OLE ऑब्जेक्ट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Cells for C++ का उपयोग करके एक Excel चार्ट बनाएं और Aspose.Slides के साथ एक PowerPoint प्रस्तुति में वर्कबुक को एम्बेड करें, जिसमें चार्ट प्रीव्यू शामिल है।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Cells for C++ के साथ Excel स्तंभ चार्ट कैसे बनाते हैं और इसे Aspose.Slides for C++ के साथ PowerPoint प्रस्तुति में एम्बेड कैसे करते हैं। एम्बेड किया गया वर्कबुक स्रोत डेटा और चार्ट दोनों को शामिल करता है। एक अलग PNG प्रीव्यू स्लाइड पर चार्ट को प्रदर्शित करता है, इससे पहले कि OLE ऑब्जेक्ट सक्रिय हो।

परिणाम एक एम्बेड किया गया Excel ऑब्जेक्ट है, न कि मूल PowerPoint चार्ट। OLE के माध्यम से वर्कबुक को संपादित करने के लिए ऐसे डेस्कटॉप एप्लिकेशन की आवश्यकता होती है जो OLE सक्रियण का समर्थन करता हो और संगत Excel स्थापना हो।

## **आवश्यकताएँ**

Aspose.Cells for C++ और Aspose.Slides for C++ के हेडर और लाइब्रेरी के साथ अपने C++ प्रोजेक्ट को कॉन्फ़िगर करें। उदाहरण कोड को अपने एप्लिकेशन के एंट्री पॉइंट में रखें, तथा include डिक्लेरेशन को फ़ाइल स्कोप पर रखें। Microsoft Office इन लाइब्रेरीज़ के साथ प्रस्तुति जनरेट करने के लिए आवश्यक नहीं है।

कोई इनपुट फ़ाइल आवश्यक नहीं है: उदाहरण मेमोरी में डेटा और चार्ट बनाता है, फिर `OutputChart.pptx` को वर्तमान कार्य निर्देशिका में लिखता है। मूल्यांकन मोड के बाहर चलाते समय दोनों उत्पादों के लिए लाइसेंस लागू करें।

## **एम्बेडिंग कैसे कार्य करती है**

1. डेटा वर्कशीट और चार्ट शीट के साथ एक वर्कबुक बनाएं।  
1. चार्ट शीट को सक्रिय करें ताकि वर्कबुक चार्ट पर खुले।  
1. वर्कबुक की OLE डिस्प्ले रेंज सेट करें और चार्ट को PNG में रेंडर करें।  
1. वर्कबुक को मेमोरी में XLSX के रूप में सहेजें और उन बाइट्स को स्लाइड में एम्बेड करें।  
1. PNG को OLE ऑब्जेक्ट के प्रीव्यू के रूप में असाइन करें और प्रस्तुति को PPTX के रूप में सहेजें।

वर्कबुक डिस्प्ले रेंज और स्लाइड पर फ्रेम की अलग भूमिकाएँ होती हैं। [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) शून्य-आधारित प्रारंभ/समाप्ति पंक्ति और स्तंभ संकेतांक लेता है। [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) इसके बजाय शीर्ष पंक्ति, बायीं स्तंभ, निचली पंक्ति और दायीं स्तंभ लेता है। उदाहरण पंक्ति संकेतांक 55 और स्तंभ संकेतांक 25 को निचले-दाएं सीमा के रूप में उपयोग करता है; ये मान लेआउट विकल्प हैं, न कि डेटा पंक्तियों या स्तंभों की संख्या।

स्लाइड फ्रेम पॉइंट्स में मापी जाती है। उदाहरण इसे स्लाइड के भीतर फिट करता है और केंद्रित करता है जबकि PNG के अनुपात को संरक्षित रखता है, बजाए प्रीव्यू को स्लाइड भरने के लिए खींचे।

## **चार्ट बनाना और एम्बेड करना**

निम्नलिखित पूर्ण उदाहरण `DataSheet` को चार पंक्तियों और पाँच स्तंभों के मानों से भरता है। प्रत्येक पंक्ति एक चार्ट सीरीज़ बनती है। `ChartSheet` को वर्कबुक सहेजने से पहले सक्रिय शीट के रूप में चुना जाता है।

वर्कबुक को स्पष्ट रूप से XLSX के रूप में सहेजा जाता है, जो `xlsx` एक्स्टेंशन के साथ मेल खाता है जो [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) को पास किया जाता है। PNG को इन-मेमोरी स्ट्रीम से लोड किया जाता है बिना किसी मध्यस्थ बिटमैप रूपांतरण के। Aspose.Cells बाइट वेक्टर रिटर्न करता है, जिसे उदाहरण Aspose.Slides द्वारा स्वीकार किए गए ऐरे प्रकार में कॉपी करता है। Aspose.Cells को उसके ऑब्जेक्ट्स का उपयोग करने से पहले इनिशियलाइज़ करें, और उन ऑब्जेक्ट्स के नष्ट हो जाने के बाद उसके संसाधनों को रिलीज़ करें। इसे [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) के माध्यम से असाइन करने से डिफ़ॉल्ट OLE प्लेसहोल्डर प्रतिस्थापित हो जाता है।

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Initialize Cells before creating any of its objects.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // चार्ट प्रीव्यू को रेंडर करें और संपादन योग्य वर्कबुक को अलग से सीरियलाइज़ करें।
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Slides द्वारा उपयोग किए जाने वाले ऐरे प्रकार में Cells बफ़र कॉपी करें।
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // प्रीव्यू को स्लाइड के भीतर फिट करें बिना उसके अनुपात को बदले।
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// सभी Cells ऑब्जेक्ट नष्ट होने के बाद Cells संसाधनों को रिलीज़ करें।
Aspose::Cells::Cleanup();
```

## **अपेक्षित परिणाम**

`OutputChart.pptx` में एक स्लाइड होती है जिसमें एम्बेड किया गया Excel वर्कबुक और चार्ट का प्रीव्यू होता है। वर्कबुक में मूल डेटा और चार सीरीज़ वाला स्तंभ चार्ट होता है। प्रीव्यू स्लाइड पर केंद्रित होता है और अपने अनुपात को बरकरार रखता है।

![Excel स्तंभ_chart जो एम्बेडेड वर्कबुक के प्रीव्यू के रूप में प्रदर्शित है](excel-chart-ole-preview.png)

संगत डेस्कटॉप PowerPoint वातावरण में जहाँ Excel उपलब्ध हो, ऑब्जेक्ट पर डबल-क्लिक करके एम्बेडेड वर्कबुक को सक्रिय और संपादित किया जा सकता है। सक्रियण और संपादन होस्ट एप्लिकेशन के OLE समर्थन और सुरक्षा सेटिंग्स पर निर्भर करते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रीव्यू इमेज क्यों आवश्यक है?**

एम्बेडेड वर्कबुक और उसकी स्लाइड प्रीव्यू अलग-अलग सामग्री हैं। एक चार्ट इमेज प्रदान करें ताकि स्लाइड डिफ़ॉल्ट "EMBEDDED OLE OBJECT" प्लेसहोल्डर के बजाय चार्ट दिखाए। देखें [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/cpp/object-preview-issue-when-adding-oleobjectframe/)।

**क्या कोड में वर्कबुक बदलने पर प्रीव्यू स्वतः अपडेट होता है?**

प्रीव्यू को एक स्नैपशॉट मानें। जब प्रोग्रामेटिक रूप से वर्कबुक डेटा को अपडेट किया जाता है, तो चार्ट इमेज को पुनः उत्पन्न करें और प्रीव्यू तथा एम्बेडेड वर्कबुक डेटा दोनों को बदलें।

**क्या मैं XLS को XLSX के बजाय उपयोग कर सकता हूँ?**

हां। वर्कबुक को XLS फॉर्मेट में सहेजें और एम्बेडेड डेटा एक्स्टेंशन के रूप में `xls` का उपयोग करें। एक्स्टेंशन वास्तविक वर्कबुक फॉर्मेट से मेल खाना चाहिए; केवल एक्स्टेंशन बदलने से डेटा परिवर्तित नहीं होता।

**सक्रियण के बाद ऑब्जेक्ट का आकार क्यों बदल सकता है?**

होस्ट एप्लिकेशन वर्कबुक को सक्रिय करने पर OLE ऑब्जेक्ट की प्रस्तुति को अपडेट कर सकता है। वर्कबुक की OLE डिस्प्ले रेंज और स्लाइड फ्रेम की आयाम दोनों महत्वपूर्ण हैं। देखें [PPTX में चार्ट रीसाइज़िंग के लिए कार्यशील समाधान](/slides/hi/cpp/working-solution-for-chart-resizing-in-pptx/)।

## **संबंधित अनुभाग**

- [PPTX में चार्ट रीसाइज़िंग के लिए कार्यशील समाधान](/slides/hi/cpp/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/cpp/object-preview-issue-when-adding-oleobjectframe/)