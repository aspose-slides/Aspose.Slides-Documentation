---
title: Ottieni i limiti delle porzioni di testo dalle presentazioni in C++
linktitle: Limiti della porzione
type: docs
weight: 47
url: /it/cpp/portion-bounds/
keywords:
- limiti della porzione di testo
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come recuperare i limiti delle porzioni di testo nelle presentazioni PowerPoint utilizzando Aspose.Slides per C++."
---
## **Panoramica**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare con quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare i limiti di un frammento di testo, applicare formattazione solo a parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

Questo articolo mostra come ottenere il rettangolo di delimitazione di una porzione utilizzando [IPortion::GetRect](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/getrect/). Mostra anche come ottenere le coordinate dell'inizio di una porzione usando [IPortion::GetCoordinates](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/getcoordinates/). Inoltre, evidenzia scenari comuni relativi alle porzioni, come l'applicazione di un collegamento ipertestuale a un singolo frammento di testo, la comprensione di come la formattazione viene risolta tramite ereditarietà di porzione, paragrafo, cornice di testo e tema, e la gestione dei casi in cui un carattere specificato non è disponibile.

## **Ottieni i limiti di una porzione di testo**

Utilizza [IPortion::GetRect](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/getrect/) per recuperare il rettangolo di delimitazione di una porzione di testo:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Ottieni le coordinate di una porzione di testo**

Utilizza [IPortion::GetCoordinates](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/getcoordinates/) per recuperare le coordinate dell'inizio di una porzione di testo:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all'interno di un singolo paragrafo?**

Sì, puoi [assegnare un collegamento ipertestuale](/slides/it/cpp/manage-hyperlinks/) a una porzione individuale; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà di stile: cosa sovrascrive una porzione e cosa viene preso da un paragrafo o da una cornice di testo?**

Le proprietà a livello di porzione hanno la precedenza più alta. Se una proprietà non è impostata su [IPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/), Aspose.Slides la prende da [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/). Se non è impostata neanche lì, Aspose.Slides utilizza lo stile di [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) o di [theme](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/theme/).

**Cosa succede se il carattere specificato per una porzione è mancante sulla macchina o sul server di destinazione?**

[Le regole di sostituzione dei caratteri](/slides/it/cpp/font-selection-sequence/) si applicano. Il testo potrebbe riformattarsi: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza o un gradiente di riempimento del testo a livello di porzione indipendentemente dal resto del paragrafo?**

Sì, il colore del testo, il riempimento e la trasparenza a livello di [IPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/) possono differire dai frammenti adiacenti.