---
title: MacroVBA
type: docs
weight: 150
url: /pt/python-net/examples/elements/vba-macro/
keywords:
- macro VBA
- adicionar macro VBA
- acessar macro VBA
- remover macro VBA
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Trabalhe com macros VBA em Python usando Aspose.Slides: adicione ou edite projetos e módulos, assine ou remova macros e salve apresentações em PPT, PPTX e ODP."
---
Ilustra como adicionar, acessar e remover macros VBA usando **Aspose.Slides for Python via .NET**.

## **Adicionar um Macro VBA**

Crie uma apresentação com um projeto VBA e um módulo de macro simples.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Inicializa um projeto VBA.
        presentation.vba_project = slides.vba.VbaProject()

        # Adiciona um módulo vazio chamado "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Acessar um Macro VBA**

Recupere o primeiro módulo do projeto VBA.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **Remover um Macro VBA**

Exclua um módulo do projeto VBA.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Pressupondo que a apresentação contém um projeto VBA e pelo menos um módulo.
        module = presentation.vba_project.modules[0]

        # Remove o módulo do projeto.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```