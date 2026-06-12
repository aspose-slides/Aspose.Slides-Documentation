---
title: Applica o modifica layout diapositive in .NET
linktitle: Layout diapositive
type: docs
weight: 60
url: /it/net/slide-layout/
keywords:
- layout diapositive
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
- C#
- .NET
- Aspose.Slides
description: "Gestisci e personalizza i layout diapositive in Aspose.Slides per .NET. Esplora i tipi di layout, il controllo dei segnaposto e la visibilità del piè di pagina tramite esempi di codice C#."
---
## **Introduzione**

Un layout di diapositiva definisce la disposizione delle caselle segnaposto e la formattazione del contenuto su una diapositiva. Controlla quali segnaposto sono disponibili e dove appaiono. I layout di diapositiva ti aiutano a progettare presentazioni rapidamente e in modo coerente—sia che tu stia creando qualcosa di semplice o più complesso. Alcuni dei layout di diapositiva più comuni in PowerPoint includono:

**Layout Titolo** – Include due segnaposto di testo: uno per il titolo e uno per il sottotitolo.

**Layout Titolo e Contenuto** – Presenta un segnaposto per il titolo più piccolo nella parte superiore e uno più grande sotto per il contenuto principale (come testo, elenchi puntati, grafici, immagini e altro).

**Layout Vuoto** – Non contiene segnaposto, offrendoti il pieno controllo per progettare la diapositiva da zero.

I layout di diapositiva fanno parte di un master di diapositiva, che è la diapositiva di livello superiore che definisce gli stili di layout per la presentazione. Puoi accedere e modificare i layout di diapositiva tramite il master di diapositiva—sia per tipo, nome o ID univoco. In alternativa, puoi modificare un layout di diapositiva specifico direttamente all'interno della presentazione.

Per lavorare con i layout di diapositiva in Aspose.Slides per .NET, è possibile utilizzare:

- Proprietà come [LayoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/layoutslides/) e [Masters](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/masters/) nella classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/)
- Tipi come [ILayoutSlide](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutplaceholdermanager/) e [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Per saperne di più su come lavorare con i master di diapositiva, consulta l'articolo [Slide Master](/slides/it/net/slide-master/).
{{% /alert %}}

## **Aggiungere layout di diapositiva alle presentazioni**

Per personalizzare l'aspetto e la struttura delle tue diapositive, potresti dover aggiungere nuovi layout di diapositiva a una presentazione. Aspose.Slides per .NET consente di verificare se un layout specifico esiste già, aggiungerne uno nuovo se necessario e usarlo per inserire diapositive basate su quel layout.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Accedi alla [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/imasterlayoutslidecollection/).
1. Verifica se il layout di diapositiva desiderato esiste già nella collezione. In caso contrario, aggiungi il layout di diapositiva necessario.
1. Aggiungi una diapositiva vuota basata sul nuovo layout di diapositiva.
1. Salva la presentazione.

Il seguente codice C# dimostra come aggiungere un layout di diapositiva a una presentazione PowerPoint:

```cs
// Istanzia la classe Presentation che rappresenta un file PowerPoint.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Scorri i tipi di layout diapositive per selezionare un layout di diapositiva.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Una situazione in cui la presentazione non contiene tutti i tipi di layout.
        // Il file della presentazione contiene solo i tipi di layout Blank e Custom.
        // Tuttavia, i layout diapositive con tipi personalizzati possono avere nomi riconoscibili,
        // come "Title", "Title and Content", ecc., che possono essere usati per la selezione del layout di diapositiva.
        // Puoi anche fare affidamento su un insieme di tipi di forma segnaposto.
        // Ad esempio, una diapositiva Title dovrebbe contenere solo il tipo di segnaposto Title, e così via.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Aggiungi una diapositiva vuota usando il layout di diapositiva aggiunto.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Salva la presentazione su disco.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Rimuovere i layout di diapositiva non utilizzati**

Aspose.Slides fornisce il metodo [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) della classe [Compress](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/) per consentirti di eliminare i layout di diapositiva indesiderati e non utilizzati.

Il seguente codice C# mostra come rimuovere un layout di diapositiva da una presentazione PowerPoint:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Aggiungere segnaposto ai layout di diapositiva**

Aspose.Slides fornisce la proprietà [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/placeholdermanager/), che consente di aggiungere nuovi segnaposto a un layout di diapositiva.

Questo gestore contiene metodi per i seguenti tipi di segnaposto:

| Segnaposto PowerPoint | Metodo [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutplaceholdermanager/) |
| ---------------------- | ----------------------------------------------------------------------------------------------------------- |
| ![Contenuto](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Contenuto (Verticale)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Testo](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Testo (Verticale)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Immagine](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Grafico](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tabella](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Immagine online](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Il seguente codice C# dimostra come aggiungere nuove forme segnaposto al layout Vuoto:

```cs
using (var presentation = new Presentation())
{
    // Ottieni il layout Blank.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Ottieni il gestore dei segnaposto del layout slide.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Aggiungi diversi segnaposto al layout Blank.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Aggiungi una nuova diapositiva con il layout Blank.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![The placeholders on the layout slide](add_placeholders.png)

## **Impostare la visibilità del piè di pagina per un layout di diapositiva**

Nelle presentazioni PowerPoint, gli elementi del piè di pagina come data, numero della diapositiva e testo personalizzato possono essere mostrati o nascosti a seconda del layout di diapositiva. Aspose.Slides per .NET ti consente di controllare la visibilità di questi segnaposto del piè di pagina. Questo è utile quando desideri che alcuni layout mostrino le informazioni del piè di pagina mentre altri rimangano puliti e minimi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento al layout di diapositiva tramite il suo indice.
1. Imposta il segnaposto del piè di pagina della diapositiva su visibile.
1. Imposta il segnaposto del numero della diapositiva su visibile.
1. Imposta il segnaposto della data/ora su visibile.
1. Salva la presentazione.

Il seguente codice C# mostra come impostare la visibilità del piè di pagina di una diapositiva ed eseguire le attività correlate:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **Impostare la visibilità del piè di pagina per i layout figlio di una diapositiva**

​Nelle presentazioni PowerPoint, gli elementi del piè di pagina come data, numero della diapositiva e testo personalizzato possono essere controllati a livello del master di diapositiva per garantire la coerenza su tutti i layout di diapositiva. Aspose.Slides per .NET consente di impostare la visibilità e il contenuto di questi segnaposto del piè di pagina sul master di diapositiva e di propagare queste impostazioni a tutti i layout figlio. Questo approccio garantisce informazioni uniformi nel piè di pagina in tutta la presentazione.​

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento al master di diapositiva tramite il suo indice.
1. Imposta tutti i segnaposto del piè di pagina del master e dei layout figlio su visibili.
1. Imposta tutti i segnaposto del numero della diapositiva del master e dei layout figlio su visibili.
1. Imposta tutti i segnaposto della data/ora del master e dei layout figlio su visibili.
1. Salva la presentazione.

Il seguente codice C# dimostra questa operazione:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Qual è la differenza tra un master slide e un layout slide?**

Un master slide definisce il tema generale e la formattazione predefinita, mentre i layout slide definiscono disposizioni specifiche di segnaposto per diversi tipi di contenuto.

**Posso copiare un layout slide da una presentazione all'altra?**

Sì, puoi clonare un layout slide dalla collezione [LayoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/layoutslides/) di una presentazione e inserirlo in un'altra usando il metodo `AddClone`.

**Cosa succede se elimino un layout slide che è ancora utilizzato da una diapositiva?**

Se provi a eliminare un layout slide che è ancora referenziato da almeno una diapositiva nella presentazione, Aspose.Slides genererà un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxeditexception/). Per evitare ciò, utilizza [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) che rimuove in sicurezza solo i layout slide non in uso.