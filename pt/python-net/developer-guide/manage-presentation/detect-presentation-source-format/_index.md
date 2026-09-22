---
title: Determinar o Formato Original da Apresentação em Python
linktitle: Formato de Origem
type: docs
weight: 35
url: /pt/python-net/detect-presentation-source-format/
keywords:
- formato de origem
- detectar formato da apresentação
- PowerPoint
- OpenDocument
- apresentação
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Leia o formato original de uma apresentação carregada em Python com Aspose.Slides for Python via .NET, compare as APIs de detecção e manipule arquivos, streams e formatos legados."
---
## **Visão geral**

Depois de carregar uma apresentação, leia a propriedade somente‑leitura [Presentation.source_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/source_format/) para determinar seu formato original. Use‑a quando o processamento subsequente depende do formato a partir do qual a instância atual foi carregada.

O formato de origem é distinto do [SaveFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/) selecionado para um arquivo de saída. Salvar em outro formato não altera o formato de origem da instância existente.

## **Ler o formato de origem de um arquivo**

Este exemplo requer um arquivo `sample.pptx` existente. Ele carrega o arquivo e seleciona uma política de processamento da aplicação usando [Presentation.source_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/source_format/), em vez do nome do arquivo. Altere o caminho de entrada para experimentar outros formatos. O exemplo imprime a política selecionada; substitua as mensagens pela lógica da sua aplicação.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Reconhecer os valores suportados**

A enumeração [SourceFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sourceformat/) distingue os seguintes formatos de apresentação. As extensões abaixo são extensões convencionais, não uma reconstrução do nome de arquivo original.

| Valor SourceFormat | Extensão | Formato |
| --- | --- | --- |
| `PPT` | `.ppt` | Apresentação PowerPoint 97–2003 |
| `PPTX` | `.pptx` | Apresentação Office Open XML |
| `PPTM` | `.pptm` | Apresentação Office Open XML com macro |
| `PPS` | `.pps` | Apresentação de slides PowerPoint 97–2003 |
| `PPSX` | `.ppsx` | Apresentação de slides Office Open XML |
| `PPSM` | `.ppsm` | Apresentação de slides Office Open XML com macro |
| `POT` | `.pot` | Modelo PowerPoint 97–2003 |
| `POTX` | `.potx` | Modelo Office Open XML |
| `POTM` | `.potm` | Modelo Office Open XML com macro |
| `ODP` | `.odp` | Apresentação OpenDocument |
| `OTP` | `.otp` | Modelo de apresentação OpenDocument |
| `FODP` | `.fodp` | Apresentação OpenDocument XML plano |
| `XML` | `.xml` | Apresentação PowerPoint XML |

## **Ler o formato de origem de um fluxo**

Este exemplo requer um arquivo `sample.pps` existente. Ler seus bytes para um fluxo de memória modela a entrada recebida sem um nome de arquivo, como um valor de banco de dados ou um array de bytes enviado. O construtor [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) recebe apenas o fluxo.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS e POT usam o mesmo formato binário subjacente. Ao carregar por caminho de arquivo, a extensão pode ajudar a distinguir uma apresentação de slides ou um modelo. Sem um nome de arquivo, o conteúdo legado PPS e POT pode ser relatado como `SourceFormat.PPT`; o exemplo PPS acima relata `PPT`.

Se sua aplicação precisar preservar a distinção, mantenha o nome de arquivo original ou os metadados de subtipo separadamente. Uma extensão é uma dica útil para esses subtipos legados, mas não deve ser a única base para identificar conteúdo de apresentação arbitrário.

## **Comparar a detecção antes e depois do carregamento**

Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/get_presentation_info/) e [PresentationInfo.load_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/load_format/) quando precisar inspecionar um arquivo antes de carregar seu modelo de objeto de apresentação completo. Use [Presentation.source_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/source_format/) quando a instância já existir.

Este exemplo requer `sample.pptx` e imprime `PPTX` em ambas as verificações. Em produção, escolha a API apropriada para o seu estágio de processamento; uma apresentação já carregada não precisa de uma segunda inspeção apenas para obter seu formato de origem.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

Os resultados têm tipos de enumeração diferentes: [LoadFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sourceformat/). Não os compare lançando seus valores numéricos nem presuma que todo formato possui resultados de detecção idênticos. Na verificação de salvar‑e‑reabrir descrita abaixo, o PowerPoint XML foi relatado como `LoadFormat.UNKNOWN` antes do carregamento e como `SourceFormat.XML` após o carregamento.

## **Manter formatos de origem e de saída separados**

Este exemplo requer `sample.pptx` e grava `converted.odp`. Ele imprime `PPTX` tanto antes quanto depois de salvar a instância original. Apenas a nova instância carregada a partir da saída ODP relata `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Uma apresentação criada do zero com `slides.Presentation()` relata `SourceFormat.PPTX`. Ela não tem arquivo de entrada: esse é o valor padrão para uma instância recém‑criada, não evidência de que um arquivo PPTX foi carregado. Controle se sua aplicação criou ou carregou a instância separadamente se essa distinção for importante.

## **Mapear um formato de origem para uma extensão**

O exemplo a seguir requer `sample.pptx`. Ele mapeia cada valor atualmente suportado de [SourceFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sourceformat/) para uma extensão convencional, sem analisar o nome de arquivo de entrada. O fallback evita atribuir silenciosamente uma extensão a um valor não reconhecido.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Esse mapeamento não converte um arquivo nem recupera um subtipo legado PPS/POT perdido durante o carregamento do fluxo. Para salvar efetivamente, selecione explicitamente um [SaveFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/) ou use a conversão mostrada em [Save Presentations in Their Original Format](/slides/pt/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Verificar formatos salvando e reabrindo**

Este exemplo autocontido cria uma apresentação e grava três arquivos no diretório de trabalho, sobrescrevendo arquivos com os mesmos nomes. Ele reabre cada saída tanto por caminho quanto por um fluxo de memória. Para PPTX e ODP, ambas as rotas relatam o formato salvo. Para PPS, carregar por caminho relata `PPS`, enquanto carregar os mesmos bytes sem nome de arquivo relata `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

A mesma verificação com todos os formatos listados acima produziu estes resultados para apresentações geradas com extensões correspondentes:

| Formato salvo | SourceFormat a partir de caminho de arquivo | SourceFormat a partir de fluxo sem nome |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` respectivamente | Igual ao caminho de arquivo |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` respectivamente | Igual ao caminho de arquivo |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` respectivamente | Igual ao caminho de arquivo |
| ODP, OTP | `ODP`, `OTP` respectivamente | Igual ao caminho de arquivo |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

Nessas verificações, a única normalização de formato de origem foi PPS/POT para `PPT` em fluxos sem nome. A tabela descreve a identificação de formatos, não a preservação de todos os recursos da apresentação durante a conversão.

## **Perguntas frequentes**

**Salvar em ODP altera o formato de origem de uma apresentação carregada de PPTX?**

Não. A instância existente ainda relata `PPTX`. Uma instância carregada a partir do ODP salvo relata `ODP`.

**Um fluxo pode sempre distinguir uma apresentação legada, um show de slides e um modelo?**

Não. PPT, PPS e POT compartilham o formato binário. Mantenha o nome de arquivo ou metadados de subtipo separadamente quando essa distinção for necessária.

**Qual API devo usar se a apresentação já estiver carregada?**

Leia [Presentation.source_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/source_format/). Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/get_presentation_info/) para inspeção antes do carregamento.