---
title: Manage SmartArt Shape Node
type: docs
weight: 30
url: /java/manage-smartart-shape-node/
---

## **Add SmartArt Node**
Aspose.Slides for Java has provided the simplest API to manage the SmartArt shapes in an easiest way. The following sample code will help to add node and child node inside SmartArt shape.

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) type and Typecast selected shape to [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) if it is SmartArt.
1. [Add a new Node](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) in SmartArt shape [**NodeCollection**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt#getAllNodes--) and set the text in TextFrame.
1. Now, [Add](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) a [**Child Node**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) in newly added [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) Node and set the text in TextFrame
1. Save the Presentation.

```php
// Load the desired the presentation
$pres = new Java("com.aspose.slides.Presentation", "SimpleSmartArt.pptx");
try {
    // Traverse through every shape inside first slide
    foreach( $pres->getSlides()->get_Item(0)->getShapes() as $shape ) 
    {
        // Check if shape is of SmartArt type
        if ($shape instanceof SmartArt) 
        {
            // Typecast shape to SmartArt
            $smart = $shape;
    
            // Adding a new SmartArt Node
            $TemNode = $smart->getAllNodes()->addNode();
    
            // Adding text
            $TemNode->getTextFrame()->setText("Test");
    
            // Adding new child node in parent node. It will be added in the end of collection
            $newNode = $TemNode->getChildNodes()->addNode();
    
            // Adding text
            $newNode->getTextFrame()->setText("New Node Added");
        }
    }
    
    // Saving Presentation
    $pres->save("AddSmartArtNode.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Add SmartArt Node at Specific Position**
In the following sample code we have explained how to add the child nodes belonging to respective nodes of SmartArt shape at particular position.

1. Create an instance of Presentation class.
1. Obtain the reference of first slide by using its Index.
1. Add a [**StackedList**](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) type [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt) shape in accessed slide.
1. Access the first node in added SmartArt shape
1. Now, add the [**Child Node**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) for selected [**Node**](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) at position 2 and set its text.
1. Save the Presentation

```php
// Creating a presentation instance
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Access the presentation slide
    $slide = $pres->getSlides()->get_Item(0);

    // Add Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, Java("com.aspose.slides.SmartArtLayoutType")->StackedList);

    // Accessing the SmartArt node at index 0
    $node = $smart->getAllNodes()->get_Item(0);

    // Adding new child node at position 2 in parent node
    $chNode = $node->getChildNodes()->addNodeByPosition(2);

    // Add Text
    $chNode->getTextFrame()->setText("Sample Text Added");

    // Save Presentation
    $pres->save("AddSmartArtNodeByPosition.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Access SmartArt Node**
The following sample code will help to access nodes inside SmartArt shape. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) type and Typecast selected shape to [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) if it is SmartArt.
1. Traverse through all [**Nodes**](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) inside SmartArt Shape.
1. Access and display information like SmartArt Node position, level and Text.

```php
// Instantiate Presentation Class
$pres = new Java("com.aspose.slides.Presentation", "SmartArtShape.pptx");
try {
    // Get first slide
    $slide = $pres->getSlides()->get_Item(0);
    
    // Traverse through every shape inside first slide
    foreach( $slide->getShapes() as $shape ) 
    {
        // Check if shape is of SmartArt type
        if ($shape instanceof ISmartArt) 
        {
            // Typecast shape to SmartArt
            $smart = $shape;
    
            // Traverse through all nodes inside SmartArt
            for ($i = 0; $i < $smart->getAllNodes()->size(); $i++) 
            {
                // Accessing SmartArt node at index i
                $node = $smart->getAllNodes()->get_Item($i);
    
                // Printing the SmartArt node parameters
                echo($node->getTextFrame()->getText() + " " + $node->getLevel() + " " + $node->getPosition());
            }
        }
    }
} finally {
    if ($pres != null) $pres->dispose();
}
```


## **Access SmartArt Child Node**
The following sample code will help to access the child nodes belonging to respective nodes of SmartArt shape.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) type and Typecast selected shape to [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) if it is SmartArt.
1. Traverse through all [**Nodes**](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) inside SmartArt Shape.
1. For every selected SmartArt shape [**Node**](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArtNode), traverse through all [**Child Nodes**](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#getChildNodes--) inside particular node.
1. Access and display information like [**Child Node**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) position, level and Text.

```php
// Instantiate Presentation Class
$pres = new Java("com.aspose.slides.Presentation", "AccessChildNodes.pptx");
try {
    // Get first slide
    $slide = $pres->getSlides()->get_Item(0);
    
    // Traverse through every shape inside first slide
    foreach( $slide->getShapes() as $shape ) 
    {
        // Check if shape is of SmartArt type
        if ($shape instanceof ISmartArt) 
        {
            // Typecast shape to SmartArt
            $smart = $shape;
    
            // Traverse through all nodes inside SmartArt
            for ($i = 0; $i < $smart->getAllNodes()->size(); $i++) 
            {
                // Accessing SmartArt node at index i
                $node0 = $smart->getAllNodes()->get_Item($i);
                
                // Traversing through the child nodes in SmartArt node at index i
                for ($j = 0; $j < node0->getChildNodes()->size(); $j++) 
                {
                    // Accessing the child node in SmartArt node
                    $node = $node0->getChildNodes()->get_Item($j);
    
                    // Printing the SmartArt child node parameters
                    echo("j = " + $j + ", Text = " + $node->getTextFrame()->getText() + ",  Level = " + $node->getLevel() + ", Position = " + $node->getPosition());
                }
            }
        }
    }
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Access SmartArt Child Node at Specific Position**
In this example, we will learn to access the child nodes at some particular position belonging to respective nodes of SmartArt shape.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of first slide by using its Index.
1. Add a [**StackedList**](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) type SmartArt shape.
1. Access the added SmartArt shape.
1. Access the node at index 0 for accessed SmartArt shape.
1. Now, access the [**Child Node**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) at position 1 for accessed SmartArt node using **get_Item()** method.
1. Access and display information like [**Child Node**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) position, level and Text.

```php
// Instantiate the presentation
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Accessing the first slide
    $slide = $pres->getSlides()->get_Item(0);
    
    // Adding the SmartArt shape in first slide
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, Java("com.aspose.slides.SmartArtLayoutType")->StackedList);
    
    // Accessing the SmartArt node at index 0
    $node = $smart->getAllNodes()->get_Item(0);
    
    // Accessing the child node at position 1 in parent node
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    
    // Printing the SmartArt child node parameters
    echo("Text = " + $chNode->getTextFrame()->getText() + ",  Level = " + $chNode->getLevel() + ", Position = " + $chNode->getPosition());
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Remove SmartArt Node**
In this example, we will learn to remove the nodes inside SmartArt shape.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) type and Typecast selected shape to [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) if it is SmartArt.
1. Check if the [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) has more than 0 nodes.
1. Select the SmartArt node to be deleted.
1. Now, remove the selected node using [**RemoveNode**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) method.
1. Save the Presentation.

```php
// Load the desired the presentation
$pres = new Java("com.aspose.slides.Presentation", "AddSmartArtNode.pptx");
try {
    // Traverse through every shape inside first slide
    foreach( $pres->getSlides()->get_Item(0)->getShapes() as $shape ) 
    {
        // Check if shape is of SmartArt type
        if ($shape instanceof ISmartArt) 
        {
            // Typecast shape to SmartArt
            $smart = $shape;
    
            if ($smart->getAllNodes()->size() > 0) 
            {
                // Accessing SmartArt node at index 0
                $node = $smart->getAllNodes()->get_Item(0);
    
                // Removing the selected node
                $smart->getAllNodes()->removeNode($node);
            }
        }
    }
    
    // Save Presentation
    $pres->save("RemoveSmartArtNode.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Remove SmartArt Node at Specific Position**
In this example, we will learn to remove the nodes inside SmartArt shape at particular position.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) type and Typecast selected shape to [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) if it is SmartArt.
1. Select the SmartArt shape node at index 0.
1. Now, check if the selected SmartArt node has more than 2 child nodes.
1. Now, remove the node at **Position 1** using [**RemoveNode**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) method.
1. Save the Presentation.

```php
// Load the desired the presentation
$pres = new Java("com.aspose.slides.Presentation", "AddSmartArtNode.pptx");
try {
    // Traverse through every shape inside first slide
    foreach( $pres->getSlides()->get_Item(0)->getShapes() as $shape ) 
    {
        // Check if shape is of SmartArt type
        if ($shape instanceof SmartArt) 
        {
            // Typecast shape to SmartArt
        $smart = $shape;
    
            if ($smart->getAllNodes()->size() > 0) 
            {
                // Accessing SmartArt node at index 0
                $node = $smart->getAllNodes()->get_Item(0);
    
                if ($node->getChildNodes()->size() >= 2) 
                {
                    // Removing the child node at position 1
                    ($node->getChildNodes())->removeNode(1);
                }
            }
        }
    }
    
    // Save Presentation
    $pres->save("RemoveSmartArtNodeByPosition.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Set Custom Position for Child Node in SmartArt**
Now Aspose.Slides for Java support for setting [SmartArtShape](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) [X](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape#setX-float-) and [Y](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape#setY-float-) properties. The code snippet below shows how to set custom SmartArtShape position, size and rotation also please note that adding new nodes causes a recalculation of the positions and sizes of all nodes. Also with custom position settings, user may set the nodes as per requirements.

```php
// Instantiate Presentation Class
$pres = new Java("com.aspose.slides.Presentation", "SimpleSmartArt.pptx");
try{
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, Java("com.aspose.slides.SmartArtLayoutType")->OrganizationChart);

    // Move SmartArt shape to new position
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() + $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);

    // Change SmartArt shape's widths
    $node = $smart->getAllNodes()->get_Item(2);
    shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() + $shape->getWidth() * 2);

    // Change SmartArt shape's height
    $node = $smart->getAllNodes()->get_Item(3);
    shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() + $shape->getHeight() * 2);

    // Change SmartArt shape's rotation
    $node = $smart->getAllNodes()->get_Item(4);
    shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);

    $pres->save("SmartArt.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
}finally {
    $pres->dispose();
}
```

## **Check Assistant Node**
{{% alert color="primary" %}} 

In this article we will further investigate features of SmartArt shapes added in presentation slides programmatically using Aspose.Slides for Java.

{{% /alert %}} 

We will use the following source SmartArt shape for our investigation in different sections of this article.

|![todo:image_alt_text](http://i.imgur.com/FItwczY.png)|
| :- |
|**Figure: Source SmartArt shape in slide**|

In the following sample code we will investigate how to identify **Assistant Nodes** in the SmartArt nodes collection and changing them.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of second slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) type and Typecast selected shape to [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) if it is SmartArt.
1. Traverse through all nodes inside SmartArt shape and check if they are [**Assistant Nodes**](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#isAssistant--).
1. Change the status of Assistant Node to normal node.
1. Save the Presentation.

```php
// Creating a presentation instance
$pres = new Java("com.aspose.slides.Presentation", "AddNodes.pptx");
try {
    // Traverse through every shape inside first slide
    foreach( $pres->getSlides()->get_Item(0)->getShapes() as $shape ) 
    {
        // Check if shape is of SmartArt type
        if ($shape instanceof ISmartArt) 
        {
            // Typecast shape to SmartArt
            $smart = $shape;
    
            // Traversing through all nodes of SmartArt shape
            for ($i = 0; $i < $smart->getAllNodes()->size(); $i++) 
            {
                $node = $smart->getAllNodes()->get_Item($i);
                // Check if node is Assistant node
                if ($node->isAssistant()) 
                {
                    // Setting Assistant node to false and making it normal node
                    $node->isAssistant();
                }
            }
        }
    }
    
    // Save Presentation
    $pres->save("ChangeAssitantNode.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure: Assistant Nodes Changed in SmartArt shape inside slide**|

## **Set Node’s Fill Format**
Aspose.Slides for Java makes it possible to add custom SmartArt shapes and set their fill format. This article explains how to create and access SmartArt shapes and set their fill format using Aspose.Slides for Java.

Please follow the steps below:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide using its index.
1. Add a [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt) shape by setting its [**LayoutType**](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Set the [**FillFormat**](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape#getFillFormat--) for the SmartArt shape nodes.
1. Write the modified presentation as a PPTX file.

```php
// Instantiate the presentation
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Accessing the slide
    $slide = $pres->getSlides()->get_Item(0);
    
    // Adding SmartArt shape and nodes
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, Java("com.aspose.slides.SmartArtLayoutType")->ClosedChevronProcess);
    $node = chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    
    // Setting node fill color
    foreach( $node->getShapes() as $item ) 
    {
        $item->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
        $item->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
    }
    
    // Save the presentation
    $pres->save("TestSmart.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Generate Thumbnail of SmartArt Child Node**
Developers can generate a thumbnail of Child node of a SmartArt by following the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. [Add SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Obtain the reference of a node by using its Index
1. Get the thumbnail image.
1. Save the thumbnail image in any desired image format.

```php
// Instantiate Presentation class that represents the PPTX file 
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Add SmartArt 
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, Java("com.aspose.slides.SmartArtLayoutType")->BasicCycle);

    // Obtain the reference of a node by using its Index  
    $node = $smart->getNodes()->get_Item(1);

    // Get thumbnail
    $bmp = $node->getShapes()->get_Item(0)->getThumbnail();

    // Save thumbnail
    Java("javax.imageio.ImageIO")->write($bmp, "PNG", new Java("java.io.File", "SmartArt_ChildNote_Thumbnail.png"));
} catch (JavaException $e) {
} finally {
    if ($pres != null) $pres->dispose();
}
```

