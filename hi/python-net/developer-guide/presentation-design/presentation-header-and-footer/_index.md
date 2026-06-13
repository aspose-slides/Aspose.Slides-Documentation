---
title: Python के साथ प्रस्तुति हेडर और फ़ूटर प्रबंधित करें
linktitle: हेडर और फ़ूटर
type: docs
weight: 140
url: /hi/python-net/presentation-header-and-footer/
keywords:
- हेडर
- हेडर पाठ
- फ़ूटर
- फ़ूटर पाठ
- हेडर सेट करें
- फ़ूटर सेट करें
- हैंडआउट
- नोट्स
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में हेडर और फ़ूटर को जोड़ने और अनुकूलित करने के लिए .NET के माध्यम से Python के लिए Aspose.Slides का उपयोग करें, जिससे पेशेवर रूप मिले।"
---
## **अवलोकन**

Aspose.Slides for Python आपको प्रस्तुति में हेडर और फ़ूटर प्लेसहोल्डर्स को सटीक दायरे के साथ नियंत्रित करने देता है। स्लाइड्स पर फ़ूटर टेक्स्ट, तिथि/समय, और स्लाइड नंबर मास्टर लेवल से प्रबंधित होते हैं और इन्हें वैश्विक रूप से लागू या प्रत्येक स्लाइड के अनुसार समायोजित किया जा सकता है। हेडर नोट्स और हैंडआउट्स में समर्थित हैं, जहाँ आप दृश्यता को टॉगल कर सकते हैं और हेडर, फ़ूटर, तिथि/समय, और पेज नंबर के लिए टेक्स्ट सेट कर सकते हैं, जो समर्पित हेडर & फ़ूटर प्रबंधक के माध्यम से मास्टर नोट्स स्लाइड या व्यक्तिगत नोट्स स्लाइड्स पर किया जाता है। यह लेख इन प्लेसहोल्डर्स को अपडेट करने और आपके डेक में लगातार बदलावों को प्रसारित करने के प्रमुख पैटर्न को रेखांकित करता है।

## **हेडर और फ़ूटर पाठ को प्रबंधित करें**

इस अनुभाग में, आप सीखेंगे कि प्रस्तुति में हेडर और फ़ूटर सामग्री को कैसे प्रबंधित किया जाए—फ़ूटर, तिथि और समय, और स्लाइड नंबर को सक्षम या संशोधित करना। हम इन सेटिंग्स को लागू करने के दायरे (पूरी प्रस्तुति, व्यक्तिगत स्लाइड्स, और नोट्स/हैंडआउट दृश्य) को संक्षेप में रेखांकित करेंगे और Aspose.Slides API का उपयोग करके उन्हें तेज़ और लगातार अपडेट करने का तरीका दिखाएंगे।

नीचे दिया गया कोड उदाहरण एक प्रस्तुति खोलता है, फ़ूटर टेक्स्ट को सक्षम और सेट करता है, मास्टर नोट्स स्लाइड पर हेडर टेक्स्ट को अपडेट करता है, और फ़ाइल को सहेजता है।

```py
import aspose.slides as slides

# हेडर टेक्स्ट सेट करने वाला फ़ंक्शन।
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# प्रस्तुति लोड करें।
with slides.Presentation("sample.pptx") as presentation:
    # फ़ूटर सेट करें।
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # हेडर तक पहुँचें और अपडेट करें।
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # प्रस्तुति सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **नोट्स स्लाइड्स पर हेडर और फ़ूटर को प्रबंधित करें**

इस अनुभाग में, आप Aspose.Slides में नोट्स स्लाइड्स के लिए हेडर और फ़ूटर को विशेष रूप से कैसे प्रबंधित किया जाए, सीखेंगे। हम संबंधित प्लेसहोल्डर्स को सक्षम करने, फ़ूटर, तिथि/समय, और पेज नंबर के लिए टेक्स्ट सेट करने, और इन बदलावों को नोट्स मास्टर और व्यक्तिगत नोट्स पेजों में लगातार लागू करने को कवर करेंगे।

नीचे दिए गए चरणों का पालन करें:

1. एक प्रस्तुति फ़ाइल लोड करें।
1. Get the master notes slide and its [हेडर और फ़ूटर प्रबंधक](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslideheaderfootermanager/)।
1. मास्टर नोट्स स्लाइड पर, मास्टर और सभी चाइल्ड नोट्स स्लाइड्स के लिए हेडर, फ़ूटर, स्लाइड नंबर, और तिथि-समय की दृश्यता सक्षम करें।
1. मास्टर नोट्स स्लाइड पर, मास्टर और सभी चाइल्ड नोट्स स्लाइड्स के लिए हेडर, फ़ूटर, और तिथि-समय का टेक्स्ट सेट करें।
1. पहली प्रस्तुति स्लाइड के लिए नोट्स स्लाइड और उसका [हेडर और फ़ूटर प्रबंधक](https://reference.aspose.com/slides/hi/python-net/aspose.slides/notesslideheaderfootermanager/) प्राप्त करें।
1. केवल इस पहली नोट्स स्लाइड के लिए, हेडर, फ़ूटर, स्लाइड नंबर, और तिथि-समय को दृश्य सुनिश्चित करें (जो बंद हों उन्हें चालू करें)।
1. केवल इस पहली नोट्स स्लाइड के लिए, हेडर, फ़ूटर, और तिथि-समय का टेक्स्ट सेट करें।
1. प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें।

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर, फ़ूटर, स्लाइड नंबर, और तिथि/समय प्लेसहोल्डर्स को दृश्यमान बनाएं।
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर, फ़ूटर, और तिथि/समय प्लेसहोल्डर्स पर टेक्स्ट सेट करें।
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # केवल पहले नोट्स स्लाइड के लिए हेडर, फ़ूटर, स्लाइड नंबर, और तिथि/समय सेटिंग्स बदलें।
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # सुनिश्चित करें कि हेडर, फ़ूटर, स्लाइड नंबर, और तिथि/समय प्लेसहोल्डर्स दृश्यमान हैं।
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # नोट्स स्लाइड हेडर, फ़ूटर, और तिथि/समय प्लेसहोल्डर्स पर टेक्स्ट सेट करें।
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # प्रस्तुति सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियमित स्लाइड्स में "header" जोड़ सकता हूँ?**

PowerPoint में, "Header" केवल नोट्स और हैंडआउट्स के लिए उपलब्ध है; सामान्य स्लाइड्स में समर्थित तत्व फ़ूटर, तिथि/समय, और स्लाइड नंबर होते हैं। Aspose.Slides में यह वही सीमाएँ हैं: हेडर केवल नोट्स/हैंडआउट के लिए, और स्लाइड्स पर—फ़ूटर/DateTime/SlideNumber।

**यदि लेआउट में फ़ूटर क्षेत्र नहीं है—क्या मैं उसकी दृश्यता सक्रिय कर सकता हूँ?**

हाँ। हेडर/फ़ूटर प्रबंधक के माध्यम से दृश्यता जाँचें और आवश्यक होने पर इसे सक्षम करें। ये API संकेतक और मेथड्स उन मामलों के लिए डिज़ाइन किए गए हैं जब प्लेसहोल्डर गायब या छिपा हो।

**मैं स्लाइड नंबर को 1 के अलावा अन्य मान से शुरू कैसे करूँ?**

प्रस्तुति का [first slide number](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/first_slide_number/) सेट करें; उसके बाद सभी क्रमांक पुनः गणना किए जाते हैं। उदाहरण के रूप में, आप 0 या 10 से शुरू कर सकते हैं, और शीर्षक स्लाइड पर नंबर को छिपा सकते हैं।

**PDF/छवियों/HTML में निर्यात करते समय हेडर/फ़ूटर क्या होते हैं?**

वे प्रस्तुति के सामान्य टेक्स्ट एलिमेंट्स के रूप में रेंडर होते हैं। अर्थात, यदि तत्व स्लाइड्स/नोट्स पेजों पर दृश्य हैं, तो वे आउटपुट फ़ॉर्मेट में बाकी सामग्री के साथ प्रदर्शित होंगे।