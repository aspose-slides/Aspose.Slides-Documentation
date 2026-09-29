---
title: "Formatos de Arquivo Suportados"
type: docs
weight: 106
url: /pt/java/supported-file-formats/
keywords:
- "formatos de arquivo suportados"
- "carregar apresentação"
- "importar PDF"
- "importar HTML"
- "salvar apresentação"
- "renderizar slides"
- "PowerPoint"
- "OpenDocument"
- "PPT"
- "PPTX"
- "ODP"
- "PDF"
- "HTML"
- "XPS"
- "SVG"
- "XAML"
- "Java"
- "Aspose.Slides"
description: "Veja quais formatos de arquivo o Aspose.Slides for Java pode carregar, importar, salvar e renderizar, e qual API lê ou grava cada um."
---
## **Visão geral**

Aspose.Slides for Java abre e salva apresentações PowerPoint e OpenDocument. Ele também importa conteúdo PDF e HTML para slides, salva apresentações em formatos de documento, web e imagem, e renderiza slides e formas individuais como imagens. Este artigo lista cada formato suportado e indica a API que o lê ou grava.

Para uma visão geral dos recursos de edição, veja [Visão geral de recursos](/slides/pt/java/features-overview/).

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
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Observação" %}}

Apresentações salvas pelo PowerPoint 95 e versões anteriores não podem ser abertas. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) reconhece um arquivo PowerPoint 95 e relata `LoadFormat.Ppt95`, mas o construtor [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) lança [PptUnsupportedFormatException](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pptunsupportedformatexception/) para ele.

{{% /alert %}}

## **Formatos de arquivo suportados**

A tabela usa quatro operações:

- **Carregar**: o construtor [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) abre o arquivo como uma apresentação editável.
- **Importar**: um método [SlideCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slidecollection/) cria slides a partir do conteúdo do arquivo e os adiciona a uma apresentação existente. O construtor Presentation não converte esses arquivos em slides.
- **Salvar**: [Presentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-java.lang.String-int-) grava a apresentação em um arquivo ou stream. Todo formato, exceto XAML, é selecionado com um valor [SaveFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/saveformat/).
- **Renderizar**: um método de renderização desenha um slide ou uma forma como imagem. Formatos que são apenas renderizados não são valores de SaveFormat.

|**Formato**|**Descrição**|**Carregar / Importar**|**Salvar / Renderizar**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Apresentação PowerPoint 97‑2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Modelo PowerPoint 97‑2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Apresentação de Slides PowerPoint 97‑2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Apresentação PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modelo PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Apresentação de Slides PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Apresentação PowerPoint com macros habilitadas|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modelo PowerPoint com macros habilitadas|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Apresentação de Slides PowerPoint com macros habilitadas|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Apresentação OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Apresentação OpenDocument XML Flat|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modelo de Apresentação OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Apresentação PowerPoint XML|Load|Save|`SaveFormat.Xml`; arquivos carregados relatam `SourceFormat.Xml` (não há valor `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Formato de Documento Portável|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Linguagem de Marcação de Hipertexto|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Especificação de Papel XML|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato de Arquivo de Imagem Etiquetada|—|Save, Render|`SaveFormat.Tiff` (uma página por slide); `ImageFormat.Tiff` (um slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Formato de Intercâmbio de Gráficos|—|Save, Render|`SaveFormat.Gif` (animado, todos slides); `ImageFormat.Gif` (um slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Formato Web Pequeno (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Linguagem de Marcação de Aplicação Extensível|—|Save|`Presentation.save(IXamlOptions)`, um arquivo XAML por slide; não é um valor `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Gráficos de Rede Portáteis|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Imagem JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Imagem Bitmap|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Metarquivo Aprimorado|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Gráficos Vetoriais Escaláveis|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Carregar e Importar**

- **Carregar:** Passe um caminho de arquivo ou um stream para o construtor [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). O formato é detectado a partir do conteúdo; [LoadOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/) fornece configurações como senha. Para verificar um arquivo antes de abri‑lo, chame [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), que relata um valor [LoadFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadformat/). Ele relata `LoadFormat.Unknown` para PowerPoint XML, mas o construtor abre esse tipo de arquivo, e [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSourceFormat--) então retorna `SourceFormat.Xml`. Consulte [Open Presentations](/slides/pt/java/open-presentation/) e [Determine the Original Presentation Format](/slides/pt/java/detect-presentation-source-format/).
- **Importar:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) adiciona um slide por página PDF ao final de uma apresentação. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) adiciona slides criados a partir de HTML, e [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) os insere em uma posição especificada. O construtor Presentation não importa: ele lança [PptUnsupportedFormatException](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pptunsupportedformatexception/) para um arquivo PDF e não converte marcação HTML em conteúdo de slides. Consulte [Import Presentations from PDF or HTML](/slides/pt/java/import-presentation/).

## **Salvar e Renderizar**

- **Salvar:** [Presentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-java.lang.String-int-) grava a apresentação no formato indicado por um valor [SaveFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/saveformat/). Sobrecargas que também aceitam um objeto de opções controlam a saída, por exemplo [PdfOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/pt/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tiffoptions/) e [GifOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/gifoptions/). Sobrecargas que recebem um array de posições de slides, começando em 1, gravam apenas esses slides; elas aceitam PDF, XPS, TIFF, HTML, HTML5, SWF, GIF e Markdown, mas não os formatos de apresentação nem PowerPoint XML. XAML tem sua própria sobrecarga, [Presentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), que aceita [IXamlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloptions/). Consulte [Save Presentations](/slides/pt/java/save-presentation/), [Convert Presentations](/slides/pt/java/convert-presentation/) e [Export Presentations to XAML](/slides/pt/java/export-to-xaml/).
- **Renderizar:** [Slide.getImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slide/#getImage-float-float-) e [Shape.getImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getImage--) retornam um [IImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iimage/), e [IImage.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iimage/#save-java.lang.String-int-) o grava como PNG, JPEG, BMP, GIF ou TIFF, selecionado por um valor [ImageFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imageformat/). [Presentation.getImages](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) renderiza todos os slides ou slides selecionados de uma vez. [Slide.writeAsSvg](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) e [Shape.writeAsSvg](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) gravam SVG, e [Slide.writeAsEmf](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) grava EMF. Consulte [Convert Presentation Slides to Images](/slides/pt/java/convert-slide/) e [Render Presentation Slides as SVG Images](/slides/pt/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Aviso" %}}

ImageFormat também contém valores `Emf`, `Wmf`, `Icon`, `Exif` e `MemoryBmp`, mas IImage.save não produz esses formatos: o arquivo gravado contém dados PNG. Para obter uma imagem EMF de um slide, use Slide.writeAsEmf.

{{% /alert %}}

## **Perguntas frequentes**

**Posso converter uma apresentação PPT para PPTX ou ODP?**

Sim. Abra o arquivo PPT com o construtor Presentation e salve‑o com `SaveFormat.Pptx` ou `SaveFormat.Odp`. Veja [Convert PPT to PPTX](/slides/pt/java/convert-ppt-to-pptx/).

**Posso abrir um arquivo PDF ou HTML como uma apresentação?**

Não. O construtor Presentation lança PptUnsupportedFormatException para um arquivo PDF e não converte marcação HTML em slides. Crie ou abra uma apresentação, importe as páginas PDF ou o conteúdo HTML nela usando os métodos da coleção de slides descritos acima, e então salve‑a em qualquer formato suportado.

**Posso carregar uma imagem PNG ou SVG exportada como uma apresentação editável?**

Não. A saída de imagem registra apenas a aparência visual do slide, não seu texto, formas ou gráficos. Mantenha a apresentação original se precisar editá‑la posteriormente.

**Posso salvar documentos PDF/A ou PDF/UA?**

Sim. Passe um valor [PdfCompliance](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pdfcompliance/) para [PdfOptions.setCompliance](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b ou PDF/UA.

**Posso verificar se um arquivo está protegido por senha antes de abri‑lo?**

Sim. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) inspeciona um arquivo sem criar um objeto Presentation, e [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) indica se uma senha é necessária. Consulte [Password-Protect Presentations](/slides/pt/java/password-protected-presentation/).