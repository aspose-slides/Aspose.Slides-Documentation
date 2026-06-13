---
title: "Aspose.Slides for .NET 14.3.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन"
linktitle: "Aspose.Slides for .NET 14.3.0"
type: docs
weight: 50
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- "स्थानांतरण"
- "पुरानी कोड"
- "आधुनिक कोड"
- "पुरानी पद्धति"
- "आधुनिक पद्धति"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग बदलावों की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुचारू रूप से माइग्रेट करें।"
---
## **सार्वजनिक API और बैकवर्ड असंगत परिवर्तन**
### **Aspose.Slides.ShapeThumbnailBounds एन्यूमरेशन और Aspose.Slides.IShape.GetThumbnail() मेथड्स जोड़े गए**
GetThumbnail() और GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) मेथड्स का उपयोग एक अलग शेप थंबनेल बनाने के लिए किया जाता है। ShapeThumbnailBounds एन्यूमरेशन संभावित शेप थंबनेल बाउंड प्रकारों को परिभाषित करता है।
### **Aspose.Slides.IShape में Property UniqueId जोड़ी गई**
Aspose.Slides.IShape.UniqueId प्रॉपर्टी प्रस्तुति स्तर पर शेप पहचानकर्ता को विशिष्ट रूप से प्राप्त करती है। ये विशिष्ट पहचानकर्ता शेप कस्टम टैग्स में संग्रहीत होते हैं।
### **IChartCategoryLevelsManager में SetGroupingItem मेथड का सिग्नेचर बदल दिया गया**
IChartCategoryLevelsManager मेथड का सिग्नेचर

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

अब अप्रचलित है और नीचे दिए गए सिग्नेचर से प्रतिस्थापित किया गया है

``` csharp

 void SetGroupingItem(int level, object value);

``` 

अब कॉल जैसे

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

को बदलकर इस प्रकार की कॉल करनी होगी

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

SetGroupingItem में "Group 1" जैसी स्ट्रिंग मान पास करें, न कि IChartDataCell प्रकार का मान। वर्ग स्तरों के लिए परिभाषित वर्कशीट, पंक्ति और कॉलम के साथ IChartDataCell बनाना कुछ आवश्यकताओं को पूरा करना चाहिए और इसे SetGroupingItem(int, object) मेथड में एन्कैप्सुलेट किया गया है।
### **Aspose.Slides.IBaseSlide इंटरफ़ेस में SlideId प्रॉपर्टी जोड़ी गई**
SlideId प्रॉपर्टी एक अनूठा स्लाइड पहचानकर्ता प्राप्त करती है।
### **ISlideShowTransition में SoundName प्रॉपर्टी जोड़ी गई**
पढ़ने-लिखने योग्य स्ट्रिंग। ट्रांज़िशन की आवाज़ के लिए एक मानव‑पठनीय नाम निर्दिष्ट करता है। Sound प्रॉपर्टी को आवाज़ के नाम को प्राप्त या सेट करने के लिए असाइन किया जाना चाहिए। यह नाम PowerPoint यूज़र इंटरफ़ेस में तब दिखता है जब ट्रांज़िशन साउंड को मैनुअली कॉन्फ़िगर किया जाता है। यदि Sound प्रॉपर्टी असाइन नहीं की गई तो PptxException उत्पन्न हो सकता है।
### **ChartSeriesGroup.Type प्रॉपर्टी का प्रकार बदल दिया गया**
ChartSeriesGroup.Type प्रॉपर्टी को ChartType एन्यूमरेशन से बदलकर नए CombinableSeriesTypesGroup एन्यूमरेशन में बदल दिया गया है। CombinableSeriesTypesGroup एन्उम संगत सीरीज़ प्रकारों के समूहों को दर्शाता है।
### **विभक्त शेप थंबनेल जनरेट करने का समर्थन जोड़ा गया**
Aspose.Slides.ShapeThumbnailBounds

Aspose.Slides.IShape, Aspose.Slides.Shape में नए सदस्य:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)