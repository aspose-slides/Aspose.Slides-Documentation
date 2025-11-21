---
title: Public API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.1.0
linktitle: Aspose.Slides für .NET 15.1.0
type: docs
weight: 130
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über Aktualisierungen der öffentlichen API und breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT-, PPTX- und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [added](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) oder [removed](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 15.1.0 API eingeführt wurden.

{{% /alert %}} 
## **Public API Changes**
#### **Funktionalität für Schriftart‑Ersetzungen wurde hinzugefügt**
Möglichkeit, Schriftarten global in der gesamten Präsentation und temporär für das Rendern zu ersetzen, wurde hinzugefügt.

Neue Eigenschaft "FontsManager" der Klasse Presentation wurde eingeführt. Die Klasse FontsManager hat folgende Mitglieder:

**IFontSubstRuleCollection FontSubstRuleList** Eigenschaft

Diese Sammlung von IFontSubstRule‑Instanzen wird verwendet, um Schriftarten beim Rendern zu ersetzen. IFontSubstRule hat die Eigenschaften SourceFont und DestFont, die das IFontData‑Interface implementieren, sowie die Eigenschaft ReplaceFontCondition, mit der die Ersetzungsbedingung gewählt werden kann („WhenInaccessible“ oder „Always“).

**IFontData[] GetFonts()** Methode

Wird verwendet, um alle in der aktuellen Präsentation verwendeten Schriftarten abzurufen.

**ReplaceFont** Methoden

Wird verwendet, um Schriftarten dauerhaft in der Präsentation zu ersetzen. 

Das folgende Beispiel zeigt, wie man Schriftarten in der Präsentation ersetzt:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Ein weiteres Beispiel zeigt die Schriftart‑Ersetzung beim Rendern, wenn die Schriftart nicht zugänglich ist:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial-Schrift wird anstelle von SomeRareFont verwendet, wenn sie nicht zugänglich ist

            pres.Slides[0].GetThumbnail();

```