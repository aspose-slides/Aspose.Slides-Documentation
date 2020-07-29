---
title: Creating Slides SVG Image in Ruby
type: docs
weight: 50
url: /java/creating-slides-svg-image-in-ruby/
---

## **Aspose.Slides - Creating Slides SVG Image**
To Create Slides SVG Image using **Aspose.Slides Java for Ruby**, simply invoke **CreatingSvg** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



\# Instantiate Presentation class that represents the presentation file

pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'demo.pptx')

\# Getting last slide index

last_slide_position = pres.getSlides().size()

#Iterating through every presentation slide and generating SVG image

i = 0

while i < last_slide_position

    # Accessing Slides

    slide = pres.getSlides().get_Item(i)

    # Getting and saving the slide SVG image    

    slide.writeAsSvg(Rjb::import('java.io.FileOutputStream').new(data_dir + "SvgImage#{i}.svg"))



    i +=1    

end

puts "Created SVG images, please check output files."

{{< /highlight >}}
## **Download Running Code**
Download **Creating Slides SVG Image (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Slides/creatingsvg.rb)
