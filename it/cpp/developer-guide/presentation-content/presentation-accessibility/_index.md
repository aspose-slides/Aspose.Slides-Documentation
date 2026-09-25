---
title: "Gestire l'accessibilità delle presentazioni in C++"
linktitle: "Accessibilità della presentazione"
type: docs
weight: 30
url: /it/cpp/presentation-accessibility/
keywords:
- accessibilità della presentazione
- testo alternativo
- titolo del testo alternativo
- descrizione del testo alternativo
- contrassegna come decorativo
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Automatizza i controlli di accessibilità delle presentazioni nei file PPT, PPTX e ODP con Aspose.Slides per C++—migliora l'esperienza dei lettori di schermo e aumenta la conformità."
---
## **Introduzione**

Il testo alternativo aiuta le persone che utilizzano tecnologie assistive a comprendere il significato di immagini, diagrammi e altre forme informative. Questo articolo spiega come leggere e aggiornare i titoli e le descrizioni del testo alternativo con Aspose.Slides per C++, distinguere le descrizioni di accessibilità dai nomi delle forme utilizzati nel codice e verificare se una forma è contrassegnata come decorativa.

Queste funzionalità supportano l’accessibilità delle presentazioni, ma non la garantiscono. È necessario anche esaminare l’ordine di lettura, il contrasto cromatico, la leggibilità del testo e altri requisiti di accessibilità.

## **Gestire i titoli e le descrizioni del testo alternativo**

Utilizzare il testo alternativo per spiegare il significato di immagini, diagrammi e altre forme informative alle persone che non possono vederle. Le seguenti proprietà hanno scopi diversi:

| Proprietà o contenuto | Scopo |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_alternativetexttitle/) | Un titolo breve per la descrizione alternativa. |
| [AlternativeText](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_alternativetext/) | Una descrizione significativa del contenuto o dello scopo della forma nel contesto della diapositiva. |
| [Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_name/) | Il nome della forma, che il codice può usare per trovare una forma specifica nella presentazione. |
| Testo visibile | Contenuto visualizzato sulla diapositiva, come il testo di una forma o il titolo e le etichette di un diagramma. L’aggiornamento del testo alternativo non modifica questo contenuto. |

Quando una presentazione viene riutilizzata come modello, il codice può trovare una forma per il suo [Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_name/) prima di aggiornarla. Questo nome ha uno scopo diverso dal testo alternativo, che spiega ciò che il visual comunica al lettore. La ricerca per nome consente agli autori di migliorare o tradurre le descrizioni senza cambiare il modo in cui il codice trova la forma. I nomi possono essere modificati e non sono garantiti essere univoci, quindi verificare che il nome corrisponda alla forma prevista; vedere [Identificare e trovare le forme](/slides/it/cpp/shape-manipulations/#identify-and-find-shapes).

L’esempio seguente richiede `input.pptx` con un’immagine di un ingresso d’ufficio come prima forma nella prima diapositiva. L’immagine non deve essere contrassegnata come decorativa. L’esempio legge e stampa il titolo e la descrizione attuali del testo alternativo, aggiorna entrambi i valori e salva la presentazione come `output.pptx`. Adattare la formulazione all’immagine reale e alle informazioni che trasmette.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Aggiungere solo il testo alternativo non garantisce l’accessibilità della presentazione né la conformità agli standard di accessibilità. Revisionare le descrizioni per accuratezza e rilevanza, e controllare anche l’ordine di lettura, il contrasto cromatico, il testo leggibile e altri requisiti di accessibilità. I contenuti visivi informativi non devono essere contrassegnati come decorativi; la sezione successiva mostra come leggere [IsDecorative](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_isdecorative/).

## **Contrassegnare come decorativo**

Il flag “contrassegnare come decorativo” indica elementi puramente ornamentali affinché i lettori di schermo li ignorino, riducendo il rumore e mantenendo l’attenzione sul contenuto significativo. Applicarlo a sfondi, ornamenti e spaziatori—mai a diagrammi, icone o immagini che trasmettono informazioni. Aspose.Slides espone questo flag per il rilevamento e la convalida, permettendo controlli di accessibilità automatizzati e pulizia.

![Contrassegna come decorativo](mark_as_decorative.png)

Il seguente esempio di codice mostra come determinare se una forma è contrassegnata come decorativa.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **FAQ**

**Cosa dovrei inserire nel titolo e nella descrizione del testo alternativo?**

Usare un titolo breve per identificare l’oggetto e una descrizione per spiegare le informazioni che il visual trasmette nel contesto della diapositiva. Per un diagramma, descrivere la tendenza o il confronto rilevante invece di limitarsi a dire “diagramma”.

**Devo usare il testo alternativo per individuare le forme in un modello?**

Preferire la ricerca della forma per il suo [Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_name/) e verificare che sia la forma prevista. Il testo alternativo può essere modificato o tradotto, il che può rompere il codice che cerca una descrizione esatta; vedere [Identificare e trovare le forme](/slides/it/cpp/shape-manipulations/).

**Quando una forma dovrebbe essere contrassegnata come decorativa?**

Usare il flag decorativo per elementi visivi che non aggiungono informazioni, come ornamenti ornamentali. Immagini e diagrammi che comunicano significato necessitano di una descrizione appropriata invece.

**L’aggiunta del testo alternativo rende una presentazione completamente accessibile?**

No. Il testo alternativo affronta solo una parte dell’accessibilità. È necessario anche rivedere l’ordine di lettura, il contrasto cromatico, la leggibilità del testo e altri requisiti applicabili; impostare queste proprietà da sole non stabilisce la conformità.