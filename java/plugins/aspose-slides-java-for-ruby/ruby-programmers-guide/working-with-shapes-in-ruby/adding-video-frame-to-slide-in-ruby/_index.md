---
title: Adding Video Frame to Slide in Ruby
type: docs
weight: 70
url: /java/adding-video-frame-to-slide-in-ruby/
---

## **Aspose.Slides - Adding Video Frame to Slide**
To Add Video Frame to Slide using **Aspose.Slides Java for Ruby**, call **add_video_frame** method of **Frame** module. Here you can see example code.

**Ruby Code**

```

 def add_video_frame()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    sld = pres.getSlides().get_Item(0)

    # Add Video Frame

    vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, data_dir + "Wildlife.mp4")

    # Set Play Mode and Volume of the Video

    vf.setPlayMode(Rjb::import('com.aspose.slides.VideoPlayModePreset').Auto)

    vf.setVolume(Rjb::import('com.aspose.slides.AudioVolumeMode').Loud)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "VideoFrame.pptx", save_format.Pptx)

    puts "Added video frame to slide, please check the output file."

end   

```
## **Download Running Code**
Download **Adding Video Frame to Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Shapes/frame.rb)
