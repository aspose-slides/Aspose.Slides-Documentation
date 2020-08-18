---
title: Working with Animations
type: docs
weight: 140
url: /cpp/working-with-animations/
---

{{% alert color="primary" %}} 

Since presentations are meant to present something, their visual appearance and interactive behavior is always considered while creating them. Animations play an important role in order to make presentations eye catching and attractive for the viewers. Aspose.Slides for C++ offers a wide range of options for applying various types of animation effects on the shapes in the presentation. This article covers some of the animation features as supported by Aspose.Slides for C++. 

{{% /alert %}} 
#### **Animation Support in Aspose.Slides for C++**
In Aspose.Slides for C++, various animations effects can be applied on the shapes. As every element on the slide including text, pictures, OLE Object, table etc is considered as a shape, it means we can apply animation effect on every element of a slide. For this purpose, **AnimationSettings** property exposed by **Shape** object can be used. This property returns an **AnimationSettings** object which represents an animation effect that can be applied to the specified shape. There are various properties exposed by this object that are used to not only apply the animation effect, but also control the animation behavior. First you can apply the animation effect and then set its activation automatically on a time interval or on click. **EntryEffect** property exposed by **AnimationSettings** object is used to apply any one of the sixty animation effect supported by Aspose.Slides for C++. Further you can apply an after effect as well using **AfterEffect** property. In the following lines of code, we have added a rectangle with some text and an ellipse shape with some animation effects in first slide of the presentation created from scratch. 

[**C#**]()

``` cpp

 //Instantiate a presentation

Presentation pptPresentation = new Presentation();



//Get first slide

Slide slideOne = pptPresentation.GetSlideByPosition(1);

//Add a rectangle shape

Rectangle rectangleShape = slideOne.Shapes.AddRectangle(50, 50, 500, 250);



//Add a Text Frame

rectangleShape.AddTextFrame("Animated Text");

//Set shape to fit according to text

rectangleShape.TextFrame.FitShapeToText = true;

//Fill rectangle with some color

rectangleShape.FillFormat.Type = FillType.Solid;

rectangleShape.FillFormat.ForeColor = System.Drawing.Color.Firebrick;

//Add an ellipse shape

Ellipse ellipseShape = slideOne.Shapes.AddEllipse(2500, 50, 500, 250);

//Set reference to AnimationSettings object associated with rectangle

AnimationSettings rectangleAnimation = rectangleShape.AnimationSettings;



//Set reference to AnimationSettings object associated with ellipse

AnimationSettings ellipseAnimation = ellipseShape.AnimationSettings;

//Apply animation effects on rectangle

rectangleAnimation.EntryEffect = ShapeEntryEffect.ZoomOutSlightly;

rectangleAnimation.AfterEffect = ShapeAfterEffect.Dim;

//Apply animation effects on ellipse

ellipseAnimation.EntryEffect = ShapeEntryEffect.DiamondOut;

ellipseAnimation.AfterEffect = ShapeAfterEffect.HideOnClick;

//Write presentation to the disk

pptPresentation.Write("d:\\ppt\\may\\animatedPres.ppt");



```


#### **Setting Animation Order**
In a presentation, animation effects can be applied on more than one shape, their order may also be controlled using **AnimationOrder** property exposed by **AnimationSettings** object. In the above example, we created two shapes with animation effects. They will appear in the order in which they were created. That is, rectangle shape with animation will be activated first and the ellipse shape will be activated subsequently. This can be changed on adding the following lines before writing the presentation to disk. 

[**C#**]()

``` cpp

 //Setting the animation order

ellipseAnimation.AnimationOrder = 1;

rectangleAnimation.AnimationOrder = 2;



```


#### **Conclusion**
{{% alert color="primary" %}} 

We can apply any of the animation effects as defined by **ShapeEntryEffect** enumeration using **EntryEffect** property of **AnimationSettings** class. These effects can be applied to any desired number of shapes and the order of these animated shapes can also be controlled through **AnimationOrder** property. 

{{% /alert %}} 
#### **Related Sections**
[Animation Settings Class](http://docs.aspose.com/display/slidesnet/AnimationSettings+Class)

[ShapeEntryEffect Enumeration](http://docs.aspose.com/display/slidesnet/ShapeEntryEffect+Enumeration)
