---
title: Gerenciar Comentários de Apresentação em Java
linktitle: Comentários de Apresentação
type: docs
weight: 100
url: /pt/java/presentation-comments/
keywords:
- comentário
- comentário moderno
- comentários do PowerPoint
- comentários da apresentação
- comentários de slide
- adicionar comentário
- acessar comentário
- editar comentário
- responder comentário
- remover comentário
- excluir comentário
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Gerencie comentários de apresentação com Aspose.Slides for Java: adicione, leia, edite, responda e remova comentários em apresentações PowerPoint rápida e facilmente."
---
## **Visão geral**

Este artigo explica como gerenciar comentários em apresentações com Aspose.Slides for Java. Ele apresenta os principais tipos relacionados a comentários e demonstra como adicionar comentários a slides, acessar comentários existentes, trabalhar com respostas e comentários modernos e remover comentários de uma apresentação.

Os exemplos cobrem cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o texto e os metadados dos comentários, criar cadeias de respostas e remover comentários selecionados ou todos os comentários.

No PowerPoint, os comentários aparecem como anotações nos slides. Selecionar um comentário exibe seu texto e a discussão relacionada.

## **Por que adicionar comentários a apresentações?**

Você pode usar comentários para fornecer feedback e colaborar com colegas ao revisar apresentações.

Aspose.Slides for Java fornece as seguintes APIs para trabalhar com comentários:

* A classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) fornece acesso aos autores de comentários da apresentação.
* A interface [ICommentCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icommentcollection/) representa os comentários associados a um autor individual.
* A interface [IComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icomment/) fornece informações sobre um comentário, incluindo seu autor, horário de criação, posição e texto.
* A classe [CommentAuthor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/commentauthor/) fornece informações sobre um autor, incluindo seu nome, iniciais e comentários associados.

## **Adicionar Comentários ao Slide**

O exemplo a seguir mostra como adicionar comentários a slides em uma apresentação PowerPoint:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    Point2D.Float position = new Point2D.Float(0.2f, 0.2f);
    Date createdTime = new Date();

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    IComment[] comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        IComment firstComment = comments[0];
        System.out.println(firstComment.getText());

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acessar Comentários do Slide**

O exemplo a seguir mostra como acessar comentários existentes em uma apresentação PowerPoint:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        for (IComment comment : author.getComments()) {
            System.out.println("Slide: " + comment.getSlide().getSlideNumber());
            System.out.println("Comment: " + comment.getText());
            System.out.println("Author: " + comment.getAuthor().getName());
            System.out.println("Posted at: " + comment.getCreatedTime());
            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Responder a Comentários**

Um comentário pai é o comentário original no topo de uma hierarquia de respostas. Os métodos [IComment.getParentComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icomment/#getParentComment--) e [IComment.setParentComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) permitem obter ou definir o pai de um comentário.

O exemplo a seguir mostra como adicionar respostas e inspecionar a hierarquia de comentários resultante:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Point2D.Float position = new Point2D.Float(10, 10);
    Date createdTime = new Date();

    ICommentAuthor author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    IComment comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++) {
        IComment comment = comments[i];
        while (comment.getParentComment() != null) {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() + ": " + comments[i].getText());
    }

    presentation.save("parent_comment.pptx", SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Quando o método [IComment.remove](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icomment/#remove--) é usado para excluir um comentário, todas as respostas a esse comentário também são excluídas.
* Se [IComment.setParentComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) criar uma referência circular, uma [PptxEditException](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pptxeditexception/) é lançada.
{{% /alert %}}

## **Adicionar Comentários Modernos**

Comentários modernos podem ser associados ao próprio slide, a uma forma específica ou a um intervalo de texto dentro de um AutoShape. O método [ICommentCollection.addModernComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) aceita um argumento [IShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/) além do slide e das coordenadas do marcador de comentário.

Quando `null` é passado para o argumento de forma, o comentário é um comentário de nível de slide. Seu marcador é posicionado pelas coordenadas fornecidas, mas não está associado a uma forma específica, portanto [IModernComment.getShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#getShape--) retorna `null`. Quando um [IShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/) é fornecido, o comentário fica ancorado a essa forma. As coordenadas ainda definem a posição do marcador de comentário no slide, enquanto a associação à forma pode ser obtida através de [IModernComment.getShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#getShape--).

### **Ancorar um Comentário Moderno a uma Forma**

O exemplo a seguir cria tanto um comentário moderno de nível de slide quanto um comentário moderno ancorado a um AutoShape específico. Em seguida, lê a forma associada de cada comentário.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    Point2D.Float slideCommentPosition = new Point2D.Float(20, 20);
    Point2D.Float shapeCommentPosition = new Point2D.Float(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ancorar Comentários a Diferentes Tipos de Forma**

Qualquer objeto de slide que implemente [IShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/) pode ser usado como âncora de forma. Exemplos comuns incluem [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iconnector/) e instâncias de [IGraphicalObject](https://reference.aspose.com/slides/pt/java/com.aspose.slides/igraphicalobject/) como gráficos.

O exemplo a seguir cria vários tipos de forma comuns e associa um comentário moderno a cada um deles.

```java
import com.aspose.slides.ChartType;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IChart;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IConnector;
import com.aspose.slides.IGroupShape;
import com.aspose.slides.IPPImage;
import com.aspose.slides.IPictureFrame;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    Point2D.Float autoShapeCommentPosition = new Point2D.Float(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    Point2D.Float pictureCommentPosition = new Point2D.Float(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    Point2D.Float groupCommentPosition = new Point2D.Float(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    Point2D.Float connectorCommentPosition = new Point2D.Float(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    Point2D.Float chartCommentPosition = new Point2D.Float(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ancorar um Comentário a Texto e Definir Seu Status**

Para um comentário moderno associado a um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/), os métodos [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) e [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) acessam a posição inicial do texto selecionado na caixa de texto da forma. Os métodos [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) e [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) acessam o comprimento da seleção. Juntos, esses valores associam o comentário a um intervalo de texto específico dentro do AutoShape.

Os métodos [IModernComment.getStatus](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#getStatus--) e [IModernComment.setStatus](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#setStatus-byte-) acessam um valor dos constantes [ModernCommentStatus](https://reference.aspose.com/slides/pt/java/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — nenhum status de comentário moderno específico está definido.
- `Active` — o comentário está ativo.
- `Resolved` — o comentário foi resolvido.
- `Closed` — o comentário está fechado.

O exemplo a seguir cria um comentário moderno ancorado a uma forma, associa‑o a uma seleção de texto, marca‑o como resolvido, salva a apresentação e verifica os valores após reabrir o arquivo.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.ModernCommentStatus;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

String outputFile = "modern_comment_text_anchor.pptx";
String shapeText = "Review the quarterly revenue forecast.";
String selectedText = "quarterly revenue";
int expectedSelectionStart = shapeText.indexOf(selectedText);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Point2D.Float commentPosition = new Point2D.Float(60, 60);
    IModernComment comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, new Date());
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length());
    comment.setStatus(ModernCommentStatus.Resolved);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IComment[] reopenedComments = reopenedSlide.getSlideComments(null);

    for (IComment reopenedComment : reopenedComments) {
        if (!(reopenedComment instanceof IModernComment)) {
            continue;
        }

        IModernComment modernComment = (IModernComment) reopenedComment;
        boolean shapeMatches = modernComment.getShape() != null && "Forecast text".equals(modernComment.getShape().getName());
        boolean selectionStartMatches = modernComment.getTextSelectionStart() == expectedSelectionStart;
        boolean selectionLengthMatches = modernComment.getTextSelectionLength() == selectedText.length();
        boolean statusMatches = modernComment.getStatus() == ModernCommentStatus.Resolved;

        System.out.println("Shape anchor preserved: " + shapeMatches);
        System.out.println("Text selection start preserved: " + selectionStartMatches);
        System.out.println("Text selection length preserved: " + selectionLengthMatches);
        System.out.println("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Inspecionar Comentários Modernos Existentes**

Para inspecionar uma apresentação existente, verifique quais comentários implementam [IModernComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/), em seguida examine [IModernComment.getShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--), e [IModernComment.getStatus](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#getStatus--). Uma forma `null` indica um comentário de nível de slide. Para uma âncora [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/), os métodos de seleção de texto identificam o intervalo associado na caixa de texto da forma.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.IModernComment;
import com.aspose.slides.IShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("comments.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        IComment[] comments = slide.getSlideComments(null);
        for (IComment comment : comments) {
            if (!(comment instanceof IModernComment)) {
                continue;
            }

            IModernComment modernComment = (IModernComment) comment;
            System.out.println("Slide: " + slide.getSlideNumber());
            System.out.println("Text: " + modernComment.getText());
            System.out.println("Status: " + modernComment.getStatus());

            IShape shape = modernComment.getShape();
            if (shape == null) {
                System.out.println("Anchor: slide level");
            } else {
                System.out.println("Anchor shape: " + shape.getName());
                System.out.println("Anchor type: " + shape.getClass().getSimpleName());

                if (shape instanceof IAutoShape) {
                    System.out.println("Text selection start: " + modernComment.getTextSelectionStart());
                    System.out.println("Text selection length: " + modernComment.getTextSelectionLength());
                }
            }

            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Remover Comentários**

### **Remover Todos os Comentários e Autores de Comentários**

O exemplo a seguir mostra como remover todos os comentários e autores de comentários de uma apresentação:

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("example.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        author.getComments().clear();
    }

    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Remover Comentários Específicos**

O exemplo a seguir mostra como remover comentários específicos de um slide:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    Point2D.Float firstCommentPosition = new Point2D.Float(0.2f, 0.2f);
    Point2D.Float secondCommentPosition = new Point2D.Float(0.3f, 0.2f);
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors()) {
        List<IComment> commentsToRemove = new ArrayList<IComment>();
        IComment[] comments = slide.getSlideComments(commentAuthor);

        for (IComment comment : comments) {
            if ("comment 1".equals(comment.getText())) {
                commentsToRemove.add(comment);
            }
        }

        for (IComment comment : commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Perguntas Frequentes**

**O Aspose.Slides suporta um status resolvido para comentários modernos?**

Sim. [IModernComment.getStatus](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#getStatus--) e [IModernComment.setStatus](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imoderncomment/#setStatus-byte-) acessam um valor de [ModernCommentStatus](https://reference.aspose.com/slides/pt/java/com.aspose.slides/moderncommentstatus/), incluindo `Resolved`. O status é armazenado na apresentação e pode ser lido novamente após o arquivo ser reaberto.

**As discussões em thread (cadeias de respostas) são suportadas e existe um limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [parent comment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icomment/#getParentComment--), permitindo cadeias de respostas. A API não define um limite específico de profundidade de aninhamento.

**Em qual sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição do marcador é definida por coordenadas de ponto flutuante no sistema de coordenadas do slide, permitindo que você o posicione com precisão no slide.