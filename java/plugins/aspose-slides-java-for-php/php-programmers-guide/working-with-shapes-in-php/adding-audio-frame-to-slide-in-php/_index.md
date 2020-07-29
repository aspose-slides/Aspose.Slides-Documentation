---
title: Adding Audio Frame to Slide in PHP
type: docs
weight: 10
url: /java/adding-audio-frame-to-slide-in-php/
---

## **Aspose.Slides - Adding Audio Frame to Slide**
To Add Audio Frame to Slide using **Aspose.Slides Java for PHP**, call **add_audio_frame** method of **Frame** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 public static function add_audio_frame($dataDir=null)

{

    # Create an instance of Presentation class

    $pres = new Presentation();

    # Get the first slide

    $sId = $pres->getSlides()->get_Item(0);

    # Load the wav sound file to stram

    $fstr = new FileInputStream(new File($dataDir . "Bass-Drum.wav"));

    # Add Audio Frame

    $af = $sId->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);

    # Set Play Mode and Volume of the Audio

    $audioPlayModePreset = new AudioPlayModePreset();

    $audioVolumeMode = new AudioVolumeMode();

    $af->setPlayMode($audioPlayModePreset->Auto);

    $af->setVolume($audioVolumeMode->Loud);

    # Write the presentation as a PPTX file

    $save_format = new SaveFormat();

    $pres->save($dataDir . "AudioFrameEmbed.pptx", $save_format->Pptx);

    print "Added audio frame to slide, please check the output file." . PHP_EOL;

}

{{< /highlight >}}
## **Download Running Code**
Download **Adding Audio Frame to Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithShapes/Frame.php)
