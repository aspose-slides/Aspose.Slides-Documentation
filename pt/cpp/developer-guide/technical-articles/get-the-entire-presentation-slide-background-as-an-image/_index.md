---
title: Obter todo o plano de fundo do slide de uma apresentação como imagem
linktitle: Todo o plano de fundo do slide
type: docs
weight: 95
url: /pt/cpp/get-the-entire-presentation-slide-background-as-an-image/
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
- C++
- Aspose.Slides
description: "Extrair planos de fundo completos dos slides como imagens de apresentações PowerPoint e OpenDocument usando o Aspose.Slides para C++, simplificando fluxos de trabalho visuais."
---
## **Visão geral**

Nas apresentações do PowerPoint, o plano de fundo de um slide pode ser formado por vários elementos, incluindo a imagem de plano de fundo do slide, o tema da apresentação, o esquema de cores e os objetos colocados no slide mestre ou no slide de layout.

Este artigo demonstra como extrair todo o plano de fundo do slide como uma imagem usando o Aspose.Slides. Como não existe um método único para essa tarefa, a abordagem consiste em clonar o slide selecionado em uma apresentação temporária, remover as formas do slide e, em seguida, converter o plano de fundo resultante do slide em uma imagem.

## **Obter todo o plano de fundo do slide**

O Aspose.Slides para C++ não fornece um método simples para extrair todo o plano de fundo do slide da apresentação como uma imagem, mas você pode seguir os passos abaixo para fazê‑lo:
1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Obtenha o tamanho do slide da apresentação.
3. Selecione um slide.
4. Crie uma apresentação temporária.
5. Defina o mesmo tamanho de slide na apresentação temporária.
6. Clone o slide selecionado na apresentação temporária.
7. Exclua as formas do slide clonado.
8. Converta o slide clonado em uma imagem.

O exemplo de código a seguir extrai todo o plano de fundo do slide da apresentação como uma imagem.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **Perguntas frequentes**

**Gradientes complexos, texturas ou preenchimentos de imagem de um slide mestre serão preservados na imagem de plano de fundo resultante?**

Sim. O Aspose.Slides renderiza preenchimentos de gradiente, imagem e textura definidos no slide, layout ou mestre. Se precisar isolar a aparência dos mestres herdados, [defina um plano de fundo próprio](/slides/pt/cpp/presentation-background/) no slide atual antes de exportar.

**Posso adicionar uma marca d'água à imagem de plano de fundo resultante antes de salvá‑la?**

Sim. Você pode [adicionar uma marca d'água](/slides/pt/cpp/watermark/) como forma ou imagem em uma [cópia de trabalho do slide](/slides/pt/cpp/clone-slides/) (colocada atrás de outros conteúdos) e então exportar. Isso permite gerar uma imagem de plano de fundo com a marca d'água incorporada.

**Posso obter o plano de fundo de um layout ou mestre específico sem vinculá‑lo a um slide existente?**

Sim. Acesse o mestre ou layout desejado, aplique‑o a um [slide temporário](/slides/pt/cpp/clone-slides/) com o tamanho necessário e exporte esse slide para obter o plano de fundo derivado desse layout ou mestre.

**Existem limitações de licenciamento que afetam a exportação de imagens?**

Os recursos de renderização estão totalmente disponíveis com uma [licença válida](/slides/pt/cpp/licensing/). No modo de avaliação, a saída pode incluir limitações, como uma marca d'água. Ative a licença uma vez por processo antes de executar exportações em lote.