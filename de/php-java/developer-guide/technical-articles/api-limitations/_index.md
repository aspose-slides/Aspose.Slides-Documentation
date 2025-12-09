---
title: API-Einschränkungen
type: docs
weight: 320
url: /de/php-java/api-limitations/
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
- PHP
- Aspose.Slides
description: "Erfahren Sie die Grenzen von Aspose.Slides für PHP: Exporte setzen feste Application/Producer-Metadaten in PPT, PPTX, ODP und PDF – damit Sie Integrationen ohne Überraschungen planen können."
---

## **Anwendung und Producer**

Wenn Sie Präsentationen mit Aspose.Slides for PHP via Java erstellen oder exportieren, werden einige technische Metadaten in die Datei geschrieben. Zwei Felder werfen häufig Fragen auf:

**Application** identifiziert das Programm, das eine **PPTX**‑Präsentation erstellt oder zuletzt gespeichert hat. In Aspose.Slides for PHP via Java ist dieser Wert fest und zeigt den Bibliotheksanbieter anstelle Ihres Anwendungsnamens, selbst wenn Sie [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setnameofapplication/) verwenden.

**Producer** identifiziert die Rendering‑Engine, die die endgültige Datei beim Export erzeugt hat. Bei **PDF**‑Exporten werden die Metadatenfelder **Creator** und **Producer** verwendet. Mit Aspose.Slides for PHP via Java sind beide Felder fest und geben die Bibliothek und ihre Version wieder.

**What’s restricted**

Sie können diese Felder über die API für die oben genannten Formate nicht überschreiben. Für **PPTX** wird die Application‑Eigenschaft als "Aspose.Slides for PHP via Java" geschrieben. Für **PDF** werden die Creator‑ und Producer‑Eigenschaften als "Aspose.Slides for PHP via Java x.x.x." geschrieben. Dieses Verhalten ist beabsichtigt und gilt unabhängig davon, wie Sie die Datei laden oder speichern, und unabhängig von den über [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setnameofapplication/) zugewiesenen Werten.