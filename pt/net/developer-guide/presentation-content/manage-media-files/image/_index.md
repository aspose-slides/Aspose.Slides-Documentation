---
title: Optimizar o gerenciamento de imagens em apresentações no .NET
linktitle: Gerenciar imagens
type: docs
weight: 10
url: /pt/net/image/
keywords:
- adicionar imagem
- adicionar foto
- adicionar bitmap
- substituir imagem
- substituir foto
- da web
- plano de fundo
- adicionar PNG
- adicionar JPG
- adicionar SVG
- adicionar EMF
- adicionar WMF
- adicionar TIFF
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Simplifique o gerenciamento de imagens no PowerPoint e OpenDocument com Aspose.Slides para .NET, otimizando o desempenho e automatizando seu fluxo de trabalho."
---
## **Introdução**

Imagens tornam as apresentações mais envolventes e interessantes. No Microsoft PowerPoint, você pode inserir imagens de um arquivo, da internet ou de outros locais em slides. Da mesma forma, o Aspose.Slides permite que você adicione imagens aos slides em suas apresentações por meio de diferentes procedimentos.

{{% alert  title="Tip" color="primary" %}} 

A Aspose oferece conversores gratuitos—[JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem que as pessoas criem apresentações rapidamente a partir de imagens. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se você quiser adicionar uma imagem como um objeto de quadro—especialmente se pretender usar opções de formatação padrão nela para alterar seu tamanho, adicionar efeitos etc.—veja [Picture Frame](https://docs.aspose.com/slides/pt/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Você pode manipular operações de entrada/saída envolvendo imagens e apresentações PowerPoint para converter uma imagem de um formato para outro. Veja estas páginas: converter [imagem para JPG](https://products.aspose.com/slides/pt/net/conversion/image-to-jpg/); converter [JPG para imagem](https://products.aspose.com/slides/pt/net/conversion/jpg-to-image/); converter [JPG para PNG](https://products.aspose.com/slides/pt/net/conversion/jpg-to-png/), converter [PNG para JPG](https://products.aspose.com/slides/pt/net/conversion/png-to-jpg/); converter [PNG para SVG](https://products.aspose.com/slides/pt/net/conversion/png-to-svg/), converter [SVG para PNG](https://products.aspose.com/slides/pt/net/conversion/svg-to-png/).

{{% /alert %}}

O Aspose.Slides oferece suporte a operações com imagens nesses formatos populares: JPEG, PNG, BMP, GIF e outros. 

## **Adicionar Imagens Armazenadas Localmente a Slides**

Você pode adicionar uma ou várias imagens do seu computador a um slide em uma apresentação. Este código de exemplo em C# mostra como adicionar uma imagem a um slide:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Adicionar Imagens da Web a Slides**

Se a imagem que você deseja adicionar a um slide não estiver disponível no seu computador, você pode adicioná‑la diretamente da web. 

Este código de exemplo mostra como adicionar uma imagem da web a um slide em C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Adicionar Imagens aos Mestres de Slides**

Um mestre de slide é o slide superior que armazena e controla informações (tema, layout, etc.) sobre todos os slides abaixo dele. Portanto, ao adicionar uma imagem a um mestre de slide, essa imagem aparece em cada slide que utiliza esse mestre. 

Este código de exemplo em C# mostra como adicionar uma imagem a um mestre de slide:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Adicionar Imagens como Plano de Fundo de Slides**

Você pode decidir usar uma imagem como plano de fundo para um slide específico ou vários slides. Nesse caso, você deve ver *[Definindo Imagens como Plano de Fundo para Slides](https://docs.aspose.com/slides/pt/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Adicionar SVG a Apresentações**
Você pode adicionar ou inserir qualquer imagem em uma apresentação usando o método [AddPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/methods/addpictureframe) que pertence à interface [IShapeCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection).

Para criar um objeto de imagem baseado em uma imagem SVG, você pode fazer assim:

1. Crie um objeto SvgImage para inseri‑lo em ImageShapeCollection
2. Crie um objeto PPImage a partir de ISvgImage
3. Crie um objeto PictureFrame usando a interface IPPImage

Este código de exemplo mostra como implementar as etapas acima para adicionar uma imagem SVG a uma apresentação:
``` csharp 
// O caminho para o diretório de documentos
string dataDir = @"D:\Documents\";

// Nome do arquivo SVG de origem
string svgFileName = dataDir + "sample.svg";

// Nome do arquivo de apresentação de saída
string outPptxPath = dataDir + "presentation.pptx";

// Criar nova apresentação
using (var p = new Presentation())
{
    // Ler o conteúdo do arquivo SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Criar objeto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Criar objeto PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Cria um novo PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Salvar a apresentação no formato PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Converter SVG em um Conjunto de Formas**
A conversão de SVG para um conjunto de formas do Aspose.Slides é semelhante à funcionalidade do PowerPoint usada para trabalhar com imagens SVG:

![PowerPoint Popup Menu](img_01_01.png)

A funcionalidade é fornecida por uma das sobrecargas do método [AddGroupShape](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/addgroupshape/methods/1) da interface [IShapeCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection) que aceita um objeto [ISvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage) como primeiro argumento.

Este código de exemplo mostra como usar o método descrito para converter um arquivo SVG em um conjunto de formas:

``` csharp 
// O caminho para o diretório de documentos
string dataDir = @"D:\Documents\";

// Nome do arquivo SVG de origem
string svgFileName = dataDir + "sample.svg";

// Nome do arquivo de apresentação de saída
string outPptxPath = dataDir + "presentation.pptx";

// Criar nova apresentação
using (IPresentation presentation = new Presentation())
{
    // Ler o conteúdo do arquivo SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Criar objeto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obter tamanho do slide
    SizeF slideSize = presentation.SlideSize.Size;

    // Converter imagem SVG em grupo de formas dimensionando-a ao tamanho do slide
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Salvar a apresentação no formato PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Adicionar Imagens como EMF a Slides**
O Aspose.Slides para .NET permite gerar imagens EMF a partir de planilhas Excel e adicionar as imagens como EMF em slides com o Aspose.Cells. 

Este código de exemplo mostra como executar a tarefa descrita:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Salvar a pasta de trabalho no fluxo
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Substituir Imagens na Coleção de Imagens**

O Aspose.Slides permite substituir imagens armazenadas na coleção de imagens de uma apresentação (incluindo aquelas usadas por formas de slide). Esta seção mostra várias abordagens para atualizar imagens na coleção. A API fornece métodos simples para substituir uma imagem usando dados brutos de byte, uma instância [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) ou outra imagem que já exista na coleção.

Siga os passos abaixo:

1. Carregue o arquivo de apresentação que contém imagens usando a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Carregue uma nova imagem de um arquivo em um array de bytes.
3. Substitua a imagem alvo pela nova imagem usando o array de bytes.
4. Na segunda abordagem, carregue a imagem em um objeto [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) e substitua a imagem alvo por esse objeto.
5. Na terceira abordagem, substitua a imagem alvo por uma imagem que já exista na coleção de imagens da apresentação.
6. Grave a apresentação modificada como um arquivo PPTX.

```cs
// Instanciar a classe Presentation que representa um arquivo de apresentação.
using Presentation presentation = new Presentation("sample.pptx");

// A primeira maneira.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// A segunda maneira.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// A terceira maneira.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Salvar a apresentação em um arquivo.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Usando o conversor GRATUITO Aspose [Text to GIF](https://products.aspose.app/slides/pt/text-to-gif), você pode animar textos facilmente, criar GIFs a partir de textos, etc. 

{{% /alert %}}

## **FAQ**

**A resolução original da imagem permanece intacta após a inserção?**

Sim. Os pixels originais são preservados, mas a aparência final depende de como o [picture](/slides/pt/net/picture-frame/) é dimensionado no slide e de qualquer compressão aplicada ao salvar.

**Qual é a melhor maneira de substituir o mesmo logotipo em dezenas de slides de uma só vez?**

Coloque o logotipo no slide mestre ou em um layout e substitua‑o na coleção de imagens da apresentação—as alterações se propagarão a todos os elementos que utilizam esse recurso.

**Um SVG inserido pode ser convertido em formas editáveis?**

Sim. Você pode converter um SVG em um grupo de formas, após o que as partes individuais se tornam editáveis com as propriedades padrão de forma.

**Como posso definir uma imagem como plano de fundo para vários slides de uma vez?**

[Defina a imagem como plano de fundo](/slides/pt/net/presentation-background/) no slide mestre ou no layout correspondente—qualquer slide que use esse mestre/layout herdará o plano de fundo.

**Como evitar que a apresentação “infle” de tamanho por causa de muitas imagens?**

Reutilize um único recurso de imagem em vez de duplicados, escolha resoluções razoáveis, aplique compressão ao salvar e mantenha gráficos repetidos no mestre onde for apropriado.