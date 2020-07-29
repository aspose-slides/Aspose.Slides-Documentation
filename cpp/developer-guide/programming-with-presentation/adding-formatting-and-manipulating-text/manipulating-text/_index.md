---
title: Manipulating Text
type: docs
weight: 30
url: /cpp/manipulating-text/
---

## **Manipulating Text**
### **Importing HTML Text in Paragraphs**
This topic is also part of a series of topics about managing text paragraphs. Aspose.Slides for C++ has enhanced support for adding HTML text or saving paragraphs text to HTML. This article shows how to manage paragraphs to use HTML data and shows how developers can use this small yet powerful feature. To manage paragraph bullets using Aspose.Slides for C++:

- Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Access the desired slide in slide collection using the ISlide object.
- Add an autoshape to the selected slide.
- Add and access the ITextFrame of the added shape.
- Remove the default paragraph in the ITextFrame.
- Read the source HTML file in a TextReader.
- Create the first paragraph instance using the Paragraph class.
- Add the HTML file content in the read TextReader to the TextFrame's ParagraphCollection.
- Save the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ImportingHTMLText-ImportingHTMLText.cpp" >}}
### **Exporting Paragraphs Text to HTML**
Please follow the steps below to see how to export the paragraph text to HTML using Aspose.Slides for C++:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the desired presentation.
- Access the desired slide into the slide collection using ISlide object.
- Access the desired shape for which text need to be exported to HTML.
- Access the TextFrame of the accessed shape.
- Create an instance of StreamWriter and add the new HTML file.
- Export the desired number of paragraphs data by providing starting index to the StreamWriter.
  The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ExportingHTMLText-ExportingHTMLText.cpp" >}}
### **Using Custom Fonts without Installing them**
Aspose.Slides lets you load fonts for rendering in presentations without even installing them. This article shows how to load fonts from custom directories without installing them. Please follow the steps below to loading Fonts from external directories by using Aspose.Slides for C++ API:

- Create an instance of FontsLoader Class and call the static method LoadExternalFonts.
- Perform render the presentation.
- Clear the cache in the FontsLoader Class.

The implementation of the above is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UseCustomFonts-UseCustomFonts.cpp" >}}
### **Get Fonts Folder**
A new property has been added that returns folders where font files are searched. Those are folders that have been added with LoadExternalFonts method as well as system font folders.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetFontsFolders-GetFontsFolders.cpp" >}}
### **Specify Fonts Used With Presentation**
A new DocumentLevelFontSources property has been added to ILoadOptions interface. It allows to specify external fonts that are used with the presentation. Sample Code is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetFontsFolders-GetFontsFolders.cpp" >}}
### **Using Default Fonts for Rendering Presentation**
Aspose.Slides lets you set the default font fore rendering the presentation to PDF, XPS or thumbnails. This article shows how to define DefaultRegular
Font and DefaultAsian Font for use as default fonts. Please follow the steps below to loading fonts from external directories by using Aspose.Slides for C++ API:

1. Create an instance of LoadOptions.
1. Set the DefaultRegularFont to your desired font. In the following example, I have used Wingdings.
1. Set the DefaultAsianFont to your desired font. I have used Wingdings in following sample.
1. Load the presentation using Presentation and setting the load options.
1. Now, generate the slide thumbnail, PDF and XPS to verify the results.

The implementation of the above is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DefaultFonts-DefaultFonts.cpp" >}}
### **Managing Fonts inside Presentation**
Aspose.Slides now allows to replace any given font in presentation with new font. It allows to replace the font both explicitly or by setting font replacement rules. In this article we will see the examples of explicit font substitution as well as rule based font substitution. This article explains how to use font substitutions in different ways:

- Replacing Fonts Explicitly Inside Presentation.
- Rule based fonts replacement inside presentation.
#### **Replacing Fonts Explicitly**
To replace the fonts using explicit replacement following steps are used:

- Load thee desired presentation.
- Load the font that is to replaced inside presentation.
- Load the replacing font.
- Replace the fonts.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ReplaceFontsExplicitly-ReplaceFontsExplicitly.cpp" >}}
#### **Rule Based Fonts Replacement**
To replace the fonts by setting some rules of replacement following steps are used:

- Load thee desired presentation.
- Load the font that is to replaced inside presentation.
- Load the replacing font.
- Add rule for replacement.
- Add the rule to presentation font replacement rule collection.
- Generate the slide image to observe the effect.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RuleBasedFontsReplacement-RuleBasedFontsReplacement.cpp" >}}
#### **Managing Embedded Fonts**
Now, you can also work with embedded fonts. FontsManger class now offer, GetEmbeddedFonts() method that returns list of embedded fonts inside presentation. You can also remove any embedded font inside presentation if that is required by using RemoveEmbeddedFont() method exposed by FontsManager class. The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageEmbeddedFonts-ManageEmbeddedFonts.cpp" >}}
#### **Embed Fonts in Presentation**
A new property of embedding fonts has been added. To allow embedding fonts into Presentation the new EmbedFontCharacters enum and two overloads of AddEmbeddedFont method have been added. Using these methods and choosing the desired embedding rule (represented by EmbedFontCharacters enum), all fonts used in Presentation can be embedded. The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddEmbeddedFonts-AddEmbeddedFonts.cpp" >}}
#### **Managing Fonts Externally**
Now, you can also load fonts externally into byte array. FontsLoader class now offer, LoadExternalFont(byte[] data) method that allows to add fonts from binary data. The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SpecifyFontsUsedWithPresentation-SpecifyFontsUsedWithPresentation.cpp" >}}
### **Tabs and EffectiveTabs in Presentation**
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs collection includes all tabs (from Tabs collection and default tabs)
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) property shows distance between default tabs (3 and 4 in our example).
- EffectiveTabs.GetTabByIndex(index) with index = 0 will return first explicit tab (Position = 731), index = 1 - second tab (Position = 1241). If you try to get next tab with index = 2 it will return first default tab (Position = 1470) and etc.
- EffectiveTabs.GetTabAfterPosition(pos) used for getting next tabulation after some text. For example you have text: "Helloworld!". To render such text you should know where to start draw "world!". At first, you should calculate length of "Hello" in pixels and call GetTabAfterPosition with this value. You will get next tab position to draw "world!".
### **Setting the AutofitType property of text frame**
In this topic, we will explore the different formatting properties of text frame. This article covers how to Set the AutofitType property of text frame, anchor of text and rotating the text in presentation. Aspose.Slides for C++ allows developers to set AutofitType property of any text frame. AutofitType could be set to Normal or Shape. If set to Normal then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If AutofitType is set to shape, then shape will be modified such that only required text is contained in it. To set the AutofitType property of a text frame, please follow the steps below:

- Create an instance of Presentation class.
- Access the first slide.
- Add any shape to the slide.
- Access the TextFrame.
- Set the AutofitType of the TextFrame.
- Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}
### **Setting the anchor of TextFrame**
Aspose.Slides for C++ allows developers to Anchor of any TextFrame. TextAnchorType specifies that where is that text placed in the shape. TextAnchorType could be set to Top, Center, Bottom, Justified or Distributed. To set Anchor of any TextFrame, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Access the first slide.
- Add any shape to the slide.
- Access the TextFrame.
- Set TextAnchorType of the TextFrame.
- Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}
### **Setting text Rotation**
Aspose.Slides for C++ allows developers to rotate the text. Text could be set to appear as Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical or WordArtVerticalRightToLeft. To rotate the text of any TextFrame, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Access the first slide.
- Add any Shape to the slide.
- Access the TextFrame.
- Rotate the text.
- Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}
### **Setting custom rotation angle for textframe**
Aspose.Slides for C++ now supports, Setting custom rotation angle for textframe. In this topic, we will see with example how to set the RotationAngle property in Aspose.Slides. The new property RotationAngle has been added to IChartTextBlockFormat and ITextFrameFormat interfaces, allows to set the custom rotation angle for textframe. In order to set the RotationAngle property, Please follow the steps below:

- Create an instance of Presentation class.
- Add a chart on slide.
- Set RotationAngle property.
- Write the presentation as a PPTX file.

In the example given below, we set the RotationAngle property.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}
### **Line Spacing of a paragraph**
Aspose.Slides for C++ lets developers to set the properties of ParagraphFormat to deal with line spacing of the paragraph. The properties SpaceAfter, SpaceBefore and SpaceWithin could be set for different line spacing. This article explains how to set these properties of ParagraphFormat. Aspose.Slides for C++ provides a simple API for setting properties of ParagraphFormat:

- Load a presentation with an AutoShape having some text in it.
- Obtain a slide's reference by its index.
- Access the TextFrame.
- Access the Paragraph.
- Set properties of Paragraph.
- Save the presentation to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-LineSpacing-LineSpacing.cpp" >}}


### **Support to get effects by text-box paragraphs**
Aspose.Slides for C++ provides support for getting all animation effects applied to paragraphs of text frame (shape). Below is the sample code given.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetEffectsByTextParagraph-GetEffectsByTextParagraph.cpp" >}}

