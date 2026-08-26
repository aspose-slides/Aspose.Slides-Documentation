---
title: "Gérer les commentaires de présentation en C++"
linktitle: "Commentaires de présentation"
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
- accéder à un commentaire
- modifier un commentaire
- répondre à un commentaire
- supprimer un commentaire
- effacer un commentaire
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Gérez les commentaires de présentation avec Aspose.Slides pour C++ : ajoutez, lisez, modifiez, répondez et supprimez les commentaires dans les présentations PowerPoint rapidement et facilement."
---
## **Vue d'ensemble**

Cet article explique comment gérer les commentaires de présentation avec Aspose.Slides for C++. Il présente les principaux types liés aux commentaires et montre comment ajouter des commentaires aux diapositives, accéder aux commentaires existants, travailler avec les réponses et les commentaires modernes, et supprimer des commentaires d'une présentation.

Les exemples couvrent des scénarios courants de révision et de collaboration dans PowerPoint, comme l'attribution de commentaires aux auteurs, la lecture du texte et des métadonnées des commentaires, la création de chaînes de réponses, et la suppression de commentaires sélectionnés ou de tous les commentaires.

Dans PowerPoint, les commentaires apparaissent comme des annotations sur les diapositives. Sélectionner un commentaire affiche son texte et la discussion associée.

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez utiliser les commentaires pour fournir des retours et collaborer avec vos collègues lors de la révision de présentations.

Aspose.Slides for C++ propose les API suivantes pour travailler avec les commentaires :

* La classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) qui permet d'accéder aux auteurs des commentaires de la présentation.
* L’interface [ICommentCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icommentcollection/) qui représente les commentaires associés à un auteur individuel.
* L’interface [IComment](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icomment/) qui fournit des informations sur un commentaire, y compris son auteur, l'heure de création, la position et le texte.
* La classe [CommentAuthor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/commentauthor/) qui fournit des informations sur un auteur, notamment son nom, ses initiales et les commentaires associés.

## **Ajouter des commentaires aux diapositives**

L’exemple suivant montre comment ajouter des commentaires aux diapositives d’une présentation PowerPoint :

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

## **Accéder aux commentaires des diapositives**

L’exemple suivant montre comment accéder aux commentaires existants dans une présentation PowerPoint :

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

## **Répondre aux commentaires**

Un commentaire parent est le commentaire original au sommet d’une hiérarchie de réponses. Les méthodes [get_ParentComment](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icomment/get_parentcomment/) et [set_ParentComment](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icomment/set_parentcomment/) de l’interface [IComment](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icomment/) vous permettent d’obtenir ou de définir le parent d’un commentaire.

L’exemple suivant montre comment ajouter des réponses et inspecter la hiérarchie de commentaires résultante :

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
* Lorsque la méthode [Remove](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icomment/remove/) de l’interface [IComment](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icomment/) est utilisée pour supprimer un commentaire, toutes les réponses à ce commentaire sont également supprimées.
* Si la méthode [set_ParentComment](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icomment/set_parentcomment/) crée une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pptxeditexception/) est levée.
{{% /alert %}}

## **Ajouter des commentaires modernes**

Les commentaires modernes peuvent être associés à la diapositive elle‑même, à une forme spécifique ou à une plage de texte à l’intérieur d’une AutoShape. La méthode [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icommentcollection/addmoderncomment/) accepte un argument [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/) en plus de la diapositive et des coordonnées du marqueur de commentaire.

Lorsque `nullptr` est passé pour l’argument shape, le commentaire est un commentaire au niveau de la diapositive. Son marqueur est positionné selon les coordonnées fournies, mais il n’est associé à aucune forme particulière, ainsi [IModernComment::get_Shape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/get_shape/) renvoie `nullptr`. Lorsqu’une [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/) est fournie, le commentaire est ancré à cette forme. Les coordonnées définissent toujours la position du marqueur de commentaire sur la diapositive, tandis que l’association à la forme peut être récupérée via [IModernComment::get_Shape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/get_shape/).

### **Ancrer un commentaire moderne à une forme**

L’exemple suivant crée à la fois un commentaire moderne au niveau de la diapositive et un commentaire moderne ancré à une AutoShape spécifique. Il lit ensuite la forme associée à chaque commentaire.

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

### **Ancrer des commentaires à différents types de formes**

Toute objet de diapositive qui implémente [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/) peut être utilisé comme ancre de forme. Des exemples courants incluent [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iconnector/) et les instances de [IGraphicalObject](https://reference.aspose.com/slides/fr/cpp/aspose.slides/igraphicalobject/) comme les graphiques.

L’exemple suivant crée plusieurs types de formes courantes et associe un commentaire moderne à chacune d’elles.

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

### **Ancrer un commentaire au texte et définir son état**

Pour un commentaire moderne associé à une [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/), les méthodes [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/get_textselectionstart/) et [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/set_textselectionstart/) contrôlent la position de départ du texte sélectionné dans le cadre de texte de la forme. De même, les méthodes [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/get_textselectionlength/) et [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/set_textselectionlength/) contrôlent la longueur de la sélection. Ensemble, ces méthodes associent le commentaire à une plage de texte spécifique à l’intérieur de l’AutoShape.

Les méthodes [IModernComment::get_Status](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/get_status/) et [IModernComment::set_Status](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/set_status/) utilisent une valeur de l’énumération [ModernCommentStatus](https://reference.aspose.com/slides/fr/cpp/aspose.slides/moderncommentstatus/) :

- `NotDefined` — aucun statut de commentaire moderne spécifique n’est défini.
- `Active` — le commentaire est actif.
- `Resolved` — le commentaire a été résolu.
- `Closed` — le commentaire est fermé.

L’exemple suivant crée un commentaire moderne ancré à une forme, l’associe à une sélection de texte, le marque comme résolu, enregistre la présentation et vérifie les valeurs après avoir rouvert le fichier.

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

### **Inspecter les commentaires modernes existants**

Pour inspecter une présentation existante, vérifiez quels commentaires implémentent [IModernComment](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/), puis examinez [IModernComment::get_Shape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/get_textselectionlength/) et [IModernComment::get_Status](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/get_status/). Une forme `nullptr` indique un commentaire au niveau de la diapositive. Pour une ancre [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/), les méthodes de sélection de texte identifient la plage associée dans le cadre de texte de la forme.

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

## **Supprimer les commentaires**

### **Supprimer tous les commentaires et les auteurs de commentaires**

L’exemple suivant montre comment supprimer tous les commentaires et tous les auteurs de commentaires d’une présentation :

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

### **Supprimer des commentaires spécifiques**

L’exemple suivant montre comment supprimer des commentaires spécifiques d’une diapositive :

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

**Aspose.Slides prend‑il en charge un statut résolu pour les commentaires modernes ?**

Oui. Les méthodes [IModernComment::get_Status](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/get_status/) et [IModernComment::set_Status](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imoderncomment/set_status/) utilisent une valeur [ModernCommentStatus](https://reference.aspose.com/slides/fr/cpp/aspose.slides/moderncommentstatus/), y compris `Resolved`. Le statut est stocké dans la présentation et peut être relu après la réouverture du fichier.

**Les discussions en fil (chaînes de réponses) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icomment/set_parentcomment/), ce qui permet les chaînes de réponses. L’API ne définit pas de limite spécifique de profondeur d’imbrication.

**Dans quel système de coordonnées la position d’un marqueur de commentaire est‑elle définie sur une diapositive ?**

La position du marqueur est défini par des coordonnées en virgule flottante dans le système de coordonnées de la diapositive, ce qui vous permet de le placer avec précision sur la diapositive.