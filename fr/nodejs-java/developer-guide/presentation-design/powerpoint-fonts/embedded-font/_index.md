---
title: Incorporer des polices dans les présentations en JavaScript
linktitle: Polices incorporées
type: docs
weight: 40
url: /fr/nodejs-java/embedded-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gérez les polices incorporées dans PowerPoint avec Aspose.Slides pour Node.js via Java. Ajoutez, récupérez, supprimez et compressez les polices afin de préserver l'apparence du texte et de réduire la taille du fichier."
---
## **Introduction**

L'incorporation de polices stocke les données de police à l'intérieur d'une présentation PowerPoint. Lorsqu'un visualiseur prend en charge les polices incorporées, il peut afficher le texte en utilisant ces polices même si elles ne sont pas installées sur le système cible. Cela permet de préserver les sauts de ligne, l'espacement du texte et la mise en page des diapositives.

Aspose.Slides for Node.js via Java vous permet de récupérer, d'ajouter et de supprimer des polices incorporées via la classe [FontsManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/) renvoyée par [Presentation.getFontsManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getfontsmanager/). Vous pouvez également réduire la taille des données de police incorporées en supprimant les caractères que la présentation n'utilise pas.

Les exemples ci-dessous fonctionnent avec des fichiers PPTX. Avant d'incorporer une police, assurez-vous que ses données de police sont disponibles pour Aspose.Slides et que sa licence autorise l'incorporation.

## **Obtenir et supprimer les polices incorporées**

Utilisez [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) pour lister les polices stockées dans une présentation. Pour en supprimer une, transmettez une police de cette liste à [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), puis enregistrez la présentation.

L'exemple suivant liste les polices incorporées dans `EmbeddedFonts.pptx` et supprime Calibri si elle est présente :
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

La suppression d'une police incorporée supprime ses données de police stockées ; cela ne modifie pas la police assignée au texte. Si la police est installée sur le système cible, le texte peut toujours l'utiliser. Sinon, le rendu peut nécessiter une [substitution de police](/slides/fr/nodejs-java/font-substitution/), ce qui peut affecter la mise en page.

## **Inspecter les données de police et les autorisations d'incorporation**

Utilisez la classe [FontsManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/) pour inspecter les polices avant de les incorporer. Appelez [FontsManager.getFonts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getfonts/) pour récupérer les polices utilisées dans la présentation. Pour chaque police, transmettez un objet [FontData](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontdata/) et la valeur requise de [FontStyleType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontstyletype/) à [FontsManager.getFontBytes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). La méthode renvoie les données binaires pour ce style de police, ou `null` lorsque la police ou le style demandé n'est pas disponible. Ne transmettez pas un résultat `null` à [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), car cette méthode nécessite un tableau d'octets. Dans Node.js, convertissez le tableau JavaScript retourné en un tableau d'octets Java avec `java.newArray` avant de le passer à `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/embeddinglevel/) indique les restrictions d'incorporation stockées dans la police sous forme d'ensemble de drapeaux :

- `Installable` permet l'incorporation et l'installation permanente sur un autre système, sous réserve de la licence de la police.
- `Restricted` interdit l'incorporation sauf si une autorisation est obtenue auprès du propriétaire légal de la police lorsque c'est le seul drapeau d'autorisation d'utilisation.
- `PreviewPrint` autorise une utilisation temporaire pour la visualisation et l'impression ; un document contenant la police doit être en lecture seule.
- `Editable` autorise une utilisation temporaire et permet que le document soit modifié et enregistré.
- `NoSubsetting` est une restriction supplémentaire qui interdit d'incorporer uniquement un sous-ensemble de glyphes. Incorporez tous les caractères lorsque ce drapeau est présent.
- `BitmapOnly` est une restriction supplémentaire qui autorise uniquement l'incorporation de frappes bitmap, pas de données de contour. Si la police n'a pas de frappes bitmap, elle ne peut pas être incorporée.

Les quatre premières valeurs décrivent l'autorisation d'utilisation, tandis que `NoSubsetting` et `BitmapOnly` peuvent être combinés avec elles. Vérifiez les modificateurs avec des opérations bit à bit. Parce que `Installable` vaut zéro, masquez les bits d'autorisation d'utilisation et comparez le résultat avec `Installable` au lieu de le vérifier comme drapeau. Les polices actuelles doivent définir au plus un bit d'autorisation d'utilisation. Pour la compatibilité avec les anciennes polices qui définissent plusieurs bits, l'aide ci-dessous sélectionne l'autorisation la moins restrictive : `Editable`, puis `PreviewPrint`, puis `Restricted`.

L'exemple suivant examine les données régulières, en gras, en italique et en gras‑italique disponibles pour chaque police renvoyée par `getFonts`. Il ignore les styles indisponibles, les polices restreintes, les polices bitmap‑only, les polices limitées à la prévisualisation et à l'impression parce que la sortie reste éditable, ainsi que les polices déjà incorporées. Si un style disponible possède `NoSubsetting`, il incorpore tous les caractères pour cette famille de polices.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Cette inspection indique les restrictions encodées dans chaque fichier de police. Elle n'accorde pas de licence, ne prouve pas que vous avez obtenu la police légalement, et ne remplace pas la vérification du contrat de licence de la police avant de distribuer une copie incorporée.

## **Ajouter des polices incorporées**

Utilisez [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) pour incorporer une police. Ses surcharges acceptent soit un objet [FontData](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontdata/), soit un tableau d'octets contenant les données de la police. [EmbedFontCharacters](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/embedfontcharacters/) contrôle quels caractères sont inclus :

- `All` incorpore tous les caractères de la police. Utilisez cette option lorsque les destinataires doivent modifier la présentation et saisir du nouveau texte.
- `OnlyUsed` incorpore uniquement les caractères utilisés dans la présentation pour réduire la taille du fichier. Choisissez cette option pour une présentation terminée destinée principalement à la visualisation.

L'exemple suivant utilise [FontsManager.getFonts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getfonts/) pour récupérer les polices utilisées dans `Fonts.pptx` et incorpore celles qui ne le sont pas déjà. Les polices à ajouter doivent être disponibles sur la machine exécutant le code. Les polices incorporées existentes conservent leurs jeux de caractères actuels.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Compresser les polices incorporées**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compress/compressembeddedfonts/) réduit les données de police incorporées en supprimant les caractères inutilisés. Il agit sur les polices déjà incorporées, de sorte que la réduction de taille dépend de la quantité de données de police inutilisées que la présentation contient.

L'exemple suivant compresse les polices dans `EmbeddedFonts.pptx` et enregistre le résultat dans un fichier séparé :
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Conservez le fichier original si les destinataires peuvent avoir besoin d'ajouter du texte ultérieurement. Les caractères supprimés lors de la compression ne sont plus disponibles dans la police incorporée, même si vous aviez initialement incorporé tous les caractères.

## **FAQ**

**Comment puis‑je vérifier si une police incorporée sera toujours substituée lors du rendu ?**

Appelez [FontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) dans l'environnement où vous rendez la présentation pour voir quelles polices Aspose.Slides remplacera. Vérifiez également les paramètres de [substitution de police](/slides/fr/nodejs-java/font-substitution/) et les règles de [police de secours](/slides/fr/nodejs-java/fallback-font/). La police de secours gère les caractères manquants, de sorte qu'incorporer une police ne résout pas les caractères que la police elle‑elle ne contient pas.

**Dois‑je incorporer des polices communes comme Arial et Calibri ?**

Bâchez votre décision sur l'environnement cible. Si les polices requises sont disponibles sur chaque machine qui ouvre ou rend la présentation, les incorporer peut augmenter inutilement la taille du fichier. Si les destinataires ou les serveurs peuvent ne pas disposer de ces polices, les incorporer peut aider à préserver l'apparence prévue, à condition que leurs licences le permettent.