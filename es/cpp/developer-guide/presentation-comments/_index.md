---
title: Comentarios de Presentación
type: docs
weight: 100
url: /cpp/presentation-comments/
keywords: "Comentarios, comentarios de PowerPoint, presentación de PowerPoint, C++, Aspose.Slides para C++"
description: "Agregar comentarios y respuestas en presentación de PowerPoint en C++"
---

En PowerPoint, un comentario aparece como una nota o una anotación en una diapositiva. Cuando se hace clic en un comentario, se revelan su contenido o mensajes.

### **¿Por qué agregar comentarios a las presentaciones?**

Puede que desee usar comentarios para proporcionar retroalimentación o comunicarse con sus colegas cuando revise presentaciones.

Para permitirle usar comentarios en las presentaciones de PowerPoint, Aspose.Slides para C++ proporciona

* La clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), que contiene las colecciones de autores (del método [get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Los autores agregan comentarios a las diapositivas. 
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection), que contiene la colección de comentarios para autores individuales. 
* La clase [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment), que contiene información sobre los autores y sus comentarios: quién agregó el comentario, la hora en que se agregó el comentario, la posición del comentario, etc. 
* La clase [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author), que contiene información sobre autores individuales: el nombre del autor, sus iniciales, comentarios asociados con el nombre del autor, etc. 

## **Agregar Comentario a la Diapositiva**
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
author->get_Comments()->AddComment(u"Hola Jawad, este es un comentario de diapositiva", slide1, point, DateTime::get_Now());

// Agrega un comentario de diapositiva para un autor en la diapositiva 2
author->get_Comments()->AddComment(u"Hola Jawad, este es el segundo comentario de diapositiva", slide2, point, DateTime::get_Now());

// Cuando se pasa null como argumento, se traen los comentarios de todos los autores a la diapositiva seleccionada
auto comments = slide1->GetSlideComments(author);

// Accede al comentario en el índice 0 para la diapositiva 1
String str = comments[0]->get_Text();

presentation->Save(u"Comentarios_salida.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Selecciona la colección de comentarios del autor en el índice 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Acceder a Comentarios de Diapositivas**
Este código C++ le muestra cómo acceder a un comentario existente en una diapositiva en una presentación de PowerPoint:

```cpp
// Instancia la clase Presentation
auto presentation = System::MakeObject<Presentation>(u"Comentarios1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" tiene comentario: " + comment->get_Text()
                        + u" con Autor: " + comment->get_Author()->get_Name()
                        + u" publicado a la hora :" + comment->get_CreatedTime() + u"\n");
    }
}
```


## **Responder Comentarios**
Un comentario padre es el comentario original o superior en una jerarquía de comentarios o respuestas. Usando la propiedad [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (de la interfaz [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)), puede establecer o obtener un comentario padre. 

Este código C++ le muestra cómo agregar comentarios y obtener respuestas a ellos:

```cpp
auto pres = System::MakeObject<Presentation>();

// Accede a ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Agrega un comentario
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Autor_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comentario1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Agrega una respuesta a comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autor_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"respuesta 1 para comentario 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Agrega otra respuesta a comment1
auto reply2 = author2->get_Comments()->AddComment(u"respuesta 2 para comentario 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Agrega una respuesta a respuesta existente
auto subReply = author1->get_Comments()->AddComment(u"subrespuesta 3 para respuesta 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comentario 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comentario 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"respuesta 4 para comentario 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
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

pres->Save(u"comentario_padre.pptx", SaveFormat::Pptx);

// Elimina comment1 y todas las respuestas a él
comment1->Remove();

pres->Save(u"eliminar_comentario.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Atención" %}} 

* Cuando se utiliza el método [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (de la interfaz [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)) para eliminar un comentario, las respuestas al comentario también se eliminan. 
* Si la configuración [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) resulta en una referencia circular, se lanzará una [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).

{{% /alert %}}

## **Agregar Comentario Moderno**

En 2021, Microsoft introdujo *comentarios modernos* en PowerPoint. La función de comentarios modernos mejora significativamente la colaboración en PowerPoint. A través de comentarios modernos, los usuarios de PowerPoint pueden resolver comentarios, anclar comentarios a objetos y textos, y participar en interacciones de manera mucho más fácil que antes.

En [Aspose Slides para C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/), implementamos soporte para comentarios modernos al agregar la clase [ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment). Se añadieron los métodos [AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) y [InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) a la clase [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection).

Este código C++ le muestra cómo agregar un comentario moderno a una diapositiva en una presentación de PowerPoint: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Accede a ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Algún Autor", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"Este es un comentario moderno", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Eliminar Comentario**

### **Eliminar Todos los Comentarios y Autores**

Este código C++ le muestra cómo eliminar todos los comentarios y autores en una presentación:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"ejemplo.pptx");

// Elimina todos los comentarios de la presentación
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Elimina todos los autores
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"ejemplo_salida.pptx", SaveFormat::Pptx);

```

### **Eliminar Comentarios Específicos**

Este código C++ le muestra cómo eliminar comentarios específicos en una diapositiva:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// agregar comentarios...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Autor", u"A");
author->get_Comments()->AddComment(u"comentario 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comentario 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// eliminar todos los comentarios que contienen el texto "comentario 1"
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comentario 1")
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