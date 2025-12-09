---
title: Standard-Schriftarten - PowerPoint JavaScript API
linktitle: Standard-Schriftarten
type: docs
weight: 30
url: /de/nodejs-java/default-font/
description: Die PowerPoint JavaScript API ermöglicht das Festlegen der Standardschriftart zum Rendern der Präsentation in PDF, XPS oder Miniaturansichten. Dieser Artikel zeigt, wie man DefaultRegular Font und DefaultAsian Font definiert, um sie als Standardschriften zu verwenden.
---

## **Standard-Schriftarten für das Rendern von Präsentationen**
Aspose.Slides ermöglicht das Festlegen der Standardschriftart für das Rendern einer Präsentation in PDF, XPS oder Miniaturansichten. Dieser Artikel zeigt, wie man DefaultRegularFont und DefaultAsianFont definiert, um sie als Standardschriften zu verwenden. Bitte folgen Sie den nachstehenden Schritten, um Schriftarten aus externen Verzeichnissen mithilfe von Aspose.Slides für Node.js über die Java-API zu laden:

1. Erstellen Sie eine Instanz von [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions).
2. Legen Sie mit [Set the DefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) die gewünschte Schriftart fest. Im folgenden Beispiel habe ich Wingdings verwendet.
3. Legen Sie mit [Set the DefaultAsianFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) die gewünschte Schriftart fest. Im folgenden Beispiel habe ich Wingdings verwendet.
4. Laden Sie die Präsentation mit Presentation und den angegebenen Ladeloptionen.
5. Erzeugen Sie nun die Folien-Miniatur, PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des Obigen ist unten dargestellt.
```javascript
// Ladeoptionen verwenden, um die Standard-Schriftarten für reguläre und asiatische Zeichen zu definieren
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Lade die Präsentation
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Erstelle Folien-Miniatur
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // Speichere das Bild auf der Festplatte.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Erstelle PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Erstelle XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Was genau beeinflussen DefaultRegularFont und DefaultAsianFont – nur den Export oder auch Miniaturansichten, PDF, XPS, HTML und SVG?**

Sie sind Teil der Rendering-Pipeline für alle unterstützten Ausgaben. Dazu gehören Folien-Miniaturansichten, [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/de/nodejs-java/convert-powerpoint-to-xps/), [Rasterbilder](/slides/de/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/), und [SVG](/slides/de/nodejs-java/render-a-slide-as-an-svg-image/), da Aspose.Slides dieselbe Layout- und Glyphen-Auflösungslogik für diese Ziele verwendet.

**Werden Standardschriftarten angewendet, wenn man einfach eine PPTX einliest und speichert, ohne zu rendern?**

Nein. Standardschriftarten sind relevant, wenn Text gemessen und gezeichnet werden muss. Ein einfaches Öffnen und Speichern einer Präsentation ändert weder die gespeicherten Schriftlaufinformationen noch die Dateistruktur. Standardschriftarten kommen bei Vorgängen zum Einsatz, die Text rendern oder neu layouten.

**Wenn ich eigene Schriftordner hinzufüge oder Schriftarten aus dem Speicher bereitstelle, werden diese bei der Auswahl der Standardschriftarten berücksichtigt?**

Ja. [Benutzerdefinierte Schriftquellen](/slides/de/nodejs-java/custom-font/) erweitern den Katalog der verfügbaren Schriftfamilien und Glyphen, die die Engine nutzen kann. Standardschriftarten und alle [Fallback-Regeln](/slides/de/nodejs-java/fallback-font/) werden zuerst anhand dieser Quellen aufgelöst, was zu einer zuverlässigeren Abdeckung auf Servern und in Containern führt.

**Werden Standardschriftarten die Textmetriken (Kerning, Vorabstände) und damit Zeilenumbrüche und den Textumbruch beeinflussen?**

Ja. Das Ändern der Schriftart ändert die Glyphenmetriken und kann während des Renderns Zeilenumbrüche, Umbrüche und die Seitennummerierung verändern. Für Layout-Stabilität sollten Sie [die ursprünglichen Schriftarten einbetten](/slides/de/nodejs-java/embedded-font/) oder metrisch kompatible Standard- und Fallback-Familien auswählen.

**Gibt es einen Sinn, Standardschriftarten festzulegen, wenn alle in der Präsentation verwendeten Schriftarten eingebettet sind?**

Oft ist es nicht nötig, da [eingebettete Schriftarten](/slides/de/nodejs-java/embedded-font/) bereits ein konsistentes Erscheinungsbild gewährleisten. Standardschriftarten dienen jedoch weiterhin als Sicherheitsnetz für Zeichen, die im eingebetteten Teil nicht enthalten sind, oder wenn eine Datei eingebetteten und nicht eingebetteten Text kombiniert.