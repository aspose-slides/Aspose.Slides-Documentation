---
title: API Pública e Alterações Incompatíveis com Versões Anteriores no Aspose.Slides para Java 14.8.0
linktitle: Aspose.Slides para Java 14.8.0
type: docs
weight: 70
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revisar as atualizações da API pública e alterações que quebram compatibilidade no Aspose.Slides para Java para migrar suavemente suas soluções de apresentações PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as [added](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) classes, methods, properties etc., quaisquer novas restrições e outras [changes](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) introduzidas com a API Aspose.Slides for Java 14.8.0.

{{% /alert %}} 
## **Public API Changes**
### **Added the Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap(), and setOverlap(byte) Mehtods**
O Aspose.Slides.Charts.IChartSeries.getOverlap() obtém o grau de sobreposição de barras e colunas em gráficos 2D (em uma faixa de -100 a 100). Este método não se aplica apenas a séries específicas, mas a todas as séries do grupo de séries pai – é a projeção da propriedade apropriada do grupo.

- Use o método IChartSeries.getParentSeriesGroup() para acessar o grupo de séries pai.
- Use os métodos IChartSeriesGroup.getOverlap() e setOverlap(byte) para gerenciar o valor.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Added the ShapeThumbnailBounds.Appearance Enum Value**
Esse método de criação de miniaturas de formas permite que os desenvolvedores gerem uma miniatura de forma dentro dos limites de sua aparência. Ele leva em consideração todos os efeitos da forma. A miniatura de forma gerada é restrita pelos limites do slide.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Added the VbaProject Class and IVbaProject Interface, Changed the Presentation.getVbaProject() and setVbaProject(VbaProject) Methods**
Um novo recurso permite que os desenvolvedores criem e editem projetos VBA em uma apresentação.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Criar novo Projeto VBA

pres.setVbaProject(new VbaProject());

// Adicionar módulo vazio ao projeto VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Definir código-fonte do módulo

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Criar referência para <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Criar referência para Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Adicionar referências ao projeto VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);
```