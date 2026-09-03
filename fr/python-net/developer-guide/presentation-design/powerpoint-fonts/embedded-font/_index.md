---
title: Intégrer des polices dans les présentations avec Python
linktitle: Polices intégrées
type: docs
weight: 40
url: /fr/python-net/embedded-font/
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
- Python
- Aspose.Slides
description: "Gérer les polices intégrées dans PowerPoint avec Aspose.Slides pour Python via .NET. Utilisez Python pour ajouter, récupérer, supprimer et compresser les polices afin de préserver l'apparence du texte et réduire la taille du fichier."
---
## **Introduction**

L'intégration de polices stocke les données de police à l'intérieur d'une présentation PowerPoint. Lorsqu'un visualiseur prend en charge les polices intégrées, il peut afficher le texte en utilisant ces polices même si elles ne sont pas installées sur le système cible. Cela aide à préserver les sauts de ligne, l'espacement du texte et la disposition des diapositives.

Aspose.Slides for Python via .NET vous permet de récupérer, d'ajouter et de supprimer des polices intégrées via la propriété [fonts_manager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/fonts_manager/). Vous pouvez également réduire la taille des données de police intégrées en supprimant les caractères que la présentation n'utilise pas.

Les exemples ci‑dessous fonctionnent avec des fichiers PPTX. Avant d'intégrer une police, assurez‑vous que ses données de police sont disponibles pour Aspose.Slides et que sa licence autorise l'intégration.

## **Obtenir et supprimer les polices intégrées**

Utilisez [get_embedded_fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) pour lister les polices stockées dans une présentation. Pour en supprimer une, transmettez une police de cette liste à [remove_embedded_font](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/remove_embedded_font/), puis enregistrez la présentation.

L'exemple suivant répertorie les polices intégrées dans `EmbeddedFonts.pptx` et supprime Calibri si elle est présente :

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Supprimer une police intégrée supprime ses données de police stockées ; cela ne modifie pas la police assignée au texte. Si la police est installée sur le système cible, le texte peut toujours l'utiliser. Sinon, le rendu peut nécessiter une [font substitution](/slides/fr/python-net/font-substitution/), ce qui peut affecter la mise en page.

## **Inspecter les données de police et les autorisations d'intégration**

Utilisez la classe [FontsManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/) pour inspecter les polices avant de les intégrer. Appelez [get_fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_fonts/) pour récupérer les polices utilisées dans la présentation. Pour chaque police, transmettez un objet [FontData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontdata/) et la valeur requise de [FontStyleType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontstyletype/) à [get_font_bytes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_font_bytes/). La méthode renvoie les données binaires pour ce style de police, ou `None` si la police ou le style demandé n’est pas disponible. Ne transmettez pas un résultat `None` à [get_font_embedding_level](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), car cette méthode nécessite un tableau d’octets.

[EmbeddingLevel](https://reference.aspose.com/slides/fr/python-net/aspose.slides/embeddinglevel/) est une énumération de drapeaux qui indique les restrictions d'intégration stockées dans la police :

- `INSTALLABLE` autorise l'intégration et l'installation permanente sur un autre système, sous réserve de la licence de la police.
- `RESTRICTED` interdit l'intégration sauf si une autorisation est obtenue auprès du propriétaire légal de la police lorsque c'est le seul drapeau d'autorisation d'utilisation.
- `PREVIEW_PRINT` autorise une utilisation temporaire pour la visualisation et l’impression ; un document contenant la police doit être en lecture seule.
- `EDITABLE` autorise une utilisation temporaire et permet au document d’être édité et enregistré.
- `NO_SUBSETTING` est une restriction supplémentaire qui interdit l’intégration d’un sous‑ensemble de glyphes. Intégrez tous les caractères lorsque ce drapeau est présent.
- `BITMAP_ONLY` est une restriction supplémentaire qui autorise uniquement l’intégration de fichiers bitmap, pas des données vectorielles. Si la police ne possède aucun bitmap, elle ne peut pas être intégrée.

Les quatre premières valeurs décrivent les autorisations d’utilisation, tandis que `NO_SUBSETTING` et `BITMAP_ONLY` peuvent être combinés avec elles. Vérifiez les modificateurs à l’aide d’opérations bit à bit. Comme `INSTALLABLE` vaut zéro, masquez les bits d’autorisation d’utilisation et comparez le résultat avec `INSTALLABLE`. Les polices actuelles ne doivent définir au plus qu’un seul bit d’autorisation d’utilisation. Pour assurer la compatibilité avec les anciennes polices qui en définissent plusieurs, l’assistant ci‑dessous sélectionne l’autorisation la moins restrictive : `EDITABLE`, puis `PREVIEW_PRINT`, puis `RESTRICTED`.

L'exemple suivant examine les données régulières, gras, italique et gras‑italique disponibles pour chaque police renvoyée par `get_fonts`. Il ignore les styles non disponibles, les polices restreintes, les polices bitmap‑only, les polices limitées à la prévisualisation et à l’impression parce que la sortie reste éditable, et les polices déjà intégrées. Si un style disponible possède le drapeau `NO_SUBSETTING`, il intègre tous les caractères pour cette famille de polices.

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Cette inspection rapporte les restrictions encodées dans chaque fichier de police. Elle ne délivre pas de licence, ne prouve pas que vous avez obtenu la police légalement, et ne remplace pas la vérification du contrat de licence de la police avant de distribuer une copie intégrée.

## **Ajouter des polices intégrées**

Utilisez [add_embedded_font](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/add_embedded_font/) pour intégrer une police. Ses surcharges acceptent soit un objet [FontData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontdata/), soit un tableau d’octets contenant les données de la police. L'énumération [EmbedFontCharacters](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/embedfontcharacters/) contrôle les caractères inclus :

- [ALL](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/embedfontcharacters/) intègre tous les caractères de la police. Utilisez cette option lorsque les destinataires doivent modifier la présentation et saisir du nouveau texte.
- [ONLY_USED](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/embedfontcharacters/) intègre uniquement les caractères utilisés dans la présentation afin de réduire la taille du fichier. Choisissez cette option pour une présentation finalisée destinée principalement à la visualisation.

L'exemple suivant utilise [get_fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_fonts/) pour récupérer les polices utilisées dans `Fonts.pptx` et intègre celles qui ne sont pas déjà intégrées. Les polices à ajouter doivent être disponibles sur la machine exécutant le code. Les polices déjà intégrées conservent leurs jeux de caractères actuels.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Compresser les polices intégrées**

[compress_embedded_fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) réduit les données de police intégrées en supprimant les caractères inutilisés. Il agit sur les polices déjà intégrées, ainsi la réduction de taille dépend de la quantité de données de police inutilisées que la présentation contient.

L'exemple suivant compresse les polices dans `EmbeddedFonts.pptx` et enregistre le résultat dans un fichier séparé :

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Conservez le fichier original si les destinataires peuvent avoir besoin d'ajouter du texte ultérieurement. Les caractères supprimés lors de la compression ne sont plus disponibles dans la police intégrée, même si vous aviez initialement intégré tous les caractères.

## **FAQ**

**Comment puis‑je vérifier si une police intégrée sera toujours substituée lors du rendu ?**

Appelez [get_substitutions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_substitutions/) dans l’environnement où vous rendez la présentation pour voir quelles polices Aspose.Slides remplacera. Vérifiez également les paramètres de [font substitution](/slides/fr/python-net/font-substitution/) et les règles de [font fallback](/slides/fr/python-net/fallback-font/). Le fallback gère les caractères manquants, donc l’intégration d’une police ne résout pas les caractères que la police elle‑même ne possède pas.

**Dois‑je intégrer des polices courantes comme Arial et Calibri ?**

Basez la décision sur l’environnement cible. Si les polices requises sont disponibles sur chaque machine qui ouvre ou rend la présentation, les intégrer peut augmenter inutilement la taille du fichier. Si les destinataires ou les serveurs peuvent manquer ces polices, les intégrer peut aider à préserver l’aspect prévu, à condition que leurs licences le permettent.