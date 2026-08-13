---
title: Sunumlarda Java ile Şekil Etkin Özelliklerini Alın
linktitle: Etkin Özellikler
type: docs
weight: 50
url: /tr/java/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık rig
- köşe şekli
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'yı kullanarak PowerPoint sunumlarında yerel, miras alınan ve etkin şekil biçimlendirmesini nasıl ayırt edeceğinizi öğrenin."
---
## **Yerel, Miras Alınan ve Etkin Özellikleri Anlamak**

PowerPoint biçimlendirmesi birkaç yerden gelebilir. Bir nesne üzerinde doğrudan depolanan değer **yerel değer** dir. Bu değer ayarlanmamışsa, PowerPoint bir paragraf varsayılanı, bir metin stili, bir yerleşim veya ana slayt, bir tema veya sunum düzeyindeki varsayılanlar gibi üst biçimlendirme kaynaklarına bakar. Bu değerler **miras alınan değerler** dir. Tüm hiyerarşi çözüldükten sonra kalan değer **etkin değer** dir — nesneyi renderlamak için kullanılan değer.

Örneğin, bir metin bölümü kendi yazı tipi yüksekliğini tanımlamıyor olabilir. Yerel [getFontHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) değeri `Float.NaN` olur, bu da "burada ayarlanmamış" anlamına gelir. Bölüm, yüksekliği paragrafından, sunumun varsayılan metin stilinden veya başka bir geçerli kaynaktan miras alabilir. Bölüm biçiminde [getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportionformat/#getEffective--) çağrısı, nihai çözülen yüksekliği döndürür.

Farklı amaçlar için iki tür biçimlendirme verisini kullanın:

- Bir değerin nerede tanımlandığını kontrol etmeniz gerektiğinde, örneğin [IPortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportionformat/), yerel bir format nesnesini okuyun veya değiştirin.
- Nihai, renderlanmış sonucu ihtiyaç duyduğunuzda, örneğin [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportionformateffectivedata/), bir etkin veri nesnesini okuyun. Etkin veri sadece okunabilir.

## **Compare Local, Inherited, and Effective Values**

Aşağıdaki tam örnek bir şekil oluşturur ve sunum, paragraf ve bölüm seviyelerinde yazı tipi yüksekliği uygular. Her adım bu seviyelerde tanımlanan değerleri ve aynı metin bölümü için sonuçta gelen etkin değeri yazdırır. Ayrıca, biçimlendirme değişikliklerinden sonra neden etkin verinin yeniden okunması gerektiğini gösterir.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // İki farklı seviyede miras alınan değerleri tanımla.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Bölümdeki yerel değer, her iki miras alınan değerin üzerine yazar.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Miras alınan bir değeri değiştirmek, mevcut bir yerel değerin üzerine yazmaz.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Yerel değeri temizle. Bölüm artık paragraftan tekrar miras alır.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Paragraf değerini temizle. Sunum varsayılanı şimdi sonucu sağlar.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // Önceki değişikliklerden sonra etkin veriyi oku.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

Bu örnekte öncelik bölümün yerel biçimlendirmesi, ardından paragraf biçimlendirmesi ve son olarak sunum varsayılanıdır. Diğer nesneler farklı miras zincirlerine sahip olabilir, ancak ilke aynıdır: daha spesifik açık bir değer kazanır ve [getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportionformat/#getEffective--) son sonucu döndürür.

## **Etkin Metin Özelliklerini Alın**

Metin biçimlendirme birden fazla nesne arasında bölünmüştür:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/#getEffective--) kenar boşlukları, sabitleme, otomatik sığdırma ve dikey metin yönü gibi metin çerçevesi özelliklerini çözer.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextstyle/#getEffective--) her metin stili seviyesi için paragraf biçimlendirmesini çözer.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraphformat/#getEffective--) hizalama, girinti ve madde işaretleri gibi paragraf özelliklerini çözer.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportionformat/#getEffective--) yazı tipi yüksekliği, tipografi, renk, kalın ve italik gibi karakter özelliklerini çözer.

Sonraki örnek için `text-formatting.pptx` en az bir slayt ve boş olmayan bir metin çerçevesine sahip bir [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/) içermelidir. AutoShape şekil koleksiyonunun herhangi bir konumunda bulunabilir; kod uygun bir nesne arar ve kullanmadan önce doğrular.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Etkin 3D Özelliklerini Alın**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformat/#getEffective--) tüm çözülen 3D ayarlarını gruplayan bir [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformateffectivedata/) nesnesi döndürür. Bu nesnenin [getCamera](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--) ve [getBevelBottom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) metodları ilgili etkin verileri ortaya çıkarır. Bu ilgili ayarları birlikte okumak, bir şeklin son 3D görünümünü anlamayı kolaylaştırır.

Bu örnek için `shape-3d.pptx` ilk slaytında en az bir şekil içermelidir. Çıktının varsayılanların dışındaki değerleri içermesini istiyorsanız, o şekle 3D kamera, ışıklandırma veya köşe ayarları uygulayın.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Etkin Tablo Biçimlendirmesini Alın**

Tablo biçimlendirme, tablo stilinden ve tüm tablo, bir sütun, bir satır veya tek bir hücreye uygulanan formatlardan gelebilir. Açıkça tanımlanmış dolgu çakışmalarında öncelik hücre, satır, sütun ve ardından tüm tablo şeklindedir. Bir hücrenin etkin biçimi, o hücreyi çizmek için kullanılan son biçimdir.

Bu örnek için `table-formatting.pptx` ilk slaytında en az bir tablo içermelidir. Tablo en az bir satır ve bir sütun içermelidir. Kod, `getShapes().get_Item(0)`'ın bir tablo olduğunu varsaymak yerine bir [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itable/) arar.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

Eğer sadece dolgu tipinden ziyade rengi ihtiyacınız varsa, önce etkin [getFillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifillformateffectivedata/#getFillType--) kontrol edin ve ardından o tipe uygulanan metodu okuyun — örneğin, katı dolgu için [getSolidFillColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) .

## **Değişikliklerden Sonra Etkin Veriyi Yeniden Okuyun**

Etkin veri, çözüldüğü zamandaki biçimlendirme hiyerarşisini tanımlar. Bu hiyerarşiye katılabilecek bir şeyi değiştirdikten sonra `getEffective` tekrar çağırın, şunlar dahil:

- nesnenin yerel biçimlendirmesi;
- paragraf veya metin çerçevesi varsayılanları;
- bir tablo stili, tablo, sütun, satır veya hücre formatı;
- yerleşim veya ana slayt biçimlendirmesi;
- tema verileri veya sunum düzeyindeki varsayılanlar;
- bir slayta atanan yerleşim veya ana.

Etkin veri nesnesini kalıcı bir anlık fotoğraf olarak tutmayın. Aspose.Slides bazı etkin verileri dahili olarak önbelleğe alabilir ve sonraki bir `getEffective` çağrısı bu verileri yenileyebilir. Bir değişiklikten önce ve sonra değerleri karşılaştırmanız gerekiyorsa, değişiklik yapmadan önce ihtiyacınız olan skaler değerleri — örneğin yazı tipi yüksekliği, renk, hizalama veya köşe genişliği — kendi değişkenlerinize kopyalayın.

Bir değeri değiştirmek için uygun yerel format nesnesini güncelleyin ve ardından sonucu doğrulamak için `getEffective` çağırın. Etkin veri nesneleri kendileri sadece okunabilir.

## **FAQ**

**Etkin bir değeri hangi seviyenin sağladığını nasıl öğrenebilirim?**

Etkin veri son değeri, kaynağını değil içerir. En spesifik seviyeden dışa doğru ilgili yerel nesneleri inceleyin. Metin için bu, bölüm, paragraf, metin çerçevesi, yerleşim, ana, tema ve sunum varsayılanlarını içerebilir. `Float.NaN` veya `null` gibi tanımsız değerler, aramanın başka bir seviyeye devam ettiğini gösterir.

**Hiçbir seviye bir özelliği tanımlamadığında ne olur?**

Aspose.Slides uygun PowerPoint veya kütüphane varsayılanını çözer. Bu çözülen değer, hiçbir yerel nesnenin açıkça tanımlamamasına rağmen etkin veride görünür.

**Neden bir etkin değer bazen yerel değere eşit olur?**

Yerel değer, miras hesaplamasını kazandı. Bu, özellik nesne üzerinde açıkça ayarlandığında ve daha spesifik bir kural tarafından geçersiz kılınmadığında beklenir.

**Ne zaman yerel veriyi etkin veri yerine kullanmalıyım?**

Yerel veriyi belirli bir biçimlendirme seviyesini incelemek veya düzenlemek için kullanın. Etkin veriyi, miras, tema kuralları ve uygulanabilir stiller çözüldükten sonraki nihai görünüm gerektiğinde kullanın. [tam karşılaştırma örneği](#compare-local-inherited-and-effective-values) aynı iş akışında ikisini de gösterir.