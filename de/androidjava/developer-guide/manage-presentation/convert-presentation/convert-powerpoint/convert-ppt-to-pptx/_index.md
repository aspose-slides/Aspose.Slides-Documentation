---
title: PPT zu PPTX auf Android konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie Legacy-PPT-Dateien zu PPTX auf Android mit Aspose.Slides. Enthält Java‑Beispiele für Einzel‑ und Stapelkonvertierung, Fehlerbehandlung und Genauigkeitshinweise."
---
## **Übersicht**

PPT ist das veraltete binäre PowerPoint‑Format, während PPTX das neuere Open‑XML‑Format ist. Aspose.Slides für Android via Java kann eine PPT‑Datei laden und sie ohne Microsoft PowerPoint als PPTX speichern. Dieser Artikel zeigt, wie man eine Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu überprüfen ist.

## **PPT‑Datei in PPTX konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) , dann rufen Sie [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/#Pptx) auf. Der `finally`‑Block setzt die Präsentation frei und gibt ihre Ressourcen frei.

```java
// Legacy-PPT-Präsentation laden.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Präsentation im PPTX-Format speichern.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Dateierweiterung wählt das Ausgabeformat nicht automatisch aus; das Argument [SaveFormat.Pptx](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/#Pptx) tut es. Halten Sie Eingabe‑ und Ausgabepfade unterschiedlich, wenn Sie die ursprüngliche PPT‑Datei behalten müssen.

## **Mehrere PPT‑Dateien konvertieren**

Das folgende Beispiel konvertiert jede `.ppt`‑Datei in einem Verzeichnis. Jede Datei wird unabhängig verarbeitet, sodass ein fehlgeschlagener Vorgang den Rest des Stapels nicht stoppt.

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

Für produktive Einsätze sollten Sie die vollständige Ausnahme protokollieren, entscheiden, ob eine vorhandene Ausgabedatei überschrieben werden darf, und fehlgeschlagene Dateinamen in eine Wiederholungs‑ oder Prüfungswarteschlange schreiben. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet werden, nicht zugängliche Pfade und nicht unterstützte Inhalte können alle zu einem Fehlversagen der Konvertierung führen. Siehe [Passwortgeschützte Präsentationen](/androidjava/password-protected-presentation/) zum Laden verschlüsselter Dateien.

## **Genauigkeit und Legacy‑Funktionen**

Die Konvertierung bewahrt normalerweise Folien, Vorlagen, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. Allerdings stellen PPT und PPTX nicht jedes Feature exakt gleich dar. Ein Legacy‑Feature, das kein PPTX‑Äquivalent hat oder von der Bibliothek nicht unterstützt wird, kann normalisiert, weggelassen oder anders dargestellt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verknüpfte OLE‑Objekte, ActiveX‑Steuerelemente, eingebettete Medien, ungewöhnliche Schriften oder VBA‑Makros enthält. Eine reine PPTX‑Datei ist kein makrofähiges Format, verwenden Sie also einen geeigneten makrofähigen Arbeitsablauf, wenn VBA erhalten bleiben muss. Vergewissern Sie sich außerdem, dass erforderliche Schriften und externe Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder gerendert wird.

Für wichtige Dokumente öffnen Sie die erzeugte PPTX‑Datei programmgesteuert erneut und prüfen Sie wichtige Folienanzahlen und Inhalte, und vergleichen Sie anschließend ihr Aussehen sowie das Verhalten der Diashow im vorgesehenen Viewer. Betrachten Sie einen erfolgreichen Aufruf von [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) nicht als Beweis dafür, dass jedes Legacy‑Feature eine exakte PPTX‑Darstellung hat.

## **Wann PPTX verwenden**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint‑Versionen bearbeitet, mit Systemen ausgetauscht wird, die mit Open‑XML‑Paketen arbeiten, oder in einem Format gespeichert werden soll, das leichter zu inspizieren und wiederherzustellen ist als das alte binäre PPT. Bewahren Sie das ursprüngliche PPT als Archiv‑ oder Rollback‑Kopie auf, bis die konvertierte Präsentation Ihre Genauigkeitsprüfungen bestanden hat.

Falls Sie stattdessen PDF, HTML, Bilder, XPS oder ein anderes Ausgabeformat benötigen, verwenden Sie die format‑spezifische Anleitung in [Präsentationen in mehrere Formate konvertieren](/slides/de/androidjava/convert-presentation/), anstatt anzunehmen, dass alle Zielformate bearbeitbare PowerPoint‑Features erhalten.

## **Online‑Konverter**

Für eine gelegentliche Datei oder einen schnellen Vergleich können Sie den [Online‑PPT‑zu‑PPTX‑Konverter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) verwenden. Für wiederholbare Konvertierungen, Stapelverarbeitung oder fehlerbehandlung auf Anwendungsebene nutzen Sie die Android‑via‑Java‑API.

## **Verwandte Artikel**

- [PPT versus PPTX](/slides/de/androidjava/ppt-vs-pptx/)
- [Präsentationen auf Android speichern](/slides/de/androidjava/save-presentation/)
- [Unterstützte Dateiformate](/slides/de/androidjava/supported-file-formats/)
- [Präsentationen auf Android öffnen](/slides/de/androidjava/open-presentation/)

## **FAQ**

**Kann ich PPT zu PPTX konvertieren, ohne dass Microsoft PowerPoint installiert ist?**

Ja. Aspose.Slides für Android via Java lädt und speichert Präsentationsdateien, ohne Microsoft PowerPoint zu benötigen.

**Wird die PPT‑zu‑PPTX‑Konvertierung den gesamten Inhalt exakt erhalten?**

Sie bewahrt gängige Präsentationsinhalte, aber eine exakte Treue ist nicht für jedes Legacy‑ oder nicht unterstützte Feature garantiert. Überprüfen Sie die erzeugte Datei, wenn sie Makros, OLE‑ oder ActiveX‑Objekte, Medien, spezialisierte Animationen oder ungewöhnliche Schriften enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, wenn Sie beim Laden der Datei das korrekte Passwort angeben. Ein fehlendes oder falsches Passwort führt dazu, dass der Ladevorgang fehlschlägt.

**Soll ich die PPT‑Datei nach der Konvertierung löschen?**

Behalten Sie das Original, bis Sie die PPTX in den für Sie relevanten Viewern und Workflows verifiziert haben. Dies bietet eine Rollback‑Kopie, falls ein Legacy‑Feature anders konvertiert wird.