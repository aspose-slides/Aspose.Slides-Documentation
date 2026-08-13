---
title: C++ का उपयोग करके प्रेज़ेंटेशन में OLE का प्रबंधन
linktitle: OLE प्रबंधन
type: docs
weight: 40
url: /hi/cpp/manage-ole/
keywords:
- OLE ऑब्जेक्ट
- ऑब्जेक्ट लिंकिंग और एम्बेडिंग
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
- प्रेज़ेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और एक्सपोर्ट करें।"
---
## **परिचय**

{{% alert title="Info" color="info" %}}
OLE (ऑब्जेक्ट लिंकिंग और एम्बेडिंग) माइक्रोसॉफ्ट तकनीक है जो एक एप्लिकेशन में निर्मित डेटा और ऑब्जेक्ट्स को लिंकिंग या एम्बेडिंग के माध्यम से दूसरे एप्लिकेशन में रखती है। 
{{% /alert %}} 

MS Excel में बनाया गया एक चार्ट मानिए। फिर वह चार्ट PowerPoint स्लाइड में रखा जाता है। वह Excel चार्ट OLE ऑब्जेक्ट माना जाता है। 

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन पर डबल‑क्लिक करते हैं, तो चार्ट अपनी सम्बंधित एप्लिकेशन (Excel) में खुल जाता है, या आपको ऑब्जेक्ट खोलने या संपादित करने के लिए एक एप्लिकेशन चयन करने के लिए कहा जाता है। 
- एक OLE ऑब्जेक्ट अपने वास्तविक सामग्री, जैसे कि चार्ट की सामग्री, प्रदर्शित कर सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट डेटा को संशोधित कर सकते हैं। 

[Aspose.Slides for C++](https://products.aspose.com/slides/hi/cpp/) आपको स्लाइड्स में OLE ऑब्जेक्ट्स डालने की अनुमति देता है OLE ऑब्जेक्ट फ़्रेम के रूप में ([OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/))।

## **स्लाइड्स में OLE ऑब्जेक्ट फ्रेम जोड़ें**

मान लीजिए आप पहले ही Microsoft Excel में एक चार्ट बना चुके हैं और Aspose.Slides for C++ का उपयोग करके इसे स्लाइड में OLE ऑब्जेक्ट फ्रेम के रूप में एम्बेड करना चाहते हैं, तो आप इसे इस तरह कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।  
4. स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) जोड़ें जिसमें बाइट एरे और OLE ऑब्जेक्ट के अन्य जानकारी शामिल हों।  
5. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

नीचे दिए गए उदाहरण में, हमने Excel फ़ाइल से एक चार्ट को Aspose.Slides for C++ का उपयोग करके एक स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) के रूप में जोड़ा। **नोट** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) कन्स्ट्रक्टर दूसरा पैरामीटर के रूप में एक एम्बेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से समझने और इस OLE ऑब्जेक्ट को खोलने के लिए सही एप्लिकेशन चुनने में मदद करता है।

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

Aspose.Slides for C++ आपको डेटा एम्बेड किए बिना केवल फ़ाइल के लिंक के साथ एक [OleObjectFrame] जोड़ने की अनुमति देता है।

यह C++ कोड आपको दिखाता है कि कैसे एक लिंक्ड Excel फ़ाइल के साथ [OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) स्लाइड में जोड़ें:

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

// लिंक्ड Excel फ़ाइल के साथ एक OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE ऑब्जेक्ट फ्रेम तक पहुँचें**

यदि एक OLE ऑब्जेक्ट पहले से स्लाइड में एम्बेडेड है, तो आप इसे इस प्रकार आसानी से खोज या एक्सेस कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाला प्रेज़ेंटेशन लोड करें।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. [OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) शेप तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक शेप था। फिर हमने उस ऑब्जेक्ट को एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ioleobjectframe/) में *cast* किया। यह वह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया जाना था।  
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा तक पहुँच की गई है।

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

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम प्रॉपर्टीज़ तक पहुँचें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम प्रॉपर्टीज़ तक पहुँचने की अनुमति देता है।

यह C++ कोड आपको दिखाता है कि कैसे जांचें कि OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पाथ प्राप्त करें:

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

    // जाँचें कि OLE ऑब्जेक्ट लिंक्ड है।
    if (oleFrame->get_IsObjectLink())
    {
        // लिंक्ड फ़ाइल का पूर्ण पथ प्रिंट करें।
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेटिव पथ प्रिंट करें।
        // केवल PPT प्रेज़ेंटेशन में रिलेटिव पाथ हो सकता है।
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="info" %}} 
इस अनुभाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for C++](/cells/cpp/) का उपयोग करता है। 
{{% /alert %}}

यदि एक OLE ऑब्जेक्ट पहले से स्लाइड में एम्बेडेड है, तो आप उस ऑब्जेक्ट तक पहुँचकर डेटा इस प्रकार संशोधित कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाला प्रेज़ेंटेशन लोड करें।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. [OLEObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) शेप तक पहुँ�ें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक शेप था। फिर हमने उस ऑब्जेक्ट को एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ioleobjectframe/) में *cast* किया। यह वह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया जाना था।  
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  
5. `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा तक पहुँचें।  
6. वांछित `Worksheet` तक पहुँचें और डेटा में संशोधन करें।  
7. अपडेटेड `Workbook` को एक स्ट्रीम में सहेजें।  
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा बदलें।  

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) तक पहुँच की गई है, और उसकी फ़ाइल डेटा को चार्ट डेटा अपडेट करने के लिए संशोधित किया गया है।

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

// Aspose.Cells for C++ को किसी भी प्रकार के उपयोग से पहले शुरू किया जाना चाहिए।
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

    // OLE फ्रेम ऑब्जेक्ट डेटा बदलें।
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **स्लाइड्स में अन्य फ़ाइल प्रकार एम्बेड करें**

Excel चार्ट के अलावा, Aspose.Slides for C++ आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में डाल सकते हैं। जब उपयोगकर्ता डालے गए ऑब्जेक्ट पर डबल‑क्लिक करता है, तो वह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उचित प्रोग्राम चुनने के लिए प्रेरित किया जाता है।

यह C++ कोड आपको दिखाता है कि कैसे HTML और ZIP को स्लाइड में एम्बेड करें:

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

प्रेज़ेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट्स को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना पड़ सकता है। Aspose.Slides for C++ आपको एम्बेडेड ऑब्जेक्ट के फ़ाइल प्रकार को सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसकी एक्सटेंशन को अपडेट कर सकते हैं।

यह C++ कोड आपको दिखाता है कि कैसे एक एम्बेडेड OLE ऑब्जेक्ट के फ़ाइल प्रकार को `zip` सेट करें:

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

// फ़ाइल प्रकार को ZIP में बदलें।
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज और शीर्षक सेट करें**

OLE ऑब्जेक्ट को एम्बेड करने के बाद, एक आइकन इमेज से बनी प्रीव्यू स्वतः जोड़ी जाती है। यह प्रीव्यू वही है जिसे उपयोगकर्ता OLE ऑब्जेक्ट तक पहुँचने या खोलने से पहले देखते हैं। यदि आप प्रीव्यू में विशिष्ट इमेज और टेक्स्ट का उपयोग करना चाहते हैं, तो आप Aspose.Slides for C++ का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह C++ कोड आपको दिखाता है कि कैसे एक एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट करें: 

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

// प्रेज़ेंटेशन संसाधनों में एक छवि जोड़ें।
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// OLE प्रीव्यू के लिए शीर्षक और छवि सेट करें।
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE ऑब्जेक्ट फ्रेम को आकार बदलने और पुन:स्थापित होने से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेज़ेंटेशन स्लाइड में जोड़ते हैं, और PowerPoint में प्रेज़ेंटेशन खोलते हैं, तो आपको लिंक अपडेट करने के लिए एक संदेश दिखाई दे सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को रिफ्रेश करता है। PowerPoint को ऑब्जेक्ट डेटा अपडेट करने के लिए प्रॉम्प्ट करने से रोकने के लिए, [IOleObjectFrame] इंटरफ़ेस की `set_UpdateAutomatic` मेथड को `false` सेट करें:

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

Aspose.Slides for C++ आपको स्लाइड्स में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट के रूप में इस प्रकार निकालने की अनुमति देता है:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की एक इंस्टेंस बनाएं जिसमें आप निकालने वाले OLE ऑब्जेक्ट्स हों।  
2. प्रेज़ेंटेशन में सभी शेप्स पर लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) शेप्स तक पहुँचें।  
3. OLE ऑब्जेक्ट फ्रेम्स से एम्बेडेड फ़ाइलों का डेटा एक्सेस करें और उसे डिस्क में लिखें।  

यह C++ कोड आपको दिखाता है कि कैसे एक स्लाइड में OLE ऑब्जेक्ट के रूप में एम्बेडेड फ़ाइलें निकालें:

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

## **FAQ**

### स्लाइड्स को PDF/इमेज में एक्सपोर्ट करते समय क्या OLE सामग्री रेंडर होगी?

स्लाइड पर जो दिखाई देता है वह रेंडर किया जाता है—आइकन/विकल्प इमेज (प्रीव्यू)। "लाइव" OLE सामग्री रेंडरिंग के दौरान निष्पादित नहीं होती। यदि आवश्यक हो, तो एक्सपोर्टेड PDF में अपेक्षित दिखावट सुनिश्चित करने के लिए अपना स्वयं का प्रीव्यू इमेज सेट करें।

### मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक करूं ताकि उपयोगकर्ता PowerPoint में उसे स्थानांतरित/संपादित न कर सकें?

शेप को लॉक करें: Aspose.Slides [shape-level locks](/slides/hi/cpp/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह आकस्मिक संपादन और स्थानांतरण को प्रभावी रूप से रोकता है।

### जब मैं प्रेज़ेंटेशन खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट क्यों "जंप" करता है या आकार बदलता है?

PowerPoint लिंक्ड OLE का प्रीव्यू रिफ्रेश कर सकता है। स्थिर दिखावट के लिए, [Working Solution for Worksheet Resizing](/slides/hi/cpp/working-solution-for-worksheet-resizing/) के अभ्यासों का पालन करें—या तो फ्रेम को रेंज के अनुसार फिट करें, या रेंज को एक स्थायी फ्रेम में स्केल करें और उपयुक्त विकल्प इमेज सेट करें।

### क्या लिंक्ड OLE ऑब्जेक्ट्स के रिलेटिव पाथ्स PPTX फ़ॉर्मेट में संरक्षित रहेंगे?

PPTX में, "relative path" जानकारी उपलब्ध नहीं है—केवल पूर्ण पाथ होती है। रिलेटिव पाथ्स पुराने PPT फ़ॉर्मेट में पाए जाते हैं। पोर्टेबिलिटी के लिए, विश्वसनीय एब्सोल्यूट पाथ/एक्सेसिबल URI या एम्बेडिंग को प्राथमिकता दें।