---
title: API-Einschränkungen
type: docs
weight: 320
url: /de/python-java/api-limitations/
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
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie mehr über die Einschränkungen von Aspose.Slides für Python via Java: feste Application-, Creator- und Producer-Metadaten in PPTX- und PDF-Dateien."
---
## **Übersicht**

Wenn Präsentationen mit Aspose.Slides erstellt oder exportiert werden, werden bestimmte technische Metadaten in die Ausgabedatei geschrieben. Dieser Artikel erklärt die Einschränkungen bezüglich der Metadatenfelder `Application`, `Creator` und `Producer` in PPTX- und PDF-Dateien.

## **Application und Producer**

Wenn Sie Präsentationen mit Aspose.Slides for Python via Java erstellen oder exportieren, werden einige technische Metadaten in die Datei geschrieben. Zwei Felder werfen häufig Fragen auf:

**Application** identifiziert das Programm, das eine **PPTX**‑Präsentation erstellt oder zuletzt gespeichert hat. In Aspose.Slides for Python via Java ist dieser Wert fest und zeigt den Bibliotheksanbieter anstelle Ihres Anwendungsnamens, selbst wenn Sie [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producer** identifiziert die Rendering‑Engine, die die endgültige Datei beim Export erstellt hat. In **PDF**‑Exporten verwendet die Metadaten **Creator**‑ und **Producer**‑Felder. Mit Aspose.Slides for Python via Java sind beide fest und geben die Bibliothek und ihre Version wieder.

**What’s Restricted**

Sie können diese Felder über die API für die oben genannten Formate nicht überschreiben. Für **PPTX** wird die Application‑Eigenschaft als „Aspose.Slides for Java“ geschrieben. Für **PDF** werden die Creator‑ und Producer‑Eigenschaften als „Aspose.Slides for Java x.x.x.“ geschrieben. Dieses Verhalten ist beabsichtigt und gilt unabhängig davon, wie Sie die Datei laden oder speichern, und unabhängig von den Werten, die Sie mit [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#setnameofapplication) zuweisen.

## **FAQ**

**Kann ich den Application‑Wert in einer PPTX‑Datei durch meinen Anwendungsnamen ersetzen?**

Nein. Der Wert ist fest, selbst wenn Sie [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#setnameofapplication) verwenden.

**Kann ich die Creator‑ und Producer‑Felder bei PDF‑Exporten überschreiben?**

Nein. Beide Felder sind fest und geben die Bibliothek und ihre Version wieder, unabhängig davon, wie Sie die Präsentation laden oder speichern.