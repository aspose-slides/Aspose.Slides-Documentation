---
title: Using Default Fonts for Rendering Presentation in PHP
type: docs
weight: 90
url: /java/using-default-fonts-for-rendering-presentation-in-php/
---

## **Aspose.Slides - Using Default Fonts for Rendering Presentation**
To Use Default Fonts for Rendering Presentation using **Aspose.Slides Java for PHP**, call **set_default_font_for_rendering** method of **TextFont** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

     public static function set_default_font_for_rendering($dataDir=null){

        # Use load options to define the default regualr and asian fonts

        $loadFormat = new LoadFormat();

        $lo = new LoadOptions($loadFormat->Auto);

        $lo->setDefaultRegularFont("Wingdings");

        $lo->setDefaultAsianFont("Wingdings");

        # Create an instance of Presentation class

        $pres = new Presentation($dataDir . 'input.pptx');

        # Generate PDF

        $save_format = new SaveFormat();

        $pres->save($dataDir . "output.pdf", $save_format->Pdf);

        print "Done with font family for text, please check the output file.".PHP_EOL;

    }

{{< /highlight >}}
## **Download Running Code**
Download **Using Default Fonts for Rendering Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithText/TextFont.php)
