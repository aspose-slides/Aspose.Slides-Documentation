---
title: Abrufen und Aktualisieren von Präsentationsinformationen in .NET
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/net/examine-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit .NET für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Präsentationsinformationen in Aspose.Slides inspiziert. Er erklärt, wie man das aktuelle Format einer Präsentation ermittelt, ohne die gesamte Datei zu laden, ihre Dokumenteigenschaften liest und diese bei Bedarf aktualisiert.

Die Beispiele basieren auf den APIs [PresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/presentationinfo/) und [DocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/documentproperties/) und demonstrieren typische Vorgänge zur Arbeit mit Präsentationsmetadaten.

## **Prüfen des Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP usw.) sich die Präsentation derzeit befindet.

Sie können das Format einer Präsentation prüfen, ohne sie zu laden. Siehe diesen C#‑Code:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Abrufen von Präsentationseigenschaften**

Dieser C#‑Code zeigt, wie man Präsentationseigenschaften (Informationen zur Präsentation) abruft:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

Sie können die [Eigenschaften der DocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/documentproperties/#properties) Klasse ansehen.

## **Aktualisieren von Präsentationseigenschaften**

Aspose.Slides stellt die Methode [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) bereit, mit der Sie Änderungen an Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint-Präsentation](input_properties.png)

Dieses Codebeispiel zeigt, wie man einige Präsentationseigenschaften bearbeitet:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Die Ergebnisse der Änderung der Dokumenteigenschaften werden unten angezeigt.

![Geänderte Dokumenteigenschaften der PowerPoint-Präsentation](output_properties.png)

## **Nützliche Links**

Um weitere Informationen zu einer Präsentation und ihren Sicherheitsattributen zu erhalten, könnten diese Links nützlich sein:

- [Passwortgeschützte Präsentationen](/slides/de/net/password-protected-presentation/)
- [Schreibgeschützte Präsentationen](/slides/de/net/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Suchen Sie nach [Informationen zu eingebetteten Schriftarten](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/getembeddedfonts/) auf Präsentationsebene und vergleichen Sie diese Einträge mit der Menge der [tatsächlich im Inhalt verwendeten Schriftarten](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/getfonts/), um zu ermitteln, welche Schriftarten für die Darstellung kritisch sind.

**Wie kann ich schnell feststellen, ob die Datei versteckte Folien enthält und wie viele?**

Durchlaufen Sie die [Folienkollektion](https://reference.aspose.com/slides/de/net/aspose.slides/slidecollection/) und prüfen Sie das [Sichtbarkeits‑Flag](https://reference.aspose.com/slides/de/net/aspose.slides/slide/hidden/) jeder Folie.

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet werden und ob sie von den Vorgaben abweichen?**

Ja. Vergleichen Sie die aktuelle [Foliengröße](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slidesize/) und Ausrichtung mit den Standard‑Voreinstellungen; dies hilft, das Verhalten beim Drucken und Exportieren vorherzusehen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle [Diagramme](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chart/), prüfen Sie deren [Datenquelle](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chartdata/datasourcetype/) und stellen Sie fest, ob die Daten intern oder verlinkt sind, einschließlich etwaiger defekter Links.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objektanzahl und achten Sie auf große Bilder, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie eine grobe Komplexitätsbewertung, um mögliche Leistungsengpässe zu kennzeichnen.