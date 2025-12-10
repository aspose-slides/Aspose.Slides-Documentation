---
title: Cloner les diapositives de présentation en .NET
linktitle: Cloner des diapositives
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
description: "Duplication rapide des diapositives PowerPoint avec Aspose.Slides pour .NET. Suivez nos exemples de code clairs pour automatiser la création de PPT en quelques secondes et éliminer le travail manuel."
---

## **Cloner les diapositives dans une présentation**
Le clonage est le processus de création d’une copie exacte ou d’un replica d’un élément. Aspose.Slides for .NET permet également de créer une copie ou un clone de n’importe quelle diapositive, puis d’insérer cette diapositive clonée dans la présentation actuelle ou dans toute autre présentation ouverte. Le processus de clonage de diapositives crée une nouvelle diapositive qui peut être modifiée par les développeurs sans modifier la diapositive originale. Il existe plusieurs manières de cloner une diapositive :

- Cloner à la fin d’une présentation.
- Cloner à une autre position dans la même présentation.
- Cloner à la fin d’une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

Dans Aspose.Slides for .NET, (une collection d’objets [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)) exposée par l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) fournit les méthodes [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) et [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) pour effectuer les types de clonage de diapositives mentionnés ci‑dessus.

## **Cloner une diapositive à la fin d’une présentation**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) selon les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en faisant référence à la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
3. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et transmettez la diapositive à cloner en paramètre de la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
4. Enregistrez le fichier de présentation modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive (située à la première position – indice zéro – de la présentation) à la fin de la présentation.
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


## **Cloner une diapositive à une autre position dans une présentation**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation mais à une position différente, utilisez la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Instanciez la classe en faisant référence à la collection **Slides** exposée par l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
3. Appelez la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et transmettez la diapositive à cloner ainsi que l’indice de la nouvelle position en paramètre de la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
4. Enregistrez la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive (située à l’indice zéro – position 1 – de la présentation) à l’indice 1 – position 2 – de la présentation.
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


## **Cloner une diapositive à la fin d’une autre présentation**
Si vous devez cloner une diapositive d’une présentation et l’utiliser dans un autre fichier de présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation depuis laquelle la diapositive sera clonée.
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
3. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en faisant référence à la collection **Slides** exposée par l’objet Presentation de la présentation de destination.
4. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et transmettez la diapositive de la présentation source en paramètre de la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
5. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (à partir du premier indice de la présentation source) à la fin de la présentation de destination.
```c#
 // Instancier la classe Presentation pour charger le fichier de présentation source
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    using (Presentation destPres = new Presentation())
    {
        // Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives de la présentation de destination
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Enregistrer la présentation de destination sur le disque
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Cloner une diapositive à une autre position dans une autre présentation**
Si vous devez cloner une diapositive d’une présentation et l’utiliser dans un autre fichier de présentation, à une position spécifique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation source depuis laquelle la diapositive sera clonée.
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation à laquelle la diapositive sera ajoutée.
3. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en faisant référence à la collection Slides exposée par l’objet Presentation de la présentation de destination.
4. Appelez la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et transmettez la diapositive de la présentation source ainsi que la position souhaitée en paramètre de la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
5. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (à partir de l’indice zéro de la présentation source) à l’indice 1 (position 2) de la présentation de destination.
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


## **Cloner une diapositive à une position spécifique dans une autre présentation**
Si vous devez cloner une diapositive avec une diapositive maître d’une présentation et l’utiliser dans une autre présentation, vous devez d’abord cloner la diapositive maître souhaitée de la présentation source vers la présentation de destination. Ensuite, utilisez cette diapositive maître pour cloner la diapositive avec maître. La méthode **AddClone(ISlide, IMasterSlide)** attend une diapositive maître provenant de la présentation de destination et non de la source. Pour cloner la diapositive avec maître, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation source depuis laquelle la diapositive sera clonée.
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation de destination vers laquelle la diapositive sera clonée.
3. Accédez à la diapositive à cloner ainsi qu’à sa diapositive maître.
4. Instanciez la classe [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) en faisant référence à la collection Masters exposée par l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la présentation de destination.
5. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l’objet [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) et transmettez le maître du PPTX source à cloner en paramètre de la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
6. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en définissant la référence à la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la présentation de destination.
7. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) exposée par l’objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et transmettez la diapositive de la présentation source à cloner ainsi que la diapositive maître en paramètre de la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
8. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive avec maître (située à l’indice zéro de la présentation source) à la fin de la présentation de destination en utilisant le maître de la diapositive source.
```c#
// Instancier la classe Presentation pour charger le fichier de présentation source

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instancier la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)
    using (Presentation destPres = new Presentation())
    {

        // Instancier ISlide à partir de la collection de diapositives de la présentation source ainsi que
        // la diapositive maître
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres de la
        // présentation de destination
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres de la
        // présentation de destination
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Cloner la diapositive souhaitée de la présentation source avec le maître désiré à la fin de la
        // collection de diapositives de la présentation de destination
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres de la // présentation de destination
        // Enregistrer la présentation de destination sur le disque
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```


## **Cloner une diapositive à la fin d’une section spécifiée**
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

**Les notes du présentateur et les commentaires des réviseurs sont-ils clonés ?**

Oui. La page de notes et les commentaires de révision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez‑les](/slides/fr/net/presentation-notes/) après l’insertion.

**Comment les graphiques et leurs sources de données sont‑ils gérés ?**

L’objet du graphique, son formatage et les données intégrées sont copiés. Si le graphique était lié à une source externe (par ex., un classeur OLE intégré), ce lien est conservé sous forme d’[objet OLE](/slides/fr/net/manage-ole/). Après le déplacement entre fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

**Puis‑je contrôler la position d’insertion et les sections du clone ?**

Oui. Vous pouvez insérer le clone à un indice de diapositive spécifique et le placer dans une [section](/slides/fr/net/slide-section/) choisie. Si la section cible n’existe pas, créez‑la d’abord puis déplacez la diapositive dedans.