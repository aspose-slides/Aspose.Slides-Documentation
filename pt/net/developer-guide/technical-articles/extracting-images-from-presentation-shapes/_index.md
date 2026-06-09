---
title: Extrair imagens de formas de apresentação em .NET
linktitle: Imagem da Forma
type: docs
weight: 90
url: /pt/net/extracting-images-from-presentation-shapes/
keywords:
- extrair imagem
- recuperar imagem
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Extrair imagens de formas em apresentações PowerPoint e OpenDocument com Aspose.Slides para .NET – solução rápida e amigável ao código."
---
## **Visão geral**

Imagens em uma apresentação podem aparecer em vários tipos de forma: como quadros de imagem comuns, como preenchimentos de imagem aplicados a formas, como imagens de visualização de objetos OLE, como miniaturas de quadros de vídeo ou áudio, como imagens de zoom ou como imagens aninhadas dentro de tabelas, gráficos e formas SmartArt. Aspose.Slides armazena essas imagens na coleção de imagens da apresentação, exposta por meio dos objetos [ImageCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/imagecollection/) e [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) .

Se você só precisa exportar todos os recursos de imagem incorporados em uma apresentação, itere por `presentation.Images`. Este artigo foca em uma tarefa diferente: percorrer as formas para encontrar onde as imagens são usadas nos slides, de modo que os arquivos gravados mantenham contexto útil, como o número do slide, a posição da forma e o tipo de origem (quadro de imagem, imagem de preenchimento, visualização de mídia, visualização OLE ou imagem de zoom).

{{% alert title="Tip" color="primary" %}}
Use [IPPImage.BinaryData](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) para preservar os dados de imagem codificados originais e o tipo de arquivo. Use [IPPImage.Image](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) com [IImage.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) quando quiser normalizar a saída para um formato específico, como PNG.
{{% /alert %}}

## **Métodos auxiliares compartilhados**

Os métodos auxiliares abaixo mantêm os exemplos curtos. `SaveOriginalImage` grava os bytes incorporados originais, escolhe uma extensão segura a partir do tipo MIME e ignora binários de imagem duplicados usando hash SHA-256.

```c#
using Aspose.Slides;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

private static bool SaveOriginalImage(
    IPPImage image,
    string outputDirectory,
    string fileNameBase,
    ISet<string> savedImageHashes)
{
    byte[] imageData = image.BinaryData;
    string imageHash = GetSha256Hash(imageData);
    if (!savedImageHashes.Add(imageHash))
    {
        return false;
    }

    string extension = GetExtensionFromContentType(image.ContentType);
    string fileName = $"{fileNameBase}.{extension}";
    string outputPath = Path.Combine(outputDirectory, fileName);
    File.WriteAllBytes(outputPath, imageData);
    return true;
}

private static void SaveImageAsPng(IPPImage image, string outputDirectory, string fileNameBase)
{
    string fileName = $"{fileNameBase}.png";
    string outputPath = Path.Combine(outputDirectory, fileName);

    using (IImage outputImage = image.Image)
    {
        outputImage.Save(outputPath, ImageFormat.Png);
    }
}

private static IPPImage GetPictureFillImage(IFillFormat fillFormat)
{
    if (fillFormat == null || fillFormat.FillType != FillType.Picture)
    {
        return null;
    }

    return fillFormat.PictureFillFormat.Picture.Image;
}

private static IEnumerable<(IShape Shape, string NamePart)> EnumerateShapes(
    IShapeCollection shapes,
    string prefix,
    bool includeGroupedShapes)
{
    int shapeCount = shapes.Count;
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        IShape shape = shapes[shapeIndex];
        int displayIndex = shapeIndex + 1;
        string shapeNamePart = $"{prefix}_shape_{displayIndex}";
        yield return (shape, shapeNamePart);

        if (includeGroupedShapes && shape is IGroupShape groupShape)
        {
            foreach ((IShape Shape, string NamePart) childShape in EnumerateShapes(
                groupShape.Shapes,
                shapeNamePart,
                includeGroupedShapes))
            {
                yield return childShape;
            }
        }
    }
}

private static string GetSha256Hash(byte[] data)
{
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] hash = sha256.ComputeHash(data);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
}

private static string GetExtensionFromContentType(string contentType)
{
    if (string.IsNullOrWhiteSpace(contentType))
    {
        return "bin";
    }

    string mediaType = contentType.Split(';')[0].Trim().ToLowerInvariant();
    switch (mediaType)
    {
        case "image/jpeg":
            return "jpg";
        case "image/png":
            return "png";
        case "image/gif":
            return "gif";
        case "image/bmp":
            return "bmp";
        case "image/tiff":
            return "tiff";
        case "image/x-emf":
        case "image/emf":
            return "emf";
        case "image/x-wmf":
        case "image/wmf":
            return "wmf";
        case "image/svg+xml":
            return "svg";
        default:
            if (mediaType.StartsWith("image/"))
            {
                string extension = mediaType.Substring("image/".Length);
                return MakeSafeFileNamePart(extension);
            }

            return "bin";
    }
}

private static string MakeSafeFileNamePart(string value)
{
    foreach (char invalidCharacter in Path.GetInvalidFileNameChars())
    {
        value = value.Replace(invalidCharacter, '_');
    }

    return value;
}
```

## **Extrair imagens de quadros de imagem**

Use esta abordagem para imagens inseridas como objetos independentes. Um [IPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe/) armazena sua imagem em `PictureFormat.Picture.Image`, que devolve um objeto [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) .

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "extracted-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
            }
        }
    }
}
```

## **Extrair imagens de formas preenchidas com imagem**

As formas podem usar uma imagem como preenchimento. Verifique primeiro o tipo de preenchimento da forma: se não for [FillType.Picture](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/), não há imagem para extrair desse preenchimento. O exemplo abaixo trata objetos [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) e salva cada imagem como PNG através de [IPPImage.Image](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) .

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "shape-fill-images");
Directory.CreateDirectory(outputDirectory);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveImageAsPng(image, outputDirectory, item.NamePart);
                }
            }
        }
    }
}
```

## **Extrair imagens de visualização de quadros de objeto OLE**

Um [IOleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ioleobjectframe/) pode ter uma imagem substituta que o PowerPoint usa como visualização do objeto em um slide. Essa imagem está disponível através de `SubstitutePictureFormat.Picture.Image`. Extrair essa imagem fornece a visualização, não o conteúdo do pacote OLE incorporado.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "ole-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Extrair imagens de visualização de quadros de vídeo**

Um [IVideoFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/) também pode armazenar uma imagem de visualização em `PictureFormat.Picture.Image`. Esta é a imagem de pôster ou miniatura exibida no slide, não um quadro decodificado a partir do fluxo de vídeo.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "video-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Extrair imagens de visualização de quadros de áudio**

Um [IAudioFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iaudioframe/) pode armazenar uma miniatura em `PictureFormat.Picture.Image`. Esta é a imagem exibida para o objeto de áudio no slide.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "audio-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Extrair imagens de objetos de zoom**

Formas [IZoomFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/izoomframe/) e [ISectionZoomFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/isectionzoomframe/) podem usar imagens personalizadas. Leia `ZoomImage` do quadro de zoom.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IZoomFrame zoomFrame && zoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_zoom";
                SaveOriginalImage(zoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

            if (item.Shape is ISectionZoomFrame sectionZoomFrame && sectionZoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_section_zoom";
                SaveOriginalImage(sectionZoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

        }
    }
}
```

## **Extrair imagens de quadros de zoom resumido**

Um [ISummaryZoomFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/isummaryzoomframe/) também é uma forma. Seus itens de seção podem usar imagens personalizadas, expostas através da propriedade `ZoomImage` de cada seção de zoom resumido.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "summary-zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is ISummaryZoomFrame summaryZoomFrame)
            {
                int sectionCount = summaryZoomFrame.SummaryZoomCollection.Count;
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    ISummaryZoomSection section = summaryZoomFrame.SummaryZoomCollection[sectionIndex];
                    if (section.ZoomImage != null)
                    {
                        int displayIndex = sectionIndex + 1;
                        string fileNameBase = $"{item.NamePart}_summary_zoom_{displayIndex}";
                        SaveOriginalImage(section.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}
```

## **Extrair imagens de formas de tabela**

Um [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) é uma forma. Imagens em uma tabela geralmente são armazenadas como preenchimentos de imagem nas células da tabela.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "table-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is ITable table)
            {
                int rowCount = table.Rows.Count;
                int columnCount = table.Columns.Count;
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        ICell cell = table[columnIndex, rowIndex];
                        IPPImage image = GetPictureFillImage(cell.CellFormat.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_cell_{rowIndex + 1}_{columnIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **Extrair imagens de formas de gráfico**

Um [IChart](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/) é uma forma. O exemplo abaixo extrai uma imagem do preenchimento de imagem da área do gráfico.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "chart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.Charts.IChart chart)
            {
                IFillFormat fillFormat = chart.FillFormat;
                IPPImage image = GetPictureFillImage(fillFormat);
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_chart_area";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Extrair imagens de formas SmartArt**

Um objeto [ISmartArt](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/ismartart/) é uma forma. Dependendo do layout do SmartArt, as imagens podem ser armazenadas nos preenchimentos de marcadores de nós ou nos formatos de preenchimento das formas de nó.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "smartart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
            {
                int nodeCount = smartArt.AllNodes.Count;
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[nodeIndex];
                    IPPImage bulletImage = GetPictureFillImage(node.BulletFillFormat);
                    if (bulletImage != null)
                    {
                        string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_bullet";
                        SaveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node.Shapes.Count;
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        var nodeShape = node.Shapes[nodeShapeIndex];
                        IPPImage image = GetPictureFillImage(nodeShape.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_shape_{nodeShapeIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **Incluir imagens dentro de formas agrupadas**

Formas agrupadas contêm suas próprias coleções de formas. O auxiliar compartilhado `EnumerateShapes` possui uma opção `includeGroupedShapes`. Defina-a como `true` quando quiser inspecionar as formas dentro de objetos [IGroupShape](https://reference.aspose.com/slides/pt/net/aspose.slides/igroupshape/) . O exemplo abaixo extrai imagens de quadros de imagem, formas preenchidas com imagem, visualizações de objetos OLE, miniaturas de quadros de vídeo e miniaturas de quadros de áudio. Para incluir também imagens de tabelas, gráficos, SmartArt e zoom resumido, reutilize a lógica de extração especializada das seções anteriores mantendo a mesma travessia recursiva de formas.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "all-shape-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                continue;
            }

            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Casos limites e notas práticas**

- **Imagens duplicadas:** Várias formas podem referenciar a mesma imagem ou imagens diferentes com bytes idênticos. Compute o hash de [IPPImage.BinaryData](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) antes de gravar arquivos se quiser um arquivo de saída por imagem única.
- **Dados originais vs. saída convertida:** Salvar [IPPImage.BinaryData](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) preserva os dados JPEG, PNG, GIF, SVG, EMF ou WMF incorporados. Salvar [IPPImage.Image](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) através de [IImage.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) é útil quando você deseja um formato de saída consistente.
- **Tipos de preenchimento não suportados:** Formas sólidas, gradientes, padrões e sem preenchimento não contêm preenchimento de imagem. Verifique [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) antes de ler `PictureFillFormat`.
- **Formas agrupadas:** A coleção de formas do slide de nível superior não achata os grupos. Inspecione recursivamente [IGroupShape.Shapes](https://reference.aspose.com/slides/pt/net/aspose.slides/igroupshape/) quando o conteúdo agrupado for relevante.
- **Visualizações de objetos OLE:** Um [IOleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ioleobjectframe/) pode expor uma imagem de visualização através de `SubstitutePictureFormat`, mas essa imagem é apenas a visualização do slide. Não é o arquivo incorporado dentro do objeto OLE.
- **Miniaturas de quadros de vídeo:** Um [IVideoFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/) pode expor uma imagem de visualização através de `PictureFormat`, mas essa imagem é apenas o pôster exibido no slide. Não é extraída do fluxo de vídeo.
- **Miniaturas de quadros de áudio:** Um [IAudioFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iaudioframe/) pode expor um ícone ou miniatura através de `PictureFormat`; não são os dados de áudio incorporados.
- **Imagens de zoom:** Formas de zoom de slide, zoom de seção e zoom resumido podem usar objetos [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) personalizados através de `ZoomImage`.
- **Modelos de forma aninhados:** objetos de tabela, gráfico e SmartArt implementam [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/), mas suas imagens geralmente são armazenadas em objetos de formatação aninhados de célula de tabela, elemento de gráfico ou nó de SmartArt.
- **Imagens recortadas ou transformadas:** Acessar [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) fornece o recurso de imagem armazenado. Não renderiza recorte, transparência, recoloração, rotação ou outros efeitos visuais aplicados pela forma.

## **Perguntas Frequentes**

**Posso extrair a imagem original sem recorte, efeitos ou transformações de forma?**

Sim. Acesse o objeto [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) e grave [IPPImage.BinaryData](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) no disco. Isso preserva a imagem codificada original armazenada na apresentação, não a forma como a imagem é renderizada no slide.

**Posso exportar todas as imagens extraídas como PNG?**

Sim. Use [IPPImage.Image](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) para obter um objeto [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) e, em seguida, chame [IImage.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) com [ImageFormat.Png](https://reference.aspose.com/slides/pt/net/aspose.slides/imageformat/). Isso converte a saída e pode não preservar o tipo de arquivo original ou dados vetoriais.

**Como evito salvar a mesma imagem mais de uma vez?**

Use um hash de [IPPImage.BinaryData](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) e mantenha os hashes em um conjunto. Se uma nova imagem tiver um hash que já exista, ignore-a ou registre outra referência ao arquivo de saída existente.

**Por que algumas formas não geram uma imagem?**

Quadros de imagem, formas preenchidas com imagem, quadros de objeto OLE, quadros de mídia, quadros de zoom, tabelas, gráficos e objetos SmartArt podem referenciar imagens. Alguns tipos de forma expõem imagens através de objetos de formatação aninhados, portanto uma simples verificação de `PictureFormat` ou `FillFormat` da forma nem sempre é suficiente.

**Posso extrair a miniatura mostrada para um quadro de vídeo?**

Sim. Use [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/) e leia `PictureFormat.Picture.Image`. Isso extrai a imagem de pôster armazenada com o quadro de vídeo, não um quadro gerado a partir do arquivo de vídeo.

**Como posso determinar quais formas usam uma imagem específica da coleção de imagens da apresentação?**

Aspose.Slides não armazena links reversos de [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) para formas. Construa um mapeamento durante a travessia: sempre que encontrar uma referência de imagem, registre o número do slide, o caminho da forma e o hash da imagem ou o item da coleção.

**Posso extrair imagens incorporadas dentro de objetos OLE, como documentos anexados?**

Você pode extrair a visualização de slide do objeto OLE através de [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ioleobjectframe/). Contudo, essa visualização não é o documento incorporado em si. Para extrair imagens de dentro do arquivo incorporado, extraia os dados OLE e inspecione-os com ferramentas adequadas ao tipo de arquivo.