---
title: Intégrer des polices dans les présentations avec PHP
linktitle: Polices incorporées
type: docs
weight: 40
url: /fr/php-java/embedded-font/
keywords:
- ajouter police
- incorporer police
- incorporation de police
- obtenir police incorporée
- ajouter police incorporée
- supprimer police incorporée
- compresser police incorporée
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Gérez les polices incorporées dans PowerPoint avec Aspose.Slides pour PHP via Java. Ajoutez, récupérez, supprimez et compressez les polices pour préserver l'apparence du texte et réduire la taille du fichier."
---
## **Introduction**

L'incorporation de polices stocke les données de police à l'intérieur d'une présentation PowerPoint. Lorsqu'un visualiseur prend en charge les polices incorporées, il peut afficher le texte en utilisant ces polices même si elles ne sont pas installées sur le système cible. Cela aide à préserver les sauts de ligne, l'espacement du texte et la mise en page des diapositives.

Aspose.Slides for PHP via Java vous permet de récupérer, ajouter et supprimer des polices incorporées via la classe [FontsManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/) retournée par [Presentation::getFontsManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getFontsManager). Vous pouvez également réduire la taille des données de police incorporées en supprimant les caractères que la présentation n'utilise pas.

Les exemples ci-dessous fonctionnent avec des fichiers PPTX. Avant d'incorporer une police, assurez‑vous que ses données de police sont disponibles pour Aspose.Slides et que sa licence autorise l'incorporation.

## **Obtenir et supprimer les polices incorporées**

Utilisez [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) pour lister les polices stockées dans une présentation. Pour en supprimer une, transmettez une police de cette liste à [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont), puis enregistrez la présentation.

L'exemple suivant répertorie les polices incorporées dans `EmbeddedFonts.pptx` et supprime Calibri si elle est présente :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Supprimer une police incorporée supprime ses données de police stockées ; cela ne modifie pas la police attribuée au texte. Si la police est installée sur le système cible, le texte peut toujours l'utiliser. Sinon, le rendu peut nécessiter [font substitution](/slides/fr/php-java/font-substitution/), ce qui peut affecter la mise en page.

## **Inspecter les données de police et les autorisations d'incorporation**

Utilisez la classe [FontsManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/) pour inspecter les polices avant de les incorporer. Appelez [FontsManager::getFonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/#getFonts) pour récupérer les polices utilisées dans la présentation. Pour chaque police, transmettez un objet [FontData](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontdata/) ainsi que la valeur requise de [FontStyleType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontstyletype/) à [FontsManager::getFontBytes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/#getFontBytes). La méthode renvoie les données binaires pour ce style de police, ou `null` lorsque la police ou le style demandé n'est pas disponible. Ne transmettez pas un résultat `null` à [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), car cette méthode nécessite un tableau d'octets.

[EmbeddingLevel](https://reference.aspose.com/slides/fr/php-java/aspose.slides/embeddinglevel/) est une énumération à indicateurs qui indique les restrictions d'incorporation stockées dans la police :

- `Installable` autorise l'incorporation et l'installation permanente sur un autre système, sous réserve de la licence de la police.
- `Restricted` interdit l'incorporation sauf autorisation du titulaire juridique de la police lorsqu'il s'agit du seul indicateur d'autorisation d'utilisation.
- `PreviewPrint` autorise une utilisation temporaire pour la visualisation et l'impression ; le document contenant la police doit être en lecture seule.
- `Editable` autorise une utilisation temporaire et permet au document d'être modifié et enregistré.
- `NoSubsetting` est une restriction supplémentaire qui interdit d'incorporer uniquement un sous‑ensemble des glyphes. Incorporez tous les caractères lorsque cet indicateur est présent.
- `BitmapOnly` est une restriction supplémentaire qui autorise uniquement l'incorporation de rasters bitmap, pas des données de contours. Si la police ne possède aucun raster bitmap, elle ne peut pas être incorporée.

Les quatre premiers indicateurs décrivent l'autorisation d'utilisation, tandis que `NoSubsetting` et `BitmapOnly` peuvent être combinés avec eux. Vérifiez les modificateurs avec des opérations bit à bit. Comme `Installable` vaut zéro, masquez les bits d'autorisation d'utilisation et comparez le résultat à `Installable` au lieu de le tester comme un indicateur. Les polices actuelles doivent définir au plus un bit d'autorisation d'utilisation. Pour la compatibilité avec les anciennes polices qui en définissent plusieurs, l'assistant ci‑dessous sélectionne l'autorisation la moins restrictive : `Editable`, puis `PreviewPrint`, puis `Restricted`.

L'exemple suivant passe en revue les données régulières, gras, italique et gras‑italique disponibles pour chaque police renvoyée par `FontsManager::getFonts`. Il ignore les styles indisponibles, les polices restreintes, les polices bitmap‑only, les polices limitées à l'aperçu et à l'impression (car la sortie reste modifiable) et les polices déjà incorporées. Si un style disponible possède `NoSubsetting`, il incorpore tous les caractères pour cette famille de polices.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Cette inspection signale les restrictions codées dans chaque fichier de police. Elle ne confère aucune licence, ne prouve pas que vous avez obtenu légalement la police, et ne remplace pas la vérification du contrat de licence de la police avant de distribuer une copie incorporée.

## **Ajouter des polices incorporées**

Utilisez [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) pour incorporer une police. Ses surcharges acceptent soit un objet [FontData](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontdata/), soit un tableau d'octets contenant les données de la police. L'énumération [EmbedFontCharacters](https://reference.aspose.com/slides/fr/php-java/aspose.slides/embedfontcharacters/) contrôle quels caractères sont inclus :

- [All](https://reference.aspose.com/slides/fr/php-java/aspose.slides/embedfontcharacters/) incorpore tous les caractères de la police. Utilisez cette option lorsque les destinataires doivent modifier la présentation et saisir du nouveau texte.
- [OnlyUsed](https://reference.aspose.com/slides/fr/php-java/aspose.slides/embedfontcharacters/) incorpore uniquement les caractères utilisés dans la présentation afin de réduire la taille du fichier. Choisissez cette option pour une présentation finalisée principalement destinée à la visualisation.

L'exemple suivant utilise [FontsManager::getFonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/#getFonts) pour récupérer les polices utilisées dans `Fonts.pptx` et incorpore celles qui ne le sont pas déjà. Les polices à ajouter doivent être disponibles sur la machine exécutant le code. Les polices déjà incorporées conservent leurs jeux de caractères actuels.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Compresser les polices incorporées**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/#compressEmbeddedFonts) réduit les données de police incorporées en supprimant les caractères inutilisés. Elle agit sur les polices déjà incorporées, de sorte que la réduction de taille dépend de la quantité de données de police inutilisées présentes dans la présentation.

L'exemple suivant compresse les polices dans `EmbeddedFonts.pptx` et enregistre le résultat dans un fichier séparé :

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Conservez le fichier original si les destinataires peuvent avoir besoin d'ajouter du texte ultérieurement. Les caractères supprimés lors de la compression ne sont plus disponibles dans la police incorporée, même si vous aviez initialement incorporé tous les caractères.

## **FAQ**

**Comment vérifier si une police incorporée sera quand même substituée lors du rendu ?**

Appelez [FontsManager::getSubstitutions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/#getSubstitutions) dans l'environnement où vous effectuez le rendu de la présentation pour voir quelles polices Aspose.Slides remplacera. Vérifiez également les paramètres de [font substitution](/slides/fr/php-java/font-substitution/) et les règles de [font fallback](/slides/fr/php-java/fallback-font/). Le fallback gère les caractères manquants, de sorte qu'incorporer une police ne résout pas les caractères que la police elle‑même ne contient pas.

**Dois‑je incorporer des polices courantes telles qu'Arial et Calibri ?**

Basez la décision sur l'environnement cible. Si les polices requises sont disponibles sur chaque machine ouvrant ou rendant la présentation, les incorporer peut augmenter inutilement la taille du fichier. Si les destinataires ou les serveurs peuvent ne pas disposer de ces polices, les incorporer peut aider à préserver l'aspect prévu, à condition que leurs licences le permettent.