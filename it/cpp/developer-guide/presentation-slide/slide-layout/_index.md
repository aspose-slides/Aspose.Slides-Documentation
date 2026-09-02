---
title: Applica o Modifica Layout di Diapositiva in C++
linktitle: Layout di Diapositiva
type: docs
weight: 60
url: /it/cpp/slide-layout/
keywords:
- layout di diapositiva
- layout di contenuto
- segnaposto
- progettazione della presentazione
- progettazione della diapositiva
- layout non utilizzato
- visibilità del piè di pagina
- diapositiva titolo
- titolo e contenuto
- intestazione di sezione
- due contenuti
- confronto
- solo titolo
- layout vuoto
- contenuto con didascalia
- immagine con didascalia
- titolo e testo verticale
- titolo verticale e testo
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Applica, crea e modifica layout diapositive in Aspose.Slides per C++, aggiungi segnaposti, rimuovi layout non utilizzati e controlla la visibilità del piè di pagina."
---
## **Panoramica**

Un layout di diapositiva definisce le posizioni e la formattazione dei segnaposto come titoli, testi, immagini, grafici e tabelle. Applicare un layout conferisce alle diapositive una struttura coerente consentendo al contempo a ciascuna diapositiva di contenere i propri contenuti.

I layout più comuni includono:

- **Diapositiva Titolo**: Contiene i segnaposto del titolo e del sottotitolo.
- **Titolo e Contenuto**: Contiene un segnaposto del titolo e un segnaposto di contenuto generico.
- **Vuota**: Non contiene segnaposti di contenuto ed è utile quando ogni forma sarà posizionata manualmente.

## **Comprendere l'ereditarietà del layout**

Una presentazione ha tre livelli correlati:

1. Una [diapositiva master](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslide/) definisce il tema, la formattazione condivisa, gli sfondi e gli oggetti comuni.
2. Una [diapositiva layout](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/) appartiene a un master e definisce una disposizione specifica di segnaposti.
3. Una [diapositiva normale](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/) utilizza un layout e memorizza il contenuto inserito per quella diapositiva.

Una diapositiva normale eredita il tema e la formattazione dal suo layout, e il layout eredita dal suo master. Un valore impostato direttamente su una diapositiva normale sovrascrive il valore ereditato a quel livello. Quando una diapositiva normale viene creata, le sue forme segnaposto sono generate dal layout selezionato, mentre il contenuto inserito in quei segnaposti appartiene alla diapositiva normale.

Aggiungi i segnaposto richiesti a un layout prima di creare diapositive da esso. L'aggiunta successiva di un altro segnaposto a un layout non aggiunge automaticamente una forma segnaposto corrispondente alle diapositive normali esistenti.

Questa relazione ha due conseguenze importanti:

- Modificare la formattazione ereditata o la geometria dei segnaposti esistenti su un layout può aggiornare tutte le diapositive che dipendono da esso. Prima di modificare un layout già in uso, ispeziona le diapositive dipendenti e verifica la presentazione risultante.
- Un layout ancora utilizzato da una diapositiva non può essere rimosso. Riassegna prima le sue diapositive dipendenti a un altro layout, o rimuovi solo i layout non utilizzati.

Per ulteriori informazioni sul livello superiore di questa gerarchia, vedi [Master delle Diapositive](/slides/it/cpp/slide-master/).

## **Selezionare e Applicare un Layout di Diapositiva**

Utilizza un tipo di layout quando la presentazione segue le definizioni standard dei layout di PowerPoint. I nomi dei layout sono modificabili dall'utente e possono essere localizzati, quindi la selezione basata sul nome è meno affidabile a meno che non si controlli il modello originale.

L'esempio seguente ricerca **Titolo e Contenuto** sul primo master. Se quel layout non è disponibile, si torna deliberatamente a **Vuota**. Il secondo controllo null è necessario perché una presentazione può contenere solo layout personalizzati. Il layout selezionato viene quindi applicato alla prima diapositiva normale tramite il metodo [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/set_layoutslide/).

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Modificare il layout di una diapositiva non rimuove le forme ordinarie aggiunte direttamente alla diapositiva. Tuttavia, le posizioni dei segnaposti, la formattazione ereditata e la corrispondenza tra i segnaposti esistenti e il nuovo layout possono cambiare, quindi verifica l'output quando si passa tra layout sostanzialmente diversi.

## **Aggiungere una Diapositiva Layout**

La selezione e la creazione sono operazioni separate. L'esempio precedente seleziona un layout esistente; non ne crea uno. Per creare un layout, chiama il metodo [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterlayoutslidecollection/add/) sulla collezione di layout del master di destinazione.

L'esempio seguente aggiunge sempre un nuovo layout **Titolo e Contenuto** denominato `Report Title and Content`, quindi aggiunge una diapositiva normale basata su di esso. I nomi dei layout devono essere unici all'interno della collezione.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Aggiungi un layout solo quando il modello necessita davvero di un'altra struttura riutilizzabile. Se esiste già un layout adeguato, selezionalo e riutilizzalo invece di crearne un duplicato.

## **Aggiungere Segnaposti a una Diapositiva Layout**

Il metodo [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) fornisce un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/) per aggiungere forme segnaposto a un layout.

| PowerPoint Placeholder | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![Contenuto](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Contenuto (Verticale)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Testo](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Testo (Verticale)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Immagine](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Grafico](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tabella](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Immagine Online](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

L'esempio seguente verifica che il layout **Vuota** esista, aggiunge quattro segnaposti ad esso, quindi crea una diapositiva normale che utilizza il layout modificato. L'ordine è intenzionale: i segnaposti vengono aggiunti prima che la diapositiva normale sia creata, così Aspose.Slides può generare le forme segnaposto corrispondenti su quella diapositiva.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![I segnaposti sulla diapositiva layout](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modificare la formattazione ereditata o la geometria dei segnaposti del layout esistenti può influire sulle diapositive dipendenti. Un segnaposto del layout appena aggiunto non viene retrocompatibilmente inserito nelle diapositive normali esistenti. Prova le modifiche al layout su una copia della presentazione e ispeziona ogni diapositiva dipendente.
{{% /alert %}}

## **Rimuovere le Diapositive Layout Non Utilizzate**

Utilizza il metodo [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) per rimuovere i layout a cui nessuna diapositiva normale fa riferimento. Il metodo lascia intatti i layout ancora in uso.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Per rimuovere un layout specifico, usa prima il suo metodo [get_HasDependingSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) o il metodo [GetDependingSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/getdependingslides/). Riassegna le diapositive dipendenti prima di chiamare [ILayoutSlide::Remove](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/remove/). Tentare di rimuovere un layout in uso genera una [PptxEditException](https://reference.aspose.com/slides/it/cpp/aspose.slides/pptxeditexception/).

## **Controllare la Visibilità del Piè di Pagina su una Diapositiva Layout**

Un layout ha i propri segnaposti per piè di pagina, numero diapositiva e data/ora. Usa il metodo [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) per controllare quei segnaposti per un singolo layout. Questo è utile quando, ad esempio, i layout di contenuto devono mostrare i piè di pagina ma i layout di titolo no.

L'esempio seguente seleziona un layout in modo sicuro e rende visibili gli elementi del piè di pagina:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Controllare la Visibilità del Piè di Pagina su un Master e sui Suoi Layout Figli**

Per applicare impostazioni del piè di pagina coerenti su tutta la gerarchia di un master, utilizza il metodo [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslide/get_headerfootermanager/). I metodi di propagazione di [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslideheaderfootermanager/) operano sul master e sulle sue diapositive layout dipendenti e sulle diapositive normali; non mirano a una sola diapositiva normale.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Qual è la differenza tra una diapositiva master e una diapositiva layout?**

Una diapositiva master definisce il tema della presentazione e la formattazione condivisa. Una diapositiva layout appartiene a un master e definisce una disposizione riutilizzabile di segnaposti. Le diapositive normali utilizzano questi layout e memorizzano i contenuti specifici della diapositiva.

**Posso copiare una diapositiva layout da una presentazione all'altra?**

Sì. Aggiungi una copia alla collezione di destinazione con il metodo [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Quando copi tra presentazioni, verifica anche i caratteri, i temi, le immagini e le altre risorse utilizzate dal layout di origine.

**Cosa succede se modifico un layout già in uso?**

Le diapositive dipendenti ereditano le modifiche al layout a meno che non sovrascrivano localmente la formattazione o gli oggetti interessati. La geometria dei segnaposti e lo stile ereditato possono quindi cambiare su molte diapositive contemporaneamente. Usa [GetDependingSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/getdependingslides/) per identificare le diapositive interessate prima di modificare il layout.

**Cosa succede se rimuovo un layout ancora in uso?**

Aspose.Slides genera una [PptxEditException](https://reference.aspose.com/slides/it/cpp/aspose.slides/pptxeditexception/). Riassegna prima le diapositive dipendenti, oppure utilizza [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) per rimuovere solo i layout non referenziati.