---
title: Adicionar Slides a Apresentações em JavaScript
linktitle: Adicionar Slide
type: docs
weight: 10
url: /pt/nodejs-java/add-slide-to-presentation/
keywords:
- adicionar slide
- criar slide
- slide vazio
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Adicione slides facilmente às suas apresentações PowerPoint e OpenDocument usando Aspose.Slides for Node.js via Java — inserção de slides perfeita e eficiente em segundos."
---
## **Visão geral**

Aspose.Slides permite adicionar slides a apresentações PowerPoint programaticamente. Uma apresentação contém slides mestre/layout e slides normais, e os slides normais são organizados por um índice baseado em zero. Cada slide tem um ID exclusivo, e arquivos de apresentação sem slides não são suportados.

Este artigo explica como criar um objeto `Presentation`, acessar sua coleção de slides, adicionar um slide vazio, trabalhar com o slide recém‑adicionado e salvar a apresentação atualizada. Também aborda pontos relacionados, como inserir slides em uma posição específica, usar layouts e entender o slide em branco que existe em uma apresentação recém‑criada.

## **Adicionar slide à apresentação**

Antes de falar sobre a adição de slides aos arquivos de apresentação, vamos discutir alguns fatos sobre os slides. Cada arquivo de apresentação PowerPoint contém slide **Master / Layout** e outros slides **Normal**. Isso significa que um arquivo de apresentação contém pelo menos um ou mais slides. É importante saber que arquivos de apresentação sem slides não são suportados pelo Aspose.Slides for Node.js via Java. Cada slide tem um Id exclusivo e todos os Slides Normais são organizados em uma ordem especificada pelo índice baseado em zero.

Aspose.Slides for Node.js via Java permite que desenvolvedores adicionem slides vazios às suas apresentações. Para adicionar um slide vazio na apresentação, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
- Instancie a classe [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection) definindo uma referência à propriedade [Slides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) (coleção de objetos Slide de conteúdo) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
- Adicione um slide vazio à apresentação ao final da coleção de slides de conteúdo chamando os métodos [**addEmptySlide**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) expostos pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection).
- Realize alguma operação com o slide vazio recém‑adicionado.
- Por fim, grave o arquivo da apresentação usando o objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).

```javascript
// Instanciar a classe Presentation que representa o arquivo de apresentação
var pres = new aspose.slides.Presentation();
try {
    // Instanciar a classe SlideCollection
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Adicionar um slide vazio à coleção Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Realizar algumas operações no slide recém-adicionado
    // Salvar o arquivo PPTX no disco
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Posso inserir um novo slide em uma posição específica, e não apenas no final?**

Sim. A biblioteca suporta coleções de slides e operações de [insert](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/insertclone/), portanto você pode adicionar um slide no índice desejado em vez de somente no final.

**Os temas/estilos são preservados ao adicionar um slide baseado em um layout?**

Sim. Um layout herda a formatação do seu mestre, e o novo slide herda do layout selecionado e de seu mestre associado.

**Qual slide está presente em uma nova apresentação "vazia" antes de adicionar slides?**

Uma apresentação recém‑criada já contém um slide em branco com índice zero. Isso é importante considerar ao calcular índices de inserção.

**Como escolher o layout "correto" para um novo slide se o mestre tem muitas opções?**

Geralmente escolha o [LayoutSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/) que corresponde à estrutura necessária ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidelayouttype/)). Se esse layout estiver ausente, você pode [adicionar ao mestre](/slides/pt/nodejs-java/slide-layout/) e então usá‑lo.