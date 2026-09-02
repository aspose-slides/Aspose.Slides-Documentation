---
title: Configurer la substitution de police dans les présentations avec JavaScript
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/nodejs-java/font-substitution/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Configurer les règles de substitution de police et inspecter les polices substituées dans Aspose.Slides pour Node.js via Java lors du rendu ou de la conversion de présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

La substitution de police permet à Aspose.Slides d'utiliser une police disponible à la place d'une police qui ne peut pas être accédée lorsqu'une présentation est rendue ou convertie. La substitution affecte la sortie rendue ; elle ne modifie pas la police attribuée au contenu de la présentation.

Vous pouvez définir la police à utiliser lorsqu'une police particulière est indisponible, et vous pouvez examiner les substitutions qu'Aspose.Slides effectuera pendant le rendu. Cela permet de maintenir une sortie cohérente entre des environnements disposant de polices installées différentes.

## **Obtenir les substitutions de police**

Utilisez la méthode [FontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) pour déterminer quelles polices seront substituées lors du rendu de la présentation. La méthode renvoie des objets [FontSubstitutionInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsubstitutioninfo/) qui identifient les noms de police d'origine et substitués.

L'exemple JavaScript suivant répertorie toutes les substitutions de police pour une présentation :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Obtenir les substitutions de police pour les diapositives sélectionnées**

Utilisez la surcharge [FontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) avec un tableau d'indices de diapositives pour examiner uniquement les substitutions nécessaires au rendu de diapositives spécifiques. Ceci est utile lorsque vous rendez ou exportez une partie d'une présentation, vérifiez une grande présentation de manière incrémentielle, localisez les diapositives dépendant de polices indisponibles, préparez un paquet de polices minimal pour un serveur ou un conteneur, ou diagnostiquez les différences de rendu sans traiter les diapositives non concernées.

La surcharge attend un primitive Java `int[]`. Créez‑le avec `java.newArray("int", [...])` ; un tableau JavaScript ordinaire est converti en `Integer[]` et ne correspond pas à cette surcharge.

Le tableau contient des indices de diapositives à base 1 : `1` identifie la première diapositive. En revanche, l'accesseur de collection [Presentation.getSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getslides/) utilise un indexation à base 0, de sorte que la même diapositive est accessible comme `presentation.getSlides().get_Item(0)`. Gardez cette différence à l'esprit lors de la construction du tableau afin d'éviter les erreurs d'index hors limites.

Appelez la surcharge via [Presentation.getFontsManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getfontsmanager/). Elle renvoie uniquement les substitutions déterminées lors du rendu des diapositives sélectionnées. Chaque résultat est un objet [FontSubstitutionInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsubstitutioninfo/) contenant les noms de police d'origine et substitués. Le résultat reflète l'environnement de police actuel, les règles de secours configurées, les règles de substitution stockées dans une [FontSubstRuleCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsubstrulecollection/) et les [polices chargées externement](/slides/fr/nodejs-java/custom-font/).

La même substitution peut être requise par plusieurs diapositives sélectionnées. Dédupliquez les résultats lorsque vous créez un inventaire de polices ou un rapport de préflight. L'exemple suivant signale chaque substitution retournée puis crée une liste triée des correspondances de polices uniques :

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

La classe [FontsManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/) fournit les deux surcharges. Choisissez‑en une en fonction de la portée de l'opération de rendu :

| Surcharge | Quand l'utiliser |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Vous avez besoin des substitutions pour l'ensemble de la présentation. |
| [getSubstitutions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | Vous avez besoin des substitutions pour une plage sélectionnée, une vérification incrémentielle ou une exportation partielle. |

## **Définir les règles de substitution de police**

Pour spécifier la police qu'Aspose.Slides doit utiliser lorsqu'une police source est indisponible :

1. Chargez la présentation.
2. Créez les définitions de police pour les polices source et de substitution.
3. Créez une [FontSubstRule](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsubstrule/) avec la condition [WhenInaccessible](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsubstcondition/).
4. Ajoutez la règle à une [FontSubstRuleCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Attribuez la collection en utilisant la méthode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Rendez ou convertissez la présentation.

L'exemple JavaScript suivant substitue `Arial` à la place de `SomeRareFont` lorsque `SomeRareFont` est indisponible, puis rend la première diapositive pour vérifier le résultat. La police de substitution doit être disponible pour Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Pour une modification inconditionnelle des polices utilisées dans toute la présentation, voir [Font Replacement](/slides/fr/nodejs-java/font-replacement/).
{{% /alert %}}

## **Limitations pour les polices d'équations mathématiques**

Les règles de substitution de police font partie du processus standard de sélection des polices utilisé lors du rendu et de la conversion. Elles fonctionnent pour le texte ordinaire lorsque Aspose.Slides peut remplacer une police inaccessible par la police disponible spécifiée par une règle.

Les équations Office Math ont une exigence supplémentaire. Si une équation utilise **Cambria Math**, Aspose.Slides peut avoir besoin de cette police exacte pour calculer et rendre la disposition de l'équation. Une règle qui substitue une autre police mathématique, comme **STIX Two Math**, ne peut pas remplacer **Cambria Math** à cette fin, et le rendu peut toujours indiquer que **Cambria Math** est requise.

Pour rendre ou convertir une telle présentation, rendez **Cambria Math** disponible pour Aspose.Slides. Installez‑la dans le système d'exploitation ou chargez‑la comme [external font](/slides/fr/nodejs-java/custom-font/).

Cette limitation s'applique à la disposition des équations. Les règles de substitution décrites ci‑dessus s'appliquent toujours au texte ordinaire de la présentation.

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Font replacement](/slides/fr/nodejs-java/font-replacement/) change intentionnellement une police en une autre dans toute la présentation. La substitution de police sélectionne une police pour la sortie rendue lorsque la condition configurée est remplie, par exemple lorsque la police d'origine est indisponible.

**Quand les règles de substitution sont‑elles appliquées ?**

Les règles participent à la [font selection sequence](/slides/fr/nodejs-java/font-selection-sequence/) pendant le rendu et la conversion. Avec `WhenInaccessible`, une règle est utilisée uniquement lorsque Aspose.Slides ne peut pas accéder à la police source.

**Que se passe‑t‑il lorsqu'une police est manquante et aucune règle de substitution n'est configurée ?**

Aspose.Slides sélectionne la police disponible la plus proche selon son processus de sélection de police. Le résultat dépend des polices disponibles dans l'environnement d'exécution.

**Puis‑je charger des polices externes pour éviter la substitution ?**

Oui. Vous pouvez [load external fonts](/slides/fr/nodejs-java/custom-font/) afin qu'Aspose.Slides puisse les utiliser pendant le rendu et la conversion.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Vous êtes responsable de fournir les polices et de respecter leurs licences.

**Les résultats de substitution peuvent‑ils différer entre Windows, Linux et macOS ?**

Oui. Les polices installées et les emplacements de recherche de polices diffèrent selon le système d'exploitation, de sorte qu'une police disponible sur une machine peut nécessiter une substitution sur une autre.

**Comment garantir une sélection de police cohérente lors de conversions par lots ?**

Utilisez les mêmes fichiers de polices et versions sur chaque machine ou conteneur, [load required external fonts](/slides/fr/nodejs-java/custom-font/), et [embed fonts](/slides/fr/nodejs-java/embedded-font/) lorsque les licences le permettent. Vous pouvez également appeler [FontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) avant l'exportation pour identifier les substitutions inattendues.