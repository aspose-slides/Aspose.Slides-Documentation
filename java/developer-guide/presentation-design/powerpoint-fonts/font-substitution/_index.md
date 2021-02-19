---
title: Font Substitution
type: docs
weight: 70
url: /java/font-substitution/
---


{{% alert color="primary" %}} 

Aspose.Slides now allow replacing any given font in presentation with the new font. It allows replacing the font both explicitly or by setting font replacement rules. In this article, we will see the examples of explicit font substitution as well as rule-based font substitution.

{{% /alert %}} 

## **Replace Fonts Explicitly inside Presentation**
To replace the fonts using explicit replacement, following steps are used:

1. Load the desired presentation.
1. Load the font that is to replace inside the presentation.
1. Load the replacing font.
1. Replace the fonts.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ReplacingFontsExplicitlyInsidePresentation-ReplacingFontsExplicitlyInsidePresentation.java" >}}
## **Rule Based Fonts Replacement inside Presentation**
To replace the fonts by setting some rules of replacement, following steps are used:

1. Load the desired presentation.
1. Load the font that is to replace inside the presentation.
1. Load the replacing font.
1. Add a rule for replacement.
1. Add the rule to presentation font replacement rule collection.
1. Generate the slide image to observe the effect.

## **Replace Fonts Explicitly**
To replace the fonts using explicit replacement following steps are used:

- Load the desired presentation.
- Load the font that is to replace inside the presentation.
- Load the replacing font.
- Replace the fonts.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-ReplaceFontsExplicitly-ReplaceFontsExplicitly.cs" >}}

## **Rule Based Font Substitution**
To replace the fonts by setting some rules of replacement following steps are used:

- Load the desired presentation.
- Load the font that is to replaced inside the presentation.
- Load the replacing font.
- Add rule for replacement.
- Add the rule to presentation font replacement rule collection.
- Generate the slide image to observe the effect.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-RuleBasedFontsReplacement-RuleBasedFontsReplacement.cs" >}}


## **Specify Fonts Used With Presentation**
A new DocumentLevelFontSources property has been added to ILoadOptions interface. It allows to specify external fonts that are used with the presentation. Sample Code is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingEmbeddedFonts-ManagingEmbeddedFonts.java" >}}


## **Get Fonts Folder**
A new property has been added that returns folders where font files are searched. Those are folders that have been added with LoadExternalFonts method as well as system font folders.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-GetFontsFolders-GetFontsFolders.java" >}}

