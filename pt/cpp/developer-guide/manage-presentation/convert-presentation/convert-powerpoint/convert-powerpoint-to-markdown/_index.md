---
title: Converter apresentações PowerPoint para Markdown em C++
linktitle: PowerPoint para Markdown
type: docs
weight: 140
url: /pt/cpp/convert-powerpoint-to-markdown/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para MD
- apresentação para MD
- slide para MD
- PPT para MD
- PPTX para MD
- salvar PowerPoint como Markdown
- salvar apresentação como Markdown
- salvar slide como Markdown
- salvar PPT como MD
- salvar PPTX como MD
- exportar PPT para MD
- exportar PPTX para MD
- exportação de imagens Markdown
- links de imagem CDN
- PowerPoint
- apresentação
- Markdown
- C++
- Aspose.Slides
description: "Converter apresentações PPT e PPTX para Markdown em C++ e controlar onde as imagens exportadas bitmap, metafile e SVG são salvas e referenciadas."
---
## **Visão geral**

Aspose.Slides for C++ pode converter apresentações PPT e PPTX para Markdown para documentação, sites estáticos, migração de conteúdo e fluxos de trabalho de controle de versão. Você pode escolher um sabor de Markdown, controlar como o conteúdo dos slides é renderizado e decidir onde as imagens exportadas são armazenadas e como o Markdown gerado as referencia.

Por padrão, a exportação para Markdown usa saída apenas de texto. Para exportar conteúdo visual, defina o método [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) para o valor `Sequential` ou `Visual` da enumeração [MarkdownExportType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/markdownexporttype/). `Sequential` renderiza os itens dos slides separadamente e em ordem, enquanto `Visual` mantém os itens agrupados juntos para preservar sua relação visual. O valor `TextOnly` não emite recursos de imagem, portanto os eventos de salvamento de imagem não são invocados nesse modo.

## **Converter uma Apresentação para Markdown**

Carregue o arquivo fonte com a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/), e então chame o método [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) com o valor `Md` da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveformat/).

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Selecionar um Sabor de Markdown**

O método [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) controla a especificação de Markdown usada na saída. A enumeração [Flavor](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/flavor/) inclui CommonMark, GitHub Flavored Markdown e outras variantes suportadas.

O exemplo a seguir exporta uma apresentação como CommonMark:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Exportar Imagens Usando o Comportamento Padrão de Salvamento Local**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/markdownsaveoptions/) oferece dois métodos para configurar imagens salvas localmente:

- [set_BasePath](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) especifica o diretório base para o documento Markdown e seus recursos.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) especifica o subdiretório de imagens. Seu valor padrão é `Images`.

O exemplo a seguir renderiza conteúdo visual, grava imagens em `output/assets` e cria referências de imagem relativas no documento Markdown:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Esse comportamento também serve como alternativa quando um manipulador personalizado de salvamento de imagem retorna `false`.

## **Personalizar o Salvamento de Imagens e Links Markdown**

Use o evento `MarkdownSaveOptions::ImageSaving` para recursos bitmap e metafile não SVG emitidos durante a exportação para Markdown. Seu delegate [MarkdownImageSavingHandler](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) recebe o objeto [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/), seu [ImageFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imageformat/) e o link Markdown gerado como um parâmetro `System::String&`. Salve ou faça upload da imagem com o formato fornecido e substitua `link` pela referência que deve aparecer na saída Markdown.

Recursos emitidos no formato SVG são tratados separadamente. Inscreva‑se no evento `MarkdownSaveOptions::SvgImageSaving`, cujo delegate [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) recebe um objeto [ISvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/) e o parâmetro `System::String& link`. Um SVG não possui argumento `ImageFormat`; escreva ou faça upload dos seus dados XML a partir do método [ISvgImage::get_SvgData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/get_svgdata/). Dependendo do modo de exportação e do agrupamento visual, um SVG na apresentação de origem pode ser rasterizado ou combinado com outro conteúdo; o recurso não‑SVG resultante é então passado para `ImageSaving`. Inscreva‑se em ambos os eventos quando cada recurso visual exportado exigir processamento personalizado.

O valor de retorno do manipulador determina quem processa a imagem:

- Retorne `true` depois que o manipulador tiver salvo, feito upload, transformado ou processado a imagem de alguma forma e atribuído um valor válido a `link`. Aspose.Slides grava esse valor no documento Markdown e não executa o salvamento local padrão.
- Retorne `false` para permitir que Aspose.Slides salve a imagem localmente e gere seu link de acordo com [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) e [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Um manipulador que retorna `true` assume a responsabilidade pela imagem. Se ele retornar `true` sem atribuir um link válido e não vazio, a exportação falha com um `InvalidOperationException`.
{{% /alert %}}

### **Salvar Imagens em um Diretório de Origem CDN e Usar URLs Externas**

O exemplo a seguir trata `cdn-origin/presentations/quarterly-report` como um diretório de origem CDN montado ou sincronizado. Cada manipulador extrai o nome de arquivo gerado, salva a imagem nesse diretório personalizado e substitui a referência local gerada por uma URL pública de CDN. O exemplo em si não realiza upload de rede: a URL se torna válida somente depois que o diretório é montado como origem CDN ou seus arquivos são publicados no CDN. Para armazenamento de objetos, substitua a gravação no sistema de arquivos pela operação de upload do SDK de armazenamento e atribua `link` somente após o upload ser bem‑sucedido.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

O manipulador de bitmap retorna deliberadamente `false` para imagens menores que 128 × 128 pixels, portanto o Aspose.Slides salva essas imagens em `output/fallback-images` usando o comportamento padrão. Recursos de bitmap e metafile maiores, bem como recursos SVG, são tratados pelo código personalizado. Por exemplo, uma referência local gerada como `fallback-images/image1.png` torna‑se `https://cdn.example.com/presentations/quarterly-report/image1.png`. Os manipuladores usam caminhos do sistema operacional apenas ao gravar arquivos; os links escritos no Markdown usam barras normais e nomes de arquivos com escape de URL. Aplique a mesma regra ao construir links relativos: use `/`, e não o separador de diretórios específico da plataforma.

## **FAQ**

**Um manipulador pode processar tanto imagens raster quanto imagens SVG?**

Não. Use `MarkdownSaveOptions::ImageSaving` para recursos bitmap e metafile emitidos e `MarkdownSaveOptions::SvgImageSaving` para recursos emitidos como SVG. O primeiro fornece um objeto [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) e um [ImageFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imageformat/); o segundo fornece um objeto [ISvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/) cujo dados SVG podem ser lidos com [ISvgImage::get_SvgData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/get_svgdata/). Um SVG de origem que é rasterizado durante a exportação é processado por `ImageSaving`.

**O que acontece quando um manipulador de salvamento de imagem retorna `false`?**

O Aspose.Slides usa seu comportamento padrão de salvamento local. A localização da imagem e a referência gerada são controladas por [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) e [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Um manipulador pode fornecer uma URL sem salvar a imagem localmente?**

Sim. O manipulador pode fazer upload da imagem para armazenamento de objetos ou passá‑la a outro serviço, atribuir a URL resultante a `link` e retornar `true`. O manipulador deve concluir o processamento por conta própria; retornar `true` impede o salvamento local padrão.

**Por que a exportação para Markdown lança um `InvalidOperationException` a partir de um manipulador?**

Essa exceção ocorre quando o manipulador retorna `true` mas não fornece um link válido. Atribua o caminho relativo ou a URL externa que deve ser escrita no Markdown antes de retornar `true`.

**Qual separador de caminho os links de imagem devem usar?**

Use barras normais (`/`) em links Markdown e URLs. Use `Path::Combine` apenas para caminhos do sistema de arquivos, e então construa ou normalize a referência Markdown separadamente.

**Os hyperlinks são preservados durante a exportação para Markdown?**

Sim. Textos [hyperlinks](/slides/pt/cpp/manage-hyperlinks/) são preservados como links Markdown padrão. [Transições](/slides/pt/cpp/slide-transition/) e [animações](/slides/pt/cpp/powerpoint-animation/) de slides não são convertidos.

**Apresentações podem ser convertidas para Markdown em paralelo?**

Você pode processar diferentes arquivos de apresentação em paralelo, mas não compartilhe a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) entre threads. Siga as [diretrizes de multithreading](/slides/pt/cpp/multithreading/) e use uma instância separada para cada arquivo.