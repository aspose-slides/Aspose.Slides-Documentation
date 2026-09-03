---
title: Intégrer des polices dans les présentations sur Android
linktitle: Polices intégrées
type: docs
weight: 40
url: /fr/androidjava/embedded-font/
keywords:
- ajouter police
- intégrer police
- intégration de police
- obtenir police intégrée
- ajouter police intégrée
- supprimer police intégrée
- compresser police intégrée
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Gérez les polices intégrées dans PowerPoint avec Aspose.Slides pour Android via Java. Ajoutez, récupérez, supprimez et compressez les polices pour préserver l'apparence du texte et réduire la taille du fichier."
---
## **Introduction**

L'incorporation de polices stocke les données de la police à l'intérieur d'une présentation PowerPoint. Lorsqu'un visualiseur prend en charge les polices intégrées, il peut afficher le texte en utilisant ces polices même si elles ne sont pas installées sur le système cible. Cela permet de conserver les sauts de ligne, l'espacement du texte et la mise en page des diapositives.

Aspose.Slides for Android via Java vous permet de récupérer, ajouter et supprimer des polices intégrées via l'interface [IFontsManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/) retournée par [Presentation.getFontsManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getFontsManager--). Vous pouvez également réduire la taille des données de police intégrées en supprimant les caractères que la présentation n'utilise pas.

Les exemples ci‑dessus fonctionnent avec des fichiers PPTX. Avant d’intégrer une police, assurez‑vous que ses données de police sont disponibles pour Aspose.Slides et que sa licence autorise l'intégration.

## **Obtenir et supprimer les polices intégrées**

Utilisez [getEmbeddedFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) pour répertorier les polices stockées dans une présentation. Pour en supprimer une, transmettez une police de cette liste à [removeEmbeddedFont](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), puis enregistrez la présentation.

L'exemple suivant répertorie les polices intégrées dans `EmbeddedFonts.pptx` et supprime Calibri si elle est présente :

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Supprimer une police intégrée supprime ses données de police stockées ; cela ne modifie pas la police attribuée au texte. Si la police est installée sur le système cible, le texte peut toujours l'utiliser. Sinon, le rendu peut nécessiter une [substitution de police](/slides/fr/androidjava/font-substitution/), ce qui peut affecter la mise en page.

## **Inspecter les données de police et les autorisations d’intégration**

Utilisez l'interface [IFontsManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/) pour inspecter les polices avant de les intégrer. Appelez [IFontsManager.getFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) pour récupérer les polices utilisées dans la présentation. Pour chaque police, transmettez un objet [IFontData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontdata/) et la valeur [FontStyleType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontstyletype/) requise à [IFontsManager.getFontBytes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). La méthode renvoie les données binaires pour ce style de police, ou `null` si la police ou le style demandé n'est pas disponible. Ne transmettez pas un résultat `null` à [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), car cette méthode nécessite un tableau d'octets.

[EmbeddingLevel](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/embeddinglevel/) est une énumération de drapeaux qui indique les restrictions d'intégration stockées dans la police :

- `Installable` autorise l'intégration et l'installation permanente sur un autre système, sous réserve de la licence de la police.
- `Restricted` interdit l'intégration sauf si une autorisation est obtenue auprès du propriétaire légal de la police lorsque c'est le seul drapeau d'autorisation d'utilisation.
- `PreviewPrint` autorise une utilisation temporaire pour la visualisation et l'impression ; un document contenant la police doit être en lecture seule.
- `Editable` autorise une utilisation temporaire et permet de modifier et d'enregistrer le document.
- `NoSubsetting` est une restriction supplémentaire qui interdit l'intégration d'un sous‑ensemble des glyphes. Intégrez tous les caractères lorsque ce drapeau est présent.
- `BitmapOnly` est une restriction supplémentaire qui ne permet d’intégrer que des matrices bitmap, pas les données de contour. Si la police ne possède pas de matrices bitmap, elle ne peut pas être intégrée.

Les quatre premières valeurs décrivent les autorisations d'utilisation, tandis que `NoSubsetting` et `BitmapOnly` peuvent être combinés avec elles. Vérifiez les modificateurs à l'aide d'opérations binaires. Comme `Installable` vaut zéro, masquez les bits d'autorisation d'utilisation et comparez le résultat avec `Installable` au lieu de le vérifier comme drapeau. Les polices actuelles doivent définir au maximum un bit d'autorisation d'utilisation. Pour assurer la compatibilité avec les anciennes polices qui définissent plusieurs bits, l'utilitaire ci‑dessous sélectionne l'autorisation la moins restrictive : `Editable`, puis `PreviewPrint`, puis `Restricted`.

L'exemple suivant audite les données normales, gras, italique et gras‑italique disponibles pour chaque police renvoyée par `getFonts`. Il ignore les styles indisponibles, les polices restreintes, les polices bitmap‑only, les polices limitées à l'aperçu et à l'impression car la sortie reste éditable, ainsi que les polices déjà intégrées. Si un style disponible possède le drapeau `NoSubsetting`, il intègre tous les caractères pour cette famille de polices.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Cette inspection indique les restrictions encodées dans chaque fichier de police. Elle ne confère pas de licence, ne prouve pas que vous avez obtenu la police légalement, et ne remplace pas la vérification du contrat de licence de la police avant de distribuer une copie intégrée.

## **Ajouter des polices intégrées**

Utilisez [addEmbeddedFont](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) pour intégrer une police. Ses surcharges acceptent soit un objet [IFontData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontdata/), soit un tableau d'octets contenant les données de la police. L'énumération [EmbedFontCharacters](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/embedfontcharacters/) contrôle les caractères inclus :

- [All](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/embedfontcharacters/) intègre tous les caractères de la police. Utilisez cette option lorsque les destinataires doivent modifier la présentation et saisir du texte nouveau.
- [OnlyUsed](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/embedfontcharacters/) intègre uniquement les caractères utilisés dans la présentation afin de réduire la taille du fichier. Choisissez cette option pour une présentation terminée destinée principalement à la visualisation.

L'exemple suivant utilise [getFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) pour récupérer les polices utilisées dans `Fonts.pptx` et intègre celles qui ne le sont pas déjà. Les polices à ajouter doivent être disponibles sur l'appareil Android ou enregistrées auprès d'Aspose.Slides. Les polices déjà intégrées conservent leurs jeux de caractères actuels.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Compresser les polices intégrées**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) réduit les données de police intégrées en supprimant les caractères inutilisés. Elle agit sur les polices déjà intégrées, ainsi la réduction de taille dépend de la quantité de données de police inutilisées contenues dans la présentation.

L'exemple suivant compresse les polices dans `EmbeddedFonts.pptx` et enregistre le résultat dans un fichier séparé :

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Conservez le fichier original si les destinataires peuvent avoir besoin d'ajouter du texte ultérieurement. Les caractères supprimés lors de la compression ne sont plus disponibles dans la police intégrée, même si vous aviez initialement intégré tous les caractères.

## **FAQ**

**Comment puis‑je vérifier si une police intégrée sera toujours substituée lors du rendu ?**

Appelez [getSubstitutions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) dans l'environnement où vous rendez la présentation pour voir quelles polices Aspose.Slides remplacera. Vérifiez également les paramètres de [substitution de police](/slides/fr/androidjava/font-substitution/) et les règles de [police de secours](/slides/fr/androidjava/fallback-font/). La police de secours gère les caractères manquants, ainsi l'intégration d'une police ne résout pas les caractères que la police elle‑même ne contient pas.

**Dois‑je intégrer des polices courantes comme Arial et Calibri ?**

Fondez votre décision sur l'environnement cible. Si les polices requises sont disponibles sur chaque appareil qui ouvre ou rend la présentation, les intégrer peut augmenter inutilement la taille du fichier. Si les destinataires ou les serveurs peuvent ne pas disposer de ces polices, les intégrer peut aider à préserver l'apparence prévue, à condition que leurs licences le permettent.