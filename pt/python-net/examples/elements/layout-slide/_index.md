---
title: Slide de Layout
type: docs
weight: 20
url: /pt/python-net/examples/elements/layout-slide/
keywords:
- slide de layout
- adicionar slide de layout
- acessar slide de layout
- remover slide de layout
- slide de layout não usado
- clonar slide de layout
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Use Python para gerenciar slides de layout com Aspose.Slides: criar, aplicar, clonar, renomear e personalizar marcadores de posição e temas em apresentações para PPT, PPTX e ODP."
---
Este artigo demonstra como trabalhar com **Layout Slides** no Aspose.Slides para Python via .NET. Um slide de layout define o design e a formatação herdados pelos slides normais. Você pode adicionar, acessar, clonar e remover slides de layout, além de limpar os que não são usados para reduzir o tamanho da apresentação.

## **Adicionar um Slide de Layout**

Você pode criar um slide de layout personalizado para definir formatação reutilizável.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Crie um slide de layout com o tipo e nome especificados.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Dica 1:** Slides de layout funcionam como modelos para slides individuais. Você pode definir elementos comuns uma vez e reutilizá-los em vários slides.
> 
> 💡 **Dica 2:** Quando você adiciona formas ou texto a um slide de layout, todos os slides baseados naquele layout exibirão esse conteúdo compartilhado automaticamente.
> A captura de tela abaixo mostra dois slides, cada um herdando uma caixa de texto do mesmo slide de layout.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Acessar um Slide de Layout**

Slides de layout podem ser acessados por índice ou por tipo de layout (por exemplo, `Blank`, `Title`, `SectionHeader`, etc.).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Acesso por índice.
        first_layout_slide = presentation.layout_slides[0]

        # Acesso por tipo de layout.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Remover um Slide de Layout**

Você pode remover um slide de layout específico se ele não for mais necessário.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Obtenha um slide de layout por tipo e remova-o.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Remover Slides de Layout Não Utilizados**

Para reduzir o tamanho da apresentação, pode ser desejável remover slides de layout que não são usados por nenhum slide normal.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Remove automaticamente todos os slides de layout que não são referenciados por nenhum slide.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar um Slide de Layout**

Você pode duplicar um slide de layout usando o método `AddClone`.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Obtenha um slide de layout existente por tipo.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Clone o slide de layout para o final da coleção de slides de layout.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Resumo:** Slides de layout são ferramentas poderosas para gerenciar formatação consistente em todos os slides. Aspose.Slides permite controle total sobre a criação, gerenciamento e otimização de slides de layout.