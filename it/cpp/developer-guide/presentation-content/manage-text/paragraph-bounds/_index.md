---
title: Ottieni i limiti dei paragrafi dalle presentazioni in C++
linktitle: Limiti dei paragrafi
type: docs
weight: 43
url: /it/cpp/paragraph-bounds/
keywords:
- limiti del paragrafo
- coordinata del paragrafo
- dimensione del paragrafo
- frame di testo
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Impara come recuperare i limiti dei paragrafi in Aspose.Slides per C++ per ottimizzare il posizionamento del testo nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, la dimensione e le coordinate dei paragrafi in Aspose.Slides. Mostra come recuperare un rettangolo di un paragrafo da un [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) usando [IParagraph::GetRect](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getrect/), come ottenere le coordinate del paragrafo all'interno del frame di testo di una cella di tabella e mette in evidenza dettagli importanti come le unità di misura, l'effetto dell'andare a capo del testo sui limiti, la conversione in pixel e i valori di formattazione del paragrafo effettivi.

## **Ottenere le coordinate rettangolari di un paragrafo**

Usa [IParagraph::GetRect](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getrect/) per ottenere il rettangolo di delimitazione di un paragrafo.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Ottenere la dimensione di un paragrafo all'interno di un TextFrame di cella di tabella**

Per ottenere la dimensione e le coordinate di un [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/) in un TextFrame di cella di tabella, usa [IParagraph::GetRect](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getrect/). Il rettangolo restituito è relativo al TextFrame della cella di tabella, quindi aggiungi la posizione della tabella e l'offset della cella quando ti servono coordinate a livello di diapositiva.

L'esempio seguente ottiene i limiti del paragrafo all'interno di una cella di tabella e disegna rettangoli sulla diapositiva per visualizzare tali limiti:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**In quali unità vengono misurate le coordinate dei paragrafi?**

Sono misurate in punti, dove 1 pollice equivale a 72 punti. Questo vale per tutte le coordinate e le dimensioni nella diapositiva.

**L'andare a capo del testo influisce sui limiti di un paragrafo?**

Sì. Se [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/set_wraptext/) è abilitato per il [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/), il testo si interrompe per adattarsi alla larghezza dell'area, modificando i limiti effettivi del paragrafo.

**Le coordinate del paragrafo possono essere mappate in modo affidabile ai pixel nell'immagine esportata?**

Sì. Converti i punti in pixel usando questa formula: pixel = punti x (DPI / 72). Il risultato dipende dal DPI scelto per il rendering o l'esportazione.

**Come ottenere i parametri di formattazione "effettivi" del paragrafo, tenendo conto dell'ereditarietà degli stili?**

Usa la [effective paragraph formatting data structure](/slides/it/cpp/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziatura, avvolgimento, RTL e altro.