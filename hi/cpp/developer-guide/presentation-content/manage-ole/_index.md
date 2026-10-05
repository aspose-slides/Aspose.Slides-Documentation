---
title: C++ का उपयोग करके प्रेजेंटेशन में OLE प्रबंधन
linktitle: OLE प्रबंधन
type: docs
weight: 40
url: /hi/cpp/manage-ole/
keywords:
- OLE ऑब्जेक्ट
- ऑब्जेक्ट लिंकिंग एवं एम्बेडिंग
- OLE जोड़ें
- OLE एम्बेड करें
- ऑब्जेक्ट जोड़ें
- ऑब्जेक्ट एम्बेड करें
- फ़ाइल जोड़ें
- फ़ाइल एम्बेड करें
- लिंक्ड ऑब्जेक्ट
- लिंक्ड फ़ाइल
- OLE बदलें
- OLE आइकन
- OLE शीर्षक
- OLE निकालें
- ऑब्जेक्ट निकालें
- फ़ाइल निकालें
- PowerPoint 
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert color="info" title="Note" %}}

OLE (ऑब्जेक्ट लिंकिंग और एम्बेडिंग) माइक्रोसॉफ्ट तकनीक है जो एक एप्लिकेशन में निर्मित डेटा और ऑब्जेक्ट को दूसरे एप्लिकेशन में लिंकिंग या एम्बेडिंग के माध्यम से रखने की अनुमति देती है। 

{{% /alert %}} 

MS Excel में बनाया गया चार्ट मानिए। फिर उस चार्ट को PowerPoint स्लाइड में रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है। 

- OLE ऑब्जेक्ट एक आइकन के रूप में दिख सकता है। इस स्थिति में, जब आप आइकन पर दो बार क्लिक करेंगे, तो चार्ट अपने सम्बंधित एप्लिकेशन (Excel) में खुलता है, या आपसे ऑब्जेक्ट को खोलने या संपादित करने के लिए एप्लिकेशन चुनने को कहा जाता है। 
- OLE ऑब्जेक्ट उसकी वास्तविक सामग्री दिखा भी सकता है, जैसे कि चार्ट की सामग्री। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट के डेटा को संशोधित कर सकते हैं।

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) आपको स्लाइड्स में OLE ऑब्जेक्ट को OLE ऑब्जेक्ट फ्रेम के रूप में सम्मिलित करने की अनुमति देता है ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/))।

## **स्लाइड्स में OLE ऑब्जेक्ट फ्रेम जोड़ें**

मान लीजिए आपने Microsoft Excel में पहले से एक चार्ट बना लिया है और इसे Aspose.Slides for C++ का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो आप इसे इस प्रकार कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इस्लाइड के इंडेक्स के माध्यम से उसकी रेफ़रेंस प्राप्त करें।
3. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।
4. बाइट एरे और OLE ऑब्जेक्ट के अन्य जानकारी के साथ स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) जोड़ें।
5. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे के उदाहरण में, हमने Excel फ़ाइल से एक चार्ट को Aspose.Slides for C++ का उपयोग करके एक स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) के रूप में जोड़ा। **ध्यान दें** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) कंस्ट्रक्टर दूसरे पैरामीटर के रूप में एम्बेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से व्याख्या करने और इस OLE ऑब्जेक्ट को खोलने के लिए उपयुक्त एप्लिकेशन चुनने में सक्षम बनाता है।

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम जोड़ें**

Aspose.Slides for C++ आपको डेटा एम्बेड किए बिना, केवल फ़ाइल के लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) जोड़ने की अनुमति देता है।

यह C++ कोड आपको दिखाता है कि लिंक्ड Excel फ़ाइल के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) को स्लाइड में कैसे जोड़ें:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// एक लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE ऑब्जेक्ट फ्रेम तक पहुंचें**

यदि एक OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इसे इस प्रकार आसानी से खोज या पहुंच सकते हैं:

1. एम्बेडेड OLE ऑब्जेक्ट वाले प्रेजेंटेशन को लोड करें, इसके लिए [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. स्लाइड के इंडेक्स का उपयोग करके उसकी रेफ़रेंस प्राप्त करें।
3. [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) आकार तक पहुंचें। हमारे उदाहरण में, हमने पहले निर्मित PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक आकार है। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) के रूप में *cast* किया। यह वही वांछित OLE ऑब्जेक्ट फ्रेम था जिसे पहुंचना था।
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुंच जाने के बाद, आप उस पर कोई भी ऑपरेशन कर सकते हैं।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा तक पहुंचा गया है।

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // एम्बेडेड फ़ाइल डेटा प्राप्त करें।
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // एम्बेडेड फ़ाइल का एक्सटेंशन प्राप्त करें।
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम गुणों तक पहुंचें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम के गुणों तक पहुंचने की अनुमति देता है।

यह C++ कोड आपको दिखाता है कि कैसे जांचें कि OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पथ प्राप्त करें:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // जांचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
    if (oleFrame->get_IsObjectLink())
    {
        // लिंक्ड फ़ाइल का पूर्ण पथ प्रिंट करें।
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेатив पथ प्रिंट करें।
        // केवल PPT प्रेजेंटेशन में रिलेатив पथ हो सकता है।
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="info" title="Note" %}}

इस अनुभाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for C++](https://docs.aspose.com/cells/cpp/) का उपयोग करता है।

{{% /alert %}}

यदि एक OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इस तरह से उस ऑब्जेक्ट तक आसानी से पहुँच सकते हैं और उसके डेटा को संशोधित कर सकते हैं:

1. एम्बेडेड OLE ऑब्जेक्ट वाले प्रेजेंटेशन को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. स्लाइड के इंडेक्स के माध्यम से उसकी रेफ़रेंस प्राप्त करें। 
3. [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) आकार तक पहुंचें। हमारे उदाहरण में, हमने पहले निर्मित PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक आकार है। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) के रूप में *cast* किया। यह वही वांछित OLE ऑब्जेक्ट फ्रेम था जिसे पहुंचना था।
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुंच जाने के बाद, आप उस पर कोई भी ऑपरेशन कर सकते हैं।
5. एक `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा तक पहुंचें।
6. इच्छित `Worksheet` तक पहुंचें और डेटा को संशोधित करें।
7. अपडेटेड `Workbook` को एक स्ट्रीम में सहेजें।
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा को बदलें।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) तक पहुंचा गया है, और उसके फ़ाइल डेटा को चार्ट डेटा को अपडेट करने के लिए संशोधित किया गया है।

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells for C++ को उसके किसी भी प्रकार का उपयोग करने से पहले शुरू किया जाना चाहिए।
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // OLE ऑब्जेक्ट डेटा को Workbook ऑब्जेक्ट के रूप में पढ़ें।
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Workbook डेटा को संशोधित करें।
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // OLE फ्रेम ऑब्जेक्ट डेटा को बदलें।
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **स्लाइड्स में अन्य फ़ाइल प्रकार एम्बेड करें**

Excel चार्ट के अलावा, Aspose.Slides for C++ आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के तौर पर, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर दो बार क्लिक करता है, तो वह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने का प्रॉम्प्ट दिखाया जाता है।

यह C++ कोड आपको दिखाता है कि कैसे HTML और ZIP को एक स्लाइड में एम्बेड करें:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए फ़ाइल प्रकार सेट करें**

प्रेजेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट को नए से बदलना या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना पड़ सकता है। Aspose.Slides for C++ आपको एम्बेडेड ऑब्जेक्ट के फ़ाइल प्रकार को सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसके एक्सटेंशन को अपडेट कर सकते हैं।

यह C++ कोड आपको दिखाता है कि एम्बेडेड OLE ऑब्जेक्ट के फ़ाइल प्रकार को `zip` कैसे सेट करें:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Change the file type to ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज और शीर्षक सेट करें**

OLE ऑब्जेक्ट को एम्बेड करने کے बाद, एक आइकन इमेज वाला प्रीव्यू स्वचालित रूप से जोड़ा जाता है। यह प्रीव्यू वह है जो उपयोगकर्ता OLE ऑब्जेक्ट तक पहुंचने या उसे खोलने से पहले देखते हैं। यदि आप प्रीव्यू में एक विशिष्ट इमेज और टेक्स्ट को तत्वों के रूप में उपयोग करना चाहते हैं, तो आप Aspose.Slides for C++ का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह C++ कोड आपको दिखाता है कि एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक कैसे सेट करें: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// प्रेजेंटेशन संसाधनों में एक इमेज जोड़ें।
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// OLE प्रिव्यू के लिए शीर्षक और इमेज सेट करें।
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE ऑब्जेक्ट फ्रेम को आकार बदलने और स्थान बदलने से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेजेंटेशन स्लाइड में जोड़ते हैं, तो PowerPoint में प्रेजेंटेशन खोलने पर आपको लिंक अपडेट करने का संदेश दिखाई दे सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को रिफ्रेश करता है। PowerPoint को ऑब्जेक्ट डेटा अपडेट करने के लिए प्रॉम्प्ट करने से रोकने के लिए, [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) इंटरफ़ेस की [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) मेथड को `false` के साथ कॉल करें:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for C++ आपको स्लाइड्स में OLE ऑब्जेक्ट के रूप में एम्बेडेड फ़ाइलों को इस तरह निकालने की अनुमति देता है:

1. उस [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं जिसमें आप निकालने वाले OLE ऑब्जेक्ट्स हों।
2. प्रेजेंटेशन में सभी आकारों पर लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) आकारों तक पहुंचें।
3. OLE ऑब्जेक्ट फ्रेम से एम्बेडेड फ़ाइलों के डेटा तक पहुंचें और उन्हें डिस्क पर लिखें।

यह C++ कोड आपको दिखाता है कि कैसे स्लाइड में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट के रूप में निकालें:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्लाइड्स को PDF/छवियों में निर्यात करने पर OLE सामग्री रेंडर होगी?**

स्लाइड पर जो दिखाई देता है वह रेंडर किया जाता है—आइकन/वैकल्पिक इमेज (प्रिव्यू)। "लाइव" OLE सामग्री रेंडरिंग के दौरान निष्पादित नहीं होती। यदि आवश्यक हो, तो निर्यातित PDF में अपेक्षित रूप दिखाने के लिए अपना स्वयं का प्रीव्यू इमेज सेट करें।  
एम्बेडेड फ़ाइल को PDF अटैचमेंट के रूप में भी संरक्षित करने के लिए, [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) को `true` के साथ कॉल करें। यह विकल्प डिफ़ॉल्ट रूप से निष्क्रिय है। उदाहरण और अटैचमेंट चेक करने के निर्देशों के लिए, देखें [Preserve Embedded OLE Files as PDF Attachments](/slides/hi/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)।

**मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक करूं ताकि उपयोगकर्ता इसे PowerPoint में स्थानांतरित/संपादित न कर सकें?**

शेप को लॉक करें: Aspose.Slides [shape-level locks](/slides/hi/cpp/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह अनावश्यक संपादन और स्थानांतरण को प्रभावी रूप से रोकता है।

**जब मैं प्रेजेंटेशन खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट "जम्प" क्यों करता है या आकार बदलता है?**

PowerPoint लिंक्ड OLE का प्रीव्यू रीफ़्रेश कर सकता है। स्थिर रूप के लिए, [Working Solution for Worksheet Resizing](/slides/hi/cpp/working-solution-for-worksheet-resizing/) की सिफ़ारिशों का पालन करें—या तो फ्रेम को रेंज के अनुसार फिट करें, या रेंज को स्थिर फ्रेम में स्केल करें और उपयुक्त वैकल्पिक इमेज सेट करें।

**क्या PPTX फॉर्मेट में लिंक्ड OLE ऑब्जेक्ट्स के लिए रिलेटिव पाथ संरक्षित रहेंगे?**

PPTX में, "relative path" जानकारी उपलब्ध नहीं है—केवल पूरा पाथ रहता है। रिलेटिव पाथ पुराने PPT फॉर्मेट में पाए जाते हैं। पोर्टेबिलिटी के लिए विश्वसनीय एब्सोल्यूट पाथ/एक्सेसेबल URI या एम्बेडिंग को प्राथमिकता दें।