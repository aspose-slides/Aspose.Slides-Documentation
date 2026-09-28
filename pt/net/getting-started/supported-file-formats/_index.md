---
title: Formatos de Arquivo Suportados
type: docs
weight: 96
url: /pt/net/supported-file-formats/
keywords:
- formatos de arquivo suportados
- carregar apresentação
- importar PDF
- importar HTML
- salvar apresentação
- renderizar slides
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- .NET
- C#
- Aspose.Slides
description: "Veja quais formatos de arquivo o Aspose.Slides for .NET pode carregar, importar, salvar e renderizar, e qual API lê ou grava cada um."
---
## **Visão geral**

Aspose.Slides for .NET abre e salva apresentações PowerPoint e OpenDocument. Também importa conteúdo PDF e HTML para slides, salva apresentações em formatos de documento, web e imagem, e renderiza slides e formas individuais como imagens. Este artigo lista cada formato suportado e indica a API que o lê ou grava.

Ambos os pacotes NuGet, Aspose.Slides.NET e Aspose.Slides.NET6.CrossPlatform, suportam os mesmos formatos; veja [Instalação](/slides/pt/net/installation/) para escolher entre eles. Para uma visão geral dos recursos de edição, veja [Visão geral de recursos](/slides/pt/net/features-overview/).

## **Versões do Microsoft PowerPoint suportadas**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint para Microsoft 365 (antigo Office 365)

{{% alert color="info" title="Nota" %}}

Apresentações salvas pelo PowerPoint 95 e versões anteriores não podem ser abertas. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/getpresentationinfo/) reconhece um arquivo PowerPoint 95 e relata `LoadFormat.Ppt95`, mas o construtor [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/presentation/) lança [PptUnsupportedFormatException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptunsupportedformatexception/) para ele.

{{% /alert %}}

## **Formatos de arquivo suportados**

A tabela usa quatro operações:

- **Load**: o construtor [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/presentation/) abre o arquivo como uma apresentação editável.
- **Import**: um método da [SlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/slidecollection/) cria slides a partir do conteúdo do arquivo e os adiciona a uma apresentação existente. O construtor Presentation não carrega esses arquivos como apresentações.
- **Save**: [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) grava a apresentação em um arquivo ou fluxo. Todo formato, exceto XAML, é selecionado com um valor de [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/).
- **Render**: um método de renderização desenha um slide ou uma forma como imagem. Formatos que são apenas renderizados não são valores de SaveFormat.

|**Formato**|**Descrição**|**Load / Import**|**Save / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Apresentação PowerPoint 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Modelo PowerPoint 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Apresentação de Slides PowerPoint 97-2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Apresentação PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modelo PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Apresentação de Slides PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Apresentação PowerPoint com macros|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modelo PowerPoint com macros|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Apresentação de Slides PowerPoint com macros|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Apresentação OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Apresentação OpenDocument XML plano|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modelo de apresentação OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Apresentação PowerPoint XML|Load|Save|`SaveFormat.Xml`; arquivos carregados relatam `SourceFormat.Xml` (não há valor `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Formato de Documento Portátil|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Linguagem de Marcação de Hipertexto|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Especificação de Papel XML|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato de Arquivo de Imagem Etiquetada|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (um slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Formato de Intercâmbio de Gráficos|—|Save, Render|`SaveFormat.Gif` (animado, todos os slides); `ImageFormat.Gif` (um slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Formato Web Pequeno (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Linguagem de Marcação de Aplicação Extensível|—|Save|`Presentation.Save(IXamlOptions)`, um arquivo XAML por slide; não é um valor `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Imagem JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Imagem Bitmap|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Gráficos Vetoriais Escaláveis|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Carregar e Importar**

- **Load:** Passe um caminho de arquivo ou um fluxo para o construtor [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/presentation/). O formato é detectado a partir do conteúdo; [LoadOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/) fornece configurações como senha. Para verificar um arquivo antes de abri‑lo, chame [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/getpresentationinfo/), que relata um valor de [LoadFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/loadformat/). Ele relata `LoadFormat.Unknown` para PowerPoint XML, mas o construtor abre esse arquivo, e [Presentation.SourceFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sourceformat/) então retorna `SourceFormat.Xml`. Consulte [Abrir apresentações](/slides/pt/net/open-presentation/) e [Determinar o formato original da apresentação](/slides/pt/net/detect-presentation-source-format/).
- **Import:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/pt/net/aspose.slides/slidecollection/addfrompdf/) adiciona um slide por página PDF ao final de uma apresentação. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/pt/net/aspose.slides/slidecollection/addfromhtml/) adiciona slides criados a partir de HTML, e [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/pt/net/aspose.slides/slidecollection/insertfromhtml/) os insere em uma posição específica. O construtor Presentation não importa: ele lança [PptUnsupportedFormatException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptunsupportedformatexception/) para um arquivo PDF e não converte marcação HTML em conteúdo de slide. Consulte [Importar apresentações de PDF ou HTML](/slides/pt/net/import-presentation/).

## **Salvar e Renderizar**

- **Save:** [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) grava a apresentação no formato de um valor de [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/). Sobrecargas que também recebem um objeto de opções controlam a saída, por exemplo [PdfOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/tiffoptions/) e [GifOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/gifoptions/). Sobrecargas que recebem um array de posições de slide, começando em 1, gravam apenas esses slides; elas aceitam PDF, XPS, TIFF, HTML, HTML5, SWF, GIF e Markdown, mas não os formatos de apresentação ou PowerPoint XML. XAML tem sua própria sobrecarga que recebe [IXamlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/ixamloptions/). Consulte [Salvar apresentações](/slides/pt/net/save-presentation/), [Converter apresentações](/slides/pt/net/convert-presentation/) e [Exportar apresentações para XAML](/slides/pt/net/export-to-xaml/).
- **Render:** [Slide.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/getimage/) e [Shape.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/getimage/) retornam um [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/), e [IImage.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/save/) o grava como PNG, JPEG, BMP, GIF ou TIFF, selecionado com um valor de [ImageFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/imageformat/). [Presentation.GetImages](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/getimages/) renderiza todos os slides ou slides selecionados de uma vez. [Slide.WriteAsSvg](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/writeassvg/) e [Shape.WriteAsSvg](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/writeassvg/) gravam SVG, e [Slide.WriteAsEmf](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/writeasemf/) grava EMF. Consulte [Converter slides de apresentação em imagens](/slides/pt/net/convert-slide/) e [Renderizar um slide como imagem SVG](/slides/pt/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Aviso" %}}

ImageFormat também possui valores `Emf`, `Wmf`, `Icon`, `Exif` e `MemoryBmp`, mas IImage.Save não produz esses formatos: o arquivo gravado contém dados PNG. Para obter uma imagem EMF de um slide, use Slide.WriteAsEmf.

{{% /alert %}}

## **FAQ**

**Posso converter uma apresentação PPT para PPTX ou ODP?**

Sim. Abra o arquivo PPT com o construtor Presentation e salve‑o com `SaveFormat.Pptx` ou `SaveFormat.Odp`. Consulte [Converter PPT para PPTX](/slides/pt/net/convert-ppt-to-pptx/).

**Posso abrir um arquivo PDF ou HTML como apresentação?**

Não. Crie ou abra uma apresentação, importe as páginas PDF ou o conteúdo HTML nela com os métodos da coleção de slides descritos acima e, então, salve‑a em qualquer formato suportado.

**Posso carregar uma imagem PNG ou SVG exportada como apresentação editável?**

Não. A saída de imagem registra como o slide aparece, não seu texto, formas ou gráficos. Mantenha a apresentação fonte se precisar editá‑la posteriormente.

**Posso salvar documentos PDF/A ou PDF/UA?**

Sim. Defina [PdfOptions.Compliance](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/compliance/) para um valor de [PdfCompliance](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfcompliance/): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b ou PDF/UA.

**Posso verificar se um arquivo está protegido por senha antes de abri‑lo?**

Sim. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/getpresentationinfo/) inspeciona um arquivo sem criar um objeto Presentation, e sua propriedade [IsPasswordProtected](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/ispasswordprotected/) indica se é necessária senha. Consulte [Apresentações protegidas por senha](/slides/pt/net/password-protected-presentation/).

**Os dois pacotes NuGet suportam formatos diferentes?**

Não. Aspose.Slides.NET e Aspose.Slides.NET6.CrossPlatform têm os mesmos valores de LoadFormat e SaveFormat e os mesmos métodos de importação e renderização. Eles diferem nas plataformas em que são executados e nas necessidades dessas plataformas; veja [Instalação](/slides/pt/net/installation/).