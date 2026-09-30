---
title: JavaScript'te Sunum Tablolarını Yönetme
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/nodejs-java/manage-table/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Node.js için Aspose.Slides ile PowerPoint slaytlarında tablolar oluşturun ve düzenleyin. Tablo iş akışlarınızı kolaylaştıran basit kod örneklerini keşfedin."
---
## **Introduction**

PowerPoint'teki tablolar bilgileri satır ve sütunlara düzenler, değerleri okumayı ve karşılaştırmayı kolaylaştırır.

Aspose.Slides, [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) sınıfını, [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) sınıfını ve sunumlarda tabloları oluşturmanıza, güncellemenize ve yönetmenize olanak tanıyan diğer türleri sağlar.

## **Create a Table from Scratch**

Konumunu, sütun genişliklerini ve satır yüksekliklerini belirterek bir tablo oluşturun. Slayta ekledikten sonra hücre kenarlıklarını biçimlendirebilir, hücreleri birleştirebilir ve metin ekleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksiyle slayta bir referans alın.  
3. Point cinsinden sütun genişliklerinin bir dizisini tanımlayın.  
4. Point cinsinden satır yüksekliklerinin bir dizisini tanımlayın.  
5. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) yöntemiyle slayta bir [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) nesnesi ekleyin.  
6. Her [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) üzerinde döngü yaparak üst, alt, sağ ve sol kenarlıklara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Birleştirilmiş hücreye [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) yöntemiyle erişin.  
9. Birleştirilmiş hücredeki metni ayarlayın.  
10. Değiştirilen sunumu kaydedin.

Aşağıdaki örnek, (100, 50) point konumunda üç sütun ve beş satırdan oluşan bir tablo oluşturur. Kırmızı kenarlıkları 5 point kalınlıkta uygular, ilk satırdaki ilk iki hücreyi birleştirir ve sonucu `table.pptx` olarak kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numbering in a Standard Table**

Standart bir tabloda hücre indisleri sıfır tabanlıdır ve (sütun, satır) biçiminde kullanılır. İlk hücre (0, 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satırdan oluşan bir tablodaki hücreler aşağıdaki gibi numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu örnek, yukarıda gösterilen 4 × 4 tabloyu, sütun genişlikleri ve satır yükseklikleri 70 point ve kırmızı hücre kenarlıkları 5 point genişliğinde oluşturarak hazırlar. Koordinatlar hücre indekslerini gösterir; örnek hücreleri boş bırakır ve tabloyu `StandardTables_out.pptx` olarak kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Access an Existing Table**

Tablolar bir slaydın şekil koleksiyonunda depolanır. Şekiller arasında döngü yaparak bir tablo bulun, ardından [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) sınıfını kullanarak hücrelerini okuyun veya güncelleyin.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.  
2. İndeksiyle tabloyu içeren slayta bir referans alın.  
3. [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) nesneleri arasında döngü yapın ve bir tablo bulunduğunda durun. Slayt birden fazla tablo içeriyorsa, ihtiyacınız olanı tanımlamak için [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) yöntemini kullanın.  
4. Hedef hücredeki metni güncelleyin.  
5. Değiştirilen sunumu kaydedin.

Aşağıdaki örnek `UpdateExistingTable.pptx` dosyasını açar ve ilk slayttaki ilk tabloyu bulur. Hücreyi sütun 0, satır 1 konumunda `New` olarak ayarlar ve sonucu `table1_out.pptx` olarak kaydeder. Girdi en az bir slayt içermeli ve o slayttaki ilk tablonun en az bir sütun ve iki satırı olmalıdır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Mevcut bir tabloda bir satırı yeniden boyutlandırmak ve gerçek yüksekliğinin istenen minimumu aşmasının nedenini anlamak için [Satır Yüksekliğini Kontrol Et](/slides/tr/nodejs-java/manage-rows-and-columns/#control-row-height) bölümüne bakın.

## **Find the Cell That Owns a Text Frame**

Bir metin çerçevesine sahip hücreyi bulma

Genel metin işleme kodu bir tablodan bir [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) aldığında, sahip [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) i almak için [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) yöntemini kullanın. Bir tablo hücresi metin çerçevesi için, [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) sahibi döndürür ve [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) `null` döndürür, hatta tablo kendisi bir şekil olsa bile.

Hücre koordinatları, sadece okunabilir [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) ve [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) yöntemleriyle elde edilebilir. [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) ayrıca sadece okunabilir bir gezinme sağlar: sahibi döndürür ancak sahipliği değiştirmez. Kullanımdan önce dönen hücrenin `null` olup olmadığını her zaman kontrol edin.

Tablo hücresi ve şekil sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de içeren tam bir örnek için [Metin Arama ve Değiştirme](/slides/tr/nodejs-java/search-and-replace-text/) bölümüne bakın.

## **Align Text in a Table**

Tablodaki metni hizalama

Bireysel tablo hücrelerinin dikey sabitlemesini ve metin yönünü kontrol edebilirsiniz. Bu bölümdeki örnek, ilk hücredeki metni ortalar ve 270 derece döndürür.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksiyle slayta bir referans alın.  
3. Slayta bir [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) nesnesi ekleyin.  
4. Tablodan bir [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) nesnesine erişin.  
5. İlk [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) a erişin ve metnini ve rengini ayarlayın.  
6. Hücrenin dikey sabitlemesini ve metin yönünü [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) ve [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-) kullanarak ayarlayın.  
7. Değiştirilen sunumu kaydedin.

Bu örnek, 120 point sütun genişlikleri ve 100 point satır yükseklikleriyle 4 × 4 bir tablo oluşturur. (0, 0) hücresindeki metni biçimlendirir, ilk satırdaki kalan hücrelere değerler ekler ve sonucu `Vertical_Align_Text_out.pptx` olarak kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set Text Formatting on the Table Level**

Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama

[setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) yöntemini kullanarak bir tablodaki tüm hücrelere metin biçimlendirmesi uygulayın. Aşırı yüklemeleri, parça, paragraf ve metin çerçevesi biçimlendirmesini kabul eder, böylece bireysel hücreler arasında döngü yapmadan bu özellikleri ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.  
2. İndeksiyle slayta bir referans alın.  
3. Slayttan bir [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) nesnesine erişin.  
4. Metin için [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) kullanarak yazı tipi boyutunu ayarlayın.  
5. Paragraf hizalamasını ve sağ kenar boşluğunu [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) ve [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) kullanarak ayarlayın.  
6. Metin yönünü [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) ile ayarlayın.  
7. Değiştirilen sunumu kaydedin.

Aşağıdaki örnek `table.pptx` dosyasını açar; bu dosya en az bir slayt içermeli ve ilk şekli bir tablo olmalıdır. Yazı tipi boyutunu 25 point olarak ayarlar, paragrafları 20 point sağ kenar boşluğu ile sağa hizalar ve metni dikey yapar. Biçimlendirilmiş sunum `result.pptx` olarak kaydedilir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Get Table Style Properties**

Tablo Stil Özelliklerini Almak

[getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) yöntemiyle bir tablonun ön tanımlı stilini okuyun ve [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) ile atayın. Bu örnek, bir tabloya [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) uygular, ön tanımlı değeri yazar ve aynı ön tanımlıyı ikinci bir tabloya atar. Her iki tablo da `table-style.pptx` içinde kaydedilir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lock Aspect Ratio of a Table**

Bir Tablonun En Boy Oranını Kilitleme

Bir tablonun en boy oranı, genişliğinin yüksekliğine oranıdır. Bu oranı bir tablo için kilitlemek üzere [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) yöntemini kullanın.

Aşağıdaki örnek `pres.pptx` dosyasını açar; bu dosya en az bir slayt içermeli ve ilk şekli bir tablo olmalıdır. Mevcut kilit durumunu yazar, en boy oranı kilidini etkinleştirir, güncellenmiş durumu (`true`) yazar ve sonucu `pres-out.pptx` olarak kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bir tablo ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, bir [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) yöntemi sunar ve paragraflar [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-) yöntemine sahiptir. İkisini de kullanmak hücre içindeki doğru RTL sırasını ve renderlamayı sağlar.

**Kullanıcıların final dosyasında tabloyu hareket ettirmesini veya yeniden boyutlandırmasını nasıl engelleyebilirim?**

[şekil kilitleri](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) kullanarak hareket ettirmeyi, yeniden boyutlandırmayı, seçimi vb. devre dışı bırakabilirsiniz. Bu kilitler tablolara da uygulanır.

**Bir hücre içinde arka plan olarak bir resim eklemek destekleniyor mu?**

Evet. Bir hücre için [resim doldurma](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) ayarlayabilirsiniz; resim seçilen moda (esnetme veya döşeme) göre hücre alanını kaplar.