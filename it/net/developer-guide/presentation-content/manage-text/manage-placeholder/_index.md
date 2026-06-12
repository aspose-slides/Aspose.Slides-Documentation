---
title: Gestire i segnaposto delle presentazioni in .NET
linktitle: Gestisci segnaposto
type: docs
weight: 10
url: /it/net/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- testo di prompt
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci facilmente i segnaposto in Aspose.Slides per .NET: sostituisci testo, personalizza i prompt e imposta la trasparenza dell'immagine in PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di gestire i segnaposto delle presentazioni in modo programmatico. Questo articolo spiega come individuare i segnaposto nelle diapositive e modificare il loro testo, impostare testi di prompt personalizzati per i layout dei segnaposto e regolare la trasparenza di un’immagine usata come sfondo del segnaposto. Include anche una breve FAQ che chiarisce la differenza tra segnaposto di base e forme locali, spiega come le modifiche ai segnaposto possono essere applicate tramite layout o master, e indica la gestione dei segnaposto di intestazione e piè di pagina.

## **Modifica del testo in un segnaposto**
Utilizzando [Aspose.Slides for .NET](/slides/it/net/), è possibile trovare e modificare i segnaposto nelle diapositive di una presentazione. Aspose.Slides consente di apportare modifiche al testo di un segnaposto.

**Prerequisito**: è necessaria una presentazione che contenga un segnaposto. È possibile creare tale presentazione con l’applicazione standard Microsoft PowerPoint.

Ecco come utilizzare Aspose.Slides per sostituire il testo nel segnaposto di quella presentazione:

1. Istanziare la classe [`Presentation`](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) e passare la presentazione come argomento.  
2. Ottenere un riferimento alla diapositiva tramite il suo indice.  
3. Scorrere le forme per individuare il segnaposto.  
4. Eseguire il cast della forma del segnaposto a un [`AutoShape`](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) e modificare il testo utilizzando il [`TextFrame`](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) associato all'[`AutoShape`](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/).  
5. Salvare la presentazione modificata.

Questo codice C# mostra come modificare il testo in un segnaposto:

```c#
// Istanzia una classe Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Accede alla prima diapositiva
    ISlide sld = pres.Slides[0];

    // Scorre le forme per trovare il segnaposto
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Modifica il testo di ogni segnaposto
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // Salva la presentazione su disco
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Imposta il testo di prompt in un segnaposto**
I layout standard e predefiniti contengono testi di prompt per i segnaposto, ad esempio ***Click to add a title*** o ***Click to add a subtitle***. Con Aspose.Slides è possibile inserire i propri testi di prompt preferiti nei layout dei segnaposto.

Questo codice C# mostra come impostare il testo di prompt in un segnaposto:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Scorre la diapositiva
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint mostra "Fai clic per aggiungere titolo"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Aggiunge sottotitolo
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Imposta la trasparenza dell’immagine del segnaposto**

Aspose.Slides consente di impostare la trasparenza dell’immagine di sfondo in un segnaposto di testo. Regolando la trasparenza dell’immagine in quel riquadro, è possibile far risaltare il testo o l’immagine (a seconda dei colori del testo e dell’immagine).

Questo codice C# mostra come impostare la trasparenza per lo sfondo dell’immagine (all’interno di una forma):

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **FAQ**

**Cos’è un segnaposto di base e in che modo differisce da una forma locale su una diapositiva?**

Un segnaposto di base è la forma originale su un layout o un master da cui la forma della diapositiva eredita—tipo, posizione e parte della formattazione provengono da esso. Una forma locale è indipendente; se non esiste un segnaposto di base, l’ereditarietà non si applica.

**Come posso aggiornare tutti i titoli o le didascalie in una presentazione senza iterare su ogni diapositiva?**

Modificare il segnaposto corrispondente sul layout o sul master. Le diapositive basate su quei layout/master erediteranno automaticamente la modifica.

**Come gestisco i segnaposto standard di intestazione/piè di pagina—data e ora, numero diapositiva e testo del piè di pagina?**

Utilizzare i gestori HeaderFooter nello scopo appropriato (diapositive normali, layout, master, note/handout) per attivare o disattivare quei segnaposto e per impostarne il contenuto.