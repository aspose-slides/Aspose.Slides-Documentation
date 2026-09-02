---
title: PPT in PPTX mit Java konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Konvertieren Sie Legacy-PPT-Dateien in PPTX in Java mit Aspose.Slides. Enthält Java-Beispiele für Einzeldatei- und Batch-Konvertierung, Fehlerbehandlung und Hinweis zur Treue."
---
## **Übersicht**

PPT ist das veraltete binäre PowerPoint-Format, während PPTX das neuere Open-XML-Format ist. Aspose.Slides für Java kann eine PPT-Datei laden und sie ohne Microsoft PowerPoint als PPTX speichern. Dieser Artikel zeigt, wie man eine Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu prüfen ist.

## **PPT-Datei in PPTX konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) und rufen Sie dann [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-) mit dem Argument [SaveFormat.Pptx](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/#Pptx) auf. Der `finally`-Block gibt die Präsentation frei und releasert ihre Ressourcen.

```java
// Laden Sie die Legacy-PPT-Präsentation.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Speichern Sie die Präsentation im PPTX-Format.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Dateierweiterung wählt das Ausgabeformat nicht automatisch aus; das Argument [SaveFormat.Pptx] tut es. Halten Sie Eingabe- und Ausgabepfade unterschiedlich, wenn Sie die ursprüngliche PPT-Datei beibehalten müssen.

## **Mehrere PPT-Dateien konvertieren**

Das folgende Beispiel konvertiert jede `.ppt`-Datei in einem Verzeichnis. Jede Datei wird unabhängig verarbeitet, sodass ein Fehlschlag bei einer Konvertierung den Rest des Stapels nicht stoppt.

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

Für Produktionsumgebungen sollten Sie die vollständige Ausnahme protokollieren, entscheiden, ob eine vorhandene Ausgabedatei überschrieben werden darf, und fehlerhafte Dateinamen in eine Wiederholungs- oder Prüfwarteschlange schreiben. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet werden, nicht zugängliche Pfade und nicht unterstützte Inhalte können eine Konvertierung fehlschlagen lassen. Siehe [Password-Protected Presentations](/java/password-protected-presentation/) zum Laden verschlüsselter Dateien.

## **Treue und Legacy-Funktionen**

Die Konvertierung bewahrt normalerweise Folien, Master, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. Allerdings stellen PPT und PPTX nicht jedes Feature exakt gleich dar. Ein Legacy-Feature, das kein PPTX-Äquivalent hat oder von der Bibliothek nicht unterstützt wird, kann normalisiert, weggelassen oder anders dargestellt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verlinkte OLE-Objekte, ActiveX-Steuerelemente, eingebettete Medien, ungewöhnliche Schriften oder VBA-Makros enthält. Eine reine PPTX-Datei ist kein makrofähiges Format, daher sollten Sie einen entsprechenden makrofähigen Workflow verwenden, wenn VBA erhalten bleiben muss. Vergewissern Sie sich außerdem, dass erforderliche Schriften und externe Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder gerendert wird.

Bei wichtigen Dokumenten öffnen Sie das erzeugte PPTX programmgesteuert erneut, prüfen Sie die Anzahl und den Inhalt wichtiger Folien und vergleichen Sie dann Aussehen und Bildlaufverhalten im gewünschten Viewer. Betrachten Sie einen erfolgreichen Aufruf von [Presentation.save] nicht als Nachweis dafür, dass jedes Legacy-Feature eine exakte PPTX-Darstellung hat.

## **Wann PPTX verwenden**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint-Versionen bearbeitet, mit Systemen ausgetauscht wird, die mit Open-XML-Paketen arbeiten, oder in einem Format gespeichert werden soll, das leichter zu prüfen und wiederherzustellen ist als das alte binäre PPT. Bewahren Sie das ursprüngliche PPT als Archiv- oder Rollback-Kopie auf, bis die konvertierte Präsentation Ihre Treue-Überprüfungen bestanden hat.

Falls Sie stattdessen PDF, HTML, Bilder, XPS oder ein anderes Ausgabeformat benötigen, nutzen Sie die formatbezogene Anleitung in [Convert Presentations to Multiple Formats](/java/convert-presentation/), anstatt anzunehmen, dass alle Ziele editierbare PowerPoint-Features erhalten.

## **Online-Konverter**

Für eine gelegentliche Datei oder einen schnellen Vergleich können Sie den [online PPT to PPTX converter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) nutzen. Für wiederholbare Konvertierungen, Batch-Verarbeitung oder Fehlerbehandlung auf Anwendungsebene verwenden Sie die Java-API.

## **Verwandte Artikel**

- [PPT vs PPTX](/java/ppt-vs-pptx/)
- [Präsentationen in Java speichern](/java/save-presentation/)
- [Unterstützte Dateiformate](/java/supported-file-formats/)
- [Präsentationen in Java öffnen](/java/open-presentation/)

## **FAQ**

**Kann ich PPT nach PPTX konvertieren, ohne dass Microsoft PowerPoint installiert ist?**

Ja. Aspose.Slides für Java lädt und speichert Präsentationsdateien, ohne Microsoft PowerPoint zu benötigen.

**Wird die PPT-zu-PPTX‑Konvertierung den gesamten Inhalt exakt erhalten?**

Sie bewahrt gängige Präsentationsinhalte, jedoch ist die exakte Treue für jedes Legacy- oder nicht unterstützte Feature nicht garantiert. Überprüfen Sie die erzeugte Datei, wenn sie Makros, OLE- oder ActiveX-Objekte, Medien, spezielle Animationen oder ungewöhnliche Schriften enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, wenn Sie beim Laden der Datei das korrekte Passwort angeben. Ein fehlendes oder falsches Passwort führt zum Fehlschlag des Ladevorgangs.

**Soll ich die PPT‑Datei nach der Konvertierung löschen?**

Behalten Sie das Original, bis Sie das PPTX in den für Sie relevanten Viewern und Workflows geprüft haben. Dadurch haben Sie eine Rollback-Kopie, falls ein Legacy-Feature anders konvertiert.