---
title: JavaScript ile Sunum Tablolarını Yönet
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
description: "JavaScript ve Aspose.Slides for Node.js ile PowerPoint slaytlarındaki tabloları oluşturun ve düzenleyin. Tablo iş akışlarınızı kolaylaştırmak için basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'te bir tablo, bilgiyi görüntüleme ve sunma konusunda verimli bir yoldur. Hücrelerden oluşan bir ızgaradaki (satır ve sütunlara düzenlenmiş) bilgi, açık ve anlaşılması kolaydır.

Aspose.Slides, [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) sınıfını, [Cell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cell/) sınıfını ve diğer türleri sağlar; böylece çeşitli sunumlarda tabloları oluşturabilir, güncelleyebilir ve yönetebilirsiniz.

## **Sıfırdan Tablo Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. `columnWidth` dizisini tanımlayın.  
4. `rowHeight` dizisini tanımlayın.  
5. Slayta, [addTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) yöntemiyle bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesi ekleyin.  
6. Her bir [Cell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cell/) üzerinden döngü yaparak üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. [Cell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cell/)'in [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/)’ine erişin.  
9. [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/)’e bazı metinler ekleyin.  
10. Değiştirilmiş sunumu kaydedin.

Bu JavaScript kodu, bir sunumda tablo oluşturma yolunu gösterir:

```javascript
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Slayta bir tablo şekli ekler
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Her hücre için kenarlık biçimini ayarlar
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
    // 1. satırın 1 ve 2. hücrelerini birleştirir
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Birleştirilen hücreye metin ekler
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

Standart bir tabloda, hücrelerin numaralandırması basit ve sıfır tabanlıdır. Bir tabloda ilk hücre 0,0 (sütun 0, satır 0) olarak indekslenir.

Örnek olarak, 4 sütun ve 4 satırdan oluşan bir tabloda hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu JavaScript kodu, bir tablodaki hücrelerin numaralandırmasını nasıl belirteceğinizi gösterir:

```javascript
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Slayta bir tablo şekli ekler
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Her hücre için kenarlık biçimini ayarlar
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

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Tabloyu içeren slayta indeks üzerinden bir referans alın.  
3. [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesi oluşturun ve null olarak ayarlayın.  
4. Tablo bulunana kadar tüm [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) nesneleri üzerinde döngü yapın.  

   Eğer üzerinde çalıştığınız slaydın tek bir tablo içerdiğini düşünüyorsanız, içerdiği tüm şekilleri basitçe kontrol edebilirsiniz. Bir şekil tablo olarak tanımlandığında, onu bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesi olarak tip dönüştürebilirsiniz. Ancak slayt birden fazla tablo içeriyorsa, ihtiyacınız olan tabloyu [setAlternativeText(String value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) yöntemiyle aramanız daha iyi olur.  

5. [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesini tabloyla çalışmak için kullanın. Aşağıdaki örnekte, tabloya yeni bir satır ekledik.  
6. Değiştirilmiş sunumu kaydedin.

Bu JavaScript kodu, mevcut bir tabloya nasıl erişileceğini ve onunla nasıl çalışılacağını gösterir:

```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // null TableEx'i başlatır
    var tbl = null;
    // Şekilleri döngüyle gezerek bulunan tabloya bir referans atar
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // İkinci satırın ilk sütunu için metni ayarlar
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

## **Tablodaki Metni Hizalama**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. Slayta bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesi ekleyin.  
4. Tablodan bir [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) nesnesine erişin.  
5. [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) içindeki [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/)’e erişin.  
6. Metni dikey olarak hizalayın.  
7. Değiştirilmiş sunumu kaydedin.

Bu JavaScript kodu, bir tablodaki metni nasıl hizalayacağınızı gösterir:

```javascript
// Presentation sınıfının bir örneğini oluşturur
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı alır
    var slide = pres.getSlides().get_Item(0);
    // Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Tablo şekli slayta eklenir
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
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Sunumu diske kaydeder
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. Slayttan bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesine erişin.  
4. Metin için [setFontHeight(float value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) ayarlayın.  
5. [setAlignment(int value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) ve [setMarginRight(float value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) ayarlarını yapın.  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.

Bu JavaScript kodu, bir tablodaki metne tercih ettiğiniz biçimlendirme seçeneklerini nasıl uygulayacağınızı gösterir:

```javascript
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
    // Tablo hücrelerinin metin dikey tipini ayarlar
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablo Stil Özelliklerini Almak**

Aspose.Slides, bir tablonun stil özelliklerini almanıza olanak tanır; bu detayları başka bir tablo veya farklı bir yerde kullanabilirsiniz. Bu JavaScript kodu, bir tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// varsayılan stil ön ayar temasını değiştir
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablonun En‑Boy Oranını Kilitleme**

Geometrik bir şeklin en‑boy oranı, farklı boyutlardaki ölçülerin oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en‑boy oranı kilitleme ayarını sağlayan [**setAspectRatioLocked**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) özelliğini sunar.

Bu JavaScript kodu, bir tablonun en‑boy oranını nasıl kilitleyeceğinizi gösterir:

```javascript
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

**Tüm tablo ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, bir [setRightToLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/table/setrighttoleft/) metodunu sunar ve paragraflar [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) metoduna sahiptir. İkisini birlikte kullanmak, hücre içindeki doğru RTL sırasını ve renderlemeyi sağlar.

**Kullanıcıların final dosyada tabloyu hareket ettirmesini veya yeniden boyutlandırmasını nasıl engelleyebilirim?**

Hareket, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakmak için şekil kilitlerini kullanın. Bu kilitler tabloya da uygulanır.

**Bir hücreye arka plan olarak resim eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/) ayarlayabilirsiniz; seçilen moda göre (germe veya döşeme) görüntü hücre alanını kaplar.