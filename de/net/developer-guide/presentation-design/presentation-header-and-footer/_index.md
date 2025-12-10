---
title: Header und Footer von Präsentationen in .NET verwalten
linktitle: Header und Footer
type: docs
weight: 140
url: /de/net/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilentext
- Fußzeile
- Fußzeilentext
- Header festlegen
- Footer festlegen
- Handzettel
- Notizen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für .NET, um Header und Footer in PowerPoint- und OpenDocument-Präsentationen hinzuzufügen und anzupassen, um ein professionelles Aussehen zu erzielen."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/de/net/) bietet Unterstützung für die Arbeit mit den Header- und Footer-Texten von Folien, die tatsächlich auf Ebene des Folienmasters verwaltet werden.

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/de/net/) stellt die Funktion zum Verwalten von Headern und Footern in Präsentationsfolien bereit. Diese werden tatsächlich auf Ebene des Präsentationsmasters verwaltet.
## **Header- und Footer-Text verwalten**
Notizen einer bestimmten Folie können wie im folgenden Beispiel aktualisiert werden:
```c#
// Präsentation laden
Presentation pres = new Presentation("headerTest.pptx");

// Footer festlegen
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
// Methode zum Festlegen von Header-/Footer-Text
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





## **Header und Footer auf Handout- und Notizfolien verwalten**
Aspose.Slides for .NET unterstützt Header und Footer in Handout- und Notizfolien. Bitte folgen Sie den nachstehenden Schritten:

- Laden Sie eine [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)die ein Video enthält.
- Ändern Sie die Header- und Footer-Einstellungen für den Notizenmaster und alle Notizfolien.
- Setzen Sie die Master-Notizfolie und alle untergeordneten Footer-Platzhalter sichtbar.
- Setzen Sie die Master-Notizfolie und alle untergeordneten Datum‑ und Zeit-Platzhalter sichtbar.
- Ändern Sie die Header‑ und Footer‑Einstellungen nur für die erste Notizfolie.
- Setzen Sie den Header‑Platzhalter der Notizfolie sichtbar.
- Setzen Sie Text für den Header‑Platzhalter der Notizfolie.
- Setzen Sie Text für den Datum‑Zeit‑Platzhalter der Notizfolie.
- Schreiben Sie die geänderte Präsentationsdatei.

Code‑Snippet im untenstehenden Beispiel bereitgestellt.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Header- und Footer-Einstellungen für den Notizen-Master und alle Notizfolien ändern
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // macht die Master-Notizfolie und alle untergeordneten Footer-Platzhalter sichtbar
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // macht die Master-Notizfolie und alle untergeordneten Header-Platzhalter sichtbar
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // macht die Master-Notizfolie und alle untergeordneten Foliennummer-Platzhalter sichtbar
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // macht die Master-Notizfolie und alle untergeordneten Datum-und-Zeit-Platzhalter sichtbar

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // setzt Text für die Master-Notizfolie und alle untergeordneten Header-Platzhalter
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // setzt Text für die Master-Notizfolie und alle untergeordneten Footer-Platzhalter
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // setzt Text für die Master-Notizfolie und alle untergeordneten Datum-und-Zeit-Platzhalter
	}

	// Header- und Footer-Einstellungen nur für die erste Notizfolie ändern
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // macht diesen Notizfolien-Header-Platzhalter sichtbar

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // macht diesen Notizfolien-Footer-Platzhalter sichtbar

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // macht diesen Notizfolien-Foliennummer-Platzhalter sichtbar

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // macht diesen Notizfolien-Datum-Zeit-Platzhalter sichtbar

		headerFooterManager.SetHeaderText("New header text"); // setzt Text für den Header-Platzhalter der Notizfolie
		headerFooterManager.SetFooterText("New footer text"); // setzt Text für den Footer-Platzhalter der Notizfolie
		headerFooterManager.SetDateTimeText("New date and time text"); // setzt Text für den Datum-Zeit-Platzhalter der Notizfolie
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **FAQ**

**Kann ich einen „Header“ zu regulären Folien hinzufügen?**

In PowerPoint existiert ein „Header“ nur für Notizen und Handouts; auf regulären Folien werden nur Footer, Datum/Zeit und Foliennummer unterstützt. In Aspose.Slides entspricht das denselben Einschränkungen: Header nur für Notizen/Handouts und auf Folien – Footer/DateTime/SlideNumber.

**Was, wenn das Layout keinen Footer‑Bereich enthält—kann ich dessen Sichtbarkeit „aktivieren“?**

Ja. Überprüfen Sie die Sichtbarkeit über den Header/Footer‑Manager und aktivieren Sie sie bei Bedarf. Diese API‑Indikatoren und Methoden sind für Fälle gedacht, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummerierung ab einem anderen Wert als 1 beginnen lassen?**

Setzen Sie die [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) der Präsentation; danach wird die gesamte Nummerierung neu berechnet. Beispielsweise können Sie bei 0 oder 10 beginnen und die Nummer auf der Titelfolie ausblenden.

**Was passiert mit Headern/Footern beim Exportieren nach PDF/Bildern/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das heißt, wenn die Elemente auf Folien/Notizseiten sichtbar sind, erscheinen sie auch im Ausgabformat zusammen mit dem übrigen Inhalt.