---
title: Gérer les commentaires de présentation en C++
linktitle: Commentaires de présentation
type: docs
weight: 100
url: /fr/cpp/presentation-comments/
keywords:
- commentaire
- commentaire moderne
- commentaires PowerPoint
- commentaires de présentation
- commentaires de diapositive
- ajouter un commentaire
- accéder au commentaire
- modifier le commentaire
- répondre au commentaire
- supprimer le commentaire
- effacer le commentaire
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Maîtrisez les commentaires de présentation avec Aspose.Slides pour C++ : ajoutez, lisez, modifiez et supprimez des commentaires dans les fichiers PowerPoint rapidement et facilement."
---

Dans PowerPoint, un commentaire apparaît comme une note ou une annotation sur une diapositive. Lorsqu'un commentaire est cliqué, son contenu ou ses messages sont affichés. 

### **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez vouloir utiliser les commentaires pour fournir des retours ou communiquer avec vos collègues lors de la révision des présentations.

* La classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui contient les collections d’auteurs (à partir de la méthode [get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Les auteurs ajoutent des commentaires aux diapositives. 
* L'interface [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection) qui contient la collection de commentaires pour chaque auteur. 
* La classe [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) qui contient des informations sur les auteurs et leurs commentaires : qui a ajouté le commentaire, l'heure à laquelle le commentaire a été ajouté, la position du commentaire, etc. 
* La classe [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author) qui contient des informations sur chaque auteur : le nom de l’auteur, ses initiales, les commentaires associés à son nom, etc. 

## **Ajouter un commentaire à une diapositive**
Ce code C++ montre comment ajouter un commentaire à une diapositive dans une présentation PowerPoint :
```cpp
// Instancie la classe Presentation
auto presentation = System::MakeObject<Presentation>();
// Ajoute une diapositive vide
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Ajoute un auteur
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Définit la position des commentaires
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Accède à ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Accède à ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Ajoute un commentaire de diapositive pour un auteur sur la diapositive 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Ajoute un commentaire de diapositive pour un auteur sur la diapositive 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Lorsqu'un null est passé en argument, les commentaires de tous les auteurs sont récupérés pour la diapositive sélectionnée
auto comments = slide1->GetSlideComments(author);

// Accède au commentaire à l'index 0 pour la diapositive 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Sélectionne la collection de commentaires de l'auteur à l'index 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```


## **Accéder aux commentaires d’une diapositive**
Ce code C++ montre comment accéder à un commentaire existant sur une diapositive dans une présentation PowerPoint :
```cpp
// Instancie la classe Presentation
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


## **Répondre aux commentaires**

Un commentaire parent est le commentaire principal ou original dans une hiérarchie de commentaires ou de réponses. En utilisant la propriété [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (de l'interface [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)), vous pouvez définir ou obtenir un commentaire parent. 

Ce code C++ montre comment ajouter des commentaires et récupérer leurs réponses :
```cpp
auto pres = System::MakeObject<Presentation>();

// Accède à ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Ajoute un commentaire
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Ajoute une réponse au commentaire1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Ajoute une autre réponse au commentaire1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Ajoute une réponse à la réponse existante
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Affiche la hiérarchie des commentaires sur la console
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

// Supprime le commentaire1 et toutes ses réponses
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```


{{% alert color="warning" title="Attention" %}} 

* Lorsque la méthode [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (de l'interface [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)) est utilisée pour supprimer un commentaire, les réponses au commentaire sont également supprimées. 
* Si le paramètre [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) entraîne une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) sera levée.

{{% /alert %}}

## **Ajouter un commentaire moderne**

En 2021, Microsoft a introduit les *commentaires modernes* dans PowerPoint. La fonctionnalité de commentaires modernes améliore considérablement la collaboration dans PowerPoint. Grâce aux commentaires modernes, les utilisateurs de PowerPoint peuvent résoudre les commentaires, ancrer les commentaires à des objets et du texte, et interagir beaucoup plus facilement qu'auparavant. 

Dans [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/), nous avons implémenté la prise en charge des commentaires modernes en ajoutant la classe [ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment). Les méthodes [AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) et [InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) ont été ajoutées à la classe [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection).

Ce code C++ montre comment ajouter un commentaire moderne à une diapositive dans une présentation PowerPoint : 
```cpp
auto pres = System::MakeObject<Presentation>();
// Accède à ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Supprimer un commentaire**

### **Supprimer tous les commentaires et auteurs**

Ce code C++ montre comment supprimer tous les commentaires et auteurs d’une présentation :
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Supprime tous les commentaires de la présentation
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Supprime tous les auteurs
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```


### **Supprimer des commentaires spécifiques**

Ce code C++ montre comment supprimer des commentaires spécifiques sur une diapositive :
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// ajouter des commentaires...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// supprimer tous les commentaires qui contiennent le texte "comment 1"
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

**Aspose.Slides prend‑il en charge un statut comme « résolu » pour les commentaires modernes ?**

Oui. Les [commentaires modernes](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/) exposent les méthodes [get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/get_status/) et [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/set_status/). Vous pouvez lire et définir l’[état d’un commentaire](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) (par exemple, le marquer comme résolu), et cet état est enregistré dans le fichier et reconnu par PowerPoint.

**Les discussions en fil (chaînes de réponses) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/comment/set_parentcomment/), permettant des chaînes de réponses arbitraires. L’API ne déclare pas de limite de profondeur spécifique.

**Dans quel système de coordonnées la position du marqueur de commentaire est‑elle définie sur une diapositive ?**

La position est stockée comme un point à virgule flottante dans le système de coordonnées de la diapositive. Cela vous permet de placer le marqueur de commentaire exactement où vous le souhaitez.