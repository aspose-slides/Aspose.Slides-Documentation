---
title: Shadow Effects on Slide Text using Aspose.Slides
type: docs
weight: 30
url: /java/shadow-effects-on-slide-text-using-aspose-slides/
---

## **Aspose.Slides - Shadow Effects on Slide Text**
Aspose.Slides for Java provides **OuterShadow** class in order to apply shadow effects on the text carried by **TextFrame**. This class is available in the Aspose.Slides.Effects namespace and provides a number of properties for handling the shadow effects.

**Java**

{{< highlight java >}}

 // instantiate a Presentation Object

Presentation pres = new Presentation();

// Get first slide

ISlide sld = pres.getSlides().get_Item(0);

// Add an AutoShape of Rectangle type

IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle,

		150, 75, 150, 50);

// Add TextFrame to the Rectangle

ashp.addTextFrame("Aspose TextBox");

// Disable shape fill in case we want to get shadow of text.

ashp.getFillFormat().setFillType(FillType.NoFill);

// Add outer shadow and set all necessary parameters

OuterShadow shadow = new OuterShadow();

ashp.getEffectFormat().setOuterShadowEffect(shadow);

shadow.setBlurRadius(4.0);

shadow.setDirection(45);

shadow.setDistance(3);

shadow.setRectangleAlign(RectangleAlignment.TopLeft);

shadow.getShadowColor().setPresetColor(PresetColor.Black);


{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/presentation/shadoweffectsontext/AsposeShadowEffectsOnText.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/presentation/shadoweffectsontext/AsposeShadowEffectsOnText.java)

{{% alert color="primary" %}} 

For more details, visit [Applying Shadow Effects on Slide Text](http://docs.aspose.com:8082/docs/display/slidesjava/Applying+Shadow+Effects+on+Slide+Text).

{{% /alert %}}
