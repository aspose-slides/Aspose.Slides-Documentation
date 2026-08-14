---
title: Appliquer des animations de forme dans les présentations en .NET
linktitle: Animation de forme
type: docs
weight: 60
url: /fr/net/shape-animation/
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
- son d'effet
- appliquer une animation
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez comment ajouter, inspecter et personnaliser les animations de forme, la synchronisation, les sons, le comportement après l'animation et le texte animé avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Aspose.Slides pour .NET représente les animations de diapositives sous forme d'effets dans une ligne de temps de diapositive. Un effet possède une forme cible, un type et un sous‑type d'animation, un déclencheur, des paramètres de synchronisation et des propriétés optionnelles telles que le son ou le comportement après l'animation.

La ligne de temps contient deux types de séquences :

- **séquence principale** se joue au fur et à mesure que la diapositive progresse.  
- **séquence interactive** démarre lorsque sa forme déclencheur est cliquée.

Comme les zones de texte, les images, les graphiques, les tableaux et les autres objets de diapositive implémentent [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/), vous utilisez la même méthode [ISequence.AddEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/isequence/addeffect/) pour la plupart du contenu de diapositive. Les effets disponibles sont listés dans l’énumération [EffectType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/effecttype/).

## **Ajouter des animations de forme**

Pour ajouter une animation, récupérez la séquence principale de la diapositive et appelez [ISequence.AddEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/isequence/addeffect/) avec la forme cible, le type d'effet, le sous‑type et le déclencheur. Pour un effet qui démarre lorsqu’une autre forme est cliquée, créez une séquence interactive dont le déclencheur est cette autre forme.

L’exemple suivant crée les deux types d’animation et enregistre le résultat dans `shape-animations.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

Le déclencheur contrôle le moment où un effet démarre :

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/effecttriggertype/) attend un clic dans la séquence principale, ou un clic sur la forme déclencheur dans une séquence interactive.  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/effecttriggertype/) démarre avec l’effet précédent.  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/effecttriggertype/) démarre lorsque l’effet précédent se termine.

Pour animer une image, un graphique ou tout autre type de forme, transmettez cet objet à [ISequence.AddEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/isequence/addeffect/) au lieu de `targetShape`. Pour les options de regroupement spécifiques aux graphiques, voir [Animated Charts](/slides/fr/net/animated-charts/).

## **Lire les animations de forme**

Utilisez [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/isequence/geteffectsbyshape/) lorsque vous connaissez la forme cible. Pour examiner chaque effet, parcourez la séquence principale et chaque séquence interactive. L’énumération évite de supposer qu’une séquence contient un effet à l’index `0`.

L’exemple suivant crée une forme avec des effets de séquence principale et interactive, récupère les effets qui ciblent la forme, puis parcourt chaque séquence de la diapositive.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

Si vous n’avez besoin que des effets pour une seule forme, identifiez d’abord la forme par son nom, son type de zone réservée ou toute autre propriété stable ; puis appelez [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/isequence/geteffectsbyshape/). Ne supposez pas que [IShapeCollection.Item](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/item/) à l’index `0` soit toujours l’objet attendu.

## **Travailler avec les effets d’espace réservé hérités**

Un espace réservé sur une diapositive normale peut hériter du comportement d’animation de l’espace réservé correspondant sur sa diapositive de mise en page et sur la diapositive maître. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/getbaseplaceholder/) renvoie cet espace réservé parent, ou `null` lorsqu’aucun parent n’existe.

Dans la présentation d’exemple suivante, le pied de page possède **Random Bars** sur la diapositive normale, **Split** sur la diapositive de mise en page, et **Fly In** sur la diapositive maître.

![Effet d’animation du pied de page sur la diapositive normale](slide-shape-animation.png)

![Effet d’animation du pied de page sur la diapositive de mise en page](layout-shape-animation.png)

![Effet d’animation du pied de page sur la diapositive maître](master-shape-animation.png)

L’exemple suivant construit lui‑même la hiérarchie des espaces réservés. Il ajoute des effets à un espace réservé maître, à un espace réservé de mise en page, et à l’espace réservé correspondant sur une diapositive normale. Chaque appel à [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/getbaseplaceholder/) est vérifié avant d’utiliser la forme retournée.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **Modifier la synchronisation de l’animation**

La boîte de dialogue **Timing** de PowerPoint correspond aux propriétés de [ITiming](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/).

![Boîte de dialogue Timing de PowerPoint pour un effet d’animation](shape-animation.png)

- **Start** correspond à [ITiming.TriggerType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/triggertype/).  
- **Duration** correspond à [ITiming.Duration](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/duration/), en secondes.  
- **Delay** correspond à [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/triggerdelaytime/), en secondes.  
- **Repeat** correspond à [ITiming.RepeatCount](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatuntilnextclick/), ou [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatuntilendslide/).  
- **Rewind when done playing** correspond à [ITiming.Rewind](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/rewind/).

Cet exemple indépendant ajoute un effet, modifie sa synchronisation via l’objet retourné par [ISequence.AddEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/isequence/addeffect/), puis enregistre le résultat. Conserver la référence au [IEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/) retourné évite un index de collection inutile.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

Utilisez un seul mode de répétition délibérément. Combiner un nombre de répétitions avec un drapeau « until » peut produire des résultats confus selon les visionneuses. Lors du changement de mode de répétition, définissez [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatuntilnextclick/) et [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatuntilendslide/) avant [ITiming.RepeatCount](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatcount/), car la définition de l’un de ces drapeaux modifie également le mode de répétition actif.

## **Ajouter et extraire les sons d’animation**

Un effet d’animation peut référencer un son intégré via [IEffect.Sound](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/stopprevioussound/) indique à un effet d’arrêter le son démarré par un effet précédent.

### **Ajouter un son à un effet**

L’exemple suivant suppose un fichier audio local nommé `animation-sound.wav`. Il crée deux effets, intègre ce fichier comme son du premier effet, et configure le deuxième effet pour arrêter le son. Il utilise les objets retournés par [ISequence.AddEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/isequence/addeffect/), ainsi aucun index de séquence n’est requis.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **Extraire les sons d’effet intégrés**

L’exemple suivant suppose une présentation locale nommée `presentation-with-animation-sounds.pptx`. Il parcourt les séquences principale et interactive et écrit chaque son d’effet intégré dans le répertoire `extracted-animation-sounds`. L’extension est choisie à partir du type MIME audio exposé par [IAudio.ContentType](https://reference.aspose.com/slides/fr/net/aspose.slides/iaudio/contenttype/).

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

Pour les gros objets audio, utilisez [IAudio.GetStream](https://reference.aspose.com/slides/fr/net/aspose.slides/iaudio/getstream/) et copiez le flux dans un fichier plutôt que de charger l’ensemble de l’objet dans un tableau d’octets.

## **Définir le comportement après l’animation**

L’option **After animation** contrôle ce qui arrive à une forme après la fin de son effet.

![Boîte de dialogue Options d’effet de PowerPoint affichant les paramètres After animation](shape-after-animation.png)

L’énumération [AfterAnimationType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/afteranimationtype/) prend en charge le maintien de la forme inchangée, le changement de sa couleur, son masquage après l’animation ou son masquage au clic suivant. Lorsque le type est [AfterAnimationType.Color](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/afteranimationtype/), définissez également [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Cet exemple indépendant crée un effet, définit son comportement après l’animation via l’objet effet retourné, puis enregistre le résultat.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

Modifier le type en dehors de [AfterAnimationType.Color](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/afteranimationtype/) supprime le paramètre de couleur après l’animation.

## **Animer du texte**

L’animation de texte possède deux contrôles liés :

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itextanimation/buildtype/) détermine si les paragraphes apparaissent tous ensemble ou par niveau de paragraphe.  
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/animatetexttype/) détermine si le texte apparaît d’un seul tenant, mot par mot ou lettre par lettre. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/delaybetweentextparts/) fixe le délai entre les mots ou les lettres. Une valeur positive représente un pourcentage de la durée de l’effet ; une valeur négative représente un délai en secondes.

L’exemple indépendant suivant anime les mots d’une zone de texte. [BuildType.AsOneObject](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/buildtype/) désactive le montage paragraphe par paragraphe afin que le réglage par mot s’applique à l’ensemble du cadre de texte.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

Pour construire une zone de texte paragraphe par paragraphe, définissez [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/buildtype/) (ou un autre niveau de paragraphe). Pour cibler un seul paragraphe avec son propre effet, utilisez la surcharge de [ISequence.AddEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/isequence/addeffect/) qui accepte un [IParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/). Consultez [Animated Text](/slides/fr/net/animated-text/) pour des exemples au niveau du paragraphe.

## **Exportation et notes de compatibilité**

- L’enregistrement au format PPT ou PPTX conserve le modèle d’animation, mais la lecture finale est contrôlée par le visionneur de présentation.  
- PDF et images statiques ne lisent pas les animations. Utilisez l’[exportation HTML5](/slides/fr/net/export-to-html5/), les GIF animés ou la [conversion vidéo](/slides/fr/net/convert-powerpoint-to-video/) lorsque le rendu doit montrer le mouvement.  
- Pour HTML5, activez [Html5Options.AnimateShapes](https://reference.aspose.com/slides/fr/net/aspose.slides.export/html5options/animateshapes/) et, si nécessaire, [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/html5options/animatetransitions/).  
- Le rendu vidéo prend en charge de nombreux effets d’entrée, d’emphase, de sortie et de trajectoire, mais tous les effets PowerPoint ne sont pas supportés. Vérifiez la page actuelle des [animations et effets pris en charge](/slides/fr/net/convert-powerpoint-to-video/#supported-animations-and-effects) et testez les présentations critiques avec votre version cible d’Aspose.Slides.  
- Les effets personnalisés avancés et les effets importés depuis d’autres formats de présentation peuvent être conservés dans le fichier mais rendus différemment dans PowerPoint, HTML5 ou vidéo. Validez le résultat exporté plutôt que de vous fier uniquement au nom de l’effet.

## **FAQ**

**Pourquoi une animation apparaît‑elle dans PowerPoint mais pas dans un PDF ?**

PDF est un format statique, donc les animations et les transitions de diapositives ne sont pas lues. Exportez vers HTML5, GIF animé ou vidéo lorsque le mouvement doit être conservé.

**Pourquoi un effet se joue‑t‑il différemment dans une vidéo ?**

L’exportation vidéo rend les animations plutôt que de stocker le comportement original de PowerPoint. Certains effets avancés ne sont pas pris en charge ou sont approximés. Consultez le tableau des effets pris en charge et testez la présentation réelle avant de l’utiliser en production.

**Le déplacement d’une forme vers l’avant ou vers l’arrière modifie‑t‑il l’ordre de son animation ?**

Non. L’ordre Z de la forme contrôle le chevauchement, tandis que l’ordre des séquences et les déclencheurs contrôlent la lecture des animations. Modifiez la ligne de temps si vous avez besoin d’un ordre de lecture différent.