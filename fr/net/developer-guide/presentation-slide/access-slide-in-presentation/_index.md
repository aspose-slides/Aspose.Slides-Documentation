---
title: Accéder à la diapositive dans la présentation
type: docs
weight: 20
url: /fr/net/access-slide-in-presentation/
keywords: "Accéder à la présentation PowerPoint, Accéder à la diapositive, Modifier les propriétés de la diapositive, Modifier la position de la diapositive, Définir le numéro de la diapositive, index, ID, position, C#, Csharp, .NET, Aspose.Slides"
description: "Accéder à la diapositive PowerPoint par index, ID ou position en C# ou .NET. Modifier les propriétés de la diapositive"
---

Aspose.Slides vous permet d'accéder aux diapositives de deux manières : par index et par ID.

## **Accéder à la diapositive par index**

Toutes les diapositives d’une présentation sont numérotées en fonction de leur position, à partir de 0. La première diapositive est accessible via l’index 0 ; la deuxième via l’index 1 ; etc.

La classe Presentation, qui représente un fichier de présentation, expose toutes les diapositives sous forme de collection [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) (collection d’objets [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) ). Ce code C# montre comment accéder à une diapositive via son index :
```c#
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Obtient la référence d'une diapositive via son index
ISlide slide = presentation.Slides[0];
```


## **Accéder à la diapositive par ID**

Chaque diapositive d’une présentation possède un ID unique. Vous pouvez utiliser la méthode [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) (exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) pour cibler cet ID. Ce code C# montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) :
```c#
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Obtient l'ID d'une diapositive
uint id = presentation.Slides[0].SlideId;

// Accède à la diapositive via son ID
IBaseSlide slide = presentation.GetSlideById(id);
```


## **Modifier la position de la diapositive**
Aspose.Slides vous permet de modifier la position d’une diapositive. Par exemple, vous pouvez spécifier que la première diapositive devienne la seconde.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence de la diapositive (dont vous voulez changer la position) via son index
3. Définissez une nouvelle position pour la diapositive via la propriété [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/).
4. Enregistrez la présentation modifiée.

Ce code C# montre une opération où la diapositive en position 1 est déplacée vers la position 2 :
```c#
 // Instancie un objet Presentation qui représente un fichier de présentation
 using (Presentation pres = new Presentation("ChangePosition.pptx"))
 {
     // Obtient la diapositive dont la position sera modifiée
     ISlide sld = pres.Slides[0];
 
     // Définit la nouvelle position de la diapositive
     sld.SlideNumber = 2;
 
     // Enregistre la présentation modifiée
     pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
 }
```


La première diapositive est devenue la seconde ; la seconde diapositive est devenue la première. Lorsque vous modifiez la position d’une diapositive, les autres diapositives sont automatiquement ajustées.

## **Définir le numéro de diapositive**
En utilisant la propriété [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) (exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)), vous pouvez spécifier un nouveau numéro pour la première diapositive d’une présentation. Cette opération entraîne le recalcul des numéros des autres diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez le numéro de la diapositive.
3. Définissez le numéro de la diapositive.
4. Enregistrez la présentation modifiée.

Ce code C# montre une opération où le numéro de la première diapositive est fixé à 10 :
```c#
// Instancie un objet Presentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Obtient le numéro de la diapositive
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Définit le numéro de la diapositive
    presentation.FirstSlideNumber=10;
    
    // Enregistre la présentation modifiée
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```


Si vous préférez ignorer la première diapositive, vous pouvez commencer la numérotation à partir de la deuxième diapositive (et masquer la numérotation pour la première) de cette manière :
```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Définit le numéro de la première diapositive de la présentation
    presentation.FirstSlideNumber = 0;

    // Affiche les numéros de diapositive pour toutes les diapositives
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Masque le numéro de diapositive pour la première diapositive
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Enregistre la présentation modifiée
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Le numéro de diapositive visible par l’utilisateur correspond‑il à l’index zéro‑basé de la collection ?**

Le numéro affiché sur une diapositive peut commencer à une valeur arbitraire (par ex., 10) et ne doit pas obligatoirement correspondre à l’index ; la relation est contrôlée par le paramètre [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) de la présentation.

**Les diapositives masquées affectent‑elles l’indexation ?**

Oui. Une diapositive masquée reste dans la collection et est comptée dans l’indexation ; « masquée » fait référence à l’affichage, pas à sa position dans la collection.

**L’index d’une diapositive change‑t‑il lorsqu‑elles sont ajoutées ou supprimées ?**

Oui. Les index reflètent toujours l’ordre actuel des diapositives et sont recalculés lors des opérations d’insertion, de suppression et de déplacement.