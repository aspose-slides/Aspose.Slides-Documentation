---
title: Managing Fonts
type: docs
weight: 20
url: /cpp/managing-fonts/
---

## **Managing Fonts inside Presentation**
Aspose.Slides now allows to replace any given font in presentation with a new font. It allows to replace the font both explicitly or by setting font replacement rules. In this article, we will see the examples of explicit font substitution as well as rule based font substitution. This article explains how to use font substitutions in different ways:

- Replacing Fonts Explicitly Inside Presentation.
- Rule based fonts replacement inside presentation.
#### **Replacing Fonts Explicitly**
To replace the fonts using explicit replacement following steps are used:

- Load thee desired presentation.
- Load the font that is to replace inside the presentation.
- Load the replacing font.
- Replace the fonts.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ReplaceFontsExplicitly-ReplaceFontsExplicitly.cpp" >}}
#### **Rule Based Fonts Replacement**
To replace the fonts by setting some rules of replacement following steps are used:

- Load thee desired presentation.
- Load the font that is to replace inside the presentation.
- Load the replacing font.
- Add a rule for replacement.
- Add the rule to presentation font replacement rule collection.
- Generate the slide image to observe the effect.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RuleBasedFontsReplacement-RuleBasedFontsReplacement.cpp" >}}
#### **Managing Embedded Fonts**
Now, you can also work with embedded fonts. FontsManger class now offers GetEmbeddedFonts() method that returns a list of embedded fonts inside the presentation. You can also remove any embedded font inside presentation if that is required by using RemoveEmbeddedFont() method exposed by FontsManager class. The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageEmbeddedFonts-ManageEmbeddedFonts.cpp" >}}
#### **Embed Fonts in Presentation**
A new property of embedding fonts has been added. To allow embedding fonts into Presentation the new EmbedFontCharacters enum and two overloads of AddEmbeddedFont method have been added. Using these methods and choosing the desired embedding rule (represented by EmbedFontCharacters enum), all fonts used in Presentation can be embedded. The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddEmbeddedFonts-AddEmbeddedFonts.cpp" >}}
#### **Managing Fonts Externally**
Now, you can also load fonts externally into a byte array. FontsLoader class now offer, LoadExternalFont(byte[] data) method that allows to add fonts from binary data. The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SpecifyFontsUsedWithPresentation-SpecifyFontsUsedWithPresentation.cpp" >}}
## **Set Font FallBack**
In Aspose.Slides there are two different mechanisms to set fonts in presentation - font substitution and font fallback. Font substitution is used when the font specified in the document could not be found among the font source.

Whereas font fallback is used when the font specified for text is present but this font does not contain a necessary glyph. In this case, new functionality allows using one of the specified fallback fonts for the glyph replacement. The necessary fallback fonts can be specified for multiple Unicode ranges as collections of FontFallBackRule objects. FontFallBackRule represents an association between the specified Unicode range for checking of missed glyphs and a list of fonts that may contain proper glyphs for FallBack-replacement.

The following code example shows how to set font fall back using FontFallBackRule objects.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetFontFallBack-SetFontFallBack.cpp" >}}

Here is another example which uses a FontFallBackRulesCollection property.  It allows to get and set a collection of FontFallBackRule objects for control of new functionality.

FontFallBackRulesCollection can be used in the following way:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FallBackRulesCollection-FallBackRulesCollection.cpp" >}}

Another example:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-RenderingWithFallBackFont-RenderingWithFallBackFont.cpp" >}}
