---
title: Ottieni i limiti del paragrafo dalle presentazioni in C++
linktitle: Paragrafo
type: docs
weight: 60
url: /it/cpp/paragraph/
keywords:
- limiti del paragrafo
- limiti della porzione di testo
- coordinate del paragrafo
- coordinate della porzione
- dimensione del paragrafo
- dimensione della porzione di testo
- frame di testo
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come recuperare i limiti del paragrafo e della porzione di testo in Aspose.Slides per C++ per ottimizzare il posizionamento del testo nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, la dimensione e le coordinate di paragrafi e porzioni di testo in Aspose.Slides. Mostra come recuperare il rettangolo di un paragrafo in un `TextFrame` usando `GetRect()`, come ottenere le coordinate del paragrafo e della porzione all'interno di un frame di testo di una cella di tabella, e evidenzia dettagli importanti come unità di misura, l'effetto del ritorno a capo sui limiti, la conversione in pixel e i valori di formattazione effective del paragrafo.

## **Ottenere le coordinate di paragrafo e porzione in un TextFrame**
Con Aspose.Slides per C++, gli sviluppatori possono ora ottenere le coordinate rettangolari per il Paragraph all'interno della raccolta di paragrafi di TextFrame. Consente anche di ottenere le coordinate della Portion all'interno della raccolta di porzioni di un paragrafo. In questo argomento dimostreremo, con l'aiuto di un esempio, come ottenere le coordinate rettangolari per il paragrafo insieme alla posizione della porzione all'interno del paragrafo.

## **Ottenere le coordinate rettangolari di un paragrafo**
È stato aggiunto il nuovo metodo **GetRect()**. Consente di ottenere il rettangolo dei limiti del paragrafo.

``` cpp
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Ottenere la dimensione di un paragrafo e di una porzione all'interno di un TextFrame di cella di tabella**
Per ottenere la dimensione e le coordinate della [Portion](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.portion) o del [Paragraph](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.paragraph) in un frame di testo di una cella di tabella, è possibile utilizzare i metodi [IPortion::GetRect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) e [IParagraph::GetRect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

Questo codice di esempio dimostra l'operazione descritta:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **FAQ**

**In quali unità vengono restituite le coordinate di un paragrafo e delle porzioni di testo?**

In punti, dove 1 pollice = 72 punti. Questo vale per tutte le coordinate e le dimensioni della diapositiva.

**Il ritorno a capo influisce sui limiti di un paragrafo?**

Sì. Se il [wrapping](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframeformat/set_wraptext/) è abilitato nel [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframe/), il testo si interrompe per adattarsi alla larghezza dell'area, il che modifica i limiti effettivi del paragrafo.

**Le coordinate del paragrafo possono essere mappate in modo affidabile in pixel nell'immagine esportata?**

Sì. Converti i punti in pixel usando: pixel = punti × (DPI / 72). Il risultato dipende dal DPI scelto per il rendering/esportazione.

**Come ottenere i parametri di formattazione "effective" del paragrafo, tenendo conto dell'ereditarietà degli stili?**

Utilizza la [effective paragraph formatting data structure](/slides/it/cpp/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziature, avvolgimento, RTL e altro.