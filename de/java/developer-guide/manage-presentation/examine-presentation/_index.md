---
title: Präsentationsinformationen in Java abrufen und aktualisieren
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/java/examine-presentation/
keywords:
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteigenschaften
- Eigenschaften abrufen
- Eigenschaften lesen
- Eigenschaften ändern
- Eigenschaften modifizieren
- Eigenschaften aktualisieren
- PPTX untersuchen
- PPT untersuchen
- ODP untersuchen
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit Java für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Aspose.Slides kann das Format einer Präsentation erkennen und die Dokument‑Metadaten auslesen, ohne ein vollständiges Präsentations‑Objektmodell zu erstellen. Das ist nützlich, wenn Sie Dateien klassifizieren, ein Inventar erstellen oder Eigenschaften prüfen möchten, bevor Sie entscheiden, ob Sie den Präsentationsinhalt laden und verarbeiten.

Dieser Artikel demonstriert leichte Inspektion durch [PresentationFactory](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationfactory/) und [IPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/), sowie gezielte Aktualisierungen durch [IDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/).

## **Prüfen des Präsentationsformats**

Wenn Sie bereits eine geladene Präsentation haben, sehen Sie sich [Determine the Original Presentation Format](/slides/de/java/detect-presentation-source-format/) an, um die Erkennung nach dem Laden und die Einschränkungen von Legacy‑PPT, PPS und POT‑Streams zu erfahren.

Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), um eine Datei zu prüfen, ohne eine [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz zu erzeugen. Die Methode [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) meldet das erkannte Format, z. B. PPTX, PPT oder ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Erstellen eines leichten Präsentationsinventars**

Wenn Sie viele Präsentationsdateien verarbeiten, benötigen Sie möglicherweise ein kompaktes Inventar für Validierung, Indexierung oder ein Dokumenten‑Management‑System. In diesem Szenario verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), um ein [IPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/)‑Objekt zu erhalten, und rufen dann [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) auf, um die Dokument‑Metadaten zu lesen. Dieser Ansatz erstellt keine [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz und erfordert nicht, das komplette Präsentations‑Objektmodell zu traversieren.

Die erweiterten Eigenschaften, die von [IDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/) bereitgestellt werden, liefern die folgenden Inventarwerte:

| Methode | Inventarwert |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getSlides--) | Gesamtzahl der Folien. |
| [getHiddenSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Anzahl der versteckten Folien. |
| [getNotes](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getNotes--) | Anzahl der Folien, die Notizen enthalten. |
| [getParagraphs](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Gesamtzahl der Absätze, sofern verfügbar. |
| [getWords](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getWords--) | Gesamtzahl der Wörter. |
| [getMultimediaClips](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Gesamtzahl der Audio‑ und Videoclips. |

Das folgende Beispiel liest diese Werte, ohne ein [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Objekt zu erzeugen, und gibt ein kompaktes Inventar aus. Es kombiniert außerdem [getHeadingPairs](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) mit [getTitlesOfParts](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) zur Anzeige von Inhaltsgruppen wie Schriftarten, Designs und Folientiteln.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Jedes [IHeadingPair](https://reference.aspose.com/slides/de/java/com.aspose.slides/iheadingpair/) liefert einen Gruppennamen und die Anzahl der Elemente in dieser Gruppe. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) gibt ein flaches, geordnetes Array zurück, sodass die Anzahl aufeinanderfolgender Titel, die von jedem Heading‑Pair angegeben wird, verbraucht werden muss.

### **Gespeicherte Metadaten und Formatbeschränkungen**

Die von [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) zurückgegebenen Inventar‑Eigenschaften spiegeln die in der Quelldatei verfügbaren Metadaten wider. Aspose.Slides lädt und traversiert das Präsentations‑Objektmodell nicht, um diese Werte für diesen Aufruf neu zu berechnen. Fehlende Eigenschaften werden durch Standardwerte repräsentiert, und gespeicherte Werte können veraltet sein, wenn die Anwendung, die die Datei zuletzt gespeichert hat, ihre Dokument‑Eigenschaften nicht aktualisiert hat.

- **PPTX:** Das Format stellt erweiterte Dokumenteigenschaften für Folien‑, Notiz‑, versteckte‑Folien‑, Absatz‑, Wort‑ und Multimedia‑Zählungen sowie Heading‑Pairs und Part‑Titel bereit. Die Verfügbarkeit hängt davon ab, welche Eigenschaften vom Dokumentersteller geschrieben wurden.
- **PPT:** Das Binärformat kann entsprechende Dokument‑Summary‑Eigenschaften speichern. Wenn eine Eigenschaft fehlt oder nicht vom Dokumentersteller aktualisiert wurde, liefert Aspose.Slides ihren gespeicherten oder Standardwert zurück, anstatt sie aus den Folien zu berechnen.
- **ODP:** OpenDocument‑Metadaten bieten allgemeine Dokumentstatistiken wie Seiten‑, Absatz‑ und Wortzahlen, aber diese Werte lassen sich nicht auf jede PowerPoint‑spezifische erweiterte Eigenschaft abbilden. Metadaten für versteckte Folien, Notizen‑Folien, Multimedia, Heading‑Pairs und Part‑Titel können fehlen, und die Inventar‑Eigenschaften können Standardwerte zurückgeben. Behandeln Sie einen Null‑Wert oder ein leeres Array nicht als endgültigen Beweis dafür, dass der entsprechende Inhalt fehlt.

Verwenden Sie den leichten Metadaten‑Ansatz für Inventare und Vorprüfungen. Laden Sie die Präsentation und inspizieren Sie ihr aktuelles Objektmodell, wenn das Ergebnis Änderungen im Speicher widerspiegeln muss oder Sie den tatsächlichen Präsentationsinhalt verifizieren wollen.

## **Präsentationseigenschaften aktualisieren**

Die von [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) zurückgegebenen Eigenschaften können ebenfalls geändert werden, ohne eine [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz zu erzeugen. Wenden Sie die Änderungen mit [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) an und schreiben Sie die gebundene Präsentation mit [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

Das folgende Bild zeigt die originalen Dokumenteigenschaften der PowerPoint‑Präsentation.

![Originale Dokumenteigenschaften der PowerPoint-Präsentation](input_properties.png)

Das folgende Beispiel ändert den Titel und die zuletzt gespeicherte Zeit und schreibt das Ergebnis in eine neue Datei:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

Das folgende Bild zeigt die geänderten Dokumenteigenschaften der PowerPoint‑Präsentation.

![Geänderte Dokumenteigenschaften der PowerPoint-Präsentation](output_properties.png)

## **Nützliche Links**

Für verwandte Sicherheitsprüfungen und Schutzeinstellungen siehe die folgenden Artikel:

- [Präsentationen mit Passwort schützen](/slides/de/java/password-protected-presentation/)
- [Präsentationen vor Schreibzugriff schützen](/slides/de/java/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Laden Sie die Präsentation und verwenden Sie [Presentation.getFontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getFontsManager--). Rufen Sie [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) auf, um die eingebetteten Schriftarten zu erhalten, und [IFontsManager.getFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getFonts--) für die von der Präsentation genutzten Schriftarten. Vergleichen Sie die beiden Ergebnisse, um Schriftarten zu finden, die für die Wiedergabe erforderlich sind, aber nicht eingebettet wurden.

**Wie kann ich schnell feststellen, ob die Datei versteckte Folien enthält und wie viele?**

Wenn die gespeicherten Dokumentmetadaten ausreichen, lesen Sie [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) über [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) und [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Dies eignet sich für ein leichtes Inventar. Wenn die Präsentation im Speicher modifiziert wurde, können die gespeicherten Metadaten fehlen oder veraltet sein; in diesem Fall iterieren Sie über [Presentation.getSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getSlides--) und prüfen jede Folie mit [ISlide.getHidden](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#getHidden--).

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet werden und ob sie von den Vorgaben abweichen?**

Ja. Laden Sie die Präsentation und rufen Sie [Presentation.getSlideSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getSlideSize--) auf. Verwenden Sie [ISlideSize.getType](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidesize/#getSize--) und [ISlideSize.getOrientation](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidesize/#getOrientation--) um die aktuellen Einstellungen mit den erwarteten Vorgaben und Abmessungen zu vergleichen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Lokalisieren Sie jedes [Chart](https://reference.aspose.com/slides/de/java/com.aspose.slides/chart/) und rufen Sie [IChartData.getDataSourceType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdata/#getDataSourceType--) auf. Für eine externe Arbeitsmappe verwenden Sie [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Der Datentyp und der Pfad zeigen eine externe Referenz an, aber die Verfügbarkeit des Ziels muss separat geprüft werden.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF-Export verlangsamen könnten?**

Es gibt keine einzelne Komplexitäts‑Eigenschaft. Durchlaufen Sie [Presentation.getSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getSlides--) und für jede Folie die [IBaseSlide.getShapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/#getShapes--)‑Sammlung. Verwenden Sie die Anzahl der Formen sowie das Vorhandensein großer Bilder, Effekte, Animationen oder Multimedia als Screening‑Signale und messen Sie ein repräsentatives Rendering oder Export, bevor Sie eine Folie als bestätigten Performance‑Engpass einstufen.