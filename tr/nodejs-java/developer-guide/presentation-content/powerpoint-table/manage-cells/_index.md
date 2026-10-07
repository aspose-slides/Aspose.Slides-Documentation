---
title: JavaScript Kullanarak Sunumlarda Tablo Hücrelerini Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/nodejs-java/manage-cells/
keywords:
- tablo hücresi
- hücre birleştirme
- kenarlık kaldırma
- hücre bölme
- hücrede resim
- arka plan rengi
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ile PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri tanımlayın, kenarlıkları kaldırın, hücreleri bölün ve Aspose.Slides for Node.js ile arka plan renkleri ve resimler ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bu hücreleri değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücreleri birleştirdikten veya ayırdıktan sonra hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl bir resim ekleyeceğinizi açıklar. Örnekler, bir sunum nasıl oluşturulur veya açılır, bir slayttan tablo nasıl alınır, hücre özellikleri aracılığıyla hücre biçimlendirmesi nasıl güncellenir ve değiştirilen sunum nasıl PPTX dosyası olarak kaydedilir, gösterir.

Aspose.Slides, tablo hücrelerine `(sütun, satır)` sırasıyla sıfır tabanlı indeksler kullanarak erişir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Slayt ve şeklin var olduğu ve şeklin bir tablo olduğu varsayılır. Daha sonra tüm satır ve sütunlar üzerinden döngü yapılır ve birleştirilmiş bölgelerdeki hücreleri tanımlamak için [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) kullanılır. Her eşleşme için hücre koordinatları `satır;sütun` sırayla, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), ve bölgenin başlangıç koordinatları, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) ve [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) yazdırılır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Tablo Hücre Kenarlıklarını Kaldırma**

Bir [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) oluşturun ve ilk slaydına [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) ile bir tablo ekleyin. Sütun genişlikleri, satır yüksekliği ve tablo konumu puan cinsinden belirtilir. Örnek, dört hücre kenarlığının tümünü [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) olarak ayarlar ve böylece kenarlıklar görünmez hâle gelir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Hücrelerini Birleştirme**

Bir tablo hücreleri dikdörtgen aralığını tek bir hücreye birleştirmek için [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) kullanın. Aralığın sol‑üst ve sağ‑alt köşelerindeki hücreleri belirtin. Son argüman, birleştirmenin belirtilen aralığın dışındaki hücreleri içerip içermeyeceğini kontrol eder; `false` birleştirmenin bu aralık içinde kalmasını sağlar.

Örnek, 70 puan genişliğinde sütun ve satırlara sahip 4x4 bir tablo oluşturur ve ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Oluşan hücre iki sütun ve iki satır kapsar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için üst‑sol konumunu kullanın: bu örnekte `table.get_Item(1, 1)`. Birleştirilen aralıktaki diğer konumlar tablo ızgarasının bir parçası olarak kalır, bu yüzden aralığın dışındaki hücrelerin indeksleri değişmez.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Hücrelerini Bölme**

Önceki örnekte hücrelerin birleştirilmesi tablo ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu oluşturabilir ve sağındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint'in tablo ızgara modelini izler.

Bu örnek, 70 puan genişliğinde sütun ve satırlara sahip 4x4 bir tablo oluşturur ve `(1, 1)` hücresinde [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) metodunu çağırır. Hücrenin 70 puan genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için kullanılır.

Bu bölünmeden sonra iki yarı `table.get_Item(1, 1)` ve `table.get_Item(2, 1)` olarak erişilir. Tablo ızgarasında artık beş sütun bulunur: ilk başta 2 ve 3. sütunlarda olan hücreler sırasıyla 3 ve 4. sütunlara taşınır. Satır indeksleri değişmez. Bölünmeden sonra hücrelere erişirken bu güncellenmiş sütun indekslerini kullanın.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Birleştirilmiş Hücreleri Satır ya da Sütun Ölçeğine Göre Bölme**

Birleştirilmiş şablon hücrelerini veri doldurmak için hazırlarken, mevcut bir satır sınırına göre bölmek için [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) , veya bir sütun sınırına göre bölmek için [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) kullanın.

`index` argümanı, bölmenin üst kısmındaki satırları ya da sol kısmındaki sütunları sayar; bu değer birleştirilmiş bölgeye göredir:

- Satır bölmesi: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Sütun bölmesi: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Örnek, bir sunumun ilk slaydındaki ilk şeklin tablo olduğu ve `(1, 2)` ile `(1, 3)` hücrelerinin dikey olarak birleştirildiği varsayar. Alt konumdan başlayarak, başlangıç noktasını bulmak için [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) ve [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) kullanır ve her iki ölçeği de kontrol eder. `splitByRowSpan(1)` ardından ürün adları için 2. ve 3. satırları ayırır. Yatay iki sütun birleştirme için bunun yerine `splitByColSpan(1)` kullanın.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // Bölünme sonrası tablodan oluşan hücreleri alın.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Tablo ızgarası ve çevresindeki hücre indeksleri değişmeden kalır. Oluşan hücreleri koordinatlarıyla alın; burada ikisinin de ölçeği 1 ve [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) `false` döndürür. Daha büyük bölgeler bir bölünmeden sonra kısmen birleştirilmiş kalabilir.

Orijinal metin ve biçimlendirmesi üst (veya sol) hücrede kalır; yeni hücre boştur ancak dolgu, kenarlık ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Hücreleri bölünmeden sonra doldurun ve gerekli metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesini koruyan ayrı "Product A" ve "Product B" hücreleri içerir. Ayrıntılar için [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) sayfasına bakın.

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu örnek, 150 puan genişliğinde sütunlar ve 50 puan yüksekliğinde satırlara sahip bir tablo oluşturur. [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) ile katı bir dolgu seçer ve [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) tarafından döndürülen rengi, üçüncü sütun ve dördüncü satırdaki `(2, 3)` hücresi için kırmızı olarak ayarlar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Hücresi İçine Resim Ekleme**

Bu örneği çalıştırmadan önce giriş resmini çalışma dizinine koyun. Resim, [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) ile yüklenir ve sunumun resim koleksiyonuna [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) ile eklenir. Daha sonra resim, tablodaki ilk hücre olan `(0, 0)` hücresinin resim dolgusuna atanır.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) resmi hücreyi dolduracak şekilde gerer, bu da en boy oranının değişmesine neden olabilir. Sütun genişlikleri ve satır yükseklikleri puan cinsindendir. Yüklenen resim, sunuma eklendikten sonra bir `finally` bloğunda serbest bırakılır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stiller ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) kenarlıklarının ayrı özellikleri vardır; bu nedenle her bir tarafın kalınlığı ve stili farklı olabilir.

**Resmi hücrenin arka planı olarak bir resim ayarladıktan sonra sütun/satır boyutunu değiştirirsem ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Germe (stretch) ile resim yeni hücreye uyum sağlar; döşeme (tile) ile döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine hiperlink atayabilir miyim?**

[Hyperlinks](/slides/tr/nodejs-java/manage-hyperlinks/) hücrenin metin çerçevesi içinde metin (parça) düzeyinde veya tüm tablo/şekil düzeyinde ayarlanır. Uygulamada, bağlantıyı bir parçaya ya da hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (çalıştırmalar) ile bağımsız biçimlendirme—yazı tipi ailesi, stil, boyut ve renk—destekler.