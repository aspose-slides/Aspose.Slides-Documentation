---
title: Manage SmartArt Shape
type: docs
weight: 20
url: /java/manage-smartart-shape/
---


## **Create SmartArt Shape**
Aspose.Slides for Java has provided an API to create SmartArt shapes. To create a SmartArt shape in a slide, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. [Add a SmartArt shape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) by setting it [LayoutType](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType).
1. Save the modified presentation as a PPTX file.

```php
// Instantiate Presentation Class
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Get first slide
    $slide = $pres->getSlides()->get_Item(0);
    
    // Add Smart Art Shape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, Java("com.aspose.slides.SmartArtLayoutType")->BasicBlockList);
    
    // Saving presentation
    $pres->save("SimpleSmartArt.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape added to the slide**|

## **Access SmartArt Shape in Slide**
The following code will be used to access the SmartArt shapes added in presentation slide. In sample code we will traverse through every shape inside the slide and check if it is a [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt) shape. If shape is of SmartArt type then we will typecast that to [**SmartArt**](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt) instance.

```php
// Load the desired the presentation
$pres = new Java("com.aspose.slides.Presentation", "AccessSmartArtShape.pptx");
try {
    // Traverse through every shape inside first slide
    foreach( $pres->getSlides()->get_Item(0)->getShapes() as $shape )
    {
        // Check if shape is of SmartArt type
        if ($shape instanceof ISmartArt)
        {
            // Typecast shape to SmartArtEx
            $smart = $shape;
            echo("Shape Name:" + $smart->getName());
        }
    }
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Access SmartArt Shape with Particular Layout Type**
The following sample code will help to access the [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt) shape with particular LayoutType. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt) shape is added.

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt) type and Typecast selected shape to SmartArt if it is SmartArt.
1. Check the SmartArt shape with particular LayoutType and perform what is required to be done afterwards.

```php
$pres = new Java("com.aspose.slides.Presentation", "AccessSmartArtShape.pptx");
try {
    // Traverse through every shape inside first slide
    foreach( $pres->getSlides()->get_Item(0)->getShapes() as $shape )
    {
        // Check if shape is of SmartArt type
        if ($shape instanceof ISmartArt)
        {
            // Typecast shape to SmartArtEx
            $smart = $shape;

            // Checking SmartArt Layout
            if ($smart->getLayout() == Java("com.aspose.slides.SmartArtLayoutType")->BasicBlockList)
            {
                echo("Do some thing here....");
            }
        }
    }
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Change SmartArt Shape Style**
In this example, we will learn to change the quick style for any SmartArt shape.

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt) type and Typecast selected shape to SmartArt if it is SmartArt.
1. Find the SmartArt shape with particular Style.
1. Set the new Style for the SmartArt shape.
1. Save the Presentation.

```php
// Instantiate Presentation Class
$pres = new Java("com.aspose.slides.Presentation", "SimpleSmartArt.pptx");
try {
    // Get first slide
    $slide = $pres->getSlides()->get_Item(0);
    
    // Traverse through every shape inside first slide
    foreach( $slide->getShapes() as $shape ) 
    {
        // Check if shape is of SmartArt type
        if ($shape instanceof ISmartArt) 
        {
            // Typecast shape to SmartArtEx
            $smart = $shape;
    
            // Checking SmartArt style
            if ($smart->getQuickStyle() == Java("com.aspose.slides.SmartArtQuickStyleType")->SimpleFill) {
                // Changing SmartArt Style
                $smart->setQuickStyle(Java("com.aspose.slides.SmartArtQuickStyleType")->Cartoon);
            }
        }
    }
    // Saving presentation
    $pres->save("ChangeSmartArtStyle.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    $pres->dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/63ZwK41.png)|
| :- |
|**Figure: SmartArt shape with changed Style**|

## **Change SmartArt Shape Color Style**
In this example, we will learn to change the color style for any SmartArt shape. In the following sample code will access the SmartArt shape with particular color style and will change its style.

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt) type and Typecast selected shape to SmartArt if it is SmartArt.
1. Find the SmartArt shape with particular Color Style.
1. Set the new Color Style for the SmartArt shape.
1. Save the Presentation.

```php
// Instantiate Presentation Class
$pres = new Java("com.aspose.slides.Presentation", "SimpleSmartArt.pptx");
try {
    // Get first slide
    $slide = $pres->getSlides()->get_Item(0);
    
    // Traverse through every shape inside first slide
    foreach( $slide->getShapes() as $shape ) 
    {
        // Check if shape is of SmartArt type
        if ($shape instanceof ISmartArt) 
        {
            // Typecast shape to SmartArtEx
            $smart = $shape;
    
            // Checking SmartArt color type
            if ($smart->getColorStyle() == Java("com.aspose.slides.SmartArtColorType")->ColoredFillAccent1) {
                // Changing SmartArt color type
                $smart->setColorStyle(Java("com.aspose.slides.SmartArtColorType")->ColorfulAccentColors);
            }
        }
    }
    // Saving presentation
    $pres->save("ChangeSmartArtColorStyle.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    $pres->dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: SmartArt shape with changed Color Style**|