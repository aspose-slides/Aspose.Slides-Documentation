---
title: API-Einschränkungen
type: docs
weight: 320
url: /de/androidjava/api-limitations/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie die Grenzen von Aspose.Slides für Android: Exporte setzen feste Application/Producer-Metadaten in PPT, PPTX, ODP und PDF - damit Sie Integrationen ohne Überraschungen planen können."
---

## **Anwendung und Ersteller**

Wenn Sie Präsentationen mit Aspose.Slides für Android via Java erstellen oder exportieren, werden technische Metadaten in die Datei geschrieben. Zwei Felder werfen häufig Fragen auf:

**Application** identifiziert das Programm, das eine **PPTX**‑Präsentation erstellt oder zuletzt gespeichert hat. In Aspose.Slides für Android via Java ist dieser Wert fest und zeigt den Bibliotheksanbieter anstelle Ihres App‑Namens, selbst wenn Sie [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) verwenden.

**Producer** identifiziert die Rendering‑Engine, die die endgültige Datei beim Export erzeugt hat. Bei **PDF**‑Exporten verwendet die Metadaten die Felder **Creator** und **Producer**. Mit Aspose.Slides für Android via Java sind beide Felder fest und geben die Bibliothek sowie deren Version wieder.

**Was eingeschränkt ist**

Sie können diese Felder über die API für die genannten Formate nicht überschreiben. Für **PPTX** wird die Eigenschaft Application als "Aspose.Slides for Android via Java" geschrieben. Für **PDF** werden die Eigenschaften Creator und Producer als "Aspose.Slides for Android via Java x.x.x." geschrieben. Dieses Verhalten ist beabsichtigt und gilt unabhängig davon, wie Sie die Datei laden oder speichern, und unabhängig von Werten, die über [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) zugewiesen wurden.