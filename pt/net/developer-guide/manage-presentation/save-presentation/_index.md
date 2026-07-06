---
title: Salvar apresentações em .NET
linktitle: Salvar apresentação
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
- apresentação para stream
- tipo de visualização predefinido
- Formato Strict Office Open XML
- modo Zip64
- atualizando miniatura
- progresso de salvamento
- .NET
- C#
- Aspose.Slides
description: "Descubra como salvar apresentações em .NET usando Aspose.Slides—exportar para PowerPoint ou OpenDocument mantendo layouts, fontes e efeitos."
---
## **Visão geral**

[Apresentações abertas em C#](/slides/pt/net/open-presentation/) descreveu como usar a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você desejará salvá‑la quando terminar. Com Aspose.Slides para .NET, você pode salvar em um **arquivo** ou **stream**. Este artigo explica as diferentes maneiras de salvar uma apresentação.

## **Salvar apresentações em arquivos**

Salve uma apresentação em um arquivo chamando o método `Save` da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento para o método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides.

```cs
// Instancie a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Execute algum trabalho aqui...

    // Salve a apresentação em um arquivo.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Salvar apresentações em streams**

Você pode salvar uma apresentação em um stream passando um stream de saída para o método `Save` da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). Uma apresentação pode ser gravada em muitos tipos de stream. No exemplo abaixo, criamos uma nova apresentação e a salvamos em um file stream.

```cs
// Instancie a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Salve a apresentação no stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Salvar apresentações com um tipo de visualização predefinido**

Aspose.Slides permite definir a visualização inicial que o PowerPoint usa quando a apresentação gerada é aberta por meio da classe [ViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/). Defina a propriedade [LastView](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/lastview/) para um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Salvar apresentações no formato Strict Office Open XML**

Aspose.Slides permite salvar uma apresentação no formato Strict Office Open XML. Use a classe [PptxOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pptxoptions/) e defina sua propriedade de conformidade ao salvar. Se você definir `Conformance.Iso29500_2008_Strict`, o arquivo de saída será salvo no formato Strict Office Open XML.

O exemplo abaixo cria uma apresentação e a salva no formato Strict Office Open XML.

```cs
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

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) ao tamanho descompactado de qualquer arquivo, ao tamanho compactado de qualquer arquivo e ao tamanho total do arquivo, além de limitar o arquivo a 65.535 (2^16‑1) arquivos. As extensões de formato ZIP64 elevam esses limites para 2^64.

A propriedade [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipptxoptions/zip64mode/) permite escolher quando usar as extensões de formato ZIP64 ao salvar um arquivo Office Open XML.

Esta propriedade oferece os seguintes modos:

- `IfNecessary` usa as extensões de formato ZIP64 somente se a apresentação exceder as limitações acima. Este é o modo padrão.
- `Never` nunca usa as extensões de formato ZIP64.
- `Always` sempre usa as extensões de formato ZIP64.

O código a seguir demonstra como salvar uma apresentação como um arquivo PPTX com as extensões de formato ZIP64 habilitadas:

```cs
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

## **Salvar apresentações no formato Office Open XML com níveis de compressão**

Ao trabalhar com apresentações grandes, você pode ajustar o nível de compressão para equilibrar o tamanho do arquivo e o tempo de processamento. Dependendo dos seus requisitos, pode preferir um processamento mais rápido ou arquivos de saída menores.

Aspose.Slides fornece a propriedade [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipptxoptions/compressionlevel/), que permite especificar o nível de compressão usado ao salvar uma apresentação no formato Office Open XML.

Os níveis de compressão disponíveis são:

- **None**: Nenhuma compressão é aplicada. Os arquivos são armazenados como estão.
- **Level1**: A compressão mais rápida com a menor taxa de compressão.
- **Level2**: Compressão mais rápida com uma taxa de compressão ligeiramente melhor que **Level1**.
- **Level3**: Oferece compressão melhor que **Level2** com impacto moderado no tempo de processamento.
- **Level4**: Oferece compressão melhor que **Level3**.
- **Level5**: Oferece compressão aprimorada em relação ao **Level4** com tempo de processamento adicional.
- **Level6**: Compressão padrão que oferece um bom equilíbrio entre velocidade de processamento e tamanho do arquivo. Este é o *nível de compressão padrão*.
- **Level7**: Oferece compressão melhor que **Level6** com processamento mais lento.
- **Level8**: Oferece compressão melhor que **Level7**.
- **Level9**: Compressão máxima. Produz o menor tamanho de arquivo ao custo do maior tempo de processamento.

O exemplo a seguir demonstra como salvar uma apresentação como um arquivo PPTX *sem compressão*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Este exemplo mostra como salvar uma apresentação como um arquivo PPTX com *compressão máxima*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Salvar apresentações sem atualizar a miniatura**

A propriedade [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) controla a geração de miniaturas ao salvar uma apresentação em PPTX:

- Se defini­da como `true`, a miniatura é atualizada durante a gravação. Este é o padrão.
- Se defini­da como `false`, a miniatura atual é preservada. Se a apresentação não possuir miniatura, nenhuma será gerada.

No código abaixo, a apresentação é salva em PPTX sem atualizar sua miniatura.

```cs
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

A interface [IProgressCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/iprogresscallback/) é usada por meio da propriedade `ProgressCallback` exposta pela interface [ISaveOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/isaveoptions/) e pela classe abstrata [SaveOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveoptions/). Atribua uma implementação de [IProgressCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/iprogresscallback/) a `ProgressCallback` para receber atualizações de progresso de salvamento como porcentagem.

Os trechos de código a seguir mostram como usar `IProgressCallback`.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Use o valor da porcentagem de progresso aqui.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
A Aspose desenvolveu um [app gratuito de divisão de PowerPoint](https://products.aspose.app/slides/pt/splitter) usando sua própria API. O app permite dividir uma apresentação em vários arquivos salvando slides selecionados como novos arquivos PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**“Salvar rápido” (salvamento incremental) é suportado para que apenas as alterações sejam gravadas?**

Não. Cada salvamento cria o arquivo de destino completo; o “salvamento rápido” incremental não é suportado.

**É seguro salvar a mesma instância de Presentation a partir de múltiplas threads?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) **não é thread‑safe** (/slides/pt/net/multithreading/); salve‑a a partir de uma única thread.

**O que acontece com hiperlinks e arquivos vinculados externamente ao salvar?**

[Hiperlinks](/slides/pt/net/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos via caminhos relativos) não são copiados automaticamente — certifique‑se de que os caminhos referenciados permaneçam acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As propriedades padrão do [documento](/slides/pt/net/presentation-properties/) são suportadas e serão gravadas no arquivo ao salvar.