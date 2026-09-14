---
title: Intégrer des polices dans les présentations en Python via Java
linktitle: Polices intégrées
type: docs
weight: 40
url: /fr/python-java/embedded-font/
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
- Java
- Aspose.Slides
description: "Gérez les polices intégrées dans PowerPoint avec Aspose.Slides pour Python via Java. Ajoutez, récupérez, supprimez et compressez les polices pour préserver l'apparence du texte et réduire la taille du fichier."
---
## **Introduction**

L'intégration de polices stocke les données de police à l'intérieur d'une présentation PowerPoint. Lorsqu'un visualiseur prend en charge les polices intégrées, il peut afficher le texte avec ces polices même si elles ne sont pas installées sur le système cible. Cela permet de conserver les sauts de ligne, l'espacement du texte et la mise en page des diapositives.

Aspose.Slides for Python via Java vous permet de récupérer, d'ajouter et de supprimer des polices intégrées via la classe [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/) renvoyée par [Presentation.getFontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getFontsManager). Vous pouvez également réduire la taille des données de police intégrées en supprimant les caractères que la présentation n'utilise pas.

Les exemples ci-dessous fonctionnent avec des fichiers PPTX. Avant d'intégrer une police, assurez‑vous que ses données de police sont disponibles pour Aspose.Slides et que sa licence autorise l'intégration.

## **Obtenir et supprimer des polices intégrées**

Utilisez [getEmbeddedFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) pour lister les polices stockées dans une présentation. Pour en supprimer une, transmettez une police de cette liste à [removeEmbeddedFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont), puis enregistrez la présentation.

L'exemple suivant répertorie les polices intégrées dans `EmbeddedFonts.pptx` et supprime Calibri si elle est présente :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Supprimer une police intégrée supprime ses données de police stockées ; cela ne modifie pas la police attribuée au texte. Si la police est installée sur le système cible, le texte peut toujours l'utiliser. Sinon, le rendu peut nécessiter une substitution de police, ce qui peut affecter la mise en page.

## **Inspecter les données de police et les autorisations d'intégration**

Utilisez la classe [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/) pour examiner les polices avant de les intégrer. Appelez [FontsManager.getFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getFonts) pour récupérer les polices utilisées dans la présentation. Pour chaque police, transmettez un objet [FontData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontdata/) et la valeur requise [FontStyleType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontstyletype/) à [FontsManager.getFontBytes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getFontBytes). La méthode renvoie les données binaires de ce style de police, ou `None` si la police ou le style demandé n'est pas disponible. Ne transmettez pas un résultat `None` à [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), car cette méthode nécessite un tableau d'octets.

[EmbeddingLevel](https://reference.aspose.com/slides/fr/python-java/aspose.slides/embeddinglevel/) est une énumération de drapeaux qui indique les restrictions d'intégration stockées dans la police :
- `Installable` autorise l'intégration et l'installation permanente sur un autre système, sous réserve de la licence de la police.
- `Restricted` interdit l'intégration sauf si une autorisation est obtenue auprès du propriétaire légal de la police lorsqu'il s'agit du seul drapeau d'autorisation d'utilisation.
- `PreviewPrint` autorise une utilisation temporaire pour la visualisation et l'impression ; un document contenant la police doit être en lecture seule.
- `Editable` autorise une utilisation temporaire et permet au document d'être édité et enregistré.
- `NoSubsetting` est une restriction supplémentaire qui interdit l'intégration d'un sous‑ensemble de glyphes. Intégrez tous les caractères lorsque ce drapeau est présent.
- `BitmapOnly` est une restriction supplémentaire qui autorise uniquement l'intégration de frappes bitmap, pas les données de contour. Si la police ne possède aucune frappe bitmap, elle ne peut pas être intégrée.

Les quatre premières valeurs décrivent l'autorisation d'utilisation, tandis que `NoSubsetting` et `BitmapOnly` peuvent être combinés avec elles. Vérifiez les modificateurs avec des opérations bit à bit. Comme `Installable` vaut zéro, masquez les bits d'autorisation d'utilisation et comparez le résultat avec `Installable` au lieu de le vérifier comme un drapeau. Les polices actuelles doivent définir au maximum un bit d'autorisation d'utilisation. Pour la compatibilité avec les anciennes polices qui en définissent plusieurs, l'assistant ci‑dessous sélectionne l'autorisation la moins restrictive : `Editable`, puis `PreviewPrint`, puis `Restricted`.

L'exemple suivant examine les données normales, en gras, en italique et en gras‑italique disponibles pour chaque police renvoyée par `getFonts`. Il ignore les styles indisponibles, les polices restreintes, les polices bitmap‑only, les polices limitées à l'aperçu et à l'impression parce que la sortie reste modifiable, ainsi que les polices déjà intégrées. Si un style disponible possède `NoSubsetting`, il intègre tous les caractères pour cette famille de polices.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cette inspection signale les restrictions encodées dans chaque fichier de police. Elle ne confère pas de licence, ne prouve pas que vous avez obtenu la police légalement, et ne remplace pas la vérification du contrat de licence de la police avant de distribuer une copie intégrée.

## **Ajouter des polices intégrées**

Utilisez [addEmbeddedFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) pour intégrer une police. Ses surcharges acceptent soit un objet [FontData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontdata/), soit un tableau d'octets contenant les données de la police. L'énumération [EmbedFontCharacters](https://reference.aspose.com/slides/fr/python-java/aspose.slides/embedfontcharacters/) détermine quels caractères sont inclus :
- [All](https://reference.aspose.com/slides/fr/python-java/aspose.slides/embedfontcharacters/) intègre tous les caractères de la police. Utilisez cette option lorsque les destinataires doivent modifier la présentation et saisir du nouveau texte.
- [OnlyUsed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/embedfontcharacters/) intègre uniquement les caractères utilisés dans la présentation afin de réduire la taille du fichier. Choisissez cette option pour une présentation terminée destinée principalement à la visualisation.

L'exemple suivant utilise [getFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getFonts) pour récupérer les polices utilisées dans `Fonts.pptx` et intègre celles qui ne sont pas déjà intégrées. Les polices à ajouter doivent être disponibles sur la machine exécutant le code. Les polices déjà intégrées conservent leurs jeux de caractères actuels.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Compresser les polices intégrées**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/#compressEmbeddedFonts) réduit les données de police intégrées en supprimant les caractères inutilisés. Il agit sur les polices déjà intégrées, ainsi la réduction de taille dépend de la quantité de données de police inutilisées présentes dans la présentation.

L'exemple suivant compresse les polices dans `EmbeddedFonts.pptx` et enregistre le résultat dans un fichier séparé :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Conservez le fichier original si les destinataires peuvent avoir besoin d'ajouter du texte ultérieurement. Les caractères supprimés lors de la compression ne sont plus disponibles dans la police intégrée, même si vous aviez initialement intégré tous les caractères.

## **FAQ**

**Comment puis‑je vérifier si une police intégrée sera toujours substituée lors du rendu ?**

Appelez [getSubstitutions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getSubstitutions) dans l'environnement où vous rendez la présentation pour voir quelles polices Aspose.Slides remplacera. Vérifiez également les paramètres de substitution de police et les règles de repli de police. Le repli gère les caractères manquants, de sorte qu'intégrer une police ne résout pas les caractères que la police elle‑même ne possède pas.

**Dois‑je intégrer des polices courantes telles qu'Arial et Calibri ?**

Fondez votre décision sur l'environnement cible. Si les polices requises sont disponibles sur chaque machine qui ouvre ou rend la présentation, les intégrer peut augmenter inutilement la taille du fichier. Si les destinataires ou les serveurs peuvent ne pas disposer de ces polices, les intégrer peut aider à préserver l'aspect prévu, à condition que leurs licences le permettent.