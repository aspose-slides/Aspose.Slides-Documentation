---
title: Intégrer des polices dans les présentations en .NET
linktitle: Polices intégrées
type: docs
weight: 40
url: /fr/net/embedded-font/
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
- .NET
- C#
- Aspose.Slides
description: "Gérez les polices intégrées dans PowerPoint avec Aspose.Slides pour .NET. Utilisez C# pour ajouter, récupérer, supprimer et compresser les polices afin de préserver l'apparence du texte et réduire la taille du fichier."
---
## **Introduction**

L’intégration de polices stocke les données de police à l’intérieur d’une présentation PowerPoint. lorsqu’un visualiseur prend en charge les polices intégrées, il peut afficher le texte avec ces polices même si elles ne sont pas installées sur le système cible. Cela permet de préserver les sauts de ligne, l’espacement du texte et la mise en page des diapositives.

Aspose.Slides for .NET vous permet de récupérer, d’ajouter et de supprimer les polices intégrées via la propriété [FontsManager](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/fontsmanager/) d’une [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). Vous pouvez également réduire la taille des données de police intégrées en supprimant les caractères que la présentation n’utilise pas.

Les exemples ci‑dessous fonctionnent avec des fichiers PPTX. Avant d’intégrer une police, assurez‑vous que ses données de police sont disponibles pour Aspose.Slides et que sa licence autorise l’intégration.

## **Get and Remove Embedded Fonts**

Utilisez [GetEmbeddedFonts](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/getembeddedfonts/) pour lister les polices stockées dans une présentation. Pour en supprimer une, passez une police de cette liste à [RemoveEmbeddedFont](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/removeembeddedfont/), puis enregistrez la présentation.

L’exemple suivant répertorie les polices intégrées dans `EmbeddedFonts.pptx` et supprime Calibri si elle est présente :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

Supprimer une police intégrée supprime ses données de police stockées ; cela ne modifie pas la police attribuée au texte. Si la police est installée sur le système cible, le texte peut toujours l’utiliser. Sinon, le rendu peut nécessiter une [substitution de police](/slides/fr/net/font-substitution/), ce qui peut affecter la mise en page.

## **Inspect Font Data and Embedding Permissions**

Utilisez l’interface [IFontsManager](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsmanager/) pour inspecter les polices avant de les intégrer. Appelez [IFontsManager.GetFonts](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsmanager/getfonts/) pour récupérer les polices utilisées dans la présentation. Pour chaque police, transmettez un objet [IFontData](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontdata/) et la valeur requise [FontStyleType](https://reference.aspose.com/slides/fr/net/aspose.slides/fontstyletype/) à [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsmanager/getfontbytes/). La méthode renvoie les données binaires pour ce style de police, ou `null` lorsque la police ou le style demandé n’est pas disponible. Ne transmettez pas un résultat `null` à [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), car cette méthode nécessite un tableau d’octets.

[EmbeddingLevel](https://reference.aspose.com/slides/fr/net/aspose.slides/embeddinglevel/) est une énumération à drapeaux qui indique les restrictions d’intégration stockées dans la police :

- `Installable` autorise l’intégration et l’installation permanente sur un autre système, sous réserve de la licence de la police.
- `Restricted` interdit l’intégration sauf autorisation du propriétaire légal de la police lorsqu’il s’agit du seul drapeau d’autorisation d’utilisation.
- `PreviewPrint` autorise une utilisation temporaire pour la visualisation et l’impression ; un document contenant la police doit être en lecture seule.
- `Editable` autorise une utilisation temporaire et permet au document d’être modifié et enregistré.
- `NoSubsetting` est une restriction supplémentaire qui interdit l’intégration d’un sous‑ensemble de glyphes. Intégrez tous les caractères lorsque ce drapeau est présent.
- `BitmapOnly` est une restriction supplémentaire qui n’autorise que l’intégration de strikes bitmap, pas des données de contours. Si la police ne possède aucun strike bitmap, elle ne peut pas être intégrée.

Les quatre premières valeurs décrivent l’autorisation d’utilisation, tandis que `NoSubsetting` et `BitmapOnly` peuvent être combinés avec elles. Vérifiez les modificateurs à l’aide d’opérations bitwise. Comme `Installable` vaut zéro, n’utilisez pas `HasFlag` pour le détecter ; masquez les bits d’autorisation d’utilisation et comparez le résultat avec `Installable`. Les polices actuelles doivent définir au plus un bit d’autorisation d’utilisation. Pour la compatibilité avec les anciennes polices qui en définissent plusieurs, l’assistant ci‑dessous sélectionne l’autorisation la moins restrictive : `Editable`, puis `PreviewPrint`, puis `Restricted`.

L’exemple suivant analyse les données régulières, gras, italique et gras‑italique disponibles pour chaque police renvoyée par `GetFonts`. Il ignore les styles indisponibles, les polices restreintes, les polices bitmap‑only, les polices limitées à l’aperçu et à l’impression parce que la sortie reste éditable, ainsi que les polices déjà intégrées. Si un style disponible possède `NoSubsetting`, il intègre tous les caractères pour cette famille de polices.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

Cette inspection rapporte les restrictions encodées dans chaque fichier de police. Elle ne constitue pas une licence, ne prouve pas que vous avez acquis la police légalement, et ne remplace pas la vérification du contrat de licence de la police avant de distribuer une copie intégrée.

## **Add Embedded Fonts**

Utilisez [AddEmbeddedFont](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/addembeddedfont/) pour intégrer une police. Ses surcharges acceptent soit un objet [IFontData](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontdata/), soit un tableau d’octets contenant les données de la police. L’énumération [EmbedFontCharacters](https://reference.aspose.com/slides/fr/net/aspose.slides.export/embedfontcharacters/) contrôle quels caractères sont inclus :

- [All](https://reference.aspose.com/slides/fr/net/aspose.slides.export/embedfontcharacters/) intègre tous les caractères de la police. Utilisez cette option lorsque les destinataires doivent éditer la présentation et saisir du nouveau texte.
- [OnlyUsed](https://reference.aspose.com/slides/fr/net/aspose.slides.export/embedfontcharacters/) intègre uniquement les caractères utilisés dans la présentation afin de réduire la taille du fichier. Choisissez cette option pour une présentation terminée destinée principalement à la visualisation.

L’exemple suivant utilise [GetFonts](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/getfonts/) pour récupérer les polices utilisées dans `Fonts.pptx` et intègre celles qui ne sont pas déjà intégrées. Les polices à ajouter doivent être disponibles sur la machine exécutant le code. Les polices déjà intégrées conservent leurs jeux de caractères actuels.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **Compress Embedded Fonts**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/compressembeddedfonts/) réduit les données de police intégrées en supprimant les caractères inutilisés. Elle agit sur les polices déjà intégrées, ainsi la réduction de taille dépend de la quantité de données de police inutilisées présentes dans la présentation.

L’exemple suivant compresse les polices dans `EmbeddedFonts.pptx` et enregistre le résultat dans un fichier distinct :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Conservez le fichier original si les destinataires peuvent avoir besoin d’ajouter du texte plus tard. Les caractères supprimés lors de la compression ne sont plus disponibles dans la police intégrée, même si vous aviez initialement intégré tous les caractères.

## **FAQ**

**How can I check whether an embedded font will still be substituted during rendering?**

Appelez [GetSubstitutions](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/getsubstitutions/) dans l’environnement où vous effectuez le rendu de la présentation pour voir quelles polices Aspose.Slides remplacera. Vérifiez également les paramètres de [substitution de police](/slides/fr/net/font-substitution/) et les règles de [fallback de police](/slides/fr/net/fallback-font/). Le fallback gère les caractères manquants, de sorte qu’intégrer une police ne résout pas les caractères que la police elle‑même ne contient pas.

**Should I embed common fonts such as Arial and Calibri?**

Basez la décision sur l’environnement cible. Si les polices requises sont disponibles sur chaque machine qui ouvre ou rend la présentation, les intégrer peut augmenter inutilement la taille du fichier. Si les destinataires ou les serveurs peuvent ne pas disposer de ces polices, les intégrer peut aider à préserver l’apparence prévue, à condition que leurs licences le permettent.