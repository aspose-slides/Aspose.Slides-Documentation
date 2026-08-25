---
title: PPT zu PPTX in Java konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPT zu PPTX
- PPT als PPTX speichern
- PPT nach PPTX exportieren
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Konvertieren Sie Legacy-PPT-Dateien in PPTX in Java mit Aspose.Slides. Enthält Java-Beispiele für Einzeldatei- und Batch-Konvertierung, Fehlermanagement und Hinweise zur Genauigkeit."
---
## **Übersicht**

PPT ist das veraltete binäre PowerPoint-Format, während PPTX das neuere Open XML-Format ist. Aspose.Slides für Java kann eine PPT-Datei laden und sie als PPTX speichern, ohne Microsoft PowerPoint zu benötigen. Dieser Artikel zeigt, wie man eine Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu überprüfen ist.

## **PPT-Datei nach PPTX konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) , dann rufen Sie [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/#Pptx) auf. Der `finally`-Block gibt die Präsentation frei und gibt ihre Ressourcen frei.

```java
// Laden Sie die alte PPT-Präsentation.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Speichern Sie die Präsentation im PPTX-Format.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Dateierweiterung bestimmt das Ausgabeformat nicht von selbst; das Argument [SaveFormat.Pptx](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/#Pptx) tut es. Halten Sie die Eingabe‑ und Ausgabepfade unterschiedlich, wenn Sie die ursprüngliche PPT‑Datei behalten müssen.

## **Mehrere PPT-Dateien konvertieren**

Das folgende Beispiel konvertiert jede `.ppt`‑Datei in einem Verzeichnis. Jede Datei wird unabhängig verarbeitet, sodass ein fehlgeschlagener Konvertierungsvorgang den Rest des Stapels nicht stoppt.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Für Produktionsszenarien protokollieren Sie die vollständige Ausnahme, entscheiden Sie, ob eine bestehende Ausgabedatei überschrieben werden darf, und schreiben Sie fehlgeschlagene Dateinamen in eine Wiederholungs‑ oder Prüfungswarteschlange. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet werden, nicht zugängliche Pfade und nicht unterstützte Inhalte können alle dazu führen, dass eine Konvertierung fehlschlägt. Siehe [Password-Protected Presentations](/slides/de/java/password-protected-presentation/) zum Laden verschlüsselter Dateien.

## **Genauigkeit und Legacy‑Funktionen**

Die Konvertierung bewahrt normalerweise Folien, Vorlagen, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. Allerdings stellen PPT und PPTX nicht jedes Merkmal exakt auf die gleiche Weise dar. Eine Legacy‑Funktion, für die es kein PPTX‑Äquivalent gibt oder die von der Bibliothek nicht unterstützt wird, kann normalisiert, weggelassen oder anders angezeigt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verknüpfte OLE‑Objekte, ActiveX‑Steuerelemente, eingebettete Medien, ungewöhnliche Schriftarten oder VBA‑Makros enthält. Eine reine PPTX‑Datei ist kein makrofähiges Format, daher verwenden Sie einen geeigneten makrofähigen Workflow, wenn VBA erhalten bleiben muss. Stellen Sie außerdem sicher, dass erforderliche Schriftarten und externe Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder gerendert wird.

Für wichtige Dokumente öffnen Sie das erzeugte PPTX programmgesteuert erneut und prüfen Sie wichtige Folienzahlen und Inhalte, dann vergleichen Sie das Aussehen und das Folien‑Show‑Verhalten im vorgesehenen Viewer. Behandeln Sie einen erfolgreichen Aufruf von [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-) nicht als Nachweis, dass jede Legacy‑Funktion eine exakte PPTX‑Darstellung hat.

## **Wann PPTX verwenden**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint‑Versionen bearbeitet, mit Systemen ausgetauscht wird, die mit Open‑XML‑Paketen arbeiten, oder in einem Format gespeichert werden soll, das leichter zu inspizieren und wiederherzustellen ist als das alte binäre PPT. Bewahren Sie das ursprüngliche PPT als Archiv‑ oder Rollback‑Kopie auf, bis die konvertierte Präsentation Ihre Genauigkeitsprüfungen bestanden hat.

Wenn Sie stattdessen PDF, HTML, Bilder, XPS oder einen anderen Ausgabetyp benötigen, verwenden Sie die formatspezifische Anleitung in [Convert Presentations to Multiple Formats](/slides/de/java/convert-presentation/), anstatt anzunehmen, dass alle Ziele bearbeitbare PowerPoint‑Funktionen erhalten.

## **Online‑Konverter**

Für eine gelegentliche Datei oder einen schnellen Vergleich können Sie den [online PPT to PPTX converter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) nutzen. Für wiederholbare Konvertierungen, Batch‑Verarbeitung oder Fehlerbehandlung auf Anwendungsebene verwenden Sie die Java‑API.

## **Verwandte Artikel**

- [PPT vs PPTX](/slides/de/java/ppt-vs-pptx/)
- [Präsentationen in Java speichern](/slides/de/java/save-presentation/)
- [Unterstützte Dateiformate](/slides/de/java/supported-file-formats/)
- [Präsentationen in Java öffnen](/slides/de/java/open-presentation/)

## **FAQ**

**Kann ich PPT nach PPTX konvertieren, ohne Microsoft PowerPoint installiert zu haben?**

Ja. Aspose.Slides für Java lädt und speichert Präsentationsdateien, ohne Microsoft PowerPoint zu benötigen.

**Wird die PPT‑zu‑PPTX‑Konvertierung sämtliche Inhalte exakt erhalten?**

Sie bewahrt gängige Präsentationsinhalte, aber exakte Treue ist nicht für jede Legacy‑ oder nicht unterstützte Funktion garantiert. Überprüfen Sie die erzeugte Datei, wenn sie Makros, OLE‑ oder ActiveX‑Objekte, Medien, spezialisierte Animationen oder ungewöhnliche Schriftarten enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, wenn Sie beim Laden der Datei das korrekte Passwort angeben. Ein fehlendes oder falsches Passwort führt zum Fehlschlagen des Ladevorgangs.

**Soll ich die PPT‑Datei nach der Konvertierung löschen?**

Behalten Sie das Original, bis Sie das PPTX in den für Sie relevanten Viewern und Workflows verifiziert haben. So haben Sie eine Rollback‑Kopie, falls eine Legacy‑Funktion anders konvertiert wird.