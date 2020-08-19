---
title: Opening a Presentation in Ruby
type: docs
weight: 90
url: /java/opening-a-presentation-in-ruby/
---

## **Aspose.Slides - Opening a Presentation**
In order to open presentation using **Aspose.Slides Java for Ruby**, you can use below code.

**Ruby Code**

```

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



\# Instantiate a Presentation object that represents a PPTX file

pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + "demo.pptx")

\# Printing the total number of slides present in the presentation

puts pres.getSlides().size()

```
