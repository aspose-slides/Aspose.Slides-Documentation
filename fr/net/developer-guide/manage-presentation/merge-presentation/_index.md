---
title: Fusionner efficacement des présentations en .NET
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/net/merge-presentation/
keywords:
- fusionner PowerPoint
- fusionner présentations
- fusionner diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner présentations
- combiner diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- .NET
- C#
- Aspose.Slides
description: "Fusionnez facilement les présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) avec Aspose.Slides pour .NET, simplifiant votre flux de travail."
---

## **Optimisez la fusion de vos présentations**

Avec [Aspose.Slides for .NET](https://products.aspose.com/slides/net/), combinez sans effort les présentations PowerPoint tout en préservant les styles, les mises en page et tous les éléments. Contrairement à d’autres outils, Aspose.Slides assimile les présentations sans compromettre la qualité ni perdre de données. Fusionnez des présentations entières, des diapositives spécifiques, et même différents formats de fichiers (PPT en PPTX, etc.).

### **Fonctionnalités de fusion**

- **Fusion complète de présentation :** Assemblez toutes les diapositives dans un seul fichier.  
- **Fusion de diapositives spécifiques :** Choisissez et combinez les diapositives sélectionnées.  
- **Fusion inter‑format :** Intégrez des présentations de formats variés tout en conservant leur intégrité.  

{{% alert title="Tip" color="primary" %}}  

Vous cherchez un outil en ligne rapide et **gratuit** pour **fusionner des présentations PowerPoint** ? Essayez le [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).  

- **Fusionnez facilement les fichiers PowerPoint** : combinez plusieurs présentations **PPT, PPTX, ODP** en un seul fichier.  
- **Prise en charge de différents formats** : fusionnez **PPT en PPTX**, **PPTX en ODP**, et plus encore.  
- **Aucune installation requise** : fonctionne directement dans votre navigateur, rapide et sécurisé.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Commencez à fusionner vos fichiers PowerPoint avec l'**outil gratuit en ligne d'Aspose** dès aujourd'hui !  

{{% /alert %}}

## **Fusion de présentations**

Lorsque vous [fusionnez une présentation avec une autre](https://products.aspose.com/slides/net/merger/ppt/), vous combinez effectivement leurs diapositives dans une seule présentation afin d'obtenir un fichier unique. 

{{% alert title="Info" color="info" %}}

La plupart des programmes de présentation (PowerPoint ou OpenOffice) ne disposent pas de fonctions permettant aux utilisateurs de combiner les présentations de cette manière. 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) , cependant, vous permet de fusionner des présentations de différentes façons. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, mise en forme, commentaires, animations, etc., sans craindre de perte de qualité ou de données. 

**Voir aussi**

[Clone Slides](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Ce qui peut être fusionné**

Avec Aspose.Slides, vous pouvez fusionner 

* des présentations entières. Toutes les diapositives des présentations se retrouvent dans une seule présentation  
* des diapositives spécifiques. Les diapositives sélectionnées se retrouvent dans une seule présentation  
* des présentations d’un même format (PPT en PPT, PPTX en PPTX, etc.) et de formats différents (PPT en PPTX, PPTX en ODP, etc.) entre elles.  

{{% alert title="Note" color="warning" %}} 

En plus des présentations, Aspose.Slides vous permet de fusionner d’autres fichiers :

* [Images](https://products.aspose.com/slides/net/merger/image-to-image/), comme [JPG en JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) ou [PNG en PNG](https://products.aspose.com/slides/net/merger/png-to-png/)  
* Documents, comme [PDF en PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) ou [HTML en HTML](https://products.aspose.com/slides/net/merger/html-to-html/)  
* Et deux fichiers différents tels que [image en PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) ou [JPG en PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) ou [TIFF en PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/).  

{{% /alert %}}

### **Options de fusion**

Vous pouvez appliquer des options qui déterminent si

* chaque diapositive de la présentation de sortie conserve un style unique  
* un style spécifique est utilisé pour toutes les diapositives de la présentation de sortie.  

Pour fusionner des présentations, Aspose.Slides fournit les méthodes [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) (de l’interface [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)). Il existe plusieurs implémentations des méthodes `AddClone` qui définissent les paramètres du processus de fusion des présentations. Chaque objet Presentation possède une collection [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), vous pouvez donc appeler une méthode `AddClone` depuis la présentation dans laquelle vous souhaitez fusionner des diapositives.  

La méthode `AddClone` renvoie un objet `ISlide`, qui est un clone de la diapositive source. Les diapositives d’une présentation de sortie sont simplement une copie des diapositives de la source. Ainsi, vous pouvez modifier les diapositives résultantes (par exemple appliquer des styles, des options de mise en forme ou des mises en page) sans vous soucier d’affecter les présentations sources.  

## **Fusionner des présentations**

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


## **Fusionner des présentations avec le maître de diapositive**

Aspose.Slides fournit la méthode [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) qui vous permet de combiner des diapositives tout en appliquant un modèle maître de présentation. Ainsi, si nécessaire, vous pouvez modifier le style des diapositives dans la présentation de sortie.  

Ce code en C# illustre l’opération décrite :
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

La mise en page de la diapositive maître est déterminée automatiquement. Lorsqu’aucune mise en page appropriée ne peut être déterminée, si le paramètre booléen `allowCloneMissingLayout` de la méthode `AddClone` est défini sur true, la mise en page de la diapositive source est utilisée. Sinon, une [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) sera levée.  

{{% /alert %}}

Si vous souhaitez que les diapositives de la présentation de sortie aient une mise en page différente, utilisez la méthode [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) lors de la fusion.  

## **Fusionner des diapositives spécifiques à partir de présentations**

La fusion de diapositives spécifiques provenant de plusieurs présentations est utile pour créer des ensembles de diapositives personnalisés. Aspose.Slides for .NET vous permet de sélectionner et d’importer uniquement les diapositives dont vous avez besoin. L’API préserve le formatage, la mise en page et le design des diapositives d’origine.  

Le code C# suivant crée une nouvelle présentation, ajoute des diapositives de titre provenant de deux autres présentations, puis enregistre le résultat dans un fichier :
```cs
using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}
```

```cs
static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```


## **Fusionner des présentations avec mise en page de diapositive**

Ce code C# vous montre comment combiner des diapositives de présentations tout en appliquant la mise en page de diapositive de votre choix pour obtenir une présentation unique :
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


## **Fusionner des présentations avec des tailles de diapositive différentes**

{{% alert title="Note" color="warning" %}} 

Vous ne pouvez pas fusionner des présentations ayant des tailles de diapositive différentes. 

{{% /alert %}}

Pour fusionner 2 présentations avec des tailles de diapositive différentes, vous devez redimensionner l’une des présentations afin que sa taille corresponde à celle de l’autre présentation.  

Ce code d’exemple illustre l’opération décrite :
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


## **Fusionner des diapositives dans une section de présentation**

Ce code C# vous montre comment fusionner une diapositive spécifique dans une section d’une présentation :
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

{{% alert title="Tip" color="primary" %}}

Aspose propose une [application web GRATUITE Collage](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc.  

{{% /alert %}}

## **FAQ**

**Les notes du présentateur sont‑elles conservées lors de la fusion ?**

Oui. Lors du clonage des diapositives, Aspose.Slides conserve tous les éléments de la diapositive, y compris les notes, le formatage et les animations.

**Les commentaires et leurs auteurs sont‑ils transférés ?**

Les commentaires, en tant que partie du contenu de la diapositive, sont copiés avec la diapositive. Les étiquettes d’auteur des commentaires sont conservées sous forme d’objets commentaire dans la présentation résultante.

**Que se passe‑t‑il si la présentation source est protégée par un mot de passe ?**

Elle doit être [ouverte avec le mot de passe](/slides/fr/net/password-protected-presentation/) via [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/); après le chargement, ces diapositives peuvent être clonées en toute sécurité dans un fichier cible non protégé (ou également protégé).

**Quel est le niveau de thread‑safety de l’opération de fusion ?**

N’utilisez pas la même instance [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/net/multithreading/). La règle recommandée est « un document — un thread » ; des fichiers différents peuvent être traités en parallèle dans des threads séparés.