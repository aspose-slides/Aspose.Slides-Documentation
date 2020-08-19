---
title: Cloning Slides in Presentation in PHP
type: docs
weight: 40
url: /java/cloning-slides-in-presentation-in-php/
---

## **Aspose.Slides - Within the Same Presentation from One Position to the End**
To clone slide within the Same Presentation from One Position to the End using **Aspose.Slides Java for PHP**, call **clone_to_end_of_presentation** of **CloneSlides** module. Here you can see example code.

**PHP Code**

```

 public static function clone_to_end_of_presentation($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir , 'Aspose.pptx');

\# Clone the desired slide to the end of the collection of slides in the same presentation

$slides = $pres->getSlides();

$slides->addClone($pres->getSlides()->get_Item(0));

\# Saving the presentation file

$save_format = new SaveFormat();

$pres->save($dataDir . "Aspose_Cloned.pptx", $save_format->Pptx);

print "Slide has been cloned, please check the output file." . PHP_EOL;

}

```
## **Aspose.Slides - From One Position to Anther within the Same Presentation**
To clone slide from one Position to Anther within the same Presentation using **Aspose.Slides Java for PHP**, call **clone_to_aonther_position** of **CloneSlides** module. Here you can see example code.

**PHP Code**

```

 public static function clone_to_aonther_position($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir , 'Aspose.pptx');

\# Clone the desired slide to the end of the collection of slides in the same presentation

$slides = $pres->getSlides();

\# Clone the desired slide to the specified index in the same presentation

$slides->insertClone(2, $pres->getSlides()->get_Item(1));

\# Saving the presentation file

$save_format = new SaveFormat();

$pres->save($dataDir . "Aspose_Cloned.pptx", $save_format->Pptx);

print "Slide has been cloned, please check the output file." . PHP_EOL;

}

```
## **Aspose.Slides - In Another Presentation at the End of the Existing Slides**
To clone slide at the End of the Existing Slides using **Aspose.Slides Java for PHP**, call **clone_to_other_presentation_at_end_of_existing_slide** of **CloneSlides** module. Here you can see example code.

**PHP Code**

```

 public static function clone_to_other_presentation_at_end_of_existing_slide($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$src_pres = new Presentation($dataDir , 'Aspose.pptx');

\# Instantiate Presentation class for destination PPTX (where slide is to be cloned)

$dest_pres = new Presentation();

\# Clone the desired slide from the source presentation to the end of the collection of slides in destination presentation

$slds = $dest_pres->getSlides();

$slds->addClone($src_pres->getSlides()->get_Item(0));

\# Saving the presentation file

$save_format = new SaveFormat();

$dest_pres->save($dataDir . "Aspose_dest2.pptx", $save_format->Pptx);

print "Slide has been cloned, please check the output file." . PHP_EOL;

}

```
## **Download Running Code**
Download **Cloning Slides in Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSlidesInPresentation/CloneSlides.php)
