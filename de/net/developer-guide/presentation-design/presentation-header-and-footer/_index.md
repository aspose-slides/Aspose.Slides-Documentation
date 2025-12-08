---
title: Präsentationskopf- und Fußzeile
type: docs
weight: 140
url: /de/net/presentation-header-and-footer/
keywords: "Kopfzeile, Fußzeile, Kopfzeile festlegen, Fußzeile festlegen, Kopf- und Fußzeile festlegen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint-Kopf- und Fußzeile in C# oder .NET"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/de/net/) bietet Unterstützung für die Arbeit mit Kopf- und Fußzeilentexten von Folien, die tatsächlich auf Ebene des Folienmasters verwaltet werden.

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/de/net/) bietet die Möglichkeit, Kopf- und Fußzeilen innerhalb von Präsentationsfolien zu verwalten. Diese werden tatsächlich auf Ebene des Präsentationsmasters verwaltet.
## **Kopf- und Fußzeilentext verwalten**
Notizen einer bestimmten Folie können wie im folgenden Beispiel aktualisiert werden:
```c#
// Präsentation laden
Presentation pres = new Presentation("headerTest.pptx");

// Fußzeile festlegen
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Header zugreifen und aktualisieren
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
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```





## **Kopf- und Fußzeilen in Handout- und Notizfolien verwalten**
Aspose.Slides for .NET unterstützt Kopf- und Fußzeilen in Handout- und Notizfolien. Bitte folgen Sie den nachstehenden Schritten:

- Laden Sie eine [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)mit einem Video.
- Ändern Sie die Kopf- und Fußzeileneinstellungen für den Notizen-Master und alle Notizfolien.
- Machen Sie den Master-Notizfolien- und alle untergeordneten Fußzeilen-Platzhalter sichtbar.
- Machen Sie den Master-Notizfolien- und alle untergeordneten Datum- und Zeit-Platzhalter sichtbar.
- Ändern Sie die Kopf- und Fußzeileneinstellungen nur für die erste Notizfolie.
- Machen Sie den Kopf-Platzhalter der Notizfolie sichtbar.
- Setzen Sie den Text für den Kopf-Platzhalter der Notizfolie.
- Setzen Sie den Text für den Datum-Zeit-Platzhalter der Notizfolie.
- Speichern Sie die geänderte Präsentationsdatei.

Code‑Snippet im nachstehenden Beispiel bereitgestellt.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Header- und Fußzeileneinstellungen für den Notizen-Master und alle Notizfolien ändern
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // den Master-Notizenfolien- und alle untergeordneten Fußzeilen-Platzhalter sichtbar machen
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // den Master-Notizenfolien- und alle untergeordneten Kopfzeilen-Platzhalter sichtbar machen
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // den Master-Notizenfolien- und alle untergeordneten Foliennummer-Platzhalter sichtbar machen
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // den Master-Notizenfolien- und alle untergeordneten Datum- und Zeit-Platzhalter sichtbar machen

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // Text für die Master-Notizenfolie und alle untergeordneten Kopfzeilen-Platzhalter festlegen
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // Text für die Master-Notizenfolie und alle untergeordneten Fußzeilen-Platzhalter festlegen
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // Text für die Master-Notizenfolie und alle untergeordneten Datum- und Zeit-Platzhalter festlegen
	}

	// Header- und Fußzeileneinstellungen nur für die erste Notizfolie ändern
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // diesen Notizfolien-Kopfzeilen-Platzhalter sichtbar machen

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // diesen Notizfolien-Fußzeilen-Platzhalter sichtbar machen

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // diesen Notizfolien-Foliennummer-Platzhalter sichtbar machen

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // diesen Notizfolien-Datum-Uhrzeit-Platzhalter sichtbar machen

		headerFooterManager.SetHeaderText("New header text"); // Text für den Notizfolien-Kopfzeilen-Platzhalter festlegen
		headerFooterManager.SetFooterText("New footer text"); // Text für den Notizfolien-Fußzeilen-Platzhalter festlegen
		headerFooterManager.SetDateTimeText("New date and time text"); // Text für den Notizfolien-Datum-Uhrzeit-Platzhalter festlegen
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **FAQ**

**Kann ich einen „Header“ zu normalen Folien hinzufügen?**

In PowerPoint gibt es „Header“ nur für Notizen und Handouts; auf normalen Folien sind die unterstützten Elemente Fußzeile, Datum/Uhrzeit und Foliennummer. In Aspose.Slides gelten dieselben Beschränkungen: Header nur für Notes/Handout und auf Folien — Footer/DateTime/SlideNumber.

**Was ist, wenn das Layout keinen Fußzeilenbereich enthält — kann ich dessen Sichtbarkeit „aktivieren“?**

Ja. Prüfen Sie die Sichtbarkeit über den Kopf-/Fußzeilen-Manager und aktivieren Sie sie bei Bedarf. Diese API-Indikatoren und Methoden sind für Fälle vorgesehen, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummer von einem anderen Wert als 1 beginnen lassen?**

Setzen Sie die [erste Foliennummer](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) der Präsentation; danach wird die gesamte Nummerierung neu berechnet. Sie können beispielsweise bei 0 oder 10 beginnen und die Nummer auf der Titelfolie ausblenden.

**Was passiert mit Headern/Fußzeilen beim Exportieren zu PDF/Bildern/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das bedeutet, wenn die Elemente auf Folien/Notizseiten sichtbar sind, erscheinen sie auch im Ausgabformat zusammen mit dem restlichen Inhalt.