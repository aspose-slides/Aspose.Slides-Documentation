---
title: Modifica dimensione e orientamento della pagina delle note in C++
linktitle: Dimensione pagina delle note
type: docs
weight: 10
url: /it/cpp/notes-size/
keywords:
- dimensione pagina delle note
- orientamento delle note
- note orizzontali
- note verticali
- dimensione del volantino
- PowerPoint
- presentazione
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Leggi e modifica le dimensioni della pagina delle note in Aspose.Slides per C++, cambia l'orientamento, verifica le dimensioni salvate ed esporta note o volantini in PDF e immagini."
---
## **Panoramica**

Utilizza [Presentation::get_NotesSize](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_notessize/) per accedere alle impostazioni della pagina delle note della presentazione. Restituisce un oggetto [INotesSize](https://reference.aspose.com/slides/it/cpp/aspose.slides/inotessize/) il cui metodo [set_Size](https://reference.aspose.com/slides/it/cpp/aspose.slides/inotessize/set_size/) imposta le dimensioni. Sebbene l'oggetto delle impostazioni delle note non possa essere sostituito, è possibile modificarne le dimensioni.

Larghezza e altezza sono specificate in **punti**, con 72 punti per pollice. Ad esempio, 900 × 600 punti corrispondono a 12,5 × 8⅓ pollici. Queste impostazioni si applicano alla presentazione, piuttosto che alle note di una singola diapositiva.

| Impostazione | Scopo |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_notessize/) | Controlla le dimensioni della pagina delle note e le dimensioni della pagina utilizzate per l'esportazione dei volantini. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_slidesize/) | Controlla le dimensioni delle diapositive della presentazione normale tramite [ISlideSize](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidesize/). |

Modificare una delle impostazioni non modifica automaticamente l'altra. Cambiare l'orientamento della pagina delle note non ruota nemmeno le diapositive normali. Vedi [Slide Size](/slides/it/cpp/slide-size/) per ridimensionare le diapositive normali.

Gli esempi seguenti utilizzano un file `sample.pptx` esistente. Per gli esempi di esportazione, usa una presentazione con almeno una diapositiva contenente note del relatore. Ogni esempio può essere eseguito in modo indipendente.

## **Leggi le dimensioni e l'orientamento della pagina delle note**

Leggi la larghezza e l'altezza e confrontale per determinare l'orientamento: una pagina più larga è orizzontale, una pagina più alta è verticale, e dimensioni uguali descrivono una pagina quadrata. Questo esempio stampa le dimensioni effettive in punti, senza assumere una dimensione di carta standard.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Passa a orizzontale senza modificare le dimensioni della carta**

Per cambiare solo l'orientamento, scambia la larghezza e l'altezza esistenti. Questo conserva le lunghezze di entrambi i lati, comprese quelle di una dimensione di carta personalizzata. La condizione seguente impedisce che una pagina già orizzontale venga nuovamente trasformata in verticale e lascia inalterata una pagina quadrata.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Per l'orientamento verticale, usa la stessa assegnazione quando `size.get_Width() > size.get_Height()`. Non sostituire le dimensioni A4 o Letter a meno che tu non voglia anche modificare le dimensioni della carta.

## **Imposta e verifica una dimensione personalizzata della pagina delle note**

Assegna entrambe le dimensioni insieme, quindi usa [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) per scrivere la presentazione. Questo esempio imposta una pagina orizzontale di 900 × 600 punti, la salva come PPTX e riapre il file salvato per verificare i valori mantenuti. Il confronto ammette una tolleranza di 0,01 punti per i valori in virgola mobile; non è una garanzia di precisione per ogni formato di file.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

Il risultato atteso è `900 x 600 points` e `Size preserved: True`. Verificare una presentazione appena aperta controlla il file salvato, piuttosto che solo le impostazioni in memoria.

## **Esporta note e fogli volantino**

Le dimensioni della pagina definiscono l'area disponibile per le note o i layout dei volantini. Non abilitano questi layout da sole: configura anche le opzioni di esportazione. L'esportazione delle diapositive normali continua a utilizzare le dimensioni della diapositiva.

### **Esporta note in PDF e PNG**

Assegna [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notescommentslayoutingoptions/) a [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) per includere le note nel PDF. Questo esempio rende anche la prima diapositiva con le note in PNG usando [Slide::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/getimage/) e [RenderingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/renderingoptions/).

La modalità [BottomTruncated](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notespositions/) mantiene le note su una sola pagina; le note che non rientrano possono essere troncate. Il PDF utilizza pagine di 900 × 600 punti. Alla scala immagine di 1 × 1 utilizzata di seguito, il PNG è di 900 × 600 pixel. I punti descrivono la geometria della pagina; i pixel descrivono l'output raster, le cui dimensioni dipendono anche dalla scala di rendering.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Per l'esportazione PDF con note lunghe, [BottomFull](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notespositions/) consente pagine aggiuntive secondo necessità. Non utilizzare tale modalità con la chiamata immagine a singola diapositiva sopra, che non la supporta. Dopo il ridimensionamento, controlla l'output per note troncate e la posizione degli oggetti note-master esistenti; modificare solo le dimensioni della pagina non garantisce che tutti i contenuti si adattino. Vedi [Convert PowerPoint to PDF with Notes](/slides/it/cpp/convert-powerpoint-to-pdf-with-notes/) per ulteriori informazioni sull'esportazione delle note.

### **Esporta volantini in PDF**

Utilizza [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/handoutlayoutingoptions/) per più miniature diapositive su una pagina. L'esempio seguente imposta una pagina di 900 × 600 punti e usa [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/handouttype/) per disporre fino a quattro diapositive per pagina. Il preset orizzontale controlla l'ordine delle diapositive; l'orientamento della pagina deriva dalla sua larghezza e altezza.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Modificare le dimensioni della pagina cambia l'area disponibile per la griglia del volantino senza modificare le dimensioni delle diapositive di origine. Per le immagini dei volantini, usa [Presentation::GetImages](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/getimages/) con il layout volantino, anziché il metodo immagine di una singola diapositiva. In Aspose.Slides, il rendering dei volantini a livello di presentazione utilizza le dimensioni della pagina delle note, mentre la chiamata immagine della singola diapositiva non produce la pagina del volantino. Vedi [Handoff Mode](/slides/it/cpp/convert-powerpoint-in-handout-mode/) per le opzioni di layout.

## **Dimensioni della pagina in visualizzatori, esportazione e stampa**

Mantieni distinti la dimensione della presentazione archiviata, la dimensione della pagina esportata e la dimensione della carta stampata:

- **Presentation viewers:** Un visualizzatore può visualizzare o stampare le note usando le proprie regole di layout. Se un'altra applicazione salva il file, riaprilo e controlla nuovamente le dimensioni; la conversione di formato di quell'applicazione potrebbe normalizzarle.
- **Export formats:** Gli esempi di PDF per note e volantini sopra usano le dimensioni della pagina configurate. Le immagini raster usano dimensioni di pixel interi e una scala di rendering, quindi i valori di punti frazionari possono essere arrotondati nell'output immagine. L'esportazione delle diapositive normali non applica la dimensione della pagina delle note.
- **Printer drivers:** La selezione della carta, la rotazione automatica e le impostazioni di adatta alla pagina possono modificare l'output fisico senza alterare le dimensioni memorizzate nella presentazione o nel PDF. Per una dimensione di carta specifica, corrispondi le impostazioni della stampante e controlla l'anteprima di stampa.

## **FAQ**

**Posso impostare la dimensione delle note per una sola diapositiva?**

La dimensione della pagina delle note è un'impostazione a livello di presentazione. Le singole diapositive possono avere contenuti di note differenti, ma questa proprietà non fornisce una dimensione di pagina separata per ciascuna diapositiva.

**Perché il cambiamento dell'orientamento delle note non ha modificato le mie diapositive?**

Le pagine delle note e le diapositive normali hanno dimensioni indipendenti. Usa le impostazioni della dimensione delle diapositive regolari quando desideri ridimensionare le diapositive stesse.

**Perché il risultato salvato o stampato ha una dimensione diversa?**

Prima riapri la presentazione salvata e confronta le sue dimensioni delle note. Se sono cambiate, verifica se il salvataggio o la conversione del file in un'altra applicazione ha modificato le impostazioni della pagina. Se non lo ha fatto, controlla il layout di esportazione, la scala dell'immagine, le impostazioni del visualizzatore e la selezione della carta della stampante.