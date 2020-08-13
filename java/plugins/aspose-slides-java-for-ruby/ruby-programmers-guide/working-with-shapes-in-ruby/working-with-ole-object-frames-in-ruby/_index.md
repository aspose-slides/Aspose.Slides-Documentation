---
title: Working with OLE Object Frames in Ruby
type: docs
weight: 190
url: /java/working-with-ole-object-frames-in-ruby/
---

## **Aspose.Slides - Accessing an OLE Object Frame from a Slide**
To Access an OLE Object Frame from a Slide using **Aspose.Slides Java for Ruby**, simply invoke **OleObject** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



\# Create an instance of Presentation class

pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'OleEmbed.pptx')

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Cast the shape to OleObjectFrameEx

oof = sld.getShapes().get_Item(0)

\# Read the OLE Object and write it to disk

if oof != nil

    fstr = Rjb::import('java.io.FileOutputStream').new(data_dir + "excelFromOLEObject.xlsx")

    buf = oof.getObjectData()

    fstr.write(buf, 0, buf.length)

    fstr.flush()

    fstr.close()

    puts "Excel OLE Object written as excelFromOLEObject.xlsx file"

end

```
## **Download Running Code**
Download **Working with OLE Object Frames (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Shapes/oleobject.rb)
