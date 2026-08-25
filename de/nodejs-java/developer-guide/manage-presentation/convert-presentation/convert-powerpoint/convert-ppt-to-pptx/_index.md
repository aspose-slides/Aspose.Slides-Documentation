---
title: PPT in Node.js nach PPTX konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/nodejs-java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
- PPT konvertieren
- PPT zu PPTX
- PPT als PPTX speichern
- PPT nach PPTX exportieren
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie Legacy-PPT-Dateien in PPTX in Node.js mit Aspose.Slides. Enthält JavaScript-Beispiele für Einzel- und Stapelkonvertierung, Fehlerbehandlung und Genauigkeitshinweise."
---
## **Übersicht**

PPT ist das veraltete binäre PowerPoint‑Format, während PPTX das neuere Open‑XML‑Format ist. Aspose.Slides für Node.js via Java kann eine PPT‑Datei laden und sie ohne Microsoft PowerPoint als PPTX speichern. Dieser Artikel zeigt, wie man eine Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu überprüfen ist.

## **Konvertieren einer PPT‑Datei in PPTX**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) und rufen Sie dann [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/) auf. Der `finally`‑Block gibt die Präsentation frei und gibt ihre Ressourcen zurück.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Lade die Legacy-PPT-Präsentation.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Speichere die Präsentation im PPTX-Format.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Dateierweiterung wählt das Ausgabeformat nicht automatisch aus; das Argument [SaveFormat.Pptx](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/) tut es. Verwenden Sie unterschiedliche Eingabe‑ und Ausgabepfade, wenn Sie die ursprüngliche PPT‑Datei behalten möchten.

## **Konvertieren mehrerer PPT‑Dateien**

Das folgende Beispiel konvertiert jede `.ppt`‑Datei in einem Verzeichnis. Jede Datei wird unabhängig verarbeitet, sodass ein fehlgeschlagener Vorgang den Rest der Stapelverarbeitung nicht stoppt.

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

Für produktive Workloads sollten Sie den vollständigen Fehler protokollieren, entscheiden, ob eine vorhandene Ausgabedatei überschrieben werden darf, und fehlgeschlagene Dateinamen in eine Wiederholungs‑ oder Prüfwarteschlange schreiben. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet werden, nicht erreichbare Pfade und nicht unterstützte Inhalte können alle dazu führen, dass die Konvertierung fehlschlägt. Siehe [Password-Protected Presentations](/slides/de/nodejs-java/password-protected-presentation/) zum Laden verschlüsselter Dateien.

## **Genauigkeit und Legacy‑Funktionen**

Die Konvertierung bewahrt normalerweise Folien, Masterfolien, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. Allerdings stellen PPT und PPTX nicht jedes Feature exakt gleich dar. Ein Legacy‑Feature, für das es keine PPTX‑Entsprechung gibt oder das von der Bibliothek nicht unterstützt wird, kann normalisiert, weggelassen oder anders dargestellt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verknüpfte OLE‑Objekte, ActiveX‑Steuerelemente, eingebettete Medien, seltene Schriftarten oder VBA‑Makros enthält. Eine reine PPTX‑Datei ist kein makrofähiges Format; verwenden Sie daher einen geeigneten makrofähigen Workflow, wenn VBA erhalten bleiben muss. Stellen Sie außerdem sicher, dass erforderliche Schriftarten und externe Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder gerendert wird.

Für wichtige Dokumente öffnen Sie das erzeugte PPTX programmgesteuert erneut, prüfen Sie wichtige Folienzahlen und Inhalte und vergleichen Sie anschließend Darstellung und Bildlaufverhalten im vorgesehenen Viewer. Betrachten Sie einen erfolgreichen Aufruf von [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save) nicht als Beweis dafür, dass jedes Legacy‑Feature eine exakte PPTX‑Entsprechung hat.

## **Wann PPTX verwenden**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint‑Versionen bearbeitet, mit Systemen ausgetauscht wird, die Open‑XML‑Pakete verarbeiten, oder in einem Format gespeichert werden soll, das leichter zu inspizieren und wiederherzustellen ist als das veraltete binäre PPT. Bewahren Sie das ursprüngliche PPT als Archiv‑ oder Rollback‑Kopie auf, bis die konvertierte Präsentation Ihre Genauigkeitsprüfungen bestanden hat.

Wenn Sie stattdessen PDF, HTML, Bilder, XPS oder ein anderes Ausgabeformat benötigen, nutzen Sie die formatbezogene Anleitung in [Convert Presentations to Multiple Formats](/slides/de/nodejs-java/convert-presentation/) und gehen nicht davon aus, dass alle Ziele bearbeitbare PowerPoint‑Features erhalten.

## **Online‑Konverter**

Für eine gelegentliche Datei oder einen schnellen Vergleich können Sie den [online PPT to PPTX converter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) verwenden. Für wiederholbare Konvertierungen, Stapelverarbeitung oder anwendungsseitiges Fehlermanagement nutzen Sie die Node.js‑via‑Java‑API.

## **Verwandte Artikel**

- [PPT vs PPTX](/slides/de/nodejs-java/ppt-vs-pptx/)
- [Präsentationen in Node.js speichern](/slides/de/nodejs-java/save-presentation/)
- [Unterstützte Dateiformate](/slides/de/nodejs-java/supported-file-formats/)
- [Präsentationen in Node.js öffnen](/slides/de/nodejs-java/open-presentation/)

## **FAQ**

**Kann ich PPT in PPTX konvertieren, ohne dass Microsoft PowerPoint installiert ist?**

Ja. Aspose.Slides für Node.js via Java lädt und speichert Präsentationsdateien, ohne Microsoft PowerPoint zu benötigen.

**Wird die PPT‑zu‑PPTX‑Konvertierung den gesamten Inhalt exakt erhalten?**

Sie bewahrt gängige Präsentationsinhalte, aber die exakte Treue ist nicht für jedes Legacy‑ oder nicht unterstützte Feature garantiert. Überprüfen Sie die erzeugte Datei, wenn sie Makros, OLE‑ oder ActiveX‑Objekte, Medien, spezialisierte Animationen oder seltene Schriftarten enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, sofern Sie beim Laden der Datei das korrekte Passwort übergeben. Ein fehlendes oder falsches Passwort führt dazu, dass der Ladevorgang fehlschlägt.

**Soll ich die PPT‑Datei nach der Konvertierung löschen?**

Bewahren Sie das Original auf, bis Sie das PPTX in den relevanten Viewern und Workflows verifiziert haben. So haben Sie eine Rollback‑Kopie, falls ein Legacy‑Feature anders konvertiert wird.