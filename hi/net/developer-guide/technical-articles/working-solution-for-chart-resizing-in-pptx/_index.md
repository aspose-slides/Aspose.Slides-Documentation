---
title: PPTX में चार्ट रिसाइज़िंग के लिए कार्य समाधान
type: docs
weight: 60
url: /hi/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- चार्ट रिसाइज़िंग
- Excel चार्ट
- OLE ऑब्जेक्ट
- चार्ट एम्बेड करें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ एम्बेडेड Excel OLE ऑब्जेक्ट्स का उपयोग करने पर PPTX में अनपेक्षित चार्ट रिसाइज़िंग को ठीक करें। आकार को समान रखने के लिए दो विधियों और कोड सीखें।"
---
## **पृष्ठभूमि**

यह देखा गया है कि Aspose घटकों के माध्यम से PowerPoint प्रस्तुति में OLE वस्तुओं के रूप में एम्बेड किए गए Excel चार्ट को पहली सक्रियता के बाद एक अनिर्दिष्ट स्केल में बदल दिया जाता है। यह व्यवहार चार्ट की सक्रियता से पहले और बाद की स्थितियों के बीच प्रस्तुति में एक स्पष्ट दृश्य अंतर पैदा करता है। Aspose टीम ने इस मुद्दे की विस्तृत जाँच की है और समाधान पाया है। यह लेख समस्या के कारणों और संबंधित सुधार का वर्णन करता है।

हमने [previous article](/slides/hi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) में बताया था कि Aspose.Cells for .NET के साथ Excel चार्ट कैसे बनाएं और Aspose.Slides for .NET का उपयोग करके उसे PowerPoint प्रस्तुति में एम्बेड करें। [object preview issue](/slides/hi/net/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए हमने चार्ट की छवि को चार्ट के OLE ऑब्जेक्ट फ्रेम को सौंपा। आउटपुट प्रस्तुति में, जब आप चार्ट छवि प्रदर्शित करने वाले OLE ऑब्जेक्ट फ्रेम पर दो बार क्लिक करते हैं, तो Excel चार्ट सक्रिय हो जाता है। अंतिम उपयोगकर्ता अंतर्निहित Excel वर्कबुक में इच्छित परिवर्तन कर सकते हैं और फिर सक्रिय वर्कबुक के बाहर क्लिक करके संबंधित स्लाइड पर वापस जा सकते हैं। उपयोगकर्ता के स्लाइड पर वापस आने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाता है, और रिसाइज़िंग फ़ैक्टर दोनों OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के मूल आकारों पर निर्भर करता है।

## **रीसाइज़िंग का कारण**

क्योंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपने मूल आकार को बनाए रखने की कोशिश करता है। हालांकि, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। माइक्रोसॉफ्ट के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर बातचीत करते हैं और एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बनाए रखते हैं। Excel विंडो के आकार और OLE ऑब्जेक्ट फ्रेम के आकार या स्थिति के बीच अंतर के आधार पर रीसाइज़िंग होती है।

## **कार्यशील समाधान**

Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियां बनाने के दो संभावित परिदृश्य हैं।

**Scenario 1:** मौजूदा टेम्पलेट के आधार पर प्रस्तुति बनाना।

**Scenario 2:** शून्य से प्रस्तुति बनाना।

यहाँ दिया गया समाधान दोनों परिदृश्यों पर लागू होता है। सभी समाधान दृष्टिकोणों का आधार समान है: **एम्बेडेड OLE ऑब्जेक्ट का विंडो आकार PowerPoint स्लाइड में OLE ऑब्जेक्ट फ्रेम के साथ मेल खाना चाहिए**। अब हम इस समाधान के दो दृष्टिकोणों पर चर्चा करेंगे।

## **पहला दृष्टिकोण**

इस दृष्टिकोण में, हम सीखेंगे कि एम्बेडेड Excel वर्कबुक का विंडो आकार कैसे सेट किया जाए ताकि वह PowerPoint स्लाइड में OLE ऑब्जेक्ट फ्रेम के आकार से मेल खाए।

**Scenario 1**  

मान लीजिए हमने एक टेम्पलेट परिभाषित किया है और उसके आधार पर प्रस्तुतियां बनाना चाहते हैं। मानिए टेम्पलेट में इंडेक्स 2 पर एक आकार (shape) है जहाँ हम एम्बेडेड Excel वर्कबुक वाला OLE फ्रेम रखना चाहते हैं। इस परिदृश्य में, OLE ऑब्जेक्ट फ्रेम का आकार पूर्व-निर्धारित है—यह टेम्पलेट में इंडेक्स 2 पर आकार के आकार के समान है। हमें केवल वर्कबुक का विंडो आकार उस आकार के बराबर सेट करना है। निम्नलिखित कोड स्निपेट इस उद्देश्य की पूर्ति करता है:

```cs
// विंडो के साथ चार्ट का आकार परिभाषित करें। 
// वर्कबुक की विंडो चौड़ाई इंच में सेट करें (72 से विभाजित क्योंकि PowerPoint 72 पिक्सेल प्रति इंच उपयोग करता है)।
 // वर्कबुक की विंडो ऊँचाई इंच में सेट करें।
 // वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
 // एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
chart.SizeWithWindow = true;

// Set the window width of the workbook in inches (divided by 72 as PowerPoint uses 72 pixels per inch).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Set the window height of the workbook in inches.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Save the workbook to a memory stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Create an OLE object frame with the embedded Excel data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**  

मान लीजिए हम शून्य से एक प्रस्तुति बनाना चाहते हैं और किसी भी आकार का OLE ऑब्जेक्ट फ्रेम एम्बेडेड Excel वर्कबुक के साथ शामिल करना चाहते हैं। निम्नलिखित कोड स्निपेट में, हम स्लाइड पर x = 0.5 इंच और y = 1 इंच पर 4 इंच ऊँची और 9.5 इंच चौड़ी OLE ऑब्जेक्ट फ्रेम बनाते हैं। फिर हम Excel वर्कबुक विंडो को उसी आकार—4 इंच ऊँची और 9.5 इंच चौड़ी—पर सेट करते हैं।

```cs
// हमारी वांछित ऊँचाई।
int desiredHeight = 288; // 4 इंच (4 * 72)

// हमारी वांछित चौड़ाई।
int desiredWidth = 684;//9.5 इंच (9.5 * 72)

// विंडो के साथ चार्ट का आकार परिभाषित करें।
chart.SizeWithWindow = true;

// वर्कबुक की विंडो चौड़ाई इंच में सेट करें।
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// वर्कबुक की विंडो ऊँचाई इंच में सेट करें।
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
MemoryStream workbookStream = workbook.SaveToStream();

// एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **दूसरा दृष्टिकोण**

इस दृष्टिकोण में, हम सीखेंगे कि एम्बेडेड Excel वर्कबुक में चार्ट का आकार कैसे सेट किया जाए ताकि वह PowerPoint स्लाइड में OLE ऑब्जेक्ट फ्रेम के आकार से मेल खाए। यह दृष्टिकोण तब उपयोगी है जब चार्ट का आकार प्रारंभ में ज्ञात हो और बाद में नहीं बदलता।

**Scenario 1**  

मान लीजिए हमने एक टेम्पलेट परिभाषित किया है और उसके आधार पर प्रस्तुतियां बनाना चाहते हैं। मानिए टेम्पलेट में इंडेक्स 2 पर एक आकार है जहाँ हम एम्बेडेड Excel वर्कबुक वाला OLE फ्रेम रखना चाहते हैं। इस परिदृश्य में, OLE फ्रेम का आकार पूर्व-निर्धारित है—टेम्पलेट में इंडेक्स 2 पर आकार के आकार के समान। हमें केवल वर्कबुक में चार्ट का आकार उस आकार के बराबर सेट करना है। निम्नलिखित कोड स्निपेट इस उद्देश्य की पूर्ति करता है:

```cs
// विंडो के बिना चार्ट का आकार परिभाषित करें। 
chart.SizeWithWindow = false;

// पिक्सेल में चार्ट की चौड़ाई सेट करें (Excel 96 पिक्सेल प्रति इंच उपयोग करता है, इसलिए 96 से गुणा करें)।    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// पिक्सेल में चार्ट की ऊँचाई सेट करें।
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// चार्ट की प्रिंट आकार परिभाषित करें।
chart.PrintSize = PrintSizeType.Custom;

// वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
MemoryStream workbookStream = workbook.SaveToStream();

// एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**  

मान लीजिए हम शून्य से एक प्रस्तुति बनाना चाहते हैं और किसी भी आकार का OLE ऑब्जेक्ट फ्रेम एम्बेडेड Excel वर्कबुक के साथ शामिल करना चाहते हैं। निम्नलिखित कोड स्निपेट में, हम स्लाइड पर x = 0.5 इंच और y = 1 इंच पर 4 इंच ऊँची और 9.5 इंच चौड़ी OLE ऑब्जेक्ट फ्रेम बनाते हैं। हम संबंधित चार्ट आकार को भी उसी आयाम—4 इंच ऊँचा और 9.5 इंच चौड़ा—पर सेट करते हैं।

```cs
 // हमारी वांछित ऊँचाई।
int desiredHeight = 288; // 4 इंच (4 * 576)

// हमारी वांछित चौड़ाई।
int desiredWidth = 684; // 9.5 इंच (9.5 * 576)

// विंडो के बिना चार्ट का आकार परिभाषित करें। 
chart.SizeWithWindow = false;

// पिक्सेल में चार्ट की चौड़ाई सेट करें।   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// पिक्सेल में चार्ट की ऊँचाई सेट करें।    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
MemoryStream workbookStream = workbook.SaveToStream();

// एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **निष्कर्ष**

चार्ट रीसाइज़िंग समस्या को ठीक करने के दो तरीके हैं। दृष्टिकोण का चयन आवश्यकताओं और उपयोग केस पर निर्भर करता है। चाहे प्रस्तुतियां टेम्पलेट से बनाई गई हों या शून्य से, दोनों तरीकों का कार्य समान होता है। साथ ही, इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

## **अक्सर पूछे जाने वाले प्रश्न**

**Why does my embedded Excel chart change size after activating it in PowerPoint?**  
यह इसलिए होता है क्योंकि Excel पहली सक्रियता पर मूल विंडो आकार को पुनर्स्थापित करने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आयाम होता है। PowerPoint और Excel आकार पर बातचीत करते हैं ताकि अनुपात बनाए रखा जा सके, जिससे रीसाइज़िंग हो सकती है।

**Is it possible to prevent this resizing issue entirely?**  
हाँ। एम्बेडिंग से पहले Excel वर्कबुक विंडो आकार या चार्ट आकार को OLE ऑब्जेक्ट फ्रेम आकार के साथ मेल करके, आप चार्ट आकार को स्थिर रख सकते हैं।

**Which approach should I take, setting the workbook window size or setting the chart size?**  
यदि आप वर्कबुक के अनुपात को बनाए रखना चाहते हैं और बाद में रिसाइज़िंग की संभावना रखना चाहते हैं तो **Approach 1 (window size)** का उपयोग करें।  
यदि चार्ट के आयाम निश्चित हैं और एम्बेडिंग के बाद नहीं बदलेंगे तो **Approach 2 (chart size)** का उपयोग करें।

**Will these methods work with both template-based presentations and new presentations?**  
हाँ। दोनों दृष्टिकोण टेम्पलेट-आधारित प्रस्तुतियों और शून्य से बनाई गई प्रस्तुतियों दोनों में समान रूप से काम करते हैं।

**Is there a limit to the size of the OLE object frame?**  
नहीं। आप OLE फ्रेम को किसी भी आकार में सेट कर सकते हैं जब तक वह वर्कबुक या चार्ट आकार के अनुसार उचित रूप से स्केल हो।

**Can I use these methods with charts created in other spreadsheet programs?**  
उदाहरण Excel चार्ट्स के लिए Aspose.Cells के साथ तैयार किए गए हैं, लेकिन सिद्धांत अन्य OLE‑संगत स्प्रेडशीट प्रोग्राम्स पर भी लागू होते हैं, बशर्ते वे समान आकार विकल्प प्रदान करते हों।

## **संबंधित अनुभाग**

- [Excel चार्ट बनाएं और उन्हें OLE ऑब्जेक्ट्स के रूप में प्रस्तुतियों में एम्बेड करें](/slides/hi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [PowerPoint ऐड‑इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वचालित रूप से अपडेट करें](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)