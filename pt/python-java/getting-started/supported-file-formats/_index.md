---
title: Formatos de Arquivo Suportados
type: docs
weight: 30
url: /pt/python-java/supported-file-formats/
keywords:
- formatos de arquivo suportados
- formatos de apresentação
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- imagens de slides
- Python
- Aspose.Slides for Python via Java
description: "Explore os formatos de apresentação, documento, web e imagem que o Aspose.Slides for Python via Java pode carregar, importar, salvar e exportar."
---
## **Visão geral**

Aspose.Slides for Python via Java lê e grava apresentações PowerPoint e OpenDocument. Também importa conteúdo PDF e HTML para slides e exporta apresentações ou slides individuais para formatos de documento, web e imagem.

A tabela abaixo diferencia o carregamento de apresentações da importação de conteúdo e da renderização de slides. Para uma visão geral dos recursos de edição e renderização, veja [Features Overview](/slides/pt/python-java/features-overview/).

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


## **Formatos de arquivo suportados**

A tabela a seguir lista os formatos de entrada e saída suportados. **Carregar / Importar** inclui a abertura de arquivos de apresentação e a importação de conteúdo PDF ou HTML. **Salvar / Exportar** inclui a gravação de apresentações e a renderização de slides em imagens. Um travessão indica que a operação correspondente não é suportada como operação de conversão de apresentação.

|**Formato**|**Descrição**|**Carregar / Importar**|**Salvar / Exportar**|**Observações**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Apresentação PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|Modelo PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|Apresentação de Slides PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Apresentação PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modelo PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Apresentação de Slides PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Apresentação PowerPoint com macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Apresentação de Slides PowerPoint com macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modelo PowerPoint com macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP](https://docs.fileformat.com/presentation/odp/)|Apresentação OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Formato OpenDocument empacotado.|
|FODP|Apresentação OpenDocument XML plana|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Armazena a apresentação como um único documento XML.|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modelo de apresentação OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato de arquivo de imagem etiquetado|—|{{< emoticons/tick >}}|Suporta saída multipáginas.|
|[EMF](https://docs.fileformat.com/image/emf/)|Metarquivo avançado|—|{{< emoticons/tick >}}|Exporta slides individuais como imagens vetoriais.|
|[PDF](https://docs.fileformat.com/pdf/)|Formato de Documento Portátil|Importar|{{< emoticons/tick >}}|Importa páginas PDF como slides; exporta apresentações para PDF.|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Especificação de Papel XML|—|{{< emoticons/tick >}}|Saída de documento com layout fixo.|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Imagem JPEG|—|{{< emoticons/tick >}}|Renderiza slides individuais como imagens rasterizadas.|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|{{< emoticons/tick >}}|Renderiza slides individuais como imagens rasterizadas.|
|[GIF](https://docs.fileformat.com/image/gif/)|Formato de Intercâmbio de Gráficos|—|{{< emoticons/tick >}}|Saída de imagem.|
|[BMP](https://docs.fileformat.com/image/bmp/)|Imagem Bitmap|—|{{< emoticons/tick >}}|Renderiza slides individuais como imagens rasterizadas.|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Gráficos Vetoriais Escaláveis|—|{{< emoticons/tick >}}|Exporta slides individuais como imagens vetoriais.|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Formato Web Pequeno|—|{{< emoticons/tick >}}|Saída Flash.|
|[HTML](https://docs.fileformat.com/web/html/)|Linguagem de Marcação de Hipertexto|Importar|{{< emoticons/tick >}}|Importa conteúdo HTML como slides; suporta exportação para HTML e HTML5.|
|[XAML](https://docs.fileformat.com/web/xaml/)|Linguagem de Marcação de Aplicação Extensível|—|{{< emoticons/tick >}}|Exporta o conteúdo da apresentação como XAML.|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|{{< emoticons/tick >}}|Exporta o conteúdo da apresentação para Markdown.|
|[XML](https://docs.fileformat.com/web/xml/)|Apresentação XML do PowerPoint|—|{{< emoticons/tick >}}|Saída XML específica do PowerPoint, não XML arbitrário.|

## **Observações de importação e exportação**

- **Importação de PDF e HTML:** Use [SlideCollection.addFromPdf](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addfrompdf) ou [SlideCollection.addFromHtml](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addfromhtml) para criar slides a partir do conteúdo fonte e adicioná‑los a uma apresentação.
- **Saída de apresentação:** [SaveFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/) lista os formatos de salvamento de apresentação disponíveis, incluindo opções de exportação separadas para HTML e HTML5.
- **Saída de imagem:** Exportar um slide para uma imagem produz uma representação visual desse slide. A coluna de entrada não descreve se uma imagem pode ser inserida em uma apresentação.

## **FAQ**

**Posso converter uma apresentação PPT para PPTX ou ODP?**

Sim. PPT é suportado como formato de entrada, e tanto PPTX quanto ODP são suportados como formatos de saída. Os resultados da conversão dependem dos recursos disponíveis no formato de destino.

**A importação de PDF ou HTML abre a fonte como um arquivo PowerPoint?**

Não. A importação cria slides a partir de páginas PDF ou conteúdo HTML. Você pode então salvar a apresentação resultante em um formato de apresentação suportado.

**Posso carregar um PNG ou SVG exportado como uma apresentação editável?**

Não. Essas exportações representam a aparência dos slides. Mantenha a apresentação original quando precisar editar seu texto, formas, gráficos e outros objetos posteriormente.