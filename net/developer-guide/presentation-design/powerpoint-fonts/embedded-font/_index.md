---
title: Embedded Font
type: docs
weight: 40
url: /net/embedded-font/
---

## **Get or Remove Embedded Fonts from Presentation**
Now, you can also work with embedded fonts. FontsManger class now offer, GetEmbeddedFonts() method that returns a list of embedded fonts inside the presentation. You can also remove any embedded font inside presentation if that is required by using RemoveEmbeddedFont() method exposed by FontsManager class. The implementation of the above steps is given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-ManageEmbeddedFonts-ManageEmbeddedFonts.cs" >}}
## **Add Embedded Fonts to Presentation**
A new property of embedding fonts has been added. To allow embedding fonts into Presentation the new EmbedFontCharacters enum and two overloads of AddEmbeddedFont method have been added. Using these methods and choosing the desired embedding rule (represented by EmbedFontCharacters enum), all fonts used in the Presentation can be embedded. The implementation of the above steps is given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-AddEmbeddedFonts-AddEmbeddedFonts.cs" >}}
