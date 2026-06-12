---
title: Gestisci i commenti della presentazione in C++
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
- aggiungi commento
- accedi al commento
- modifica commento
- rispondi al commento
- rimuovi commento
- elimina commento
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci i commenti della presentazione con Aspose.Slides per C++: aggiungi, leggi, modifica e elimina i commenti nei file PowerPoint in modo rapido e semplice."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti di presentazione in Aspose.Slides. Mostra i principali tipi correlati ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, lavorare con le risposte, utilizzare i commenti moderni e rimuovere i commenti da una presentazione.

Gli esempi si concentrano su scenari comuni di revisione e collaborazione in PowerPoint, come l'assegnazione dei commenti agli autori, la lettura del contenuto e dei metadati dei commenti, la costruzione di catene di risposte e la cancellazione di tutti i commenti o l'eliminazione di quelli selezionati.

In PowerPoint, un commento appare come una nota o un'annotazione su una diapositiva. Quando si fa clic su un commento, il suo contenuto o i suoi messaggi vengono visualizzati.

### **Perché aggiungere commenti alle presentazioni?**

Potresti voler utilizzare i commenti per fornire feedback o comunicare con i colleghi quando esamini le presentazioni.

Per consentirti di usare i commenti nelle presentazioni PowerPoint, Aspose.Slides per C++ fornisce

* La classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) che contiene le collezioni di autori (dal metodo [get_CommentAuthors()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Gli autori aggiungono commenti alle diapositive. 
* L’interfaccia [ICommentCollection](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_comment_collection) che contiene la collezione di commenti per singoli autori. 
* La classe [IComment](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_comment) che contiene informazioni sugli autori e sui loro commenti: chi ha aggiunto il commento, l'ora in cui è stato aggiunto, la posizione del commento, ecc. 
* La classe [CommentAuthor](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.comment_author) che contiene informazioni su singoli autori: nome dell'autore, sue iniziali, commenti associati al nome dell'autore, ecc. 

## **Aggiungere un commento a una diapositiva**
Questo codice C++ mostra come aggiungere un commento a una diapositiva in una presentazione PowerPoint:

```cpp
// Istanzia la classe Presentation
auto presentation = System::MakeObject<Presentation>();
// Aggiunge una diapositiva vuota
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Aggiunge un autore
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Imposta la posizione per i commenti
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Accede a ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Accede a ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Aggiunge un commento di diapositiva per un autore sulla diapositiva 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Aggiunge un commento di diapositiva per un autore sulla diapositiva 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Quando null viene passato come argomento, i commenti di tutti gli autori vengono riportati alla diapositiva selezionata
auto comments = slide1->GetSlideComments(author);

// Accede al commento all'indice 0 per la diapositiva 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Seleziona la collezione di commenti dell'autore all'indice 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Accedere ai commenti della diapositiva**
Questo codice C++ mostra come accedere a un commento esistente su una diapositiva in una presentazione PowerPoint:

```cpp
// Istanzia la classe Presentation
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```

## **Rispondere ai commenti**
Un commento genitore è il commento principale o originale in una gerarchia di commenti o risposte. Utilizzando la proprietà [ParentComment](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (dell’interfaccia [IComment](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_comment)), è possibile impostare o ottenere un commento genitore. 

Questo codice C++ mostra come aggiungere commenti e ottenere le risposte ad essi:

```cpp
auto pres = System::MakeObject<Presentation>();

// Accede a ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Aggiunge un commento
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Aggiunge una risposta al commento1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Aggiunge un'altra risposta al commento1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Aggiunge una risposta a una risposta esistente
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Visualizza la gerarchia dei commenti sulla console
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// Rimuove il commento1 e tutte le risposte ad esso
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attenzione" %}} 

* Quando il metodo [Remove](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (dell’interfaccia [IComment](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_comment)) viene utilizzato per eliminare un commento, anche le risposte al commento vengono cancellate. 
* Se l’impostazione [ParentComment](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) genera un riferimento circolare, verrà sollevata l’eccezione [PptxEditException](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).

{{% /alert %}}

## **Aggiungere un commento moderno**

Nel 2021, Microsoft ha introdotto i *commenti moderni* in PowerPoint. La funzionalità dei commenti moderni migliora notevolmente la collaborazione in PowerPoint. Attraverso i commenti moderni, gli utenti di PowerPoint possono risolvere i commenti, ancorare i commenti a oggetti e testi e interagire in modo molto più semplice rispetto a prima. 

In [Aspose Slides per C++ 21.11](https://docs.aspose.com/slides/it/cpp/aspose-slides-for-cpp-21-11-release-notes/), abbiamo implementato il supporto per i commenti moderni aggiungendo la classe [ModernComment](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.modern_comment). Sono stati aggiunti i metodi [AddModernComment](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) e [InsertModernComment](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) alla classe [CommentCollection](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.comment_collection).

Questo codice C++ mostra come aggiungere un commento moderno a una diapositiva in una presentazione PowerPoint: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Accede a ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Rimuovere un commento**

### **Eliminare tutti i commenti e gli autori**

Questo codice C++ mostra come rimuovere tutti i commenti e gli autori in una presentazione:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Elimina tutti i commenti dalla presentazione
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Elimina tutti gli autori
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Eliminare commenti specifici**

Questo codice C++ mostra come eliminare commenti specifici su una diapositiva:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// aggiunge commenti...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// rimuove tutti i commenti che contengono il testo "comment 1"
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Aspose.Slides supporta uno stato come “risolto” per i commenti moderni?**

Sì. I [commenti moderni](https://reference.aspose.com/slides/it/cpp/aspose.slides/moderncomment/) espongono i metodi [get_Status](https://reference.aspose.com/slides/it/cpp/aspose.slides/moderncomment/get_status/) e [set_Status](https://reference.aspose.com/slides/it/cpp/aspose.slides/moderncomment/set_status/); è possibile leggere e impostare lo [stato del commento](https://reference.aspose.com/slides/it/cpp/aspose.slides/moderncommentstatus/) (ad esempio, contrassegnarlo come risolto), e questo stato viene salvato nel file e riconosciuto da PowerPoint.

**Le discussioni a thread (catene di risposte) sono supportate e c’è un limite di annidamento?**

Sì. Ogni commento può fare riferimento al proprio [parent comment](https://reference.aspose.com/slides/it/cpp/aspose.slides/comment/set_parentcomment/), consentendo catene di risposte arbitrarie. L’API non dichiara un limite specifico di profondità di annidamento.

**In quale sistema di coordinate è definita la posizione del marcatore del commento su una diapositiva?**

La posizione è memorizzata come punto a virgola mobile nel sistema di coordinate della diapositiva. Questo consente di posizionare il marcatore del commento esattamente dove è necessario.