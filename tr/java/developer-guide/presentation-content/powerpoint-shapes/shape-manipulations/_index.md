---
title: Java'da Sunum Şekillerini Yönet
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
- önceden tanımlı şekil ayarı
- şekil geometrisi
- şekil düzen formatları
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

Aspose.Slides for Java, bir slayttaki şekilleri sıralı bir [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirdiğiniz yer olmanın yanı sıra yığın sıralarının kaynağıdır: indeks `0` en arkadaki şekildir, son indeks ise en öndeki şekildir.

Bu makale bu modeli izler. İlk olarak bir şekli güvenilir bir şekilde nasıl tanımlayacağınızı ve önceden tanımlı şekil ayar noktalarını nasıl değiştireceğinizi açıklar, ardından şekilleri kopyalama, kaldırma, gizleme ve yeniden sıralama gösterir. Son bölümler düzen düzeyi biçimlendirme, SVG dışa aktarımı, hizalama ve çevrim ayarlarını kapsar. Her örnek bağımsızdır, böylece yalnızca iş akışınızın gerektirdiği işlemleri kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri bilinen bir dosya işlendiğinde kullanışlıdır, ancak sabit tanımlayıcılar değildir. Bir şekil eklemek, kaldırmak veya yeniden sıralamak indeksini değiştirebilir. Sunumun nasıl oluşturulduğu ve korunduğuna göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getName--) geliştirici kontrolündeki şablonlar için yararlıdır ve PowerPoint'in Seçim Bölmesi'nde kolayca incelenebilir. İsimler düzenlenebilir ve benzersiz olması garantilenmez; kod bu isimlere bağlıysa bir adlandırma kuralı oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getAlternativeText--) erişilebilirlik açıklaması ya da yazar tarafından sağlanan bir etiket zaten şekli tanımlıyorsa yararlıdır. Kullanıcılara görünür, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olması garantilenmez. Anlamlı erişilebilirlik metnini sessizce veritabanı anahtarı olarak kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) okunabilir bir tanımlayıcıdır, bir slayt içinde benzersizdir ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile bütünleştirirken veya bir şeklin yaşam süresi boyunca kesin bir referansa ihtiyacınız olduğunda kullanın. Kopyalanan ya da yeniden oluşturulan bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [getUniqueId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getUniqueId--) yöntemi sunum kapsamlı bir tanımlayıcı döndürür, ancak bu tanımlayıcı eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar olarak kullanılmamalıdır. Uzun vadeli kimlik önemliyse eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Alternatif metin başlığı ve açıklamasını okuma ve güncelleme üzerine pratik bir örnek için [Manage Alternative Text Titles and Descriptions](/slides/tr/java/presentation-accessibility/) bölümüne bakın. Alternatif metni, görselin okuyuculara anlamını açıklamak için kullanın ve kodun şekilleri bulmak için kullandığı şekil adlarından ayrı tutun.

Aşağıdaki örnek, adı tam eşleme ile arar ve slayt kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde kod, yanlış nesneyle devam etmek yerine bu sonucu raporlar.

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

Bir işlem belirli bir şekil türüne özgüyse, tür‑özel üyelere erişmeden önce arabirimi kontrol edin. Bu örnek, adlandırılmış nesne bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ise yalnızca metni ve alternatif metni günceller.

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

## **Önceden Tanımlı Şekil Ayarlarını Tanımlama ve Değiştirme**

Önceden tanımlı geometri şekilleri, köşe boyutu, ok oranları veya yay açıları gibi özellikleri kontrol eden ayar noktaları sunar. Bu noktalara yalnızca okunabilir [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igeometryshape/#getAdjustments--) koleksiyonu üzerinden erişilir. Koleksiyon şekil tarafından sağlanır, ancak her [IAdjustValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iadjustvalue/) değiştirilebilen bir değer içerir.

Sabit bir koleksiyon indeksine güvenmeyin. Ayarları döngüyle gezip yalnızca okunabilir [getType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iadjustvalue/#getType--) yöntemini inceleyin; bu yöntemin döndürdüğü [ShapeAdjustmentType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapeadjustmenttype/) değeri ayarın neyi kontrol ettiğini açıklar. Okunabilir [getName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iadjustvalue/#getName--) yöntemi ek tanımlama bilgisi sağlar ve aynı anlamsal türde birden fazla ayar içeren önceden tanımlı şekillerde özellikle yararlıdır.

Ayara karşılık gelen anlamı taşıyan değer yöntemini kullanın:

| Ayarlama türü | Amacı | Değiştirilecek değer |
|---|---|---|
| `CornerSize` | Yuvarlatılmış köşelerin boyutu | [setRawValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Ok kuyruğunun kalınlığı | `setRawValue` |
| `ArrowheadLength` | Ok başının uzunluğu | `setRawValue` |
| `ArrowheadWidth` | Ok başının genişliği | `setRawValue` |
| `StartAngle` | Pasta veya yay başlangıç açısı | [setAngleValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Pasta veya yay bitiş açısı | `setAngleValue` |

`getType` ve `getName` yalnızca okunabilir bilgi döndürür. `getRawValue` ve `setRawValue` önceden tanımlı şeklin yerel geometri birimlerinde bir tamsayıyla çalışırken, `getAngleValue` ve `setAngleValue` derece cinsinden açıyla çalışır. Ayarların sayısı, sırası, anlamı ve geçerli aralığı önceden tanımlı [ShapeType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igeometryshape/#getShapeType--) değerine bağlıdır. Bir önceden tanımlı şekil için geçerli bir değer, başka bir şekil için geçersiz olabilir ya da farklı bir etki yaratabilir.

`getType` `ShapeAdjustmentType.Custom` döndürdüğünde API standart bir anlamsal anlam tanımaz. `getName`, önceden tanımlı tür ve mevcut değeri inceleyin; beklenen anlam ve aralık bilinmiyorsa ayarı değiştirmeyin. Tanınan türler için bile aynı tip birden fazla kez ortaya çıkıyorsa bir değer seçmeden önce kontrol edin. [Connector](/slides/tr/java/connector/) makalesi, bağlayıcı bükülme ayarlarıyla bu durumu gösterir.

Aşağıdaki tam örnek, üç önceden tanımlı şeklin varsayılan ve değiştirilmiş sürümlerini oluşturur. Her ayarı döngüyle geçer, adını ve tipini raporlar, boyutla ilgili değerleri `setRawValue` ile, açıları `setAngleValue` ile değiştirir ve sonucu kaydeder. Sol sütun varsayılan geometriyi tutar; sağ sütun ise ayarlanmış yuvarlak dikdörtgeni, dört yönlü oku ve pastayı gösterir.

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

Değiştirmeden önce anlamsal türü kontrol etmek, kodun niyetini açıkça ortaya koyar ve farklı önceden tanımlı şekillerde aynı koleksiyon indeksinin aynı anlamı taşıdığını varsaymayı engeller.

## **Şekil Koleksiyonunu Değiştirme**

Ekle, kopyala, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını veya sırasını değiştiriyorsa, o işlemden önce yakalanmış indekslere bağlı kalmayın.

### **Bir Şekli Kopyalama**

[addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) da bir kopya oluşturur ancak belirtilen z‑sırası indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler klonu boyutunu değiştirmeden taşırken, genişlik ve yükseklik alan aşırı yüklemeler yeniden boyutlandırabilir.

Örnek, bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne kopyalar ve ikinci kopyayı arkaya ekler. Her iki kopyada yapılan değişiklikler kaynak şekli etkilemez.

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

Kopyalama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini de içerecek şekilde kopyalar. Bu değerlerin benzersiz olması gerekiyorsa kopyaya yeni mantıksal kimlikler atayın. Karmaşık şekiller tarafından kullanılan kaynaklar sunum tarafından yönetilir, ancak bir kopya yeni bir koleksiyon öğesi ve yeni bir şekil kimliğiyle kalır.

### **Şekilleri Kaldırma**

[remove](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) belirli bir şekil nesnesini koleksiyonundan siler. Dizinsel yineleme sırasında birden çok eşleşmeyi kaldırırken, kalan her indeksin geçerli kalması için sondan başlayarak dolaşın.

Bu örnek, belirli bir ad taşıyan her şekli kaldırır. Şekli sabit bir koleksiyon öğesi olarak değil, mevcut indeksteki şekli okuyarak kaldırır ve gereksiz tip dönüşümü yapmaz.

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

Kaldırma işleminden sonra şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere referanslar, kaydedilmiş indekslere göre daha güvenilirdir. Ayrıca kaldırılan nesneye başvuran bağlayıcılar, animasyonlar ve diğer sunum öğelerini de göz önünde bulundurun; görünür bir şekli kaldırmak slaydın görünümünden daha fazlasını değiştirebilir.

### **Bir Şekli Gizleme**

[Hidden](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setHidden-boolean-) özelliğini `true` olarak ayarlamak, şekli koleksiyonda tutar ancak normal gösterimde görünmesini engeller. İndeksi, biçimlendirmesi ve içeriği kod için kullanılabilir kalır; bu, daha sonra geri getirilebilecek isteğe bağlı öğeler için uygundur.

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

Gizleme silme veya güvenlik değildir. Nesne hâlâ keşfedilebilir ve kullanıcı ya da kod tarafından yeniden görünür hâle getirilebilir ve sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirme**

Üst üste binen şekiller koleksiyon sırasına göre çizilir. [reorder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) mevcut bir şekli yeni bir indeks konumuna taşır; kopyalama yapmaz. İndeks `0` arkadadır; `size() - 1` öndedir.

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

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasındadır. Son indekse taşındığında öne gelir. Tüm ilgili şekiller eklendikten ya da kopyalandıktan sonra z‑sırasını sonlandırın; bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytların ayrı şekil koleksiyonları vardır. Bir düzen koleksiyonundaki şekil, normal bir slaytta aynı konumda olan şekil ile aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak ya da değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getFillFormat--) ve [LineFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getLineFormat--) özelliklerini okur; her şeklin `AutoShape` olduğu varsayımına dayanmaz.

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

Bir düzenin düzenlenmesi, onu kullanan birden çok slaytı etkileyebilir. Normal bir slayt nesneyi devralıyor mu yoksa yerel bir geçersiz kılma içeriyor mu belirleyin ve o düzeni kullanan tüm slaytları test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[writeAsSvg](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) bir şeklin render edilmiş içeriğini bir akıma yazar. Sonuç, şekli içerir; tüm slayt arka planını veya komşu şekilleri içermez.

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

Render ederken sunumu açık tutun. Çıktı, şeklin biçimlendirmesine ve yazı tipleri, görseller gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, tek bir şekil yerine slaytı dışa aktarın. Çağıran akımı yönetir ve kapatmalıdır.

## **Şekilleri Hizalama**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) aşırı yüklemeleri, tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapesalignmenttype/) kenar, merkez çizgi ya da dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarları kullanılır; `false` yaparsanız seçili şekiller birbirine göre hizalanır.

Bu örnek, üç şekli slaytın üst kenarına hizalar. Döndürülen şekil referansları, hizalamadan hemen önce mevcut indekslerine dönüştürülür.

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

Hizalama konumları değiştirir, z‑sırayı değiştirmez. Göreceli hizalama genellikle en az iki şekil gerektirir, yatay ya da dikey dağıtım ise boşluk tanımlamak için yeterli şekil sayısı gerektirir. Yöntemi çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ve döndürmeyi saklar. `getFlipH` ve `getFlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/java/com.aspose.slides/nullablebool/) kullanır: `True` çevirme etkin, `False` devre dışı, `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu, çevirilmemiş bir şekil içerir.

![Ters çevrilmeden önceki şekil](shape_to_be_flipped.png)

Örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir çünkü yeni bir [Frame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) atamak çerçevenin tamamını değiştirir.

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

Kaydedilen şekil, konum, boyut ve döndürme korunurken yatay ve dikey olarak yansıtılır.

![Çevirildikten sonraki şekil](flipped_shape.png)

## **SSS**

**Bir koleksiyon indeksini şekil tanımlayıcısı olarak kullanmalı mıyım?**

Sadece koleksiyon işlem süresince değişmeyecek kısa vadeli işlemler için kullanılabilir. Oluşturulmuş şablonlar için doğrulanmış bir `Name` ya da `AlternativeText` konvansiyonu, slayt kapsamlı interop işleri için `OfficeInteropShapeId` tercih edin.

**Bir şekli gizlemek, onu z‑sırasından kaldırır mı?**

Hayır. Gizli bir şekil aynı indeksle koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Klonlanan bir şekil neden başka bir şeklin önünde göründü?**

`addClone` klonu koleksiyonun sonuna ekler; bu, z‑sırasının ön kısmıdır. Başlangıç indeksini seçmek için `insertClone` kullanın veya tüm şekiller eklendikten sonra `reorder` ile konumlandırın.

**Önceden tanımlı bir şekil ayarını tanımlamak için sabit bir indeks kullanabilir miyim?**

Yalnızca kesin önceden tanımlı şekil ve koleksiyon düzeni doğrulandıysa. `IGeometryShape.getAdjustments` döngüsüyle ilerleyin ve `IAdjustValue.getType` kontrol edin; aynı anlamsal tip birden çok kez ortaya çıkıyorsa ek bilgi için `IAdjustValue.getName` kullanın.