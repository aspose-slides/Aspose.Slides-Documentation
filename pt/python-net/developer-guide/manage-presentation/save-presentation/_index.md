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
- apresentação para fluxo
- tipo de visualização pré-definido
- Formato Strict Office Open XML
- modo Zip64
- atualização de miniatura
- progresso de salvamento
- Python
- Aspose.Slides
description: "Descubra como salvar apresentações em Python usando Aspose.Slides—exportar para PowerPoint ou OpenDocument mantendo layouts, fontes e efeitos."
---
## **Visão geral**

[Open a Presentation in Python](/slides/pt/python-net/open-presentation/) descreve como usar a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você desejará salvá‑la quando terminar. Com Aspose.Slides for Python, você pode salvar em um **arquivo** ou **fluxo**. Este artigo explica as diferentes maneiras de salvar uma apresentação.

## **Salvar apresentações em arquivos**

Salve uma apresentação em um arquivo chamando o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento para o método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides for Python.

```py
import aspose.slides as slides

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:
    
    # Faça algum trabalho aqui...

    # Salve a apresentação em um arquivo.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Salvar apresentações em fluxos**

Você pode salvar uma apresentação em um fluxo passando um fluxo de saída para o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). Uma apresentação pode ser gravada em vários tipos de fluxo. No exemplo abaixo, criamos uma nova apresentação e a salvamos em um fluxo de arquivo.

```py
import aspose.slides as slides

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Salve a apresentação no fluxo.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Salvar apresentações com um tipo de visualização predefinido**

Aspose.Slides for Python permite definir a visualização inicial que o PowerPoint usa quando a apresentação gerada é aberta através da classe [ViewProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/). Defina a propriedade `last_view` para um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewtype/).

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

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) ao tamanho descompactado de qualquer arquivo, ao tamanho compactado de qualquer arquivo e ao tamanho total do arquivo, além de limitar o arquivo a 65 535 (2^16‑1) itens. As extensões de formato ZIP64 elevam esses limites para 2^64.

A propriedade [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) permite escolher quando usar as extensões de formato ZIP64 ao salvar um arquivo Office Open XML.

Esta propriedade oferece os seguintes modos:

- `IF_NECESSARY` usa as extensões de formato ZIP64 somente se a apresentação exceder as limitações acima. Este é o modo padrão.
- `NEVER` nunca usa as extensões de formato ZIP64.
- `ALWAYS` sempre usa as extensões de formato ZIP64.

O código a seguir demonstra como salvar uma apresentação como um arquivo PPTX com as extensões de formato ZIP64 habilitadas:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTA" color="warning" %}}
Quando você salva com `Zip64Mode.NEVER`, uma [PptxException](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pptxexception/) é lançada se a apresentação não puder ser salva no formato ZIP32.
{{% /alert %}}

## **Salvar apresentações no formato Office Open XML com níveis de compressão**

Ao trabalhar com apresentações grandes, você pode ajustar o nível de compressão para equilibrar tamanho do arquivo e tempo de processamento. Dependendo de seus requisitos, pode preferir um processamento mais rápido ou arquivos de saída menores.

Aspose.Slides fornece a propriedade [PptxOptions.compression_level](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pptxoptions/compression_level/), que permite especificar o nível de compressão usado ao salvar uma apresentação no formato Office Open XML.

Os seguintes níveis de compressão estão disponíveis:

- [**NONE**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/compressionlevel/): Nenhuma compressão é aplicada. Os arquivos são armazenados como estão.
- [**LEVEL1**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/compressionlevel/): A compressão mais rápida com a menor taxa de compressão.
- [**LEVEL2**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/compressionlevel/): Compressão mais rápida com uma taxa de compressão ligeiramente melhor que **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/compressionlevel/): Fornece melhor compressão que **LEVEL2** com impacto moderado no tempo de processamento.
- [**LEVEL4**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/compressionlevel/): Fornece melhor compressão que **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/compressionlevel/): Fornece compressão aprimorada em relação ao **LEVEL4** com tempo de processamento adicional.
- [**LEVEL6**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/compressionlevel/): Compressão padrão que oferece um bom equilíbrio entre velocidade de processamento e tamanho do arquivo. Este é o *nível de compressão padrão*.
- [**LEVEL7**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/compressionlevel/): Fornece melhor compressão que **LEVEL6** com processamento mais lento.
- [**LEVEL8**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/compressionlevel/): Fornece melhor compressão que **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/compressionlevel/): Compressão máxima. Produz o menor tamanho de arquivo ao custo do maior tempo de processamento.

O exemplo a seguir demonstra como salvar uma apresentação como um arquivo PPTX *sem compressão*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Este exemplo mostra como salvar uma apresentação como um arquivo PPTX com *compressão máxima*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Salvar apresentações sem atualizar a miniatura**

A propriedade [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) controla a geração de miniaturas ao salvar uma apresentação em PPTX:

- Se definido como `True`, a miniatura é atualizada durante a gravação. Este é o padrão.
- Se definido como `False`, a miniatura atual é preservada. Se a apresentação não possuir miniatura, nenhuma será gerada.

No código abaixo, a apresentação é salva em PPTX sem atualizar sua miniatura.

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
A Aspose desenvolveu um [app gratuito de divisão de PowerPoint](https://products.aspose.app/slides/pt/splitter) usando sua própria API. O app permite dividir uma apresentação em vários arquivos salvando slides selecionados como novos arquivos PPTX ou PPT.
{{% /alert %}}

## **Perguntas frequentes**

**O “salvamento rápido” (salvamento incremental) é suportado, de modo que apenas as alterações sejam gravadas?**

Não. O salvamento cria o arquivo de destino completo a cada vez; o “salvamento rápido” incremental não é suportado.

**É seguro em múltiplas threads salvar a mesma instância de Presentation a partir de várias threads?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) [não é thread‑safe](/slides/pt/python-net/multithreading/); salve‑a a partir de uma única thread.

**O que acontece com hyperlinks e arquivos vinculados externamente ao salvar?**

[Hyperlinks](/slides/pt/python-net/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos via caminhos relativos) não são copiados automaticamente — assegure‑se de que os caminhos referenciados permaneçam acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As [propriedades padrão do documento](/slides/pt/python-net/presentation-properties/) são suportadas e serão gravadas no arquivo ao salvar.