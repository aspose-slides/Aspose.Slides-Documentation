---
title: Substitution de police - API PowerPoint C#
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/net/font-substitution/
keywords:
- police
- police de substitution
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: L'API PowerPoint C# vous permet de substituer des polices à l'intérieur des présentations
---

## **Obtention du remplacement de police**

Pour vous permettre de découvrir les polices de présentation qui sont remplacées lors du processus de rendu d’une présentation, Aspose.Slides fournit la méthode [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) de l’interface [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/).

Le code C# vous montre comment obtenir tous les remplacements de police effectués lorsqu’une présentation est rendue :
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **Définition des règles de remplacement de police**

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu’une police est inaccessible) de la manière suivante :

1. Chargez la présentation concernée.
2. Chargez la police qui sera remplacée.
3. Chargez la nouvelle police.
4. Ajoutez une règle pour le remplacement.
5. Ajoutez la règle à la collection de règles de remplacement de police de la présentation.
6. Générez l’image de la diapositive pour observer l’effet.

Ce code C# illustre le processus de remplacement de police :
```c#
// Charge une présentation
Presentation presentation = new Presentation("Fonts.pptx");

// Charge la police source qui sera remplacée
IFontData sourceFont = new FontData("SomeRareFont");

// Charge la nouvelle police
IFontData destFont = new FontData("Arial");

// Ajoute une règle de police pour le remplacement de police
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Ajoute la règle à la collection de règles de substitution de police
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

Vous voudrez peut‑être consulter [**Remplacement de police**](/slides/fr/net/font-replacement/). 

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre le remplacement de police et le remplacement / substitution de police ?**

[Replacement](/slides/fr/net/font-replacement/) est une substitution forcée d’une police par une autre sur l’ensemble de la présentation. La substitution est une règle qui se déclenche sous une condition spécifique, par exemple lorsque la police d’origine n’est pas disponible, et alors une police de secours désignée est utilisée.

**À quel moment les règles de substitution sont‑elles appliquées ?**

Les règles participent à la séquence standard de [sélection de police](/slides/fr/net/font-selection-sequence/) qui est évaluée lors du chargement, du rendu et de la conversion ; si la police choisie n’est pas disponible, le remplacement ou la substitution est appliqué.

**Quel est le comportement par défaut si aucun remplacement ni aucune substitution n’est configuré et que la police manque sur le système ?**

La bibliothèque tentera de choisir la police système disponible la plus proche, comme le ferait PowerPoint.

**Puis‑je attacher des polices externes personnalisées au moment de l’exécution pour éviter la substitution ?**

Oui. Vous pouvez [ajouter des polices externes](/slides/fr/net/custom-font/) à l’exécution afin que la bibliothèque les prenne en compte pour la sélection et le rendu, y compris pour les conversions ultérieures.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Aspose ne distribue ni polices payantes ni gratuites ; vous ajoutez et utilisez les polices à votre propre discrétion et responsabilité.

**Existe‑t‑il des différences de comportement de substitution sous Windows, Linux et macOS ?**

Oui. La découverte des polices commence à partir des répertoires de polices du système d’exploitation. L’ensemble des polices disponibles par défaut et les chemins de recherche diffèrent selon les plateformes, ce qui affecte la disponibilité et le besoin de substitution.

**Comment préparer l’environnement pour minimiser les substitutions inattendues lors de conversions par lots ?**

Synchronisez l’ensemble de polices entre les machines ou les conteneurs, [ajoutez les polices externes](/slides/fr/net/custom-font/) requises pour les documents de sortie, et [intégrez les polices](/slides/fr/net/embedded-font/) dans les présentations lorsque cela est possible afin que les polices choisies soient disponibles pendant le rendu.