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
description: "Aspose.Slides for Java ile PowerPoint slaytlarında tablo oluşturun ve düzenleyin. Tablo iş akışlarınızı hızlandırmak için basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki bir tablo, bilgiyi görüntülemenin ve aktarmanın verimli bir yoludur. Satır ve sütunlarda düzenlenmiş hücre ızgarasındaki bilgi, doğrudan ve anlaşılması kolaydır.

Aspose.Slides, [Table](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Table) sınıfı, [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) arayüzü, [Cell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cell/) sınıfı, [ICell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icell/) arayüzü ve tabloları tüm sunum türlerinde oluşturmanıza, güncellemenize ve yönetmenize olanak tanıyan diğer tipleri sağlar. 

## **Sıfırdan Tablo Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksine göre bir referans alın.  
3. `columnWidth` dizisini tanımlayın.  
4. `rowHeight` dizisini tanımlayın.  
5. [addTable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) yöntemiyle slayta bir [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) nesnesi ekleyin.  
6. Her bir [ICell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icell/) üzerinden geçerek üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırının ilk iki hücresini birleştirin.  
8. Bir [ICell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icell/)'in [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/) öğesine erişin.  
9. [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/) öğesine bir metin ekleyin.  
10. Değiştirilen sunumu kaydedin.

Bu Java kodu, bir sunumda tablo oluşturmayı gösterir:

```java
// PPTX dosyasını temsil eden Presentation sınıfını oluşturur
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Genişliklerle sütunları ve yüksekliklerle satırları tanımlar
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Slayda bir tablo şekli ekler
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Her hücrenin kenarlık biçimini ayarlar
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
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
    // 1. satırın 1. ve 2. hücrelerini birleştirir
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Birleştirilmiş hücreye bazı metinler ekler
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Sunumu diske kaydeder
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standart Tablo Numaralandırması**

Standart bir tabloda hücrelerin numaralandırması basit ve sıfır tabanlıdır. Bir tablodaki ilk hücre 0,0 (sütun 0, satır 0) olarak indekslenir. 

Örneğin, 4 sütun ve 4 satır içeren bir tablodaki hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu Java kodu, bir tablodaki hücrelerin numaralandırmasını nasıl belirleyeceğinizi gösterir:

```java
// PPTX dosyasını temsil eden Presentation sınıfını oluşturur
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Genişliklerle sütunları ve yüksekliklerle satırları tanımlar
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Slayta bir tablo şekli ekler
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Her hücrenin kenarlık biçimini ayarlar
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Sunumu diske kaydeder
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mevcut Bir Tabloya Erişim**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  

2. Tabloyu içeren slayta indeks üzerinden bir referans alın.  

3. Bir [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) nesnesi oluşturun ve null olarak ayarlayın.  

4. Tablo bulunana kadar tüm [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) nesneleri üzerinden geçin.  

   Eğer üzerinde çalıştığınız slayt tek bir tablo içeriyorsa, içinde bulunan tüm şekilleri kontrol edebilirsiniz. Bir şekil tablo olarak tanımlandığında, onu bir [Table](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Table) nesnesine tip dönüşümü yapabilirsiniz. Ancak, slayt birden fazla tablo içeriyorsa, ihtiyacınız olan tabloyu [setAlternativeText(String value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) yöntemiyle aramanız daha iyidir.  

5. [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) nesnesini tablo ile çalışmak için kullanın. Aşağıdaki örnekte tabloya yeni bir satır ekledik.  

6. Değiştirilen sunumu kaydedin.  

Bu Java kodu, mevcut bir tabloya nasıl erişileceğini ve onunla nasıl çalışılacağını gösterir:

```java
// PPTX dosyasını temsil eden Presentation sınıfını oluşturur
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // null TableEx'i başlatır
    ITable tbl = null;

    // Şekillerde dolaşıp bulunan tabloya bir referans ayarlar
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // İkinci satırın ilk sütunu için metni ayarlar
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Değiştirilen sunumu diske kaydeder
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tablodaki Metni Hizalama**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksine göre bir referans alın.  
3. Slayta bir [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) nesnesi ekleyin.  
4. Tablo üzerinden bir [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) nesnesine erişin.  
5. [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) içindeki [IParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/) öğesine erişin.  
6. Metni dikey olarak hizalayın.  
7. Değiştirilen sunumu kaydedin.  

Bu Java kodu, bir tablodaki metnin nasıl hizalanacağını gösterir:

```java
// Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Genişliklerle sütunları ve yüksekliklerle satırları tanımlar
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Tablo şekli slayta eklenir
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Metin çerçevesine erişir
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Metin çerçevesi için Paragraph nesnesi oluşturur
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Paragraf için Portion nesnesi oluşturur
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Metni dikey olarak hizalar
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Sunumu diske kaydeder
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tablo Düzeyinde Metin Biçimlendirmesi Ayarlama**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksine göre bir referans alın.  
3. Slayttan bir [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) nesnesine erişin.  
4. Metin için [setFontHeight(float value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) metodunu ayarlayın.  
5. [setAlignment(int value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) ve [setMarginRight(float value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) metodlarını ayarlayın.  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) metodunu ayarlayın.  
7. Değiştirilen sunumu kaydedin.  

Bu Java kodu, bir tablo içindeki metne tercih ettiğiniz biçimlendirme seçeneklerini nasıl uygulayacağınızı gösterir:

```java
// Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation("simpletable.pptx");
try {
    // İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Tablo hücrelerinin font yüksekliğini ayarlar
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Tablo hücrelerinin metin hizalamasını ve sağ kenar boşluğunu tek bir çağrıda ayarlar
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Tablo hücrelerinin metin dikey tipini ayarlar
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tablo Stil Özelliklerini Almak**

Aspose.Slides, bir tablonun stil özelliklerini almanıza olanak tanır; böylece bu detayları başka bir tabloya ya da başka bir konuma uygulayabilirsiniz. Bu Java kodu, bir tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // varsayılan stil ön ayar temasını değiştir
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Tablonun En Boy Oranını Kilitleme**

Geometrik bir şeklin en boy oranı, farklı boyutlardaki boyutlarının oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en boy oranı kilitleme ayarını sağlamanız amacıyla [**setAspectRatioLocked**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) özelliğini sundu. 

Bu Java kodu, bir tablonun en boy oranını nasıl kilitleyeceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // tersine çevir

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Bir tablonun ve hücrelerindeki metnin tamamı için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, [setRightToLeft](https://reference.aspose.com/slides/tr/java/com.aspose.slides/table/#setRightToLeft-boolean-) metodunu sunar ve paragraflar da [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/tr/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) metoduna sahiptir. Her ikisinin de kullanılması, hücreler içinde doğru RTL sırasını ve renderlamayı sağlar.

**Kullanıcıların final dosyasında tabloyu taşımasını veya yeniden boyutlandırmasını nasıl engelleyebilirim?**

[Şekil kilitlerini](/slides/tr/java/applying-protection-to-presentation/) kullanarak taşıma, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakın. Bu kilitler tablolara da uygulanır.

**Bir hücrenin içinde arka plan olarak bir resim eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/tr/java/com.aspose.slides/picturefillformat/) ayarlayabilirsiniz; resim, seçilen moda (esnetme ya da döşeme) göre hücre alanını kaplar.