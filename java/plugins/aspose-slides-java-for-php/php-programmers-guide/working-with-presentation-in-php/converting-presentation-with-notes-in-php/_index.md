---
title: Converting Presentation with Notes in PHP
type: docs
weight: 70
url: /java/converting-presentation-with-notes-in-php/
---

## **Aspose.Slides - Converting Presentation to TIFF Notes**
To convert Presentation to TIFF Notes using **Aspose.Slides Java for PHP**, simply invoke **convert_to_tiff_notes** method of **ConvertingToNotes** module. Here you can see example code.

**PHPCode**

```

 public static function convert_to_tiff_notes($dataDir=null)

{

\# Instantiate a Presentation object that represents a PPTX file

$pres = new Presentation($dataDir . "Aspose.pptx");

\# Saving the presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "Notes.tiff", $save_format->TiffNotes);

print "Document has been converted, please check the output file.";

}

```
## **Aspose.Slides - Converting Presentation to PDF Notes**
To convert Presentation to PDF Notes using **Aspose.Slides Java for PHP**, simply invoke **convert_to_pdf_notes** method of **ConvertingToNotes** module. Here you can see example code.

**PHPCode**

```

 public static function convert_to_pdf_notes($dataDir=null)

{

\# Instantiate a Presentation object that represents a PPTX file

$pres = new Presentation($dataDir . "Aspose.pptx");

\# Saving the presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "Notes.pdf", $save_format->pdf);

print "Document has been converted, please check the output file.";

}

```
## **Download Running Code**
Download **Converting Presentation with Notes (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithPresentation/ConvertingToNotes.php)
