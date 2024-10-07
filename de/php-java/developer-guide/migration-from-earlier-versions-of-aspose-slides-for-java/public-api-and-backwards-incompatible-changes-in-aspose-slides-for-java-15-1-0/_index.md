---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für PHP über Java 15.1.0
type: docs
weight: 100
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) Klassen, Methoden, Eigenschaften und so weiter, alle neuen Einschränkungen und andere [Änderungen](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) auf, die mit der Aspose.Slides für PHP über Java 15.1.0 API eingeführt wurden.

{{% /alert %}} {{% alert color="primary" %}} 

Es gibt bekannte Probleme mit einigen Bildaufzählungszeichen und WordArt-Objekten, die in Aspose.Slides für PHP über Java 15.2.0 behoben werden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Funktionen zur Schriftartenersetzung wurden hinzugefügt**
Die Möglichkeit, Schriftarten global über die Präsentation und temporär für die Wiedergabe zu ersetzen, wurde hinzugefügt.

Die neue Methode getFontsManager() der Presentation-Klasse wurde eingeführt. Die FontsManager-Klasse hat folgende Mitglieder:

**IFontSubstRuleCollection getFontSubstRuleList**() Methode

Dies ist die Sammlung von IFontSubstRule-Instanzen, die zur Schriftartenersetzung während der Wiedergabe verwendet werden. IFontSubstRule hat die Methoden getSourceFont() und getDestFont(), die das IFontData-Interface implementieren, sowie die Methode getReplaceFontCondition(), die es ermöglicht, die Bedingung für die Ersetzung auszuwählen ("WhenInaccessible" oder "Always").

**IFontData[] getFonts()** Methode kann verwendet werden, um alle in der aktuellen Präsentation verwendeten Schriftarten abzurufen.

**replaceFont(...)** Methoden können verwendet werden, um eine Schriftart in einer Präsentation dauerhaft zu ersetzen. 

Das folgende Beispiel zeigt, wie man eine Schriftart in einer Präsentation ersetzt:

```php
  $pres = new Presentation("PresContainsArialFont.pptx");
  $sourceFont = new FontData("Arial");
  $destFont = new FontData("Times New Roman");
  $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
  $pres->save("PresContainsTimesNoewRomanFont.pptx", SaveFormat::Pptx);
```

Ein weiteres Beispiel zeigt die Schriftartenersetzung für die Wiedergabe, wenn sie unzugänglich ist:

```php
  $pres = new Presentation("PresContainsSomeRareFontFont.pptx");
  $sourceFont = new FontData("SomeRareFont");
  $destFont = new FontData("Arial");
  $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
  $fontSubstRuleCollection = new FontSubstRuleCollection();
  $fontSubstRuleCollection->add($fontSubstRule);
  $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
  # Arial-Schriftart wird anstelle von SomeRareFont verwendet, wenn sie unzugänglich ist
  $pres->getSlides()->get_Item(0)->getThumbnail(1, 1);
```