---
title: Exportar apresentações para XAML em Python via Java
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/python-java/export-to-xaml/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar apresentação
- converter PowerPoint
- converter OpenDocument
- converter apresentação
- PowerPoint para XAML
- OpenDocument para XAML
- apresentação para XAML
- PPT para XAML
- PPTX para XAML
- ODP para XAML
- salvar PPT como XAML
- salvar PPTX como XAML
- salvar ODP como XAML
- exportar PPT para XAML
- exportar PPTX para XAML
- exportar ODP para XAML
- Python
- Java
- Aspose.Slides
description: "Exporte apresentações PowerPoint e OpenDocument para XAML com Aspose.Slides for Python via Java. Use as opções padrão ou inclua slides ocultos."
---
## **Visão geral**

Este artigo explica como exportar apresentações PowerPoint e OpenDocument para XAML usando Aspose.Slides for Python via Java. Ele introduz o XAML, mostra como exportar com as configurações padrão e demonstra como incluir slides ocultos com [XamlOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/).

Os exemplos requerem Aspose.Slides for Python via Java e um runtime Java compatível. Coloque `pres.pptx` no diretório de trabalho atual. Cada exemplo inicia a JVM somente se ela ainda não estiver em execução.

## **Sobre o XAML**

XAML (Extensible Application Markup Language) é uma linguagem baseada em XML para descrever interfaces de usuário. É usada por frameworks como Windows Presentation Foundation (WPF). Você pode criar e editar XAML com um designer visual ou um editor de texto.

## **Exportar apresentações para XAML com opções padrão**

Crie uma [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) a partir do arquivo de entrada e, em seguida, passe [XamlOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/) para [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) para exportar com as configurações padrão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Exportar apresentações para XAML com opções personalizadas**

Use [XamlOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/) para configurar a exportação. Para incluir slides ocultos, chame [setExportHiddenSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) com `True` antes de salvar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Como posso escolher uma fonte alternativa quando a fonte original não está disponível?**

Use [setDefaultRegularFont](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) no seu objeto [XamlOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/) para especificar uma fonte de fallback. Certifique‑se de que a fonte selecionada esteja disponível no ambiente de exportação.

**Posso usar a marcação exportada em qualquer framework XAML?**

Os frameworks XAML diferem nos elementos e recursos suportados. Teste a marcação exportada no framework de destino antes de integrá‑la a uma aplicação.

**Os slides ocultos são exportados por padrão?**

Não. Para incluí‑los, chame [setExportHiddenSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) com `True`. Mantenha‑a definida como `False` para excluí‑los.