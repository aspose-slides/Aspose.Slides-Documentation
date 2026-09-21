---
title: Alterar o tamanho do slide em apresentações com Python
linktitle: Tamanho do slide
type: docs
weight: 70
url: /pt/python-net/slide-size/
keywords:
- tamanho do slide
- proporção
- padrão
- formato widescreen
- 4:3
- 16:9
- definir tamanho do slide
- alterar tamanho do slide
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

Aspose.Slides fornece ferramentas abrangentes para ajustar o tamanho do slide e a proporção em apresentações PowerPoint, fundamentais tanto para impressão quanto para exibição em tela.

Tamanhos e proporções de slide populares:

- **Padrão (proporção 4:3)**: Ideal para telas e dispositivos mais antigos.
- **Widescreen (proporção 16:9)**: Recomendado para projetores e monitores modernos.

Certifique-se de manter a consistência em toda a apresentação, pois um único tamanho de slide e proporção se aplicam a todos os slides. Para obter resultados ideais, defina as dimensões dos slides no início do processo de criação da apresentação para evitar complicações.

{{% alert color="info" title="Note" %}}
Por padrão, apresentações criadas com Aspose.Slides usam a proporção padrão 4:3.
{{% /alert %}}

As páginas de notas e folhetos têm dimensões separadas dos slides normais. Veja [Tamanho da página de notas](/slides/pt/python-net/notes-size/) para alterar seu tamanho e orientação.

## **Alterar o tamanho do slide em uma apresentação**

Este exemplo de código mostra como alterar o tamanho do slide em uma apresentação em Python usando Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Especificar tamanhos de slide personalizados**

Se os tamanhos de slide comuns (4:3 e 16:9) não forem adequados ao seu trabalho, você pode optar por um tamanho de slide específico ou exclusivo. Por exemplo, se planeja imprimir slides em tamanho real a partir da sua apresentação em um layout de página personalizado ou se pretende exibir sua apresentação em determinados tipos de tela, provavelmente se beneficiará ao usar uma configuração de tamanho personalizada para sua apresentação.

Este exemplo de código mostra como usar Aspose.Slides for Python via .NET para especificar um tamanho de slide personalizado para uma apresentação em Python:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Tamanho de papel A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Manipular o conteúdo do slide após redimensionar**

Depois de alterar o tamanho do slide de uma apresentação, o conteúdo dos slides (imagens ou objetos, por exemplo) pode ficar distorcido. Por padrão, os objetos são redimensionados automaticamente para se ajustarem ao novo tamanho do slide. Contudo, ao mudar o tamanho do slide de uma apresentação, você pode especificar uma configuração que determina como o Aspose.Slides trata o conteúdo nos slides.

Dependendo do que você pretende fazer ou alcançar, pode usar qualquer uma dessas configurações:

- `DO_NOT_SCALE`

  Se você NÃO deseja que os objetos nos slides sejam redimensionados, use esta configuração.

- `ENSURE_FIT`

  Se você deseja redimensionar para um slide menor e precisa que o Aspose.Slides reduza os objetos dos slides para garantir que todos caibam nos slides (assim, evita a perda de conteúdo), use esta configuração.

- `MAXIMIZE`

  Se você deseja redimensionar para um slide maior e precisa que o Aspose.Slides aumente os objetos dos slides para torná‑los proporcionais ao novo tamanho do slide, use esta configuração.

Este exemplo de código mostra como usar a configuração `MAXIMIZE` ao alterar o tamanho do slide de uma apresentação:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Posso definir um tamanho de slide personalizado usando unidades diferentes de polegadas (por exemplo, pontos ou milímetros)?**

Sim. Aspose.Slides usa pontos internamente, onde 1 ponto equivale a 1/72 de polegada. Você pode converter qualquer unidade (como milímetros ou centímetros) para pontos e usar os valores convertidos para definir a largura e a altura do slide.

**Um tamanho de slide personalizado muito grande afetará o desempenho e o uso de memória durante a renderização?**

Sim. Dimensões de slide maiores (em pontos) combinadas com escala de renderização mais alta levam a maior consumo de memória e tempos de processamento mais longos. Procure um tamanho de slide prático e ajuste a escala de renderização somente quando necessário para alcançar a qualidade de saída desejada.

**Posso definir um tamanho de slide não padrão e depois mesclar slides de apresentações que tenham tamanhos diferentes?**

Você não pode [mesclar apresentações](/slides/pt/python-net/merge-presentation/) enquanto elas têm tamanhos de slide diferentes — primeiro, redimensione uma apresentação para corresponder à outra. Ao mudar o tamanho do slide, você pode escolher como o conteúdo existente será tratado via opção [SlideSizeScaleType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidesizescaletype/). Após alinhar os tamanhos, pode mesclar slides preservando a formatação.

**Posso gerar miniaturas para formas individuais ou regiões específicas de um slide, e elas respeitarão o novo tamanho do slide?**

Sim. Aspose.Slides pode renderizar miniaturas para [slides inteiros](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/) assim como para [formas selecionadas](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_image/). As imagens resultantes refletem o tamanho e a proporção atuais do slide, garantindo enquadramento e geometria consistentes.