---
title: .NET में प्रस्तुति दृश्य गुणों को पुनः प्राप्त करें और अपडेट करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/net/presentation-view-properties/
keywords: 
- दृश्य गुण
- सामान्य दृश्य
- रूपरेखा सामग्री
- रूपरेखा आइकन
- उभाय विभाजन को स्नैप करें
- एकल दृश्य
- बार स्थिति
- आयाम आकार
- स्वचालित समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में सामान्य दृश्य लेआउट, स्लाइड और नोट्स ज़ूम, ग्रिड अंतराल और टिप्पणी दृश्यता को कॉन्फ़िगर करने के लिये .NET के लिए Aspose.Slides का उपयोग करें।"
---
## **परिचय**

PowerPoint के सामान्य दृश्य में, स्लाइड थंबनेल या रूपरेखा के लिये साइड पेन और नीचे नोट्स पेन के बीच दिखाई देती है। Aspose.Slides for .NET प्रस्तुति की सहेजी गई संपादन प्राथमिकताओं को [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) के माध्यम से उजागर करता है। इनमें पेन लेआउट, ज़ूम स्तर, ग्रिड अंतराल, और टिप्पणी दृश्यमानता शामिल हैं।

## **INormalViewProperties के बारे में**

इंटरफ़ेस [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/) तक पहुँचने के लिये [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) का उपयोग करें। [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) निर्धारित करता है कि रूपरेखा में स्लाइड शीर्षकों के बगल में आइकन दिखें या नहीं। [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) उपयोगकर्ता द्वारा साइड पेन को संकरी करने पर इसे न्यूनतम स्थिति में स्नैप करने की अनुमति देता है। [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) पूर्ण विंडो में एक पेन दिखाने की पसंद को संकेत करता है।

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) साइड पेन और स्लाइड के बीच विभाजक को नियंत्रित करता है। [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) नोट्स पेन के ऊपर विभाजक को नियंत्रित करता है। दोनों एक [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) मान स्वीकार करते हैं जिससे `Minimized`, `Maximized`, या `Restored` हो।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

जब विभाजक को पुनर्स्थापित किया जाता है, तो [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) साइड पेन का सहेजा गया आकार प्रदान करता है और [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) ऊपर के स्लाइड क्षेत्र का सहेजा गया आकार प्रदान करता है। दोनों [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/) को उजागर करते हैं। इसका [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) प्रॉपर्टी 0 से 100 तक प्रतिशत स्वीकार करता है, और [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) यह नियंत्रित करता है कि विंडो के आकार बदलने पर संपादक आकार को समायोजित करे या नहीं।

यह उदाहरण एक मौजूदा प्रस्तुति को अपडेट करता है। यह क्षैतिज विभाजक को पुनर्स्थापित करता है, [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) को 80% सेट करता है जिसमें स्वचालित समायोजन सक्षम है, और लंबवत विभाजक को अधिकतम करता है। यह रूपरेखा दृश्य के लिये भी [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) सक्षम करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) और [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) संपादक के लिये स्वतंत्र ज़ूम सेटिंग्स संग्रहीत करते हैं। ये सेटिंग्स स्लाइड आयाम, स्लाइड-शो प्लेबैक, या छवि निर्यात रिज़ॉल्यूशन को प्रभावित नहीं करतीं।

यह उदाहरण एक मौजूदा प्रस्तुति खोलता है और स्लाइड को संपादन विंडो में फिट करने के लिये [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) सक्षम करता है। नोट्स पेज के लिये, यह स्वचालित स्केलिंग को अक्षम करता है और [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) को स्थिर 80% ज़ूम पर सेट करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **ग्रिड अंतराल सेट करें**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) पूरी प्रस्तुति में संपादन ग्रिड रेखाओं के बीच की दूरी निर्धारित करता है। यह पॉइंट में सकारात्मक मान लेता है, जहाँ 72 पॉइंट प्रति इंच होते हैं। यह उदाहरण मौजूदा प्रस्तुति में वर्तमान अंतराल को प्रदर्शित करता है और अंतराल को 18 पॉइंट सेट करके एक चौथाई इंच ग्रिड सहेजता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

ग्रिड एक निश्चित अंतराल पर दोहराया जाता है। [Drawing guides](/slides/hi/net/drawing-guides/) व्यक्तिगत क्षैतिज या लंबवत स्थितियों को चिह्नित करते हैं। दोनों ही संपादन सहायक हैं और केवल उन संपादकों में दिखते हैं जो इन्हें प्रदर्शित करते हैं। स्लाइड शो और PDF, छवियों, या SVG निर्यात में इन्हें छोड़ दिया जाता है।

## **प्रस्तुति खोलते समय टिप्पणी दिखाएँ या छुपाएँ**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) वह पसंद संग्रहीत करता है जिसे संगत संपादक प्रस्तुति खोलते समय उपयोग करते हैं। टिप्पणी वाली मौजूदा प्रस्तुति के लिये, यह उदाहरण वर्तमान सेटिंग को प्रदर्शित करता है और टिप्पणी छुपी हुई कॉपी सहेजता है। यह साथ ही [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) को [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) पर सेट करता है ताकि कॉपी स्लाइड दृश्य में खुले।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

टिप्पणियों को छुपाने से उनका पाठ, लेखक, स्थान, उत्तर और स्थिति संरक्षित रहती है। टिप्पणी स्वयं को बदलने के लिये, देखें [Presentation Comments](/slides/hi/net/presentation-comments/)। निर्यात सेटिंग्स नियंत्रित करती हैं कि टिप्पणी PDF, HTML, छवियों, नोट्स, या हैंडआउट में दिखाई दें या नहीं।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब मैं प्रस्तुति को पुनः खोलता हूँ तो ग्रिड क्यों छिपा रहता है?**  
प्रस्तुति ग्रिड अंतराल को संग्रहीत करती है। ग्रिड देखने के लिये, संपादक में ग्रिड दृश्यता को सक्षम करें।

**क्या ड्राइंग गाइड्स को साफ़ करने से ग्रिड अंतराल बदलता है?**  
नहीं। गाइड जोड़ने, स्थान बदलने या साफ़ करने से ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या प्रस्तुति के विभिन्न सेक्शन में अलग-अलग दृश्य सेटिंग्स हो सकती हैं?**  
नहीं। [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) पूरे प्रस्तुति पर लागू होता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिये अलग-अलग दृश्य सेटिंग्स सहेज सकता हूँ?**  
फ़ाइल सभी उपयोगकर्ताओं के लिये एक सेट दृश्य प्रॉपर्टीज़ संग्रहीत करती है। एक संपादक उपयोगकर्ता की स्थानीय प्राथमिकताओं को भी लागू कर सकता है।

**क्या मैं टेम्पलेट में दृश्य सेटिंग्स सहेज सकता हूँ?**  
हाँ। टेम्पलेट से निर्मित प्रस्तुतियों में उसकी सहेजी गई दृश्य सेटिंग्स विरासत में मिलती हैं।