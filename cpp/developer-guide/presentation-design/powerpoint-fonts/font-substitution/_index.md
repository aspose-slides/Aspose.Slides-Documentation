---
title: Font Substitution
type: docs
weight: 70
url: /cpp/font-substitution/
---

## **Get Font Folder**
A new property has been added that returns folders where font files are searched. Those are folders that have been added with LoadExternalFonts method as well as system font folders.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetFontsFolders-GetFontsFolders.cpp" >}}


## **Specify Font Used in Presentation**
A new DocumentLevelFontSources property has been added to ILoadOptions interface. It allows to specify external fonts that are used with the presentation. Sample Code is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetFontsFolders-GetFontsFolders.cpp" >}}


## **Replace Font Explicitly**
To replace the fonts using explicit replacement following steps are used:

- Load thee desired presentation.
- Load the font that is to replace inside the presentation.
- Load the replacing font.
- Replace the fonts.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ReplaceFontsExplicitly-ReplaceFontsExplicitly.cpp" >}}


## **Rule Based Fonts Replacement**
To replace the fonts by setting some rules of replacement following steps are used:

- Load thee desired presentation.
- Load the font that is to replace inside the presentation.
- Load the replacing font.
- Add a rule for replacement.
- Add the rule to presentation font replacement rule collection.
- Generate the slide image to observe the effect.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RuleBasedFontsReplacement-RuleBasedFontsReplacement.cpp" >}}


