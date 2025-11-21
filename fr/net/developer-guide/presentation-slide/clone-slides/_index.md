---
title: "Cloner des diapositives"
type: docs
weight: 40
url: /fr/net/clone-slides/
keywords: "Cloner diapositive, Copier diapositive, Enregistrer la copie de diapositive, PowerPoint, Présentation, C#, Csharp, .NET, Aspose.Slides"
description: "Cloner une diapositive PowerPoint en C# ou .NET"
---

## **Cloner des diapositives dans la présentation**
Le clonage est le processus consistant à créer une copie exacte ou une réplique de quelque chose. Aspose.Slides for .NET permet également de créer une copie ou un clone de n'importe quelle diapositive, puis d'insérer cette diapositive clonée dans la présentation actuelle ou dans toute autre présentation ouverte. Le processus de clonage de diapositive crée une nouvelle diapositive qui peut être modifiée par les développeurs sans altérer la diapositive originale. Il existe plusieurs façons possibles de cloner une diapositive :

- Cloner à la fin dans une présentation.
- Cloner à une autre position dans la même présentation.
- Cloner à la fin dans une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

Dans Aspose.Slides for .NET, (une collection d'[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) objets) exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) fournit les méthodes [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) et [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) pour réaliser les types de clonage ci‑dessus.

## **Cloner à la fin dans une présentation**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) selon les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en référencant la collection Slides exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et transmettez la diapositive à cloner en paramètre de la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Enregistrez le fichier de présentation modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive (située à la première position – index zéro – de la présentation) à la fin de la présentation.
```c#
 // Instancier la classe Presentation qui représente un fichier de présentation
 using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
 {
 
     // Cloner la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
     ISlideCollection slds = pres.Slides;
 
     slds.AddClone(pres.Slides[0]);
 
     // Enregistrer la présentation modifiée sur le disque
     pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
 
 }
```


## **Cloner à une autre position dans la même présentation**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation mais à une autre position, utilisez la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Instanciez la classe en référencant la collection **Slides** exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Appelez la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et transmettez la diapositive à cloner ainsi que l’indice de la nouvelle position en paramètres de la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Enregistrez la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (située à l’indice zéro – position 1 – de la présentation) à l’indice 1 – position 2 – de la présentation.
```c#
// Instancier la classe Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Cloner la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    ISlideCollection slds = pres.Slides;

    // Cloner la diapositive souhaitée à l'index spécifié dans la même présentation
    slds.InsertClone(2, pres.Slides[1]);

    // Enregistrer la présentation modifiée sur le disque
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **Cloner à la fin dans une autre présentation**
Si vous devez cloner une diapositive d’une présentation et l’utiliser dans une autre présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation source de la diapositive à cloner.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en référencant la collection **Slides** exposée par l’objet Presentation de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et transmettez la diapositive de la présentation source en paramètre de la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (du premier indice de la présentation source) à la fin de la présentation de destination.
```c#
// Instancier la classe Presentation pour charger le fichier de présentation source
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    using (Presentation destPres = new Presentation())
    {
        // Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Enregistrer la présentation de destination sur le disque
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Cloner à une autre position dans une autre présentation**
Si vous devez cloner une diapositive d’une présentation et l’utiliser dans une autre présentation, à une position spécifique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation source de la diapositive à cloner.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en référencant la collection Slides exposée par l’objet Presentation de la présentation de destination.
1. Appelez la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et transmettez la diapositive de la présentation source ainsi que la position souhaitée en paramètres de la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (de l’indice zéro de la présentation source) à l’indice 1 (position 2) de la présentation de destination.
```c#
// Instancier la classe Presentation pour charger le fichier de présentation source
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Enregistrer la présentation de destination sur le disque
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Cloner à une position spécifique dans une autre présentation**
Si vous devez cloner une diapositive avec une diapositive maître d’une présentation vers une autre, vous devez d’abord cloner la diapositive maître souhaitée de la présentation source vers la présentation de destination. Ensuite, utilisez cette diapositive maître pour cloner la diapositive avec maître. La méthode **AddClone(ISlide, IMasterSlide)** attend une diapositive maître provenant de la présentation de destination et non de la source. Pour cloner la diapositive avec maître, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation source de la diapositive à cloner.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation de destination vers laquelle la diapositive sera clonée.
1. Accédez à la diapositive à cloner ainsi qu’à sa diapositive maître.
1. Instanciez la classe [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) en référencant la collection Masters exposée par l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l’objet [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) et transmettez le maître de la source PPTX à cloner en paramètre de la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en définissant la référence à la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et transmettez la diapositive source à cloner ainsi que la diapositive maître en paramètres de la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive avec maître (située à l’indice zéro de la présentation source) à la fin de la présentation de destination en utilisant un maître provenant de la diapositive source.
```c#
// Instancier la classe Presentation pour charger le fichier de présentation source

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instancier la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)
    using (Presentation destPres = new Presentation())
    {

        // Instancier ISlide à partir de la collection de diapositives de la présentation source ainsi que
        // diapositive maître
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres de la
        // présentation de destination
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres de la
        // présentation de destination
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Cloner la diapositive souhaitée de la présentation source avec le maître souhaité à la fin de la
        // collection de diapositives de la présentation de destination
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans la // présentation de destination
        // Enregistrer la présentation de destination sur le disque
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```


## **Cloner à la fin dans une section spécifiée**

Avec Aspose.Slides for .NET, vous pouvez cloner une diapositive d’une section d’une présentation et insérer cette diapositive dans une autre section de la même présentation. Dans ce cas, vous devez utiliser la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) de l’interface [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection).

Ce code C# montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée :
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


## **FAQ**

**Les notes du présentateur et les commentaires du réviseur sont-ils clonés ?**

Oui. La page de notes et les commentaires de révision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez‑les](/slides/fr/net/presentation-notes/) après l’insertion.

**Comment les graphiques et leurs sources de données sont‑ils gérés ?**

L’objet graphique, son formatage et les données intégrées sont copiés. Si le graphique était lié à une source externe (par ex., un classeur OLE intégré), ce lien est conservé en tant qu’[objet OLE](/slides/fr/net/manage-ole/). Après le déplacement entre fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

**Puis‑je contrôler la position d’insertion et les sections du clone ?**

Oui. Vous pouvez insérer le clone à un indice de diapositive spécifique et le placer dans une [section](/slides/fr/net/slide-section/) choisie. Si la section cible n’existe pas, créez‑la d’abord puis déplacez la diapositive dans celle‑ci.