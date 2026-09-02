---
title: Android'de Sunum Tablolarını Yönetme
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/androidjava/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tabloya eriş
- en-boy oranı
- metni hizala
- metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint slaytlarında tablolar oluşturun ve düzenleyin. Tablo iş akışlarınızı basitleştirecek basit Java kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'te bir tablo, bilgiyi görüntülemenin ve sunmanın etkili bir yoludur. Hücrelerden oluşan bir ızgara (satırlar ve sütunlar halinde düzenlenmiş) içindeki bilgi doğrudan ve anlaşılması kolaydır.

Aspose.Slides, tabloları tüm sunumlardaki oluşturmanıza, güncellemenize ve yönetmenize olanak tanıyan [Table](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Table) sınıfı, [ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITable) arayüzü, [Cell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cell/) sınıfı, [ICell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icell/) arayüzü ve diğer türleri sağlar.

## **Sıfırdan Tablo Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. `columnWidth` dizisini tanımlayın.  
4. `rowHeight` dizisini tanımlayın.  
5. Slayta bir [ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITable) nesnesi eklemek için [addTable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) yöntemini kullanın.  
6. [ICell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icell/) nesnelerini dolaşarak üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Bir [ICell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icell/)'in [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) nesfesine erişin.  
9. [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) içine bazı metinler ekleyin.  
10. Değiştirilen sunumu kaydedin.

Bu Java kodu, bir sunumda tablo oluşturmayı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Bir PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Slayta bir tablo şekli ekler
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Her hücre için kenarlık biçimini ayarlar
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
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // Birleştirilmiş hücreye bazı metinler ekler
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Sunumu diske kaydeder
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standart Bir Tablo’da Numarlama**

Standart bir tabloda hücrelerin numaralandırması basit ve sıfır temellidir. Bir tablodaki ilk hücre 0,0 (sütun 0, satır 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satırdan oluşan bir tabloda hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu Java kodu, bir tablodaki hücreler için numaralandırmayı nasıl belirleyeceğinizi gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Slayta bir tablo şekli ekler
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Her hücre için kenarlık biçimini ayarlar
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

## **Mevcut Bir Tabloya Erişme**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. Tabloyu içeren slayta indeks üzerinden bir referans alın.  
3. Bir [ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITable) nesnesi oluşturun ve null olarak ayarlayın.  
4. Tablo bulunana kadar tüm [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) nesnelerini dolaşın.  

   Eğer üzerinde çalıştığınız slayt tek bir tablo içerdiğini düşünüyorsanız, içinde bulunan tüm şekilleri basitçe kontrol edebilirsiniz. Bir şekil tablo olarak tanımlandığında, onu bir [Table](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Table) nesnesi olarak tip dönüştürebilirsiniz. Ancak slayt birden fazla tablo içeriyorsa, ihtiyacınız olan tabloyu [setAlternativeText(String value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) yöntemiyle aramanız daha iyidir.

5. [ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITable) nesnesini tabloyla çalışmak için kullanın. Aşağıdaki örnekte, tablodaki bir hücrenin metnini ayarlıyoruz.  
6. Değiştirilen sunumu kaydedin.

Bu Java kodu, mevcut bir tabloya nasıl erişileceğini ve bununla nasıl çalışılacağını gösterir:

```java
import com.aspose.slides.*;

// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // null TableEx'i başlatır
    ITable tbl = null;

    // Şekilleri dolaşır ve bulunan tabloya bir referans atar
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

## **Bir Metin Çerçevesine Sahip Hücreyi Bulma**

Genel bir metin işleme kodu bir tablodan bir [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) aldığında, sahip [ICell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icell/) öğesini elde etmek için [ITextFrame.getParentCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getParentCell--) yöntemini kullanın. Bir tablo hücresi metin çerçevesi için, [ITextFrame.getParentCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getParentCell--) sahibi döndürür ve [ITextFrame.getParentShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getParentShape--) `null` döndürür, ancak tablo kendisi bir şekildir.

Hücre koordinatları, yalnızca okunabilen [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) ve [ICell.getFirstRowIndex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) yöntemleriyle alınabilir. [ITextFrame.getParentCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getParentCell--) aynı zamanda yalnızca okunabilir bir gezinme sağlar: sahibi döndürür ancak sahipliği değiştirmez. Kullanımdan önce döndürülen hücreyi `null` olup olmadığını mutlaka kontrol edin.

Tablo hücresi ve şekil sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de belirten eksiksiz bir örnek için [Search and Replace Text](/slides/tr/androidjava/search-and-replace-text/) sayfasına bakın.

## **Bir Tablodaki Metni Hizalama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. Slayta bir [ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITable) nesnesi ekleyin.  
4. Tablodan bir [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) nesnesine erişin.  
5. [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) içindeki [IParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph/) nesnesine erişin.  
6. Metni dikey olarak hizalayın.  
7. Değiştirilen sunumu kaydedin.

Bu Java kodu, bir tablodaki metni nasıl hizalayacağınızı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slaytı alır 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Genişlikleriyle sütunları ve yükseklikleriyle satırları tanımlar
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

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. Slayttan bir [ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITable) nesnesine erişin.  
4. Metin için [setFontHeight(float value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) ayarlayın.  
5. [setAlignment(int value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) ve [setMarginRight(float value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) ayarlayın.  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) ayarlayın.  
7. Değiştirilen sunumu kaydedin.  

Bu Java kodu, bir tablodaki metne tercih ettiğiniz biçimlendirme seçeneklerini nasıl uygulayacağınızı gösterir:

```java
import com.aspose.slides.*;

// Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation("simpletable.pptx");
try {
    // İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Tablo hücrelerinin yazı tipi yüksekliğini ayarlar
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

Aspose.Slides, bir tablonun stil özelliklerini almanıza olanak tanır; böylece bu ayrıntıları başka bir tabloya ya da başka bir yere uygulayabilirsiniz. Bu Java kodu, bir tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // varsayılan stil ön ayar temasını değiştirir

    // Tablonun stil ön ayarını al
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // Alınan stil ön ayarını başka bir tabloya uygula
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Tablonun En‑Boy Oranını Kilitleme**

Geometrik bir şeklin en‑boy oranı, farklı boyutlardaki ölçülerinin oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en‑boy oranı kilitleme ayarını sağlayan [**setAspectRatioLocked**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) özelliğini sunar.

Bu Java kodu, bir tablonun en‑boy oranını nasıl kilitleyeceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // tersine

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Bir tablonun tamamı ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, [setRightToLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) metodunu sunar ve paragraflar da [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) metoduna sahiptir. Her ikisinin birlikte kullanılması, hücre içindeki doğru RTL sırasını ve renderlamayı sağlar.

**Kullanıcıların son dosyada tabloyu taşımalarını veya yeniden boyutlandırmalarını nasıl engelleyebilirim?**

Taşıma, yeniden boyutlandırma, seçme vb. işlemleri devre dışı bırakmak için şekil kilitlerini kullanın. Bu kilitler tablolar için de geçerlidir.

**Bir hücrenin içinde arka plan olarak bir görsel eklemek destekleniyor mu?**

Evet. Bir hücreye [picture fill](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/picturefillformat/) ayarlayabilirsiniz; görsel, seçilen moda (stretç veya döşeme) göre hücre alanını kaplayacaktır.