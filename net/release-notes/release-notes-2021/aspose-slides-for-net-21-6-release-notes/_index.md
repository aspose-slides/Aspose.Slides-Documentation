---
title: Aspose.Slides for .NET 21.6 Release Notes
type: docs
weight: 20
url: /net/aspose-slides-for-net-21-6-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for .NET 21.6](https://www.nuget.org/packages/Aspose.Slides.NET/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|**Related Documentation**|
| :- | :- | :- | :- |
|SLIDESNET-42514|Support of Cylinder column shape for 3-D Column and 3-D Bar Charts|Feature|<https://docs.aspose.com/slides/net/powerpoint-charts/>
|SLIDESNET-42447|Support of 3-D Bar Chart|Feature|<https://docs.aspose.com/slides/net/powerpoint-charts/>
|SLIDESNET-37955|Support of 3D Transforms for thumbnails|Feature|<https://docs.aspose.com/slides/net/3d-presentation/>
|SLIDESNET-30675|Support of Presentation to XAML export|Feature|
|SLIDESNET-42623|Loading presentation throws PptxReadException|Bug|<https://docs.aspose.com/slides/net/open-presentation/>
|SLIDESNET-42598|Copying Slide with Chart runs into Deadlock|Bug|<https://docs.aspose.com/slides/net/clone-slides/>
|SLIDESNET-42586|PPTX update chart values produces bad output file|Bug|<https://docs.aspose.com/slides/net/chart-workbook/>
|SLIDESNET-42583|SVG external link is removed from slide|Bug|<https://docs.aspose.com/slides/net/save-presentation/>
|SLIDESNET-42582|IParagraph.GetRect returns wrong value for height|Bug|<https://docs.aspose.com/slides/net/manage-paragraph/>
|SLIDESNET-42578|IParagraph.GetRect returns incorrect position or width for list items|Bug|<https://docs.aspose.com/slides/net/manage-paragraph/>
|SLIDESNET-42568|PPTX to JPEG: Wrong fonts used in the output file|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-jpg/>
|SLIDESNET-42563|Animations getting damaged when PPT file is saved|Bug|<https://docs.aspose.com/slides/net/save-presentation/ https://docs.aspose.com/slides/net/powerpoint-animation/>
|SLIDESNET-42561|PPTX to PDF: Unwanted shape in output file|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf/>
|SLIDESNET-42554|Creating thumbnail of chart thows ArgumentException|Bug|<https://docs.aspose.com/slides/net/create-shape-thumbnails/>
|SLIDESNET-42550|Calculated paragraph height is incorrect|Bug|<https://docs.aspose.com/slides/net/manage-paragraph/>
|SLIDESNET-41563|Image rotation is missing in generated thumbnail|Bug|<https://docs.aspose.com/slides/net/3d-presentation/>
|SLIDESNET-41008|The effects lost in generated PNG|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-jpg/>
|SLIDESNET-39925|Pptx to pdf not properly converted|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf>
|SLIDESNET-39365|Missing shape shadow and bevel when converting to PDF|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf/>
|SLIDESNET-38555|Incorrect font size in notes page|Bug|<https://docs.aspose.com/slides/net/shape-effective-properties/>
|SLIDESNET-36944|3D object is missing in generated thumbnail|Bug|<https://docs.aspose.com/slides/net/3d-presentation/>
|SLIDESNET-36385|3D effects are missing for shapes in exported PDF|Bug|<https://docs.aspose.com/slides/net/3d-presentation/>
|SLIDESNET-34958|The pentagon shape is improperly rendered in generated PDF|Bug|<https://docs.aspose.com/slides/net/3d-presentation/>
|SLIDESNET-34632|The border for the shapes are improperly around the shape in exported XPS|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/>
|SLIDESNET-32336|Wrong shape direction on thumbnail|Bug|<https://docs.aspose.com/slides/net/3d-presentation/>

## Public API Changes ##

## Support of Presentation to XAML export ##

o support the Presentation to XAML export new API members have been added:

IXamlOptions interface and XamlOptions class. IXamlOptions definition:

``` csharp
/// <summary>
/// Options that control how a XAML document is saved.
/// </summary>
/// <example>
/// <code>
/// [C#]
/// using (Presentation pres = new Presentation("pres.pptx"))
/// {
/// 	pres.Save(new XamlOptions { ExportHiddenSlides = true });
/// }
/// </code>
/// </example>    
public interface IXamlOptions : ISaveOptions
{
    /// <summary>
    /// Determines whether hidden slides will be exported.
    /// </summary>
    /// <example>
    /// <code>
    /// [C#]
    /// using (Presentation pres = new Presentation("pres.pptx"))
    /// {
    /// 	pres.Save(new XamlOptions { ExportHiddenSlides = true });
    /// }
    /// </code>
    /// </example>        
    bool ExportHiddenSlides { get; set; }
    
    /// <summary>
    /// Represents an implementation of IOutputSaver interface.
    /// </summary>
    IXamlOutputSaver OutputSaver { get; set; }
}
```

To export Presentation to XAML a new method added to the Presentation class;

``` csharp
public void Save(IXamlOptions options);
```

The code sample below demonstrates the export of Presentation to the set of XAML files:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

XAML files will be saved in new created folder "pres".

## IEffect.TargetShape property has been added ##

Aspose.Slides.Animation.IEffect.TargetShape property has been added. It returns the shape that is affected by this effect.

Property declaration:

``` csharp
/// <summary>
/// Returns target shape for effect.
/// Read-only <see cref="IShape"/>.
/// </summary>
IShape TargetShape { get; }
```

Code sample below demonstrates output information of all animated shapes in main sequence for all slides in the presentation.

``` csharp
using (Presentation pres = new Presentation("SomePresentation.pptx"))
{
    foreach (ISlide slide in pres.Slides)
        foreach (IEffect effect in slide.Timeline.MainSequence)
            Console.WriteLine(effect.Type + " animation effect is set to shape#" + effect.TargetShape.UniqueId + " on slide#" + slide.SlideNumber);
}
```

## Aspose.Slides.Export.Web.* interfaces were removed ##

The following interfaces were removed from Aspose.Slides.Export.Web namespace:

* IInput (please use Input instead)
* IOutput (please use Output instead)
* IStorage (please use Storage instead)
* IWebDocument (please use WebDocument instead)
* IWebDocumentOptions (please use WebDocumentOptions instead)
* ITemplateEngine method:

``` csharp
string Compile<TModel>(string key, TModel model);
```

Was replaced with:

``` csharp
string Compile(string key, object model);
```

## Storage.ContainsKey method has been added ##

Aspose.Slides.Export.Web.Storage.ContainsKey method has been added. It allows to check if some value with certain key was added to the storage.

Method declaration:

``` csharp
/// <summary>
/// Determines whether the storage contains an element with the specified key.
/// </summary>
/// <param name="key">Key of the value.</param>
/// <returns>True if the storage contains an element with the specified key, false otherwise.</returns>
public bool ContainsKey(string key)
{
   ...
}
```

Sample code (an example of Aspose.Slides.WebExtensions template) demonstrating new method usage:

``` javascript
@model TemplateContext<AutoShape>

@{
    AutoShape contextObject = Model.Object;

    string id = "slide-" + contextObject.Slide.SlideId + "-shape-" + contextObject.UniqueId;

    string animationAttributes = "";
    if (Model.Local.ContainsKey("animationAttributes"))
    {
        animationAttributes = Model.Local.Get<string>("animationAttributes");
    }
}

@{
    <div class="shape" id="@id" @Raw(animationAttributes)>
        @{
            var subModel = Model.SubModel((TextFrame)contextObject.TextFrame);
            @Include("textframe", subModel)        
        }
    </div>
}
```

## WebDocumentOptions.AnimateShapes property has been added ##

Aspose.Slides.Export.Web.WebDocumentOptions.AnimateShapes property has been added. If the property set to true exported HTML results will contain shape animations.

The code sample below demonstrates how the property can be used within the project based on Aspose.Slides.WebExtensions. 

``` csharp
using (Presentation pres = new Presentation(@"SomePresentation.pptx"))
{
    WebDocumentOptions opts = new WebDocumentOptions() { EmbedImages = false , AnimateTransitions = true, AnimateShapes = true };
    pres.ToSinglePageWebDocument(opts, @"templates\single-page", @"single-page-presentation").Save();
}
```

More information about Aspose.Slides.WebExtensions is available here: Aspose.Slides.Export.Web members application example.