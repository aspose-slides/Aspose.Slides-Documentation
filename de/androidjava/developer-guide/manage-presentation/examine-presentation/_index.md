---
title: Präsentation Überprüfen
type: docs
weight: 30
url: /de/androidjava/examine-presentation/
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
- Android
- Java
description: "Lesen und Ändern von PowerPoint-Präsentationseigenschaften in Android über Java"
---

Aspose.Slides für Android über Java ermöglicht es Ihnen, eine Präsentation zu überprüfen, um ihre Eigenschaften zu ermitteln und ihr Verhalten zu verstehen.

{{% alert title="Info" color="info" %}} 

Die [PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo) und [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/) Klassen enthalten die Eigenschaften und Methoden, die in den hier beschriebenen Operationen verwendet werden.

{{% /alert %}} 

## **Präsentationsformat Überprüfen**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation derzeit befindet.

Sie können das Format einer Präsentation überprüfen, ohne die Präsentation zu laden. Sehen Sie sich diesen Java-Code an:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Präsentationseigenschaften Abrufen**

Dieser Java-Code zeigt Ihnen, wie Sie die Präsentationseigenschaften (Informationen über die Präsentation) abrufen:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Sie möchten möglicherweise die [Eigenschaften unter der DokumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) Klasse ansehen.

## **Präsentationseigenschaften Aktualisieren**

Aspose.Slides bietet die [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) Methode, die es Ihnen ermöglicht, Änderungen an den Präsentationseigenschaften vorzunehmen.

Angenommen, wir haben eine PowerPoint-Präsentation mit den unten aufgeführten Dokumenteigenschaften.

![Original Dokumenteigenschaften der PowerPoint-Präsentation](input_properties.png)

Dieses Codebeispiel zeigt Ihnen, wie Sie einige Präsentationseigenschaften bearbeiten können:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("Mein Titel");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Die Ergebnisse der Änderung der Dokumenteigenschaften sind unten aufgeführt.

![Geänderte Dokumenteigenschaften der PowerPoint-Präsentation](output_properties.png)

## **Nützliche Links**

Um mehr Informationen über eine Präsentation und ihre Sicherheitsattribute zu erhalten, können Ihnen diese Links nützlich sein:

- [Überprüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfen, ob eine Präsentation schreibgeschützt (schreibgeschützt) ist](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigen des Passworts, das zum Schutz einer Präsentation verwendet wurde](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).