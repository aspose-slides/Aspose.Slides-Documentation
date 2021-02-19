---
title: Embedded Font
type: docs
weight: 40
url: /java/embedded-font/
---

## **Manage Embedded Fonts**
FontsManger class offer getEmbeddedFonts() method that returns a list of embedded fonts inside the presentation. You can also remove any embedded font inside presentation if that is required by using removeEmbeddedFont() method exposed by FontsManager class.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingEmbeddedFonts-ManagingEmbeddedFonts.java" >}}


## **Embedded Fonts in Presentation**
To allow embedding fonts into Presentation the new EmbedFontCharacters enum and two overloads of AddEmbeddedFont method have been added. Using these methods and choosing the desired embedding rule (represented by EmbedFontCharacters enum), all fonts used in Presentation can be embedded. The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-AddEmbeddedFonts-AddEmbeddedFonts.java" >}}
