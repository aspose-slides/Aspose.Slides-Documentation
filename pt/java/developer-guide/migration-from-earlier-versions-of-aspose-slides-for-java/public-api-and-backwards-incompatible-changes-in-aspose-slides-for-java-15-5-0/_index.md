---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides for Java 15.5.0
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
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
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides for Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todos os [added](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) classes, methods, properties etc., quaisquer novas restrições e outras [changes](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) introduzidas com a Aspose.Slides for Java 15.5.0 API.

{{% /alert %}} 
## **Alterações da API Pública**
### **Classe CommonSlideViewProperties e interface ICommonSlideViewProperties foram adicionadas**
A classe com.aspose.slides.CommonSlideViewProperties (e sua interface com.aspose.slides.ICommonSlideViewProperties) representa propriedades comuns de visualização de slides (atualmente opções de escala de visualização).
### **Métodos IAxis.getLabelOffset() e setLabelOffset(int) foram adicionados**
Os métodos IAxis.getLabelOffset() e setLabelOffset(int) permitem obter e especificar a distância dos rótulos em relação ao eixo. Aplicado ao eixo de categoria ou de data.
### **Métodos IChartTextBlockFormat.getAutofitType() e setAutofitType(byte) foram adicionados**
Os métodos getAutofitType() e setAutofitType(/**TextAutofitType**/byte) foram adicionados à interface com.aspose.slides.IChartTextBlockFormat.  
Alterar esse valor pode produzir uma certa influência apenas nas seguintes partes do gráfico: DataLabel e DataLabelFormat (suporte total no PowerPoint 2013; no PowerPoint 2007 não há efeito na renderização).
### **Métodos IChartTextBlockFormat.getWrapText() e setWrapText(byte) foram adicionados**
Os métodos getWrapText() e setWrapText(/**NullableBool**/byte) foram adicionados à interface com.aspose.slides.IChartTextBlockFormat.  
Alterar esse valor pode produzir uma certa influência apenas nas seguintes partes do gráfico: DataLabel e DataLabelFormat (suporte total no PowerPoint 2007/2013).
### **Os métodos para gerenciar margens foram adicionados ao IChartTextBlockFormat**
Os métodos getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() e setMarginBottom(double) foram adicionados à interface com.aspose.slides.IChartTextBlockFormat.  
Alterar esses valores pode produzir uma certa influência apenas nas seguintes partes do gráfico: DataLabel e DataLabelFormat (suporte total no PowerPoint 2013; no PowerPoint 2007 não há efeito na renderização).
### **Método ViewProperties.getNotesViewProperties() foi adicionado**
A propriedade com.aspose.slides.ViewProperties.getNotesViewProperties() foi adicionada. Ela obtém as propriedades de visualização comuns associadas ao modo de visualização de notas.
### **Método ViewProperties.getSlideViewProperties() foi adicionado**
O método com.aspose.slides.ViewProperties.getSlideViewProperties() foi adicionado. Ele obtém as propriedades de visualização comuns associadas ao modo de visualização de slides.