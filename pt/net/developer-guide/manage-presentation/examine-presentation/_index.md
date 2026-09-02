---
title: Recuperar e Atualizar Informações da Apresentação em .NET
linktitle: Informações da Apresentação
type: docs
weight: 30
url: /pt/net/examine-presentation/
keywords:
- formato de apresentação
- propriedades da apresentação
- propriedades do documento
- obter propriedades
- ler propriedades
- alterar propriedades
- modificar propriedades
- atualizar propriedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando .NET para obter insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão geral**

Aspose.Slides pode identificar o formato de uma apresentação e ler seus metadados de documento sem criar um modelo completo de objeto de apresentação. Isso é útil quando você precisa classificar arquivos, montar um inventário ou inspecionar propriedades antes de decidir se carrega e processa o conteúdo da apresentação.

Este artigo demonstra a inspeção leve por meio de [PresentationFactory](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/) e [IPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/), bem como atualizações direcionadas por meio de [IDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/).

## **Verificar o formato de uma apresentação**

Use [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/getpresentationinfo/) para inspecionar um arquivo sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). A propriedade [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/loadformat/) relata o formato detectado, como PPTX, PPT ou ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Criar um inventário leve de apresentações**

Ao processar muitos arquivos de apresentação, pode ser necessário um inventário compacto para validação, indexação ou um sistema de gerenciamento de documentos. Nesse cenário, use [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/getpresentationinfo/) para obter um objeto [IPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/) e, em seguida, chame [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/readdocumentproperties/) para ler os metadados do documento. Essa abordagem não cria uma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) nem exige percorrer todo o modelo de objeto da apresentação.

As propriedades estendidas expostas por [IDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/) fornecem os seguintes valores de inventário:

| Propriedade | Valor do inventário |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/slides/pt/) | Número total de slides. |
| [HiddenSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/hiddenslides/) | Número de slides ocultos. |
| [Notes](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/notes/) | Número de slides que contêm notas. |
| [Paragraphs](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/paragraphs/) | Número total de parágrafos, quando disponível. |
| [Words](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/words/) | Número total de palavras. |
| [MultimediaClips](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/multimediaclips/) | Número total de clipes de áudio e vídeo. |

O exemplo a seguir lê esses valores sem criar um objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e imprime um inventário compacto. Ele também combina [HeadingPairs](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/headingpairs/) com [TitlesOfParts](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/titlesofparts/) para exibir grupos de conteúdo como fontes, temas e títulos de slides.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Cada [IHeadingPair](https://reference.aspose.com/slides/pt/net/aspose.slides/iheadingpair/) fornece um nome de grupo e o número de itens naquele grupo. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/titlesofparts/) é uma matriz plana e ordenada, portanto consuma o número de títulos consecutivos especificado por cada par de cabeçalho.

### **Metadados armazenados e limitações de formato**

As propriedades de inventário retornadas por [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/readdocumentproperties/) refletem os metadados disponíveis no documento de origem. Aspose.Slides não carrega e percorre o modelo de objeto da apresentação para recalcular esses valores nesta chamada. Propriedades ausentes são representadas por valores padrão, e os valores armazenados podem estar desatualizados se o aplicativo que salvou o arquivo pela última vez não atualizou suas propriedades de documento.

- **PPTX:** O formato fornece propriedades de documento estendidas para contagens de slide, nota, slide oculto, parágrafo, palavra e multimídia, bem como pares de cabeçalhos e títulos de partes. A disponibilidade depende de quais propriedades foram gravadas pelo produtor do documento.
- **PPT:** O formato binário pode armazenar propriedades de resumo de documento correspondentes. Se uma propriedade estiver ausente ou não for atualizada pelo produtor do documento, Aspose.Slides retorna seu valor armazenado ou padrão em vez de calculá‑lo a partir dos slides.
- **ODP:** Os metadados do OpenDocument fornecem estatísticas gerais do documento, como contagens de página, parágrafo e palavra, mas esses valores não mapeiam para todas as propriedades estendidas específicas do PowerPoint. Metadados de slide oculto, slide de notas, multimídia, pares de cabeçalhos e títulos de partes podem estar indisponíveis, e as propriedades de inventário podem retornar valores padrão. Não trate um valor zero ou uma matriz vazia como prova autoritária de que o conteúdo correspondente está ausente.

Use a abordagem de metadados leves para inventários e verificações preliminares. Carregue a apresentação e inspecione seu modelo de objeto ao vivo quando o resultado precisar refletir mudanças em memória ou quando for necessário verificar o conteúdo real da apresentação.

## **Atualizar propriedades da apresentação**

As propriedades retornadas por [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/readdocumentproperties/) também podem ser alteradas sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). Aplique as alterações com [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) e, em seguida, grave a apresentação vinculada com [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

A imagem a seguir mostra as propriedades originais do documento.

![Propriedades originais do documento da apresentação PowerPoint](input_properties.png)

O exemplo a seguir altera o título e a hora da última gravação e grava o resultado em um novo arquivo:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

A imagem a seguir mostra as propriedades do documento atualizadas.

![Propriedades alteradas do documento da apresentação PowerPoint](output_properties.png)

## **Links úteis**

Para verificações de segurança relacionadas e configurações de proteção, consulte os artigos a seguir:

- [Proteger apresentações com senha](/slides/pt/net/password-protected-presentation/)
- [Proteger apresentações contra gravação](/slides/pt/net/write-protected-presentation/)

## **Perguntas frequentes**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Carregue a apresentação e use [Presentation.FontsManager](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/fontsmanager/). Chame [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/getembeddedfonts/) para obter as fontes incorporadas e [FontsManager.GetFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/getfonts/) para obter as fontes usadas pela apresentação. Compare os dois resultados para encontrar fontes necessárias para renderização que não estejam incorporadas.

**Como posso rapidamente saber se o arquivo tem slides ocultos e quantos?**

Quando os metadados armazenados do documento são suficientes, leia [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/hiddenslides/) por meio de [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/getpresentationinfo/) e [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Isso é adequado para um inventário leve. Se a apresentação foi modificada em memória, os metadados armazenados podem estar ausentes ou desatualizados, ou se precisar verificar valores ao vivo, itere em [Presentation.Slides](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/slides/pt/) e inspecione a propriedade [Slide.Hidden](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/hidden/) de cada slide.

**Posso detectar se um tamanho e orientação de slide personalizados são usados e se diferem dos padrões?**

Sim. Carregue a apresentação e leia [Presentation.SlideSize](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/slidesize/). Inspecione [ISlideSize.Type](https://reference.aspose.com/slides/pt/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/pt/net/aspose.slides/islidesize/size/) e [ISlideSize.Orientation](https://reference.aspose.com/slides/pt/net/aspose.slides/islidesize/orientation/) para comparar as configurações atuais com o preset e as dimensões esperados.

**Existe uma maneira rápida de ver se os gráficos referenciam fontes de dados externas?**

Sim. Localize cada [Chart](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chart/) e inspecione [ChartData.DataSourceType](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/datasourcetype/). Para uma pasta de trabalho externa, leia [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/externalworkbookpath/). O tipo de fonte de dados e o caminho identificam uma referência externa, mas verificar se o alvo está disponível requer uma verificação de recurso separada.

**Como posso avaliar slides 'pesados' que podem desacelerar a renderização ou a exportação para PDF?**

Não há uma única propriedade de complexidade. Percorra [Presentation.Slides](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/slides/pt/) e a coleção [IBaseSlide.Shapes](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/shapes/) de cada slide. Use contagens de formas e a presença de imagens grandes, efeitos, animações ou multimídia como sinais de triagem, e meça uma renderização ou exportação representativa antes de considerar um slide como um gargalo de desempenho confirmado.