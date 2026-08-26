---
title: Gérer les thèmes de présentation en PHP
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/php-java/presentation-theme/
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
- PHP
- Aspose.Slides
description: "Maîtrisez les thèmes de présentation dans Aspose.Slides pour PHP via Java afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, de polices, de styles d'arrière-plan, de remplissages, de lignes et d'effets. Les objets sensibles au thème font référence à ces définitions partagées au lieu de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’une modification du thème peut mettre à jour de nombreux objets à la fois.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/). Une présentation peut également contenir des substitutions de thème à des niveaux inférieurs. Un master peut substituer le thème de la présentation via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterthememanager/), tandis qu’une disposition ou une diapositive individuelle peut substituer son thème hérité via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseoverridethememanager/). En pratique, le thème effectif d’une diapositive est résolu à travers cette chaîne d’héritage : thème de la présentation, substitution du master, substitution de la disposition et substitution de la diapositive.

![Composants du thème : couleurs, polices, styles d'arrière-plan et effets](theme-constituents.png)

Les sections ci‑dessous présentent les flux de travail les plus courants liés aux thèmes : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effets, et lire les valeurs effectives après résolution de l’héritage et des substitutions.

## **Inspecter un thème**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mastertheme/) expose le schéma de couleurs, le schéma de polices et le schéma de formats du thème via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mastertheme/) et [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mastertheme/). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les propriétés principales du thème et indique le nombre de styles d’arrière‑plan, de remplissage, de ligne et d’effet stockés dans le thème :

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Si un fichier utilise plusieurs masters, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le master associé à la diapositive et utilisez le flux de travail « thème effectif » présenté plus loin dans cet article lorsqu’il peut y avoir des substitutions au niveau de la disposition ou de la diapositive.

## **Modifier les couleurs du thème**

Les remplissages, lignes et textes sensibles au thème peuvent se référer à une couleur logique à partir de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [ColorScheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/colorscheme/), tous les objets qui référencent encore cette couleur de thème sont résolus par rapport à la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple de bout en bout suivant crée une forme qui utilise `Accent4`, change la couleur du thème `Accent4` en rouge, enregistre la présentation, la rouvre et affiche la couleur de remplissage effective :

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après la modification du thème. Si vous remplacez la couleur de schéma par une couleur directe sur la forme, les changements ultérieurs de `Accent4` n’affecteront plus ce remplissage.

### **Utiliser les couleurs de la palette supplémentaire**

PowerPoint génère des variantes plus claires et plus foncées à partir d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via l’énumération [ColorTransformOperation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/colortransformoperation/).

![Couleurs principales du thème et couleurs plus claires et plus foncées générées à partir de la palette supplémentaire](additional-palette-colors.png)

**1** - Couleurs principales du thème.  
**2** - Variantes plus claires et plus foncées produites à partir des couleurs principales du thème.

L’exemple suivant crée six rectangles basés sur `Accent4`, applique des transformations de luminance à cinq d’entre eux et enregistre le résultat :

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ces variantes restent basées sur la couleur du thème. Si `Accent4` change plus tard, les couleurs transformées sont recalculées à partir de la nouvelle valeur `Accent4`.

### **Faire correspondre les valeurs `SchemeColor` aux emplacements `ColorScheme`**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que le [ColorScheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/colorscheme/) expose les mêmes emplacements de thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mapping est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Il s’agit simplement de noms alternatifs pour les mêmes emplacements de thème ; ils ne sont pas des valeurs converties dynamiquement d’une forme à l’autre.

## **Modifier les polices du thème**

Un schéma de polices de thème contient un jeu de polices principal pour les titres et un jeu de polices secondaire pour le corps du texte. Les méthodes [FontScheme.getMajor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontscheme/) et [FontScheme.getMinor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontscheme/) exposent ces jeux.

Les identifiants de police compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn‑lt` - Police du corps Latin (Minor Latin Font)
* `+mj‑lt` - Police du titre Latin (Major Latin Font)
* `+mn‑ea` - Police du corps Est‑asiatique (Minor East Asian Font)
* `+mj‑ea` - Police du titre Est‑asiatique (Major East Asian Font)

L’exemple suivant crée un titre qui utilise la police Latin principale du thème et une ligne de corps qui utilise la police Latin secondaire du thème. Il modifie ensuite les polices du thème et enregistre le résultat :

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le titre suit la police principale et le texte du corps suit la police secondaire. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le schéma de polices du thème évoluera.

Les collections de polices principales et secondaires peuvent également contenir des correspondances de police pour des systèmes d’écriture individuels, tels que le cyrillique, l’arabe, le japonais, le géorgien et le thaana. Pour inspecter, ajouter, remplacer ou supprimer ces correspondances, consultez [Script‑Specific Theme Fonts](/slides/fr/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Pour plus d’informations sur les polices de présentation, voir [PowerPoint Fonts](/slides/fr/php-java/powerpoint-fonts/).

{{% /alert %}}

## **Copier ou appliquer un thème**

Les flux de travail ci‑dessous résolvent différents problèmes liés aux thèmes.

### **Appliquer un thème externe aux diapositives dépendantes d’un master**

Utilisez [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/) lorsqu’un fichier de thème PowerPoint (`.thmx`) doit être appliqué à chaque diapositive dépendant d’un master particulier. Sélectionnez le master dans la collection [Presentation::getMasters](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/), représentée par [MasterSlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslidecollection/), et transmettez le chemin du fichier thème à la méthode.

La méthode effectue les opérations suivantes :

1. Crée une nouvelle diapositive master basée sur le master sélectionné.  
1. Applique le thème externe au nouveau master.  
1. Associe le nouveau master à toutes les diapositives qui dépendaient auparavant du master sélectionné.  
1. Retourne le [MasterSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/) nouvellement créé.

L’exemple suivant applique un thème externe aux diapositives qui dépendent du premier master et enregistre la présentation :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Un thème invalide, corrompu ou non pris en charge peut entraîner une [PptxReadException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxreadexception/). Validez les chemins fournis par les utilisateurs, gérez les échecs d’accès au système de fichiers et n’enregistrez la présentation qu’après que le thème a été appliqué avec succès.

Seules les diapositives qui dépendaient du master sélectionné sont réaffectées. Les diapositives associées à d’autres masters conservent leurs masters et thèmes existants. Les couleurs, polices, remplissages, lignes, arrière‑plans et effets sensibles au thème sont résolus par rapport au thème externe. Les couleurs, polices, remplissages et autre formatage attribués directement peuvent rester inchangés. Les substitutions au niveau de la disposition ou de la diapositive peuvent également prévaloir sur les valeurs héritées du nouveau master.

Le thème peut référencer des polices non disponibles dans l’environnement d’exécution. Pour garantir un rendu et une exportation cohérents, installez les polices requises, fournissez‑les via [custom font sources](/slides/fr/php-java/custom-font/), ou configurez la [font substitution](/slides/fr/php-java/font-substitution/).

Il s’agit d’un flux de travail direct au niveau du master : la méthode accepte le chemin d’un fichier `.thmx` et ne nécessite aucune création manuelle de substitutions de thème au niveau de la diapositive ou de la disposition.

### **Appliquer différents thèmes externes dans une présentation multi‑master**

Lorsque le master pertinent n’est pas connu à l’avance, récupérez‑le depuis une diapositive représentative via [Slide::getLayoutSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/) et [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/). Conservez les références des masters originaux avant d’appliquer un thème, car chaque appel crée un nouveau master dans la présentation.

L’exemple suivant utilise des diapositives de deux sections pour localiser leurs masters et applique un thème externe différent à chaque groupe :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Le premier appel n’affecte que les diapositives dépendant de `$firstGroupMaster`, et le second appel n’affecte que celles dépendant de `$secondGroupMaster`. Les diapositives appartenant à tout autre master ne sont pas restylées.

### **Conserver le thème source lors du déplacement de diapositives**

Pour déplacer une diapositive vers une autre présentation tout en conservant son design original, clonez le master source dans la présentation cible avec [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslidecollection/), puis clonez la diapositive avec [SlideCollection.addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/) et le master cloné. Cela transporte le master, ses mises en page et le thème associé en même temps.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

C’est le flux de travail recommandé lorsque la diapositive source doit conserver le même aspect dans la destination. Simplement cloner le contenu sur un master de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets dictés par le thème.

### **Appliquer les valeurs du thème à une diapositive existante**

Si la diapositive cible doit rester sur son master et sa disposition actuels, initialisez une substitution de niveau diapositive à partir du thème source. Les méthodes [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fr/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fr/php-java/aspose.slides/overridetheme/) et [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fr/php-java/aspose.slides/overridetheme/) copient les trois principaux composants du thème dans la substitution.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Cela modifie le thème utilisé par cette diapositive sans toucher au thème hérité par les autres diapositives. Pour supprimer la substitution locale et revenir aux valeurs héritées, appelez [OverrideTheme.clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/overridetheme/).

### **Appliquer une substitution de thème à une disposition**

Une substitution au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, sauf si une diapositive particulière possède sa propre substitution. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslidethememanager/) :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Utilisez un thème au niveau du master ou de la présentation lorsque de nombreuses dispositions et diapositives doivent partager la même base de design, une substitution de disposition lorsqu’une famille de dispositions nécessite un style différent, et une substitution de diapositive uniquement pour de véritables exceptions. Un excès de substitutions au niveau de la diapositive rend les modifications globales du thème ultérieures plus difficiles à prévoir.

## **Mettre à jour les styles d’arrière‑plan du thème**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fr/php-java/aspose.slides/formatscheme/). PowerPoint peut proposer plus d’options d’arrière‑plan dans son interface utilisateur que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’UI peut combiner les remplissages de thème avec des couleurs de thème et d’autres références de style.

![Galerie de styles d’arrière‑plan PowerPoint pour un thème de présentation](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et l’indice de style actuel via [Background.getStyleIndex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/background/). Un indice de style de `0` signifie aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan du thème. Cela diffère de l’indexation directe de la collection PHP, où `get_Item(0)` désigne le premier élément stocké. Ne supposez pas que chaque présentation contienne le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, assigne une référence d’arrière‑plan thématisé au premier master et enregistre la présentation :

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat visible dépend de l’entrée de thème référencée par le master et d’éventuelles substitutions d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, la modification du seul arrière‑plan du master peut ne pas affecter cette diapositive. Utilisez [Background.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/background/) lorsque vous devez connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}

Ne traitez pas l’indice de style comme un indice de collection zéro‑basé. Évitez également de coder en dur un numéro de style provenant d’un fichier et de supposer qu’il aura le même aspect dans un autre fichier ; les définitions de style de thème sont spécifiques à chaque présentation.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Pour le formatage direct de l’arrière‑plan et l’héritage d’arrière‑plan, consultez [Presentation Background](/slides/fr/php-java/presentation-background/).

{{% /alert %}}

## **Mettre à jour les effets du thème**

Un schéma de formats de thème contient des collections séparées de remplissages, de lignes et d’effets exposées via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/fr/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/fr/php-java/aspose.slides/formatscheme/) et [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/fr/php-java/aspose.slides/formatscheme/). Les thèmes Office typiques contiennent souvent trois entrées de style principales qui correspondent visuellement à des formats subtils, modérés et intenses, mais le code doit inspecter chaque collection plutôt que de supposer un nombre fixe.

![Effets subtils, modérés et intenses d’un thème appliqués à la même forme](presentation-design_10.png)

Lorsque vous accédez à ces collections en PHP, l’indice de la collection est zéro‑basé : `get_Item(0)` est le premier style stocké et `get_Item(2)` le troisième. Les indices de référence de style d’une forme constituent un concept séparé, exposé via [ShapeStyle](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapestyle/). Modifier un style de thème affecte les formes qui le référencent ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, modifie le troisième style de remplissage, active une ombre externe dans le troisième style d’effet et enregistre le résultat :

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour les formes qui référencent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt plein, et le troisième style d’effet gagne une ombre externe avec une distance de 10 points. Le rendu visuel exact dépend toujours des emplacements de style référencés par chaque forme et d’éventuels formatages directs qui remplacent le thème.

![Styles d’effet du thème après modification des paramètres de ligne, remplissage et ombre](presentation-design_11.png)

## **Lire les valeurs effectives du thème**

Les objets de thème bruts indiquent ce qui est défini à un niveau particulier. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution de l’héritage et des substitutions locales. Pour une diapositive, appelez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseoverridethememanager/). Pour un arrière‑plan, utilisez [Background.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/background/), et pour un remplissage, utilisez [FillFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fillformat/).

L’exemple suivant lit le thème effectif, l’arrière‑plan et le premier remplissage de forme d’une diapositive :

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Utilisez les données effectives pour les diagnostics de rendu, la validation et les comparaisons. Si vous ne consultez que [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/), vous pouvez manquer une substitution au niveau du master, de la disposition, de la diapositive ou de la forme qui modifie l’apparence finale.

## **FAQ**

**L’application d’un thème externe affecte‑t‑elle chaque diapositive de la présentation ?**

Non. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/) ne réaffecte que les diapositives qui dépendent du master sélectionné. Les diapositives utilisant d’autres masters conservent leurs thèmes existants.

**Puis‑je appliquer un thème à une seule diapositive sans modifier le master ?**

Oui. Utilisez le [SlideThemeManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidethememanager/) de la diapositive et initialisez sa substitution de thème. La modification reste locale à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes existants.

**Quelle est la façon la plus sûre de transférer un thème d’une présentation à une autre ?**

Lorsque vous déplacez une diapositive tout en préservant son apparence source, clonez le master source dans la destination et clonez la diapositive avec ce master en utilisant [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslidecollection/) et [SlideCollection.addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/). Cela garde le master, les mises en page et le thème ensemble.

**Comment puis‑je voir les valeurs effectives après héritage et substitutions ?**

Utilisez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseoverridethememanager/) pour un thème de diapositive ou de disposition et les méthodes de données effectives correspondantes pour les objets de format tels que [Background.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/background/) et [FillFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fillformat/). Ces API renvoient les valeurs résolues après l’application de l’héritage et des substitutions.