---
title: Alterar o Tamanho do Slide em Apresentações com Python
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
- alterar tamanho do slide
- tamanho de slide personalizado
- tamanho de slide especial
- tamanho de slide exclusivo
- slide em tamanho real
- tipo de tela
- não escalar
- garantir ajuste
- maximizar
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
descriptions: "Aprenda a redimensionar rapidamente slides em arquivos PPT, PPTX e ODP com Python e Aspose.Slides, otimize apresentações para qualquer tela sem perder qualidade."
---
## **Introdução**

Aspose.Slides oferece ferramentas abrangentes para ajustar o tamanho do slide e a proporção em apresentações do PowerPoint, essenciais tanto para impressão quanto para exibição em tela.

Tamanhos de Slides Populares e Proporções:

- **Padrão (Proporção 4:3)**: Ideal para telas e dispositivos mais antigos.
- **Tela larga (Proporção 16:9)**: Recomendado para projetores e monitores modernos.

Garanta consistência em toda a sua apresentação, pois um único tamanho de slide e proporção se aplicam a todos os slides. Para obter resultados ideais, defina as dimensões do slide no início do processo de criação da apresentação para evitar complicações.

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

Se os tamanhos de slide comuns (4:3 e 16:9) não forem adequados ao seu trabalho, você pode optar por usar um tamanho de slide específico ou exclusivo. Por exemplo, se planeja imprimir slides em tamanho real a partir da sua apresentação em um layout de página personalizado ou se pretende exibir a apresentação em determinados tipos de tela, provavelmente se beneficiará ao definir um tamanho personalizado para sua apresentação.

Este código de exemplo mostra como usar Aspose.Slides para Python via .NET para especificar um tamanho de slide personalizado em Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Tamanho de papel A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Manipular o Conteúdo do Slide Após Redimensionamento**

Depois de alterar o tamanho do slide de uma apresentação, o conteúdo dos slides (imagens ou objetos, por exemplo) pode ficar distorcido. Por padrão, os objetos são redimensionados automaticamente para caber no novo tamanho do slide. Contudo, ao mudar o tamanho do slide de uma apresentação, você pode especificar uma configuração que determina como o Aspose.Slides lida com o conteúdo dos slides.

Dependendo do que você pretende fazer ou alcançar, pode usar qualquer uma destas configurações:

- `DO_NOT_SCALE`

  Se NÃO quiser que os objetos nos slides sejam redimensionados, use esta configuração.

- `ENSURE_FIT`

  Se desejar reduzir para um tamanho de slide menor e precisar que o Aspose.Slides diminua os objetos dos slides para garantir que todos caibam nos slides (evitando perda de conteúdo), use esta configuração.

- `MAXIMIZE`

  Se desejar ampliar para um tamanho de slide maior e precisar que o Aspose.Slides aumente os objetos dos slides para torná‑los proporcionais ao novo tamanho, use esta configuração.

Este código de exemplo mostra como usar a configuração `MAXIMIZE` ao alterar o tamanho do slide de uma apresentação:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Posso definir um tamanho de slide personalizado usando unidades diferentes de polegadas (por exemplo, pontos ou milímetros)?**

Sim. Aspose.Slides usa pontos internamente, onde 1 ponto equivale a 1/72 de polegada. Você pode converter qualquer unidade (como milímetros ou centímetros) para pontos e usar os valores convertidos para definir a largura e altura do slide.

**Um tamanho de slide personalizado muito grande afetará o desempenho e o uso de memória durante a renderização?**

Sim. Dimensões de slide maiores (em pontos) combinadas com escala de renderização mais alta levam a maior consumo de memória e tempos de processamento mais longos. Procure um tamanho de slide prático e ajuste a escala de renderização apenas quando necessário para alcançar a qualidade de saída desejada.

**Posso definir um tamanho de slide não padrão e depois mesclar slides de apresentações que têm tamanhos diferentes?**

Você não pode [merge presentations](/slides/pt/python-net/merge-presentation/) enquanto elas possuem tamanhos de slide diferentes — primeiro, redimensione uma apresentação para corresponder à outra. Ao mudar o tamanho do slide, você pode escolher como o conteúdo existente será tratado via a opção [SlideSizeScaleType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidesizescaletype/). Após alinhar os tamanhos, você pode mesclar slides preservando a formatação.

**Posso gerar miniaturas para formas individuais ou regiões específicas de um slide, e elas respeitarão o novo tamanho do slide?**

Sim. Aspose.Slides pode renderizar miniaturas para [entire slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/) assim como para [selected shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_image/). As imagens resultantes refletem o tamanho e a proporção atuais do slide, garantindo enquadramento e geometria consistentes.