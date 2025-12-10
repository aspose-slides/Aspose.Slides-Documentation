---
title: Configurer la substitution de polices dans les présentations en .NET
linktitle: Substitution de polices
type: docs
weight: 70
url: /fr/net/font-substitution/
keywords:
- police
- police de substitution
- substitution de police
- remplacement de police
- remplacement de police
- règle de substitution
- règle de remplacement
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Activer une substitution de polices optimale dans Aspose.Slides pour .NET lors de la conversion de présentations PowerPoint et OpenDocument vers d'autres formats de fichiers."
---

## **Obtenir les substitutions de polices**

Pour vous permettre de découvrir les polices de la présentation qui sont substituées lors du processus de rendu d’une présentation, Aspose.Slides fournit la méthode [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) de l’interface [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/).

```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **Définir des règles de substitution de polices**

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu’une police n’est pas accessible) de la manière suivante :

1. Chargez la présentation concernée.  
2. Chargez la police qui sera remplacée.  
3. Chargez la nouvelle police.  
4. Ajoutez une règle de remplacement.  
5. Ajoutez la règle à la collection des règles de substitution de polices de la présentation.  
6. Générez l’image de la diapositive pour observer l’effet.

```c#
// Charge une présentation
Presentation presentation = new Presentation("Fonts.pptx");

// Charge la police source qui sera remplacée
IFontData sourceFont = new FontData("SomeRareFont");

// Charge la nouvelle police
IFontData destFont = new FontData("Arial");

// Ajoute une règle de substitution de police
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Ajoute la règle à la collection des règles de substitution de police
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Ajoute la collection de règles de police à la liste des règles
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Enregistre l'image sur le disque au format JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

Vous pouvez consulter [**Font Replacement**](/slides/fr/net/font-replacement/). 

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Replacement](/slides/fr/net/font-replacement/) est une substitution forcée d’une police par une autre sur l’ensemble de la présentation. La substitution est une règle qui se déclenche sous une condition spécifique, par exemple lorsque la police d’origine n’est pas disponible, et une police de secours désignée est alors utilisée.

**Quand exactement les règles de substitution sont‑elles appliquées ?**

Les règles participent à la séquence standard de [font selection](/slides/fr/net/font-selection-sequence/) qui est évaluée lors du chargement, du rendu et de la conversion ; si la police choisie n’est pas disponible, le remplacement ou la substitution est appliqué.

**Quel est le comportement par défaut si ni remplacement ni substitution n’est configuré et que la police est absente du système ?**

La bibliothèque tentera de choisir la police système la plus proche disponible, de manière similaire à PowerPoint.

**Puis‑je attacher des polices externes personnalisées au moment de l’exécution pour éviter la substitution ?**

Oui. Vous pouvez [add external fonts](/slides/fr/net/custom-font/) au moment de l’exécution afin que la bibliothèque les prenne en compte pour la sélection et le rendu, y compris pour les conversions ultérieures.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Aspose ne distribue aucune police payante ou gratuite ; vous ajoutez et utilisez les polices à votre propre discrétion et responsabilité.

**Existe‑t‑il des différences de comportement de substitution sous Windows, Linux et macOS ?**

Oui. La découverte des polices débute à partir des répertoires de polices du système d’exploitation. L’ensemble des polices disponibles par défaut et les chemins de recherche diffèrent selon les plateformes, ce qui influence la disponibilité et le besoin de substitution.

**Comment préparer l’environnement pour minimiser les substitutions inattendues lors de conversions par lots ?**

Synchronisez l’ensemble de polices entre les machines ou les conteneurs, [add the external fonts](/slides/fr/net/custom-font/) nécessaires pour les documents de sortie, et [embed fonts](/slides/fr/net/embedded-font/) dans les présentations lorsque c’est possible afin que les polices choisies soient disponibles lors du rendu.