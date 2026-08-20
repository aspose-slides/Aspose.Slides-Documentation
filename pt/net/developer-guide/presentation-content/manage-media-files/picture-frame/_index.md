---
title: Gerenciar Quadros de Imagem em Apresentações em .NET
linktitle: Quadro de Imagem
type: docs
weight: 10
url: /pt/net/picture-frame/
keywords:
- quadro de imagem
- adicionar quadro de imagem
- criar quadro de imagem
- imagem incorporada
- imagem vinculada
- extrair imagem
- imagem raster
- imagem SVG
- recortar imagem
- excluir áreas recortadas
- compactar imagem
- StretchOffset
- formatação de quadro de imagem
- escala relativa
- efeito de imagem
- proporção
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Criar, formatar, vincular, recortar, extrair e compactar quadros de imagem em apresentações com Aspose.Slides para .NET."
---
## **Visão geral**

Um quadro de imagem é uma forma de slide que exibe uma imagem. No Aspose.Slides, o recurso de imagem e a forma que a exibe são objetos separados: uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) possui recursos de imagem incorporados através de sua coleção [Images](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/images/), enquanto um [IPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe/) controla a posição, tamanho, formatação de linha, rotação, recorte, efeitos de imagem e outras configurações ao nível do quadro.

Essa separação é útil quando a mesma imagem é exibida mais de uma vez. Adicione a imagem à apresentação uma vez, mantenha o [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) retornado e use esse recurso de imagem ao criar quadros de imagem.

Quadros de imagem podem conter imagens raster como PNG ou JPEG e imagens vetoriais SVG. Eles também podem referir-se a imagens vinculadas em vez de armazenar os bytes da imagem na apresentação. A escolha afeta a portabilidade, o tamanho do arquivo, a extração e o comportamento de exportação, portanto é útil decidir como a imagem deve ser armazenada antes de aplicar formatação ou otimização.

## **Adicionar e formatar uma imagem incorporada**

Para uma imagem incorporada, adicione os dados da imagem à apresentação e crie um quadro de imagem com [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addpictureframe/). A imagem se torna parte do pacote da apresentação, de modo que a apresentação permaneça autocontida quando for movida para outro computador.

O exemplo a seguir adiciona uma imagem JPEG, cria um quadro nas dimensões nativas da imagem e aplica formatação de linha e rotação:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

O quadro de imagem controla a geometria exibida; alterar o tamanho do quadro não altera as dimensões de pixel originais armazenadas no recurso de imagem incorporado. Essa distinção torna-se importante ao recortar ou comprimir uma imagem posteriormente.

## **Usar escala relativa**

[IPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe/) expõe a escala relativa de largura e altura para o quadro. Um valor de `1.0` corresponde a 100% do tamanho original da imagem. A escala relativa é útil quando um fluxo de trabalho precisa preservar a relação com o tamanho da imagem de origem em vez de calcular manualmente as dimensões finais.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

A escala relativa altera as configurações de escala do quadro; não reamostra nem comprime a imagem incorporada.

## **Imagens incorporadas e vinculadas**

Uma imagem incorporada armazena os dados da imagem dentro da apresentação e, portanto, é a escolha mais segura para portabilidade e renderização previsível. Uma imagem vinculada armazena um local externo por meio do caminho de link [ISlidesPicture](https://reference.aspose.com/slides/pt/net/aspose.slides/islidespicture/) , em vez de incorporar os dados da imagem da mesma forma.

Imagens vinculadas podem reduzir a quantidade de dados de imagem armazenados no PPTX, mas introduzem uma dependência externa. O arquivo vinculado deve permanecer acessível à aplicação que abre ou renderiza a apresentação. Se o caminho mudar, o arquivo for movido ou o recurso estiver indisponível, a imagem vinculada pode não ser exibida como esperado. Para apresentações que precisam ser enviadas por email, arquivadas ou renderizadas em ambientes isolados, imagens incorporadas geralmente são mais confiáveis.

### **Adicionar uma imagem vinculada**

O exemplo a seguir cria um quadro de imagem e o aponta para um arquivo de imagem local. Ele trata apenas de vinculação de imagem; a vinculação de vídeo é um fluxo de mídia separado e intencionalmente não foi misturado neste exemplo.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Use links quando o gerenciamento de arquivos externos for intencional. Não os use apenas como substitutos da compressão: um PPTX pequeno com dependências de imagem quebradas costuma ser menos útil do que uma apresentação maior e autocontida.

## **Extrair imagens de quadros de imagem**

Antes de extrair uma imagem de uma apresentação existente, verifique se uma forma é realmente um [IPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe/) e se contém uma imagem incorporada. Quadros de imagem vinculados podem não conter bytes de imagem que possam ser extraídos da mesma forma.

### **Extrair uma imagem raster**

A API de imagem moderna usa [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) diretamente e não requer o wrapper de imagem de sistema mais antigo. O exemplo a seguir encontra a primeira imagem raster incorporada em um slide e a salva como PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Salvar via [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) converte a imagem extraída para o formato de saída solicitado. Se precisar dos bytes codificados armazenados na apresentação em vez de um arquivo raster convertido, use os dados binários do recurso de imagem.

### **Extrair uma imagem SVG**

Para uma imagem SVG, o [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) expõe um objeto [ISvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage/). Isso permite recuperar os dados SVG diretamente em vez de rasterizar a imagem primeiro.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Manter o conteúdo SVG como SVG preserva a fonte vetorial dentro da apresentação. Exportações raster, como PNG ou JPEG, necessariamente renderizam esse conteúdo vetorial em pixels. A exportação de slide para PDF ou SVG também é uma operação de renderização, portanto os gráficos exportados não devem ser tratados como uma cópia byte a byte do SVG incorporado original; use os dados do [ISvgImage] incorporado quando o recurso vetorial original for necessário.

## **Recortar uma imagem**

O recorte altera qual parte da imagem fica visível dentro do quadro. Os valores de recorte em [IPictureFillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/) são percentuais das dimensões da imagem de origem. O recorte não exclui inicialmente os pixels ocultos da imagem incorporada; ele apenas altera a região visível.

O exemplo a seguir encontra um quadro de imagem com segurança e aplica valores de recorte:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Como os dados de imagem ocultos ainda estão presentes, o recorte pode ser alterado posteriormente sem perder os pixels originais. Se o tamanho do arquivo for mais importante que a reversibilidade, as regiões recortadas podem ser removidas fisicamente conforme descrito na seção seguinte.

## **Remover dados de imagem recortados**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) remove os dados de imagem fora do retângulo de recorte atual e retornam o recurso de imagem resultante. Isso pode reduzir o tamanho do arquivo, mas é uma otimização destrutiva: após a apresentação ser salva, os pixels removidos não estão mais disponíveis para uma operação de desfazer recorte posterior.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

O método pode adicionar um novo recurso de imagem à apresentação. Se a imagem original também for usada por outros quadros de imagem, esses quadros ainda precisarão do recurso existente, portanto excluir áreas recortadas não reduz necessariamente o número total de imagens. Recortar conteúdo WMF ou EMF com este método rasteriza o resultado recortado para PNG.

## **Comprimir imagens raster**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/compressimage/) reduz a resolução da imagem raster em relação ao tamanho em que a imagem é exibida. Também pode remover regiões recortadas na mesma operação. O método retorna `true` quando a imagem foi redimensionada ou recortada e `false` quando nenhuma mudança foi necessária.

Use um valor predefinido de [PicturesCompression](https://reference.aspose.com/slides/pt/net/aspose.slides.export/picturescompression/) quando uma resolução alvo padrão for suficiente:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Um valor DPI positivo personalizado pode ser passado em vez de um valor enum quando um alvo específico for necessário.

A compressão destina‑se a imagens raster. Conteúdo SVG e metafile não é reduzido por este fluxo de compressão raster. Também lembre‑se de que resolução mais baixa e regiões recortadas excluídas não podem ser recuperadas da apresentação otimizada. Escolha uma resolução alvo com base no maior tamanho no qual a imagem será realmente visualizada ou exportada, em vez de aplicar o DPI mais baixo globalmente.

## **Inspecionar efeitos de imagem**

Os efeitos de imagem são armazenados na imagem usada pelo quadro. A coleção de transformações da imagem pode conter efeitos como modulação alfa fixa para transparência e luminância para brilho e contraste. O exemplo abaixo lê com segurança ambos os tipos de efeitos do primeiro quadro de imagem em um slide:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

Esses efeitos alteram como a imagem é renderizada no quadro; eles não regravam os bytes da imagem incorporada original.

## **Bloquear a geometria do quadro de imagem**

As configurações de [IPictureFrameLock](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframelock/) controlam quais operações de edição são desativadas para um quadro de imagem. Por exemplo, o bloqueio de proporção preserva as proporções da forma enquanto ela é redimensionada.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

O bloqueio se aplica à forma do quadro de imagem. Ele não força a imagem de origem a ser reamostrada ou permanentemente alterada para a mesma proporção.

## **Ajustar os valores StretchOffset**

Quando o modo de preenchimento da imagem é stretch, os valores stretch‑offset em [IPictureFillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/) definem o retângulo de preenchimento relativo à caixa delimitadora do quadro de imagem. Percentuais positivos criam um recuo a partir de uma borda, enquanto percentuais negativos criam um deslocamento externo.

Isso é diferente de recorte. Os valores de recorte selecionam qual parte da imagem de origem está visível; os offsets de stretch alteram o retângulo no qual o preenchimento da imagem visível é esticado.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Use stretch offsets para posicionamento do preenchimento. Use propriedades de recorte quando o objetivo for ocultar as bordas da imagem de origem.

## **Armazenamento, tamanho de arquivo e considerações de exportação**

Os principais trade‑offs são mais fáceis de gerenciar quando o armazenamento de imagens e a formatação de quadros de imagem são tratados separadamente:

- **Imagens incorporadas** tornam a apresentação autocontida e são as mais confiáveis para compartilhamento e renderização no servidor, mas imagens raster grandes aumentam o tamanho do PPTX e o uso de memória.
- **Imagens vinculadas** podem manter o pacote menor, mas a apresentação depende de arquivos externos permanecerem disponíveis nos caminhos ou locais armazenados.
- **Recorte** é inicialmente não destrutivo. Os pixels ocultos permanecem incorporados até que as áreas recortadas sejam explicitamente excluídas ou removidas durante a compressão.
- **Compressão** pode reduzir significativamente o tamanho do arquivo para imagens raster superdimensionadas, mas sacrifica a resolução original. Deve ser aplicada após o tamanho desejado na slide ser conhecido.
- **Imagens SVG** devem permanecer como SVG quando a preservação vetorial é importante. Extraia o SVG incorporado diretamente quando precisar do recurso vetorial em si. Exportações raster de slides sempre convertem o slide renderizado em pixels.
- **Imagens repetidas** devem reutilizar um recurso [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) existente quando possível, em vez de carregar repetidamente o mesmo arquivo no fluxo de trabalho da apresentação.

Para apresentações grandes, a otimização de imagens costuma ser mais eficaz quando executada de forma seletiva: mantenha logotipos e diagramas como conteúdo vetorial, comprima fotografias de acordo com seu tamanho real de exibição, remova pixels recortados somente quando a edição posterior não for necessária e evite links externos, a menos que o gerenciamento de dependências faça parte do design de implantação.

## **Perguntas frequentes**

**Qual é a diferença entre um quadro de imagem e um recurso de imagem?**

Um [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) representa um recurso de imagem associado à apresentação. Um [IPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe/) é uma forma em um slide que exibe uma imagem e armazena geometria e formatação ao nível do quadro, como tamanho, rotação, valores de recorte, efeitos e bloqueios.

**Devo incorporar ou vincular imagens?**

Incorpore imagens quando a apresentação precisar ser portátil, arquivada ou renderizada sem acesso a recursos externos. Vincule imagens somente quando manter os arquivos de imagem fora do PPTX for intencional e os locais externos puderem ser mantidos de forma confiável.

**O recorte reduz o tamanho do arquivo PPTX?**

Não por si só. As configurações normais de recorte ocultam partes da imagem de origem, mas mantêm os pixels subjacentes. Use [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ou compressão de imagem com remoção de áreas recortadas quando esses pixels podem ser descartados permanentemente.

**Posso restaurar a qualidade da imagem após a compressão?**

Não. A compressão pode reduzir a resolução raster armazenada e a remoção de regiões recortadas descarta dados da imagem. Mantenha a imagem fonte original fora da apresentação se edição de alta resolução posterior for necessária.

**Como as imagens SVG devem ser tratadas?**

Mantenha o conteúdo SVG como SVG quando a fidelidade vetorial for importante. O [ISvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage/) incorporado pode ser extraído diretamente. Renderizar um slide para um formato raster, como PNG ou JPEG, rasteriza o SVG como parte da imagem do slide.

**Como evitar casts inseguros ao ler slides existentes?**

Verifique o tipo da forma antes de usar membros específicos de quadros de imagem. O pattern matching com [IPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe/) ou filtrar a coleção de formas por essa interface evita casts inválidos e permite que o código trate slides que não contêm quadros de imagem.