---
title: Verwalten von Präsentationsnotizen in .NET
linktitle: Präsentationsnotizen
type: docs
weight: 110
url: /de/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Passen Sie Präsentationsnotizen mit Aspose.Slides für .NET an. Arbeiten Sie nahtlos mit PowerPoint- und OpenDocument-Notizen, um Ihre Produktivität zu steigern."
---

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema führen wir die neue Funktion zum Entfernen von Notizen sowie zum Hinzufügen von Notizstilfolien zu einer beliebigen Präsentation ein. Aspose.Slides für .NET bietet die Funktion, Notizen von beliebigen Folien zu entfernen sowie Stil zu vorhandenen Notizen hinzuzufügen. Entwickler können Notizen auf folgende Weise entfernen:

- Notizen einer bestimmten Folie einer Präsentation entfernen.
- Notizen aller Folien einer Präsentation entfernen.

## **Notizen von einer Folie entfernen**
Notizen einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:
```c#
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Entfernen von Notizen der ersten Folie
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Präsentation auf Festplatte speichern
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Notizen von allen Folien entfernen**
Notizen aller Folien einer Präsentation können wie im folgenden Beispiel entfernt werden:
```c#
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Entfernen von Notizen aller Folien
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}

// Präsentation auf Festplatte speichern
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **Einen Notizstil hinzufügen**
Die Eigenschaft NotesStyle wurde dem Interface [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) und der Klasse [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) jeweils hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztextes an. Die Implementierung wird im folgenden Beispiel gezeigt.
```c#
// Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Textstil des MasterNotesSlide abrufen
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Set Symbol-Aufzählungszeichen für Absätze der ersten Ebene
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // PPTX-Datei auf die Festplatte speichern
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```


## **FAQ**

**Welches API-Entität stellt den Zugriff auf die Notizen einer bestimmten Folie bereit?**

Notizen werden über den Notiz-Manager der Folie abgerufen: Die Folie verfügt über einen [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) und eine [property](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/), die das Notizobjekt zurückgibt oder `null`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek richtet sich an ein breites Spektrum von Microsoft‑PowerPoint‑Formaten (97‑neuere) und ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte PowerPoint‑Kopie erforderlich ist.