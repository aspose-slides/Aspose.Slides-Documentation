---
title: Präsentation mit Fallback-Schriftart rendern
type: docs
weight: 30
url: /de/java/render-presentation-with-fallback-font/
---

Das folgende Beispiel umfasst diese Schritte:

1. Wir [erstellen eine Sammlung von Fallback-Schriftart-Regeln](/slides/de/java/create-fallback-fonts-collection/).
1. [Entfernen](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) Sie eine Fallback-Schriftartregel und [fügen Sie Fallback-Schriftarten](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einer anderen Regel hinzu.
1. Setzen Sie die Regel-Sammlung auf [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) Methode.
1. Mit der [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) Methode können wir die Präsentation im selben Format speichern oder in einem anderen. Nachdem die Sammlung der Fallback-Schriftart-Regeln auf den [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) gesetzt wurde, werden diese Regeln während aller Operationen über die Präsentation angewendet: speichern, rendern, konvertieren usw.

```java
// Erstellen Sie eine neue Instanz einer Regel-Sammlung
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// Erstellen Sie eine Anzahl von Regeln
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Versuchen, die Fallback-Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
    fallBackRule.remove("Tahoma");

    //Und Aktualisieren der Regeln für den angegebenen Bereich
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//Auch können wir vorhandene Regeln aus der Liste entfernen
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //Zuweisen einer vorbereiteten Regel-Liste zur Verwendung
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    //Rendering von Miniaturansichten mit der Verwendung der initialisierten Regel-Sammlung und Speichern im JPEG-Format
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Speichern Sie das Bild auf der Festplatte im JPEG-Format
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
Lesen Sie mehr über [Speichern und Konvertieren in Präsentationen](/slides/de/java/creating-saving-and-converting-a-presentation/).
{{% /alert %}}