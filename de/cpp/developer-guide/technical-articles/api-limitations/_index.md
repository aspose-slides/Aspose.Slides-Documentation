---
title: API-Einschränkungen
type: docs
weight: 320
url: /de/cpp/api-limitations/
keywords:
- API-Einschränkungen
- Exportformat
- Anwendung
- Erzeuger
- Dokumenteigenschaften
- Metadaten
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie die Grenzen von Aspose.Slides for C++: Exporte setzen feste Application/Producer-Metadaten in PPT, PPTX, ODP und PDF - damit Sie Integrationen ohne Überraschungen planen können."
---

## **Application und Producer**

Wenn Sie Präsentationen mit Aspose.Slides for C++ erstellen oder exportieren, werden einige technische Metadaten in die Datei geschrieben. Zwei Felder werfen häufig Fragen auf:

**Application** identifiziert das Programm, das eine **PPTX**‑Präsentation erstellt oder zuletzt gespeichert hat. In Aspose.Slides for C++ ist dieser Wert fest und zeigt den Bibliotheksanbieter anstelle Ihres Anwendungsnamens, selbst wenn Sie [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/) verwenden.

**Producer** identifiziert die Rendering‑Engine, die die endgültige Datei beim Export erzeugt hat. Bei **PDF**‑Exporten verwenden die Metadaten die Felder **Creator** und **Producer**. Bei Aspose.Slides for C++ sind beide fest und geben die Bibliothek und ihre Version wieder.

**What’s restricted**

Sie können diese Felder über die API für die oben genannten Formate nicht überschreiben. Für **PPTX** wird die Application‑Eigenschaft als "Aspose.Slides for C++" geschrieben. Für **PDF** werden die Creator‑ und Producer‑Eigenschaften als "Aspose.Slides for C++ x.x.x" geschrieben. Dieses Verhalten ist beabsichtigt und gilt unabhängig davon, wie Sie die Datei laden oder speichern, und unabhängig von den über [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/) zugewiesenen Werten.