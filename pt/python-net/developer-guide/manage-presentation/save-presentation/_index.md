---
title: Salvar apresentações em Python
linktitle: Salvar Apresentação
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
- tipo de visualização predefinido
- Formato Strict Office Open XML
- modo Zip64
- atualizando miniatura
- progresso de salvamento
- Python
- Aspose.Slides
description: "Salvar apresentações PowerPoint e OpenDocument em arquivos ou fluxos em Python com Aspose.Slides e configurar opções de saída PPTX."
---
## **Visão geral**

Depois de criar uma apresentação ou [abrir uma existente](/slides/pt/python-net/open-presentation/), use o método [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ipresentation/save/) para gravar o resultado. Aspose.Slides for Python via .NET pode salvar uma apresentação em um arquivo ou fluxo nos formatos PowerPoint, OpenDocument, PDF e outros. As seções a seguir abordam as operações padrão de salvamento e as opções disponíveis para saída PPTX.

## **Salvar apresentações em arquivos**

Para salvar uma apresentação em um arquivo, passe o caminho de saída e um valor [SaveFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/) ao método [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ipresentation/save/). O valor do formato determina o tipo de arquivo que o Aspose.Slides cria.

O exemplo a seguir cria uma apresentação e a salva como um arquivo PPTX:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Adicionar ou modificar o conteúdo da apresentação aqui.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Salvar apresentações no formato original**

Para exemplos de detecção de arquivos e fluxos, o comportamento de apresentações recém‑criadas e a distinção entre formatos de origem e de saída, veja [Determinar o formato original da apresentação](/slides/pt/python-net/detect-presentation-source-format/).

Em um aplicativo de processamento em lote, o formato de entrada pode não ser conhecido antecipadamente. Depois de carregar um arquivo, leia seu formato original a partir da propriedade [Presentation.source_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/source_format/). Passe o valor resultante de [SourceFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sourceformat/) para [SlideUtil.to_save_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides.util/slideutil/to_save_format/) a fim de obter o valor correspondente de [SaveFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/), e então use [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ipresentation/save/) para gravar a apresentação modificada.

O exemplo completo a seguir processa cada arquivo em um diretório de entrada, atualiza seu título e o salva em um diretório de saída no formato em que foi carregado:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides.util/slideutil/to_save_format/) mapeia PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML para seus respectivos formatos de salvamento de apresentação. Ele mapeia apenas formatos de origem da apresentação; não se destina a selecionar formatos de exportação como PDF, HTML, TIFF ou imagens. Passar um valor de [SourceFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sourceformat/) não suportado ou inválido gera uma exceção.

Arquivos legados PPT, PPS e POT usam o mesmo contêiner binário. Quando tal apresentação é carregada a partir de um fluxo sem extensão de arquivo, um arquivo PPS ou POT pode, portanto, ser identificado como PPT. Se for necessário preservar esses subtipos legados, retenha o nome original do arquivo ou os metadados de formato separadamente e use‑os ao escolher o nome e o formato do arquivo de saída.

## **Salvar apresentações em fluxos**

Para gravar uma apresentação sem depender de um caminho de arquivo final, passe um fluxo [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) gravável e um valor [SaveFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/) ao método [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ipresentation/save/). Essa abordagem é útil quando a saída deve ser retornada de um serviço web, armazenada em um banco de dados ou processada na memória.

O exemplo a seguir salva uma nova apresentação em um fluxo de arquivo:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Salvar apresentações com um tipo de visualização predefinido**

É possível especificar a visualização na qual o PowerPoint abre inicialmente uma apresentação salva. Defina a propriedade [ViewProperties.last_view](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/last_view/) para um valor [ViewType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewtype/) antes de salvar.

O exemplo a seguir configura a visualização Mestre de Slides como visualização inicial:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Salvar apresentações no formato Strict Office Open XML**

Para criar um arquivo PPTX que esteja em conformidade com o perfil Strict do Office Open XML, crie uma instância de [PptxOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pptxoptions/) e defina sua propriedade [conformance](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pptxoptions/conformance/) como `Conformance.ISO_29500_2008_STRICT`. Em seguida, passe as opções ao método [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ipresentation/save/).

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo ZIP padrão limita o tamanho compactado e descompactado de cada entrada, o tamanho total do arquivo e o número de entradas. Como um arquivo PPTX é um arquivo ZIP, uma apresentação muito grande pode exceder esses limites. As extensões ZIP64 aumentam os limites de tamanho e contagem de entradas aplicáveis.

Use a propriedade [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) para controlar se o Aspose.Slides grava extensões ZIP64:

- `IF_NECESSARY` usa ZIP64 somente quando a apresentação excede os limites padrão de ZIP. Este é o modo padrão.
- `NEVER` desabilita as extensões ZIP64.
- `ALWAYS` grava sempre as extensões ZIP64.

O exemplo a seguir habilita sempre as extensões ZIP64 para a apresentação de saída:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
Se `Zip64Mode.NEVER` for usado e a apresentação não couber dentro dos limites padrão de ZIP, a operação de salvamento gera uma [PptxException](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Salvar apresentações no formato Office Open XML com níveis de compressão**

Para saída PPTX, você pode equilibrar a velocidade de gravação com o tamanho do arquivo definindo a propriedade [PptxOptions.compression_level](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pptxoptions/compression_level/). A enumeração [CompressionLevel](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/compressionlevel/) fornece os seguintes valores:

- `NONE` armazena os dados sem compressão.
- `LEVEL1` oferece a compressão mais rápida e a maior saída compactada.
- `LEVEL2` a `LEVEL5` favorecem progressivamente uma saída menor em detrimento da velocidade de gravação.
- `LEVEL6` equilibra velocidade de gravação e tamanho do arquivo. Este é o nível padrão.
- `LEVEL7` e `LEVEL8` favorecem ainda mais uma saída menor em detrimento da velocidade de gravação.
- `LEVEL9` oferece a compressão mais forte e requer mais tempo de processamento.

O exemplo a seguir salva uma apresentação sem compressão:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

O exemplo a seguir usa o nível máximo de compressão:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Salvar apresentações sem atualizar a miniatura**

Quando uma apresentação é salva como PPTX, a propriedade [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) controla sua miniatura de documento:

- `True` regenera a miniatura durante a operação de salvamento. Este é o valor padrão.
- `False` preserva a miniatura existente. Se a apresentação não possuir miniatura, o Aspose.Slides não gera uma.

O exemplo a seguir salva uma apresentação sem atualizar sua miniatura:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
Desativar a atualização da miniatura pode reduzir o tempo necessário para salvar um arquivo PPTX.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
A Aspose oferece um [PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) gratuito construído com a API Aspose.Slides. Ele salva slides selecionados de uma apresentação como arquivos PPT ou PPTX separados.
{{% /alert %}}

## **FAQ**

**O Aspose.Slides suporta salvamento incremental ou “salvamento rápido”?**

Não. Cada operação de salvamento grava um arquivo de saída completo em vez de atualizar apenas as partes alteradas.

**Vários threads podem salvar a mesma instância de Presentation?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) **não é thread‑safe** (/slides/pt/python-net/multithreading/). Acesse e salve cada instância a partir de apenas um thread por vez.

**O que acontece com hyperlinks e arquivos vinculados externamente ao salvar uma apresentação?**

[Hyperlinks](/slides/pt/python-net/manage-hyperlinks/) permanecem na apresentação. O Aspose.Slides não copia arquivos vinculados externamente, portanto a apresentação salva ainda precisa acessar seus locais.

**Posso salvar metadados do documento, como autor, título, empresa e data de criação?**

Sim. Defina as [propriedades do documento](/slides/pt/python-net/presentation-properties/) apropriadas antes de salvar, e o Aspose.Slides as grava no arquivo de saída.