---
title: Salvar Apresentações em .NET
linktitle: Salvar Apresentação
type: docs
weight: 80
url: /pt/net/save-presentation/
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
- Formato Estrito Office Open XML
- modo Zip64
- atualizando miniatura
- progresso de salvamento
- .NET
- C#
- Aspose.Slides
description: "Salve apresentações PowerPoint e OpenDocument em arquivos ou fluxos em C# com Aspose.Slides para .NET, e configure a saída PPTX e o relatório de progresso."
---
## **Visão geral**

Depois de criar uma apresentação ou [abrir uma existente](/slides/pt/net/open-presentation/), use o método [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) para gravar o resultado. Aspose.Slides for .NET pode salvar uma apresentação em um arquivo ou fluxo nos formatos PowerPoint, OpenDocument, PDF e outros. As seções a seguir cobrem as operações padrão de salvamento e as opções disponíveis para saída PPTX.

## **Salvar Apresentações em Arquivos**

Para salvar uma apresentação em um arquivo, passe o caminho de saída e um valor [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/) ao método [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/). O valor do formato determina o tipo de arquivo que o Aspose.Slides cria.

O exemplo a seguir cria uma apresentação e a salva como um arquivo PPTX:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Adicionar ou modificar o conteúdo da apresentação aqui.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Salvar Apresentações no Seu Formato Original**

Para exemplos de detecção de arquivos e fluxos, o comportamento de apresentações recém‑criadas e a distinção entre formatos de origem e de saída, veja [Determinar o Formato Original da Apresentação](/slides/pt/net/detect-presentation-source-format/).

Em um aplicativo de processamento em lote, o formato de entrada pode não ser conhecido com antecedência. Depois de carregar um arquivo, leia seu formato original da propriedade [IPresentation.SourceFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/sourceformat/). Passe o valor resultante de [SourceFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/sourceformat/) para [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/tosaveformat/) a fim de obter o correspondente valor de [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/) e, em seguida, use [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) para gravar a apresentação modificada.

O exemplo completo a seguir processa cada arquivo em um diretório de entrada, atualiza seu título e o salva em um diretório de saída no formato em que foi carregado:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/tosaveformat/) mapeia PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML para seus respectivos formatos de salvamento de apresentação. Ele mapeia apenas formatos de origem de apresentação; não é destinado a selecionar formatos de exportação como PDF, HTML, TIFF ou imagens. Passar um valor de [SourceFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/sourceformat/) não suportado ou inválido resulta em um [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

Arquivos legados PPT, PPS e POT usam o mesmo contêiner binário. Quando tal apresentação é carregada a partir de um fluxo sem extensão de arquivo, um arquivo PPS ou POT pode, portanto, ser identificado como PPT. Se for necessário preservar esses subtipos legados, retenha o nome de arquivo original ou os metadados de formato separadamente e use‑os ao escolher o nome de arquivo e o formato de saída.

## **Salvar Apresentações em Fluxos**

Para gravar uma apresentação sem depender de um caminho de arquivo final, passe um [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) gravável e um valor [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/) ao método [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/). Essa abordagem é útil quando a saída deve ser retornada de um serviço web, armazenada em um banco de dados ou processada na memória.

O exemplo a seguir salva uma nova apresentação em um fluxo de arquivo:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Salvar Apresentações com um Tipo de Exibição Pré‑definido**

É possível especificar a visualização na qual o PowerPoint abre inicialmente uma apresentação salva. Defina a propriedade [ViewProperties.LastView](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/lastview/) para um valor [ViewType](https://reference.aspose.com/slides/pt/net/aspose.slides/viewtype/) antes de salvar.

O exemplo a seguir configura a visualização Slide Master como a visualização inicial:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Salvar Apresentações no Formato Estrito Office Open XML**

Para criar um arquivo PPTX que esteja em conformidade com o perfil Strict do Office Open XML, crie uma instância de [PptxOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pptxoptions/) e defina sua propriedade [Conformance](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pptxoptions/conformance/) para `Conformance.Iso29500_2008_Strict`. Em seguida, passe as opções ao método [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Salvar Apresentações no Formato Office Open XML no Modo Zip64**

Um arquivo ZIP padrão limita o tamanho comprimido e descomprimido de cada entrada, o tamanho total do arquivo e o número de entradas. Como um arquivo PPTX é um arquivo ZIP, uma apresentação muito grande pode exceder esses limites. As extensões ZIP64 aumentam os limites de tamanho e de contagem de entradas.

Use a propriedade [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pptxoptions/zip64mode/) para controlar se o Aspose.Slides grava extensões ZIP64:

- `IfNecessary` usa ZIP64 somente quando a apresentação excede os limites padrão de ZIP. Este é o modo padrão.
- `Never` desabilita extensões ZIP64.
- `Always` grava sempre extensões ZIP64.

O exemplo a seguir sempre habilita extensões ZIP64 para a apresentação de saída:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
Se `Zip64Mode` for definido como `Never` e a apresentação não couber nos limites padrão de ZIP, a operação de salvamento lançará um [PptxException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Salvar Apresentações no Formato Office Open XML com Níveis de Compressão**

Para saída PPTX, você pode equilibrar a velocidade de salvamento contra o tamanho do arquivo definindo a propriedade [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pptxoptions/compressionlevel/). A enumeração [CompressionLevel](https://reference.aspose.com/slides/pt/net/aspose.slides.export/compressionlevel/) fornece esses valores:

- `None` armazena os dados sem compressão.
- `Level1` oferece a compressão mais rápida e o maior tamanho compactado.
- `Level2` a `Level5` favorecem progressivamente um tamanho menor em detrimento da velocidade de salvamento.
- `Level6` equilibra velocidade de salvamento e tamanho do arquivo. Este é o nível padrão.
- `Level7` e `Level8` favorecem ainda mais um tamanho menor sobre a velocidade.
- `Level9` fornece a compressão mais forte e requer mais tempo de processamento.

O exemplo a seguir salva uma apresentação sem compressão:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

O exemplo a seguir usa o nível máximo de compressão:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Salvar Apresentações sem Atualizar a Miniatura**

Quando uma apresentação é salva como PPTX, a propriedade [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pptxoptions/refreshthumbnail/) controla sua miniatura de documento:

- `true` regenera a miniatura durante a operação de salvamento. Este é o valor padrão.
- `false` preserva a miniatura existente. Se a apresentação não possuir miniatura, o Aspose.Slides não gera uma.

O exemplo a seguir salva uma apresentação sem atualizar sua miniatura:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
Desabilitar a atualização da miniatura pode reduzir o tempo necessário para salvar um arquivo PPTX.
{{% /alert %}}

## **Salvar Atualizações de Progresso em Percentual**

Para monitorar uma operação de salvamento, implemente a interface [IProgressCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/iprogresscallback/) e atribua a implementação à propriedade [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/pt/net/aspose.slides.export/isaveoptions/progresscallback/). O Aspose.Slides então chama o método [IProgressCallback.Reporting](https://reference.aspose.com/slides/pt/net/aspose.slides/iprogresscallback/reporting/) com valores de progresso durante a exportação.

O exemplo a seguir relata o progresso da exportação de PDF no console:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
A Aspose oferece um [PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) gratuito construído com a API Aspose.Slides. Ele salva slides selecionados de uma apresentação como arquivos PPT ou PPTX separados.
{{% /alert %}}

## **FAQ**

**O Aspose.Slides oferece suporte a salvamento incremental ou “salvamento rápido”?**

Não. Cada operação de salvamento grava um arquivo de saída completo em vez de atualizar apenas as partes alteradas.

**Vários threads podem salvar a mesma instância de Presentation?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) [não é thread‑safe](/slides/pt/net/multithreading/). Acesse e salve cada instância a partir de apenas um thread por vez.

**O que acontece com hyperlinks e arquivos vinculados externamente quando salvo uma apresentação?**

[Hyperlinks](/slides/pt/net/manage-hyperlinks/) permanecem na apresentação. O Aspose.Slides não copia arquivos vinculados externamente, portanto a apresentação salva ainda deve ser capaz de acessar seus locais.

**Posso salvar metadados do documento, como autor, título, empresa e data de criação?**

Sim. Defina as [propriedades do documento](/slides/pt/net/presentation-properties/) apropriadas antes de salvar, e o Aspose.Slides as grava no arquivo de saída.