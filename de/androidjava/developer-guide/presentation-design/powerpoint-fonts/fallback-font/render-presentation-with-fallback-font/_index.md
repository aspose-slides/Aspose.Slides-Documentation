---
title: Rendern von Präsentationen mit Fallback-Schriftarten auf Android
linktitle: Präsentationen rendern
type: docs
weight: 30
url: /de/androidjava/render-presentation-with-fallback-font/
keywords:
- Fallback-Schriftart
- PowerPoint rendern
- Präsentation rendern
- Folie rendern
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Rendern von Präsentationen mit Fallback‑Schriftarten in Aspose.Slides für Android – Text in PPT, PPTX und ODP konsistent halten mit schrittweisen Java‑Code‑Beispielen."
---
## **Übersicht**

Aspose.Slides ermöglicht das Rendern von Präsentationen mit Fallback‑Schriftartenregeln. Dieser Artikel zeigt, wie man eine Sammlung von Fallback‑Schriftartenregeln erstellt, die Regeln durch Entfernen oder Hinzufügen von Fallback‑Schriftarten ändert und die Sammlung mit der Methode `FontsManager.setFontFallBackRulesCollection` zuweist.

Sobald die Sammlung von Fallback‑Schriftartenregeln dem `FontsManager` der Präsentation zugewiesen ist, werden die Regeln bei Vorgängen wie dem Speichern, Rendern und Konvertieren der Präsentation angewendet. Das Beispiel zeigt, wie die konfigurierten Regeln beim Rendern einer Folienminiatur und beim Speichern als JPEG‑Bild verwendet werden.

## **Rendern einer Folie mit Fallback‑Schriftartenregeln**

1. Wir [Erstellen einer Sammlung von Fallback‑Schriftartenregeln](/slides/de/androidjava/create-fallback-fonts-collection/).
2. [Entfernen](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) eine Fallback‑Schriftartenregel und [addFallBackFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einer anderen Regel.
3. Setzen Sie die Regelesammlung über die Methode [getFontsManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
4. Mit der Methode [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) können wir die Präsentation im selben Format speichern oder in einem anderen Format speichern. Nachdem die Fallback‑Schriftartenregelesammlung dem [FontsManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontsManager) zugewiesen wurde, werden diese Regeln bei allen Vorgängen mit der Präsentation angewendet: Speichern, Rendern, Konvertieren usw.

```java
import com.aspose.slides.*;

// Neue Instanz einer Regelsammlung erstellen
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// Eine Reihe von Regeln erstellen
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Versuchen, die Fallback‑Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
    fallBackRule.remove("Tahoma");

    // Und die Regeln für den angegebenen Bereich aktualisieren
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Wir können auch vorhandene Regeln aus der Liste entfernen, dabei mindestens eine Regel zum Rendern behalten
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Zuweisen einer vorbereiteten Regelliste zur Verwendung
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendern der Miniatur mit der initialisierten Regelsammlung und Speichern als JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Bild im JPEG‑Format auf die Festplatte speichern
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Erfahren Sie mehr über [PowerPoint (PPT und PPTX) nach JPG auf Android konvertieren](/slides/de/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}