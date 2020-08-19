---
title: Adding Video Frame to Slide in PHP
type: docs
weight: 40
url: /java/adding-video-frame-to-slide-in-php/
---

## **Aspose.Slides - Adding Video Frame to Slide**
To Add Video Frame to Slide using **Aspose.Slides Java for PHP**, call **add_video_frame** method of **Frame** module. Here you can see example code.

**PHPCode**

```

 public static function add_video_frame($dataDir=null)

{

    # Create an instance of Presentation class

    $pres = new Presentation();

    # Get the first slide

    $sId = $pres->getSlides()->get_Item(0);

    # Add Video Frame

    $vf = $sId->getShapes()->addVideoFrame(50, 150, 300, 150, $dataDir . "Wildlife.mp4");

    # Set Play Mode and Volume of the Video

    $videoPlayModePreset = new VideoPlayModePreset();

    $audioVolumeMode = new AudioVolumeMode();

    $vf->setPlayMode($videoPlayModePreset->Auto);

    $vf->setVolume($audioVolumeMode->Loud);

    # Write the presentation as a PPTX file

    $save_format = new SaveFormat();

    $pres->save($dataDir . "VideoFrame.pptx", $save_format->Pptx);

    print "Added video frame to slide, please check the output file." . PHP_EOL;

}

```
## **Download Running Code**
Download **Adding Video Frame to Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithShapes/Frame.php)
