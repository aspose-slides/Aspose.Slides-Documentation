---
title: Casella di testo
type: docs
weight: 40
url: /it/cpp/examples/elements/text-box/
keywords:
- esempio di codice
- casella di testo
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Lavora con le caselle di testo in Aspose.Slides per C++: aggiungi, formatta, allinea, avvolgi, adatta automaticamente e stile il testo usando C++ per presentazioni PPT, PPTX e ODP."
---
In Aspose.Slides, una **casella di testo** è rappresentata da un `AutoShape`. Quasi qualsiasi forma può contenere testo, ma una tipica casella di testo non ha riempimento né bordo e visualizza solo il testo.

Questa guida spiega come aggiungere, accedere e rimuovere le caselle di testo programmaticamente.

## **Aggiungere una casella di testo**

Una casella di testo è semplicemente un `AutoShape` senza riempimento né bordo e con del testo formattato. Ecco come crearne una:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Crea una forma rettangolare (predefinita riempita con bordo e senza testo).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Rimuovi riempimento e bordo per farla sembrare una tipica casella di testo.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Imposta la formattazione del testo.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Assegna il contenuto testuale effettivo.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Nota:** Qualsiasi `AutoShape` che contiene un `TextFrame` non vuoto può fungere da casella di testo.

## **Accedere alle caselle di testo per contenuto**

Per trovare tutte le caselle di testo contenenti una parola chiave specifica (ad esempio "Slide"), iterare tra le forme e controllare il loro testo:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Solo gli AutoShape possono contenere testo modificabile.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Esegui un'operazione sulla casella di testo corrispondente.
            }
        }
    }

    presentation->Dispose();
}
```

## **Rimuovere le caselle di testo per contenuto**

Questo esempio trova ed elimina tutte le caselle di testo nella prima diapositiva che contengono una parola chiave specifica:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Suggerimento:** Creare sempre una copia della collezione di forme prima di modificarla durante l'iterazione per evitare errori di modifica della collezione.