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
- commenti della diapositiva
- aggiungere commento
- accedere al commento
- modificare commento
- rispondere al commento
- rimuovere commento
- eliminare commento
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Gestisci i commenti della presentazione con Aspose.Slides per C++: aggiungi, leggi, modifica, rispondi e rimuovi i commenti nelle presentazioni PowerPoint in modo rapido e semplice."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti della presentazione con Aspose.Slides per C++. Introduce i principali tipi relativi ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, lavorare con le risposte e i commenti moderni e rimuovere i commenti da una presentazione.

Gli esempi coprono scenari comuni di revisione e collaborazione in PowerPoint, come assegnare commenti agli autori, leggere il testo e i metadati del commento, costruire catene di risposte e rimuovere commenti selezionati o tutti i commenti.

In PowerPoint, i commenti appaiono come annotazioni sulle diapositive. Selezionare un commento mostra il suo testo e la discussione correlata.

## **Perché aggiungere commenti alle presentazioni?**

È possibile utilizzare i commenti per fornire feedback e collaborare con i colleghi durante la revisione delle presentazioni.

Aspose.Slides per C++ fornisce le seguenti API per lavorare con i commenti:

* La classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) che fornisce l'accesso agli autori dei commenti della presentazione.
* L'interfaccia [ICommentCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/icommentcollection/) che rappresenta i commenti associati a un singolo autore.
* L'interfaccia [IComment](https://reference.aspose.com/slides/it/cpp/aspose.slides/icomment/) che fornisce informazioni su un commento, includendo il suo autore, l'ora di creazione, la posizione e il testo.
* La classe [CommentAuthor](https://reference.aspose.com/slides/it/cpp/aspose.slides/commentauthor/) che fornisce informazioni su un autore, includendo il suo nome, le iniziali e i commenti associati.

## **Aggiungere commenti alle diapositive**

L'esempio seguente mostra come aggiungere commenti alle diapositive in una presentazione PowerPoint:

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

## **Accedere ai commenti delle diapositive**

L'esempio seguente mostra come accedere ai commenti esistenti in una presentazione PowerPoint:

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

## **Rispondere ai commenti**

Un commento genitore è il commento originale in cima a una gerarchia di risposte. I metodi [get_ParentComment](https://reference.aspose.com/slides/it/cpp/aspose.slides/icomment/get_parentcomment/) e [set_ParentComment](https://reference.aspose.com/slides/it/cpp/aspose.slides/icomment/set_parentcomment/) dell'interfaccia [IComment](https://reference.aspose.com/slides/it/cpp/aspose.slides/icomment/) consentono di ottenere o impostare il genitore di un commento.

L'esempio seguente mostra come aggiungere risposte e ispezionare la gerarchia di commenti risultante:

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

auto author1 = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto author2 = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
reply1->set_ParentComment(comment1);

auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
reply2->set_ParentComment(comment1);

auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(reply2);

author2->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
reply3->set_ParentComment(comment3);

auto comments = slide->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

comment1->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* Quando il metodo [Remove](https://reference.aspose.com/slides/it/cpp/aspose.slides/icomment/remove/) dell'interfaccia [IComment](https://reference.aspose.com/slides/it/cpp/aspose.slides/icomment/) viene utilizzato per eliminare un commento, tutte le risposte a quel commento vengono eliminate.
* Se il metodo [set_ParentComment](https://reference.aspose.com/slides/it/cpp/aspose.slides/icomment/set_parentcomment/) crea un riferimento circolare, viene generata un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/cpp/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Aggiungere commenti moderni**

I commenti moderni possono essere associati alla diapositiva stessa, a una forma specifica o a un intervallo di testo all'interno di un'AutoShape. Il metodo [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/it/cpp/aspose.slides/icommentcollection/addmoderncomment/) accetta un argomento [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) oltre alle coordinate della diapositiva e del marcatore del commento.

Quando viene passato `nullptr` come argomento shape, il commento è un commento a livello di diapositiva. Il suo marcatore è posizionato secondo le coordinate fornite, ma non è associato a una forma particolare, quindi [IModernComment::get_Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/get_shape/) restituisce `nullptr`. Quando viene fornito un [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/), il commento è ancorato a quella forma. Le coordinate continuano a definire la posizione del marcatore del commento sulla diapositiva, mentre l'associazione alla forma può essere recuperata tramite [IModernComment::get_Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/get_shape/).

### **Ancorare un commento moderno a una forma**

L'esempio seguente crea sia un commento moderno a livello di diapositiva sia un commento moderno ancorato a una AutoShape specifica. Successivamente legge la forma associata a ciascun commento.

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

### **Ancorare commenti a diversi tipi di forma**

Qualsiasi oggetto della diapositiva che implementa [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) può essere usato come ancora di forma. Esempi comuni includono [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/it/cpp/aspose.slides/iconnector/) e istanze di [IGraphicalObject](https://reference.aspose.com/slides/it/cpp/aspose.slides/igraphicalobject/) come i grafici.

L'esempio seguente crea diversi tipi di forma comuni e associa un commento moderno a ciascuno di essi.

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

### **Ancorare un commento al testo e impostarne lo stato**

Per un commento moderno associato a un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/), i metodi [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/get_textselectionstart/) e [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/set_textselectionstart/) controllano la posizione iniziale del testo selezionato nel frame di testo della forma. Allo stesso modo, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/get_textselectionlength/) e [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/set_textselectionlength/) controllano la lunghezza della selezione. Insieme, questi metodi associano il commento a un intervallo di testo specifico all'interno dell'AutoShape.

I metodi [IModernComment::get_Status](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/get_status/) e [IModernComment::set_Status](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/set_status/) utilizzano un valore dell'enumerazione [ModernCommentStatus](https://reference.aspose.com/slides/it/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — nessuno stato specifico del commento moderno è definito.
- `Active` — il commento è attivo.
- `Resolved` — il commento è stato risolto.
- `Closed` — il commento è chiuso.

L'esempio seguente crea un commento moderno ancorato a una forma, lo associa a una selezione di testo, lo segna come risolto, salva la presentazione e verifica i valori dopo aver riaperto il file.

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

### **Ispezionare i commenti moderni esistenti**

Per ispezionare una presentazione esistente, verificare quali commenti implementano [IModernComment](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/), quindi esaminare [IModernComment::get_Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/get_textselectionlength/) e [IModernComment::get_Status](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/get_status/). Una forma `nullptr` indica un commento a livello di diapositiva. Per un'ancora [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/), i metodi di selezione del testo identificano l'intervallo associato nel frame di testo della forma.

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

## **Rimuovere i commenti**

### **Rimuovere tutti i commenti e gli autori dei commenti**

L'esempio seguente mostra come rimuovere tutti i commenti e gli autori dei commenti da una presentazione:

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

### **Rimuovere commenti specifici**

L'esempio seguente mostra come rimuovere commenti specifici da una diapositiva:

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

**Aspose.Slides supporta lo stato risolto per i commenti moderni?**

Sì. [IModernComment::get_Status](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/get_status/) e [IModernComment::set_Status](https://reference.aspose.com/slides/it/cpp/aspose.slides/imoderncomment/set_status/) utilizzano un valore [ModernCommentStatus](https://reference.aspose.com/slides/it/cpp/aspose.slides/moderncommentstatus/), incluso `Resolved`. Lo stato è memorizzato nella presentazione e può essere letto nuovamente dopo aver riaperto il file.

**Le discussioni a thread (catene di risposte) sono supportate e c'è un limite di nidificazione?**

Sì. Ogni commento può fare riferimento al proprio [parent comment](https://reference.aspose.com/slides/it/cpp/aspose.slides/icomment/set_parentcomment/), consentendo catene di risposte. L'API non definisce un limite specifico di profondità di nidificazione.

**In quale sistema di coordinate è definita la posizione del marcatore di un commento su una diapositiva?**

La posizione del marcatore è definita da coordinate a virgola mobile nel sistema di coordinate della diapositiva, consentendo di posizionarlo con precisione sulla diapositiva.