---
title: Konvertieren von PowerPoint-Präsentationen zu XML in Java
linktitle: PowerPoint zu XML
type: docs
weight: 145
url: /de/java/convert-powerpoint-to-xml/
keywords:
- PowerPoint zu XML konvertieren
- Präsentation zu XML konvertieren
- PPT zu XML
- PPTX zu XML
- ODP zu XML
- PowerPoint-XML-Präsentation
- SaveFormat.Xml
- Präsentation als XML speichern
- Präsentation nach XML exportieren
- XML-Stream
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Präsentationen in PowerPoint-XML-Dateien oder -Streams in Java mit Aspose.Slides für Java."
---
## **Übersicht**

Aspose.Slides für Java kann PowerPoint‑Präsentationen in das PowerPoint XML‑Präsentationsformat konvertieren. XML‑Ausgabe ist nützlich, wenn Sie eine textbasierte Darstellung benötigen, um die Präsentationsstruktur zu prüfen, generierte Dokumente zu troubleshooten, Ausgaben in automatisierten Tests zu vergleichen oder einen Workflow zu integrieren, der XML statt eines Präsentationspakets konsumiert.

Verwenden Sie die [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode mit dem `Xml`‑Wert aus der Klasse [SaveFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/). Das Ergebnis können Sie direkt in eine Datei oder in einen Stream schreiben.

{{% alert color="info" title="Hinweis" %}}
`SaveFormat.Xml` erstellt eine PowerPoint XML‑Präsentation. Es extrahiert nicht die einzelnen Office Open XML‑Teile, die in einem PPTX‑Paket gespeichert sind. Wenn Sie die genauen PPTX‑Paketteile benötigen, wie `ppt/presentation.xml` oder einzelne Folien‑XML‑Dateien, müssen Sie das PPTX‑Paket selbst untersuchen.
{{% /alert %}}

## **Eine Präsentation in eine XML‑Datei konvertieren**

Laden Sie eine Quell‑Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) und übergeben Sie dann den Ausgabepfad sowie `SaveFormat.Xml` an [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Die Quelle kann jedes für das Laden unterstützte Präsentationsformat sein, etwa PPT, PPTX oder ODP.

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

## **Das XML‑Ergebnis in einen Stream schreiben**

Verwenden Sie die Stream‑Überladung von [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-), wenn das XML im Speicher bleiben oder an eine andere Komponente wie einen Web‑Service, Speicher‑Provider oder eine XML‑Verarbeitungspipeline weitergegeben werden muss. Das folgende Beispiel schreibt das Ergebnis in einen [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) und erhält das resultierende XML als Byte‑Array:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Übergeben Sie xmlData an die nächste Komponente im Workflow.
} finally {
    presentation.dispose();
}
```

## **XML mit Präsentations‑ und Exportformaten vergleichen**

Wählen Sie das Ausgabformat danach aus, wie das Ergebnis verwendet werden soll:

| Format | Ausgabe | Typische Verwendung |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Eine PowerPoint XML‑Präsentation | Überprüfung der Struktur, Fehlersuche, Vergleich von generierten Ausgaben und XML‑basierte Integration |
| PPT (`.ppt`) | Eine veraltete binäre Präsentationsdatei | Kompatibilität mit älteren PowerPoint‑Workflows |
| PPTX (`.pptx`) | Ein Office Open XML‑Paket, das mehrere Teile enthält | Reguläre PowerPoint‑Bearbeitung und -Austausch |
| PDF oder TIFF | Seiten mit festem Layout oder ein mehrseitiges Bild | Anzeigen, Drucken und Archivieren |
| PNG, JPEG oder SVG | Eine gerenderte Darstellung einer einzelnen Folie | Miniaturansichten, Vorschaubilder und Bildressourcen |
| HTML oder HTML5 | Weborientierte Präsentationsausgabe | Browseranzeige und Web‑Veröffentlichung |

Im Gegensatz zu PPT und PPTX ist XML‑Ausgabe hauptsächlich für Inspektion und datenorientierte Workflows gedacht. Im Gegensatz zu PDF, TIFF, HTML und den Folien‑Bildformaten stellt sie Präsentationsdaten dar, anstatt Folien als Seiten oder visuelle Assets zu rendern. Die Tabelle der [unterstützten Dateiformate](/slides/de/java/supported-file-formats/) listet PowerPoint XML Presentation nur als reines Speicherformat auf; verwenden Sie es nicht, wenn ein Workflow die exportierte Datei wieder in Aspose.Slides laden muss, um die Bearbeitung fortzusetzen.

## **FAQ**

**Ist `SaveFormat.Xml` dasselbe wie das Speichern einer PPTX‑Datei?**

Nein. PPTX ist ein Paket, das mehrere Office Open XML‑Teile enthält, während `SaveFormat.Xml` eine PowerPoint XML‑Präsentationsdatei erzeugt.

**Kann ich die XML‑Ausgabe speichern, ohne eine Datei auf der Festplatte zu erstellen?**

Ja. Übergeben Sie einen schreibbaren Stream an [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Verwenden Sie beispielsweise einen [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) für die Verarbeitung im Speicher.

**Kann Aspose.Slides die exportierte XML‑Datei erneut laden?**

Nein. PowerPoint XML Presentation wird derzeit nur zum Speichern unterstützt, nicht zum Laden. Verwenden Sie PPTX oder ein anderes unterstütztes Präsentationsformat, wenn ein Rundreise‑Editieren erforderlich ist.

**Wandelt die XML‑Konvertierung jede Folie in eine Seite oder ein Bild um?**

Nein. Die XML‑Konvertierung schreibt strukturierte Präsentationsdaten. Verwenden Sie PDF oder TIFF für seitenorientierte Ausgaben oder PNG, JPEG und SVG für einzelne Folien‑Bilder.