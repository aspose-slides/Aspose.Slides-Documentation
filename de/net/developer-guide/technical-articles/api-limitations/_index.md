---
title: Einschränkungen bei Ausgabemetadaten
type: docs
weight: 320
url: /de/net/api-limitations/
keywords:
- API-Einschränkungen
- Exportformat
- Anwendung
- Producer
- Dokumenteigenschaften
- Metadaten
- Generator
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET schreibt feste Anwendungs-, Creator- und Producer-Metadaten in gespeicherte PPTX-, PDF- und ODP-Dateien, unabhängig vom eingestellten Anwendungsnamen."
---
## **Übersicht**

Wenn Präsentationen mit Aspose.Slides erstellt oder exportiert werden, werden bestimmte technische Metadaten in die Ausgabedatei geschrieben. Dieser Artikel erklärt die Einschränkungen der Metadatenfelder `Application`, `Creator`, `Producer` und generator in PPTX-, PDF- und ODP-Dateien.

## **Application und Producer**

Wenn Sie Präsentationen mit Aspose.Slides für .NET erstellen oder exportieren, werden einige technische Metadaten in die Datei geschrieben. Zwei Felder werfen häufig Fragen auf:

**Application** identifiziert das Programm, das eine **PPTX**‑Präsentation erstellt oder zuletzt gespeichert hat. In Aspose.Slides für .NET ist dieser Wert fest und zeigt den Bibliotheksnamen anstelle Ihres Anwendungsnamens, selbst wenn Sie [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/de/net/aspose.slides/documentproperties/nameofapplication/) festlegen.

**Producer** identifiziert die Rendering‑Engine, die die endgültige Datei beim Export erstellt hat. Bei **PDF**‑Exporten verwendet die Metadaten **Creator**‑ und **Producer**‑Felder. Mit Aspose.Slides für .NET sind beide fest und geben die Bibliothek und deren Version wieder.

**Was eingeschränkt ist**

Sie können diese Felder über die API für die genannten Formate nicht überschreiben. Für **PPTX** wird die Application‑Eigenschaft als "Aspose.Slides for .NET" geschrieben. Für **PDF** werden die Creator‑ und Producer‑Eigenschaften als "Aspose.Slides for .NET" gefolgt von der Bibliotheksversion geschrieben. Für **ODP** wird das generator‑Feld als "Aspose.Slides for .NET" gefolgt von der Bibliotheksversion geschrieben. Dieses Verhalten ist beabsichtigt und gilt unabhängig davon, wie Sie die Datei laden oder speichern, und ungeachtet der Werte, die Sie [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/de/net/aspose.slides/documentproperties/nameofapplication/) zuweisen.

Diese Einschränkung gilt nicht für **PPT**‑Dateien: In einer PPT‑Datei wird der Anwendungsname, den Sie in [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/de/net/aspose.slides/documentproperties/nameofapplication/) festgelegt haben, gespeichert.