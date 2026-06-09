---
title: Salvar apresentações em Python
linktitle: Salvar apresentações
type: docs
weight: 80
url: /pt/python-net/save-presentation/
keywords:
- salvar PowerPoint
- salvar OpenDocument
- salvar apresentação
- salvar slide
- salvar PPT
- salvar PPTX
- salvar ODP
- apresentação para arquivo
- apresentação para stream
- tipo de visualização predefinido
- Formato Strict Office Open XML
- modo Zip64
- atualizando miniatura
- progresso de salvamento
- Python
- Aspose.Slides
description: "Descubra como salvar apresentações em Python usando Aspose.Slides — exporte para PowerPoint ou OpenDocument preservando layout, fontes e efeitos."
---
## **Visão geral**

[Open a Presentation in Python](/slides/pt/python-net/open-presentation/) descreve como usar a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você desejará salvá‑la quando terminar. Com Aspose.Slides para Python, você pode salvar em um **arquivo** ou **stream**. Este artigo explica as diferentes maneiras de salvar uma apresentação.

## **Salvar apresentações em arquivos**

Salve uma apresentação em um arquivo chamando o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento para o método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides para Python.

```py
import aspose.slides as slides

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:
    
    # Faça algum trabalho aqui...

    # Salve a apresentação em um arquivo.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Salvar apresentações em streams**

Você pode salvar uma apresentação em um stream passando um stream de saída para o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). Uma apresentação pode ser gravada em vários tipos de stream. No exemplo abaixo, criamos uma nova apresentação, adicionamos texto a uma forma e a salvamos em um stream.

```py
import aspose.slides as slides

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Salve a apresentação no stream.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Salvar apresentações com um Tipo de Exibição Predefinido**

Aspose.Slides para Python permite definir a exibição inicial que o PowerPoint usa quando a apresentação gerada é aberta através da classe [ViewProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/). Defina a propriedade `last_view` com um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Salvar apresentações no formato Strict Office Open XML**

Aspose.Slides permite salvar uma apresentação no formato Strict Office Open XML. Use a classe [PptxOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pptxoptions/) e defina sua propriedade `conformance` ao salvar. Se você definir `Conformance.ISO_29500_2008_STRICT`, o arquivo de saída será salvo no formato Strict Office Open XML.

O exemplo abaixo cria uma apresentação e a salva no formato Strict Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:
    # Salve a apresentação no formato Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) para o tamanho descompactado de qualquer arquivo, o tamanho compactado de qualquer arquivo e o tamanho total do arquivo, além de limitar o número de arquivos no arquivo a 65 535 (2^16‑1). As extensões de formato ZIP64 aumentam esses limites para 2^64.

A propriedade [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) permite escolher quando usar as extensões de formato ZIP64 ao salvar um arquivo Office Open XML.

Esta propriedade oferece os seguintes modos:

- `IF_NECESSARY` usa extensões ZIP64 apenas se a apresentação exceder as limitações acima. Este é o modo padrão.
- `NEVER` nunca usa extensões ZIP64.
- `ALWAYS` sempre usa extensões ZIP64.

O código a seguir demonstra como salvar uma apresentação como PPTX com extensões de formato ZIP64 habilitadas:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Ao salvar com `Zip64Mode.NEVER`, uma [PptxException](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pptxexception/) é lançada se a apresentação não puder ser salva no formato ZIP32.
{{% /alert %}}

## **Salvar apresentações sem atualizar a miniatura**

A propriedade [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) controla a geração de miniaturas ao salvar uma apresentação em PPTX:

- Se definido como `True`, a miniatura é atualizada durante a gravação. Este é o padrão.
- Se definido como `False`, a miniatura atual é preservada. Se a apresentação não possuir miniatura, nenhuma será gerada.

No código abaixo, a apresentação é salva como PPTX sem atualizar sua miniatura.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Esta opção ajuda a reduzir o tempo necessário para salvar uma apresentação no formato PPTX.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
A Aspose desenvolveu um [app gratuito de divisão de PowerPoint](https://products.aspose.app/slides/pt/splitter) usando sua própria API. O app permite dividir uma apresentação em vários arquivos ao salvar os slides selecionados como novos arquivos PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**O “salvamento rápido” (salvamento incremental) é suportado para que apenas as alterações sejam gravadas?**

Não. Cada salvamento cria o arquivo de destino completo; o “salvamento rápido” incremental não é suportado.

**É seguro salvar a mesma instância de Presentation a partir de várias threads?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) [não é thread‑safe](/slides/pt/python-net/multithreading/); salve-a a partir de uma única thread.

**O que acontece com hyperlinks e arquivos vinculados externamente ao salvar?**

[Hyperlinks](/slides/pt/python-net/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos via caminhos relativos) não são copiados automaticamente — certifique‑se de que os caminhos referenciados permaneçam acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As propriedades padrão do documento [/slides/pt/python-net/presentation-properties/] são suportadas e serão gravadas no arquivo ao salvar.