---
title: Präsentationskopf und -fußzeile
type: docs
weight: 140
url: /de/net/presentation-header-and-footer/
keywords: "Kopfzeile, Fußzeile, Kopfzeile festlegen, Fußzeile festlegen, Kopf- und Fußzeile festlegen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint Kopf- und Fußzeile in C# oder .NET"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/de/net/) bietet Unterstützung für die Arbeit mit Kopf- und Fußzeilentexten, die tatsächlich auf der Folienmaster-Ebene verwaltet werden.

{{% /alert %}} 

[Aspose.Slides für .NET](/slides/de/net/) bietet die Funktion zur Verwaltung von Kopf- und Fußzeilen in Präsentationsfolien. Diese werden tatsächlich auf der Präsentationsmaster-Ebene verwaltet.
## **Kopf- und Fußzeilentext verwalten**
Notizen einer bestimmten Folie können wie im folgenden Beispiel aktualisiert werden:

```c#
// Präsentation laden
Presentation pres = new Presentation("headerTest.pptx");

// Fußzeile festlegen
pres.HeaderFooterManager.SetAllFootersText("Mein Fußzeilentext");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Kopfzeile abrufen und aktualisieren
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Präsentation speichern
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// Methode zum Festlegen von Kopf-/Fußzeilentext
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI dort neuer Kopf";
            }
        }
    }
}
```




## **Kopf- und Fußzeilen in Handouts und Notizenfolien verwalten**
Aspose.Slides für .NET unterstützt Kopf- und Fußzeilen in Handouts und Notizenfolien. Bitte folgen Sie den nachstehenden Schritten:

- Laden Sie eine [Präsentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), die ein Video enthält.
- Ändern Sie die Kopf- und Fußzeileneinstellungen für das Notizenmaster und alle Notizenfolien.
- Setzen Sie die Sichtbarkeit der Master-Notizenfolie und aller untergeordneten Fußzeilenplatzhalter auf sichtbar.
- Setzen Sie die Sichtbarkeit der Master-Notizenfolie und aller untergeordneten Datums- und Uhrzeitplatzhalter auf sichtbar.
- Ändern Sie die Kopf- und Fußzeileneinstellungen nur für die erste Notizenfolie.
- Stellen Sie den Platzhalter für die Kopfzeile der Notizenfolie sichtbar.
- Setzen Sie den Text für den Platzhalter der Kopfzeile der Notizenfolie.
- Setzen Sie den Text für den Platzhalter für Datum und Uhrzeit der Notizenfolie.
- Schreiben Sie die modifizierte Präsentationsdatei.

Der Codeausschnitt ist im folgenden Beispiel enthalten.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Ändern Sie die Kopf- und Fußzeileneinstellungen für das Notizenmaster und alle Notizenfolien
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // machen Sie die Master-Notizenfolie und alle untergeordneten Fußzeilenplatzhalter sichtbar
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // machen Sie die Master-Notizenfolie und alle untergeordneten Kopfzeilenplatzhalter sichtbar
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // machen Sie die Master-Notizenfolie und alle untergeordneten Foliennummernplatzhalter sichtbar
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // machen Sie die Master-Notizenfolie und alle untergeordneten Datums- und Uhrzeitplatzhalter sichtbar

		headerFooterManager.SetHeaderAndChildHeadersText("Kopfzeilentext"); // setzen Sie den Text für die Master-Notizenfolie und alle untergeordneten Kopfzeilenplatzhalter
		headerFooterManager.SetFooterAndChildFootersText("Fußzeilentext"); // setzen Sie den Text für die Master-Notizenfolie und alle untergeordneten Fußzeilenplatzhalter
		headerFooterManager.SetDateTimeAndChildDateTimesText("Datum- und Uhrzeittext"); // setzen Sie den Text für die Master-Notizenfolie und alle untergeordneten Datums- und Uhrzeitplatzhalter
	}

	// Ändern Sie die Kopf- und Fußzeileneinstellungen nur für die erste Notizenfolie
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // machen Sie diesen Kopfzeilenplatzhalter der Notizenfolie sichtbar

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // machen Sie diesen Fußzeilenplatzhalter der Notizenfolie sichtbar

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // machen Sie diesen Foliennummernplatzhalter der Notizenfolie sichtbar

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // machen Sie diesen Datums- und Uhrzeitplatzhalter der Notizenfolie sichtbar

		headerFooterManager.SetHeaderText("Neuer Kopfzeilentext"); // setzen Sie den Text für den Platzhalter der Kopfzeile der Notizenfolie
		headerFooterManager.SetFooterText("Neuer Fußzeilentext"); // setzen Sie den Text für den Platzhalter der Fußzeile der Notizenfolie
		headerFooterManager.SetDateTimeText("Neuer Datum- und Uhrzeittext"); // setzen Sie den Text für den Platzhalter für Datum und Uhrzeit der Notizenfolie
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```