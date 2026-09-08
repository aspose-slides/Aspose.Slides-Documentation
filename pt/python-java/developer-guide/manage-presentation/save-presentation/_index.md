---
title: Salvar apresentações em Python via Java
linktitle: Salvar apresentação
type: docs
weight: 80
url: /pt/python-java/save-presentation/
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
- Formato Office Open XML Strict
- modo Zip64
- atualizar miniatura
- progresso de salvamento
- Python
- Java
- Aspose.Slides
description: "Salvar apresentações PowerPoint e OpenDocument em arquivos ou fluxos em Python via Java com Aspose.Slides, e configurar a saída PPTX e o relatório de progresso."
---
## **Visão geral**

Depois de criar uma apresentação ou [abrir uma existente](/slides/pt/python-java/open-presentation/), use o método [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) para gravar o resultado. Aspose.Slides for Python via Java pode salvar uma apresentação em um arquivo ou fluxo nos formatos PowerPoint, OpenDocument, PDF e outros. As seções a seguir cobrem as operações de salvamento padrão e as opções disponíveis para saída PPTX.

## **Salvar apresentações em arquivos**

Para salvar uma apresentação em um arquivo, passe o caminho de saída e um valor [SaveFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/) ao método [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save). O valor de formato determina o tipo de arquivo que o Aspose.Slides cria.

O exemplo a seguir cria uma apresentação e a salva como um arquivo PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Adicione ou modifique o conteúdo da apresentação aqui.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Salvar apresentações no formato original**

Em um aplicativo de processamento em lote, o formato de entrada pode não ser conhecido antecipadamente. Após carregar um arquivo, leia seu formato original do método [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSourceFormat). Passe o valor [SourceFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sourceformat/) resultante para [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideutil/#toSaveFormat) para obter o valor correspondente de [SaveFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/), e então use [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) para gravar a apresentação modificada.

O exemplo completo a seguir processa cada arquivo em um diretório de entrada, atualiza seu título e o salva em um diretório de saída no formato em que foi carregado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideutil/#toSaveFormat) mapeia PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML para seus respectivos formatos de salvamento de apresentação. Ele mapeia apenas os formatos de origem da apresentação; não destina-se a selecionar formatos de exportação como PDF, HTML, TIFF ou imagens. Passar um valor [SourceFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sourceformat/) não suportado ou inválido resulta em uma [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Arquivos legados PPT, PPS e POT usam o mesmo contêiner binário. Quando uma apresentação desse tipo é carregada a partir de um fluxo sem extensão de arquivo, um arquivo PPS ou POT pode ser identificado como PPT. Se for necessário preservar esses subtipos legados, mantenha o nome de arquivo original ou os metadados de formato separadamente e use-os ao escolher o nome de arquivo e o formato de saída.

## **Salvar apresentações em fluxos**

Para gravar uma apresentação sem depender de um caminho de arquivo final, passe um fluxo gravável e um valor [SaveFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/) ao método [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save). Essa abordagem é útil quando a saída deve ser retornada de um serviço web, armazenada em um banco de dados ou processada na memória.

O exemplo a seguir salva uma nova apresentação em um fluxo de arquivo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **Salvar apresentações com um tipo de visualização predefinido**

Você pode especificar a visualização na qual o PowerPoint abre inicialmente uma apresentação salva. Use o método [ViewProperties.setLastView](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#setLastView) com um valor [ViewType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewtype/) antes de salvar.

O exemplo a seguir configura a visualização Slide Master como visualização inicial:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Salvar apresentações no formato Office Open XML estrito**

Para criar um arquivo PPTX que cumpra o perfil Strict do Office Open XML, crie uma instância de [PptxOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptxoptions/) e use seu método [setConformance](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptxoptions/#setConformance) com [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pt/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Em seguida, passe as opções ao método [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo ZIP padrão limita o tamanho compactado e descompactado de cada entrada, o tamanho total do arquivo e o número de entradas. Como um arquivo PPTX é um arquivo ZIP, uma apresentação muito grande pode exceder esses limites. As extensões ZIP64 elevam os limites de tamanho e contagem de entradas aplicáveis.

Use o método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptxoptions/#setZip64Mode) para controlar se o Aspose.Slides grava extensões ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zip64mode/#IfNecessary) usa ZIP64 somente quando a apresentação excede os limites padrão de ZIP. Este é o modo padrão.
- [Never](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zip64mode/#Never) desabilita extensões ZIP64.
- [Always](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zip64mode/#Always) sempre grava extensões ZIP64.

O exemplo a seguir sempre habilita extensões ZIP64 para a apresentação de saída:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Aviso" %}}
Se [Zip64Mode.Never](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zip64mode/#Never) for usado e a apresentação não couber nos limites padrão de ZIP, a operação de salvamento lançará uma [PptxException](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Salvar apresentações no formato Office Open XML com níveis de compressão**

Para saída PPTX, você pode equilibrar a velocidade de salvamento com o tamanho do arquivo usando o método [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptxoptions/#setCompressionLevel). A classe [CompressionLevel](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compressionlevel/) fornece os seguintes valores:

- [None](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compressionlevel/#None) armazena dados sem compressão.
- [Level1](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compressionlevel/#Level1) fornece a compressão mais rápida e o maior tamanho de saída compactado.
- [Level2](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compressionlevel/#Level2) até [Level5](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compressionlevel/#Level5) favorecem progressivamente uma saída menor em detrimento da velocidade de salvamento.
- [Level6](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compressionlevel/#Level6) equilibra a velocidade de salvamento e o tamanho do arquivo. Este é o nível padrão.
- [Level7](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compressionlevel/#Level7) e [Level8](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compressionlevel/#Level8) favorecem ainda mais uma saída menor em detrimento da velocidade de salvamento.
- [Level9](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compressionlevel/#Level9) fornece a compressão mais forte e requer o maior tempo de processamento.

O exemplo a seguir salva uma apresentação sem compressão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

O exemplo a seguir usa o nível máximo de compressão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Salvar apresentações sem atualizar a miniatura**

Quando uma apresentação é salva como PPTX, o método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla a miniatura do documento:

- `True` regenera a miniatura durante a operação de salvamento. Este é o valor padrão.
- `False` preserva a miniatura existente. Se a apresentação não tem miniatura, o Aspose.Slides não gera uma.

O exemplo a seguir salva uma apresentação sem atualizar sua miniatura:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
Desativar a atualização da miniatura pode reduzir o tempo necessário para salvar um arquivo PPTX.
{{% /alert %}}

## **Salvar atualizações de progresso em porcentagem**

Para monitorar uma operação de salvamento, registre um manipulador de progresso em Python via `jpype.JProxy` e passe-o ao método [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveoptions/#setProgressCallback). O Aspose.Slides então chama o método `reporting` do manipulador com valores de progresso durante a exportação.

O exemplo a seguir relata o progresso de uma exportação PDF no console:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
Aspose fornece um [PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) gratuito construído com a API Aspose.Slides. Ele salva slides selecionados de uma apresentação como arquivos PPT ou PPTX separados.
{{% /alert %}}

## **Perguntas frequentes**

**O Aspose.Slides suporta salvamento incremental ou “salvamento rápido”?**

Não. Cada operação de salvamento grava um arquivo de saída completo, em vez de atualizar apenas as partes alteradas.

**Vários threads podem salvar a mesma instância de Presentation?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) [não é thread-safe](/slides/pt/python-java/multithreading/). Acesse e salve cada instância a partir de apenas um thread por vez.

**O que acontece com hyperlinks e arquivos vinculados externamente quando eu salvo uma apresentação?**

[Hyperlinks](/slides/pt/python-java/manage-hyperlinks/) permanecem na apresentação. O Aspose.Slides não copia arquivos vinculados externamente, portanto a apresentação salva ainda deve ser capaz de acessar suas localizações.

**Posso salvar metadados do documento, como autor, título, empresa e data de criação?**

Sim. Defina as [propriedades do documento](/slides/pt/python-java/presentation-properties/) apropriadas antes de salvar, e o Aspose.Slides as grava no arquivo de saída.