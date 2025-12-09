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

Aspose.Slides for .NET ermöglicht es Ihnen, eine Präsentation zu untersuchen, um ihre Eigenschaften zu ermitteln und ihr Verhalten zu verstehen. 

{{% alert title="Info" color="info" %}} 

Die Klassen [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) und [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) enthalten die hier verwendeten Eigenschaften und Methoden. 

{{% /alert %}} 

## **Prüfen des Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) die Präsentation derzeit vorliegt.

Sie können das Format einer Präsentation prüfen, ohne die Präsentation zu laden. Siehe diesen C#‑Code:
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **Abrufen von Präsentationseigenschaften**

Dieser C#‑Code zeigt, wie Sie Präsentationseigenschaften (Informationen zur Präsentation) erhalten:
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```


Möglicherweise möchten Sie die [Eigenschaften in der Klasse DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) ansehen.

## **Aktualisieren von Präsentationseigenschaften**

Aspose.Slides stellt die Methode [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) bereit, mit der Sie Änderungen an Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Original document properties of the PowerPoint presentation](input_properties.png)

Dieses Code‑Beispiel zeigt, wie einige Präsentationseigenschaften bearbeitet werden:
```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```


Die Ergebnisse der Änderung der Dokumenteigenschaften sind unten dargestellt.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Nützliche Links**

Weitere Informationen zu einer Präsentation und ihren Sicherheitsattributen finden Sie in diesen Links:

- [Überprüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfen, ob eine Präsentation schreibgeschützt (read‑only) ist](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigung des zum Schutz einer Präsentation verwendeten Passworts](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Wie kann ich prüfen, ob Schriften eingebettet sind und welche das sind?**

Suchen Sie nach [embedded‑font‑Informationen](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) auf Präsentationsebene und vergleichen Sie diese Einträge mit dem Satz der [tatsächlich im Inhalt verwendeten Schriften](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/), um zu ermitteln, welche Schriften für die Darstellung kritisch sind.

**Wie erkenne ich schnell, ob die Datei verborgene Folien enthält und wie viele?**

Durchlaufen Sie die [slide collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) und prüfen Sie das [visibility‑Flag jeder Folie](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/).

**Kann ich feststellen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet werden und ob sie von den Vorgaben abweichen?**

Ja. Vergleichen Sie die aktuelle [slide size](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) und Ausrichtung mit den Standard‑Presets; das hilft, das Verhalten beim Drucken und Export vorherzusehen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle [charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), prüfen Sie deren [data source](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) und notieren Sie, ob die Daten intern oder verlinkt sind, einschließlich ggf. defekter Links.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objekte, suchen Sie nach großen Bildern, Transparenz, Schatten, Animationen und Multimedia und vergeben Sie einen groben Komplexitäts‑Score, um potenzielle Performance‑Engpässe zu kennzeichnen.