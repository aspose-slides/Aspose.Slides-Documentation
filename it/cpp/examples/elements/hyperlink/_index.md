---
title: Collegamento ipertestuale
type: docs
weight: 130
url: /it/cpp/examples/elements/hyperlink/
keywords:
- esempio di codice
- collegamento ipertestuale
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Aggiungi e gestisci i collegamenti ipertestuali in Aspose.Slides for C++: collega testo, forme e immagini, imposta destinazioni e azioni per PPT, PPTX e ODP con esempi in C++."
---
Questo articolo dimostra come aggiungere, accedere, rimuovere e aggiornare i collegamenti ipertestuali su forme utilizzando **Aspose.Slides for C++**.

## **Aggiungere un collegamento ipertestuale**
Crea una forma rettangolare con un collegamento ipertestuale che punta a un sito web esterno.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **Accedere a un collegamento ipertestuale**
Leggi le informazioni del collegamento ipertestuale dalla porzione di testo di una forma.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **Rimuovere un collegamento ipertestuale**
Rimuovi il collegamento ipertestuale dal testo di una forma.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **Aggiornare un collegamento ipertestuale**
Modifica la destinazione di un collegamento ipertestuale esistente. Usa `HyperlinkManager` per modificare il testo che contiene già un collegamento ipertestuale, simulando il modo in cui PowerPoint aggiorna i collegamenti ipertestuali in modo sicuro.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // Modificare un collegamento ipertestuale nel testo esistente dovrebbe essere fatto tramite
    // HyperlinkManager anziché impostare direttamente la proprietà.
    // Questo imita il modo in cui PowerPoint aggiorna in modo sicuro i collegamenti ipertestuali.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```