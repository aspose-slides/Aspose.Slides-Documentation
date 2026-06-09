---
title: Obter o plano de fundo completo do slide de uma apresentação como imagem
linktitle: Plano de fundo completo do slide
type: docs
weight: 95
url: /pt/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- plano de fundo do slide
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
- .NET
- C#
- Aspose.Slides
description: "Extrair planos de fundo completos de slides como imagens de apresentações PowerPoint e OpenDocument usando Aspose.Slides para .NET, simplificando fluxos de trabalho visuais."
---
## **Visão geral**

Em apresentações do PowerPoint, o plano de fundo de um slide pode ser formado por vários elementos, incluindo a imagem de fundo do slide, o tema da apresentação, o esquema de cores e os objetos colocados no slide mestre ou no slide de layout.

Este artigo mostra como extrair todo o plano de fundo do slide como uma imagem usando o Aspose.Slides para .NET. Como não existe um método único para essa tarefa, a abordagem envolve clonar o slide selecionado em uma apresentação temporária, remover as formas do slide e, em seguida, converter o plano de fundo resultante em uma imagem.

## **Obter o plano de fundo completo do slide**

O Aspose.Slides para .NET não fornece um método simples para extrair todo o plano de fundo do slide da apresentação como uma imagem, mas você pode seguir as etapas abaixo para fazer isso:
1. Carregue a apresentação usando a [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) class.
1. Obtenha o tamanho do slide da apresentação.
1. Selecione um slide.
1. Crie uma apresentação temporária.
1. Defina o mesmo tamanho de slide na apresentação temporária.
1. Clone o slide selecionado na apresentação temporária.
1. Exclua as formas do slide clonado.
1. Converta o slide clonado em uma imagem.

O exemplo de código a seguir extrai todo o plano de fundo do slide da apresentação como uma imagem.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```

## **Perguntas frequentes**

**Os gradientes complexos, texturas ou preenchimentos de imagem de um slide mestre serão preservados na imagem de fundo resultante?**

Sim. O Aspose.Slides renderiza preenchimentos de gradiente, imagem e textura definidos no slide, layout ou mestre. Se precisar isolar a aparência dos mestres herdados, [defina um fundo próprio](/slides/pt/net/presentation-background/) no slide atual antes de exportar.

**Posso adicionar uma marca d'água à imagem de fundo resultante antes de salvá‑la?**

Sim. Você pode [adicionar uma marca d'água](/slides/pt/net/watermark/) como forma ou imagem em uma [cópia de trabalho do slide](/slides/pt/net/clone-slides/) (colocada atrás de outros conteúdos) e então exportar. Isso permite gerar uma imagem de fundo com a marca d'água incorporada.

**Posso obter o fundo de um layout ou mestre específico sem vinculá‑lo a um slide existente?**

Sim. Acesse o mestre ou layout desejado, aplique‑o a um [slide temporário](/slides/pt/net/clone-slides/) com o tamanho necessário e exporte esse slide para obter o fundo derivado desse layout ou mestre.

**Existem limitações de licenciamento que afetam a exportação de imagens?**

Recursos de renderização estão totalmente disponíveis com uma [licença válida](/slides/pt/net/licensing/). No modo de avaliação, a saída pode incluir limitações, como uma marca d'água. Ative a licença uma vez por processo antes de executar exportações em lote.