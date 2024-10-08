---
title: Präsentationsnotizen
type: docs
weight: 110
url: /de/net/presentation-notes/
keywords: "Notizen, PowerPoint-Notizen, Notizen hinzufügen, Notizen entfernen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Notizen in PowerPoint-Präsentationen in C# oder .NET hinzufügen und entfernen"
---



Aspose.Slides unterstützt das Entfernen von Notizenfolien aus einer Präsentation. In diesem Thema werden wir diese neue Funktion zum Entfernen von Notizen sowie das Hinzufügen von Notizenstilfolien aus einer beliebigen Präsentation einführen. Aspose.Slides für .NET bietet die Funktion, Notizen von jeder Folie zu entfernen sowie bestehenden Notizen Stil hinzuzufügen. Entwickler können Notizen auf folgende Weise entfernen:

- Notizen einer bestimmten Folie einer Präsentation entfernen.
- Notizen aller Folien einer Präsentation entfernen.
## **Notizen von einer Folie entfernen**
Notizen einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:

```c#
// Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Entfernen der Notizen der ersten Folie
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Präsentation auf die Festplatte speichern
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Notizen von allen Folien entfernen**
Notizen aller Folien einer Präsentation können wie im folgenden Beispiel entfernt werden:

```c#
// Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation("AccessSlides.pptx");

// Entfernen der Notizen aller Folien
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Präsentation auf die Festplatte speichern
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **Notizenstil hinzufügen**
Die Notizenstil-Eigenschaft wurde zum [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) Interface und zur [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) Klasse hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztextes an. Die Implementierung wird im folgenden Beispiel demonstriert.

```c#
// Erstellen Sie die Klasse Presentation, die die Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Stil des MasterNotesSlide-Textes abrufen
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // Setzen Sie das Symbol-Bullet für die Absätze der ersten Ebene
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Die PPTX-Datei auf die Festplatte speichern
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```