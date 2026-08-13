---
title: Otimizar o gerenciamento de imagens em apresentações no .NET
linktitle: Gerenciar Imagens
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
- fundo
- adicionar PNG
- adicionar JPG
- adicionar SVG
- recursos SVG externos
- resolvedor SVG
- imagens SVG vinculadas
- fontes SVG
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

As imagens tornam as apresentações mais envolventes e visualmente atraentes. No Microsoft PowerPoint, você pode inserir imagens nos slides a partir de arquivos, da internet ou de outras fontes. Da mesma forma, o Aspose.Slides permite adicionar imagens aos slides de apresentação de várias maneiras.

{{% alert  title="Dica" color="info" %}} 
Aspose fornece conversores gratuitos—[JPEG to PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem criar rapidamente apresentações a partir de imagens. 
{{% /alert %}} 

{{% alert title="Informação" color="info" %}}
Se você quiser adicionar uma imagem como uma moldura de foto — especialmente se planeja redimensioná‑la, aplicar efeitos ou usar outras opções de formatação padrão — veja [Picture Frame](/slides/pt/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}
Você pode converter imagens de um formato para outro. Consulte as páginas a seguir: converter [image to JPG](https://products.aspose.com/slides/pt/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/pt/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/pt/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/pt/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/pt/net/conversion/png-to-svg/), e [SVG to PNG](https://products.aspose.com/slides/pt/net/conversion/svg-to-png/).
{{% /alert %}}

O Aspose.Slides oferece suporte a imagens em formatos populares, como JPEG, PNG, BMP, GIF e outros. 

## **Adicionar Imagens Armazenadas Localmente aos Slides**

Você pode adicionar uma ou mais imagens armazenadas no seu computador a um slide de apresentação. O código de exemplo C# a seguir mostra como adicionar uma imagem a um slide:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Adicionar Imagens da Web aos Slides**

Se a imagem que você deseja adicionar a um slide não estiver armazenada no seu computador, você pode adicioná‑la diretamente da web. 

O código de exemplo C# a seguir mostra como adicionar uma imagem da web a um slide:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Adicionar Imagens aos Mestres de Slide**

Um mestre de slide armazena e controla informações como o tema e o layout dos slides que o utilizam. Quando você adiciona uma imagem a um mestre de slide, a imagem aparece em todos os slides baseados nesse mestre. 

O código de exemplo C# a seguir mostra como adicionar uma imagem a um mestre de slide:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Adicionar Imagens como Fundo de Slides**

Você pode usar uma imagem como fundo para um ou mais slides. Para detalhes, veja *[Definir Imagens como Fundos de Slides](/slides/pt/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Adicionar SVG a Apresentações**

O conteúdo SVG pode ser adicionado a uma apresentação usando a classe [SvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/svgimage/). O objeto [ISvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage/) resultante pode então ser adicionado à coleção de imagens da apresentação e usado para criar uma moldura de foto. 

O exemplo C# a seguir importa uma string SVG autônoma. Todas as imagens, estilos e outros recursos usados por este SVG são incorporados diretamente ao conteúdo SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **Importar Conteúdo SVG com Recursos Externos**

Arquivos SVG exportados de ferramentas de design, editores de diagramas, sistemas de ícones e pipelines da web podem referenciar recursos armazenados fora do documento SVG. Por exemplo, um SVG pode conter um link de imagem como `images/photo.png`, um valor CSS `url(...)` ou uma URL de fonte. 

Para importar esse conteúdo SVG, crie uma implementação de [IExternalResourceResolver](https://reference.aspose.com/slides/pt/net/aspose.slides.import/iexternalresourceresolver/) e passe‑a, juntamente com um URI base, para o construtor adequado de `SvgImage`. O URI base identifica a localização do documento SVG e é usado para resolver links relativos. 

A interface [ISvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage/) fornece acesso às informações sobre o SVG importado:
- `SvgContent` retorna a marcação SVG como uma string.
- `SvgData` retorna o conteúdo SVG como um array de bytes.
- `BaseUri` retorna o URI base usado para links relativos.
- `ExternalResourceResolver` retorna o resolvedor atribuído à imagem SVG.

### **Implementar um Resolvedor de Recurso Externo**

O resolvedor possui dois métodos:
- [ResolveUri](https://reference.aspose.com/slides/pt/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) combina o URI base e um link de recurso relativo e retorna um URI absoluto. Retorne `null` quando o link não puder ser resolvido ou não for permitido.
- [GetEntity](https://reference.aspose.com/slides/pt/net/aspose.slides.import/iexternalresourceresolver/getentity/) retorna um fluxo legível para um URI de recurso absoluto. Retorne `null` quando o recurso estiver ausente, bloqueado ou indisponível. Um fluxo de fallback também pode ser retornado quando apropriado.

O resolvedor a seguir carrega recursos vinculados apenas de um diretório local permitido. Recursos de rede e caminhos fora do diretório permitido são bloqueados. Uma imagem de fallback opcional é retornada para links de imagem não resolvidos.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // Este resolvedor permite intencionalmente apenas arquivos locais.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Use um fallback apenas para recursos de imagem. Retornar um fluxo de imagem
        // para uma fonte ou folha de estilo ausente não seria válido.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **Resolver Recursos Vinculados Durante a Importação de SVG**

Assuma que `assets/diagram.svg` contém uma referência relativa como:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

O exemplo C# a seguir passa o URI do arquivo SVG como URI base e fornece um resolvedor personalizado. O resolvedor converte o link de imagem relativo em um URI absoluto e retorna um fluxo contendo o recurso vinculado enquanto o Aspose.Slides processa o SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// O URI base representa a localização do documento SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage expõe o conteúdo fonte, os dados binários, o URI base e o resolvedor.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

A classe `SvgImage` também fornece sobrecargas que aceitam dados SVG como um array de bytes ou um fluxo, juntamente com um resolvedor de recurso externo e um URI base.

{{% alert title="Importante" color="warning" %}}
O resolvedor de recursos disponibiliza recursos externos enquanto o Aspose.Slides processa e renderiza o SVG. Ele não modifica a marcação SVG original nem incorpora automaticamente os recursos resolvidos nele.

Quando um `ISvgImage` é adicionado à coleção de imagens da apresentação, o arquivo PPTX pode conter tanto a representação SVG original quanto uma imagem raster de fallback. Um recurso vinculado pode aparecer na imagem de fallback gerada enquanto um link relativo como `images/photo.png` permanece inalterado no SVG armazenado. Um aplicativo que renderiza a representação SVG nativa pode, portanto, omitir o conteúdo vinculado quando o recurso externo original estiver indisponível.
{{% /alert %}}

### **Criar uma Imagem SVG Portável**

Para criar uma imagem SVG que não dependa de arquivos externos, torne o SVG autônomo antes de criar o `SvgImage`. Por exemplo, substitua URLs de imagens vinculadas por URIs `data:` que contenham os dados da imagem:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Depois que todos os recursos necessários estiverem incorporados ao conteúdo SVG, crie o `SvgImage`, adicione‑o à coleção de imagens da apresentação e insira‑o em uma moldura de foto conforme mostrado no exemplo anterior.

### **Lidar com Recursos Ausentes ou Bloqueados**

Retorne `null` de `ResolveUri` quando um URI de recurso for inválido, proibido ou não puder ser resolvido. Retorne `null` de `GetEntity` quando o recurso não puder ser lido. O Aspose.Slides continua processando o SVG sem esse recurso quando possível.

Um fluxo de fallback pode ser retornado para um recurso ausente, mas seu conteúdo deve ser compatível com o tipo de recurso solicitado. Por exemplo, retorne um fluxo de imagem apenas para uma imagem ausente, não para uma fonte ou folha de estilos.

{{% alert title="Segurança" color="warning" %}}
Não resolva caminhos de arquivos arbitrários ou URLs de rede irrestritas de arquivos SVG não confiáveis. Restrinja esquemas, diretórios e hosts permitidos. Para recursos de rede, aplique também limites de tempo de conexão, tamanho de resposta e validação de conteúdo.
{{% /alert %}}

## **Converter SVG em um Conjunto de Formas**
O Aspose.Slides pode converter um SVG em um conjunto de formas, semelhante à funcionalidade correspondente no PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Essa funcionalidade é fornecida por uma sobrecarga do método [AddGroupShape](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/addgroupshape/methods/1) da interface [IShapeCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection) que aceita um objeto [ISvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage) como seu primeiro argumento.

O código de exemplo C# a seguir mostra como usar este método para converter um arquivo SVG em um conjunto de formas:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Nome do arquivo SVG fonte
string svgFileName = "sample.svg";

// Nome do arquivo de saída da apresentação
string outPptxPath = "presentation.pptx";

// Cria uma nova apresentação
using (IPresentation presentation = new Presentation())
{
    // Lê o conteúdo do arquivo SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Cria um objeto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obtém o tamanho do slide
    SizeF slideSize = presentation.SlideSize.Size;

    // Converte a imagem SVG em um grupo de formas e a dimensiona ao tamanho do slide
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Salva a apresentação no formato PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Adicionar Imagens como EMF aos Slides**
O Aspose.Slides for .NET permite gerar imagens EMF a partir de planilhas Excel com o Aspose.Cells e adicioná‑las aos slides de apresentação.

O código de exemplo C# a seguir mostra como fazer isso:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Salvar a pasta de trabalho em um fluxo
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Substituir Imagens na Coleção de Imagens**
O Aspose.Slides permite substituir imagens armazenadas na coleção de imagens de uma apresentação, incluindo imagens usadas por formas de slide. Esta seção descreve várias formas de atualizar imagens na coleção. Você pode substituir uma imagem usando dados de bytes brutos, uma instância de [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/), ou outra imagem que já exista na coleção.

Siga os passos abaixo:
1. Carregue o arquivo de apresentação que contém imagens usando a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Carregue uma nova imagem de um arquivo em um array de bytes.
3. Substitua a imagem alvo pela nova imagem usando o array de bytes.
4. Na segunda abordagem, carregue a imagem em um objeto [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) e substitua a imagem alvo por esse objeto.
5. Na terceira abordagem, substitua a imagem alvo por uma imagem que já exista na coleção de imagens da apresentação.
6. Grave a apresentação modificada como um arquivo PPTX.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert title="Informação" color="info" %}}
Com o conversor gratuito [Text to GIF](https://products.aspose.app/slides/pt/text-to-gif) da Aspose, você pode animar texto facilmente e criar GIFs a partir de texto. 
{{% /alert %}}

## **Perguntas Frequentes**

**A resolução da imagem original permanece intacta após a inserção?**

Sim. Os pixels originais são preservados, mas a aparência final depende de como a [imagem](/slides/pt/net/picture-frame/) é dimensionada no slide e de qualquer compressão aplicada ao salvar.

**Qual é a melhor forma de substituir o mesmo logotipo em dezenas de slides de uma vez?**

Coloque o logotipo no slide mestre ou em um layout e substitua‑lo na coleção de imagens da apresentação — as atualizações se propagarão para todos os elementos que utilizam esse recurso.

**Um SVG inserido pode ser convertido em formas editáveis?**

Sim. Você pode converter um SVG em um grupo de formas, após o qual as partes individuais tornam‑se editáveis com as propriedades padrão de forma.

**Como posso definir uma imagem como fundo para vários slides ao mesmo tempo?**

[Atribuir a imagem como fundo](/slides/pt/net/presentation-background/) no slide mestre ou no layout relevante — quaisquer slides que usarem esse mestre/layout herdarão o fundo.

**Como evito que uma apresentação se torne muito grande por causa de muitas imagens?**

Reutilize um único recurso de imagem em vez de duplicados, escolha resoluções razoáveis, aplique compressão ao salvar e mantenha gráficos repetidos no mestre quando apropriado.