---
title: Unisci presentazioni in modo efficiente in C++
linktitle: Unisci presentazioni
type: docs
weight: 40
url: /it/cpp/merge-presentation/
keywords:
- unire PowerPoint
- unire presentazioni
- unire diapositive
- unire PPT
- unire PPTX
- unire ODP
- combina PowerPoint
- combina presentazioni
- combina diapositive
- combina PPT
- combina PPTX
- combina ODP
- C++
- Aspose.Slides
description: "Unisci facilmente presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP) con Aspose.Slides per C++, ottimizzando il tuo flusso di lavoro."
---
## **Panoramica**

Aspose.Slides consente di unire presentazioni clonando diapositive da una presentazione a un’altra. Questo articolo spiega come unire intere presentazioni o diapositive selezionate, utilizzare un master della diapositiva o un layout specifico durante l’unione, gestire presentazioni con dimensioni della diapositiva diverse e aggiungere diapositive unite a una sezione della presentazione. Copre anche note pratiche relative al contenuto unito, incluse note del relatore, commenti, file di origine protetti da password e utilizzo dei thread.

## **Unione di presentazioni**

Quando unisci una presentazione a un’altra, combini effettivamente le loro diapositive in un’unica presentazione per ottenere un unico file. 

{{% alert title="Info" color="info" %}}

La maggior parte dei programmi di presentazione (PowerPoint o OpenOffice) non dispone di funzioni che permettano agli utenti di combinare presentazioni in questo modo. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/it/cpp/) consente comunque di unire le presentazioni in diversi modi. Puoi unire presentazioni con tutte le loro forme, stili, testi, formattazioni, commenti, animazioni, ecc., senza preoccuparti di perdita di qualità o dati. 

**Vedi anche**

[Clone Slides](https://docs.aspose.com/slides/it/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Cosa può essere unito**

Con Aspose.Slides, puoi unire 

* intere presentazioni. Tutte le diapositive delle presentazioni finiscono in un’unica presentazione
* diapositive specifiche. Le diapositive selezionate finiscono in un’unica presentazione
* presentazioni in un formato (PPT a PPT, PPTX a PPTX, ecc.) e in formati diversi (PPT a PPTX, PPTX a ODP, ecc.) tra loro. 

{{% alert title="Nota" color="warning" %}} 

Oltre alle presentazioni, Aspose.Slides consente di unire altri file:

* [Immagini](https://products.aspose.com/slides/it/cpp/merger/image-to-image/), ad esempio [JPG a JPG](https://products.aspose.com/slides/it/cpp/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/it/cpp/merger/png-to-png/)
* Documenti, ad esempio [PDF a PDF](https://products.aspose.com/slides/it/cpp/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/it/cpp/merger/html-to-html/)
* E due file diversi come [immagine a PDF](https://products.aspose.com/slides/it/cpp/merger/image-to-pdf/) o [JPG a PDF](https://products.aspose.com/slides/it/cpp/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/it/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opzioni di unione**

Puoi applicare opzioni che determinano se

* ogni diapositiva nella presentazione di output mantiene uno stile unico
* uno stile specifico è usato per tutte le diapositive nella presentazione di output. 

Per unire presentazioni, Aspose.Slides fornisce i metodi [AddClone](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (dall’interfaccia [ISlideCollection](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_slide_collection)). Esistono diverse implementazioni dei metodi `AddClone` che definiscono i parametri del processo di unione. Ogni oggetto Presentation ha una collezione [Slides](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), quindi puoi chiamare un metodo `AddClone` sulla presentazione in cui desideri unire le diapositive. 

Il metodo `AddClone` restituisce un oggetto `ISlide`, che è una copia della diapositiva di origine. Le diapositive nella presentazione di output sono semplicemente una copia delle diapositive di origine. Pertanto, puoi modificare le diapositive risultanti (ad esempio, applicare stili, opzioni di formattazione o layout) senza preoccuparti che le presentazioni di origine vengano influenzate. 

## **Unire presentazioni** 

Aspose.Slides fornisce il metodo [**AddClone (ISlide)**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) che consente di combinare diapositive mantenendo i loro layout e stili (parametri predefiniti). 

Questo codice C++ mostra come unire presentazioni:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Unire presentazioni con un master della diapositiva**

Aspose.Slides fornisce il metodo [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) che consente di combinare diapositive applicando un modello di master della diapositiva. In questo modo, se necessario, puoi modificare lo stile delle diapositive nella presentazione di output. 

Questo codice C++ dimostra l’operazione descritta:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Nota" color="warning" %}} 

Il layout della diapositiva per il master è determinato automaticamente. Quando non è possibile determinare un layout appropriato, se il parametro booleano `allowCloneMissingLayout` del metodo `AddClone` è impostato su true, viene usato il layout della diapositiva di origine. Altrimenti, verrà generata un’eccezione [PptxEditException](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Se desideri che le diapositive nella presentazione di output abbiano un layout diverso, utilizza il metodo [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) al momento dell’unione. 

## **Unire diapositive specifiche da presentazioni**

Unire diapositive specifiche da più presentazioni è utile per creare deck personalizzati. Aspose.Slides C++ consente di selezionare e importare solo le diapositive necessarie. L’API preserva la formattazione, il layout e il design delle diapositive originali.

Il seguente codice C++ crea una nuova presentazione, aggiunge diapositive titolo da due altre presentazioni e salva il risultato in un file:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Dichiarato nel codice sopra.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Unire presentazioni con un layout della diapositiva**

Questo codice C++ mostra come combinare diapositive da presentazioni applicando il layout di diapositiva desiderato per ottenere una presentazione di output unica:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Unire presentazioni con dimensioni della diapositiva diverse**

{{% alert title="Nota" color="warning" %}} 

Non è possibile unire presentazioni con dimensioni della diapositiva diverse. 

{{% /alert %}}

Per unire 2 presentazioni con dimensioni della diapositiva diverse, è necessario ridimensionare una delle presentazioni affinché corrisponda alle dimensioni dell’altra. 

Questo esempio di codice dimostra l’operazione descritta:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Unire diapositive a una sezione della presentazione**

Questo codice C++ mostra come unire una diapositiva specifica a una sezione in una presentazione:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

La diapositiva viene aggiunta alla fine della sezione. 

{{% alert title="Suggerimento" color="info" %}}

Aspose offre una [app web GRATUITA per collage](https://products.aspose.app/slides/it/collage). Utilizzando questo servizio online, puoi unire [JPG a JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG a PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e così via. 

{{% /alert %}}

## **FAQ**

### Le note del relatore vengono preservate durante l’unione?

Sì. Quando si clonano le diapositive, Aspose.Slides trasferisce tutti gli elementi della diapositiva, incluse le note, la formattazione e le animazioni.

### I commenti e i loro autori vengono trasferiti?

I commenti, in quanto parte del contenuto della diapositiva, vengono copiati con la diapositiva. Le etichette degli autori dei commenti sono preservate come oggetti commento nella presentazione risultante.

### Cosa succede se la presentazione di origine è protetta da password?

Deve essere [aperta con la password](/slides/it/cpp/password-protected-presentation/) tramite [LoadOptions::set_Password](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_password/); dopo il caricamento, quelle diapositive possono essere clonate in modo sicuro in un file di destinazione non protetto (o anche protetto).

### Quanto è sicura dal punto di vista dei thread l’operazione di unione?

Non utilizzare la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) da [thread multipli](/slides/it/cpp/multithreading/). La regola consigliata è “un documento — un thread”; file diversi possono essere processati in parallelo in thread separati.