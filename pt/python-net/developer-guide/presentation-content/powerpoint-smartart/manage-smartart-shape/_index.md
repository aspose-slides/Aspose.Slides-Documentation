---
title: Gerenciar Gráficos SmartArt em Apresentações Usando Python
linktitle: Gráficos SmartArt
type: docs
weight: 20
url: /pt/python-net/manage-smartart-shape/
keywords:
- Objeto SmartArt
- Gráfico SmartArt
- Estilo SmartArt
- Cor SmartArt
- Criar SmartArt
- Adicionar SmartArt
- Editar SmartArt
- Alterar SmartArt
- Acessar SmartArt
- Tipo de layout SmartArt
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Automatize a criação, edição e estilização de SmartArt no PowerPoint em Python via .NET usando Aspose.Slides, com exemplos de código concisos e orientações focadas em desempenho."
---
## **Visão Geral**

Aspose.Slides permite que você crie e gerencie gráficos SmartArt em apresentações do PowerPoint programaticamente. Este artigo explica como adicionar uma forma SmartArt a um slide, acessar formas SmartArt existentes, encontrar SmartArt por um tipo de layout específico e atualizar sua aparência visual alterando o estilo SmartArt ou o estilo de cor.

Os exemplos mostram como trabalhar com formas SmartArt através da coleção de formas do slide da apresentação, verificar se uma forma é SmartArt e então modificar ou inspecionar suas propriedades.

## **Criar Formas SmartArt**

Aspose.Slides for Python via .NET permite que você adicione formas SmartArt personalizadas aos slides do zero. A API torna isso fácil. Para adicionar uma forma SmartArt a um slide:

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha o slide de destino pelo seu índice.
3. Adicione uma forma SmartArt, especificando seu tipo de layout.
4. Salve a apresentação modificada como um arquivo PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Instanciar a classe Presentation.
with slides.Presentation() as presentation:
    # Acessar o slide da apresentação.
    slide = presentation.slides[0]
    # Adicionar uma forma SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Salvar a apresentação no disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar Formas SmartArt em Slides**

O código a seguir demonstra como acessar formas SmartArt em um slide. O exemplo itera por cada forma no slide e verifica se ela é um objeto [SmartArt](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartart/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Carregar um arquivo de apresentação.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterar por todas as formas no primeiro slide.
    for shape in presentation.slides[0].shapes:
        # Verificar se a forma é uma forma SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Imprimir o nome da forma.
            print("Shape name:", shape.name)
```

## **Acessar Formas SmartArt com um Tipo de Layout Especificado**

O exemplo a seguir mostra como acessar uma forma SmartArt com um tipo de layout especificado. Observe que você não pode alterar o tipo de layout de um SmartArt — ele é somente leitura e definido quando a forma é criada.

1. Crie uma instância de [Apresentação](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação que contém a forma SmartArt.
2. Obtenha uma referência ao primeiro slide pelo índice.
3. Itere sobre todas as formas no primeiro slide.
4. Verifique se a forma é um objeto [SmartArt](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartart/).
5. Se o tipo de layout da forma SmartArt corresponder ao que você precisa, execute as ações necessárias.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterar por todas as formas no primeiro slide.
    for shape in presentation.slides[0].shapes:
        # Verificar se a forma é uma forma SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Verificar o tipo de layout do SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **Alterar o Estilo da Forma SmartArt**

O exemplo a seguir mostra como localizar formas SmartArt e alterar seu estilo:

1. Crie uma [Apresentação](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue o arquivo que contém as formas SmartArt.
2. Obtenha uma referência ao primeiro slide pelo índice.
3. Itere sobre cada forma no primeiro slide.
4. Encontre a forma SmartArt com o estilo especificado.
5. Atribua o novo estilo à forma SmartArt.
6. Salve a apresentação.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterar por todas as formas no primeiro slide.
    for shape in presentation.slides[0].shapes:
        # Verificar se a forma é uma forma SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Verificar o estilo do SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Alterar o estilo do SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Salvar a apresentação.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Alterar o Estilo de Cor das Formas SmartArt**

Este exemplo mostra como alterar o estilo de cor de uma forma SmartArt. O código de exemplo localiza uma forma SmartArt com um estilo de cor especificado e a atualiza.

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação que contém as formas SmartArt.
2. Obtenha uma referência ao primeiro slide pelo índice.
3. Itere sobre cada forma no primeiro slide.
4. Verifique se a forma é um objeto [SmartArt](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartart/).
5. Localize a forma SmartArt com o estilo de cor especificado.
6. Defina o novo estilo de cor para essa forma SmartArt.
7. Salve a apresentação.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterar por todas as formas no primeiro slide.
    for shape in presentation.slides[0].shapes:
        # Verificar se a forma é uma forma SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Verificar o tipo de cor.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Alterar o tipo de cor.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Salvar a apresentação.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas Frequentes**

**Posso animar SmartArt como um único objeto?**

Sim. SmartArt é uma forma, portanto você pode aplicar [animações padrão](/slides/pt/python-net/powerpoint-animation/) via a API de animações (entrada, saída, ênfase, trajetórias de movimento) assim como em outras formas.

**Como posso encontrar um SmartArt específico em um slide se eu não conheço seu ID interno?**

Defina e use o Texto Alternativo (AltText) e procure a forma por esse valor — esta é uma maneira recomendada de localizar a forma alvo.

**Posso agrupar SmartArt com outras formas?**

Sim. Você pode agrupar SmartArt com outras formas (imagens, tabelas, etc.) e então [manipular o grupo](/slides/pt/python-net/group/).

**Como obtenho uma imagem de um SmartArt específico (por exemplo, para pré‑visualização ou relatório)?**

Exporte uma miniatura/imagem da forma; a biblioteca pode [renderizar formas individuais](/slides/pt/python-net/create-shape-thumbnails/) para arquivos raster (PNG/JPG/TIFF).

**A aparência do SmartArt será preservada ao converter toda a apresentação para PDF?**

Sim. O mecanismo de renderização visa alta fidelidade para [exportação de PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/), com uma variedade de opções de qualidade e compatibilidade.