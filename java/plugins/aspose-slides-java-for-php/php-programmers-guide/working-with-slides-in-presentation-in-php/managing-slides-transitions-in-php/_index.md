---
title: Managing Slides Transitions in PHP
type: docs
weight: 70
url: /java/managing-slides-transitions-in-php/
---

## **Aspose.Slides - Managing Slides Transitions**
To create a simple slide transition effect using **Aspose.Slides Java for PHP**, simply invoke **Transitions** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 public static function run($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir . 'demo.pptx');

$transition_type = new TransitionType();

\# Apply circle type transition on slide 1

$pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType($transition_type->Circle);

\# Apply comb type transition on slide 2

$pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType($transition_type->Comb);

\# Saving the presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "SimpleTransition.pptx", $save_format->Pptx);

print "Done with simple transition, please check the output file." . PHP_EOL;

}

{{< /highlight >}}
## **Download Running Code**
Download **Managing Slides Transitions (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSlidesInPresentation/Transitions.php)
