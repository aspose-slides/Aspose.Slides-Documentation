---
title: Saving a Presentation in Ruby
type: docs
weight: 100
url: /java/saving-a-presentation-in-ruby/
---

## **Aspose.Slides - Saving a Presentation**
In order to save presentation using **Aspose.Slides Java for Ruby**, you can use following code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'

\# Saving the presentation

save_format = Rjb::import('com.aspose.slides.SaveFormat')

pres.save(data_dir + "output.pptx", save_format.Pptx)

```
