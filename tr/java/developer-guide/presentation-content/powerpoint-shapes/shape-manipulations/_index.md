---
title: Java'da Sunum Şekillerini Yönetme
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/java/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil kopyalama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini al
- şekil alternatif metni
- şekil ayar noktası
- önceden ayarlanmış şekil ayarı
- şekil geometrisi
- şekil yerleşim formatları
- SVG olarak şekil
- şekli SVG'ye dönüştür
- şekli hizala
- şekli çevir
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile sunum şekillerini tanımlamayı, ayarlamayı, kopyalamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Java, bir slayd üzerindeki şekilleri sıralı bir [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirdiğiniz yer olduğu gibi, yığının sırasının kaynağıdır: indeks `0` en arka şekildir, son indeks ise en ön şekildir.

Bu makale bu modeli izler. Öncelikle bir şekli güvenilir bir şekilde tanımlamayı ve önceden ayarlanmış şekil ayar noktalarını değiştirmeyi açıklar, ardından şekilleri kopyalamayı, kaldırmayı, gizlemeyi ve yeniden sıralamayı gösterir. Son bölümler, düzen‑düzeyi biçimlendirme, SVG dışa aktarma, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır, böylece yalnızca iş akışınız için gerekli işlemleri kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri bilinen bir dosya işlenirken kullanışlıdır, ancak sabit tanımlayıcılar değildir. Bir şekle ekleme, kaldırma veya yeniden sıralama işlemi indeksini değiştirebilir. Sunumun nasıl oluşturulduğuna ve korunduğuna göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getName--) geliştirici kontrolündeki şablonlar için kullanışlıdır ve PowerPoint'in Seçim Bölmesi'nde incelenmesi kolaydır. İsimler düzenlenebilir ve benzersiz olması garantilenmez; bu yüzden kod bu isime dayanıyorsa bir adlandırma kuralı oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getAlternativeText--) erişilebilirlik açıklaması veya yazar‑tarafından sağlanan bir etiket zaten şekli tanımlıyorsa kullanışlıdır. Kullanıcılar tarafından görülür, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olması garantilenmez. Anlamlı erişilebilirlik metnini sessizce bir veritabanı anahtarı olarak yeniden kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) bir slayt içinde benzersiz ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelen yalnızca‑okunur bir tanımlayıcıdır. PowerPoint ile bütünleştirirken veya bir şeklin ömrü boyunca kesin bir referansa ihtiyaç duyulduğunda kullanın. Kopyalanan veya yeniden oluşturulan bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [getUniqueId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getUniqueId--) yöntemi sunum kapsamındaki bir tanımlayıcı döndürür, ancak bu tanımlayıcı eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı harici bir anahtar olarak kullanılmamalıdır. Uzun vadeli kimlik önem taşıyorsa, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek, isme göre tam karşılaştırma yaparak arama gerçekleştirir ve slayt‑kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde, kod yanlış nesneyle devam etmek yerine bu sonucu raporlar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Bir işlem belirli bir şekil tipine özgüyse, tip‑özel üyeleri kullanmadan önce arabirimi kontrol edin. Bu örnek, adlandırılmış nesne bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ise yalnızca metin ve alternatif metni günceller.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Önceden Ayarlanmış Şekil Ayarlarını Tanımlama ve Değiştirme**

Önceden ayarlanmış geometri şekilleri, köşe boyutu, ok oranları veya yay açıları gibi özellikleri kontrol eden ayar noktalarını açığa çıkarabilir. Bunlara, yalnızca‑okunur [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igeometryshape/#getAdjustments--) koleksiyonu aracılığıyla ulaşın. Koleksiyon şekil tarafından sağlanır, ancak her [IAdjustValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iadjustvalue/) değiştirilebilen bir değere sahiptir.

Sabit bir koleksiyon indeksine yalnızca güvenmeyin. Ayarları döngüyle gezip yalnızca‑okunur [getType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iadjustvalue/#getType--) yöntemini inceleyin; bu yöntemin döndürdüğü [ShapeAdjustmentType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapeadjustmenttype/) değeri ayarın neyi kontrol ettiğini tanımlar. Yalnızca‑okunur [getName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iadjustvalue/#getName--) yöntemi ek kimlik bilgileri sunar ve aynı anlamsal tipe sahip birden fazla ayar bulunduğunda özellikle faydalıdır.

Ayara karşılık gelen anlamı ile eşleşen değer yöntemini kullanın:

| Ayar türü | Amacı | Değiştirilecek değer |
|---|---|---|
| `CornerSize` | Yuvarlatılmış köşelerin boyutu | [setRawValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Ok kuyruğunun kalınlığı | `setRawValue` |
| `ArrowheadLength` | Ok başının uzunluğu | `setRawValue` |
| `ArrowheadWidth` | Ok başının genişliği | `setRawValue` |
| `StartAngle` | Dilim ya da yay başlangıç açısı | [setAngleValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Dilim ya da yay bitiş açısı | `setAngleValue` |

`getType` ve `getName` yalnızca‑okunur bilgileri döndürür. `getRawValue` ve `setRawValue`, önceden ayarlanmışın yerel geometri birimlerinde bir tam sayı ile çalışırken, `getAngleValue` ve `setAngleValue` derecelerde açı ile çalışır. Ayarların sayısı, sırası, anlamı ve geçerli aralığı, önceden ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igeometryshape/#getShapeType--) değerine bağlıdır. Bir önceden ayarlama için geçerli olan bir değer, başka bir önceden ayarlama için geçersiz olabilir ya da farklı bir etki yaratabilir.

`getType` `ShapeAdjustmentType.Custom` döndürdüğünde, API standart bir anlamsal anlam tanımaz. `getName`, önceden ayarlama tipini ve mevcut değeri inceleyin ve beklenen anlam ve aralık bilinmiyorsa ayarı değiştirmeyin. Tanınan tipler için bile aynı tip birden fazla kez ortaya çıkıyorsa önce kontrol edin. Bağlayıcı bükülme ayarlarıyla ilgili örnek için [Connector](/slides/tr/java/connector/) makalesine bakın.

Aşağıdaki tam örnek, üç önceden ayarlanmış şeklin varsayılan ve değiştirilmiş sürümlerini oluşturur. Her ayarı döngüyle gezerek adını ve tipini raporlar, `setRawValue` ile boyutla ilgili değerleri, `setAngleValue` ile açıları değiştirir ve sonucu kaydeder. Sol sütun varsayılan geometrisini tutar; sağ sütun ayarlanmış yuvarlak dikdörtgeni, dört yönlü oku ve dilimi gösterir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Varsayılan ve ayarlanmış şekil sütunları için başlıklar ekler.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Değiştirmeden önce anlamsal tipi kontrol etmek, kodun amacını açık hale getirir ve bir koleksiyon indeksinin farklı önceden ayarlanmış şekillerde aynı anlama geldiği varsayımını önler.

## **Şekil Koleksiyonunu Değiştirme**

Ekle, kopyala, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını veya sırasını değiştirirse, o işlemin öncesinde yakalanan indekslere güvenmeye devam etmeyin.

### **Bir Şekli Kopyalama**

[addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) da bir kopya oluşturur ancak belirtilen z‑order indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler, boyutunu değiştirmeden kopyayı taşır; genişlik ve yükseklik içeren aşırı yüklemeler yeniden boyutlandırabilir.

Örnek bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne kopyalar ve ikinci bir kopyayı arka tarafa ekler. Her iki kopyada yapılan değişiklikler kaynak şekli etkilemez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kopyalama, şeklin içeriğini ve biçimini, adı ve alternatif metni dahil olmak üzere kopyalar. Bu değerlerin benzersiz olması gerekiyorsa, kopyaya yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak bir kopya yeni bir koleksiyon öğesi ve yeni bir şekil kimliğiyle kalır.

### **Şekilleri Kaldırma**

[remove](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) belirli bir şekil nesnesini kendi koleksiyonundan siler. İndeksli yineleme sırasında birden fazla eşleşmeyi kaldırırken, kalan indekslerin geçerli kalması için sondan başlayarak dolaşın.

Bu örnek, belirli bir isim taşıyan her şekli kaldırır. Şekli sabit bir koleksiyon öğesi yerine geçerli indekste okur ve gereksiz tür dönüşümü yapmaz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kaldırma işleminden sonra şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere referanslar, kaydedilmiş indekslerden daha güvenilirdir. Bağlayıcılar, animasyonlar ve kaldırılan nesneye başvuran diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şekli kaldırmak slaydın görünümünden daha fazlasını değiştirebilir.

### **Bir Şekli Gizleme**

[Hidden](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setHidden-boolean-) özelliğini `true` yaparak şekli koleksiyonda tutar ancak normal slayt gösterisinde görünmesini engellersiniz. İndeksi, biçimlendirmesi ve içeriği kod tarafından erişilebilir olmaya devam eder; bu yüzden gizleme, daha sonra geri getirilebilecek isteğe bağlı öğeler için uygundur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gizleme silme veya güvenlik değildir. Nesne hâlâ bulunabilir ve bir kullanıcı ya da kod tarafından tekrar görünür hâle getirilebilir; ayrıca sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirme**

Üst üste gelen şekiller koleksiyon sırasına göre boyanır. [reorder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) mevcut bir şekli klonlamadan hedef bir indeks'e taşır. İndeks `0` arka, `size() - 1` ön konumdadır.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dikdörtgen ilk oluşturulduğunda elipsin arkasında yer alır. Son indekse taşınması onu öne getirir. Tüm ilgili şekiller eklendikten ya da kopyalandıktan sonra z‑sırasını tamamlayın; çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytların ayrı şekil koleksiyonları vardır. Bir düzen koleksiyonundaki şekil, aynı konumdaki bir normal slayttaki şekil ile aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak ya da değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getFillFormat--) ve [LineFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getLineFormat--) özelliklerini okur; her şeklin bir `AutoShape` olduğunu varsaymaz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Bir düzenin düzenlenmesi, onu kullanan birden çok slaytı etkileyebilir. Normal bir slayt nesneyi devralıyor mu yoksa yerel bir geçersiz kılma mı içeriyor belirleyin ve o düzeni kullanan tüm slaytları test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[writeAsSvg](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) bir şeklin çizilmiş içeriğini bir akıma yazar. Sonuç yalnızca şekli içerir; tüm slayt arka planı ya da komşu şekilleri içermez.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Render sırasında sunumu açık tutun. Çıktı, şeklin biçimlendirmesine ve fontlar ile resimler gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, bireysel şekil yerine slaytı dışa aktarın. Çağırıcı akımı yönetir ve kapatmak zorundadır.

## **Şekilleri Hizalama**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) aşırı yüklemeleri, tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapesalignmenttype/) kenar, merkez hattı ya da dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparak slayt kenarlarını, `false` yaparak seçili şekilleri birbirlerine göre hizalayabilirsiniz.

Bu örnek üç şekli slaydın üst kenarına hizalar. Döndürülen şekil referansları, hizalamadan hemen önce geçerli indekslerine dönüştürülür.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hizalama konumları değiştirir, z‑sırasını etkilemez. Göreceli hizalama genellikle en az iki şekil gerektirir; yatay ya da dikey dağıtım için aralığı tanımlayacak yeterli şekil gerekir. Yöntemi çağırmadan önce koleksiyonu değiştirirseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ve dönüşümleri saklar. `getFlipH` ve `getFlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/java/com.aspose.slides/nullablebool/) kullanır: `True` çevirme etkin, `False` devre dışı, `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu, bir çevirilmeyen şekil içerir.

![Şekil çevirilmeden önce](shape_to_be_flipped.png)

Örnek, diğer tüm frame değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir; çünkü yeni bir [Frame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) atanması tüm frame'i üzerine yazar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kaydedilen şekil, konumunu, boyutunu ve dönüşünü korurken yatay ve dikey olarak yansıtılmıştır.

![Şekil çevirildikten sonra](flipped_shape.png)

## **SSS**

**Bir şekil tanımlayıcı olarak koleksiyon indeksi kullanmalı mıyım?**

Sadece koleksiyonun indeks değişmeyecek kısa vadeli işlemler için kullanılabilir. Oluşturulmuş şablonlar için doğrulanmış bir `Name` ya da `AlternativeText` kuralı, slayt‑kapsamlı işlerde ise `OfficeInteropShapeId` tercih edilmelidir.

**Bir şekli gizlemek, onu z‑sırasından çıkarır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Kopyalanan bir şekil neden başka bir şeklin önüne çıktı?**

`addClone` kopyayı koleksiyonun sonuna ekler; bu, z‑sırasının ön kısmıdır. Başlangıç indeksini seçmek için `insertClone` kullanın ya da tüm şekiller eklendikten sonra `reorder` ile konumlandırın.

**Önceden ayarlanmış bir şekil ayarını tanımlamak için sabit bir indeks kullanabilir miyim?**

Sadece kesin önceden ayarlama ve koleksiyon düzeni doğrulandıysa kullanılabilir. `IGeometryShape.getAdjustments` üzerinden yineleyip `IAdjustValue.getType` kontrol etmeye öncelik verin; aynı anlamsal tip birden çok kez ortaya çıkıyorsa ek bilgi için `IAdjustValue.getName` kullanın.