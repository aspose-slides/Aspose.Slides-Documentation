---
title: Android'de Sunumlarda Tablo Hücrelerini Yönet
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/androidjava/manage-cells/
keywords:
- tablo hücresi
- hücre birleştirme
- kenarlık kaldırma
- hücre bölme
- hücrede resim
- arka plan rengi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Java ile Android için Aspose.Slides kullanarak PowerPoint'te tablo hücrelerini zahmetsizce yönetin. Hücrelere hızlı erişim, değiştirme ve stil verme konusunda ustalaşarak sorunsuz slayt otomasyonu sağlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bu hücreleri değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücreleri birleştirdikten veya böldükten sonra numaralandırma ile nasıl çalışacağınızı, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunumun nasıl oluşturulacağını veya açılacağını, bir slayttan nasıl tablo alınacağını, hücre özellikleri aracılığıyla hücre biçimlendirmesinin nasıl güncelleneceğini ve değiştirilmiş sunumun PPTX dosyası olarak nasıl kaydedileceğini gösterir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**
1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. İlk slayttan tabloyu alın.  
3. Birleştirilmiş hücreleri bulmak için tablonun satır ve sütunlarında döngü yapın.  
4. Birleştirilmiş hücreler bulunduğunda mesaj yazdırın.  

Bu Java kodu, bir sunumda birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı gösterir:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // Slide#0.Shape#0'nin bir tablo olduğunu varsayarak
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
1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. İndeks yoluyla bir slayd referansı alın.  
3. Genişliği olan bir sütun dizisi tanımlayın.  
4. Yüksekliği olan bir satır dizisi tanımlayın.  
5. [addTable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) yöntemiyle slayda bir tablo ekleyin.  
6. Her hücreyi dolaşarak üst, alt, sağ ve sol kenarlıkları temizleyin.  
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu Java kodu, tablo hücrelerinin kenarlıklarını nasıl kaldıracağınızı gösterir:

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekleştirir
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
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
Eğer (1,1) x (2,1) ve (1,2) x (2,2) hücre çiftlerini birleştirirsek, ortaya çıkan tablo numaralandırılır. Bu Java kodu süreci gösterir:

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekleştirir
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Slayta tablo şekli ekler
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

Ardından (1,1) ve (1,2) hücrelerini birleştirerek hücreleri daha da birleştiririz. Sonuç, merkezinde büyük bir birleştirilmiş hücre bulunan bir tablo olur:

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekleştirir
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Slayta tablo şekli ekler
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
    
    //PPTX dosyasını diske yazar
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bölünmüş Hücrede Numaralandırma**
Önceki örneklerde, tablo hücreleri birleştirildiğinde diğer hücrelerdeki numaralandırma sistemi değişmedi.  

Bu sefer, bir normal tablo (birleştirilmiş hücreleri olmayan bir tablo) alıp (1,1) hücresini bölmeye çalışıyoruz ve özel bir tablo elde ediyoruz. Bu tablonun numaralandırmasına dikkat edebilirsiniz; bu garip görünebilir. Ancak bu, Microsoft PowerPoint'in tablo hücrelerini numaralandırma şeklidir ve Aspose.Slides da aynı şekilde çalışır.  

Bu Java kodu, açıklanan süreci gösterir:

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekleştirir
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Slayta tablo şekli ekler
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

    // Hücreyi (1, 1) bölerek
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // PPTX dosyasını diske yazar
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu Java kodu, bir tablo hücresinin arka plan rengini nasıl değiştireceğinizi gösterir:

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

## **Bir Tablo Hücresine Resim Ekleme**
1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. İndeks yoluyla bir slayd referansı alın.  
3. Genişliği olan bir sütun dizisi tanımlayın.  
4. Yüksekliği olan bir satır dizisi tanımlayın.  
5. [AddTable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) yöntemiyle slayda bir tablo ekleyin.  
6. `Images` nesnesi oluşturarak resim dosyasını tutun.  
7. `IImage` resmini `IPPImage` nesnesine ekleyin.  
8. Tablo hücresi için `FillFormat`'ı `Picture` olarak ayarlayın.  
9. Resmi tablonun ilk hücresine ekleyin.  
10. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu Java kodu, bir tablo oluştururken tablo hücresinin içine nasıl resim yerleştirileceğini gösterir:

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekleştirir
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide islide = pres.getSlides().get_Item(0);

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Slayta tablo şekli ekler
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

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**  

Evet. [top](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellformat/#getBorderRight--) kenarlıklarının ayrı özellikleri vardır, bu nedenle her bir kenarın kalınlığı ve stili farklı olabilir. Bu, makalede gösterilen hücre başına kenarlık kontrolünden mantıksal olarak izlenir.  

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem resim ne olur?**  

Davranış, [fill mode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Stretch (germe) olduğunda, resim yeni hücreye uyum sağlar; tile (döşeme) olduğunda, döşemeler yeniden hesaplanır. Makale, bir hücredeki resim gösterim modlarından bahseder.  

**Bir hücrenin tüm içeriğine bir köprü (hyperlink) atayabilir miyim?**  

[Hyperlinks](/slides/tr/androidjava/manage-hyperlinks/) hücre içindeki metin (portion) seviyesinde ya da tüm tablo/şekil seviyesinde ayarlanır. Pratikte, bağlantıyı bir bölüme ya da hücredeki tüm metne atarsınız.  

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**  

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) (run)ları destekler—yazı tipi ailesi, stil, boyut ve renk.