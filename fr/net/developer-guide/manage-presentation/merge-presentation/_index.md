---
title: Fusionner des présentations PowerPoint PPT, PPTX utilisant C#
linktitle: Fusionner la présentation
type: docs
weight: 40
url: /fr/net/merge-presentation/
keywords: "Fusionner PowerPoint, PPTX, PPT, combiner PowerPoint, fusionner présentation, combiner présentation, C#, Csharp, .NET"
description: "Fusionner ou combiner des présentations PowerPoint en C# ou .NET"
---

{{% alert  title="Astuce" color="primary" %}} 

Vous voudrez peut-être consulter l'application **Aspose gratuite en ligne** [Merger app](https://products.aspose.app/slides/merger). Elle permet aux utilisateurs de fusionner des présentations PowerPoint dans le même format (PPT à PPT, PPTX à PPTX, etc.) et de fusionner des présentations dans différents formats (PPT à PPTX, PPTX à ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Fusion de Présentations**

Lorsque vous [fusionnez une présentation avec une autre](https://products.aspose.com/slides/net/merger/ppt/), vous combinez en effet leurs diapositives dans une seule présentation pour obtenir un fichier. 

{{% alert title="Info" color="info" %}}

La plupart des programmes de présentation (PowerPoint ou OpenOffice) manquent de fonctions permettant aux utilisateurs de combiner des présentations de cette manière. 

Cependant, [**Aspose.Slides pour .NET**](https://products.aspose.com/slides/net/) vous permet de fusionner des présentations de différentes manières. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, formats, commentaires, animations, etc. sans avoir à vous soucier de la perte de qualité ou de données. 

**Voir aussi**

[Clone Slides](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Ce qui Peut Être Fusionné**

Avec Aspose.Slides, vous pouvez fusionner 

* des présentations entières. Toutes les diapositives des présentations se retrouvent dans une seule présentation
* des diapositives spécifiques. Les diapositives sélectionnées se retrouvent dans une seule présentation
* des présentations dans un même format (PPT à PPT, PPTX à PPTX, etc.) et dans différents formats (PPT à PPTX, PPTX à ODP, etc.) les uns avec les autres. 

{{% alert title="Note" color="warning" %}} 

En plus des présentations, Aspose.Slides vous permet de fusionner d'autres fichiers :

* [Images](https://products.aspose.com/slides/net/merger/image-to-image/), telles que [JPG à JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) ou [PNG à PNG](https://products.aspose.com/slides/net/merger/png-to-png/)
* Documents, tels que [PDF à PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) ou [HTML à HTML](https://products.aspose.com/slides/net/merger/html-to-html/)
* Et deux fichiers différents tels que [image à PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) ou [JPG à PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) ou [TIFF à PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Options de Fusion**

Vous pouvez appliquer des options qui déterminent si

* chaque diapositive dans la présentation de sortie conserve un style unique
* un style spécifique est utilisé pour toutes les diapositives dans la présentation de sortie. 

Pour fusionner des présentations, Aspose.Slides fournit des méthodes [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) (de l'interface [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)). Il existe plusieurs implémentations des méthodes `AddClone` qui définissent les paramètres du processus de fusion des présentations. Chaque objet Presentation a une collection [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), donc vous pouvez appeler une méthode `AddClone` depuis la présentation à laquelle vous souhaitez fusionner des diapositives. 

La méthode `AddClone` retourne un objet `ISlide`, qui est un clone de la diapositive source. Les diapositives dans une présentation de sortie sont simplement une copie des diapositives de la source. Par conséquent, vous pouvez apporter des modifications aux diapositives résultantes (par exemple, appliquer des styles ou des options de formatage ou des mises en page) sans vous soucier que les présentations sources soient affectées. 

## **Fusionner des Présentations** 

Aspose.Slides fournit la méthode [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) qui vous permet de combiner des diapositives tout en conservant leurs mises en page et styles (paramètres par défaut). 

Ce code C# vous montre comment fusionner des présentations :

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Fusionner des Présentations avec Master de Diapositive**

Aspose.Slides fournit la méthode [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) qui vous permet de combiner des diapositives tout en appliquant un modèle de présentation de master de diapositive. De cette façon, si nécessaire, vous pouvez changer le style des diapositives dans la présentation de sortie. 

Ce code en C# démontre l'opération décrite :

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}} 

La mise en page de la diapositive pour le master de diapositive est déterminée automatiquement. Lorsqu'une mise en page appropriée ne peut pas être déterminée, si le paramètre booléen `allowCloneMissingLayout` de la méthode `AddClone` est défini sur true, la mise en page de la diapositive source est utilisée. Sinon, une [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) sera levée. 

{{% /alert %}}

Si vous souhaitez que les diapositives dans la présentation de sortie aient une mise en page de diapositive différente, utilisez la méthode [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) à la place lors de la fusion. 

## **Fusionner des Diapositives Spécifiques À Partir de Présentations**

Ce code C# vous montre comment sélectionner et combiner des diapositives spécifiques à partir de différentes présentations pour obtenir une présentation de sortie :

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Fusionner des Présentations Avec Mise en Page de Diapositive**

Ce code C# vous montre comment combiner des diapositives à partir de présentations tout en appliquant votre mise en page de diapositive préférée pour obtenir une présentation de sortie :

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Fusionner des Présentations Avec Différentes Tailles de Diapositive**

{{% alert title="Note" color="warning" %}} 

Vous ne pouvez pas fusionner des présentations avec différentes tailles de diapositive. 

{{% /alert %}}

Pour fusionner 2 présentations avec différentes tailles de diapositive, vous devez redimensionner l'une des présentations pour que sa taille corresponde à celle de l'autre présentation. 

Ce code d'exemple démontre l'opération décrite :

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Fusionner des Diapositives dans une Section de Présentation**

Ce code C# vous montre comment fusionner une diapositive spécifique dans une section d'une présentation :

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

La diapositive est ajoutée à la fin de la section. 

{{% alert title="Astuce" color="primary" %}}

Aspose fournit une [application web gratuite Collage](https://products.aspose.app/slides/collage). Avec ce service en ligne, vous pouvez fusionner des [JPG à JPG](https://products.aspose.app/slides/collage/jpg) ou des images PNG à PNG, créer des [grilles photo](https://products.aspose.app/slides/collage/photo-grid), et plus encore. 

{{% /alert %}}