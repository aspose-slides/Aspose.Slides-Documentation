---
title: Applica o modifica i layout delle diapositive in C++
linktitle: Layout diapositiva
type: docs
weight: 60
url: /it/cpp/slide-layout/
keywords:
- layout diapositiva
- layout contenuto
- segnaposto
- progettazione presentazione
- progettazione diapositiva
- layout inutilizzato
- visibilità piè di pagina
- diapositiva titolo
- titolo e contenuto
- intestazione sezione
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
description: "Applica, crea e modifica i layout delle diapositive in Aspose.Slides per C++, aggiungi segnaposti, rimuovi layout inutilizzati e controlla la visibilità del piè di pagina."
---
## **Panoramica**

Un layout di diapositiva definisce le posizioni e la formattazione dei segnaposti come titoli, testo, immagini, grafici e tabelle. L’applicazione di un layout conferisce alle diapositive una struttura coerente consentendo al contempo a ciascuna diapositiva di contenere il proprio contenuto.

I layout più comuni includono:

- **Title Slide**: Contiene i segnaposti per titolo e sottotitolo.  
- **Title and Content**: Contiene un segnaposto titolo e un segnaposto contenuto di uso generale.  
- **Blank**: Non contiene segnaposti di contenuto ed è utile quando ogni forma verrà posizionata manualmente.

## **Comprendere l'ereditarietà del layout**

Una presentazione ha tre livelli correlati:

1. Una [slide master](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslide/) definisce il tema, la formattazione condivisa, gli sfondi e gli oggetti comuni.  
1. Una [slide di layout](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/) appartiene a un master e definisce una particolare disposizione dei segnaposti.  
1. Una [slide normale](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/) utilizza un layout e conserva il contenuto inserito per quella diapositiva.

Una slide normale eredita tema e formattazione dal suo layout, e il layout eredita dal suo master. Un valore impostato direttamente su una slide normale sovrascrive il valore ereditato a quel livello. Quando una slide normale viene creata, le sue forme segnaposto sono generate dal layout selezionato, mentre il contenuto inserito in quei segnaposti appartiene alla slide normale.

Aggiungi i segnaposti richiesti a un layout prima di creare le diapositive da esso. L’aggiunta successiva di un nuovo segnaposto a un layout non aggiunge automaticamente una forma segnaposto corrispondente alle slide normali esistenti.

Questa relazione ha due conseguenze importanti:

- Modificare la formattazione ereditata o la geometria dei segnaposti esistenti su un layout può aggiornare ogni diapositiva che dipende da esso. Prima di modificare un layout già in uso, ispeziona le diapositive dipendenti e verifica la presentazione risultante.  
- Un layout ancora utilizzato da una diapositiva non può essere rimosso. Riassegna prima le diapositive dipendenti a un altro layout, oppure rimuovi solo i layout non utilizzati.

Per ulteriori informazioni sul livello superiore di questa gerarchia, consulta [Slide Master](/slides/it/cpp/slide-master/).

Per nascondere loghi ereditati o forme decorative del master su una singola diapositiva o tramite un layout condiviso, vedi [Control the Visibility of Master Graphics](/slides/it/cpp/slide-master/). L’esempio confronta due diapositive che usano lo stesso master.

## **Selezionare e applicare un layout di diapositiva**

Usa un tipo di layout quando la presentazione segue le definizioni standard dei layout di PowerPoint. I nomi dei layout sono modificabili dall’utente e possono essere localizzati, quindi la selezione basata sul nome è meno affidabile a meno che non si controlli il modello di origine.

L’esempio seguente cerca **Title and Content** sul primo master. Se quel layout non è disponibile, ricade deliberatamente su **Blank**. Il secondo controllo null è necessario perché una presentazione può contenere solo layout personalizzati. Il layout selezionato viene quindi applicato alla prima slide normale attraverso il metodo [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/set_layoutslide/).

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

Modificare il layout di una diapositiva non rimuove le forme ordinarie aggiunte direttamente alla diapositiva. Tuttavia, le posizioni dei segnaposti, la formattazione ereditata e la corrispondenza tra i segnaposti esistenti e il nuovo layout possono cambiare, quindi controlla l’output quando passi da layout sostanzialmente diversi.

## **Aggiungere una slide di layout**

Selezione e creazione sono operazioni separate. L’esempio precedente seleziona un layout esistente; non ne crea uno. Per creare un layout, chiama il metodo [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterlayoutslidecollection/add/) sulla collezione di layout del master di destinazione.

L’esempio seguente aggiunge sempre un nuovo layout **Title and Content** denominato `Report Title and Content`, quindi aggiunge una slide normale basata su di esso. I nomi dei layout devono essere unici all’interno della collezione.

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

Aggiungi un layout solo quando il modello necessita realmente di un’altra struttura riutilizzabile. Se esiste già un layout adatto, selezionalo e riutilizzalo invece di crearne uno duplicato.

## **Aggiungere segnaposti a una slide di layout**

Il metodo [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) fornisce un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/) per aggiungere forme segnaposto a un layout.

| Segnaposto PowerPoint | `ILayoutPlaceholderManager` Metodo |
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
| ![Immagine online](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

L’esempio seguente verifica che il layout **Blank** esista, aggiunge quattro segnaposti e quindi crea una slide normale che utilizza il layout modificato. L’ordine è intenzionale: i segnaposti vengono aggiunti prima della creazione della slide normale, così Aspose.Slides può generare le forme segnaposto corrispondenti su quella slide.

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

![I segnaposti sulla slide di layout](add_placeholders.png)

{{% alert color="warning" title="Attenzione" %}}
Modificare la formattazione ereditata o la geometria dei segnaposti esistenti di un layout può influire sulle diapositive dipendenti. Un segnaposto di layout appena aggiunto non viene retropropagato nelle slide normali esistenti. Prova le modifiche al layout su una copia della presentazione e ispeziona ogni diapositiva dipendente.
{{% /alert %}}

## **Rimuovere le slide di layout inutilizzate**

Usa il metodo [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) per rimuovere i layout a cui nessuna slide normale fa riferimento. Il metodo lascia intatti i layout ancora in uso.

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

Per rimuovere un layout specifico, usa prima il suo metodo [get_HasDependingSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) o [GetDependingSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/getdependingslides/). Riassegna le eventuali slide dipendenti prima di chiamare [ILayoutSlide::Remove](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/remove/). Tentare di rimuovere un layout in uso genera una [PptxEditException](https://reference.aspose.com/slides/it/cpp/aspose.slides/pptxeditexception/).

## **Controllare la visibilità del piè di pagina su una slide di layout**

Un layout possiede i propri segnaposti per piè di pagina, numero diapositiva e data/ora. Usa il metodo [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) per gestire questi segnaposti su un singolo layout. È utile, ad esempio, quando i layout di contenuto devono mostrare il piè di pagina ma i layout di titolo no.

L’esempio seguente seleziona in modo sicuro un layout e rende visibili gli elementi del piè di pagina:

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

## **Controllare la visibilità del piè di pagina su un master e sui suoi layout figlio**

Per applicare impostazioni di piè di pagina coerenti su un’intera gerarchia di master, usa il metodo [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslide/get_headerfootermanager/). I metodi di propagazione di [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslideheaderfootermanager/) agiscono sul master e sui suoi layout dipendenti e sulle slide normali; non mirano a una singola slide normale.

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

**Qual è la differenza tra una slide master e una slide di layout?**

Una slide master definisce il tema della presentazione e la formattazione condivisa. Una slide di layout appartiene a un master e definisce una disposizione riutilizzabile di segnaposti. Le slide normali utilizzano quei layout e archiviano il contenuto specifico della diapositiva.

**Posso copiare una slide di layout da una presentazione all'altra?**

Sì. Aggiungi una copia alla collezione di destinazione con il metodo [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Quando copi tra presentazioni, verifica anche caratteri, temi, immagini e altre risorse usate dal layout di origine.

**Cosa succede quando modifico un layout già in uso?**

Le slide dipendenti erediteranno le modifiche al layout a meno che non abbiano sovrascritto localmente la formattazione o gli oggetti interessati. La geometria dei segnaposti e lo stile ereditato possono quindi cambiare in molte diapositive contemporaneamente. Usa [GetDependingSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/getdependingslides/) per identificare le slide interessate prima di modificare il layout.

**Cosa succede se rimuovo un layout ancora in uso?**

Aspose.Slides lancia una [PptxEditException](https://reference.aspose.com/slides/it/cpp/aspose.slides/pptxeditexception/). Riassegna prima le slide dipendenti, oppure usa [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) per rimuovere solo i layout non referenziati.