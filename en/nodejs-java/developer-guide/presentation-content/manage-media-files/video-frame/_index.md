---
title: Video Frame
type: docs
weight: 10
url: /nodejs-java/video-frame/
keywords: "Add video, create video frame, extract video, PowerPoint presentation, Java, Aspose.Slides for Node.js via Java"
description: "Add Video frame to PowerPoint presentation in JavaScript"
---

A well-placed video in a presentation can make your message more compelling and increase engagement levels with your audience. 

PowerPoint allows you to add videos to a slide in a presentation in two ways:

* Add or embed a local video (stored on your machine)
* Add an online video (from a web source such as YouTube).

To allow you to add videos (video objects) to a presentation, Aspose.Slides provides the [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) class, [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) class, and other relevant types.

## **Create Embedded Video Frame**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation. 

1. Create an instance of the [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)class.
1. Get a slide's reference through its index. 
1. Add an [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) object and pass the video file path to embed the video with the presentation.
1. Add an [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) object to create a frame for the video.
1. Save the modified presentation. 

This JavaScript code shows you how to add a video stored locally to a presentation:

```javascript
// Instantiates the Presentation class
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Loads the video
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Gets the first slide and adds a videoframe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Saves the presentation to disk
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Alternatively, you can add a video by passing its file path directly to the [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) method:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Create Video Frame with Video from Web Source**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) support YouTube videos in presentations. If the video you want to use is available online (e.g. on YouTube), you can add it to your presentation through its web link. 

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)class
1. Get a slide's reference through its index. 
1. Add an [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) object and pass the link to the video.
1. Set a thumbnail for the video frame. 
1. Save the presentation. 

This JavaScript code shows you how to add a video from the web to a slide in a PowerPoint presentation:

```javascript
// Instantiates a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}

```

## **Extract Video From Slide**

Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class to load the presentation containing the video.
2. Iterate through all the [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) objects.
3. Iterate through all the [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) objects to find a [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).
4. Save the video to disk.

This JavaScript code shows you how to extract the video on a presentation slide:

```javascript
// Instantiates a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // Gets the File Extension
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

