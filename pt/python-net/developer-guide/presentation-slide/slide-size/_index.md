---
title: Mudar o Tamanho do Slide em Apresentações com Python
linktitle: Tamanho do Slide
type: docs
weight: 70
url: /pt/python-net/slide-size/
keywords:
- tamanho do slide
- proporção
- padrão
- tela larga
- 4:3
- 16:9
- definir tamanho do slide
- mudar tamanho do slide
- tamanho de slide personalizado
- tamanho de slide especial
- tamanho de slide exclusivo
- slide em tamanho completo
- tipo de tela
- não escalar
- garantir ajuste
- maximizar
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a redimensionar rapidamente slides em arquivos PPT, PPTX e ODP com Python e Aspose.Slides, otimize apresentações para qualquer tela sem perder qualidade."
---
## **Introdução**

Aspose.Slides fornece ferramentas abrangentes para ajustar o tamanho do slide e a proporção em apresentações do PowerPoint, essenciais tanto para impressão quanto para exibição em tela.

Tamanhos de Slide e Proporções Populares:

- **Standard (Proporção 4:3)**: Ideal para telas e dispositivos mais antigos.
- **Widescreen (Proporção 16:9)**: Recomendada para projetores e monitores modernos.

Garanta consistência em toda a sua apresentação, pois um único tamanho de slide e proporção se aplica a todos os slides. Para resultados ideais, defina as dimensões do slide no início do processo de criação da apresentação, evitando complicações.

{{% alert color="primary" %}} 
Por padrão, apresentações criadas com Aspose.Slides usam a proporção padrão 4:3.
{{% /alert %}}

## **Alterar o Tamanho do Slide em uma Apresentação**

Este código de exemplo mostra como alterar o tamanho do slide em uma apresentação em Python usando Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Especificar Tamanhos de Slide Personalizados**

Se os tamanhos de slide comuns (4:3 e 16:9) não atenderem às suas necessidades, você pode optar por usar um tamanho de slide específico ou exclusivo. Por exemplo, se planeja imprimir slides em tamanho completo a partir da sua apresentação em um layout de página personalizado ou se pretende exibir a apresentação em determinados tipos de tela, provavelmente se beneficiará ao usar uma configuração de tamanho personalizada.

Este código de exemplo mostra como usar Aspose.Slides para Python via .NET para especificar um tamanho de slide personalizado para uma apresentação em Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # tamanho de papel A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Manipular o Conteúdo do Slide Após Redimensionamento**

Após alterar o tamanho do slide de uma apresentação, o conteúdo dos slides (imagens ou objetos, por exemplo) pode ficar distorcido. Por padrão, os objetos são redimensionados automaticamente para se ajustarem ao novo tamanho do slide. No entanto, ao mudar o tamanho do slide, você pode especificar uma configuração que determina como o Aspose.Slides lida com o conteúdo nos slides.

Dependendo do que você pretende fazer ou alcançar, pode usar qualquer uma destas configurações:

- `DO_NOT_SCALE`

  Se NÃO quiser que os objetos nos slides sejam redimensionados, use esta configuração.

- `ENSURE_FIT`

  Se desejar reduzir para um slide menor e precisar que o Aspose.Slides ajuste os objetos dos slides para garantir que todos caibam nos slides (evitando perda de conteúdo), use esta configuração.

- `MAXIMIZE`

  Se quiser ampliar para um slide maior e precisar que o Aspose.Slides aumente os objetos dos slides para que fiquem proporcionais ao novo tamanho, use esta configuração.

Este código de exemplo mostra como usar a configuração `MAXIMIZE` ao alterar o tamanho do slide de uma apresentação:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Posso definir um tamanho de slide personalizado usando unidades diferentes de polegadas (por exemplo, pontos ou milímetros)?**

Sim. Aspose.Slides usa pontos internamente, onde 1 ponto equivale a 1/72 de polegada. Você pode converter qualquer unidade (como milímetros ou centímetros) para pontos e usar os valores convertidos para definir a largura e a altura do slide.

**Um tamanho de slide personalizado muito grande afeta o desempenho e o uso de memória durante a renderização?**

Sim. Dimensões de slide maiores (em pontos) combinadas com escala de renderização mais alta aumentam o consumo de memória e o tempo de processamento. Procure um tamanho de slide prático e ajuste a escala de renderização apenas quando necessário para alcançar a qualidade de saída desejada.

**Posso definir um tamanho de slide não padrão e depois mesclar slides de apresentações que têm tamanhos diferentes?**

Você não pode [mesclar apresentações](/slides/pt/python-net/merge-presentation/) enquanto elas têm tamanhos de slide diferentes — primeiro, redimensione uma apresentação para coincidir com a outra. Ao mudar o tamanho do slide, pode escolher como o conteúdo existente será tratado via a opção [SlideSizeScaleType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidesizescaletype/). Após alinhar os tamanhos, é possível mesclar slides preservando a formatação.

**Posso gerar miniaturas para formas individuais ou regiões específicas de um slide, e elas respeitarão o novo tamanho do slide?**

Sim. Aspose.Slides pode renderizar miniaturas para [slides inteiros](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/) assim como para [formas selecionadas](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_image/). As imagens resultantes refletem o tamanho atual do slide e a proporção, garantindo enquadramento e geometria consistentes.