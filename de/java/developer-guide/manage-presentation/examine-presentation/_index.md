---
title: Abrufen und Aktualisieren von Präsentationsinformationen in Java
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
description: "Erkunden Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit Java für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Präsentationsinformationen in Aspose.Slides inspiziert. Er erklärt, wie man das aktuelle Format einer Präsentation ermittelt, ohne die gesamte Datei zu laden, ihre Dokumenteigenschaften ausliest und diese bei Bedarf aktualisiert.

Die Beispiele basieren auf den APIs [PresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationinfo/) und [DocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/documentproperties/) und demonstrieren typische Vorgänge zum Arbeiten mit Präsentations‑Metadaten.

## **Format einer Präsentation überprüfen**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP usw.) die Präsentation derzeit vorliegt.

Sie können das Format einer Präsentation überprüfen, ohne die Präsentation zu laden. Siehe diesen Java‑Code:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Präsentationseigenschaften abrufen**

Dieser Java‑Code zeigt, wie Sie Präsentationseigenschaften (Informationen zur Präsentation) erhalten:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Weitere Informationen finden Sie in der Klasse [DocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/documentproperties/#DocumentProperties--) unter den Eigenschaften.

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides stellt die Methode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) bereit, mit der Sie Änderungen an Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint‑Präsentation](input_properties.png)

Dieses Code‑Beispiel zeigt, wie Sie einige Präsentationseigenschaften bearbeiten:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Die Ergebnisse der Änderungen der Dokumenteigenschaften sind unten dargestellt.

![Geänderte Dokumenteigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Weitere Informationen zu einer Präsentation und deren Sicherheitsattributen finden Sie in diesen Links:

- [Password-Protect Presentations](/slides/de/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/de/java/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Suchen Sie nach Informationen zu [embedded-font](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) auf Präsentationsebene und vergleichen Sie diese Einträge mit der Menge der [tatsächlich im Inhalt verwendeten Schriftarten](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsmanager/#getFonts--), um zu ermitteln, welche Schriftarten für die Darstellung kritisch sind.

**Wie kann ich schnell erkennen, ob die Datei versteckte Folien enthält und wie viele?**

Iterieren Sie über die [slide collection](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidecollection/) und prüfen Sie für jede Folie das [visibility flag](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/#getHidden--).

**Kann ich feststellen, ob eine benutzerdefinierte Foliengröße und Ausrichtung verwendet werden und ob sie von den Vorgaben abweichen?**

Ja. Vergleichen Sie die aktuelle [slide size](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getSlideSize--) und Ausrichtung mit den Standard‑Presets; dies hilft, das Verhalten beim Drucken und Export vorherzusehen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle [charts](https://reference.aspose.com/slides/de/java/com.aspose.slides/chart/), prüfen Sie deren [data source](https://reference.aspose.com/slides/de/java/com.aspose.slides/chartdata/#getDataSourceType--) und notieren Sie, ob die Daten intern oder verlinkt sind, einschließlich etwaiger defekter Links.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objektanzahl und achten Sie auf große Bilder, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie einen groben Komplexitäts‑Score, um potenzielle Performance‑Hotspots zu kennzeichnen.