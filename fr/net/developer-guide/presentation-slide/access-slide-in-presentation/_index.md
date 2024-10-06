---
title: Accéder à la diapositive dans la présentation
type: docs
weight: 20
url: /net/access-slide-in-presentation/
keywords: "Accéder à la présentation PowerPoint, Accéder à la diapositive, Modifier les propriétés de la diapositive, Changer la position de la diapositive, Définir le numéro de diapositive, index, ID, position C#, Csharp, .NET, Aspose.Slides"
description: "Accéder à la diapositive PowerPoint par index, ID ou position en C# ou .NET. Modifier les propriétés de la diapositive"
---

Aspose.Slides vous permet d'accéder aux diapositives de deux manières : par index et par ID.

## **Accéder à la diapositive par index**

Toutes les diapositives d'une présentation sont organisées numériquement en fonction de la position de la diapositive en commençant par 0. La première diapositive est accessible via l'index 0 ; la deuxième diapositive est accessible via l'index 1 ; etc.

La classe Presentation, représentant un fichier de présentation, expose toutes les diapositives sous forme de collection [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) (collection d'objets [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)). Ce code C# vous montre comment accéder à une diapositive par son index :

```c#
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Obtient la référence d'une diapositive par son index
ISlide slide = presentation.Slides[0];
```

## **Accéder à la diapositive par ID**

Chaque diapositive dans une présentation a un ID unique qui y est associé. Vous pouvez utiliser la méthode [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) (exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) pour cibler cet ID. Ce code C# vous montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) :

```c#
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Obtient un ID de diapositive
uint id = presentation.Slides[0].SlideId;

// Accède à la diapositive par son ID
IBaseSlide slide = presentation.GetSlideById(id);
```

## **Changer la position de la diapositive**
Aspose.Slides permet de changer la position d'une diapositive. Par exemple, vous pouvez spécifier que la première diapositive doit devenir la deuxième diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence de la diapositive (dont vous souhaitez changer la position) par son index.
1. Définissez une nouvelle position pour la diapositive via la propriété [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/).
1. Enregistrez la présentation modifiée.

Ce code C# démontre une opération dans laquelle la diapositive en position 1 est déplacée en position 2 :

```c#
// Instancie un objet Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Obtient la diapositive dont la position sera changée
    ISlide sld = pres.Slides[0];

    // Définit la nouvelle position pour la diapositive
    sld.SlideNumber = 2;

    // Enregistre la présentation modifiée
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

La première diapositive est devenue la deuxième ; la deuxième diapositive est devenue la première. Lorsque vous changez la position d'une diapositive, les autres diapositives sont automatiquement ajustées.

## **Définir le numéro de diapositive**
À l'aide de la propriété [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) (exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)), vous pouvez spécifier un nouveau numéro pour la première diapositive d'une présentation. Cette opération entraîne le recalcul des numéros des autres diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez le numéro de diapositive.
1. Définissez le numéro de diapositive.
1. Enregistrez la présentation modifiée.

Ce code C# démontre une opération où le numéro de la première diapositive est fixé à 10 :

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

Si vous préférez sauter la première diapositive, vous pouvez commencer la numérotation à partir de la deuxième diapositive (et masquer la numérotation pour la première diapositive) de cette manière :

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Définit le numéro pour la première diapositive de la présentation
    presentation.FirstSlideNumber = 0;

    // Affiche les numéros de diapositive pour toutes les diapositives
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Masque le numéro de diapositive pour la première diapositive
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Enregistre la présentation modifiée
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```