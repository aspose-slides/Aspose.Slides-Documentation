---
title: Abrufen und Aktualisieren von Präsentationsinformationen unter Android
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mithilfe von Java für schnellere Einblicke und intelligentere Inhaltsprüfungen.
---
## **Übersicht**

Dieser Artikel zeigt, wie man Präsentationsinformationen in Aspose.Slides inspiziert. Er erklärt, wie man das aktuelle Format einer Präsentation ermittelt, ohne die gesamte Datei zu laden, ihre Dokumenteigenschaften liest und diese bei Bedarf aktualisiert.

Die Beispiele basieren auf den APIs [PresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationinfo/) und [DocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/documentproperties/) und demonstrieren typische Vorgänge zum Arbeiten mit Präsentationsmetadaten.

## **Prüfen des Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation derzeit befindet.

Sie können das Format einer Präsentation prüfen, ohne sie zu laden. Siehe diesen Java‑Code:

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

Dieser Java‑Code zeigt, wie Sie Präsentationseigenschaften (Informationen zur Präsentation) abrufen:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Vielleicht möchten Sie die [Eigenschaften in der DocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--)‑Klasse sehen.

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides stellt die Methode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) bereit, mit der Sie Änderungen an den Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint‑Präsentation](input_properties.png)

Dieses Codebeispiel zeigt, wie Sie einige Präsentationseigenschaften bearbeiten:

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

Die Ergebnisse der Änderung der Dokumenteigenschaften werden unten angezeigt.

![Geänderte Dokumenteigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Um weitere Informationen zu einer Präsentation und ihren Sicherheitsattributen zu erhalten, können diese Links nützlich sein:

- [Password-Protect Presentations](/slides/de/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/de/androidjava/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche?**

Suchen Sie nach [embedded-font information](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) auf Präsentationsebene und vergleichen Sie diese Einträge mit der Menge der [fonts actually used across content](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsmanager/#getFonts--), um zu ermitteln, welche Schriftarten für die Darstellung kritisch sind.

**Wie kann ich schnell feststellen, ob die Datei versteckte Folien enthält und wie viele?**

Durchlaufen Sie die [slide collection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidecollection/) und prüfen Sie das [visibility flag](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slide/#getHidden--) jeder Folie.

**Kann ich erkennen, ob benutzerdefinierte Foliengröße und -ausrichtung verwendet werden und ob sie von den Vorgaben abweichen?**

Ja. Vergleichen Sie die aktuelle [slide size](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSlideSize--) und Ausrichtung mit den Standardvoreinstellungen; dies hilft, das Verhalten beim Drucken und Exportieren vorherzusehen.

**Gibt es eine schnelle Möglichkeit zu erkennen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle [charts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/chart/), prüfen Sie deren [data source](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/chartdata/#getDataSourceType--), und notieren Sie, ob die Daten intern oder verlinkt sind, einschließlich etwaiger defekter Links.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objektanzahl und suchen Sie nach großen Bildern, Transparenzen, Schatten, Animationen und Multimedia; vergeben Sie eine grobe Komplexitätsbewertung, um potenzielle Leistungsengpässe zu kennzeichnen.