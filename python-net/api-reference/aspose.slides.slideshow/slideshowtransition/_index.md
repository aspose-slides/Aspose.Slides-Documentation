---
title: SlideShowTransition Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 320
url: /python-net/api-reference/aspose.slides.slideshow/slideshowtransition/
---

Represents slide show transition.

**Namespace:** [aspose.slides.slideshow](/python-net/api-reference/aspose.slides.slideshow/)

**Full Class Name:** aspose.slides.slideshow.SlideShowTransition

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The SlideShowTransition type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|sound|Returns or sets the embedded audio data.<br/>            Read/write [IAudio](/python-net/api-reference/aspose.slides/iaudio/).|
|sound_mode|Set or returns sound mode for slide transition.<br/>            Read/write [TransitionSoundMode](/python-net/api-reference/aspose.slides.slideshow/transitionsoundmode/).|
|sound_loop|This attribute specifies if the sound will loop until the next sound event occurs in<br/>            slideshow.<br/>            Read/write bool.|
|advance_on_click|Specifies whether a mouse click will advance the slide or not. If this attribute is not<br/>            specified then a value of true is assumed.<br/>            Read/write bool.|
|advance_after_time|Specifies the time, in milliseconds, after which the transition should start. This setting<br/>            may be used in conjunction with the advClick attribute. If this attribute is not specified<br/>            then it is assumed that no auto-advance will occur.<br/>            Read/write int.|
|speed|Specifies the transition speed that is to be used when transitioning from the current slide<br/>            to the next.<br/>            Read/write [TransitionSpeed](/python-net/api-reference/aspose.slides.slideshow/transitionspeed/).|
|value|Slide show transition value.<br/>            Read-only [ITransitionValueBase](/python-net/api-reference/aspose.slides.slideshow/itransitionvaluebase/).|
|type|Type of transition.<br/>            Read/write [TransitionType](/python-net/api-reference/aspose.slides.slideshow/transitiontype/).|
|sound_is_built_in|Specifies whether or not this sound is a built-in sound. If this attribute is set to true then<br/>            the generating application is alerted to check the name attribute specified for this sound<br/>            in it's list of built-in sounds and can then surface a custom name or UI as needed.<br/>            Read-write bool.|
|sound_name|Specifies a human readable name for the sound of the transition. The [sound](/python-net/api-reference/aspose.slides.slideshow/slideshowtransition/) property must be assigned to get or set the sound name.<br/>            Read-write string.|
