---
title: Alterar tamanho e orientação da página de notas em .NET
linktitle: Tamanho da página de notas
type: docs
weight: 10
url: /pt/net/notes-size/
keywords:
- tamanho da página de notas
- orientação das notas
- notas em paisagem
- notas em retrato
- tamanho do folheto
- PowerPoint
- apresentação
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Leia e altere as dimensões da página de notas no Aspose.Slides para .NET, altere a orientação, verifique os tamanhos salvos e exporte notas ou folhetos para PDF e imagens."
---
## **Visão geral**

Use [Presentation.NotesSize](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/notessize/) para acessar as configurações da página de notas da apresentação. Ele retorna um objeto [INotesSize](https://reference.aspose.com/slides/pt/net/aspose.slides/inotessize/) cujo propriedade [Size](https://reference.aspose.com/slides/pt/net/aspose.slides/inotessize/size/) é gravável. Embora o objeto de configurações seja somente leitura, você pode atribuir novas dimensões à sua propriedade size.

A largura e a altura são especificadas em **pontos**, com 72 pontos por polegada. Por exemplo, 900 × 600 pontos correspondem a 12,5 × 8⅓ polegadas. Essas configurações se aplicam à apresentação, e não às notas de um slide individual.

| Configuração | Finalidade |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/notessize/) | Controla as dimensões da página de notas e as dimensões da página usadas para exportação de folhetos. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/slidesize/) | Controla as dimensões dos slides regulares da apresentação através de [ISlideSize](https://reference.aspose.com/slides/pt/net/aspose.slides/islidesize/). |

Alterar qualquer uma das configurações não altera automaticamente a outra. Alterar a orientação da página de notas também não gira os slides regulares. Veja [Tamanho do slide](/slides/pt/net/slide-size/) para redimensionar slides regulares.

Os exemplos abaixo utilizam um `sample.pptx` existente. Para os exemplos de exportação, use uma apresentação com ao menos um slide contendo notas do apresentador. Cada exemplo pode ser executado independentemente.

## **Ler o tamanho e a orientação da página de notas**

Leia a largura e a altura e compare-as para determinar a orientação: uma página mais larga é paisagem, uma página mais alta é retrato, e dimensões iguais descrevem uma página quadrada. Este exemplo imprime as dimensões reais em pontos, sem assumir um tamanho de papel padrão.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Mudar para paisagem sem alterar o tamanho do papel**

Para mudar apenas a orientação, troque a largura e a altura existentes. Isso preserva o comprimento de ambos os lados, incluindo os de um tamanho de papel personalizado. A condição abaixo impede que uma página já em paisagem seja revertida para retrato e deixa uma página quadrada inalterada.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Para orientação retrato, use a mesma atribuição quando `size.Width > size.Height`. Não substitua as dimensões A4 ou Letter a menos que também queira alterar o tamanho do papel.

## **Definir e verificar um tamanho de página de notas personalizado**

Atribua ambas as dimensões juntas, então use [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) para gravar a apresentação. Este exemplo define uma página de paisagem de 900 × 600 pontos, salva-a como PPTX e abre o arquivo salvo novamente para verificar os valores persistidos. A comparação permite uma tolerância de 0,01 ponto para valores de ponto flutuante; não é uma garantia de precisão para todos os formatos de arquivo.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

O resultado esperado é `900 x 600 points` e `Size preserved: True`. Verificar uma apresentação recém-aberta confirma o arquivo salvo, e não apenas as configurações em memória.

## **Exportar notas e folhetos**

As dimensões da página definem a área disponível para layouts de notas ou folhetos. Elas não ativam esses layouts por si só: configure também as opções de exportação. A exportação de slides regulares continua a usar as dimensões dos slides.

### **Exportar notas para PDF e PNG**

Atribua [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/notescommentslayoutingoptions/) a [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) para incluir notas no PDF. Este exemplo também renderiza o primeiro slide com notas para PNG usando [Slide.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/getimage/) e [RenderingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/renderingoptions/).

O modo [BottomTruncated](https://reference.aspose.com/slides/pt/net/aspose.slides.export/notespositions/) mantém as notas em uma página; notas que não couberem podem ser truncadas. O PDF usa páginas de 900 × 600 pontos. Na escala de imagem de 1 × 1 usada abaixo, o PNG tem 900 × 600 pixels. Pontos descrevem a geometria da página; pixels descrevem a saída raster, cujas dimensões também dependem da escala de renderização.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Para exportação de PDF com notas extensas, [BottomFull](https://reference.aspose.com/slides/pt/net/aspose.slides.export/notespositions/) permite páginas adicionais conforme necessário. Não use esse modo com a chamada de imagem de slide único acima, que não o suporta. Após redimensionar, inspeccione a saída para notas cortadas e a posição dos objetos notes-master existentes; mudar apenas as dimensões da página não deve ser considerado uma garantia de que todo o conteúdo caberá. Veja [Converter PowerPoint para PDF com Notas](/slides/pt/net/convert-powerpoint-to-pdf-with-notes/) para mais informações sobre exportação de notas.

### **Exportar folhetos para PDF**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/handoutlayoutingoptions/) para múltiplas miniaturas de slides em uma página. O exemplo a seguir define uma página de 900 × 600 pontos e usa [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/pt/net/aspose.slides.export/handouttype/) para organizar até quatro slides por página. O preset horizontal controla a ordem dos slides; a orientação da página vem da sua largura e altura.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Alterar o tamanho da página altera a área disponível para a grade de folhetos sem mudar as dimensões dos slides de origem. Para imagens de folhetos, use [Presentation.GetImages](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/getimages/) com o layout de folheto, em vez do método de imagem de um slide individual. No Aspose.Slides, a renderização de folhetos a nível de apresentação usa as dimensões da página de notas, enquanto a chamada de imagem de slide individual não produz a página de folheto. Veja [Modo folheto](/slides/pt/net/convert-powerpoint-in-handout-mode/) para opções de layout.

## **Tamanho da página em visualizadores, exportação e impressão**

Mantenha o tamanho da apresentação armazenado, o tamanho da página exportada e o tamanho do papel impresso distintos:

- **Visualizadores de apresentação:** Um visualizador pode exibir ou imprimir notas usando suas próprias regras de layout. Se outro aplicativo salvar o arquivo, reabra‑o e verifique as dimensões novamente; a conversão de formato desse aplicativo pode normalizá‑las.
- **Formatos de exportação:** Os exemplos de PDF de notas e folhetos acima usam as dimensões de página configuradas. Imagens raster usam dimensões de pixel inteiras e uma escala de renderização, portanto valores fracionários de ponto podem ser arredondados na saída da imagem. Exportar slides regulares não aplica o tamanho da página de notas.
- **Drivers de impressão:** A seleção de papel, rotação automática e configurações de ajuste à página podem mudar a saída física sem alterar as dimensões armazenadas na apresentação ou no PDF. Para um tamanho de papel específico, ajuste as configurações da impressora e inspeccione a pré‑visualização de impressão.

## **Perguntas frequentes**

**Posso definir o tamanho das notas para apenas um slide?**

O tamanho da página de notas é uma configuração a nível de apresentação. Slides individuais podem ter conteúdo de notas diferente, mas essa propriedade não fornece um tamanho de página separado para cada slide.

**Por que mudar a orientação das notas não mudou meus slides?**

As páginas de notas e os slides regulares têm dimensões independentes. Use as configurações de tamanho de slide regular quando quiser redimensionar os próprios slides.

**Por que meu resultado salvo ou impresso tem um tamanho diferente?**

Primeiro, reabra a apresentação salva e compare as dimensões das notas. Se elas mudaram, verifique se salvar ou converter o arquivo em outro aplicativo alterou as configurações da página. Se não, verifique o layout de exportação, a escala da imagem, as configurações do visualizador e a seleção de papel da impressora.