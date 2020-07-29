---
title: Hello World Application in PHP
type: docs
weight: 10
url: /java/hello-world-application-in-php/
---

## **Aspose.Slides - Hello World**
In this simple application, we will create a PowerPoint presentation having Hello World text at a specified position of the slide. To create Hello Word document using **Aspose.Slides Java for PHP**, simply call **HelloWord** module. Below you can see example code.

**PHP Code**

{{< highlight php >}}

 # Instantiate Presentation

$pres = new Presentation();

\# Get the first slide

$slide = $pres->getSlides()->get_Item(0);

\# Add an AutoShape of Rectangle type

$shape_type = new ShapeType();

$ashp = $slide->getShapes()->addAutoShape($shape_type->Rectangle, 150, 75, 150, 50);

\# Add ITextFrame to the Rectangle

$ashp->addTextFrame("Hello World");

\# Change the text color to Black (which is White by default)

$fill_type = new FillType();

$color = new Color();

$ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getFillFormat()->setFillType($fill_type->Solid);

$ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($color->BLACK);

\# Change the line color of the rectangle to White

$ashp->getShapeStyle()->getLineColor()->setColor($color->WHITE);

\# Remove any fill formatting in the shape

$ashp->getFillFormat()->setFillType ($fill_type->NoFill);

\# Save the presentation to disk

$save_format = new SaveFormat();

$pres->save($dataDir . "HelloWorld.pptx", $save_format->Pptx);

print "Document has been saved, please check the output file.";

{{< /highlight >}}
## **Download Running Code**
Download **Hello World** **(Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/IntroductionToPresentation/HelloWorld.php)
