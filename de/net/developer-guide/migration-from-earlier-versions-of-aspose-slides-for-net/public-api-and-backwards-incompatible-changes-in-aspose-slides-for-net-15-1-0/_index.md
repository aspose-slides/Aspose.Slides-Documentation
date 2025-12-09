---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.1.0
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
description: "Überprüfen Sie die öffentlichen API-Updates und Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 
Diese Seite listet alle [added](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) oder [removed](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for .NET 15.1.0 API eingeführt wurden.
{{% /alert %}} 
## **Public API Änderungen**
#### **Funktionalität zum Ersetzen von Schriften wurde hinzugefügt**
Die Möglichkeit, Schriftarten global in der gesamten Präsentation und temporär für das Rendering zu ersetzen, wurde hinzugefügt.

Eine neue Eigenschaft „FontsManager“ der Klasse Presentation wurde eingeführt. Die Klasse FontsManager verfügt über folgende Mitglieder:

**IFontSubstRuleCollection FontSubstRuleList** Property

Diese Sammlung von IFontSubstRule‑Instanzen wird zum Ersetzen von Schriften während des Renderns verwendet. IFontSubstRule besitzt die Eigenschaften SourceFont und DestFont, die das IFontData‑Interface implementieren, sowie die Eigenschaft ReplaceFontCondition, mit der die Ersetzungsbedingung („WhenInaccessible“ oder „Always“) festgelegt werden kann.

**IFontData[] GetFonts()** Method

Wird verwendet, um alle in der aktuellen Präsentation verwendeten Schriften abzurufen.

**ReplaceFont** Methods

Wird verwendet, um Schriften dauerhaft in der Präsentation zu ersetzen.

Das folgende Beispiel zeigt, wie eine Schrift in der Präsentation ersetzt wird:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Ein weiteres Beispiel demonstriert die Schriftartsubstitution beim Rendering, wenn die Schrift nicht verfügbar ist:

``` csharp

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

```