---
title: Configurer la substitution de police dans les présentations en utilisant PHP
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/php-java/font-substitution/
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
- PHP
- Aspose.Slides
description: "Configurez les règles de substitution de police et inspectez les polices substituées dans Aspose.Slides pour PHP via Java lors du rendu ou de la conversion de présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

La substitution de police permet à Aspose.Slides d'utiliser une police disponible à la place d'une police qui ne peut pas être accessible lorsqu'une présentation est rendue ou convertie. La substitution affecte la sortie rendue ; elle ne modifie pas la police attribuée au contenu de la présentation.

Vous pouvez définir la police à utiliser lorsqu'une police particulière est indisponible, et vous pouvez inspecter les substitutions qu'Aspose.Slides effectuera pendant le rendu. Cela aide à maintenir une sortie cohérente entre des environnements avec des polices installées différentes.

Si une police est disponible mais n'a pas de graisse dédiée, consultez [Gérer les polices sans graisse dédiée](/slides/fr/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Cette section explique comment rasteriser le texte concerné lors de l'exportation en PDF et les conséquences sur la sélection du texte, la recherche et le redimensionnement.

## **Obtenir les substitutions de police**

Utilisez la méthode [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) pour déterminer quelles polices seront substituées lorsque la présentation est rendue. La méthode renvoie des objets [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) qui identifient les noms de police d'origine et de substitution.

L'exemple PHP suivant répertorie toutes les substitutions de police pour une présentation :

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Obtenir les substitutions de police pour les diapositives sélectionnées**

Utilisez la surcharge de [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) avec un argument `int[] slides` pour inspecter uniquement les substitutions requises pour rendre des diapositives spécifiques. Cela est utile lorsque vous rendez ou exportez une partie d'une présentation, vérifiez une grande présentation de façon incrémentielle, localisez les diapositives dépendant de polices indisponibles, préparez un paquet de polices minimal pour un serveur ou un conteneur, ou diagnostiquez des différences de rendu sans traiter les diapositives non concernées.

Le tableau `slides` contient des index de diapositives basés à 1 : `1` identifie la première diapositive. En revanche, l'accesseur de collection [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) utilise un indexage à base zéro, de sorte que la même diapositive est accessible via `$presentation->getSlides()->get_Item(0)`. Gardez cette différence à l'esprit lors de la construction du tableau afin d'éviter les erreurs d'indexation.

Appelez la surcharge via la méthode [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/). Elle ne renvoie que les substitutions déterminées lors du rendu des diapositives sélectionnées. Chaque résultat est un objet [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) contenant les noms de police d'origine et de substitution. Le résultat reflète l'environnement de polices actuel, les règles de repli configurées, les règles de substitution stockées dans une [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/), et les [polices chargées externement](/slides/fr/php-java/custom-font/).

La même substitution peut être requise par plusieurs diapositives sélectionnées. Dédupliquez les résultats lorsque vous créez un inventaire de polices ou un rapport de prévol. L'exemple suivant indique chaque substitution renvoyée, puis crée une liste triée des correspondances de polices uniques :

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

La classe [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) fournit les deux surcharges. Choisissez‑en une en fonction de la portée de l'opération de rendu :

| Surcharge | Utilisez‑la quand |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Vous avez besoin de substitutions pour l'ensemble de la présentation. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | Vous avez besoin de substitutions pour une plage sélectionnée, une vérification incrémentielle ou une exportation partielle. |

## **Définir les règles de substitution de police**

Pour spécifier la police qu'Aspose.Slides doit utiliser lorsqu'une police source est indisponible :

1. Chargez la présentation.
2. Créez les définitions de police pour les polices source et de substitution.
3. Créez une [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) avec la condition [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/).
4. Ajoutez la règle à une [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/).
5. Assignez la collection en utilisant la méthode [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Rendez ou convertissez la présentation.

L'exemple PHP suivant substitue `Arial` à la place de `SomeRareFont` lorsque `SomeRareFont` est indisponible, puis rend la première diapositive pour vérifier le résultat. La police de substitution doit être disponible pour Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Pour un changement inconditionnel des polices utilisées dans toute une présentation, consultez [Remplacement de police](/slides/fr/php-java/font-replacement/).
{{% /alert %}}

## **Limitations pour les polices d'équations mathématiques**

Les règles de substitution de police font partie du processus standard de sélection de police utilisé lors du rendu et de la conversion. Elles fonctionnent pour le texte ordinaire lorsque Aspose.Slides peut remplacer une police inaccessible par la police disponible spécifiée par une règle.

Les équations Office Math ont une exigence supplémentaire. Si une équation utilise **Cambria Math**, Aspose.Slides peut avoir besoin de cette police exacte pour calculer et rendre la mise en page de l'équation. Une règle qui substitue une autre police mathématique, telle que **STIX Two Math**, ne peut pas remplacer **Cambria Math** à cet effet, et le rendu peut toujours indiquer que **Cambria Math** est requis.

Pour rendre ou convertir une telle présentation, rendez **Cambria Math** disponible pour Aspose.Slides. Installez‑la dans le système d'exploitation ou chargez‑la comme une [police externe](/slides/fr/php-java/custom-font/).

Cette limitation s'applique à la mise en page des équations. Les règles de substitution décrites ci‑dessus s'appliquent toujours au texte ordinaire de la présentation.

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**

[Remplacement de police](/slides/fr/php-java/font-replacement/) change intentionnellement une police en une autre dans toute la présentation. La substitution de police sélectionne une police pour la sortie rendue lorsque la condition configurée est remplie, par exemple lorsque la police d'origine est indisponible.

**Quand les règles de substitution sont‑elles appliquées ?**

Les règles participent à la [séquence de sélection de police](/slides/fr/php-java/font-selection-sequence/) lors du rendu et de la conversion. Avec `WhenInaccessible`, une règle est utilisée uniquement lorsque Aspose.Slides ne peut pas accéder à la police source.

**Que se passe‑t‑il lorsqu'une police est manquante et aucune règle de substitution n'est configurée ?**

Aspose.Slides sélectionne la police disponible la plus proche selon son processus de sélection de police. Le résultat dépend des polices disponibles dans l'environnement d'exécution.

**Puis‑je charger des polices externes pour éviter la substitution ?**

Oui. Vous pouvez [charger des polices externes](/slides/fr/php-java/custom-font/) pour que Aspose.Slides les utilise pendant le rendu et la conversion.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Vous êtes responsable de la fourniture des polices et du respect de leurs licences.

**Les résultats de substitution peuvent‑ils différer entre Windows, Linux et macOS ?**

Oui. Les polices installées et les emplacements de recherche des polices diffèrent selon le système d'exploitation, ainsi une police disponible sur une machine peut nécessiter une substitution sur une autre.

**Comment rendre la sélection de police cohérente lors de conversions par lots ?**

Utilisez les mêmes fichiers de police et versions sur chaque machine ou conteneur, [chargez les polices externes requises](/slides/fr/php-java/custom-font/), et [intégrez les polices](/slides/fr/php-java/embedded-font/) lorsque les licences le permettent. Vous pouvez également appeler [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) avant l'exportation pour identifier les substitutions inattendues.