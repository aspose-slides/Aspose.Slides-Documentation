---
title: Clonar Slides do PowerPoint em Python
linktitle: Clonar Slides
type: docs
weight: 40
url: /pt/python-net/clone-slides/
keywords:
- clonar slide
- copiar slide
- salvar slide
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Clone ou duplique rapidamente slides do PowerPoint com Aspose.Slides for Python via .NET. Siga nossos exemplos de código claros e dicas para automatizar a criação de PPT em segundos, aumentar a produtividade e eliminar o trabalho manual."
---
## **Introdução**

Clonagem é o processo de fazer uma cópia ou réplica exata de algo. Aspose.Slides também permite copiar (clonar) qualquer slide e então inserir o slide clonado na apresentação atual ou em qualquer outra apresentação aberta. A clonagem de slide cria um novo slide que os desenvolvedores podem modificar sem afetar o slide original. Há várias maneiras de clonar um slide:

- Clonar no final de uma apresentação.
- Clonar em outra posição dentro de uma apresentação.
- Clonar no final de outra apresentação.
- Clonar em outra posição em outra apresentação.
- Clonar em uma posição específica em outra apresentação.

No Aspose.Slides for Python via .NET, a [slide collection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) fornece os métodos `add_clone` e `insert_clone` para realizar esses tipos de clonagem de slide.

## **Clonar no Final Dentro da Mesma Apresentação**

Se você quiser clonar um slide dentro da mesma apresentação e adicioná‑lo ao final dos slides existentes, use o método `add_clone`. Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha a coleção de slides do objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Chame o método `add_clone` na [SlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/), passando o slide a ser clonado.
1. Salve a apresentação modificada.

No exemplo abaixo, o primeiro slide (índice 0) é clonado e adicionado ao final da apresentação.

```py
import aspose.slides as slides

# Instancie a classe Presentation para representar o arquivo de apresentação.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Clone o slide desejado para o final da coleção de slides na mesma apresentação.
    presentation.slides.add_clone(presentation.slides[0])
    # Salve a apresentação modificada no disco.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar para uma Posição Específica Dentro da Mesma Apresentação**

Se você quiser clonar um slide dentro da mesma apresentação e colocá‑lo em uma posição diferente, use o método `insert_clone`:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha a coleção de slides do objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Chame o método `insert_clone` na [SlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/), passando o slide a ser clonado e o índice de destino para sua nova posição.
1. Salve a apresentação modificada.

No exemplo abaixo, o slide no índice 0 (posição 1) é clonado para o índice 1 (posição 2) dentro da mesma apresentação.

```py
import aspose.slides as slides

# Instancie a classe Presentation para representar o arquivo de apresentação.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Clone o slide desejado para a posição especificada (índice) dentro da mesma apresentação.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Salve a apresentação modificada no disco.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar no Final de Outra Apresentação**

Se for necessário clonar um slide de uma apresentação e adicioná‑lo ao final de outra apresentação:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para a apresentação de origem (a que contém o slide a ser clonado).
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para a apresentação de destino (onde o slide será adicionado).
1. Obtenha a coleção de slides da apresentação de destino.
1. Chame `add_clone` na [SlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/) de destino, passando o slide da apresentação de origem.
1. Salve a apresentação de destino modificada.

No exemplo abaixo, o slide no índice 0 da apresentação de origem é clonado para o final da apresentação de destino.

```py
import aspose.slides as slides

# Instancie a classe Presentation para representar o arquivo de apresentação de origem.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instancie a classe Presentation para o PPTX de destino (onde o slide será clonado).
    with slides.Presentation() as target_presentation:
        # Clone o slide desejado da apresentação de origem para o final da coleção de slides na apresentação de destino.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Salve a apresentação de destino no disco.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar para uma Posição Específica em Outra Apresentação**

Se for necessário clonar um slide de uma apresentação e inseri‑lo em outra apresentação em uma posição específica:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para a apresentação de origem (a que contém o slide a ser clonado).
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para a apresentação de destino (onde o slide será adicionado).
1. Obtenha a coleção de slides da apresentação de destino.
1. Chame o método `insert_clone` na [SlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/) de destino, passando o slide da apresentação de origem e o índice de destino desejado.
1. Salve a apresentação de destino modificada.

No exemplo abaixo, o slide no índice 0 da apresentação de origem é clonado para o índice 1 (posição 2) na apresentação de destino.

```py
import aspose.slides as slides

# Instancie a classe Presentation para representar o arquivo de apresentação de origem.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instancie a classe Presentation para o PPTX de destino (onde o slide será clonado).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Insira uma cópia do primeiro slide da origem no índice 2 na apresentação de destino.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Salve a apresentação de destino no disco.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar um Slide com seu Slide Mestre em Outra Apresentação**

Se for necessário clonar um slide **com seu mestre** de uma apresentação e usá‑lo em outra, primeiro clone o slide mestre necessário da apresentação de origem para a apresentação de destino. Em seguida, use esse mestre de destino ao clonar o slide. O método `add_clone(Slide, MasterSlide)` espera um **slide mestre da apresentação de destino**, não da origem.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para a apresentação de origem (a que contém o slide a ser clonado).
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para a apresentação de destino.
1. Acesse o slide de origem a ser clonado e seu slide mestre.
1. Obtenha a [MasterSlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslidecollection/) da coleção de mestres da apresentação de destino.
1. Chame `add_clone` na [MasterSlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslidecollection/) de destino, passando o mestre de origem para cloná‑lo na destino.
1. Obtenha a [SlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/) da coleção de slides da apresentação de destino.
1. Chame `add_clone` na [SlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/) de destino, passando o slide de origem e o mestre clonado de destino.
1. Salve a apresentação de destino modificada.

No exemplo abaixo, o slide no índice 0 da apresentação de origem é clonado para o final da apresentação de destino usando o mestre clonado da origem.

```py
import aspose.slides as slides

# Instancie a classe Presentation para representar o arquivo de apresentação de origem.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instancie a classe Presentation para a apresentação de destino onde o slide será clonado.
    with slides.Presentation() as target_presentation:
        # Obtenha o primeiro slide da apresentação de origem.
        source_slide = source_presentation.slides[0]
        # Obtenha o slide mestre usado pelo primeiro slide.
        source_master = source_slide.layout_slide.master_slide
        # Clone o slide mestre na coleção de mestres da apresentação de destino.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Clone o slide da apresentação de origem para o final da apresentação de destino usando o mestre clonado.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Salve a apresentação de destino no disco.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar no Final em uma Seção Especificada**

Com Aspose.Slides for Python via .NET, você pode clonar um slide de uma seção de uma apresentação e inseri‑lo em outra seção dentro da mesma apresentação. Para isso, use o método `add_clone(Slide, Section)` da classe [SlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/).

O exemplo Python a seguir demonstra como clonar um slide e inserir a cópia em uma seção especificada:

```py
import aspose.slides as slides

# Crie uma nova apresentação em branco.
with slides.Presentation() as presentation:
    # Adicione um slide vazio baseado no layout do primeiro slide.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Adicione uma forma elíptica ao novo slide; este slide será clonado mais tarde.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Adicione outro slide vazio baseado no layout do primeiro slide.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Crie uma seção chamada "Section2" que começa no slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Clone o slide criado anteriormente na seção "Section2".
    presentation.slides.add_clone(slide, section)
    # Salve a apresentação como um arquivo PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**As notas do apresentador e os comentários do revisor são clonados?**

Sim. A página de notas e os comentários de revisão são incluídos na cópia. Se você não quiser them, [remova‑os](/slides/pt/python-net/presentation-notes/) após a inserção.

**Como os gráficos e suas fontes de dados são tratados?**

O objeto do gráfico, sua formatação e os dados incorporados são copiados. Se o gráfico estava vinculado a uma fonte externa (por exemplo, uma pasta de trabalho incorporada via OLE), esse vínculo é preservado como um [objeto OLE](/slides/pt/python-net/manage-ole/). Após mover entre arquivos, verifique a disponibilidade dos dados e o comportamento de atualização.

**Posso controlar a posição de inserção e as seções da cópia?**

Sim. Você pode inserir a cópia em um índice de slide específico e colocá‑la em uma [seção](/slides/pt/python-net/slide-section/) escolhida. Se a seção de destino não existir, crie‑a primeiro e então mova o slide para ela.