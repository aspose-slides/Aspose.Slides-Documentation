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
- Formato Strict Office Open XML
- modo Zip64
- atualizar miniatura
- progresso de salvamento
- .NET
- C#
- Aspose.Slides
description: "Descubra como salvar apresentações em .NET usando Aspose.Slides — exporte para PowerPoint ou OpenDocument mantendo layouts, fontes e efeitos."
---
## **Visão geral**

[Apresentações abertas em C#](/slides/pt/net/open-presentation/) descreve como usar a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você desejará salvá‑la quando terminar. Com Aspose.Slides para .NET, você pode salvar em um **arquivo** ou **fluxo**. Este artigo explica as diferentes maneiras de salvar uma apresentação.

## **Salvar apresentações em arquivos**

Salve uma apresentação em um arquivo chamando o método `Save` da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento para o método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Faça algum trabalho aqui...

    // Salve a apresentação em um arquivo.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Salvar apresentações em fluxos**

Você pode salvar uma apresentação em um fluxo passando um fluxo de saída para o método `Save` da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). Uma apresentação pode ser gravada em vários tipos de fluxo. No exemplo abaixo, criamos uma nova apresentação e a salvamos em um fluxo de arquivo.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Salve a apresentação no fluxo.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Salvar apresentações com um tipo de visualização pré‑definido**

Aspose.Slides permite definir a visualização inicial que o PowerPoint usa quando a apresentação gerada é aberta através da classe [ViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/). Defina a propriedade [LastView](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/lastview/) para um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/net/aspose.slides/viewtype/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Salvar apresentações no formato Strict Office Open XML**

Aspose.Slides permite salvar uma apresentação no formato Strict Office Open XML. Use a classe [PptxOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pptxoptions/) e defina sua propriedade de conformidade ao salvar. Se você definir `Conformance.Iso29500_2008_Strict`, o arquivo de saída será salvo no formato Strict Office Open XML.

O exemplo a seguir cria uma apresentação e a salva no formato Strict Office Open XML.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instancie a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Salve a apresentação no formato Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) no tamanho descompactado de qualquer arquivo, no tamanho compactado de qualquer arquivo e no tamanho total do arquivo, além de limitar o pacote a 65 535 (2^16‑1) arquivos. As extensões de formato ZIP64 elevam esses limites para 2^64.

A propriedade [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipptxoptions/zip64mode/) permite escolher quando usar as extensões de formato ZIP64 ao salvar um arquivo Office Open XML.

Esta propriedade fornece os seguintes modos:

- `IfNecessary` usa extensões de formato ZIP64 somente se a apresentação exceder as limitações acima. Este é o modo padrão.
- `Never` nunca usa extensões de formato ZIP64.
- `Always` sempre usa extensões de formato ZIP64.

O código a seguir demonstra como salvar uma apresentação como um arquivo PPTX com extensões de formato ZIP64 habilitadas:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Ao salvar com `Zip64Mode.Never`, uma [PptxException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxexception/) é lançada se a apresentação não puder ser salva no formato ZIP32.
{{% /alert %}}

## **Salvar apresentações no formato Office Open XML com níveis de compactação**

Ao trabalhar com apresentações grandes, você pode ajustar o nível de compactação para equilibrar o tamanho do arquivo e o tempo de processamento. Dependendo dos seus requisitos, você pode preferir processamento mais rápido ou arquivos de saída menores.

Aspose.Slides fornece a propriedade [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipptxoptions/compressionlevel/), que permite especificar o nível de compactação usado ao salvar uma apresentação no formato Office Open XML.

Os seguintes níveis de compactação estão disponíveis:

- **None**: Nenhuma compactação é aplicada. Os arquivos são armazenados como estão.
- **Level1:** A compactação mais rápida com a menor taxa de compressão.
- **Level2:** Compactação mais rápida com uma taxa de compressão ligeiramente melhor que **Level1**.
- **Level3:** Fornece melhor compactação que **Level2** com impacto moderado no tempo de processamento.
- **Level4:** Fornece melhor compactação que **Level3**.
- **Level5:** Fornece compressão aprimorada em relação a **Level4** com tempo de processamento adicional.
- **Level6:** Compactação padrão que oferece um bom equilíbrio entre velocidade de processamento e tamanho do arquivo. Este é o *nível de compactação padrão*.
- **Level7:** Fornece melhor compactação que **Level6** com processamento mais lento.
- **Level8:** Fornece melhor compactação que **Level7**.
- **Level9:** Compactação máxima. Produz o menor tamanho de arquivo ao custo do maior tempo de processamento.

O exemplo a seguir demonstra como salvar uma apresentação como um arquivo PPTX *sem compactação*:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Este exemplo mostra como salvar uma apresentação como um arquivo PPTX com *compactação máxima*:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Salvar apresentações sem atualizar a miniatura**

A propriedade [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) controla a geração da miniatura ao salvar uma apresentação em PPTX:

- Se definido como `true`, a miniatura é atualizada durante a gravação. Este é o padrão.
- Se definido como `false`, a miniatura atual é preservada. Se a apresentação não possuir miniatura, nenhuma será gerada.

No código abaixo, a apresentação é salva em PPTX sem atualizar sua miniatura.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Esta opção ajuda a reduzir o tempo necessário para salvar uma apresentação no formato PPTX.
{{% /alert %}}

## **Atualizações de progresso de salvamento em porcentagem**

A interface [IProgressCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/iprogresscallback/) é usada via a propriedade `ProgressCallback` exposta pela interface [ISaveOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/isaveoptions/) e pela classe abstrata [SaveOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveoptions/). Atribua uma implementação de [IProgressCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/iprogresscallback/) a `ProgressCallback` para receber atualizações de progresso de salvamento em porcentagem.

Os trechos de código a seguir mostram como usar `IProgressCallback`.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Use o valor percentual de progresso aqui.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
A Aspose desenvolveu um [aplicativo gratuito PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) usando sua própria API. O aplicativo permite dividir uma apresentação em vários arquivos salvando slides selecionados como novos arquivos PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**O “salvamento rápido” (salvamento incremental) é suportado para que apenas as alterações sejam gravadas?**

Não. Cada vez que salva, um arquivo de destino completo é criado; o “salvamento rápido” incremental não é suportado.

**É seguro salvar a mesma instância de Presentation a partir de várias threads?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) [não é thread‑safe](/slides/pt/net/multithreading/); salve‑a a partir de uma única thread.

**O que acontece com hiperlinks e arquivos vinculados externamente ao salvar?**

[Hyperlinks](/slides/pt/net/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos via caminhos relativos) não são copiados automaticamente — certifique‑se de que os caminhos referenciados permaneçam acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As [propriedades padrão do documento](/slides/pt/net/presentation-properties/) são suportadas e serão gravadas no arquivo ao salvar.