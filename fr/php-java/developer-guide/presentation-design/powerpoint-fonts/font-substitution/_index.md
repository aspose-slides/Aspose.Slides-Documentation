---
title: Configurer la substitution de polices dans les présentations avec PHP
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/php-java/font-substitution/
keywords:
- police
- police substituée
- substitution de police
- remplacement de police
- remplacement de police
- règle de substitution
- règle de remplacement
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Configurez les règles de substitution de polices et examinez les polices substituées dans Aspose.Slides pour PHP via Java lors du rendu ou de la conversion de présentations PowerPoint et OpenDocument."
---
## **Aperçu**

La substitution de polices permet à Aspose.Slides d’utiliser une police disponible à la place d’une police qui ne peut pas être accédée lorsqu’une présentation est rendue ou convertie. La substitution affecte la sortie rendue ; elle ne modifie pas la police attribuée au contenu de la présentation.

Vous pouvez définir la police à utiliser lorsqu’une police particulière est indisponible, et vous pouvez examiner les substitutions que Aspose.Slides effectuera lors du rendu. Cela aide à garder une sortie cohérente entre des environnements disposant de polices installées différentes.

## **Obtenir les substitutions de polices**

Utilisez la méthode [FontsManager::getSubstitutions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/getsubstitutions/) pour déterminer quelles polices seront substituées lorsque la présentation est rendue. La méthode renvoie des objets [FontSubstitutionInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsubstitutioninfo/) qui identifient les noms de police d'origine et de substitution.

L’exemple PHP suivant répertorie toutes les substitutions de polices pour une présentation :

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

## **Obtenir les substitutions de polices pour les diapositives sélectionnées**

Utilisez la surcharge de [FontsManager::getSubstitutions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/getsubstitutions/) avec un argument `int[] slides` pour n’inspecter que les substitutions requises pour rendre des diapositives spécifiques. Cela est utile lorsque vous rendez ou exportez une partie d’une présentation, vérifiez une grande présentation de façon incrémentielle, localisez les diapositives dépendantes de polices indisponibles, préparez un paquet de polices minimal pour un serveur ou un conteneur, ou diagnostiquer des différences de rendu sans traiter les diapositives non concernées.

Le tableau `slides` contient des index de diapositives basés sur 1 : `1` identifie la première diapositive. En revanche, l’accesseur de collection [Presentation::getSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSlides) utilise un indexation à partir de 0, de sorte que la même diapositive est accédée via `$presentation->getSlides()->get_Item(0)`. Gardez cette différence à l’esprit lors de la construction du tableau afin d’éviter les erreurs d’indice de +1/-1.

Appelez la surcharge via la méthode [Presentation::getFontsManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getFontsManager). Elle ne renvoie que les substitutions déterminées lors du rendu des diapositives sélectionnées. Chaque résultat est un objet [FontSubstitutionInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsubstitutioninfo/) contenant les noms de police d’origine et de substitution. Le résultat reflète l’environnement de police actuel, les règles de secours configurées, les règles de substitution stockées dans une [FontSubstRuleCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsubstrulecollection/) et les [polices chargées externement](/slides/fr/php-java/custom-font/).

La même substitution peut être requise par plusieurs diapositives sélectionnées. Dédupliquez les résultats lorsque vous créez un inventaire de polices ou un rapport de pré‑vol. L’exemple suivant rapporte chaque substitution renvoyée puis crée une liste triée de correspondances de polices uniques :

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

La classe [FontsManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/) fournit les deux surcharges. Choisissez‑en une en fonction de la portée de l’opération de rendu :

| Surcharge | Quand l'utiliser |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/getsubstitutions/) sans arguments | Vous avez besoin des substitutions pour l’ensemble de la présentation. |
| [getSubstitutions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/getsubstitutions/) avec `int[] slides` | Vous avez besoin des substitutions pour une plage sélectionnée, une vérification incrémentielle ou une exportation partielle. |

## **Définir les règles de substitution de polices**

Pour spécifier la police que Aspose.Slides doit utiliser lorsqu’une police source est indisponible :

1. Chargez la présentation.  
2. Créez des définitions de police pour les polices source et de substitution.  
3. Créez une [FontSubstRule](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsubstrule/) avec la condition [WhenInaccessible](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsubstcondition/).  
4. Ajoutez la règle à une [FontSubstRuleCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsubstrulecollection/).  
5. Assignez la collection en utilisant la méthode [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Rendez ou convertissez la présentation.

L’exemple PHP suivant substitue `Arial` à `SomeRareFont` lorsque `SomeRareFont` est indisponible, puis rend la première diapositive pour vérifier le résultat. La police de substitution doit être disponible pour Aspose.Slides.

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
Pour une modification inconditionnelle des polices utilisées dans toute la présentation, consultez [Font Replacement](/slides/fr/php-java/font-replacement/).
{{% /alert %}}

## **Limitations pour les polices d’équations mathématiques**

Les règles de substitution de polices font partie du processus standard de sélection des polices utilisé lors du rendu et de la conversion. Elles fonctionnent pour le texte ordinaire lorsque Aspose.Slides peut remplacer une police inaccessible par la police disponible spécifiée par une règle.

Les équations Office Math ont une exigence supplémentaire. Si une équation utilise **Cambria Math**, Aspose.Slides peut avoir besoin de cette police exacte pour calculer et rendre la mise en forme de l’équation. Une règle qui substitue une autre police mathématique, comme **STIX Two Math**, ne peut pas remplacer **Cambria Math** à cette fin, et le rendu peut toujours indiquer que **Cambria Math** est requis.

Pour rendre ou convertir une telle présentation, rendez **Cambria Math** disponible pour Aspose.Slides. Installez‑la dans le système d’exploitation ou chargez‑la comme une [police externe](/slides/fr/php-java/custom-font/).

Cette limitation s’applique à la mise en forme des équations. Les règles de substitution décrites ci‑dessus restent valables pour le texte ordinaire des présentations.

## **FAQ**

**Quelle est la différence entre le remplacement de police et la substitution de police ?**  
[Font replacement](/slides/fr/php-java/font-replacement/) change intentionnellement une police en une autre dans l’ensemble de la présentation. La substitution de police sélectionne une police pour la sortie rendue lorsque la condition configurée est remplie, par exemple lorsque la police d’origine est indisponible.

**Quand les règles de substitution sont‑elles appliquées ?**  
Les règles participent à la [séquence de sélection des polices](/slides/fr/php-java/font-selection-sequence/) pendant le rendu et la conversion. Avec `WhenInaccessible`, une règle n’est utilisée que lorsque Aspose.Slides ne peut pas accéder à la police source.

**Que se passe‑t‑il lorsqu’une police est manquante et qu’aucune règle de substitution n’est configurée ?**  
Aspose.Slides sélectionne la police disponible la plus proche selon son processus de sélection des polices. Le résultat dépend des polices disponibles dans l’environnement d’exécution.

**Puis‑je charger des polices externes pour éviter la substitution ?**  
Oui. Vous pouvez [charger des polices externes](/slides/fr/php-java/custom-font/) afin qu’Aspose.Slides les utilise pendant le rendu et la conversion.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**  
Non. Vous êtes responsable de fournir les polices et de respecter leurs licences.

**Les résultats de substitution peuvent‑ils différer entre Windows, Linux et macOS ?**  
Oui. Les polices installées et les emplacements de recherche diffèrent selon le système d’exploitation, de sorte qu’une police disponible sur une machine peut nécessiter une substitution sur une autre.

**Comment assurer une sélection de police cohérente lors de conversions par lots ?**  
Utilisez les mêmes fichiers de polices et les mêmes versions sur chaque machine ou conteneur, [chargez les polices externes requises](/slides/fr/php-java/custom-font/), et [intégrez les polices](/slides/fr/php-java/embedded-font/) lorsque les licences le permettent. Vous pouvez également appeler [FontsManager::getSubstitutions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/getsubstitutions/) avant l’exportation pour identifier les substitutions inattendues.