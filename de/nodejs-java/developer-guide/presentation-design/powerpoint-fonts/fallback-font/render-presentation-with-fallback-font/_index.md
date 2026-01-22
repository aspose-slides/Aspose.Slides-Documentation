---
title: Präsentationen mit Fallback-Schriftarten in JavaScript rendern
linktitle: Präsentationen rendern
type: docs
weight: 30
url: /de/nodejs-java/render-presentation-with-fallback-font/
keywords:
- Fallback-Schriftart
- PowerPoint rendern
- Präsentation rendern
- Folie rendern
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Präsentationen mit Fallback-Schriftarten in Aspose.Slides für Node.js rendern – behalten Sie den Text über PPT, PPTX und ODP hinweg konsistent mit schrittweisen JavaScript-Codebeispielen."
---

Das folgende Beispiel umfasst diese Schritte:

1. Wir [erstellen eine Sammlung von Fallback‑Schriftartregeln](/slides/de/nodejs-java/create-fallback-fonts-collection/).
2. [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) eine Fallback‑Schriftartregel und [addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einer anderen Regel.
3. Setzen Sie die Regelsammlung auf die Methode [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
4. Mit der Methode [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) können wir die Präsentation im selben Format speichern oder in ein anderes Format. Nachdem die Sammlung von Fallback‑Schriftartregeln auf [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) gesetzt wurde, werden diese Regeln bei allen Vorgängen mit der Präsentation angewendet: speichern, rendern, konvertieren usw.
```javascript
// Erstelle neue Instanz einer Regelsammlung
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// erstelle eine Anzahl von Regeln
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Versuche, die Fallback-Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
    fallBackRule.remove("Tahoma");
    // Und die Regeln für den angegebenen Bereich zu aktualisieren
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Außerdem können wir beliebige vorhandene Regeln aus der Liste entfernen
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Zuweisen einer vorbereiteten Regelliste zur Verwendung
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Rendern einer Miniaturansicht unter Verwendung der initialisierten Regelsammlung und speichern als JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Speichere das Bild auf der Festplatte im JPEG-Format
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
Erfahren Sie mehr darüber, wie man [Convert PPT and PPTX to JPG in JavaScript](/slides/de/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}