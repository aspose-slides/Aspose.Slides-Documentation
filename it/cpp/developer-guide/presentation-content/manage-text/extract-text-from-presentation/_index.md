---
title: Estrazione avanzata del testo da presentazioni in C++
linktitle: Estrai testo
type: docs
weight: 90
url: /it/cpp/extract-text-from-presentation/
aliases:
  - /cpp/extracting-text-from-the-presentation/
keywords:
- estrarre testo
- estrarre testo da diapositiva
- estrarre testo da presentazione
- estrarre testo da PowerPoint
- estrarre testo da OpenDocument
- estrarre testo da PPT
- estrarre testo da PPTX
- estrarre testo da ODP
- recuperare testo
- recuperare testo da diapositiva
- recuperare testo da presentazione
- recuperare testo da PowerPoint
- recuperare testo da OpenDocument
- recuperare testo da PPT
- recuperare testo da PPTX
- recuperare testo da ODP
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Estrai rapidamente il testo da presentazioni PowerPoint e OpenDocument usando Aspose.Slides per C++. Segui la nostra semplice guida passo passo per risparmiare tempo."
---
## **Panoramica**

Estrarre il testo dalle presentazioni è un’attività comune ma fondamentale per gli sviluppatori che lavorano con contenuti diapositive. Che tu stia gestendo file Microsoft PowerPoint in formato PPT o PPTX, o presentazioni OpenDocument (ODP), accedere e recuperare i dati testuali può essere cruciale per analisi, automazione, indicizzazione o migrazione dei contenuti.

Questo articolo fornisce una guida completa su come estrarre in modo efficiente il testo da vari formati di presentazione, inclusi PPT, PPTX e ODP, utilizzando Aspose.Slides for C++. Imparerai a scorrere sistematicamente gli elementi della presentazione per recuperare con precisione il contenuto testuale di cui hai bisogno.

## **Estrai testo da una diapositiva**

Aspose.Slides for C++ fornisce lo spazio dei nomi [Aspose.Slides.Util](https://reference.aspose.com/slides/it/cpp/aspose.slides.util/) che include la classe [SlideUtil](https://reference.aspose.com/slides/it/cpp/aspose.slides.util/slideutil/). Questa classe espone diversi metodi statici sovraccaricati per estrarre tutto il testo da una presentazione o da una diapositiva. Per estrarre il testo da una diapositiva in una presentazione, utilizza il metodo [GetAllTextBoxes](https://reference.aspose.com/slides/it/cpp/aspose.slides.util/slideutil/getalltextboxes/). Questo metodo accetta come parametro un oggetto di tipo [IBaseSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslide/). Quando viene eseguito, il metodo esamina l’intera diapositiva alla ricerca di testo e restituisce un array di oggetti di tipo [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/), preservando la formattazione del testo.

Il frammento di codice seguente estrae tutto il testo dalla prima diapositiva della presentazione:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Estrai testo da una presentazione**

Per scansionare il testo dell’intera presentazione, utilizza il metodo statico [GetAllTextFrames](https://reference.aspose.com/slides/it/cpp/aspose.slides.util/slideutil/getalltextframes/) esposto dalla classe [SlideUtil](https://reference.aspose.com/slides/it/cpp/aspose.slides.util/slideutil/). Accetta due parametri:

1. In primo luogo, un oggetto [IPresentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/) che rappresenta una presentazione PowerPoint o OpenDocument da cui verrà estratto il testo.  
2. In secondo luogo, un valore `Boolean` che indica se includere le slide master durante la scansione del testo della presentazione.

Il metodo restituisce un array di oggetti di tipo [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/), includendo le informazioni di formattazione del testo. Il codice sottostante esamina il testo e i dettagli di formattazione da una presentazione, includendo le slide master.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Estrazione di testo categorizzata e veloce**

La classe [PresentationFactory](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentationfactory/) fornisce anche metodi per estrarre tutto il testo dalle presentazioni:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

L’argomento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/it/cpp/aspose.slides/textextractionarrangingmode/) indica la modalità di organizzazione del risultato dell’estrazione del testo e può essere impostato sui seguenti valori:
- `Unarranged` – Il testo grezzo senza considerare la sua posizione sulla diapositiva.  
- `Arranged` – Il testo è disposto nello stesso ordine in cui appare sulla diapositiva.

La modalità non ordinata può essere usata quando la velocità è critica; è più veloce della modalità ordinata.

[IPresentationText](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationtext/) rappresenta il testo grezzo estratto dalla presentazione. Il suo metodo `get_SlidesText()` restituisce un array di oggetti di tipo [ISlideText](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidetext/). Ogni oggetto rappresenta il testo della diapositiva corrispondente. L’oggetto di tipo [ISlideText](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidetext/) dispone dei seguenti metodi:

- `get_Text()` – Il testo all’interno delle forme della diapositiva.  
- `get_MasterText()` – Il testo all’interno delle forme della diapositiva master associate a questa diapositiva.  
- `get_LayoutText()` – Il testo all’interno delle forme della diapositiva layout associate a questa diapositiva.  
- `get_NotesText()` – Il testo all’interno delle forme della diapositiva note associate a questa diapositiva.  
- `get_CommentsText()` – Il testo all’interno dei commenti associati a questa diapositiva.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **FAQ**

**Quanto è veloce Aspose.Slides nell’elaborare presentazioni di grandi dimensioni durante l’estrazione del testo?**

Aspose.Slides è ottimizzato per alte prestazioni e può elaborare anche [presentazioni di grandi dimensioni](/slides/it/cpp/open-presentation/), rendendolo adatto a scenari di elaborazione in tempo reale o in batch.

**Aspose.Slides può estrarre testo da tabelle e grafici all’interno delle presentazioni?**

Sì. Aspose.Slides può estrarre testo da molti elementi della diapositiva, incluse tabelle e oggetti correlati a grafici, consentendoti di accedere e analizzare il contenuto testuale nelle strutture di presentazione più comuni.

**È necessaria una licenza speciale di Aspose.Slides per estrarre testo dalle presentazioni?**

Puoi estrarre testo usando la versione di prova gratuita di Aspose.Slides, sebbene presenti [alcune limitazioni](/slides/it/cpp/licensing/), come la possibilità di elaborare solo un numero limitato di diapositive. Per utilizzo illimitato e per gestire presentazioni di dimensioni maggiori, è consigliato acquistare una licenza completa.