---
title: Adding Audio Frame to Slide using Aspose.Slides
type: docs
weight: 10
url: /java/adding-audio-frame-to-slide-using-aspose-slides/
---

## **Aspose.Slides - Adding Audio Frame to Slide**
Aspose.Slides for Java allows developers to add audio files in their slides. These audio files are embedded in the slides as **Audio Frames**. An Audio Frame contains the embedded audio file. 

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents the PPTX

Presentation pres = new Presentation();

//Get the first slide

ISlide sld = pres.getSlides().get_Item(0);

//Load the wav sound file to stram

FileInputStream fstr = new FileInputStream(new File("C:\\logon.wav"));

//Add Audio Frame

IAudioFrame af = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);

//Set Play Mode and Volume of the Audio

af.setPlayMode(AudioPlayModePreset.Auto);
s
af.setVolume(AudioVolumeMode.Loud);

//Write the PPTX file to disk

pres.save(dataDir + "AsposeAudio.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://archive.codeplex.com/?p=asposeslidesjavaapachepoi)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://archive.codeplex.com/?p=asposeslidesjavaapachepoi#src/main/java/com/aspose/slides/examples/asposefeatures/mediacontrols/addingaudioframe/AsposeAudioFrame.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/mediacontrols/addingaudioframe/AsposeAudioFrame.java)

{{% alert color="primary" %}} 

For more details, visit [Adding Audio Frame to Slide](http://docs.aspose.com:8082/docs/display/slidesjava/Adding+Audio+Frame+to+Slide).

{{% /alert %}}
