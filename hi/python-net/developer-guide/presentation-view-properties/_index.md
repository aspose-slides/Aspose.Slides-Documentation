---
title: Python में प्रस्तुति दृश्य गुणों को प्राप्त करें और अपडेट करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/python-net/presentation-view-properties/
keywords: 
- दृश्य गुण
- सामान्य दृश्य
- आउटलाइन सामग्री
- आउटलाइन आइकन
- वर्टिकल स्प्लिटर स्नेप
- एकल दृश्य
- बार स्थिति
- आयाम आकार
- ऑटो समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में सामान्य दृश्य लेआउट, स्लाइड और नोट्स ज़ूम, ग्रिड अंतराल, और टिप्पणी दृश्यता को कॉन्फ़िगर करने के लिए .NET के माध्यम से Python के लिए Aspose.Slides का उपयोग करें।"
---
## **परिचय**

PowerPoint के सामान्य दृश्य में, स्लाइड थंबनेल या आउटलाइन के लिए एक साइड पेन और नीचे नोट्स पेन के बीच दिखाई देती है। Aspose.Slides for Python via .NET प्रस्तुति की सहेजी गई संपादन प्राथमिकताओं को [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) के माध्यम से प्रदान करता है। इनमें पेन लेआउट, ज़ूम स्तर, ग्रिड अंतराल, और टिप्पणी दृश्यमानता शामिल हैं।

## **NormalViewProperties के बारे में**

Use [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) to access the [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/) object. [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) controls whether icons appear beside slide titles in the outline. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) lets the side pane snap to its minimized state when the user narrows it. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) indicates a preference for displaying one pane in the full window.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) controls the divider between the side pane and the slide. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) controls the divider above the notes pane. Both accept a [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) value of `MINIMIZED`, `MAXIMIZED`, or `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![एक वैचारिक संपादक एक साइड पैनल, स्लाइड क्षेत्र और निचले क्षेत्र को लेबल किए हुए वर्टिकल और हॉरिज़ॉन्टल स्प्लिटर के साथ अलग करता है।](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*सामान्य दृश्य में, वर्टिकल डिवाइडर साइड पेन की चौड़ाई को नियंत्रित करता है। हॉरिज़ॉन्टल डिवाइडर नोट्स पेन के ऊपर की जगह को नियंत्रित करता है।*
<!-- visual-explanation:presentation-view-properties:end -->

## **NormalViewProperties को पुनर्स्थापित करने के बारे में**

When a divider is restored, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) supplies the saved size of the side pane and [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) supplies the saved size of the upper slide area. Both expose [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). Its [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) property accepts a percentage from 0 to 100, and [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) controls whether the editor adjusts the size when the window is resized.

This example updates an existing presentation. It restores the horizontal divider, sets [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) to 80% with automatic adjustment enabled, and maximizes the vertical divider. It also enables [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) for outline view.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) and [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) store independent zoom settings for the editor. These settings do not affect slide dimensions, slide-show playback, or image export resolution.

This example opens an existing presentation and enables [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) to fit the slide to the editing window. For the notes page, it disables automatic scaling and sets [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) to a fixed 80% zoom.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **ग्रिड अंतराल सेट करें**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) sets the distance between editing grid lines throughout the presentation. It takes a positive value in points, with 72 points per inch. This example prints the current spacing in an existing presentation and saves a quarter-inch grid by setting the interval to 18 points.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

The grid repeats at a fixed interval. [Drawing guides](/slides/hi/python-net/drawing-guides/) mark individual horizontal or vertical positions. Both are editing aids and appear only in editors that display them. Slide shows and exports to PDF, images, or SVG omit them.

## **प्रस्तुति खोलते समय टिप्पणी दिखाएँ या छुपाएँ**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) stores a preference that compatible editors use when opening the presentation. For an existing presentation with comments, this example prints the current setting and saves a copy with comments hidden. It also sets [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) to [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) so the copy opens in slide view.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Hiding comments preserves their text, authors, positions, replies, and statuses. To change the comments themselves, see [Presentation Comments](/slides/hi/python-net/presentation-comments/). Export settings control whether comments appear in PDF, HTML, images, notes, or handouts.

## **FAQ**

**प्रस्तुति को फिर से खोलने पर ग्रिड क्यों छिपा रहता है?**

प्रस्तुति ग्रिड अंतराल को सहेजती है। ग्रिड देखने के लिए, संपादक में ग्रिड दृश्यमानता को सक्षम करें।

**ड्रॉइंग गाइड्स को साफ़ करने से ग्रिड अंतराल बदलता है क्या?**

नहीं। गाइड जोड़ने, ले जाने या साफ़ करने से ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या प्रस्तुति के विभिन्न हिस्सों में अलग-अलग दृश्य सेटिंग्स हो सकती हैं?**

नहीं। [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) पूरी प्रस्तुति पर लागू होता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग दृश्य सेटिंग्स सहेज सकता हूँ?**

फ़ाइल सभी के लिए एक सेट दृश्य गुण सहेजती है। एक संपादक उपयोगकर्ता की स्थानीय प्राथमिकताओं को भी लागू कर सकता है।

**क्या मैं टेम्प्लेट में दृश्य सेटिंग्स सहेज सकता हूँ?**

हां। टेम्प्लेट से बनाई गई प्रस्तुतियों में उसके सहेजे हुए दृश्य सेटिंग्स विरासत में मिलते हैं।