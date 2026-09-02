---
title: Appliquer des animations de forme dans les présentations avec JavaScript
linktitle: Animation de forme
type: docs
weight: 60
url: /fr/nodejs-java/shape-animation/
keywords:
- forme
- animation
- effet
- forme animée
- texte animé
- ajouter une animation
- obtenir une animation
- extraire une animation
- ajouter un effet
- obtenir un effet
- extraire un effet
- son d’effet
- appliquer une animation
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à ajouter, inspecter et personnaliser les animations de forme, la synchronisation, les sons, le comportement après l'animation et le texte animé avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via Java représente les animations de diapositives sous forme d'effets dans une chronologie de diapositive. Un effet possède une forme cible, un type et un sous‑type d’animation, un déclencheur, des paramètres de synchronisation et des propriétés optionnelles telles que le son ou le comportement après l’animation.

La chronologie contient deux types de séquences :

- La **séquence principale** s’exécute au fur et à mesure que la diapositive progresse.
- Une **séquence interactive** démarre lorsque sa forme déclencheur est cliquée.

Comme les zones de texte, les images, les graphiques, les tableaux et les autres objets de diapositive sont des objets [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/), vous utilisez la même méthode [Sequence.addEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sequence/#addEffect) pour la plupart du contenu de la diapositive. Les effets disponibles sont répertoriés dans l’énumération [EffectType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effecttype/).

## **Ajouter des animations de forme**

Pour ajouter une animation, récupérez la séquence principale de la diapositive et appelez [Sequence.addEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sequence/#addEffect) avec la forme cible, le type d’effet, le sous‑type et le déclencheur. Pour un effet qui commence lorsqu’une autre forme est cliquée, créez une séquence interactive dont le déclencheur est cette autre forme.

L’exemple suivant crée les deux types d’animation et enregistre le résultat dans `shape-animations.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Click to animate this shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    const entranceEffect = mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    entranceEffect.getTiming().setDuration(java.newFloat(1.5));

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    presentation.save("shape-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le déclencheur contrôle le moment où un effet démarre :

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effecttriggertype/#OnClick) attend un clic dans la séquence principale, ou un clic sur la forme déclencheur dans une séquence interactive.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) démarre avec l’effet précédent.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) démarre lorsque l’effet précédent se termine.

Pour animer une image, un graphique ou tout autre type de forme, transmettez cet objet à [Sequence.addEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sequence/#addEffect) au lieu de `targetShape`. Pour les options de groupement spécifiques aux graphiques, consultez [Animated Charts](/slides/fr/nodejs-java/animated-charts/).

## **Lire les animations de forme**

Utilisez [Sequence.getEffectsByShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sequence/#getEffectsByShape) lorsque vous connaissez la forme cible. Pour inspecter chaque effet, énumérez la séquence principale et toutes les séquences interactives. L’énumération évite de supposer qu’une séquence contient un effet à l’index `0`.

L’exemple suivant crée une forme avec des effets de séquence principale et interactive, récupère les effets qui ciblent la forme, puis énumère chaque séquence de la diapositive.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printSequence(label, sequence) {
    console.log(`  ${label}: ${sequence.getCount()} effect(s)`);

    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);
        const targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        const triggerName = getEnumName(aspose.slides.EffectTriggerType, effect.getTiming().getTriggerType());
        console.log(`    ${typeName} ${subtypeName}; target: ${targetName}; trigger: ${triggerName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Animated shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const targetEffects = mainSequence.getEffectsByShape(targetShape);
    console.log(`The main sequence contains ${targetEffects.length} effect(s) for ${targetShape.getName()}.`);

    printSequence("Main sequence", mainSequence);

    const interactiveSequences = slide.getTimeline().getInteractiveSequences();
    for (let i = 0; i < interactiveSequences.getCount(); i++) {
        const sequence = interactiveSequences.get_Item(i);
        const triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
        printSequence(`Interactive sequence ${i + 1}, trigger: ${triggerName}`, sequence);
    }
} finally {
    presentation.dispose();
}
```

Si vous avez uniquement besoin des effets pour une forme, identifiez d’abord la forme par son nom, son type d’espace réservé ou une autre propriété stable ; puis appelez [Sequence.getEffectsByShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sequence/#getEffectsByShape). Ne supposez pas que [ShapeCollection.get_Item](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/#get_Item) à l’index `0` soit toujours l’objet souhaité.

## **Travailler avec les effets d’espace réservé hérités**

Un espace réservé sur une diapositive normale peut hériter du comportement d’animation de l’espace réservé correspondant sur sa diapositive modèle et sa diapositive maître. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getBasePlaceholder) renvoie cet espace réservé parent, ou `null` lorsqu’aucun parent n’existe.

Dans la présentation d’exemple suivante, le pied de page possède **Random Bars** sur la diapositive normale, **Split** sur la diapositive de disposition et **Fly In** sur la diapositive maître.

![Effet d’animation du pied de page sur la diapositive normale](slide-shape-animation.png)

![Effet d’animation du pied de page sur la diapositive de disposition](layout-shape-animation.png)

![Effet d’animation du pied de page sur la diapositive maître](master-shape-animation.png)

L’exemple suivant utilise une hiérarchie d’espaces réservés à partir d’une nouvelle présentation. Il ajoute des effets à un espace réservé maître, à un espace réservé de disposition et à l’espace réservé correspondant sur une diapositive normale. Chaque appel à [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getBasePlaceholder) est vérifié avant d’utiliser la forme renvoyée.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function findPlaceholderWithBase(baseSlide, expectedBase) {
    const shapes = baseSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const basePlaceholder = shape.getBasePlaceholder();

        if (basePlaceholder == null) {
            continue;
        }

        if (expectedBase == null || basePlaceholder.getPlaceholder().getType() === expectedBase.getPlaceholder().getType()) {
            return shape;
        }
    }

    return null;
}

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printEffects(source, effects) {
    console.log(`${source}: ${effects.length} effect(s)`);

    for (const effect of effects) {
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        console.log(`  ${typeName} ${subtypeName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const layoutSlide = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    const layoutPlaceholder = findPlaceholderWithBase(layoutSlide, null);

    if (layoutPlaceholder == null) {
        throw new Error("The layout slide does not contain a placeholder linked to its master slide.");
    }

    const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
    layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
    layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, aspose.slides.EffectType.Split, aspose.slides.EffectSubtype.VerticalIn, aspose.slides.EffectTriggerType.OnClick);

    const slide = presentation.getSlides().addEmptySlide(layoutSlide);
    const slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

    if (slidePlaceholder == null) {
        throw new Error("The slide does not contain a placeholder linked to its layout slide.");
    }

    slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, aspose.slides.EffectType.RandomBars, aspose.slides.EffectSubtype.Horizontal, aspose.slides.EffectTriggerType.OnClick);
    printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

    const baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
    if (baseLayoutPlaceholder != null) {
        printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

        const baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
        if (baseMasterPlaceholder != null) {
            printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
        }
    }

    presentation.save("placeholder-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Modifier la synchronisation d’une animation**

La boîte de dialogue **Timing** de PowerPoint correspond aux propriétés de [Timing](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/).

![Boîte de dialogue Timing de PowerPoint pour un effet d’animation](shape-animation.png)

- **Start** correspond à [Timing.getTriggerType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duration** correspond à [Timing.getDuration](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getDuration), en secondes.
- **Delay** correspond à [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getTriggerDelayTime), en secondes.
- **Repeat** correspond à [Timing.getRepeatCount](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) ou [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** correspond à [Timing.getRewind](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getRewind).

Cet exemple autonome ajoute un effet, modifie sa synchronisation via l’objet renvoyé par [Sequence.addEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sequence/#addEffect) et enregistre le résultat. Conserver la référence renvoyée à [Effect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effect/) évite un accès inutile à l’index de la collection.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Timed animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setDuration(java.newFloat(2.0));
    effect.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    effect.getTiming().setRepeatUntilNextClick(false);
    effect.getTiming().setRepeatUntilEndSlide(false);
    effect.getTiming().setRepeatCount(java.newFloat(2.0));
    effect.getTiming().setRewind(true);

    presentation.save("shape-animation-timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilisez un seul mode de répétition de manière intentionnelle. Combiner un compte de répétition avec un drapeau « until » peut produire des résultats déroutants selon les visionneuses. Lors du changement de mode de répétition, définissez d’abord [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) et [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) avant [Timing.setRepeatCount](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#setRepeatCount), car le réglage de l’un ou l’autre drapeau modifie également le mode de répétition actif.

## **Ajouter et extraire des sons d’animation**

Un effet d’animation peut référencer un audio intégré via [Effect.getSound](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effect/#setStopPreviousSound) indique à un effet d’arrêter le son lancé par un effet antérieur.

### **Ajouter un son à un effet**

L’exemple suivant suppose un fichier audio local nommé `animation-sound.wav`. Il crée deux effets, intègre ce fichier comme son du premier effet et configure le second effet pour arrêter le son. Il utilise les objets renvoyés par [Sequence.addEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sequence/#addEffect), aucune indexation de séquence n’est donc requise.

```javascript
const fs = require("fs");
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const firstShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 100, 240, 80);
    const secondShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 400, 100, 240, 80);
    firstShape.addTextFrame("Starts sound");
    secondShape.addTextFrame("Stops sound");

    const sequence = slide.getTimeline().getMainSequence();
    const firstEffect = sequence.addEffect(firstShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    const secondEffect = sequence.addEffect(secondShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const audioData = java.newArray("byte", Array.from(fs.readFileSync("animation-sound.wav")));
    const effectSound = presentation.getAudios().addAudio(audioData);
    firstEffect.setSound(effectSound);
    secondEffect.setStopPreviousSound(true);

    presentation.save("shape-animation-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Extraire les sons d’effet intégrés**

L’exemple suivant suppose une présentation locale nommée `presentation-with-animation-sounds.pptx`. Il parcourt les séquences principales et interactives et écrit chaque son d’effet intégré dans le répertoire `extracted-animation-sounds`. L’extension est choisie à partir du type MIME audio exposé par [Audio.getContentType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audio/#getContentType).

```javascript
const fs = require("fs");
const path = require("path");
const aspose = { slides: require("aspose.slides.via.java") };

function getAudioExtension(contentType) {
    const normalizedType = contentType == null ? "" : contentType.toLowerCase();

    if (normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if (normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if (normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if (normalizedType === "audio/wav" || normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds(sequence, outputDirectory, soundIndex) {
    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);

        if (effect.getSound() == null) {
            continue;
        }

        const extension = getAudioExtension(effect.getSound().getContentType());
        const outputPath = path.join(outputDirectory, `effect-sound-${soundIndex}${extension}`);
        fs.writeFileSync(outputPath, Buffer.from(effect.getSound().getBinaryData()));
        soundIndex++;
    }

    return soundIndex;
}

const outputDirectory = "extracted-animation-sounds";
fs.mkdirSync(outputDirectory, { recursive: true });

const presentation = new aspose.slides.Presentation("presentation-with-animation-sounds.pptx");
try {
    let soundIndex = 1;

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

        const interactiveSequences = slide.getTimeline().getInteractiveSequences();
        for (let sequenceIndex = 0; sequenceIndex < interactiveSequences.getCount(); sequenceIndex++) {
            soundIndex = saveSounds(interactiveSequences.get_Item(sequenceIndex), outputDirectory, soundIndex);
        }
    }

    console.log(`Extracted ${soundIndex - 1} sound file(s) to ${path.resolve(outputDirectory)}.`);
} finally {
    presentation.dispose();
}
```

Pour les objets audio volumineux, utilisez [Audio.getStream](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audio/#getStream) et copiez le flux dans un fichier au lieu de charger l’ensemble de l’objet dans un tableau d’octets.

## **Définir le comportement après l’animation**

L’option **After animation** contrôle ce qui arrive à une forme après la fin de son effet.

![Boîte de dialogue Options d’effet de PowerPoint affichant les paramètres After animation](shape-after-animation.png)

L’énumération [AfterAnimationType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/afteranimationtype/) permet de laisser la forme inchangée, de changer sa couleur, de la masquer après l’animation ou de la masquer au clic suivant. Lorsque le type est [AfterAnimationType.Color](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/afteranimationtype/#Color), définissez également [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Cet exemple autonome crée un effet, définit son comportement après l’animation via l’objet effet renvoyé, et enregistre le résultat.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Dim after animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    effect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("shape-animation-after-effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Changer le type autre que [AfterAnimationType.Color](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/afteranimationtype/#Color) réinitialise le paramètre de couleur après l’animation.

## **Animer du texte**

L’animation du texte possède deux contrôles associés :

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textanimation/#getBuildType) contrôle si les paragraphes apparaissent ensemble ou par niveau de paragraphe.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effect/#getAnimateTextType) contrôle si le texte apparaît en une fois, par mot ou par lettre. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) fixe le délai entre les mots ou les lettres. Une valeur positive représente un pourcentage de la durée de l’effet ; une valeur négative représente un délai en secondes.

L’exemple autonome suivant anime les mots d’une zone de texte. [BuildType.AsOneObject](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/buildtype/#AsOneObject) désactive le montage paragraphe par paragraphe afin que le paramètre de mot s’applique à l’ensemble du cadre de texte.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 560, 100);
    textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

    const effect = slide.getTimeline().getMainSequence().addEffect(textBox, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    effect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    effect.setDelayBetweenTextParts(java.newFloat(20.0));

    presentation.save("animated-text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour construire une zone de texte paragraphe par paragraphe, définissez [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (ou un autre niveau de paragraphe). Pour cibler un seul paragraphe avec son propre effet, utilisez la surcharge de [Sequence.addEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sequence/#addEffect) qui accepte un [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/). Consultez [Animated Text](/slides/fr/nodejs-java/animated-text/) pour des exemples au niveau du paragraphe.

## **Exportation et notes de compatibilité**

- L’enregistrement en PPT ou PPTX préserve le modèle d’animation, mais la lecture finale est contrôlée par le visualiseur de présentation.
- Les PDF et les images statiques ne lisent pas les animations. Utilisez l’[exportation HTML5](/slides/fr/nodejs-java/export-to-html5/), les GIF animés ou la [conversion vidéo](/slides/fr/nodejs-java/convert-powerpoint-to-video/) lorsque la sortie doit montrer du mouvement.
- Pour HTML5, activez [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/html5options/#setAnimateShapes) et, si nécessaire, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- Le rendu vidéo prend en charge de nombreux effets d’entrée, d’accentuation, de sortie et de trajectoire, mais tous les effets PowerPoint ne sont pas supportés. Consultez la page actuelle des [animations et effets pris en charge](/slides/fr/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) et testez les présentations critiques avec la version Aspose.Slides que vous utilisez.
- Les effets personnalisés avancés et les effets importés d’autres formats de présentation peuvent être conservés dans le fichier mais rendus différemment dans PowerPoint, HTML5 ou vidéo. Validez le résultat exporté plutôt que de vous fier uniquement au nom de l’effet.

## **FAQ**

**Pourquoi une animation apparaît‑elle dans PowerPoint mais pas dans un PDF ?**

Le PDF est un format statique, donc les animations et les transitions de diapositive ne sont pas lues. Exportez en HTML5, GIF animé ou vidéo lorsque le mouvement doit être conservé.

**Pourquoi un effet se lit‑il différemment dans une vidéo ?**

L’exportation vidéo rend les animations plutôt que de stocker le comportement PowerPoint d’origine. Certains effets avancés ne sont pas pris en charge ou sont approximés. Consultez le tableau des effets pris en charge et testez la présentation réelle avant de l’utiliser en production.

**Déplacer une forme vers l’avant ou l’arrière modifie‑t‑il l’ordre de son animation ?**

Non. L’ordre Z de la forme contrôle le chevauchement, tandis que l’ordre des séquences et les déclencheurs contrôlent la lecture de l’animation. Modifiez la chronologie si vous avez besoin d’un ordre de lecture différent.