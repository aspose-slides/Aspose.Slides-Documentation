---
title: Gestionar comentarios de presentación en C++
linktitle: Comentarios de la presentación
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
description: "Gestiona los comentarios de presentación con Aspose.Slides para C++: añade, lee, edita, responde y elimina comentarios en presentaciones de PowerPoint de forma rápida y sencilla."
---
## **Visión general**

Este artículo explica cómo gestionar los comentarios de una presentación con Aspose.Slides for C++. Introduce los tipos principales relacionados con los comentarios y muestra cómo añadir comentarios a diapositivas, acceder a los comentarios existentes, trabajar con respuestas y comentarios modernos, y eliminar comentarios de una presentación.

Los ejemplos cubren escenarios comunes de revisión y colaboración en PowerPoint, como asignar comentarios a autores, leer el texto y los metadatos de los comentarios, crear cadenas de respuestas y eliminar comentarios seleccionados o todos los comentarios.

En PowerPoint, los comentarios aparecen como anotaciones en las diapositivas. Seleccionar un comentario muestra su texto y la discusión relacionada.

Para solicitar que los comentarios se muestren u oculten al abrir una presentación sin modificar los propios comentarios, consulte [Mostrar u Ocultar Comentarios al Abrir una Presentación](/slides/es/cpp/presentation-view-properties/).

## **¿Por qué añadir comentarios a presentaciones?**

Puede usar los comentarios para proporcionar retroalimentación y colaborar con colegas al revisar presentaciones.

Aspose.Slides for C++ ofrece las siguientes API para trabajar con comentarios:

* La clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) que proporciona acceso a los autores de comentarios de la presentación.
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) que representa los comentarios asociados a un autor concreto.
* La interfaz [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) que brinda información sobre un comentario, incluido su autor, hora de creación, posición y texto.
* La clase [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) que proporciona información sobre un autor, incluido su nombre, iniciales y los comentarios asociados.

## **Añadir comentarios a diapositivas**

El ejemplo crea dos diapositivas y registra un autor de comentario con [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/). Utiliza [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) para colocar un comentario en cada diapositiva, y luego recupera los comentarios de la primera diapositiva para ese autor con [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/). La consola muestra el texto del primer comentario dos veces, demostrando el acceso tanto a través de la diapositiva como del autor, y la presentación guardada contiene ambos comentarios.

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

## **Buscar o crear un autor de comentario**

Cuando una revisión automatizada procesa la misma presentación repetidamente, busque en la colección devuelta por [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) antes de añadir un autor. [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) coincide tanto con el nombre como con las iniciales y devuelve una matriz de autores coincidentes, o una matriz vacía si no existen coincidencias. En contraste, [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) busca sólo por nombre, sin importar las iniciales. Llamar a [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) con un nombre e iniciales ya presentes en la colección lanza una excepción.

El ejemplo requiere un archivo de presentación con al menos una diapositiva. En cada una de dos pasadas, reutiliza el primer autor coincidente, o crea uno solo cuando el resultado está vacío. Si hay varias coincidencias, selecciona el primer elemento de la matriz sin combinar ni eliminar los demás autores. A continuación llama a [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) para el autor seleccionado y guarda la presentación. La segunda pasada abre la salida de la primera pasada y repite la operación.

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

La segunda pasada añade otro comentario sin agregar otro autor ni eliminar los comentarios existentes. El archivo final, `review_pass_2.pptx`, contiene ambos comentarios nuevos junto a los comentarios originales. Reutilizar un autor no deduplica los comentarios: para evitar añadir repetidamente el mismo comentario, implemente una detección de duplicados separada antes de añadirlo.

## **Acceder a los comentarios de diapositivas**

El ejemplo abre una presentación existente y lee la colección devuelta por [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/). Para cada autor, itera a través de la colección devuelta por [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) e imprime el número de diapositiva, el texto del comentario, el nombre del autor y la hora de creación. La presentación de entrada debe contener comentarios para producir salida en la consola.

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

Un comentario padre es el comentario original en la parte superior de una jerarquía de respuestas. Los métodos [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) y [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) de la interfaz [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) permiten obtener o establecer el comentario padre.

El ejemplo crea comentarios de dos autores y usa [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) para construir respuestas, incluida una respuesta a otra respuesta. Pasar `nullptr` a [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) recupera los comentarios de todos los autores; la consola sangra cada entrada según su profundidad en la jerarquía de respuestas. El ejemplo guarda la discusión completa, llama a [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) sobre el primer comentario raíz y guarda una segunda presentación con ese comentario y sus respuestas eliminados.

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
    }

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

rootComment->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* Cuando se usa el método [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) de la interfaz [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) para eliminar un comentario, también se eliminan todas las respuestas a ese comentario.
* Si el método [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) crea una referencia circular, se lanza una [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Añadir comentarios modernos**

Los comentarios modernos pueden asociarse a la propia diapositiva, a una forma concreta o a un rango de texto dentro de un AutoShape. El método [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) acepta un argumento [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) además de la diapositiva y las coordenadas del marcador del comentario.

Cuando se pasa `nullptr` para el argumento de forma, el comentario es un comentario a nivel de diapositiva. Su marcador se posiciona mediante las coordenadas suministradas, pero no está asociado a una forma concreta, por lo que [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) devuelve `nullptr`. Cuando se proporciona un [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), el comentario se ancla a esa forma. Las coordenadas continúan definiendo la posición del marcador del comentario en la diapositiva, mientras que la asociación a la forma puede recuperarse mediante [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/).

### **Anclar un comentario moderno a una forma**

El ejemplo llama a [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) dos veces: una vez con una forma `nullptr` para un comentario a nivel de diapositiva y otra con un rectángulo como ancla. Llamar a [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) imprime `True` para la comprobación nula del comentario a nivel de diapositiva y `Revenue title` para el comentario anclado. Ambos comentarios se guardan con la presentación.

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

Cualquier objeto de diapositiva que implemente [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) puede usarse como ancla de forma. Los ejemplos más habituales incluyen [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/) e instancias de [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) como gráficos.

El ejemplo usa [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) para asociar un comentario a cada uno de cinco tipos de forma: un AutoShape, un marco de imagen, un grupo, un conector y un gráfico. La imagen del marco está incrustada, por lo que no se requiere una imagen externa. Cada comentario tiene su propia posición de marcador, y la presentación guardada conserva las cinco asociaciones de forma.

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

Para un comentario moderno asociado a un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), los métodos [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) y [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) controlan la posición inicial del texto seleccionado en el marco de texto de la forma. De forma similar, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) y [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) controlan la longitud de la selección. Juntos, estos métodos asocian el comentario a un rango de texto específico dentro del AutoShape.

Los métodos [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) y [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) utilizan un valor de la enumeración [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — no se ha definido un estado específico para el comentario moderno.
- `Active` — el comentario está activo.
- `Resolved` — el comentario se ha resuelto.
- `Closed` — el comentario está cerrado.

El ejemplo ancla un comentario moderno a las palabras “quarterly revenue” en el texto de un rectángulo. Calcula el inicio de la selección (cero basado) a partir del texto, lo pasa a [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/), y llama a [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) con el número de caracteres seleccionados. Después de llamar a [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) con `Resolved`, guarda y vuelve a abrir la presentación. Las cuatro comprobaciones en la consola deberían imprimir `True`, confirmando que se conservó la ancla de forma, el rango de texto y el estado.

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

El ejemplo requiere una presentación existente que contenga comentarios modernos y muestra su texto, estado y detalles de anclaje. Para inspeccionarla, compruebe qué comentarios implementan [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/), luego examine [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) y [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/). Una forma `nullptr` indica un comentario a nivel de diapositiva. Para una ancla [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), los métodos de selección de texto identifican el rango asociado en el marco de texto de la forma.

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

Aspose.Slides for C++ permite eliminar todos los comentarios y sus autores de una presentación o suprimir comentarios seleccionados manteniendo el resto. Los ejemplos siguientes demuestran ambos enfoques y guardan la presentación actualizada.

### **Eliminar todos los comentarios y autores de comentarios**

El ejemplo abre una presentación existente y llama a [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) para cada autor, y luego llama a [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) para eliminar a los propios autores. La presentación guardada no contiene ni comentarios ni autores de comentarios. Use una presentación que contenga comentarios para observar la eliminación.

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

El ejemplo crea dos comentarios en una diapositiva y usa [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) para encontrar los comentarios de cada autor. Recoge los comentarios cuyo texto sea “comment 1” antes de llamar a [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/), evitando cambios en la colección durante la selección. La presentación guardada conserva sólo “comment 2”.

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

**¿Aspose.Slides soporta un estado resuelto para los comentarios modernos?**

Sí. [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) y [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) utilizan un valor de [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/), incluido `Resolved`. El estado se almacena en la presentación y puede leerse nuevamente tras volver a abrir el archivo.

**¿Se admiten discusiones en hilos (cadenas de respuestas), y hay un límite de anidación?**

Sí. Cada comentario puede referenciar su [comentario padre](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/), lo que permite crear cadenas de respuestas. La API no define un límite específico de profundidad de anidación.

**¿En qué sistema de coordenadas se define la posición del marcador de un comentario en una diapositiva?**

La posición del marcador se define mediante coordenadas de punto flotante en el sistema de coordenadas de la diapositiva, lo que permite colocarla con precisión en la misma.