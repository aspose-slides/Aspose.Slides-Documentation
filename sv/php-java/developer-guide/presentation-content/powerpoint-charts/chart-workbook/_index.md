---
title: Hantera diagramarböcker i presentationer med PHP
linktitle: Diagramarbok
type: docs
weight: 70
url: /sv/php-java/chart-workbook/
keywords:
- diagramarbok
- diagramdata
- arbetsbokscell
- datamärkning
- kalkylblad
- datakälla
- extern arbetsbok
- extern data
- diagramcache
- arbetsboksåterställning
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Upptäck Aspose.Slides för PHP via Java: hantera enkelt diagramarböcker i PowerPoint- och OpenDocument-format för att förenkla dina presentationsdata."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboks‑celler som diagramdatamärkning, får åtkomst till kalkylbladssamlingar och specificerar datakälltyp för diagramvärden. Den täcker också arbete med externa arbetsböcker som diagramdatakällor. Exemplen demonstrerar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkat till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides tillhandahåller metoderna [readWorkbookStream](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/#readWorkbookStream) och [writeWorkbookStream](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/#writeWorkbookStream) som låter dig läsa och skriva diagramdataarbetsböcker (innehållande diagramdata redigerad med Aspose.Cells). **Observera** att diagramdata måste vara organiserade på samma sätt eller ha en struktur som liknar källan.

Denna PHP‑kod demonstrerar ett exempel på en operation:
```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ställ in en arbetsboks‑cell som diagramdatamärkning**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till ett bubbeldiagram med några data.
4. Få åtkomst till diagramserierna.
5. Ange arbetsbokscellen som en datamärkning.
6. Spara presentationen.

Denna PHP‑kod visar hur du ställer in en arbetsbokscell som en diagramdatamärkning:
```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Instansierar en presentationsklass som representerar en presentationsfil
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hantera kalkylblad**

Denna PHP‑kod demonstrerar en operation där metoden [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/#getWorksheets) används för att komma åt en kalkylblads‑samling:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Specificera datakälltyp**

Denna PHP‑kod visar hur du specificerar en typ för en datakälla:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Upptäck ej stödda inbäddade arbetsboksformat**

Aspose.Slides stöder inte Excel‑binärarbetsboksformatet (.xlsb) som kan bäddas in i vissa diagram. Du kan använda metoden `getEmbeddedWorkbookType` på [ChartData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/workbooktype/) för att upptäcka ej stödda format och hoppa över dessa diagram.
```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # Inbäddad arbetsbok är i .xlsb-format, vilket inte stöds.
      continue;
    }

    # Läs eller ändra diagramarbokdata här.
  }
} finally {
  $presentation->dispose();
}
```

## **Extern arbetsbok**

Aspose.Slides stödjer externa arbetsböcker som datakälla för diagram.

### **Skapa en extern arbetsbok**

Genom att använda metoderna **`readWorkbookStream`** och **`setExternalWorkbook`** kan du antingen skapa en extern arbetsbok från grunden eller göra en intern arbetsbok extern.

Denna PHP‑kod demonstrerar processen för att skapa en extern arbetsbok:
```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tilldela en extern arbetsbok**

Genom att använda metoden **`setExternalWorkbook`** kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera sökvägen till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du fortfarande använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok tillhandahålls konverteras den automatiskt till en fullständig sökväg.

Denna PHP‑kod visar hur du tilldelar en extern arbetsbok:
```php
  # Skapar en instans av Presentation-klassen
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

`ChartData`‑parametern (under metoden `setExternalWorkbook`) används för att ange om en Excel‑arbetsbok ska laddas eller inte.

* När `ChartData`‑värdet är satt till `false` uppdateras endast arbetsbokens sökväg – diagramdata laddas inte och uppdateras inte från målarbetsboken. Du kan vilja använda denna inställning när målarbetsboken saknas eller är otillgänglig.  
* När `ChartData`‑värdet är satt till `true` uppdateras diagramdata från målarbetsboken.

```php
  # Skapar en instans av Presentation-klassen
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Hämta den externa datakällans arbetsbokssökväg för ett diagram**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
2. Hämta en bilds referens via dess index.
3. Skapa ett objekt för diagramformen.
4. Skapa ett objekt för källtypen (`ChartDataSourceType`) som representerar diagrammets datakälla.
5. Specificera det relevanta villkoret baserat på att källtypen är densamma som den externa arbetsbokens datakälltyp.

Denna PHP‑kod demonstrerar operationen:
```php
  # Skapar en instans av Presentation-klassen
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Sparar presentationen
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Redigera diagramdata**

Du kan redigera data i externa arbetsböcker på samma sätt som du ändrar innehållet i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

Denna PHP‑kod är en implementering av den beskrivna processen:
```php
  # Skapar en instans av Presentation-klassen
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Återskapa en arbetsbok från diagramcachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig kan Aspose.Slides rekonstruera diagramarbetsboken från data som cachats i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/), konfigurera den med [SpreadsheetOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/spreadsheetoptions/), och anropa [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/sv/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) med `true` innan presentationen öppnas.

Följande PHP‑exempel öppnar en presentation vars diagram refererar till en otillgänglig extern arbetsbok och får åtkomst till den återhämtade data via [Chart::getChartData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/#getChartData) och [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/#getChartDataWorkbook):
```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Läs eller ändra den återställda arbetsboksdata här.
} finally {
    $presentation->dispose();
}
```

Om den externa arbetsboken är otillgänglig och återhämtning är inaktiverad kastar Aspose.Slides ett undantag. Aktivera återhämtning endast när det är acceptabelt att använda den cachade diagramdatan som en reserv, eftersom cachen kanske inte innehåller ändringar gjorda i den externa arbetsboken efter att presentationen senast uppdaterades.

## **Vanliga frågor**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller inbäddad arbetsbok?**  
Ja. Ett diagram har en [datakälltyp](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/getdatasourcetype/) och en [sökväg till en extern arbetsbok](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/getexternalworkbookpath/); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**  
Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Detta är praktiskt för projektportabilitet; var dock medveten om att presentationen lagrar den absoluta sökvägen i PPTX‑filen.

**Kan jag använda arbetsböcker som finns på nätverksresurser/delade mappar?**  
Ja, sådana arbetsböcker kan användas som en extern datakälla. Att redigera fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte – de kan endast användas som en källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**  
Nej. Presentationen lagrar en [länk till den externa filen](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/getexternalworkbookpath/) och använder den för att läsa data. Den externa filen ändras inte när presentationen sparas.

**Vad bör jag göra om den externa filen är lösenordsskyddad?**  
Aspose.Slides accepterar inte ett lösenord vid länkar. Ett vanligt tillvägagångssätt är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](/cells/php-java/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**  
Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av den filen att återspeglas i varje diagram nästa gång data laddas.