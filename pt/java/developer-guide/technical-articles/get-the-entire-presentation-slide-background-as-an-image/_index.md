---
title: Obter todo o plano de fundo do slide de uma apresentação como imagem
linktitle: Plano de fundo completo do slide
type: docs
weight: 95
url: /pt/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- plano de fundo do slide
- plano de fundo final
- extrair plano de fundo
- plano de fundo completo
- plano de fundo para imagem
- plano de fundo PPT
- plano de fundo PPTX
- plano de fundo ODP
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Extrair planos de fundo completos de slides como imagens de apresentações PowerPoint e OpenDocument usando Aspose.Slides para Java, simplificando fluxos de trabalho visuais."
---
## **Visão geral**

Em apresentações do PowerPoint, o plano de fundo de um slide pode ser formado por vários elementos, incluindo a imagem de fundo do slide, o tema da apresentação, o esquema de cores e os objetos colocados no slide mestre ou no slide de layout.

Este artigo mostra como extrair todo o plano de fundo do slide como uma imagem usando Aspose.Slides para .NET. Como não existe um método único para essa tarefa, a abordagem envolve clonar o slide selecionado em uma apresentação temporária, remover as formas do slide e então converter o plano de fundo resultante em uma imagem.

## **Obter todo o plano de fundo do slide**

Aspose.Slides para Java não fornece um método simples para extrair todo o plano de fundo do slide de uma apresentação como imagem, mas você pode seguir os passos abaixo para fazer isso:
1. Carregue a apresentação usando a classe [Apresentação](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).
1. Obtenha o tamanho do slide a partir da apresentação.
1. Selecione um slide.
1. Crie uma apresentação temporária.
1. Defina o mesmo tamanho de slide na apresentação temporária.
1. Clone o slide selecionado para a apresentação temporária.
1. Exclua as formas do slide clonado.
1. Converta o slide clonado em uma imagem.

O exemplo de código a seguir extrai todo o plano de fundo do slide da apresentação como uma imagem.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **Perguntas frequentes**

**Os gradientes complexos, texturas ou preenchimentos de imagem de um slide mestre serão preservados na imagem de fundo resultante?**

Sim. Aspose.Slides renderiza preenchimentos de gradiente, imagem e textura definidos no slide, layout ou mestre. Se precisar isolar a aparência dos mestres herdados, [definir um fundo próprio](/slides/pt/java/presentation-background/) no slide atual antes da exportação.

**Posso adicionar uma marca d'água à imagem de fundo resultante antes de salvá‑la?**

Sim. Você pode [adicionar uma marca d'água](/slides/pt/java/watermark/) como forma ou imagem em uma [cópia do slide](/slides/pt/java/clone-slides/) de trabalho (colocada atrás de outros conteúdos) e então exportar. Isso permite gerar uma imagem de fundo com a marca d'água incorporada.

**Posso obter o plano de fundo de um layout ou mestre específico sem vinculá‑lo a um slide existente?**

Sim. Acesse o mestre ou layout desejado, aplique‑o a um [slide temporário](/slides/pt/java/clone-slides/) com o tamanho necessário e exporte esse slide para obter o plano de fundo derivado desse layout ou mestre.

**Existem limitações de licenciamento que afetam a exportação de imagens?**

Os recursos de renderização estão totalmente disponíveis com uma [licença válida](/slides/pt/java/licensing/). No modo de avaliação, a saída pode incluir limitações, como uma marca d'água. Ative a licença uma vez por processo antes de executar exportações em lote.