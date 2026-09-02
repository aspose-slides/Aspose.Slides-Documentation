---
title: Cloner les diapositives de présentation en .NET
linktitle: Cloner les diapositives
type: docs
weight: 40
url: /fr/net/clone-slides/
keywords:
- cloner diapositive
- copier diapositive
- enregistrer diapositive
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Dupliquez rapidement les diapositives PowerPoint avec Aspose.Slides pour .NET. Suivez nos exemples de code clairs pour automatiser la création de PPT en quelques secondes et éliminer le travail manuel."
---
## **Introduction**

Le clonage est le processus de création d’une copie exacte ou d’une réplique d’un élément. Aspose.Slides vous permet également de copier (cloner) n’importe quelle diapositive puis d’insérer la diapositive clonée dans la présentation en cours ou dans toute autre présentation ouverte. Le clonage de diapositive crée une nouvelle diapositive que les développeurs peuvent modifier sans affecter la diapositive originale. Il existe plusieurs manières de cloner une diapositive :

- Cloner à la fin d’une présentation.
- Cloner à une autre position dans une présentation.
- Cloner à la fin d’une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner avec sa diapositive maître dans une autre présentation.

Dans Aspose.Slides for .NET, la collection de diapositives (une collection d’objets [ISlide](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/) ) exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) fournit les méthodes [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/addclone/) et [InsertClone](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/insertclone/) pour effectuer les opérations de clonage de diapositives décrites ci‑dessus.

## **Cloner une diapositive à la fin d’une présentation**

Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/methods/addclone/index) selon les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection) en faisant référence à la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection) et transmettez la diapositive à cloner en tant que paramètre de la méthode [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/methods/addclone/index).
1. Enregistrez le fichier de présentation modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive (située à la première position – indice zéro – de la présentation) à la fin de la présentation.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Clonez la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Enregistrez la présentation modifiée sur le disque
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Cloner une diapositive à une autre position dans une présentation**

Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation mais à une position différente, utilisez la méthode [InsertClone](https://reference.aspose.com/slides/fr/net/aspose.slides.ishapecollection/insertclone/methods/1) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
1. Instanciez la classe en faisant référence à la collection **Slides** exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
1. Appelez la méthode [InsertClone](https://reference.aspose.com/slides/fr/net/aspose.slides.ishapecollection/insertclone/methods/1) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection) et transmettez la diapositive à cloner ainsi que l’indice de la nouvelle position en tant que paramètres de la méthode [InsertClone](https://reference.aspose.com/slides/fr/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Enregistrez la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive (située à l’indice 1 – position 2 – de la présentation) à l’indice 2 – position 3 – de la présentation.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Clonez la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    ISlideCollection slds = pres.Slides;

    // Clonez la diapositive souhaitée à l'index spécifié dans la même présentation
    slds.InsertClone(2, pres.Slides[1]);

    // Enregistrez la présentation modifiée sur le disque
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Cloner une diapositive à la fin d’une autre présentation**

Si vous devez cloner une diapositive d’une présentation et l’utiliser dans un autre fichier de présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) contenant la présentation à partir de laquelle la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection) en faisant référence à la collection **Slides** exposée par l’objet Presentation de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection) et transmettez la diapositive de la présentation source en tant que paramètre de la méthode [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/methods/addclone/index).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive (à partir du premier indice de la présentation source) à la fin de la présentation de destination.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation pour charger le fichier de présentation source
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanciez la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    using (Presentation destPres = new Presentation())
    {
        // Clonez la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Enregistrez la présentation de destination sur le disque
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Cloner une diapositive à une autre position dans une autre présentation**

Si vous devez cloner une diapositive d’une présentation et l’utiliser dans un autre fichier de présentation, à une position précise :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) contenant la présentation source à partir de laquelle la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) contenant la présentation à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection) en faisant référence à la collection Slides exposée par l’objet Presentation de la présentation de destination.
1. Appelez la méthode [InsertClone](https://reference.aspose.com/slides/fr/net/aspose.slides.ishapecollection/insertclone/methods/1) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection) et transmettez la diapositive de la présentation source ainsi que la position souhaitée en tant que paramètres de la méthode [InsertClone](https://reference.aspose.com/slides/fr/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (à partir de l’indice zéro de la présentation source) à l’indice 1 (position 2) de la présentation de destination.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation pour charger le fichier de présentation source
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanciez la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Enregistrez la présentation de destination sur le disque
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Cloner une diapositive avec sa diapositive maître dans une autre présentation**

Si vous devez cloner une diapositive avec sa diapositive maître d’une présentation et l’utiliser dans une autre présentation, vous devez d’abord cloner la diapositive maître souhaitée de la présentation source vers la présentation de destination. Ensuite, utilisez cette diapositive maître pour cloner la diapositive avec maître. La méthode **AddClone(ISlide, IMasterSlide)** attend une diapositive maître provenant de la présentation de destination plutôt que de la source. Pour cloner la diapositive avec maître, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) contenant la présentation source à partir de laquelle la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) contenant la présentation de destination vers laquelle la diapositive sera clonée.
1. Accédez à la diapositive à cloner ainsi qu’à sa diapositive maître.
1. Instanciez la classe [IMasterSlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslidecollection) en faisant référence à la collection Masters exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l’objet [IMasterSlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslidecollection) et transmettez le maître du PPTX source à cloner en tant que paramètre de la méthode [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/methods/addclone/index).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection) en définissant la référence à la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection) et transmettez la diapositive de la présentation source à cloner ainsi que la diapositive maître en tant que paramètres de la méthode [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/methods/addclone/index).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive avec son maître (située à l’indice zéro de la présentation source) à la fin de la présentation de destination en utilisant le maître de la diapositive source.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation pour charger le fichier de présentation source

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instanciez la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)
    using (Presentation destPres = new Presentation())
    {

        // Instanciez ISlide à partir de la collection de diapositives de la présentation source ainsi que
        // Diapositive maître
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clonez la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans le
        // Présentation de destination
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clonez la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans le
        // Présentation de destination
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Clonez la diapositive souhaitée de la présentation source avec le maître souhaité à la fin du
        // Collection de diapositives de la présentation de destination
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Clonez la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans le // présentation de destination
        // Enregistrez la présentation de destination sur le disque
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Cloner une diapositive à la fin d’une section spécifiée**

Avec Aspose.Slides for .NET, vous pouvez cloner une diapositive d’une section d’une présentation et insérer cette diapositive dans une autre section de la même présentation. Dans ce cas, vous devez utiliser la méthode [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/methods/addclone/index) de l’interface [ISlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection).

Ce code C# montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // à cloner
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Assurer la correspondance de la taille des diapositives**

Lors du clonage de diapositives dans une autre présentation, assurez‑vous que la présentation de destination a la même taille de diapositive que la source. Si les tailles diffèrent, Aspose.Slides ne redimensionne pas automatiquement les formes clonées — leurs coordonnées et dimensions d’origine sont conservées, ce qui peut entraîner un mauvais alignement du contenu ou un débordement au‑delà des limites de la diapositive.

Vous pouvez définir la taille des diapositives de la présentation de destination pour qu’elle corresponde à celle de la source avant de cloner le maître et la diapositive :

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Faites‑le avant de cloner le maître et la diapositive.

## **FAQ**

**Les notes du présentateur et les commentaires des relecteurs sont‑ils clonés ?**

Oui. La page des notes et les commentaires de révision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez‑les](/slides/fr/net/presentation-notes/) après l’insertion.

**Comment les graphiques et leurs sources de données sont‑ils gérés ?**

L’objet du graphique, son formatage et les données incorporées sont copiés. Si le graphique était lié à une source externe (par exemple, un classeur intégré OLE), ce lien est conservé sous forme d’un [OLE object](/slides/fr/net/manage-ole/). Après le déplacement entre fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

**Puis‑je contrôler la position d’insertion et les sections du clone ?**

Oui. Vous pouvez insérer le clone à un indice de diapositive spécifique et le placer dans une [section](/slides/fr/net/slide-section/) choisie. Si la section cible n’existe pas, créez‑la d’abord puis déplacez la diapositive dedans.