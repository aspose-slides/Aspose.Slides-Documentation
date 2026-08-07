---
title: Otimizar o Gerenciamento de Imagens em Apresentações no .NET
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
- plano de fundo
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

Imagens tornam as apresentações mais envolventes e visualmente atraentes. No Microsoft PowerPoint, você pode inserir fotos nos slides a partir de arquivos, da internet ou de outras fontes. Da mesma forma, o Aspose.Slides permite que você adicione imagens aos slides da apresentação de várias maneiras.

{{% alert  title="Dica" color="primary" %}} 

A Aspose oferece conversores gratuitos—[JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem criar rapidamente apresentações a partir de imagens. 

{{% /alert %}} 

{{% alert title="Informação" color="info" %}}

Se você quiser adicionar uma imagem como moldura de foto—especialmente se pretender redimensioná‑la, aplicar efeitos ou usar outras opções de formatação padrão—consulte [Moldura de Foto](/slides/pt/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Você pode converter imagens de um formato para outro. Veja as páginas a seguir: converter [imagem para JPG](https://products.aspose.com/slides/pt/net/conversion/image-to-jpg/), [JPG para imagem](https://products.aspose.com/slides/pt/net/conversion/jpg-to-image/), [JPG para PNG](https://products.aspose.com/slides/pt/net/conversion/jpg-to-png/), [PNG para JPG](https://products.aspose.com/slides/pt/net/conversion/png-to-jpg/), [PNG para SVG](https://products.aspose.com/slides/pt/net/conversion/png-to-svg/), e [SVG para PNG](https://products.aspose.com/slides/pt/net/conversion/svg-to-png/).

{{% /alert %}}

O Aspose.Slides oferece suporte a imagens em formatos populares como JPEG, PNG, BMP, GIF e outros. 

## **Adicionar Imagens Armazenadas Localmente aos Slides**

Você pode adicionar uma ou mais imagens armazenadas no seu computador a um slide da apresentação. O código de exemplo em C# a seguir mostra como adicionar uma imagem a um slide:

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

Se a imagem que você deseja adicionar a um slide não estiver armazenada no seu computador, pode inseri‑la diretamente da web. 

O código de exemplo em C# a seguir mostra como adicionar uma imagem da web a um slide:

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

## **Adicionar Imagens a Mestres de Slides**

Um mestre de slides armazena e controla informações como o tema e o layout dos slides que o utilizam. Quando você adiciona uma imagem a um mestre de slides, a imagem aparece em todos os slides baseados naquele mestre. 

O código de exemplo em C# a seguir mostra como adicionar uma imagem a um mestre de slides:

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

## **Adicionar Imagens como Plano de Fundo dos Slides**

Você pode usar uma foto como plano de fundo de um ou mais slides. Para detalhes, consulte *[Definir Imagens como Plano de Fundo dos Slides](/slides/pt/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Adicionar SVG às Apresentações**

Conteúdo SVG pode ser adicionado a uma apresentação usando a classe [SvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/svgimage/). O objeto resultante [ISvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage/) pode então ser adicionado à coleção de imagens da apresentação e usado para criar uma moldura de foto.

O exemplo em C# a seguir importa uma string SVG autocontida. Todas as imagens, estilos e demais recursos usados por esse SVG são incorporados diretamente no conteúdo SVG.

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

Arquivos SVG exportados de ferramentas de design, editores de diagramas, sistemas de ícones e pipelines web podem referenciar recursos armazenados fora do documento SVG. Por exemplo, um SVG pode conter um link de imagem como `images/photo.png`, um valor CSS `url(...)` ou uma URL de fonte.

Para importar esse conteúdo SVG, crie uma implementação de [IExternalResourceResolver](https://reference.aspose.com/slides/pt/net/aspose.slides.import/iexternalresourceresolver/) e passe‑a, juntamente com um URI base, a um construtor apropriado de `SvgImage`. O URI base identifica a localização do documento SVG e é usado para resolver links relativos.

A interface [ISvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage/) fornece acesso às informações sobre o SVG importado:

- `SvgContent` devolve a marcação SVG como string.
- `SvgData` devolve o conteúdo SVG como array de bytes.
- `BaseUri` devolve o URI base usado para links relativos.
- `ExternalResourceResolver` devolve o resolvedor atribuído à imagem SVG.

### **Implementar um Resolvedor de Recursos Externos**

O resolvedor possui dois métodos:

- [ResolveUri](https://reference.aspose.com/slides/pt/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) combina o URI base e um link de recurso relativo e devolve um URI absoluto. Retorne `null` quando o link não puder ser resolvido ou não for permitido.
- [GetEntity](https://reference.aspose.com/slides/pt/net/aspose.slides.import/iexternalresourceresolver/getentity/) devolve um fluxo legível para um URI de recurso absoluto. Retorne `null` quando o recurso estiver faltando, bloqueado ou indisponível. Um fluxo de fallback também pode ser devolvido quando apropriado.

O resolvedor a seguir carrega recursos vinculados apenas de um diretório local permitido. Recursos de rede e caminhos fora do diretório permitido são bloqueados. Uma imagem de fallback opcional é devolvida para links de imagem não resolvidos.

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

Suponha que `assets/diagram.svg` contenha uma referência relativa como:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

O exemplo em C# a seguir passa o URI do arquivo SVG como URI base e fornece um resolvedor personalizado. O resolvedor converte o link de imagem relativo em um URI absoluto e devolve um fluxo contendo o recurso vinculado enquanto o Aspose.Slides processa o SVG.

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

A classe `SvgImage` também fornece sobrecargas que aceitam dados SVG como array de bytes ou fluxo, juntamente com um resolvedor de recursos externos e um URI base.

{{% alert title="Importante" color="warning" %}}

O resolvedor de recursos disponibiliza recursos externos enquanto o Aspose.Slides processa e renderiza o SVG. Ele não modifica a marcação SVG original nem incorpora automaticamente os recursos resolvidos nela.

Quando um `ISvgImage` é adicionado à coleção de imagens da apresentação, o arquivo PPTX pode conter tanto a representação SVG original quanto uma imagem raster de fallback. Um recurso vinculado pode aparecer na imagem de fallback gerada, enquanto um link relativo como `images/photo.png` permanece inalterado no SVG armazenado. Uma aplicação que renderiza a representação SVG nativa pode, portanto, omitir o conteúdo vinculado quando o recurso externo original não estiver disponível.

{{% /alert %}}

### **Criar uma Imagem SVG Portátil**

Para criar uma imagem SVG que não dependa de arquivos externos, torne o SVG autocontido antes de criar o `SvgImage`. Por exemplo, substitua URLs de imagens vinculadas por URIs `data:` que contenham os dados da imagem:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Depois que todos os recursos necessários estiverem incorporados ao conteúdo SVG, crie o `SvgImage`, adicione‑o à coleção de imagens da apresentação e insira‑o em uma moldura de foto conforme demonstrado no exemplo anterior.

### **Tratar Recursos Ausentes ou Bloqueados**

Retorne `null` de `ResolveUri` quando um URI de recurso for inválido, proibido ou não puder ser resolvido. Retorne `null` de `GetEntity` quando o recurso não puder ser lido. O Aspose.Slides continua processando o SVG sem esse recurso sempre que possível.

Um fluxo de fallback pode ser devolvido para um recurso ausente, mas seu conteúdo deve ser compatível com o tipo de recurso solicitado. Por exemplo, devolva um fluxo de imagem apenas para uma imagem ausente, não para uma fonte ou folha de estilo.

{{% alert title="Segurança" color="warning" %}}

Não resolva caminhos de arquivo arbitrários ou URLs de rede irrestritos a partir de arquivos SVG não confiáveis. Restrinja esquemas, diretórios e hosts permitidos. Para recursos de rede, aplique também limites de tempo de conexão, limites de tamanho de resposta e validação de conteúdo.

{{% /alert %}}

## **Converter SVG em um Conjunto de Formas**
O Aspose.Slides pode converter um SVG em um conjunto de formas, semelhante à funcionalidade correspondente no PowerPoint:


![PowerPoint Popup Menu](img_01_01.png)

Essa funcionalidade é fornecida por uma sobrecarga do método [AddGroupShape](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/addgroupshape/methods/1) da interface [IShapeCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection) que aceita um objeto [ISvgImage](https://reference.aspose.com/slides/pt/net/aspose.slides/isvgimage) como seu primeiro argumento.

O código de exemplo em C# a seguir mostra como usar esse método para converter um arquivo SVG em um conjunto de formas:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Nome do arquivo SVG de origem
string svgFileName = "sample.svg";

// Nome do arquivo de apresentação de saída
string outPptxPath = "presentation.pptx";

// Criar uma nova apresentação
using (IPresentation presentation = new Presentation())
{
    // Ler o conteúdo do arquivo SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Criar um objeto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obter o tamanho do slide
    SizeF slideSize = presentation.SlideSize.Size;

    // Converter a imagem SVG em um grupo de formas e dimensioná‑la ao tamanho do slide
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Salvar a apresentação no formato PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Adicionar Imagens como EMF aos Slides**
O Aspose.Slides for .NET permite gerar imagens EMF a partir de planilhas do Excel com o Aspose.Cells e adicioná‑las aos slides da apresentação.

O código de exemplo em C# a seguir demonstra como fazer isso:

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

    // Salvar a pasta de trabalho em um stream
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

O Aspose.Slides permite substituir imagens armazenadas na coleção de imagens de uma apresentação, incluindo imagens usadas por formas de slide. Esta seção descreve várias maneiras de atualizar imagens na coleção. Você pode substituir uma imagem usando dados brutos de bytes, uma instância de [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) ou outra imagem que já exista na coleção.

Siga os passos abaixo:

1. Carregue o arquivo de apresentação que contém imagens usando a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Carregue uma nova imagem de um arquivo em um array de bytes.
1. Substitua a imagem alvo pela nova imagem usando o array de bytes.
1. Na segunda abordagem, carregue a imagem em um objeto [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) e substitua a imagem alvo por esse objeto.
1. Na terceira abordagem, substitua a imagem alvo por uma imagem que já exista na coleção de imagens da apresentação.
1. Grave a apresentação modificada como um arquivo PPTX.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie a classe Presentation que representa um arquivo de apresentação.
using Presentation presentation = new Presentation("sample.pptx");

// A primeira forma.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// A segunda forma.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// A terceira forma.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Salve a apresentação em um arquivo.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Informação" color="info" %}}

Com o conversor gratuito de [Texto para GIF](https://products.aspose.app/slides/pt/text-to-gif) da Aspose, você pode animar texto facilmente e criar GIFs a partir de texto. 

{{% /alert %}}

## **Perguntas Frequentes**

**A resolução original da imagem permanece intacta após a inserção?**

Sim. Os pixels originais são preservados, mas a aparência final depende de como o [picture](/slides/pt/net/picture-frame/) é dimensionado no slide e de qualquer compressão aplicada ao salvar.

**Qual a melhor maneira de substituir o mesmo logotipo em dezenas de slides de uma só vez?**

Coloque o logotipo no slide mestre ou em um layout e substitua‑o na coleção de imagens da apresentação—as alterações se propagarão a todos os elementos que usam esse recurso.

**Um SVG inserido pode ser convertido em formas editáveis?**

Sim. Você pode converter um SVG em um grupo de formas, após o que as partes individuais ficam editáveis com as propriedades padrão de forma.

**Como definir uma foto como plano de fundo de vários slides ao mesmo tempo?**

[Atribua a imagem como plano de fundo](/slides/pt/net/presentation-background/) no slide mestre ou no layout relevante—todos os slides que utilizam esse mestre/layout herdarão o plano de fundo.

**Como impedir que uma apresentação se torne muito grande por causa de muitas fotos?**

Reutilize um único recurso de imagem em vez de duplicados, escolha resoluções razoáveis, aplique compressão ao salvar e mantenha gráficos repetidos no mestre quando apropriado.