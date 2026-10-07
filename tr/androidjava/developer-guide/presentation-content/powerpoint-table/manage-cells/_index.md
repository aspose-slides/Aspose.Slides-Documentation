---
title: Android'de Sunumlarda Tablo Hücrelerini Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/androidjava/manage-cells/
keywords:
- tablo hücresi
- hücreleri birleştir
- kenarlığı kaldır
- hücreyi böl
- hücrede resim
- arka plan rengi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android'de PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri tanımlayın, kenarlıkları kaldırın, hücreleri bölün ve Aspose.Slides for Android ile Java aracılığıyla arka plan renklerini ve resimleri ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bu hücreleri değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, birleştirme veya bölme sonrasında hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresi içine nasıl bir resim ekleyeceğinizi açıklar. Örnekler, bir sunumu nasıl oluşturup açacağınızı, bir slayttan tablo almayı, hücre özellikleri aracılığıyla hücre biçimlendirmesini güncellemeyi ve değiştirilmiş sunumu PPTX dosyası olarak kaydetmeyi gösterir.

Aspose.Slides, tablo hücrelerine `(sütun, satır)` sırasıyla erişmek için sıfırdan başlayan dizinler kullanır.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Slayt ve şeklin mevcut olduğu ve şeklin bir tablo olduğu varsayılır. Daha sonra tüm satır ve sütunlar üzerinde döngü yapar ve birleştirilmiş bölgelerdeki hücreleri tanımlamak için [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) metodunu kullanır. Her eşleşme için hücre koordinatlarını `satır;sütun` sırasında, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--) ve bölgenin başlangıç koordinatlarını, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) ve [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) yazar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Tablo Hücresi Kenarlıklarını Kaldırma**

[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) oluşturun ve ilk slaytına [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) ile bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu puan cinsindendir. Örnek, tüm dört hücre kenarlığını [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) yaparak görünmez hâle getirir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Hücrelerini Birleştirme**

[mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) kullanarak dikdörtgen bir hücre aralığını tek bir hücreye dönüştürün. Aralığın sol‑üst ve sağ‑alt köşesindeki hücreleri belirtin. Son argüman, birleştirmenin belirtilen aralığın dışındaki hücreleri kapsayıp kapsamayacağını kontrol eder; `false` birleştirmenin yalnızca bu aralık içinde kalmasını sağlar.

Örnek, 70 puan genişliğinde sütunlar ve satırlar içeren 4×4 bir tablo oluşturur, ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Oluşan hücre iki sütun ve iki satır kaplar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için bu örnekte `table.get_Item(1, 1)` kullanılır. Birleştirilmiş aralıktaki diğer konumlar tablo ızgarasının bir parçası olmaya devam eder, bu yüzden aralığın dışındaki hücre indeksleri değişmez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Hücrelerini Bölme**

Önceki örnekte hücreleri birleştirmek tablonun ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu ekleyebilir ve sağındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint'in tablo ızgara modelini izler.

Bu örnek, 70 puan genişliğinde sütun ve satırlarla 4×4 bir tablo oluşturur ve `(1, 1)` hücresinde [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) metodunu çağırır. Hücrenin 70 puan genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için kullanılır.

Bu bölmeden sonra iki yarı `table.get_Item(1, 1)` ve `table.get_Item(2, 1)` olarak erişilir. Tablo ızgarası şimdi beş sütuna sahiptir: önceki 2. ve 3. sütunlardaki hücreler sırasıyla 3. ve 4. sütunlara taşınır. Satır indeksleri değişmez. Bölmeden sonra hücrelere erişirken bu güncellenmiş sütun indekslerini kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Satır veya Sütun Kapsamına Göre Birleştirilmiş Hücreleri Bölme**

Birleştirilmiş şablon hücrelerini veri doldurmak için hazırlamak amacıyla, mevcut bir satır sınırı boyunca bölmek için [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-), bir sütun sınırı boyunca bölmek için ise [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) kullanın.

`index` argümanı, bölmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; birleştirilmiş bölgeye görecelidir:

- Satır bölmesi: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Sütun bölmesi: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Örnek, bir sunumun ilk slaytındaki ilk şeklin tablo olduğunu ve `(1, 2)` ile `(1, 3)` hücrelerinin dikey olarak birleştirilmiş olduğunu varsayar. Alt konumdan başlayarak, kökü bulmak için [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) ve [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) kullanır ve her iki kapsamı da kontrol eder. `splitByRowSpan(1)` ardından ürün adları için 2. ve 3. satırları ayırır. Yatay iki sütun birleştirme için `splitByColSpan(1)` kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Ayrıştırmadan sonra tablodan oluşan hücreleri al.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Tablo ızgarası ve çevredeki hücre indeksleri değişmeden kalır. Sonuç hücreleri koordinatlarıyla alın; burada ikisi de 1 kapsamına sahiptir ve [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) `false` yazdırır. Daha büyük bölgeler tek bir bölmeden sonra kısmen birleşik kalabilir.

Orijinal metin ve biçimlendirme üst (veya sol) hücrede kalır; yeni hücre boştur ancak dolgu, kenarlık ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Bölmeden sonra hücreleri doldurun ve gerekli metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesi korunmuş ayrı “Product A” ve “Product B” hücrelerini içerir. Ayrıntılar için [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) sayfasına bakın.

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu örnek, 150 puan genişliğinde sütunlar ve 50 puan yüksekliğinde satırlar içeren bir tablo oluşturur. [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) kullanarak düz bir dolgu seçer ve [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) tarafından döndürülen rengi, üçüncü sütun ve dördüncü satırdaki `(2, 3)` hücresi için kırmızı olarak ayarlar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Hücresi İçine Resim Ekleme**

Bu örneği çalıştırmadan önce giriş resmini çalışma dizinine koyun. Resmi [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) ile yükler ve sunumun resim koleksiyonuna [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) ile ekler. Ardından resmi, tablodaki ilk hücre olan `(0, 0)` hücresinin resim dolgusuna atar.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) resmi hücreye sığdırmak için genişletir, bu da en‑boy oranını değiştirebilir. Sütun genişlikleri ve satır yükseklikleri puan cinsindendir. Yüklenen resim, sunuma eklendikten sonra bir `finally` bloğunda serbest bırakılır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) kenarlarının ayrı özellikleri vardır, bu nedenle her bir kenarın kalınlığı ve stili farklı olabilir.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem resim ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) seçimine bağlıdır. Stretch seçildiğinde resim yeni hücreye göre ayarlanır; tile seçildiğinde ise karolar yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir köprü ekleyebilir miyim?**

[Hyperlinks](/slides/tr/androidjava/manage-hyperlinks/) hücrenin metin çerçevesi içindeki metin (portion) seviyesinde veya tüm tablo/şekil düzeyinde ayarlanabilir. Pratikte, bağlantıyı bir portion’a ya da hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (run) destekler—yazı tipi ailesi, stil, boyut ve renk.