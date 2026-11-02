---
title: Gestisci i collegamenti ipertestuali della presentazione in C++
linktitle: Gestisci i collegamenti ipertestuali
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
- collegamento ipertestuale di testo
- collegamento ipertestuale di diapositiva
- collegamento ipertestuale di forma
- collegamento ipertestuale di immagine
- collegamento ipertestuale video
- collegamento ipertestuale modificabile
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Aggiungi, formatta, aggiorna e rimuovi collegamenti ipertestuali nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per C++, utilizzando esempi in C++."
---
## **Introduzione**

Un collegamento ipertestuale collega il contenuto della presentazione a un sito web o a una posizione all'interno della presentazione. In PowerPoint, i collegamenti ipertestuali servono comunemente a due scopi:

* Aprire un sito web da un testo, una forma o un riquadro multimediale.
* Passare a un'altra diapositiva, ad esempio da un indice.

Aspose.Slides per C++ consente di aggiungere questi collegamenti, controllarne l'aspetto e il suono, aggiornare le impostazioni e rimuoverli. Gli esempi seguenti mostrano come lavorare con i collegamenti ipertestuali su singoli elementi e come accedere ai collegamenti ipertestuali a livello di presentazione, diapositiva o riquadro di testo.

{{% alert color="info" title="Note" %}}
È possibile anche modificare le presentazioni con il [gratuito editor online di Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Aggiungere collegamenti URL**

È possibile assegnare l'URL di un sito web a un testo, a una forma o a un riquadro multimediale. L'elemento a cui si assegna il collegamento ipertestuale determina l'area cliccabile: una porzione di testo collega il testo selezionato, mentre una forma o un riquadro collega l'oggetto della diapositiva.

Per presentazioni che contengono collegamenti ipertestuali relativi, vedere [Gestisci la base dei collegamenti ipertestuali](/slides/it/cpp/presentation-properties/#manage-the-hyperlink-base) per leggere, modificare o cancellare la base a livello di documento.

### **Aggiungere collegamenti URL al testo**

Per collegare il testo a un sito web, creare un [Hyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlink/) e assegnarlo tramite il metodo [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/set_hyperlinkclick/) della porzione di testo, come mostrato di seguito. Solo quella porzione di testo diventa cliccabile.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Aggiungere collegamenti URL a forme e riquadri multimediali**

Per rendere cliccabile una forma o un riquadro, utilizzare il suo metodo [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_hyperlinkclick/). Il collegamento ipertestuale appartiene all'oggetto stesso anziché a una porzione di testo al suo interno.

Lo stesso approccio si applica a riquadri di immagine, audio e video: assegnare il collegamento ipertestuale al riquadro e utilizzare [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) per aggiungere un suggerimento, se necessario.

L'esempio seguente rende cliccabile un rettangolo:

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **Usare i collegamenti ipertestuali per creare un indice**

I collegamenti ipertestuali interni consentono ai lettori di passare da un indice a una diapositiva specifica. L'esempio seguente utilizza [SetInternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) per collegare il testo “Page 2” nella prima diapositiva alla seconda diapositiva.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **Formattare i collegamenti ipertestuali**

### **Colore**

Il metodo [set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/) di [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) determina se un collegamento ipertestuale utilizza il colore dei collegamenti della presentazione o la formattazione della porzione di testo. Per applicare un colore di testo personalizzato, selezionare [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkcolorsource/) e impostare il colore di riempimento della porzione. Questa funzionalità è stata introdotta in PowerPoint 2019; le versioni precedenti non applicano questa impostazione.

L'esempio seguente aggiunge due collegamenti ipertestuali di testo alla stessa diapositiva. Il primo utilizza un riempimento di testo rosso, mentre il secondo mantiene il colore predefinito del collegamento ipertestuale.

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

### **Suono**

Un collegamento ipertestuale può riprodurre un suono quando attivato o fermare un suono già in riproduzione. Utilizzare i seguenti metodi per configurare questi comportamenti:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) specifica l'audio associato al collegamento ipertestuale.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) controlla se l'attivazione del collegamento ipertestuale interrompe il suono precedente.

#### **Aggiungere un suono al collegamento ipertestuale**

L'esempio seguente carica `sampleaudio.wav` e lo associa a un pulsante nella prima diapositiva. Cliccando il pulsante il suono viene riprodotto e si passa alla diapositiva successiva. Una seconda forma su quella diapositiva interrompe il suono precedente quando viene cliccata, senza eseguire un'azione di navigazione.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **Estrarre un suono dal collegamento ipertestuale**

L'esempio seguente apre la presentazione creata sopra e legge l'audio del collegamento ipertestuale della prima forma in memoria tramite [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_sound/) e [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/).

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **Tooltip e impostazioni di interazione**

È possibile aggiornare le seguenti impostazioni di [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) tramite questi metodi dopo aver assegnato un collegamento ipertestuale a testo o forma:

- [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) imposta il testo che un visualizzatore può visualizzare come suggerimento per il collegamento.
- [set_TargetFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_targetframe/) specifica il frame di destinazione all'interno di un frameset HTML genitore, se applicabile.
- [set_History](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_history/) controlla se l'attivazione del collegamento aggiunge la destinazione all'elenco dei collegamenti ipertestuali visualizzati.
- [set_HighlightClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_highlightclick/) controlla se il collegamento ipertestuale è evidenziato quando viene cliccato.

## **Rimuovere i collegamenti ipertestuali dalle presentazioni**

Utilizzare [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) per raccogliere i contenitori di collegamenti ipertestuali, inclusi i collegamenti a porzioni di testo, prima di modificarli. L'esempio seguente rimuove entrambi i tipi di attivazione dalla prima diapositiva. Per rimuovere solo un tipo, chiamare solo [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) o [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); rimuovere un'azione di clic non rimuove la sua controparte al passaggio del mouse.

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

Per una rimozione incondizionata, [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) rimuove entrambi i tipi di attivazione nell'ambito selezionato con una singola chiamata. Per una pulizia selettiva e la copertura di master, layout e note, vedere [Report, Sanitize e Verifica i collegamenti ipertestuali](#report-sanitize-and-verify-hyperlinks).

## **Creare un inventario completo dei collegamenti ipertestuali**

Prima di distribuire una presentazione, è necessario inventariare le sue azioni interattive così come i suoi collegamenti web. [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) restituisce oggetti [IHyperlinkContainer](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/), non un elenco piatto di stringhe URL. Ispezionare sia [get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) sia [get_HyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) su ogni contenitore. Sono indipendenti: lo stesso contenitore può esporre entrambe le azioni, quindi un report completo richiede fino a due righe per contenitore.

Scansionare solo i collegamenti ipertestuali a livello di forma può far perdere i collegamenti allegati a porzioni di testo. Interrogare invece l'ambito appropriato e conservare i contenitori restituiti in modo da poter successivamente aggiornare o rimuovere le loro azioni.

### **Interrogare gli ambiti di presentazione, diapositiva e riquadro di testo**

[IHyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/) interfaccia è disponibile tramite [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) e [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). Ogni ambito supporta le stesse query:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) restituisce i contenitori con un'azione di clic.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) restituisce i contenitori con un'azione al passaggio del mouse.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) restituisce i contenitori con una o entrambe le azioni.

L'esempio seguente crea `hyperlink-audit-input.pptx` con un collegamento di clic esterno, un collegamento di passaggio del mouse a file, una navigazione interna della diapositiva, un collegamento di testo al passaggio del mouse e un'azione macro. Non esegue nessuna di queste azioni. Le stesse tre query funzionano in ogni ambito; i conteggi descrivono i contenitori, non il totale delle azioni. L'ambito del riquadro di testo esclude i collegamenti della forma che lo contiene.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

Per questo esempio, le query di presentazione e diapositiva riportano ciascuna tre contenitori di clic, due contenitori di passaggio del mouse e tre contenitori con una delle due azioni. La query del riquadro di testo riporta un contenitore in ciascuna categoria.

### **Classificare azioni e destinazioni**

Utilizzare [IHyperlink::get_ActionType](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_actiontype/) per interpretare un'azione prima di interpretare la sua destinazione. I valori di [HyperlinkActionType](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkactiontype/) coprono più della semplice navigazione web:

| Valori | Significato per un audit |
| --- | --- |
| `Hyperlink` | Collegamento ipertestuale esterno; controllare l'URL e il suo schema. |
| `JumpSpecificSlide` | Navigazione interna a una diapositiva specifica. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigazione integrata della presentazione, risolta nel contesto della presentazione. |
| `JumpEndShow`, `StartCustomSlideShow` | Termina lo spettacolo corrente o avvia uno spettacolo personalizzato. |
| `StartMacro` | Esegue una macro. |
| `StartProgram` | Avvia un programma. |
| `OpenFile`, `OpenPresentation` | Apre un file o un'altra presentazione; revisionare separatamente dagli URL web. |
| `StartStopMedia` | Avvia o interrompe la riproduzione multimediale. |
| `NoAction`, `Unknown` | Nessuna azione di navigazione, o un'azione non riconosciuta che richiede revisione. |

Leggere le destinazioni esterne da [get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) e le destinazioni interne specifiche da [get_TargetSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_targetslide/). Le azioni interne e i comandi integrati possono non avere un URL esterno; un URL vuoto non significa che il contenitore non abbia alcuna azione. Conservare [get_ExternalUrlOriginal](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) quando differisce dall'URL normalizzato, e includere il tooltip restituito da [get_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_tooltip/) quando disponibile.

### **Report, Sanitize e Verifica dei collegamenti ipertestuali**

L'esempio C++ seguente legge una presentazione esistente (utilizzare il file creato sopra), scrive `hyperlink-audit.json`, applica una politica, salva `hyperlink-sanitized.pptx` e lo riapre per controllare nuovamente entrambi i tipi di attivazione. Raccoglie i contenitori prima di modificarli e utilizza l'identità dei puntatori per evitare di elaborare lo stesso contenitore due volte. Le query di presentazione coprono le diapositive ordinarie; per un inventario a livello di pacchetto, interroga esplicitamente anche master, layout, note e i master di note e di handout quando presenti.

Il report registra un indice di diapositiva a base 1 e [get_SlideId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideid/) dove disponibile. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/islidecomponent/get_slide/) fornisce la diapositiva proprietaria per i contenitori supportati. Master, layout e note non hanno un indice di diapositiva ordinario e sono identificati per ambito. I contenitori di forma e i contenitori di formattazione di porzione di testo sono etichettati separatamente; gli altri tipi di contenitore mantengono il loro nome di tipo a runtime. Ogni contenitore ottiene un ID locale al report in modo che le sue due azioni possano essere correlate.

Questa politica applicativa deliberatamente restrittiva consente solo URL HTTPS assoluti e target di diapositiva interni validi. Rifiuta macro, programmi, azioni su file, altre azioni di presentazione, azioni sconosciute e altri schemi di URL. Queste rifiuti sono decisioni di policy, non un verdetto di sicurezza di Aspose.Slides. HTTPS da solo non stabilisce fiducia: aggiungere liste di host consentiti e altri controlli per l'applicazione. Sia gli URL esterni originali che quelli normalizzati sono verificati. L'esempio verifica i metadati senza seguire i collegamenti o eseguire azioni.

Per la rimessione in stato, il [get_HyperlinkManager](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) del contenitore supporta [SetExternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) e [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Qui, i collegamenti di clic esterni proibiti vengono sostituiti con una pagina di destinazione HTTPS fissa; gli altri clic proibiti e le azioni di passaggio del mouse proibite vengono rimossi indipendentemente. Impostare `replaceExternalClicks` a `false` per rimuovere tutte le violazioni della policy. Scegliere una pagina di sostituzione gestita dall'applicazione prima del dispiegamento.

Il flag di esportazione del report utilizza una politica di revisione PDF conservativa: segnala le azioni al passaggio del mouse e tutto ciò che non è un collegamento esterno o un salto di diapositiva specifico come potenzialmente non supportato. È un suggerimento di revisione, non un test di capacità o una garanzia che i collegamenti non segnalati sopravvivranno all'esportazione. Le esportazioni PDF e HTML supportate [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/) e [HTML](/slides/it/cpp/convert-powerpoint-to-html/) possono preservare i collegamenti ipertestuali, a seconda dell'azione, delle opzioni di esportazione e del visualizzatore. Le [immagini](/slides/it/cpp/convert-powerpoint-to-png/) raster e i [video](/slides/it/cpp/convert-powerpoint-to-video/) non possono preservare i collegamenti ipertestuali interattivi; segnalare ogni azione quando si effettua l'audit per quei output.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

Con l'input creato sopra, il report contiene cinque righe di azioni. Il collegamento al file al passaggio del mouse e il clic della macro vengono rimossi, mentre i collegamenti HTTPS e la navigazione interna delle diapositive rimangono. La verifica stampa zero azioni proibite. Un input contenente un URL di clic esterno proibito esercita anche il ramo di sostituzione. Un contenitore con un clic consentito e un passaggio del mouse proibito mantiene la sua azione di clic.

Questa pulizia selettiva differisce da [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), che rimuove entrambi i tipi di attivazione in tutto l'ambito selezionato indipendentemente dalla policy. La verifica qui controlla solo le azioni dei collegamenti ipertestuali; non rimuove i progetti VBA incorporati, gli oggetti OLE o altri contenuti attivi, e non convalida un file PDF o HTML esportato.

## **FAQ**

**Come posso collegare a una sezione o alla sua prima diapositiva?**

Le sezioni in PowerPoint raggruppano le diapositive, ma un collegamento ipertestuale interno mira a una singola diapositiva. Per creare una navigazione verso una sezione, collegare alla prima diapositiva di quella sezione.

**Posso allegare un collegamento ipertestuale agli elementi del master in modo che funzioni su tutte le diapositive?**

Sì. Gli elementi del master slide e del layout supportano i collegamenti ipertestuali. I collegamenti su questi elementi sono disponibili durante la presentazione su diapositive che utilizzano il master o il layout corrispondente.

**I collegamenti ipertestuali saranno conservati quando si esporta in PDF, HTML, immagini o video?**

Le esportazioni PDF e HTML supportate possono preservare i collegamenti ipertestuali; le immagini raster e i video non possono. Vedere le considerazioni sull'esportazione in [Report, Sanitize e Verifica i collegamenti ipertestuali](#report-sanitize-and-verify-hyperlinks).