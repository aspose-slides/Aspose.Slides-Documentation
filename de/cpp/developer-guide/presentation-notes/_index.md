---
title: Präsentationsnotizen verwalten in C++
linktitle: Präsentationsnotizen
type: docs
weight: 110
url: /de/cpp/presentation-notes/
keywords:
- Notizen
- Notizfolie
- Notizen hinzufügen
- Notizen entfernen
- Notizstil
- Master-Notizen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Passen Sie Präsentationsnotizen mit Aspose.Slides für C++ an. Arbeiten Sie nahtlos mit PowerPoint- und OpenDocument-Notizen, um Ihre Produktivität zu steigern."
---

## **Foliennotizen hinzufügen und entfernen**
Aspose.Slides unterstützt jetzt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese neue Funktion zum Entfernen von Notizen sowie zum Hinzufügen von Notizstil‑Folien zu einer beliebigen Präsentation vor. Aspose.Slides für C++ bietet die Möglichkeit, Notizen einer beliebigen Folie zu entfernen und Stil zu vorhandenen Notizen hinzuzufügen. Entwickler können Notizen auf folgende Weise entfernen:

- Entfernen von Notizen einer bestimmten Folie einer Präsentation.
- Entfernen von Notizen aller Folien einer Präsentation.

## **Notizen einer bestimmten Folie entfernen**
Notizen einer bestimmten Folie können wie im Beispiel unten gezeigt entfernt werden:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Notizen aller Folien entfernen**
Notizen aller Folien einer Präsentation können wie im folgenden Beispiel entfernt werden:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Einen Notizstil hinzufügen**
Die Eigenschaft **NotesStyle** wurde dem Interface **IMasterNotesSlide** und der Klasse **MasterNotesSlide** hinzugefügt. Diese Eigenschaft legt den Stil eines Notiztexts fest. Die Implementierung wird im nachstehenden Beispiel gezeigt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

**Welches API‑Entität stellt den Zugriff auf die Notizen einer bestimmten Folie bereit?**

Notizen werden über den Notiz‑Manager der Folie abgerufen: Die Folie besitzt einen [NotesSlideManager](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/) und eine [Methode](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/get_notesslide/), die das Notizobjekt zurückgibt oder `null`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek richtet sich an ein breites Spektrum von Microsoft‑PowerPoint‑Formaten (97‑neuere) sowie ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.