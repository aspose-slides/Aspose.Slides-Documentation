---
title: Adding Media Player ActiveX Controls in Slide in Ruby
type: docs
weight: 10
url: /java/adding-media-player-activex-controls-in-slide-in-ruby/
---

## **Aspose.Slides - Adding Media Player ActiveX Controls in Slide**
To Add Media Player ActiveX Controls in Slide using **Aspose.Slides Java for Ruby**, simply invoke **AddActiveX** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'

\# Create an instance of Presentation class

pres = Rjb::import('com.aspose.slides.Presentation').new

\# Adding the Media Player ActiveX control

pres.getSlides().get_Item(0).getControls().addControl(Rjb::import('com.aspose.slides.ControlType').WindowsMediaPlayer, 100, 100, 400, 400)

\# Access the Media Player ActiveX control and set the video path

pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL" ,  data_dir + "Wildlife.mp4")

\# Write the presentation as a PPTX file

pres.save(data_dir + "AddActiveX.pptx", Rjb::import('com.aspose.slides.SaveFormat').Pptx)

puts "Added ActiveX control, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download **Adding Media Player ActiveX Controls in Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/ActiveX/addactivex.rb)
