---
title: Abrufen und Aktualisieren von Präsentationsinformationen unter Android
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/androidjava/examine-presentation/
keywords:
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteneigenschaften
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
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit Java für schnellere Erkenntnisse und intelligentere Inhaltsprüfungen."
---

Aspose.Slides für Android via Java ermöglicht es Ihnen, eine Präsentation zu untersuchen, um deren Eigenschaften zu ermitteln und ihr Verhalten zu verstehen.

{{% alert title="Info" color="info" %}} 

Die [PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo) und [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/) Klassen enthalten die Eigenschaften und Methoden, die in den nachfolgenden Vorgängen verwendet werden.

{{% /alert %}} 

## **Präsentationsformat prüfen**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise das aktuelle Format (PPT, PPTX, ODP usw.) der Präsentation herausfinden.

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

Dieser Java‑Code zeigt, wie Sie Präsentationseigenschaften (Informationen zur Präsentation) erhalten:
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```


Weitere Informationen finden Sie in den [properties der DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) Klasse.

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides stellt die Methode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) bereit, mit der Sie Änderungen an den Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteneigenschaften.

![Originale Dokumenteneigenschaften der PowerPoint‑Präsentation](input_properties.png)

Dieses Code‑Beispiel zeigt, wie Sie einige Präsentationseigenschaften bearbeiten:
```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


Die Ergebnisse der Änderungen der Dokumenteneigenschaften sind unten dargestellt.

![Geänderte Dokumenteneigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Weitere Informationen zu einer Präsentation und ihren Sicherheitsattributen finden Sie unter folgenden Links:

- [Überprüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfen, ob eine Präsentation schreibgeschützt (nur lesbar) ist](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfen, ob eine Präsentation passwortgeschützt ist, bevor sie geladen wird](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigen des zum Schutz einer Präsentation verwendeten Passworts](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **FAQ**

**Wie kann ich prüfen, ob Schriften eingebettet sind und welche das sind?**

Suchen Sie nach Informationen zu [embedded-font](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) auf Präsentationsebene und vergleichen Sie diese Einträge mit der Menge der [tatsächlich im Inhalt verwendeten Schriften](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--), um zu ermitteln, welche Schriften für die Darstellung kritisch sind.

**Wie kann ich schnell erkennen, ob die Datei versteckte Folien enthält und wie viele?**

Durchlaufen Sie die [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) und prüfen Sie das [visibility flag](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--) jeder Folie.

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und Ausrichtung verwendet werden und ob sie von den Vorgaben abweichen?**

Ja. Vergleichen Sie die aktuelle [slide size](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideSize--) und Ausrichtung mit den Standard‑Voreinstellungen; dies hilft, das Verhalten beim Drucken und Exportieren vorherzusehen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle [charts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/), prüfen Sie deren [data source](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) und stellen Sie fest, ob die Daten intern oder verlinkt sind, einschließlich defekter Links.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objektanzahl und achten Sie auf große Bilder, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie einen groben Komplexitäts‑Score, um potenzielle Leistungsengpässe zu kennzeichnen.