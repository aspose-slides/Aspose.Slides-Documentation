---
title: API-Einschränkungen
type: docs
weight: 320
url: /de/net/api-limitations/
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
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie die Grenzen von Aspose.Slides für .NET: Exporte setzen feste Application/Producer-Metadaten in PPT, PPTX, ODP und PDF - damit Sie Integrationen ohne Überraschungen planen können."
---

## **Anwendung und Ersteller**

Wenn Sie Präsentationen mit Aspose.Slides für .NET erstellen oder exportieren, werden einige technische Metadaten in die Datei geschrieben. Zwei Felder werfen häufig Fragen auf:

**Application** identifiziert das Programm, das eine **PPTX**‑Präsentation erstellt oder zuletzt gespeichert hat. In Aspose.Slides für .NET ist dieser Wert fest und zeigt den Bibliotheksanbieter anstelle Ihres Anwendungsnamens, selbst wenn Sie [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) setzen.

**Producer** identifiziert die Rendering‑Engine, die die endgültige Datei beim Export erzeugt hat. Bei **PDF**‑Exporten werden die Metadatenfelder **Creator** und **Producer** verwendet. Mit Aspose.Slides für .NET sind beide Felder fest und geben die Bibliothek und deren Version wieder.

**Was eingeschränkt ist**

Sie können diese Felder über die API für die genannten Formate nicht überschreiben. Für **PPTX** wird die Application‑Eigenschaft als "Aspose.Slides for .NET" geschrieben. Für **PDF** werden die Creator‑ und Producer‑Eigenschaften als "Aspose.Slides for .NET x.x.x" geschrieben. Dieses Verhalten ist beabsichtigt und gilt unabhängig davon, wie Sie die Datei laden oder speichern, und unabhängig von den Werten, die Sie [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) zuweisen.
