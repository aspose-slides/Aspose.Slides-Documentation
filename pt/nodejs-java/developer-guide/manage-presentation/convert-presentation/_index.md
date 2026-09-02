---
title: Converter apresentações para múltiplos formatos em JavaScript
linktitle: Converter apresentação
type: docs
weight: 70
url: /pt/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter apresentações PowerPoint e OpenDocument para PPTX, PDF, HTML, imagens, XPS, TIFF e mais com Aspose.Slides for Node.js via Java."
---
## **Visão geral**

Aspose.Slides for Node.js via Java pode carregar apresentações PowerPoint e OpenDocument e salvá‑las ou renderizá‑las em muitos outros formatos sem Microsoft PowerPoint, OpenOffice ou LibreOffice. Você pode converter arquivos PPT legados para PPTX modernos, exportar apresentações para documentos de layout fixo como PDF e XPS, publicar slides como HTML ou renderizar slides como arquivos de imagem para pré‑visualizações, miniaturas e arquivos.

A maioria das conversões de documentos usa o mesmo fluxo de trabalho geral: carregar o arquivo de origem, escolher o formato de saída necessário e aplicar opções específicas do formato quando necessário. Para formatos de imagem, cada slide é renderizado separadamente e então salvo como imagem raster ou vetorial. Os artigos dedicados vinculados abaixo fornecem os detalhes de implementação para cada caso.

## **Escolha um Cenário de Conversão**

Use os artigos abaixo para exemplos completos em JavaScript e opções específicas de formato.

| Cenário | Use quando precisar | Artigo |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernize arquivos PPT legados, normalize arquivos PPTX existentes ou converta apresentações OpenDocument para PowerPoint PPTX. | [Convert PPT to PPTX](/slides/pt/nodejs-java/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/pt/nodejs-java/convert-odp-to-pptx/), [Save Presentations](/slides/pt/nodejs-java/save-presentation/) |
| PPTX to PPT | Salve uma apresentação PowerPoint moderna no formato binário PPT mais antigo para compatibilidade com fluxos de trabalho antigos. | [Convert PPTX to PPT](/slides/pt/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Crie documentos portáteis, pesquisáveis e de layout fixo para compartilhamento, impressão ou arquivamento. | [Convert PowerPoint to PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exporte notas do apresentador juntamente com o conteúdo dos slides. | [Convert PowerPoint to PDF with Notes](/slides/pt/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publique apresentações como páginas HTML e controle imagens, fontes, notas e opções de layout responsivo. | [Convert PowerPoint to HTML](/slides/pt/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exporte slides para HTML5 para visualização baseada em navegador com formatação e interatividade preservadas. | [Convert Presentations to HTML5](/slides/pt/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Renderize cada slide em uma imagem PNG para pré‑visualizações, miniaturas ou saída web. | [Convert PowerPoint to PNG](/slides/pt/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Renderize slides em imagens JPG e controle dimensões e qualidade da imagem. | [Convert PowerPoint to JPG](/slides/pt/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exporte slides individuais como gráficos vetoriais escaláveis. | [Render Slide as SVG](/slides/pt/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Gere documentos XPS de layout fixo. | [Convert PowerPoint to XPS](/slides/pt/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Salve uma apresentação como um arquivo TIFF multipágina para impressão, digitalização, fax ou fluxos de trabalho de arquivamento. | [Convert PowerPoint to TIFF](/slides/pt/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Salve slides com notas do apresentador em TIFF. | [Convert PowerPoint to TIFF with Notes](/slides/pt/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Extraia o conteúdo da apresentação para Markdown para documentação e fluxos de trabalho baseados em texto. | [Convert PowerPoint to Markdown](/slides/pt/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Crie uma apresentação PowerPoint XML baseada em texto para inspeção, comparação, solução de problemas ou fluxos de trabalho baseados em XML. | [Convert PowerPoint to XML](/slides/pt/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Crie um GIF animado a partir dos slides. | [Convert PowerPoint to Animated GIF](/slides/pt/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Construa um fluxo de exportação de vídeo a partir dos slides da apresentação. | [Convert PowerPoint to Video](/slides/pt/nodejs-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exporte slides para XAML para cenários de UI em JavaScript ou Java. | [Export Presentations to XAML](/slides/pt/nodejs-java/export-to-xaml/) |

Para uma lista mais ampla de formatos de entrada e saída, veja [Supported File Formats](/slides/pt/nodejs-java/supported-file-formats/).

## **Conversão de PowerPoint e OpenDocument**

Aspose.Slides for Node.js via Java suporta conversão a partir de formatos de apresentação comumente usados, como PPT, PPTX, PPS, PPSX, POT, POTX e ODP. A mesma API de conversão é usada para arquivos PowerPoint e OpenDocument, então um fluxo de trabalho que salva um arquivo PPTX em PDF normalmente pode ser aplicado a um arquivo ODP alterando apenas o arquivo de entrada.

Ao converter arquivos ODP, lembre‑se de que aplicativos PowerPoint e OpenDocument não suportam todos os recursos de layout e formatação da mesma forma exata. Se um arquivo ODP foi criado no LibreOffice ou OpenOffice Impress, revise a saída e use as opções descritas em [Convert OpenDocument Presentations](/slides/pt/nodejs-java/convert-openoffice-odp/) quando precisar de orientações específicas ao formato.

## **Conversão de PPT para PPTX**

PPT é o formato binário mais antigo do PowerPoint, enquanto PPTX é o formato moderno Office Open XML. Aspose.Slides for Node.js via Java suporta conversão de PPT para PPTX de alta fidelidade, preservando estruturas de apresentação complexas, como masters, layouts, slides, gráficos, formas agrupadas, placeholders, quadros de texto, texturas e preenchimentos de imagem.

Para detalhes, veja [Convert PPT to PPTX](/slides/pt/nodejs-java/convert-ppt-to-pptx/) e [PPT vs PPTX](/slides/pt/nodejs-java/ppt-vs-pptx/).

## **Exportação de Layout Fixo**

PDF, XPS e TIFF são úteis quando a saída deve ter a mesma aparência em diferentes dispositivos e não deve ser editada como uma apresentação. Os artigos dedicados a PDF, XPS e TIFF explicam como controlar conformidade, slides ocultos, notas, qualidade de imagem, compressão, formato de pixel e tamanho de saída.

## **Exportação de HTML e Imagem**

A exportação para HTML e HTML5 é útil para visualização em navegadores, publicação na web e compartilhamento leve. A exportação de imagem é útil quando cada slide deve se tornar uma pré‑visualização, miniatura ou ativo raster separado. Use os artigos PNG, JPG e SVG para orientações de renderização específicas ao formato.

## **Perguntas Frequentes**

**Preciso do Microsoft PowerPoint para converter apresentações?**

Não. Aspose.Slides for Node.js via Java é uma biblioteca autônoma e não requer Microsoft PowerPoint ou automação do Office.

**Posso converter várias apresentações em lote?**

Sim. Carregue cada apresentação, salve-a no formato necessário e descarte o objeto de apresentação após o processamento. Para processamento paralelo, use instâncias de apresentação separadas e siga as orientações de [multithreading](/slides/pt/nodejs-java/multithreading/).

**Posso exportar apenas slides selecionados?**

Sim. Vários métodos de exportação permitem que você passe índices de slides ou renderize slides individuais, dependendo do formato de saída. Veja o artigo dedicado ao formato de destino.

**Posso incluir slides ocultos ao exportar para PDF ou XPS?**

Sim. Use as configurações de exportação de slides ocultos descritas nos artigos de conversão de [PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/) e [XPS](/slides/pt/nodejs-java/convert-powerpoint-to-xps/).

**Posso criar saída PDF/A?**

Sim. Configurações de conformidade PDF estão disponíveis para exportação em PDF. Veja [Convert PowerPoint to PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/) para detalhes.

**Como as fontes são tratadas durante a conversão?**

Aspose.Slides pode usar fontes incorporadas, fallback de fontes e configurações de substituição de fontes. Veja [Embedded Font](/slides/pt/nodejs-java/embedded-font/), [Fallback Font](/slides/pt/nodejs-java/fallback-font/) e [Font Substitution](/slides/pt/nodejs-java/font-substitution/).