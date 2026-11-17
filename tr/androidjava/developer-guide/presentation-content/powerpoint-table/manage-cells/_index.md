---
title: Android'ta Sunumlarda Tablo Hücrelerini Yönetmek
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
description: "Android'de PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri tanımlayın, kenarlıkları kaldırın, hücreleri bölün ve Aspose.Slides for Android ile Java aracılığıyla arka plan renklerini ve resimleri ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bu hücreleri değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücreleri birleştirdikten veya böldükten sonra hücre numaralandırmasıyla nasıl çalışacağınızı, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresi içine nasıl resim ekleyeceğinizi açıklamaktadır. Örnekler, bir sunumun nasıl oluşturulup açılacağını, bir slayttan nasıl tablo alınacağını, hücre özellikleri aracılığıyla hücre biçimlendirmesinin nasıl güncelleneceğini ve değiştirilmiş sunumun PPTX dosyası olarak nasıl kaydedileceğini göstermektedir.

Aspose.Slides, tablo hücrelerine `(sütun, satır)` sırasıyla sıfır tabanlı indeksler kullanarak erişir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Slayt ve şeklin var olduğunu ve şeklin bir tablo olduğunu varsayar. Daha sonra tüm satır ve sütunlarda döngü yapar ve birleştirilmiş bölgelerdeki hücreleri tanımlamak için [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) yöntemini kullanır. Eşleşen her hücre için `row;column` sırasında hücre koordinatlarını, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), ve bölgenin başlangıç koordinatlarını, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) ve [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) yazdırır.

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

## **Tablo Hücre Kenarlıklarını Kaldırma**

Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) oluşturun ve ilk slaytına [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) yöntemiyle bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu puan cinsinden belirtilir. Örnek, dört hücre kenarlığının tamamını [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) olarak ayarlar ve böylece görünmez hale getirir.

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

## **Çapraz Hücre Kenarlıkları Ekleme**

[getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) kullanarak sol üst köşeden sağ alt köşeye bir çizgi çizin ve [getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) kullanarak sol alt köşeden sağ üst köşeye bir çizgi çizin. Bir çapraz, köşe başlığını işaretleyebilir; her iki çapraz da bir X oluşturup hücreyi uygulanamaz olarak işaretleyebilir.

Her çapraz bir [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) nesnesidir. Onun [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) içinde, [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) kullanarak [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) seçin ve bir renk seçmek için [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) çağırın. Çizginin kalınlığını puan cinsinden [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) ile ayarlayın.

Örnek, bir satırda üç hücre oluşturur: kırmızı aşağı doğru çapraz, mavi yukarı doğru çapraz ve her iki çapraz. Üst, alt, sol ve sağ hücre kenarlıkları değişmeden kalır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bir çapraz bir biçimlendirme özelliğidir, hücre bölmesi değildir. Her hücre, [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) aracılığıyla erişilebilen tek bir metin çerçevesi tutar; bir çaprazın her iki tarafındaki bölgeler bağımsız olarak düzenlenemez.

![Üst sol köşeden alt sağ köşeye kırmızı bir çapraz, alt sol köşeden üst sağ köşeye mavi bir çapraz ve her iki çaprazın bir X oluşturduğu üç tablo hücresi.](diagonal-cell-borders.png)

*Soldan sağa: aşağı doğru çapraz (kırmızı, 3 pt), yukarı doğru çapraz (mavi, 5 pt) ve her iki çapraz.*

## **Tablo Hücrelerini Birleştirme**

[mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) kullanarak bir tablo hücresi dikdörtgen aralığını tek bir hücreye birleştirin. Aralığın sol üst ve sağ alt köşelerindeki hücreleri belirtin. Son argüman, birleştirmenin belirtilen aralığın dışındaki hücreleri içermesini kontrol eder; `false` birleştirmenin bu aralık içinde kalmasını sağlar.

Örnek, 70 puan sütun ve satır genişliğine sahip 4x4 bir tablo oluşturur, ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Ortaya çıkan hücre iki sütun ve iki satır kapsar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için, bu örnekte `table.get_Item(1, 1)` üst‑sol konumunu kullanın. Birleştirme aralığının dışındaki diğer konumlar tablo ızgarasının bir parçası olmaya devam eder, bu nedenle aralık dışı hücrelerin indeksleri değişmez.

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

Önceki örnekte hücreleri birleştirmek tablo ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu ekleyebilir ve sağındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint'in tablo ızgara modelini kullanır.

Bu örnek, 70 puan sütun ve satır genişliğine sahip 4x4 bir tablo oluşturur ve `(1, 1)` hücresi üzerinde [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) metodunu çağırır. Hücrenin 70 puan genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için geçirilir.

Bölme işleminden sonra iki yarı `table.get_Item(1, 1)` ve `table.get_Item(2, 1)` olarak erişilir. Tablo ızgarası artık beş sütuna sahiptir: önceden 2 ve 3. sütunlardaki hücreler sırasıyla 3 ve 4. sütunlara taşınır. Satır indeksleri değişmez. Bölme sonrası hücrelere erişirken bu güncellenmiş sütun indekslerini kullanın.

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

<!-- visual-explanation:manage-cells:start -->
[![Birleştirilmemiş 70 puanlık bir hücre iki 35 puanlık hücreye bölünür, beşinci bir ızgara sütunu ekler ve sağındaki indeksleri kaydırır.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Genişlik bölmesi, (1, 1) hücresini etkiler ve sıfır tabanlı (sütun, satır) indeksleri kullanır. Diğer satırlar, yeni iki sütun konumunu kapsayan bir hücreyi korur.*
<!-- visual-explanation:manage-cells:end -->

### **Birleştirilmiş Hücreleri Satır veya Sütun Kapsamına Göre Bölme**

Birleştirilmiş şablon hücrelerini veri doldurma için hazırlamak amacıyla, [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) kullanarak mevcut bir satır sınırında bölün, ya da [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) kullanarak bir sütun sınırında bölün.

`index` parametresi, bölmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; birleşik bölgeye göredir:

- Satır bölmesi: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Sütun bölmesi: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Örnek, bir sunumun ilk slaytındaki ilk şeklin bir tablo olduğunu varsayar ve `(1, 2)` ve `(1, 3)` hücrelerinin dikey olarak birleştirildiğini varsayar. Alt konumdan başlayarak, [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) ve [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) kullanarak kökeni bulur ve her iki kapsamı da kontrol eder. `splitByRowSpan(1)` ardından ürün adları için satır 2 ve 3'ü ayırır. Yatay iki sütun birleştirme için `splitByColSpan(1)` kullanın.

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

        // Bölme işleminden sonra tablodan elde edilen hücreleri al.
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

Tablo ızgarası ve çevredeki hücre indeksleri değişmez. Sonuç hücrelerini koordinatlarıyla alın; burada her iki hücre de 1 kapsama sahiptir ve [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) `false` yazdırır. Daha büyük bölgeler tek bir bölmeden sonra kısmen birleştirilebilir kalabilir.

Orijinal metin ve biçimlendirmesi üst (veya sol) hücrede kalır; yeni hücre boştur ancak dolgu, kenarlıklar ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Hücreleri bölme sonrası doldurun ve gerektiğinde metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesini koruyan ayrı "Product A" ve "Product B" hücreleri içerir. Detaylar için [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) sayfasına bakın.

### **Bir Hücreyi Belirli Bir Yükseklikte Bölme**

[splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) üst kısmın yüksekliğini puan cinsinden alır. [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) üst kısmın mevcut ızgara satır sayısını alır. 40 puanlık bir hücreyi sağ sütunda ortalamak için, hücrenin gerçek yüksekliğinden 40 çıkarın ve kalan boşluğu üstte ve altta eşit bölün.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };

    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

İlk bölme bir ızgara satırı ekler ve `(1, 1)` hücresinde 90 puanlık alt kısmı bırakır. İkinci bölme, o hücreyi 40 puanlık orta hücre ve 50 puanlık alt hücreye ayırır. Sağ sütun artık üstten alta 50, 40 ve 50 puan yüksekliğinde üç hücreye sahiptir. Sol hücre tüm üç satırı kapsar ve orijinal 140 puan yüksekliğini korur.

![Sol hücre, ortada Orta hücre bulunan üç hücrenin yanında tablonun tam yüksekliğini kapsar.](split-by-height.png)

## **Tablo Hücresi Arka Plan Rengini Değiştirme**

Bu örnek, 150 puan sütun ve 50 puan satır genişliğine sahip bir tablo oluşturur. [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) kullanarak katı bir dolgu seçer ve [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) tarafından döndürülen rengi `(2, 3)` hücresi (üçüncü sütun, dördüncü satır) için kırmızı olarak ayarlar.

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

## **Bir Tablo Hücresi İçine Resim Ekleme**

Bu örneği çalıştırmadan önce giriş resmini çalışma dizinine yerleştirin. Resmi [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) ile yükler ve sunumun resim koleksiyonuna [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) ile ekler. Ardından resmi, tablodaki ilk hücre olan `(0, 0)` hücresinin resim dolgusuna atar.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) resmi hücreyi dolduracak şekilde gerer, bu da en‑boy oranının değişmesine neden olabilir. Sütun genişlikleri ve satır yükseklikleri puan cinsindendir. Yüklenen resim, sunuma eklendikten sonra bir `finally` bloğunda serbest bırakılır.

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

**Bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) kenarlıkları ayrı özelliklere sahiptir, böylece her bir kenarın kalınlığı ve stili farklı olabilir.

**Bir hücrenin arka planı olarak resmi ayarladıktan sonra sütun/satır boyutunu değiştirirsem ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Germe (stretch) ile resim yeni hücreye göre ayarlanır; döşeme (tile) ile döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir hiperlink atayabilir miyim?**

[Hyperlinks](/slides/tr/androidjava/manage-hyperlinks/) hücrenin metin çerçevesindeki metin (parça) düzeyinde ya da tüm tablo/şekil seviyesinde ayarlanır. Pratikte bağlantıyı bir parçaya ya da hücredeki tüm metne atarsınız.

**Bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (çalıştırmalar) – font ailesi, stil, boyut ve renk – destekler.