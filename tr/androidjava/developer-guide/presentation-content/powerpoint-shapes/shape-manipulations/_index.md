---
title: Android'de Sunum Şekillerini Yönetme
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/androidjava/shape-manipulations/
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
- ön ayarlı şekil ayarı
- şekil geometrisi
- şekil düzen formatları
- Şekil SVG olarak
- Şekli SVG'ye dönüştür
- şekli hizalama
- şekli çevirme
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile sunum şekillerini tanımlamayı, ayarlamayı, kopyalamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, slayttaki şekilleri sıralı bir [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirdiğiniz yerin yanı sıra yığılma sırasının kaynağıdır: indeks `0` en arka şekildir, son indeks ise en ön şekildir.

Bu makale bu modeli izler. Öncelikle bir şekli güvenilir şekilde nasıl tanımlayacağınızı ve ön ayarlı şekil ayar noktalarını nasıl değiştireceğinizi açıklar, ardından şekilleri nasıl kopyalayacağınızı, kaldıracağınızı, gizleyeceğinizi ve yeniden sıralayacağınızı gösterir. Son bölümler, düzen seviyesinde biçimlendirme, SVG dışa aktarımı, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır; iş akışınızın gerektirdiği işlemleri yalnızca kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri bilinen bir dosya işlenirken kullanışlıdır, ancak istikrarlı tanımlayıcılar değildir. Bir şekil eklemek, kaldırmak veya yeniden sıralamak indeksini değiştirebilir. Sunumun nasıl oluşturulduğuna ve sürdürüldüğüne göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getName--) geliştirici kontrollü şablonlar için yararlıdır ve PowerPoint'in Seçim Bölmesi'nde kolayca incelenebilir. İsimler düzenlenebilir ve benzersiz olduğu garanti edilmez; kod bu ismlere bağlıysa bir adlandırma kuralı belirleyin.
- [AlternativeText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getAlternativeText--) bir erişilebilirlik açıklaması veya yazar tarafından sağlanan bir etiket zaten şekli tanımlıyorsa faydalıdır. Kullanıcılara görünür, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olduğu garanti edilmez. Anlamlı erişilebilirlik metnini sessizce bir veri tabanı anahtarı olarak kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) bir slayt içinde benzersiz, yalnızca okunabilir bir tanımlayıcıdır ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile bütünleştirirken veya bir şeklin ömrü boyunca kesin bir referansa ihtiyaç duyduğunuzda kullanın. Kopyalanan veya yeniden oluşturulan bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [getUniqueId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getUniqueId--) yöntemi sunum kapsamlı bir tanımlayıcı döndürür, ancak bu tanımlayıcı eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar gibi kullanılmamalıdır. Uzun vadeli kimlik önem taşıyorsa, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Alternatif metin başlığı ve açıklamasını okuma ve güncelleme ile ilgili pratik bir örnek için [Manage Alternative Text Titles and Descriptions](/slides/tr/androidjava/presentation-accessibility/) bölümüne bakın. Alternatif metni görselin anlamını okuyuculara açıklamak için kullanın ve kodun şekilleri bulmak için kullandığı şekil isimlerinden ayrı tutun.

Aşağıdaki örnek, tam karşılaştırma ile isimle arama yapar ve slayt kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde, kod yanlış nesneyle devam etmek yerine bu sonucu raporlar.

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

Bir işlem belirli bir şekil türüne özgü ise, tür‑özel üyeleri kullanmadan önce arabirimi kontrol edin. Bu örnek, adlandırılmış nesne bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ise yalnızca metin ve alternatif metni günceller.

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

## **Ön Ayarlı Şekil Ayarlarını Tanımlama ve Değiştirme**

Ön ayarlı geometri şekilleri, köşe boyutu, ok oranları veya yay açıları gibi özellikleri kontrol eden ayar noktaları sunabilir. Bu noktalara, yalnızca okunabilir [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) koleksiyonu üzerinden erişin. Koleksiyon şekil tarafından sağlanır, ancak her [IAdjustValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/) değiştirilebilen bir değer içerir.

Yalnızca sabit bir koleksiyon indeksine güvenmeyin. Ayarları döngüyle gezip yalnızca okunabilir [getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#getType--) yöntemini inceleyin; bu yöntemin döndürdüğü [ShapeAdjustmentType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapeadjustmenttype/) değeri ayarın neyi kontrol ettiğini tanımlar. Yalnızca okunabilir [getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#getName--) yöntemi ek tanımlama bilgisi sağlar ve aynı anlamsal tipe sahip birden fazla ayar bulunduğunda özellikle yararlıdır.

Ayara uygun değer yöntemini kullanın:

| Ayarlama türü | Amaç | Değiştirilecek değer |
|---|---|---|
| `CornerSize` | Yuvarlatılmış köşelerin boyutu | [setRawValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Ok kuyruğunun kalınlığı | `setRawValue` |
| `ArrowheadLength` | Ok başının uzunluğu | `setRawValue` |
| `ArrowheadWidth` | Ok başının genişliği | `setRawValue` |
| `StartAngle` | Dilim veya yay başlangıç açısı | [setAngleValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Dilim veya yay bitiş açısı | `setAngleValue` |

`getType` ve `getName` yalnızca okunabilir bilgiyi döndürür. `getRawValue` ve `setRawValue`, ön ayarın yerel geometri birimlerinde bir tam sayı ile çalışırken, `getAngleValue` ve `setAngleValue` derece cinsinden açıyla çalışır. Ayarların sayısı, sırası, anlamı ve geçerli aralığı ön ayar [ShapeType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) değerine bağlıdır. Bir ön ayar için geçerli bir değer, başka bir ön ayar için geçersiz olabilir ya da farklı bir etki yaratabilir.

`getType` `ShapeAdjustmentType.Custom` döndürdüğünde, API standart bir anlamsal anlamı tanımaz. `getName`, ön ayar tipi ve mevcut değeri inceleyin ve beklenen anlam ve aralık bilinmiyorsa ayarı değiştirmeyin. Tanınan tiplerde bile aynı tip birden fazla kez ortaya çıkıyorsa, değer seçmeden önce bunu kontrol edin. [Connector](/slides/tr/androidjava/connector/) makalesi, bağlayıcı bükme ayarları durumunu gösterir.

Aşağıdaki tam örnek, üç ön ayarlı şeklin varsayılan ve değiştirilmiş sürümlerini oluşturur. Her ayarı döngüyle gezerek adını ve tipini raporlar, `setRawValue` ile boyut‑ilişkili değerleri, `setAngleValue` ile açıları değiştirir ve sonucu kaydeder. Sol sütun varsayılan geometriyi, sağ sütun ise ayarlanmış yuvarlak dikdörtgeni, dört yönlü oku ve dilimi gösterir.

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

Değiştirmeden önce anlamsal tipi kontrol etmek, kodun amacını açıklar ve farklı ön ayarlı şekillerde aynı koleksiyon indeksinin aynı anlama gelmediğini varsayımlardan korur.

## **Şekil Koleksiyonunu Değiştirme**

Ekle, kopyala, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde anında etkili olur. Bir işlem şekil sayısını veya sırasını değiştiriyorsa, o işlemden önce yakalanmış indekslere güvenerek devam etmeyin.

### **Bir Şekli Kopyalama**

[addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) da bir kopya yaratır ancak belirtilen z‑order indeksine yerleştirir. Koordinat kabul eden aşırı yüklemeler kopyayı boyutunu değiştirmeden taşırken, genişlik ve yükseklik kabul eden aşırı yüklemeler yeniden boyutlandırabilir.

Örnek, bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne kopyalar ve ikinci bir kopyayı arkaya ekler. Her iki kopyada yapılan değişiklikler kaynak şekli etkilemez.

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

Kopyalama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini de kapsar. Bu değerlerin benzersiz olması gerekiyorsa, kopyaya yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak kopya yeni bir koleksiyon öğesi ve yeni bir şekil kimliği alır.

### **Şekilleri Kaldırma**

[remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) belirli bir şekil nesnesini koleksiyonundan siler. İndeksli dolaşma sırasında birden çok eşleşmeyi kaldırırken, kalan indekslerin geçerli kalması için sonundan başlayarak ilerleyin.

Bu örnek, belirli bir isim taşıyan her şekli kaldırır. Şekli sabit bir koleksiyon öğesi yerine mevcut indeksten okur ve gereksiz tip dönüşümü yapmaz.

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

Kaldırma sonrası şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere yapılan referanslar kaydedilmiş indekslerden daha güvenilirdir. Bağlayıcılar, animasyonlar ve kaldırılan nesneye başvuran diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şekli kaldırmak slaydın görünümünden daha fazlasını değiştirebilir.

### **Bir Şekli Gizleme**

[Hidden](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) özelliğini `true` olarak ayarlamak şekli koleksiyonda tutar ancak normal slayt gösterisinde görünmesini engeller. İndeksi, biçimlendirmesi ve içeriği koda açıktır, bu nedenle isteğe bağlı öğelerin daha sonra tekrar görünür hâle getirilebilmesi için uygundur.

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

Gizleme bir silme veya güvenlik işlemi değildir. Nesne hâlâ bulunabilir, kullanıcı ya da kod tarafından gizlenmesi kaldırılabilir ve sunum dosyasının bir parçası olmaya devam eder.

### **Z‑Sırasını Değiştirme**

Üst üste gelen şekiller koleksiyon sırasına göre çizilir. [reorder](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) mevcut bir şekli kopyalamadan hedef bir indeksine taşır. İndeks `0` arka, `size() - 1` ön demektir.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasında durur. Son indekse taşındığında öne gelir. Tüm ilgili şekiller eklenip/kopyalandıktan sonra z‑sırasını sonlandırın; çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir veya ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytlar ayrı şekil koleksiyonlarına sahiptir. Bir düzen koleksiyonundaki şekil, aynı konumda bir normal slayttaki şekille aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak veya değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getFillFormat--) ve [LineFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getLineFormat--) özelliklerini okur; her şeklin bir `AutoShape` olduğu varsayımı yapılmaz.

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

Bir düzenin düzenlenmesi, onu kullanan birden çok slaytı etkileyebilir. Normal bir slayt nesneyi devralıyor mu yoksa yerel bir geçersiz kılma içeriyor mu belirleyin ve o düzeni kullanan her slaytı test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[writeAsSvg](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) bir şeklin render edilmiş içeriğini akıma yazar. Sonuç, şekli içerir; tüm slayt arka planını veya komşu şekilleri içermez.

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

Renderlama sırasında sunumu açık tutun. Çıktı, şeklin biçimlendirmesine ve yazı tipleri ile resimler gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, tek bir şekil yerine slaytı dışa aktarın. Akışı çağıran taraf sahibi olur ve akışı kapatmak zorundadır.

## **Şekilleri Hizalama**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) aşırı yüklemeleri, tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapesalignmenttype/) kenar, merkez çizgi veya dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarları kullanılır; `false` yaparsanız seçili şekiller birbirlerine göre hizalanır.

Bu örnek, üç şekli slaydın üst kenarına hizalar. Döndürmeden hemen önce döndürülen şekil referansları geçerli indekslerine dönüştürülür.

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

Hizalama konumları değiştirir, z‑sırasını etkilemez. Göreceli hizalama genellikle en az iki şekil gerektirir, yatay veya dikey dağıtım ise boşluk tanımlamak için yeterli sayıda şekil gerektirir. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ve dönüşüm bilgilerini saklar. `getFlipH` ve `getFlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/nullablebool/) kullanır: `True` çevirme aktif, `False` devre dışı, `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu, çevrilmemiş bir şekil içerir.

![The shape before flipping](shape_to_be_flipped.png)

Örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir çünkü yeni bir [Frame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) atamak çerçevenin tamamını değiştirir.

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

Kaydedilen şekil, konum, boyut ve dönüşüm korunarak yatay ve dikey olarak aynalanır.

![The shape after flipping](flipped_shape.png)

## **SSS**

**Bir şekil tanımlayıcısı olarak koleksiyon indeksi kullanmalı mı?**

Sadece koleksiyon işlem süresi içinde değişmeyecekse kısa ömürlü işleme için kullanılabilir. Oluşturulmuş şablonlar için doğrulanmış bir `Name` veya `AlternativeText` kuralı, slayt kapsamlı interop çalışmaları için `OfficeInteropShapeId` tercih edin.

**Bir şekli gizlemek z‑sırasını kaldırır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Kopyalanan bir şekil neden başka bir şeklin önünde göründü?**

`addClone` kopyayı koleksiyonun sonuna ekler; bu z‑sırasının ön kısmıdır. Başlangıç indeksini seçmek için `insertClone` kullanın veya tüm şekiller eklendikten sonra `reorder` ile konumlandırın.

**Ön ayarlı bir şekil ayarını tanımlamak için sabit bir indeks kullanabilir miyim?**

Sadece kesin ön ayar ve koleksiyon düzeni doğrulandıysa kullanılabilir. `IGeometryShape.getAdjustments` üzerinden döngüyle geçmeyi, `IAdjustValue.getType` kontrol etmeyi tercih edin; aynı anlamsal tip birden fazla kez ortaya çıkıyorsa ek bilgi için `IAdjustValue.getName` kullanın.