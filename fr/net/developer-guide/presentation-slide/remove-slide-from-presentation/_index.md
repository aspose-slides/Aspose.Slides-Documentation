---
title: Supprimer une diapositive de la présentation
type: docs
weight: 30
url: /fr/net/remove-slide-from-presentation/
keywords: "Supprimer diapositive, Effacer diapositive, PowerPoint, Présentation, C#, Csharp, .NET, Aspose.Slides"
description: "Supprimez une diapositive de PowerPoint par référence ou index en C# ou .NET"

---

Si une diapositive (ou son contenu) devient redondant, vous pouvez la supprimer. Aspose.Slides fournit la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) qui encapsule [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), qui est un dépôt pour toutes les diapositives d'une présentation. En utilisant des pointeurs (référence ou index) pour un objet [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) connu, vous pouvez spécifier la diapositive que vous souhaitez supprimer.

## **Supprimer une diapositive par référence**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence de la diapositive que vous souhaitez supprimer via son ID ou Index.
1. Supprimez la diapositive référencée de la présentation.
1. Enregistrez la présentation modifiée.

Ce code C# vous montre comment supprimer une diapositive par sa référence :

```c#
// Instancie un objet Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Accède à une diapositive via son index dans la collection de diapositives
    ISlide slide = pres.Slides[0];

    // Supprime une diapositive par sa référence
    pres.Slides.Remove(slide);

    // Enregistre la présentation modifiée
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Supprimer une diapositive par index**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Supprimez la diapositive de la présentation par sa position index.
1. Enregistrez la présentation modifiée.

Ce code C# vous montre comment supprimer une diapositive par son index :

```c#
// Instancie un objet Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Supprime une diapositive par son index
    pres.Slides.RemoveAt(0);

    // Enregistre la présentation modifiée
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Supprimer une diapositive de disposition inutilisée**

Aspose.Slides fournit la méthode [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (de la classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) pour vous permettre de supprimer des diapositives de disposition indésirables et inutilisées. Ce code C# vous montre comment supprimer une diapositive de disposition d'une présentation PowerPoint :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Supprimer une diapositive maître inutilisée**

Aspose.Slides fournit la méthode [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) pour vous permettre de supprimer des diapositives maîtres indésirables et inutilisées. Ce code C# vous montre comment supprimer une diapositive maîtresse d'une présentation PowerPoint :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```