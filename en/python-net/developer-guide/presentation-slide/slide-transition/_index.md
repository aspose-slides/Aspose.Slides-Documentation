---
title: Manage Slide Transitions in Presentations Using Python
linktitle: Slide Transition
type: docs
weight: 90
url: /python-net/slide-transition/
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
- Python
- Aspose.Slides
description: "Apply slide transitions, configure automatic slide advancement, and customize Morph and other transition effects with Aspose.Slides for Python via .NET."
---

## **Overview**

Slide transitions control how slides appear during a slide show. With Aspose.Slides for Python via .NET, you can choose a transition effect for each slide, configure advancement by mouse click or timer, and adjust options specific to an effect. This article uses Python examples to apply transitions, set exact transition durations, manage slide timing, and create a Morph transition between two slides. The examples also show how to save the settings to a PPTX file.

## **Add Slide Transition**

To apply a transition, load a presentation with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and access the slide's [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) property. Set its [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) to a value from the [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) enumeration, then save the presentation.

The following example applies a Circle transition to the first slide and a Comb transition to the second. Use an `input.pptx` file with at least two slides.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Add Advanced Slide Transition**

You can configure how long a slide remains on screen and whether a mouse click advances the slide show. The following properties control this behavior:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) allows the viewer to advance by clicking the mouse.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) enables automatic advancement.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) specifies the delay before automatic advancement, in milliseconds.

Enable both click and timed advancement to let the viewer move on with a click or wait for the timer. To use only the timer, set [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) to `False`. The delay controls when the slide show advances; it does not set the duration of the visual transition effect.

This example assigns different effects to the first three slides and enables automatic advancement after 3, 5, and 7 seconds, respectively. Mouse clicks can also advance these slides. Use an `input.pptx` file with at least three slides.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

To check whether timed advancement is enabled, read [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). A stored delay alone does not indicate that the timer is active.

The next example opens the file saved above, reports each enabled timer, and disables automatic advancement for slides with a delay greater than two seconds. It enables mouse clicks for those slides and saves the updated settings.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Control Transition Timing Precisely**

Use [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) to specify the exact length of a transition effect in milliseconds. The slide's [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) property exposes these settings through [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Property | Purpose |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Sets the duration of the transition effect itself, in milliseconds. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Sets the delay before the slide advances automatically, in milliseconds. Enable [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) to activate this timer. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Selects a predefined speed category from [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM, or FAST. It is used when an exact duration is not specified. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) controls only the transition effect; it does not determine how long the slide remains visible. Configure the automatic advancement delay separately. When no explicit duration is set, Aspose.Slides determines the effect duration from the transition type and [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) value.

### **Apply the Same Duration to Every Slide**

For consistent pacing, apply the same effect and exact duration to every slide. This example loads `input.pptx`, selects Fade from [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), and gives each transition a duration of 750 milliseconds. It separately enables automatic advancement after 5,000 milliseconds and disables advancement by mouse click, then saves the result as PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Configure automatic advancement independently of the effect duration.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Set Different Durations for Individual Slides**

Different slides can use different effect durations. For example, use a brief transition for a title slide and a longer transition for a section introduction. This example sets 500 milliseconds for the first slide and 1,200 milliseconds for the second. Use an `input.pptx` file with at least two slides.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Coordinate Transitions with Animated Output**

When preparing an [animated GIF](/slides/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/python-net/export-to-html5/), or [video](/slides/python-net/convert-powerpoint-to-video/), set exact transition durations before export to match the intended pacing. For example, use a 600-millisecond fade between scenes, and adjust each slide's advancement delay separately to allow time for its narration or content.

For GIF and video, coordinate the output frame rate with the effect duration: 600 milliseconds corresponds to 18 frames at 30 frames per second. In HTML5, enable animated transitions in the export settings. Check the chosen export format's supported effects and timing options, and preview the output to confirm synchronization.

### **Read an Existing Transition Duration**

Read [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) before modifying the transition to determine whether an explicit value is stored. A value of `-1` means no explicit duration is set; a nonnegative value specifies the stored duration in milliseconds. The unset value is not the calculated playback duration: Aspose.Slides uses the transition type and [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) to determine that duration. Setting a transition type can initialize a duration, so inspect the original settings first.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Morph Transition**

The Morph transition animates changes between objects on consecutive slides. To create a simple Morph effect, clone a slide, move or resize an object on the clone, and apply the Morph transition to the second slide. This gives the transition corresponding objects to animate between their original and modified states.

The following example creates a slide with a text rectangle, clones the slide, and changes the rectangle's position and size on the clone. It then selects Morph from the [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) enumeration for the second slide. Open the saved file in a presentation viewer that supports Morph to see the effect during a slide show.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph Transition Types**

The [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) enumeration controls how Morph matches and animates content:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) treats each shape as a whole object.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animates text by matching words where possible.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animates text by matching characters where possible.

Set the transition [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) to Morph before accessing its [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). The value then provides the [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) object, whose [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) property selects the matching mode.

This example opens the presentation created in the previous section and configures the second slide to use word-based Morph animation.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Set Transition Effects**

Some transitions expose additional options, such as direction or whether the effect starts from a black screen. The available options depend on the selected transition [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/). Set the type first, then use the appropriate transition object from its [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

The following example applies a Cut transition to the first slide of `input.pptx`. It sets [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) through [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) so that the transition starts from a black screen.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**Can I control the playback speed of a slide transition?**

Yes. Prefer [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) when you need an exact effect duration in milliseconds. Use [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) when a predefined [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) category—SLOW, MEDIUM, or FAST—is sufficient and no explicit duration is set. These settings control the transition effect independently of the automatic advancement delay.

**Can I attach audio to a transition and make it loop?**

Yes. Assign embedded audio to [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), set [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) to START_SOUND from the [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) enumeration, and enable [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). The audio loops until the next sound event in the slide show.

**What's the fastest way to apply the same transition to every slide?**

Loop through the presentation's [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) collection and set each slide's transition [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) to the same value. Set any timing and effect options in the same loop to keep the behavior consistent across slides.

**How can I check which transition is currently set on a slide?**

Read the [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) property from the slide's [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). It returns a value from the [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) enumeration; NONE means that no transition effect is applied.
