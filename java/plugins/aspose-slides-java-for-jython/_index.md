---
title: Aspose.Slides Java for Jython
type: docs
weight: 40
url: /java/aspose-slides-java-for-jython/
---

## **Introduction**
### **What is Jython?**
Jython is a Java implementation of Python that combines expressive power with clarity. Jython is freely available for both commercial and non-commercial use and is distributed with source code. Jython is complementary to Java and is especially suited for the following tasks:

- **Embedded scripting** - Java programmers can add the Jython libraries to their system to allow end users to write simple or complicated scripts that add functionality to the application.
- **Interactive experimentation** - Jython provides an interactive interpreter that can be used to interact with Java packages or with running Java applications. This allows programmers to experiment and debug any Java system using Jython.
- **Rapid application development** - Python programs are typically 2-10X shorter than the equivalent Java program. This translates directly to increased programmer productivity. The seamless interaction between Python and Java allows developers to freely mix the two languages both during development and in shipping products. 
### **Aspose.Slides for Java**
Aspose.Slides for Java is a unique PowerPoint management component that enables Java based applications to read, write and manipulate PowerPoint documents without using Microsoft PowerPoint.

One can generate, modify, copy, convert, render and print presentations without installing Microsoft PowerPoint.

Aspose.Slides for Java supports presentation file formats including PPT, PPS, POT, PresentationML (OOXML, PPTX) and Open Document Presentations (ODP).
### **Aspose.Slides Java for Jython**
Aspose.Slides Java for Jython is a project that demonstrates / provides the Aspose.Slides for Java API usage examples in Jython.
## **System Requirements and Supported Platforms**
### **System Requirements**
**Following are the system requirements to use Aspose.Slides Java for Jython:**

- Java 1.5 or above installed
- Downloaded Aspose.Slides component
- Jython 2.7.0
### **Supported Platforms**
**Following are the supported platforms:**

- Aspose.Slides 15.4 and above.
- Java IDE (Eclipse, NetBeans ...)
## **Download Installation and Usage**
### **Downloading**
**Download Examples from social coding websites**

Following releases of running examples are available to download on all of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavajython.codeplex.com/releases/view/620122)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Jython-v1.0)

**Download Aspose.Slides for Java component**

- [Aspose.Slides for Java](http://www.aspose.com/community/files/72/java-components/aspose.slides-for-java/default.aspx)
### **Installing**
- Place downloaded Aspose.Slides for Java jar file into "lib" directory.
- Replace "your-lib" with the downloaded jar filename in _*init*_.py file.
### **Using**
You can create HelloWorld document using following example code:

{{< highlight java >}}

 from aspose-slides import Settings

from com.aspose.slides import Presentation

from com.aspose.slides import ShapeType

from com.aspose.slides import FillType

from com.aspose.slides import SaveFormat

from java.awt import Color

class HelloWorld:

    def __init__(self):



        dataDir = Settings.dataDir + 'IntroductionToPresentation/HelloWorld'



        # Instantiate Presentation

        pres = Presentation()

        # Get the first slide

        slide = pres.getSlides().get_Item(0)

        # Add an AutoShape of Rectangle type

        shape_type = ShapeType

        ashp = slide.getShapes().addAutoShape(shape_type.Rectangle, 150, 75, 150, 50)

        # Add ITextFrame to the Rectangle

        ashp.addTextFrame("Hello World")

        # Change the text color to Black (which is White by default)

        fill_type = FillType

        color = Color

        ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getFillFormat().setFillType(fill_type.Solid)

        ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getFillFormat().getSolidFillColor().setColor(color.BLACK)

        # Change the line color of the rectangle to White

        ashp.getShapeStyle().getLineColor().setColor(color.WHITE)

        # Remove any fill formatting in the shape

        ashp.getFillFormat().setFillType (fill_type.NoFill)

        # Save the presentation to disk

        save_format = SaveFormat

        pres.save(dataDir + "HelloWorld.pptx", save_format.Pptx)

        print "Document has been saved, please check the output file."

if __name__ == '__main__':        

    HelloWorld()

{{< /highlight >}}
## **Support, Extend and Contribute**
### **Support**
From the very first days of Aspose, we knew that just giving our customers good products would not be enough. We also needed to deliver good service. We are developers ourselves and understand how frustrating it is when a technical issue or a quirk in the software stops you from doing what you need to do. We're here to solve problems, not create them.

This is why we offer free support. Anyone who uses our product, whether they have bought them or are using an evaluation, deserves our full attention and respect.

You can log any issues or suggestions related to Aspose.Slides Java for Jython using any of the following platforms:

- [CodePlex](https://asposewordsjavajython.codeplex.com/workitem/list/basic)
- [Github](https://github.com/asposewords/Aspose_Words_Java/issues)
### **Extend and Contribute**
Aspose.Slides Java for Jython is open source and its source code is available on the major social coding websites listed below. Developers are encouraged to download the source code and contribute by suggesting or adding new feature or improving the existing ones, so that others could also benefit from it.
### **Source Code**
You can get the latest source code from one of the following locations

- [CodePlex](https://asposeslidesjavajython.codeplex.com/SourceControl/latest)
- [Github](https://github.com/aspose-slides/Aspose_Words_Java)
