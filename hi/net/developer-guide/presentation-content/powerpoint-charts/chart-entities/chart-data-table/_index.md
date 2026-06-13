---
title: ".NET में प्रस्तुतियों में चार्ट डेटा टेबल को अनुकूलित करें"
linktitle: "डेटा टेबल"
type: docs
url: /hi/net/chart-data-table/
keywords:
- "चार्ट डेटा"
- "डेटा टेबल"
- "फ़ॉन्ट गुण"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET में PPT और PPTX के लिए Aspose.Slides के साथ चार्ट डेटा टेबल को अनुकूलित करें ताकि प्रस्तुतियों में दक्षता और आकर्षण बढ़े।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट डेटा टेबल के साथ कैसे काम किया जाए, समझाता है। यह दिखाता है कि चार्ट के लिए डेटा टेबल कैसे प्रदर्शित किया जाए और फ़ॉन्ट गुण जैसे बोल्ड स्टाइल और फ़ॉन्ट ऊँचाई सेट करके उसके टेक्स्ट फ़ॉर्मेटिंग को कैसे अनुकूलित किया जाए। उदाहरण में प्रस्तुति लोड करना, चार्ट जोड़ना, चार्ट डेटा टेबल को सक्षम करना, फ़ॉन्ट सेटिंग्स लागू करना, और अपडेटेड प्रस्तुति को सहेजना दर्शाया गया है।

यह चार्ट डेटा टेबल में लेजेंड कुंजियों को दिखाने, निर्यात के दौरान डेटा टेबल को संरक्षित रखने, मौजूदा प्रस्तुतियों या टेम्पलेट्स से लोड किए गए चार्ट के साथ काम करने, और उन चार्टों की पहचान करने के बारे में सामान्य प्रश्नों के संक्षिप्त उत्तर भी शामिल करता है जहाँ डेटा टेबल सक्षम है।

## **चार्ट डेटा टेबल के लिए फ़ॉन्ट गुण सेट करें**
Aspose.Slides for .NET श्रृंखला रंग में श्रेणियों के रंग को बदलने के लिए समर्थन प्रदान करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास ऑब्जेक्ट बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट टेबल सेट करें।
1. फ़ॉन्ट ऊँचाई सेट करें।
1. संशोधित प्रस्तुति सहेजें।

नीचे एक नमूना उदाहरण दिया गया है।

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट के डेटा टेबल में मानों के बगल में छोटे लेजेंड कुंजियों को दिखा सकता हूँ?**

हाँ। डेटा टेबल [legend keys](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/datatable/showlegendkey/) का समर्थन करती है, और आप इन्हें चालू या बंद कर सकते हैं।

**क्या प्रस्तुति को PDF, HTML, या छवियों में निर्यात करने पर डेटा टेबल संरक्षित रहेगा?**

हाँ। Aspose.Slides चार्ट को स्लाइड के हिस्से के रूप में रेंडर करता है, इसलिए निर्यात किए गए [PDF](/slides/hi/net/convert-powerpoint-to-pdf/)/[HTML](/slides/hi/net/convert-powerpoint-to-html/)/[image](/slides/hi/net/convert-powerpoint-to-png/) में चार्ट उसके डेटा टेबल के साथ शामिल होता है।

**क्या टेम्पलेट फ़ाइल से आए चार्ट के लिए डेटा टेबल समर्थित हैं?**

हाँ। किसी भी चार्ट के लिए जो मौजूदा प्रस्तुति या टेम्पलेट से लोड किया गया है, आप चार्ट की प्रॉपर्टीज़ का उपयोग करके जाँच और बदल सकते हैं कि डेटा टेबल [is shown](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chart/hasdatatable/) है या नहीं।

**मैं किसी फ़ाइल में कौन से चार्ट डेटा टेबल सक्षम हैं, इसे जल्दी से कैसे पता लगा सकता हूँ?**

प्रत्येक चार्ट की उस प्रॉपर्टी की जाँच करें जो दर्शाती है कि डेटा टेबल [is shown](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chart/hasdatatable/) है या नहीं, और स्लाइड्स के माध्यम से इटरेट करके उन चार्टों की पहचान करें जहाँ यह सक्षम हो।