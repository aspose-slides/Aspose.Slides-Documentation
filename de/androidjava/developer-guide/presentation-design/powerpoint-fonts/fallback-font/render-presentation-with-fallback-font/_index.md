---
title: Präsentationen mit Fallback-Schriftarten auf Android rendern
linktitle: Präsentationen rendern
type: docs
weight: 30
url: /de/androidjava/render-presentation-with-fallback-font/
keywords:
- Fallback-Schriftart
- PowerPoint rendern
- Präsentation rendern
- Folien rendern
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Präsentationen mit Fallback-Schriftarten in Aspose.Slides für Android rendern – Text über PPT, PPTX und ODP hinweg konsistent halten mit schrittweisen Java-Codebeispielen."
---

Das folgende Beispiel enthält diese Schritte:

1. Wir [erstellen die Sammlung von Fallback‑Schriftartregeln](/slides/de/androidjava/create-fallback-fonts-collection/).
1. Entfernen Sie eine Fallback‑Schriftartregel und [addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einer anderen Regel.
1. Setzen Sie die Sammlung der Regeln über die Methode [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) fest.
1. Mit der Methode [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) können wir die Präsentation im selben Format speichern oder in einem anderen Format. Nachdem die Sammlung von Fallback‑Schriftartregeln im [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) festgelegt ist, werden diese Regeln bei allen Vorgängen mit der Präsentation angewendet: speichern, rendern, konvertieren usw.
```java
// Neue Instanz einer Regel-Sammlung erstellen
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// Eine Reihe von Regeln erstellen
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Versuch, die Fallback-Schriftart "Tahoma" aus geladenen Regeln zu entfernen
    fallBackRule.remove("Tahoma");

    // Und die Regeln für den angegebenen Bereich aktualisieren
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Auch können wir vorhandene Regeln aus der Liste entfernen
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Zuweisung einer vorbereiteten Regel-Liste zur Verwendung
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendern des Thumbnails unter Verwendung der initialisierten Regel-Sammlung und Speicherung als JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Bild im JPEG-Format auf die Festplatte speichern
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Erfahren Sie mehr über [PPT und PPTX auf Android in JPG konvertieren](/slides/de/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}