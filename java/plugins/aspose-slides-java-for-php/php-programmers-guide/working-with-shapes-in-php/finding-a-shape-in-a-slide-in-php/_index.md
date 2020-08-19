---
title: Finding a Shape in a Slide in PHP
type: docs
weight: 80
url: /java/finding-a-shape-in-a-slide-in-php/
---

## **Aspose.Slides - Finding a Shape in a Slide**
To Find a Shape in a Slide using **Aspose.Slides Java for PHP**, simply invoke **FindShape** module. Here you can see example code.

**PHPCode**

```

 # Create an instance of Presentation class

$pres = new Presentation($dataDir . 'demo.pptx');

\# Get the first slide

$slide = $pres->getSlides()->get_Item(0);

$shape = FindShape::find_shape($slide, "Shape1");

print "Shape: " . $shape . PHP_EOL;

```

To Find a Shape in a Slide using **Aspose.Slides Java for PHP**, simply invoke **FindShape** module. Here you can see example code.

**PHPCode**

```

 public static function find_shape($slide, $alttext)

{

    #Iterating through all shapes inside the slide

    $i = 0;

    $slide_size = java_values($slide->getShapes()->size());

    while ($i < $slide_size) {

        # If the alternative text of the slide matches with the required one then return the shape

        if ($slide->getShapes()->get_Item($i)->getAlternativeText() == $alttext) {

            return $slide->getShapes()->get_Item($i);

        }

        $i++;

    }

    return nil;

}

```
## **Download Running Code**
Download **Finding a Shape in a Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithShapes/FindShape.php)
