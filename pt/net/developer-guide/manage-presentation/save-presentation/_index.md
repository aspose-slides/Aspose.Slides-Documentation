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
- atualizar miniatura
- progresso de salvamento
- .NET
- C#
- Aspose.Slides
description: "Descubra como salvar apresentações em .NET usando Aspose.Slides—exportar para PowerPoint ou OpenDocument mantendo layouts, fontes e efeitos."
---
## **Visão geral**

[Open Presentations in C#](/slides/pt/net/open-presentation/) descreveu como usar a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você desejará salvá‑la quando terminar. Com Aspose.Slides for .NET, você pode salvar em um **arquivo** ou **fluxo**. Este artigo explica as diferentes maneiras de salvar uma apresentação.

## **Salvar apresentações em arquivos**

Salve uma apresentação em um arquivo chamando o método `Save` da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento para o método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides.

```cs
// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Fazer algum trabalho aqui...

    // Salvar a apresentação em um arquivo.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Salvar apresentações em streams**

Você pode salvar uma apresentação em um stream passando um stream de saída para o método `Save` da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). Uma apresentação pode ser gravada em vários tipos de stream. No exemplo abaixo, criamos uma nova apresentação e a salvamos em um stream de arquivo.

```cs
// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Salvar a apresentação no stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Salvar apresentações com um tipo de visualização predefinido**

Aspose.Slides permite definir a visualização inicial que o PowerPoint usa quando a apresentação gerada é aberta por meio da classe [ViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/). Defina a propriedade [LastView](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/lastview/) com um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/net/aspose.slides/viewtype/).

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

// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Salvar a apresentação no formato Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Salvar apresentações no formato Office Open XML em modo Zip64**

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) ao tamanho descompactado de qualquer arquivo, ao tamanho compactado de qualquer arquivo e ao tamanho total do arquivo, além de limitar o arquivo ZIP a 65 535 (2^16‑1) arquivos. As extensões de formato ZIP64 elevam esses limites para 2^64.

A propriedade [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipptxoptions/zip64mode/) permite escolher quando usar as extensões de formato ZIP64 ao salvar um arquivo Office Open XML.

Esta propriedade fornece os seguintes modos:

- `IfNecessary` usa as extensões de formato ZIP64 apenas se a apresentação exceder as limitações acima. Este é o modo padrão.
- `Never` nunca usa as extensões de formato ZIP64.
- `Always` sempre usa as extensões de formato ZIP64.

O código a seguir demonstra como salvar uma apresentação como PPTX com as extensões de formato ZIP64 habilitadas:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTA" color="warning" %}}
Quando você salva com `Zip64Mode.Never`, uma [PptxException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxexception/) é lançada se a apresentação não puder ser salva no formato ZIP32.
{{% /alert %}}

## **Salvar apresentações sem atualizar a miniatura**

A propriedade [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) controla a geração de miniaturas ao salvar uma apresentação em PPTX:

- Se definido como `true`, a miniatura é atualizada durante a gravação. Este é o padrão.
- Se definido como `false`, a miniatura atual é preservada. Se a apresentação não tiver miniatura, nenhuma será gerada.

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

{{% alert title="Informação" color="info" %}}
Esta opção ajuda a reduzir o tempo necessário para salvar uma apresentação no formato PPTX.
{{% /alert %}}

## **Salvar atualizações de progresso em porcentagem**

A interface [IProgressCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/iprogresscallback/) é usada por meio da propriedade `ProgressCallback` exposta pela interface [ISaveOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/isaveoptions/) e pela classe abstrata [SaveOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveoptions/). Atribua uma implementação de [IProgressCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/iprogresscallback/) a `ProgressCallback` para receber atualizações de progresso de salvamento em porcentagem.

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
        // Use o valor percentual de progresso aqui.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Informação" color="info" %}}
A Aspose desenvolveu um [app gratuito PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) usando sua própria API. O app permite dividir uma apresentação em vários arquivos salvando os slides selecionados como novos arquivos PPTX ou PPT.
{{% /alert %}}

## **Perguntas frequentes**

**O “salvamento rápido” (salvamento incremental) é suportado para que somente as alterações sejam gravadas?**

Não. Cada salvamento cria o arquivo completo de destino; o “salvamento rápido” incremental não é suportado.

**É seguro em termos de threads salvar a mesma instância de Presentation a partir de múltiplas threads?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) [não é thread‑safe](/slides/pt/net/multithreading/); salve‑a a partir de um único thread.

**O que acontece com hiperlinks e arquivos vinculados externamente ao salvar?**

[Hyperlinks](/slides/pt/net/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos por caminhos relativos) não são copiados automaticamente — certifique‑se de que os caminhos referenciados continuem acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As [propriedades padrão do documento](/slides/pt/net/presentation-properties/) são suportadas e serão gravadas no arquivo ao salvar.