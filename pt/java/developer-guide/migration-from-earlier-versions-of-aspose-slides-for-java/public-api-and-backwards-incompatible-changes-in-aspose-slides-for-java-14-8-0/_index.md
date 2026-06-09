---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para Java 14.8.0
linktitle: Aspose.Slides para Java 14.8.0
type: docs
weight: 70
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legado
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise as atualizações da API pública e as alterações que quebram compatibilidade no Aspose.Slides para Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades e assim por diante [adicionados](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/), quaisquer novas restrições e outras [alterações](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) introduzidas com a API Aspose.Slides for Java 14.8.0.

{{% /alert %}} 
## **Alterações da API Pública**
### **Adicionado o Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() e os Métodos setOverlap(byte)**
O Aspose.Slides.Charts.IChartSeries.getOverlap() obtém quanto as barras e colunas devem se sobrepor em gráficos 2D (em uma faixa de -100 a 100).  
Este método não se aplica apenas a séries específicas, mas a todas as séries do grupo de séries pai – é a projeção da propriedade de grupo apropriada.

- Use o método IChartSeries.getParentSeriesGroup() para acessar o grupo de séries pai.  
- Use os métodos IChartSeriesGroup.getOverlap() e setOverlap(byte) para gerenciar o valor.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **Adicionado o Valor Enum ShapeThumbnailBounds.Appearance**
Esse método de criação de miniaturas de forma permite que os desenvolvedores gerem uma miniatura de forma dentro dos limites de sua aparência. Ele leva em consideração todos os efeitos da forma. A miniatura de forma gerada é restrita pelos limites do slide.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Adicionada a Classe VbaProject e a Interface IVbaProject, Alterados os Métodos Presentation.getVbaProject() e setVbaProject(VbaProject)**
Um novo recurso permite que os desenvolvedores criem e editem projetos VBA em uma apresentação.

``` java

 Presentation pres = new Presentation();

// Crie um novo projeto VBA
pres.setVbaProject(new VbaProject());

// Adicione um módulo vazio ao projeto VBA
IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Defina o código-fonte do módulo
module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Crie referência para <stdole>
VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Crie referência para Office
VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Adicione referências ao projeto VBA
pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```