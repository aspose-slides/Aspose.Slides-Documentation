---
title: JavaScript ile Sunum Tablolarını Yönetme
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/nodejs-java/manage-table/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js kullanarak PowerPoint slaytlarında tablolar oluşturun ve düzenleyin. Tablo işlemlerinizi kolaylaştırmak için basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki bir tablo, bilgiyi görüntülemenin ve sunmanın etkili bir yoludur. Hücrelerden oluşan bir ızgaradaki (satır ve sütunlara düzenlenmiş) bilgiler doğrudan ve anlaşılması kolaydır.

Aspose.Slides, [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) sınıfı, [Cell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cell/) sınıfı ve tabloları her türlü sunumda oluşturmanıza, güncellemenize ve yönetmenize olanak sağlayan diğer türleri sağlar.

## **Sıfırdan Tablo Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksine göre alın.  
3. `columnWidth` dizisini tanımlayın.  
4. `rowHeight` dizisini tanımlayın.  
5. Slayta, [addTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) yöntemiyle bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesi ekleyin.  
6. Her bir [Cell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cell/) üzerinde dolaşarak üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun sol üst köşesindeki dört hücreyi (ilk iki satırın ilk iki sütunu) tek bir hücreye birleştirin.  
8. Bir [Cell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cell/)'in [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin.  
9. [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/)’e bir metin ekleyin.  
10. Değiştirilmiş sunumu kaydedin.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX dosyasını temsil eden bir Presentation sınıfı örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Genişlikleriyle sütunları ve yükseklikleriyle satırları tanımlar
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Slayta bir tablo şekli ekler
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Her hücrenin kenar biçimini ayarlar
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Sol üstteki 2x2 hücre bloğunu tek hücreye birleştirir
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Birleştirilen hücreye bazı metin ekler
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Sunumu diske kaydeder
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Standart Tablo Numaralandırması**

Standart bir tabloda hücrelerin numaralandırması doğrudan ve sıfır tabanlıdır. Bir tablodaki ilk hücre 0,0 (sütun 0, satır 0) olarak indekslenir.  

Örneğin, 4 sütun ve 4 satır içeren bir tablodaki hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu JavaScript kodu, bir tablodaki hücreler için numaralandırmanın nasıl belirtileceğini gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX dosyasını temsil eden bir Presentation sınıfı örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Genişlikleriyle sütunları ve yükseklikleriyle satırları tanımlar
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Slayta bir tablo şekli ekler
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Her hücre için kenar biçimini ayarlar
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Sunumu diske kaydeder
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mevcut Tabloya Erişim**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Tabloyu içeren slayta indeksine göre bir referans alın.  
3. Bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesi oluşturun ve null olarak ayarlayın.  
4. Tablo bulunana kadar tüm [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) nesneleri üzerinde döngü yapın.  
   Eğer üzerinde çalıştığınız slaydın tek bir tablo içerdiğini düşünüyorsanız, içindeki tüm şekilleri basitçe kontrol edebilirsiniz. Bir şekil tablo olarak tanımlandığında, onu bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesi olarak tip dönüştürebilirsiniz. Ancak slayt birden fazla tablo içeriyorsa, ihtiyacınız olan tabloyu [setAlternativeText(String value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) yöntemiyle aramanız daha iyidir.  
5. Tabloyla çalışmak için [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesini kullanın. Aşağıdaki örnekte, tablodaki bir hücrenin metnini ayarlıyoruz.  
6. Değiştirilmiş sunumu kaydedin.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // null TableEx'i başlatır
    var tbl = null;
    // Şekiller üzerinde döner ve bulunan tabloya bir referans ayarlar
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // İkinci satırın birinci sütunu için metni ayarlar
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Değiştirilmiş sunumu diske kaydeder
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bir Metin Çerçevesine Sahip Hücreyi Bulma**

Genel bir metin işleme kodu bir tablodan [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) aldığında, sahip olduğu [Cell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cell/) nesnesini almak için [TextFrame.getParentCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentCell--) yöntemini kullanın. Bir tablo hücresi metin çerçevesi için, [TextFrame.getParentCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentCell--) sahibi döndürür ve [TextFrame.getParentShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentShape--) `null` döndürür, tablo kendisi bir şekil olsa bile.  

Hücre koordinatları, yalnızca okunabilir [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) ve [Cell.getFirstRowIndex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) yöntemleriyle elde edilir. [TextFrame.getParentCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentCell--) aynı zamanda yalnızca okunabilir bir gezinme sağlar: sahibi döndürür ancak sahipliği değiştirmez. Kullanımdan önce dönen hücrenin `null` olup olmadığını her zaman kontrol edin.  

SmartArt düğümleriyle ilişkili şekilleri de içeren tablo hücresi ve şekil sahiplerini belirten eksiksiz bir örnek için [Search and Replace Text](/slides/tr/nodejs-java/search-and-replace-text/) sayfasına bakın.

## **Tabloda Metni Hizalama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksine göre alın.  
3. Slayta bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesi ekleyin.  
4. Tablodan bir [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) nesnesine erişin.  
5. [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) içerisindeki [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) öğesine erişin.  
6. Metni dikey olarak hizalayın.  
7. Değiştirilmiş sunumu kaydedin.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation sınıfının bir örneğini oluşturur
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı alır
    var slide = pres.getSlides().get_Item(0);
    // Genişlikleriyle sütunları ve yükseklikleriyle satırları tanımlar
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Tablo şeklini slayta ekler
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Metin çerçevesine erişir
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Metin çerçevesi için Paragraph nesnesi oluşturur
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Paragraf için Portion nesnesi oluşturur
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Metni dikey olarak hizalar
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // Sunumu diske kaydeder
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksine göre alın.  
3. Slayttan bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesine erişin.  
4. Metin için [setFontHeight(float value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) metodunu ayarlayın.  
5. [setAlignment(int value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) ve [setMarginRight(float value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) metodlarını ayarlayın.  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) metodunu ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.  

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation sınıfının bir örneğini oluşturur
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Tablo hücrelerinin yazı tipi yüksekliğini ayarlar
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Tablo hücrelerinin metin hizalamasını ve sağ kenar boşluğunu tek bir çağrıda ayarlar
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Tablo hücrelerinin metin dikey türünü ayarlar
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablo Stil Ön Ayarını Belirleme**

Aspose.Slides, yerleşik PowerPoint tablo stillerini [TableStylePreset](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tablestylepreset/) sayımı olarak sunar, böylece aynı görünümü herhangi bir tabloya uygulayabilirsiniz. Bu JavaScript kodu, bir tablonun varsayılan stilini ön ayar stiliyle nasıl değiştireceğinizi gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// varsayılan stil ön ayarı temasını değiştirir
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablonun En–Boy Oranını Kilitleme**

Geometrik bir şeklin en–boy oranı, farklı boyutlardaki ölçülerinin oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en–boy oranı kilitleme ayarını sağlayan [**setAspectRatioLocked**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) özelliğini sunar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Bir tablonun tamamı ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, [setRightToLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/table/setrighttoleft/) yöntemini, paragraflar ise [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) yöntemini sağlar. Her ikisinin kullanılması, hücre içindeki doğru RTL sırasını ve render'ı garantiler.

**Kullanıcıların son dosyada bir tabloyu taşımasını veya yeniden boyutlandırmasını nasıl engelleyebilirim?**

Taşıma, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakmak için şekil kilitlerini kullanın. Bu kilitler tabloya da uygulanır.

**Bir hücrenin içinde görüntüyü arka plan olarak eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/) ayarlayabilirsiniz; görüntü, seçilen moda (germe veya döşeme) göre hücre alanını kaplar.