---
title: Einschränkungen bei Ausgabemetadaten
type: docs
weight: 320
url: /de/java/api-limitations/
keywords:
- API-Einschränkungen
- Exportformat
- Anwendung
- Erzeuger
- Dokumenteigenschaften
- Metadaten
- Generator
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Aspose.Slides for Java schreibt feste Anwendungs-, Ersteller- und Erzeuger-Metadaten in gespeicherte PPTX-, PDF- und ODP-Dateien, unabhängig vom von Ihnen festgelegten Anwendungsnamen."
---
## **Übersicht**

Wenn Präsentationen mit Aspose.Slides erstellt oder exportiert werden, werden bestimmte technische Metadaten in die Ausgabedatei geschrieben. Dieser Artikel erklärt die Einschränkungen im Zusammenhang mit den Metadatenfeldern `Application`, `Creator`, `Producer` und generator in PPTX-, PDF- und ODP-Dateien.

## **Anwendung und Erzeuger**

Wenn Sie Präsentationen mit Aspose.Slides for Java erstellen oder exportieren, werden einige technische Metadaten in die Datei geschrieben. Zwei Felder werfen häufig Fragen auf:

**Application** identifiziert das Programm, das eine **PPTX**‑Präsentation erstellt oder zuletzt gespeichert hat. In Aspose.Slides for Java ist dieser Wert fest und zeigt den Bibliotheksnamen statt Ihres Anwendungsnamens, selbst wenn Sie [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/de/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) verwenden.

**Producer** identifiziert die Rendering‑Engine, die die endgültige Datei beim Export erzeugt hat. Bei **PDF**‑Exporten verwendet die Metadaten **Creator**‑ und **Producer**‑Felder. Mit Aspose.Slides for Java sind beide Felder fest und geben die Bibliothek und ihre Version wieder.

**Was ist eingeschränkt**

Sie können diese Felder über die API für die oben genannten Formate nicht überschreiben. Für **PPTX** wird die Application‑Eigenschaft als "Aspose.Slides for Java" geschrieben. Für **PDF** werden die Creator‑ und Producer‑Eigenschaften als "Aspose.Slides for Java" gefolgt von der Bibliotheksversion geschrieben. Für **ODP** wird das generator‑Feld als "Aspose.Slides for Java" gefolgt von der Bibliotheksversion geschrieben. Dieses Verhalten ist beabsichtigt und gilt unabhängig davon, wie Sie die Datei laden oder speichern, und unabhängig von den mit [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/de/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) zugewiesenen Werten.

Diese Einschränkung gilt nicht für **PPT**‑Dateien: In einer PPT‑Datei wird der Anwendungsname, den Sie mit [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/de/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) festlegen, gespeichert.