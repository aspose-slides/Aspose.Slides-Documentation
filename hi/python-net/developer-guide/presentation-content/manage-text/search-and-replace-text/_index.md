---
title: PowerPoint प्रस्तुतियों में Python के साथ टेक्स्ट खोजें और बदलें
linktitle: टेक्स्ट खोजें और बदलें
type: docs
weight: 55
url: /hi/python-net/search-and-replace-text/
keywords:
- टेक्स्ट खोजें
- टेक्स्ट हाइलाइट करें
- टेक्स्ट बदलें
- रेगुलर एक्सप्रेशन
- टेक्स्ट फ्रेम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint प्रस्तुतियों में टेक्स्ट को खोजें, हाइलाइट करें और बदलें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET व्यक्तिगत टेक्स्ट फ्रेम में या पूरी प्रस्तुति में टेक्स्ट को खोजने, हाइलाइट करने और बदलने में सक्षम है। ये सुविधाएँ समीक्षा, हटाना, शब्दावली जाँच, टेम्प्लेट सफाई और अन्य स्वचालित दस्तावेज़‑प्रसंस्करण कार्यप्रवाहों के लिए उपयोगी हैं।

नीचे दिए गए पहले उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करते हैं, जिसमें पहले स्लाइड पर एकल टेक्स्ट बॉक्स है जिसमें निम्नलिखित टेक्स्ट है:

![Sample text](sample_text.png)

## **खोज का दायरा चुनें**

एक ऑपरेशन को एक टेक्स्ट फ्रेम तक सीमित करने के लिए [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) पर विधियों का उपयोग करें। प्रस्तुति में सभी लागू टेक्स्ट को प्रोसेस करने के लिए [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) पर विधियों का उपयोग करें।

| ऑपरेशन | एक टेक्स्ट फ्रेम | पूरी प्रस्तुति |
|---|---|---|
| Highlight literal text | [TextFrame.highlight_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/highlight_text/) |
| Highlight regular-expression matches | [TextFrame.highlight_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/highlight_regex/) |
| Replace literal text | [TextFrame.replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/replace_text/) |
| Replace regular-expression matches | [TextFrame.replace_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/replace_regex/) |

## **टेक्स्ट मिलान कॉन्फ़िगर करें**

शाब्दिक-टेक्स्ट ऑपरेशनों के लिए, मिलानों को नियंत्रित करने के लिए [TextSearchOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/) का उपयोग करें:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/whole_words_only/) मिलानों को पूर्ण शब्दों तक सीमित करता है।
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/case_sensitive/) यह नियंत्रित करता है कि अक्षर केस का मिलान आवश्यक है या नहीं।
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/include_notes/) प्रस्तुति‑स्तरीय खोज, प्रतिस्थापन और हाइलाइटिंग ऑपरेशनों में स्लाइड नोट्स को शामिल करता है।

रेगुलर‑एक्सप्रेशन ऑपरेशनों में पैटर्न स्ट्रिंग का उपयोग किया जाता है, इसलिए केस‑सेंसिटिविटी और शब्द‑सीमाएँ जैसी नियम अभिव्यक्ति द्वारा परिभाषित होते हैं।

## **टेक्स्ट फ्रेम के मालिक की पहचान करें**

सामान्य टेक्स्ट‑प्रसंस्करण वर्कफ़्लो अक्सर खोज, प्रतिस्थापन, मान्यकरण, या निर्यात के दौरान एक [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) प्राप्त करते हैं। टेक्स्ट फ्रेम के मालिक को निर्धारित करने के लिए [TextFrame.parent_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_shape/) और [TextFrame.parent_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_cell/) का उपयोग करें।

अपेक्षित मान मालिक पर निर्भर करते हैं:

| टेक्स्ट फ्रेम मालिक | `parent_shape` | `parent_cell` |
|---|---|---|
| AutoShape या अन्य टेक्स्ट‑समाहित आकार | मालिक [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) | `None` |
| एक तालिका सेल | `None` | मालिक [Cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/) |

दोनों गुण केवल‑पढ़ने योग्य नेविगेशन गुण हैं। इन्हें पढ़ने से टेक्स्ट फ्रेम नहीं चलता और न ही उसका मालिक बदलता है। सामान्य कोड को दोनों मानों के `None` होने की जाँच करनी चाहिए और यह संभालना चाहिए कि दोनों मालिक उपलब्ध न हों।

निम्न उदाहरण में [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/hi/python-net/aspose.slides.util/slideutil/get_all_text_frames/) का उपयोग करके प्रस्तुति में टेक्स्ट फ्रेमों को इटरनेट किया गया है। आकारों के लिए, आकार का नाम, Python रन‑टाइम टाइप और समाविष्ट स्लाइड रिपोर्ट की जाती है। तालिका कोशिकाओं के लिए, शून्य‑आधारित स्तंभ और पंक्ति निर्देशांक तथा समाविष्ट स्लाइड रिपोर्ट की जाती है।

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

SmartArt सामग्री के लिए, [SmartArtNode.shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartartnode/shapes/) में आकारों को इटरनेट करें और प्रत्येक [ISmartArtShape.text_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/ismartartshape/text_frame/) तक पहुंचें। टेक्स्ट फ्रेम को उसके संबंधित आकार से [TextFrame.parent_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_shape/) के माध्यम से ट्रेस किया जा सकता है, जबकि [TextFrame.parent_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_cell/) `None` है। इसलिए, उदाहरण में आकार शाखा SmartArt नोड्स से टेक्स्ट भी संभालती है।

## **टेक्स्ट हाइलाइट करें**

एक टेक्स्ट फ्रेम में शाब्दिक‑टेक्स्ट मिलानों को हाइलाइट करने के लिए [TextFrame.highlight_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_text/) विधि का उपयोग करें। खोज को नियंत्रित करने के लिए [TextSearchOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/) पास करें।

नीचे का कोड उदाहरण अक्षर **"try"** की सभी आवृत्तियों को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # टेक्स्ट फ्रेम में "try" की हर उपस्थिति को हाइलाइट करें.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # केवल पूर्ण शब्द "to" को हाइलाइट करें.
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![हाइलाइट किया गया टेक्स्ट](highlighted_text.png)

## **रेगुलर एक्सप्रेशन का उपयोग करके टेक्स्ट हाइलाइट करें**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_regex/) विधि एक रेगुलर एक्सप्रेशन द्वारा पाए गए टेक्स्ट मिलानों को एक टेक्स्ट फ्रेम में हाइलाइट करती है।

निम्न कोड सभी सात या अधिक अक्षरों वाले शब्दों को हाइलाइट करता है:

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

![रेगुलर एक्सप्रेशन का उपयोग करके हाइलाइट किया गया टेक्स्ट](highlighted_text_using_regex.png)

## **पूरा प्रस्तुति में टेक्स्ट हाइलाइट करें**

[Presentation.highlight_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/highlight_text/) और [Presentation.highlight_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/highlight_regex/) का उपयोग करके प्रस्तुति में सभी लागू टेक्स्ट फ्रेमों को खोजें। निम्न उदाहरण में एक शाब्दिक शब्द और सभी ई‑मेल पते हाइलाइट किए गए हैं:

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

## **टेक्स्ट फ्रेम में टेक्स्ट बदलें**

शाब्दिक टेक्स्ट के लिए [TextFrame.replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_text/) और पैटर्न‑आधारित प्रतिस्थापन के लिए [TextFrame.replace_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_regex/) का उपयोग करें। ये विधियाँ मौजूदा टेक्स्ट फ्रेम के भीतर मिले टेक्स्ट को अपडेट करती हैं, जिससे आसपास के भाग का फॉर्मेट बना रहता है और फ्रेम को साधारण स्ट्रिंग से पुनःनिर्मित नहीं किया जाता।

निम्न उदाहरण एक वर्तनी रूपांतर को मानकीकृत करता है और फिर संस्करण लेबल बदलता है:

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

यदि कोई मिलान विभिन्न फॉर्मेट वाले भागों को कवर करता है, तो आउटपुट की जाँच करें कि किस फॉर्मेट को प्रतिस्थापन टेक्स्ट पर लागू करना है।

## **पूरा प्रस्तुति में टेक्स्ट बदलें**

[Presentation.replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/replace_text/) और [Presentation.replace_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/replace_regex/) का उपयोग करके वही ऑपरेशनों को पूरी प्रस्तुति में लागू करें। यह टेम्प्लेट सफाई, शब्दावली अपडेट और हटाने के लिए उपयोगी है।

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

**मैं पूरी प्रस्तुति के बजाय केवल एक टेक्स्ट बॉक्स कैसे खोज सकता हूँ?**

आकार के टेक्स्ट फ्रेम को प्राप्त करें और उस टेक्स्ट फ्रेम पर [TextFrame.highlight_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_text/), या [TextFrame.replace_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_regex/) को कॉल करें। प्रस्तुति‑स्तरीय विधियां सभी लागू टेक्स्ट फ्रेमों को प्रोसेस करती हैं।

**मैं पूर्ण शब्दों को सही बड़े‑छोटे अक्षरों के साथ कैसे मिलान कर सकता हूँ?**

[TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/whole_words_only/) और [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/case_sensitive/) को `True` पर सेट करें, और विकल्पों को शाब्दिक‑टेक्स्ट हाइलाइट या प्रतिस्थापन विधि में पास करें। रेगुलर एक्सप्रेशनों के लिए, पैटर्न स्वयं में शब्द‑सीमाएँ और केस‑सेंसिटिविटी तय करें।

**क्या खोज और प्रतिस्थापन में स्लाइड नोट्स का टेक्स्ट शामिल हो सकता है?**

हाँ। प्रस्तुति‑स्तरीय शाब्दिक‑टेक्स्ट ऑपरेशन का उपयोग करते समय [TextSearchOptions.include_notes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/include_notes/) को `True` पर सेट करें।

**क्या टेक्स्ट बदलने से उसका फ़ॉर्मेटिंग बरकरार रहता है?**

[TextFrame.replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_text/) और [TextFrame.replace_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/replace_regex/) मौजूदा टेक्स्ट फ्रेम के भीतर मिले टेक्स्ट को संशोधित करती हैं और आसपास के भाग का फॉर्मेटिंग बनाए रखती हैं। यदि कोई मिलान विभिन्न फॉर्मेट वाले भागों को कवर करता है, तो परिणाम की जाँच करें ताकि प्रतिस्थापन इच्छित शैली का उपयोग करे।