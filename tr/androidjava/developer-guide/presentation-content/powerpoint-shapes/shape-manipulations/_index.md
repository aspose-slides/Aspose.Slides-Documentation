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
- önceden ayarlanmış şekil ayarı
- şekil geometrisi
- şekil yerleşim formatları
- Şekil SVG olarak
- Şekli SVG'ye
- şekli hizalama
- şekli döndürme
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile sunum şekillerini tanımlamayı, ayarlamayı, kopyalamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve döndürmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, bir slayd üzerindeki şekilleri sıralı bir [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirmenizi sağlayan yer olmanın yanı sıra, yığılma sırasının kaynağıdır: indeks `0` en arkadaki şekli, son indeks ise en öndeki şekli gösterir.

Bu makale bu modeli izler. Öncelikle bir şekli güvenilir şekilde nasıl tanımlayacağınızı ve önceden ayarlanmış şekil ayar noktalarını nasıl değiştireceğinizi açıklar, ardından şekilleri nasıl kopyalayacağınızı, kaldıracağınızı, gizleyeceğinizi ve yeniden sıralayacağınızı gösterir. Son bölümler, düzen‑seviyesi biçimlendirme, SVG dışa aktarma, hizalama ve döndürme ayarlarını kapsar. Her örnek bağımsızdır, bu yüzden yalnızca iş akışınızın gerektirdiği işlemleri kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri bilinen bir dosya işlenirken kullanışlıdır, ancak sabit tanımlayıcılar değildir. Bir şeklin eklenmesi, kaldırılması veya yeniden sıralanması indeksini değiştirebilir. Sunumun nasıl oluşturulduğuna ve yönetildiğine göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getName--) geliştirici‑kontrollü şablonlar için yararlıdır ve PowerPoint’in Seçim Bölmesi’nde kolayca incelenebilir. İsimler düzenlenebilir ve benzersiz olması garanti edilmez; bu yüzden koda bağlıysanız bir adlandırma konvansiyonu oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getAlternativeText--) erişilebilirlik açıklaması ya da yazar‑tarafından sağlanan bir etiket zaten şekli tanımlıyorsa işe yarar. Kullanıcılar tarafından görülür, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti edilmez. Anlamlı erişilebilirlik metnini sessizce bir veritabanı anahtarı olarak kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) yalnızca bir slayt içinde benzersiz olan ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelen salt‑okunur bir tanımlayıcıdır. PowerPoint ile bütünleştirirken veya bir şeklin ömrü boyunca kesin bir referansa ihtiyaç duyduğunuzda bunu kullanın. Kopyalanmış ya da yeniden oluşturulmuş bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [getUniqueId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getUniqueId--) yöntemi sunum kapsamlı bir tanımlayıcı döndürür, ancak bu tanımlayıcı eklentiler içindir ve yeniden atanabilir. Dış anahtar olarak kalıcı kabul edilmemelidir. Uzun vadeli kimlik önemliyse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek, isme tam eşleşme ile arama yapar ve slayt‑kapsamlı interop kimliğini rapor eder. Şablon beklenen şekli içermediğinde, kod hatalı nesneyle devam etmek yerine bu sonucu raporlar.

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

Bir işlem belirli bir şekil türüne özgüyse, tür‑özel üyeleri kullanmadan önce arabirimi kontrol edin. Bu örnek, adlandırılmış nesne bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ise yalnızca metin ve alternatif metni günceller.

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

Önceden ayarlanmış geometri şekilleri, köşe boyutu, ok oranları ya da yay açıları gibi özellikleri kontrol eden ayar noktaları sunabilir. Bu noktalara, salt‑okunur [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) koleksiyonu üzerinden erişin. Koleksiyon şekil tarafından sağlanır, ancak her [IAdjustValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/) değiştirilebilen bir değere sahiptir.

Yalnızca sabit bir koleksiyon indeksine güvenmeyin. Ayarlamalar üzerinde döngü kurun ve salt‑okunur [getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#getType--) yöntemini inceleyin; bu yöntemin döndürdüğü [ShapeAdjustmentType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapeadjustmenttype/) değeri ayarın neyi kontrol ettiğini tanımlar. Salt‑okunur [getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#getName--) yöntemi ek tanımlama bilgisi sağlar ve aynı anlamsal türe sahip birden çok ayar bulunduğunda özellikle yararlıdır.

Ayarlamanın anlamına uyan değer yöntemini kullanın:

| Ayarlama türü | Amaç | Değiştirilecek değer |
|---|---|---|
| `CornerSize` | Yuvarlatılmış köşelerin boyutu | [setRawValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Bir ok kuyruğunun kalınlığı | `setRawValue` |
| `ArrowheadLength` | Ok ucu uzunluğu | `setRawValue` |
| `ArrowheadWidth` | Ok ucu genişliği | `setRawValue` |
| `StartAngle` | Pasta ya da yay başlangıç açısı | [setAngleValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Pasta ya da yay bitiş açısı | `setAngleValue` |

`getType` ve `getName` salt‑okunur bilgiler döndürür. `getRawValue` ve `setRawValue`, önceden ayarlanmış şeklin yerel geometri birimlerinde bir tamsayıyla çalışırken, `getAngleValue` ve `setAngleValue` derece cinsinden açıyla çalışır. Ayarların sayısı, sırası, anlamı ve geçerli aralığı önceden ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) değerine bağlıdır. Bir önceden ayarlanmış için geçerli olan bir değer, başka birinde geçersiz ya da farklı bir etki yapabilir.

`getType` `ShapeAdjustmentType.Custom` döndürdüğünde, API standart bir anlamsal anlamı tanımaz. `getName`, önceden ayarlanmış tür ve mevcut değeri inceleyin ve beklenen anlam ve aralık bilinmiyorsa ayarı değiştirmeyin. Tanınan türler için bile aynı tür birden çok kez ortaya çıkıyorsa bir değer seçmeden önce kontrol edin. [Connector](/slides/tr/androidjava/connector/) makalesi, bağlayıcı bükülme ayarlarıyla bu durumu gösterir.

Aşağıdaki tam örnek, üç önceden ayarlanmış şeklin varsayılan ve değiştirilmiş sürümlerini oluşturur. Her ayar üzerinden döner, ismini ve tipini raporlar, boyutla ilgili değerleri `setRawValue` ile, açıları ise `setAngleValue` ile değiştirir ve sonucu kaydeder. Sol sütun varsayılan geometriyi, sağ sütun ise ayarlanmış yuvarlak dikdörtgeni, dört yönlü oku ve pastayı gösterir.

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

Değişiklik yapmadan önce anlamsal türü kontrol etmek, kodun amacını açıkça belirtir ve aynı koleksiyon indeksinin farklı önceden ayarlanmış şekillerde aynı anlama geldiği varsayımını önler.

## **Şekil Koleksiyonunu Değiştirme**

Ekle, kopyala, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını ya da sırasını değiştiriyorsa, o işlemden önce yakalanan indekslere güvenmeyin.

### **Bir Şekli Kopyalama**

[addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) da bir kopya oluşturur ancak belirtilen z‑order indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler, kopyayı boyutunu değiştirmeden taşırken; genişlik ve yükseklik kabul edenler ise yeniden boyutlandırabilir.

Bu örnek bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne kopyalar ve ikinci bir kopyayı arka tarafa ekler. Her iki kopyada yapılan değişiklikler kaynak şekli etkilemez.

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

Kopyalama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini dahil ederek kopyalar. Bu değerlerin benzersiz olması gerekiyorsa klona yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak kopya yeni bir koleksiyon öğesi ve yeni bir şekil kimliği alır.

### **Şekilleri Kaldırma**

[remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) belirli bir şekil nesnesini kendi koleksiyonundan siler. İndeksli döngü sırasında birden çok eşleşme kaldırılırken, kalan indekslerin geçerli kalması için sonundan geriye doğru dolaşın.

Bu örnek, belirli bir isim taşıyan her şekli kaldırır. Sabit bir koleksiyon öğesi yerine mevcut indeksteki şekli okur ve gereksiz tür dönüşümü yapmaz.

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

Kaldırma sonrası, şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere referanslar, kaydedilmiş indekslerden daha güvenilirdir. Ayrıca kaldırılan nesneye referans verebilecek bağlayıcılar, animasyonlar ve diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şekli kaldırmak slaytın görünümünden daha fazlasını değiştirebilir.

### **Bir Şekli Gizleme**

[Hidden](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) özelliğini `true` olarak ayarlamak, şekli koleksiyonda tutar ancak normal slayt gösterisinde görünmesini engeller. İndeksi, biçimi ve içeriği kod tarafından erişilebilir olmaya devam eder; bu yüzden daha sonra geri getirilebilecek isteğe bağlı öğeler için gizleme uygundur.

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

Gizleme, silme ya da güvenlik değildir. Nesne hâlâ keşfedilebilir ve bir kullanıcı ya da kod tarafından tekrar görünür hâle getirilebilir; ayrıca sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirme**

Üst‑üste binen şekiller koleksiyon sırasına göre çizilir. [reorder](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) mevcut bir şekli kopyalamadan hedef bir indekse taşır. İndeks `0` arka, `size() - 1` ön taraftır.

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

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasında yer alır. Son indekse taşındığında ön tarafta görünür. Tüm ilgili şekiller eklenip/kopyalandıktan sonra z‑sırasını sonlandırın; çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığılımı değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve master slaytlar ayrı şekil koleksiyonlarına sahiptir. Bir düzen koleksiyonundaki şekil, normal bir slayttaki benzer konumdaki şekille aynı nesne değildir. Düzenin sağladığı biçimlendirmeyi anlamak ya da değiştirmek için düzen şekillerini inceleyin.

Aşağıdaki örnek, her bir düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getFillFormat--) ve [LineFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getLineFormat--) özelliklerini okur; her şeklin bir `AutoShape` olduğu varsayımı yapılmaz.

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

Bir düzeni düzenlemek, onu kullanan birden fazla slaytı etkileyebilir. Normal bir slayt nesneyi devralıyor mu ya da yerel bir geçersiz kılma içeriyor mu belirleyin ve o düzeni kullanan her slaytı test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[writeAsSvg](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) bir şeklin renderlanmış içeriğini bir akıma yazar. Sonuç, şekli içerir; tüm slayt arka planı ya da komşu şekiller dahil değildir.

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

Renderlama sırasında sunumu açık tutun. Çıktı, şeklin biçimlendirmesine ve fontlar, görüntüler gibi kaynaklara bağlıdır. Tüm kompozisyon gerektiğinde, tek bir şekil yerine slaytı dışa aktarın. Çağıran akımı sahiplenir ve kapatmak zorundadır.

## **Şekilleri Hizalama**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) aşırı yüklemeleri, tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapesalignmenttype/) kenarı, merkez çizgiyi veya dağıtım kipini belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarlarını, `false` yaparsanız seçili şekilleri birbirine göre hizalarsınız.

Bu örnek, üç şekli slaytın üst kenarına hizalar. Döndürmeden hemen önce döndürülen şekil referansları mevcut indekslerine çevrilir.

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

Hizalama konumları değiştirir, z‑order’ı etkilemez. Göreli hizalama genellikle en az iki şekil gerektirir, yatay ya da dikey dağıtım ise aralık tanımlamak için yeterli sayıda şekil gerektirir. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Döndürme**

[ShapeFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey döndürme ayarları ile rotasyonu saklar. `getFlipH` ve `getFlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/nullablebool/) kullanır: `True` döndürmeyi etkinleştirir, `False` devre dışı bırakır ve `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu, döndürülmemiş bir şekil içerir.

![The shape before flipping](shape_to_be_flipped.png)

Örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki döndürme ayarını değiştirir. Bu önemlidir çünkü yeni bir [Frame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) atamak çerçevenin tamamını değiştirir.

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

Kaydedilen şekil, konum, boyut ve rotasyonu korurken yatay ve dikey olarak yansıtılır.

![The shape after flipping](flipped_shape.png)

## **SSS**

**Bir şekil tanımlayıcısı olarak koleksiyon indeksi kullanılmalı mı?**

Sadece koleksiyonun işlem süresince değişmeyeceği kısa‑vadeli işlemelerde kullanılabilir. Oluşturulmuş şablonlar için doğrulanmış bir `Name` ya da `AlternativeText` konvansiyonu, slayt‑kapsamlı interop işleri için `OfficeInteropShapeId` tercih edin.

**Bir şekli gizlemek, onu z‑sırasından çıkarır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir ya da tekrar görünür hâle getirilebilir.

**Kopyalanan bir şekil neden başka bir şeklin önünde göründü?**

`addClone` kopyayı koleksiyonun sonuna ekler; bu z‑order’da ön taraftır. Başlangıç indeksini belirlemek için `insertClone` kullanın ya da tüm şekiller eklendikten sonra `reorder` ile konumlandırın.

**Önceden ayarlanmış bir şekil ayarını tanımlamak için sabit bir indeks kullanılabilir mi?**

Sadece önceden ayarlanmış tip ve koleksiyon düzeni kesin olarak doğrulandıysa. `IGeometryShape.getAdjustments` üzerinden döngü kurup `IAdjustValue.getType` kontrol etmeyi tercih edin; aynı anlamsal tip birden çok kez ortaya çıktığında ek bilgi için `IAdjustValue.getName` kullanın.