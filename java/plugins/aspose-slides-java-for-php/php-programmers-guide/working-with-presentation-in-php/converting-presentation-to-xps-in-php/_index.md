---
title: Converting Presentation to XPS in PHP
type: docs
weight: 60
url: /java/converting-presentation-to-xps-in-php/
---

## **Aspose.Slides - Converting Presentation to XPS with default size**
To convert presentation to XPS with default size using **Aspose.Slides Java for Ruby**, simply invoke **convert_with_default_size** method of **ConvertingToXps** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 public static function convert_with_default_size($dataDir=null)

{

\# Instantiate a Presentation object that represents a PPTX file

$pres = new Presentation($dataDir . "Aspose.pptx");

\# Saving the presentation to XPS format

$save_format = new SaveFormat();

$pres->save($dataDir . "Aspose.xps", $save_format->Xps);

print "Document has been converted, please check the output file.";

}

{{< /highlight >}}
## **Aspose.Slides - Converting Presentation to XPS with custom size**
To convert presentation to XPS with custom size using **Aspose.Slides Java for PHP**, simply invoke **convert_with_custom_size** method of **ConvertingToXps** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 public static function convert_with_custom_size($dataDir=null)

{

\# Instantiate a Presentation object that represents a PPTX file

$pres = new Presentation($dataDir . "Aspose.pptx");

\# Instantiate the TiffOptions class

$opts = new XpsOptions();

\# Save MetaFiles as PNG

$opts->SaveMetafilesAsPng = true;

\# Save the presentation to TIFF with specified image size

$save_format = new SaveFormat();

$pres->save($dataDir . "Aspose-Custom-Size.xps", $save_format->Xps, $opts);

print "Document has been converted, please check the output file.";

}

{{< /highlight >}}
## **Download Running Code**
Download **Converting Presentation to XPS (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithPresentation/ConvertingToXps.php)
