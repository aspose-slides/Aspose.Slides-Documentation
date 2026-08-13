---
title: Converti PPT e PPTX in JPG in .NET
linktitle: PowerPoint in JPG
type: docs
weight: 60
url: /it/net/convert-powerpoint-to-jpg/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in JPG
- presentazione in JPG
- diapositiva in JPG
- PPT in JPG
- PPTX in JPG
- salva PowerPoint come JPG
- salva presentazione come JPG
- salva diapositiva come JPG
- salva PPT come JPG
- salva PPTX come JPG
- esporta PPT in JPG
- esporta PPTX in JPG
- .NET
- C#
- Aspose.Slides
description: "Converti le diapositive PowerPoint (PPT, PPTX) in immagini JPG di alta qualità in C# con Aspose.Slides per .NET utilizzando esempi di codice veloci e affidabili."
---
## **Introduzione**

Convertire presentazioni PowerPoint e OpenDocument in immagini JPG aiuta a condividere le diapositive, ottimizzare le prestazioni e incorporare i contenuti in siti web o applicazioni. Aspose.Slides per .NET consente di trasformare i file PPTX, PPT e ODP in immagini JPEG ad alta qualità. Questa guida spiega i diversi metodi di conversione.

Con queste funzionalità è facile implementare il proprio visualizzatore di presentazioni e creare una miniatura per ogni diapositiva. Questo può essere utile se si desidera proteggere le diapositive dalla copia o dimostrare la presentazione in modalità sola lettura. Aspose.Slides permette di convertire l'intera presentazione o una diapositiva specifica in formati immagine.

## **Converti le diapositive della presentazione in immagini JPG**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottieni l'oggetto diapositiva di tipo [ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide) dalla collezione [Presentation.Slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/properties/slides).
1. Crea un'immagine della diapositiva usando il metodo [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/#getimage_5).
1. Chiama il metodo [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/save/#save_3) sull'oggetto immagine. Passa il nome del file di output e il formato immagine come argomenti.

{{% alert color="info" %}} 
**Nota:** La conversione da PPT, PPTX o ODP a JPG differisce dalla conversione ad altri formati nell'API Aspose.Slides .NET. Per altri formati, tipicamente si utilizza il metodo [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/save/#save_5). Tuttavia, per la conversione JPG è necessario usare il metodo [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/save/#save_3).
{{% /alert %}} 

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Crea un'immagine della diapositiva con la scala specificata.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Salva l'immagine su disco in formato JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Converti le diapositive in JPG con dimensioni personalizzate**

Per modificare le dimensioni delle immagini JPG risultanti, puoi impostare la dimensione dell'immagine passandola al metodo [ISlide.GetImage(Size)](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/#getimage_6). Questo consente di generare immagini con valori specifici di larghezza e altezza, garantendo che l'output soddisfi i requisiti di risoluzione e rapporto d'aspetto. Questa flessibilità è particolarmente utile quando si generano immagini per applicazioni web, report o documentazione, dove sono richieste dimensioni precise dell'immagine.

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Crea un'immagine della diapositiva con la dimensione specificata.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Salva l'immagine su disco in formato JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Renderizza i commenti durante il salvataggio delle diapositive come immagini**

Aspose.Slides per .NET fornisce una funzionalità che permette di renderizzare i commenti sulle diapositive di una presentazione quando le si converte in immagini JPG. Questa funzionalità è particolarmente utile per preservare annotazioni, feedback o discussioni aggiunte dai collaboratori in presentazioni PowerPoint. Abilitando questa opzione, i commenti saranno visibili nelle immagini generate, facilitando la revisione e la condivisione del feedback senza dover aprire il file originale della presentazione.

Supponiamo di avere un file di presentazione, "sample.pptx", con una diapositiva che contiene commenti:

![La diapositiva con commenti](slide_with_comments.png)

Il seguente codice C# converte la diapositiva in un'immagine JPG preservando i commenti:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Imposta le opzioni per i commenti delle diapositive.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // Converte la prima diapositiva in un'immagine.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

Il risultato:

![L'immagine JPG con commenti](image_with_comments.png)

## **Vedi anche**

Vedi altre opzioni per convertire PPT, PPTX o ODP in immagini, ad esempio:

- [Converti PowerPoint in GIF](/slides/it/net/convert-powerpoint-to-animated-gif/)
- [Converti PowerPoint in PNG](/slides/it/net/convert-powerpoint-to-png/)
- [Converti PowerPoint in TIFF](/slides/it/net/convert-powerpoint-to-tiff/)
- [Converti PowerPoint in SVG](/slides/it/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
Per vedere come Aspose.Slides converte PowerPoint in immagini JPG, prova questi convertitori online gratuiti: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/it/conversion/pptx-to-jpg) e [PPT to JPG](https://products.aspose.app/slides/it/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Convertitore online gratuito PPTX in JPG](ppt-to-jpg.png)

{{% alert title="Suggerimento" color="info" %}}

Aspose fornisce un'app web GRATUITA per collage ([FREE Collage web app](https://products.aspose.app/slides/it/collage)). Utilizzando questo servizio online, puoi unire immagini [JPG to JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG to PNG, creare [photo grids](https://products.aspose.app/slides/it/collage/photo-grid) e così via. 

Usando gli stessi principi descritti in questo articolo, puoi convertire immagini da un formato all'altro. Per ulteriori informazioni, consulta queste pagine: converti [image to JPG](https://products.aspose.com/slides/it/net/conversion/image-to-jpg/); converti [JPG to image](https://products.aspose.com/slides/it/net/conversion/jpg-to-image/); converti [JPG to PNG](https://products.aspose.com/slides/it/net/conversion/jpg-to-png/), converti [PNG to JPG](https://products.aspose.com/slides/it/net/conversion/png-to-jpg/); converti [PNG to SVG](https://products.aspose.com/slides/it/net/conversion/png-to-svg/), converti [SVG to PNG](https://products.aspose.com/slides/it/net/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

### Questo metodo supporta la conversione in batch?

Sì, Aspose.Slides consente la conversione batch di più diapositive in JPG in un'unica operazione.

### La conversione supporta SmartArt, grafici e altri oggetti complessi?

Sì, Aspose.Slides rende tutto il contenuto, inclusi SmartArt, grafici, tabelle, forme e altro ancora. Tuttavia, la precisione del rendering può variare leggermente rispetto a PowerPoint, soprattutto quando si utilizzano caratteri personalizzati o mancanti.

### Esistono limitazioni sul numero di diapositive che possono essere elaborate?

Aspose.Slides non impone limiti rigidi sul numero di diapositive che è possibile elaborare. Tuttavia, potresti incontrare errori di out‑of‑memory lavorando con presentazioni molto grandi o immagini ad alta risoluzione.