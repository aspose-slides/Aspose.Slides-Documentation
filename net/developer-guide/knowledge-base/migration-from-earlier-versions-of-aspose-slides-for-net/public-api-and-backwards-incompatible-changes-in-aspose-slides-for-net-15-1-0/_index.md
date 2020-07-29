---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 15.1.0 API.

{{% /alert %}} 
## **Public API Chages**
#### **Fonts substitutions functinality has been added**
Possibility to replace font globally across the presentation and temporary for rendering has been added.

New property "FontsManager" of Presentation class has been introduced. FontsManager class has following members:

**IFontSubstRuleCollection FontSubstRuleList** Property

This collection of IFontSubstRule instances using to substitute fonts during rendering. IFontSubstRule has SourceFont and DestFont properties implementing IFontData interface and ReplaceFontCondition property allowing to choose condition of replacement ("WhenInaccessible" or "Always").

**IFontData[] GetFonts()** Method

Using to retrieve all fonts uisng in the current presentation.

**ReplaceFont** Methods

Using to persistently replace font in the presentation. 

The following example shows how to replace font in the presentation:

{{< highlight java >}}

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


{{< /highlight >}}

Another example, demonstrates font substitution for rendering when inaccessible:

{{< highlight java >}}

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial font will be used instead of SomeRareFont when inaccessible

            pres.Slides[0].GetThumbnail();

{{< /highlight >}}
