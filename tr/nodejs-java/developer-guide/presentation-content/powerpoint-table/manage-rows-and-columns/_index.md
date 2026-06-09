---
title: JavaScript Kullanarak PowerPoint Tablolarında Satır ve Sütunları Yönetme
linktitle: Satırlar ve Sütunlar
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
description: "JavaScript ve Aspose.Slides for Node.js kullanarak PowerPoint'te tablo satırlarını ve sütunlarını yönetin, Java üzerinden sunum düzenlemeyi ve veri güncellemelerini hızlandırın."
---
## **Giriş**

PowerPoint sunumunda bir tablonun satır ve sütunlarını yönetmenizi sağlamak için Aspose.Slides, [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/table/) sınıfı ve diğer tipleri sağlar.

## **İlk Satırı Başlık Olarak Ayarla**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturun ve sunumu yükleyin.
2. İndeks aracılığıyla bir slaytın referansını alın. 
3. [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesi oluşturun ve onu null olarak ayarlayın.
4. İlgili tabloyu bulmak için tüm [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) nesneleri arasında döngü yapın.
5. Tablonun ilk satırını başlık olarak ayarlayın. 

Bu JavaScript kodu, bir tablonun ilk satırını başlık olarak nasıl ayarlayacağınızı gösterir:

```javascript
// Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // İlk slaytı erişir
    var sld = pres.getSlides().get_Item(0);
    // null TableEx'i başlatır
    var tbl = null;
    // Şekiller arasında döngü yapar ve tabloya referans ayarlar
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Bir tablonun ilk satırını başlık olarak ayarlar
            tbl.setFirstRow(true);
        }
    }
    // Sunumu diske kaydeder
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablonun Satırını veya Sütununu Kopyala**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturun ve sunumu yükleyin,
2. İndeks aracılığıyla bir slaytın referansını alın. 
3. `columnWidth` dizisini tanımlayın.
4. `rowHeight` dizisini tanımlayın.
5. [addTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) yöntemi aracılığıyla slayta bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesi ekleyin.
6. Tablo satırını kopyalayın.
7. Tablo sütununu kopyalayın.
8. Değiştirilmiş sunumu kaydedin.

Bu JavaScript kodu, bir PowerPoint tablosunun satırını veya sütununu nasıl kopyalayacağınızı gösterir:

```javascript
// Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Sütunları genişlikleriyle ve satırları yükseklikleriyle tanımlar
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Slayta bir tablo şekli ekler
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Satır 1 hücre 1'e bir metin ekler
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Satır 1 hücre 2'ye bir metin ekler
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Satır 1'i tablonun sonuna klonlar
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Satır 2 hücre 1'e bir metin ekler
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Satır 2 hücre 2'ye bir metin ekler
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Satır 2'yi tablonun 4. satırı olarak klonlar
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // İlk sütunu sonuna klonlar
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // 2. sütunu 4. sütun indeksine klonlar
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Sunumu diske kaydeder
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablodan Satır veya Sütun Kaldır**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturun ve sunumu yükleyin,
2. İndeks aracılığıyla bir slaytın referansını alın. 
3. `columnWidth` dizisini tanımlayın.
4. `rowHeight` dizisini tanımlayın.
5. [addTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) yöntemi aracılığıyla slayta bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesi ekleyin.
6. Tablo satırını kaldırın.
7. Tablo sütununu kaldırın.
8. Değiştirilmiş sunumu kaydedin. 

Bu JavaScript kodu, bir tablodan satır veya sütun nasıl kaldırılacağını gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablo Satır Düzeyinde Metin Biçimlendirmesini Ayarla**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturun ve sunumu yükleyin,
2. İndeks aracılığıyla bir slaytın referansını alın. 
3. Slayttan ilgili [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesine erişin.
4. İlk satır hücrelerinin [setFontHeight(float value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) ayarını yapın.
5. İlk satır hücrelerinin [setAlignment(int value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) ve [setMarginRight(float value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) ayarlarını yapın.
6. İkinci satır hücrelerinin [setTextVerticalType(byte value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) ayarını yapın.
7. Değiştirilmiş sunumu kaydedin.

Bu JavaScript kodu işlemi gösterir.

```javascript
// Presentation sınıfının bir örneğini oluşturur
var pres = new aspose.slides.Presentation();
try {
    // İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // İlk satır hücrelerinin yazı tipi yüksekliğini ayarlar
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // İlk satır hücrelerinin metin hizalamasını ve sağ kenar boşluğunu ayarlar
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // İkinci satır hücrelerinin metin dikey tipini ayarlar
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Sunumu diske kaydeder
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablo Sütun Düzeyinde Metin Biçimlendirmesini Ayarla**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturun ve sunumu yükleyin,
2. İndeks aracılığıyla bir slaytın referansını alın. 
3. Slayttan ilgili [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Table) nesnesine erişin.
4. İlk sütun hücrelerinin [setFontHeight(float value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) ayarını yapın.
5. İlk sütun hücrelerinin [setAlignment(int value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) ve [setMarginRight(float value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) ayarlarını yapın.
6. İkinci sütun hücrelerinin [setTextVerticalType(byte value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) ayarını yapın.
7. Değiştirilmiş sunumu kaydedin. 

Bu JavaScript kodu işlemi gösterir:

```javascript
// Presentation sınıfının bir örneğini oluşturur
var pres = new aspose.slides.Presentation();
try {
    // İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // İlk sütun hücrelerinin yazı tipi yüksekliğini ayarlar
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // İlk sütun hücrelerinin metin hizalamasını ve sağ kenar boşluğunu tek bir çağrıda ayarlar
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // İkinci sütun hücrelerinin metin dikey tipini ayarlar
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablo Stil Özelliklerini Al**

Aspose.Slides, bir tablonun stil özelliklerini almanıza olanak tanır, böylece bu ayrıntıları başka bir tablo ya da başka bir yerde kullanabilirsiniz. Bu JavaScript kodu, bir tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir:

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

## **SSS**

**Bir tabloya zaten oluşturulmuş bir PowerPoint teması/stili uygulayabilir miyim?**

Evet. Tablo, slayt/düzen/ana tema mirasını alır ve bu temanın üzerine dolgu, kenarlık ve metin renklerini hâlâ geçersiz kılabilirsiniz.

**Tablo satırlarını Excel gibi sıralayabilir miyim?**

Hayır, Aspose.Slides tabloları yerleşik sıralama veya filtreleme özelliğine sahip değildir. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını bu sırayla yeniden doldurun.

**Belirli hücrelere özel renkler verirken, şeritli (bantlı) sütunlar elde edebilir miyim?**

Evet. Bantlı sütunları etkinleştirin, ardından belirli hücreleri yerel biçimlendirme ile geçersiz kılın; hücre düzeyindeki biçimlendirme tablo stiline göre önceliklidir.