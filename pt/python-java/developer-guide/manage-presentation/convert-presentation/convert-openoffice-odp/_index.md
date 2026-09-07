---
title: Converter apresentações OpenDocument em Python
linktitle: Converter OpenDocument
type: docs
weight: 10
url: /pt/python-java/convert-openoffice-odp/
keywords:
- converter ODP
- ODP para PDF
- ODP para HTML
- ODP para TIFF
- ODP para PPT
- ODP para PPTX
- ODP para XPS
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Converta apresentações OpenDocument (ODP) para PDF, HTML e outros formatos com Aspose.Slides for Python via Java, sem instalar OpenOffice ou LibreOffice."
---
## **Introdução**

Aspose.Slides for Python via Java permite converter apresentações OpenDocument (ODP) para formatos como PDF, HTML, TIFF, XPS, PPT e PPTX. A conversão de ODP usa a mesma API da conversão de PowerPoint: carregue o arquivo fonte com [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e selecione o formato de saída com [SaveFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/).

## **Converter ODP para PDF**

Siga as [instruções de instalação](/slides/pt/python-java/installation/) antes de executar o exemplo. coloque uma apresentação ODP chamada `pres.odp` no diretório de trabalho. O código a seguir inicia a JVM se necessário, carrega a apresentação e a salva como `pres.pdf`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Apresentação OpenDocument em Diferentes Aplicativos**

Uma apresentação ODP pode aparecer diferente no PowerPoint e no LibreOffice/OpenOffice Impress porque esses aplicativos suportam recursos de apresentação e comportamentos de renderização diferentes. Revise as apresentações convertidas quando seu layout depender de formatação complexa.

Diferenças de compatibilidade podem afetar:

- Tabelas, incluindo sua ordem de empilhamento em relação a outras formas e suporte a preenchimentos de imagem.
- Rotação e alinhamento de texto.
- Preenchimentos de imagem, degradê e padrão aplicados ao texto.
- Listas numeradas e com marcadores.

A imagem abaixo mostra uma lista criada no LibreOffice Impress:

![Exemplo de lista ODP no LibreOffice Impress](odp-list-example.png)

Aspose.Slides salva listas ODP para compatibilidade com LibreOffice/OpenOffice Impress.

Para detalhes sobre a compatibilidade de recursos, consulte o [guia da Microsoft para o formato OpenDocument Presentation](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **Perguntas frequentes**

**E se a formatação do meu arquivo ODP mudar após a conversão?**

ODP e PowerPoint utilizam modelos de apresentação diferentes. Tabelas, fontes e estilos de preenchimento podem ser renderizados de maneira distinta. Verifique se as fontes necessárias estão disponíveis, revise o resultado e ajuste o layout ou a formatação, se necessário.

**Preciso ter o OpenOffice ou LibreOffice instalados para converter arquivos ODP?**

Não. Aspose.Slides for Python via Java processa apresentações sem nenhum desses aplicativos. É necessário apenas um runtime Java compatível e o pacote Python.

**Posso personalizar a saída PDF ao converter uma apresentação ODP?**

Sim. Use [PdfOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pdfoptions/) para configurar as opções de exportação PDF, como qualidade e compressão de imagens.

**Posso converter apresentações ODP em um servidor ou em um contêiner?**

Sim. Instale o pacote Python, um runtime Java compatível e as fontes exigidas pelas suas apresentações no ambiente de destino. Nenhum aplicativo de escritório é necessário.