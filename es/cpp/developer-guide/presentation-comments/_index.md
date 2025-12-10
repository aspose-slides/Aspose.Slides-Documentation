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
- agregar comentario
- acceder a comentario
- editar comentario
- responder comentario
- eliminar comentario
- borrar comentario
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Domine los comentarios de presentación con Aspose.Slides para C++: agregue, lea, edite y elimine comentarios en archivos de PowerPoint rápida y fácilmente."
---

En PowerPoint, un comentario aparece como una nota o anotación en una diapositiva. Cuando se hace clic en un comentario, se revelan sus contenidos o mensajes. 

### **¿Por qué agregar comentarios a presentaciones?**

Puede que desee usar comentarios para proporcionar retroalimentación o comunicarse con sus colegas al revisar presentaciones.

Para permitirle usar comentarios en presentaciones de PowerPoint, Aspose.Slides for C++ ofrece

* La clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que contiene las colecciones de autores (del método [get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Los autores añaden comentarios a las diapositivas. 
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection) que contiene la colección de comentarios para autores individuales. 
* La clase [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) que contiene información sobre los autores y sus comentarios: quién añadió el comentario, la hora en que se añadió, la posición del comentario, etc. 
* La clase [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author) que contiene información sobre autores individuales: el nombre del autor, sus iniciales, los comentarios asociados al nombre del autor, etc. 

## **Agregar un comentario a una diapositiva**
Este código C++ le muestra cómo agregar un comentario a una diapositiva en una presentación de PowerPoint:
```cpp
// Instancia la clase Presentation
auto presentation = System::MakeObject<Presentation>();
// Agrega una diapositiva vacía
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Agrega un autor
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Establece la posición para los comentarios
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Accede a ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Accede a ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Agrega un comentario de diapositiva para un autor en la diapositiva 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Agrega un comentario de diapositiva para un autor en la diapositiva 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Cuando se pasa null como argumento, los comentarios de todos los autores se traen a la diapositiva seleccionada
auto comments = slide1->GetSlideComments(author);

// Accede al comentario en el índice 0 de la diapositiva 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Selecciona la colección de comentarios del Autor en el índice 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```


## **Acceder a los comentarios de la diapositiva**
Este código C++ le muestra cómo acceder a un comentario existente en una diapositiva de una presentación de PowerPoint:
```cpp
// Instancia la clase Presentation
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


## **Responder a comentarios**
Un comentario principal es el comentario superior u original en una jerarquía de comentarios o respuestas. Usando la propiedad [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (de la interfaz [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)), puede establecer o obtener un comentario principal. 

Este código C++ le muestra cómo agregar comentarios y obtener sus respuestas:
```cpp
auto pres = System::MakeObject<Presentation>();

// Accede a ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Añade un comentario
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Añade una respuesta a comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Añade otra respuesta a comment1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Añade una respuesta a la respuesta existente
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Muestra la jerarquía de comentarios en la consola
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

// Elimina comment1 y todas sus respuestas
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```


{{% alert color="warning" title="Attention" %}} 

* Cuando se usa el método [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (de la interfaz [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)) para eliminar un comentario, también se eliminan las respuestas al comentario. 
* Si la configuración [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) resulta en una referencia circular, se lanzará [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).

{{% /alert %}}

## **Agregar un comentario moderno**

En 2021, Microsoft introdujo *comentarios modernos* en PowerPoint. La función de comentarios modernos mejora significativamente la colaboración en PowerPoint. A través de los comentarios modernos, los usuarios de PowerPoint pueden resolver comentarios, anclar comentarios a objetos y textos, y participar en interacciones de forma mucho más fácil que antes. 

En [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/), implementamos soporte para comentarios modernos añadiendo la clase [ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment). Los métodos [AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) y [InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) se añadieron a la clase [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection).

Este código C++ le muestra cómo agregar un comentario moderno a una diapositiva en una presentación de PowerPoint: 
```cpp
auto pres = System::MakeObject<Presentation>();
// Accede a ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Eliminar un comentario**

### **Eliminar todos los comentarios y autores**

Este código C++ le muestra cómo eliminar todos los comentarios y autores en una presentación:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Elimina todos los comentarios de la presentación
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Elimina todos los autores
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```


### **Eliminar comentarios específicos**

Este código C++ le muestra cómo eliminar comentarios específicos en una diapositiva:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// agregar comentarios...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// eliminar todos los comentarios que contienen el texto "comment 1"
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


## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado como 'resuelto' para los comentarios modernos?**

Sí. Los [comentarios modernos](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/) exponen los métodos [get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/get_status/) y [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/set_status/). Puede leer y establecer el [estado del comentario](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) (por ejemplo, marcarlo como resuelto), y este estado se guarda en el archivo y es reconocido por PowerPoint.

**¿Se admiten discusiones en hilo (cadenas de respuestas) y hay un límite de anidamiento?**

Sí. Cada comentario puede referenciar su [comentario principal](https://reference.aspose.com/slides/cpp/aspose.slides/comment/set_parentcomment/), lo que permite cadenas de respuestas arbitrarias. La API no declara un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de comentario en una diapositiva?**

La posición se almacena como un punto de coma flotante en el sistema de coordenadas de la diapositiva. Esto le permite colocar el marcador de comentario exactamente donde lo necesite.