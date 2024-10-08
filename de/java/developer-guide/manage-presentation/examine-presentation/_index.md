---
title: Präsentation überprüfen
type: docs
weight: 30
url: /de/java/examine-presentation/
keywords:
- PowerPoint
- präsentation
- dateiformat präsentiert
- präsentationseigenschaften
- dokumenteigenschaften
- eigenschaften abrufen
- eigenschaften lesen
- eigenschaften ändern
- eigenschaften anpassen
- PPTX
- PPT
- Java
description: "Lesen und Ändern von PowerPoint-Präsentationseigenschaften in Java"
---

Aspose.Slides für Java ermöglicht es Ihnen, eine Präsentation zu überprüfen, um ihre Eigenschaften herauszufinden und ihr Verhalten zu verstehen.

{{% alert title="Info" color="info" %}} 

Die Klassen [PresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/PresentationInfo) und [DocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/) enthalten die Eigenschaften und Methoden, die in den hier beschriebenen Operationen verwendet werden.

{{% /alert %}} 

## **Präsentationsformat überprüfen**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation gerade befindet.

Sie können das Format einer Präsentation überprüfen, ohne die Präsentation zu laden. Sehen Sie sich diesen Java-Code an:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Präsentationseigenschaften abrufen**

Dieser Java-Code zeigt Ihnen, wie Sie Präsentationseigenschaften (Informationen über die Präsentation) abrufen:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Sie möchten möglicherweise die [Eigenschaften der Dokumenteigenschaften](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#DocumentProperties--) Klasse ansehen.

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides bietet die Methode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), mit der Sie Änderungen an den Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint-Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint-Präsentation](input_properties.png)

Dieses Codebeispiel zeigt Ihnen, wie Sie einige Präsentationseigenschaften bearbeiten:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("Mein Titel");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Die Ergebnisse der Änderung der Dokumenteigenschaften sind unten dargestellt.

![Geänderte Dokumenteigenschaften der PowerPoint-Präsentation](output_properties.png)

## **Nützliche Links**

Um mehr Informationen über eine Präsentation und ihre Sicherheitseigenschaften zu erhalten, finden Sie diese Links nützlich:

- [Überprüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfen, ob eine Präsentation schreibgeschützt ist (nur-lesend)](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfen, ob eine Präsentation passwortgeschützt ist, bevor sie geladen wird](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigen des Passworts, das zum Schutz einer Präsentation verwendet wurde](https://docs.aspose.com/slides/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).