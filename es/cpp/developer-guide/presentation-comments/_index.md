---
title: Administrar comentarios de presentación en C++
linktitle: Comentarios de presentación
type: docs
weight: 100
url: /es/cpp/presentation-comments/
keywords:
- comentario
- comentario moderno
- comentarios de PowerPoint
- comentarios de presentación
- comentarios de diapositiva
- añadir comentario
- acceder al comentario
- editar comentario
- responder comentario
- eliminar comentario
- borrar comentario
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Administre los comentarios de presentación con Aspose.Slides para C++: añada, lea, edite, responda y elimine comentarios en presentaciones de PowerPoint de forma rápida y sencilla."
---
## **Visión general**

Este artículo explica cómo gestionar los comentarios de presentación con Aspose.Slides para C++. Introduce los principales tipos relacionados con los comentarios y muestra cómo añadir comentarios a diapositivas, acceder a los comentarios existentes, trabajar con respuestas y comentarios modernos, y eliminar comentarios de una presentación.

Los ejemplos cubren escenarios comunes de revisión y colaboración en PowerPoint, como asignar comentarios a autores, leer el texto y los metadatos de los comentarios, construir cadenas de respuestas y eliminar comentarios seleccionados o todos los comentarios.

En PowerPoint, los comentarios aparecen como anotaciones en las diapositivas. Al seleccionar un comentario se muestra su texto y la discusión relacionada.

## **¿Por qué añadir comentarios a las presentaciones?**

Puede usar los comentarios para proporcionar retroalimentación y colaborar con colegas al revisar presentaciones.

Aspose.Slides para C++ ofrece las siguientes API para trabajar con comentarios:

* La clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) , que proporciona acceso a los autores de comentarios de la presentación.
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/icommentcollection/) , que representa los comentarios asociados a un autor individual.
* La interfaz [IComment](https://reference.aspose.com/slides/es/cpp/aspose.slides/icomment/) , que brinda información sobre un comentario, incluido su autor, hora de creación, posición y texto.
* La clase [CommentAuthor](https://reference.aspose.com/slides/es/cpp/aspose.slides/commentauthor/) , que proporciona información sobre un autor, incluido su nombre, iniciales y comentarios asociados.

## **Añadir comentarios a diapositivas**

La siguiente muestra cómo añadir comentarios a diapositivas en una presentación de PowerPoint:

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

## **Acceder a los comentarios de diapositivas**

La siguiente muestra cómo acceder a los comentarios existentes en una presentación de PowerPoint:

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

## **Responder a los comentarios**

Un comentario principal es el comentario original en la parte superior de una jerarquía de respuestas. Los métodos [get_ParentComment](https://reference.aspose.com/slides/es/cpp/aspose.slides/icomment/get_parentcomment/) y [set_ParentComment](https://reference.aspose.com/slides/es/cpp/aspose.slides/icomment/set_parentcomment/) de la interfaz [IComment](https://reference.aspose.com/slides/es/cpp/aspose.slides/icomment/) le permiten obtener o establecer el comentario principal de un comentario.

La siguiente muestra cómo añadir respuestas e inspeccionar la jerarquía de comentarios resultante:

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
* Cuando se usa el método [Remove](https://reference.aspose.com/slides/es/cpp/aspose.slides/icomment/remove/) de la interfaz [IComment](https://reference.aspose.com/slides/es/cpp/aspose.slides/icomment/) , todas las respuestas a ese comentario también se eliminan.
* Si el método [set_ParentComment](https://reference.aspose.com/slides/es/cpp/aspose.slides/icomment/set_parentcomment/) crea una referencia circular, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/cpp/aspose.slides/pptxeditexception/) .
{{% /alert %}}

## **Añadir comentarios modernos**

Los comentarios modernos pueden estar asociados a la propia diapositiva, a una forma específica o a un rango de texto dentro de una AutoShape. El método [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/es/cpp/aspose.slides/icommentcollection/addmoderncomment/) acepta un argumento [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/) además de la diapositiva y las coordenadas del marcador del comentario.

Cuando se pasa `nullptr` como argumento de forma, el comentario es un comentario a nivel de diapositiva. Su marcador se posiciona con las coordenadas suministradas, pero no está asociado a una forma concreta, por lo que [IModernComment::get_Shape](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/get_shape/) devuelve `nullptr`. Cuando se proporciona un [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/) , el comentario se ancla a esa forma. Las coordenadas siguen definiendo la posición del marcador del comentario en la diapositiva, mientras que la asociación con la forma puede obtenerse mediante [IModernComment::get_Shape](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/get_shape/) .

### **Anclar un comentario moderno a una forma**

La siguiente muestra crea tanto un comentario moderno a nivel de diapositiva como un comentario moderno anclado a una AutoShape específica. Luego lee la forma asociada a cada comentario.

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

### **Anclar comentarios a diferentes tipos de forma**

Cualquier objeto de diapositiva que implemente [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/) puede usarse como ancla de forma. Los ejemplos comunes incluyen [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) , [IPictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipictureframe/) , [IGroupShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/igroupshape/) , [IConnector](https://reference.aspose.com/slides/es/cpp/aspose.slides/iconnector/) y [IGraphicalObject](https://reference.aspose.com/slides/es/cpp/aspose.slides/igraphicalobject/) como gráficos.

La siguiente muestra crea varios tipos de forma comunes y asocia un comentario moderno con cada una.

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

### **Anclar un comentario a texto y establecer su estado**

Para un comentario moderno asociado a una [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) , los métodos [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/get_textselectionstart/) y [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/set_textselectionstart/) controlan la posición inicial del texto seleccionado en el marco de texto de la forma. De manera similar, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/get_textselectionlength/) y [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/set_textselectionlength/) controlan la longitud de la selección. Juntos, estos métodos asocian el comentario con un rango de texto específico dentro de la AutoShape.

Los métodos [IModernComment::get_Status](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/get_status/) y [IModernComment::set_Status](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/set_status/) utilizan un valor de la enumeración [ModernCommentStatus](https://reference.aspose.com/slides/es/cpp/aspose.slides/moderncommentstatus/) :

- `NotDefined` — no se define un estado específico para el comentario moderno.
- `Active` — el comentario está activo.
- `Resolved` — el comentario ha sido resuelto.
- `Closed` — el comentario está cerrado.

La siguiente muestra crea un comentario moderno anclado a una forma, lo asocia a una selección de texto, lo marca como resuelto, guarda la presentación y verifica los valores después de volver a abrir el archivo.

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

### **Inspeccionar comentarios modernos existentes**

Para inspeccionar una presentación existente, verifique qué comentarios implementan [IModernComment](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/) , luego examine [IModernComment::get_Shape](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/get_shape/) , [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/get_textselectionstart/) , [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/get_textselectionlength/) y [IModernComment::get_Status](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/get_status/) . Una forma `nullptr` indica un comentario a nivel de diapositiva. Para un ancla [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) , los métodos de selección de texto identifican el rango asociado en el marco de texto de la forma.

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

## **Eliminar comentarios**

### **Eliminar todos los comentarios y autores de comentarios**

La siguiente muestra cómo eliminar todos los comentarios y autores de comentarios de una presentación:

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

### **Eliminar comentarios específicos**

La siguiente muestra cómo eliminar comentarios específicos de una diapositiva:

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

## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado resuelto para los comentarios modernos?**

Sí. Los métodos [IModernComment::get_Status](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/get_status/) y [IModernComment::set_Status](https://reference.aspose.com/slides/es/cpp/aspose.slides/imoderncomment/set_status/) utilizan un valor de [ModernCommentStatus](https://reference.aspose.com/slides/es/cpp/aspose.slides/moderncommentstatus/) , incluido `Resolved`. El estado se almacena en la presentación y puede leerse nuevamente después de volver a abrir el archivo.

**¿Se admiten discusiones en hilos (cadenas de respuestas) y existe un límite de anidamiento?**

Sí. Cada comentario puede referenciar su [comentario principal](https://reference.aspose.com/slides/es/cpp/aspose.slides/icomment/set_parentcomment/) , lo que permite cadenas de respuestas. La API no define un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de un comentario en una diapositiva?**

La posición del marcador se define mediante coordenadas en coma flotante en el sistema de coordenadas de la diapositiva, lo que permite colocarlo con precisión en la diapositiva.