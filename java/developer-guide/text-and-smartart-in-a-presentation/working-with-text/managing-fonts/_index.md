---
title: Managing Fonts
type: docs
weight: 20
url: /java/managing-fonts/
---

## **Managing Fonts inside Presentation**
{{% alert color="primary" %}} 

Aspose.Slides now allow replacing any given font in presentation with the new font. It allows replacing the font both explicitly or by setting font replacement rules. In this article, we will see the examples of explicit font substitution as well as rule-based font substitution.

{{% /alert %}} 
### **Replacing Fonts Explicitly Inside Presentation**
To replace the fonts using explicit replacement, following steps are used:

1. Load the desired presentation.
1. Load the font that is to replace inside the presentation.
1. Load the replacing font.
1. Replace the fonts.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ReplacingFontsExplicitlyInsidePresentation-ReplacingFontsExplicitlyInsidePresentation.java" >}}
### **Rule Based Fonts Replacement Inside Presentation**
To replace the fonts by setting some rules of replacement, following steps are used:

1. Load the desired presentation.
1. Load the font that is to replace inside the presentation.
1. Load the replacing font.
1. Add a rule for replacement.
1. Add the rule to presentation font replacement rule collection.
1. Generate the slide image to observe the effect.
### **Specify Fonts Used With Presentation**
A new DocumentLevelFontSources property has been added to ILoadOptions interface. It allows to specify external fonts that are used with the presentation. Sample Code is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingEmbeddedFonts-ManagingEmbeddedFonts.java" >}}
### **Managing Embedded Fonts**
Now, you can also work with embedded fonts. FontsManger class now offer, getEmbeddedFonts() method that returns a list of embedded fonts inside the presentation. You can also remove any embedded font inside presentation if that is required by using removeEmbeddedFont() method exposed by FontsManager class.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingEmbeddedFonts-ManagingEmbeddedFonts.java" >}}
### **Get Fonts Folder**
A new property has been added that returns folders where font files are searched. Those are folders that have been added with LoadExternalFonts method as well as system font folders.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-GetFontsFolders-GetFontsFolders.java" >}}
### **Embed Fonts in Presentation**
A new property of embedding fonts has been added. To allow embedding fonts into Presentation the new EmbedFontCharacters enum and two overloads of AddEmbeddedFont method have been added. Using these methods and choosing the desired embedding rule (represented by EmbedFontCharacters enum), all fonts used in Presentation can be embedded. The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-AddEmbeddedFonts-AddEmbeddedFonts.java" >}}
## **Managing Font Related Properties**
{{% alert color="primary" %}} 

Presentations usually contain both text and images. The text can be formatted in a various way, either to highlight specific sections and words or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for Java to configure the font properties of paragraphs of text on slides.

{{% /alert %}} 

To manage font properties of a paragraph using Aspose.Slides for Java:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by using its index.
1. Access the [Placeholder](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Placeholder) shapes in the slide and typecast them to [AutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/AutoShape).
1. Get the [Paragraph](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Paragraph) from the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame) exposed by [AutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/AutoShape).
1. Justify the paragraph.
1. Access a [Paragraph](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Paragraph)'s text [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion).
1. Define the font using [FontData](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/FontData) and set the **Font** of the text [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion) accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the [FillFormat](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/FillFormat) exposed by the [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion) object.
1. Save the modified presentation to a PPTX file.

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides. The screenshots that follow show the input file and how the code snippets change it. The code changes the font, the color, and the font style.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: The text in the input file**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: The same text with updated formatting**|
{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingFontRelatedProperties-ManagingFontRelatedProperties.java" >}}
## **Managing Font Family of Text**
{{% alert color="primary" %}} 

As mentioned in **Managing Font Related Properties**, a [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion) is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for Java to create a textbox with some text and then define a particular font, and various other properties of the font family category.

{{% /alert %}} 
### **Setting a Text's Font Properties**
To create a textbox and set font properties of the text in it:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its index.
1. Add an [AutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/AutoShape) of the type **Rectangle** to the slide.
1. Remove the fill style associated with the [AutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/AutoShape).
1. Access the of the [AutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/AutoShape)'s [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Add some text to the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Access the [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion) object associated with the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Define the font to be used for the [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion).
1. Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion) object.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: Text with some font properties set by Aspose.Slides for Java**|
{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingFontFamilyOfText-ManagingFontFamilyOfText.java" >}}
## **Using Custom Fonts without Installing them**
{{% alert color="primary" %}} 

Aspose.Slides let you load fonts for rendering in presentations without even installing them. This article shows how to load fonts from custom directories without installing them.

{{% /alert %}} 
### **Loading Fonts from External Directories**
To manage paragraph bullets using Aspose.Slides for Java:

1. Create an instance of [FontsLoader](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/FontsLoader) class and call the static method **loadExternalFonts**.
1. Perform renders the presentation.
1. Clear the cache in the [FontsLoader](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/FontsLoader) class.

The implementation of the above is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-UsingCustomFonts-UsingCustomFonts.java" >}}
## **Using Default Fonts for Rendering Presentation**
{{% alert color="primary" %}} 

Aspose.Slides let you set the default font for rendering the presentation to PDF, XPS or thumbnails. This article shows how to define **DefaultRegular Font** and **DefaultAsian Font** for use as default fonts.

{{% /alert %}} 
### **Setting Default Fonts**
To manage paragraph bullets using Aspose.Slides for Java:

1. Create an instance of [LoadOptions](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/LoadOptions).
1. Set the DefaultRegularFont to your desired font. In the following example, I have used **Wingdings**.
1. Set the DefaultAsianFont to your desired font. I have used **Wingdings** in the following sample.
1. Load the presentation using [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) and setting the load options.
1. Now, generate the slide thumbnail, PDF, and XPS to verify the results

The implementation of the above is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-UsingDefaultFontsForRenderingPresentation-UsingDefaultFontsForRenderingPresentation.java" >}}
### **Managing Fonts Externally**
Now, you can also load fonts externally into byte array. FontsLoader class now offer, LoadExternalFont(byte[] data) method that allows to add fonts from binary data. The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-LoadExternalFonts-LoadExternalFonts.java" >}}
## **Set Font FallBack**
In Aspose.Slides there are two different mechanisms to set fonts in presentation - font substitution and font fallback. Font substitution is used when the font specified in the document could not be found among the font source.

Whereas font fallback is used when the font specified for text is present but this font does not contain a necessary glyph. In this case, new functionality allows using one of the specified fallback fonts for the glyph replacement. The necessary fallback fonts can be specified for multiple Unicode ranges as collections of FontFallBackRule objects. FontFallBackRule represents an association between the specified Unicode range for checking of missed glyphs and list of fonts that may contain proper glyphs for FallBack-replacement.

The following code example shows how to set font fall back using FontFallBackRule objects.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-SetFontFallBack-SetFontFallBack.java" >}}

Here is another example which uses a FontFallBackRulesCollection property.  It allows to get and set a collection of FontFallBackRule objects for control of new functionality.

FontFallBackRulesCollection can be used in the following way:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FallBackRulesCollection-FallBackRulesCollection.java" >}}

Another example:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-RenderingWithFallBackFont-RenderingWithFallBackFont.java" >}}





