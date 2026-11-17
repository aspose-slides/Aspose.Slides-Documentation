---
title: Java Kullanarak Sunumlarda Tablo Hücrelerini Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/java/manage-cells/
keywords:
- tablo hücresi
- hücreleri birleştir
- kenarlığı kaldır
- hücresi böl
- hücrede resim
- arka plan rengi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java'da PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri tanımlayın, kenarlıkları kaldırın, hücreleri bölün ve Aspose.Slides for Java ile arka plan renkleri ve resimler ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bunları değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücre birleştirme veya bölme sonrasında hücre numaralandırmasını nasıl yöneteceğinizi, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunum oluşturmayı veya açmayı, bir slayttan tablo almayı, hücre özellikleri aracılığıyla hücre biçimlendirmesini güncellemeyi ve değiştirilmiş sunumu PPTX dosyası olarak kaydetmeyi göstermektedir.

Aspose.Slides, tablo hücrelerine erişmek için sıfır‑tabanlı `(sütun, satır)` indekslerini kullanır.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekli tablo olarak erişir. Slayt ve şeklin var olduğunu ve şeklin bir tablo olduğunu varsayar. Ardından tüm satır ve sütunlarda döngü yapar ve [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) kullanarak birleştirilmiş bölgelerdeki hücreleri tanımlar. Her eşleşme için hücre koordinatlarını `row;column` sırasıyla, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), bölgenin başlangıç koordinatlarını [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) ve [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) yazar.

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

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) oluşturun ve ilk slaytına [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) ile bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu nokta biriminde belirtilir. Örnek, dört hücre kenarlığının tamamını [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) yaparak görünmez kılar.

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

[getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) kullanarak sol‑üst köşeden sağ‑alt köşeye bir çizgi çizin ve [getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) ile sol‑alt köşeden sağ‑üst köşeye bir çizgi çizin. Bir çapraz, köşe başlığı işaretleyebilir; iki çapraz bir X oluşturup hücreyi geçerli olmadığını işaretleyebilir.

Her çapraz bir [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) nesnesidir. Bunun [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) içinde [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) ile [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) seçin ve [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) ile bir renk belirleyin. Çizginin kalınlığını [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) ile nokta biriminde ayarlayın.

Örnek, bir satırda üç hücre oluşturur: kırmızı aşağı doğru çapraz, mavi yukarı doğru çapraz ve her iki çapraz. Üst, alt, sol ve sağ kenarlıklar değişmeden kalır.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Çapraz bir biçimlendirme özelliğidir, hücre bölünmesi değildir. Her hücre, [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) aracılığıyla erişilen tek bir metin çerçevesi tutar; çaprazın iki tarafındaki bölgeler bağımsız olarak düzenlenemez.

Kaydedilen tablo, Microsoft PowerPoint'te oluşturulmuş hali:

![Üç tablo hücresi, sol‑üstten sağ‑alta kırmızı bir diagonal, sol‑alta sağ‑üstten mavi bir diagonal ve her iki diagonal X oluşturuyor.](diagonal-cell-borders.png)

*Soldan sağa: aşağı doğru diagonal (kırmızı, 3 pt), yukarı doğru diagonal (mavi, 5 pt) ve her iki diagonal.*

## **Tablo Hücrelerini Birleştirme**

[mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) ile dikdörtgen bir hücre aralığını tek bir hücreye birleştirin. Aralığın sol‑üst ve sağ‑alt köşe hücrelerini belirtin. Son parametre, birleştirmenin belirtilen aralığın dışındaki hücreleri kapsayıp kapsamayacağını kontrol eder; `false` birleştirmenin sadece bu aralıkta kalmasını sağlar.

Örnek, 70 puan genişliğinde sütun ve satırlarla 4×4 bir tablo oluşturur, ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Sonuçta hücre iki sütun ve iki satır yayılır; tablonun temel ızgarası hâlâ dört sütun ve dört satırdır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için üst‑sol konumunu kullanın: bu örnekte `table.get_Item(1, 1)`. Birleştirme aralığı dışındaki konumlar tablo ızgarasının bir parçası olmaya devam eder, bu yüzden dışındaki hücre indeksleri değişmez.

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

Önceki örnekte hücre birleştirme, tablonun ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu ekleyebilir ve sağındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint'in tablo ızgara modelini izler.

Bu örnek, 70 puan sütun ve satırlarla 4×4 bir tablo oluşturur ve `(1, 1)` hücresinde [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) çağırır. Hücrenin 70 puan genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için kullanılır.

Bu bölünmeden sonra iki yarı `table.get_Item(1, 1)` ve `table.get_Item(2, 1)` olarak erişilir. Tablo ızgarası artık beş sütuna sahiptir: orijinal 2 ve 3 numaralı sütunlardaki hücreler sırasıyla 3 ve 4 numaralı sütunlara kayar. Satır indeksleri değişmez. Bölme sonrası hücrelere erişirken bu güncellenmiş sütun indekslerini kullanın.

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
[![Bir birleştirilmemiş 70 puanlık hücre iki 35 puanlık hücreye bölünür, beşinci bir ızgara sütunu eklenir ve sağındaki indeksler kaydırılır.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Genişlik bölünmesi (1, 1) hücresini etkiler, sıfır‑tabanlı (sütun, satır) indeksleri kullanır. Diğer satırlar iki yeni sütun konumunu kapsayan bir hücreyi korur.*
<!-- visual-explanation:manage-cells:end -->

### **Satır veya Sütun Yayılımına Göre Birleştirilmiş Hücreleri Bölme**

Birleştirilmiş şablon hücrelerini veri doldurmak için hazırlarken, mevcut bir satır sınırı boyunca bölmek için [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) ve sütun sınırı boyunca bölmek için [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) kullanın.

`index` parametresi, bölmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; birleştirilmiş bölgeye göredir:

- Satır bölme: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- Sütun bölme: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

Örnek, sunumun ilk slaytındaki ilk şeklin bir tablo olduğunu ve `(1, 2)` ile `(1, 3)` hücrelerinin dikey olarak birleştirildiğini varsayar. Alt konumdan başlayarak, [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) ve [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) ile başlangıç bulunur ve her iki yayılım da kontrol edilir. `splitByRowSpan(1)` ardından satır 2 ve 3'ü ayırarak ürün adlarını ortaya çıkarır. Yatay iki sütun birleştirme için `splitByColSpan(1)` kullanılır.

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

        // Bölme işleminden sonra tablodan oluşan hücreleri al.
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

Tablo ızgarası ve çevredeki hücre indeksleri değişmez. Sonuç hücreleri koordinatlarıyla alın; burada her ikisi de 1 yayılımına sahiptir ve [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) `false` döndürür. Daha büyük bölgeler tek bir bölmeden sonra kısmen birleştirilmiş kalabilir.

Orijinal metin ve biçimlendirme üst (veya sol) hücrede kalır; yeni hücre boştur ancak doldurma, kenarlıklar ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Bölme sonrasında hücreleri doldurun ve gereken metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesini koruyan ayrı “Product A” ve “Product B” hücrelerini içerir. Ayrıntılar için [Hücre API Referansı](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) inceleyin.

### **Belirli Bir Yükseklikte Hücreyi Bölme**

[splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) üst kısmın yüksekliğini puan biriminde alır. [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) üst kısmın mevcut ızgara satır sayısını alır. Sağ sütunda 40 puanluk bir hücreyi ortalamak için hücrenin gerçek yüksekliğinden 40 çıkarılır ve kalan alan eşit olarak üst ve alt bölümlere dağıtılır.

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

İlk bölme bir ızgara satırı ekler ve `(1, 1)` hücresinde alt 90 puanı bırakır. İkinci bölme bu hücreyi orta 40 puanlık bir hücre ve alt 50 puanlık bir hücreye ayırır. Sağ sütun artık üstten alta 50, 40 ve 50 puan yüksekliğinde üç hücreye sahiptir. Sol hücre tüm üç satırı kapsar ve orijinal 140 puan yüksekliğini korur.

![Sol hücre, ortada “Middle” bulunan üç hücrenin yanındaki tüm tablo yüksekliğini kapsar.](split-by-height.png)

## **Tablo Hücresi Arka Plan Rengini Değiştirme**

Bu örnek, 150 puan sütun ve 50 puan satırlarla bir tablo oluşturur. [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) ile katı doldurma seçilir ve [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) tarafından döndürülen renk, `(2, 3)` hücresi için kırmızı olarak ayarlanır; bu, üçüncü sütun ve dördüncü satırdır.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Bir Tablo Hücresine Resim Ekleme**

Bu örneği çalıştırmadan önce giriş görüntüsünü çalışma dizinine yerleştirin. Görüntü, [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) ile yüklenir ve [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) ile sunumun resim koleksiyonuna eklenir. Ardından resim, tablodaki ilk hücre `(0, 0)` için resim doldurmasına atanır.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) resmi hücreyi doldurmak için uzatır; bu, görüntünün en‑boy oranını değiştirebilir. Sütun genişlikleri ve satır yükseklikleri puan birimindedir. Yüklenen görüntü, sunuma eklendikten sonra `finally` bloğunda serbest bırakılır.

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

Evet. [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) kenarlıklarının ayrı özellikleri vardır; bu nedenle her bir kenarın kalınlığı ve stili farklı olabilir.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem görüntü ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Uzatma (stretch) seçilirse görüntü yeni hücreye uyacak şekilde ayarlanır; döşeme (tile) seçilirse döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir köprü (hyperlink) atayabilir miyim?**

[Hyperlinks](/slides/tr/java/manage-hyperlinks/) hücrenin metin çerçevesi içindeki metin (portion) seviyesinde veya tüm tablo/şekil seviyesinde ayarlanır. Pratikte, bağlantıyı bir kısma veya hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (run) biçimlendirmesiyle bağımsız olarak farklı yazı tipleri, stiller, boyutlar ve renkler destekler.