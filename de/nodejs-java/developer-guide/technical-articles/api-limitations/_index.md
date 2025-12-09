---
title: API-Beschränkungen
type: docs
weight: 320
url: /de/nodejs-java/api-limitations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie die Grenzen von Aspose.Slides für Node.js: Exporte setzen feste Application/Producer-Metadaten in PPT, PPTX, ODP und PDF - damit Sie Integrationen ohne Überraschungen planen können."
---

## **Application und Producer**

Wenn Sie Präsentationen mit Aspose.Slides for Node.js via Java erstellen oder exportieren, werden einige technische Metadaten in die Datei geschrieben. Zwei Felder werfen häufig Fragen auf:

**Application** identifiziert das Programm, das eine **PPTX**‑Präsentation erstellt oder zuletzt gespeichert hat. In Aspose.Slides for Node.js via Java ist dieser Wert fest und zeigt den Anbieter der Bibliothek anstelle Ihres Anwendungsnamens, selbst wenn Sie [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) verwenden.

**Producer** identifiziert die Rendering‑Engine, die die endgültige Datei beim Export erzeugt hat. Bei **PDF**‑Exporten verwendet die Metadaten die Felder **Creator** und **Producer**. Mit Aspose.Slides for Node.js via Java sind beide Felder fest und geben die Bibliothek und ihre Version wieder.

**Was ist eingeschränkt**

Sie können diese Felder für die oben genannten Formate nicht über die API überschreiben. Für **PPTX** wird die Application‑Eigenschaft als "Aspose.Slides for Node.js via Java" geschrieben. Für **PDF** werden die Creator‑ und Producer‑Eigenschaften als "Aspose.Slides for Node.js via Java x.x.x." geschrieben. Dieses Verhalten ist beabsichtigt und gilt unabhängig davon, wie Sie die Datei laden oder speichern, und unabhängig von den über [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) zugewiesenen Werten.