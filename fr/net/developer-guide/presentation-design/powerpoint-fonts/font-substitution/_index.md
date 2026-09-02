---
title: Configurer la substitution de polices dans les présentations en .NET
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/net/font-substitution/
keywords:
- police
- police de substitution
- substitution de police
- remplacer la police
- remplacement de police
- règle de substitution
- règle de remplacement
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Configurer les règles de substitution de polices et examiner les polices substituées dans Aspose.Slides pour .NET lors du rendu ou de la conversion des présentations PowerPoint et OpenDocument."
---
## **Aperçu**

La substitution de polices permet à Aspose.Slides d’utiliser une police disponible à la place d’une police qui ne peut pas être accédée lors du rendu ou de la conversion d’une présentation. La substitution affecte le résultat rendu ; elle ne modifie pas la police attribuée au contenu de la présentation.

Vous pouvez définir la police à utiliser lorsqu’une police donnée est indisponible, et vous pouvez examiner les substitutions que Aspose.Slides effectuera pendant le rendu. Ceci aide à maintenir une sortie cohérente entre des environnements disposant de polices installées différentes.

## **Obtenir les substitutions de polices**

Utilisez la méthode [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsmanager/getsubstitutions/) pour déterminer quelles polices seront substituées lors du rendu de la présentation. La méthode renvoie des objets [FontSubstitutionInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsubstitutioninfo/) qui identifient les noms de police d’origine et de substitution.

L’exemple C# suivant répertorie toutes les substitutions de polices pour une présentation :

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Obtenir les substitutions de polices pour des diapositives sélectionnées**

Utilisez la surcharge de [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsmanager/getsubstitutions/) avec un argument `int[] slides` pour examiner uniquement les substitutions nécessaires au rendu de diapositives spécifiques. Cela est utile lorsque vous rendez ou exportez une partie d’une présentation, que vous vérifiez une grande présentation de façon incrémentielle, que vous localisez des diapositives dépendant de polices indisponibles, que vous préparez un paquet de polices minimal pour un serveur ou un conteneur, ou que vous diagnostiquez des différences de rendu sans traiter les diapositives non concernées.

Le tableau `slides` contient des index de diapositives à base 1 : `1` identifie la première diapositive. En revanche, l’indexeur de la collection [Presentation.Slides](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/slides/fr/) est à base 0, de sorte que la même diapositive est accessible via `presentation.Slides[0]`. Gardez cette différence à l’esprit lors de la création du tableau afin d’éviter les erreurs d’indexation de type « off-by-one ».

Appelez la surcharge via la propriété [Presentation.FontsManager](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/fontsmanager/). Elle renvoie uniquement les substitutions déterminées lors du rendu des diapositives sélectionnées. Chaque résultat est un objet [FontSubstitutionInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsubstitutioninfo/) contenant les noms de police d’origine et de substitution. Le résultat reflète l’environnement de polices actuel, les règles de secours configurées, les règles de substitution stockées dans une [IFontSubstRuleCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsubstrulecollection/) et les [polices chargées externement](/slides/fr/net/custom-font/).

La même substitution peut être requise par plusieurs diapositives sélectionnées. Dédupliquez les résultats lorsque vous créez un inventaire de polices ou un rapport de prévalidation. L’exemple suivant signale chaque substitution renvoyée puis crée une liste triée de correspondances de polices uniques :

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

L’interface [IFontsManager](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsmanager/) propose les deux surcharges. Choisissez‑en une en fonction de la portée de l’opération de rendu :

| Surcharge | Utilisez‑la lorsque |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsmanager/getsubstitutions/) without arguments | Vous avez besoin de substitutions pour l’ensemble de la présentation. |
| [GetSubstitutions](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | Vous avez besoin de substitutions pour une plage sélectionnée, une vérification incrémentielle ou une exportation partielle. |

## **Définir les règles de substitution de polices**

Pour spécifier la police que Aspose.Slides doit utiliser lorsqu’une police source est indisponible :

1. Chargez la présentation.
2. Créez des définitions de police pour les polices source et de substitution.
3. Créez une [FontSubstRule](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsubstrule/) avec la condition [WhenInaccessible](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsubstcondition/).
4. Ajoutez la règle à une [FontSubstRuleCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsubstrulecollection/).
5. Assignez la collection à la propriété [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Rendu ou conversion de la présentation.

L’exemple C# suivant substitue `Arial` à `SomeRareFont` lorsque `SomeRareFont` est indisponible, puis rend la première diapositive pour vérifier le résultat. La police de substitution doit être disponible pour Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
Pour un changement inconditionnel des polices utilisées dans toute la présentation, consultez [Font Replacement](/slides/fr/net/font-replacement/).
{{% /alert %}}

## **Limitations des polices d’équations mathématiques**

Les règles de substitution de polices font partie du processus standard de sélection de police utilisé pendant le rendu et la conversion. Elles fonctionnent pour le texte ordinaire lorsque Aspose.Slides peut remplacer une police inaccessible par la police disponible spécifiée par une règle.

Les équations Office Math ont une exigence supplémentaire. Si une équation utilise **Cambria Math**, Aspose.Slides peut nécessiter cette police exacte pour calculer et rendre la mise en page de l’équation. Une règle qui substitue une autre police mathématique, comme **STIX Two Math**, ne peut pas remplacer **Cambria Math** à cet effet, et le rendu peut toujours indiquer que **Cambria Math** est requise.

Pour rendre ou convertir une telle présentation, rendez **Cambria Math** disponible pour Aspose.Slides. Installez‑la dans le système d’exploitation ou chargez‑la en tant que [police externe](/slides/fr/net/custom-font/).

Cette limitation s’applique à la mise en page des équations. Les règles de substitution décrites ci‑dessus restent valables pour le texte ordinaire de la présentation.

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Font replacement](/slides/fr/net/font-replacement/) modifie intentionnellement une police en une autre dans toute la présentation. La substitution de police sélectionne une police pour le rendu lorsque la condition configurée est remplie, par exemple lorsque la police d’origine est indisponible.

**Quand les règles de substitution sont‑elles appliquées ?**

Les règles participent à la [séquence de sélection de police](/slides/fr/net/font-selection-sequence/) pendant le rendu et la conversion. Avec `WhenInaccessible`, une règle n’est utilisée que lorsque Aspose.Slides ne peut pas accéder à la police source.

**Que se passe‑t‑il lorsqu’une police est manquante et aucune règle de substitution n’est configurée ?**

Aspose.Slides sélectionne la police disponible la plus proche selon son processus de sélection de police. Le résultat dépend des polices disponibles dans l’environnement d’exécution.

**Puis‑je charger des polices externes pour éviter la substitution ?**

Oui. Vous pouvez [charger des polices externes](/slides/fr/net/custom-font/) afin qu’Aspose.Slides puisse les utiliser pendant le rendu et la conversion.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Vous êtes responsable de fournir les polices et de respecter leurs licences.

**Les résultats de substitution peuvent‑ils différer entre Windows, Linux et macOS ?**

Oui. Les polices installées et les emplacements de recherche de police diffèrent selon le système d’exploitation, de sorte qu’une police disponible sur une machine peut nécessiter une substitution sur une autre.

**Comment assurer une sélection de police cohérente lors de conversions en lot ?**

Utilisez les mêmes fichiers de polices et les mêmes versions sur chaque machine ou conteneur, [chargez les polices externes requises](/slides/fr/net/custom-font/), et [intégrez les polices](/slides/fr/net/embedded-font/) lorsque les licences le permettent. Vous pouvez également appeler [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsmanager/getsubstitutions/) avant l’exportation pour identifier les substitutions inattendues.