---
title: Gestisci i collegamenti ipertestuali della presentazione in C++
linktitle: Gestisci collegamento ipertestuale
type: docs
weight: 20
url: /it/cpp/manage-hyperlinks/
keywords:
- aggiungi URL
- aggiungi collegamento ipertestuale
- crea collegamento ipertestuale
- formatta collegamento ipertestuale
- rimuovi collegamento ipertestuale
- aggiorna collegamento ipertestuale
- collegamento ipertestuale nel testo
- collegamento ipertestuale nella diapositiva
- collegamento ipertestuale nella forma
- collegamento ipertestuale nell'immagine
- collegamento ipertestuale video
- collegamento ipertestuale mutabile
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci senza sforzo i collegamenti ipertestuali nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per C++ — migliora l'interattività e il flusso di lavoro in pochi minuti."
---
## **Introduzione**

Un collegamento ipertestuale è un riferimento a un oggetto, dati o a una posizione in qualcosa. Questi sono collegamenti ipertestuali comuni nelle presentazioni PowerPoint:

* Collegamenti a siti web all'interno di testi, forme o media
* Collegamenti a diapositive

Aspose.Slides per C++ consente di eseguire molte operazioni relative ai collegamenti ipertestuali nelle presentazioni. 

{{% alert color="primary" %}} 
Potresti voler provare Aspose simple, [editor online gratuito di PowerPoint.](https://products.aspose.app/slides/it/editor)
{{% /alert %}} 

## **Aggiungi Collegamenti URL**

### **Aggiungi Collegamenti URL al Testo**

Questo codice C++ mostra come aggiungere un collegamento a un sito web a un testo:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Aggiungi Collegamenti URL a Forme o Riquadri**

Questo esempio di codice in C++ mostra come aggiungere un collegamento a un sito web a una forma:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **Aggiungi Collegamenti URL a Media**

Aspose.Slides consente di aggiungere collegamenti a immagini, file audio e video. 

Questo esempio di codice mostra come aggiungere un collegamento a un'**immagine**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// Aggiunge immagine alla presentazione
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Creates picture frame on slide 1 based on previously added image
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

Questo esempio di codice mostra come aggiungere un collegamento a un **file audio**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

Questo esempio di codice mostra come aggiungere un collegamento a un **video**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{% alert title="Consiglio" color="primary" %}} 
Potresti voler vedere *[Gestisci OLE](https://docs.aspose.com/slides/it/cpp/manage-ole/)*.
{{% /alert %}}

## **Usa i Collegamenti per Creare un Indice**

Poiché i collegamenti consentono di aggiungere riferimenti a oggetti o posizioni, è possibile usarli per creare un indice. 

Questo esempio di codice mostra come creare un indice con collegamenti ipertestuali:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```

## **Formatta i Collegamenti**

### **Colore**

Con i metodi [set_ColorSource()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) e [get_ColorSource()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) nell'interfaccia [IHyperlink](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_hyperlink) è possibile impostare il colore dei collegamenti e recuperare le informazioni sul colore. La funzionalità è stata introdotta per la prima volta in PowerPoint 2019, quindi le modifiche relative alla proprietà non si applicano alle versioni precedenti di PowerPoint.

Questo esempio di codice dimostra un'operazione in cui collegamenti con colori diversi vengono aggiunti alla stessa diapositiva:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

## **Rimuovi i Collegamenti dalle Presentazioni**

### **Rimuovi i Collegamenti dal Testo**

Questo codice C++ mostra come rimuovere il collegamento ipertestuale da un testo in una diapositiva della presentazione:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

### **Rimuovi i Collegamenti da Forme o Riquadri**

Questo codice C++ mostra come rimuovere il collegamento ipertestuale da una forma in una diapositiva della presentazione: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

## **Collegamento Ipertestuale Mutabile**

La classe [Hyperlink](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.hyperlink) è mutabile. Con questa classe, è possibile modificare i valori per questi metodi:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

Il frammento di codice mostra come aggiungere un collegamento a una diapositiva e modificare successivamente il tooltip:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **Metodi Supportati in IHyperlinkQueries**

È possibile accedere a IHyperlinkQueries da una presentazione, diapositiva o testo per cui è definito il collegamento. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

La classe IHyperlinkQueries supporta questi metodi: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **FAQ**

**Come posso creare una navigazione interna non solo a una diapositiva, ma a una "sezione" o alla prima diapositiva di una sezione?**

Le sezioni in PowerPoint raggruppano le diapositive; la navigazione tecnicamente punta a una diapositiva specifica. Per "navigare a una sezione", di solito si collega alla sua prima diapositiva.

**Posso allegare un collegamento ipertestuale agli elementi della diapositiva master in modo che funzioni su tutte le diapositive?**

Sì. Gli elementi del master e dei layout supportano i collegamenti ipertestuali. Tali collegamenti appaiono nelle diapositive figlie e sono cliccabili durante la presentazione.

**I collegamenti ipertestuali saranno conservati durante l'esportazione in PDF, HTML, immagini o video?**

In [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/) e [HTML](/slides/it/cpp/convert-powerpoint-to-html/), sì — i collegamenti sono generalmente mantenuti. Quando si esporta in [immagini](/slides/it/cpp/convert-powerpoint-to-png/) e [video](/slides/it/cpp/convert-powerpoint-to-video/), la cliccabilità non viene trasferita a causa della natura di quei formati (frame raster/video non supportano collegamenti).