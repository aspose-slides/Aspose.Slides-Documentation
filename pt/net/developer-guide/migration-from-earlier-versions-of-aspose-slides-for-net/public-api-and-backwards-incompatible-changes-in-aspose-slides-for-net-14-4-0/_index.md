---
title: API Pública e Alterações Incompatíveis com Versões Anteriores em Aspose.Slides para .NET 14.4.0
linktitle: Aspose.Slides para .NET 14.4.0
type: docs
weight: 60
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legado
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Revise as atualizações da API pública e as mudanças incompatíveis em Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
## **API Pública e Alterações Incompatíveis com Versões Anteriores**
### **Interfaces, Classes, Métodos e Propriedades Adicionados**
#### **Propriedade Aspose.Slides.ILayoutSlide.HasDependingSlides Foi Adicionada**
A propriedade Aspose.Slides.ILayoutSlide.HasDependingSlides retorna true se existir ao menos um slide que dependa deste slide de layout. Por exemplo:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Método Aspose.Slides.ILayoutSlide.Remove()**
O método Aspose.Slides.ILayoutSlide.Remove() permite remover um layout de uma apresentação com o mínimo de código. Por exemplo:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Método Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
O método Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) permite remover um layout da coleção. Exemplos de código:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

ou

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
O método Aspose.Slides.ILayoutSlideCollection.RemoveUnused() permite remover slides de layout não utilizados (slides de layout cujo HasDependingSlides é false). Exemplos de código:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

ou

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Propriedade Aspose.Slides.IMasterSlide.HasDependingSlides**
A propriedade Aspose.Slides.IMasterSlide.HasDependingSlides retorna true se existir ao menos um slide que dependa deste slide mestre. Por exemplo:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Método Aspose.Slides.ISlide.Remove()**
O método Aspose.Slides.ISlide.Remove() permite remover um slide de uma apresentação com o mínimo de código. Por exemplo:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
A propriedade Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat retorna IFillFormat para a marca de ponto de um nó SmartArt se o layout fornecer marcadores. Pode ser usado para definir a imagem do marcador.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Propriedade Aspose.Slides.SmartArt.ISmartArtNode.Level**
A propriedade Aspose.Slides.SmartArt.ISmartArtNode.Level retorna o nível de aninhamento dos nós SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Propriedade Aspose.Slides.SmartArt.ISmartArtNode.Position**
A propriedade Aspose.Slides.SmartArt.ISmartArtNode.Position retorna a posição de um nó entre seus irmãos.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Método Aspose.Slides.SmartArt.ISmartArtNode.Remove() Foi Adicionado**
O método Aspose.Slides.SmartArt.ISmartArtNode.Remove() permite a remoção de um nó de um diagrama.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Interface IGlobalLayoutSlideCollection e Classe GlobalLayoutSlideCollection**
A interface IGlobalLayoutSlideCollection e a classe GlobalLayoutSlideCollection foram adicionadas ao namespace Aspose.Slides.

A classe GlobalLayoutSlideCollection implementa a interface IGlobalLayoutSlideCollection.

A interface IGlobalLayoutSlideCollection representa uma coleção de todos os slides de layout em uma apresentação. A propriedade IPresentation.LayoutSlides é do tipo IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection estende a interface ILayoutSlideCollection com métodos para adicionar e clonar slides de layout no contexto da união das coleções individuais de slides de layout de mestres:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Pode ser usado para adicionar uma cópia de um slide de layout especificado à apresentação. Este método preserva a formatação original (ao clonar um layout entre apresentações diferentes, o mestre do layout também pode ser clonado. O registro interno é usado para rastrear mestres clonados automaticamente e evitar a criação de múltiplos clones do mesmo slide mestre.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Usado para adicionar uma cópia de um slide de layout especificado a uma apresentação. O novo layout será vinculado ao mestre definido na apresentação de destino. Esta opção é análoga a copiar ou colar com a opção **Use Destination Theme** no Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Usado para adicionar um novo slide de layout a uma apresentação. Tipos de layout suportados: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. O nome do layout pode ser gerado automaticamente. Um layout adicionado do tipo SlideLayoutType.Custom não contém placeholders nem formas. Um análogo deste método é o método IMasterLayoutSlideCollection.Add(SlideLayoutType, string) acessado através da propriedade IMasterSlide.LayoutSlides.
#### **Interface IMasterLayoutSlideCollection e Classe MasterLayoutSlideCollection**
A interface IMasterLayoutSlideCollection e a classe MasterLayoutSlideCollection foram adicionadas ao namespace Aspose.Slides. A classe MasterLayoutSlideCollection implementa a interface IMasterLayoutSlideCollection.

A interface IMasterLayoutSlideCollection representa uma coleção de todos os slides de layout de um slide mestre definido. Ela estende a interface ILayoutSlideCollection com métodos para adicionar, inserir, remover ou clonar slides de layout no contexto das coleções individuais de slides de layout de um mestre:

``` csharp

 // Assinatura do método:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Exemplo de código que anexa a cópia do sourceLayout ao destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

O método pode ser usado para adicionar uma cópia de um slide de layout especificado ao final da coleção. O novo layout será vinculado ao slide mestre pai desta coleção de slides de layout. Portanto, isto é análogo a copiar ou colar com a opção **Use Destination Theme** no PowerPoint. O análogo deste método é o método IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) acessado através da propriedade IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Usado para inserir uma cópia de um slide de layout especificado em uma posição determinada da coleção. O novo layout será vinculado ao slide mestre pai desta coleção de slides de layout. Portanto, isto é análogo a copiar e colar com a opção **Use Destination Theme** no PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Usado para adicionar ou inserir um novo slide de layout. Tipos de layout suportados: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. O nome do layout pode ser gerado automaticamente. O layout adicionado do tipo SlideLayoutType.Custom não contém placeholders nem formas. Um análogo deste método é o método IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) acessado através da propriedade IPresentation.LayoutSlides.
- void RemoveAt(int index); – Usado para remover o layout no índice especificado da coleção.
- void Reorder(int index, ILayoutSlide layoutSlide); – Usado para mover o slide de layout dentro da coleção para a posição especificada.
### **Métodos e Propriedades Alterados**
#### **Assinatura do Método Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
A assinatura do método ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

agora está obsoleta e foi substituída pela assinatura

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

O parâmetro allowCloneMissingLayout especifica o que fazer caso não exista um layout apropriado no destMaster para o novo slide (clonado). O layout apropriado é aquele com o mesmo tipo ou nome do layout do slide de origem. Se não houver um layout apropriado no mestre especificado, o layout do slide de origem será clonado (se allowCloneMissingLayout for true) ou será lançada uma PptxEditException (se allowCloneMissingLayout for false).

Uma chamada ao método obsoleto como

AddClone(sourceSlide, destMaster);

presume que allowCloneMissingLayout seja false (ou seja, uma PptxEditException será lançada se não houver um layout apropriado). Uma chamada funcionalmente idêntica que usa a nova assinatura fica assim:
AddClone(sourceSlide, destMaster, false);

Se desejar que layouts ausentes sejam clonados automaticamente em vez de lançar PptxEditException, passe o parâmetro allowCloneMissingLayout como true.

O mesmo se aplica ao método ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

também está obsoleto e foi substituído pela assinatura

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Tipo da Propriedade Aspose.Slides.IMasterSlide.LayoutSlides**
O tipo da propriedade Aspose.Slides.IMasterSlide.LayoutSlides foi alterado de ILayoutSlideCollection para a nova interface IMasterLayoutSlideCollection. A interface IMasterLayoutSlideCollection é descendente de ILayoutSlideCollection, portanto o código existente não precisa de adaptações.
#### **Tipo da Propriedade Aspose.Slides.IPresentation.LayoutSlides Foi Alterado**
O tipo da propriedade Aspose.Slides.IPresentation.LayoutSlides foi alterado de ILayoutSlideCollection para a nova interface IGlobalLayoutSlideCollection. A interface IGlobalLayoutSlideCollection é descendente de ILayoutSlideCollection, portanto o código existente não precisa de adaptações.