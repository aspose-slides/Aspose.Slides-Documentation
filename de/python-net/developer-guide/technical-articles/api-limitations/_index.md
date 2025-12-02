---
title: API-Beschränkungen
type: docs
weight: 210
url: /de/python-net/api-limitations/
keywords:
- API-Beschränkungen
- Exportformat
- Anwendung
- Erzeuger
- Dokumenteigenschaften
- Metadaten
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie die Grenzen von Aspose.Slides für Python: Exporte setzen feste Application/Producer-Metadaten in PPT, PPTX, ODP und PDF – damit Sie Integrationen ohne Überraschungen planen können."
---

## **Anwendung und Producer**

Beim Erstellen oder Exportieren von Präsentationen mit Aspose.Slides for Python via .NET werden einige technische Metadaten in die Datei geschrieben. Zwei Felder werfen häufig Fragen auf:

**Application** identifiziert das Programm, das eine **PPTX**-Präsentation erstellt oder zuletzt gespeichert hat. In Aspose.Slides for Python via .NET ist dieser Wert festgelegt und zeigt den Bibliotheksanbieter anstelle Ihres Anwendungsnamens, selbst wenn Sie [DocumentProperties.name_of_application](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/name_of_application/) setzen.

**Producer** identifiziert die Rendering-Engine, die die endgültige Datei beim Export erzeugt hat. Bei **PDF**-Exporten verwendet die Metadaten die Felder **Creator** und **Producer**. Bei Aspose.Slides for Python via .NET sind beide festgelegt und geben die Bibliothek und ihre Version wider.

**Was ist eingeschränkt**

Sie können diese Felder über die API für die oben genannten Formate nicht überschreiben. Für **PPTX** wird die Application‑Eigenschaft als "Aspose.Slides for Python via .NET" geschrieben. Für **PDF** werden die Creator‑ und Producer‑Eigenschaften als "Aspose.Slides for Python via .NET x.x.x" geschrieben. Dieses Verhalten ist beabsichtigt und gilt unabhängig davon, wie Sie die Datei laden oder speichern, und unabhängig von den Werten, die Sie [DocumentProperties.name_of_application](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/name_of_application/) zuweisen.