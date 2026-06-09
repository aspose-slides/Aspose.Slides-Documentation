---
title: Converter apresentações para vários formatos em .NET
linktitle: Converter apresentação
type: docs
weight: 70
url: /pt/net/convert-presentation/
keywords:
- converter apresentação
- exportar apresentação
- PPT para PPTX
- PPTX para PPT
- ODP para PPTX
- PPT para PDF
- PPTX para PDF
- ODP para PDF
- PPT para HTML
- PPTX para HTML
- ODP para HTML
- PPT para PNG
- PPTX para PNG
- ODP para PNG
- PPTX para JPG
- ODP para JPG
- PPT para XPS
- PPTX para XPS
- ODP para XPS
- PPT para TIFF
- PPTX para TIFF
- ODP para TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Converter apresentações PowerPoint e OpenDocument para PPTX, PDF, HTML, imagens, XPS, TIFF e mais com Aspose.Slides para .NET."
---
## **Visão geral**

Aspose.Slides for .NET pode carregar apresentações PowerPoint e OpenDocument e salvá‑las ou renderizá‑las para muitos outros formatos sem Microsoft PowerPoint, OpenOffice ou LibreOffice. Você pode converter arquivos PPT legados para PPTX modernos, exportar apresentações para documentos de layout fixo como PDF e XPS, publicar slides como HTML ou renderizar slides como arquivos de imagem para visualizações, miniaturas e arquivamento.

Na maioria das conversões de documentos, utiliza‑se o mesmo fluxo de trabalho geral: carregar o arquivo de origem, escolher o formato de saída necessário e aplicar as opções específicas do formato quando necessário. Para formatos de imagem, cada slide é renderizado separadamente e então salvo como imagem raster ou vetorial. Os artigos dedicados vinculados abaixo fornecem os detalhes de implementação para cada caso.

## **Escolha um cenário de conversão**

Use os artigos abaixo para exemplos completos em C# e opções específicas de formato.

| Cenário | Use quando precisar | Artigo |
| --- | --- | --- |
| PPT/PPTX/ODP para PPTX | Modernizar arquivos PPT legados, normalizar arquivos PPTX existentes ou converter apresentações OpenDocument para PowerPoint PPTX. | [Converter PPT para PPTX](/slides/pt/net/convert-ppt-to-pptx/), [Converter ODP para PPTX](/slides/pt/net/convert-odp-to-pptx/), [Salvar apresentações](/slides/pt/net/save-presentation/) |
| PPTX para PPT | Salvar uma apresentação PowerPoint moderna no formato binário PPT mais antigo para compatibilidade com fluxos de trabalho mais antigos. | [Converter PPTX para PPT](/slides/pt/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP para PDF | Criar documentos portáteis, pesquisáveis e de layout fixo para compartilhamento, impressão ou arquivamento. | [Converter PowerPoint para PDF](/slides/pt/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP para PDF com notas | Exportar notas do apresentador junto com o conteúdo dos slides. | [Converter PowerPoint para PDF com notas](/slides/pt/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP para HTML | Publicar apresentações como páginas HTML e controlar imagens, fontes, notas e opções de layout responsivo. | [Converter PowerPoint para HTML](/slides/pt/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP para HTML5 | Exportar slides para HTML5 para visualização baseada em navegador com formatação e interatividade preservadas. | [Converter apresentações para HTML5](/slides/pt/net/export-to-html5/) |
| PPT/PPTX/ODP para PNG | Renderizar cada slide em uma imagem PNG para pré‑visualizações, miniaturas ou saída web. | [Converter PowerPoint para PNG](/slides/pt/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP para JPG | Renderizar slides em imagens JPG e controlar dimensões e qualidade da imagem. | [Converter PowerPoint para JPG](/slides/pt/net/convert-powerpoint-to-jpg/) |
| Slide para SVG | Exportar slides individuais como gráficos vetoriais escaláveis. | [Renderizar slide como SVG](/slides/pt/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP para XPS | Gerar documentos XPS de layout fixo. | [Converter PowerPoint para XPS](/slides/pt/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP para TIFF | Salvar uma apresentação como um arquivo TIFF multipágina para impressão, digitalização, fax ou fluxos de trabalho de arquivamento. | [Converter PowerPoint para TIFF](/slides/pt/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP para TIFF com notas | Salvar slides com notas do apresentador em TIFF. | [Converter PowerPoint para TIFF com notas](/slides/pt/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX para Word | Converter slides para um documento Word quando precisar de saída em estilo de documento. | [Converter PowerPoint para Word](/slides/pt/net/convert-powerpoint-to-word/) |
| PPT/PPTX para Markdown | Extrair o conteúdo da apresentação para Markdown para documentação e fluxos de trabalho baseados em texto. | [Converter PowerPoint para Markdown](/slides/pt/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX para GIF animado | Criar um GIF animado a partir dos slides. | [Converter PowerPoint para GIF animado](/slides/pt/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX para vídeo | Criar um fluxo de exportação de vídeo a partir dos slides da apresentação. | [Converter PowerPoint para vídeo](/slides/pt/net/convert-powerpoint-to-video/) |
| Apresentação para XAML | Exportar slides para XAML para cenários de UI .NET. | [Exportar apresentações para XAML](/slides/pt/net/export-to-xaml/) |

Para uma lista mais abrangente de formatos de entrada e saída, veja [Formatos de arquivo suportados](/slides/pt/net/supported-file-formats/).

## **Conversão PowerPoint e OpenDocument**

Aspose.Slides for .NET oferece suporte à conversão a partir de formatos de apresentação comumente usados, como PPT, PPTX, PPS, PPSX, POT, POTX e ODP. A mesma API de conversão é usada para arquivos PowerPoint e OpenDocument, portanto, um fluxo de trabalho que salva um arquivo PPTX em PDF geralmente pode ser aplicado a um arquivo ODP alterando apenas o arquivo de entrada.

Ao converter arquivos ODP, lembre‑se de que os aplicativos PowerPoint e OpenDocument não suportam todos os recursos de layout e formatação da mesma forma. Se um arquivo ODP foi criado no LibreOffice ou no OpenOffice Impress, revise a saída e use as opções descritas em [Converter apresentações OpenDocument](/slides/pt/net/convert-openoffice-odp/) quando precisar de orientação específica ao formato.

## **Conversão PPT para PPTX**

PPT é o formato binário mais antigo do PowerPoint, enquanto PPTX é o formato moderno Office Open XML. Aspose.Slides for .NET oferece conversão PPT para PPTX de alta fidelidade, preservando estruturas complexas de apresentação, como mestres, layouts, slides, gráficos, formas agrupadas, marcadores de posição, quadros de texto, texturas e preenchimentos de imagem.

Para detalhes, veja [Converter PPT para PPTX](/slides/pt/net/convert-ppt-to-pptx/) e [PPT vs PPTX](/slides/pt/net/ppt-vs-pptx/).

## **Exportação de layout fixo**

PDF, XPS e TIFF são úteis quando a saída deve ter a mesma aparência em diferentes dispositivos e não deve ser editada como uma apresentação. Use [PdfOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/xpsoptions/) e [TiffOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/tiffoptions/) para controlar conformidade, slides ocultos, notas, qualidade de imagem, compressão, formato de pixel e tamanho da saída.

## **Exportação HTML e de Imagem**

A exportação HTML e HTML5 é útil para visualização em navegador, publicação web e compartilhamento leve. A exportação de imagem é útil quando cada slide deve se tornar uma pré‑visualização, miniatura ou recurso raster separado. Use os artigos PNG, JPG e SVG para orientações específicas de renderização por formato.

## **FAQ**

**Preciso do Microsoft PowerPoint para converter apresentações?**

Não. Aspose.Slides for .NET é uma biblioteca autônoma e não requer Microsoft PowerPoint ou automação do Office.

**Posso converter em lote muitas apresentações?**

Sim. Carregue cada apresentação, salve‑a no formato requerido e descarte o objeto `Presentation` após o processamento. Para processamento paralelo, use instâncias de apresentação separadas e siga as orientações de [multithreading](/slides/pt/net/multithreading/).

**Posso exportar apenas slides selecionados?**

Sim. Vários métodos de exportação permitem passar índices de slides ou renderizar slides individuais, dependendo do formato de saída. Consulte o artigo dedicado ao formato de destino.

**Posso incluir slides ocultos ao exportar para PDF ou XPS?**

Sim. Use a propriedade `ShowHiddenSlides` em [PdfOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/) ou [XpsOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/xpsoptions/).

**Posso criar saída PDF/A?**

Sim. As configurações de conformidade PDF estão disponíveis através de [PdfOptions.Compliance](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/compliance/) e [PdfCompliance](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfcompliance/).

**Como as fontes são tratadas durante a conversão?**

Aspose.Slides pode usar fontes incorporadas, fallback de fontes e configurações de substituição de fontes. Veja [Embedded Font](/slides/pt/net/embedded-font/), [Fallback Font](/slides/pt/net/fallback-font/) e [Font Substitution](/slides/pt/net/font-substitution/).