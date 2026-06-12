---
title: Applica o Modifica Layout di Diapositive in C++
linktitle: Layout Diapositiva
type: docs
weight: 60
url: /it/cpp/slide-layout/
keywords:
- layout diapositiva
- layout contenuto
- segnaposto
- design della presentazione
- design della diapositiva
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
description: "Gestisci e personalizza i layout diapositive in Aspose.Slides per C++. Esplora i tipi di layout, il controllo dei segnaposto e la visibilità del piè di pagina attraverso esempi di codice C++."
---
## **Introduzione**

Un layout di diapositiva definisce la disposizione delle caselle segnaposto e la formattazione del contenuto su una diapositiva. Controlla quali segnaposto sono disponibili e dove appaiono. I layout diapositive ti aiutano a progettare presentazioni rapidamente e in modo coerente, sia che tu stia creando qualcosa di semplice oppure più complesso. Alcuni dei layout diapositive più comuni in PowerPoint includono:

**Layout diapositiva titolo** – Include due segnaposto di testo: uno per il titolo e uno per il sottotitolo.

**Layout Titolo e Contenuto** – Presenta un segnaposto titolo più piccolo in alto e uno più grande sotto per il contenuto principale (come testo, elenchi puntati, grafici, immagini e altro).

**Layout vuoto** – Non contiene segnaposto, consentendoti di avere il pieno controllo per progettare la diapositiva da zero.

I layout diapositive fanno parte di un master diapositive, che è la diapositiva di livello superiore che definisce gli stili di layout per la presentazione. Puoi accedere e modificare i layout diapositive tramite il master diapositive—sia per tipo, nome o ID univoco. In alternativa, puoi modificare un layout diapositive specifico direttamente nella presentazione.

Per lavorare con i layout diapositive in Aspose.Slides per Android, puoi utilizzare:

- Metodi come [get_LayoutSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_layoutslides/) e [get_Masters](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_masters/) nella classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
- Tipi come [ILayoutSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/), e [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Per saperne di più sul lavoro con i master diapositive, consulta l'articolo [Slide Master](/slides/it/cpp/slide-master/).
{{% /alert %}}

## **Aggiungere layout diapositive alle presentazioni**

Per personalizzare l'aspetto e la struttura delle tue diapositive, potresti dover aggiungere nuovi layout diapositive a una presentazione. Aspose.Slides per Android ti consente di verificare se un layout specifico esiste già, aggiungerne uno nuovo se necessario e usarlo per inserire diapositive basate su quel layout.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Accedi a [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Verifica se il layout di diapositiva desiderato esiste già nella raccolta. In caso contrario, aggiungi il layout di diapositiva necessario.
1. Aggiungi una diapositiva vuota basata sul nuovo layout di diapositiva.
1. Salva la presentazione.

Il seguente codice C++ dimostra come aggiungere un layout di diapositiva a una presentazione PowerPoint:

```cpp
// Instanzia la classe Presentation che rappresenta un file PowerPoint.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Scorri i tipi di layout di diapositiva per selezionare un layout di diapositiva.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Una situazione in cui la presentazione non contiene tutti i tipi di layout.
    // Il file di presentazione contiene solo i tipi di layout Blank e Custom.
    // Tuttavia, i layout diapositive con tipi personalizzati possono avere nomi riconoscibili,
    // come "Title", "Title and Content", ecc., che possono essere usati per la selezione del layout di diapositiva.
    // Puoi anche basarti su un insieme di tipi di forme segnaposto.
    // Ad esempio, una diapositiva Titolo dovrebbe avere solo il tipo di segnaposto Title, e così via.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Aggiungi una diapositiva vuota usando il layout di diapositiva aggiunto.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Salva la presentazione su disco.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Rimuovere layout diapositive inutilizzati**

Aspose.Slides fornisce il metodo [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) della classe [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/) per consentire di eliminare i layout diapositive indesiderati e non utilizzati.

Il seguente codice C++ mostra come rimuovere un layout di diapositiva da una presentazione PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Aggiungere segnaposto ai layout diapositive**

Aspose.Slides fornisce il metodo [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) che consente di aggiungere nuovi segnaposto a un layout di diapositiva.

Questo gestore contiene metodi per i seguenti tipi di segnaposto:

| Segnaposto PowerPoint              | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutplaceholdermanager/) Metodo |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Contenuto](content.png)           | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Contenuto (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Testo](text.png)                  | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Testo (Vertical)](textV.png)      | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Immagine](picture.png)            | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Grafico](chart.png)               | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tabella](table.png)               | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Immagine online](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Il seguente codice C++ dimostra come aggiungere nuove forme segnaposto al layout vuoto:

```cpp
auto presentation = MakeObject<Presentation>();

// Ottieni il layout Blank.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Ottieni il gestore dei segnaposto del layout diapositiva.
auto placeholderManager = layout->get_PlaceholderManager();

// Add different placeholders to the Blank layout slide.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Add a new slide with the Blank layout.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![I segnaposto sul layout di diapositiva](add_placeholders.png)

## **Impostare la visibilità del piè di pagina per un layout di diapositiva**

In PowerPoint, gli elementi del piè di pagina come data, numero diapositiva e testo personalizzato possono essere mostrati o nascosti a seconda del layout della diapositiva. Aspose.Slides per Android ti permette di controllare la visibilità di questi segnaposto del piè di pagina. È utile quando vuoi che alcuni layout mostrino le informazioni del piè di pagina mentre altri rimangano puliti e minimalisti.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni un riferimento al layout di diapositiva tramite il suo indice.
1. Imposta il segnaposto del piè di pagina della diapositiva su visibile.
1. Imposta il segnaposto del numero di diapositiva su visibile.
1. Imposta il segnaposto della data e ora su visibile.
1. Salva la presentazione.

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **Impostare la visibilità del piè di pagina figlio per una diapositiva**

In PowerPoint, gli elementi del piè di pagina come data, numero diapositiva e testo personalizzato possono essere controllati a livello di master slide per garantire coerenza su tutti i layout diapositive. Aspose.Slides per Android consente di impostare la visibilità e il contenuto di questi segnaposto del piè di pagina sul master slide e di propagare tali impostazioni a tutti i layout diapositive figli. Questo approccio assicura informazioni uniformi sul piè di pagina in tutta la presentazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni un riferimento al master slide tramite il suo indice.
1. Imposta i segnaposto del piè di pagina del master e di tutti i layout figli su visibili.
1. Imposta i segnaposto del numero di diapositiva del master e di tutti i layout figli su visibili.
1. Imposta i segnaposto della data e ora del master e di tutti i layout figli su visibili.
1. Salva la presentazione.

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Qual è la differenza tra un master slide e un layout slide?**

Un master slide definisce il tema generale e la formattazione predefinita, mentre i layout slide definiscono disposizioni specifiche di segnaposto per diversi tipi di contenuto.

**Posso copiare un layout slide da una presentazione all'altra?**

Sì, è possibile clonare un layout slide dalla raccolta dei layout slide di una presentazione, accessibile tramite il metodo [get_LayoutSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_layoutslides/), e inserirlo in un'altra presentazione usando il metodo `AddClone`.

**Cosa succede se elimino un layout slide che è ancora utilizzato da una diapositiva?**

Se tenti di eliminare un layout slide ancora referenziato da almeno una diapositiva nella presentazione, Aspose.Slides lancerà una [PptxEditException](https://reference.aspose.com/slides/it/cpp/aspose.slides/pptxeditexception/). Per evitare ciò, utilizza [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) che rimuove in modo sicuro solo i layout slide non in uso.