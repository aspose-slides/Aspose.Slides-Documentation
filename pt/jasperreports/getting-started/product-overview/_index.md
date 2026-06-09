---
title: Visão geral do produto
type: docs
weight: 10
url: /pt/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Bem-vindo ao Aspose.Slides for JasperReports!**

Aspose.Slides for JasperReports é uma biblioteca projetada e desenvolvida especialmente para desenvolvedores que precisam exportar relatórios do JasperReports para os formatos Microsoft PowerPoint Presentation (PPT) e Microsoft PowerPoint Show (PPS) em suas aplicações Java. Todos os recursos do relatório são convertidos com o mais alto grau de precisão para apresentações do Microsoft PowerPoint. Aspose.Slides for JasperReports inclui suporte ao JasperReports 5+.

## **Descrição do Produto**
JasperReports e JasperServer não possuem recursos nativos para exportar relatórios como apresentações Microsoft PowerPoint, mas o Aspose.Slides for JasperReports oferece acesso a dois formatos de exportação adicionais: 

- PPT – Apresentação PowerPoint via Aspose.Slides
- PPS – PowerPoint Show via Aspose.Slides
- PPTX – Apresentação PowerPoint via Aspose.Slides
- PPSX – PowerPoint Show via Aspose.Slides

O Aspose.Slides for JasperReports usa internamente nossas bibliotecas Java 100% puras Aspose.Slides for Java e Aspose.Metafiles for Java, bibliotecas de classe mundial para processamento de apresentações e metafiles no lado do servidor.

O Aspose.Slides for JasperReports possibilita exportar qualquer relatório nos formatos PPT ou PPS.

### **Exemplo de Saída**
A classe ASPptExporter estende a classe ASAbstractExporter, de modo que pode ser usada da mesma forma que quaisquer outros exportadores padrão. Este breve exemplo mostra o código típico e uma captura de tela de um relatório visualizado no MS PowerPoint. Exemplos detalhados podem ser encontrados nos relatórios de demonstração fornecidos. 

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Apresentação gerada com a demonstração JasperReports xmldatasource** 

![Apresentação gerada com JasperReports](product-overview_2.png)