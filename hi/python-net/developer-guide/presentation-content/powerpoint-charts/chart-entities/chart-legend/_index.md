---
title: Python के साथ प्रस्तुतियों में चार्ट लेजेंड को कस्टमाइज़ करें
linktitle: चार्ट लेजेंड
type: docs
url: /hi/python-net/chart-legend/
keywords:
- चार्ट लेजेंड
- लेजेंड स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python को .NET के माध्यम से उपयोग करके चार्ट लेजेंड को कस्टमाइज़ करें, जिससे पावरपॉइंट और OpenDocument प्रस्तुतियों को अनुकूलित किया जा सके, विशेष रूप से तैयार किए गए लेजेंड फ़ॉर्मेटिंग के साथ।"
---
## **Overview**

Aspose.Slides for Python चार्ट लेजेंड्स पर पूरी नियंत्रण प्रदान करता है ताकि आप डेटा लेबल्स को स्पष्ट और प्रस्तुति-तैयार बना सकें। आप लेजेंड को दिखा या छिपा सकते हैं, स्लाइड पर उसकी स्थिति चुन सकते हैं, और प्लॉट एरिया के साथ ओवरलैप से बचाने के लिए लेआउट समायोजित कर सकते हैं। API आपको टेक्स्ट और मार्कर्स को स्टाइल करने, पैडिंग और बैकग्राउंड को फाइन‑ट्यून करने, तथा बॉर्डर और फ़िल्स को अपने थीम के अनुसार फ़ॉर्मेट करने की अनुमति देती है। डेवलपर व्यक्तिगत लेजेंड एंट्रीज़ तक पहुँच सकते हैं, उन्हें पुनःनामित या फ़िल्टर कर सकते हैं, जिससे केवल सबसे प्रासंगिक सीरीज़ दिखाई देती है। इन क्षमताओं के साथ, आपके चार्ट पढ़ने योग्य, सुसंगत और आपकी प्रस्तुति के डिज़ाइन मानकों के अनुरूप रहते हैं।

## **Legend Positioning**

Aspose.Slides का उपयोग करके आप जल्दी से निर्धारित कर सकते हैं कि चार्ट लेजेंड कहां दिखाई देगा और वह आपके स्लाइड लेआउट में कैसे फिट होगा। जानें कि लेजेंड को सटीक रूप से कैसे रखें।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) class.
2. Get a reference to the slide.
3. Add a chart to the slide.
4. Set the legend properties.
5. Save the presentation as a PPTX file.

नीचे दिए गए उदाहरण में, हम चार्ट लेजेंड की स्थिति और आकार सेट करते हैं:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation क्लास का एक इंस्टेंस बनाएं।
with slides.Presentation() as presentation:

    # स्लाइड का रेफ़रेंस प्राप्त करें।
    slide = presentation.slides[0]

    # स्लाइड में एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # लेजेंड प्रॉपर्टीज़ सेट करें।
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # प्रेज़ेंटेशन को डिस्क पर सहेजें।
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Set the Legend Font Size**

एक चार्ट का लेजेंड उतना ही पठनीय होना चाहिए जितना कि वह डेटा जिसे वह समझाता है। यह अनुभाग दिखाता है कि लेजेंड का फ़ॉन्ट आकार कैसे समायोजित करें ताकि आप अपनी प्रस्तुति की टाइपोग्राफी से मेल करा सकें और एक्सेसेबिलिटी में सुधार कर सकें।

1. Instantiate the [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) class.
2. Create a chart.
3. Set the font size.
4. Save the presentation to disk.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Set the Font Size for a Legend Entry**

Aspose.Slides आपको चार्ट लेजेंड्स की उपस्थिति को व्यक्तिगत एंट्रीज़ को फ़ॉर्मेट करके फाइन‑ट्यून करने की अनुमति देता है। नीचे दिया गया उदाहरण दिखाता है कि कैसे एक विशिष्ट लेजेंड आइटम को लक्षित किया जाए और उसकी प्रॉपर्टीज़ सेट की जाए बिना बाकी लेजेंड को बदले।

1. Instantiate the [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) class.
2. Create a chart.
3. Access a legend entry.
4. Set the entry properties.
5. Save the presentation to disk.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Yes. Use the non-overlay mode ([overlay](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/legend/overlay/) = `false`); in this case, the plot area will shrink to accommodate the legend.

**Can I make multi-line legend labels?**

Yes. Long labels wrap automatically when space is insufficient; forced line breaks are supported via newline characters in the series name.

**How do I make the legend follow the presentation theme’s color scheme?**

Do not set explicit colors/fills/fonts for the legend or its text. They will then inherit from the theme and update correctly when the design changes।