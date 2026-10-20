---
title: Vytvořte grafy v Excelu a vložte je do prezentací jako OLE objekty
type: docs
weight: 30
url: /cs/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Graf Excel
- vložit graf
- OLE objekt
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvořte graf v Excelu pomocí Aspose.Cells pro Java a vložte sešit do prezentace PowerPoint s Aspose.Slides, včetně náhledového obrázku grafu."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit sloupcový graf v Excelu pomocí Aspose.Cells for Java a vložit sešit do prezentace PowerPoint pomocí Aspose.Slides for Java. Vložený sešit obsahuje jak zdrojová data, tak graf. Samostatná náhledová PNG zobrazí graf na snímku před aktivací OLE objektu.

Výsledkem je vložený objekt Excel, ne původní graf PowerPoint. Úprava sešitu přes OLE vyžaduje desktopovou aplikaci podporující aktivaci OLE a kompatibilní instalaci Excelu.

## **Požadavky**

Přidejte Aspose.Cells for Java a Aspose.Slides for Java do závislostí projektu. Spusťte příklad uvnitř metody Java. K vygenerování prezentace s těmito knihovnami není nutný Microsoft Office.

Nejsou vyžadovány vstupní soubory: příklad vytvoří data a graf v paměti a poté zapíše `OutputChart.pptx` do aktuálního pracovního adresáře. Použijte licence pro oba produkty, pokud neběžíte v režimu hodnocení.

## **Jak funguje vkládání**

1. Vytvořte sešit s listem dat a listem grafu.  
1. Nastavte list grafu jako aktivní, aby se sešit otevřel na grafu.  
1. Nastavte OLE zobrazovací oblast sešitu a vykreslete graf do PNG.  
1. Uložte sešit jako XLSX v paměti a vložte tyto bajty do snímku.  
1. Přiřaďte PNG jako náhled OLE objektu a uložte prezentaci jako PPTX.

Oblast zobrazení sešitu a rámec na snímku mají různé role. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) používá nulové indexy počátečního a koncového řádku a sloupce. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) naproti tomu přijímá horní řádek, levý sloupec, dolní řádek a pravý sloupec. Příklad používá řádkový index 55 a sloupcový index 25 jako pravý dolní roh; tyto hodnoty jsou volby rozložení, ne počet řádků nebo sloupců dat.

Rámec snímku používá body. Příklad jej umístí do snímku a vystředí, přičemž zachová poměr stran PNG, místo aby náhled roztahoval po celé ploše snímku.

## **Vytvoření a vložení grafu**

Následující kompletní příklad naplní `DataSheet` čtyřmi řádky a pěti sloupci hodnot. Každý řádek se stane sérií grafu. `ChartSheet` je vybrán jako aktivní list před uložením sešitu.

Sešit je explicitně uložen jako XLSX, což odpovídá příponě `xlsx` předané do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/). PNG je načten přímo z bajtů bez mezikroku bitmapové konverze. Přiřazením přes [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) se nahradí výchozí OLE zástupce.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // Vykreslete náhled grafu a odděleně serializujte editovatelný sešit.
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // Přizpůsobte náhled rozměrům snímku při zachování poměru stran.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```

## **Očekávaný výsledek**

`OutputChart.pptx` obsahuje jeden snímek s vloženým sešitem Excel a náhledem grafu. Sešit obsahuje původní data a sloupcový graf se čtyřmi sériemi. Náhled je vystředěn na snímku a zachovává své proporce.

![Excel sloupcový graf zobrazený jako náhled vloženého sešitu](excel-chart-ole-preview.png)

V kompatibilním desktopovém prostředí PowerPoint s dostupným Excelem dvojkliknutím na objekt aktivujete a upravíte vložený sešit. Aktivace a úpravy závisí na podpoře OLE hostitelské aplikace a na nastavení zabezpečení.

## **Často kladené otázky**

**Proč je potřeba náhledový obrázek?**

Vložený sešit a jeho náhled na snímku jsou oddělený obsah. Poskytněte obrázek grafu, aby snímek zobrazoval graf místo výchozího zástupce „EMBEDDED OLE OBJECT“. Viz [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/java/object-preview-issue-when-adding-oleobjectframe/).

**Aktualizuje se náhled automaticky při změně sešitu v kódu?**

Náhled považujte za snímek. Při programovém aktualizování dat sešitu vygenerujte znovu obrázek grafu a nahraďte náhled i data vloženého sešitu.

**Můžu použít XLS místo XLSX?**

Ano. Uložte sešit ve formátu XLS a použijte `xls` jako příponu vložených dat. Přípona musí odpovídat skutečnému formátu sešitu; změna pouhého názvu přípony neprovádí konverzi dat.

**Proč se objekt může po aktivaci změnit velikost?**

Hostitelská aplikace může aktualizovat vzhled OLE objektu při aktivaci sešitu. Oblast OLE zobrazení sešitu a rozměry rámce snímku mají oba vliv. Viz [Řešení pro změnu velikosti grafu v PPTX](/slides/cs/java/working-solution-for-chart-resizing-in-pptx/).

## **Související sekce**

- [Řešení pro změnu velikosti grafu v PPTX](/slides/cs/java/working-solution-for-chart-resizing-in-pptx/)
- [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/java/object-preview-issue-when-adding-oleobjectframe/)
- [Automatická aktualizace OLE objektů pomocí PowerPoint Add-In](/slides/cs/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)