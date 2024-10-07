---
title: Öffentliche API und nicht rückwärtskompatible Änderungen in Aspose.Slides für Java 15.1.0
type: docs
weight: 100
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) Klassen, Methoden, Eigenschaften usw., alle neuen Einschränkungen und andere [Änderungen](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) auf, die mit der Aspose.Slides für Java 15.1.0 API eingeführt wurden.

{{% /alert %}} {{% alert color="primary" %}} 

Es gibt bekannte Probleme mit einigen Bildpunkten und WordArt-Objekten, die in Aspose.Slides für Java 15.2.0 behoben werden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **Funktionalität zur Schriftartenersetzung wurde hinzugefügt**
Die Möglichkeit, Schriftarten global in der Präsentation und temporär für die Darstellung zu ersetzen, wurde hinzugefügt.

Die neue Methode getFontsManager() der Präsentationsklasse wurde eingeführt. Die FontsManager-Klasse hat folgende Mitglieder:

**IFontSubstRuleCollection getFontSubstRuleList**() Methode

Dies ist die Sammlung von IFontSubstRule-Instanzen, die zur Schriftartenersetzung während der Darstellung verwendet werden. IFontSubstRule hat die Methoden getSourceFont() und getDestFont(), die das IFontData-Interface implementieren, sowie die Methode getReplaceFontCondition(), die es ermöglicht, die Bedingung der Ersetzung auszuwählen ("WhenInaccessible" oder "Always").

**IFontData[] getFonts()** Methode kann verwendet werden, um alle in der aktuellen Präsentation verwendeten Schriftarten abzurufen.

**replaceFont(...)** Methoden können verwendet werden, um eine Schriftart dauerhaft in einer Präsentation zu ersetzen. 

Das folgende Beispiel zeigt, wie man eine Schriftart in einer Präsentation ersetzt:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Ein weiteres Beispiel zeigt die Schriftartenersetzung für die Darstellung, wenn sie nicht verfügbar ist:

``` java

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Arial-Schriftart wird anstelle von SomeRareFont verwendet, wenn sie nicht verfügbar ist

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```