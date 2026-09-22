---
title: "Determinar o Formato Original da Apresentação em Python via Java"
linktitle: "Formato de Origem"
type: docs
weight: 35
url: /pt/python-java/detect-presentation-source-format/
keywords:
- "formato de origem"
- "detectar formato de apresentação"
- PowerPoint
- OpenDocument
- "apresentação"
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Leia o formato original de uma apresentação carregada em Python via Java com Aspose.Slides for Python via Java, compare APIs de detecção e trate arquivos, streams e formatos legados."
---
## **Visão geral**

Depois de carregar uma apresentação, chame o método [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSourceFormat) para determinar seu formato original. Use-o quando o processamento subsequente depender do formato a partir do qual a instância atual foi carregada.

O formato de origem é distinto do [SaveFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/) selecionado para um arquivo de saída. Salvar em outro formato não altera o formato de origem da instância existente.

Os exemplos requerem Aspose.Slides para Python via Java e um runtime Java compatível. Cada exemplo inicia a JVM se ela ainda não estiver em execução.

## **Ler o Formato de Origem de um Arquivo**

Este exemplo requer um arquivo `sample.pptx` existente. Ele carrega o arquivo e seleciona uma política de processamento da aplicação usando [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSourceFormat), ao invés do nome do arquivo. Altere o caminho de entrada para testar outros formatos. O exemplo imprime a política selecionada; substitua as mensagens pela lógica da sua aplicação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Reconhecer os Valores Suportados**

A classe [SourceFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sourceformat/) define constantes inteiras que distinguem os seguintes formatos de apresentação. As extensões abaixo são extensões convencionais, não uma reconstrução do nome de arquivo original.

| Valor SourceFormat | Extensão | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Apresentação PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Apresentação Office Open XML |
| `Pptm` | `.pptm` | Apresentação Office Open XML habilitada para macros |
| `Pps` | `.pps` | Apresentação de slides PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Apresentação de slides Office Open XML |
| `Ppsm` | `.ppsm` | Apresentação de slides Office Open XML habilitada para macros |
| `Pot` | `.pot` | Modelo PowerPoint 97–2003 |
| `Potx` | `.potx` | Modelo Office Open XML |
| `Potm` | `.potm` | Modelo Office Open XML habilitado para macros |
| `Odp` | `.odp` | Apresentação OpenDocument |
| `Otp` | `.otp` | Modelo de apresentação OpenDocument |
| `Fodp` | `.fodp` | Apresentação OpenDocument XML plana |
| `Xml` | `.xml` | Apresentação PowerPoint XML |

## **Ler o Formato de Origem de um Fluxo**

Este exemplo requer um arquivo `sample.pps` existente. Ler seus bytes em um fluxo de memória modela a entrada recebida sem um nome de arquivo, como um valor de banco de dados ou um array de bytes enviado. O construtor [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) recebe apenas o fluxo. O Python lê os bytes do arquivo e o JPype os converte em um array de bytes Java para o fluxo de memória Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS e POT usam o mesmo formato binário subjacente. Ao carregar por caminho de arquivo, a extensão pode ajudar a distinguir uma apresentação de slides ou um modelo. Sem um nome de arquivo, o conteúdo legado de PPS e POT pode ser relatado como `SourceFormat.Ppt`; o exemplo de PPS acima imprime o valor inteiro de `SourceFormat.Ppt`.

Se sua aplicação precisar preservar a distinção, mantenha o nome de arquivo original ou os metadados de subtipo separadamente. Uma extensão é uma dica útil para esses subtipos legados, mas não deve ser a única base para identificar conteúdo de apresentação arbitrário.

## **Comparar a Detecção Antes e Depois do Carregamento**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationfactory/#getPresentationInfo) e [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#getLoadFormat) quando precisar inspecionar um arquivo antes de carregar seu modelo completo de objeto de apresentação. Use [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSourceFormat) quando a instância já existir.

Este exemplo requer `sample.pptx` e imprime os valores inteiros de `LoadFormat.Pptx` e `SourceFormat.Pptx`, respectivamente. Em produção, escolha a API adequada à sua fase de processamento; uma apresentação já carregada não precisa de uma segunda inspeção apenas para obter seu formato de origem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Os resultados usam constantes de classes diferentes: [LoadFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sourceformat/). Não compare seus valores numéricos nem presuma que todo formato tem resultados de detecção idênticos. O PowerPoint XML pode ser relatado como `LoadFormat.Unknown` antes do carregamento e `SourceFormat.Xml` após o carregamento.

## **Manter Formatos de Origem e Saída Separados**

Este exemplo requer `sample.pptx` e grava `converted.odp`. Ele imprime o valor inteiro de `SourceFormat.Pptx` tanto antes quanto depois de salvar a instância original. Apenas a nova instância carregada a partir da saída ODP relata `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Uma apresentação criada do zero com `Presentation()` relata `SourceFormat.Pptx`. Ela não tem arquivo de entrada: este é o valor padrão para uma instância recém‑criada, não evidência de que um arquivo PPTX foi carregado. Controle separadamente se sua aplicação criou ou carregou a instância, caso essa distinção seja importante.

## **Mapear um Formato de Origem para uma Extensão**

O exemplo a seguir requer `sample.pptx`. Ele mapeia cada valor atualmente suportado de [SourceFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sourceformat/) para uma extensão convencional, sem analisar o nome do arquivo de entrada. O fallback evita atribuir silenciosamente uma extensão a um valor não reconhecido.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Esse mapeamento não converte um arquivo nem recupera um subtipo legado PPS/POT perdido durante o carregamento do stream. Para salvar realmente, selecione um [SaveFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/) explicitamente, ou use a conversão mostrada em [Save Presentations in Their Original Format](/slides/pt/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Verificar Formatos Salvando e Reabrindo**

Este exemplo autocontido cria uma apresentação e grava três arquivos no diretório de trabalho, sobrescrevendo arquivos com os mesmos nomes. Ele reabre cada saída tanto por caminho quanto por um fluxo de memória. Para PPTX e ODP, ambas as rotas relatam o formato salvo. Para PPS, o carregamento por caminho relata `Pps`, enquanto o carregamento dos mesmos bytes sem nome de arquivo relata `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

A tabela a seguir resume a identificação do formato de origem para apresentações com extensões correspondentes. Os nomes denotam constantes; os exemplos em Python imprimem seus valores inteiros:

| Formato salvo | SourceFormat a partir de um caminho de arquivo | SourceFormat a partir de um stream sem nome |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivamente | Mesmo que o caminho do arquivo |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivamente | Mesmo que o caminho do arquivo |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivamente | Mesmo que o caminho do arquivo |
| ODP, OTP | `Odp`, `Otp` respectivamente | Mesmo que o caminho do arquivo |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

O conteúdo PPS/POT é identificado como `Ppt` para streams sem nome. A tabela descreve a identificação de formato, não a preservação de todos os recursos da apresentação durante a conversão.

## **FAQ**

**Salvar em ODP altera o formato de origem de uma apresentação carregada a partir de PPTX?**

Não. A instância existente ainda relata `Pptx`. Uma instância carregada a partir do arquivo ODP salvo relata `Odp`.

**Um stream pode sempre distinguir uma apresentação legada, um slideshow e um modelo?**

Não. PPT, PPS e POT compartilham o formato binário. Mantenha o nome de arquivo ou os metadados de subtipo separadamente quando essa distinção for necessária.

**Qual API devo usar se a apresentação já estiver carregada?**

Leia [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSourceFormat). Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationfactory/#getPresentationInfo) para inspeção antes do carregamento.