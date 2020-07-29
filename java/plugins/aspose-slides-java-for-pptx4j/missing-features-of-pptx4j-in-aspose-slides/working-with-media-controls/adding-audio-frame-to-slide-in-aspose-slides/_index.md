---
title: Adding Audio Frame to Slide in Aspose.Slides
type: docs
weight: 10
url: /java/adding-audio-frame-to-slide-in-aspose-slides/
---

## **Aspose.Slides - Adding Audio Frame to Slide**
Aspose.Slides for Java allows developers to add audio files in their slides. These audio files are embedded in the slides as **Audio Frames**. An Audio Frame contains the embedded audio file. 

**Java**

{{< highlight java >}}

 //Instantiate Prsentation class that represents the PPTX

Presentation pres = new Presentation();

//Get the first slide

ISlide sld = pres.getSlides().get_Item(0);

//Load the wav sound file to stram

FileInputStream fstr = new FileInputStream(new File("logon.wav"));

//Add Audio Frame

IAudioFrame af = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);

//Set Play Mode and Volume of the Audio

af.setPlayMode(AudioPlayModePreset.Auto);

af.setVolume(AudioVolumeMode.Loud);

//Write the PPTX file to disk

pres.save("AsposeAudio.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Adding Audio Frame to Slide](http://docs.aspose.com:8082/docs/display/slidesjava/Adding+Audio+Frame+to+Slide).

{{% /alert %}}
