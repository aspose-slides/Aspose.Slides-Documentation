---
title: Adicionar Slides a Apresentações no Android
linktitle: Adicionar Slide
type: docs
weight: 10
url: /pt/androidjava/add-slide-to-presentation/
keywords:
- adicionar slide
- criar slide
- slide vazio
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Adicione slides facilmente às suas apresentações PowerPoint e OpenDocument usando Aspose.Slides for Android via Java — inserção de slides contínua e eficiente em segundos."
---
## **Visão Geral**

Aspose.Slides permite que você adicione slides a apresentações do PowerPoint programaticamente. Uma apresentação contém slides mestre/layout e slides normais, e os slides normais são organizados por um índice baseado em zero. Cada slide tem um ID exclusivo, e arquivos de apresentação sem slides não são suportados.

Este artigo explica como criar um objeto `Presentation`, acessar sua coleção de slides, adicionar um slide vazio, trabalhar com o slide recém‑adicionado e salvar a apresentação atualizada. Também aborda pontos relacionados, como inserir slides em uma posição específica, usar layouts e entender o slide em branco que existe em uma apresentação recém‑criada.

## **Adicionar um Slide a uma Apresentação**

Antes de falar sobre a adição de slides aos arquivos de apresentação, vamos discutir alguns fatos sobre os slides. Cada arquivo de apresentação do PowerPoint contém **slide Mestre / Layout** e outros slides **Normais**. Isso significa que um arquivo de apresentação contém pelo menos um slide. É importante saber que arquivos de apresentação sem slides não são suportados pelo Aspose.Slides for Android via Java. Cada slide tem um Id exclusivo e todos os Slides Normais são organizados em ordem especificada pelo índice baseado em zero.

Aspose.Slides for Android via Java permite que os desenvolvedores adicionem slides vazios às suas apresentações. Para adicionar um slide vazio na apresentação, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
- Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection) definindo uma referência à propriedade [Slides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getSlides--) (coleção de objetos Slide de conteúdo) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
- Adicione um slide vazio à apresentação ao final da coleção de slides de conteúdo chamando o método [**addEmptySlide**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection).
- Execute alguma operação com o slide vazio recém‑adicionado.
- Por fim, grave o arquivo de apresentação usando o objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).

```java
// Instanciar a classe Presentation que representa o arquivo de apresentação
Presentation pres = new Presentation();
try {
    // Instanciar a classe SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Adicionar um slide vazio à coleção Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Fazer algum trabalho no slide recém‑adicionado

    // Salvar o arquivo PPTX no disco
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Posso inserir um novo slide em uma posição específica, e não apenas no final?**

Sim. A biblioteca suporta coleções de slides e operações de [insert](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) , portanto você pode adicionar um slide no índice desejado em vez de somente no final.

**Os temas/estilos são preservados ao adicionar um slide baseado em um layout?**

Sim. Um layout herda a formatação de seu mestre, e o novo slide herda do layout selecionado e de seu mestre associado.

**Qual slide está presente em uma nova apresentação “vazia” antes de adicionar slides?**

Uma apresentação recém‑criada já contém um slide em branco com índice zero. Isso é importante considerar ao calcular os índices de inserção.

**Como escolho o layout “correto” para um novo slide se o mestre tem muitas opções?**

Geralmente escolha o [LayoutSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/layoutslide/) que corresponde à estrutura requerida ([Título e Conteúdo, Dois Conteúdos, etc.](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidelayouttype/)). Se esse layout estiver ausente, você pode [add it to the master](/slides/pt/androidjava/slide-layout/) e então utilizá‑lo.