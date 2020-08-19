---
title: Converting Presentation to TIFF in PHP
type: docs
weight: 50
url: /java/converting-presentation-to-tiff-in-php/
---

## **Aspose.Slides - Converting Presentation to TIFF with default size**
To convert presentation to TIFF with default size using **Aspose.Slides Java for PHP**, simply invoke **convert_with_default_size** method of **ConvertingToTiff** module. Here you can see example code.

**PHPCode**

```

 public static function convert_with_default_size($dataDir=null)

{

\# Instantiate a Presentation object that represents a PPTX file

$pres = new Presentation($dataDir . "Aspose.pptx");

\# Saving the PPTX presentation to Tiff format

$save_format = new SaveFormat();

$pres->save($dataDir . "Aspose.tiff", $save_format->Tiff);

print "Document has been converted, please check the output file.";

}

```
## **Aspose.Slides - Converting Presentation to TIFF with custom size**
To convert presentation to TIFF with custom size using **Aspose.Slides Java for PHP**, simply invoke **convert_with_custom_size** method of **ConvertingToTiff** module. Here you can see example code.

**PHPCode**

```

 public static function convert_with_custom_size($dataDir=null)

{

\# Instantiate a Presentation object that represents a PPTX file

$pres = new Presentation($dataDir . "Aspose.pptx");

\# Instantiate the TiffOptions class

$opts = new TiffOptions();

\# Setting compression type

$tiff_compression_types = new TiffCompressionTypes;

$opts->setCompressionType ($tiff_compression_types->Default);

\# Compression Types

#Default - Specifies the default compression scheme (LZW).

#None - Specifies no compression.

#CCITT3

#CCITT4

#LZW

#RLE

\# Depth - depends on the compression type and cannot be set manually.

\# Resolution unit - is always equal to "2" (dots per inch)

#Setting image DPI

$opts->setDpiX(200);

$opts->setDpiY(100);

\# Set Image Size

$opts->setImageSize(new Dimension(1728, 1078));

\# Save the presentation to TIFF with specified image size

$save_format = new SaveFormat();

$pres->save($dataDir . "Aspose-Custom-Size.tiff", $save_format->Tiff,$opts);

print "Document has been converted, please check the output file.";

}

```
## **Download Running Code**
Download **Converting Presentation to TIFF (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithPresentation/ConvertingToTiff.php)
