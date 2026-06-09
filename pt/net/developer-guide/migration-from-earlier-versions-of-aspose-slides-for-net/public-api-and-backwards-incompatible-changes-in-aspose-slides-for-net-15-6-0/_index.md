---
title: API pública e alterações incompatíveis retroativas no Aspose.Slides para .NET 15.6.0
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
description: "Revise as atualizações da API pública e as mudanças que quebram compatibilidade no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentações PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todos os [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) ou [removidos](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) classes, métodos, propriedades e assim por diante, bem como outras alterações introduzidas na API do Aspose.Slides for .NET 15.6.0.

{{% /alert %}} 
## **Alterações da API Pública**
#### **A Assinatura do Construtor DataLabel Foi Alterada**
A assinatura do construtor DataLabel foi alterada:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Os Membros IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) Foram Marcados como Obsoletos e Suas Substituições Foram Introduzidas**
A propriedade IDocumentProperties.Count e os métodos IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) foram marcados como Obsoletos. A propriedade IDocumentProperties.CountOfCustomProperties e os métodos IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) foram adicionados em seu lugar.
#### **Método INotesSlideManager.RemoveNotesSlide() Foi Adicionado**
O método INotesSlideManager.RemoveNotesSlide() foi adicionado para remover o slide de notas de algum slide.
#### **Método Remove Foi Adicionado a IComment**
O método IComment.Remove foi adicionado para remover o comentário da coleção.
#### **Método Remove Foi Adicionado a ICommentAuthor**
O método ICommentAuthor.Remove foi adicionado para remover o autor dos comentários da coleção.
#### **Métodos ClearCustomProperties e ClearBuiltInProperties Foram Adicionados a IDocumentProperties**
O método IDocumentProperties.ClearCustomProperties foi adicionado para remover todas as propriedades personalizadas do documento.
O método IDocumentProperties.ClearBuiltInProperties foi adicionado para remover e definir valores padrão para todas as propriedades integradas do documento (Company, Subject, Author etc).
#### **Métodos RemoveAt, Remove e Clear Foram Adicionados a ICommentAuthorCollection**
O método ICommentAuthorCollection.RemoveAt foi adicionado para remover o autor por índice especificado.
O método ICommentAuthorCollection.Remove foi adicionado para remover o autor especificado da coleção.
O método ICommentAuthorCollection.Clear foi adicionado para remover todos os itens da coleção.
#### **Propriedade AppVersion Foi Adicionada a IDocumentProperties**
A propriedade IDocumentProperties.AppVersion foi adicionada para obter a propriedade integrada do documento que representa os números de versão internos usados pela Microsoft durante o desenvolvimento.
#### **Propriedade BlackWhiteMode Foi Adicionada a IShape e a Shape**
A propriedade BlackWhiteMode foi adicionada a IShape e a Shape.

Esta propriedade especifica como uma forma será renderizada no modo de exibição em preto e branco.

|**Valor** |**Significado** |
| :- | :- |
|Color |Renderiza com coloração normal |
|Automatic |Renderiza com coloração automática |
|Gray |Renderiza com coloração cinza |
|LightGray |Renderiza com coloração cinza clara |
|InverseGray |Renderiza com coloração cinza invertida |
|GrayWhite |Renderiza com coloração cinza e branca |
|BlackGray |Renderiza com coloração preta e cinza |
|BlackWhite |Renderiza com coloração preta e branca |
|Black |Renderiza somente com coloração preta |
|White |Renderiza com coloração branca |
|Hidden |Não renderiza |
|NotDefined|significa que a propriedade não está definida|
#### **Propriedade ISlide.NotesSlideManager Foi Adicionada. A Propriedade ISlide.NotesSlide e o Método ISlide.AddNotesSlide() Foram Marcados como Obsoletos**
Os membros ISlide.NotesSlide e ISlide.AddNotesSlide() foram marcados como obsoletos. Use a nova propriedade ISlide.NotesSlideManager em seu lugar.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsoleto

// notes = slide.NotesSlide; - obsoleto

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```