---
title: Obter todo o plano de fundo do slide de uma apresentação como imagem
linktitle: Todo o plano de fundo do slide
type: docs
weight: 95
url: /pt/php-java/get-the-entire-presentation-slide-background-as-an-image/
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
- PHP
- Aspose.Slides
description: "Extrair planos de fundo completos dos slides como imagens de apresentações PowerPoint e OpenDocument usando Aspose.Slides for PHP via Java, simplificando fluxos de trabalho visual."
---
## **Visão geral**

Nas apresentações do PowerPoint, o plano de fundo de um slide pode ser formado por vários elementos, incluindo a imagem de fundo do slide, o tema da apresentação, o esquema de cores e objetos colocados no slide mestre ou no slide de layout.

Este artigo mostra como extrair todo o plano de fundo do slide como uma imagem usando Aspose.Slides. Como não existe um método único para essa tarefa, a abordagem envolve clonar o slide selecionado em uma apresentação temporária, remover as formas do slide e, em seguida, converter o plano de fundo resultante do slide em uma imagem.

## **Obter todo o plano de fundo do slide**

O Aspose.Slides for PHP via Java não fornece um método simples para extrair todo o plano de fundo dos slides da apresentação como uma imagem, mas você pode seguir os passos abaixo para fazer isso:
1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha o tamanho do slide a partir da apresentação.
1. Selecione um slide.
1. Crie uma apresentação temporária.
1. Defina o mesmo tamanho de slide na apresentação temporária.
1. Clone o slide selecionado na apresentação temporária.
1. Exclua as formas do slide clonado.
1. Converta o slide clonado em uma imagem.

O exemplo de código a seguir extrai todo o plano de fundo dos slides da apresentação como uma imagem.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **Perguntas frequentes**

**Gradientes complexos, texturas ou preenchimentos de imagem de um slide mestre serão preservados na imagem de fundo resultante?**

Sim. O Aspose.Slides renderiza preenchimentos de gradiente, imagem e textura definidos no slide, layout ou mestre. Se precisar isolar a aparência dos mestres herdados, [defina um fundo próprio](/slides/pt/php-java/presentation-background/) no slide atual antes de exportar.

**Posso adicionar uma marca d'água à imagem de fundo resultante antes de salvá‑la?**

Sim. Você pode [adicionar uma marca d'água](/slides/pt/php-java/watermark/) como forma ou imagem em uma [cópia de trabalho do slide](/slides/pt/php-java/clone-slides/) (colocada atrás de outro conteúdo) e, em seguida, exportar. Isso permite gerar uma imagem de fundo com a marca d'água incorporada.

**Posso obter o plano de fundo de um layout ou mestre específico sem vinculá‑lo a um slide existente?**

Sim. Acesse o mestre ou layout desejado, aplique‑o a um [slide temporário](/slides/pt/php-java/clone-slides/) com o tamanho necessário e exporte esse slide para obter o plano de fundo derivado desse layout ou mestre.

**Existem limitações de licenciamento que afetam a exportação de imagens?**

Os recursos de renderização estão totalmente disponíveis com uma [licença válida](/slides/pt/php-java/licensing/). No modo de avaliação, a saída pode incluir limitações, como uma marca d'água. Ative a licença uma vez por processo antes de executar exportações em lote.