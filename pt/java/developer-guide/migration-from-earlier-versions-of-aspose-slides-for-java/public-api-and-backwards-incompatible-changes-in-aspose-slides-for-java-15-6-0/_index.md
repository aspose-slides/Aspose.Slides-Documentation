---
title: API pública e alterações incompatíveis retroativas no Aspose.Slides for Java 15.6.0
linktitle: Aspose.Slides para Java 15.6.0
type: docs
weight: 140
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
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
description: "Reveja as atualizações da API pública e mudanças incompatíveis no Aspose.Slides for Java para migrar suavemente suas soluções de apresentações PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as classes, métodos, propriedades e afins [added](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) , quaisquer novas restrições e outras [changes](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) introduzidas com a API Aspose.Slides for Java 15.6.0.

{{% /alert %}} 
## **Alterações da API Pública**
#### **A assinatura do construtor com.aspose.slides.DataLabel foi alterada**
A assinatura do construtor foi alterada de DataLabel(com.aspose.slides.IChartSeries) para DataLabel(com.aspose.slides.IChartDataPoint).
#### **Os membros com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) foram marcados como obsoletos; substituições foram introduzidas**
Os métodos IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name) e .contains(string name) foram marcados como obsoletos. Em vez deles, foram introduzidos os métodos IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name) e .containsCustomProperty(string name).
#### **O método com.aspose.slides.INotesSlideManager.removeNotesSlide() foi adicionado**
O método com.aspose.slides.INotesSlideManager.RemoveNotesSlide() foi adicionado para remover o slide de notas de um determinado slide.
#### **O método com.aspose.slides.ISlide.getNotesSlideManager() foi adicionado. Os métodos ISlide.getNotesSlide() e ISlide.addNotesSlide() foram marcados como obsoletos**
Os métodos ISlide.getNotesSlide() e ISlide.addNotesSlide() foram marcados como obsoletos. Use o novo método ISlide.getNotesSlideManager() em vez disso.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - obsoleto

    // notes = slide.getNotesSlide(); - obsoleto

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **O método getAppVersion() foi adicionado a com.aspose.slides.IDocumentProperties**
O método com.aspose.slides.IDocumentProperties.getAppVersion() foi adicionado para obter a propriedade de documento incorporada que representa os números de versão internos usados pelo Microsoft PowerPoint.
#### **O método remove() foi adicionado a com.aspose.slides.IComment**
O método com.aspose.slides.IComment.remove() foi adicionado para remover um comentário da coleção.
#### **O método remove() foi adicionado a com.aspose.slides.ICommentAuthor**
O método ICommentAuthor.Remove foi adicionado para remover o autor dos comentários da coleção.
#### **Os métodos clearCustomProperties() e clearBuiltInProperties() foram adicionados a com.aspose.slides.IDocumentProperties**
O método com.aspose.slides.IDocumentProperties.clearCustomProperties() foi adicionado para remover todas as propriedades de documento personalizadas.
O método com.aspose.slides.IDocumentProperties.clearBuiltInProperties() foi adicionado para remover e definir valores padrão para todas as propriedades de documento incorporadas (Company, Subject, Author etc).
#### **Os métodos getBlackWhiteMode() e setBlackWhiteMode(byte) foram adicionados a com.aspose.slides.IShape**
Os métodos getBlackWhiteMode() e setBlackWhiteMode(byte) foram adicionados a com.aspose.slides.IShape. Os métodos especificam como uma forma será renderizada no modo de exibição em preto e branco. Os valores possíveis são especificados na classe com.aspose.slides.BlackWhiteMode.

|**Valor**|**Significado**|
| :- | :- |
|Color|Retorna com coloração normal|
|Automatic|Retorna com coloração automática|
|Gray|Retorna com coloração cinza|
|LightGray|Retorna com coloração cinza clara|
|InverseGray|Retorna com coloração cinza inversa|
|GrayWhite|Retorna com coloração cinza e branca|
|BlackGray|Retorna com coloração preta e cinza|
|BlackWhite|Retorna com coloração preta e branca|
|Black|Retorna apenas com coloração preta|
|White|Retorna com coloração branca|
|Hidden|O objeto não é renderizado|

#### **Os métodos removeAt(int), remove(ICommentAuthor) e clear() foram adicionados a com.aspose.slides.ICommentAuthorCollection**
O método ICommentAuthorCollection.removeAt(int) foi adicionado para remover o autor pelo índice especificado. O método ICommentAuthorCollection.remove(ICommentAuthor) foi adicionado para remover o autor especificado da coleção. O método ICommentAuthorCollection.clear() foi adicionado para remover todos os itens da coleção.