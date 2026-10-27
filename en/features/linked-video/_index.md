---
title: Link to external videos
description: Reference a video file outside the presentation.
type: docs
url: /features/linked-video/
weight: 1100
feature_id: linked-video
feature_group: media
translationKey: slides-feature-linked-video
feature_catalogue_version: 3
feature_guides:
- /slides/net/video-frame/
---

## **Overview**

Add a video frame that points to an external media file rather than embedding the media bytes. This keeps the presentation connected to that file and avoids storing the clip inside the deck. Make the referenced media reachable wherever the presentation is used.

## **Usage example**

Link directly to a public [MP4 file](https://raw.githubusercontent.com/aspose-slides/Aspose.Slides-for-.NET/master/Examples/Data/Slides/Media/sample_bunny.mp4) and generate a blue poster with the text Video preview. The saved presentation stores the external media URL without including the clip bytes. The presenting application needs network access to that URL. This is a media reference, not an embedded web player. Use a URL for this external-reference workflow: a readable local file can be embedded when the presentation is saved. The PNG shows the poster, not video playback. This C# sample uses Aspose.Slides for .NET. It saves *linked-video.pptx* and *linked-video.png*. Install the library using the [installation guide](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;
using System.Net.Http;
using System.Drawing;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
using var posterStream = new MemoryStream();
using (var posterDeck = new Presentation())
{
    var posterShape = posterDeck.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 720, 540);
    posterShape.FillFormat.FillType = FillType.Solid;
    posterShape.FillFormat.SolidFillColor.Color = Color.DarkSlateBlue;
    posterShape.TextFrame.Text = "Video preview";
    posterShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    posterShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    posterShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    posterShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
    using var posterImage = posterDeck.Slides[0].GetImage(1f, 1f);
    posterImage.Save(posterStream, ImageFormat.Png);
}
var posterBytes = posterStream.ToArray();
var poster = presentation.Images.AddImage(posterBytes);
var videoUrl = "https://raw.githubusercontent.com/aspose-slides/Aspose.Slides-for-.NET/master/Examples/Data/Slides/Media/sample_bunny.mp4";
var videoFrame = slide.Shapes.AddVideoFrame(80, 80, 480, 270, videoUrl);
videoFrame.PictureFormat.Picture.Image = poster;
videoFrame.PlayMode = VideoPlayModePreset.OnClick;
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("linked-video.png", ImageFormat.Png);
```

## **FAQ**

### **Can I pass a YouTube page URL to embed a web player?**

This is an external media-file reference, not the separate online-video player markup used by PowerPoint.

### **What happens when the linked video file is moved?**

Restore the media at the referenced URL or update the video frame's link. A saved reference cannot make a missing clip available to the slideshow player.

### **How is a linked video different from an embedded video?**

A linked frame stores a reference to a separate media file. An embedded frame stores the media bytes inside the presentation, increasing its size but carrying the clip with the deck.

## **Guides**

- [Manage Video Frames in Presentations in .NET](/slides/net/video-frame/)

Related feature: [Embed videos in slides](/slides/features/embedded-video/).
