---
title: Präsentation mit Fallback-Schriftart rendern
type: docs
weight: 30
url: /de/androidjava/render-presentation-with-fallback-font/
---

Das folgende Beispiel umfasst diese Schritte:

1. Wir [erstellen eine Fallback-Schriftartregel-Sammlung](/slides/de/androidjava/create-fallback-fonts-collection/).
1. [Entfernen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) einer Fallback-Schriftartregel und [fügen SieFallbackFonts hinzu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einer anderen Regel.
1. Setzen Sie die Regel-Sammlung auf [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) Methode.
1. Mit der [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) Methode können wir die Präsentation im gleichen Format speichern oder in ein anderes speichern. Nachdem die Fallback-Schriftartregel-Sammlung auf [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) gesetzt ist, werden diese Regeln während aller Operationen über die Präsentation angewendet: speichern, rendern, konvertieren usw.

```java
// Erstellen Sie eine neue Instanz einer Regelsammlung
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// Erstellen Sie eine Anzahl von Regeln
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Versuchen, die Fallback-Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
    fallBackRule.remove("Tahoma");

    // Und Aktualisierung der Regeln für den angegebenen Bereich
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Wir können auch vorhandene Regeln von der Liste entfernen
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Zuweisen einer vorbereiteten Regelliste zur Verwendung
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering des Thumbnails mit Verwendung der initialisierten Regelsammlung und Speichern als JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Speichern des Bildes auf der Festplatte im JPEG-Format
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
Erfahren Sie mehr über [Speichern und Konvertieren in Präsentationen](/slides/de/androidjava/creating-saving-and-converting-a-presentation/).
{{% /alert %}}