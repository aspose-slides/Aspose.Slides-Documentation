---
title: Gerenciar Transições de Slides em Apresentações Usando Python via Java
linktitle: Transição de Slide
type: docs
weight: 80
url: /pt/python-java/slide-transition/
keywords:
- transição de slide
- adicionar transição de slide
- aplicar transição de slide
- transição avançada de slide
- transição morph
- tipo de transição
- efeito de transição
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aplicar transições de slide, configurar avanço automático dos slides e personalizar Morph e outros efeitos de transição com Aspose.Slides para Python via Java."
---
## **Visão geral**

Slide transitions control how slides appear during a slide show. With Aspose.Slides for Python via Java, you can choose a transition effect for each slide, configure advancement by mouse click or timer, and adjust options specific to an effect. This article uses Python examples to apply transitions, set exact transition durations, manage slide timing, and create a Morph transition between two slides. The examples also show how to save the settings to a PPTX file.

## **Adicionar transição de slide**

To apply a transition, load a presentation with the [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) class and access the slide's transition settings through [getSlideShowTransition](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getSlideShowTransition). Use [setType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setType) with a value from the [TransitionType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/transitiontype/) enumeration, then save the presentation.

The following example applies a Circle transition to the first slide and a Comb transition to the second. Use an `input.pptx` file with at least two slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Adicionar transição avançada de slide**

You can configure how long a slide remains on screen and whether a mouse click advances the slide show. The following methods control this behavior:

- [setAdvanceOnClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) allows the viewer to advance by clicking the mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) enables automatic advancement.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) specifies the delay before automatic advancement, in milliseconds.

Enable both click and timed advancement to let the viewer move on with a click or wait for the timer. To use only the timer, pass `False` to [setAdvanceOnClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). The delay controls when the slide show advances; it does not set the duration of the visual transition effect.

This example assigns different effects to the first three slides and enables automatic advancement after 3, 5, and 7 seconds, respectively. Mouse clicks can also advance these slides. Use an `input.pptx` file with at least three slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

To check whether timed advancement is enabled, call [getAdvanceAfter](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). A stored delay alone does not indicate that the timer is active.

The next example opens the file saved above, reports each enabled timer, and disables automatic advancement for slides with a delay greater than two seconds. It enables mouse clicks for those slides and saves the updated settings.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlar o tempo da transição com precisão**

Use [setDuration](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setDuration) to specify the exact length of a transition effect in milliseconds. The slide's [getSlideShowTransition](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getSlideShowTransition) method exposes these settings through [SlideShowTransition](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/):

| Método | Propósito |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setDuration) | Define a duração do próprio efeito de transição, em milissegundos. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Define o atraso antes que o slide avance automaticamente, em milissegundos. Passe `True` para [setAdvanceAfter](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) para ativar este temporizador. |
| [setSpeed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setSpeed) | Seleciona uma categoria de velocidade predefinida da enumeração TransitionSpeed: Slow, Medium ou Fast. É usada quando uma duração exata não é especificada. |

[setDuration](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setDuration) controls only the transition effect; it does not determine how long the slide remains visible. Configure the automatic advancement delay separately. When no explicit duration is set, Aspose.Slides determines the effect duration from the transition type and the [getSpeed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#getSpeed) value.

### **Aplicar a mesma duração a todos os slides**

For consistent pacing, apply the same effect and exact duration to every slide. This example loads `input.pptx`, selects Fade from [TransitionType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/transitiontype/), and gives each transition a duration of 750 milliseconds. It separately enables automatic advancement after 5,000 milliseconds and disables advancement by mouse click, then saves the result as PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Configurar avanço automático independentemente da duração do efeito.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Definir durações diferentes para slides individuais**

Different slides can use different effect durations. For example, use a brief transition for a title slide and a longer transition for a section introduction. This example sets 500 milliseconds for the first slide and 1,200 milliseconds for the second. Use an `input.pptx` file with at least two slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Coordenar transições com saída animada**

When preparing an [animated GIF](/slides/pt/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pt/python-java/export-to-html5/), or [video](/slides/pt/python-java/convert-powerpoint-to-video/), set exact transition durations before export to match the intended pacing. For example, use a 600‑millisecond fade between scenes, and adjust each slide's advancement delay separately to allow time for its narration or content.

For GIF and video, coordinate the output frame rate with the effect duration: 600 milliseconds corresponds to 18 frames at 30 frames per second. In HTML5, enable animated transitions in the export settings. Check the chosen export format's supported effects and timing options, and preview the output to confirm synchronization.

### **Ler a duração de transição existente**

Call [getDuration](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#getDuration) before modifying the transition to determine whether an explicit value is stored. A value of `-1` means no explicit duration is set; a nonnegative value specifies the stored duration in milliseconds. The unset value is not the calculated playback duration: Aspose.Slides uses the transition type and the [getSpeed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#getSpeed) value to determine that duration. Setting a transition type can initialize a duration, so inspect the original settings first.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Transição Morph**

The Morph transition animates changes between objects on consecutive slides. To create a simple Morph effect, clone a slide, move or resize an object on the clone, and apply the Morph transition to the second slide. This gives the transition corresponding objects to animate between their original and modified states.

The following example creates a slide with a text rectangle, clones the slide, and changes the rectangle's position and size on the clone. It then selects Morph from the [TransitionType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/transitiontype/) enumeration for the second slide. Open the saved file in a presentation viewer that supports Morph to see the effect during a slide show.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tipos de transição Morph**

The [TransitionMorphType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/transitionmorphtype/) enumeration controls how Morph matches and animates content:

- [ByObject](https://reference.aspose.com/slides/pt/python-java/aspose.slides/transitionmorphtype/#ByObject) trata cada forma como um objeto completo.
- [ByWord](https://reference.aspose.com/slides/pt/python-java/aspose.slides/transitionmorphtype/#ByWord) anima o texto correspondendo palavras quando possível.
- [ByChar](https://reference.aspose.com/slides/pt/python-java/aspose.slides/transitionmorphtype/#ByChar) anima o texto correspondendo caracteres quando possível.

Use [setType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setType) to select Morph before accessing [getValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#getValue). The value is then an instance of the [MorphTransition](https://reference.aspose.com/slides/pt/python-java/aspose.slides/morphtransition/) class, whose [setMorphType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/morphtransition/#setMorphType) method selects the matching mode.

This example opens the presentation created in the previous section and configures the second slide to use word‑based Morph animation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Definir efeitos de transição**

Some transitions expose additional options, such as direction or whether the effect starts from a black screen. The available options depend on the transition selected with [setType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setType). Set the type first, then use the appropriate class from [getValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#getValue).

The following example applies a Cut transition to the first slide of `input.pptx`. It calls [setFromBlack](https://reference.aspose.com/slides/pt/python-java/aspose.slides/optionalblacktransition/#setFromBlack) through [OptionalBlackTransition](https://reference.aspose.com/slides/pt/python-java/aspose.slides/optionalblacktransition/) so that the transition starts from a black screen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Posso controlar a velocidade de reprodução de uma transição de slide?**

Yes. Prefer [setDuration](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setDuration) when you need an exact effect duration in milliseconds. Use [setSpeed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setSpeed) when a predefined [TransitionSpeed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/transitionspeed/) category—Slow, Medium, or Fast—is sufficient and no explicit duration is set. These settings control the transition effect independently of the automatic advancement delay.

**Posso anexar áudio a uma transição e fazê-lo repetir?**

Yes. Assign embedded audio with [setSound](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setSound), pass StartSound from the [TransitionSoundMode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/transitionsoundmode/) enumeration to [setSoundMode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setSoundMode), and enable [setSoundLoop](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setSoundLoop) with `True`. The audio loops until the next sound event in the slide show.

**Qual é a maneira mais rápida de aplicar a mesma transição a todos os slides?**

Loop through the presentation's [getSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSlides) collection and call [setType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#setType) with the same value for each slide's transition. Set any timing and effect options in the same loop to keep the behavior consistent across slides.

**Como posso verificar qual transição está atualmente definida em um slide?**

Call [getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideshowtransition/#getType) on the slide's [getSlideShowTransition](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getSlideShowTransition) result. It returns a value from the [TransitionType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/transitiontype/) enumeration; None_ means that no transition effect is applied.