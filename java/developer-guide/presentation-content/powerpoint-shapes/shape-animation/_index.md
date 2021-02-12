---
title: Shape Animation
type: docs
weight: 50
url: /net/shape-animation/
---

Animation is one of the most important parts of the presentations that make them more attractive and meaningful. Aspose.Slides for .NET also allows developers to apply different kinds of animation effects on different kinds of shapes. There is a separate namespace [Aspose.Slides.Animation](http://www.aspose.com/api/net/slides/aspose.slides.animation/) that provides classes to handle the animations on PPTX presentations. In this topic, we will show how to apply animation effects on shapes.

Here we will apply the PathFootball effect (one of more than 150 available effects) on a TextBox that will be activated on clicking the bevel shape (some sort of button). To apply such animation effect, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type.
- Add an IAutoShape of [Bevel type](http://www.aspose.com/api/net/slides/aspose.slides/shapetype) (clicking on which, animations will take effect).
- Create sequence of effects on this Bevel shape.
- Create custom User Path.
- Add commands to the Path for moving.
- Write the presentation to the disk as a PPTX file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AnimationsOnShapes-AnimationsOnShapes.cs" >}}
