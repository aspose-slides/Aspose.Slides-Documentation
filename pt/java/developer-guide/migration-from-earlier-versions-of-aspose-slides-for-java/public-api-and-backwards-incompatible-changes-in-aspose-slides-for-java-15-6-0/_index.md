---
title: API Pública e Alterações Incompatíveis com Versões Anteriores em Aspose.Slides for Java 15.6.0
linktitle: Aspose.Slides para Java 15.6.0
type: docs
weight: 140
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
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
description: "Reveja as atualizações da API pública e as mudanças incompatíveis em Aspose.Slides for Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes [adicionados](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/), métodos, propriedades e etc, quaisquer novas restrições e outras [alterações](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) introduzidas com a API Aspose.Slides for Java 15.6.0.

{{% /alert %}} 
## **Alterações da API Pública**
#### **A assinatura do construtor com.aspose.slides.DataLabel foi alterada**
A assinatura do construtor foi alterada de DataLabel(com.aspose.slides.IChartSeries) para DataLabel(com.aspose.slides.IChartDataPoint).
#### **Os membros com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) foram marcados como obsoletos; substituições foram introduzidas em seu lugar**
Os métodos IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) foram marcados como obsoletos. Foram introduzidos os métodos IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) em seu lugar.
#### **Método com.aspose.slides.INotesSlideManager.removeNotesSlide() foi adicionado**
O método com.aspose.slides.INotesSlideManager.RemoveNotesSlide() foi adicionado para remover o slide de notas de um slide.
#### **Método com.aspose.slides.ISlide.getNotesSlideManager() foi adicionado. Os métodos ISlide.getNotesSlide() e ISlide.addNotesSlide() foram marcados como obsoletos**
Método com.aspose.slides.ISlide.getNotesSlideManager() foi adicionado. Os métodos ISlide.getNotesSlide() e ISlide.addNotesSlide() foram marcados como obsoletos. Use o novo método ISlide.getNotesSlideManager() em seu lugar.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - obsoleto

// notes = slide.getNotesSlide(); - obsoleto

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Método getAppVersion() foi adicionado a com.aspose.slides.IDocumentProperties**
O método com.aspose.slides.IDocumentProperties.getAppVersion() foi adicionado para obter a propriedade de documento embutida que representa os números de versão internos usados pelo Microsoft PowerPoint.
#### **Método remove() foi adicionado a com.aspose.slides.IComment**
O método com.aspose.slides.IComment.remove() foi adicionado para remover um comentário da coleção.
#### **Método remove() foi adicionado a com.aspose.slides.ICommentAuthor**
O método ICommentAuthor.Remove foi adicionado para remover o autor dos comentários da coleção.
#### **Métodos clearCustomProperties() e clearBuiltInProperties() foram adicionados a com.aspose.slides.IDocumentProperties**
O método com.aspose.slides.IDocumentProperties.clearCustomProperties() foi adicionado para remover todas as propriedades de documento personalizadas.
O método com.aspose.slides.IDocumentProperties.clearBuiltInProperties() foi adicionado para remover e definir valores padrão para todas as propriedades de documento embutidas (Company, Subject, Author etc).
#### **Métodos getBlackWhiteMode() e setBlackWhiteMode(byte) foram adicionados a com.aspose.slides.IShape**
Os métodos getBlackWhiteMode() e setBlackWhiteMode(byte) foram adicionados a com.aspose.slides.IShape. Os métodos especificam como uma forma será renderizada no modo de exibição em preto e branco. Os valores possíveis são especificados na classe com.aspose.slides.BlackWhiteMode.

|**Valor**|**Significado**|
| :- | :- |
|Color|Retorna com coloração normal|
|Automatic|Retorna com coloração automática|
|Gray|Retorna com coloração cinza|
|LightGray|Retorna com coloração cinza claro|
|InverseGray|Retorna com coloração cinza inversa|
|GrayWhite|Retorna com coloração cinza e branca|
|BlackGray|Retorna com coloração preta e cinza|
|BlackWhite|Retorna com coloração preta e branca|
|Black|Retorna apenas com coloração preta|
|White|Retorna com coloração branca|
|Hidden|O objeto não é renderizado|
#### **Métodos removeAt(int), remove(ICommentAuthor) e clear() foram adicionados a com.aspose.slides.ICommentAuthorCollection**
O método ICommentAuthorCollection.removeAt(int) foi adicionado para remover o autor por índice especificado. O método ICommentAuthorCollection.remove(ICommentAuthor) foi adicionado para remover o autor especificado da coleção. O método ICommentAuthorCollection.clear() foi adicionado para remover todos os itens da coleção.