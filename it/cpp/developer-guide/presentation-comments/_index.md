---
title: Gestire i commenti della presentazione in C++
linktitle: Commenti della presentazione
type: docs
weight: 100
url: /it/cpp/presentation-comments/
keywords:
- commento
- commento moderno
- commenti PowerPoint
- commenti della presentazione
- commenti diapositiva
- aggiungi commento
- accedi al commento
- modifica commento
- rispondi al commento
- rimuovi commento
- elimina commento
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Gestisci i commenti della presentazione con Aspose.Slides per C++: aggiungi, leggi, modifica, rispondi e rimuovi i commenti nelle presentazioni PowerPoint in modo rapido e semplice."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti di presentazione con Aspose.Slides per C++. Introduce i principali tipi relativi ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, lavorare con le risposte e i commenti moderni, e rimuovere i commenti da una presentazione.

Gli esempi coprono scenari comuni di revisione e collaborazione in PowerPoint, come assegnare commenti agli autori, leggere il testo e i metadati dei commenti, costruire catene di risposte e rimuovere commenti selezionati o tutti i commenti.

In PowerPoint, i commenti appaiono come annotazioni sulle diapositive. Selezionare un commento visualizza il suo testo e la discussione correlata.

Per richiedere che i commenti vengano mostrati o nascosti quando una presentazione viene aperta senza modificare i commenti stessi, vedere [Mostra o Nascondi i Commenti all'Apertura di una Presentazione](/slides/it/cpp/presentation-view-properties/).

## **Perché Aggiungere Commenti alle Presentazioni?**

Puoi utilizzare i commenti per fornire feedback e collaborare con i colleghi durante la revisione delle presentazioni.

Aspose.Slides per C++ fornisce le seguenti API per lavorare con i commenti:

* La classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) fornisce l'accesso agli autori dei commenti della presentazione.
* L'interfaccia [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) rappresenta i commenti associati a un singolo autore.
* L'interfaccia [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) fornisce informazioni su un commento, includendo autore, data di creazione, posizione e testo.
* La classe [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) fornisce informazioni su un autore, includendo nome, iniziali e commenti associati.

## **Aggiungere Commenti alle Diapositive**

L'esempio crea due diapositive e registra un autore di commenti con [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/). Utilizza [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) per posizionare un commento su ciascuna diapositiva, quindi recupera i commenti della prima diapositiva per quell'autore con [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/). La console visualizza due volte il testo del primo commento, dimostrando l'accesso sia tramite diapositiva sia tramite autore, e la presentazione salvata contiene entrambi i commenti.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlide(0));

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");
auto position = PointF(0.2f, 0.2f);
auto createdTime = DateTime::get_Now();

author->get_Comments()->AddComment(u"Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author->get_Comments()->AddComment(u"Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

auto comments = firstSlide->GetSlideComments(author);
if (comments->get_Length() > 0)
{
    auto firstComment = comments[0];
    Console::WriteLine(firstComment->get_Text());

    auto commentText = firstComment->get_Author()->get_Comments()->idx_get(0)->get_Text();
    Console::WriteLine(commentText);
}

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);
```

## **Trova o Crea un Autore di Commenti**

Quando una revisione automatizzata elabora la stessa presentazione più volte, cerca nella raccolta restituita da [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) prima di aggiungere un autore. [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) corrisponde sia al nome sia alle iniziali e restituisce un array di autori corrispondenti, oppure un array vuoto se non esistono corrispondenze. Al contrario, [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) ricerca solo per nome, indipendentemente dalle iniziali. Chiamare [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) con un nome e delle iniziali già presenti nella raccolta genera un'eccezione.

L'esempio richiede un file di presentazione con almeno una diapositiva. In ciascuna delle due esecuzioni, riutilizza il primo autore corrispondente, o ne crea uno solo quando il risultato è vuoto. Se ci sono più corrispondenze, seleziona il primo elemento dell'array senza unire o rimuovere gli altri autori. Quindi chiama [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) per l'autore selezionato e salva la presentazione. La seconda esecuzione apre l'output della prima e ripete l'operazione.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String authorName = u"Reviewer";
const String authorInitials = u"RV";

auto inputFile = String(u"input.pptx");
auto position = PointF(20.0f, 20.0f);

for (auto pass = 1; pass <= 2; pass++)
{
    auto presentation = MakeObject<Presentation>(inputFile);

    auto matches = presentation->get_CommentAuthors()->FindByNameAndInitials(authorName, authorInitials);

    auto author = matches->get_Length() > 0 ? matches[0] : presentation->get_CommentAuthors()->AddAuthor(authorName, authorInitials);
    author->get_Comments()->AddComment(u"Please review this slide.", presentation->get_Slide(0), position, DateTime::get_Now());

    auto outputFile = String::Format(u"review_pass_{0}.pptx", pass);
    presentation->Save(outputFile, SaveFormat::Pptx);
    inputFile = outputFile;
}
```

La seconda esecuzione aggiunge un altro commento senza aggiungere un nuovo autore né rimuovere i commenti esistenti. Il file finale, `review_pass_2.pptx`, contiene entrambi i nuovi commenti insieme a eventuali commenti originali. Riutilizzare un autore non deduplica i commenti: per evitare di aggiungere ripetutamente lo stesso commento, implementa un rilevamento dei duplicati separato prima di aggiungerlo.

## **Accedere ai Commenti delle Diapositive**

L'esempio apre una presentazione esistente e legge la raccolta restituita da [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/). Per ciascun autore, itera sulla raccolta restituita da [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) e stampa il numero della diapositiva, il testo del commento, il nome dell'autore e la data di creazione. La presentazione di input deve contenere commenti per produrre output sulla console.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    for (auto&& comment : author->get_Comments())
    {
        Console::WriteLine(u"Slide: {0}", comment->get_Slide()->get_SlideNumber());
        Console::WriteLine(u"Comment: {0}", comment->get_Text());
        Console::WriteLine(u"Author: {0}", comment->get_Author()->get_Name());
        Console::WriteLine(u"Posted at: {0}", comment->get_CreatedTime());
        Console::WriteLine();
    }
}
```

## **Rispondere ai Commenti**

Un commento genitore è il commento originale alla cima di una gerarchia di risposte. I metodi [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) e [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) dell'interfaccia [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) consentono di ottenere o impostare il genitore di un commento.

L'esempio crea commenti da due autori e utilizza [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) per costruire le risposte, includendo una risposta a un'altra risposta. Passare `nullptr` a [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) recupera i commenti da tutti gli autori; la console indentifica ogni voce in base alla sua profondità nella gerarchia di risposte. L'esempio salva la discussione completa, chiama [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) sul primo commento radice e salva una seconda presentazione con quel commento e le sue risposte rimosse.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto position = PointF(10.0f, 10.0f);
auto createdTime = DateTime::get_Now();

auto originalAuthor = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto rootComment = originalAuthor->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto reviewer = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto firstReply = reviewer->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
firstReply->set_ParentComment(rootComment);

auto secondReply = reviewer->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
secondReply->set_ParentComment(rootComment);

auto subReply = originalAuthor->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(secondReply);

reviewer->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto separateComment = reviewer->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto separateReply = originalAuthor->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
separateReply->set_ParentComment(separateComment);

auto comments = slide->GetSlideComments(nullptr);
for (auto i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
   

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

rootComment->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* Quando il metodo [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) dell'interfaccia [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) viene utilizzato per eliminare un commento, tutte le risposte a quel commento vengono eliminate.
* Se il metodo [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) crea un riferimento circolare, viene lanciata una [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Aggiungere Commenti Moderni**

I commenti moderni possono essere associati alla diapositiva stessa, a una forma specifica o a un intervallo di testo all'interno di un'AutoShape. Il metodo [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) accetta un argomento [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) oltre alle coordinate della diapositiva e del marcatore del commento.

Quando `nullptr` viene passato per l'argomento shape, il commento è un commento a livello di diapositiva. Il suo marcatore è posizionato dalle coordinate fornite, ma non è associato a una forma specifica, quindi [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) restituisce `nullptr`. Quando viene fornito un [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), il commento è ancorato a quella forma. Le coordinate definiscono comunque la posizione del marcatore del commento sulla diapositiva, mentre l'associazione alla forma può essere recuperata tramite [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/).

### **Ancorare un Commento Moderno a una Forma**

L'esempio chiama [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) due volte: una volta con una forma `nullptr` per un commento a livello di diapositiva e una volta con un rettangolo come ancoraggio. Chiamare [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) stampa `True` per il controllo nullo del commento a livello di diapositiva e `Revenue title` per il commento ancorato. Entrambi i commenti vengono salvati con la presentazione.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 300.0f, 80.0f);
shape->set_Name(u"Revenue title");
shape->get_TextFrame()->set_Text(u"Quarterly revenue");

auto createdTime = DateTime::get_Now();
auto slideCommentPosition = PointF(20.0f, 20.0f);
auto shapeCommentPosition = PointF(60.0f, 60.0f);
auto slideComment = author->get_Comments()->AddModernComment(u"Review the overall slide layout.", slide, nullptr, slideCommentPosition, createdTime);
auto shapeComment = author->get_Comments()->AddModernComment(u"Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console::WriteLine(slideComment->get_Shape() == nullptr);
auto shapeAnchor = shapeComment->get_Shape();
if (shapeAnchor != nullptr)
{
    Console::WriteLine(shapeAnchor->get_Name());
}

presentation->Save(u"modern_comments.pptx", SaveFormat::Pptx);
```

### **Ancorare Commenti a Diversi Tipi di Forma**

Qualsiasi oggetto della diapositiva che implementa [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) può essere usato come ancoraggio di forma. Esempi comuni includono [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/) e istanze di [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) come grafici.

L'esempio utilizza [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) per associare un commento a ciascuno dei cinque tipi di forma: un'AutoShape, un picture frame, un gruppo, un connettore e un grafico. L'immagine utilizza dati immagine incorporati, quindi non è richiesta alcuna immagine esterna. Ogni commento ha la propria posizione del marcatore e la presentazione salvata conserva tutte e cinque le associazioni di forma.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IConnector.h>
#include <DOM/IGroupShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/convert.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto createdTime = DateTime::get_Now();

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 60.0f);
autoShape->get_TextFrame()->set_Text(u"AutoShape");

auto autoShapeCommentPosition = PointF(30.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

auto imageBase64 = u"iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
auto imageData = Convert::FromBase64String(imageBase64);
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 120.0f, 80.0f, image);
auto pictureCommentPosition = PointF(230.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

auto groupShape = slide->get_Shapes()->AddGroupShape();
groupShape->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 80.0f, 40.0f);
groupShape->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 100.0f, 0.0f, 80.0f, 40.0f);
auto groupCommentPosition = PointF(40.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 220.0f, 150.0f, 140.0f, 40.0f);
auto connectorCommentPosition = PointF(240.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 400.0f, 20.0f, 250.0f, 180.0f);
auto chartCommentPosition = PointF(420.0f, 40.0f);
author->get_Comments()->AddModernComment(u"Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation->Save(u"modern_comment_shape_types.pptx", SaveFormat::Pptx);
```

### **Ancorare un Commento al Testo e Impostarne lo Stato**

Per un commento moderno associato a un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), i metodi [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) e [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) controllano la posizione iniziale del testo selezionato nel frame di testo della forma. Analogamente, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) e [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) controllano la lunghezza della selezione. Insieme, questi metodi associano il commento a un intervallo di testo specifico all'interno dell'AutoShape.

I metodi [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) e [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) utilizzano un valore dell'enumerazione [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — nessuno stato specifico del commento moderno è definito.
- `Active` — il commento è attivo.
- `Resolved` — il commento è stato risolto.
- `Closed` — il commento è chiuso.

L'esempio ancorra un commento moderno alle parole "quarterly revenue" nel testo di un rettangolo. Calcola l'indice di inizio zero‑based dal testo, lo passa a [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/), e chiama [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) con il numero di caratteri selezionati. Dopo aver chiamato [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) con `Resolved`, salva e riapre la presentazione. I quattro controlli della console dovrebbero tutti stampare `True`, confermando che l'ancoraggio della forma, l'intervallo di testo e lo stato siano stati conservati.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String outputFile = u"modern_comment_text_anchor.pptx";
const String shapeText = u"Review the quarterly revenue forecast.";
const String selectedText = u"quarterly revenue";
auto expectedSelectionStart = shapeText.IndexOf(selectedText);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 100.0f);
shape->set_Name(u"Forecast text");
shape->get_TextFrame()->set_Text(shapeText);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto commentPosition = PointF(60.0f, 60.0f);
auto comment = author->get_Comments()->AddModernComment(u"Verify this forecast wording.", slide, shape, commentPosition, DateTime::get_Now());
comment->set_TextSelectionStart(expectedSelectionStart);
comment->set_TextSelectionLength(selectedText.get_Length());
comment->set_Status(ModernCommentStatus::Resolved);

presentation->Save(outputFile, SaveFormat::Pptx);

auto reopenedPresentation = MakeObject<Presentation>(outputFile);
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedComments = reopenedSlide->GetSlideComments(nullptr);

for (auto&& reopenedComment : reopenedComments)
{
    auto modernComment = AsCast<IModernComment>(reopenedComment);
    if (modernComment == nullptr)
    {
        continue;
    }

    auto shapeAnchor = modernComment->get_Shape();
    auto shapeMatches = shapeAnchor != nullptr && shapeAnchor->get_Name() == u"Forecast text";
    auto selectionStartMatches = modernComment->get_TextSelectionStart() == expectedSelectionStart;
    auto selectionLengthMatches = modernComment->get_TextSelectionLength() == selectedText.get_Length();
    auto statusMatches = modernComment->get_Status() == ModernCommentStatus::Resolved;

    Console::WriteLine(u"Shape anchor preserved: {0}", shapeMatches);
    Console::WriteLine(u"Text selection start preserved: {0}", selectionStartMatches);
    Console::WriteLine(u"Text selection length preserved: {0}", selectionLengthMatches);
    Console::WriteLine(u"Resolved status preserved: {0}", statusMatches);
}
```

### **Ispezionare i Commenti Moderni Esistenti**

L'esempio richiede una presentazione esistente contenente commenti moderni e stampa il loro testo, stato e dettagli di ancoraggio. Per ispezionarla, verifica quali commenti implementano [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/), quindi esamina [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) e [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/). Una forma `nullptr` indica un commento a livello di diapositiva. Per un ancoraggio a [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), i metodi di selezione del testo identificano l'intervallo associato nel frame di testo della forma.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"comments.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto comments = slide->GetSlideComments(nullptr);
    for (auto&& comment : comments)
    {
        auto modernComment = AsCast<IModernComment>(comment);
        if (modernComment == nullptr)
        {
            continue;
        }

        Console::WriteLine(u"Slide: {0}", slide->get_SlideNumber());
        Console::WriteLine(u"Text: {0}", modernComment->get_Text());
        Console::WriteLine(u"Status: {0}", modernComment->get_Status());

        auto shape = modernComment->get_Shape();
        if (shape == nullptr)
        {
            Console::WriteLine(u"Anchor: slide level");
        }
        else
        {
            Console::WriteLine(u"Anchor shape: {0}", shape->get_Name());
            Console::WriteLine(u"Anchor type: {0}", shape->GetType().get_Name());

            auto autoShape = AsCast<IAutoShape>(shape);
            if (autoShape != nullptr)
            {
                Console::WriteLine(u"Text selection start: {0}", modernComment->get_TextSelectionStart());
                Console::WriteLine(u"Text selection length: {0}", modernComment->get_TextSelectionLength());
            }
        }

        Console::WriteLine();
    }
}
```

## **Rimuovere i Commenti**

Aspose.Slides per C++ consente di rimuovere tutti i commenti e i loro autori da una presentazione o di eliminare commenti selezionati mantenendo gli altri. I seguenti esempi mostrano entrambi gli approcci e salvano la presentazione aggiornata.

### **Rimuovere tutti i Commenti e gli Autori dei Commenti**

L'esempio apre una presentazione esistente e chiama [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) per ciascun autore, quindi chiama [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) per rimuovere gli autori stessi. La presentazione salvata non contiene né commenti né autori di commenti. Usa una presentazione contenente commenti per osservare la rimozione.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"example.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}

presentation->get_CommentAuthors()->Clear();

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Rimuovere Commenti Specifici**

L'esempio crea due commenti su una diapositiva e utilizza [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) per trovare i commenti di ciascun autore. Raccoglie i commenti il cui testo è uguale a "comment 1" prima di chiamare [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/), evitando modifiche alla raccolta durante la selezione. La presentazione salvata conserva solo "comment 2".

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
auto createdTime = DateTime::get_Now();

auto firstCommentPosition = PointF(0.2f, 0.2f);
auto secondCommentPosition = PointF(0.3f, 0.2f);
author->get_Comments()->AddComment(u"comment 1", slide, firstCommentPosition, createdTime);
author->get_Comments()->AddComment(u"comment 2", slide, secondCommentPosition, createdTime);

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto commentsToRemove = MakeObject<List<SharedPtr<IComment>>>();
    auto comments = slide->GetSlideComments(commentAuthor);

    for (auto&& comment : comments)
    {
        if (comment->get_Text() == u"comment 1")
        {
            commentsToRemove->Add(comment);
        }
    }

    for (auto&& comment : commentsToRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}

presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Aspose.Slides supporta uno stato risolto per i commenti moderni?**

Sì. [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) e [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) utilizzano un valore di [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/), incluso `Resolved`. Lo stato è memorizzato nella presentazione e può essere letto nuovamente dopo che il file è stato riaperto.

**Le discussioni a filo (catene di risposte) sono supportate e c'è un limite di nidificazione?**

Sì. Ogni commento può fare riferimento al suo [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/), consentendo catene di risposte. L'API non definisce un limite specifico di profondità di nidificazione.

**In quale sistema di coordinate è definita la posizione del marcatore di un commento su una diapositiva?**

La posizione del marcatore è definita da coordinate a virgola mobile nel sistema di coordinate della diapositiva, consentendo di posizionarlo con precisione sulla diapositiva.