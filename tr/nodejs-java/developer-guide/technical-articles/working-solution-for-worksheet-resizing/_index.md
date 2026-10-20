---
title: Çalışma Sayfası Yeniden Boyutlandırma için Çözüm
type: docs
weight: 20
url: /tr/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme görüntüsü
- görüntü yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmanın iki yolu—çerçeveyi ya da sayfayı ölçeklendirin—PPT ve PPTX formatlarında."
---
{{% alert color="info" title="Note" %}}

Aspose bileşenleri kullanılarak bir PowerPoint sunumuna OLE nesneleri olarak gömülen Excel çalışma sayfaları, ilk etkinleştirmelerinden sonra beklenmedik bir şekilde yeniden boyutlandırılabilir. Bu davranış, OLE nesnesi etkinleştirilmeden önce ve sonra arasında belirgin bir görsel fark yaratır. Bu makale sorunu açıklar ve iki çözüm yolunu tanımlar.

{{% /alert %}}

## **Arka Plan**

[OLE'yi Yönet](/slides/tr/nodejs-java/manage-ole/) makalesinde, Aspose.Slides for Node.js via Java kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [nesne önizleme sorunu](/slides/tr/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) ele almak için, OLE nesne çerçevesine seçilen çalışma sayfası alanının bir resmini atadık. Çıktı sunumunda, çalışma sayfası resmini gösteren OLE nesne çerçevesine çift‑tıkladığınızda Excel çalışma kitabı etkinleştirilir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve etkinleştirilen Excel çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğundan, ilk etkinleştirmede orijinal boyutunu korumaya çalışır. Öte yandan OLE nesne çerçevesinin de kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme sürecinin bir parçası olarak doğru oranları koruması için boyutu müzakere eder. Yeniden boyutlandırma, Excel penceresi boyutu ile OLE nesne çerçevesinin boyut ve konumu arasındaki farklara dayalı olarak gerçekleşir.

## **Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm vardır.

- PowerPoint sunumundaki OLE çerçevesini seçilen satır ve sütunların toplam yüksekliği ve genişliğine göre ölçeklendirin.
- OLE çerçevesi boyutunu sabit tutun ve seçilen satır ve sütunları ona sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendirin**

Bu yaklaşım, gömülü Excel çalışma sayfasındaki seçilen satır ve sütunların toplam yüksekliği ve genişliğiyle eşleşecek şekilde OLE çerçeve boyutunu ayarlar.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır‑tabanlı indeksler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) görüntülenen aralığı tanımlar. Önizleme 96 DPI'da oluşturulur ve piksel boyutları inç başına 72 puan kullanılarak puana dönüştürülür. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) değiştirilmiş çalışma kitabını bu boyutlarda bir çerçeveye gömer. Önizleme, kaydedilen sunumdaki "EMBEDDED OLE OBJECT" yer tutucusunu değiştirmek için [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) aracılığıyla atanır.

`aspose.cells`, `aspose.slides.via.java` ve `java` paketlerini kurun ve `sample.xlsx` dosyasını çalışma dizinine yerleştirin. Her yaklaşım için önce hazırlık betiğini, ardından aynı dizinde ayrı bir Node.js sürecinde gömme betiğini çalıştırın. İki Aspose paketi Java köprüsünü ayrı ayrı başlatır.

Bu hazırlık betiğini `prepare-frame-scaled.js` olarak kaydedin ve `node prepare-frame-scaled.js` ile çalıştırın. `frame-scaled.xlsx` ve `frame-scaled.png` dosyalarını yazar.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// Tüm eşzamanlı işler tamamlandı; Java köprü sürecini durdurun.
process.exit(0);
```

Bu gömme betiğini `embed-frame-scaled.js` olarak kaydedin ve `node embed-frame-scaled.js` ile çalıştırın. Bu dosyaları okur ve `frame-scaled.pptx` oluşturur.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// Tüm eşzamanlı işler tamamlandı; Java köprü sürecini durdurun.
process.exit(0);
```

Önizleme yardımcı işlevi, [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) ile seçilen aralığı ayarlar ve kenar boşluklarını, üst bilgi ve alt bilgileri kaldırır. [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) etkinleştirildiğinde, [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) aralığı PNG resmi olarak oluşturur. Yardımcı, PNG görüntüsünü sunumda kullanılmak üzere bir dosyaya kaydeder.

### **Hücre Aralığı Boyutunu Ölçeklendirin**

Bu yaklaşım, seçilen satırların yüksekliğini ve seçilen sütunların genişliğini özel bir OLE çerçeve boyutuna uyduracak şekilde ölçeklendirir.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır‑tabanlı indeksler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) görüntülenen aralığı tanımlar ve yardımcı, bu aralığı 400 puan genişliğinde ve 100 puan yüksekliğinde bir çerçeveye sığacak şekilde ölçeklendirir. Değiştirilmiş çalışma kitabı bir dosyaya kaydedildikten sonra, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) belirtilen boyutta çerçeveye gömülür. 96 DPI'da oluşturulan bir önizleme, [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) aracılığıyla atanır; böylece kaydedilen sunum, varsayılan yer tutucu yerine seçilen hücreleri gösterir.

Bu hazırlık betiğini `prepare-cells-scaled.js` olarak kaydedin ve `node prepare-cells-scaled.js` ile çalıştırın. `cells-scaled.xlsx` ve `cells-scaled.png` dosyalarını yazar.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// Tüm eşzamanlı işler tamamlandı; Java köprü sürecini durdurun.
process.exit(cellsPrepared ? 0 : 1);
```

Bu gömme betiğini `embed-cells-scaled.js` olarak kaydedin ve `node embed-cells-scaled.js` ile çalıştırın. Bu dosyaları okur ve `cells-scaled.pptx` oluşturur.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// Tüm eşzamanlı işler tamamlandı; Java köprü sürecini durdurun.
process.exit(0);
```

Ölçekleme yardımcı işlevi, seçilen aralık için ayrı genişlik ve yükseklik oranları hesaplar; bu sayede sütunların göreceli genişlikleri ve satırların göreceli yükseklikleri korunur. Hesaplanan boyutlar, [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) ve [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch) ile uygulanmadan önce puandan inçe dönüştürülür. Seçilen aralığın sıfır olmayan bir genişliği ve yüksekliği olmalıdır.

Bu önizleme yardımcı işlevi, [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) kullanarak yeniden boyutlandırılmış aralığı oluşturur. [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) bu aralığı sınırlamak, kenar boşluklarını, üst bilgi ve alt bilgileri kaldırmak ve PNG görüntüsünü bir dosyaya kaydetmek için kullanılır.

## **Sonuç**

{{% alert color="info" title="Note" %}}

Çalışma sayfası yeniden boyutlandırma sorununu gidermek için iki yaklaşım vardır. Gereksinimlerinize ve kullanım senaryonuza en uygun yaklaşımı seçin. Her iki yaklaşım da aynı şekilde çalışır; sunumlar bir şablondan ya da sıfırdan oluşturulmuş olsun fark etmez. Ayrıca bu çözümde OLE nesne çerçevesinin boyutu için bir sınırlama yoktur.

{{% /alert %}}

## **SSS**

**Bir PowerPoint sunumunda gömülü bir Excel çalışma sayfası ilk etkinleştirmede neden boyut değiştiriyor?**

Excel, etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışırken, PowerPoint'teki OLE nesne çerçevesinin kendi boyutları vardır. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder; bu da yeniden boyutlandırmaya yol açar.

**Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?**

Evet. OLE çerçevesini Excel hücre aralığı boyutuna göre ölçeklendirerek veya hücre aralığını istediğiniz OLE çerçeve boyutuna uydurarak istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Hangi ölçekleme yöntemi kullanılmalı, OLE çerçeve ölçeklendirme mi yoksa hücre aralığı ölçeklendirme mi?**

Orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız **OLE çerçeve ölçeklendirmesini** seçin. Sunumunuzda OLE çerçevesi için sabit bir boyut istiyorsanız **hücre aralığı ölçeklendirmesini** seçin.

**Bu çözümler şablona dayalı bir sunumda da çalışır mı?**

Evet. Her iki çözüm de şablonlardan oluşturulan ve sıfırdan oluşturulan sunumlarda çalışır.

**Bu yöntemlerle OLE çerçevesinin boyutu için bir sınırlama var mı?**

Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz boyutta yapabilirsiniz.

**PowerPoint'te "EMBEDDED OLE OBJECT" yer tutucu metninden kaçınmanın bir yolu var mı?**

Evet. Hedef Excel hücre aralığının bir anlık görüntüsünü alıp OLE çerçevesinin yer tutucu resmi olarak ayarlayarak varsayılan yer tutucu yerine özel bir önizleme resmi gösterebilirsiniz.

## **İlgili Makaleler**

[Excel Grafiği Oluşturma ve Sunumda OLE Nesnesi Olarak Gömme](/slides/tr/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelleme](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)