---
title: Accedi alle diapositive della presentazione in C++
linktitle: Accedi alla diapositiva
type: docs
weight: 20
url: /it/cpp/access-slide-in-presentation/
keywords:
- accesso diapositiva
- indice diapositiva
- id diapositiva
- posizione diapositiva
- modifica posizione
- proprietà diapositiva
- numero diapositiva
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come accedere e gestire le diapositive in presentazioni PowerPoint e OpenDocument con Aspose.Slides per C++. Aumenta la produttività con esempi di codice."
---
## **Panoramica**

Questo articolo spiega come accedere e gestire le diapositive in una presentazione utilizzando Aspose.Slides. Mostra come recuperare le diapositive tramite il loro indice a base zero dalla collezione di diapositive e come accedere a una diapositiva tramite il suo ID univoco utilizzando il metodo `GetSlideById`.

Imparerai anche come modificare la posizione di una diapositiva usando il metodo `set_SlideNumber` e come definire il numero della diapositiva iniziale per una presentazione con il metodo `set_FirstSlideNumber`. Gli esempi mostrano come caricare una presentazione, ottenere riferimenti alle diapositive, aggiornare l'ordine o la numerazione delle diapositive e salvare la presentazione modificata.

## **Accesso a una diapositiva per indice**

Tutte le diapositive in una presentazione sono ordinate numericamente in base alla posizione della diapositiva a partire da 0. La prima diapositiva è accessibile tramite l'indice 0; la seconda diapositiva è accessibile tramite l'indice 1; ecc.

La classe Presentation, che rappresenta un file di presentazione, espone tutte le diapositive come una collezione [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) (collezione di oggetti [ISlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/)). Questo codice C++ mostra come accedere a una diapositiva tramite il suo indice:

```c++
	// Il percorso alla directory dei documenti.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Istanzia la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Ottieni il riferimento di una diapositiva tramite il suo indice
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Accesso a una diapositiva per ID**

Ogni diapositiva in una presentazione ha un ID univoco associato. È possibile utilizzare il metodo [GetSlideById()](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/getslidebyid/) (esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/)) per puntare a quell'ID. Questo codice C++ mostra come fornire un ID diapositiva valido e accedere a quella diapositiva tramite il metodo [GetSlideById()](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/getslidebyid/):

```c++
	// Il percorso alla directory dei documenti.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instanzia la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Ottiene l'ID di una diapositiva
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Accede alla diapositiva tramite il suo ID
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Modifica della posizione della diapositiva**

Aspose.Slides consente di modificare la posizione di una diapositiva. Ad esempio, è possibile specificare che la prima diapositiva diventi la seconda diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni il riferimento della diapositiva (la cui posizione desideri modificare) tramite il suo indice
1. Imposta una nuova posizione per la diapositiva tramite la proprietà [set_SlideNumber()](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/set_slidenumber/).
1. Salva la presentazione modificata.

Questo codice C++ dimostra un'operazione in cui la diapositiva in posizione 1 viene spostata in posizione 2:

```c++
	// Il percorso alla directory dei documenti.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Istanzia la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Ottiene la diapositiva la cui posizione verrà modificata
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Imposta la nuova posizione per la diapositiva
	slide->set_SlideNumber(2);

	// Salva la presentazione modificata
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

La prima diapositiva è diventata la seconda; la seconda diapositiva è diventata la prima. Quando cambi la posizione di una diapositiva, le altre diapositive vengono automaticamente riordinate.

## **Imposta il numero della diapositiva**

Utilizzando la proprietà [set_FirstSlideNumber()](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/set_firstslidenumber/) (esposta dalla classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/)), è possibile specificare un nuovo numero per la prima diapositiva di una presentazione. Questa operazione fa sì che gli altri numeri delle diapositive vengano ricalcolati.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni il numero della diapositiva.
1. Imposta il numero della diapositiva.
1. Salva la presentazione modificata.

Questo codice C++ dimostra un'operazione in cui il numero della prima diapositiva è impostato a 10:

```c++
	// Il percorso alla directory dei documenti.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Instanzia la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Ottiene il numero della diapositiva
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Imposta il numero della diapositiva
	pres->set_FirstSlideNumber(2);
	
	// Salva la presentazione modificata
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Se preferisci omettere la prima diapositiva, puoi iniziare la numerazione dalla seconda diapositiva (e nascondere la numerazione per la prima diapositiva) in questo modo:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Il numero della diapositiva visualizzato dall'utente corrisponde all'indice a base zero della collezione?**

Il numero mostrato sulla diapositiva può iniziare da un valore arbitrario (ad esempio, 10) e non deve corrispondere all'indice; la relazione è controllata dall'impostazione [first slide number](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/set_firstslidenumber/) della presentazione.

**Le diapositive nascoste influenzano l'indicizzazione?**

Sì. Una diapositiva nascosta rimane nella collezione ed è conteggiata nell'indicizzazione; "hidden" si riferisce alla visualizzazione, non alla sua posizione nella collezione.

**L'indice di una diapositiva cambia quando vengono aggiunte o rimosse altre diapositive?**

Sì. Gli indici riflettono sempre l'ordine corrente delle diapositive e vengono ricalcolati durante le operazioni di inserimento, eliminazione e spostamento.