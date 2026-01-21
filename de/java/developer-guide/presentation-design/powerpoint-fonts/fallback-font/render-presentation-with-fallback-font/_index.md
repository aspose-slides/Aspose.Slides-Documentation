---
title: Präsentationen mit Fallback-Schriftarten in Java rendern
linktitle: Präsentationen rendern
type: docs
weight: 30
url: /de/java/render-presentation-with-fallback-font/
keywords:
- Fallback-Schriftart
- PowerPoint rendern
- Präsentation rendern
- Folie rendern
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Präsentationen mit Fallback-Schriftarten in Aspose.Slides für Java rendern – Text über PPT, PPTX und ODP hinweg konsistent halten mit Schritt-für-Schritt-Java-Codebeispielen."
---

Das folgende Beispiel enthält diese Schritte:

1. Wir [erstellen eine Sammlung von Fallback-Schriftartenregeln](/slides/de/java/create-fallback-fonts-collection/).
1. [Entfernen](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) eine Fallback-Schriftartregel und [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einer anderen Regel hinzufügen.
1. Setzen Sie die Regelsammlung mit der Methode [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--).
1. Mit der Methode [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) können wir die Präsentation im selben Format speichern oder in ein anderes Format konvertieren. Nachdem die Fallback-Schriftartenregelsammlung im [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) festgelegt wurde, werden diese Regeln bei allen Vorgängen mit der Präsentation angewendet: speichern, rendern, konvertieren usw.
```java
// Neue Instanz einer Regelsammlung erstellen
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// Eine Anzahl von Regeln erstellen
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Versucht, die Rückfallschriftart "Tahoma" aus den geladenen Regeln zu entfernen
    fallBackRule.remove("Tahoma");

    // Und die Regeln für den angegebenen Bereich zu aktualisieren
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//Also wir können beliebige vorhandene Regeln aus der Liste entfernen
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Zuweisen einer vorbereiteten Regelliste zur Verwendung
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendern einer Miniaturansicht mit der initialisierten Regelsammlung und Speichern als JPEG
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
Erfahren Sie mehr darüber, wie man PPT und PPTX in Java zu JPG konvertiert.
{{% /alert %}}