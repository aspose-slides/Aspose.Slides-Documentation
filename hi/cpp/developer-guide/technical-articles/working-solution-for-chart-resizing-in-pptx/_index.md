---
title: PPTX में चार्ट आकार बदलने के लिए कार्यशील समाधान
type: docs
weight: 60
url: /hi/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- चार्ट आकार बदलना
- Excel चार्ट
- OLE ऑब्जेक्ट
- चार्ट एम्बेड
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ एम्बेडेड Excel OLE ऑब्जेक्ट्स का उपयोग करने पर PPTX में अप्रत्याशित चार्ट आकार बदलने को ठीक करें। चार्ट और OLE फ्रेम के आकार को स्थिर रखने के लिए निश्चित चार्ट आयाम सेट करें।"
---
## **पृष्ठभूमि**

Excel चार्ट को Aspose घटकों का उपयोग करके PowerPoint प्रस्तुतियों में OLE ऑब्जेक्ट के रूप में एम्बेड करने पर पहली सक्रियता के बाद उनका आकार बदल सकता है। इससे चार्ट के सक्रिय होने से पहले और बाद में दिखावट में स्पष्ट अंतर आ सकता है। यह लेख बताता है कि आकार बदलने का कारण क्या है और OLE फ्रेम के साथ निश्चित चार्ट आयाम मिलाकर इसे कैसे रोका जाए।

[Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) में हमने बताया था कि Aspose.Cells for C++ का उपयोग करके Excel चार्ट कैसे बनाएं और Aspose.Slides for C++ का उपयोग करके इसे PowerPoint प्रस्तुति में कैसे एम्बेड करें। [object preview issue](/slides/hi/cpp/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए हमने चार्ट छवि को चार्ट के OLE ऑब्जेक्ट फ्रेम में असाइन किया। आउटपुट प्रस्तुति में, जब आप चार्ट छवि दिखाने वाले OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करते हैं, तो Excel चार्ट सक्रिय हो जाता है। उपयोगकर्ता एम्बेडेड Excel वर्कबुक को संपादित कर सकते हैं और फिर सक्रिय वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर वापस आने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाता है, और यह परिवर्तन OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के मूल आकारों पर निर्भर करता है।

## **आकार बदलने का कारण**

एम्बेडेड Excel वर्कबुक का अपना विंडो आयाम होता है, जिसे Excel पहली बार सक्रिय होने पर बरकरार रखने की कोशिश करता है। स्लाइड पर OLE फ्रेम का आयाम स्वतंत्र रूप से परिभाषित होता है। जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint ऑब्जेक्ट के आकार को उसके अनुपात को बनाए रखने के लिए चर्चा करते हैं। वर्कबुक विंडो और OLE फ्रेम के बीच अंतर के कारण ऑब्जेक्ट का आकार बदल सकता है।

## **काम करने वाला समाधान**

चार्ट का आकार स्लाइड पर OLE फ्रेम से मिलाएँ और चार्ट आयाम को वर्कबुक विंडो से स्वतंत्र रखें। यह समाधान नई प्रस्तुति या मौजूदा टेम्प्लेट दोनों के साथ काम करता है।

यह उदाहरण Aspose.Cells for C++ और Aspose.Slides for C++ की आवश्यकता रखता है। यह सक्रिय चार्ट शीट पर एक साधारण कॉलम चार्ट बनाता है और वर्कबुक को XLS स्वरूप में एम्बेड करता है। कोई चार्ट प्रीव्यू छवि असाइन नहीं की गई; चार्ट PowerPoint में OLE ऑब्जेक्ट सक्रिय होने पर दिखाई देता है।

उदाहरण कोड को अपने एप्लिकेशन एंट्री पॉइंट में रखें, जिसमें फ़ाइल स्तर पर include घोषणा शामिल हों। Aspose.Cells को उसके ऑब्जेक्ट बनाने से पहले इनिशियलाइज़ करें और उन ऑब्जेक्ट्स को नष्ट करने के बाद उसके संसाधनों को मुक्त करें। यह उदाहरण Aspose.Cells द्वारा लौटाए गए वर्कबुक बाइट वेक्टर को Aspose.Slides द्वारा स्वीकार किए गए एरे टाइप में कॉपी करता है।

यह उदाहरण 9.5 × 4‑इंच OLE फ्रेम के साथ नई प्रस्तुति बनाता है, जो बाएँ किनारे से 0.5 इंच और शीर्ष से 1 इंच पर स्थित है। स्लाइड निर्देशांक और आयाम पॉइंट्स में होते हैं (प्रति इंच 72 पॉइंट)। मौजूदा प्रस्तुति के लिए, देखें [Use a Template](#use-a-template)।

## **निश्चित चार्ट आकार सेट करना**

[Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) को false सेट करें ताकि चार्ट आयाम वर्कबुक विंडो से स्वतंत्र रहें। [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) के आयाम को [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) और [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/) के माध्यम से सेट करें, पॉइंट्स को पिक्सेल में बदलते समय 96 पिक्सेल प्रति इंच का प्रयोग करें: 684 × 288 पॉइंट्स का फ्रेम 912 × 384 पिक्सेल के चार्ट के बराबर है। [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) को [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/) के Custom मान पर सेट करें। उदाहरण वर्कबुक को [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) से एम्बेड करता है और 9.5 × 4‑इंच OLE फ्रेम वाली प्रस्तुति सहेजता है।

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // स्लाइड के निर्देशांक और आयाम पॉइंट्स में हैं (प्रति इंच 72 पॉइंट्स)।
    auto width = 684.f; // 9.5 इंच।
    auto height = 288.f; // 4 इंच।

    chart.SetSizeWithWindow(false);
    // पॉइंट्स को चार्ट पिक्सेल में बदलें, 96 पिक्सेल प्रति इंच का उपयोग करके।
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Cells बाइट वेक्टर को Slides द्वारा स्वीकार किए गए एरे प्रकार में कॉपी करें।
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **टेम्प्लेट का उपयोग करें**

मौजूदा प्रस्तुति के लिए आकार निर्धारण तर्क समान है। उदाहरण को अनुकूलित करने के लिए:

1. खाली प्रस्तुति बनाकर नहीं, बल्कि टेम्प्लेट प्रस्तुति लोड करें।
2. सुनिश्चित करें कि पहली स्लाइड में कम से कम तीन शैप्स हों, फिर इंडेक्स 2 पर स्थित शैप को प्लेसहोल्डर के रूप में उपयोग करें।
3. निश्चित मान 684 और 288 के बजाय उस शैप से फ्रेम की चौड़ाई और ऊँचाई प्राप्त करें। आकार गणना को अपरिवर्तित रखें।
4. प्लेसहोल्डर की स्थिति पर OLE फ्रेम जोड़ें, न कि निश्चित निर्देशांक 36 और 72 पर।
5. प्रस्तुति सहेजने से पहले प्लेसहोल्डर को हटा दें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मेरे एम्बेडेड Excel चार्ट का आकार PowerPoint में सक्रिय करने के बाद क्यों बदल जाता है?**

यह इसलिए होता है क्योंकि Excel पहली बार सक्रिय होने पर मूल विंडो आकार पुनर्स्थापित करने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आयाम होता है। PowerPoint और Excel अनुपात बनाए रखने के लिए आकार पर बातचीत करते हैं, जिससे आकार परिवर्तन हो सकता है।

**मैं चार्ट और OLE फ्रेम के आकार को कैसे स्थिर रख सकता हूँ?**

निश्चित चार्ट आयाम सेट करें जो OLE फ्रेम से मेल खाते हों और वर्कबुक एम्बेड करने से पहले कस्टम चार्ट प्रिंट आकार का प्रयोग करें। ऊपर दिया गया उदाहरण आवश्यक सेटिंग्स और इकाई रूपांतरण दिखाता है।

**क्या केवल वर्कबुक विंडो आकार मिलाना पर्याप्त है?**

केवल वर्कबुक विंडो आकार मिलाना OLE फ्रेम के सक्रिय होने के बाद आकार बदलने को विश्वसनीय रूप से रोकता नहीं है। उदाहरण में दिखाए गए अनुसार निश्चित चार्ट आयाम उपयोग करें।

**क्या यह समाधान टेम्प्लेट‑आधारित और नई दोनों प्रस्तुतियों के साथ काम करता है?**

हाँ। टेम्प्लेट के लिए प्लेसहोल्डर के आयाम और स्थिति उपयोग करें। नई प्रस्तुति के लिए फ्रेम के आयाम और स्थिति सीधे निर्दिष्ट करें।

**क्या मैं इस उदाहरण को अन्य स्प्रेडशीट प्रोग्रामों में बने चार्ट के साथ उपयोग कर सकता हूँ?**

उदाहरण Excel वर्कबुक (Aspose.Cells से निर्मित) को उपयोग करता है। यह अन्य स्प्रेडशीट प्रोग्रामों के सक्रियण व्यवहार को दर्शाता नहीं है।

## **संबंधित अनुभाग**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)