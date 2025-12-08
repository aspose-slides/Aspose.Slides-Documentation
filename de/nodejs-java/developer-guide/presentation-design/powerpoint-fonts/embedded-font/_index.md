---
title: Eingebettete Schriftart - PowerPoint JavaScript API
linktitle: Eingebettete Schriftart
type: docs
weight: 40
url: /de/nodejs-java/embedded-font/
keywords: "Schriftarten, eingebettete Schriftarten, Schriftarten hinzufügen, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "Verwenden Sie eingebettete Schriftarten in einer PowerPoint-Präsentation in JavaScript"
---

**Eingebettete Schriftarten in PowerPoint** sind nützlich, wenn Ihre Präsentation auf jedem System oder Gerät korrekt angezeigt werden soll. Wenn Sie aus kreativen Gründen eine Drittanbieter‑ oder nicht‑standardisierte Schriftart verwendet haben, haben Sie noch mehr Gründe, diese Schriftart einzubetten. Ohne eingebettete Schriftarten können Texte oder Zahlen auf Ihren Folien, das Layout, das Styling usw. sich ändern oder in unleserliche Rechtecke umgewandelt werden. 

Die [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager)-Klasse, die [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/)-Klasse, die [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)-Klasse und ihre Methoden enthalten die meisten Eigenschaften und Methoden, die Sie benötigen, um mit eingebetteten Schriftarten in PowerPoint‑Präsentationen zu arbeiten.

## **Eingebettete Schriftarten aus einer Präsentation abrufen oder entfernen**

Aspose.Slides stellt die Methode [getEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (bereitgestellt von der [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager)-Klasse) zur Verfügung, mit der Sie die in einer Präsentation eingebetteten Schriftarten ermitteln (oder herausfinden) können. Zum Entfernen von Schriftarten wird die Methode [removeEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (ebenfalls von derselben Klasse) verwendet.

Dieser JavaScript‑Code zeigt, wie man eingebettete Schriftarten aus einer Präsentation abruft und entfernt:
```javascript
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Rendert eine Folie, die einen Textframe enthält und die eingebettete Schriftart "FunSized" verwendet
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Speichert das Bild auf der Festplatte im JPEG-Format
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Ruft alle eingebetteten Schriftarten ab
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Findet die Schriftart "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Entfernt die Schriftart "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Rendert die Präsentation; die Schriftart "Calibri" wird durch eine vorhandene ersetzt
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Speichert das Bild auf der Festplatte im JPEG-Format
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Speichert die Präsentation ohne die eingebettete Schriftart "Calibri" auf der Festplatte
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Eingebettete Schriftarten zu einer Präsentation hinzufügen**

Mit dem Aufzählungstyp [EmbedFontCharacters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/embedfontcharacters/) und zwei Überladungen der Methode [addEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) können Sie die gewünschte (Einbettungs‑)Regel auswählen, um Schriftarten in einer Präsentation einzubetten. Dieser JavaScript‑Code demonstriert, wie man Schriftarten einbettet und zu einer Präsentation hinzufügt:
```javascript
// Lädt die Präsentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Speichert die Präsentation auf der Festplatte
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Eingebettete Schriftarten komprimieren**

Um Ihnen das Komprimieren der in einer Präsentation eingebetteten Schriftarten und die Reduzierung der Dateigröße zu ermöglichen, stellt Aspose.Slides die Methode [compressEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (bereitgestellt von der [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)-Klasse) bereit.

Dieser JavaScript‑Code zeigt, wie man eingebettete PowerPoint‑Schriftarten komprimiert:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Wie kann ich erkennen, dass eine bestimmte Schriftart in der Präsentation trotz Einbettung beim Rendern noch ersetzt wird?**

Prüfen Sie die [substitution information](/slides/de/nodejs-java/font-substitution/) im Schriftarten‑Manager und die [fallback/substitution rules](/slides/de/nodejs-java/fallback-font/): Wenn die Schriftart nicht verfügbar oder eingeschränkt ist, wird eine Ersatzschriftart verwendet.

**Lohnt es sich, „System“-Schriftarten wie Arial/Calibri einzubetten?**

In der Regel nicht – sie sind fast immer vorhanden. Für volle Portabilität in „dünnen“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriftarten) kann das Einbetten von Systemschriftarten jedoch das Risiko unerwarteter Ersetzungen eliminieren.