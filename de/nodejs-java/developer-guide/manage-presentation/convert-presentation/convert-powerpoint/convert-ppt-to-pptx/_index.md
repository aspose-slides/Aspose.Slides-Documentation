---
title: PPT nach PPTX in Node.js konvertieren
linktitle: PPT nach PPTX
type: docs
weight: 20
url: /de/nodejs-java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPT nach PPTX
- PPT als PPTX speichern
- PPT nach PPTX exportieren
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie Legacy-PPT-Dateien zu PPTX in Node.js mit Aspose.Slides. Enthält JavaScript-Beispiele für Einzeldatei- und Batch-Konvertierung, Fehlerbehandlung und Genauigkeitshinweise."
---
## **Übersicht**

PPT ist das veraltete binäre PowerPoint-Format, während PPTX das neuere Open XML-Format ist. Aspose.Slides für Node.js via Java kann eine PPT-Datei laden und sie ohne Microsoft PowerPoint als PPTX speichern. Dieser Artikel zeigt, wie man eine einzelne Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu überprüfen ist.

## **PPT-Datei in PPTX konvertieren**

Laden Sie die Quelldatei mit der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) Klasse und rufen Sie dann [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/) auf. Der `finally`-Block gibt die Präsentation frei und gibt ihre Ressourcen frei.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Laden Sie die Legacy-PPT-Präsentation.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Speichern Sie die Präsentation im PPTX-Format.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Dateierweiterung bestimmt das Ausgabeformat nicht von selbst; das Argument [SaveFormat.Pptx](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/) tut es. Halten Sie die Eingabe‑ und Ausgabe‑Pfad unterschiedlich, wenn Sie die ursprüngliche PPT‑Datei beibehalten müssen.

## **Mehrere PPT‑Dateien konvertieren**

Das folgende Beispiel konvertiert jede `.ppt`‑Datei in einem Verzeichnis. Jede Datei wird unabhängig verarbeitet, sodass ein fehlgeschlagener Vorgang den Rest des Stapels nicht stoppt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Für Produktionsszenarien sollten Sie den vollständigen Fehler protokollieren, entscheiden, ob eine vorhandene Ausgabedatei überschrieben werden darf, und fehlerhafte Dateinamen in eine Wiederhol‑ oder Prüfwarteschlange schreiben. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet werden, nicht zugängliche Pfade und nicht unterstützte Inhalte können alle dazu führen, dass die Konvertierung fehlschlägt. Siehe [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) zum Laden verschlüsselter Dateien.

## **Genauigkeit und Legacy‑Funktionen**

Die Konvertierung bewahrt normalerweise Folien, Master, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. PPT und PPTX stellen jedoch nicht jedes Feature exakt gleich dar. Ein Legacy‑Feature, für das es kein PPTX‑Äquivalent gibt oder das von der Bibliothek nicht unterstützt wird, kann normalisiert, weggelassen oder anders dargestellt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verknüpfte OLE‑Objekte, ActiveX‑Steuerelemente, eingebettete Medien, ungewöhnliche Schriften oder VBA‑Makros enthält. Eine einfache PPTX‑Datei ist kein makrofähiges Format, daher sollten Sie einen entsprechenden makrofähigen Workflow verwenden, wenn VBA erhalten bleiben muss. Vergewissern Sie sich außerdem, dass erforderliche Schriften und externe Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder gerendert wird.

Für wichtige Dokumente sollten Sie das erzeugte PPTX programmgesteuert erneut öffnen und zentrale Folienzahlen sowie Inhalte prüfen, anschließend das Aussehen und das Bildlaufverhalten im gewünschten Viewer vergleichen. Betrachten Sie einen erfolgreichen Aufruf von [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save) nicht als Nachweis, dass jedes Legacy‑Feature eine exakte PPTX‑Darstellung hat.

## **Wann PPTX verwenden**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint‑Versionen bearbeitet, mit Systemen ausgetauscht wird, die Open‑XML‑Pakete verarbeiten, oder in einem Format gespeichert werden soll, das leichter zu inspizieren und wiederherzustellen ist als das alte binäre PPT. Bewahren Sie das ursprüngliche PPT als Archiv‑ oder Rollback‑Kopie auf, bis die konvertierte Präsentation Ihre Genauigkeitsprüfungen bestanden hat.

Falls Sie stattdessen PDF, HTML, Bilder, XPS oder einen anderen Ausgabetyp benötigen, nutzen Sie die formatbezogene Anleitung in [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/), anstatt anzunehmen, dass alle Ziele bearbeitbare PowerPoint‑Features erhalten.

## **Online‑Konverter**

Für eine gelegentliche Datei oder einen schnellen Vergleich können Sie den [online PPT to PPTX converter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) verwenden. Für wiederholbare Konvertierungen, Stapelverarbeitung oder Fehlerbehandlung auf Anwendungsebene nutzen Sie die Node.js‑via‑Java‑API.

## **Verwandte Artikel**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/nodejs-java/save-presentation/)
- [Supported File Formats](/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/nodejs-java/open-presentation/)

## **FAQ**

**Kann ich PPT in PPTX konvertieren, ohne dass Microsoft PowerPoint installiert ist?**

Ja. Aspose.Slides für Node.js via Java lädt und speichert Präsentationsdateien, ohne dass Microsoft PowerPoint erforderlich ist.

**Wird die PPT‑zu‑PPTX‑Konvertierung den gesamten Inhalt exakt erhalten?**

Sie bewahrt den üblichen Präsentationsinhalt, aber eine exakte Treue ist für jedes Legacy‑ oder nicht unterstützte Feature nicht garantiert. Überprüfen Sie die erzeugte Datei, wenn sie Makros, OLE‑ oder ActiveX‑Objekte, Medien, spezialisierte Animationen oder ungewöhnliche Schriften enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, sofern Sie beim Laden der Datei das korrekte Passwort angeben. Ein fehlendes oder falsches Passwort führt dazu, dass der Ladevorgang fehlschlägt.

**Sollte ich die PPT‑Datei nach der Konvertierung löschen?**

Bewahren Sie das Original auf, bis Sie das PPTX in den für Sie relevanten Viewern und Workflows geprüft haben. So haben Sie eine Rollback‑Kopie, falls ein Legacy‑Feature anders konvertiert wird.