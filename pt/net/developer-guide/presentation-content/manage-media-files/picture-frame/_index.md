---
title: Gerenciar Quadros de Imagem em Apresentações no .NET
linktitle: Quadro de Imagem
type: docs
weight: 10
url: /pt/net/picture-frame/
keywords:
- quadro de imagem
- adicionar quadro de imagem
- criar quadro de imagem
- adicionar imagem
- criar imagem
- extrair imagem
- imagem raster
- imagem vetorial
- cortar imagem
- área recortada
- propriedade StretchOff
- formatação de quadro de imagem
- propriedades de quadro de imagem
- escala relativa
- efeito de imagem
- proporção
- transparência de imagem
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Adicione quadros de imagem a apresentações PowerPoint e OpenDocument com Aspose.Slides para .NET. Otimize seu fluxo de trabalho e melhore o design dos slides."
---
## **Introdução**

Um quadro de imagem é uma forma que contém uma imagem — é como uma foto em uma moldura.  

Você pode adicionar uma imagem a um slide através de um quadro de imagem. Dessa forma, você formata a imagem formatando o quadro de imagem.

{{% alert  title="Dica" color="primary" %}} 

A Aspose oferece conversores gratuitos — [JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt) — que permitem criar apresentações rapidamente a partir de imagens. 

{{% /alert %}} 

## **Criar um Quadro de Imagem**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).  
2. Obtenha a referência de um slide por seu índice.  
3. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage) adicionando uma imagem à [IImagescollection](https://reference.aspose.com/slides/pt/net/aspose.slides/iimagecollection) associada ao objeto de apresentação que será usado para preencher a forma.  
4. Especifique a largura e a altura da imagem.  
5. Crie um [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/pictureframe) com base na largura e altura da imagem através do método `AddPictureFrame` exposto pelo objeto shape associado ao slide referenciado.  
6. Adicione um quadro de imagem (contendo a foto) ao slide.  
7. Grave a apresentação modificada como um arquivo PPTX.

Este código C# mostra como criar um quadro de imagem:

```c#
// Instancia a classe Presentation que representa um arquivo PPTX
using (Presentation pres = new Presentation())
{
    // Obtém o primeiro slide
    ISlide slide = pres.Slides[0];

    // Carrega uma imagem e a adiciona à coleção de imagens da apresentação
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Adiciona um quadro de imagem com a mesma altura e largura
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Aplica alguma formatação ao quadro de imagem
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Grava a apresentação em um arquivo PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Os quadros de imagem permitem criar rapidamente slides de apresentação a partir de imagens. Quando você combina o quadro de imagem com as opções de salvamento do Aspose.Slides, pode manipular operações de entrada/saída para converter imagens de um formato para outro. Você pode querer ver estas páginas: converter [imagem para JPG](https://products.aspose.com/slides/pt/net/conversion/image-to-jpg/); converter [JPG para imagem](https://products.aspose.com/slides/pt/net/conversion/jpg-to-image/); converter [JPG para PNG](https://products.aspose.com/slides/pt/net/conversion/jpg-to-png/), converter [PNG para JPG](https://products.aspose.com/slides/pt/net/conversion/png-to-jpg/); converter [PNG para SVG](https://products.aspose.com/slides/pt/net/conversion/png-to-svg/), converter [SVG para PNG](https://products.aspose.com/slides/pt/net/conversion/svg-to-png/).

{{% /alert %}}

## **Criar um Quadro de Imagem com Escala Relativa**

Alterando a escala relativa de uma imagem, você pode criar um quadro de imagem mais complexo.  

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).  
2. Obtenha a referência de um slide por seu índice.  
3. Adicione uma imagem à coleção de imagens da apresentação.  
4. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage) adicionando uma imagem à [IImagescollection](https://reference.aspose.com/slides/pt/net/aspose.slides/iimagecollection) associada ao objeto de apresentação que será usado para preencher a forma.  
5. Especifique a largura e altura relativas da imagem no quadro de imagem.  
6. Grave a apresentação modificada como um arquivo PPTX.

Este código C# mostra como criar um quadro de imagem com escala relativa:

```c#
 // Instancia a classe Presentation que representa um arquivo PPTX
 using (Presentation presentation = new Presentation())
 {
     // Carrega uma imagem e a adiciona à coleção de imagens da apresentação
     IImage image = Images.FromFile("aspose-logo.jpg");
     IPPImage ppImage = presentation.Images.AddImage(image);
     image.Dispose();

     // Adiciona um quadro de imagem ao slide
     IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

     // Define a largura e altura da escala relativa
     pictureFrame.RelativeScaleHeight = 0.8f;
     pictureFrame.RelativeScaleWidth = 1.35f;

     // Salva a apresentação
     presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
 }
```

## **Extrair Imagens Raster de Quadros de Imagem**

Você pode extrair imagens raster de objetos [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/pictureframe) e salvá‑las em PNG, JPG e outros formatos. O exemplo de código abaixo demonstra como extrair uma imagem do documento “sample.pptx” e salvá‑la no formato PNG.

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Extrair Imagens SVG de Quadros de Imagem**

Quando uma apresentação contém gráficos SVG inseridos dentro de formas [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/pictureframe/), o Aspose.Slides for .NET permite recuperar as imagens vetoriais originais com fidelidade total. Percorrendo a coleção de formas do slide, você pode identificar cada [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/pictureframe/), verificar se o [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) subjacente contém conteúdo SVG e, então, salvar essa imagem em disco ou em um stream no formato SVG nativo.

O código a seguir demonstra como extrair uma imagem SVG de um quadro de imagem:

```cs
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **Obter Transparência de uma Imagem**

O Aspose.Slides permite obter o efeito de transparência aplicado a uma imagem. Este código C# demonstra a operação:

```c#
using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **Obter Brilho e Contraste de uma Imagem**

O Aspose.Slides permite obter o efeito de brilho e contraste aplicado a uma imagem. A interface [ILuminance](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iluminance/) representa esse efeito de transformação de imagem.

Este código C# demonstra como obter as configurações de brilho e contraste de um quadro de imagem:

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="primary" %}} 
Todos os efeitos aplicados às imagens podem ser encontrados em [Aspose.Slides.Effects](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/).
{{% /alert %}}

## **Formatação de Quadros de Imagem**

O Aspose.Slides fornece muitas opções de formatação que podem ser aplicadas a um quadro de imagem. Usando essas opções, você pode alterar um quadro de imagem para que atenda a requisitos específicos.

1. Crie uma instância da classe [Presentation](http://www.aspose.com/api/net/slides/pt/aspose.slides/).  
2. Obtenha a referência de um slide por seu índice.  
3. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage) adicionando uma imagem à [IImagescollection](https://reference.aspose.com/slides/pt/net/aspose.slides/iimagecollection) associada ao objeto de apresentação que será usado para preencher a forma.  
4. Especifique a largura e a altura da imagem.  
5. Crie um `PictureFrame` com base na largura e altura da imagem através do método [AddPictureFrame](http://www.aspose.com/api/net/slides/pt/aspose.slides/ishapecollection/methods/addpictureframe) exposto pelo objeto [IShapes](http://www.aspose.com/api/net/slides/pt/aspose.slides/ishapecollection) associado ao slide referenciado.  
6. Adicione o quadro de imagem (contendo a foto) ao slide.  
7. Defina a cor da linha do quadro de imagem.  
8. Defina a largura da linha do quadro de imagem.  
9. Gire o quadro de imagem fornecendo um valor positivo ou negativo.  
   * Um valor positivo gira a imagem no sentido horário.  
   * Um valor negativo gira a imagem no sentido anti‑horário.  
10. Adicione o quadro de imagem (contendo a foto) ao slide.  
11. Grave a apresentação modificada como um arquivo PPTX.

Este código C# demonstra o processo de formatação do quadro de imagem:

```c#
// Instancia a classe Presentation que representa um arquivo PPTX
using (Presentation presentation = new Presentation())
{
    // Obtém o primeiro slide
    ISlide slide = presentation.Slides[0];

    // Carrega uma imagem e a adiciona à coleção de imagens da apresentação
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Adiciona um quadro de imagem com a altura e largura equivalentes da imagem
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Aplica alguma formatação ao quadro de imagem
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Grava a apresentação em um arquivo PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

A Aspose desenvolveu recentemente um [Collage Maker gratuito](https://products.aspose.app/slides/pt/collage). Se precisar [mesclar JPG/JPEG](https://products.aspose.app/slides/pt/collage/jpg) ou imagens PNG, [criar grades a partir de fotos](https://products.aspose.app/slides/pt/collage/photo-grid), pode usar este serviço. 

{{% /alert %}}

## **Adicionar uma Imagem como Link**

Para evitar tamanhos grandes de apresentação, você pode adicionar imagens (ou vídeos) por meio de links em vez de incorporar os arquivos diretamente nas apresentações. Este código C# mostra como adicionar uma imagem e um vídeo em um placeholder:

```c#
using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Cortar Imagens**

Este código C# mostra como cortar uma imagem existente em um slide:

```c#
using (Presentation presentation = new Presentation())
{
    // Cria um novo objeto de imagem
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Adiciona um PictureFrame a um slide
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Recorta a imagem (valores em porcentagem)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Salva o resultado
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Excluir Áreas Cortadas de uma Imagem**

Se quiser excluir as áreas cortadas de uma imagem contida em um quadro, pode usar o método [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Esse método devolve a imagem cortada ou a imagem original se o recorte for desnecessário.

Este código C# demonstra a operação:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtém o PictureFrame do primeiro slide
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Exclui áreas recortadas da imagem do PictureFrame e devolve a imagem recortada
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Salva o resultado
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTA" color="warning" %}} 

O método [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) adiciona a imagem recortada à coleção de imagens da apresentação. Se a imagem for usada apenas no [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/pictureframe/) processado, essa configuração pode reduzir o tamanho da apresentação. Caso contrário, o número de imagens na apresentação resultante aumentará.

Esse método converte arquivos metafile WMF/EMF para imagem PNG raster no processo de recorte. 

{{% /alert %}}

## **Compactar Imagens**

Você pode compactar uma imagem em uma apresentação usando o método [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/compressimage/).  
Esse método compacta a imagem reduzindo seu tamanho com base no tamanho da forma e na resolução especificada, com a opção de excluir áreas recortadas.  

Ele ajusta o tamanho e a resolução da imagem de forma semelhante ao recurso **Formato da Imagem → Compactar Imagens → Resolução** do PowerPoint.

Os exemplos C# a seguir demonstram como compactar uma imagem em uma apresentação especificando uma resolução alvo e, opcionalmente, removendo áreas recortadas:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Compacta a imagem com resolução alvo de 150 DPI (resolução da Web) e remove áreas recortadas.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Verifica o resultado da compactação.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

Ou usando um valor DPI personalizado diretamente:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Compacta a imagem para 150 DPI (resolução web), removendo áreas recortadas.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTA" color="warning" %}} 

O método converte a imagem para uma resolução mais baixa com base no tamanho da forma e no DPI fornecido. Regiões recortadas também podem ser excluídas para otimizar o tamanho do arquivo.  
Se a imagem for um metafile (WMF/EMF) ou SVG, a compactação não será aplicada. Além disso, a qualidade do JPEG é preservada ou ligeiramente reduzida conforme a resolução, de maneira semelhante ao que o PowerPoint faz com JPEGs de alta resolução.

{{% /alert %}}

## **Bloquear Proporção**

Se desejar que uma forma contendo uma imagem mantenha sua proporção mesmo após alterar as dimensões da imagem, pode usar a propriedade [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframelock/aspectratiolocked/) para definir a configuração *Bloquear Proporção*.  

Este código C# mostra como bloquear a proporção de uma forma:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Define a forma para manter a proporção ao redimensionar
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTA" color="warning" %}} 

Essa configuração *Bloquear Proporção* preserva apenas a proporção da forma, não a da imagem que ela contém.

{{% /alert %}}

## **Usar a Propriedade StretchOff**

Usando as propriedades [StretchOffsetLeft](https://reference.aspose.com/slides/pt/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/pt/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/pt/net/aspose.slides/picturefillformat/properties/stretchoffsetright) e [StretchOffsetBottom](https://reference.aspose.com/slides/pt/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) da interface [IPictureFillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat) e da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/picturefillformat), você pode especificar um retângulo de preenchimento.  

Quando o estiramento é especificado para uma imagem, um retângulo de origem é escalado para caber no retângulo de preenchimento especificado. Cada borda do retângulo de preenchimento é definida por um deslocamento percentual a partir da borda correspondente da caixa delimitadora da forma. Um percentual positivo indica inserção, enquanto um percentual negativo indica projeção.

1. Crie uma instância da [Presentation](http://www.aspose.com/api/net/slides/pt/aspose.slides/) class.  
2. Obtenha a referência de um slide por seu índice.  
3. Adicione um retângulo `AutoShape`.  
4. Crie uma imagem.  
5. Defina o tipo de preenchimento da forma.  
6. Defina o modo de preenchimento de imagem da forma.  
7. Defina a imagem de preenchimento da forma.  
8. Especifique os deslocamentos da imagem a partir das bordas correspondentes da caixa delimitadora da forma.  
9. Grave a apresentação modificada como um arquivo PPTX.

Este código C# demonstra um processo que usa a propriedade StretchOff:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Define a imagem esticada em todos os lados no corpo da forma
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **Perguntas Frequentes**

**Como descobrir quais formatos de imagem são suportados para PictureFrame?**

O Aspose.Slides suporta tanto imagens raster (PNG, JPEG, BMP, GIF etc.) quanto imagens vetoriais (por exemplo, SVG) por meio do objeto de imagem atribuído a um [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/pictureframe/). A lista de formatos suportados geralmente coincide com as capacidades do motor de conversão de slides e imagens.

**Como a adição de dezenas de imagens grandes afeta o tamanho e o desempenho do PPTX?**

Incorporar imagens grandes aumenta o tamanho do arquivo e o uso de memória; vincular imagens ajuda a manter o tamanho da apresentação reduzido, mas requer que os arquivos externos permaneçam acessíveis. O Aspose.Slides permite adicionar imagens por link para reduzir o tamanho do arquivo.

**Como bloquear um objeto de imagem contra movimentação/redimensionamento acidental?**

Use [travas de forma](https://reference.aspose.com/slides/pt/net/aspose.slides/pictureframe/pictureframelock/) para um [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/pictureframe/) (por exemplo, desabilitar mover ou redimensionar). O mecanismo de bloqueio é descrito para formas em um artigo separado de [proteção](/slides/pt/net/applying-protection-to-presentation/) e é suportado para vários tipos de forma, incluindo [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/pictureframe/).

**A fidelidade vetorial do SVG é preservada ao exportar uma apresentação para PDF/imagens?**

O Aspose.Slides permite extrair um SVG de um [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/pictureframe/) como o vetor original. Ao [exportar para PDF](/slides/pt/net/convert-powerpoint-to-pdf/) ou formatos raster [/converter para PNG](/slides/pt/net/convert-powerpoint-to-png/), o resultado pode ser rasterizado dependendo das configurações de exportação; o fato de o SVG original ser armazenado como vetor é confirmado pelo comportamento de extração.