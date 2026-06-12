---
title: Rimuovere diapositive dalle presentazioni in C++
linktitle: Rimuovi diapositiva
type: docs
weight: 30
url: /it/cpp/remove-slide-from-presentation/
keywords:
- rimuovi diapositiva
- elimina diapositiva
- rimuovi diapositiva inutilizzata
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Rimuovi facilmente diapositive da presentazioni PowerPoint e OpenDocument con Aspose.Slides per C++. Ottieni esempi di codice chiari e velocizza il tuo flusso di lavoro."
---
## **Introduzione**

Se una diapositiva (o il suo contenuto) diventa ridondante, puoi eliminarla. Aspose.Slides fornisce la classe [Presentazione](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) che incapsula [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/), un repository per tutte le diapositive di una presentazione. Utilizzando puntatori (riferimento o indice) per un oggetto [ISlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/) noto, puoi specificare la diapositiva da rimuovere. 

## **Rimuovere una diapositiva per riferimento**

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva da rimuovere tramite il suo ID o indice.
1. Rimuovi la diapositiva di riferimento dalla presentazione.
1. Salva la presentazione modificata. 

Questo codice C++ mostra come rimuovere una diapositiva tramite il suo riferimento: 

```c++
	// Il percorso della directory dei documenti
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Istanzia un oggetto Presentation che rappresenta un file di presentazione
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Accede a una diapositiva tramite il suo indice nella raccolta di diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Rimuove una diapositiva tramite il suo riferimento
	pres->get_Slides()->Remove(slide);

	// Salva la presentazione modificata
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Rimuovere una diapositiva per indice**

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Rimuovi la diapositiva dalla presentazione tramite la sua posizione indice.
1. Salva la presentazione modificata. 

Questo codice C++ mostra come rimuovere una diapositiva tramite il suo indice: 

```c++
	// Il percorso della directory dei documenti
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Istanzia un oggetto Presentation che rappresenta un file di presentazione
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Rimuove una diapositiva tramite il suo indice
	pres->get_Slides()->RemoveAt(0);

	// Salva la presentazione modificata
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Rimuovere le diapositive layout inutilizzate**

Aspose.Slides fornisce il metodo [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (dalla classe [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/)) per consentire l'eliminazione di layout diapositive indesiderati e non utilizzati. Questo codice C++ mostra come rimuovere un layout diapositiva da una presentazione PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Rimuovere le diapositive master inutilizzate**

Aspose.Slides fornisce il metodo [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (dalla classe [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/)) per consentire l'eliminazione di master diapositive indesiderati e non utilizzati. Questo codice C++ mostra come rimuovere un master diapositiva da una presentazione PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Cosa succede agli indici delle diapositive dopo aver eliminato una diapositiva?**

Dopo l'eliminazione, la [collection](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidecollection/) riorganizza gli indici: ogni diapositiva successiva si sposta di una posizione verso sinistra, quindi i numeri di indice precedenti diventano obsoleti. Se ti serve un riferimento stabile, usa l'ID persistente di ciascuna diapositiva invece del suo indice.

**L'ID di una diapositiva è diverso dal suo indice e cambia quando le diapositive vicine vengono eliminate?**

Sì. L'indice è la posizione della diapositiva e cambia quando le diapositive vengono aggiunte o rimosse. L'ID della diapositiva è un identificatore persistente e non varia quando altre diapositive vengono eliminate.

**Come influisce l'eliminazione di una diapositiva sulle sezioni delle diapositive?**

Se la diapositiva apparteneva a una sezione, quella sezione conterrà semplicemente una diapositiva in meno. La struttura della sezione rimane invariata; se una sezione diventa vuota, puoi [rimuovere o riorganizzare le sezioni](/slides/it/cpp/slide-section/) secondo necessità.

**Cosa accade a note e commenti collegati a una diapositiva quando questa viene eliminata?**

[Notes](/slides/it/cpp/presentation-notes/) e [comments](/slides/it/cpp/presentation-comments/) sono legati a quella specifica diapositiva e vengono rimossi insieme ad essa. Il contenuto delle altre diapositive non è influenzato.

**In che modo l'eliminazione delle diapositive differisce dalla pulizia di layout/master inutilizzati?**

L'eliminazione rimuove diapositive normali specifiche dal mazzo. La pulizia di layout/master inutilizzati elimina diapositive layout o master a cui nessuno fa riferimento, riducendo la dimensione del file senza modificare il contenuto delle diapositive rimanenti. Queste azioni sono complementari: tipicamente si elimina prima, poi si esegue la pulizia.