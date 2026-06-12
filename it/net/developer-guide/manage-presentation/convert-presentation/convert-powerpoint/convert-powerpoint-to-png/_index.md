---
title: Converti diapositive PowerPoint in PNG in .NET
linktitle: PowerPoint in PNG
type: docs
weight: 30
url: /it/net/convert-powerpoint-to-png/
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
- .NET
- C#
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in immagini PNG di alta qualità rapidamente con Aspose.Slides per .NET, garantendo risultati precisi e automatizzati."
---
## **Panoramica**

Questo articolo spiega come convertire presentazioni PowerPoint in immagini PNG utilizzando Aspose.Slides. Mostra come caricare file di presentazione in formati come PPT, PPTX e ODP, renderizzare le slide come immagini e salvare i risultati in formato PNG.

L'articolo dimostra inoltre come personalizzare le immagini PNG generate impostando valori di scala o specificando la larghezza e l'altezza desiderate.

## **Convertire PowerPoint in PNG**

Segui questi passaggi:

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Ottieni l'oggetto slide dalla collezione [Presentation.Slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/properties/slides) tramite l'interfaccia [ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide).
3. Utilizza il metodo [ISlide.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/) per ottenere la miniatura di ciascuna slide.
4. Utilizza il metodo [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/it/net/aspose.slides.ipresentation/save/methods/5) per salvare la miniatura della slide in formato PNG.

Questo codice C# mostra come convertire una presentazione PowerPoint in PNG. L'oggetto Presentation può caricare PPT, PPTX, ODP ecc., quindi ogni slide nell'oggetto Presentation viene convertita in formato PNG o in altri formati immagine.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Convertire PowerPoint in PNG con Dimensioni Personalizzate**

Se desideri ottenere file PNG a una certa scala, puoi impostare i valori per `desiredX` e `desiredY`, che determinano le dimensioni della miniatura risultante.

Questo codice in C# dimostra l'operazione descritta:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Convertire PowerPoint in PNG con Dimensione Personalizzata**

Se desideri ottenere file PNG a una certa dimensione, puoi passare i tuoi argomenti `width` e `height` preferiti per `imageSize`.

Questo codice mostra come convertire un PowerPoint in PNG specificando la dimensione delle immagini:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **FAQ**

**Come posso esportare solo una forma specifica (ad es. grafico o immagine) anziché l'intera slide?**

Aspose.Slides supporta la [generazione di miniature per forme individuali](/slides/it/net/create-shape-thumbnails/); puoi renderizzare una forma in un'immagine PNG.

**La conversione parallela è supportata su un server?**

Sì, ma [non condividere](/slides/it/net/multithreading/) un'unica istanza di presentation tra thread. Utilizza un'istanza separata per thread o per processo.

**Quali sono le limitazioni della versione di prova durante l'esportazione in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica [altre restrizioni](/slides/it/net/licensing/) finché non viene applicata una licenza.