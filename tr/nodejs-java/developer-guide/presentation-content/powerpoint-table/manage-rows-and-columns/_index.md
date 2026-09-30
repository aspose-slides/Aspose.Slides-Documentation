---
title: PowerPoint Tablolarında Satır ve Sütunları JavaScript ile Yönetme
linktitle: Satır ve Sütunlar
type: docs
weight: 20
url: /tr/nodejs-java/manage-rows-and-columns/
keywords:
- tablo satırı
- tablo sütunu
- ilk satır
- tablo başlığı
- satır klonla
- sütun klonla
- satır kopyala
- sütun kopyala
- satır kaldır
- sütun kaldır
- satır metin biçimlendirme
- sütun metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint'te tablo satırlarını ve sütunlarını JavaScript ve Aspose.Slides for Node.js via Java kullanarak yönetin ve sunum düzenleme ve veri güncellemelerini hızlandırın."
---
## **Giriş**

Aspose.Slides for Node.js via Java, PowerPoint sunumlarında tablo yapısı ve biçimlendirmesini [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) sınıfı aracılığıyla yönetmenizi sağlar. Başlık satırı belirleyebilir, satır ve sütunları kopyalayabilir veya kaldırabilir ve bir satır ya da sütunun tamamına metin biçimlendirmesi uygulayabilirsiniz.

Bu makale, bu işlemleri JavaScript örnekleriyle açıklar. Ayrıca bir tablonun stil ön ayarını nasıl alıp yeniden kullanabileceğinizi gösterir. Tablo satır ve sütun indeksleri sıfır‑tabanlıdır.

## **Satır Yüksekliğini Kontrol Et**

[Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) kullanarak bir satırın minimum yüksekliğini puan olarak ayarlayabilirsiniz. Bu bir alt sınırdır, sabit bir yükseklik değildir. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) gerçek yüksekliği döndürür. Satırı, [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--) aracılığıyla erişin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren [row-height-input.pptx](row-height-input.pptx) dosyasını yükler. İlk satırı 70 puanda başlar. Hücreler 18 puan Arial metin, sarmalama ve 6 puan üst‑alt kenar boşluğu kullanır; ikinci sütundaki daha uzun metin birden çok satıra sarmalanır. Örnek, minimumu 100 puana artırır, ardından 20 puana düşürür, her değişiklik sonrası gerçek yüksekliği yazdırır ve her iki sonucu kaydeder.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sağlanan sunumla, minimumu artırmak satıra boşluk ekler. Azaltmak bu ekstra boşluğu kaldırır, ancak gerçek yükseklik 20 puandan büyük kalır çünkü metin ve hücre kenar boşlukları daha fazla alana ihtiyaç duyar. Yalnızca minimumu düşürmek, içeriğin gerektirdiği alandan daha düşük bir satır yüksekliğine zorlayamaz.

Gerçek yüksekliği etkileyen çeşitli faktörler:

- **Metin ve yazı tipi boyutu:** daha uzun metin, açık satır sonları veya daha büyük bir yazı tipi daha fazla dikey alan gerektirebilir.
- **Sarmalama ve sütun genişliği:** sarmalama açıkken, [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) ile sütun genişliğini azaltmak daha çok satır oluşturabilir. Daha geniş bir sütun dikey alana ihtiyaç duyulan boşluğu azaltabilir.
- **Hücre kenar boşlukları:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) ve [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) dikey boşluk ekler. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) ve [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) metin için kullanılabilir genişliği azaltır ve ek sarmalamaya neden olabilir.

Birleştirilmiş hücreleri olmayan bu tablo için, en fazla dikey alana ihtiyaç duyan hücre, tüm satır için içeriğe dayalı alt sınırı belirler. Satırı kısaltmak için metni kısaltmanız, yazı tipi boyutunu veya kenar boşluklarını azaltmanız ya da bir sütunu genişletmeniz gerekebilir.

Aşağıdaki görseller aynı tabloyu aynı ölçekte gösterir. İllüstre edilen sonuçlarda gerçek yükseklikler sırasıyla 70, 100 ve 55,2 puandı: son satır 20 puanlık minimumdan daha yüksek kaldı. Tam metin ölçümleri ortamınızdaki yazı tiplerine göre değişebilir. Kaydedilen sonuçları indirin: [increased minimum](row-height-increased.pptx) ve [decreased minimum](row-height-decreased.pptx).

| Orijinal: minimum 70 pt, gerçek 70 pt | Artırıldı: minimum 100 pt, gerçek 100 pt | Azaltıldı: minimum 20 pt, gerçek 55.2 pt |
| --- | --- | --- |
| ![İlk satırı 70 puan olan orijinal tablo.](row-height-before.png) | ![İlk satır minimumu 100 puana artırıldıktan sonraki tablo.](row-height-increased.png) | ![İlk satır minimumu 20 puana azaltıldıktan sonraki tablo; sarmalanmış metin satırı minimumun üzerindeki yüksekliğinde tutar.](row-height-decreased.png) |

## **İlk Satırı Başlık Olarak Ayarla**

[setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) metodunu kullanarak ilk satırı başlık biçimlendirmesi için işaretleyin. Görünümü, tabloya uygulanan tablo stiline bağlıdır.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfı ile sunumu yükleyin.
2. İlk slayta erişin.
3. Slayttaki ilk şekil olarak depolanan tabloya erişin.
4. İlk satırı için başlık biçimlendirmesini etkinleştirin.
5. Değiştirilmiş sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren `table.pptx` dosyasını gerektirir. İlk satır için başlık biçimlendirmesini etkinleştirir ve `First_row_header.pptx` olarak kaydeder.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Satırını veya Sütununu Kopyala**

Satırları veya sütunları kopyalayarak içerik ve biçimlendirmelerini yeniden kullanabilirsiniz. Kopyayı tablonun sonuna ekleyebilir veya belirli bir konuma ekleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfı ile sunumu yükleyin.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) metodu ile bir tablo ekleyin.
5. Gerekli satırları kopyalayın.
6. Gerekli sütunları kopyalayın.
7. Değiştirilmiş sunumu kaydedin.

Örnek, en az bir slaytı olan `Test.pptx` dosyasını gerektirir. Üç sütun ve beş satır içeren bir tablo oluşturur, boyutları puan cinsindendir. İlk satır ve sütunun kopyalarını sona ekler, ardından ikinci satır ve sütunun kopyalarını 3. indeksde (dördüncü konum) ekler. Sonuçta tablo yedi satır ve beş sütun içerir. `false` argümanı, bitişik birleştirilmiş satır veya sütunlara kopyalama yapılmasını engeller; bu tabloda birleştirilmiş hücre yoktur.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablodan Satır veya Sütun Kaldır**

Artık ihtiyaç duyulmayan satırları veya sütunları bir tablodan kaldırın. Bir öğeyi kaldırmak, ardından gelen satırların veya sütunların indekslerini kaydırır.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfı ile bir sunum oluşturun.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) metodu ile bir tablo ekleyin.
5. İkinci satırı ve ikinci sütunu kaldırın.
6. Değiştirilmiş sunumu kaydedin.

Bu örnek, üç‑üç tablo oluşturur ve indeks 1’deki satır ve sütunu kaldırarak `TestTable_out.pptx` içinde iki‑iki bir tablo bırakır. Boyutlar puan cinsindendir. `false` argümanı, bitişik birleştirilmiş satır veya sütunların kaldırılmasını engeller; bu tabloda birleştirilmiş hücre yoktur.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Satır Seviyesinde Metin Biçimlendirmesini Ayarla**

Tüm bir satıra metin biçimlendirmesi uygulayarak hücrelerin tutarlı kalmasını sağlayın. Yazı tipi özelliklerini, paragraf biçimlendirmesini ve metin yönünü, her hücreyi ayrı ayrı biçimlendirmeden ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfı ile sunumu yükleyin.
2. İlk slayttaki tabloya erişin.
3. İlk satır için [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) metodunu kullanın.
4. İlk satır için [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) ve [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) metodlarını kullanın.
5. İkinci satır için [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) metodunu kullanın.
6. Değiştirilmiş sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren ve en az iki satır bulunan `table.pptx` dosyasını gerektirir. İlk satıra 25 puan metin, sağ hizalama ve 20 puan sağ paragraf kenar boşluğu uygular, ardından ikinci satıra dikey metin ayarlar.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Sütun Seviyesinde Metin Biçimlendirmesini Ayarla**

Tüm bir sütuna metin biçimlendirmesi uygulayarak hücrelerin tutarlı kalmasını sağlayın. Yazı tipi özelliklerini, paragraf biçimlendirmesini ve metin yönünü, her hücreyi ayrı ayrı biçimlendirmeden ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfı ile sunumu yükleyin.
2. İlk slayttaki tabloya erişin.
3. İlk sütun için [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) metodunu kullanın.
4. İlk sütun için [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) ve [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) metodlarını kullanın.
5. İkinci sütun için [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) metodunu kullanın.
6. Değiştirilmiş sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren ve en az iki sütun bulunan `table.pptx` dosyasını gerektirir. İlk sütuna 25 puan metin, sağ hizalama ve 20 puan sağ paragraf kenar boşluğu uygular, ardından ikinci sütuna dikey metin ayarlar.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo Stil Özelliklerini Al**

[getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) metodunu kullanarak bir tabloya uygulanmış ön ayarı alabilir ve başka bir tabloya yeniden uygulayabilirsiniz. Bu, hücre bazında yapılan bireysel biçimlendirme geçersiz kılmalarından ziyade ön ayarı tanımlar.

Örnek bir tablo oluşturur, [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) uygular ve ön ayarı geri okur. `DarkStyle1` ile eşleşen tam sayı değerini yazdırır ve tabloyu `table.pptx` içinde kaydeder.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**PowerPoint temalarını/stillerini zaten oluşturulmuş bir tabloya uygulayabilir miyim?**

Evet. Tablo, slayt/yerleşim/ana tema temasını devralır ve yine de dolgu, kenarlık ve metin renklerini bu temanın üzerinde geçersiz kılabilirsiniz.

**Tablo satırlarını Excel’deki gibi sıralayabilir miyim?**

Hayır, Aspose.Slides tabloları yerleşik sıralama veya filtreleme özelliğine sahip değildir. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını o sıraya göre yeniden doldurun.

**Özel renkli hücreleri korurken şeritli (bantlı) sütunlar oluşturabilir miyim?**

Evet. Şeritli sütunları açın, ardından belirli hücreleri yerel biçimlendirme ile geçersiz kılın; hücre‑seviyesi biçimlendirme tablo stiline göre önceliklidir.