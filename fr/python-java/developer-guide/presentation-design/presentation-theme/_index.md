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
description: "Thèmes de présentation maîtres dans Aspose.Slides pour Python via Java afin de créer, personnaliser et convertir des fichiers PowerPoint avec une image de marque cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, de polices, de styles d’arrière‑plan, de remplissages, de lignes et d’effets. Les objets sensibles au thème font référence à ces définitions partagées plutôt que de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’un changement de thème peut mettre à jour de nombreux objets à la fois.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme). Une présentation peut également contenir des substitutions de thème à des niveaux inférieurs. Un maître peut remplacer le thème de la présentation via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/masterthememanager/#getOverrideTheme), tandis qu’une mise en page ou une diapositive individuelle peut remplacer le thème hérité via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). En pratique, le thème effectif d’une diapositive est résolu à travers cette chaîne d’héritage : thème de la présentation, substitution du maître, substitution de la mise en page et substitution de la diapositive.

![Composants du thème : couleurs, polices, styles d’arrière‑plan et effets](theme-constituents.png)

Les sections ci‑dessous présentent les flux de travail les plus courants liés aux thèmes : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effets, et lire les valeurs effectives après résolution des héritages et des substitutions.

## **Inspecter un thème**

L’objet [MasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/) expose le schéma de couleur du thème, le schéma de police et le schéma de format via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFontScheme) et [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFormatScheme). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

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

Si un fichier utilise plusieurs maîtres, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le maître associé à la diapositive, et utilisez le flux de travail du thème effectif présenté plus loin dans cet article lorsqu’il peut y avoir des substitutions de mise en page ou de diapositive.

## **Modifier les couleurs du thème**

Les remplissages, lignes et textes sensibles au thème peuvent référencer une couleur logique provenant de l’énumération [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/), tous les objets qui référencent encore cette couleur de thème sont résolus avec la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple de bout en bout suivant crée une forme qui utilise `Accent4`, change la couleur du thème `Accent4` en rouge, enregistre la présentation, la rouvre et affiche la couleur de remplissage effective :

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

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après le changement de thème. Si vous remplacez la couleur de schéma par une couleur directe sur la forme, les modifications ultérieures de `Accent4` n’affecteront plus ce remplissage.

### **Utiliser les couleurs de la palette supplémentaire**

PowerPoint crée des variantes plus claires et plus foncées à partir d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via l’énumération [ColorTransformOperation](https://reference.aspose.com/slides/python-java/aspose.slides/colortransformoperation/).

![Couleurs principales du thème et couleurs plus claires et plus sombres générées à partir de la palette supplémentaire](additional-palette-colors.png)

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

Ces variantes restent basées sur la couleur du thème. Si `Accent4` change plus tard, les couleurs transformées sont recalculées à partir de la nouvelle valeur `Accent4`.

### **Faire correspondre les valeurs `SchemeColor` aux emplacements `ColorScheme`**

L’énumération [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que le [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) expose les mêmes emplacements de thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mapping est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Il s’agit de noms alternatifs pour les mêmes emplacements de thème ; ils ne sont pas des valeurs converties dynamiquement d’une forme à l’autre.

## **Modifier les polices du thème**

Un schéma de polices du thème contient un jeu de polices principal pour les titres et un jeu de polices secondaire pour le corps du texte. Les méthodes [FontScheme.getMajor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMajor) et [FontScheme.getMinor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMinor) exposent ces jeux.

Les identifiants de police compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn-lt` - Police du corps Latin (Police Latin mineure)
* `+mj-lt` - Police du titre Latin (Police Latin majeure)
* `+mn-ea` - Police du corps Asiatique de l’Est (Police Asiatique de l’Est mineure)
* `+mj-ea` - Police du titre Asiatique de l’Est (Police Asiatique de l’Est majeure)
* `+mn-cs` - Police du corps Script complexe (Police Script complexe mineure)
* `+mj-cs` - Police du titre Script complexe (Police Script complexe majeure)

L’exemple suivant crée un titre qui utilise la police Latin majeure du thème et une ligne de corps qui utilise la police Latin mineure du thème. Il modifie ensuite les polices du thème et enregistre le résultat :

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

Le titre suit la police majeure et le texte du corps suit la police mineure. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le schéma de polices du thème change.

Les collections majeures et mineures peuvent également contenir des mappages de police pour des systèmes d’écriture individuels, tels que le cyrillique, l’arabe, le japonais, le géorgien et le thaana. Pour inspecter, ajouter, remplacer ou supprimer ces mappages, voir [Polices de thème spécifiques aux scripts](/slides/fr/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}
Pour plus d’informations sur les polices de présentation, consultez [Polices PowerPoint](/slides/fr/python-java/powerpoint-fonts/).
{{% /alert %}}

### **Résoudre les références de police du thème**

Lors de l’inspection du texte, [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) peut renvoyer une référence de thème telle que `+mn-lt` au lieu d’un nom de famille de police. Appelez [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) avec les données de thème effectif appropriées pour résoudre cette référence. Les préfixes `+mj` et `+mn` sélectionnent les jeux de polices majeures et mineures ; les suffixes `-lt`, `-ea` et `-cs` sélectionnent respectivement leurs polices Latin, Asiatique de l’Est et Script complexe.

Obtenez le thème effectif via [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) sur le gestionnaire de thème de l’objet dont le thème s’applique au texte inspecté. Pour du texte ordinaire sur une diapositive, utilisez le gestionnaire de thème de la diapositive afin que le contexte inclue le thème hérité de cette diapositive et les substitutions locales. Lors de l’inspection d’une mise en page ou d’un maître lui‑même, utilisez son propre thème effectif. Ne supposez pas que le thème du premier maître s’applique à chaque diapositive.

L’exemple suivant crée une portion de texte qui référence explicitement la police Latin mineure. Il initialise un schéma de polices de diapositive via [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFromInherited) et définit les familles Latin majeures et mineures sur `Arial` et `Calibri`, rendant le résultat reproductible sans fichier d’entrée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    theme = slide.getThemeManager().getOverrideTheme()
    theme.initFontSchemeFromInherited()
    major_font = FontData("Arial")
    theme.getFontScheme().getMajor().setLatinFont(major_font)
    minor_font = FontData("Calibri")
    theme.getFontScheme().getMinor().setLatinFont(minor_font)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Text using the minor theme font")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    theme_font = FontData("+mn-lt")
    portion.getPortionFormat().setLatinFont(theme_font)

    font = portion.getPortionFormat().getLatinFont()
    effective_theme = slide.getThemeManager().createThemeEffective()
    print(f"{font.getFontName()} -> {font.getFontName(effective_theme)}")

    explicit_font = FontData("Verdana")
    print(f"{explicit_font.getFontName()} -> {explicit_font.getFontName(effective_theme)}")
finally:
    presentation.dispose()
```

La sortie est `+mn-lt -> Calibri` suivi de `Verdana -> Verdana`. La référence stockée reste inchangée, tandis qu’un nom de famille explicite est renvoyé tel quel. Si la portion utilisait `+mj-lt`, elle serait résolue en `Arial` dans ce thème.

Résoudre une référence de thème identifie la famille de police spécifiée par le thème. Cela ne vérifie pas la disponibilité de la police ni ne détermine le fichier de police réellement utilisé après substitution ou repli de glyphes lors du rendu. Voir [Séquence de sélection de police](/slides/fr/python-java/font-selection-sequence/) et [Substitution de police](/slides/fr/python-java/font-substitution/) pour ces étapes distinctes.

## **Copier ou appliquer un thème**

Les flux de travail ci‑dessous résolvent différents problèmes liés aux thèmes.

### **Appliquer un thème externe aux diapositives dépendantes d’un maître**

Utilisez [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) lorsque vous disposez d’un fichier de thème PowerPoint (`.thmx`) et que vous souhaitez re‑styliser chaque diapositive dépendant d’un maître particulier. Sélectionnez le maître dans la collection [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters), représentée par [MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/), puis passez le chemin du fichier thème à la méthode.

La méthode réalise les opérations suivantes :

1. Crée une nouvelle diapositive maître basée sur le maître sélectionné.  
1. Applique le thème externe au nouveau maître.  
1. Assigne le nouveau maître à toutes les diapositives qui dépendaient auparavant du maître sélectionné.  
1. Retourne le nouveau [MasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/).

L’exemple suivant applique un thème externe aux diapositives qui dépendent du premier maître et enregistre la présentation :

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

Un thème invalide, corrompu ou non pris en charge peut provoquer [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/). Validez les chemins fournis par les utilisateurs, gérez les échecs d’accès au système de fichiers et n’enregistrez la présentation qu’après que le thème a été appliqué avec succès.

Seules les diapositives qui dépendaient du maître sélectionné sont réaffectées. Les diapositives associées à d’autres maîtres conservent leurs maîtres et thèmes existants. Les couleurs, polices, remplissages, lignes, arrière‑plans et effets sensibles au thème sont résolus par rapport au thème externe. Les couleurs, polices, remplissages et autres formats assignés directement peuvent rester inchangés. Les substitutions au niveau de la mise en page et de la diapositive peuvent également prévaloir sur les valeurs héritées du nouveau maître.

Le thème peut référencer des polices qui ne sont pas disponibles dans l’environnement d’exécution. Pour un rendu et une exportation cohérents, installez les polices requises, fournissez‑les via [sources de police personnalisées](/slides/fr/python-java/custom-font/), ou configurez la [substitution de police](/slides/fr/python-java/font-substitution/).

C’est un flux de travail direct au niveau du maître : la méthode accepte le chemin d’un fichier `.thmx` et ne nécessite pas de créer manuellement des substitutions de thème au niveau de la diapositive ou de la mise en page.

### **Appliquer différents thèmes externes dans une présentation à maîtres multiples**

Lorsque le maître pertinent n’est pas connu à l’avance, récupérez‑le à partir d’une diapositive représentative via [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) et [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getMasterSlide). Conservez les références des maîtres d’origine avant d’appliquer des thèmes, car chaque appel crée un autre maître dans la présentation.

L’exemple suivant utilise des diapositives de deux sections pour localiser leurs maîtres et applique un thème externe différent à chaque groupe :

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

Le premier appel n’affecte que les diapositives dépendant de `first_group_master`, et le deuxième appel n’affecte que les diapositives dépendant de `second_group_master`. Les diapositives appartenant à un autre maître ne sont pas re‑stylisées.

### **Conserver un thème source lors du déplacement de diapositives**

Si vous souhaitez déplacer une diapositive vers une autre présentation tout en conservant son apparence d’origine, clonez le maître source dans la présentation cible avec [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone), puis clonez la diapositive avec [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) et le maître cloné. Cela transporte le maître, ses mises en page et le thème associé ensemble.

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

C’est le flux de travail préféré lorsque la diapositive source doit garder le même aspect dans la destination. Simplement cloner le contenu sur un maître de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets dictés par le thème.

### **Appliquer les valeurs du thème à une diapositive existante**

Si la diapositive cible doit rester sur son maître et sa mise en page actuels, initialisez une substitution au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) et [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) copient les trois principaux composants du thème dans la substitution.

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

Cela modifie le thème utilisé par cette diapositive sans toucher au thème hérité par les autres diapositives. Pour supprimer la substitution locale et revenir aux valeurs héritées, appelez [OverrideTheme.clear](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#clear).

### **Appliquer une substitution de thème à une mise en page**

Une substitution au niveau de la mise en page s’applique aux diapositives qui utilisent cette mise en page, sauf si une diapositive particulière possède sa propre substitution. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslidethememanager/) :

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

Utilisez un thème au niveau du maître ou de la présentation lorsque de nombreuses mises en page et diapositives doivent partager la même conception de base, une substitution de mise en page lorsqu’une famille de mise en page nécessite un style différent, et une substitution de diapositive uniquement pour de véritables exceptions. Un excès de substitutions au niveau de la diapositive rend les changements globaux de thème ultérieurs plus difficiles à prévoir.

<!-- visual-explanation:presentation-theme:start -->
[![Un thème maître alimente deux mises en page ; un substitut de mise en page affecte ses diapositives sauf une diapositive avec un substitut plus local.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Un substitut de mise en page s’applique aux diapositives utilisant cette mise en page sauf si une diapositive fournit son propre substitut. Les valeurs basées sur le thème suivent leur schéma résolu ; les objets formatés explicitement peuvent conserver leur apparence locale. Gardez les substituts aussi étroits que l’exception de conception prévue.*
<!-- visual-explanation:presentation-theme:end -->

## **Mettre à jour les styles d’arrière‑plan du thème**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). PowerPoint peut présenter plus d’options d’arrière‑plan dans son interface que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’interface peut combiner les remplissages du thème avec les couleurs du thème et d’autres références de style.

![Galerie de styles d’arrière‑plan PowerPoint pour un thème de présentation](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et l’[Background.getStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getStyleIndex) actuel. Un indice de style de `0` signifie aucun remplissage thématisé ; des valeurs positives sont des références de style d’arrière‑plan du thème. Cela diffère de l’indexation directe de la collection, où `get_Item(0)` désigne le premier élément stocké. Ne supposez pas que chaque présentation contienne le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, affecte une référence d’arrière‑plan thématisée au premier maître, puis enregistre la présentation :

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

Le résultat visible dépend de l’entrée du thème référencée par le maître et de toute substitution d’arrière‑plan au niveau de la mise en page ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, modifier uniquement l’arrière‑plan du maître peut ne pas affecter cette diapositive. Utilisez [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) lorsque vous devez connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}
Ne traitez pas l’indice de style comme un indice de collection basé sur zéro. Évitez également de coder en dur un numéro de style provenant d’un fichier et de supposer qu’il a la même apparence dans un autre fichier ; les définitions de style du thème sont propres à chaque présentation.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
Pour le formatage direct de l’arrière‑plan et l’héritage d’arrière‑plan, consultez [Arrière‑plan de la présentation](/slides/fr/python-java/presentation-background/).
{{% /alert %}}

## **Mettre à jour les effets du thème**

Un schéma de format du thème contient des collections séparées de styles de remplissage, de ligne et d’effet exposées via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getLineStyles) et [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getEffectStyles). Les thèmes Office typiques contiennent souvent trois entrées principales qui correspondent visuellement à des formats subtils, modérés et intenses, mais le code doit inspecter chaque collection plutôt que de supposer un nombre fixe.

![Effets de thème subtils, modérés et intenses appliqués à la même forme](presentation-design_10.png)

Lorsque vous accédez à ces collections en Python via Java, l’index de la collection est basé sur zéro : `get_Item(0)` est le premier style stocké et `get_Item(2)` le troisième. Les index de référence de style d’une forme constituent un concept distinct, exposé via [ShapeStyle](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/). Modifier un style de thème affecte les formes qui référencent ce style ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, modifie le troisième style de remplissage, active une ombre extérieure dans le troisième style d’effet, puis enregistre le résultat :

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

Pour les formes qui référencent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt plein, et le troisième style d’effet gagne une ombre extérieure avec une distance de 10 points. Le rendu visuel exact dépend toujours des emplacements de style référencés par chaque forme et de la présence éventuelle d’un formatage direct qui surpasse le thème.

![Styles d’effet du thème après modification des paramètres de ligne, de remplissage et d’ombre](presentation-design_11.png)

## **Sélectionner les styles de remplissage et de ligne du thème pour une forme**

Une forme peut sélectionner indépendamment son remplissage et son contour via [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setFillStyleIndex) et [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setLineStyleIndex). Pour chaque méthode, l’indice `1` sélectionne la première entrée de la collection de thème correspondante (`get_Item(0)`), et l’indice `2` sélectionne la deuxième (`get_Item(1)`).

L’exemple suivant crée deux styles de remplissage (or et bleu ciel) et deux styles de ligne (bleu foncé à 6 pt et rouge foncé à 12 pt) dans le thème par défaut d’une nouvelle présentation. Il enregistre la diapositive à trois étapes afin que vous puissiez comparer les résultats dans PowerPoint.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    styles = presentation.getMasterTheme().getFormatScheme()

    gold_fill = styles.getFillStyles().get_Item(0)
    gold_fill.setFillType(FillType.Solid)
    gold_fill.getSolidFillColor().setColor(Color(255, 215, 0))
    blue_fill = styles.getFillStyles().get_Item(1)
    blue_fill.setFillType(FillType.Solid)
    blue_fill.getSolidFillColor().setColor(Color(135, 206, 235))

    thin_line = styles.getLineStyles().get_Item(0)
    thin_line.getFillFormat().setFillType(FillType.Solid)
    thin_line.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    thin_line.setWidth(6)
    thick_line = styles.getLineStyles().get_Item(1)
    thick_line.getFillFormat().setFillType(FillType.Solid)
    thick_line.getFillFormat().getSolidFillColor().setColor(Color(139, 0, 0))
    thick_line.setWidth(12)

    shapes = presentation.getSlides().get_Item(0).getShapes()
    left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130)
    right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130)
    left.getShapeStyle().setFillStyleIndex(1)
    right.getShapeStyle().setFillStyleIndex(2)
    left.getShapeStyle().setLineStyleIndex(1)
    right.getShapeStyle().setLineStyleIndex(1)
    presentation.save("01-initial.pptx", SaveFormat.Pptx)

    right.getShapeStyle().setLineStyleIndex(2)
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx)

    gold_fill.getSolidFillColor().setColor(Color(46, 139, 87))
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Styles initiaux | Modifier le contour droit | Modifier le premier remplissage du thème |
|:---:|:---:|:---:|
| ![Rectangles or et bleu ciel avec contours fins bleu foncé correspondants](theme-style-initial.png) | ![Le rectangle bleu ciel a maintenant un contour épais rouge foncé](theme-style-line-changed.png) | ![Le rectangle gauche est maintenant vert et les deux contours restent inchangés](theme-style-fill-changed.png) |

Sélectionner un style de ligne différent ne change que le contour du rectangle droit. Modifier le premier remplissage du thème met à jour chaque forme qui l’utilise. Ici, seul le rectangle gauche devient vert.

Sur une forme existante, une couleur de remplissage locale, une couleur de ligne ou une épaisseur de ligne peuvent remplacer cette partie du style du thème. Si la modification d’un indice de style n’a aucun effet visible, vérifiez le [formatage direct](/slides/fr/python-java/shape-formatting/) de la forme.

## **Déterminer si un remplissage solide effectif utilise une couleur de thème**

Un remplissage peut être stocké directement sur un objet ou hérité d’un paragraphe, d’une mise en page, d’un maître, d’un style de thème ou d’un autre niveau de formatage. Appelez [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) pour résoudre cette hiérarchie en données de remplissage effectives immuables. Commencez par vérifier `getFillType` sur l’objet de données effectives. Ce n’est que lorsqu’il est `FillType.Solid` que vous devez lire les propriétés du remplissage solide.

Pour un remplissage solide, `getSolidFillColor` renvoie la valeur RVB finale rendue après héritage, recherche dans le thème et application des transformations de couleur. `getSolidFillSchemeColor` renvoie l’emplacement logique [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) correspondant, tel que `Text1` ou `Accent6`. Une valeur de `SchemeColor.NotDefined` signifie que le remplissage solide effectif n’est pas basé sur une couleur de schéma. Dans un flux où les remplissages sont soit des couleurs de thème, soit des couleurs RVB directes, cette valeur identifie un remplissage RVB direct.

N’utilisez pas uniquement la valeur locale [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getSchemeColor) pour classer un remplissage. Par exemple, une portion de texte peut ne pas avoir de couleur de schéma définie localement, donc sa valeur locale est `NotDefined`, alors que son remplissage effectif hérite d’une couleur de thème et résout en `Text1` ou `Accent6`. Inversement, `getSolidFillSchemeColor` indique quel emplacement logique du thème a produit la couleur effective, mais ne précise pas si cet emplacement provient de l’objet, du paragraphe, de la mise en page, du maître ou d’un autre niveau de la hiérarchie de formatage.

L’exemple suivant charge une présentation, examine les remplissages des formes et des portions de texte, imprime chaque valeur RVB finale et la couleur de schéma associée, et signale les remplissages solides qui ne suivront pas les changements de couleur du thème :

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

La branche `NotDefined` fournit une liste d’audit des remplissages solides qui ne réagiront pas aux changements des emplacements de couleur du thème. Examinez ces objets lorsqu’une présentation doit suivre une nouvelle palette de marque. La valeur RVB rapportée montre toujours l’apparence actuelle, tandis que la valeur de schéma explique si cette apparence est liée au thème.

Les objets de formatage effectif sont des instantanés. Après avoir modifié le thème de la présentation, une substitution de thème ou tout formatage hérité, appelez de nouveau `getEffective` et lisez un nouvel objet de données de remplissage effectif avant de comparer ou d’afficher les couleurs.

## **Lire les valeurs de thème effectives**

Les objets de thème bruts indiquent ce qui est défini à un niveau donné. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution des héritages et des substitutions locales. Pour une diapositive, appelez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). Pour un arrière‑plan, utilisez [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective), et pour un remplissage, utilisez [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective).

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

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme), vous pouvez manquer une substitution de maître, de mise en page, de diapositive ou de forme qui modifie l’apparence finale.

## **FAQ**

**L’application d’un thème externe affecte‑t‑elle chaque diapositive de la présentation ?**

Non. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) ne réaffecte que les diapositives dépendant du maître sélectionné. Les diapositives utilisant d’autres maîtres conservent leurs thèmes existants.

**Puis‑je appliquer un thème à une seule diapositive sans modifier le maître ?**

Oui. Utilisez le [SlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/slidethememanager/) de la diapositive et initialisez sa substitution de thème. Le changement reste local à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes existants.

**Quelle est la manière la plus sûre de transférer un thème d’une présentation à une autre ?**

Lors du déplacement d’une diapositive tout en préservant son apparence source, clonez le maître source dans la destination et clonez la diapositive avec ce maître à l’aide de [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) et [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone). Cela conserve le maître, les mises en page et le thème ensemble.

**Comment voir les valeurs effectives après héritage et substitutions ?**

Utilisez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) pour un thème de diapositive ou de mise en page, ainsi que les méthodes de données effectives correspondantes pour les objets de format comme [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) et [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective). Ces API renvoient les valeurs résolues après application de l’héritage et des substitutions.