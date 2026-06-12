---
title: Gestisci intestazioni e piè di pagina della presentazione in .NET
linktitle: Intestazione e piè di pagina
type: docs
weight: 140
url: /it/net/presentation-header-and-footer/
keywords:
- intestazione
- testo intestazione
- piè di pagina
- testo piè di pagina
- impostare intestazione
- impostare piè di pagina
- dispensa
- note
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Utilizza Aspose.Slides per .NET per aggiungere e personalizzare intestazioni e piè di pagina in presentazioni PowerPoint e OpenDocument per un aspetto professionale."
---
## **Panoramica**

Aspose.Slides consente di gestire le impostazioni di intestazione e piè di pagina nelle presentazioni PowerPoint. Intestazioni e piè di pagina vengono gestiti a livello del master della presentazione e l'API fornisce metodi per impostare il testo del piè di pagina, modificare la visibilità del piè di pagina e aggiornare il testo dell'intestazione nelle diapositive master delle note.

È inoltre possibile gestire intestazioni e piè di pagina per le diapositive di dispensa e note. Ciò include la modifica della visibilità e del testo dei segnaposto di intestazione, piè di pagina, numero diapositiva e data/ora per il master delle note, tutte le diapositive figlie delle note o una singola diapositiva di note.

## **Gestisci testo di intestazione e piè di pagina**

Le note di una diapositiva specifica possono essere aggiornate come mostrato nell'esempio seguente:

```c#
// Carica presentazione
Presentation pres = new Presentation("headerTest.pptx");

// Impostazione del piè di pagina
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Accedi e aggiorna intestazione
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
    UpdateHeaderFooterText(masterNotesSlide);
}

// Salva presentazione
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```

```c#
// Metodo per impostare il testo dell'intestazione/piè di pagina
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

## **Gestisci intestazioni e piè di pagina su diapositive di dispensa e note**
Aspose.Slides per .NET supporta intestazioni e piè di pagina su diapositive di dispensa e note. Segui i passaggi seguenti:

- Carica una [Presentazione](https://reference.aspose.com/slides/it/net/aspose.slides/presentation)contenente un video.
- Modifica le impostazioni di intestazione e piè di pagina per il master delle note e tutte le diapositive delle note.
- Imposta i segnaposto Footer del master delle note e di tutte le note figlie come visibili.
- Imposta i segnaposto Data e ora del master delle note e di tutte le note figlie come visibili.
- Modifica le impostazioni di intestazione e piè di pagina solo per la prima diapositiva di note.
- Imposta il segnaposto Header della diapositiva di note come visibile.
- Imposta il testo del segnaposto Header della diapositiva di note.
- Imposta il testo del segnaposto Data-ora della diapositiva di note.
- Scrivi il file della presentazione modificata.

Snippet di codice fornito nell'esempio seguente.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Modifica le impostazioni di intestazione e piè di pagina per il master delle note e tutte le diapositive delle note
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // rendere la diapositiva master delle note e tutti i segnaposto Footer figli visibili
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // rendere la diapositiva master delle note e tutti i segnaposto Header figli visibili
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // rendere la diapositiva master delle note e tutti i segnaposto SlideNumber figli visibili
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // rendere la diapositiva master delle note e tutti i segnaposto Data e ora figli visibili

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // impostare il testo nella diapositiva master delle note e tutti i segnaposto Header figli
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // impostare il testo nella diapositiva master delle note e tutti i segnaposto Footer figli
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // impostare il testo nella diapositiva master delle note e tutti i segnaposto Data e ora figli
	}

	// Modifica le impostazioni di intestazione e piè di pagina solo per la prima diapositiva delle note
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // rendere visibile il segnaposto Header di questa diapositiva delle note

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // rendere visibile il segnaposto Footer di questa diapositiva delle note

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // rendere visibile il segnaposto SlideNumber di questa diapositiva delle note

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // rendere visibile il segnaposto Data-ora di questa diapositiva delle note

		headerFooterManager.SetHeaderText("New header text"); // impostare il testo nel segnaposto Header della diapositiva delle note
		headerFooterManager.SetFooterText("New footer text"); // impostare il testo nel segnaposto Footer della diapositiva delle note
		headerFooterManager.SetDateTimeText("New date and time text"); // impostare il testo nel segnaposto Date-time della diapositiva delle note
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **FAQ**

**Posso aggiungere un "header" alle diapositive normali?**

In PowerPoint, l'"Header" è disponibile solo per note e dispense; nelle diapositive regolari gli elementi supportati sono il piè di pagina, data/ora e numero diapositiva. In Aspose.Slides questo corrisponde alle stesse limitazioni: intestazione solo per Notes/Handout, e nelle diapositive—Footer/DateTime/SlideNumber.

**Cosa succede se il layout non contiene un'area piè di pagina—posso "attivare" la sua visibilità?**

Sì. Verifica la visibilità tramite il gestore intestazione/piè di pagina e abilitala se necessario. Questi indicatori e metodi dell'API sono progettati per i casi in cui il segnaposto è mancante o nascosto.

**Come faccio a far iniziare il numero della diapositiva da un valore diverso da 1?**

Imposta il [primo numero diapositiva](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/firstslidenumber/) della presentazione; dopo di ciò, tutta la numerazione viene ricalcolata. Ad esempio, puoi iniziare da 0 o 10 e nascondere il numero sulla diapositiva del titolo.

**Cosa succede a intestazioni/piè di pagina quando si esporta in PDF/immagini/HTML?**

Vengono renderizzati come normali elementi di testo della presentazione. Ovvero, se gli elementi sono visibili su diapositive/pagine di note, appariranno anche nel formato di output insieme al resto del contenuto.