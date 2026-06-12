---
title: Gestire le Porzioni di Testo nelle Presentazioni con C++
linktitle: Porzione di Testo
type: docs
weight: 70
url: /it/cpp/portion/
keywords:
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come gestire le porzioni di testo nelle presentazioni PowerPoint utilizzando Aspose.Slides per C++, migliorando prestazioni e personalizzazione."
---
## **Introduzione**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare con quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare la posizione di un frammento di testo, applicare formattazione solo a una parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

## **Ottenere le coordinate di una porzione di testo**
Il metodo **GetCoordinates()** è stato aggiunto all'interfaccia IPortion e alla classe Portion, consentendo di recuperare le coordinate dell'inizio della porzione:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all'interno di un singolo paragrafo?**

Sì, è possibile [assegnare un collegamento ipertestuale](/slides/it/cpp/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà degli stili: cosa sovrascrive una Portion e cosa viene preso da Paragraph/TextFrame?**

Le proprietà a livello di Portion hanno la massima precedenza. Se una proprietà non è impostata sulla [Portion](https://reference.aspose.com/slides/it/cpp/aspose.slides/portion/), il motore la prende dalla [Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraph/); se non è impostata neppure lì, dalla [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframe/) o dallo stile del [theme](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/theme/).

**Cosa succede se il font specificato per una Portion è assente sulla macchina/server di destinazione?**

Si applicano le [regole di sostituzione dei font](/slides/it/cpp/font-selection-sequence/). Il testo può riformattarsi: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza o il gradiente di riempimento del testo specifici per una Portion indipendentemente dal resto del paragrafo?**

Sì, colore del testo, riempimento e trasparenza a livello di [Portion](https://reference.aspose.com/slides/it/cpp/aspose.slides/portion/) possono differire dai frammenti adiacenti.