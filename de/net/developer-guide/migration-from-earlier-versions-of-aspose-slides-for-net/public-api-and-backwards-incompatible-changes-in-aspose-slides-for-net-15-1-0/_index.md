---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 15.1.0
type: docs
weight: 130
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) Klassen, Methoden, Eigenschaften usw. auf und andere Änderungen, die mit der Aspose.Slides für .NET 15.1.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API Änderungen**
#### **Funktionalität für Schriftartsubstitution wurde hinzugefügt**
Die Möglichkeit, die Schriftart global in der Präsentation und temporär für die Darstellung zu ersetzen, wurde hinzugefügt.

Die neue Eigenschaft "FontsManager" der Präsentationsklasse wurde eingeführt. Die FontsManager-Klasse hat folgende Mitglieder:

**IFontSubstRuleCollection FontSubstRuleList** Eigenschaft

Diese Sammlung von IFontSubstRule-Instanzen wird verwendet, um Schriftarten während der Darstellung zu substituieren. IFontSubstRule hat die Eigenschaften SourceFont und DestFont, die das IFontData-Interface implementieren, sowie die ReplaceFontCondition-Eigenschaft, die es ermöglicht, die Bedingung für den Ersatz auszuwählen ("WhenInaccessible" oder "Always").

**IFontData[] GetFonts()** Methode

Wird verwendet, um alle in der aktuellen Präsentation verwendeten Schriftarten abzurufen.

**ReplaceFont** Methoden

Wird verwendet, um die Schriftart dauerhaft in der Präsentation zu ersetzen.

Das folgende Beispiel zeigt, wie man die Schriftart in der Präsentation ersetzt:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

``` 

Ein weiteres Beispiel zeigt die Schriftartsubstitution für die Darstellung, wenn sie nicht verfügbar ist:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial wird anstelle von SomeRareFont verwendet, wenn sie nicht verfügbar ist

            pres.Slides[0].GetThumbnail();

```