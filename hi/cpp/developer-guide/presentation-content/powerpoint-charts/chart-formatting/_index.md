---
title: C++ में प्रस्तुति चार्ट स्वरूपित करें
linktitle: चार्ट स्वरूपण
type: docs
weight: 60
url: /hi/cpp/chart-formatting/
keywords:
- चार्ट फ़ॉर्मेट
- चार्ट स्वरूपण
- चार्ट इकाई
- चार्ट गुण
- चार्ट सेटिंग्स
- चार्ट विकल्प
- फ़ॉन्ट गुण
- गोल किनारा
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में चार्ट फ़ॉर्मेटिंग सीखें और पेशेवर, आकर्षक शैली के साथ अपने PowerPoint प्रस्तुति को उन्नत करें।"
---
## **परिचय**

यह लेख बताता है कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट कैसे फ़ॉर्मेट किए जाते हैं। यह अक्षों, ग्रिड लाइनों, शीर्षकों, लीजेंड, प्लॉट एरिया और दीवार भराव जैसे प्रमुख चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता को कैसे बेहतर बनाया जा सकता है, इसे दर्शाता है।

यह फ़ॉन्ट गुणों को चार्ट टेक्स्ट पर सेट करने, चार्ट डेटा पर तैयार और कस्टम संख्यात्मक फ़ॉर्मेट लागू करने, और चार्ट एरिया के लिए गोल कोनों को सक्षम करने का भी प्रदर्शन करता है। ये उदाहरण मिलकर प्रस्तुतियों में चार्ट के दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने का तरीका दिखाते हैं।

## **चार्ट इकाइयों को फ़ॉर्मेट करें**
Aspose.Slides for C++ डेवलपर्स को शून्य से कस्टम चार्ट बनाने की सुविधा देता है। यह लेख विभिन्न चार्ट इकाइयों जैसे चार्ट श्रेणी (Category) और मान (Value) अक्ष को फ़ॉर्मेट करने के तरीकों को समझाता है।

Aspose.Slides for C++ विभिन्न चार्ट इकाइयों को प्रबंधित करने और उन्हें कस्टम मानों के साथ फ़ॉर्मेट करने के लिए सरल API प्रदान करता है:

1. **Presentation** क्लास की एक इंस्टेंस बनाएँ।  
1. इंडेक्स के आधार पर स्लाइड का रेफ़रेंस प्राप्त करें।  
1. डिफ़ॉल्ट डेटा के साथ वांछित प्रकार का चार्ट जोड़ें (इस उदाहरण में हम `ChartType.LineWithMarkers` का उपयोग करेंगे)।  
1. चार्ट के Value Axis तक पहुँचें और निम्नलिखित गुण सेट करें:  
   1. Value Axis Major Grid lines के लिए **Line format** सेट करना  
   1. Value Axis Minor Grid lines के लिए **Line format** सेट करना  
   1. Value Axis के लिए **Number Format** सेट करना  
   1. Value Axis के लिए **Min, Max, Major and Minor units** सेट करना  
   1. Value Axis डेटा के लिए **Text Properties** सेट करना  
   1. Value Axis के लिए **Title** सेट करना  
   1. Value Axis के लिए **Line Format** सेट करना  
1. चार्ट के Category Axis तक पहुँचें और निम्नलिखित गुण सेट करें:  
   1. Category Axis Major Grid lines के लिए **Line format** सेट करना  
   1. Category Axis Minor Grid lines के लिए **Line format** सेट करना  
   1. Category Axis डेटा के लिए **Text Properties** सेट करना  
   1. Category Axis के लिए **Title** सेट करना  
   1. Category Axis के लिए **Label Positioning** सेट करना  
   1. Category Axis लेबल्स के लिए **Rotation Angle** सेट करना  
1. चार्ट के Legend तक पहुँचें और उनके लिए **Text Properties** सेट करें  
1. लेजेंड को इस प्रकार सेट करें कि वह चार्ट के साथ ओवरलैप न हो  
1. चार्ट के **Secondary Value Axis** तक पहुँचें और निम्नलिखित गुण सेट करें:  
   1. Secondary **Value Axis** को सक्षम करें  
   1. Secondary Value Axis के लिए **Line Format** सेट करें  
   1. Secondary Value Axis के लिए **Number Format** सेट करें  
   1. Secondary Value Axis के लिए **Min, Max, Major and Minor units** सेट करें  
1. अब पहली चार्ट सीरीज़ को Secondary Value Axis पर प्लॉट करें  
1. चार्ट बैक वॉल को भरने के लिए रंग सेट करें  
1. चार्ट प्लॉट एरिया का फ़िल कलर सेट करें  
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**
Aspose.Slides for C++ चार्ट के फ़ॉन्ट संबंधित गुणों को सेट करने का समर्थन प्रदान करता है। कृपया नीचे दिए गए चरणों का पालन करें:

- `Presentation` क्लास ऑब्जेक्ट को इंस्टैंशिएट करें।  
- स्लाइड पर चार्ट जोड़ें।  
- फ़ॉन्ट की ऊँचाई सेट करें।  
- संशोधित प्रस्तुति को सहेजें।

नीचे एक नमूना उदाहरण दिया गया है।

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **चार्ट डेटा तालिका के लिए फ़ॉन्ट गुण सेट करें**
Aspose.Slides for C++ सीरीज़ में शैलियों के रंग बदलने का समर्थन प्रदान करता है।

1. `Presentation` क्लास ऑब्जेक्ट को इंस्टैंशिएट करें।  
1. स्लाइड पर चार्ट जोड़ें।  
1. चार्ट तालिका सेट करें।  
1. फ़ॉन्ट की ऊँचाई सेट करें।  
1. संशोधित प्रस्तुति को सहेजें।

नीचे एक नमूना उदाहरण दिया गया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **चार्ट एरिया के गोल किनारे सेट करें**
Aspose.Slides for C++ चार्ट एरिया के लिए **IChart.HasRoundedCorners** और **Chart.HasRoundedCorners** गुण जोड़ता है।

1. `Presentation` क्लास ऑब्जेक्ट को इंस्टैंशिएट करें।  
1. स्लाइड पर चार्ट जोड़ें।  
1. चार्ट का फ़िल टाइप और रंग सेट करें।  
1. गोल कोने का गुण `True` सेट करें।  
1. संशोधित प्रस्तुति को सहेजें।

नीचे एक नमूना उदाहरण दिया गया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **संख्यात्मक फ़ॉर्मेट सेट करें**
Aspose.Slides for C++ चार्ट डेटा फ़ॉर्मेट को प्रबंधित करने के लिए सरल API प्रदान करता है:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) class.  
1. Obtain a slide's reference by its index.  
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).  
1. Set the preset number format from the possible preset values.  
1. Traverse through the chart data cell in every chart series and set the chart data number format.  
1. Save the presentation.  
1. Set the custom number format.  
1. Traverse through chart data cell inside every chart series and setting a different chart data number format.  
1. Save the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**संभव प्रीसेट नंबर फ़ॉर्मेट मान और उनका इंडेक्स, जिन्हें नीचे उपयोग किया जा सकता है:**|
| :- | :- |
|**0**|General|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|
|||
| :- | :- |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/एरिया के लिये अर्ध-पारदर्शी भराव सेट कर सकता हूँ जबकि बॉर्डर ओपेक रहता है?**  
हाँ। भराव की पारदर्शिता और आउटलाइन को अलग‑अलग कॉन्फ़िगर किया जा सकता है। यह घनी दृश्यावली में ग्रिड और डेटा की पठनीयता सुधारने में उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं क्या करूँ?**  
फ़ॉन्ट आकार कम करें, गैर‑आवश्यक लेबल घटकों (जैसे श्रेणियां) को अक्षम करें, लेबल का ऑफ़सेट/स्थिति सेट करें, आवश्यक होने पर केवल चयनित बिंदुओं के लिये लेबल दिखाएँ, या फ़ॉर्मेट को “value + legend” में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न भराव लागू कर सकता हूँ?**  
हाँ। सॉलिड तथा ग्रेडिएंट/पैटर्न दोनों भराव सामान्यतः उपलब्ध होते हैं। व्यावहारिक रूप से ग्रेडिएंट का उपयोग सीमित रखें और ऐसे संयोजन से बचें जो ग्रिड और पाठ के साथ कंट्रास्ट घटा दें।