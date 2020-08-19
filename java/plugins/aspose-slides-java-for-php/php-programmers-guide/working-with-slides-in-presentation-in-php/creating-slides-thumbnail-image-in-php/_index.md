---
title: Creating Slides Thumbnail Image in PHP
type: docs
weight: 60
url: /java/creating-slides-thumbnail-image-in-php/
---

## **Aspose.Slides - Generating a Thumbnail from a Slide**
To Generate a Thumbnail from a Slide using **Aspose.Slides Java for PHP**, call **create_thumbnail** method of **Thumbnail** module. Here you can see example code.

**PHPCode**

```

 public static function create_thumbnail($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir . 'demo.pptx');

\# Access the first slide

$slide = $pres->getSlides()->get_Item(0);

\# Create a full scale image

$image = $slide->getThumbnail();

\# Save the image to disk in JPEG format

$imageIO = new ImageIO();

$imageIO->write($image, "jpeg", new File($dataDir . "ContentBG_tnail.jpg"));

print "Created thumbnail, please check the output file." . PHP_EOL;

}

```
## **Aspose.Slides - Generating a Thumbnail from a Slide with User Defined Dimensions**
To Generate a Thumbnail from a Slide with user defined Dimensions using **Aspose.Slides Java for PHP**, call **create_thumbnail_custom_size** method of **Thumbnail** module. Here you can see example code.

**PHPCode**

```

 public static function create_thumbnail_custom_size($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir . 'demo.pptx');

\# Access the first slide

$slide = $pres->getSlides()->get_Item(0);

\# User defined dimension

$desired_x = 1200;

$desired_y = 800;

\# Getting scaled value  of X and Y

$scale_x = (1.0 / $pres->getSlideSize()->getSize()->getWidth()) * $desired_x;

$scale_y = (1.0 / $pres->getSlideSize()->getSize()->getHeight()) * $desired_y;

\# Create a full scale image

$image = $slide->getThumbnail($scale_x, $scale_y);

\# Save the image to disk in JPEG format

$imageIO = new ImageIO();

$imageIO->write($image, "jpeg", new File($dataDir . "ContentBG_tnail.jpg"));

print "Created thumbnail with custom size, please check the output file.". PHP_EOL;

}

```
## **Aspose.Slides - Generating a Thumbnail from a Slide in Notes Slides View**
To Generate a Thumbnail from a Slide in Notes Slides View using **Aspose.Slides Java for PHP**, call **create_thumbnail_in_notes_slides_view** method of **Thumbnail** module. Here you can see example code.

**PHPCode**

```

 public static function create_thumbnail_in_notes_slides_view($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir . 'demo.pptx');

\# Access the first slide

$slide = $pres->getSlides()->get_Item(0);

\# User defined dimension

$desired_x = 1200;

$desired_y = 800;

\# Getting scaled value  of X and Y

$scale_x = (1.0 / $pres->getSlideSize()->getSize()->getWidth()) * $desired_x;

$scale_y = (1.0 / $pres->getSlideSize()->getSize()->getHeight()) * $desired_y;

\# Create a full scale image

$image = $slide->getNotesSlide()->getThumbnail($scale_x, $scale_y);

\# Save the image to disk in JPEG format

$imageIO = new ImageIO();

$imageIO->write(image, "jpeg", new File($dataDir . "ContentBG_tnail.jpg"));

print "Created thumbnail in notes slides view, please check the output file." . PHP_EOL;


}

```
## **Aspose.Slides - Generating a Thumbnail of User Defined Window from a Slide**
To Generate a Thumbnail of user defined Window from a Slide using **Aspose.Slides Java for PHP**, call **create_thumbnail_of_user_defined_window** method of **Thumbnail** module. Here you can see example code.

**PHPCode**

```

 public static function create_thumbnail_of_user_defined_window($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir . 'demo.pptx');

\# Access the first slide

$slide = $pres->getSlides()->get_Item(0);

\# Create a full scale image

$image = $slide->getThumbnail(1,1);

\# Getting the image of desired window inside generated slide thumnbnail

\# BufferedImage window = image.getSubimage(windowX, windowY, windowsWidth, windowHeight);

$window_image = $image->getSubimage(100, 100, 200, 200);

\# Save the image to disk in JPEG format

$imageIO = new ImageIO();

$imageIO->write(image, "jpeg", new File($dataDir . "ContentBG_tnail.jpg"));

print "Created thumbnail of user defined window, please check the output file." . PHP_EOL;

}

```
## **Download Running Code**
Download **Creating Slides Thumbnail Image (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSlidesInPresentation/Thumbnail.php)
