---
title: Commentaires de présentation
type: docs
weight: 100
url: /cpp/presentation-comments/
keywords: "Commentaires, commentaires PowerPoint, présentation PowerPoint, C++, Aspose.Slides pour C++"
description: "Ajoutez des commentaires et des réponses dans une présentation PowerPoint en C++"
---

Dans PowerPoint, un commentaire apparaît comme une note ou une annotation sur une diapositive. Lorsqu'un commentaire est cliqué, son contenu ou ses messages sont révélés.

### **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez utiliser des commentaires pour donner des retours ou communiquer avec vos collègues lorsque vous examinez des présentations.

Pour vous permettre d'utiliser des commentaires dans les présentations PowerPoint, Aspose.Slides pour C++ fournit

* La classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), qui contient les collections d'auteurs (à partir de la méthode [get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Les auteurs ajoutent des commentaires aux diapositives.
* L'interface [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection), qui contient la collection de commentaires pour des auteurs individuels.
* La classe [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment), qui contient des informations sur les auteurs et leurs commentaires : qui a ajouté le commentaire, à quel moment le commentaire a été ajouté, la position du commentaire, etc.
* La classe [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author), qui contient des informations sur des auteurs individuels : le nom de l'auteur, ses initiales, les commentaires associés au nom de l'auteur, etc.

## **Ajouter un commentaire sur une diapositive**
Ce code C++ vous montre comment ajouter un commentaire à une diapositive dans une présentation PowerPoint :

```cpp
// Instancie la classe Presentation
auto presentation = System::MakeObject<Presentation>();
// Ajoute une diapositive vide
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Ajoute un auteur
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Définit la position pour les commentaires
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Accède à ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Accède à ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Ajoute un commentaire de diapositive pour un auteur sur la diapositive 1
author->get_Comments()->AddComment(u"Salut Jawad, ceci est un commentaire de diapositive", slide1, point, DateTime::get_Now());

// Ajoute un commentaire de diapositive pour un auteur sur la diapositive 2
author->get_Comments()->AddComment(u"Salut Jawad, ceci est le deuxième commentaire de diapositive", slide2, point, DateTime::get_Now());

// Lorsque null est passé comme argument, les commentaires de tous les auteurs sont apportés à la diapositive sélectionnée
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

## **Accéder aux commentaires de diapositives**
Ce code C++ vous montre comment accéder à un commentaire existant sur une diapositive dans une présentation PowerPoint :

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
                        + u" a le commentaire : " + comment->get_Text()
                        + u" avec l'auteur : " + comment->get_Author()->get_Name()
                        + u" posté à l'heure :" + comment->get_CreatedTime() + u"\n");
    }
}
```

## **Répondre aux commentaires**
Un commentaire parent est le commentaire d'origine dans une hiérarchie de commentaires ou de réponses. En utilisant la propriété [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (de l'interface [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)), vous pouvez définir ou obtenir un commentaire parent.

Ce code C++ vous montre comment ajouter des commentaires et obtenir des réponses à ceux-ci :

```cpp
auto pres = System::MakeObject<Presentation>();

// Accède à ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Ajoute un commentaire
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Auteur_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"commentaire1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Ajoute une réponse à commentaire1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Auteur_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"réponse 1 pour commentaire 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Ajoute une autre réponse à commentaire1
auto reply2 = author2->get_Comments()->AddComment(u"réponse 2 pour commentaire 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Ajoute une réponse à une réponse existante
auto subReply = author1->get_Comments()->AddComment(u"sous-réponse 3 pour réponse 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"commentaire 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"commentaire 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"réponse 4 pour commentaire 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Affiche la hiérarchie des commentaires dans la console
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

// Supprime commentaire1 et toutes les réponses à celui-ci
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 

* Lorsque la méthode [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (de l'interface [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)) est utilisée pour supprimer un commentaire, les réponses au commentaire sont également supprimées.
* Si l'attribut [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) crée une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) sera lancée.

{{% /alert %}}

## **Ajouter un commentaire moderne**

En 2021, Microsoft a introduit les *commentaires modernes* dans PowerPoint. La fonctionnalité de commentaires modernes améliore considérablement la collaboration dans PowerPoint. Grâce aux commentaires modernes, les utilisateurs de PowerPoint peuvent résoudre des commentaires, ancrer des commentaires à des objets et des textes, et interagir beaucoup plus facilement qu'auparavant.

Dans [Aspose Slides pour C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/), nous avons implémenté le support des commentaires modernes en ajoutant la classe [ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment). Les méthodes [AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) et [InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) ont été ajoutées à la classe [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection).

Ce code C++ vous montre comment ajouter un commentaire moderne à une diapositive dans une présentation PowerPoint :

```cpp
auto pres = System::MakeObject<Presentation>();
// Accède à ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Un Auteur", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"Ceci est un commentaire moderne", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Supprimer un commentaire**

### **Supprimer tous les commentaires et auteurs**

Ce code C++ vous montre comment supprimer tous les commentaires et auteurs dans une présentation :

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

Ce code C++ vous montre comment supprimer des commentaires spécifiques sur une diapositive :

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// ajoute des commentaires...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Auteur", u"A");
author->get_Comments()->AddComment(u"commentaire 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"commentaire 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// supprime tous les commentaires contenant le texte "commentaire 1"
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"commentaire 1")
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