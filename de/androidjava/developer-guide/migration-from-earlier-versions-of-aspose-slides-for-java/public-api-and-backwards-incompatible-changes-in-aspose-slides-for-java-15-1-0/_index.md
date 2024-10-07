---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für Java 15.1.0
type: docs
weight: 100
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) Klassen, Methoden, Eigenschaften und so weiter auf, sowie alle neuen Einschränkungen und andere [Änderungen](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/), die mit der Aspose.Slides für Java 15.1.0 API eingeführt wurden.

{{% /alert %}} {{% alert color="primary" %}} 

Es gibt bekannte Probleme mit einigen Bildaufzählungen und WordArt-Objekten, die in Aspose.Slides für Java 15.2.0 behoben werden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **Funktionalität für Schriftartsubstitution wurde hinzugefügt**
Die Möglichkeit, Schriftarten global über die Präsentation und temporär für die Darstellung zu ersetzen, wurde hinzugefügt.

Neue Methode getFontsManager() der Klasse Presentation wurde eingeführt. Die Klasse FontsManager hat folgende Mitglieder:

**IFontSubstRuleCollection getFontSubstRuleList**() Methode

Dies ist die Sammlung von IFontSubstRule Instanzen, die verwendet werden, um Schriftarten während der Darstellung zu substituieren. IFontSubstRule hat die Methoden getSourceFont() und getDestFont(), die das IFontData-Interface implementieren, sowie die Methode getReplaceFontCondition(), die es ermöglicht, die Bedingung für den Austausch auszuwählen ("WhenInaccessible" oder "Always").

**IFontData[] getFonts()** Methode kann verwendet werden, um alle in der aktuellen Präsentation verwendeten Schriftarten abzurufen.

**replaceFont(...)** Methoden können verwendet werden, um eine Schriftart dauerhaft in einer Präsentation zu ersetzen.

Das folgende Beispiel zeigt, wie man eine Schriftart in einer Präsentation ersetzt:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNewRomanFont.pptx", SaveFormat.Pptx);

```

Ein weiteres Beispiel zeigt die Schriftartsubstitution für die Darstellung, wenn sie nicht zugänglich ist:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Arial wird anstelle von SomeRareFont verwendet, wenn sie nicht zugänglich ist

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```