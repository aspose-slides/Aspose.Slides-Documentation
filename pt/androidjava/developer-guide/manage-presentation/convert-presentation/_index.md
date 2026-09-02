---
title: Converter Apresentações para Múltiplos Formatos no Android
linktitle: Converter Apresentação
type: docs
weight: 70
url: /pt/androidjava/convert-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Converter apresentações PowerPoint e OpenDocument para PPTX, PDF, HTML, imagens, XPS, TIFF e mais com Aspose.Slides for Android via Java."
---
## **Visão geral**

Aspose.Slides for Android via Java pode carregar apresentações PowerPoint e OpenDocument e salvá‑las ou renderizá‑las em muitos outros formatos sem precisar do Microsoft PowerPoint, OpenOffice ou LibreOffice. Você pode converter arquivos PPT legados para o moderno PPTX, exportar apresentações para documentos de layout fixo como PDF e XPS, publicar slides como HTML ou renderizar slides como arquivos de imagem para visualizações, miniaturas e arquivos.

A maioria das conversões de documentos usa o mesmo fluxo de trabalho geral: carregar o arquivo de origem, escolher o formato de saída desejado e aplicar opções específicas do formato quando necessário. Para formatos de imagem, cada slide é renderizado separadamente e então salvo como imagem raster ou vetorial. Os artigos dedicados vinculados abaixo fornecem os detalhes de implementação para cada caso.

## **Escolha um Cenário de Conversão**

Use os artigos abaixo para exemplos Java completos e opções específicas de formato.

| Cenário | Use quando precisar | Artigo |
| --- | --- | --- |
| PPT/PPTX/ODP para PPTX | Modernizar arquivos PPT legados, normalizar arquivos PPTX existentes ou converter apresentações OpenDocument para PowerPoint PPTX. | [Converter PPT para PPTX](/slides/pt/androidjava/convert-ppt-to-pptx/),[Converter ODP para PPTX](/slides/pt/androidjava/convert-odp-to-pptx/),[Salvar Apresentações](/slides/pt/androidjava/save-presentation/) |
| PPTX para PPT | Salvar uma apresentação PowerPoint moderna no formato binário PPT antigo para compatibilidade com fluxos de trabalho legados. | [Converter PPTX para PPT](/slides/pt/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP para PDF | Criar documentos portáteis, pesquisáveis e de layout fixo para compartilhamento, impressão ou arquivamento. | [Converter PowerPoint para PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP para PDF com notas | Exportar notas do apresentador junto com o conteúdo dos slides. | [Converter PowerPoint para PDF com Notas](/slides/pt/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP para HTML | Publicar apresentações como páginas HTML e controlar imagens, fontes, notas e opções de layout responsivo. | [Converter PowerPoint para HTML](/slides/pt/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP para HTML5 | Exportar slides para HTML5 para visualização baseada em navegador com formatação e interatividade preservadas. | [Converter Apresentações para HTML5](/slides/pt/androidjava/export-to-html5/) |
| PPT/PPTX/ODP para PNG | Renderizar cada slide como imagem PNG para visualizações, miniaturas ou saída web. | [Converter PowerPoint para PNG](/slides/pt/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP para JPG | Renderizar slides como imagens JPG e controlar dimensões e qualidade da imagem. | [Converter PowerPoint para JPG](/slides/pt/androidjava/convert-powerpoint-to-jpg/) |
| Slide para SVG | Exportar slides individuais como gráficos vetoriais escaláveis. | [Renderizar Slide como SVG](/slides/pt/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP para XPS | Gerar documentos XPS de layout fixo. | [Converter PowerPoint para XPS](/slides/pt/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP para TIFF | Salvar uma apresentação como arquivo TIFF multipágina para impressão, digitalização, fax ou fluxo de arquivamento. | [Converter PowerPoint para TIFF](/slides/pt/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP para TIFF com notas | Salvar slides com notas do apresentador em TIFF. | [Converter PowerPoint para TIFF com Notas](/slides/pt/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX para Word | Converter slides para um documento Word quando precisar de saída estilo documento. | [Converter PowerPoint para Word](/slides/pt/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX para Markdown | Extrair conteúdo da apresentação para Markdown para documentação e fluxos de trabalho baseados em texto. | [Converter PowerPoint para Markdown](/slides/pt/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP para XML | Criar uma apresentação PowerPoint XML baseada em texto para inspeção, comparação, solução de problemas ou fluxos de trabalho XML. | [Converter PowerPoint para XML](/slides/pt/androidjava/convert-powerpoint-to-xml/) |
| PPT/PPTX para GIF animado | Criar um GIF animado a partir dos slides. | [Converter PowerPoint para GIF Animado](/slides/pt/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX para vídeo | Construir um fluxo de exportação de vídeo a partir dos slides da apresentação. | [Converter PowerPoint para Vídeo](/slides/pt/androidjava/convert-powerpoint-to-video/) |
| Apresentação para XAML | Exportar slides para XAML para cenários de UI Android ou Java. | [Exportar Apresentações para XAML](/slides/pt/androidjava/export-to-xaml/) |

Para uma lista mais ampla de formatos de entrada e saída, veja [Formatos de Arquivo Compatíveis](/slides/pt/androidjava/supported-file-formats/).

## **Conversão PowerPoint e OpenDocument**

Aspose.Slides for Android via Java oferece suporte à conversão a partir de formatos de apresentação amplamente usados, como PPT, PPTX, PPS, PPSX, POT, POTX e ODP. A mesma API de conversão é usada para arquivos PowerPoint e OpenDocument, de modo que um fluxo de trabalho que salva um arquivo PPTX em PDF costuma ser aplicado a um arquivo ODP alterando apenas o arquivo de entrada.

Ao converter arquivos ODP, lembre‑se de que os aplicativos PowerPoint e OpenDocument não suportam todos os recursos de layout e formatação exatamente da mesma forma. Se um arquivo ODP foi criado no LibreOffice ou OpenOffice Impress, revise a saída e use as opções descritas em [Converter Apresentações OpenDocument](/slides/pt/androidjava/convert-openoffice-odp/) quando precisar de orientação específica do formato.

## **Conversão de PPT para PPTX**

PPT é o formato binário antigo do PowerPoint, enquanto PPTX é o formato moderno Office Open XML. Aspose.Slides for Android via Java oferece conversão de alta fidelidade de PPT para PPTX preservando estruturas complexas da apresentação, como mestres, layouts, slides, gráficos, formas agrupadas, marcadores de posição, caixas de texto, texturas e preenchimentos de imagem.

Para detalhes, veja [Converter PPT para PPTX](/slides/pt/androidjava/convert-ppt-to-pptx/) e [PPT vs PPTX](/slides/pt/androidjava/ppt-vs-pptx/).

## **Exportação de Layout Fixo**

PDF, XPS e TIFF são úteis quando a saída deve ter a mesma aparência em todos os dispositivos e não deve ser editada como apresentação. Os artigos dedicados a PDF, XPS e TIFF explicam como controlar conformidade, slides ocultos, notas, qualidade da imagem, compressão, formato de pixel e tamanho da saída.

## **Exportação HTML e de Imagens**

Exportação HTML e HTML5 são úteis para visualização em navegador, publicação web e compartilhamento leve. Exportação de imagens é útil quando cada slide deve se tornar uma visualização, miniatura ou recurso raster separado. Use os artigos PNG, JPG e SVG para orientações de renderização específicas ao formato.

## **FAQ**

**Preciso do Microsoft PowerPoint para converter apresentações?**

Não. Aspose.Slides for Android via Java é uma biblioteca autônoma e não requer Microsoft PowerPoint ou automação do Office.

**Posso converter em lote muitas apresentações?**

Sim. Carregue cada apresentação, salve‑a no formato exigido e descarte o objeto de apresentação após o processamento. Para processamento paralelo, use instâncias de apresentação separadas e siga as orientações de [multithreading](/slides/pt/androidjava/multithreading/).

**Posso exportar somente slides selecionados?**

Sim. Vários métodos de exportação permitem passar índices de slides ou renderizar slides individuais, dependendo do formato de saída. Consulte o artigo dedicado ao formato de destino.

**Posso incluir slides ocultos ao exportar para PDF ou XPS?**

Sim. Use as configurações de exportação de slide oculto descritas nos artigos de [PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/) e [XPS](/slides/pt/androidjava/convert-powerpoint-to-xps/).

**Posso criar saída PDF/A?**

Sim. Configurações de conformidade PDF estão disponíveis para exportação PDF. Veja [Converter PowerPoint para PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/) para detalhes.

**Como as fontes são tratadas durante a conversão?**

Aspose.Slides pode usar fontes incorporadas, fallback de fontes e configurações de substituição de fontes. Consulte [Fonte Incorporada](/slides/pt/androidjava/embedded-font/), [Fonte de Fallback](/slides/pt/androidjava/fallback-font/) e [Substituição de Fonte](/slides/pt/androidjava/font-substitution/).