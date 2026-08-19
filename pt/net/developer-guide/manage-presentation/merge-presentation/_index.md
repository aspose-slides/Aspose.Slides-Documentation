---
title: Mesclar apresentações de forma eficiente em .NET
linktitle: Mesclar apresentações
type: docs
weight: 40
url: /pt/net/merge-presentation/
keywords:
- mesclar PowerPoint
- mesclar apresentações
- mesclar slides
- mesclar PPT
- mesclar PPTX
- mesclar ODP
- combinar PowerPoint
- combinar apresentações
- combinar slides
- combinar PPT
- combinar PPTX
- combinar ODP
- .NET
- C#
- Aspose.Slides
description: "Aprenda como mesclar apresentações PowerPoint e OpenDocument em .NET clonando slides, controlando mestres e layouts, redimensionando o conteúdo dos slides, preservando seções e lidando com arquivos protegidos ou grandes."
---
## **Visão geral**

Aspose.Slides for .NET mescla apresentações clonando slides de uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) para outra. A operação principal é [ISlideCollection.AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/), que pode preservar a formatação do slide de origem ou anexar o slide clonado a um mestre ou layout na apresentação de destino.

Este artigo cobre os fluxos de trabalho de mesclagem mais comuns:

- mesclar todos os slides preservando a formatação de origem;
- mesclar slides selecionados;
- aplicar um mestre da apresentação de destino;
- aplicar um layout específico da apresentação de destino;
- normalizar diferentes tamanhos de slide antes da mesclagem;
- adicionar slides clonados a uma seção;
- mesclar várias apresentações em um fluxo de trabalho de ponta a ponta;
- tratar mestres, recursos, notas, comentários, mídia, fontes, senhas, arquivos grandes e questões de multithreading.

## **Como a clonagem de slides afeta mestres e layouts**

Um slide herda grande parte de sua aparência do layout e do mestre. Por esse motivo, a sobrecarga de clonagem que você escolher determina como o slide mesclado é integrado à apresentação de destino.

Use [ISlideCollection.AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/) de uma destas maneiras:

- `AddClone(sourceSlide)` — preserva o layout e a formatação do slide de origem. Quando necessário, o mestre de origem pode ser clonado automaticamente para a apresentação de destino. Aspose.Slides rastreia mestres clonados automaticamente para que slides repetidos que usam o mesmo mestre de origem não causem clonagem múltipla desse mestre.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — anexa o slide clonado a um [IMasterSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslide/) de destino específico. Aspose.Slides procura um layout correspondente sob esse mestre por tipo ou nome de layout.
- `AddClone(sourceSlide, destinationLayout)` — anexa o slide clonado diretamente a um [ILayoutSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/) de destino específico.

O mestre ou layout passado para uma sobrecarga `AddClone` deve pertencer à **apresentação de destino**, não à apresentação de origem.

## **Mesclar apresentações inteiras e preservar a formatação de origem**

A mesclagem mais simples copia cada slide da apresentação de origem para a apresentação de destino. Essa é a escolha apropriada quando os slides importados devem manter seu tema, mestre e relacionamentos de layout originais.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

A apresentação resultante pode conter vários mestres quando a origem e o destino usam designs diferentes. Isso é esperado quando a formatação de origem é intencionalmente preservada.

## **Mesclar slides selecionados**

Você não precisa clonar todos os slides. O exemplo a seguir importa apenas os índices de slide selecionados da apresentação de origem.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Valide os índices de slide antes de clonar quando eles vierem de entrada do usuário ou de configuração externa.

## **Mesclar slides usando um mestre de destino**

Use a sobrecarga [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/) quando os slides importados devem seguir um mestre que já pertence à apresentação de destino.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides seleciona um layout apropriado sob o mestre especificado correspondendo ao tipo ou nome do layout de origem. Se nenhum layout adequado existir e `allowCloneMissingLayout` for `true`, o layout de origem será clonado para que o slide possa ser adicionado. Se for `false`, uma [PptxEditException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxeditexception/) será lançada.

Use `false` quando quiser que a mesclagem falhe em vez de introduzir um layout adicional no mestre de destino.

## **Mesclar slides usando um layout de destino específico**

Use a sobrecarga [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/) quando você souber exatamente qual layout de destino os slides importados devem usar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Aplicar um layout de destino altera o relacionamento de layout herdado; não redesenha o conteúdo do slide de origem. Se os layouts de origem e destino possuem estruturas de espaço reservado diferentes, inspecione o resultado para confirmar que a formatação herdada e o comportamento dos espaços reservados são adequados.

## **Mesclar apresentações com diferentes tamanhos de slide**

Apresentações com dimensões de slide diferentes podem ser mescladas, mas clonar um slide em uma apresentação com outro tamanho de slide não redesenha automaticamente seu conteúdo para a nova área de desenho. Formas podem aparecer deslocadas, dimensionadas inesperadamente ou fora da área visível do slide.

Uma abordagem prática é redimensionar a apresentação de origem antes de clonar. O método [SlideSize.SetSize](https://reference.aspose.com/slides/pt/net/aspose.slides/slidesize/setsize/) pode escalar o conteúdo existente enquanto altera as dimensões do slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pt/net/aspose.slides/slidesizescaletype/) ajusta o conteúdo para caber no tamanho solicitado.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Redimensionar altera o objeto da apresentação de origem na memória. Se precisar da apresentação de origem original inalterada para outras operações, abra uma instância separada para a mesclagem.

## **Mesclar slides em uma seção de apresentação**

O loop básico de clonagem de slides não recria a hierarquia de seções da apresentação de origem. Se as seções forem importantes na saída, crie ou selecione seções na apresentação de destino e clone os slides nelas explicitamente com [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

Os slides clonados são anexados à seção de destino especificada. Para preservar várias seções de origem, recrie essas seções no destino e mapeie cada slide de origem para a seção de destino correspondente.

## **Mesclar múltiplas apresentações com segurança**

O exemplo de ponta a ponta a seguir usa a primeira apresentação como destino, normaliza o tamanho de slide de cada origem adicional, mantém cada origem aberta apenas enquanto está sendo copiada e salva o arquivo final uma única vez.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Este é um ponto de partida útil para preservar a formatação de origem dos slides importados. Se sua saída precisar usar um único tema de destino, substitua a chamada simples `AddClone(slide)` pela sobrecarga de mestre ou layout de destino apresentada anteriormente.

## **Considerações práticas**

### **Mestres, layouts e fidelidade de formatação**

A clonagem padrão de slides pode trazer automaticamente um mestre de origem necessário para a apresentação de destino. Aspose.Slides mantém um registro interno de mestres clonados automaticamente para evitar clonar o mesmo mestre repetidamente. Mestres clonados manualmente não são rastreados por esse registro, portanto evite pré-clonar mestres a menos que precise de controle explícito sobre a estrutura do mestre.

Não presuma que dois mestres ou layouts com o mesmo nome sejam visualmente equivalentes. Se um modelo corporativo deve controlar a aparência final, escolha explicitamente um mestre ou layout de destino e verifique o resultado após a mesclagem.

### **Notas e comentários**

Notas de apresentador e comentários de slide são associados ao conteúdo do slide e são copiados quando um slide é clonado. Aspose.Slides também expõe APIs dedicadas para [presentation notes](https://docs.aspose.com/slides/pt/net/presentation-notes/) e [presentation comments](https://docs.aspose.com/slides/pt/net/presentation-comments/).

Se a formatação da página de notas for importante, verifique a apresentação mesclada porque mestres de notas são objetos de nível de apresentação e podem diferir entre arquivos de origem. Para fluxos de revisão, verifique também os autores dos comentários e comentários em threads após combinar arquivos de diferentes autores ou modelos.

### **Imagens, áudio, vídeo, objetos OLE e links externos**

Slides podem referenciar recursos de nível de apresentação como imagens, áudio incorporado, vídeo incorporado e dados OLE. Clone o slide inteiro em vez de copiar apenas suas formas visíveis para que Aspose.Slides mantenha os relacionamentos do slide com seus recursos.

Recursos incorporados e vinculados devem ser tratados de forma diferente. Um áudio, vídeo, objeto OLE ou hiperlInk vinculado permanece dependente de seu alvo externo; clonar um slide não transforma um link externo em conteúdo incorporado. Teste caminhos e URLs de recursos vinculados no ambiente onde a apresentação mesclada será aberta.

Aspose.Slides rastreia explicitamente mestres clonados automaticamente, mas isso não deve ser interpretado como garantia geral de que recursos binários idênticos de apresentações de origem distintas serão sempre deduplicados. Se o tamanho do arquivo de saída for importante, inspecione o pacote mesclado e meça o resultado em vez de contar com deduplicação implícita.

### **Fontes incorporadas e disponibilidade de fontes**

Fontes são gerenciadas em nível de apresentação. Se a tipografia precisar permanecer consistente entre máquinas, não presuma que clonar slides sozinho garante que todas as fontes necessárias estejam disponíveis no ambiente de destino. Você pode inspecionar fontes incorporadas com [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/getembeddedfonts/) e gerenciar a incorporação explicitamente como descrito em [Embed Fonts in Presentations](https://docs.aspose.com/slides/pt/net/embedded-font/).

Também verifique se você tem permissão para incorporar as fontes usadas pelos arquivos de origem. Licenças de fonte podem restringir a incorporação.

### **Apresentações protegidas por senha**

Uma origem protegida por senha deve ser aberta com sucesso antes que seus slides possam ser clonados. Forneça a senha através de [LoadOptions.Password](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Abrir uma origem criptografada não aplica automaticamente a mesma proteção à apresentação de destino. Configure a proteção de saída separadamente quando necessário.

### **Apresentações grandes e uso de memória**

Apresentações grandes que contêm imagens de alta resolução, áudio, vídeo ou outros objetos binários volumosos podem consumir memória significativa. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/blobmanagementoptions/) fornece controles para manipulação de BLOBs e uso de arquivos temporários. Consulte [Manage Presentation BLOBs](https://docs.aspose.com/slides/pt/net/manage-blob/) para estratégias de arquivos grandes.

Para arquivos grandes, prefira carregar a partir de caminhos de arquivo quando possível, descarte cada apresentação de origem assim que ela for mesclada e evite salvar resultados intermediários repetidamente, a menos que o fluxo de trabalho exija pontos de verificação.

### **Segurança de threads**

Não carregue, modifique, salve ou clone a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) simultaneamente a partir de múltiplas threads. Mantenha cada instância de apresentação confinada a uma operação de mesclagem. Se paralelizar tarefas independentes, use instâncias de apresentação independentes e siga as diretrizes de multithreading do [Aspose.Slides](https://docs.aspose.com/slides/pt/net/multithreading/).

## **FAQ**

**Como mantenho o design original de cada apresentação de origem?**

Use [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/) sem fornecer um mestre ou layout de destino. Aspose.Slides pode clonar automaticamente o mestre de origem quando ele for necessário para o slide importado.

**Como faço os slides importados usarem o tema de destino?**

Use a sobrecarga que aceita um mestre de destino. Passe um mestre da apresentação de destino, não da origem. Aspose.Slides tentará mapear cada slide de origem para um layout adequado sob esse mestre.

**Quando devo usar um layout de destino específico em vez de um mestre de destino?**

Use um layout específico quando cada slide importado deve usar um layout conhecido. Use um mestre quando quiser que Aspose.Slides selecione entre os layouts desse mestre com base no tipo ou nome do layout de origem.

**É possível mesclar apresentações com diferentes tamanhos de slide?**

Sim, mas o conteúdo do slide não é redesenhado automaticamente para as dimensões de destino. Redimensione a apresentação de origem primeiro quando precisar de posicionamento previsível, por exemplo com [SlideSize.SetSize](https://reference.aspose.com/slides/pt/net/aspose.slides/slidesize/setsize/) e [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pt/net/aspose.slides/slidesizescaletype/).

**Posso mesclar apresentações PPT, PPTX e ODP em um único arquivo?**

Sim. Carregue cada apresentação de origem, clone os slides necessários em um destino e salve o destino em um formato de saída suportado. Como os formatos de apresentação não suportam exatamente o mesmo conjunto de recursos, verifique o conteúdo complexo após mesclagens entre formatos diferentes. Consulte [Supported File Formats](https://docs.aspose.com/slides/pt/net/supported-file-formats/).

**As seções de origem são preservadas automaticamente?**

Não por um loop básico que apenas clona slides. Recrie as seções necessárias no destino e use a sobrecarga de seção de [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/) quando a estrutura de seções precisar ser preservada.

**Notas de apresentador e comentários são preservados?**

Eles são copiados com o slide clonado. Para fluxos que dependem do estilo do notes‑master, autores de comentários ou dados de revisão em threads, verifique o resultado mesclado porque esses cenários envolvem estruturas de nível de apresentação além do conteúdo de slide.

**O que acontece com áudio, vídeo, objetos OLE e hyperlinks?**

Conteúdo incorporado é transportado como parte dos relacionamentos de recursos do slide clonado. Links externos permanecem externos, de modo que seus arquivos ou URLs de destino ainda precisam estar disponíveis após a mesclagem.

**Fontes incorporadas de todas as origens são garantidas no slide mesclado?**

Não confie apenas na clonagem de slides para implantação de fontes. Inspecione as fontes incorporadas no destino e gerencie explicitamente a incorporação ou disponibilidade externa de fontes quando a tipografia for importante.

**Como mesclro um arquivo protegido por senha?**

Abra-o com o [LoadOptions.Password](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/password/) correto, depois clone seus slides normalmente. A proteção de saída é configurada separadamente.

**Como devo tratar apresentações muito grandes?**

Use a gestão de BLOBs quando objetos binários grandes dominarem o uso de memória, prefira carregamento por caminho de arquivo para arquivos muito grandes, descarte apresentações de origem prontamente e salve o resultado final apenas quando necessário.

**Posso mesclar slides de múltiplas threads?**

Não use a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) simultaneamente em várias threads. Mantenha cada operação de mesclagem isolada em suas próprias instâncias de apresentação.