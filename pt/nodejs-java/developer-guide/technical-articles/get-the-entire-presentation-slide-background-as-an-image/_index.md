---
title: Obter o Fundo Completo do Slide de uma Apresentação como Imagem
linktitle: Fundo Completo do Slide
type: docs
weight: 95
url: /pt/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- fundo do slide
- fundo final
- extrair fundo
- fundo completo
- fundo para imagem
- fundo PPT
- fundo PPTX
- fundo ODP
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Extraia fundos de slide completos como imagens de apresentações PowerPoint e OpenDocument usando Aspose.Slides para Node.js via Java, otimizando fluxos de trabalho visuais."
---
## **Visão Geral**

Em apresentações do PowerPoint, o fundo de um slide pode ser formado por vários elementos, incluindo a imagem de fundo do slide, o tema da apresentação, o esquema de cores e objetos colocados no slide mestre ou no slide de layout.

Este artigo mostra como extrair todo o fundo do slide como uma imagem usando Aspose.Slides. Como não existe um método único para essa tarefa, a abordagem envolve clonar o slide selecionado em uma apresentação temporária, remover as formas do slide e então converter o fundo resultante do slide em uma imagem.

## **Obter o Fundo Completo do Slide**

Aspose.Slides for Node.js via Java não fornece um método simples para extrair todo o fundo do slide da apresentação como uma imagem, mas você pode seguir os passos abaixo para fazer isso:
1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha o tamanho do slide da apresentação.
1. Selecione um slide.
1. Crie uma apresentação temporária.
1. Defina o mesmo tamanho de slide na apresentação temporária.
1. Clone o slide selecionado na apresentação temporária.
1. Exclua as formas do slide clonado.
1. Converta o slide clonado em uma imagem.

O exemplo de código a seguir extrai todo o fundo do slide da apresentação como uma imagem.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**Gradientes complexos, texturas ou preenchimentos de imagem de um slide mestre serão preservados na imagem de fundo resultante?**

Sim. Aspose.Slides renderiza preenchimentos de gradiente, imagem e textura definidos no slide, layout ou mestre. Se precisar isolar a aparência dos mestres herdados, [defina um fundo próprio](/slides/pt/nodejs-java/presentation-background/) no slide atual antes de exportar.

**Posso adicionar uma marca d'água à imagem de fundo resultante antes de salvá‑la?**

Sim. Você pode [adicionar uma marca d'água](/slides/pt/nodejs-java/watermark/) como forma ou imagem em uma [cópia de trabalho do slide](/slides/pt/nodejs-java/clone-slides/) (colocada atrás de outros conteúdos) e então exportar. Isso permite gerar uma imagem de fundo com a marca d'água incorporada.

**Posso obter o fundo de um layout ou mestre específico sem vinculá‑lo a um slide existente?**

Sim. Acesse o mestre ou layout desejado, aplique‑o a um [slide temporário](/slides/pt/nodejs-java/clone-slides/) com o tamanho necessário e exporte esse slide para obter o fundo derivado desse layout ou mestre.

**Existem limitações de licenciamento que afetam a exportação de imagens?**

Os recursos de renderização estão totalmente disponíveis com uma [licença válida](/slides/pt/nodejs-java/licensing/). No modo de avaliação, a saída pode incluir limitações como uma marca d'água. Ative a licença uma vez por processo antes de executar exportações em lote.