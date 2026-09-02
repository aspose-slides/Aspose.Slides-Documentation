---
title: Appliquer des animations de formes dans les présentations avec Java
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
- ajouter une animation
- récupérer une animation
- extraire une animation
- ajouter un effet
- récupérer un effet
- extraire un effet
- son d'effet
- appliquer une animation
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez comment ajouter, inspecter et personnaliser les animations de formes, le minutage, les sons, le comportement après l'animation et le texte animé avec Aspose.Slides pour Java."
---
## **Vue d'ensemble**

Aspose.Slides for Java représente les animations de diapositive comme des effets dans une chronologie de diapositive. Un effet possède une forme cible, un type et sous‑type d’animation, un déclencheur, des paramètres de minutage et des propriétés optionnelles telles que le son ou le comportement après l’animation.

La chronologie contient deux types de séquences :

- La **séquence principale** s’exécute au fur et à mesure que la diapositive avance.  
- Une **séquence interactive** démarre lorsque sa forme déclencheur est cliquée.

Comme les zones de texte, les images, les graphiques, les tableaux et les autres objets de diapositive implémentent [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/), vous utilisez la même méthode [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) pour la plupart du contenu de diapositive. Les effets disponibles sont listés dans la classe [EffectType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/effecttype/).

## **Ajouter des animations de forme**

Pour ajouter une animation, récupérez la séquence principale de la diapositive et appelez [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) avec la forme cible, le type d’effet, le sous‑type et le déclencheur. Pour un effet qui démarre lorsqu’une autre forme est cliquée, créez une séquence interactive dont le déclencheur est cette autre forme.

L’exemple suivant crée les deux types d’animation et enregistre le résultat dans `shape-animations.pptx`.

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
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/fr/java/com.aspose.slides/effecttriggertype/#WithPrevious) démarre avec l’effet précédent.  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/fr/java/com.aspose.slides/effecttriggertype/#AfterPrevious) démarre lorsque l’effet précédent se termine.

Pour animer une image, un graphique ou un autre type de forme, transmettez cet objet à [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) au lieu de `targetShape`. Pour les options de groupement propres aux graphiques, consultez [Animated Charts](/slides/fr/java/animated-charts/).

## **Lire les animations de forme**

Utilisez [ISequence.getEffectsByShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) lorsque vous connaissez la forme cible. Pour examiner chaque effet, parcourez la séquence principale et chaque séquence interactive. L’énumération évite de supposer qu’une séquence contient un effet à l’index `0`.

L’exemple suivant crée une forme avec des effets de séquence principale et interactive, récupère les effets qui ciblent la forme, puis parcourt chaque séquence de la diapositive.

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

Si vous avez seulement besoin des effets d’une forme, identifiez d’abord la forme par son nom, son type de paramètre ou une autre propriété stable ; puis appelez [ISequence.getEffectsByShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Ne supposez pas que [IShapeCollection.get_Item](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#get_Item-int-) à l’index `0` soit toujours l’objet souhaité.

## **Travailler avec les effets de paramètres hérités**

Un paramètre sur une diapositive normale peut hériter du comportement d’animation du paramètre correspondant sur sa diapositive de mise en page et sur le masque principal. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getBasePlaceholder--) renvoie ce paramètre parent, ou `null` lorsqu’aucun parent n’existe.

Dans la présentation d’exemple suivante, le pied de page possède **Random Bars** sur la diapositive normale, **Split** sur la diapositive de mise en page et **Fly In** sur le masque principal.

![Effet d’animation du pied de page sur la diapositive normale](slide-shape-animation.png)

![Effet d’animation du paramètre pied de page sur la diapositive de mise en page](layout-shape-animation.png)

![Effet d’animation du paramètre pied de page sur le masque principal](master-shape-animation.png)

L’exemple suivant utilise une hiérarchie de paramètres provenant d’une nouvelle présentation. Il ajoute des effets à un paramètre de masque, à un paramètre de mise en page et au paramètre correspondant sur une diapositive normale. Chaque appel à [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getBasePlaceholder--) est vérifié avant d’utiliser la forme retournée.

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

## **Modifier le minutage de l’animation**

Le dialogue **Timing** de PowerPoint correspond aux propriétés de [ITiming](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/).

![Dialogue Timing de PowerPoint pour un effet d’animation](shape-animation.png)

- **Start** correspond à [ITiming.getTriggerType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getTriggerType--).  
- **Duration** correspond à [ITiming.getDuration](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getDuration--), en secondes.  
- **Delay** correspond à [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getTriggerDelayTime--), en secondes.  
- **Repeat** correspond à [ITiming.getRepeatCount](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), ou [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).  
- **Rewind when done playing** correspond à [ITiming.getRewind](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getRewind--).

Cet exemple indépendant ajoute un effet, modifie son minutage via l’objet retourné par [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), puis enregistre le résultat. Conserver la référence [IEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/) retournée évite un accès inutile par indice de collection.

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

Utilisez un seul mode de répétition intentionnellement. Combiner un nombre de répétitions avec un drapeau « until » peut produire des résultats confus selon les visionneuses. Lors du changement de mode, définissez [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) et [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) avant [ITiming.setRepeatCount](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#setRepeatCount-float-), car la configuration de l’un des drapeaux modifie également le mode de répétition actif.

## **Ajouter et extraire des sons d’animation**

Un effet d’animation peut référencer un audio intégré via [IEffect.getSound](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) indique à un effet d’arrêter le son démarré par un effet précédent.

### **Ajouter un son à un effet**

L’exemple suivant attend un fichier audio local nommé `animation-sound.wav`. Il crée deux effets, intègre ce fichier comme son du premier effet, et configure le deuxième effet pour arrêter le son. Il utilise les objets retournés par [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), aucune référence d’indice de séquence n’est nécessaire.

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

### **Extraire les sons d’effets intégrés**

L’exemple suivant attend une présentation locale nommée `presentation-with-animation-sounds.pptx`. Il parcourt les séquences principale et interactive et écrit chaque son d’effet intégré dans le répertoire `extracted-animation-sounds`. L’extension est choisie à partir du type MIME audio exposé par [IAudio.getContentType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaudio/#getContentType--).

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

Pour les objets audio volumineux, utilisez [IAudio.getStream](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaudio/#getStream--) et copiez le flux vers un fichier au lieu de charger l’objet complet dans un tableau d’octets.

## **Définir le comportement après l’animation**

L’option **After animation** contrôle ce qui arrive à une forme après la fin de son effet.

![Dialogue Options d’effet de PowerPoint affichant les paramètres After animation](shape-after-animation.png)

La classe [AfterAnimationType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/afteranimationtype/) prend en charge le fait de laisser la forme inchangée, de changer sa couleur, de la masquer après l’animation ou de la masquer au clic suivant. Lorsque le type est [AfterAnimationType.Color](https://reference.aspose.com/slides/fr/java/com.aspose.slides/afteranimationtype/#Color), définissez également [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Cet exemple autonome crée un effet, définit son comportement après l’animation via l’objet effet retourné, puis enregistre le résultat.

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

Modifier le type hors de [AfterAnimationType.Color](https://reference.aspose.com/slides/fr/java/com.aspose.slides/afteranimationtype/#Color) supprime le réglage de couleur après l’animation.

## **Animer du texte**

L’animation de texte possède deux contrôles liés :

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextanimation/#getBuildType--) contrôle si les paragraphes apparaissent ensemble ou par niveau de paragraphe.  
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getAnimateTextType--) contrôle si le texte apparaît en une fois, par mot ou par lettre. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) définit le délai entre les mots ou les lettres. Une valeur positive représente un pourcentage de la durée de l’effet ; une valeur négative représente un délai en secondes.

L’exemple autonome suivant anime les mots d’une zone de texte. [BuildType.AsOneObject](https://reference.aspose.com/slides/fr/java/com.aspose.slides/buildtype/#AsOneObject) désactive le montage paragraphe par paragraphe afin que le réglage de mot s’applique à tout le cadre de texte.

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

Pour construire une zone de texte paragraphe par paragraphe, définissez [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fr/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (ou un autre niveau de paragraphe). Pour cibler un paragraphe unique avec son propre effet, utilisez la surcharge [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) qui accepte un [IParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/). Consultez [Animated Text](/slides/fr/java/animated-text/) pour des exemples au niveau du paragraphe.

## **Exportation et notes de compatibilité**

- L’enregistrement en PPT ou PPTX conserve le modèle d’animation, mais la lecture finale dépend du visionneur de présentation.  
- PDF et images statiques ne lisent pas les animations. Utilisez l’[exportation HTML5](/slides/fr/java/export-to-html5/), les GIF animés ou la [conversion vidéo](/slides/fr/java/convert-powerpoint-to-video/) lorsque le résultat doit montrer du mouvement.  
- Pour HTML5, activez [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) et, si nécessaire, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).  
- Le rendu vidéo prend en charge de nombreux effets d’entrée, d’emphase, de sortie et de trajectoire, mais tous les effets PowerPoint ne sont pas supportés. Consultez la page actuelle des [animations et effets supportés](/slides/fr/java/convert-powerpoint-to-video/#supported-animations-and-effects) et testez les présentations critiques avec votre version cible d’Aspose.Slides.  
- Les effets personnalisés avancés et les effets importés d’autres formats peuvent être conservés dans le fichier mais se rendre différemment dans PowerPoint, HTML5 ou la vidéo. Validez le résultat exporté plutôt que de vous fier uniquement au nom de l’effet.

## **FAQ**

**Pourquoi une animation apparaît‑elle dans PowerPoint mais pas dans un PDF ?**

Le PDF est un format statique, donc les animations et les transitions de diapositive ne sont pas lues. Exportez en HTML5, GIF animé ou vidéo lorsque le mouvement doit être conservé.

**Pourquoi un effet se comporte‑t‑il différemment dans une vidéo ?**

L’exportation vidéo rend les animations au lieu de conserver le comportement PowerPoint d’origine. Certains effets avancés ne sont pas pris en charge ou sont approximés. Consultez le tableau des effets pris en charge et testez la présentation réelle avant la mise en production.

**Déplacer une forme vers l’avant ou vers l’arrière change‑t‑il l’ordre de son animation ?**

Non. L’ordre Z de la forme contrôle le chevauchement, tandis que l’ordre des séquences et les déclencheurs contrôlent la lecture des animations. Modifiez la chronologie si vous avez besoin d’un ordre de lecture différent.