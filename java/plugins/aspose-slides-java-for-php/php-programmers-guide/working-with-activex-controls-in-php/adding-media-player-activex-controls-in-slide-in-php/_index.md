---
title: Adding Media Player ActiveX Controls in Slide in PHP
type: docs
weight: 10
url: /java/adding-media-player-activex-controls-in-slide-in-php/
---

## **Aspose.Slides - Adding Media Player ActiveX Controls in Slide**
To Add Media Player ActiveX Controls in Slide using **Aspose.Slides Java for PHP**, simply invoke **AddActiveX** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 # Create an instance of Presentation class

$pres = new Presentation();

\# Adding the Media Player ActiveX control

$controlType = new ControlType();

$pres->getSlides()->get_Item(0)->getControls()->addControl($controlType->WindowsMediaPlayer, 100, 100, 400, 400);

\# Access the Media Player ActiveX control and set the video path

$pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL" ,  $dataDir . "Wildlife.mp4");

\# Write the presentation as a PPTX file

$saveFormat = new SaveFormat();

$pres->save($dataDir . "AddActiveX.pptx", $saveFormat->Pptx);

print "Added ActiveX control, please check the output file.".PHP_EOL;

{{< /highlight >}}
## **Download Running Code**
Download **Adding Media Player ActiveX Controls in Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithActiveXControls/AddActiveX.php)
