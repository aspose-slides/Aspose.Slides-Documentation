---
title: Visão Geral do Produto
type: docs
weight: 10
url: /pt/jasperreports/product-overview/
description: "Saiba o que o Aspose.Slides for JasperReports faz, quais versões do JasperReports e formatos de saída ele suporta, e para que servem seus dois jars."
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Descrição do Produto**

Aspose.Slides for JasperReports exporta relatórios do JasperReports para apresentações PowerPoint, em aplicações Java e no JasperReports Server, sem necessidade do Microsoft PowerPoint. Ele suporta JasperReports 3.7.2 até 6.16.0, com um jar separado para cada intervalo de versões — veja [Instalando Aspose.Slides for JasperReports](/slides/pt/jasperreports/installing-aspose-slides-for-jasperreports/).

Ele exporta um relatório preenchido para quatro formatos, um slide ou página por página do relatório:

- PPT – Apresentação PowerPoint 97–2003
- PPTX – Apresentação PowerPoint (Office Open XML)
- PDF
- HTML

O produto tem duas partes:

- O jar da biblioteca adiciona os exportadores `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` e `ASHtmlExporter` à JasperReports Library.
- O jar do servidor fornece ações de exportação para os mesmos quatro formatos, que você registra no JasperReports Server — veja [Integração com JasperServer](/slides/pt/jasperreports/integration-with-jasperserver/).

### **Exemplo de Saída**

Os exportadores estendem as próprias classes de exportação do JasperReports e são usados da mesma forma: passe a eles o relatório preenchido e o arquivo de saída, então chame `exportReport`. Para um programa completo que preenche um relatório e o exporta para PPTX, veja [Sua primeira exportação](/slides/pt/jasperreports/#your-first-export); para os quatro formatos, veja [Exportação PPT, PPTX, PDF e HTML](/slides/pt/jasperreports/ppt-pptx-pdf-and-html-export/).

![Um relatório exportado para uma apresentação sem licença, com a marca d'água de avaliação no centro do slide](product-overview_2.png)