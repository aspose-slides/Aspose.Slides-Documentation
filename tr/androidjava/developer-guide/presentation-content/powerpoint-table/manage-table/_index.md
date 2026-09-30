---
title: Android'de Sunum Tablolarını Yönet
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/androidjava/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tabloya eriş
- en‑boy oranı
- metni hizala
- metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint slaytlarında tablo oluşturun ve düzenleyin. Tablo iş akışlarınızı kolaylaştırmak için basit Java kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki tablolar, bilgiyi satır ve sütunlara ayırarak okumayı ve değerleri karşılaştırmayı kolaylaştırır.

Aspose.Slides, sunularda tablolar oluşturmanıza, güncellemenize ve yönetmenize olanak tanıyan [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/), [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) arabirimi, [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) sınıfı, [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) arabirimi ve diğer türleri sağlar.

## **Sıfırdan Tablo Oluşturma**

Konum, sütun genişlikleri ve satır yükseklikleri belirterek bir tablo oluşturun. Slayta ekledikten sonra hücre kenarlıklarını biçimlendirebilir, hücreleri birleştirebilir ve metin ekleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slayta indeksine göre bir referans alın.
3. Sütun genişliklerini puan cinsinden bir dizi olarak tanımlayın.
4. Satır yüksekliklerini puan cinsinden bir dizi olarak tanımlayın.
5. [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) yöntemiyle slayta bir [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) nesnesi ekleyin.
6. Her bir [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) üzerinden geçerek üst, alt, sağ ve sol kenarlıklara biçimlendirme uygulayın.
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.
8. Birleştirilmiş hücreye [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) yöntemiyle erişin.
9. Birleştirilmiş hücreye metni ayarlayın.
10. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, (100, 50) puanda üç sütun ve beş satır içeren bir tablo oluşturur. 5 puan genişliğinde kırmızı kenarlıklar uygular, ilk satırdaki ilk iki hücreyi birleştirir ve sonucu `table.pptx` olarak kaydeder.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Standart Bir Tablo’da Numaralandırma**

Standart bir tabloda hücre indisleri sıfır tabanlıdır ve (sütun, satır) sırasını kullanır. İlk hücre (0, 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satır içeren bir tablodaki hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu örnek, yukarıda gösterilen 4 × 4 tabloyu, her sütun genişliği ve satır yüksekliği 70 puan olacak şekilde ve 5 puan genişliğinde kırmızı hücre kenarlıklarıyla oluşturur. Koordinatlar hücre indislerini gösterir; örnek hücreleri boş bırakır ve tabloyu `StandardTables_out.pptx` olarak kaydeder.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mevcut Bir Tabloya Erişim**

Tablolar, bir slaydın şekil koleksiyonunda depolanır. Şekilleri dolaşarak bir tablo bulabilir, ardından [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) arabirimini kullanarak hücrelerini okuyabilir veya güncelleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfı ile sunumu yükleyin.
2. Tabloyu içeren slayta indeksine göre bir referans alın.
3. [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) nesnelerini dolaşın ve bir tablo bulunduğunda durun. Slayt birden fazla tablo içeriyorsa, ihtiyacınız olanı belirlemek için [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) metodunu kullanın.
4. Hedef hücredeki metni güncelleyin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek `UpdateExistingTable.pptx` dosyasını açar ve ilk slayttaki ilk tabloyu bulur. Hücreyi (sütun 0, satır 1) `New` olarak ayarlar ve sonucu `table1_out.pptx` olarak kaydeder. Girdi en az bir slayt içermeli ve o slayttaki ilk tablo en az bir sütun ve iki satır barındırmalıdır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Bir mevcut tabloda bir satırı yeniden boyutlandırmak ve gerçek yüksekliğinin talep edilen minimum değeri aşmasının nedenini anlamak için [Control Row Height](/slides/tr/androidjava/manage-rows-and-columns/#control-row-height) belgesine bakın.

## **Bir Metin Çerçevesine Sahip Hücreyi Bulma**

Genel bir metin işleme kodu bir tablodan bir [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) aldığında, ait olduğu [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) nesnesini elde etmek için [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) metodunu kullanın. Bir tablo‑hücre metin çerçevesi için, [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) sahibi döndürürken, [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) `null` döndürür; tablo kendisi bir şekildir.

Hücre koordinatları, yalnızca okunabilir [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) ve [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) metodlarıyla elde edilir. [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) ayrıca yalnızca okunabilir bir gezinme sağlar: sahibi döndürür ancak sahipliği değiştirmez. Kullanımdan önce her zaman döndürülen hücrenin `null` olup olmadığını kontrol edin.

Tablo‑hücre ve şekil sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de içeren tam bir örnek için [Search and Replace Text](/slides/tr/androidjava/search-and-replace-text/) bölümüne bakın.

## **Tablodaki Metni Hizalama**

Bireysel tablo hücrelerinin dikey yerleşimini ve metin yönünü kontrol edebilirsiniz. Bu bölümdeki örnek, ilk hücredeki metni ortalar ve 270 derece döndürür.

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slayta indeksine göre bir referans alın.
3. Slayta bir [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) nesnesi ekleyin.
4. Tablodan bir [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) nesnesine erişin.
5. İlk [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) nesnesine erişin ve metnini ve rengini ayarlayın.
6. Hücrenin dikey yerleşimini ve metin yönünü [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) ve [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) ile ayarlayın.
7. Değiştirilmiş sunumu kaydedin.

Bu örnek, 120 puan sütun genişliği ve 100 puan satır yüksekliği olan 4 × 4 bir tablo oluşturur. (0, 0) hücresindeki metni biçimlendirir, ilk satırdaki kalan hücrelere değerler ekler ve sonucu `Vertical_Align_Text_out.pptx` olarak kaydeder.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Düzeyinde Metin Biçimlendirme Ayarlama**

[setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) kullanarak bir tablodaki tüm hücrelere metin biçimlendirmesi uygulayabilirsiniz. Aşırı yüklemeleri, bölüm, paragraf ve metin çerçevesi biçimlendirmesini kabul eder; böylece bireysel hücreleri dolaşmadan bu özellikleri ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfı ile sunumu yükleyin.
2. Slayta indeksine göre bir referans alın.
3. Slayttan bir [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) nesnesine erişin.
4. Metin için [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) ile yazı tipi boyutunu ayarlayın.
5. Paragraf hizalamasını ve sağ kenar boşluğunu [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) ve [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) ile ayarlayın.
6. Metin yönünü [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) ile ayarlayın.
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek `table.pptx` dosyasını açar; dosya en az bir tablo içeren bir slayt barındırmalıdır. Yazı tipi boyutunu 25 puana, sağa hizalamayı 20 puan sağ kenar boşluğuna ve metni dikeye çevirir. Biçimlendirilmiş sunum `result.pptx` olarak kaydedilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Stili Özelliklerini Alma**

[getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) ile bir tablonun önceden tanımlı stilini okuyabilir ve [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) ile atayabilirsiniz. Bu örnek, bir tabloya [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) uygular, önceden tanımlı değeri yazdırır ve aynı stili ikinci tabloya atar. Her iki tablo da `table-style.pptx` içinde kaydedilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablonun En Boy Oranını Kilitleme**

Bir tablonun en‑boy oranı, genişliğinin yüksekliğine oranıdır. Bu oranı kilitlemek için [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) metodunu kullanın.

Aşağıdaki örnek `pres.pptx` dosyasını açar; dosya en az bir tablo içeren bir slayt barındırmalıdır. Mevcut kilitleme durumunu yazdırır, en‑boy oranı kilidini etkinleştirir, güncellenen durumu (`true`) yazar ve sonucu `pres-out.pptx` olarak kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir tablonun ve hücrelerindeki metnin tamamı için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) metodunu ve paragraflar da [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) metodunu sunar. Her ikisini de kullanmak, hücre içindeki doğru RTL sırasını ve renderlamasını sağlar.

**Kullanıcıların nihai dosyada bir tabloyu hareket ettirmesini veya yeniden boyutlandırmasını nasıl engelleyebilirim?**

Tablolar da dahil olmak üzere şekil kilitleri ([shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/)) kullanarak taşıma, yeniden boyutlandırma, seçme vb. işlemleri devre dışı bırakabilirsiniz.

**Bir hücrenin içinde bir resmi arka plan olarak eklemek destekleniyor mu?**

Evet. Bir hücreye [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) uygulayabilirsiniz; resim, seçilen mod (esnetme veya döşeme) doğrultusunda hücre alanını kaplar.