---
title: Manage Slide Transitions in Presentations Using PHP
linktitle: Slide Transition
type: docs
weight: 80
url: /php-java/slide-transition/
keywords:
- slide transition
- add slide transition
- apply slide transition
- advanced slide transition
- morph transition
- transition type
- transition effect
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Apply slide transitions, configure automatic slide advancement, and customize Morph and other transition effects with Aspose.Slides for PHP via Java."
---

## **Overview**

Slide transitions control how slides appear during a slide show. With Aspose.Slides for PHP via Java, you can choose a transition effect for each slide, configure advancement by mouse click or timer, and adjust options specific to an effect. This article uses PHP examples to apply transitions, set exact transition durations, manage slide timing, and create a Morph transition between two slides. The examples also show how to save the settings to a PPTX file.

## **Add Slide Transition**

To apply a transition, load a presentation with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class and access the slide's transition settings through [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Use [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) with a value from the [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) enumeration, then save the presentation.

The following example applies a Circle transition to the first slide and a Comb transition to the second. Use an `input.pptx` file with at least two slides.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Add Advanced Slide Transition**

You can configure how long a slide remains on screen and whether a mouse click advances the slide show. The following methods control this behavior:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) allows the viewer to advance by clicking the mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) enables automatic advancement.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) specifies the delay before automatic advancement, in milliseconds.

Enable both click and timed advancement to let the viewer move on with a click or wait for the timer. To use only the timer, pass `false` to [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). The delay controls when the slide show advances; it does not set the duration of the visual transition effect.

This example assigns different effects to the first three slides and enables automatic advancement after 3, 5, and 7 seconds, respectively. Mouse clicks can also advance these slides. Use an `input.pptx` file with at least three slides.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

To check whether timed advancement is enabled, call [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). A stored delay alone does not indicate that the timer is active.

The next example opens the file saved above, reports each enabled timer, and disables automatic advancement for slides with a delay greater than two seconds. It enables mouse clicks for those slides and saves the updated settings.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Control Transition Timing Precisely**

Use [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) to specify the exact length of a transition effect in milliseconds. The slide's [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) method exposes these settings through [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Sets the duration of the transition effect itself, in milliseconds. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Sets the delay before the slide advances automatically, in milliseconds. Pass `true` to [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) to activate this timer. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Selects a predefined speed category from [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium, or Fast. It is used when an exact duration is not specified. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) controls only the transition effect; it does not determine how long the slide remains visible. Configure the automatic advancement delay separately. When no explicit duration is set, Aspose.Slides determines the effect duration from the transition type and the [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) value.

### **Apply the Same Duration to Every Slide**

For consistent pacing, apply the same effect and exact duration to every slide. This example loads `input.pptx`, selects Fade from [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), and gives each transition a duration of 750 milliseconds. It separately enables automatic advancement after 5,000 milliseconds and disables advancement by mouse click, then saves the result as PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // Configure automatic advancement independently of the effect duration.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Set Different Durations for Individual Slides**

Different slides can use different effect durations. For example, use a brief transition for a title slide and a longer transition for a section introduction. This example sets 500 milliseconds for the first slide and 1,200 milliseconds for the second. Use an `input.pptx` file with at least two slides.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Coordinate Transitions with Animated Output**

When preparing an [animated GIF](/slides/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/php-java/export-to-html5/), or [video](/slides/php-java/convert-powerpoint-to-video/), set exact transition durations before export to match the intended pacing. For example, use a 600-millisecond fade between scenes, and adjust each slide's advancement delay separately to allow time for its narration or content.

For GIF and video, coordinate the output frame rate with the effect duration: 600 milliseconds corresponds to 18 frames at 30 frames per second. In HTML5, enable animated transitions in the export settings. Check the chosen export format's supported effects and timing options, and preview the output to confirm synchronization.

### **Read an Existing Transition Duration**

Call [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) before modifying the transition to determine whether an explicit value is stored. A value of `-1` means no explicit duration is set; a nonnegative value specifies the stored duration in milliseconds. The unset value is not the calculated playback duration: Aspose.Slides uses the transition type and the [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) value to determine that duration. Setting a transition type can initialize a duration, so inspect the original settings first.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Morph Transition**

The Morph transition animates changes between objects on consecutive slides. To create a simple Morph effect, clone a slide, move or resize an object on the clone, and apply the Morph transition to the second slide. This gives the transition corresponding objects to animate between their original and modified states.

The following example creates a slide with a text rectangle, clones the slide, and changes the rectangle's position and size on the clone. It then selects Morph from the [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) enumeration for the second slide. Open the saved file in a presentation viewer that supports Morph to see the effect during a slide show.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Morph Transition Types**

The [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) enumeration controls how Morph matches and animates content:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) treats each shape as a whole object.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) animates text by matching words where possible.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) animates text by matching characters where possible.

Use [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) to select Morph before accessing [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). The value then provides a [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) object, whose [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) method selects the matching mode.

This example opens the presentation created in the previous section and configures the second slide to use word-based Morph animation.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Set Transition Effects**

Some transitions expose additional options, such as direction or whether the effect starts from a black screen. The available options depend on the transition selected with [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). Set the type first, then use the appropriate transition object from [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

The following example applies a Cut transition to the first slide of `input.pptx`. It calls [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) through [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) so that the transition starts from a black screen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Can I control the playback speed of a slide transition?**

Yes. Prefer [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) when you need an exact effect duration in milliseconds. Use [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) when a predefined [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) category—Slow, Medium, or Fast—is sufficient and no explicit duration is set. These settings control the transition effect independently of the automatic advancement delay.

**Can I attach audio to a transition and make it loop?**

Yes. Assign embedded audio with [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), pass StartSound from the [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) enumeration to [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode), and enable [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) with `true`. The audio loops until the next sound event in the slide show.

**What's the fastest way to apply the same transition to every slide?**

Loop through the presentation's [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) collection and call [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) with the same value for each slide's transition. Set any timing and effect options in the same loop to keep the behavior consistent across slides.

**How can I check which transition is currently set on a slide?**

Call [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) on the slide's [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) result. It returns a value from the [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) enumeration; None means that no transition effect is applied.
