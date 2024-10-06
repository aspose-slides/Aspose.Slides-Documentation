---
title: Cloner des Diapositives
type: docs
weight: 40
url: /net/clone-slides/
keywords: "Cloner une diapositive, Copier une diapositive, Sauvegarder une copie de diapositive, PowerPoint, Présentation, C#, Csharp, .NET, Aspose.Slides"
description: "Cloner une diapositive PowerPoint en C# ou .NET"
---

## **Cloner des Diapositives dans une Présentation**
Le clonage est le processus de création d'une copie ou d'une réplique exacte de quelque chose. Aspose.Slides pour .NET permet également de faire une copie ou un clone de n'importe quelle diapositive et ensuite d'insérer cette diapositive clonée dans la présentation actuelle ou dans toute autre présentation ouverte. Le processus de clonage de diapositive crée une nouvelle diapositive qui peut être modifiée par les développeurs sans changer la diapositive originale. Il existe plusieurs façons possibles de cloner une diapositive :

- Cloner à la fin d'une Présentation.
- Cloner à un Autre Emplacement dans la Présentation.
- Cloner à la fin d'une autre Présentation.
- Cloner à un Autre Emplacement dans une autre Présentation.
- Cloner à un emplacement spécifique dans une autre Présentation.

Dans Aspose.Slides pour .NET, (une collection d'objets [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)) exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) fournit les méthodes [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) et [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) pour effectuer les types de clonage de diapositives ci-dessus.

## **Cloner à la Fin d'une Présentation**
Si vous souhaitez cloner une diapositive et ensuite l'utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) selon les étapes énumérées ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en référencant la collection de Diapositives exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et passez la diapositive à cloner en tant que paramètre de la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Écrivez le fichier de présentation modifié.

Dans l'exemple ci-dessous, nous avons cloné une diapositive (située à la première position – index zéro – de la présentation) à la fin de la présentation.

```c#
// Instancier la classe Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Cloner la diapositive désirée à la fin de la collection de diapositives dans la même présentation
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Écrire la présentation modifiée sur le disque
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **Cloner à un Autre Emplacement dans la Présentation**
Si vous souhaitez cloner une diapositive et ensuite l'utiliser dans le même fichier de présentation mais à un autre emplacement, utilisez la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Instanciez la classe en référencant la collection **Slides** exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Appelez la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et passez la diapositive à cloner ainsi que l'index pour le nouvel emplacement en tant que paramètre de la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons cloné une diapositive (située à l'index zéro – position 1 – de la présentation) à l'index 1 – Position 2 – de la présentation.

```c#
// Instancier la classe Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Cloner la diapositive désirée à la fin de la collection de diapositives dans la même présentation
    ISlideCollection slds = pres.Slides;

    // Cloner la diapositive désirée à l'index spécifié dans la même présentation
    slds.InsertClone(2, pres.Slides[1]);

    // Écrire la présentation modifiée sur le disque
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **Cloner à la Fin dans une Autre Présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans un autre fichier de présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en référencant la collection **Slides** exposée par l'objet Presentation de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et passez la diapositive de la présentation source en tant que paramètre de la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple ci-dessous, nous avons cloné une diapositive (de l'index premier de la présentation source) à la fin de la présentation de destination.

```c#
// Instancier la classe Presentation pour charger le fichier de présentation source
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instancier la classe Presentation pour la destination PPTX (où la diapositive doit être clonée)
    using (Presentation destPres = new Presentation())
    {
        // Cloner la diapositive désirée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Écrire la présentation de destination sur le disque
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Cloner à un Autre Emplacement dans une Autre Présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans un autre fichier de présentation, à une position spécifique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation dans laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en référencant la collection de Diapositives exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la présentation de destination.
1. Appelez la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et passez la diapositive de la présentation source ainsi que la position souhaitée en tant que paramètre à la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple ci-dessous, nous avons cloné une diapositive (de l'index zéro de la présentation source) à l'index 1 (position 2) de la présentation de destination.

```c#
// Instancier la classe Presentation pour charger le fichier de présentation source
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instancier la classe Presentation pour la destination PPTX (où la diapositive doit être clonée)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Écrire la présentation de destination sur le disque
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Cloner à un Emplacement Spécifique dans une Autre Présentation**
Si vous devez cloner une diapositive avec une diapositive maître d'une présentation et l'utiliser dans une autre présentation, vous devez d'abord cloner la diapositive maître désirée de la présentation source à la présentation de destination. Ensuite, vous devez utiliser cette diapositive maître pour cloner la diapositive avec la diapositive maître. Le **AddClone(ISlide, IMasterSlide)** attend une diapositive maître de la présentation de destination plutôt que de la présentation source. Pour cloner la diapositive avec un maître, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation de destination à laquelle la diapositive sera clonée.
1. Accédez à la diapositive à cloner ainsi qu'à la diapositive maître.
1. Instanciez la classe [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) en référencant la collection de Maîtres exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l'objet [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) et passez la diapositive maître du PPTX source à cloner en tant que paramètre de la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en réglant la référence à la collection de Diapositives exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et passez la diapositive de la présentation source à cloner et la diapositive maître en tant que paramètre de la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple ci-dessous, nous avons cloné une diapositive avec un maître (située à l'index zéro de la présentation source) à la fin de la présentation de destination en utilisant un maître de la diapositive source.

```c#
// Instancier la classe Presentation pour charger le fichier de présentation source

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instancier la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)
    using (Presentation destPres = new Presentation())
    {

        // Instancier ISlide à partir de la collection de diapositives dans la présentation source avec
        // Diapositive maître
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Cloner la diapositive maître désirée de la présentation source à la collection de maîtres dans la
        // Présentation de destination
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Cloner la diapositive maître désirée de la présentation source à la collection de maîtres dans la
        // Présentation de destination
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Cloner la diapositive désirée de la présentation source avec le maître désiré à la fin de la
        // Collection de diapositives dans la présentation de destination
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Cloner la diapositive maître désirée de la présentation source à la collection de maîtres dans la // Présentation de destination
        // Sauvegarder la présentation de destination sur disque
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```



## Cloner à la Fin dans une Section Spécifiée

Avec Aspose.Slides pour .NET, vous pouvez cloner une diapositive d'une section d'une présentation et insérer cette diapositive dans une autre section de la même présentation. Dans ce cas, vous devez utiliser la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) de l'interface [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection).

Ce code C# vous montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée :

```c#
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