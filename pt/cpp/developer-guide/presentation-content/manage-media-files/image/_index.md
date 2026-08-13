---
title: Otimizar o Gerenciamento de Imagens em Apresentações Usando C++
linktitle: Gerenciar Imagens
type: docs
weight: 10
url: /pt/cpp/image/
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
- C++
- Aspose.Slides
description: "Simplifique o gerenciamento de imagens no PowerPoint e OpenDocument com Aspose.Slides para C++, otimizando o desempenho e automatizando seu fluxo de trabalho."
---
## **Introdução**

As imagens tornam as apresentações mais envolventes e visualmente atraentes. No Microsoft PowerPoint, você pode inserir fotos nos slides a partir de arquivos, da internet ou de outras fontes. Da mesma forma, Aspose.Slides permite adicionar imagens aos slides da apresentação de várias maneiras. 

{{% alert title="Dica" color="info" %}} 
A Aspose oferece conversores gratuitos—[JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem criar apresentações rapidamente a partir de imagens. 
{{% /alert %}} 

{{% alert title="Informação" color="info" %}}
Se você quiser adicionar uma imagem como moldura de foto—especialmente se planeja redimensioná‑la, aplicar efeitos ou usar outras opções padrão de formatação—consulte [Moldura de Foto](/slides/pt/cpp/picture-frame/). 
{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}
Você pode converter imagens de um formato para outro. Veja as páginas a seguir: converter [imagem para JPG](https://products.aspose.com/slides/pt/cpp/conversion/image-to-jpg/), [JPG para imagem](https://products.aspose.com/slides/pt/cpp/conversion/jpg-to-image/), [JPG para PNG](https://products.aspose.com/slides/pt/cpp/conversion/jpg-to-png/), [PNG para JPG](https://products.aspose.com/slides/pt/cpp/conversion/png-to-jpg/), [PNG para SVG](https://products.aspose.com/slides/pt/cpp/conversion/png-to-svg/), e [SVG para PNG](https://products.aspose.com/slides/pt/cpp/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides suporta imagens em formatos populares como JPEG, PNG, BMP, GIF e outros. 

## **Adicionar Imagens Armazenadas Localmente aos Slides**

Você pode adicionar uma ou mais imagens armazenadas no seu computador a um slide de apresentação. O exemplo de código C++ a seguir mostra como adicionar uma imagem a um slide:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Adicionar Imagens da Web aos Slides**

Se a imagem que você deseja adicionar a um slide não estiver armazenada no seu computador, você pode adicioná‑la diretamente da web. 

O exemplo de código C++ a seguir mostra como adicionar uma imagem da web a um slide:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Adicionar Imagens aos Mestres de Slide**

Um mestre de slide armazena e controla informações como o tema e o layout dos slides que o utilizam. Quando você adiciona uma imagem a um mestre de slide, a imagem aparece em todos os slides baseados nesse mestre. 

O exemplo de código C++ a seguir mostra como adicionar uma imagem a um mestre de slide:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Adicionar Imagens como Fundos de Slide**

Você pode usar uma foto como fundo de um ou mais slides. Para detalhes, veja *[Definindo Imagens como Fundos de Slides](/slides/pt/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Adicionar SVG a Apresentações**

O conteúdo SVG pode ser adicionado a uma apresentação usando a classe [SvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/svgimage/). O objeto resultante [ISvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/) pode então ser inserido na coleção de imagens da apresentação e usado para criar uma moldura de foto.

O exemplo de C++ a seguir importa uma string SVG autocontida. Todas as imagens, estilos e outros recursos usados por esse SVG são incorporados diretamente no conteúdo SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Importar Conteúdo SVG com Recursos Externos**

Arquivos SVG exportados de ferramentas de design, editores de diagramas, sistemas de ícones e pipelines web podem referenciar recursos armazenados fora do documento SVG. Por exemplo, um SVG pode conter um link de imagem como `images/photo.png`, um valor CSS `url(...)` ou uma URL de fonte.

Para importar esse conteúdo SVG, crie uma implementação de [IExternalResourceResolver](https://reference.aspose.com/slides/pt/cpp/aspose.slides.import/iexternalresourceresolver/) e passe‑a, juntamente com um URI base, para um construtor apropriado de `SvgImage`. O URI base identifica a localização do documento SVG e é usado para resolver links relativos.

A interface [ISvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/) fornece acesso a informações sobre o SVG importado:

- `get_SvgContent()` retorna a marcação SVG como string.
- `get_SvgData()` retorna o conteúdo SVG como um array de bytes.
- `get_BaseUri()` retorna o URI base usado para links relativos.
- `get_ExternalResourceResolver()` retorna o resolvedor atribuído à imagem SVG.

### **Implementar um Resolvedor de Recursos Externos**

O resolvedor possui dois métodos:

- [ResolveUri](https://reference.aspose.com/slides/pt/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) combina o URI base e um link de recurso relativo e retorna um URI absoluto. Retorne uma string nula quando o link não puder ser resolvido ou não for permitido.
- [GetEntity](https://reference.aspose.com/slides/pt/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) retorna um fluxo legível para um URI de recurso absoluto. Retorne `nullptr` quando o recurso estiver ausente, bloqueado ou indisponível. Um fluxo de fallback também pode ser retornado quando apropriado.

O resolvedor a seguir carrega recursos vinculados apenas de um diretório local permitido. Recursos de rede e caminhos fora do diretório permitido são bloqueados. Uma imagem de fallback opcional é retornada para links de imagem não resolvidos.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // Este resolvedor permite intencionalmente apenas arquivos locais.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Use um fallback apenas para recursos de imagem. Retornar um fluxo de imagem
        // para uma fonte ou folha de estilo ausente não seria válido.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **Resolver Recursos Vinculados Durante a Importação de SVG**

Presuma que `assets/diagram.svg` contenha uma referência relativa como:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

O exemplo de C++ a seguir passa o URI do arquivo SVG como URI base e fornece um resolvedor personalizado. O resolvedor converte o link de imagem relativo em um URI absoluto e retorna um fluxo contendo o recurso vinculado enquanto Aspose.Slides processa o SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// O URI base representa o local do documento SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A classe `SvgImage` também oferece sobrecargas que aceitam dados SVG como array de bytes ou fluxo, juntamente com um resolvedor de recursos externos e um URI base.

{{% alert title="Importante" color="warning" %}}
O resolvedor de recursos torna recursos externos disponíveis enquanto Aspose.Slides processa e renderiza o SVG. Ele não modifica a marcação SVG original nem incorpora automaticamente os recursos resolvidos nela.

Quando um `ISvgImage` é adicionado à coleção de imagens da apresentação, o arquivo PPTX pode conter tanto a representação SVG original quanto uma imagem raster de fallback. Um recurso vinculado pode aparecer na imagem de fallback gerada enquanto um link relativo como `images/photo.png` permanece inalterado no SVG armazenado. Uma aplicação que renderiza a representação SVG nativa pode, portanto, omitir o conteúdo vinculado quando o recurso externo original estiver indisponível.
{{% /alert %}}

### **Criar uma Imagem SVG Portável**

Para criar uma imagem SVG que não dependa de arquivos externos, torne o SVG autocontido antes de criar o `SvgImage`. Por exemplo, substitua URLs de imagens vinculadas por URIs `data:` que contenham os dados da imagem:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Após todos os recursos necessários serem incorporados ao conteúdo SVG, crie o `SvgImage`, adicione‑o à coleção de imagens da apresentação e insira‑o em uma moldura de foto como mostrado no exemplo anterior.

### **Manipular Recursos Ausentes ou Bloqueados**

Retorne uma string nula de `ResolveUri` quando um URI de recurso for inválido, proibido ou não puder ser resolvido. Retorne `nullptr` de `GetEntity` quando o recurso não puder ser lido. Aspose.Slides continua processando o SVG sem esse recurso quando possível.

Um fluxo de fallback pode ser retornado para um recurso ausente, mas seu conteúdo deve ser compatível com o tipo de recurso solicitado. Por exemplo, retorne um fluxo de imagem apenas para uma imagem ausente, não para uma fonte ou folha de estilo.

{{% alert title="Segurança" color="warning" %}}
Não resolva caminhos de arquivo arbitrários ou URLs de rede não restritas a partir de arquivos SVG não confiáveis. Restrinja esquemas, diretórios e hosts permitidos. Para recursos de rede, aplique também limites de tempo de conexão, tamanho de resposta e validação de conteúdo.
{{% /alert %}}

## **Converter SVG em um Conjunto de Formas**
Aspose.Slides pode converter um SVG em um conjunto de formas, similar à funcionalidade correspondente no PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Essa funcionalidade é fornecida por uma sobrecarga do método [AddGroupShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/) da interface [IShapeCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/) que recebe um objeto [ISvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/) como primeiro argumento.

O exemplo de código C++ a seguir mostra como usar esse método para converter um arquivo SVG em um conjunto de formas:

``` cpp
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Nome do arquivo SVG de origem
auto svgFileName = System::String(u"sample.svg");

// Nome do arquivo de apresentação de saída
auto outPptxPath = System::String(u"presentation.pptx");

// Criar uma nova apresentação
auto presentation = System::MakeObject<Presentation>();

// Ler o conteúdo do arquivo SVG
auto svgContent = File::ReadAllText(svgFileName);

// Criar um objeto SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Obter o tamanho do slide
auto slideSize = presentation->get_SlideSize()->get_Size();

// Converter a imagem SVG em um grupo de formas e dimensioná‑la ao tamanho do slide
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Salvar a apresentação no formato PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Adicionar Imagens como EMF aos Slides**
Aspose.Slides for C++ permite gerar imagens EMF a partir de planilhas do Excel com Aspose.Cells e adicioná‑las aos slides da apresentação. 

O exemplo de código C++ a seguir demonstra como fazer isso:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells para C++ deve ser iniciado antes que qualquer de seus tipos seja usado.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Renderizar a planilha como EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells devolve a página renderizada como um buffer, que o Aspose.Slides adiciona como uma imagem.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Substituir Imagens na Coleção de Imagens**

Aspose.Slides permite substituir imagens armazenadas na coleção de imagens de uma apresentação, incluindo imagens usadas por formas de slide. Esta seção descreve várias maneiras de atualizar imagens na coleção. Você pode substituir uma imagem usando dados brutos de bytes, uma instância de [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) ou outra imagem que já exista na coleção.

Siga os passos abaixo:

1. Carregue o arquivo de apresentação que contém imagens usando a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Carregue uma nova imagem a partir de um arquivo em um array de bytes.
1. Substitua a imagem de destino pela nova imagem usando o array de bytes.
1. Na segunda abordagem, carregue a imagem em um objeto [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) e substitua a imagem de destino por esse objeto.
1. Na terceira abordagem, substitua a imagem de destino por uma imagem que já exista na coleção de imagens da apresentação.
1. Grave a apresentação modificada como um arquivo PPTX.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// A primeira forma.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// A segunda forma.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// A terceira forma.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Salvar a apresentação em um arquivo.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Com o conversor gratuito de [Texto para GIF](https://products.aspose.app/slides/pt/text-to-gif) da Aspose, você pode animar texto facilmente e criar GIFs a partir de texto. 
{{% /alert %}}

## **FAQ**

**A resolução da imagem original permanece intacta após a inserção?**

Sim. Os pixels de origem são preservados, mas a aparência final depende de como o [picture](/slides/pt/cpp/picture-frame/) é dimensionado no slide e de qualquer compressão aplicada ao salvar.

**Qual a melhor maneira de substituir o mesmo logotipo em dezenas de slides de uma só vez?**

Coloque o logotipo no mestre de slide ou em um layout e substitua‑o na coleção de imagens da apresentação—as atualizações se propagarão a todos os elementos que utilizam esse recurso.

**Um SVG inserido pode ser convertido em formas editáveis?**

Sim. Você pode converter um SVG em um grupo de formas, após o que as partes individuais tornam‑se editáveis com as propriedades padrão de formas.

**Como definir uma foto como fundo de vários slides ao mesmo tempo?**

[Atribua a imagem como fundo](/slides/pt/cpp/presentation-background/) no mestre de slide ou no layout relevante—qualquer slide que use esse mestre/layout herdará o fundo.

**Como impedir que uma apresentação fique muito grande por causa de muitas imagens?**

Reutilize um único recurso de imagem em vez de duplicatas, escolha resoluções razoáveis, aplique compressão ao salvar e mantenha gráficos repetidos no mestre quando apropriado.