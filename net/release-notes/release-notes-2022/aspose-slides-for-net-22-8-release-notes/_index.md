 ---
title: Aspose.Slides for .NET 22.8 Release Notes
type: docs
weight: 25
url: /net/aspose-slides-for-net-22-8-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [ Aspose.Slides for .NET 22.8](https://www.nuget.org/packages/Aspose.Slides.NET/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|**Related Documentation**|
| :- | :- | :- | :- |
|SLIDESNET-43261|Supporting "Slide Show" / "Set Up Show" settings|Feature|
|SLIDESNET-42752|Extracting audio file from slide timeline|Feature|<https://docs.aspose.com/slides/net/shape-animation/>
|SLIDESNET-40604|Rendering presentation to pure HTML without SVG parent tag|Feature|<https://docs.aspose.com/slides/net/export-to-html5/>
|SLIDESNET-36907|Support to set slide show settings|Feature|
|SLIDESNET-35994|Add support of 3-D Surface chart type|Feature|<https://docs.aspose.com/slides/net/create-chart/>
|SLIDESNET-43269|Incorrect layouting of text lines when converting PPT slides to JPG/SVG|Enhancement|<https://docs.aspose.com/slides/net/convert-slide/>
|SLIDESNET-43244|Failed to check "Transitions / Advance Slide / After" flag|Enhancement|<https://docs.aspose.com/slides/net/slide-transition/>
|SLIDESNET-42740|Changing slide number does not work|Enhancement|<https://docs.aspose.com/slides/net/presentation-header-and-footer/>
|SLIDESNET-43334|Loading a presentation throws OutOfMemoryException|Bug|<https://docs.aspose.com/slides/net/open-presentation/>
|SLIDESNET-43328|NullReferenceException while trying to save shape to SVG part 2|Bug|<https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/>
|SLIDESNET-43322|Shape background colors are not consistent but values are equal|Bug|<https://docs.aspose.com/slides/net/shape-formatting/>
|SLIDESNET-43320|Fill color of shapes is changed when loading and saving PPT file|Bug|<https://docs.aspose.com/slides/net/shape-formatting/>
|SLIDESNET-43319|Text is distorted when converting a presentation slide to image|Bug|<https://docs.aspose.com/slides/net/convert-slide/>
|SLIDESNET-43316|IMasterSlide.Preserve property does not work|Bug|<https://docs.aspose.com/slides/net/slide-master/>
|SLIDESNET-43314|Loading a presentation throws PptxReadException: LoadAnnotationElementData|Bug|<https://docs.aspose.com/slides/net/open-presentation/>
|SLIDESNET-43311|Aspose.Slides does not see digital signatures|Bug|<https://docs.aspose.com/slides/net/password-protected-presentation/>
|SLIDESNET-43299|NullReferenceException when creating thumbnail of tables with custom style|Bug|<https://docs.aspose.com/slides/net/create-shape-thumbnails/>
|SLIDESNET-43292|Broken presentation when using "AddClone"|Bug|<https://docs.aspose.com/slides/net/clone-slides/>
|SLIDESNET-43286|Getting effective portion value throws an unexpected exception. |Bug|<https://docs.aspose.com/slides/net/shape-effective-properties/>
|SLIDESNET-43283|Part of HTML content is ignored when added into presentation|Bug|<https://docs.aspose.com/slides/net/manage-paragraph/#import-html-text-in-paragraphs>
|SLIDESNET-43282|Changed the number format of chart data labels|Bug|<https://docs.aspose.com/slides/net/powerpoint-charts/>
|SLIDESNET-43275|Line is appearing when converting slide from PPTX to PNG|Bug|<https://docs.aspose.com/slides/net/convert-slide/>
|SLIDESNET-43267|Specific PPTX causes OutOfMemoryException when saving it in Linux|Bug|<https://docs.aspose.com/slides/net/open-presentation/>
|SLIDESNET-43262|Image is upside down when converting PPTX to PDF|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/>
|SLIDESNET-43246|Text drifts when converting presentation slides to images|Bug|<https://docs.aspose.com/slides/net/convert-slide/>
|SLIDESNET-43146|Cannot open correct unprotected document when password is applied|Bug|<https://docs.aspose.com/slides/net/password-protected-presentation/>
|SLIDESNET-43137|Failed to set gap width for a histogram chart|Bug|<https://docs.aspose.com/slides/net/powerpoint-charts/>
|SLIDESNET-43022|3D chart is not displayed when converting a slide to image|Bug|< https://docs.aspose.com/slides/net/convert-slide/>
|SLIDESNET-42713|Text font is incorrect after converting PPTX to PNG|Bug|< https://docs.aspose.com/slides/net/convert-powerpoint-to-png/>
|SLIDESNET-42644|Image quality of document gets fade when converting slide to HTML|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-to-html/>
|SLIDESNET-41942|Chart is missing in exported PDF|Bug|< https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/>
|SLIDESNET-36618|Charts missing in generated Pdf|Bug|< https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/>
|SLIDESNET-36445|Surface chart is lost and legend is incorrect when thumbnail is generated|Bug|<https://docs.aspose.com/slides/net/convert-slide/>
|SLIDESNET-35820|Missing charts in generated PDF file|Bug|< https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/>
|SLIDESNET-35591|3D effects on charts are lost in generated PDF|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/>
|SLIDESNET-34063|Surface chart failed to render in generated PDF|Bug|< https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/>
|SLIDESNET-33487|StartingSlide doesn't work|Bug|


## Public API Changes ##

### Presentation Slide Show Setup Settings support ###

Presentation Slide Show Settings support was added. 

![Slide Show Settings](slideShowSetup.png)

The following classes and preoprties were addeded to support Slide Show Settings:

* [Presentation.SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/) property - provides the access to setup the slide show settings of the presentation.
* [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/slideshowsettings/) class - represents the slide show settings for the presentation. It has the following properties:
  - [SlideShowType](https://reference.aspose.com/slides/net/aspose.slides/slideshowsettings/slideshowtype)
  - [Loop](https://reference.aspose.com/slides/net/aspose.slides/slideshowsettings/loop)
  - [ShowNarration](https://reference.aspose.com/slides/net/aspose.slides/slideshowsettings/shownarration)
  - [ShowAnimation](https://reference.aspose.com/slides/net/aspose.slides/slideshowsettings/showanimation)
  - [PenColor](https://reference.aspose.com/slides/net/aspose.slides/slideshowsettings/pencolor)
  - [Slides](https://reference.aspose.com/slides/net/aspose.slides/slideshowsettings/slides)
  - [UseTimings](https://reference.aspose.com/slides/net/aspose.slides/slideshowsettings/usetimings)
* [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk) class - represents browsed at a kiosk (full screen) settings.
* [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual) class - represents browsed by individual (window) settings.
* [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker) class - represents presented by a speaker (full screen) settings.
* [SlidesRange](https://reference.aspose.com/slides/net/aspose.slides/slidesrange/) class - represents a slides range.

Here is an example of setting "presented by a speaker" mode of a slide show:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.SlideShowSettings.SlideShowType = new PresentedBySpeaker();
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

Settings "browsed by individual" mode: 

``` csharp
using (Presentation pres = new Presentation())
{
    BrowsedByIndividual browsedByIndividual = new BrowsedByIndividual {ShowScrollbar = true};
    pres.SlideShowSettings.SlideShowType = browsedByIndividual;
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

### Animation Effect.Sound property added ###

Embedded effect of the sound support was added - [Effect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) property. 

``` csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    
    // Gets the effects sequence for the slide
    ISequence effectsSequence = slide.Timeline.MainSequence;
       
    foreach (IEffect effect in effectsSequence)
    {
        if (effect.Sound == null)
            continue;
        
        // Extracts the effect sound in byte array
        byte[] audio = effect.Sound.BinaryData;
    }
}
