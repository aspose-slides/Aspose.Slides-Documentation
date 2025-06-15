---
title: Ink
type: docs
weight: 180
url: /net/examples/elements/ink
---

Provides examples of accessing existing ink shapes and removing them using **Aspose.Slides for .NET**.

> ❗ **Note:** Ink shapes represent user input from specialized devices. Aspose.Slides cannot create new ink strokes programmatically, but you can read and modify existing ink.

## Access Ink

Read the tags from the first ink shape on a slide.

```csharp
static void Access_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Use tagName as needed
        }
    }
}
```

## Remove Ink

Delete an ink shape from the slide if one exists.

```csharp
static void Remove_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```
