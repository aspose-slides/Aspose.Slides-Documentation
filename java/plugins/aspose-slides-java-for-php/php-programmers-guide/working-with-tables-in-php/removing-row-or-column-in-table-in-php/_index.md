---
title: Removing Row Or Column in Table in PHP
type: docs
weight: 40
url: /java/removing-row-or-column-in-table-in-php/
---

## **Aspose.Slides - Removing Row Or Column in Table**
To Create a Table from Scratch in Slide using **Aspose.Slides Java for PHP**, simply invoke **RemoveRowColumn** Class. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 $pres = new Presentation();

\# Get the first slide

$slide = $pres->getSlides()->get_Item(0);

$col_width = [100, 50, 30];

$row_height = [30, 50, 30];

$table = $slide->getShapes()->addTable(100, 100, $col_width, $row_height);

$table->getRows()->removeAt(1, false);

$table->getColumns()->removeAt(1, false);

\# Write the presentation as a PPTX file

$save_format = new SaveFormat();

$pres->save($dataDir . "RemoveRowColumn.pptx", $save_format->Pptx);

print "Removed Row & Column from table, please check the output file.".PHP_EOL;

{{< /highlight >}}
## **Download Running Code**
Download **Creating a Table from Scratch in Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithTables/RemoveRowColumn.php)
