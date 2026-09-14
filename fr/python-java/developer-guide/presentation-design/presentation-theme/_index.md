---
title: Gérer les thèmes de présentation en Python via Java
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/python-java/presentation-theme/
keywords:
- thème PowerPoint
- thème de présentation
- thème de diapositive
- définir le thème
- modifier le thème
- gérer le thème
- thème externe
- THMX
- couleur du thème
- palette supplémentaire
- police du thème
- style du thème
- effet du thème
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Thèmes de présentation maîtres dans Aspose.Slides pour Python via Java afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, de polices, de styles d'arrière-plan, de remplissages, de lignes et d'effets. Les objets sensibles au thème font référence à ces définitions partagées au lieu de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu'un changement de thème peut mettre à jour de nombreux objets en même temps.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getMasterTheme). Une présentation peut également contenir des substitutions de thème à des niveaux inférieurs. Un master peut remplacer le thème de la présentation via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterthememanager/#getOverrideTheme), tandis qu'une disposition ou une diapositive individuelle peut remplacer son thème hérité via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). En pratique, le thème effectif d’une diapositive est résolu grâce à cette chaîne d’héritage : thème de la présentation, substitution du master, substitution de la disposition et substitution de la diapositive.

![Composants du thème : couleurs, polices, styles d'arrière-plan et effets](theme-constituents.png)

Les sections ci‑dessous montrent les flux de travail les plus courants : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effets, et lire les valeurs effectives après résolution des héritages et des substitutions.

## **Inspecter un thème**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mastertheme/) expose le schéma de couleurs, le schéma de polices et le schéma de formats du thème via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mastertheme/#getFontScheme) et [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mastertheme/#getFormatScheme). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les propriétés principales du thème et indique combien de styles d’arrière‑plan, de remplissage, de ligne et d’effet sont stockés dans le thème :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()
    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

Si un fichier utilise plusieurs masters, ne supposez pas que chaque diapositive a le même thème effectif. Inspectez le master associé à la diapositive et utilisez le flux de travail « thème effectif » présenté plus loin dans cet article lorsque des substitutions de disposition ou de diapositive peuvent être présentes.

## **Modifier les couleurs du thème**

Les remplissages, lignes et textes sensibles au thème peuvent faire référence à une couleur logique provenant de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [ColorScheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/colorscheme/), tous les objets qui référencent encore cette couleur de thème sont résolus avec la nouvelle valeur. Les objets qui utilisent une couleur RGB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple de bout en bout suivant crée une forme qui utilise `Accent4`, change la couleur `Accent4` du thème en rouge, enregistre la présentation, la rouvre et affiche la couleur de remplissage effective :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)
    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après le changement de thème. Si vous remplacez la couleur de schéma par une couleur directe sur la forme, les modifications ultérieures de `Accent4` ne toucheront plus ce remplissage.

### **Utiliser les couleurs de la palette supplémentaire**

PowerPoint dérive des variantes plus claires et plus foncées d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via l’énumération [ColorTransformOperation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/colortransformoperation/).

![Couleurs principales du thème et couleurs plus claires et plus foncées générées à partir de la palette supplémentaire](additional-palette-colors.png)

**1** - Couleurs principales du thème.

**2** - Variantes plus claires et plus foncées produites à partir des couleurs principales du thème.

L’exemple suivant crée six rectangles basés sur `Accent4`, applique des transformations de luminance à cinq d’entre eux, puis enregistre le résultat :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ces variantes restent fondées sur la couleur du thème. Si `Accent4` change plus tard, les couleurs transformées sont recalculées à partir de la nouvelle valeur `Accent4`.

### **Mapper les valeurs `SchemeColor` aux emplacements `ColorScheme`**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que le [ColorScheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/colorscheme/) expose les mêmes emplacements de thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mappage est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ce sont des noms alternatifs pour les mêmes emplacements de thème ; il ne s’agit pas de valeurs converties dynamiquement d’une forme à une autre.

## **Modifier les polices du thème**

Un schéma de polices du thème contient un jeu de polices majeur pour les titres et un jeu de polices mineur pour le corps du texte. Les méthodes [FontScheme.getMajor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontscheme/#getMajor) et [FontScheme.getMinor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontscheme/#getMinor) exposent ces jeux.

Les identifiants de police compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn-lt` - Police du corps Latin (Police mineure Latin)
* `+mj-lt` - Police du titre Latin (Police majeure Latin)
* `+mn-ea` - Police du corps Est‑asiatique (Police mineure Est‑asiatique)
* `+mj-ea` - Police du titre Est‑asiatique (Police majeure Est‑asiatique)

L’exemple suivant crée un titre qui utilise la police majeure Latin du thème et une ligne de corps qui utilise la police mineure Latin du thème. Il modifie ensuite les polices du thème et enregistre le résultat :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le titre suit la police majeure et le texte du corps suit la police mineure. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le schéma de polices du thème évolue.

Les collections majeures et mineures peuvent également contenir des mappages de polices pour des systèmes d’écriture individuels, tels que le cyrillique, l’arabe, le japonais, le géorgien et le thaana. Pour inspecter, ajouter, remplacer ou supprimer ces mappages, voir [Script-Specific Theme Fonts](/slides/fr/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}
Pour plus d’informations sur les polices de présentation, consultez [PowerPoint Fonts](/slides/fr/python-java/powerpoint-fonts/).
{{% /alert %}}

## **Copier ou appliquer un thème**

Les flux de travail ci‑dessous résolvent différents problèmes liés aux thèmes.

### **Appliquer un thème externe aux diapositives dépendantes d'un maître**

Utilisez [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) lorsque vous disposez d’un fichier de thème PowerPoint (`.thmx`) et que vous souhaitez re‑styliser chaque diapositive dépendante d’un master particulier. Sélectionnez le master dans la collection [Presentation.getMasters](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getMasters), représentée par [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslidecollection/), et transmettez le chemin du fichier thème à la méthode.

La méthode effectue les opérations suivantes :

1. Crée un nouveau master slide basé sur le master sélectionné.
1. Applique le thème externe au nouveau master.
1. Associe le nouveau master à toutes les diapositives qui dépendaient auparavant du master sélectionné.
1. Retourne le nouveau [MasterSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/).

L’exemple suivant applique un thème externe aux diapositives qui dépendent du premier master et enregistre la présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")

    print("Created master:", themed_master.getName())
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Un thème invalide, corrompu ou non pris en charge peut déclencher une [PptxReadException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxreadexception/). Validez les chemins fournis par les utilisateurs, gérez les échecs d’accès au système de fichiers et n’enregistrez la présentation qu’après que le thème a été appliqué avec succès.

Seules les diapositives qui dépendaient du master sélectionné sont réaffectées. Les diapositives associées à d’autres masters conservent leurs masters et thèmes existants. Les couleurs, polices, remplissages, lignes, arrière‑plans et effets sensibles au thème sont résolus par rapport au thème externe. Les couleurs, polices, remplissages et autres formats assignés directement peuvent rester inchangés. Les substitutions au niveau de la disposition et de la diapositive peuvent également prévaloir sur les valeurs héritées du nouveau master.

Le thème peut référencer des polices non disponibles dans l’environnement d’exécution. Pour une rendu et une exportation cohérents, installez les polices requises, fournissez‑les via [custom font sources](/slides/fr/python-java/custom-font/), ou configurez la [font substitution](/slides/fr/python-java/font-substitution/).

Il s’agit d’un flux de travail direct au niveau du master : la méthode accepte un chemin de fichier `.thmx` et ne nécessite pas de créer manuellement des substitutions de thème au niveau de la diapositive ou de la disposition.

### **Appliquer différents thèmes externes dans une présentation multi‑masters**

Lorsque le master concerné n’est pas connu à l’avance, obtenez‑le à partir d’une diapositive représentative via [Slide.getLayoutSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getLayoutSlide) et [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/#getMasterSlide). Conservez les références des masters originaux avant d’appliquer des thèmes, car chaque appel crée un nouveau master dans la présentation.

L’exemple suivant utilise des diapositives de deux sections pour localiser leurs masters et applique un thème externe différent à chaque groupe :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le premier appel n’affecte que les diapositives dépendantes de `first_group_master`, et le second appel n’affecte que les diapositives dépendantes de `second_group_master`. Les diapositives appartenant à tout autre master ne sont pas re‑stylisées.

### **Conserver le thème source lors du déplacement de diapositives**

Si vous devez déplacer une diapositive vers une autre présentation tout en conservant son design original, clonez le master source dans la présentation cible avec [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslidecollection/#addClone), puis clonez la diapositive avec [SlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone) et le master cloné. Cette opération transmet le master, ses dispositions et le thème associé.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

C’est le flux de travail recommandé lorsqu’il faut que la diapositive source conserve exactement le même aspect dans la destination. Simplement copier le contenu sur un master de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets pilotés par le thème.

### **Appliquer les valeurs du thème à une diapositive existante**

Si la diapositive cible doit rester sur son master et sa disposition actuels, initialisez une substitution au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) et [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) copient les trois principaux composants du thème dans la substitution.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Cela modifie le thème utilisé par cette diapositive sans changer le thème hérité par les autres diapositives. Pour supprimer la substitution locale et revenir aux valeurs héritées, appelez [OverrideTheme.clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/overridetheme/#clear).

### **Appliquer une substitution de thème à une disposition**

Une substitution au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, sauf si une diapositive particulière possède sa propre substitution. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslidethememanager/) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Utilisez un thème au niveau du master ou de la présentation lorsque de nombreuses dispositions et diapositives doivent partager le même design de base, une substitution de disposition lorsqu’une famille de dispositions nécessite un style différent, et une substitution de diapositive uniquement pour de véritables exceptions. Des substitutions excessives au niveau de la diapositive rendent les changements globaux de thème plus difficiles à prévoir.

## **Mettre à jour les styles d'arrière‑plan du thème**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fr/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). PowerPoint peut proposer davantage de choix d’arrière‑plan dans son interface que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’UI peut combiner les remplissages de thème avec les couleurs de thème et d’autres références de style.

![Galerie de styles d'arrière-plan PowerPoint pour un thème de présentation](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et la valeur actuelle de [Background.getStyleIndex](https://reference.aspose.com/slides/fr/python-java/aspose.slides/background/#getStyleIndex). Un indice de style de `0` signifie aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan du thème. Cela diffère de l’indexation directe de la collection, où `get_Item(0)` désigne le premier élément stocké. Ne supposez pas que chaque présentation contient le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, affecte une référence d’arrière‑plan thématisé au premier master et enregistre la présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)
        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat visible dépend de l’entrée du thème référencée par le master et d’éventuelles substitutions d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, modifier uniquement l’arrière‑plan du master peut ne pas affecter cette diapositive. Utilisez [Background.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/background/#getEffective) lorsque vous devez connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}
Ne traitez pas l’indice de style comme un indice de collection zéro‑based. Évitez également de coder en dur un numéro de style d’un fichier et de supposer qu’il a le même aspect dans un autre fichier ; les définitions de style de thème sont spécifiques à chaque présentation.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
Pour le formatage direct de l’arrière‑plan et l’héritage d’arrière‑plan, consultez [Presentation Background](/slides/fr/python-java/presentation-background/).
{{% /alert %}}

## **Mettre à jour les effets du thème**

Un schéma de formats du thème contient des collections distinctes de remplissage, de ligne et d’effet exposées via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/fr/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/fr/python-java/aspose.slides/formatscheme/#getLineStyles) et [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/fr/python-java/aspose.slides/formatscheme/#getEffectStyles). Les thèmes Office typiques contiennent souvent trois entrées de style principales qui correspondent visuellement à des formats subtils, modérés et intenses, mais le code doit inspecter chaque collection plutôt que de supposer un nombre fixe.

![Effets de thème subtils, modérés et intenses appliqués à la même forme](presentation-design_10.png)

Lorsque vous accédez à ces collections en Python via Java, l’index de la collection est zéro‑based : `get_Item(0)` est le premier style stocké et `get_Item(2)` le troisième. Les index de référence de style d’une forme constituent un concept distinct, exposé via [ShapeStyle](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapestyle/). Modifier un style de thème affecte les formes qui référen­cent ce style ; les formes avec un formatage direct peuvent rester inchangées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)
        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour les formes qui référen­cent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt plein, et le troisième effet du thème obtient une ombre extérieure avec une distance de 10 points. Le résultat visuel exact dépend toujours des emplacements de style référencés par chaque forme et d’éventuels formatages directs qui remplacent le thème.

![Styles d’effet du thème après modification des réglages de ligne, remplissage et ombre](presentation-design_11.png)

## **Déterminer si un remplissage uni effectif utilise une couleur de thème**

Un remplissage peut être stocké directement sur un objet ou hérité d’un paragraphe, d’une disposition, d’un master, d’un style de thème ou d’un autre niveau de formatage. Appelez [FillFormat.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/#getEffective) pour résoudre cette hiérarchie en données de remplissage effectives immuables. Vérifiez d’abord `getFillType` sur l’objet de données effectives. Ce n’est que lorsqu’il vaut `FillType.Solid` que vous devez lire les propriétés du remplissage uni.

Pour un remplissage uni, `getSolidFillColor` renvoie la valeur RGB finale rendue après héritage, recherche dans le thème et application des transformations de couleur. `getSolidFillSchemeColor` renvoie l’emplacement logique correspondant de [SchemeColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/schemecolor/), tel que `Text1` ou `Accent6`. Une valeur de `SchemeColor.NotDefined` signifie que le remplissage uni effectif n’est pas basé sur une couleur de schéma. Dans un flux de travail où les remplissages sont soit des couleurs de thème, soit des couleurs RGB directes, cette valeur identifie un remplissage RGB direct.

N’utilisez pas uniquement la valeur locale de [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/colorformat/#getSchemeColor) pour classer un remplissage. Par exemple, une portion de texte peut ne pas avoir de couleur de schéma définie localement, son valeur locale étant `NotDefined`, tandis que son remplissage effectif hérite d’une couleur de thème et se résout en `Text1` ou `Accent6`. Inversement, `getSolidFillSchemeColor` indique quel emplacement logique du thème a produit la couleur effective, mais ne précise pas si cet emplacement provient de l’objet, du paragraphe, de la disposition, du master ou d’un autre niveau de la hiérarchie de formatage.

L’exemple suivant charge une présentation, passe en revue les remplissages des formes et des portions de texte, affiche chaque valeur RGB finale ainsi que la couleur de schéma associée, et signale les remplissages uni qui ne suivront pas les changements de couleur du thème :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

La branche `NotDefined` fournit une liste d’audit des remplissages uni qui ne réagiront pas aux modifications des emplacements de couleur du thème. Passez en revue ces objets lorsqu’une présentation doit respecter une nouvelle palette de marque. La valeur RGB affichée montre toujours l’apparence actuelle, tandis que la valeur de schéma explique si cette apparence est liée au thème.

Les objets de format effectif sont des instantanés. Après modification du thème de la présentation, d’une substitution de thème ou de tout formatage hérité, appelez de nouveau `getEffective` et lisez un nouvel objet de données de remplissage effectif avant de comparer ou de rapporter les couleurs.

## **Lire les valeurs effectives du thème**

Les objets de thème bruts indiquent ce qui est défini à un niveau donné. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution des héritages et des substitutions locales. Pour une diapositive, appelez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). Pour un arrière‑plan, utilisez [Background.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/background/#getEffective), et pour un remplissage, utilisez [FillFormat.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/#getEffective).

L’exemple suivant lit le thème effectif, l’arrière‑plan et le premier remplissage de forme d’une diapositive :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getMasterTheme), vous pouvez manquer une substitution de master, de disposition, de diapositive ou de forme qui modifie l’apparence finale.

## **FAQ**

**L’application d’un thème externe affecte‑t‑elle chaque diapositive de la présentation ?**

Non. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) ne réaffecte que les diapositives dépendantes du master sélectionné. Les diapositives utilisant d’autres masters conservent leurs thèmes existants.

**Puis‑je appliquer un thème à une seule diapositive sans modifier le master ?**

Oui. Utilisez le [SlideThemeManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidethememanager/) de la diapositive et initialisez sa substitution de thème. Le changement reste local à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes existants.

**Quelle est la façon la plus sûre de transférer un thème d’une présentation à une autre ?**

Lors du déplacement d’une diapositive tout en conservant son apparence source, clonez le master source dans la destination et clonez la diapositive avec ce master à l’aide de [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslidecollection/#addClone) et [SlideCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addClone). Cela conserve le master, les dispositions et le thème ensemble.

**Comment puis‑je voir les valeurs effectives après héritage et substitutions ?**

Utilisez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) pour un thème de diapositive ou de disposition, ainsi que les méthodes de données effectives correspondantes pour les objets de format tels que [Background.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/background/#getEffective) et [FillFormat.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/#getEffective). Ces API renvoient les valeurs résolues après application des héritages et des substitutions.