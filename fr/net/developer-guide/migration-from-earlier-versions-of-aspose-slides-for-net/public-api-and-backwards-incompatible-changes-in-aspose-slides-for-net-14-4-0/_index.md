---
title: API publique et changements incompatibles avec les versions antérieures dans Aspose.Slides pour .NET 14.4.0
type: docs
weight: 60
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
---

## **API publique et changements incompatibles avec les versions antérieures**
### **Interfaces, classes, méthodes et propriétés ajoutées**
#### **La propriété Aspose.Slides.ILayoutSlide.HasDependingSlides a été ajoutée**
La propriété Aspose.Slides.ILayoutSlide.HasDependingSlides retourne true s'il existe au moins une diapositive qui dépend de cette diapositive de mise en page. Par exemple :

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Méthode Aspose.Slides.ILayoutSlide.Remove()**
La méthode Aspose.Slides.ILayoutSlide.Remove() permet de supprimer une mise en page d'une présentation avec un minimum de code. Par exemple :

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Méthode Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
La méthode Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) permet de supprimer une mise en page de la collection. Exemples de code :

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
La méthode Aspose.Slides.ILayoutSlideCollection.RemoveUnused() permet de supprimer les diapositives de mise en page inutilisées (les diapositives de mise en page dont HasDependingSlides est false). Exemples de code :

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

ou

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Propriété Aspose.Slides.IMasterSlide.HasDependingSlides**
La propriété Aspose.Slides.IMasterSlide.HasDependingSlides retourne true s'il existe au moins une diapositive qui dépend de cette diapositive maître. Par exemple :

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Méthode Aspose.Slides.ISlide.Remove()**
La méthode Aspose.Slides.ISlide.Remove() permet de supprimer une diapositive d'une présentation avec un minimum de code. Par exemple :

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
La propriété Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat retourne IFillFormat pour une puce de nœud SmartArt si la mise en page fournit des puces. Elle peut être utilisée pour définir l'image de la puce.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Propriété Aspose.Slides.SmartArt.ISmartArtNode.Level**
La propriété Aspose.Slides.SmartArt.ISmartArtNode.Level retourne le niveau imbriqué pour les nœuds SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "Premier niveau";

``` 
#### **Propriété Aspose.Slides.SmartArt.ISmartArtNode.Position**
La propriété Aspose.Slides.SmartArt.ISmartArtNode.Position retourne la position d'un nœud parmi ses frères et sœurs.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Méthode Aspose.Slides.SmartArt.ISmartArtNode.Remove() ajoutée**
La méthode Aspose.Slides.SmartArt.ISmartArtNode.Remove() permet de supprimer un nœud d'un diagramme.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Interface IGlobalLayoutSlideCollection et classe GlobalLayoutSlideCollection**
L'interface IGlobalLayoutSlideCollection et la classe GlobalLayoutSlideCollection ont été ajoutées dans l'espace de noms Aspose.Slides.

La classe GlobalLayoutSlideCollection implémente l'interface IGlobalLayoutSlideCollection.

L'interface IGlobalLayoutSlideCollection représente une collection de toutes les diapositives de mise en page dans une présentation. La propriété IPresentation.LayoutSlides est de type IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection étend l'interface ILayoutSlideCollection avec des méthodes pour ajouter et cloner des diapositives de mise en page dans le contexte de l'union des collections individuelles de diapositives de mise en page des maîtres :

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Peut être utilisée pour ajouter une copie d'une diapositive de mise en page spécifiée à la présentation. Cette méthode conserve le formatage source (lors du clonage d'une mise en page entre différentes présentations, le maître de la mise en page peut également être cloné. Le registre interne est utilisé pour suivre les maîtres clonés automatiquement afin d'éviter la création de plusieurs clones de la même diapositive maître.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Utilisé pour ajouter une copie d'une diapositive de mise en page spécifiée à une présentation. La nouvelle mise en page sera liée au maître défini dans la présentation de destination. Cette option est analogue à copier ou coller avec l'option **Utiliser le thème de destination** dans Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Utilisé pour ajouter une nouvelle diapositive de mise en page à une présentation. Types de mise en page pris en charge : Titre, TitreUniquement, Vide, TitreEtObjet, TexteVertical, TitreEtTexteVertical, DeuxObjets, En-têteDeSection, DeuxTextesEtDeuxObjets, ObjetsDeTitreEtLégende, ImageEtLégende, Personnalisé. Le nom de la mise en page peut être généré automatiquement. Une mise en page ajoutée de type SlideLayoutType.Custom ne contient pas de zones réservées ni de formes. Un analogue de cette méthode est la méthode IMasterLayoutSlideCollection.Add(SlideLayoutType, string) accessible avec la propriété IMasterSlide.LayoutSlides.
#### **Interface IMasterLayoutSlideCollection et classe MasterLayoutSlideCollection**
L'interface IMasterLayoutSlideCollection et la classe MasterLayoutSlideCollection ont été ajoutées à l'espace de noms Aspose.Slides. La classe MasterLayoutSlideCollection implémente l'interface IMasterLayoutSlideCollection.

L'interface IMasterLayoutSlideCollection représente une collection de toutes les diapositives de mise en page d'une diapositive maître définie. Elle étend l'interface ILayoutSlideCollection avec des méthodes pour ajouter, insérer, supprimer ou cloner des diapositives de mise en page dans le contexte des collections individuelles des diapositives de mise en page d'un maître :

``` csharp

 // Signature de la méthode :

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Exemple de code qui attache une copie du sourceLayout au destMasterSlide :

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

La méthode peut être utilisée pour ajouter une copie d'une diapositive de mise en page spécifiée à la fin de la collection. La nouvelle mise en page sera liée à la diapositive maître parente pour cette collection de diapositives de mise en page. Ainsi, cela est analogue à copier ou coller avec l'option **Utiliser le thème de destination** dans PowerPoint. L'analogue de cette méthode est la méthode IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) accessible avec la propriété IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Utilisé pour insérer une copie d'une diapositive de mise en page spécifiée à une position spécifiée de la collection. La nouvelle mise en page sera liée à la diapositive maître parente pour cette collection de diapositives de mise en page. Ainsi, cela est analogue à copier et coller avec l'option **Utiliser le thème de destination** dans PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Utilisé pour ajouter ou insérer une nouvelle diapositive de mise en page. Types de mise en page pris en charge : Titre, TitreUniquement, Vide, TitreEtObjet, TexteVertical, TitreEtTexteVertical, DeuxObjets, En-têteDeSection, DeuxTextesEtDeuxObjets, ObjetsDeTitreEtLégende, ImageEtLégende, Personnalisé. Le nom de la mise en page peut être généré automatiquement. Une mise en page ajoutée de type SlideLayoutType.Custom ne contient pas de zones réservées ni de formes. L'analogue de cette méthode est la méthode IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) accessible avec la propriété IPresentation.LayoutSlides.
- void RemoveAt(int index); – Utilisé pour supprimer la mise en page à l'index spécifié de la collection.
- void Reorder(int index, ILayoutSlide layoutSlide); – Utilisé pour déplacer une diapositive de mise en page de la collection vers la position spécifiée.
### **Méthodes et propriétés modifiées**
#### **Signature de la méthode Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
La signature de la méthode ISlideCollection :
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

est maintenant obsolète et est remplacée par la signature

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Le paramètre allowCloneMissingLayout spécifie que faire s'il n'y a pas de mise en page appropriée dans le destMaster pour la nouvelle diapositive (clonée). La mise en page appropriée est celle avec le même type ou nom que la mise en page de la diapositive source. S'il n'y a pas de mise en page appropriée dans le maître spécifié, alors la mise en page de la diapositive source sera clonée (si allowCloneMissingLayout est true) ou une PptxEditException sera levée (si allowCloneMissingLayout est false).

L'appel de la méthode obsolète comme

AddClone(sourceSlide, destMaster);

suppose que allowCloneMissingLayout est égal à false (c'est-à-dire que PptxEditException sera levée s'il n'y a pas de mise en page appropriée). Un appel fonctionnellement identique qui utilise la nouvelle signature ressemble à ceci :
AddClone(sourceSlide, destMaster, false);

Si vous souhaitez que les mises en page manquantes soient automatiquement clonées au lieu de provoquer une PptxEditException, passez le paramètre allowCloneMissingLayout comme true.

Il en va de même pour la méthode ISlideCollection :

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

est également obsolète maintenant et est remplacée par la signature

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Type de la propriété Aspose.Slides.IMasterSlide.LayoutSlides**
Le type de la propriété Aspose.Slides.IMasterSlide.LayoutSlides a été changé de ILayoutSlideCollection à la nouvelle interface IMasterLayoutSlideCollection. L'interface IMasterLayoutSlideCollection est un descendant de l'interface ILayoutSlideCollection, donc le code existant n'a pas besoin d'adaptations.
#### **Type de la propriété Aspose.Slides.IPresentation.LayoutSlides a été modifié**
Le type de la propriété Aspose.Slides.IPresentation.LayoutSlides a été changé de ILayoutSlideCollection à la nouvelle interface IGlobalLayoutSlideCollection. L'interface IGlobalLayoutSlideCollection est un descendant de l'interface ILayoutSlideCollection, donc le code existant n'a pas besoin d'adaptations.