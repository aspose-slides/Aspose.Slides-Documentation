---
title: Mesclar Apresentações de Forma Eficiente no .NET
linktitle: Mesclar Apresentações
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
description: "Saiba como mesclar apresentações PowerPoint e OpenDocument no .NET clonando slides, controlando mestres e layouts, redimensionando o conteúdo dos slides, preservando seções e lidando com arquivos protegidos ou grandes."
---
## **Visão geral**

Aspose.Slides para .NET mescla apresentações clonando slides de um [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) para outro. A operação principal é [ISlideCollection.AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/), que pode preservar a formatação do slide de origem ou anexar o slide clonado a um mestre ou layout na apresentação de destino.

Este artigo cobre os fluxos de trabalho de mesclagem mais comuns:

- mesclar todos os slides preservando sua formatação original;
- mesclar slides selecionados;
- aplicar um mestre da apresentação de destino;
- aplicar um layout específico da apresentação de destino;
- normalizar diferentes tamanhos de slide antes de mesclar;
- adicionar slides clonados a uma seção;
- mesclar várias apresentações em um fluxo de trabalho de ponta a ponta;
- tratar mestres, recursos, notas, comentários, mídia, fontes, senhas, arquivos grandes e questões de multithreading.

## **Como a clonagem de slides afeta mestres e layouts**

Um slide herda grande parte de sua aparência do layout e do mestre. Por esse motivo, a sobrecarga de clonagem que você escolher determina como o slide mesclado é integrado à apresentação de destino.

Use [ISlideCollection.AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/) de uma das seguintes maneiras:

- `AddClone(sourceSlide)` — preserva o layout e a formatação do slide de origem. Quando necessário, o mestre de origem pode ser clonado automaticamente para a apresentação de destino. Aspose.Slides rastreia mestres clonados automaticamente para que slides repetidos que utilizam o mesmo mestre de origem não causem a clonagem repetida desse mestre.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — anexa o slide clonado a um [IMasterSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslide/) de destino específico. Aspose.Slides procura um layout correspondente sob esse mestre pelo tipo ou nome do layout.
- `AddClone(sourceSlide, destinationLayout)` — anexa o slide clonado diretamente a um [ILayoutSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/) de destino específico.

O mestre ou layout passado para uma sobrecarga `AddClone` deve pertencer à **apresentação de destino**, não à apresentação de origem.

## **Mesclar apresentações inteiras e preservar a formatação da origem**

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

A apresentação resultante pode conter vários mestres quando a origem e o destino usam designs diferentes. Isso é esperado quando a formatação da origem é intencionalmente preservada.

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

Valide os índices de slide antes de clonar quando eles provêm de entrada do usuário ou de configuração externa.

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

Aspose.Slides seleciona um layout apropriado sob o mestre especificado correspondendo ao tipo ou nome do layout de origem. Se nenhum layout adequado existir e `allowCloneMissingLayout` for `true`, o layout de origem é clonado para que o slide possa ser adicionado. Se for `false`, uma [PptxEditException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxeditexception/) é lançada.

Use `false` quando quiser que a mesclagem falhe em vez de introduzir um layout adicional no mestre de destino.

## **Mesclar slides usando um layout específico de destino**

Use a sobrecarga [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/) quando souber exatamente qual layout de destino os slides importados devem usar.

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

Aplicar um layout de destino altera o relacionamento de layout herdado; não redesenha o conteúdo do slide de origem. Se os layouts de origem e destino tiverem estruturas de marcadores diferentes, inspeccione o resultado para confirmar que a formatação herdada e o comportamento dos marcadores são adequados.

## **Mesclar apresentações com diferentes tamanhos de slide**

Apresentações com dimensões de slide diferentes podem ser mescladas, mas clonar um slide em uma apresentação com outro tamanho de slide não redesenha automaticamente seu conteúdo para o novo canvas. Formas podem aparecer deslocadas, escaladas inesperadamente ou fora da área visível do slide.

Uma abordagem prática é redimensionar a apresentação de origem antes de clonar. O método [SlideSize.SetSize](https://reference.aspose.com/slides/pt/net/aspose.slides/slidesize/setsize/) pode dimensionar o conteúdo existente enquanto altera as dimensões do slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pt/net/aspose.slides/slidesizescaletype/) escala o conteúdo para caber no tamanho solicitado.

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

O redimensionamento altera o objeto da apresentação de origem na memória. Se precisar da apresentação de origem original inalterada para outras operações, abra uma instância separada para a mesclagem.

## **Mesclar slides em uma seção de apresentação**

O loop básico de clonagem de slides não recria a hierarquia de seções da apresentação de origem. Se as seções importarem na saída, crie ou selecione seções na apresentação de destino e clone os slides nelas explicitamente com [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/).

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

Os slides clonados são anexados à seção de destino especificada. Para preservar várias seções de origem, enumere [Presentation.Sections](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sections/), recupere os slides atuais de cada seção de origem com [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/pt/net/aspose.slides/isection/getslideslistofsection/), recrie as seções no destino e clone cada slide retornado para sua respectiva seção de destino. Consulte [Manage Slide Sections](/slides/pt/net/slide-section/) para um exemplo completo de enumeração de seções, incluindo seções vazias e alterações estruturais.

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

Este é um ponto de partida útil para preservar a formatação de origem dos slides importados. Se sua saída precisar usar um único tema de destino, substitua a chamada simples `AddClone(slide)` pela sobrecarga de mestre ou layout de destino apropriada mostrada anteriormente.

## **Considerações práticas**

### **Mestres, layouts e fidelidade de formatação**

A clonagem padrão de slides pode trazer automaticamente um mestre de origem necessário para a apresentação de destino. Aspose.Slides mantém um registro interno de mestres clonados automaticamente para evitar a clonagem repetida do mesmo mestre. Mestres clonados manualmente não são rastreados por esse registro, portanto evite pré-clonar mestres a menos que precise de controle explícito sobre a estrutura do mestre.

Não presuma que dois mestres ou layouts com o mesmo nome sejam visualmente equivalentes. Se um modelo corporativo deve controlar a aparência final, escolha explicitamente um mestre ou layout de destino e verifique o resultado após a mesclagem.

### **Notas e comentários**

Notas do apresentador e comentários de slide estão associados ao conteúdo do slide e são copiados quando um slide é clonado. Aspose.Slides também expõe APIs dedicadas para [presentation notes](/slides/pt/net/presentation-notes/) e [presentation comments](/slides/pt/net/presentation-comments/).

Se a formatação da página de notas for importante, verifique a apresentação mesclada, pois os mestres de notas são objetos de nível de apresentação e podem diferir entre arquivos de origem. Para fluxos de revisão, verifique também os autores dos comentários e os comentários encadeados após combinar arquivos de diferentes autores ou modelos.

### **Imagens, áudio, vídeo, objetos OLE e links externos**

Slides podem referenciar recursos de nível de apresentação, como imagens, áudio incorporado, vídeo incorporado e dados OLE. Clone o slide completo em vez de copiar apenas as formas visíveis para que Aspose.Slides mantenha os relacionamentos do slide com seus recursos.

Recursos incorporados e vinculados devem ser tratados de forma diferente. Um áudio, vídeo, objeto OLE ou hyperlink vinculado permanece dependente de seu alvo externo; clonar um slide não transforma um link externo em conteúdo incorporado. Teste os caminhos e URLs de recursos vinculados no ambiente onde a apresentação mesclada será aberta.

Aspose.Slides rastreia explicitamente mestres clonados automaticamente, mas isso não deve ser interpretado como garantia geral de que recursos binários idênticos de apresentações de origem distintas serão sempre desduplicados. Se o tamanho do arquivo de saída for importante, inspecione o pacote mesclado e meça o resultado em vez de confiar na desduplicação implícita.

### **Fontes incorporadas e disponibilidade de fontes**

As fontes são gerenciadas a nível de apresentação. Se a tipografia deve permanecer consistente entre máquinas, não presuma que clonar slides sozinho garante que todas as fontes necessárias estejam disponíveis no ambiente de destino. Você pode inspecionar fontes incorporadas com [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/getembeddedfonts/) e gerenciar a incorporação explicitamente conforme descrito em [Embed Fonts in Presentations](/slides/pt/net/embedded-font/).

Também verifique se você tem permissão para incorporar as fontes usadas pelos arquivos de origem. Licenças de fontes podem restringir a incorporação.

### **Apresentações protegidas por senha**

Uma origem protegida por senha deve ser aberta com sucesso antes que seus slides possam ser clonados. Forneça a senha através de [LoadOptions.Password](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Abrir uma origem criptografada não aplica automaticamente a mesma proteção à apresentação de destino. Configure a proteção de saída separadamente quando necessário.

### **Apresentações grandes e uso de memória**

Apresentações grandes contendo imagens de alta resolução, áudio, vídeo ou outros objetos binários volumosos podem consumir memória significativa. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/blobmanagementoptions/) fornece controles para o tratamento de BLOBs e uso de arquivos temporários. Consulte [Manage Presentation BLOBs](/slides/pt/net/manage-blob/) para estratégias com arquivos grandes.

Para arquivos grandes, prefira carregar a partir de caminhos de arquivo quando possível, descarte cada apresentação de origem assim que ela for mesclada e evite salvar resultados intermediários repetidamente, a menos que o fluxo exija pontos de verificação.

### **Segurança de threads**

Não carregue, modifique, salve ou clone a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) simultaneamente em múltiplas threads. Mantenha cada instância de apresentação confinada a uma operação de mesclagem. Se paralelizar trabalhos independentes, use instâncias de apresentação independentes e siga as diretrizes de [Aspose.Slides multithreading](/slides/pt/net/multithreading/).

## **Perguntas frequentes**

**Como mantenho o design original de cada apresentação de origem?**

Use [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/) sem fornecer um mestre ou layout de destino. Aspose.Slides pode clonar automaticamente o mestre de origem quando ele for necessário para o slide importado.

**Como faço com que os slides importados usem o tema de destino?**

Use a sobrecarga que aceita um mestre de destino. Passe um mestre da apresentação de destino, não da origem. Aspose.Slides tentará mapear cada slide de origem para um layout apropriado sob esse mestre.

**Quando devo usar um layout específico de destino em vez de um mestre de destino?**

Use um layout específico quando cada slide importado deve usar um layout conhecido. Use um mestre quando desejar que Aspose.Slides selecione entre os layouts desse mestre com base no tipo ou nome do layout de origem.

**É possível mesclar apresentações com diferentes tamanhos de slide?**

Sim, mas o conteúdo do slide não é redesenhado automaticamente para as dimensões de destino. Redimensione a apresentação de origem primeiro quando precisar de posicionamento previsível, por exemplo com [SlideSize.SetSize](https://reference.aspose.com/slides/pt/net/aspose.slides/slidesize/setsize/) e [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pt/net/aspose.slides/slidesizescaletype/).

**Posso mesclar apresentações PPT, PPTX e ODP em um único arquivo?**

Sim. Carregue cada apresentação de origem, clone os slides necessários em um destino e salve o destino em um formato de saída suportado. Como os formatos de apresentação não suportam exatamente o mesmo conjunto de recursos, verifique conteúdo complexo após mesclar entre formatos diferentes. Consulte [Supported File Formats](/slides/pt/net/supported-file-formats/).

**As seções de origem são preservadas automaticamente?**

Não por um loop básico que apenas clona slides. Recrie as seções necessárias no destino e use a sobrecarga de seção de [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/) quando a estrutura de seções precisar ser preservada.

**As notas de orador e comentários são preservados?**

Eles são copiados com o slide clonado. Para fluxos que dependem da estilização do mestre de notas, autores de comentários ou dados de revisão encadeados, verifique o resultado mesclado, pois esses cenários envolvem estruturas de nível de apresentação além do conteúdo de slide.

**O que acontece com áudio, vídeo, objetos OLE e hyperlinks?**

Conteúdos incorporados são transportados como parte dos relacionamentos de recursos do slide clonado. Links externos permanecem externos, portanto seus arquivos ou URLs de destino ainda devem estar disponíveis após a mesclagem.

**As fontes incorporadas de cada origem são garantidas como disponíveis na apresentação mesclada?**

Não confie apenas na clonagem de slides para implantação de fontes. Inspecione as fontes incorporadas no destino e gerencie explicitamente a incorporação de fontes ou a disponibilidade externa de fontes quando a tipografia for importante.

**Como mesclar um arquivo protegido por senha?**

Abra-o com a senha correta via [LoadOptions.Password](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/password/), depois clone seus slides normalmente. A proteção de saída é configurada separadamente.

**Como devo lidar com apresentações muito grandes?**

Use a gestão de BLOBs quando objetos binários grandes dominarem o uso de memória, prefira o carregamento por caminho de arquivo para arquivos muito grandes, descarte as apresentações de origem prontamente e salve o resultado final somente quando necessário.

**Posso mesclar slides a partir de múltiplas threads?**

Não use a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) simultaneamente em múltiplas threads. Mantenha cada operação de mesclagem isolada em suas próprias instâncias de apresentação.