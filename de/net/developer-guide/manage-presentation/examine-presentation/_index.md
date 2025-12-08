---
title: Präsentation untersuchen
type: docs
weight: 30
url: /de/net/examine-presentation/
keywords:
- PowerPoint
- Präsentation
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteigenschaften
- Eigenschaften abrufen
- Eigenschaften lesen
- Eigenschaften ändern
- Eigenschaften modifizieren
- PPTX
- PPT
- C#
- Csharp
- .NET
description: "PowerPoint-Präsentationseigenschaften in C# oder .NET lesen und ändern"
---

Aspose.Slides für .NET ermöglicht es Ihnen, eine Präsentation zu untersuchen, um deren Eigenschaften zu ermitteln und ihr Verhalten zu verstehen. 

{{% alert title="Info" color="info" %}} 
Die Klassen [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) und [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) enthalten die Eigenschaften und Methoden, die in den hier beschriebenen Vorgängen verwendet werden. 
{{% /alert %}} 

## **Prüfen des Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation derzeit befindet.

Sie können das Format einer Präsentation prüfen, ohne sie zu laden. Siehe diesen C#‑Code:
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **Präsentationseigenschaften abrufen**

Dieser C#‑Code zeigt Ihnen, wie Sie die Präsentationseigenschaften (Informationen zur Präsentation) abrufen:
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```


Sie möchten vielleicht die [Eigenschaften in der DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties)-Klasse ansehen.

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides stellt die Methode [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) bereit, mit der Sie Änderungen an den Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint‑Präsentation](input_properties.png)

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```


Die Ergebnisse der Änderung der Dokumenteigenschaften werden unten angezeigt.

![Geänderte Dokumenteigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Um weitere Informationen zu einer Präsentation und deren Sicherheitsattributen zu erhalten, könnten diese Links hilfreich sein:

- [Überprüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfen, ob eine Präsentation schreibgeschützt (nur lesbar) ist](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfen, ob eine Präsentation passwortgeschützt ist, bevor sie geladen wird](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigen des Passworts, das zum Schutz einer Präsentation verwendet wurde](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Suchen Sie nach [Informationen zu eingebetteten Schriftarten](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) auf Präsentationsebene und vergleichen Sie diese Einträge anschließend mit der Menge der [tatsächlich im Inhalt verwendeten Schriftarten](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/), um festzustellen, welche Schriftarten für die Darstellung entscheidend sind.

**Wie kann ich schnell erkennen, ob die Datei versteckte Folien enthält und wie viele?**

Durchlaufen Sie die [Folienkollektion](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) und prüfen Sie für jede Folie das [Sichtbarkeits‑Flag](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/).

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet wird und ob sie von den Vorgabewerten abweicht?**

Ja. Vergleichen Sie die aktuelle [Foliengröße](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) und Ausrichtung mit den Standard‑Voreinstellungen; dies hilft, das Verhalten für Druck und Export vorherzusehen.

**Gibt es eine schnelle Möglichkeit zu prüfen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle [Diagramme](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), prüfen Sie deren [Datenquelle](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) und notieren Sie, ob die Daten intern oder verlinkt sind, einschließlich etwaiger defekter Links.

**Wie kann ich "schwere" Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objektanzahl und achten Sie auf große Bilder, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie eine grobe Komplexitätsbewertung, um mögliche Leistungs‑Hotspots zu kennzeichnen.