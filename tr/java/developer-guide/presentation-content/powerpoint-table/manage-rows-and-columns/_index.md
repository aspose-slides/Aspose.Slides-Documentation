---
title: PowerPoint Tablolarında Satır ve Sütunları Java Kullanarak Yönetme
linktitle: Satır ve Sütunlar
type: docs
weight: 20
url: /tr/java/manage-rows-and-columns/
keywords:
- tablo satırı
- tablo sütunu
- ilk satır
- tablo başlığı
- satırı çoğalt
- sütunu çoğalt
- satırı kopyala
- sütunu kopyala
- satır kaldır
- sütun kaldır
- satır metin biçimlendirmesi
- sütun metin biçimlendirmesi
- tablo stili
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint'te tablo satır ve sütunlarını yönetin ve sunum düzenleme ile veri güncellemelerini hızlandırın."
---
## **Giriş**

Aspose.Slides for Java, PowerPoint sunumlarında tablo yapısını ve biçimlendirmesini [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) sınıfı ve [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) arayüzü aracılığıyla yönetmenizi sağlar. Başlık satırı belirleyebilir, satır ve sütunları kopyalayabilir veya kaldırabilir ve bir satır veya sütunun tamamına metin biçimlendirmesi uygulayabilirsiniz.

Bu makale bu işlemleri Java örnekleriyle açıklar. Ayrıca bir tablonun stil ön ayarını nasıl alacağınızı ve yeniden kullanabileceğinizi gösterir. Tablo satır ve sütun dizinleri sıfır tabanlıdır.

## **Satır Yüksekliğini Kontrol Et**

Bir satırın minimum yüksekliğini puan cinsinden ayarlamak için [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) kullanın. Bu bir alt sınırdır, sabit bir yükseklik değildir. [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) gerçek yüksekliği döndürür. Satıra [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--) aracılığıyla erişin.

Örnek, birinci slayttaki ilk şekil olarak tablo içeren [row-height-input.pptx](row-height-input.pptx) dosyasını yükler. İlk satırı 70 puandan başlar. Hücreler 18 puanlık Arial metin, satır sonu ve 6 puanlık üst ve alt kenar boşlukları kullanır; ikinci sütundaki uzun metin birden çok satıra sarılır. Örnek, minimumu 100 puana yükseltir, ardından 20 puana düşürür, her değişiklikten sonra gerçek yüksekliği yazar ve her iki sonucu kaydeder.

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

Sağlanan sunumda, minimumu artırmak satıra boşluk ekler. Azaltmak ek boşluğu kaldırır, ancak gerçek yükseklik metin ve hücre kenar boşlukları daha fazla alan gerektirdiği için 20 puandan büyük kalır. Minimumu yalnızca azaltmak, satırı içeriğinin gerektirdiği boşluğun altına zorlayamaz.

Gerçek yüksekliği etkileyen birkaç faktör:

- **Metin ve yazı tipi boyutu:** daha uzun metin, açık satır sonları veya daha büyük bir yazı tipi daha fazla dikey alan gerektirebilir.
- **Sarılma ve sütun genişliği:** sarılma etkinleştirildiğinde, [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) ile sütun genişliğini azaltmak daha fazla satır oluşturabilir. Daha geniş bir sütun, dikey olarak gereken alanı azaltabilir.
- **Hücre kenar boşlukları:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) ve [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) dikey alan ekler. [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) ve [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) metin için mevcut genişliği azaltır ve ek sarılmaya neden olabilir.

Birleştirilmiş hücreleri olmayan bu tabloda, en çok dikey alana ihtiyaç duyan hücre, tüm satır için içerik tarafından belirlenen alt sınırı belirler. Satırı kısaltmak için metni kısaltmanız, yazı tipi boyutunu veya kenar boşluklarını azaltmanız veya bir sütunu genişletmeniz gerekebilir.

Altındaki görseller aynı tabloyu aynı ölçekte gösterir. Görselleştirilen sonuçlarda gerçek yükseklikler 70, 100 ve 55,2 puan idi: son satır, 20 puanlık minimumunun üzerinde kaldı. Kesin metin ölçümleri, ortamınızda mevcut yazı tiplerine bağlı olarak değişebilir. Kaydedilen sonuçları indirin: [artırılmış minimum](row-height-increased.pptx) ve [azaltılmış minimum](row-height-decreased.pptx).

| Orijinal: minimum 70 pt, gerçek 70 pt | Artırılmış: minimum 100 pt, gerçek 100 pt | Azaltılmış: minimum 20 pt, gerçek 55.2 pt |
| --- | --- | --- |
| ![İlk satırı 70 puan olan orijinal tablo.](row-height-before.png) | ![İlk satır minimumu 100 puana artırıldıktan sonraki tablo.](row-height-increased.png) | ![İlk satır minimumu 20 puana azaltıldıktan sonraki tablo; sarılmış metin satırı minimumun üzerinde tutar.](row-height-decreased.png) |

## **İlk Satırı Başlık Olarak Ayarla**

İlk satırı başlık biçimlendirmesi için işaretlemek amacıyla [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) metodunu kullanın. Görünümü, tabloya uygulanan tablo stiline bağlıdır.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayta erişin.
3. Slayt üzerindeki ilk şekil olarak depolanmış tabloya erişin.
4. İlk satırı için başlık biçimlendirmesini etkinleştirin.
5. Değiştirilmiş sunumu kaydedin.

Örnek, birinci slayttaki ilk şekil olarak tablo içeren `table.pptx` dosyasını gerektirir. İlk satır için başlık biçimlendirmesini etkinleştirir ve `First_row_header.pptx` dosyasını kaydeder.

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

Satırları veya sütunları kopyalayarak içerik ve biçimlendirmelerini yeniden kullanabilirsiniz. Kopyayı tablonun sonuna ekleyebilir veya belirli bir konuma yerleştirebilirsiniz.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. Tabloyu [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metodu ile ekleyin.
5. Gerekli satırları kopyalayın.
6. Gerekli sütunları kopyalayın.
7. Değiştirilmiş sunumu kaydedin.

Örnek, en az bir slaytı olan `Test.pptx` dosyasını gerektirir. Üç sütun ve beş satır içeren bir tablo oluşturur, boyutlar puan cinsindendir. İlk satır ve sütunun kopyalarını sona ekler, ardından ikinci satır ve sütunun kopyalarını indeks 3'te (dördüncü konum) ekler. Oluşan tablo yedi satır ve beş sütun içerir. `false` argümanı, bitişik birleştirilmiş satır veya sütunlara kopyalamayı devre dışı bırakır; bu tabloda birleşik hücre yoktur.

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

Bir tabloda artık ihtiyaç duymadığınız satır ve sütunları kaldırın. Bir öğeyi kaldırmak, ardından gelen satır veya sütunların dizinlerini kaydırır.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfı ile oluşturun.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. Tabloyu [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metodu ile ekleyin.
5. İkinci satırı ve ikinci sütunu kaldırın.
6. Değiştirilmiş sunumu kaydedin.

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

## **Tablo Satır Düzeyinde Metin Biçimlendirme Ayarla**

Bir satırın tüm hücrelerinde tutarlı kalması için metin biçimlendirmesi uygulayın. Her hücreyi ayrı ayrı biçimlendirmeye gerek kalmadan yazı tipi özellikleri, paragraf biçimlendirmesi ve metin yönünü ayarlayabilirsiniz.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayttaki tabloya erişin.
3. İlk satır için [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) kullanın.
4. İlk satır için [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) ve [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) kullanın.
5. İkinci satır için [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) kullanın.
6. Değiştirilmiş sunumu kaydedin.

Örnek, birinci slayttaki ilk şekil olarak tablo içeren ve en az iki satır bulunan `table.pptx` dosyasını gerektirir. İlk satıra 25 puanlık metin, sağ hizalama ve 20 puanlık sağ paragraf kenar boşluğu uygular, ardından ikinci satıra dikey metin ayarlar.

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

## **Tablo Sütun Düzeyinde Metin Biçimlendirme Ayarla**

Bir sütunun tüm hücrelerinde tutarlı kalması için metin biçimlendirmesi uygulayın. Her hücreyi ayrı ayrı biçimlendirmeye gerek kalmadan yazı tipi özellikleri, paragraf biçimlendirmesi ve metin yönünü ayarlayabilirsiniz.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayttaki tabloya erişin.
3. İlk sütun için [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) kullanın.
4. İlk sütun için [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) ve [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) kullanın.
5. İkinci sütun için [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) kullanın.
6. Değiştirilmiş sunumu kaydedin.

Örnek, birinci slayttaki ilk şekil olarak tablo içeren ve en az iki sütun bulunan `table.pptx` dosyasını gerektirir. İlk sütuna 25 puanlık metin, sağ hizalama ve 20 puanlık sağ paragraf kenar boşluğu uygular, ardından ikinci sütuna dikey metin ayarlar.

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

[ getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) metodunu kullanarak bir tabloya uygulanan ön ayarı alabilir ve başka bir tabloda yeniden kullanabilirsiniz. Bu, bireysel hücre biçimlendirme geçersiz kılmalarından ziyade ön ayarı tanımlar.

Örnek bir tablo oluşturur, [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1) uygular ve ön ayarı geri okur. `DarkStyle1` ile eşleşen tamsayı değerini yazar ve tabloyu `table.pptx` içinde kaydeder.

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

**Varolan bir tabloya PowerPoint temalarını/stillerini uygulayabilir miyim?**

Evet. Tablo, slayt/layout/master temasını devralır ve bu temanın üzerine dolgu, kenarlık ve metin renklerini hâlâ geçersiz kılabilirsiniz.

**Excel'de olduğu gibi tablo satırlarını sıralayabilir miyim?**

Hayır, Aspose.Slides tablolarının yerleşik sıralama veya filtreleme özelliği yoktur. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını bu sırayla yeniden doldurun.

**Belirli hücrelerde özelleştirilmiş renkleri korurken şeritli (bantlı) sütunlar kullanabilir miyim?**

Evet. Şeritli sütunları etkinleştirin, ardından belirli hücreleri yerel biçimlendirme ile geçersiz kılın; hücre seviyesindeki biçimlendirme tablo stiline göre öncelikli olur.