---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 15.1.0
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
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT-, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 
Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 15.1.0 API eingeführt wurden.
{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Funktionalität für Schriftart-Substitution wurde hinzugefügt**
Die Möglichkeit, Schriftarten global in der gesamten Präsentation und temporär für das Rendering zu ersetzen, wurde hinzugefügt.

Eine neue Eigenschaft "FontsManager" der Klasse Presentation wurde eingeführt. Die Klasse FontsManager enthält die folgenden Mitglieder:

**IFontSubstRuleCollection FontSubstRuleList** Eigenschaft

Diese Sammlung von IFontSubstRule-Instanzen wird verwendet, um Schriftarten beim Rendering zu ersetzen. IFontSubstRule verfügt über die Eigenschaften SourceFont und DestFont, die das IFontData-Interface implementieren, sowie über die Eigenschaft ReplaceFontCondition, mit der die Ersetzungsbedingung („WhenInaccessible“ oder „Always“) gewählt werden kann.

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

Ein weiteres Beispiel demonstriert die Schriftart-Substitution beim Rendering, wenn die Schriftart nicht verfügbar ist:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial-Schrift wird verwendet, wenn SomeRareFont nicht verfügbar ist

            pres.Slides[0].GetThumbnail();

```