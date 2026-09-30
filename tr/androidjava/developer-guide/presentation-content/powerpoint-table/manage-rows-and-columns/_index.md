---
title: Android'de PowerPoint Tablolarındaki Satır ve Sütunları Yönetme
linktitle: Satır ve Sütunlar
type: docs
weight: 20
url: /tr/androidjava/manage-rows-and-columns/
keywords:
- tablo satırı
- tablo sütunu
- ilk satır
- tablo başlığı
- satır kopyala
- sütun kopyala
- satır kopyala
- sütun kopyala
- satır kaldır
- sütun kaldır
- satır metin biçimlendirmesi
- sütun metin biçimlendirmesi
- tablo stili
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint'te tablo satırlarını ve sütunlarını yönetin ve sunum düzenleme ve veri güncellemelerini hızlandırın."
---
## **Giriş**

Aspose.Slides for Android via Java, PowerPoint sunumlarında tablo yapısını ve biçimlendirmesini [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) sınıfı ve [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) arayüzü aracılığıyla yönetmenizi sağlar. Bir başlık satırı belirleyebilir, satır ve sütunları kopyalayabilir veya kaldırabilir ve bir bütün satır veya sütuna metin biçimlendirmesi uygulayabilirsiniz.

Bu makale, bu işlemleri Java örnekleriyle açıklar. Ayrıca, bir tablonun stil ön ayarını nasıl alıp yeniden kullanabileceğinizi gösterir. Tablo satır ve sütun dizinleri sıfır tabanlıdır.

## **Satır Yüksekliğini Kontrol Et**

Bir satırın minimum yüksekliğini puan cinsinden ayarlamak için [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) kullanın. Bu, sabit bir yükseklik değil, alt bir sınırlamadır. [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) gerçek yüksekliği döndürür. Satıra, [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--) aracılığıyla erişin.

Örnek, ilk slaydın ilk şekli olarak bir tablo içeren [row-height-input.pptx](row-height-input.pptx) dosyasını yükler. İlk satırı 70 puandan başlar. Hücreler 18 puanlık Arial metin, kaydırma ve 6 puanlık üst ve alt kenar boşlukları kullanır; ikinci sütundaki daha uzun metin birden fazla satıra kayar. Örnek, minimumu 100 puana artırır, ardından 20 puana düşürür, her değişiklikten sonra gerçek yüksekliği yazdırır ve her iki sonucu da kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sağlanan sunumla, minimumun artırılması satıra boşluk ekler. Minimumun azaltılması bu fazla boşluğu kaldırır, ancak gerçek yükseklik 20 puandan büyük kalır çünkü metin ve hücre kenar boşlukları daha fazla alan gerektirir. Sadece minimumu azaltmak, içeriğin gerektirdiği boşluktan daha düşük bir satır yüksekliğini zorlayamaz.

Gerçek yüksekliği etkileyen çeşitli faktörler şunlardır:

- **Metin ve yazı tipi boyutu:** daha uzun metin, açık satır sonları veya daha büyük bir yazı tipi daha fazla dikey alan gerektirebilir.
- **Satır kaydırma ve sütun genişliği:** kaydırma etkinleştirildiğinde, [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) ile sütun genişliğini azaltmak daha fazla satır üretebilir. Daha geniş bir sütun, dikey olarak gereken alanı azaltabilir.
- **Hücre kenar boşlukları:** [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) ve [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) dikey boşluk ekler. [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) ve [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) metin için kullanılabilir genişliği azaltır ve ek kaydırmaya neden olabilir.

Birleştirilmiş hücreleri olmayan bu tablo için, en çok dikey alan gerektiren hücre, tüm satır için içeriğe dayalı alt sınırlamayı belirler. Satırı kısaltmak için metni kısaltmanız, yazı tipi boyutunu veya kenar boşluklarını azaltmanız veya bir sütunu genişletmeniz gerekebilir.

Aşağıdaki görseller aynı tabloyu aynı ölçekte gösterir. Görsel sonuçlarda gerçek yükseklikler 70, 100 ve 55,2 puan idi: son satır 20 puanlık minimumundan daha yüksek kaldı. Metin ölçümleri, ortamınızda bulunan yazı tiplerine göre değişebilir. Kaydedilen sonuçları indirin: [increased minimum](row-height-increased.pptx) ve [decreased minimum](row-height-decreased.pptx).

| Orijinal: minimum 70 pt, gerçek 70 pt | Artırıldı: minimum 100 pt, gerçek 100 pt | Azaltıldı: minimum 20 pt, gerçek 55.2 pt |
| --- | --- | --- |
| ![Orijinal tablo, 70 puanlık ilk satırla.](row-height-before.png) | ![İlk satır minimumu 100 puana artırıldıktan sonraki tablo.](row-height-increased.png) | ![İlk satır minimumu 20 puana düşürüldükten sonraki tablo; kaydırılmış metin satırı minimumdan daha yüksek tutar.](row-height-decreased.png) |

## **İlk Satırı Başlık Olarak Ayarla**

İlk satırı başlık biçimlendirmesi için işaretlemek amacıyla [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) yöntemini kullanın. Görünümü, tabloya uygulanan tablo stiline bağlıdır.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayta erişin.
3. Slayttaki ilk şekil olarak saklanan tabloya erişin.
4. İlk satırı için başlık biçimlendirmesini etkinleştirin.
5. Değiştirilen sunumu kaydedin.

Örnek, ilk slaydın ilk şekli olarak bir tablo içeren `table.pptx` dosyasını gerektirir. İlk satır için başlık biçimlendirmesini etkinleştirir ve `First_row_header.pptx` dosyasını kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Tablo Satırını veya Sütununu Kopyala**

Satırları veya sütunları, içerik ve biçimlendirmelerini yeniden kullanmak için kopyalayın. Kopyayı tablonun sonuna ekleyebilir veya belirli bir konuma ekleyebilirsiniz.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) yöntemiyle bir tablo ekleyin.
5. Gerekli satırları kopyalayın.
6. Gerekli sütunları kopyalayın.
7. Değiştirilen sunumu kaydedin.

Örnek, en az bir slaytı olan `Test.pptx` dosyasını gerektirir. Üç sütun ve beş satır içeren bir tablo oluşturur, boyutlar puan cinsindendir. İlk satır ve sütunun kopyalarını ekler, ardından ikinci satır ve sütunun kopyalarını indeks 3'te (dördüncü konum) ekler. Sonuçta tablo yedi satır ve beş sütun olur. `false` argümanı, bitişik birleştirilmiş satır veya sütunlara kopyalamayı devre dışı bırakır; bu tabloda birleşik hücre yoktur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Tablodan Satır veya Sütun Kaldır**

Tabloda artık ihtiyaç duyulmayan satırları veya sütunları kaldırın. Bir öğeyi kaldırmak, ardından gelen satır veya sütunların dizinlerini kaydırır.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfı ile oluşturun.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliğini tanımlayın.
4. [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) yöntemiyle bir tablo ekleyin.
5. İkinci satırı ve ikinci sütunu kaldırın.
6. Değiştirilen sunumu kaydedin.

Bu örnek, üçe üç bir tablo oluşturur ve indeks 1'deki satır ve sütunu kaldırarak `TestTable_out.pptx` içinde ikiye iki bir tablo bırakır. Boyutlar puan cinsindendir. `false` argümanı, bitişik birleştirilmiş satır veya sütunların kaldırılmasını devre dışı bırakır; bu tabloda birleşik hücre yoktur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Satır Düzeyinde Metin Biçimlendirmesini Ayarla**

Bir tüm satıra metin biçimlendirmesi uygulayarak hücrelerinin tutarlı kalmasını sağlayın. Her hücreyi ayrı ayrı biçimlendirmeye gerek kalmadan yazı tipi özelliklerini, paragraf biçimlendirmesini ve metin yönünü ayarlayabilirsiniz.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayttaki tabloya erişin.
3. İlk satır için [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) kullanın.
4. İlk satır için [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) ve [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) kullanın.
5. İkinci satır için [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) kullanın.
6. Değiştirilen sunumu kaydedin.

Örnek, ilk slaydın ilk şekli olarak bir tablo içeren ve en az iki satırı olan `table.pptx` dosyasını gerektirir. İlk satıra 25 puanlık metin, sağ hizalama ve 20 puanlık sağ paragraf kenar boşluğu uygular, ardından ikinci satıra dikey metin ayarlar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Sütun Düzeyinde Metin Biçimlendirmesini Ayarla**

Bir tüm sütuna metin biçimlendirmesi uygulayarak hücrelerinin tutarlı kalmasını sağlayın. Her hücreyi ayrı ayrı biçimlendirmeye gerek kalmadan yazı tipi özelliklerini, paragraf biçimlendirmesini ve metin yönünü ayarlayabilirsiniz.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayttaki tabloya erişin.
3. İlk sütun için [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) kullanın.
4. İlk sütun için [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) ve [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) kullanın.
5. İkinci sütun için [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) kullanın.
6. Değiştirilen sunumu kaydedin.

Örnek, ilk slaydın ilk şekli olarak bir tablo içeren ve en az iki sütunu olan `table.pptx` dosyasını gerektirir. İlk sütuna 25 puanlık metin, sağ hizalama ve 20 puanlık sağ paragraf kenar boşluğu uygular, ardından ikinci sütuna dikey metin ayarlar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Stil Özelliklerini Al**

Bir tabloya uygulanan stil ön ayarını almak ve başka bir tabloda yeniden kullanmak için [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) yöntemini kullanın. Bu, bireysel hücre biçimlendirme geçersiz kılmalarından ziyade ön ayarı tanımlar.

Örnek bir tablo oluşturur, [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1) uygular ve ön ayarı geri okur. `DarkStyle1` değerine karşılık gelen tam sayı değerini yazdırır ve tabloyu `table.pptx` içinde kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Varolan bir tabloya PowerPoint temaları/stilleri uygulayabilir miyim?**  
Evet. Tablo, slayt/layout/ana tema miras alır ve yine de bu temanın üzerine dolgu, kenarlık ve metin renklerini geçersiz kılabilirsiniz.

**Excel'de olduğu gibi tablo satırlarını sıralayabilir miyim?**  
Hayır, Aspose.Slides tablolarında yerleşik sıralama veya filtreleme özelliği yoktur. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını o sırayla yeniden doldurun.

**Belirli hücrelerde özel renkler tutarken şeritli (banded) sütunlar oluşturabilir miyim?**  
Evet. Şeritli sütunları etkinleştirin, ardından belirli hücreleri yerel biçimlendirme ile geçersiz kılın; hücre seviyesindeki biçimlendirme tablo stiline göre öncelikli olur.