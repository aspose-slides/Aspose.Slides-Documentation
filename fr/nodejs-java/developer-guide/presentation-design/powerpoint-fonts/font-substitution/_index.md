---
title: Configurer la substitution de police dans les présentations à l'aide de JavaScript
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

Le remplacement de police permet à Aspose.Slides d'utiliser une police disponible à la place d'une police qui ne peut pas être accédée lorsque la présentation est rendue ou convertie. Le remplacement affecte la sortie rendue ; il ne modifie pas la police attribuée au contenu de la présentation.

Vous pouvez définir la police à utiliser lorsqu'une police particulière est indisponible, et vous pouvez inspecter les substitutions que Aspose.Slides effectuera pendant le rendu. Cela aide à maintenir une sortie cohérente entre des environnements disposant de polices installées différentes.

Si une police est disponible mais n’a pas de graisse dédiée, voir [Gérer les polices sans graisse dédiée](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Cette section explique comment rastériser le texte affecté lors de l’exportation PDF et les conséquences pour la sélection de texte, la recherche et le redimensionnement.

## **Obtenir les substitutions de police**

Utilisez la méthode [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) pour déterminer quelles polices seront substituées lorsque la présentation est rendue. La méthode renvoie des objets [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) qui identifient les noms de police d'origine et de substitution.

Voici un exemple JavaScript qui liste toutes les substitutions de police pour une présentation :
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

Utilisez la surcharge de [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) avec un tableau d’index de diapositives pour inspecter uniquement les substitutions nécessaires au rendu de diapositives spécifiques. Cela est utile lorsque vous rendez ou exportez une partie d’une présentation, que vous vérifiez une grande présentation de façon incrémentielle, que vous localisez des diapositives dépendant de polices indisponibles, que vous préparez un paquet de polices minimal pour un serveur ou un conteneur, ou que vous diagnostiquez des différences de rendu sans traiter les diapositives non concernées.

La surcharge attend un primitive Java `int[]`. Créez‑le avec `java.newArray("int", [...]) ; un tableau JavaScript simple est converti en `Integer[]` et ne correspond pas à cette surcharge.

Le tableau contient des index de diapositives base‑1 : `1` identifie la première diapositive. En revanche, l’accesseur de collection [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) utilise un index base‑0, de sorte que la même diapositive est accessible via `presentation.getSlides().get_Item(0)`. Gardez cette différence à l’esprit lors de la construction du tableau afin d’éviter les erreurs d’offset.

Appelez la surcharge via [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). Elle ne renvoie que les substitutions déterminées pendant le rendu des diapositives sélectionnées. Chaque résultat est un objet [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) contenant les noms de police d’origine et de substitution. Le résultat reflète l’environnement de police actuel, les règles de secours configurées, les règles de substitution stockées dans une [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) et les [external loaded fonts](/slides/fr/nodejs-java/custom-font/).

La même substitution peut être requise par plusieurs diapositives sélectionnées. Dédupliquez les résultats lorsque vous créez un inventaire de polices ou un rapport de pré‑flight. L’exemple suivant rapporte chaque substitution renvoyée puis crée une liste triée de correspondances de polices uniques :
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

La classe [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) propose les deux surcharges. Choisissez‑en une selon la portée de l’opération de rendu :

| Surcharge | Quand l'utiliser |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) avec aucun argument | Vous avez besoin des substitutions pour l’ensemble de la présentation. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) avec un `int[]` Java d’index de diapositives | Vous avez besoin des substitutions pour une plage sélectionnée, une vérification incrémentielle ou une exportation partielle. |

## **Définir les règles de substitution de police**

1. Charger la présentation.  
2. Créer des définitions de police pour la police source et la police de substitution.  
3. Créer une [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) avec la condition [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/).  
4. Ajouter la règle à une [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/).  
5. Assigner la collection en utilisant la méthode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Rendre ou convertir la présentation.

L’exemple JavaScript suivant substitue `Arial` à `SomeRareFont` lorsque `SomeRareFont` est indisponible, puis rend la première diapositive pour vérifier le résultat. La police de substitution doit être disponible pour Aspose.Slides.
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
Pour un changement inconditionnel des polices utilisées dans toute la présentation, voir [Remplacement de police](/slides/fr/nodejs-java/font-replacement/).
{{% /alert %}}

## **Limites pour les polices d'équations mathématiques**

Les règles de substitution de police font partie du processus standard de sélection des polices utilisé lors du rendu et de la conversion. Elles fonctionnent pour le texte ordinaire lorsque Aspose.Slides peut remplacer une police inaccessible par la police disponible spécifiée par une règle.

Les équations Office Math ont une exigence supplémentaire. Si une équation utilise **Cambria Math**, Aspose.Slides peut avoir besoin de cette police exacte pour calculer et rendre la disposition de l’équation. Une règle qui substitue une autre police mathématique, comme **STIX Two Math**, ne peut pas remplacer **Cambria Math** à cette fin, et le rendu peut encore indiquer que **Cambria Math** est requise.

Pour rendre ou convertir une telle présentation, rendez **Cambria Math** disponible pour Aspose.Slides. Installez‑la dans le système d’exploitation ou chargez‑la comme une [external font](/slides/fr/nodejs-java/custom-font/).

Cette limitation s’applique à la mise en page des équations. Les règles de substitution décrites ci‑dessus restent valables pour le texte ordinaire de la présentation.

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**  
[Remplacement de police](/slides/fr/nodejs-java/font-replacement/) modifie intentionnellement une police en une autre dans toute la présentation. La substitution de police sélectionne une police pour la sortie rendue lorsque la condition configurée est remplie, par exemple lorsque la police d'origine n'est pas disponible.

**Quand les règles de substitution sont appliquées ?**  
Les règles participent à la [font selection sequence](/slides/fr/nodejs-java/font-selection-sequence/) pendant le rendu et la conversion. Avec `WhenInaccessible`, une règle n’est utilisée que lorsque Aspose.Slides ne peut pas accéder à la police source.

**Que se passe‑t‑il lorsqu’une police est manquante et qu’aucune règle de substitution n’est configurée ?**  
Aspose.Slides sélectionne la police disponible la plus proche selon son processus de sélection de police. Le résultat dépend des polices disponibles dans l’environnement d’exécution.

**Puis‑je charger des polices externes pour éviter la substitution ?**  
Oui. Vous pouvez [charger des polices externes](/slides/fr/nodejs-java/custom-font/) afin qu’Aspose.Slides puisse les utiliser pendant le rendu et la conversion.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**  
Non. Vous êtes responsable de fournir les polices et de respecter leurs licences.

**Les résultats de substitution peuvent‑ils différer entre Windows, Linux et macOS ?**  
Oui. Les polices installées et les emplacements de recherche de polices diffèrent selon le système d’exploitation, ainsi une police disponible sur une machine peut nécessiter une substitution sur une autre.

**Comment garantir une sélection de police cohérente lors de conversions par lots ?**  
Utilisez les mêmes fichiers de police et les mêmes versions sur chaque machine ou conteneur, [charger les polices externes requises](/slides/fr/nodejs-java/custom-font/) et [embed fonts](/slides/fr/nodejs-java/embedded-font/) lorsque les licences le permettent. Vous pouvez également appeler [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) avant l’exportation pour identifier les substitutions inattendues.