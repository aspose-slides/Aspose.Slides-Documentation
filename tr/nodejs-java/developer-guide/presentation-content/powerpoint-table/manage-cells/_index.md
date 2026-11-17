---
title: Sunumlarda JavaScript Kullanarak Tablo Hücrelerini Yönetme
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
description: "PowerPoint tablo hücrelerini JavaScript'te yönetin: birleştirilmiş hücreleri tanımlayın, kenarlıkları kaldırın, hücreleri bölün ve Aspose.Slides for Node.js ile arka plan renklerini ve resimleri ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bunları değiştirmenizi sağlar. Bu makale birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücreleri birleştirdikten veya böldükten sonra hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresinin içine nasıl resim ekleyeceğinizi açıklar. Örnekler bir sunumu nasıl oluşturup açacağınızı, bir slayttan tablo almayı, hücre özellikleri aracılığıyla hücre biçimlendirmesini güncellemeyi ve değiştirilmiş sunumu PPTX dosyası olarak kaydetmeyi gösterir.

Aspose.Slides, tablo hücrelerine `(sütun, satır)` sırasıyla sıfır tabanlı dizinler kullanarak erişir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Slayt ve şeklin var olduğunu ve şeklin bir tablo olduğunu varsayar. Ardından tüm satır ve sütunlarda dolaşır ve birleştirilmiş bölgelerdeki hücreleri tanımlamak için [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) kullanır. Her eşleşme için hücre koordinatlarını `row;column` sırasında, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), ve bölgenin başlangıç koordinatlarını, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) ve [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) yazdırır.

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

## **Tablo Hücresi Kenarlıklarını Kaldırma**

Bir [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) oluşturun ve bir tabloyu ilk slaytına [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) ile ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu puan cinsinden belirtilir. Örnek, dört hücre kenarlığının tamamını [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) olarak ayarlar ve böylece görünmez hâle getirir.

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

## **Köşegen Hücre Kenarlıkları Ekleme**

Üst‑sol köşeden alt‑sağ köşeye bir çizgi çizmek için [getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/) kullanın, alt‑sol köşeden üst‑sağ köşeye bir çizgi çizmek için [getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/) kullanın. Bir köşegen köşe başlığını işaretleyebilir; iki köşegen birlikte bir X oluşturup hücreyi geçerli değildir şeklinde işaretleyebilir.

Her köşegen bir [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) dir. Onun [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) içinde, [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) kullanarak [FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) seçilir ve [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) aracılığıyla bir renk seçilir. Çizginin genişliği, [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) ile puan cinsinden ayarlanır.

Örnek bir satırda üç hücre oluşturur: kırmızı aşağı doğru köşegen, mavi yukarı doğru köşegen ve her iki köşegen. Üst, alt, sol ve sağ hücre kenarlıkları değişmeden bırakılır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Köşegen bir biçimlendirme özelliğidir, hücre bölünmesi değildir. Her hücre, [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/) aracılığıyla erişilen tek bir metin çerçevesini korur; köşegenin her iki tarafındaki bölgeler bağımsız olarak düzenlenemez.

The saved table, rendered in Microsoft PowerPoint:

![Üst‑soldan alt‑sağa kırmızı bir köşegen, alt‑soldan üst‑sağa mavi bir köşegen ve her iki köşegenin bir X oluşturduğu üç tablo hücresi.](diagonal-cell-borders.png)

*Soldan sağa: aşağı doğru köşegen (kırmızı, 3 pt), yukarı doğru köşegen (mavi, 5 pt) ve her iki köşegen.*

## **Tablo Hücrelerini Birleştirme**

[mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) kullanarak bir tablo hücresi dikdörtgen aralığını tek bir hücreye birleştirebilirsiniz. Aralığın üst‑sol ve alt‑sağ köşelerindeki hücreleri belirtin. Son argüman, birleştirmenin belirtilen aralığın dışındaki hücreleri kapsayıp kapsamayacağını kontrol eder; `false` birleştirmenin bu aralık içinde kalmasını sağlar.

Örnek, 70 puan genişliğinde sütun ve satırlara sahip 4×4 bir tablo oluşturur, ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Oluşan hücre iki sütun ve iki satırı kapsar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için üst‑sol konumunu kullanın: bu örnekte `table.get_Item(1, 1)`. Birleştirme aralığındaki diğer konumlar tablo ızgarasının bir parçası olmaya devam eder, bu yüzden aralık dışındaki hücrelerin dizinleri değişmez.

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

Önceki örnekte hücreleri birleştirmek tablo ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu ekleyebilir ve sağındaki hücrelerin sütun dizinlerini değiştirebilir. Aspose.Slides, PowerPoint'in tablo ızgara modelini izler.

Bu örnek, 70 puan genişliğinde sütun ve satırlara sahip 4×4 bir tablo oluşturur ve `(1, 1)` hücresinde [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) çağırır. Hücrenin 70 puan genişliğinin yarısı, iki eşit genişlikte hücre oluşturmak için kullanılır.

Bu bölünmeden sonra iki yarı `table.get_Item(1, 1)` ve `table.get_Item(2, 1)` olarak erişilir. Tablo ızgarası artık beş sütuna sahiptir: başlangıçta 2 ve 3. sütunlarda olan hücreler sırasıyla 3 ve 4. sütunlara taşınır. Satır dizinleri değişmez. Bölünmeden sonra hücrelere erişirken bu güncellenmiş sütun dizinlerini kullanın.

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

<!-- visual-explanation:manage-cells:start -->
[![Birleştirilmemiş 70 puanlık bir hücre iki 35 puanlık hücreye bölünür, beşinci bir ızgara sütunu ekler ve sağındaki dizinleri kaydırır.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Genişlik bölünmesi hücre (1, 1)'i etkiler, sıfır tabanlı (sütun, satır) indeksleri kullanır. Diğer satırlar, iki yeni sütun konumunu kapsayan bir hücreyi korur.*
<!-- visual-explanation:manage-cells:end -->

### **Birleştirilmiş Hücreleri Satır veya Sütun Yayılımına Göre Bölme**

Birleştirilmiş şablon hücrelerini veri doldurma için hazırlamak üzere, mevcut bir satır sınırı boyunca bölmek için [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) kullanın, veya bir sütun sınırı boyunca bölmek için [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) kullanın.

`index` argümanı, bölünmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; birleştirilmiş bölgeye göredir:

- Satır bölünmesi: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Sütun bölünmesi: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Örnek, bir sunumun ilk slayttaki ilk şekli olarak bir tablo içerdiğini ve `(1, 2)` ile `(1, 3)` hücrelerinin dikey olarak birleştirildiğini varsayar. Alt konumdan başlayarak, kökeni bulmak için [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) ve [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) kullanır ve her iki yayılımı da kontrol eder. `splitByRowSpan(1)` ardından ürün adları için satır 2 ve 3'ü ayırır. Yatay iki sütun birleştirme için `splitByColSpan(1)` kullanın.

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

        // Bölündükten sonra tablodan ortaya çıkan hücreleri alın.
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

Tablo ızgarası ve çevredeki hücre indeksleri değişmez. Sonuç hücreleri koordinatlarıyla alın; burada ikisi de 1 yayılıma sahiptir ve [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) `false` yazdırır. Daha büyük bölgeler bir bölünmeden sonra kısmen birleşik kalabilir.

Orijinal metin ve biçimlendirmesi üst (veya sol) hücrede kalır; yeni hücre boş olur ancak dolgu, kenarlık ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Hücreleri bölündükten sonra doldurun ve gerekli metin biçimlendirmesini açıkça ayarlayın.

Kayıtlı sunum, şablonun hücre biçimlendirmesini koruyan ayrı "Product A" ve "Product B" hücrelerini içerir. Ayrıntılar için [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) bakın.

### **Bir Hücreyi Belirli Bir Yükseklikte Bölme**

[splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/) üst kısmın yüksekliğini puan cinsinden alır. [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) üst kısımdaki mevcut ızgara satırlarının sayısını alır. Sağ sütunda 40 puanlık bir hücreyi ortalamak için, hücrenin gerçek yüksekliğinden 40'ı çıkarın ve kalan boşluğu üstte ve altta eşit şekilde bölün.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

İlk bölme bir ızgara satırı ekler ve `(1, 1)` hücresinde alt kısmı 90 puan bırakır. İkinci bölme, bu hücreyi 40 puanlık orta hücre ve 50 puanlık alt hücreye ayırır. Sağ sütun artık üstten alta doğru 50, 40 ve 50 puan yüksekliğinde üç hücreye sahiptir. Sol hücre üç satırı kapsar ve orijinal 140 puan yüksekliğini korur.

![Sol hücre, ortada 'Middle' bulunan üç hücrenin yanına tablo yüksekliğinin tamamını kapsar.](split-by-height.png)

## **Tablo Hücresi Arka Plan Rengini Değiştirme**

Bu örnek, 150 puan genişliğinde sütunlar ve 50 puan yüksekliğinde satırlara sahip bir tablo oluşturur. [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) kullanarak katı bir dolgu seçer ve [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) tarafından döndürülen rengi, üçüncü sütun ve dördüncü satırda bulunan `(2, 3)` hücresi için kırmızı olarak ayarlar.

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

## **Bir Tablo Hücresinin İçine Resim Ekleme**

Bu örneği çalıştırmadan önce giriş resmini çalışma dizinine yerleştirin. Resmi [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) ile yükler ve sunumun resim koleksiyonuna [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) ile ekler. Daha sonra resmi tablodaki ilk hücre olan `(0, 0)` hücresinin resim doldurmasına atar.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) resmi hücreyi dolduracak şekilde uzatır, bu da en boy oranını değiştirebilir. Sütun genişlikleri ve satır yükseklikleri puan cinsindendir. Yüklenen resim, sunuma eklendikten sonra bir `finally` bloğunda serbest bırakılır.

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

Evet. [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) kenarlıkların ayrı özellikleri vardır, bu yüzden her bir kenarın kalınlığı ve stili farklı olabilir.

**Resmi hücrenin arka planı olarak bir resim ayarladıktan sonra sütun/satır boyutunu değiştirirsem ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/)’a bağlıdır. Uzatma durumunda, resim yeni hücreye göre ayarlanır; döşeme durumunda ise döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir hiperlink atayabilir miyim?**

[Hyperlinks](/slides/tr/nodejs-java/manage-hyperlinks/) hücre içindeki metin çerçevesinin (parça) seviyesinde ya da tüm tablo/şekil seviyesinde ayarlanır. Pratikte, bağlantıyı bir parçaya ya da hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (koşu) öğelerini destekler—yazı tipi ailesi, stil, boyut ve renk.