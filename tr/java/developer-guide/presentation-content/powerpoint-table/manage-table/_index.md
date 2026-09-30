---
title: Java'da Sunum Tablolarını Yönetme
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/java/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tabloya eriş
- en boy oranı
- metni hizala
- metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint slaytlarında tablolar oluşturun ve düzenleyin. Tablo iş akışlarınızı basitleştirecek basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki tablolar, bilgileri satır ve sütunlara düzenler, değerleri okumayı ve karşılaştırmayı kolaylaştırır.

Aspose.Slides, [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) sınıfını, [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) arayüzünü, [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) sınıfını, [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) arayüzünü ve sunumlarda tablolar oluşturmanıza, güncellemenize ve yönetmenize olanak tanıyan diğer türleri sağlar.

## **Sıfırdan Bir Tablo Oluşturma**

Pozisyonunu, sütun genişliklerini ve satır yüksekliklerini belirterek bir tablo oluşturun. Slayta ekledikten sonra hücre kenarlıklarını biçimlendirebilir, hücreleri birleştirebilir ve metin ekleyebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre slayta bir referans alın.  
3. Sütun genişliklerinin bir diziğini puan cinsinden tanımlayın.  
4. Satır yüksekliklerinin bir diziğini puan cinsinden tanımlayın.  
5. [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) yöntemiyle slayta bir [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) nesnesi ekleyin.  
6. Her bir [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) üzerinde döngü yaparak üst, alt, sağ ve sol kenarlıklara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Birleştirilmiş hücreye [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) metoduyla erişin.  
9. Birleştirilmiş hücreye metni ayarlayın.  
10. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, (100, 50) puanda üç sütun ve beş satırdan oluşan bir tablo oluşturur. 5 puan genişliğinde kırmızı kenarlıklar uygular, ilk satırdaki ilk iki hücreyi birleştirir ve sonucu `table.pptx` olarak kaydeder.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Standart bir tabloda, hücre indeksleri sıfır tabanlıdır ve (sütun, satır) sırasını kullanır. İlk hücre (0, 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satırdan oluşan bir tabloda hücreler şu şekilde numaralanır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu örnek, yukarıda gösterilen 4 × 4 tabloyu, sütun genişlikleri ve satır yükseklikleri 70 puan ve 5 puan genişliğinde kırmızı hücre kenarlıklarıyla oluşturur. Koordinatlar hücre indekslerini gösterir; örnek hücreleri boş bırakır ve tabloyu `StandardTables_out.pptx` olarak kaydeder.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Mevcut Bir Tabloya Erişme**

Tablolar bir slaydın şekil koleksiyonunda depolanır. Şekilleri dolaşarak bir tablo bulun, ardından hücrelerini okumak veya güncellemek için [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) arayüzünü kullanın.

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.  
2. İndeksine göre tabloyu içeren slayta bir referans alın.  
3. [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) nesnelerini dolaşın ve tablo bulunduğunda durun. Slayt birden fazla tablo içeriyorsa, ihtiyacınız olanı tanımlamak için [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) kullanın.  
4. Hedef hücredeki metni güncelleyin.  
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek `UpdateExistingTable.pptx` dosyasını açar ve ilk slaydın ilk tablosunu bulur. 0. sütun, 1. satır hücresini `New` olarak ayarlar ve sonucu `table1_out.pptx` olarak kaydeder. Girdi en az bir slayt içermeli ve o slayttaki ilk tablo en az bir sütun ve iki satır içermelidir.

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

Bir satırı yeniden boyutlandırmak ve gerçek yüksekliğinin istenen minimumu aşmasının nedenini anlamak için [Satır Yüksekliğini Kontrol Et](/slides/tr/java/manage-rows-and-columns/#control-row-height) bölümüne bakın.

## **Bir Metin Çerçevesine Sahip Hücreyi Bulma**

Genel metin işleme kodu bir tablodan bir [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) aldığında, sahip [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) nesnesini almak için [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) metodunu kullanın. Bir tablo‑hücre metin çerçevesi için [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) sahibi döndürür ve [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) `null` döndürür, tablo kendisi bir şekil olsa bile.

Hücre koordinatları, yalnızca‑okunur [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) ve [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) metodlarıyla elde edilebilir. [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) ayrıca yalnızca‑okunur bir gezinme sağlar: sahibi döndürür ancak sahipliği değiştirmez. Kullanımdan önce dönen hücrenin `null` olup olmadığını her zaman kontrol edin.

Tablo‑hücre ve şekil sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de içeren tam bir örnek için [Metin Arama ve Değiştirme](/slides/tr/java/search-and-replace-text/) bölümüne bakın.

## **Bir Tablo’da Metni Hizalama**

Tek tek tablo hücrelerinin dikey sabitlemesini ve metin yönünü kontrol edebilirsiniz. Bu bölümdeki örnek, ilk hücredeki metni ortalar ve 270 derece döndürür.

1. Bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre slayta bir referans alın.  
3. Slayta bir [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) nesnesi ekleyin.  
4. Tablodan bir [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) nesnesine erişin.  
5. İlk [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) nesnesine erişin ve metnini ve rengini ayarlayın.  
6. Hücrenin dikey sabitlemesini ve metin yönünü [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) ve [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-) kullanarak ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.

Bu örnek, 120 puan sütun genişliği ve 100 puan satır yüksekliği olan 4 × 4 bir tablo oluşturur. (0, 0) hücresindeki metni biçimlendirir, ilk satırdaki kalan hücrelere değer ekler ve sonucu `Vertical_Align_Text_out.pptx` olarak kaydeder.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

[setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) kullanarak bir tablodaki tüm hücrelere metin biçimlendirmesi uygulayabilirsiniz. Aşırı yüklemeleri, bölüm, paragraf ve metin çerçevesi biçimlendirmesini kabul eder, böylece tek tek hücreleri dolaşmadan bu özellikleri ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.  
2. İndeksine göre slayta bir referans alın.  
3. Slayttan bir [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) nesnesine erişin.  
4. Metnin punto boyutunu [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) kullanarak ayarlayın.  
5. Paragraf hizalamasını ve sağ kenar boşluğunu [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) ve [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) kullanarak ayarlayın.  
6. Metin yönünü [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) kullanarak ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, ilk şekli tablo olan en az bir slayt içeren `table.pptx` dosyasını açar. Yazı tipi boyutunu 25 puana, paragrafları 20 puan sağ kenar boşluğuyla sağa hizalar ve metni dikey yapar. Biçimlendirilmiş sunum `result.pptx` olarak kaydedilir.

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

## **Tablo Stil Özelliklerini Almak**

[getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) kullanarak bir tablonun ön tanımlı stilini okuyabilir ve [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) ile atayabilirsiniz. Bu örnek, bir tabloya [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) uygular, ön tanımlı değeri yazar ve aynı ön tanımlıyı ikinci bir tabloya atar. Her iki tablo da `table-style.pptx` içinde kaydedilir.

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

Bir tablonun en boy oranı, genişliğinin yüksekliğine oranıdır. Bu oranı bir tablo için kilitlemek üzere [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) kullanın.

Aşağıdaki örnek, ilk şekli tablo olan en az bir slayt içeren `pres.pptx` dosyasını açar. Mevcut kilit durumunu yazar, en boy oranı kilidini etkinleştirir, güncellenmiş durumu (`true`) yazar ve sonucu `pres-out.pptx` olarak kaydeder.

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

## **FAQ**

**Bir tablonun ve hücrelerindeki metnin tamamı için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-) metodunu sağlar ve paragraflar da [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) metoduna sahiptir. Her ikisini birlikte kullanmak, hücre içindeki doğru RTL sırasını ve rendering'i garanti eder.

**Kullanıcıların final dosyada bir tabloyu taşımasını veya yeniden boyutlandırmasını nasıl engelleyebilirim?**

Sunumda hareket ettirme, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakmak için [shape locks](/slides/tr/java/applying-protection-to-presentation/) kullanın. Bu kilitler tablolar için de geçerlidir.

**Bir hücrenin içinde arka plan olarak bir resim eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) ayarlayabilirsiniz; seçilen mod (germe veya döşeme) göre resim hücre alanını kaplar.