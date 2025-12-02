---
title: API-Einschränkungen
type: docs
weight: 320
url: /de/java/api-limitations/
keywords:
- API-Einschränkungen
- Exportformat
- Anwendung
- Ersteller
- Dokumenteigenschaften
- Metadaten
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie die Grenzen von Aspose.Slides für Java: Exporte setzen feste Application/Producer-Metadaten in PPT, PPTX, ODP und PDF – das hilft Ihnen, Integrationen ohne Überraschungen zu planen."
---

## **Anwendung und Ersteller**

Wenn Sie Präsentationen mit Aspose.Slides for Java erstellen oder exportieren, werden einige technische Metadaten in die Datei geschrieben. Zwei Felder werfen häufig Fragen auf:

**Application** identifiziert das Programm, das eine **PPTX**‑Präsentation erstellt oder zuletzt gespeichert hat. In Aspose.Slides for Java ist dieser Wert fest und zeigt den Bibliotheksanbieter anstelle Ihres Anwendungnamens, selbst wenn Sie [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifiziert die Rendering‑Engine, die die endgültige Datei beim Export erzeugt hat. Bei **PDF**‑Exporten werden Metadatenfelder **Creator** und **Producer** verwendet. Mit Aspose.Slides for Java sind beide Felder fest und geben die Bibliothek sowie deren Version wieder.

**Einschränkungen**

Sie können diese Felder über die API für die oben genannten Formate nicht überschreiben. Für **PPTX** wird die Application‑Eigenschaft als "Aspose.Slides for Java" geschrieben. Für **PDF** werden die Creator‑ und Producer‑Eigenschaften als "Aspose.Slides for Java x.x.x." geschrieben. Dieses Verhalten ist beabsichtigt und gilt unabhängig davon, wie Sie die Datei laden oder speichern, und unabhängig von den über [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) zugewiesenen Werten.