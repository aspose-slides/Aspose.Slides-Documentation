---
title: Alterações da API Pública e Incompatíveis Retroativamente no Aspose.Slides para .NET 15.6.0
linktitle: Aspose.Slides para .NET 15.6.0
type: docs
weight: 170
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as classes, métodos, propriedades etc. [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) ou [removidos](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) e outras mudanças introduzidas com a API Aspose.Slides for .NET 15.6.0.

{{% /alert %}} 
## **Alterações da API Pública**
#### **A assinatura do construtor DataLabel foi alterada**
A assinatura do construtor DataLabel foi alterada:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Os membros IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name) e .Contains(string name) foram marcados como obsoletos e suas substituições foram introduzidas**
Property IDocumentProperties.Count and methods IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) have been marked as Obsolete. Property IDocumentProperties.CountOfCustomProperties and methods IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) have been added instead.
#### **O método INotesSlideManager.RemoveNotesSlide() foi adicionado**
O método INotesSlideManager.RemoveNotesSlide() foi adicionado para remover a nota de slide de algum slide.
#### **O método Remove foi adicionado ao IComment**
O método Remove foi adicionado ao IComment para remover o comentário da coleção.
#### **O método Remove foi adicionado ao ICommentAuthor**
O método Remove foi adicionado ao ICommentAuthor para remover o autor dos comentários da coleção.
#### **Os métodos ClearCustomProperties e ClearBuiltInProperties foram adicionados ao IDocumentProperties**
Method IDocumentProperties.ClearCustomProperties has been added for removing all custom document properties.
Method IDocumentProperties.ClearBuiltInProperties has been added for removing and setting default values for all builtIn document properties (Company, Subject, Author etc).
#### **Os métodos RemoveAt, Remove e Clear foram adicionados ao ICommentAuthorCollection**
Method ICommentAuthorCollection.RemoveAt has added for removing author by specified index.
Method ICommentAuthorCollection.Remove has added for removing specified author from collection.
Method ICommentAuthorCollection.Clear has been added for removing all items from collection.
#### **A propriedade AppVersion foi adicionada ao IDocumentProperties**
Property IDocumentProperties.AppVersion has been added to get builtIn document property which representis internal version numbers used by Microsoft during development.
#### **A propriedade BlackWhiteMode foi adicionada ao IShape e ao Shape**
A propriedade BlackWhiteMode foi adicionada ao IShape e ao Shape.

Esta propriedade especifica como uma forma será renderizada no modo de exibição preto‑e‑branco.

|**Valor**|**Significado**|
| :- | :- |
|Color|Renderizar com cores normais|
|Automatic|Renderizar com coloração automática|
|Gray|Renderizar com coloração cinza|
|LightGray|Renderizar com coloração cinza clara|
|InverseGray|Renderizar com coloração cinza invertida|
|GrayWhite|Renderizar com coloração cinza e branca|
|BlackGray|Renderizar com coloração preta e cinza|
|BlackWhite|Renderizar com coloração preta e branca|
|Black|Renderizar apenas com coloração preta|
|White|Renderizar com coloração branca|
|Hidden|Não renderizar|
|NotDefined|significa que a propriedade não está definida|
#### **A propriedade ISlide.NotesSlideManager foi adicionada. A propriedade ISlide.NotesSlide e o método ISlide.AddNotesSlide() foram marcados como obsoletos.**
Os membros ISlide.NotesSlide e ISlide.AddNotesSlide() foram marcados como Obsolete. Use a nova propriedade ISlide.NotesSlideManager em vez disso.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - obsoleto
    // notes = slide.NotesSlide; - obsoleto

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```