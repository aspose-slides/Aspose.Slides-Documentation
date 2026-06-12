---
title: Gestire intestazioni e piè di pagina della presentazione in C++
linktitle: Intestazione e piè di pagina
type: docs
weight: 140
url: /it/cpp/presentation-header-and-footer/
keywords:
- intestazione
- testo intestazione
- piè di pagina
- testo piè di pagina
- impostare intestazione
- impostare piè di pagina
- dispense
- note
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Utilizza Aspose.Slides per C++ per aggiungere e personalizzare intestazioni e piè di pagina nelle presentazioni PowerPoint e OpenDocument per un aspetto professionale."
---
## **Panoramica**

Aspose.Slides consente di gestire le impostazioni di intestazione e piè di pagina nelle presentazioni PowerPoint. Le intestazioni e i piè di pagina sono gestiti a livello del master della presentazione e l'API fornisce metodi per impostare il testo del piè di pagina, modificare la visibilità del piè di pagina e aggiornare il testo dell'intestazione nelle diapositive master delle note.

È inoltre possibile gestire intestazioni e piè di pagina per le diapositive di handout e note. Questo include la modifica della visibilità e del testo dei segnaposto di intestazione, piè di pagina, numero diapositiva e data/ora per il master delle note, tutte le diapositive di note figlie o una singola diapositiva di note.

## **Gestire testo intestazione e piè di pagina**

Le note di alcune diapositive specifiche possono essere aggiornate come mostrato nell'esempio seguente:

``` cpp
// Funzione per impostare il testo intestazione/piè di pagina
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Carica presentazione
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Imposta piè di pagina
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Accedi e aggiorna intestazione
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Salva presentazione
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Gestire intestazioni e piè di pagina su diapositive Handout e Note**
Aspose.Slides per C++ supporta intestazione e piè di pagina nelle diapositive Handout e Note. Segui i passaggi seguenti:

- Carica una [Presentazione](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation)contenente un video.
- Modifica le impostazioni di intestazione e piè di pagina per il master delle note e tutte le diapositive di note.
- Imposta il master delle note e tutti i segnaposto Footer figlio come visibili.
- Imposta il master delle note e tutti i segnaposto Date and time figlio come visibili.
- Modifica le impostazioni di intestazione e piè di pagina solo per la prima diapositiva di note.
- Imposta il segnaposto Header della diapositiva di note come visibile.
- Imposta il testo nel segnaposto Header della diapositiva di note.
- Imposta il testo nel segnaposto Date-time della diapositiva di note.
- Scrivi il file di presentazione modificato.

Snippet di codice fornito nell'esempio seguente.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Modifica le impostazioni di intestazione e piè di pagina per il master delle note e tutte le diapositive di note
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// rendi visibili la diapositiva master delle note e tutti i segnaposto Footer dei figli
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// rendi visibili la diapositiva master delle note e tutti i segnaposto Header dei figli
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// rendi visibili la diapositiva master delle note e tutti i segnaposto SlideNumber dei figli
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// rendi visibili la diapositiva master delle note e tutti i segnaposto Data e ora dei figli
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// imposta il testo sulla diapositiva master delle note e su tutti i segnaposto Header dei figli
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// imposta il testo sulla diapositiva master delle note e su tutti i segnaposto Footer dei figli
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// imposta il testo sulla diapositiva master delle note e su tutti i segnaposto Data e ora dei figli
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Modifica le impostazioni di intestazione e piè di pagina solo per la prima diapositiva di note
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// rendi visibile il segnaposto Header di questa diapositiva di note
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// rendi visibile il segnaposto Footer di questa diapositiva di note
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// rendi visibile il segnaposto SlideNumber di questa diapositiva di note
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// rendi visibile il segnaposto Data-ora di questa diapositiva di note
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// imposta il testo sul segnaposto Header della diapositiva di note
	headerFooterManager->SetHeaderText(u"New header text");
	// imposta il testo sul segnaposto Footer della diapositiva di note
	headerFooterManager->SetFooterText(u"New footer text");
	// imposta il testo sul segnaposto Date-time della diapositiva di note
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso aggiungere un "header" alle diapositive normali?**

In PowerPoint, "Header" esiste solo per le note e gli handout; nelle diapositive normali, gli elementi supportati sono il footer, date/time e slide number. In Aspose.Slides questa corrisponde alle stesse limitazioni: header solo per Notes/Handout, e nelle diapositive—Footer/DateTime/SlideNumber.

**Cosa succede se il layout non contiene un'area piè di pagina—posso "attivare" la sua visibilità?**

Sì. Controlla la visibilità tramite il gestore di header/footer e abilitala se necessario. Questi indicatori e metodi dell'API sono progettati per i casi in cui il segnaposto è mancante o nascosto.

**Come posso far partire il numero della diapositiva da un valore diverso da 1?**

Imposta il [first slide number](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/set_firstslidenumber/) della presentazione; dopo di che, tutta la numerazione viene ricalcolata. Per esempio, puoi iniziare da 0 o 10 e nascondere il numero nella diapositiva titolo.

**Cosa succede a intestazioni/piè di pagina quando si esporta in PDF/immagini/HTML?**

Vengono renderizzati come normali elementi di testo della presentazione. Cioè, se gli elementi sono visibili nelle diapositive/pagine delle note, appariranno anche nel formato di output insieme al resto del contenuto.