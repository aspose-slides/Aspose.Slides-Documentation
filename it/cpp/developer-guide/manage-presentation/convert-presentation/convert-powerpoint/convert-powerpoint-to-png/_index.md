---
title: Converti le diapositive PowerPoint in PNG in C++
linktitle: PowerPoint in PNG
type: docs
weight: 30
url: /it/cpp/convert-powerpoint-to-png/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in PNG
- presentazione in PNG
- diapositiva in PNG
- PPT in PNG
- PPTX in PNG
- salva PPT come PNG
- salva PPTX come PNG
- esporta PPT in PNG
- esporta PPTX in PNG
- C++
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in immagini PNG di alta qualità rapidamente con Aspose.Slides per C++, garantendo risultati precisi e automatizzati."
---
## **Panoramica**

Questo articolo spiega come convertire le diapositive di una presentazione in immagini PNG utilizzando Aspose.Slides per C++. È possibile caricare presentazioni in formati come PPT, PPTX e ODP, renderizzare ogni diapositiva e salvarla come immagine PNG separata.

Gli esempi seguenti mostrano il rendering alla scala predefinita, l'aumento della scala, la specifica delle dimensioni di output in pixel e la scelta di uno stile di rendering a gradiente.

## **Converti PowerPoint in PNG**

Carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) e accedi alle sue diapositive tramite l'accessore [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/). L'esempio rende ogni diapositiva con [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) senza parametri per creare una miniatura. Quindi chiama [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) con [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) per salvare ogni diapositiva renderizzata come immagine PNG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
La sovraccarico senza parametri di [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) rende a una scala di 0,2. Ad esempio, una diapositiva di 720 × 540 punti produce una miniatura di 144 × 108 pixel. Per controllare le dimensioni di output, usa i sovraccarichi con i fattori di scala o una dimensione dell'immagine esplicita mostrata di seguito.
{{% /alert %}}

## **Converti PowerPoint in PNG con dimensioni personalizzate**

Passa i fattori di scala orizzontale e verticale a [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) per controllare le dimensioni renderizzate. In questo esempio, entrambi i fattori sono 2, quindi una diapositiva di 720 × 540 punti produce un'immagine di 1440 × 1080 pixel. Fattori di scala uguali preservano le proporzioni della diapositiva. Ogni immagine viene salvata in formato PNG con [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Converti PowerPoint in PNG con dimensione personalizzata**

Per specificare le dimensioni di output in pixel, passa una dimensione a [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) invece dei fattori di scala. Questo esempio renderizza ogni diapositiva a 960 × 720 pixel e salva il risultato con [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Scegli dimensioni che corrispondono alle proporzioni della diapositiva per evitare di allungare l'immagine.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Scegli uno stile di rendering a gradiente**

Supponi che una diapositiva contenga riempimenti a gradiente, ma le transizioni nel PNG esportato appaiano più chiare o comunque diverse da quelle che vedi in PowerPoint. Puoi usare il metodo [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) di [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) per scegliere come vengono renderizzati i gradienti.

Scarica [gradient-styles.pptx](gradient-styles.pptx) e posizionalo nella directory di lavoro dell'applicazione. La sua prima diapositiva contiene due gradienti lineari: ciano verso arancione nella parte superiore e blu verso giallo nella parte inferiore. Ogni gradiente ha due fermate, al 0% e al 100%.

L'esempio seguente carica questa presentazione e renderizza la stessa prima diapositiva in entrambi i modi con [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

Le immagini seguenti mostrano l'output della stessa diapositiva, con entrambi i gradienti in ciascuna immagine:

| Default | PowerPointUI |
| --- | --- |
| ![Gradienti dal ciano all'arancione e dal blu al giallo renderizzati con Default](gradient-Default.png) | ![Gli stessi gradienti renderizzati con PowerPointUI](gradient-PowerPointUI.png) |

In questo esempio, `Default` produce colori intermedi più chiari, mentre `PowerPointUI` produce colori intermedi più scuri. La differenza dipende dai colori e dalle fermate nel gradiente.

Scegli `Default` quando l'output standard di Aspose.Slides soddisfa le tue esigenze. Prova `PowerPointUI` quando la tua priorità è corrispondere all'aspetto in PowerPoint. Confronta entrambi gli output con il risultato desiderato; nessuna modalità è universalmente preferibile.

## **FAQ**

**Come posso esportare una forma specifica, come un grafico o un'immagine, invece dell'intera diapositiva?**

Aspose.Slides supporta la [generazione di miniature per forme individuali](/slides/it/cpp/shape-thumbnails/), consentendo di renderizzare una forma come immagine PNG.

**La conversione parallela è supportata su un server?**

Sì. Usa un'istanza di presentazione separata per ogni thread o processo; [non condividere una singola istanza tra thread](/slides/it/cpp/multithreading/).

**Quali sono le limitazioni della versione di valutazione quando si esporta in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica [altre restrizioni](/slides/it/cpp/licensing/) finché non viene applicata una licenza.