---
title: PPTX में चार्ट री‑साइज़िंग के लिए कार्यशील समाधान
type: docs
weight: 60
url: /hi/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- चार्ट री‑साइज़िंग
- Excel चार्ट
- OLE ऑब्जेक्ट
- चार्ट एम्बेड
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ एम्बेडेड Excel OLE ऑब्जेक्ट्स का उपयोग करने पर PPTX में अनपेक्षित चार्ट री‑साइज़िंग को ठीक करें। आकार को स्थिर रखने के लिए दो कोड विधियों को सीखें।"
---
## **पृष्ठभूमि**

यह देखा गया है कि Aspose घटकों के माध्यम से PowerPoint प्रस्तुति में OLE वस्तुओं के रूप में एम्बेड किए गए Excel चार्ट अपने पहले सक्रियण के बाद अनिर्दिष्ट स्केल में पुनः आकारित हो जाते हैं। यह व्यवहार प्रस्तुति में चार्ट की पूर्व‑और‑परिणाम सक्रियण स्थितियों के बीच एक स्पष्ट दृश्य अंतर पैदा करता है। Aspose टीम ने इस समस्या की विस्तार से जाँच की है और एक समाधान पाया है। यह लेख समस्या के कारणों और संबंधित समाधान का वर्णन करता है।

In the [previous article](/slides/hi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for C++ and embed it in a PowerPoint presentation using Aspose.Slides for C++. To address the [object preview issue](/slides/hi/cpp/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. End users can make any desired changes in the underlying Excel workbook and then return to the corresponding slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **पुनः आकार देने का कारण**

क्योंकि Excel workbook का अपना विंडो आकार होता है, यह पहले सक्रियण पर अपना मूल आकार बनाए रखने की कोशिश करता है। OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। Microsoft के अनुसार, जब Excel workbook सक्रिय किया जाता है, तो Excel और PowerPoint आकार पर बात‑चित करते हैं और एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बनाए रखते हैं। Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार या स्थिति के बीच के अंतर के आधार पर पुनः आकार देना होता है।

## **कार्यशील समाधान**

PowerPoint प्रस्तुतियों को Aspose.Slides for C++ के साथ बनाने के दो संभावित परिदृश्य हैं।

**Scenario 1:** मौजूदा टेम्पलेट के आधार पर प्रस्तुति बनाना।

**Scenario 2:** शून्य से नई प्रस्तुति बनाना।

यहाँ प्रस्तुत किया गया समाधान दोनों परिदृश्यों पर लागू होता है। सभी समाधान दृष्टिकोणों का मूल सिद्धान्त समान है: **एम्बेडेड OLE ऑब्जेक्ट का विंडो आकार PowerPoint स्लाइड में OLE ऑब्जेक्ट फ्रेम के आकार के बराबर होना चाहिए**। अब हम इस समाधान के दो दृष्टिकोणों पर चर्चा करेंगे।

## **पहला दृष्टिकोण**

इस दृष्टिकोण में हम सीखेंगे कि एम्बेडेड Excel workbook का विंडो आकार कैसे सेट किया जाए ताकि वह PowerPoint स्लाइड में OLE ऑब्जेक्ट फ्रेम के आकार के बराबर हो जाए।

**Scenario 1**  

मान लीजिए हमने एक टेम्पलेट परिभाषित किया है और उसके आधार पर प्रस्तुतियाँ बनाना चाहते हैं। मान लें कि टेम्पलेट में इंडेक्स 2 पर एक आकृति है जहाँ हम एक OLE फ्रेम रखना चाहते हैं जो एम्बेडेड Excel workbook रखेगा। इस परिदृश्य में OLE ऑब्जेक्ट फ्रेम का आकार पहले से निर्धारित है—यह टेम्पलेट में इंडेक्स 2 पर स्थित आकृति के आकार के बराबर है। हमें केवल workbook के विंडो आकार को उसी आकृति के आकार के बराबर सेट करना है। नीचे दिया गया कोड स्निपेट इस उद्देश्य को पूरा करता है:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// विंडो के साथ चार्ट का आकार निर्धारित करें। 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// वर्कबुक की विंडो चौड़ाई को इंच में सेट करें (PowerPoint प्रत्येक इंच में 72 पिक्सेल उपयोग करता है, इसलिए 72 से विभाजित)।
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// वर्कबुक की विंडो ऊँचाई को इंच में सेट करें।
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// एम्बेडेड Excel डेटा के साथ एक OLE ऑब्जेक्ट फ्रेम बनाएं।
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**Scenario 2**  

मान लीजिए हम शून्य से एक नई प्रस्तुति बनाना चाहते हैं और किसी भी आकार के OLE ऑब्जेक्ट फ्रेम के साथ एम्बेडेड Excel workbook शामिल करना चाहते हैं। नीचे दिए गए कोड स्निपेट में हम स्लाइड पर x = 0.5 इंच और y = 1 इंच पर 4 इंच ऊँचा और 9.5 इंच चौड़ा OLE ऑब्जेक्ट फ्रेम बनाते हैं। फिर हम Excel workbook की विंडो को उसी आकार—4 इंच ऊँचा और 9.5 इंच चौड़ा—पर सेट करते हैं।

```cpp
// हमारी इच्छित ऊँचाई।
int32_t desiredHeight = 288; // 4 इंच (4 * 72)

// हमारी इच्छित चौड़ाई।
int32_t desiredWidth = 684; // 9.5 इंच (9.5 * 72)

// विंडो के साथ चार्ट का आकार निर्धारित करें। 
chart->SetSizeWithWindow(true);

// वर्कबुक की विंडो चौड़ाई को इंच में सेट करें।
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// वर्कबुक की विंडो ऊँचाई को इंच में सेट करें।
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएँ।
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **दूसरा दृष्टिकोण**

इस दृष्टिकोण में हम सीखेंगे कि एम्बेडेड Excel workbook में चार्ट का आकार कैसे सेट किया जाए ताकि वह PowerPoint स्लाइड में OLE ऑब्जेक्ट फ्रेम के आकार के बराबर हो जाए। यह दृष्टिकोण तब उपयोगी है जब चार्ट का आकार प्रारम्भ में ही ज्ञात हो और बाद में नहीं बदलेगा।

**Scenario 1**  

मान लीजिए हमने एक टेम्पलेट परिभाषित किया है और उसके आधार पर प्रस्तुतियाँ बनाना चाहते हैं। मान लें कि टेम्पलेट में इंडेक्स 2 पर एक आकृति है जहाँ हम एक OLE फ्रेम रखना चाहते हैं जो एम्बेडेड Excel workbook रखेगा। इस परिदृश्य में OLE फ्रेम का आकार पहले से निर्धारित है—यह टेम्पलेट में इंडेक्स 2 पर स्थित आकृति के आकार के बराबर है। हमें केवल workbook में चार्ट का आकार उसी आकृति के आकार के बराबर सेट करना है। नीचे दिया गया कोड स्निपेट इस उद्देश्य को पूरा करता है:

```cpp
// विंडो के बिना चार्ट का आकार निर्धारित करें। 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// पिक्सेल में चार्ट की चौड़ाई सेट करें (Excel प्रति इंच 96 पिक्सेल उपयोग करता है, इसलिए 96 से गुणा करें)।    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// पिक्सेल में चार्ट की ऊँचाई सेट करें।
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// चार्ट का प्रिंट आकार निर्धारित करें।
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**Scenario 2**  

मान लीजिए हम शून्य से नई प्रस्तुति बनाना चाहते हैं और किसी भी आकार के OLE ऑब्जेक्ट फ्रेम के साथ एम्बेडेड Excel workbook शामिल करना चाहते हैं। नीचे दिए गए कोड स्निपेट में हम स्लाइड पर x = 0.5 इंच और y = 1 इंच पर 4 इंच ऊँचा और 9.5 इंच चौड़ा OLE ऑब्जेक्ट फ्रेम बनाते हैं। फिर हम सम्बंधित चार्ट का आकार भी वही—4 इंच ऊँचा और 9.5 इंच चौड़ा—सेट करते हैं:

```cpp
// हमारी इच्छित ऊँचाई।
int32_t desiredHeight = 288; // 4 इंच (4 * 576)

// हमारी इच्छित चौड़ाई।
int32_t desiredWidth = 684; // 9.5 इंच(9.5 * 576)

// विंडो के बिना चार्ट का आकार निर्धारित करें। 
chart->SetSizeWithWindow(false);

// पिक्सेल में चार्ट की चौड़ाई सेट करें।    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// पिक्सेल में चार्ट की ऊँचाई सेट करें।
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **निष्कर्ष**

चार्ट‑रीसाइज़िंग समस्या को ठीक करने के दो दृष्टिकोण हैं। किस दृष्टिकोण को अपनाना है यह आवश्यकताओं और उपयोग के मामलों पर निर्भर करता है। दोनों दृष्टिकोण समान रूप से काम करते हैं, चाहे प्रस्तुतियाँ टेम्पलेट से बनायीँ गई हों या शून्य से बनाई गई हों। साथ ही इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई प्रतिबंध नहीं है।

## **FAQ**

**मेरे एम्बेडेड Excel चार्ट का आकार PowerPoint में सक्रिय करने के बाद क्यों बदल जाता है?**  
यह इसलिए होता है क्योंकि Excel पहले सक्रियण पर अपना मूल विंडो आकार पुनः स्थापित करने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम की अपनी माप होती है। PowerPoint और Excel आकार पर बातचीत करते हैं ताकि अनुपात बना रहे, जिससे री‑साइज़िंग हो सकती है।

**क्या इस री‑साइज़िंग समस्या को पूरी तरह रोकना संभव है?**  
हाँ। एम्बेड करने से पहले Excel workbook के विंडो आकार या चार्ट आकार को OLE ऑब्जेक्ट फ्रेम के आकार के बराबर करके आप चार्ट के आकार को स्थिर रख सकते हैं।

**कौन‑सा दृष्टिकोण चुनूँ, workbook विंडो आकार सेट करना या चार्ट आकार सेट करना?**  
यदि आप workbook के अनुपात को बनाए रखना चाहते हैं और बाद में पुनः आकार देने की संभावना रखना चाहते हैं तो **Approach 1 (विंडो आकार)** उपयोग करें।  
यदि चार्ट के आयाम स्थिर हैं और एम्बेड करने के बाद नहीं बदलेंगे तो **Approach 2 (चार्ट आकार)** उपयोग करें।

**क्या ये विधियाँ टेम्पलेट‑आधारित प्रस्तुतियों और नई प्रस्तुतियों दोनों पर काम करेंगी?**  
हाँ। दोनों दृष्टिकोण टेम्पलेट से बनाई गई प्रस्तुतियों और शून्य से बनाई गई प्रस्तुतियों दोनों पर समान रूप से काम करते हैं।

**OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा है क्या?**  
नहीं। आप OLE फ्रेम को कोई भी आकार दे सकते हैं, बशर्ते वह workbook या चार्ट के आकार के साथ उचित比例 में स्केल हो।

**क्या मैं इन विधियों को अन्य स्प्रेडशीट प्रोग्राम में बनाये गए चार्ट पर लागू कर सकता हूँ?**  
उदाहरण Excel चार्ट के लिए Aspose.Cells के साथ तैयार किए गए हैं, लेकिन सिद्धान्त उन अन्य OLE‑संगत स्प्रेडशीट प्रोग्राम पर भी लागू होते हैं जो समान आकार निर्धारण विकल्पों का समर्थन करते हैं।

## **संबंधित अनुभाग**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)