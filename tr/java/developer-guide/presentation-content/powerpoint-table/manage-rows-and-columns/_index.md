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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint'te tablo satır ve sütunlarını yönetin ve sunum düzenleme ve veri güncellemelerini hızlandırın."
---
## **Giriş**

PowerPoint sunumunda bir tablonun satır ve sütunlarını yönetebilmeniz için Aspose.Slides, [Table](https://reference.aspose.com/slides/tr/java/com.aspose.slides/table/) sınıfı, [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) arayüzü ve birçok diğer türü sağlar. 

## **İlk Satırı Başlık Olarak Ayarla**

1. Sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun. 
2. Slaytın referansını indeksini kullanarak alın. 
3. [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) nesnesi oluşturun ve null olarak ayarlayın. 
4. İlgili tabloyu bulmak için tüm [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) nesneleri arasında döngü yapın. 
5. Tablo'nun ilk satırını başlık olarak ayarlayın. 

Bu Java kodu, bir tablonun ilk satırını başlık olarak nasıl ayarlayacağınızı gösterir:

```java
// Presentation sınıfını örnekler
Presentation pres = new Presentation("table.pptx");
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // null TableEx'i başlatır
    ITable tbl = null;

    // Şekilleri iterasyonla dolaşır ve tabloya bir referans ayarlar
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Tablonun ilk satırını başlık olarak ayarlar
            tbl.setFirstRow(true);
        }
    }
    
    // Sunumu diske kaydeder
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Bir Tablo Satırını veya Sütununu Kopyala**

1. Sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun, 
2. Slaytın referansını indeksini kullanarak alın. 
3. `columnWidth` dizisini tanımlayın. 
4. `rowHeight` dizisini tanımlayın. 
5. [addTable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metodunu kullanarak slayta bir [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) nesnesi ekleyin. 
6. Tablo satırını kopyalayın. 
7. Tablo sütununu kopyalayın. 
8. Değiştirilmiş sunumu kaydedin. 

Bu Java kodu, bir PowerPoint tablosunun satırını veya sütununu nasıl kopyalayacağınızı gösterir:

```java
 // Presentation sınıfını örnekler
Presentation pres = new Presentation("Test.pptx");
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Sütunları genişliklerle ve satırları yüksekliklerle tanımlar
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Slayta bir tablo şekli ekler
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Satır 1 hücre 1'e bazı metin ekler
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Satır 1 hücre 2'ye bazı metin ekler
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Satır 1'i tablonun sonuna kopyalar
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Satır 2 hücre 1'e bazı metin ekler
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Satır 2 hücre 2'ye bazı metin ekler
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Satır 2'yi tablonun 4. satırı olarak kopyalar
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // İlk sütunu sonuna kopyalar
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // 2. sütunu 4. sütun indeksinde kopyalar
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Sunumu diske kaydeder
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Tablo Satırını veya Sütununu Kaldır**

1. Sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun, 
2. Slaytın referansını indeksini kullanarak alın. 
3. `columnWidth` dizisini tanımlayın. 
4. `rowHeight` dizisini tanımlayın. 
5. [addTable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metodunu kullanarak slayta bir [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) nesnesi ekleyin. 
6. Tablo satırını kaldırın. 
7. Tablo sütununu kaldırın. 
8. Değiştirilmiş sunumu kaydedin. 

Bu Java kodu, bir tablodan satır veya sütun nasıl kaldırılacağını gösterir:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tablo Satır Seviyesinde Metin Biçimlendirmesini Ayarla**

1. Sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun, 
2. Slaytın referansını indeksini kullanarak alın. 
3. Slayttan ilgili [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) nesnesine erişin. 
4. İlk satır hücrelerinin [setFontHeight(float value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) metodunu ayarlayın. 
5. İlk satır hücrelerinin [setAlignment(int value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) ve [setMarginRight(float value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) metodunu ayarlayın. 
6. İkinci satır hücrelerinin [setTextVerticalType(byte value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) metodunu ayarlayın. 
7. Değiştirilmiş sunumu kaydedin. 

Bu Java kodu işlemi gösterir.

```java
// Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // İlk satır hücrelerinin yazı tipi yüksekliğini ayarlar
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // İlk satır hücrelerinin metin hizalamasını ve sağ marjini ayarlar
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // İkinci satır hücrelerinin metin dikey tipini ayarlar
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Sunumu diske kaydeder
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tablo Sütun Seviyesinde Metin Biçimlendirmesini Ayarla**

1. Sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun, 
2. Slaytın referansını indeksini kullanarak alın. 
3. Slayttan ilgili [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) nesnesine erişin. 
4. İlk sütun hücrelerinin [setFontHeight(float value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) metodunu ayarlayın. 
5. İlk sütun hücrelerinin [setAlignment(int value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) ve [setMarginRight(float value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) metodunu ayarlayın. 
6. İkinci sütun hücrelerinin [setTextVerticalType(byte value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) metodunu ayarlayın. 
7. Değiştirilmiş sunumu kaydedin. 

Bu Java kodu işlemi gösterir: 

```java
// Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // İlk sütun hücrelerinin yazı tipi yüksekliğini ayarlar
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // İlk sütun hücrelerinin metin hizalamasını ve sağ marjini tek bir çağrıda ayarlar
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // İkinci sütun hücrelerinin metin dikey tipini ayarlar
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tablo Stil Özelliklerini Al**

Aspose.Slides, bir tablo için stil özelliklerini almanıza olanak tanır, böylece bu detayları başka bir tabloya ya da başka bir yere kullanabilirsiniz. Bu Java kodu, bir tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // varsayılan stil ön ayarı temasını değiştir
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Bir tabloya zaten oluşturulmuş bir PowerPoint teması/stili uygulayabilir miyim?**

Evet. Tablo, slayt/yerleşim/ana tema temasını devralır ve yine de bu temanın üzerine dolgu, kenarlık ve metin renklerini geçersiz kılabilirsiniz.

**Tablo satırlarını Excel'deki gibi sıralayabilir miyim?**

Hayır, Aspose.Slides tablolarında yerleşik sıralama veya filtreleme özelliği yoktur. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını bu sıraya göre yeniden doldurun.

**Belirli hücrelerde özel renkleri korurken şeritli (banded) sütunlar elde edebilir miyim?**

Evet. Şeritli sütunları etkinleştirin, ardından belirli hücreleri yerel biçimlendirme ile geçersiz kılın; hücre‑seviyesi biçimlendirme tablo stiline göre önceliklidir.