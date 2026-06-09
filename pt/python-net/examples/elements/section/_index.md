---
title: Seção
type: docs
weight: 90
url: /pt/python-net/examples/elements/section/
keywords:
- seção
- seção de slide
- adicionar seção
- acessar seção
- remover seção
- renomear seção
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Gerencie seções de slides em Python com Aspose.Slides: crie, renomeie, reordene facilmente, mova slides entre seções e controle a visibilidade para PPT, PPTX e ODP."
---
Exemplos de gerenciamento de seções de apresentação—adicionar, acessar, remover e renomear programaticamente usando **Aspose.Slides for Python via .NET**.

## **Adicionar uma Seção**

Crie uma seção que comece em um slide específico.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Adiciona uma nova seção e especifica o slide que marca o início da seção.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar uma Seção**

Obtenha uma seção de uma apresentação.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Acessa uma seção por índice.
        section = presentation.sections[0]
```

## **Remover uma Seção**

Exclua uma seção adicionada anteriormente.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Remova a seção.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Renomear uma Seção**

Altere o nome de uma seção existente.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Renomeie a seção.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```