---
title: Bestimmen Sie das ursprüngliche Präsentationsformat auf Android
linktitle: Quellformat
type: docs
weight: 35
url: /de/androidjava/detect-presentation-source-format/
keywords:
- Quellformat
- Präsentationsformat erkennen
- PowerPoint
- OpenDocument
- Präsentation
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Lesen Sie das ursprüngliche Format einer geladenen Präsentation auf Android mit Aspose.Slides für Android über Java, vergleichen Sie Erkennungs-APIs und verarbeiten Sie Dateien, Streams und Legacy-Formate."
---
## **Übersicht**

Nach dem Laden einer Präsentation rufen Sie die [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSourceFormat--) Methode auf, um ihr ursprüngliches Format zu bestimmen. Die Methode ist auch über [IPresentation.getSourceFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) verfügbar. Verwenden Sie sie, wenn die nachfolgende Verarbeitung vom Format abhängt, aus dem die aktuelle Instanz geladen wurde.

Das Quellformat unterscheidet sich vom für eine Ausgabedatei ausgewählten [SaveFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/). Das Speichern in ein anderes Format ändert das Quellformat der bestehenden Instanz nicht.

Die Beispiele verwenden Java und Dateipfade. Auf Android ersetzen Sie die Beispielpfade durch Pfade im app‑zugänglichen Speicher, z. B. das interne Dateiverzeichnis Ihrer App.

## **Quellformat einer Datei lesen**

Dieses Beispiel benötigt eine vorhandene `sample.pptx`‑Datei. Es lädt die Datei und wählt eine Anwendungs‑Verarbeitungspolicy mittels [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSourceFormat--), anstatt den Dateinamen zu verwenden. Ändern Sie den Eingabepfad, um andere Formate zu testen. Das Beispiel gibt die gewählte Policy aus; ersetzen Sie die Meldungen durch Ihre Anwendungslogik.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Unterstützte Werte erkennen**

Die [SourceFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sourceformat/) Klasse definiert Ganzzahl‑Konstanten, die die folgenden Präsentationsformate unterscheiden. Die unten angegebenen Erweiterungen sind konventionelle Erweiterungen, keine Rekonstruktion des ursprünglichen Dateinamens.

| SourceFormat-Wert | Erweiterung | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003‑Präsentation |
| `Pptx` | `.pptx` | Office Open XML‑Präsentation |
| `Pptm` | `.pptm` | Makro‑aktivierte Office Open XML‑Präsentation |
| `Pps` | `.pps` | PowerPoint 97–2003‑Diashow |
| `Ppsx` | `.ppsx` | Office Open XML‑Diashow |
| `Ppsm` | `.ppsm` | Makro‑aktivierte Office Open XML‑Diashow |
| `Pot` | `.pot` | PowerPoint 97–2003‑Vorlage |
| `Potx` | `.potx` | Office Open XML‑Vorlage |
| `Potm` | `.potm` | Makro‑aktivierte Office Open XML‑Vorlage |
| `Odp` | `.odp` | OpenDocument‑Präsentation |
| `Otp` | `.otp` | OpenDocument‑Präsentationsvorlage |
| `Fodp` | `.fodp` | Flat‑XML‑ODF‑Präsentation |
| `Xml` | `.xml` | PowerPoint‑XML‑Präsentation |

## **Quellformat eines Streams lesen**

Dieses Beispiel benötigt eine vorhandene `sample.pps`‑Datei. Das Einlesen der Bytes in einen Speicher‑Stream simuliert Eingaben ohne Dateinamen, etwa einen Datenbankwert oder ein hochgeladenes Byte‑Array. Der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Konstruktor erhält nur den Stream.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS und POT verwenden dasselbe zugrunde liegende Binärformat. Beim Laden über einen Dateipfad kann die Erweiterung helfen, zwischen Diashow und Vorlage zu unterscheiden. Ohne Dateinamen kann Legacy‑PPS‑ und‑POT‑Inhalt als `SourceFormat.Ppt` gemeldet werden; das obige PPS‑Beispiel gibt den Ganzzahlwert von `SourceFormat.Ppt` aus.

Muss Ihre Anwendung die Unterscheidung bewahren, behalten Sie den ursprünglichen Dateinamen oder Metadaten zum Subtyp separat. Eine Erweiterung ist ein nützlicher Hinweis für diese Legacy‑Subtypen, sollte jedoch nicht die einzige Grundlage für die Identifizierung beliebiger Präsentationsinhalte sein.

## **Erkennung vor und nach dem Laden vergleichen**

Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) und [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) wenn Sie eine Datei vor dem Laden ihres kompletten Präsentations‑Objektmodells inspizieren müssen. Verwenden Sie [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSourceFormat--) wenn die Instanz bereits existiert.

Dieses Beispiel benötigt `sample.pptx` und gibt die Ganzzahlwerte von `LoadFormat.Pptx` bzw. `SourceFormat.Pptx` aus. In der Produktion wählen Sie die API, die zu Ihrem Verarbeitungs‑Stadium passt; eine bereits geladene Präsentation benötigt keine zweite Inspektion ausschließlich zum Abrufen ihres Quellformats.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Die Ergebnisse verwenden Konstanten aus unterschiedlichen Klassen: [LoadFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadformat/) und [SourceFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sourceformat/). Vergleichen Sie deren numerische Werte nicht und gehen Sie nicht davon aus, dass jedes Format identische Erkennungsergebnisse liefert. PowerPoint‑XML kann vor dem Laden als `LoadFormat.Unknown` und nach dem Laden als `SourceFormat.Xml` gemeldet werden.

## **Quell- und Ausgabeformate getrennt halten**

Dieses Beispiel benötigt `sample.pptx` und schreibt `converted.odp`. Es gibt den Ganzzahlwert von `SourceFormat.Pptx` sowohl vor als auch nach dem Speichern der ursprünglichen Instanz aus. Nur die neue Instanz, die aus der ODP‑Ausgabe geladen wird, meldet `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Eine von Grund auf neu erstellte Präsentation mittels `new Presentation()` meldet `SourceFormat.Pptx`. Sie hat keine Eingabedatei: Dies ist der Standardwert für eine neu erstellte Instanz, kein Hinweis darauf, dass eine PPTX‑Datei geladen wurde. Verfolgen Sie, ob Ihre Anwendung die Instanz erstellt oder geladen hat, falls diese Unterscheidung von Bedeutung ist.

## **Ein Quellformat einer Erweiterung zuordnen**

Das folgende Beispiel benötigt `sample.pptx`. Es ordnet jedem aktuell unterstützten [SourceFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sourceformat/)‑Wert eine konventionelle Erweiterung zu, ohne den Eingabedateinamen zu analysieren. Der Fallback verhindert, dass stillschweigend einer unbekannten Variante eine Erweiterung zugewiesen wird.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Diese Zuordnung konvertiert keine Datei und stellt keinen verlorenen Legacy‑PPS‑/‑POT‑Subtyp wieder her, der beim Laden aus einem Stream verloren ging. Für das eigentliche Speichern wählen Sie explizit ein [SaveFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/) oder verwenden die in [Save Presentations in Their Original Format](/slides/de/androidjava/save-presentation/#save-presentations-in-their-original-format) gezeigte Konvertierung.

## **Formate durch Speichern und erneutes Öffnen überprüfen**

Dieses eigenständige Beispiel erstellt eine Präsentation und schreibt drei Dateien in das Arbeitsverzeichnis, wobei Dateien mit denselben Namen überschrieben werden. Es öffnet jede Ausgabe sowohl über den Pfad als auch über einen Speicher‑Stream erneut. Für PPTX und ODP melden beide Wege das gespeicherte Format. Für PPS meldet das Laden über den Pfad `Pps`, während das Laden derselben Bytes ohne Dateinamen `Ppt` meldet.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Die folgende Tabelle fasst die Quellformat‑Identifikation für Präsentationen mit passenden Erweiterungen zusammen. Die Namen bezeichnen Konstanten; die Java‑Beispiele geben deren Ganzzahlwerte aus:

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

PPS‑/‑POT‑Inhalt wird für namenlose Streams als `Ppt` identifiziert. Die Tabelle beschreibt die Formatidentifikation, nicht die Bewahrung jeder Präsentationsfunktion während der Konvertierung.

## **FAQ**

**Ändert das Speichern in ODP das Quellformat einer aus PPTX geladenen Präsentation?**

Nein. Die bestehende Instanz meldet weiterhin `Pptx`. Eine aus der gespeicherten ODP‑Datei geladene Instanz meldet `Odp`.

**Kann ein Stream immer zwischen einer Legacy‑Präsentation, Diashow und Vorlage unterscheiden?**

Nein. PPT, PPS und POT teilen das Binärformat. Bewahren Sie Dateinamen oder Subtyp‑Metadaten separat, wenn diese Unterscheidung erforderlich ist.

**Welche API sollte ich verwenden, wenn die Präsentation bereits geladen ist?**

Lesen Sie [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSourceFormat--). Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) für die Inspektion vor dem Laden.