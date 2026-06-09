---
title: Acessar slides de apresentação em JavaScript
linktitle: Acessar slide
type: docs
weight: 20
url: /pt/nodejs-java/access-slide-in-presentation/
keywords:
- acessar slide
- índice de slide
- id de slide
- posição do slide
- alterar posição
- propriedades do slide
- número do slide
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como acessar e gerenciar slides em apresentações PowerPoint e OpenDocument com Aspose.Slides para Node.js. Aumente a produtividade com exemplos de código."
---
## **Visão geral**

Este artigo explica como acessar e gerenciar slides em uma apresentação usando Aspose.Slides. Ele mostra como recuperar slides pelo índice baseado em zero da coleção de slides e como acessar um slide pelo seu ID exclusivo usando o método `getSlideById`.

Você também aprenderá como alterar a posição de um slide usando o método `setSlideNumber` e como definir o número do slide inicial de uma apresentação com o método `setFirstSlideNumber`. Os exemplos demonstram como carregar uma apresentação, obter referências de slides, atualizar a ordem ou numeração dos slides e salvar a apresentação modificada.

## **Acessar slide por índice**

Todos os slides em uma apresentação são organizados numericamente com base na posição do slide, começando em 0. O primeiro slide é acessível pelo índice 0; o segundo slide é acessado pelo índice 1; etc.

A classe Presentation, que representa um arquivo de apresentação, expõe todos os slides como uma coleção [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/) (coleção de objetos [Slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/)). Este código JavaScript mostra como acessar um slide pelo seu índice:

```javascript
// Instancia um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Acessa um slide usando seu índice de slide
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Acessar slide por ID**

Cada slide em uma apresentação tem um ID exclusivo associado a ele. Você pode usar o método [getSlideById](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/)) para direcionar esse ID. Este código JavaScript mostra como fornecer um ID de slide válido e acessar esse slide através do método [getSlideById](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSlideById-long-):

```javascript
// Instancia um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Obtém o ID de um slide
    var id = pres.getSlides().get_Item(0).getSlideId();
    // Acessa o slide através do seu ID
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Alterar posição do slide**

Aspose.Slides permite que você altere a posição de um slide. Por exemplo, você pode especificar que o primeiro slide deve se tornar o segundo slide.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha a referência do slide (cuja posição você deseja alterar) através do seu índice
1. Defina uma nova posição para o slide através da propriedade [setSlideNumber](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#setSlideNumber-int-).
1. Salve a apresentação modificada.

Este código JavaScript demonstra uma operação na qual o slide na posição 1 é movido para a posição 2:

```javascript
// Instancia um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Obtém o slide cuja posição será alterada
    var sld = pres.getSlides().get_Item(0);
    // Define a nova posição para o slide
    sld.setSlideNumber(2);
    // Salva a apresentação modificada
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

O primeiro slide tornou‑se o segundo; o segundo slide tornou‑se o primeiro. Quando você altera a posição de um slide, os demais slides são ajustados automaticamente.

## **Definir número do slide**

Usando a propriedade [setFirstSlideNumber](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (exposta pela classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/)), você pode especificar um novo número para o primeiro slide em uma apresentação. Essa operação faz com que os demais números de slides sejam recalculados.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha o número do slide.
1. Defina o número do slide.
1. Salve a apresentação modificada.

Este código JavaScript demonstra uma operação em que o número do primeiro slide é definido como 10:

```javascript
// Instancia um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // Obtém o número do slide
    var firstSlideNumber = pres.getFirstSlideNumber();
    // Define o número do slide
    pres.setFirstSlideNumber(10);
    // Salva a apresentação modificada
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Se preferir pular o primeiro slide, você pode iniciar a numeração a partir do segundo slide (e ocultar a numeração do primeiro slide) desta forma:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // Define o número do primeiro slide da apresentação
    presentation.setFirstSlideNumber(0);
    // Exibe números de slide para todos os slides
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);
    // Oculta o número do slide do primeiro slide
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);
    // Salva a apresentação modificada
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**O número do slide que o usuário vê corresponde ao índice baseado em zero da coleção?**

O número exibido em um slide pode começar a partir de um valor arbitrário (por exemplo, 10) e não precisa corresponder ao índice; a relação é controlada pela configuração de [first slide number](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) da apresentação.

**Os slides ocultos afetam a indexação?**

Sim. Um slide oculto permanece na coleção e é contado na indexação; "hidden" refere‑se à exibição, não à sua posição na coleção.

**O índice de um slide muda quando outros slides são adicionados ou removidos?**

Sim. Os índices sempre refletem a ordem atual dos slides e são recalculados ao inserir, excluir ou mover slides.