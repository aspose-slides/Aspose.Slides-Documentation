---
title: Appliquer des animations de forme dans les présentations avec Java
linktitle: Animation de forme
type: docs
weight: 60
url: /fr/java/shape-animation/
keywords:
- forme
- animation
- effet
- forme animée
- texte animé
- ajouter animation
- obtenir animation
- extraire animation
- ajouter effet
- obtenir effet
- extraire effet
- son d'effet
- appliquer animation
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment ajouter, inspecter et personnaliser les animations de formes, la synchronisation, les sons, le comportement après l'animation et le texte animé avec Aspose.Slides pour Java."
---
## **Vue d'ensemble**

Pour travailler avec les comportements individuels à l'intérieur d'un effet ou modifier les segments de trajectoire de mouvement, consultez [Animation personnalisée](/slides/fr/java/custom-animation/).

Aspose.Slides for Java représente les animations de diapositive sous forme d'effets dans une chronologie de diapositive. Un effet possède une forme cible, un type et un sous‑type d'animation, un déclencheur, des paramètres de synchronisation et des propriétés optionnelles telles que le son ou le comportement après l'animation.

La chronologie contient deux types de séquences :

- La **séquence principale** se lit au fur et à mesure que la diapositive avance.
- Une **séquence interactive** démarre lorsque sa forme déclencheur est cliquée.

Étant donné que les zones de texte, images, graphiques, tableaux et autres objets de diapositive implémentent [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/), vous utilisez la même méthode [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) pour la plupart du contenu de diapositive. Les effets disponibles sont répertoriés dans la classe [EffectType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/effecttype/).

## **Ajouter des animations de forme**

Pour ajouter une animation, récupérez la séquence principale de la diapositive et appelez [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) avec la forme cible, le type d'effet, le sous‑type et le déclencheur. Pour un effet qui démarre lorsqu'une autre forme est cliquée, créez une séquence interactive dont le déclencheur est cette autre forme.

L'exemple suivant crée les deux types d'animation et enregistre le résultat dans `shape-animations.pptx`.

```java
import com.aspose.slides.*;

public class AddShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);

            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Click to animate this shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            IEffect entranceEffect = mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            entranceEffect.getTiming().setDuration(1.5f);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            presentation.save("shape-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Le déclencheur contrôle le moment où un effet démarre :

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/fr/java/com.aspose.slides/effecttriggertype/#OnClick) attend un clic dans la séquence principale, ou un clic sur la forme déclencheur dans une séquence interactive.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/fr/java/com.aspose.slides/effecttriggertype/#WithPrevious) démarre avec l'effet précédent.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/fr/java/com.aspose.slides/effecttriggertype/#AfterPrevious) démarre lorsque l'effet précédent se termine.

Pour animer une image, un graphique ou tout autre type de forme, transmettez cet objet à [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) à la place de `targetShape`. Pour les options de groupement spécifiques aux graphiques, consultez [Graphiques animés](/slides/fr/java/animated-charts/).

## **Lire les animations de forme**

Utilisez [ISequence.getEffectsByShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) lorsque vous connaissez la forme cible. Pour inspecter chaque effet, énumérez la séquence principale et toutes les séquences interactives. L'énumération évite de supposer qu'une séquence contient un effet à l'index `0`.

L'exemple suivant crée une forme avec des effets de séquence principale et interactive, récupère les effets qui ciblent la forme, puis énumère chaque séquence de la diapositive.

```java
import com.aspose.slides.*;

public class ReadShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Animated shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            IEffect[] targetEffects = mainSequence.getEffectsByShape(targetShape);
            System.out.println("The main sequence contains " + targetEffects.length + " effect(s) for " + targetShape.getName() + ".");

            printSequence("Main sequence", mainSequence);

            int interactiveIndex = 1;
            for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                String triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
                String sequenceLabel = "Interactive sequence " + interactiveIndex + ", trigger: " + triggerName;
                printSequence(sequenceLabel, sequence);
                interactiveIndex++;
            }
        } finally {
            presentation.dispose();
        }
    }

    private static void printSequence(String label, ISequence sequence) {
        System.out.println("  " + label + ": " + sequence.getCount() + " effect(s)");

        for (IEffect effect : sequence) {
            String targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            String triggerName = EffectTriggerType.getName(EffectTriggerType.class, effect.getTiming().getTriggerType());
            String effectDescription = typeName + " " + subtypeName + "; target: " + targetName + "; trigger: " + triggerName;
            System.out.println("    " + effectDescription);
        }
    }
}
```

Si vous ne avez besoin que des effets pour une seule forme, identifiez d'abord la forme par son nom, son type d'espace réservé ou toute autre propriété stable ; puis appelez [ISequence.getEffectsByShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Ne supposez pas que [IShapeCollection.get_Item](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#get_Item-int-) à l'index `0` soit toujours l'objet souhaité.

## **Travailler avec les effets d'espace réservé hérités**

Un espace réservé sur une diapositive normale peut hériter du comportement d'animation de l'espace réservé correspondant sur sa diapositive de mise en page et sur la diapositive maître. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getBasePlaceholder--) renvoie cet espace réservé parent, ou `null` s'il n'existe aucun parent.

Dans la présentation d'exemple suivante, le pied de page possède **Barres aléatoires** sur la diapositive normale, **Division** sur la diapositive de mise en page, et **Entrée en vol** sur la diapositive maître.

![Animation d'effet du pied de page sur la diapositive normale](slide-shape-animation.png)

![Animation d'effet du pied de page sur la diapositive de mise en page](layout-shape-animation.png)

![Animation d'effet du pied de page sur la diapositive maître](master-shape-animation.png)

L'exemple suivant utilise une hiérarchie d'espaces réservés d'une nouvelle présentation. Il ajoute des effets à un espace réservé maître, à un espace réservé de mise en page et à l'espace réservé correspondant sur une diapositive normale. Chaque appel à [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getBasePlaceholder--) est vérifié avant d'utiliser la forme renvoyée.

```java
import com.aspose.slides.*;

public class InheritedPlaceholderAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);
            IShape layoutPlaceholder = findPlaceholderWithBase(layoutSlide);

            if (layoutPlaceholder == null) {
                throw new IllegalStateException("The layout slide does not contain a placeholder linked to its master slide.");
            }

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
            layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

            ISlide slide = presentation.getSlides().addEmptySlide(layoutSlide);
            IShape slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

            if (slidePlaceholder == null) {
                throw new IllegalStateException("The slide does not contain a placeholder linked to its layout slide.");
            }

            slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
            printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

            IShape baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
            if (baseLayoutPlaceholder != null) {
                printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

                IShape baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
                if (baseMasterPlaceholder != null) {
                    printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
                }
            }

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static IShape findPlaceholderWithBase(ILayoutSlide layoutSlide) {
        for (IShape shape : layoutSlide.getShapes()) {
            if (shape.getBasePlaceholder() != null) {
                return shape;
            }
        }

        return null;
    }

    private static IShape findPlaceholderWithBase(ISlide slide, IShape expectedBase) {
        for (IShape shape : slide.getShapes()) {
            if (shape.getBasePlaceholder() == expectedBase) {
                return shape;
            }
        }

        return null;
    }

    private static void printEffects(String source, IEffect[] effects) {
        System.out.println(source + ": " + effects.length + " effect(s)");

        for (IEffect effect : effects) {
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            System.out.println("  " + typeName + " " + subtypeName);
        }
    }
}
```

## **Modifier la synchronisation d'animation**

Le dialogue **Synchronisation** de PowerPoint correspond aux propriétés de [ITiming](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/).

![Dialogue de synchronisation PowerPoint pour un effet d'animation](shape-animation.png)

- **Début** correspond à [ITiming.getTriggerType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getTriggerType--).
- **Durée** correspond à [ITiming.getDuration](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getDuration--), en secondes.
- **Retard** correspond à [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getTriggerDelayTime--), en secondes.
- **Répéter** correspond à [ITiming.getRepeatCount](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), ou [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rembobiner à la fin de la lecture** correspond à [ITiming.getRewind](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getRewind--).

Cet exemple indépendant ajoute un effet, modifie sa synchronisation via l'objet renvoyé par [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), et enregistre le résultat. Conserver la référence [IEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/) renvoyée évite un accès inutile à un indice de collection.

```java
import com.aspose.slides.*;

public class ChangeAnimationTiming {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Timed animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTiming().setTriggerType(EffectTriggerType.OnClick);
            effect.getTiming().setDuration(2.0f);
            effect.getTiming().setTriggerDelayTime(0.5f);
            effect.getTiming().setRepeatUntilNextClick(false);
            effect.getTiming().setRepeatUntilEndSlide(false);
            effect.getTiming().setRepeatCount(2.0f);
            effect.getTiming().setRewind(true);

            presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Utilisez un mode de répétition de manière intentionnelle. Combiner un nombre de répétitions avec un drapeau « jusqu'à » peut produire des résultats confus selon les visionneuses. Lors du changement de mode de répétition, définissez d'abord [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) et [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) avant [ITiming.setRepeatCount](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#setRepeatCount-float-), car le réglage de l'un ou l'autre drapeau modifie également le mode de répétition actif.

## **Ajouter et extraire des sons d'animation**

Un effet d'animation peut référencer un audio intégré via [IEffect.getSound](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) indique à un effet d'arrêter le son démarré par un effet antérieur.

### **Ajouter un son à un effet**

L'exemple suivant suppose un fichier audio local nommé `animation-sound.wav`. Il crée deux effets, intègre ce fichier comme son du premier effet, et configure le deuxième effet pour arrêter le son. Il utilise les objets renvoyés par [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), aucun indice de séquence n'est donc requis.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class AddAnimationSound {
    public static void main(String[] args) throws IOException {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
            IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
            firstShape.addTextFrame("Starts sound");
            secondShape.addTextFrame("Stops sound");

            ISequence sequence = slide.getTimeline().getMainSequence();
            IEffect firstEffect = sequence.addEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            IEffect secondEffect = sequence.addEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            byte[] audioData = Files.readAllBytes(Paths.get("animation-sound.wav"));
            IAudio effectSound = presentation.getAudios().addAudio(audioData);
            firstEffect.setSound(effectSound);
            secondEffect.setStopPreviousSound(true);

            presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

### **Extraire les sons d'effet intégrés**

L'exemple suivant suppose une présentation locale nommée `presentation-with-animation-sounds.pptx`. Il parcourt les séquences principales et interactives et écrit chaque son d'effet intégré dans le répertoire `extracted-animation-sounds`. L'extension est choisie en fonction du type MIME audio exposé par [IAudio.getContentType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaudio/#getContentType--).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

public class ExtractAnimationSounds {
    public static void main(String[] args) throws IOException {
        Path inputPath = Paths.get("presentation-with-animation-sounds.pptx");
        Path outputDirectory = Paths.get("extracted-animation-sounds");

        Files.createDirectories(outputDirectory);

        Presentation presentation = new Presentation(inputPath.toString());
        try {
            int soundIndex = 1;

            for (ISlide slide : presentation.getSlides()) {
                soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

                for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                    soundIndex = saveSounds(sequence, outputDirectory, soundIndex);
                }
            }

            System.out.println("Extracted " + (soundIndex - 1) + " sound file(s) to " + outputDirectory.toAbsolutePath() + ".");
        } finally {
            presentation.dispose();
        }
    }

    private static int saveSounds(ISequence sequence, Path outputDirectory, int soundIndex) throws IOException {
        for (IEffect effect : sequence) {
            if (effect.getSound() == null) {
                continue;
            }

            String extension = getAudioExtension(effect.getSound().getContentType());
            Path outputPath = outputDirectory.resolve("effect-sound-" + soundIndex + extension);
            Files.write(outputPath, effect.getSound().getBinaryData());
            soundIndex++;
        }

        return soundIndex;
    }

    private static String getAudioExtension(String contentType) {
        String normalizedType = contentType == null ? "" : contentType.toLowerCase(Locale.ROOT);

        if (normalizedType.equals("audio/mpeg")) {
            return ".mp3";
        }

        if (normalizedType.equals("audio/mp4")) {
            return ".m4a";
        }

        if (normalizedType.equals("audio/ogg")) {
            return ".ogg";
        }

        if (normalizedType.equals("audio/wav") || normalizedType.equals("audio/x-wav")) {
            return ".wav";
        }

        return ".bin";
    }
}
```

Pour les gros objets audio, utilisez [IAudio.getStream](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaudio/#getStream--) et copiez le flux dans un fichier plutôt que de charger l'objet entier dans un tableau d'octets.

## **Définir le comportement après l'animation**

L'option **Après animation** contrôle ce qui arrive à une forme après la fin de son effet.

![Dialogue Options d'effet PowerPoint affichant les paramètres Après animation](shape-after-animation.png)

La classe [AfterAnimationType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/afteranimationtype/) permet de laisser la forme inchangée, de modifier sa couleur, de la masquer après l'animation, ou de la masquer au clic suivant. Lorsque le type est [AfterAnimationType.Color](https://reference.aspose.com/slides/fr/java/com.aspose.slides/afteranimationtype/#Color), définissez également [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Cet exemple indépendant crée un effet, définit son comportement après animation via l'objet effet renvoyé, et enregistre le résultat.

```java
import com.aspose.slides.*;
import java.awt.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Modifier le type en dehors de [AfterAnimationType.Color](https://reference.aspose.com/slides/fr/java/com.aspose.slides/afteranimationtype/#Color) réinitialise le paramètre de couleur après animation.

## **Animer du texte**

L'animation de texte possède deux contrôles liés :

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextanimation/#getBuildType--) contrôle si les paragraphes apparaissent ensemble ou par niveau de paragraphe.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getAnimateTextType--) contrôle si le texte apparaît en une fois, mot par mot ou lettre par lettre. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) définit le délai entre les mots ou les lettres. Une valeur positive représente un pourcentage de la durée de l'effet ; une valeur négative représente un délai en secondes.

L'exemple indépendant suivant anime les mots d'une zone de texte. [BuildType.AsOneObject](https://reference.aspose.com/slides/fr/java/com.aspose.slides/buildtype/#AsOneObject) désactive la construction paragraphe par paragraphe afin que le paramètre mot s'applique à l'ensemble du cadre de texte.

```java
import com.aspose.slides.*;

public class AnimateTextByWord {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
            textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTextAnimation().setBuildType(BuildType.AsOneObject);
            effect.setAnimateTextType(AnimateTextType.ByWord);
            effect.setDelayBetweenTextParts(20.0f);

            presentation.save("animated-text.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Pour construire une zone de texte paragraphe par paragraphe, définissez [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fr/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (ou un autre niveau de paragraphe). Pour cibler un seul paragraphe avec son propre effet, utilisez la surcharge [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) qui accepte un [IParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/). Consultez [Texte animé](/slides/fr/java/animated-text/) pour des exemples au niveau du paragraphe.

## **Exportation et notes de compatibilité**

- L'enregistrement au format PPT ou PPTX préserve le modèle d'animation, mais la lecture finale dépend du visionneur de présentation.
- Le PDF et les images statiques ne lisent pas les animations. Utilisez [l'exportation HTML5](/slides/fr/java/export-to-html5/), GIF animé ou [conversion vidéo](/slides/fr/java/convert-powerpoint-to-video/) lorsque la sortie doit montrer le mouvement.
- Pour HTML5, activez [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) et, si nécessaire, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Le rendu vidéo prend en charge de nombreux effets d'entrée, d'emphase, de sortie et de trajectoire, mais tous les effets PowerPoint ne sont pas supportés. Consultez la page [animations et effets pris en charge](/slides/fr/java/convert-powerpoint-to-video/#supported-animations-and-effects) et testez les présentations critiques avec votre version cible d'Aspose.Slides.
- Les effets personnalisés avancés et les effets importés d'autres formats de présentation peuvent être conservés dans le fichier mais affichés différemment dans PowerPoint, HTML5 ou vidéo. Validez le résultat exporté plutôt que de vous fier uniquement au nom de l'effet.

## **FAQ**

**Pourquoi une animation apparaît‑elle dans PowerPoint mais pas dans un PDF ?**

Le PDF est un format statique, donc les animations et les transitions de diapositive ne sont pas lues. Exportez vers HTML5, GIF animé ou vidéo lorsque le mouvement doit être conservé.

**Pourquoi un effet se lit‑il différemment dans une vidéo ?**

L'exportation vidéo rend les animations plutôt que de stocker le comportement original de PowerPoint. Certains effets avancés ne sont pas pris en charge ou sont approximés. Consultez le tableau des effets pris en charge et testez la présentation réelle avant une utilisation en production.

**Le fait de déplacer une forme vers l'avant ou vers l'arrière modifie‑t‑il son ordre d'animation ?**

Non. L'ordre Z de la forme contrôle le chevauchement, tandis que l'ordre des séquences et les déclencheurs contrôlent la lecture des animations. Modifiez la chronologie si vous avez besoin d'un ordre de lecture différent.