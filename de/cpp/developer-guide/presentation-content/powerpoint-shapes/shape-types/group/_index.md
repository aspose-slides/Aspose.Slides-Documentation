---
title: Gruppenpräsentationsformen in C++
linktitle: Formgruppe
type: docs
weight: 40
url: /de/cpp/group/
keywords:
- Gruppenform
- Formgruppe
- Gruppe hinzufügen
- Alternativtext
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PowerPoint-Präsentationen mit Aspose.Slides für C++ gruppieren und aufheben — schneller, schrittweiser Leitfaden mit kostenlosem C++-Code."
---

## **Eine Gruppenform hinzufügen**
Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf Folien. Diese Funktion hilft Entwicklern, reichhaltigere Präsentationen zu erstellen. Aspose.Slides für C++ unterstützt das Hinzufügen oder Zugreifen auf Gruppenformen. Es ist möglich, Formen zu einer hinzugefügten Gruppenform hinzuzufügen, um sie zu füllen, oder jede Eigenschaft der Gruppenform zuzugreifen. So fügen Sie einer Folie mit Aspose.Slides für C++ eine Gruppenform hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie der Folie ein Gruppenobjekt hinzu.
1. Fügen Sie die Formen dem hinzugefügten Gruppenobjekt hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Das nachstehende Beispiel fügt einer Folie ein Gruppenobjekt hinzu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Zugriff auf die AltText‑Eigenschaft**
Dieses Thema zeigt einfache Schritte, komplett mit Codebeispielen, zum Hinzufügen einer Gruppenform und zum Zugriff auf die AltText‑Eigenschaft von Gruppenformen auf Folien. So greifen Sie mit Aspose.Slides für C++ auf AltText einer Gruppenform in einer Folie zu:

1. Instanziieren Sie die `Presentation` Klasse, die eine PPTX-Datei darstellt.
1. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Zugriff auf die Formensammlung der Folien.
1. Zugriff auf das Gruppenobjekt.
1. Zugriff auf die AltText‑Eigenschaft.

Das nachstehende Beispiel greift auf den Alternativtext des Gruppenobjekts zu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**Wird verschachtelte Gruppierung (eine Gruppe innerhalb einer Gruppe) unterstützt?**

Ja. [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) hat eine [get_ParentGroup](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_parentgroup/)‑Methode, die direkt die Hierarchieunterstützung anzeigt (eine Gruppe kann ein Kind einer anderen Gruppe sein).

**Wie kann ich die Z‑Reihenfolge der Gruppe relativ zu anderen Objekten auf der Folie steuern?**

Verwenden Sie die [Z-Order position](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) des [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/), um dessen Position im Anzeige‑Stack zu prüfen.

**Kann ich das Verschieben/Bearbeiten/Entgruppieren verhindern?**

Ja. Der Sperrabschnitt der Gruppe wird über [get_GroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/get_groupshapelock/) bereitgestellt, mit dem Sie Operationen am Objekt einschränken können.