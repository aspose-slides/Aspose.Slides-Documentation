---
title: API publique et modifications incompatibles rétroactives dans Aspose.Slides pour .NET 14.4.0
linktitle: Aspose.Slides pour .NET 14.4.0
type: docs
weight: 60
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentations PowerPoint PPT, PPTX et ODP."
---

## **API publique et modifications incompatibles rétroactives**
### **Interfaces, classes, méthodes et propriétés ajoutées**
#### **La propriété Aspose.Slides.ILayoutSlide.HasDependingSlides a été ajoutée**
La propriété Aspose.Slides.ILayoutSlide.HasDependingSlides renvoie true s'il existe au moins une diapositive qui dépend de cette diapositive de mise en page. Par exemple :

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Méthode Aspose.Slides.ILayoutSlide.Remove()**
La méthode Aspose.Slides.ILayoutSlide.Remove() vous permet de supprimer une mise en page d'une présentation avec un minimum de code. Par exemple :

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Méthode Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
La méthode Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) vous permet de supprimer une mise en page de la collection. Exemples de code :

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
La méthode Aspose.Slides.ILayoutSlideCollection.RemoveUnused() vous permet de supprimer les diapositives de mise en page inutilisées (diapositives dont HasDependingSlides est false). Exemples de code :

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

ou

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Propriété Aspose.Slides.IMasterSlide.HasDependingSlides**
La propriété Aspose.Slides.IMasterSlide.HasDependingSlides renvoie true s'il existe au moins une diapositive qui dépend de cette diapositive maître. Par exemple :

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Méthode Aspose.Slides.ISlide.Remove()**
La méthode Aspose.Slides.ISlide.Remove() vous permet de supprimer une diapositive d'une présentation avec un minimum de code. Par exemple :

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
La propriété Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat renvoie IFillFormat pour le puce d'un nœud SmartArt si la mise en page fournit des puces. Elle peut être utilisée pour définir l'image de la puce.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Propriété Aspose.Slides.SmartArt.ISmartArtNode.Level**
La propriété Aspose.Slides.SmartArt.ISmartArtNode.Level renvoie le niveau imbriqué des nœuds SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Propriété Aspose.Slides.SmartArt.ISmartArtNode.Position**
La propriété Aspose.Slides.SmartArt.ISmartArtNode.Position renvoie la position d'un nœud parmi ses frères et sœurs.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Méthode Aspose.Slides.SmartArt.ISmartArtNode.Remove() a été ajoutée**
La méthode Aspose.Slides.SmartArt.ISmartArtNode.Remove() permet de supprimer un nœud d'un diagramme.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Interface IGlobalLayoutSlideCollection et classe GlobalLayoutSlideCollection**
L'interface IGlobalLayoutSlideCollection et la classe GlobalLayoutSlideCollection ont été ajoutées dans l'espace de noms Aspose.Slides.

La classe GlobalLayoutSlideCollection implémente l'interface IGlobalLayoutSlideCollection.

L'interface IGlobalLayoutSlideCollection représente une collection de toutes les diapositives de mise en page d'une présentation. La propriété IPresentation.LayoutSlides est du type IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection étend l'interface ILayoutSlideCollection avec des méthodes d'ajout et de clonage de diapositives de mise en page dans le contexte de l'union des collections individuelles des diapositives de mise en page du maître :

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Peut être utilisé pour ajouter une copie d'une diapositive de mise en page spécifiée à la présentation. Cette méthode conserve le formatage source (lors du clonage d'une mise en page entre différentes présentations, le maître de la mise en page peut également être cloné. Le registre interne est utilisé pour suivre automatiquement les maîtres clonés afin d'éviter la création de clones multiples du même maître).
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Utilisé pour ajouter une copie d'une mise en page spécifiée à une présentation. La nouvelle mise en page sera liée au maître défini dans la présentation cible. Cette option est analogue à la copie ou au collage avec l'option **Use Destination Theme** dans Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Utilisé pour ajouter une nouvelle diapositive de mise en page à une présentation. Types de mise en page pris en charge : Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Le nom de la mise en page peut être généré automatiquement. Une mise en page ajoutée de type SlideLayoutType.Custom ne contient aucun espace réservé ni aucune forme. Un analogue de cette méthode est la méthode IMasterLayoutSlideCollection.Add(SlideLayoutType, string) accessible via la propriété IMasterSlide.LayoutSlides.
#### **Interface IMasterLayoutSlideCollection et classe MasterLayoutSlideCollection**
L'interface IMasterLayoutSlideCollection et la classe MasterLayoutSlideCollection ont été ajoutées à l'espace de noms Aspose.Slides. La classe MasterLayoutSlideCollection implémente l'interface IMasterLayoutSlideCollection.

L'interface IMasterLayoutSlideCollection représente une collection de toutes les diapositives de mise en page d'un maître défini. Elle étend l'interface ILayoutSlideCollection avec des méthodes d'ajout, d'insertion, de suppression ou de clonage de diapositives de mise en page dans le contexte des collections individuelles des diapositives de mise en page d'un maître :

``` csharp

 // Signature de la méthode :

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Exemple de code qui attache la copie du sourceLayout au destMasterSlide :

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

La méthode peut être utilisée pour ajouter une copie d'une mise en page spécifiée à la fin de la collection. La nouvelle mise en page sera liée au maître parent pour cette collection de diapositives de mise en page. C'est donc l'analogue de la copie ou du collage avec l'option **Use Destination Theme** dans PowerPoint. L'analogue de cette méthode est la méthode IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) accessible via la propriété IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Utilisé pour insérer une copie d'une mise en page spécifiée à la position indiquée de la collection. La nouvelle mise en page sera liée au maître parent pour cette collection de diapositives de mise en page. C'est donc l'analogue de la copie et du collage avec l'option **Use Destination Theme** dans PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Utilisé pour ajouter ou insérer une nouvelle diapositive de mise en page. Types de mise en page pris en charge : Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Le nom de la mise en page peut être généré automatiquement. Une mise en page ajoutée de type SlideLayoutType.Custom ne contient aucun espace réservé ni aucune forme. L'analogue de cette méthode est la méthode IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) accessible via la propriété IPresentation.LayoutSlides.
- void RemoveAt(int index); – Utilisé pour supprimer la mise en page à l'index spécifié de la collection.
- void Reorder(int index, ILayoutSlide layoutSlide); – Utilisé pour déplacer la diapositive de mise en page dans la collection vers la position indiquée.
### **Méthodes et propriétés modifiées**
#### **Signature de la méthode Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
La signature de la méthode ISlideCollection :
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

est désormais obsolète et est remplacée par la signature

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Le paramètre allowCloneMissingLayout indique quoi faire s'il n'existe pas de mise en page appropriée dans destMaster pour la nouvelle diapositive (clonée). La mise en page appropriée est celle qui possède le même type ou le même nom que la mise en page de la diapositive source. S'il n'existe aucune mise en page appropriée dans le maître spécifié, la mise en page de la diapositive source sera clonée (si allowCloneMissingLayout vaut true) ou une PptxEditException sera levée (si allowCloneMissingLayout vaut false).

Un appel de la méthode obsolète tel que

AddClone(sourceSlide, destMaster);

suppose que allowCloneMissingLayout est égal à false (c’est‑à‑dire qu’une PptxEditException sera levée s'il n'y a pas de mise en page appropriée). Un appel fonctionnellement identique utilisant la nouvelle signature ressemble à ceci :
AddClone(sourceSlide, destMaster, false);

Si vous souhaitez que les mises en page manquantes soient automatiquement clonées au lieu de lever une PptxEditException, passez le paramètre allowCloneMissingLayout à true.

Il en va de même pour la méthode ISlideCollection :

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

qui est également obsolète et remplacée par la signature

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Type de la propriété Aspose.Slides.IMasterSlide.LayoutSlides**
Le type de la propriété Aspose.Slides.IMasterSlide.LayoutSlides a été changé de ILayoutSlideCollection en la nouvelle interface IMasterLayoutSlideCollection. L'interface IMasterLayoutSlideCollection dérive de ILayoutSlideCollection, de sorte que le code existant ne nécessite aucune adaptation.
#### **Type de la propriété Aspose.Slides.IPresentation.LayoutSlides a été changé**
Le type de la propriété Aspose.Slides.IPresentation.LayoutSlides a été changé de ILayoutSlideCollection en la nouvelle interface IGlobalLayoutSlideCollection. L'interface IGlobalLayoutSlideCollection dérive de ILayoutSlideCollection, de sorte que le code existant ne nécessite aucune adaptation.