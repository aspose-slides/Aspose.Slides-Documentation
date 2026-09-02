---
title: Gérer les polices de thème spécifiques aux scripts en PHP
linktitle: Polices de thème spécifiques aux scripts
type: docs
weight: 15
url: /fr/php-java/script-specific-font-mappings/
keywords:
- police spécifique au script
- mappage de police de thème
- présentation multilingue
- système d'écriture
- police cyrillique
- police arabe
- police japonaise
- police géorgienne
- police thaana
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Inspecter, ajouter, remplacer et supprimer les mappages de polices spécifiques aux scripts dans les thèmes PowerPoint avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Un thème de présentation peut sélectionner différentes familles de polices pour différents systèmes d'écriture. Cela permet au texte multilingue qui utilise toujours les polices du thème de suivre un schéma de polices coordonné tout en utilisant des polices appropriées pour le cyrillique, l'arabe, le japonais, le géorgien, le thaana et d'autres scripts.

Le [FontScheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontscheme/) du thème contient une collection de polices majeures, généralement utilisée pour les titres, et une collection de polices mineures, généralement utilisée pour le corps du texte. En plus de leurs paramètres de polices latines et d'Asie de l'Est, les deux collections [Fonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fonts/) exposent des mappages des balises de système d'écriture vers les noms de familles de polices.

Cet article montre comment inspecter et modifier ces mappages dans le thème maître de la présentation et vérifier que les modifications survivent à un cycle d'enregistrement et de rechargement.

## **Comprendre les balises de script**

Les méthodes de police de script utilisent des sous‑balises de script BCP 47 à quatre lettres pour identifier les systèmes d'écriture. Les valeurs courantes incluent :

| Balise de script | Système d'écriture |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

Ces mappages appartiennent au schéma de polices du thème, pas aux portions de texte individuelles. Une présentation peut définir différents mappages pour les collections majeures et mineures, et elle peut omettre des mappages pour certains scripts.

## **Accéder et inspecter les mappages de police de script**

Utilisez [Presentation::getMasterTheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getMasterTheme) pour accéder au thème au niveau de la présentation. Les méthodes [MasterTheme::getFontScheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontscheme/#getMajor) et [FontScheme::getMinor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontscheme/#getMinor) donnent accès aux deux collections [Fonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fonts/).

Appelez [Fonts::getScriptFontMap](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fonts/#getScriptFontMap) pour récupérer tous les mappages d'une collection. Pour rechercher un système d'écriture, appelez [Fonts::getScriptFont](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fonts/#getScriptFont) avec sa balise de script. `Fonts::getScriptFont` renvoie `null` lorsque cette collection ne définit pas le mappage demandé.

## **Modifier les mappages et vérifier la persistance**

Utilisez [Fonts::setScriptFont](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fonts/#setScriptFont) pour créer un mappage ou remplacer la famille de polices actuelle. Utilisez [Fonts::removeScriptFont](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fonts/#removeScriptFont) pour supprimer un mappage.

L'exemple de bout en bout suivant lit tous les mappages majeurs et mineurs existants, recherche la police majeure japonaise, modifie la police majeure cyrillique, supprime le mappage mineur thaana, enregistre la présentation et la rouvre pour vérifier les deux modifications. Pour rendre l'étape de suppression indépendante du thème initial, l'exemple crée d'abord un mappage Thaana uniquement lorsqu'aucun n'est déjà défini.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

La vérification utilise le même comportement `null` qu'une recherche ordinaire : après l'enregistrement de la suppression, `Fonts::getScriptFont("Thaa")` renvoie `null` pour la collection mineure.

## **Distinguer les mappages du thème des autres paramètres de police**

Les mappages de thème spécifiques aux scripts participent à la sélection des polices, mais ils résolvent un problème différent de celui du formatage direct du texte, de la substitution et du recours à une police de secours :

| Mécanisme | Objectif | Effet du changement d'un mappage du thème |
|---|---|---|
| Mappage de police du thème spécifique au script | Sélectionne une police majeure ou mineure du thème pour un système d'écriture. | Le texte qui utilise toujours la police du thème correspondante peut se résoudre à la nouvelle famille mappée. |
| Police assignée explicitement à une portion de texte | Fixe la famille de police demandée sur cette portion au lieu de dépendre du thème. | La portion peut rester inchangée car son formatage direct surcharge le choix du thème. |
| Substitution de police | Remplace une police demandée lorsque celle‑ci n’est pas disponible ou lorsqu’une règle de substitution s’applique. | Elle agit après qu’une police a été demandée ; elle ne redéfinit pas le mappage du script du thème. |
| Police de secours | Fournit les glyphes que la police sélectionnée ne contient pas, souvent pour des plages Unicode spécifiques. | Elle comble les lacunes de couverture des glyphes ; elle ne modifie pas le mappage du thème stocké. |

Pour plus d'informations sur les deux derniers mécanismes, voir [Font Substitution](/slides/fr/php-java/font-substitution/) et [Fallback Fonts](/slides/fr/php-java/fallback-font/).

Modifier un mappage dans [Presentation::getMasterTheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getMasterTheme) n'affecte que le contenu dont le formatage effectif dépend encore de ce thème. Le texte peut plutôt hériter d'une substitution de thème depuis un maître, une disposition ou une diapositive, ou utiliser une police assignée explicitement. Inspectez ces niveaux lorsque le résultat visible ne suit pas le mappage au niveau de la présentation.

## **Rendre les polices mappées disponibles et valider le résultat**

Un mappage de script stocke le nom d'une famille de polices ; il n'installe pas et ne charge pas le fichier de police correspondant. Pour un rendu et une exportation cohérents, chaque police mappée doit être installée dans l'environnement ou fournie à Aspose.Slides via une source personnalisée telle que [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsloader/#loadExternalFonts) ou [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Consultez [Custom Fonts](/slides/fr/php-java/custom-font/) pour les options de chargement disponibles.

La vérification du mappage enregistré ne confirme que la préservation de la définition du thème. Elle ne prouve pas que la police est disponible, qu’elle contient tous les glyphes requis, ou qu’elle produit la mise en page prévue. Rendre du texte représentatif pour chaque système d'écriture requis en image ou PDF et inspecter le résultat. Cela détecte les polices manquantes, la couverture de glyphes incomplète, le comportement de secours et les changements de mise en page avant la distribution de la présentation. Voir [Convert PowerPoint Presentations](/slides/fr/php-java/convert-powerpoint/) pour des exemples de rendu et d'exportation.

## **FAQ**

**Que renvoie `Fonts::getScriptFont` lorsqu'un script n'est pas mappé ?**

`[Fonts::getScriptFont](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fonts/#getScriptFont)` renvoie `null` lorsque le mappage du script demandé n'est pas défini dans cette collection de polices majeures ou mineures.

**`Fonts::setScriptFont` ajoute-t-il un deuxième mappage lorsque le script existe déjà ?**

Non. `[Fonts::setScriptFont](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fonts/#setScriptFont)` crée le mappage lorsqu'il manque et remplace la famille de polices mappée lorsque la même balise de script est déjà présente.

**Pourquoi la modification d'un mappage du thème n'a-t-elle pas modifié certains textes ?**

Le texte peut avoir une police assignée explicitement, hériter d'un thème différent via une substitution, ou être affecté par la substitution ou le recours à une police de secours lors du rendu. Un mappage de script au niveau de la présentation contrôle uniquement le texte dont le formatage effectif fait encore référence à cette collection de polices du thème.

**Est‑ce que l'enregistrement et la réouverture suffisent à valider la sortie multilingue ?**

Non. La réouverture vérifie la persistance des données du thème. Il faut également rendre du texte représentatif pour chaque système d'écriture requis afin de confirmer que les polices mappées sont disponibles et contiennent les glyphes nécessaires.