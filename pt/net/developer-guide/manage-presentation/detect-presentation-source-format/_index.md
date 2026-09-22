---
title: Determinar o Formato Original da Apresentação em .NET
linktitle: Formato de Origem
type: docs
weight: 35
url: /pt/net/detect-presentation-source-format/
keywords:
- formato de origem
- detectar formato de apresentação
- PowerPoint
- OpenDocument
- apresentação
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Leia o formato original de uma apresentação carregada em C# com Aspose.Slides para .NET, compare as APIs de detecção e manipule arquivos, streams e formatos legados."
---
## **Visão geral**

Após carregar uma apresentação, leia a propriedade somente leitura [Presentation.SourceFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sourceformat/) para determinar seu formato original. A propriedade também está disponível através de [IPresentation.SourceFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/sourceformat/). Use-a quando o processamento subsequente depender do formato a partir do qual a instância atual foi carregada.

O formato de origem é distinto do [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/) selecionado para um arquivo de saída. Salvar em outro formato não altera o formato de origem da instância existente.

## **Ler o Formato de Origem de um Arquivo**

Este exemplo requer um arquivo `sample.pptx` existente. Ele carrega o arquivo e seleciona uma política de processamento de aplicação usando [Presentation.SourceFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sourceformat/), em vez do nome do arquivo. Altere o caminho de entrada para experimentar outros formatos. O exemplo imprime a política selecionada; substitua as mensagens pela lógica da sua aplicação.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **Reconhecer os Valores Suportados**

A enumeração [SourceFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/sourceformat/) diferencia os seguintes formatos de apresentação. As extensões abaixo são extensões convencionais, não uma reconstrução do nome de arquivo original.

| Valor SourceFormat | Extensão | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Apresentação PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Apresentação Office Open XML |
| `Pptm` | `.pptm` | Apresentação Office Open XML com macro |
| `Pps` | `.pps` | Apresentação de slides PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Apresentação de slides Office Open XML |
| `Ppsm` | `.ppsm` | Apresentação de slides Office Open XML com macro |
| `Pot` | `.pot` | Modelo PowerPoint 97–2003 |
| `Potx` | `.potx` | Modelo Office Open XML |
| `Potm` | `.potm` | Modelo Office Open XML com macro |
| `Odp` | `.odp` | Apresentação OpenDocument |
| `Otp` | `.otp` | Modelo de apresentação OpenDocument |
| `Fodp` | `.fodp` | Apresentação ODF XML plano |
| `Xml` | `.xml` | Apresentação PowerPoint XML |

## **Ler o Formato de Origem de um Stream**

Este exemplo requer um arquivo `sample.pps` existente. Ler seus bytes em um fluxo de memória modela a entrada recebida sem um nome de arquivo, como um valor de banco de dados ou um array de bytes carregado. O construtor [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) recebe apenas o stream.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS e POT usam o mesmo formato binário subjacente. Ao carregar por caminho de arquivo, a extensão pode ajudar a distinguir um slide show ou modelo. Sem um nome de arquivo, o conteúdo legado PPS e POT pode ser relatado como `SourceFormat.Ppt`; o exemplo PPS acima relata `Ppt`.

Se sua aplicação precisar preservar essa distinção, mantenha o nome de arquivo original ou os metadados de subtipo separadamente. Uma extensão é uma dica útil para esses subtipos legados, mas não deve ser a única base para identificar conteúdo arbitrário de apresentação.

## **Comparar a Detecção Antes e Depois do Carregamento**

Use [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/getpresentationinfo/) e [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/loadformat/) quando precisar inspecionar um arquivo antes de carregar seu modelo de objeto de apresentação completo. Use [Presentation.SourceFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sourceformat/) quando a instância já existir.

Este exemplo requer `sample.pptx` e imprime `Pptx` para ambas as verificações. Em produção, escolha a API apropriada ao seu estágio de processamento; uma apresentação já carregada não necessita de uma segunda inspeção apenas para obter seu formato de origem.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Os resultados têm tipos de enumeração diferentes: [LoadFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/sourceformat/). Não os compare convertendo seus valores numéricos ou presumindo que cada formato tem resultados de detecção idênticos. Na verificação de salvar‑e‑reabrir descrita abaixo, o PowerPoint XML foi relatado como `LoadFormat.Unknown` antes do carregamento e `SourceFormat.Xml` após o carregamento.

## **Manter Formatos de Origem e de Saída Separados**

Este exemplo requer `sample.pptx` e grava `converted.odp`. Ele imprime `Pptx` tanto antes quanto depois de salvar a instância original. Apenas a nova instância carregada a partir da saída ODP relata `Odp`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

Uma apresentação criada do zero com `new Presentation()` relata `SourceFormat.Pptx`. Ela não tem arquivo de entrada: esse é o valor padrão para uma instância recém‑criada, não evidência de que um arquivo PPTX foi carregado. Controle se sua aplicação criou ou carregou a instância separadamente se essa distinção for importante.

## **Mapear um Formato de Origem para uma Extensão**

O exemplo a seguir requer `sample.pptx`. Ele mapeia cada valor atualmente suportado de [SourceFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/sourceformat/) para uma extensão convencional, sem analisar o nome de arquivo de entrada. O fallback evita atribuir silenciosamente uma extensão a um valor não reconhecido.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

Esse mapeamento não converte um arquivo nem recupera um subtipo legado PPS/POT perdido durante o carregamento por stream. Para salvamento efetivo, selecione explicitamente um [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/) ou use a conversão mostrada em [Save Presentations in Their Original Format](/slides/pt/net/save-presentation/#save-presentations-in-their-original-format).

## **Verificar Formatos Salvando e Reabrindo**

Este exemplo independente cria uma apresentação e grava três arquivos no diretório de trabalho, substituindo arquivos com os mesmos nomes. Ele reabre cada saída tanto por caminho quanto por meio de um fluxo de memória. Para PPTX e ODP, ambas as rotas relatam o formato salvo. Para PPS, o carregamento por caminho relata `Pps`, enquanto o carregamento dos mesmos bytes sem nome de arquivo relata `Ppt`.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

A mesma verificação com todos os formatos listados acima produziu estes resultados para apresentações geradas com extensões correspondentes:

| Formato salvo | SourceFormat a partir de caminho de arquivo | SourceFormat a partir de stream sem nome |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivamente | Igual ao caminho de arquivo |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivamente | Igual ao caminho de arquivo |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivamente | Igual ao caminho de arquivo |
| ODP, OTP | `Odp`, `Otp` respectivamente | Igual ao caminho de arquivo |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Nessas verificações, a única normalização de formato‑origem foi PPS/POT para `Ppt` em streams sem nome. A tabela descreve a identificação de formato, não a preservação de todos os recursos da apresentação durante a conversão.

## **FAQ**

**Salvar para ODP altera o formato de origem de uma apresentação carregada a partir de PPTX?**

Não. A instância existente ainda relata `Pptx`. Uma instância carregada a partir do ODP salvo relata `Odp`.

**Um stream pode sempre distinguir uma apresentação legada, um slide show e um modelo?**

Não. PPT, PPS e POT compartilham o formato binário. Mantenha o nome de arquivo ou os metadados de subtipo separadamente quando essa distinção for necessária.

**Qual API devo usar se a apresentação já estiver carregada?**

Leia [Presentation.SourceFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sourceformat/). Use [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/getpresentationinfo/) para inspeção antes do carregamento.