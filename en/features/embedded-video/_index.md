---
title: Embed videos in slides
description: Store video clips in a presentation and set their playback options.
type: docs
url: /features/embedded-video/
weight: 1090
feature_id: embedded-video
feature_group: media
translationKey: slides-feature-embedded-video
feature_catalogue_version: 3
feature_guides:
- /slides/net/video-frame/
---

## **Overview**

Embed a video file in a slide, position its video frame and configure presentation playback settings. A poster image can represent the video on the slide before it plays. The presentation retains the embedded media data for later extraction or editing.

## **Usage example**

Download the public [sample MP4](https://raw.githubusercontent.com/aspose-slides/Aspose.Slides-for-.NET/master/Examples/Data/Slides/Media/sample_bunny.mp4) to the working directory and generate a blue poster with the text Video preview. Embed the MP4 and set click-to-play behavior. The saved presentation carries the original media bytes. The PNG shows the poster, not video playback. The sample requires network access and Aspose.Slides for .NET. It saves *embedded-video.pptx* and *embedded-video.png*. Install the library using the [installation guide](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;
using System.Net.Http;
using System.Drawing;

using var httpClient = new HttpClient();
var videoBytes = httpClient.GetByteArrayAsync("https://raw.githubusercontent.com/aspose-slides/Aspose.Slides-for-.NET/master/Examples/Data/Slides/Media/sample_bunny.mp4").GetAwaiter().GetResult();
File.WriteAllBytes("sample_bunny.mp4", videoBytes);
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
var video = presentation.Videos.AddVideo(videoBytes);
var videoFrame = slide.Shapes.AddVideoFrame(80, 80, 480, 270, video);
videoFrame.PictureFormat.Picture.Image = poster;
videoFrame.PlayMode = VideoPlayModePreset.OnClick;
presentation.Save("embedded-video.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("embedded-video.png", ImageFormat.Png);
```

## **FAQ**

### **Does embedding video convert it to another codec?**

Embedding stores the supplied media. Playback still depends on the media format and the application used to present the deck.

### **Does the video travel inside the saved presentation?**

Yes. Embedding includes the media bytes in the presentation, so the original clip can be extracted from it. Compatible codecs and playback support are still required by the presenting application.

### **How do I choose the poster image shown before playback?**

Assign an image to the video frame's picture. This sample generates the poster explicitly; it does not assume a video frame is extracted automatically.

## **Guides**

- [Manage Video Frames in Presentations in .NET](/slides/net/video-frame/)

Related feature: [Link to external videos](/slides/features/linked-video/).
