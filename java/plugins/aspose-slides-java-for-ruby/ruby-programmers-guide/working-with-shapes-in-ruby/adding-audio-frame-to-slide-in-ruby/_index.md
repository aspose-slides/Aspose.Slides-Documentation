---
title: Adding Audio Frame to Slide in Ruby
type: docs
weight: 20
url: /java/adding-audio-frame-to-slide-in-ruby/
---

## **Aspose.Slides - Adding Audio Frame to Slide**
To Add Audio Frame to Slide using **Aspose.Slides Java for Ruby**, call **add_audio_frame** method of **Frame** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def add_audio_frame()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    sld = pres.getSlides().get_Item(0)

    # Load the wav sound file to stram

    fstr = Rjb::import('java.io.FileInputStream').new(Rjb::import('java.io.File').new(data_dir + "Bass-Drum.wav"))



    # Add Audio Frame

    af = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr)

    # Set Play Mode and Volume of the Audio

    af.setPlayMode(Rjb::import('com.aspose.slides.AudioPlayModePreset').Auto)

    af.setVolume(Rjb::import('com.aspose.slides.AudioVolumeMode').Loud)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "AudioFrameEmbed.pptx", save_format.Pptx)

    puts "Added audio frame to slide, please check the output file."

end   

```
## **Download Running Code**
Download **Adding Audio Frame to Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Shapes/frame.rb)
