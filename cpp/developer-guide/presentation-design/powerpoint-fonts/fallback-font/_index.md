---
title: Fallback Font
type: docs
weight: 50
url: /cpp/fallback-font/
---

## **Create FallBack Font**
In Aspose.Slides there are two different mechanisms to set fonts in presentation - font substitution and font fallback. Font substitution is used when the font specified in the document could not be found among the font source.

Whereas font fallback is used when the font specified for text is present but this font does not contain a necessary glyph. In this case, new functionality allows using one of the specified fallback fonts for the glyph replacement. The necessary fallback fonts can be specified for multiple Unicode ranges as collections of FontFallBackRule objects. FontFallBackRule represents an association between the specified Unicode range for checking of missed glyphs and a list of fonts that may contain proper glyphs for FallBack-replacement.

The following code example shows how to set font fall back using FontFallBackRule objects.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetFontFallBack-SetFontFallBack.cpp" >}}

Here is another example which uses a FontFallBackRulesCollection property.  It allows to get and set a collection of FontFallBackRule objects for control of new functionality.

FontFallBackRulesCollection can be used in the following way:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FallBackRulesCollection-FallBackRulesCollection.cpp" >}}

Another example:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-RenderingWithFallBackFont-RenderingWithFallBackFont.cpp" >}}



