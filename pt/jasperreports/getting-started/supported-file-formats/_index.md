---
title: Formatos de Arquivo Compatíveis
type: docs
weight: 20
url: /pt/jasperreports/supported-file-formats/
description: "Veja quais entradas o Aspose.Slides for JasperReports aceita e para quais formatos de arquivo ele exporta relatórios."
---
## **Entrada**

O Aspose.Slides for JasperReports exporta relatórios; ele não converte apresentações existentes. Seus exportadores recebem um relatório JasperReports preenchido (`JasperPrint`), como o resultado de `JasperFillManager` ou um relatório preenchido carregado de um arquivo *.jrprint*.

## **Formatos de Saída**

A tabela a seguir lista os formatos para os quais o Aspose.Slides for JasperReports exporta um relatório, bem como a classe exportadora que grava cada um.

|**Formato**|**Descrição**|**Exportador**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Apresentação PowerPoint 97-2003; um slide por página de relatório|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Apresentação PowerPoint (Office Open XML); um slide por página de relatório|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Formato de Documento Portátil; uma página PDF por página de relatório|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Um único arquivo HTML com uma imagem SVG por página de relatório|`ASHtmlExporter`|

Não há exportador para os formatos de apresentação de slides PPS e PPSX. Ao dar a uma exportação PPTX um nome de arquivo *.ppsx* ainda produz uma apresentação PPTX, não uma apresentação de slides. Para ver como cada exportador é usado, consulte [Exportação PPT, PPTX, PDF e HTML](/slides/pt/jasperreports/ppt-pptx-pdf-and-html-export/).