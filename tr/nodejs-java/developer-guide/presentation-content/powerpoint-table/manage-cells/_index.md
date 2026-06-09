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
description: "Aspose.Slides for Node.js ile PowerPoint'te tablo hücrelerini yönetin. Hücrelere hızlı erişim, değişiklik ve stil verme konusunda uzmanlaşın ve sorunsuz slayt otomasyonu sağlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bu hücreleri değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücreleri birleştirme veya bölme sonrasında hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunumun nasıl oluşturulup açılacağını, bir slayttan tablo almayı, hücre özellikleri aracılığıyla hücre biçimlendirmesini güncellemeyi ve değiştirilmiş sunumu PPTX dosyası olarak kaydetmeyi gösterir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**
1.  [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. İlk slayttan tabloyu alın.  
3. Birleştirilmiş hücreleri bulmak için tablonun satır ve sütunlarında yineleme yapın.  
4. Birleştirilmiş hücreler bulunduğunda mesaj yazdırın.  

Bu JavaScript kodu, bir sunumda birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// Slide#0.Shape#0'ın bir tablo olduğunu varsayarak
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablo Hücreleri Kenarlığını Kaldırma**
1.  [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaytın referansını indeks üzerinden alın.  
3. Genişlik değerleriyle bir sütun dizisi tanımlayın.  
4. Yükseklik değerleriyle bir satır dizisi tanımlayın.  
5. [addTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) yöntemiyle slayta bir tablo ekleyin.  
6. Her hücrede üst, alt, sağ ve sol kenarlıkları temizlemek için yineleme yapın.  
7. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu JavaScript kodu, tablo hücrelerinin kenarlıklarını nasıl kaldıracağınızı gösterir:

```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Slayta tablo şekli ekler
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Her hücre için kenarlık biçimini ayarlar
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // PPTX dosyasını diske yazar
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Birleştirilmiş Hücrelerde Numaralandırma**
2 çift hücreyi (1, 1) x (2, 1) ve (1, 2) x (2, 2) birleştirirsek, ortaya çıkan tablo numaralandırılmış olacaktır. Bu JavaScript kodu süreci gösterir:

```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Slayta tablo şeklini ekler
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Her hücre için kenarlık biçimini ayarlar
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // (1, 1) x (2, 1) hücrelerini birleştirir
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // (1, 2) x (2, 2) hücrelerini birleştirir
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Daha sonra (1, 1) ve (1, 2) hücrelerini birleştirerek tabloyu daha da birleştiririz. Sonuç, ortada büyük bir birleştirilmiş hücre içeren bir tablo olur: 

```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Slayta tablo şekli ekler
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Her hücre için kenarlık biçimini ayarlar
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // (1, 1) x (2, 1) hücrelerini birleştirir
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // (1, 2) x (2, 2) hücrelerini birleştirir
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // (1, 1) x (1, 2) hücrelerini birleştirir
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // PPTX dosyasını diske yazar
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bölünmüş Hücrelerde Numaralandırma**
Önceki örneklerde, tablo hücreleri birleştirildiğinde diğer hücrelerdeki numaralandırma sistemi değişmezdi.  

Bu sefer, birleştirilmemiş bir tablo (birleştirilmiş hücre olmayan tablo) alıp (1,1) hücresini bölerek özel bir tablo elde ediyoruz. Bu tablonun numaralandırmasına dikkat etmeniz gerekebilir; ilk bakışta garip görünebilir. Ancak bu, Microsoft PowerPoint'in tablo hücrelerini numaralandırma şeklidir ve Aspose.Slides de aynı davranışı sergiler.  

Bu JavaScript kodu, açıklanan süreci gösterir:

```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Slayta tablo şekli ekler
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Her hücre için kenarlık biçimini ayarlar
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // (1, 1) x (2, 1) hücrelerini birleştirir
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // (1, 2) x (2, 2) hücrelerini birleştirir
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // (1, 1) hücresini böler
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // PPTX dosyasını diske yazar
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablo Hücresi Arka Plan Rengini Değiştirme**

Bu JavaScript kodu, bir tablo hücresinin arka plan rengini nasıl değiştireceğinizi gösterir:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // yeni bir tablo oluştur
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // bir hücre için arka plan rengini ayarla
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Tablo Hücresi İçine Resim Ekleme**

1.  [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaytın referansını indeks üzerinden alın.  
3. Genişlik değerleriyle bir sütun dizisi tanımlayın.  
4. Yükseklik değerleriyle bir satır dizisi tanımlayın.  
5. [addTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) yöntemiyle slayta bir tablo ekleyin.  
6. Resim dosyasını tutmak için bir `Images` nesnesi oluşturun.  
7. `IImage` resmini `PPImage` nesnesine ekleyin.  
8. Tablo hücresi için `FillFormat` değerini `Picture` olarak ayarlayın.  
9. Resmi tablonun ilk hücresine ekleyin.  
10. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu JavaScript kodu, bir tablo oluştururken bir tablo hücresine nasıl resim yerleştirileceğini gösterir:

```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var islide = pres.getSlides().get_Item(0);
    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // Slayta tablo şekli ekler
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // Görüntü dosyasını kullanarak bir PPImage nesnesi oluşturur
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Görüntüyü ilk tablo hücresine ekler
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // PPTX dosyasını diske kaydeder
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellformat/getborderright/) kenarların ayrı özellikleri vardır; böylece her tarafın kalınlığı ve stili farklı olabilir. Bu, makalede gösterilen hücre başına kenar kontrolüne dayanmaktadır.

**Bir hücrenin arka planına resmi ayarladıktan sonra sütun/ satır boyutunu değiştirirsem resim ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Stretch seçilirse resim yeni hücreye göre ayarlanır; tile seçilirse döşemeler yeniden hesaplanır. Makale, hücredeki resim görüntüleme modlarından bahseder.

**Bir hücrenin tüm içeriğine bir hiperlink atayabilir miyim?**

[Hyperlinks](/slides/tr/nodejs-java/manage-hyperlinks/) hücrenin metin çerçevesindeki metin (parça) seviyesinde veya tüm tablo/şekil seviyesinde ayarlanır. Pratikte, bağlantıyı bir parçaya ya da hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri kullanabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) (run)ları destekler—yazı tipi, stil, boyut ve renk.