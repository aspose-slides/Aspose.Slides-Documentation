---
title: Converti le diapositive PowerPoint in PNG in C++
linktitle: PowerPoint a PNG
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
description: "Converti le presentazioni PowerPoint in immagini PNG ad alta qualità rapidamente con Aspose.Slides per C++, garantendo risultati precisi e automatizzati."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in immagini PNG utilizzando Aspose.Slides. Mostra come caricare i file di presentazione in formati come PPT, PPTX e ODP, rendere le diapositive come immagini e salvare i risultati in formato PNG.

L'articolo dimostra anche come personalizzare le immagini PNG generate impostando i valori di scala o specificando la larghezza e l'altezza desiderate.

## **Converti PowerPoint in PNG**

Segui questi passaggi:

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Ottieni l'oggetto diapositiva dalla collezione [Presentation::get_Slides()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) tramite l'interfaccia [ISlide](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_slide).
3. Utilizza il metodo [ISlide::GetImage()](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/getimage) per ottenere la miniatura di ogni diapositiva.
4. Usa il metodo [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) per salvare la miniatura della diapositiva in formato PNG.

Questo codice C++ mostra come convertire una presentazione PowerPoint in PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **Converti PowerPoint in PNG con dimensioni personalizzate**

Se desideri ottenere file PNG a una certa scala, puoi impostare i valori di `desiredX` e `desiredY`, che determinano le dimensioni della miniatura risultante.

Questo codice in C++ dimostra l'operazione descritta:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **Converti PowerPoint in PNG con dimensione personalizzata**

Se desideri ottenere file PNG a una certa dimensione, puoi passare i valori di `width` e `height` desiderati per `ImageSize`.

Questo codice mostra come convertire un PowerPoint in PNG specificando la dimensione delle immagini:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **FAQ**

**Come posso esportare solo una forma specifica (ad esempio un grafico o un'immagine) anziché l'intera diapositiva?**

Aspose.Slides supporta la [generazione di miniature per forme individuali](/slides/it/cpp/create-shape-thumbnails/); è possibile rendere una forma in un'immagine PNG.

**La conversione parallela è supportata su un server?**

Sì, ma [non condividere](/slides/it/cpp/multithreading/) una singola istanza di presentazione tra i thread. Usa un'istanza separata per thread o processo.

**Quali sono le limitazioni della versione di prova durante l'esportazione in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e impone [altre restrizioni](/slides/it/cpp/licensing/) finché non viene applicata una licenza.