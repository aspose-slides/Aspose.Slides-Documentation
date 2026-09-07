---
title: Converter apresentações PowerPoint para XPS em Python
linktitle: PowerPoint para XPS
type: docs
weight: 70
url: /pt/python-java/convert-powerpoint-to-xps/
keywords:
- converter PowerPoint
- converter apresentação
- converter PPT
- converter PPTX
- PowerPoint para XPS
- apresentação para XPS
- PPT para XPS
- PPTX para XPS
- salvar PPT como XPS
- salvar PPTX como XPS
- exportar PPT para XPS
- exportar PPTX para XPS
- Python
- Java
- Aspose.Slides
description: "Converter apresentações PowerPoint PPT e PPTX para XPS em Python usando Aspose.Slides for Python via Java, com configurações de exportação padrão ou personalizadas."
---
## **Visão geral**

Aspose.Slides for Python via Java permite converter apresentações PowerPoint para XPS salvando um arquivo PPT ou PPTX no formato XPS. Este artigo explica quando o XPS pode ser útil e mostra como exportar uma apresentação usando as configurações padrão ou configurações personalizadas de [XpsOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xpsoptions/).

## **Sobre XPS**

XPS (XML Paper Specification) é um formato de documento baseado em XML desenvolvido pela Microsoft. Ele descreve páginas fixas, preservando o layout de texto e gráficos para visualização e impressão com softwares compatíveis.

## **Quando usar o formato Microsoft XPS**

Use XPS quando um fluxo de trabalho de documentos requer arquivos de layout fixo para compartilhamento ou impressão através de ferramentas compatíveis com XPS. Os destinatários precisam de software que suporte XPS. Se o seu fluxo de trabalho requer PDF, veja [Converter PowerPoint para PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Observação" %}}
Para experimentar a conversão de uma apresentação PPT ou PPTX para XPS, use o [conversor online gratuito](https://products.aspose.app/slides/pt/conversion).
{{% /alert %}}

| Apresentação PowerPoint de entrada | Documento XPS de saída |
| --- | --- |
| ![Apresentação PowerPoint original](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Apresentação convertida para XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Conversão XPS com Aspose.Slides**

Use o método [save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) com [SaveFormat.Xps](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Xps) para exportar uma apresentação. Você pode usar as configurações de exportação padrão ou fornecer [XpsOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xpsoptions/) para personalizar a saída.

Cada exemplo abaixo inicia a máquina virtual Java se necessário e libera a apresentação após o uso. Substitua o nome do arquivo de entrada pelo caminho do seu arquivo PPT ou PPTX.

### **Converter apresentações para XPS usando configurações padrão**

O código Python a seguir converte uma apresentação para XPS usando as configurações padrão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Salvar a apresentação como um documento XPS.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Converter apresentações para XPS usando configurações personalizadas**

O exemplo a seguir usa [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) para salvar metafiles como imagens PNG no documento XPS resultante:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Salvar a apresentação com as configurações personalizadas de XPS.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Posso salvar XPS em um fluxo em vez de um arquivo?**

Sim. O método [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) tem sobrecargas que aceitam um fluxo de saída Java. Com Python via Java, use um fluxo Java compatível através do JPype, como um fluxo de saída de array de bytes Java, para manter os dados exportados na memória.

**Slides ocultos são incluídos na saída XPS?**

Slides ocultos são excluídos por padrão. Para incluí-los, defina [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) como `True` antes de salvar.

**Animações e transições de slide são preservadas no XPS?**

Não. O XPS contém páginas fixas, portanto os slides exportados não reproduzem animações ou efeitos de transição.