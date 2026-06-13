---
title: C++ का उपयोग करके प्रस्तुतियों में OLE प्रबंधन करें
linktitle: OLE प्रबंधन करें
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
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) एक Microsoft तकनीक है जो डेटा और ऑब्जेक्ट्स को जो एक एप्लिकेशन में बनाए गए होते हैं, को लिंकिंग या एम्बेडिंग के माध्यम से दूसरे एप्लिकेशन में रखने की अनुमति देती है। 

{{% /alert %}} 

MS Excel में बनाए गए चार्ट पर विचार करें। फिर यह चार्ट PowerPoint स्लाइड के अंदर रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है। 

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन पर दो बार क्लिक करते हैं, तो चार्ट अपने संबंधित एप्लिकेशन (Excel) में खुल जाता है, या आपको ऑब्जेक्ट खोलने या संपादित करने के लिए एक एप्लिकेशन चुनने को कहा जाता है। 
- एक OLE ऑब्जेक्ट अपना वास्तविक कंटेंट प्रदर्शित कर सकता है, जैसे कि चार्ट की सामग्री। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट का डेटा संशोधित कर सकते हैं।

[Aspose.Slides for C++](https://products.aspose.com/slides/hi/cpp/) आपको OLE ऑब्जेक्ट्स को स्लाइड्स में OLE ऑब्जेक्ट फ्रेम के रूप में सम्मिलित करने की अनुमति देता है ([OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/))।

## **स्लाइड्स में OLE ऑब्जेक्ट फ्रेम जोड़ें**

मान लेते हैं कि आपने Microsoft Excel में पहले ही एक चार्ट बनाया है और आप इसे Aspose.Slides for C++ का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो आप यह इस तरह कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।
4. OLE ऑब्जेक्ट के बारे में बाइट एरे और अन्य जानकारी के साथ स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) जोड़ें।
5. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे के उदाहरण में, हमने Aspose.Slides for C++ का उपयोग करके एक Excel फ़ाइल से चार्ट को स्लाइड में एक [OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) के रूप में जोड़ा है।  
**नोट** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) कंस्ट्रक्टर एक एम्बेडेबल ऑब्जेक्ट एक्सटेंशन को दूसरे पैरामीटर के रूप में लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से समझने और इस OLE ऑब्जेक्ट को खोलने के लिए सही एप्लिकेशन चुनने की अनुमति देता है।

``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// OLE ऑब्जेक्ट के लिए डेटा तैयार करें।
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम जोड़ें**

Aspose.Slides for C++ आपको डेटा एम्बेड किए बिना केवल फ़ाइल के लिंक्स के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) जोड़ने की अनुमति देता है।

यह C++ कोड आपको दिखाता है कि कैसे एक लिंक्ड Excel फ़ाइल के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) को स्लाइड में जोड़ें:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ्रेम जोड़ें।
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE ऑब्जेक्ट फ्रेम्स तक पहुंचें**

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इसे इस तरह आसानी से खोज या एक्सेस कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट के साथ प्रेज़ेंटेशन लोड करें।
2. उसके इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
3. [OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) आकार तक पहुंचें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक आकार है। फिर हमने उस ऑब्जेक्ट को एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ioleobjectframe/) के रूप में *cast* किया। यह वही वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया जाना था।
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (एक स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और इसकी फ़ाइल डेटा को एक्सेस किया गया है।

``` cpp
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

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम प्रॉपर्टीज़ तक पहुंचें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम प्रॉपर्टीज़ तक पहुंचने की अनुमति देता है।

यह C++ कोड आपको दिखाता है कि कैसे जांचें कि कोई OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पथ प्राप्त करें:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // जांचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
    if (oleFrame->get_IsObjectLink())
    {
        // लिंक्ड फ़ाइल का पूरा पथ प्रिंट करें।
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

{{% alert color="primary" %}} 

इस सेक्शन में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for C++](/cells/cpp/) का उपयोग करता है। 

{{% /alert %}}

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप उस ऑब्जेक्ट को आसानी से एक्सेस करके उसका डेटा इस तरह संशोधित कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट के साथ प्रेज़ेंटेशन लोड करें।
2. उसके इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. [OLEObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) आकार तक पहुंचें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक आकार है। फिर हमने उस ऑब्जेक्ट को एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ioleobjectframe/) के रूप में *cast* किया। यह वही वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया जाना था।
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।
5. एक `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा तक पहुंचें।
6. वांछित `Worksheet` तक पहुंचें और डेटा में संशोधन करें।
7. अपडेटेड `Workbook` को एक स्ट्रीम में सहेजें।
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा को बदलें।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (एक स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) को एक्सेस किया गया है, और उसकी फ़ाइल डेटा को संशोधित करके चार्ट डेटा को अपडेट किया गया है।

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// पहले आकार को OLE ऑब्जेक्ट फ्रेम के रूप में प्राप्त करें।
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // OLE ऑब्जेक्ट डेटा को Workbook ऑब्जेक्ट के रूप में पढ़ें।
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // वर्कबुक डेटा को संशोधित करें।
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
```

## **स्लाइड्स में अन्य फ़ाइल प्रकार एम्बेड करें**

Excel चार्ट के अलावा, Aspose.Slides for C++ आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के तौर पर, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर दो बार क्लिक करता है, तो यह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने के लिए कहा जाता है।

यह C++ कोड आपको दिखाता है कि कैसे HTML और ZIP को स्लाइड में एम्बेड करें:

``` cpp
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

## **एम्बेडेड ऑब्जेक्ट्स के लिए फ़ाइल प्रकार निर्धारित करें**

प्रेज़ेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट्स को नए से बदलने या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलने की आवश्यकता हो सकती है। Aspose.Slides for C++ आपको एम्बेडेड ऑब्जेक्ट के लिए फ़ाइल प्रकार सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसकी एक्सटेंशन को अपडेट कर सकते हैं।

यह C++ कोड आपको दिखाता है कि कैसे एम्बेडेड OLE ऑब्जेक्ट का फ़ाइल प्रकार `zip` सेट करें:

``` cpp
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

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज़ और शीर्षक सेट करें**

एक OLE ऑब्जेक्ट एम्बेड करने के बाद, एक प्रीव्यू जिसमें आइकन इमेज़ होता है, स्वचालित रूप से जुड़ जाता है। यह प्रीव्यू वही है जो उपयोगकर्ता OLE ऑब्जेक्ट को एक्सेस या खोलने से पहले देखते हैं। यदि आप प्रीव्यू में विशिष्ट इमेज़ और टेक्स्ट को तत्वों के रूप में उपयोग करना चाहते हैं, तो आप Aspose.Slides for C++ का उपयोग करके आइकन इमेज़ और शीर्षक सेट कर सकते हैं।

यह C++ कोड आपको दिखाता है कि कैसे एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज़ और शीर्षक सेट करें: 

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// प्रस्तुति संसाधनों में एक चित्र जोड़ें।
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// OLE प्रीव्यू के लिए शीर्षक और चित्र सेट करें।
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE ऑब्जेक्ट फ्रेम को आकार बदलने और पुनर्स्थानित होने से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेज़ेंटेशन स्लाइड में जोड़ते हैं, और PowerPoint में प्रेज़ेंटेशन खोलते हैं, तो आपको लिंक अपडेट करने के लिए एक संदेश दिख सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को रीफ़्रेश करता है। PowerPoint को ऑब्जेक्ट के डेटा को अपडेट करने के लिए प्रॉम्प्ट करने से रोकने हेतु, [IOleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ioleobjectframe/) इंटरफ़ेस की `set_UpdateAutomatic` मेथड को `false` सेट करें:

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for C++ आपको OLE ऑब्जेक्ट्स के रूप में स्लाइड्स में एम्बेडेड फ़ाइलें इस तरह निकालने की अनुमति देता है:

1. उस [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं जिसमें आप निकालने वाले OLE ऑब्जेक्ट्स हों।
2. प्रेज़ेंटेशन में सभी आकारों के माध्यम से लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) आकारों तक पहुंचें।
3. OLE ऑब्जेक्ट फ्रेम से एम्बेडेड फ़ाइलों का डेटा एक्सेस करें और उसे डिस्क पर लिखें।

यह C++ कोड आपको दिखाता है कि कैसे स्लाइड में OLE ऑब्जेक्ट्स के रूप में एम्बेडेड फ़ाइलें निकालें:

``` cpp
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

**क्या OLE कंटेंट स्लाइड्स को PDF/छवियों में निर्यात करते समय रेंडर होगा?**  
स्लाइड पर जो दिखाई देता है वह रेंडर किया जाता है—आइकन/सब्स्टिट्यूट इमेज (प्रीव्यू)। "लाइव" OLE कंटेंट रेंडरिंग के दौरान निष्पादित नहीं होता। यदि आवश्यक हो, तो अपनी खुद की प्रीव्यू इमेज सेट करें ताकि निर्यात किए गए PDF में अपेक्षित रूप दिखे।

**मैं स्लाइड पर एक OLE ऑब्जेक्ट को कैसे लॉक करूं ताकि उपयोगकर्ता PowerPoint में उसे मूव/एडिट न कर सकें?**  
शेप को लॉक करें: Aspose.Slides [shape-level locks](/slides/hi/cpp/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन अनजाने संपादन और मूवमेंट को प्रभावी रूप से रोकता है।

**जब मैं प्रेज़ेंटेशन खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट "जंप" करता है या आकार बदलता है, क्यों?**  
PowerPoint लिंक्ड OLE का प्रीव्यू रीफ़्रेश कर सकता है। स्थिर दिखावट के लिए, [Worksheet Resizing के लिए कार्यशील समाधान](/slides/hi/cpp/working-solution-for-worksheet-resizing/) का पालन करें—या तो फ्रेम को रेंज के अनुसार फिट करें, या रेंज को एक निश्चित फ्रेम में स्केल करके एक उपयुक्त सब्स्टिट्यूट इमेज सेट करें।

**क्या PPTX फॉर्मेट में लिंक्ड OLE ऑब्जेक्ट्स के रिलेैटिव पाथ्स संरक्षित रहते हैं?**  
PPTX में "रिलेैटिव पाथ" जानकारी उपलब्ध नहीं है—सिर्फ पूर्ण पाथ होता है। रिलेैटिव पाथ्स पुराने PPT फॉर्मेट में मिलते हैं। पोर्टेबिलिटी के लिए विश्वसनीय एब्सोल्यूट पाथ/एक्सेसिबल URI या एम्बेडिंग को प्राथमिकता दें।