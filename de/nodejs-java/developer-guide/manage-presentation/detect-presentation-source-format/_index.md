---
title: Originales Präsentationsformat in Node.js ermitteln
linktitle: Quellformat
type: docs
weight: 35
url: /de/nodejs-java/detect-presentation-source-format/
keywords:
- Quellformat
- Präsentationsformat erkennen
- PowerPoint
- OpenDocument
- Präsentation
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Lesen Sie das ursprüngliche Format einer geladenen Präsentation in Node.js mit Aspose.Slides für Node.js via Java, vergleichen Sie Erkennungs‑APIs und verarbeiten Sie Dateien, Streams und Legacy‑Formate."
---
## **Übersicht**

Nachdem Sie eine Präsentation geladen haben, rufen Sie die Methode [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSourceFormat) auf, um ihr ursprüngliches Format zu bestimmen. Verwenden Sie sie, wenn die nachfolgende Verarbeitung vom Format abhängt, aus dem die aktuelle Instanz geladen wurde.

Das Quellformat unterscheidet sich vom für eine Ausgabedatei ausgewählten [SaveFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/). Das Speichern in ein anderes Format ändert das Quellformat der bestehenden Instanz nicht.

## **Quellformat einer Datei auslesen**

Dieses Beispiel benötigt eine vorhandene Datei `sample.pptx`. Es lädt die Datei und wählt eine Anwendungs‑Verarbeitungspolicy mit [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSourceFormat) aus, anstatt den Dateinamen zu verwenden. Ändern Sie den Eingabepfad, um andere Formate zu testen. Das Beispiel gibt die ausgewählte Policy aus; ersetzen Sie die Meldungen durch Ihre Anwendungslogik.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Erkennen der unterstützten Werte**

Die Klasse [SourceFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sourceformat/) definiert ganzzahlige Konstanten, die die folgenden Präsentationsformate unterscheiden. Die nachstehenden Erweiterungen sind konventionelle Dateiendungen und stellen keine Rekonstruktion des ursprünglichen Dateinamens dar.

| SourceFormat‑Wert | Erweiterung | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑97‑2003‑Präsentation |
| `Pptx` | `.pptx` | Office‑Open‑XML‑Präsentation |
| `Pptm` | `.pptm` | Makro‑aktivierte Office‑Open‑XML‑Präsentation |
| `Pps` | `.pps` | PowerPoint‑97‑2003‑Bildschirmpräsentation |
| `Ppsx` | `.ppsx` | Office‑Open‑XML‑Bildschirmpräsentation |
| `Ppsm` | `.ppsm` | Makro‑aktivierte Office‑Open‑XML‑Bildschirmpräsentation |
| `Pot` | `.pot` | PowerPoint‑97‑2003‑Vorlage |
| `Potx` | `.potx` | Office‑Open‑XML‑Vorlage |
| `Potm` | `.potm` | Makro‑aktivierte Office‑Open‑XML‑Vorlage |
| `Odp` | `.odp` | OpenDocument‑Präsentation |
| `Otp` | `.otp` | OpenDocument‑Präsentationsvorlage |
| `Fodp` | `.fodp` | Flat‑XML‑ODF‑Präsentation |
| `Xml` | `.xml` | PowerPoint‑XML‑Präsentation |

## **Quellformat eines Streams auslesen**

Dieses Beispiel benötigt eine vorhandene Datei `sample.pps`. Das Einlesen ihrer Bytes in einen Speicher‑Stream modelliert Eingaben, die ohne Dateinamen empfangen werden, wie z. B. ein Datenbankwert oder ein hochgeladenes Byte‑Array. Der Konstruktor von [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) erhält nur den Stream.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS und POT verwenden dasselbe zugrunde liegende Binärformat. Beim Laden über einen Dateipfad kann die Erweiterung helfen, eine Bildschirmpräsentation oder Vorlage zu unterscheiden. Ohne Dateinamen kann Legacy‑PPS‑ und‑POT‑Inhalt als `SourceFormat.Ppt` gemeldet werden; das obige PPS‑Beispiel gibt den ganzzahligen Wert von `SourceFormat.Ppt` aus.

Wenn Ihre Anwendung die Unterscheidung bewahren muss, speichern Sie den ursprünglichen Dateinamen oder Subtyp‑Metadaten getrennt. Eine Erweiterung ist ein nützlicher Hinweis für diese Legacy‑Subtypen, sollte jedoch nicht die einzige Grundlage zur Identifizierung beliebiger Präsentationsinhalte sein.

## **Erkennung vor und nach dem Laden vergleichen**

Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) und [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat), wenn Sie eine Datei prüfen müssen, bevor ihr vollständiges Präsentationsobjektmodell geladen wird. Verwenden Sie [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSourceFormat), wenn die Instanz bereits existiert.

Dieses Beispiel benötigt `sample.pptx` und gibt die ganzzahligen Werte von `LoadFormat.Pptx` bzw. `SourceFormat.Pptx` aus. In der Produktion wählen Sie die für Ihre Verarbeitungsphase geeignete API; eine bereits geladene Präsentation benötigt keine zweite Untersuchung ausschließlich zur Ermittlung ihres Quellformats.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Die Ergebnisse verwenden Konstanten aus verschiedenen Klassen: [LoadFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadformat/) und [SourceFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sourceformat/). Vergleichen Sie deren numerische Werte nicht und gehen Sie nicht davon aus, dass jedes Format identische Erkennungsergebnisse liefert. PowerPoint‑XML kann vor dem Laden als `LoadFormat.Unknown` und nach dem Laden als `SourceFormat.Xml` gemeldet werden.

## **Quell‑ und Ausgabeformate getrennt halten**

Dieses Beispiel benötigt `sample.pptx` und schreibt `converted.odp`. Es gibt den ganzzahligen Wert von `SourceFormat.Pptx` sowohl vor als auch nach dem Speichern der ursprünglichen Instanz aus. Nur die neue Instanz, die aus der ODP‑Ausgabe geladen wird, meldet `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Eine mit `new Presentation()` von Grund auf neu erstellte Präsentation meldet `SourceFormat.Pptx`. Sie hat keine Eingabedatei: Dies ist der Standardwert für eine neu erstellte Instanz, kein Hinweis darauf, dass eine PPTX‑Datei geladen wurde. Verfolgen Sie, ob Ihre Anwendung die Instanz erstellt oder geladen hat, wenn diese Unterscheidung wichtig ist.

## **Ein Quellformat einer Erweiterung zuordnen**

Das folgende Beispiel benötigt `sample.pptx`. Es ordnet jedem aktuell unterstützten [SourceFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sourceformat/)-Wert eine konventionelle Erweiterung zu, ohne den Eingabedateinamen zu analysieren. Der Fallback verhindert, dass stillschweigend einer nicht erkannten Quelle eine Erweiterung zugewiesen wird.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Diese Zuordnung konvertiert keine Datei und stellt keinen Legacy‑PPS/POT‑Subtyp wieder her, der beim Laden aus einem Stream verloren ging. Für das tatsächliche Speichern wählen Sie explizit ein [SaveFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/) aus oder verwenden Sie die in [Save Presentations in Their Original Format](/slides/de/nodejs-java/save-presentation/#save-presentations-in-their-original-format) gezeigte Konvertierung.

## **Formate durch Speichern und erneutes Öffnen verifizieren**

Dieses eigenständige Beispiel erstellt eine Präsentation und schreibt drei Dateien im Arbeitsverzeichnis, wobei Dateien mit denselben Namen überschrieben werden. Es öffnet jede Ausgabe sowohl über den Pfad als auch über einen Speicher‑Stream erneut. Für PPTX und ODP melden beide Wege das gespeicherte Format. Für PPS meldet das Laden über den Pfad `Pps`, während das Laden derselben Bytes ohne Dateinamen `Ppt` meldet.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Die folgende Tabelle fasst die Quellformat‑Identifizierung für Präsentationen mit übereinstimmenden Erweiterungen zusammen. Namen bezeichnen Konstanten; die JavaScript‑Beispiele geben ihre ganzzahligen Werte aus:

| Gespeichertes Format | SourceFormat aus einem Dateipfad | SourceFormat aus einem namenlosen Stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS‑/POT‑Inhalt wird für namenlose Streams als `Ppt` identifiziert. Die Tabelle beschreibt die Formatidentifikation, nicht die Erhaltung aller Präsentationsfunktionen während der Konvertierung.

## **FAQ**

**Ändert das Speichern im ODP‑Format das Quellformat einer aus PPTX geladenen Präsentation?**

Nein. Die bestehende Instanz meldet weiterhin `Pptx`. Eine aus der gespeicherten ODP‑Datei geladene Instanz meldet `Odp`.

**Kann ein Stream stets zwischen einer Legacy‑Präsentation, einer Bildschirmpräsentation und einer Vorlage unterscheiden?**

Nein. PPT, PPS und POT verwenden dasselbe Binärformat. Bewahren Sie den Dateinamen oder Subtyp‑Metadaten getrennt auf, wenn diese Unterscheidung erforderlich ist.

**Welche API sollte ich verwenden, wenn die Präsentation bereits geladen ist?**

Lesen Sie [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSourceFormat). Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) für die Inspektion vor dem Laden.