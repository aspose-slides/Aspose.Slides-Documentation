---
title: Converting Presentation to HTML in PHP
type: docs
weight: 30
url: /java/converting-presentation-to-html-in-php/
---

## **Aspose.Slides - Converting Presentation to HTML**
To convert presentation to HTML using **Aspose.Slides Java for PHP**, simply invoke **convert_to_html method** of **ConvertingToHtml** module. Here you can see example code.

**PHPCode**

```

 public static function convert_to_html($dataDir=null)

{

\# Instantiate a Presentation object that represents a PPTX file

$pres = new Presentation($dataDir . "Aspose.pptx");

$html_opt = new HtmlOptions();

$html_formatter = new HtmlFormatter();

$html_opt->setHtmlFormatter($html_formatter->createDocumentFormatter("",false));

\# Saving the presentation to HTML format

$save_format = new SaveFormat();

$pres->save($dataDir . "Aspose.html", $save_format->Html, $html_opt);

print "Document has been converted, please check the output file.";

}

```
## **Download Running Code**
Download **Converting Presentation to HTML (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithPresentation/ConvertingToHtml.php)
