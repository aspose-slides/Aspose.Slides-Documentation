---
title: Presentasyonlarda Tablo Hücrelerini Java Kullanarak Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/java/manage-cells/
keywords:
- tablo hücresi
- hücre birleştirme
- kenarlık kaldırma
- hücre bölme
- hücrede görüntü
- arka plan rengi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint'te tablo hücrelerini zahmetsizce yönetin. Hücrelere hızlıca erişme, değiştirme ve stil uygulama konularında ustalaşarak sorunsuz slayt otomasyonu sağlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bunları değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücreleri birleştirdikten veya ayırdıktan sonra hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresinin içine nasıl görüntü ekleyeceğinizi açıklar. Örnekler, bir sunum nasıl oluşturulur veya açılır, slayttan bir tablo nasıl alınır, hücre özellikleri aracılığıyla hücre biçimlendirmesi nasıl güncellenir ve değiştirilmiş sunum nasıl PPTX dosyası olarak kaydedilir gösterir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**
1. Create an instance of the  [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) class.
2. İlk slayttan tabloyu alın. 
3. Birleştirilmiş hücreleri bulmak için tablonun satır ve sütunları arasında dolaşın. 
4. Birleştirilmiş hücreler bulunduğunda mesaj yazdırın.

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // Slide#0.Shape#0 bir tablo olduğu varsayılıyor
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tablo Hücre Kenarlıklarını Kaldırma**
1. Create an instance of the  [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) class.
2. İndeks aracılığıyla bir slaydın referansını alın. 
3. Genişliği olan bir sütun dizisi tanımlayın. 
4. Yüksekliği olan bir satır dizisi tanımlayın. 
5. Slayta [addTable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) yöntemiyle bir tablo ekleyin. 
6. Her hücreyi dolaşarak üst, alt, sağ ve sol kenarlıkları temizleyin. 
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```java
// Presentation sınıfını örnekler; bu sınıf bir PPTX dosyasını temsil eder
Presentation pres = new Presentation();
try {
    // İlk slaytı erişir
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Slayta tablo şekli ekler
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Her hücre için kenarlık biçimini ayarlar
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // PPTX dosyasını diske yazar
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Birleştirilmiş Hücrelerde Numaralandırma**

İki hücre çifti (1,1) x (2,1) ve (1,2) x (2,2) birleştirirsek, ortaya çıkan tablo numaralandırılacaktır. Bu Java kodu süreci gösterir:

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Slayta bir tablo şekli ekler
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Her hücre için kenarlık biçimini ayarlar
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Hücreleri (1, 1) x (2, 1) birleştirir
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Hücreleri (1, 2) x (2, 2) birleştirir
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ardından (1,1) ve (1,2) hücrelerini birleştirerek hücreleri daha da birleştiririz. Sonuç, ortasında büyük bir birleştirilmiş hücre bulunan bir tablo olur: 

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Slayta bir tablo şekli ekler
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Her hücre için kenarlık biçimini ayarlar
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Hücreleri (1, 1) x (2, 1) birleştirir
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Hücreleri (1, 2) x (2, 2) birleştirir
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Hücreleri (1, 1) x (1, 2) birleştirir
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// PPTX dosyasını diske yazar
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bölünmüş Bir Hücrede Numaralandırma**
Önceki örneklerde, tablo hücreleri birleştirildiğinde, diğer hücrelerdeki numaralandırma veya sayı sistemi değişmedi. 

Bu sefer, birleştirilmiş hücresi olmayan normal bir tablo alıp (1,1) hücresini bölerek özel bir tablo elde etmeye çalışıyoruz. Bu tablonun numaralandırmasına dikkat etmek isteyebilirsiniz; bu garip görünebilir. Ancak bu, Microsoft PowerPoint'in tablo hücrelerini numaralandırma şeklidir ve Aspose.Slides de aynı şeyi yapar. 

Bu Java kodu açıklanan süreci gösterir:

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Slayta bir tablo şekli ekler
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Her hücre için kenarlık biçimini ayarlar
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Hücreleri (1, 1) x (2, 1) birleştirir
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Hücreleri (1, 2) x (2, 2) birleştirir
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Hücreyi (1, 1) bölür
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // PPTX dosyasını diske yazar
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu Java kodu size bir tablo hücresinin arka plan rengini nasıl değiştireceğinizi gösterir:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // yeni bir tablo oluştur
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // bir hücrenin arka plan rengini ayarla 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Bir Tablo Hücresinin İçine Görüntü Ekleme**

1. Create an instance of the  [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) class.
2. İndeks aracılığıyla bir slaydın referansını alın. 
3. Genişliği olan bir sütun dizisi tanımlayın. 
4. Yüksekliği olan bir satır dizisi tanımlayın. 
5. Slayta [AddTable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) yöntemiyle bir tablo ekleyin. 
6. `Images` nesnesi oluşturun ve görüntü dosyasını tutun. 
7. `IImage` görüntüsünü `IPPImage` nesnesine ekleyin. 
8. Tablo hücresi için `FillFormat` değerini `Picture` olarak ayarlayın. 
9. Görüntüyü tablonun ilk hücresine ekleyin. 
10. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin

```java
// Presentation sınıfını örnekler; bu sınıf bir PPTX dosyasını temsil eder
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide islide = pres.getSlides().get_Item(0);

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Slayta bir tablo şekli ekler
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Resim dosyasını kullanarak bir IPPImage nesnesi oluşturur
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Resmi ilk tablo hücresine ekler
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX dosyasını diske kaydeder
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stiller ayarlayabilir miyim?**

Evet. [üst](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellformat/#getBorderTop--)/[alt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellformat/#getBorderBottom--)/[sol](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellformat/#getBorderLeft--)/[sağ](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellformat/#getBorderRight--) kenarlıklarının ayrı özellikleri vardır, bu nedenle her bir kenarın kalınlığı ve stili farklı olabilir. Bu, makalede gösterilen bir hücre için kenar kontrolünün taraf bazlı olmasıyla mantıksal olarak uyumludur.

**Bir hücrenin arka planı olarak bir resim ayarladıktan sonra sütun/satır boyutunu değiştirirsem, görüntü ne olur?**

Davranış, [dolgu modu](https://reference.aspose.com/slides/tr/java/com.aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Stretch seçildiğinde, görüntü yeni hücreye uyacak şekilde ayarlanır; tile seçildiğinde, döşemeler yeniden hesaplanır. Makalede hücredeki görüntü görüntüleme modlarından bahsedilmektedir.

**Bir hücrenin tüm içeriğine bir köprü (hyperlink) atayabilir miyim?**

[Hyperlinks](/slides/tr/java/manage-hyperlinks/) hücrenin metin çerçevesindeki metin (portion) seviyesinde veya tüm tablo/şekil seviyesinde ayarlanır. Pratikte, bağlantıyı bir bölüme veya hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, [portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) bağımsız biçimlendirmeye (yazı tipi aileleri, stil, boyut ve renk) sahip bölümleri destekler.