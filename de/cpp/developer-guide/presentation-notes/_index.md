---
title: Verwalten von Präsentationsnotizen in C++
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
## **Übersicht**

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema werden wir diese Funktion vorstellen, einschließlich wie man Notizen entfernt und wie man einen Stil auf Notizfolien in einer Präsentation anwendet. Aspose.Slides ermöglicht es Ihnen, Notizen von beliebigen Folien zu entfernen und zudem Stil auf vorhandene Notizen anzuwenden. Entwickler können Notizen auf folgende Arten entfernen:

- Notizen von einer bestimmten Folie in einer Präsentation entfernen.
- Notizen von allen Folien in einer Präsentation entfernen.

Um Seitenabmessungen von Notizen zu lesen oder zu ändern, die Ausrichtung zu wechseln und das Exportverhalten zu prüfen, siehe [Notizseitengröße](/slides/de/cpp/notes-size/).

## **Notizen von einer bestimmten Folie entfernen**
Notizen von einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Notizen von allen Folien entfernen**
Notizen von allen Folien in einer Präsentation können wie im folgenden Beispiel entfernt werden:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Notizstil hinzufügen**
Die NotesStyle‑Eigenschaft wurde zum IMasterNotesSlide‑Interface und zur MasterNotesSlide‑Klasse hinzugefügt. Diese Eigenschaft gibt den Stil des Notiztextes an. Die Implementierung wird im folgenden Beispiel gezeigt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

### Welche API‑Entität stellt Zugang zu den Notizen einer bestimmten Folie bereit?
Auf Notizen wird über den Notiz‑Manager der Folie zugegriffen: Die Folie verfügt über einen [NotesSlideManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/notesslidemanager/) und eine [Methode](https://reference.aspose.com/slides/de/cpp/aspose.slides/notesslidemanager/get_notesslide/), die das Notiz‑Objekt zurückgibt, oder `null`, wenn keine Notizen vorhanden sind.

### Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?
Die Bibliothek zielt auf ein breites Spektrum von Microsoft‑PowerPoint‑Formaten (97- und neuer) sowie ODP ab; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.