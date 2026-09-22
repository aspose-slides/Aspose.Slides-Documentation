---
title: Ermitteln des ursprünglichen Präsentationsformats in PHP
linktitle: Quellformat
type: docs
weight: 35
url: /de/php-java/detect-presentation-source-format/
keywords:
- Quellformat
- Präsentationsformat erkennen
- PowerPoint
- OpenDocument
- Präsentation
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Lesen Sie das ursprüngliche Format einer geladenen Präsentation in PHP mit Aspose.Slides für PHP über Java, vergleichen Sie Erkennungs-APIs und verarbeiten Sie Dateien, Streams und Legacy-Formate."
---
## **Übersicht**

Nach dem Laden einer Präsentation rufen Sie die [Presentation::getSourceFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSourceFormat) Methode auf, um das ursprüngliche Format zu bestimmen. Verwenden Sie sie, wenn die nachfolgende Verarbeitung vom Format abhängt, aus dem die aktuelle Instanz geladen wurde.

Das Quellformat unterscheidet sich vom für eine Ausgabedatei gewählten [SaveFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/). Das Speichern in ein anderes Format ändert das Quellformat der bestehenden Instanz nicht.

## **Quellformat einer Datei auslesen**

Dieses Beispiel benötigt eine vorhandene Datei `sample.pptx`. Es lädt die Datei und wählt eine Anwendungs‑Verarbeitungspolitik mittels [Presentation::getSourceFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSourceFormat) aus, anstatt den Dateinamen zu verwenden. Ändern Sie den Eingabepfad, um andere Formate zu testen. Das Beispiel gibt die ausgewählte Richtlinie aus; ersetzen Sie die Meldungen durch Ihre Anwendungslogik.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **Erkennen der unterstützten Werte**

Die Klasse [SourceFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/sourceformat/) definiert Ganzzahlkonstanten, die die folgenden Präsentationsformate unterscheiden. Die nachstehenden Erweiterungen sind konventionelle Erweiterungen und stellen keine Rekonstruktion des ursprünglichen Dateinamens dar.

| SourceFormat‑Wert | Erweiterung | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑97–2003‑Präsentation |
| `Pptx` | `.pptx` | Office‑Open‑XML‑Präsentation |
| `Pptm` | `.pptm` | Makro‑aktivierte Office‑Open‑XML‑Präsentation |
| `Pps` | `.pps` | PowerPoint‑97–2003‑Bildschirmpräsentation |
| `Ppsx` | `.ppsx` | Office‑Open‑XML‑Bildschirmpräsentation |
| `Ppsm` | `.ppsm` | Makro‑aktivierte Office‑Open‑XML‑Bildschirmpräsentation |
| `Pot` | `.pot` | PowerPoint‑97–2003‑Vorlage |
| `Potx` | `.potx` | Office‑Open‑XML‑Vorlage |
| `Potm` | `.potm` | Makro‑aktivierte Office‑Open‑XML‑Vorlage |
| `Odp` | `.odp` | OpenDocument‑Präsentation |
| `Otp` | `.otp` | OpenDocument‑Präsentationsvorlage |
| `Fodp` | `.fodp` | Flache XML‑ODF‑Präsentation |
| `Xml` | `.xml` | PowerPoint‑XML‑Präsentation |

## **Quellformat eines Streams auslesen**

Dieses Beispiel benötigt eine vorhandene Datei `sample.pps`. Das Einlesen ihrer Bytes in einen Speicher‑Stream simuliert Eingaben, die ohne Dateinamen empfangen werden, z. B. ein Datenbankwert oder ein hochgeladenes Byte‑Array. Der Konstrukteur von [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) erhält ausschließlich den Stream.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS und POT verwenden dasselbe zugrundeliegende Binärformat. Beim Laden über einen Dateipfad kann die Erweiterung dabei helfen, zwischen einer Bildschirmpräsentation oder Vorlage zu unterscheiden. Ohne Dateinamen kann alter PPS‑ und POT‑Inhalt als `SourceFormat::Ppt` gemeldet werden; das oben gezeigte PPS‑Beispiel gibt den Ganzzahlwert von `SourceFormat::Ppt` aus.

Wenn Ihre Anwendung die Unterscheidung bewahren muss, speichern Sie den ursprünglichen Dateinamen oder Subtyp‑Metadaten separat. Eine Erweiterung ist ein hilfreicher Hinweis für diese alten Subtypen, sollte jedoch nicht die einzige Grundlage zur Identifizierung beliebiger Präsentationsinhalte sein.

## **Erkennung vor und nach dem Laden vergleichen**

Verwenden Sie [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/#getPresentationInfo) und [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#getLoadFormat), wenn Sie eine Datei prüfen müssen, bevor ihr vollständiges Präsentations‑Objektmodell geladen wird. Verwenden Sie [Presentation::getSourceFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSourceFormat), wenn die Instanz bereits existiert.

Dieses Beispiel benötigt `sample.pptx` und gibt die Ganzzahlwerte von `LoadFormat::Pptx` bzw. `SourceFormat::Pptx` aus. In der Produktion wählen Sie die für Ihre Verarbeitungsphase passende API; eine bereits geladene Präsentation benötigt keine zweite Prüfung, um lediglich ihr Quellformat zu erhalten.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Die Ergebnisse verwenden Konstanten aus verschiedenen Klassen: [LoadFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadformat/) und [SourceFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/sourceformat/). Vergleichen Sie deren numerische Werte nicht und gehen Sie nicht davon aus, dass jedes Format identische Erkennungsergebnisse liefert. PowerPoint‑XML kann vor dem Laden als `LoadFormat::Unknown` und nach dem Laden als `SourceFormat::Xml` gemeldet werden.

## **Quell‑ und Ausgabeformate getrennt halten**

Dieses Beispiel benötigt `sample.pptx` und schreibt `converted.odp`. Es gibt den Ganzzahlwert von `SourceFormat::Pptx` sowohl vor als auch nach dem Speichern der ursprünglichen Instanz aus. Nur die neue, aus der ODP‑Ausgabe geladene Instanz meldet `Odp`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Eine von Grund auf mit `new Presentation()` erstellte Präsentation meldet `SourceFormat::Pptx`. Sie hat keine Eingabedatei: Dies ist der Standardwert für eine neu erstellte Instanz und kein Hinweis darauf, dass eine PPTX‑Datei geladen wurde. Verfolgen Sie, ob Ihre Anwendung die Instanz erstellt oder geladen hat, falls diese Unterscheidung von Bedeutung ist.

## **Ein Quellformat einer Erweiterung zuordnen**

Das folgende Beispiel benötigt `sample.pptx`. Es ordnet jedem aktuell unterstützten [SourceFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/sourceformat/)-Wert eine konventionelle Erweiterung zu, ohne den Eingabedateinamen zu analysieren. Der Fallback verhindert, dass stillschweigend einer nicht erkannten Variable eine Erweiterung zugewiesen wird.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Diese Zuordnung konvertiert keine Datei und stellt keinen alten PPS‑/POT‑Subtyp wieder her, der beim Laden aus einem Stream verloren ging. Für das tatsächliche Speichern wählen Sie ein [SaveFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/) explizit aus oder verwenden die in [Save Presentations in Their Original Format](/slides/de/php-java/save-presentation/#save-presentations-in-their-original-format) gezeigte Konvertierung.

## **Formate durch Speichern und erneutes Öffnen verifizieren**

Dieses eigenständige Beispiel erstellt eine Präsentation und schreibt drei Dateien in das Arbeitsverzeichnis, wobei vorhandene Dateien mit denselben Namen überschrieben werden. Es öffnet jede Ausgabe sowohl über den Pfad als auch über einen Speicher‑Stream erneut. Für PPTX und ODP melden beide Wege das gespeicherte Format. Für PPS meldet das Laden über den Pfad `Pps`, während das Laden derselben Bytes ohne Dateinamen `Ppt` zurückgibt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Die folgende Tabelle fasst die Quellformat‑Identifikation für Präsentationen mit übereinstimmenden Erweiterungen zusammen. Die Namen stehen für Konstanten; die PHP‑Beispiele geben deren Ganzzahlwerte aus:

| Gespeichertes Format | SourceFormat aus einem Dateipfad | SourceFormat aus einem namenlosen Stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` jeweils | Wie Dateipfad |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` jeweils | Wie Dateipfad |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` jeweils | Wie Dateipfad |
| ODP, OTP | `Odp`, `Otp` jeweils | Wie Dateipfad |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS‑/POT‑Inhalt wird für namenlose Streams als `Ppt` identifiziert. Die Tabelle beschreibt die Format‑Identifikation, nicht die Erhaltung aller Präsentations‑Features während einer Konvertierung.

## **FAQ**

**Ändert das Speichern im ODP‑Format das Quellformat einer aus PPTX geladenen Präsentation?**

Nein. Die bestehende Instanz meldet weiterhin `Pptx`. Eine aus der gespeicherten ODP‑Datei geladene Instanz meldet `Odp`.

**Kann ein Stream immer zwischen einer alten Präsentation, Bildschirmpräsentation und Vorlage unterscheiden?**

Nein. PPT, PPS und POT teilen das Binärformat. Speichern Sie den Dateinamen oder Subtyp‑Metadaten separat, wenn diese Unterscheidung erforderlich ist.

**Welche API sollte ich verwenden, wenn die Präsentation bereits geladen ist?**

Lesen Sie [Presentation::getSourceFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSourceFormat). Verwenden Sie [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/#getPresentationInfo) zur Inspektion vor dem Laden.