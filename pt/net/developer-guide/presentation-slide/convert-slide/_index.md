---
title: Convertir Slides de Apresentação em Imagens no .NET
linktitle: Slide para Imagem
type: docs
weight: 41
url: /pt/net/convert-slide/
keywords:
- converter slide
- exportar slide
- slide para imagem
- salvar slide como imagem
- slide para EMF
- slide para PNG
- slide para JPEG
- slide para bitmap
- slide para TIFF
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Converta slides de apresentações PPT, PPTX e ODP para PNG, JPEG, GIF, TIFF, EMF e outros formatos de imagem em C# com Aspose.Slides for .NET."
---
## **Introdução**

Aspose.Slides for .NET pode renderizar slides individuais de apresentações PowerPoint e OpenDocument como PNG, JPEG, GIF, TIFF e outros formatos de imagem.

Para converter um slide em uma imagem, siga estas etapas:

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Selecione o slide que você deseja renderizar.
3. Se necessário, configure a renderização com a classe [RenderingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/renderingoptions/) ou [TiffOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/tiffoptions/).
4. Chame o método [GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/getimage/). Ele retorna um objeto [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/).
5. Chame o método [IImage.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/save/) e especifique o formato de saída com um valor [ImageFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/imageformat/).

## **Converter um Slide para uma Imagem PNG**

A conversão mais simples usa as configurações padrão de renderização. O objeto [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) resultante pode ser processado na memória ou salvo em um arquivo.

O exemplo C# a seguir renderiza o primeiro slide e o salva como uma imagem PNG:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Converter Slides em Imagens com Tamanhos Personalizados**

Use a sobrecarga [GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/getimage/) que aceita um valor [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) para renderizar um slide com dimensões de pixel exatas.

O exemplo a seguir cria uma imagem JPEG de 1820 × 1040:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Converter Slides com Notas e Comentários em Imagens**

Por padrão, as imagens dos slides não incluem notas ou comentários. Atribua um objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/notescommentslayoutingoptions/) à propriedade [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) para controlar onde as notas e os comentários aparecem.

O exemplo a seguir coloca notas truncadas abaixo do slide e comentários à sua direita:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
Para a conversão de slide para imagem, não defina a propriedade [NotesPosition](https://reference.aspose.com/slides/pt/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) como [BottomFull](https://reference.aspose.com/slides/pt/net/aspose.slides.export/notespositions/). As notas podem conter mais texto do que o tamanho fixo da imagem pode acomodar. Use [BottomTruncated](https://reference.aspose.com/slides/pt/net/aspose.slides.export/notespositions/) em vez disso.
{{% /alert %}}

## **Converter Slides em Imagens Usando Opções TIFF**

A classe [TiffOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/tiffoptions/) permite controlar o tamanho, a resolução e outras propriedades da imagem TIFF renderizada.

O exemplo a seguir renderiza o primeiro slide como uma imagem TIFF de 2160 × 2880 a 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Converter Todos os Slides em Imagens**

Itere pela coleção de slides para converter toda a apresentação em uma série de imagens. Slides ocultos são incluídos, a menos que você os ignore explicitamente.

O exemplo a seguir renderiza cada slide como uma imagem JPEG com fatores de escala horizontal e vertical de 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Criar Saída Enhanced Metafile**

Enhanced Metafile (EMF) é útil quando gráficos vetoriais precisam ser trocados com o Microsoft Office ou outros aplicativos Windows que suportam metarquivos do Windows. Ao contrário de uma imagem baseada em pixels, um EMF pode reter operações de desenho vetoriais que escalam sem a mesma perda de nitidez. Contudo, o EMF é principalmente um formato de compatibilidade para aplicativos com suporte a metarquivos do Windows, não um formato de intercâmbio universal. Além disso, conteúdo de slide complexo, como imagens bitmap e alguns efeitos, pode ser armazenado como elementos rasterizados dentro do contêiner vetorial do metafile.

### **Exportar um Slide para EMF**

O método [ISlide.WriteAsEmf](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/writeasemf/) grava um [ISlide](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/) em um stream de destino no formato EMF. O exemplo a seguir carrega uma apresentação, seleciona o primeiro slide e o grava em um stream de arquivo EMF:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

O chamador possui o stream passado para [ISlide.WriteAsEmf](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/writeasemf/) e deve fechá‑lo ou descartá‑lo. Aspose.Slides escreve na posição atual do stream e deixa o stream aberto.

### **Converter uma Imagem SVG para EMF e Adicioná‑la a uma Apresentação**

Use [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage/writeasemf/) para converter conteúdo SVG em EMF. Os bytes resultantes podem ser adicionados à apresentação através de [IImageCollection.AddImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimagecollection/addimage/) e colocados em um slide com [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addpictureframe/).

O exemplo a seguir cria um [SvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/svgimage/) a partir de marcação SVG, converte‑o em um EMF em memória, insere o metafile no primeiro slide e salva a apresentação:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage/writeasemf/) não assume a propriedade do stream de destino. Após a gravação, a posição do stream está no final dos dados gerados. Redefina `Position` para o início antes de passar o mesmo stream buscável para um leitor, conforme mostrado acima. Mantenha o stream aberto até que o consumidor termine de lê‑lo e descarte‑o em seguida. Alternativamente, chame `ToArray` e passe o array de bytes retornado para [IImageCollection.AddImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimagecollection/addimage/); `ToArray` retorna o buffer completo independentemente da posição atual do stream.

A geração de EMF está disponível nos sistemas operacionais suportados pela compilação selecionada do Aspose.Slides for .NET, mas a renderização pode variar entre plataformas quando fontes ou dependências gráficas nativas não estão disponíveis. Instale as fontes usadas pelo conteúdo de origem ou configure substituições adequadas, siga os [requisitos da plataforma](/slides/pt/net/system-requirements/) para o seu pacote Aspose.Slides e valide o resultado no aplicativo de consumo de EMF alvo. Aplicativos Linux e macOS costumam ter suporte limitado ou inconsistente para exibir e editar metarquivos do Windows.

## **Renderização de Emoji Colorido**

{{% alert title="Note" color="info" %}}
Para renderizar emojis coloridos corretamente ao converter slides de apresentação em imagens, as fontes de emoji usadas na apresentação devem estar instaladas e disponíveis no sistema que realiza a conversão. Por exemplo, se a apresentação usar **Segoe UI Emoji** e essa fonte estiver ausente, os emojis podem aparecer em monocromático nas imagens de saída.
{{% /alert %}}

## **FAQ**

**O Aspose.Slides suporta renderização de slides com animações?**

Não. O método [GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/getimage/) renderiza uma imagem estática do slide e não exporta animações.

**Slides ocultos podem ser exportados como imagens?**

Sim. Slides ocultos podem ser renderizados como slides normais. Inclua‑os no loop de processamento, como mostrado no exemplo acima.

**Sombras e outros efeitos são preservados nas imagens dos slides?**

Sim. Aspose.Slides renderiza sombras, transparência e outros efeitos gráficos suportados nas imagens dos slides.