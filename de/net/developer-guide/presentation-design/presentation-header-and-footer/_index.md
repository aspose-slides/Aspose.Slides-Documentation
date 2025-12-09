---
title: Verwalten von Präsentations-Headern und -Footern in .NET
linktitle: Header und Footer
type: docs
weight: 140
url: /de/net/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilentext
- Fußzeile
- Fußzeilentext
- Kopfzeile festlegen
- Fußzeile festlegen
- Handzettel
- Notizen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für .NET, um Header und Footer in PowerPoint- und OpenDocument-Präsentationen hinzuzufügen und anzupassen, damit sie professionell aussehen."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/de/net/) bietet Unterstützung zur Arbeit mit Header- und Footer-Texten von Folien, die tatsächlich auf Folienmaster‑Ebene verwaltet werden.

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/de/net/) bietet die Funktion zur Verwaltung von Headern und Footern in Präsentationsfolien. Diese werden tatsächlich auf der Präsentationsmaster‑Ebene verwaltet.
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
// Methode zum Setzen von Header-/Footer-Text
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





## **Header und Footer in Handout‑ und Notizfolien verwalten**
Aspose.Slides for .NET unterstützt Header und Footer in Handout‑ und Notizfolien. Bitte folgen Sie den untenstehenden Schritten:

- Laden Sie eine [Präsentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), die ein Video enthält.
- Ändern Sie die Header‑ und Footer‑Einstellungen für den Notizen‑Master und alle Notizfolien.
- Machen Sie den Master‑Notizfolien‑ und alle untergeordneten Footer‑Platzhalter sichtbar.
- Machen Sie den Master‑Notizfolien‑ und alle untergeordneten Datums‑ und Zeit‑Platzhalter sichtbar.
- Ändern Sie die Header‑ und Footer‑Einstellungen nur für die erste Notizfolie.
- Machen Sie den Header‑Platzhalter der Notizfolie sichtbar.
- Setzen Sie den Text im Header‑Platzhalter der Notizfolie.
- Setzen Sie den Text im Datum‑Zeit‑Platzhalter der Notizfolie.
- Schreiben Sie die geänderte Präsentationsdatei.

Code‑Snippet im nachfolgenden Beispiel bereitgestellt.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Header- und Footer-Einstellungen für Notizen-Master und alle Notizen-Folien ändern
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // Master-Notizenfolie und alle untergeordneten Footer-Platzhalter sichtbar machen
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // Master-Notizenfolie und alle untergeordneten Header-Platzhalter sichtbar machen
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // Master-Notizenfolie und alle untergeordneten Foliennummer-Platzhalter sichtbar machen
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // Master-Notizenfolie und alle untergeordneten Datum- und Zeit-Platzhalter sichtbar machen

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // Text für Master-Notizenfolie und alle untergeordneten Header-Platzhalter festlegen
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // Text für Master-Notizenfolie und alle untergeordneten Footer-Platzhalter festlegen
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // Text für Master-Notizenfolie und alle untergeordneten Datum- und Zeit-Platzhalter festlegen
	}

	// Header- und Footer-Einstellungen nur für die erste Notizfolie ändern
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // Header-Platzhalter dieser Notizfolie sichtbar machen

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // Footer-Platzhalter dieser Notizfolie sichtbar machen

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // Foliennummer-Platzhalter dieser Notizfolie sichtbar machen

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // Datum‑Zeit-Platzhalter dieser Notizfolie sichtbar machen

		headerFooterManager.SetHeaderText("New header text"); // Text für Header-Platzhalter der Notizfolie festlegen
		headerFooterManager.SetFooterText("New footer text"); // Text für Footer-Platzhalter der Notizfolie festlegen
		headerFooterManager.SetDateTimeText("New date and time text"); // Text für Datum‑Zeit-Platzhalter der Notizfolie festlegen
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **FAQ**

**Kann ich einen „Header“ zu regulären Folien hinzufügen?**

In PowerPoint gibt es einen „Header“ nur für Notizen und Handouts; auf regulären Folien werden nur Footer, Datum/Zeit und Foliennummer unterstützt. In Aspose.Slides gelten dieselben Einschränkungen: Header nur für Notes/Handout und auf Folien — Footer/DateTime/SlideNumber.

**Was ist, wenn das Layout keinen Footer‑Bereich enthält – kann ich dessen Sichtbarkeit „einschalten“?**

Ja. Prüfen Sie die Sichtbarkeit über den Header/Footer‑Manager und aktivieren Sie sie bei Bedarf. Diese API‑Indikatoren und Methoden sind für Fälle vorgesehen, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummerierung bei einem anderen Wert als 1 beginnen lassen?**

Setzen Sie die [erste Foliennummer](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/); danach wird die gesamte Nummerierung neu berechnet. Beispielsweise können Sie bei 0 oder 10 beginnen und die Nummer auf der Titelfolie ausblenden.

**Was passiert mit Headern/Footern beim Exportieren zu PDF/Bildern/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das heißt, wenn die Elemente auf Folien/Notizseiten sichtbar sind, erscheinen sie auch im Ausgabeformat zusammen mit dem übrigen Inhalt.