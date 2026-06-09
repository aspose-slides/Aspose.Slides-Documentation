---
title: Gerenciar Comentários de Apresentação em C++
linktitle: Comentários de Apresentação
type: docs
weight: 100
url: /pt/cpp/presentation-comments/
keywords:
- comentário
- comentário moderno
- comentários do PowerPoint
- comentários de apresentação
- comentários de slide
- adicionar comentário
- acessar comentário
- editar comentário
- responder comentário
- remover comentário
- excluir comentário
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Domine os comentários de apresentação com Aspose.Slides para C++: adicione, leia, edite e exclua comentários em arquivos PowerPoint de forma rápida e fácil."
---
## **Visão geral**

Este artigo explica como gerenciar comentários de apresentação no Aspose.Slides. Ele mostra os principais tipos relacionados a comentários e demonstra como adicionar comentários aos slides, acessar comentários existentes, trabalhar com respostas, usar comentários modernos e remover comentários de uma apresentação.

Os exemplos focam em cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o conteúdo e os metadados dos comentários, criar cadeias de respostas e limpar todos os comentários ou excluir os selecionados.

No PowerPoint, um comentário aparece como uma nota ou anotação em um slide. Quando um comentário é clicado, seu conteúdo ou mensagens são revelados.

### **Por que adicionar comentários às apresentações?**

Você pode querer usar comentários para fornecer feedback ou se comunicar com seus colegas ao revisar apresentações.

Para permitir que você use comentários em apresentações PowerPoint, o Aspose.Slides for C++ fornece

* A classe [Apresentação](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation), que contém as coleções de autores (do método [get_CommentAuthors()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Os autores adicionam comentários aos slides. 
* A interface [ICommentCollection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_comment_collection), que contém a coleção de comentários para autores individuais. 
* A classe [IComment](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_comment), que contém informações sobre autores e seus comentários: quem adicionou o comentário, a hora em que o comentário foi adicionado, a posição do comentário, etc. 
* A classe [CommentAuthor](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.comment_author), que contém informações sobre autores individuais: o nome do autor, suas iniciais, comentários associados ao nome do autor, etc. 

## **Adicionar um comentário de slide**
Este código C++ mostra como adicionar um comentário a um slide em uma apresentação PowerPoint:

```cpp
// Instancia a classe Presentation
auto presentation = System::MakeObject<Presentation>();
// Adiciona um slide vazio
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Adiciona um autor
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Define a posição dos comentários
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Acessa ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Acessa ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Adiciona comentário de slide para um autor no slide 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Adiciona comentário de slide para um autor no slide 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Quando null é passado como argumento, comentários de todos os autores são trazidos para o slide selecionado
auto comments = slide1->GetSlideComments(author);

// Acessa o comentário no índice 0 para o slide 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Seleciona a coleção de comentários do autor no índice 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Acessar comentários de slide**
Este código C++ mostra como acessar um comentário existente em um slide em uma apresentação PowerPoint:

```cpp
// Instancia a classe Presentation
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


## **Responder a comentários**
Um comentário pai é o comentário original ou principal em uma hierarquia de comentários ou respostas. Usando a propriedade [ParentComment](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (da interface [IComment](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_comment)), você pode definir ou obter um comentário pai. 

Este código C++ mostra como adicionar comentários e obter respostas a eles:

```cpp
auto pres = System::MakeObject<Presentation>();

// Acessa ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Adiciona um comentário
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Adiciona uma resposta ao comentário1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Adiciona outra resposta ao comentário1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Adiciona uma resposta a uma resposta existente
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Exibe a hierarquia de comentários no console
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

// Remove o comentário1 e todas as respostas a ele
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 

* Quando o método [Remove](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (da interface [IComment](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_comment)) é usado para excluir um comentário, as respostas ao comentário também são excluídas. 
* Se a configuração de [ParentComment](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) resultar em uma referência circular, será lançada a exceção [PptxEditException](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).

{{% /alert %}}

## **Adicionar um comentário moderno**

Em 2021, a Microsoft introduziu *comentários modernos* no PowerPoint. O recurso de comentários modernos melhora significativamente a colaboração no PowerPoint. Por meio dos comentários modernos, os usuários do PowerPoint podem resolver comentários, ancorar comentários a objetos e textos e interagir de forma muito mais fácil do que antes. 

No [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/pt/cpp/aspose-slides-for-cpp-21-11-release-notes/), implementamos suporte a comentários modernos adicionando a classe [ModernComment](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.modern_comment). Os métodos [AddModernComment](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) e [InsertModernComment](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) foram adicionados à classe [CommentCollection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.comment_collection).

Este código C++ mostra como adicionar um comentário moderno a um slide em uma apresentação PowerPoint: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Acessa ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Remover um comentário**

### **Excluir todos os comentários e autores**

Este código C++ mostra como remover todos os comentários e autores em uma apresentação:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Exclui todos os comentários da apresentação
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Exclui todos os autores
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Excluir comentários específicos**

Este código C++ mostra como excluir comentários específicos em um slide:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// adiciona comentários...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// remove todos os comentários que contêm o texto "comment 1"
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

**O Aspose.Slides oferece um status como “resolvido” para comentários modernos?**

Sim. Os [comentários modernos](https://reference.aspose.com/slides/pt/cpp/aspose.slides/moderncomment/) expõem os métodos [get_Status](https://reference.aspose.com/slides/pt/cpp/aspose.slides/moderncomment/get_status/) e [set_Status](https://reference.aspose.com/slides/pt/cpp/aspose.slides/moderncomment/set_status/); você pode ler e definir o [estado do comentário](https://reference.aspose.com/slides/pt/cpp/aspose.slides/moderncommentstatus/) (por exemplo, marcá‑lo como resolvido), e esse estado é salvo no arquivo e reconhecido pelo PowerPoint.

**As discussões em cadeia (cadeias de respostas) são suportadas e existe um limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [comentário pai](https://reference.aspose.com/slides/pt/cpp/aspose.slides/comment/set_parentcomment/), permitindo cadeias de respostas arbitrárias. A API não declara um limite específico de profundidade de aninhamento.

**Em que sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição é armazenada como um ponto de ponto flutuante no sistema de coordenadas do slide. Isso permite que você posicione o marcador de comentário precisamente onde precisar.