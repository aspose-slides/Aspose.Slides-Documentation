---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für Java 15.1.0
linktitle: Aspose.Slides für Java 15.1.0
type: docs
weight: 100
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- Migration
- Legacy-Code
- moderner Code
- Legacy-Ansatz
- moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überblick über Aktualisierungen der öffentlichen API und kritische Änderungen in Aspose.Slides für Java, um Ihre PowerPoint PPT-, PPTX- und ODP-Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) Klassen, Methoden, Eigenschaften usw. sowie neue Einschränkungen und andere [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) auf, die mit der Aspose.Slides for Java 15.1.0 API eingeführt wurden.

{{% /alert %}} {{% alert color="info" %}} 

Bekannte Probleme mit einigen Bildaufzählungszeichen und WordArt‑Objekten werden in Aspose.Slides for Java 15.2.0 behoben.

{{% /alert %}} 
## **Änderungen an der öffentlichen API**
### **Funktionalität für Schriftart‑Substitutionen wurde hinzugefügt**
Die Möglichkeit, Schriftarten global in der gesamten Präsentation und temporär für das Rendern zu ersetzen, wurde hinzugefügt.

Neue Methode getFontsManager() der Klasse Presentation wurde eingeführt. Die Klasse FontsManager hat folgende Mitglieder:

**IFontSubstRuleCollection getFontSubstRuleList**() Methode

Dies ist die Sammlung von IFontSubstRule‑Instanzen, die zum Ersetzen von Schriftarten während des Renderns verwendet werden. IFontSubstRule verfügt über die Methoden getSourceFont() und getDestFont() aus dem Interface IFontData sowie die Methode getReplaceFontCondition(), mit der die Ersetzungsbedingung („WhenInaccessible“ oder „Always“) gewählt werden kann.

**IFontData[] getFonts()** Methode kann verwendet werden, um alle in der aktuellen Präsentation verwendeten Schriftarten abzurufen.

**replaceFont(...)** Methoden können verwendet werden, um eine Schriftart dauerhaft in einer Präsentation zu ersetzen. 

Das folgende Beispiel zeigt, wie eine Schriftart in einer Präsentation ersetzt wird:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Ein weiteres Beispiel zeigt die Schriftart‑Substitution beim Rendern, wenn die Schriftart nicht verfügbar ist:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // Arial-Schrift wird anstelle von SomeRareFont verwendet, wenn sie nicht verfügbar ist.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```