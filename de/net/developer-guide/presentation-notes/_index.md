---
title: Präsentationsnotizen
type: docs
weight: 110
url: /de/net/presentation-notes/
keywords: "Notizen, PowerPoint-Notizen, Notizen hinzufügen, Notizen entfernen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Notizen in PowerPoint-Präsentationen in C# oder .NET hinzufügen und entfernen"
---

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese neue Funktion zum Entfernen von Notizen sowie zum Hinzufügen von Notizstilfolien aus einer beliebigen Präsentation vor. Aspose.Slides für .NET bietet die Möglichkeit, Notizen einer beliebigen Folie zu entfernen und Stil zu vorhandenen Notizen hinzuzufügen. Entwickler können Notizen auf folgende Weise entfernen:

- Notizen einer bestimmten Folie einer Präsentation entfernen.
- Notizen aller Folien einer Präsentation entfernen.

## **Remove Notes from Slide**
Notizen einer bestimmten Folie können wie im Beispiel unten entfernt werden:
```c#
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Entfernen von Notizen der ersten Folie
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Präsentation auf Festplatte speichern
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Remove Notes from All Slides**
Notizen aller Folien einer Präsentation können wie im Beispiel unten entfernt werden:
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


## **Add NotesStyle**
Die NotesStyle‑Eigenschaft wurde dem [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide)-Interface bzw. der [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide)-Klasse hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztextes an. Die Implementierung wird im Beispiel unten demonstriert.
```c#
 // Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei darstellt
 using (Presentation presentation = new Presentation("AccessSlides.pptx"))
 {
     IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

     if (notesMaster != null)
     {
         // MasterNotesSlide-Textstil abrufen
         ITextStyle notesStyle = notesMaster.NotesStyle;

         //Set Symbol‑Aufzählungszeichen für Absätze der ersten Ebene festlegen
         IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
         paragraphFormat.Bullet.Type = BulletType.Symbol;
     }

     // Die PPTX-Datei auf der Festplatte speichern
     presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

 }
```


## **FAQ**

**Welches API‑Element bietet Zugriff auf die Notizen einer bestimmten Folie?**

Notizen werden über den Notiz‑Manager der Folie abgerufen: Die Folie verfügt über einen [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) und eine [property](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/), die das Notizobjekt zurückgibt, oder `null`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek richtet sich an ein breites Spektrum von Microsoft PowerPoint‑Formaten (97–neuere) und ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.