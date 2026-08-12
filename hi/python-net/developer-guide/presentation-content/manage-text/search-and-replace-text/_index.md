---
title: Python में PowerPoint प्रस्तुतियों में टेक्स्ट खोजें और बदलें
linktitle: टेक्स्ट खोजें और बदलें
type: docs
weight: 55
url: /hi/python-net/search-and-replace-text/
keywords:
- टेक्स्ट खोजें
- टेक्स्ट हाइलाइट करें
- टेक्स्ट बदलें
- नियमित अभिव्यक्ति
- टेक्स्ट फ्रेम
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint प्रस्तुतियों में टेक्स्ट खोजें, हाइलाइट करें और बदलें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET एक व्यक्तिगत टेक्स्ट फ्रेम या पूरी प्रेजेंटेशन में टेक्स्ट को खोज, हाइलाइट और बदल सकता है। ये क्षमताएँ समीक्षा, रीडैक्शन, शब्दावली जांच, टेम्पलेट सफाई और अन्य स्वचालित दस्तावेज़-प्रसंस्करण कार्यप्रवाहों के लिए उपयोगी हैं।

नीचे पहले उदाहरणों में हम "sample.pptx" नामक फ़ाइल का उपयोग करते हैं, जिसमें पहली स्लाइड पर एक टेक्स्ट बॉक्स होता है जिसमें निम्नलिखित टेक्स्ट है:

![Sample text](sample_text.png)

## **खोज परिधि चुनें**

एक ऑपरेशन को एक टेक्स्ट फ्रेम तक सीमित करने के लिए [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) पर मेथड्स का उपयोग करें। सभी लागू टेक्स्ट को प्रोसेस करने के लिए [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) पर मेथड्स का उपयोग करें।

| ऑपरेशन | एक टेक्स्ट फ्रेम | पूरी प्रेजेंटेशन |
|---|---|---|
| शाब्दिक टेक्स्ट को हाइलाइट करें | [TextFrame.highlight_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/highlight_text/) |
| नियमित-व्यक्तिकरण (regex) मैच को हाइलाइट करें | [TextFrame.highlight_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/highlight_regex/) |
| शाब्दिक टेक्स्ट को बदलें | [TextFrame.replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/replace_text/) |
| नियमित-व्यक्तिकरण (regex) मैच को बदलें | [TextFrame.replace_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/replace_regex/) |

## **पाठ मिलान कॉन्फ़िगर करें**

शाब्दिक-टेक्स्ट संचालन के लिए, मिलान को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/) का उपयोग करें:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/whole_words_only/) मैच को पूर्ण शब्दों तक सीमित करता है।
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/case_sensitive/) नियंत्रित करता है कि क्या अक्षर केस मेल खानी चाहिए।
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/include_notes/) प्रेजेंटेशन-स्तर की खोज, प्रतिस्थापन और हाइलाइटिंग ऑपरेशनों में स्लाइड नोट्स को शामिल करता है।

नियमित-व्यक्तिकरण (regex) संचालन एक पैटर्न स्ट्रिंग का उपयोग करता है, इसलिए केस संवेदनशीलता और शब्द सीमाओं जैसे मिलान नियम अभिव्यक्ति द्वारा परिभाषित होते हैं।

## **पाठ को हाइलाइट करें**

एक टेक्स्ट फ्रेम में शाब्दिक-टेक्स्ट मैच को हाइलाइट करने के लिए [TextFrame.highlight_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_text/) मेथड का उपयोग करें। खोज को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/) पास करें।

नीचे का कोड उदाहरण **"try"** अक्षरों की सभी घटनाओं को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # टेक्स्ट फ्रेम में "try" की प्रत्येक उपस्थिति को हाइलाइट करें।
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # केवल पूर्ण शब्द "to" को हाइलाइट करें।
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![The highlighted text](highlighted_text.png)

## **नियमित अभिव्यक्तियों का उपयोग करके पाठ को हाइलाइट करें**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_regex/) मेथड एक टेक्स्ट फ्रेम में नियमित अभिव्यक्ति द्वारा पाए गए टेक्स्ट मैच को हाइलाइट करता है।

निम्नलिखित कोड सात या उससे अधिक अक्षर वाले सभी शब्दों को हाइलाइट करता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

परिणाम:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **प्रेजेंटेशन भर में पाठ को हाइलाइट करें**

[Presentation.highlight_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/highlight_text/) और [Presentation.highlight_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/highlight_regex/) का उपयोग करके प्रेजेंटेशन के सभी लागू टेक्स्ट फ्रेम को खोजें। नीचे का उदाहरण एक शाब्दिक शब्द और सभी ईमेल पते को हाइलाइट करता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **टेक्स्ट फ्रेम में पाठ को बदलें**

शाब्दिक टेक्स्ट के लिए [TextFrame.replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_text/) और पैटर्न-आधारित प्रतिस्थापन के लिए [TextFrame.replace_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_regex/) का उपयोग करें। ये मेथड मौजूदा टेक्स्ट फ्रेम के भीतर मिले हुए टेक्स्ट को अपडेट करते हैं, जिससे आसपास के फ़ॉर्मेटिंग को पुनर्निर्माण के बिना बरकरार रखा जाता है।

नीचे का उदाहरण वर्तनी वैरिएंट को मानकीकृत करता है और फिर संस्करण लेबल को बदलता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

यदि कोई मैच अलग-अलग फ़ॉर्मेटिंग वाले हिस्सों को कवर करता है, तो आउटपुट की समीक्षा करें ताकि यह पुष्टि की जा सके कि प्रतिस्थापन टेक्स्ट पर कौन सा फ़ॉर्मेट लागू होना चाहिए।

## **प्रेजेंटेशन भर में पाठ को बदलें**

[Presentation.replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/replace_text/) और [Presentation.replace_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/replace_regex/) का उपयोग करके प्रेजेंटेशन भर में समान ऑपरेशन लागू करें। यह टेम्पलेट सफाई, शब्दावली अपडेट और रीडैक्शन के लिए उपयोगी है।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरी प्रेजेंटेशन के बजाय केवल एक टेक्स्ट बॉक्स में कैसे खोज कर सकता हूँ?**

शेप के टेक्स्ट फ्रेम को प्राप्त करें और उस टेक्स्ट फ्रेम पर [TextFrame.highlight_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_text/), या [TextFrame.replace_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_regex/) को कॉल करें। प्रेजेंटेशन-स्तर के मेथड सभी लागू टेक्स्ट फ्रेम को प्रोसेस करते हैं।

**मैं पूर्ण शब्दों को सही कैपिटलाइज़ेशन के साथ कैसे मिलाऊँ?**

[TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/whole_words_only/) और [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/case_sensitive/) को `True` सेट करें, और इन विकल्पों को शाब्दिक-टेक्स्ट हाइलाइट या प्रतिस्थापन मेथड में पास करें। नियमित अभिव्यक्तियों के लिए, पैटर्न में शब्द सीमाएँ और केस संवेदनशीलता परिभाषित करें।

**क्या खोज और प्रतिस्थापन स्लाइड नोट्स में टेक्स्ट को शामिल कर सकते हैं?**

हाँ। प्रेजेंटेशन-स्तर के शाब्दिक-टेक्स्ट ऑपरेशन का उपयोग करते समय [TextSearchOptions.include_notes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/include_notes/) को `True` सेट करें।

**क्या टेक्स्ट को बदलने से उसका फ़ॉर्मेटिंग बना रहता है?**

[TextFrame.replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_text/) और [TextFrame.replace_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_regex/) मौजूदा टेक्स्ट फ्रेम के भीतर मिले हुए टेक्स्ट को संशोधित करते हैं और आसपास के फ़ॉर्मेटिंग को बरकरार रखते हैं। यदि कोई मैच अलग-अलग फ़ॉर्मेटिंग वाले हिस्सों को कवर करता है, तो परिणाम की जांच करें ताकि यह सुनिश्चित हो सके कि प्रतिस्थापन वांछित शैली का उपयोग कर रहा है।