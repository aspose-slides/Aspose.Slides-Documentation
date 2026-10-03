---
title: PowerPoint-Präsentationen in XML konvertieren in Java
linktitle: PowerPoint zu XML
type: docs
weight: 145
url: /de/java/convert-powerpoint-to-xml/
keywords:
- PowerPoint in XML konvertieren
- Präsentation in XML konvertieren
- PPT zu XML
- PPTX zu XML
- ODP zu XML
- PowerPoint XML-Präsentation
- SaveFormat.Xml
- Präsentation als XML speichern
- Präsentation nach XML exportieren
- XML-Stream
- Java
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Präsentationen in PowerPoint-XML-Dateien oder -Streams in Java mit Aspose.Slides für Java konvertieren."
---
## **Übersicht**

Aspose.Slides for Java kann PowerPoint‑Präsentationen in das PowerPoint‑XML‑Präsentationsformat konvertieren. XML‑Ausgabe ist nützlich, wenn Sie eine textbasierte Darstellung zur Inspektion der Präsentationsstruktur, Fehlersuche bei erzeugten Dokumenten, zum Vergleich von Ausgaben in automatisierten Tests oder zur Integration in einen Workflow benötigen, der XML anstelle eines Präsentationspakets verarbeitet.

Verwenden Sie die [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode mit dem `Xml`‑Wert aus der [SaveFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/)‑Klasse. Sie können das Ergebnis direkt in eine Datei oder in einen Stream schreiben.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` erstellt eine PowerPoint‑XML‑Präsentation. Es extrahiert nicht die einzelnen Office‑Open‑XML‑Teile, die in einem PPTX‑Paket gespeichert sind. Wenn Sie die genauen PPTX‑Paket‑Teile benötigen, wie `ppt/presentation.xml` oder einzelne Folien‑XML‑Dateien, untersuchen Sie das PPTX‑Paket selbst.

{{% /alert %}}

## **Konvertieren einer Präsentation in eine XML‑Datei**

Laden Sie eine Quellpräsentation mit der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse und übergeben Sie anschließend den Ausgabepfad sowie `SaveFormat.Xml` an [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Die Quelle kann jedes von Aspose.Slides unterstützte Präsentationsformat zum Laden sein, z. B. PPT, PPTX oder ODP.

Das folgende Beispiel konvertiert eine PPTX‑Präsentation in eine XML‑Datei:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML‑Ausgabe in einen Stream schreiben**

Verwenden Sie die Stream‑Überladung von [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-), wenn die XML‑Ausgabe im Speicher bleiben oder an eine andere Komponente weitergegeben werden soll, z. B. an einen Web‑Service, Speicher‑Provider oder eine XML‑Verarbeitungspipeline. Das folgende Beispiel schreibt das Ergebnis in einen [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) und erhält die resultierende XML als Byte‑Array:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // xmlData an die nächste Komponente im Workflow übergeben.
} finally {
    presentation.dispose();
}
```

## **XML mit Präsentations‑ und Exportformaten vergleichen**

Wählen Sie das Ausgabeformat entsprechend der geplanten Verwendung des Ergebnisses:

| Format | Ausgabe | Typische Verwendung |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Eine PowerPoint‑XML‑Präsentation | Strukturanalyse, Fehlersuche, Vergleich der erzeugten Ausgabe und XML‑basierte Integration |
| PPT (`.ppt`) | Eine veraltete binäre Präsentationsdatei | Kompatibilität mit älteren PowerPoint‑Workflows |
| PPTX (`.pptx`) | Ein Office‑Open‑XML‑Paket, das mehrere Teile enthält | Reguläre PowerPoint‑Bearbeitung und -Austausch |
| PDF oder TIFF | Seiten mit festem Layout oder ein mehrseitiges Bild | Anzeigen, Drucken und Archivieren |
| PNG, JPEG oder SVG | Eine gerenderte Darstellung einer einzelnen Folie | Vorschaubilder, Vorschauen und Bildressourcen |
| HTML oder HTML5 | Weborientierte Präsentationsausgabe | Betrachtung im Browser und Web‑Veröffentlichung |

Im Gegensatz zu PPT und PPTX ist die XML‑Ausgabe primär für Inspektions‑ und datenorientierte Workflows gedacht. Im Gegensatz zu PDF, TIFF, HTML und Bildformaten für Folien stellt sie Präsentationsdaten bereit, anstatt Folien als Seiten oder visuelle Assets zu rendern. Die Tabelle [unterstützte Dateiformate](/slides/de/java/supported-file-formats/) listet jedes Format auf, das Aspose.Slides laden, importieren, speichern oder rendern kann.

## **FAQ**

**Ist `SaveFormat.Xml` dasselbe wie das Speichern einer PPTX‑Datei?**

Nein. PPTX ist ein Paket, das mehrere Office‑Open‑XML‑Teile enthält, während `SaveFormat.Xml` eine PowerPoint‑XML‑Präsentationsdatei erstellt.

**Kann ich die XML‑Ausgabe speichern, ohne eine Datei auf dem Datenträger zu erzeugen?**

Ja. Übergeben Sie einen beschreibbaren Stream an [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Verwenden Sie beispielsweise einen [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) für die Verarbeitung im Speicher.

**Kann Aspose.Slides die exportierte XML‑Datei erneut laden?**

Ja. Übergeben Sie die XML‑Datei oder einen Stream an den [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#Presentation-java.lang.String-)‑Konstruktor. [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getSourceFormat--) liefert dann `SourceFormat.Xml`. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) gibt `LoadFormat.Unknown` für dieses Format zurück, sodass Sie es nicht zur Entscheidung nutzen sollten, ob eine XML‑Datei geöffnet werden kann.

**Wandelt die XML‑Konvertierung jede Folie in eine Seite oder ein Bild um?**

Nein. Die XML‑Konvertierung schreibt strukturierte Präsentationsdaten. Verwenden Sie PDF oder TIFF für seitenorientierte Ausgaben bzw. PNG, JPEG und SVG für einzelne Folien‑Bilder.