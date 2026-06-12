---
title: Diapositiva master
type: docs
weight: 30
url: /it/cpp/examples/elements/master-slide/
keywords:
- esempio di codice
- diapositiva master
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Esplora esempi di diapositive master di Aspose.Slides per C++: crea, modifica e formatta master, segnaposto e temi in PPT, PPTX e ODP con codice C++ chiaro."
---
Le diapositive master costituiscono il livello superiore della gerarchia di ereditarietà delle diapositive in PowerPoint. Una **diapositiva master** definisce elementi di design comuni come sfondi, loghi e formattazione del testo. Le **diapositive layout** ereditano dalle diapositive master, e le **diapositive normali** ereditano dalle diapositive layout.

Questo articolo dimostra come creare, modificare e gestire le diapositive master usando Aspose.Slides for C++.

## **Aggiungere una diapositiva master**

Questo esempio mostra come creare una nuova diapositiva master clonando quella predefinita. Successivamente aggiunge un banner con il nome dell'azienda a tutte le diapositive tramite l'ereditarietà del layout.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Clona la diapositiva master predefinita.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Aggiungi un banner con il nome dell'azienda nella parte superiore della diapositiva master.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Assegna la nuova diapositiva master a una diapositiva layout.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Assegna la diapositiva layout alla prima diapositiva della presentazione.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Nota 1:** Le diapositive master forniscono un modo per applicare un branding coerente o elementi di design condivisi a tutte le diapositive. Qualsiasi modifica apportata al master si riflette automaticamente sulle diapositive layout e sulle diapositive normali dipendenti.

> 💡 **Nota 2:** Qualsiasi forma o formattazione aggiunta a una diapositiva master viene ereditata dalle diapositive layout e, a loro volta, da tutte le diapositive normali che utilizzano tali layout.  
> L'immagine seguente illustra come una casella di testo aggiunta su una diapositiva master venga resa automaticamente sulla diapositiva finale.

![Esempio di ereditarietà del master](master-slide-banner.png)

## **Accedere a una diapositiva master**

È possibile accedere alle diapositive master tramite la collezione master della presentazione. Ecco come recuperarle e lavorare con esse:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Modifica il tipo di sfondo.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Rimuovere una diapositiva master**

Le diapositive master possono essere rimosse sia per indice che per riferimento.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Rimuovi una diapositiva master per indice.
    presentation->get_Masters()->RemoveAt(0);

    // Rimuovi una diapositiva master per riferimento.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Rimuovere le diapositive master inutilizzate**

Alcune presentazioni contengono diapositive master che non sono in uso. Rimuovere queste diapositive può contribuire a ridurre le dimensioni del file.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Rimuovi tutte le diapositive master inutilizzate (anche quelle contrassegnate come Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```