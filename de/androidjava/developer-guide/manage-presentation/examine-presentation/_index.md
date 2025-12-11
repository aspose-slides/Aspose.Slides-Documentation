---
title: Abrufen und Aktualisieren von Präsentationsinformationen auf Android
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
description: "Durchsuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mithilfe von Java für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---

Aspose.Slides für Android über Java ermöglicht es Ihnen, eine Präsentation zu untersuchen, um ihre Eigenschaften zu ermitteln und ihr Verhalten zu verstehen.

{{% alert title="Info" color="info" %}} 

Die Klassen [PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo) und [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/) enthalten die Eigenschaften und Methoden, die hier verwendet werden.

{{% /alert %}} 

## **Prüfen des Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation derzeit befindet.

Sie können das Format einer Präsentation prüfen, ohne sie zu laden. Siehe diesen Java‑Code:
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```


## **Präsentationseigenschaften abrufen**

Dieser Java‑Code zeigt Ihnen, wie Sie Präsentationseigenschaften (Informationen zur Präsentation) abrufen können:
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```


Sie möchten möglicherweise die [Eigenschaften unter DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) Klasse sehen.

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides stellt die Methode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) bereit, mit der Sie Änderungen an Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Originale Dokumenteigenschaften der PowerPoint‑Präsentation](input_properties.png)

Dieses Codebeispiel zeigt, wie Sie einige Präsentationseigenschaften bearbeiten können:
```java
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

- [Prüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Prüfen, ob eine Präsentation schreibgeschützt (nur lesbar) ist](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Prüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigen des zum Schutz einer Präsentation verwendeten Passworts](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Wie kann ich prüfen, ob Schriften eingebettet sind und welche es sind?**

Suchen Sie nach [Informationen zu eingebetteten Schriften](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) auf Präsentationsebene und vergleichen Sie diese Einträge mit der Menge der [tatsächlich im Inhalt verwendeten Schriften](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--), um zu ermitteln, welche Schriften für das Rendern kritisch sind.

**Wie kann ich schnell feststellen, ob die Datei versteckte Folien enthält und wie viele?**

Durchlaufen Sie die [Folien‑Sammlung](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) und prüfen Sie das [Sichtbarkeits‑Flag](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--) jeder Folie.

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet wird und ob sie von den Vorgaben abweicht?**

Ja. Vergleichen Sie die aktuelle [Foliengröße](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideSize--) und -ausrichtung mit den Standard‑Voreinstellungen; dies hilft, das Verhalten beim Drucken und Export vorherzusehen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle [Diagramme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/), prüfen Sie deren [Datenquelle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--), und notieren Sie, ob die Daten intern oder verlinkt sind, einschließlich etwaiger defekter Links.

**Wie kann ich 'schwere' Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objektanzahl und achten Sie auf große Bilder, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie eine grobe Komplexitätsbewertung, um potenzielle Leistungsengpässe zu kennzeichnen.