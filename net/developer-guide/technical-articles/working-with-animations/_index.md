---
title: Working with Animations
type: docs
weight: 30
url: /net/working-with-animations/
---

{{% alert color="primary" %}} 

This information is outdated, please visit [**Powerpoint Animation**](/slides/net/powerpoint-animation/).

{{% /alert %}} 


## **Animation Support in Aspose.Slides for .NET**
In Aspose.Slides for .NET, various animations effects can be applied on the shapes. As every element on the slide including text, pictures, OLE Object, table etc is considered as a shape, it means we can apply animation effect on every element of a slide. For this purpose, **AnimationSettings** property exposed by **Shape** object can be used. This property returns an **AnimationSettings** object which represents an animation effect that can be applied to the specified shape. There are various properties exposed by this object that are used to not only apply the animation effect, but also control the animation behavior. First you can apply the animation effect and then set its activation automatically on a time interval or on click. **EntryEffect** property exposed by **AnimationSettings** object is used to apply any one of the sixty animation effect supported by Aspose.Slides for .NET. Further you can apply an after effect as well using **AfterEffect** property. In the following lines of code, we have added a rectangle with some text and an ellipse shape with some animation effects in first slide of the presentation created from scratch. 

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Slides-Animations-SupportOfAnimation-SupportOfAnimation.cs" >}}




## **Setting Animation Order**
In a presentation, animation effects can be applied on more than one shape, their order may also be controlled using **AnimationOrder** property exposed by **AnimationSettings** object. In the above example, we created two shapes with animation effects. They will appear in the order in which they were created. That is, rectangle shape with animation will be activated first and the ellipse shape will be activated subsequently. This can be changed on adding the following lines before writing the presentation to disk. 

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Slides-Animations-SetAnimationOrder-SetAnimationOrder.cs" >}}


## **Conclusion**
{{% alert color="primary" %}} 

We can apply any of the animation effects as defined by **ShapeEntryEffect** enumeration using **EntryEffect** property of **AnimationSettings** class. These effects can be applied to any desired number of shapes and the order of these animated shapes can also be controlled through **AnimationOrder** property. 

{{% /alert %}} 
