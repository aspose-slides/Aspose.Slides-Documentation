---
title: Präsentation Untersuchen
type: docs
weight: 30
url: /net/examine-presentation/
keywords:
- PowerPoint
- präsentation
- präsentationsformat
- präsentationseigenschaften
- dokumenteigenschaften
- eigenschaften abrufen
- eigenschaften lesen
- eigenschaften ändern
- eigenschaften modifizieren
- PPTX
- PPT
- C#
- Csharp
- .NET
description: "Lese und ändere die Eigenschaften von PowerPoint-Präsentationen in C# oder .NET"
---

Aspose.Slides für .NET ermöglicht es Ihnen, eine Präsentation zu untersuchen, um ihre Eigenschaften herauszufinden und ihr Verhalten zu verstehen.

{{% alert title="Info" color="info" %}} 

Die Klassen [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) und [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) enthalten die Eigenschaften und Methoden, die in den hier beschriebenen Operationen verwendet werden.

{{% /alert %}} 

## **Überprüfen eines Präsentationsformats**

Bevor Sie mit einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation gerade befindet.

Sie können das Format einer Präsentation überprüfen, ohne die Präsentation zu laden. Sehen Sie sich diesen C#-Code an:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Eigenschaften der Präsentation abrufen**

Dieser C#-Code zeigt Ihnen, wie Sie die Eigenschaften der Präsentation (Informationen über die Präsentation) abrufen können:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

Sie möchten möglicherweise die [Eigenschaften der Klasse DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) einsehen.

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides bietet die Methode [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties), mit der Sie Änderungen an den Eigenschaften der Präsentation vornehmen können.

Angenommen, wir haben eine PowerPoint-Präsentation mit den unten angezeigten Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint-Präsentation](input_properties.png)

Dieses Codebeispiel zeigt Ihnen, wie Sie einige Präsentationseigenschaften bearbeiten:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "Mein Titel";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Die Ergebnisse der Änderung der Dokumenteigenschaften sind unten dargestellt.

![Geänderte Dokumenteigenschaften der PowerPoint-Präsentation](output_properties.png)

## **Nützliche Links**

Um mehr Informationen über eine Präsentation und ihre Sicherheitsattribute zu erhalten, finden Sie diese Links möglicherweise nützlich:

- [Überprüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfen, ob eine Präsentation schreibgeschützt ist (nur lesen)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigen des Passworts, das zum Schutz einer Präsentation verwendet wurde](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).