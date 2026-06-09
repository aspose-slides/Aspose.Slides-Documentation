---
title: Slide Mestre
type: docs
weight: 30
url: /pt/python-net/examples/elements/master-slide/
keywords:
- slide mestre
- adicionar slide mestre
- acessar slide mestre
- remover slide mestre
- slide mestre não usado
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Gerencie slides mestres no Python com Aspose.Slides: crie, edite, clone e formate temas, planos de fundo e marcadores de posição para unificar slides no PowerPoint e OpenDocument."
---
Slides mestre formam o nível superior da hierarquia de herança de slides no PowerPoint. Um **slide mestre** define elementos de design comuns, como planos de fundo, logotipos e formatação de texto. **Slides de layout** herdam de slides mestre, e **slides normais** herdam de slides de layout.

Este artigo demonstra como criar, modificar e gerenciar slides mestre usando Aspose.Slides for Python via .NET.

## **Adicionar um Slide Mestre**

Este exemplo mostra como criar um novo slide mestre clonando o padrão.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Clone o slide mestre padrão.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Dica 1:** Slides mestre fornecem um meio de aplicar branding consistente ou elementos de design compartilhados em todos os slides. Qualquer alteração feita no mestre será refletida automaticamente nos slides de layout e nos slides normais dependentes.

> 💡 **Dica 2:** Qualquer forma ou formatação adicionada a um slide mestre é herdada pelos slides de layout e, por sua vez, por todos os slides normais que usam esses layouts. A imagem abaixo ilustra como uma caixa de texto adicionada em um slide mestre é renderizada automaticamente no slide final.

![Exemplo de Herança de Slide Mestre](master-slide-banner.png)

## **Acessar um Slide Mestre**

Você pode acessar slides mestre usando a coleção `Presentation.masters`. Veja como recuperá‑los e trabalhar com eles:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Acesse o primeiro slide mestre.
        first_master_slide = presentation.masters[0]
```

## **Remover um Slide Mestre**

Slides mestre podem ser removidos tanto por índice quanto por referência.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Remover por índice.
        presentation.masters.remove_at(0)

        # Ou remover por referência.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Remover Slides Mestre Não Utilizados**

Algumas apresentações contêm slides mestre que não estão em uso. Remover esses slides pode ajudar a reduzir o tamanho do arquivo.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Remova todos os slides mestres não usados (mesmo aqueles marcados como Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Dica:** Use `remove_unused(True)` para limpar slides mestre não utilizados e minimizar o tamanho da apresentação.