---
title: "Java'da Sunum Şekillerini Yönetme"
linktitle: "Şekil Manipülasyonu"
type: docs
weight: 40
url: /tr/java/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil klonlama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini al
- şekil alternatif metni
- şekil düzen biçimleri
- şekil SVG olarak
- şekli SVG'ye
- şekil hizalama
- şekil çevirme
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile sunum şekillerini tanımlamayı, klonlamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Java, bir slayttaki şekilleri sıralı bir [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/) olarak temsil eder. Bu koleksiyon, şekilleri bulup değiştirdiğiniz yer olduğu gibi yığın sırasının da kaynağıdır: indeks `0` en arkadaki şekli, son indeks ise en öndeki şekli gösterir.

Bu makale bu modeli izler. Önce bir şekli güvenilir şekilde nasıl tanımlayacağınızı açıklar, ardından şekilleri nasıl kopyalayacağınızı, kaldıracağınızı, gizleyeceğinizi ve yeniden sıralayacağınızı gösterir. Son bölümler, düzen seviyesindeki biçimlendirme, SVG dışa aktarma, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır; böylece iş akışınızın gerektirdiği işlemleri tek başına kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri bilinen bir dosya işlenirken kullanışlıdır, ancak sabit tanımlayıcılar değildir. Bir şekle ekleme, kaldırma veya yeniden sıralama yapıldığında indeksi değişebilir. Sunumun nasıl oluşturulduğu ve sürdürüldüğüne göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getName--) geliştirici kontrolündeki şablonlar için kullanışlıdır ve PowerPoint'in Seçim Bölmesi'nde kolayca incelenebilir. İsimler düzenlenebilir ve benzersiz olması garanti değildir; kod bu isimlere bağlıysa bir adlandırma kuralları oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getAlternativeText--) bir erişilebilirlik açıklaması veya yazar tarafından sağlanan bir etiket zaten şekli tanımlıyorsa işe yarar. Kullanıcılar tarafından görülebilir, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti değildir. Anlamlı erişilebilirlik metnini sessizce bir veritabanı anahtarı olarak yeniden kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) okunabilir bir tanımlayıcıdır, slayt içinde benzersizdir ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile bütünleştirirken veya bir şeklin ömrü boyunca belirsiz bir referansa ihtiyaç duyduğunuzda kullanın. Kopyalanmış veya yeniden oluşturulmuş bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [getUniqueId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getUniqueId--) yöntemi sunum kapsamlı bir tanımlayıcı döndürür, ancak bu tanımlayıcı eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar olarak kullanılmamalıdır. Uzun vadeli kimlik önemliyse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ var olduğunu doğrulayın.

Aşağıdaki örnek, tam eşleşme ile isme göre arama yapar ve slayt kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde kod, yanlış nesneyle devam etmek yerine bu sonucu raporlar.

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

Bir işlem belirli bir şekil türüne özgü ise, tür‑özel üyeleri kullanmadan önce arabirimi kontrol edin. Bu örnek, adlandırılmış nesne bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ise yalnızca metni ve alternatif metni günceller.

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

## **Şekil Koleksiyonunu Değiştirme**

Ekleme, kopyalama, kaldırma ve yeniden sıralama yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını veya sırasını değiştiriyorsa, o işlemden önce yakalanmış indekslere güvenmeye devam etmeyin.

### **Bir Şekli Kopyalama**

[addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) da bir kopya oluşturur ancak belirtilen z‑order indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler kopyayı boyutunu değiştirmeden taşır; genişlik ve yükseklik alan aşırı yüklemeler ise yeniden boyutlandırabilir.

Örnek, bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne kopyalar ve ikinci bir kopyayı arka tarafa ekler. Her iki kopyada yapılan değişiklikler kaynak şekli etkilemez.

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

Kopyalama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini de dahil olmak üzere kopyalar. Bu değerlerin benzersiz olması gerekiyorsa, kopyaya yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak kopya yeni bir koleksiyon öğesi ve yeni bir şekil kimliği alır.

### **Şekilleri Kaldırma**

[remove](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) belirli bir şekil nesnesini koleksiyonundan siler. İndeksli yineleme sırasında birden çok eşleşmeyi kaldırırken, her kalan indeksin geçerli kalması için sondan başlayarak dolaşın.

Bu örnek, belirli bir isim taşıyan her şekli kaldırır. Şekli sabit bir koleksiyon öğesi yerine geçerli indekste okur ve gereksiz dönüşüm yapmaz.

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

Kaldırma işleminden sonra şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere yapılan referanslar, kaydedilmiş indekslerden daha güvenilirdir. Ayrıca kaldırılan nesneye referans veren bağlayıcıları, animasyonları ve diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şekli kaldırmak slaydın görünümünden daha fazlasını etkileyebilir.

### **Bir Şekli Gizleme**

[Hidden](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setHidden-boolean-) özelliğini `true` yapmak şekli koleksiyonda tutar ancak normal slayt gösterisinde görünmesini engeller. İndeksi, biçimlendirmesi ve içeriği koda hâlâ açıktır; bu yüzden daha sonra geri getirilebilecek isteğe bağlı öğeler için gizleme uygundur.

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

Gizleme, silme ya da güvenlik değildir. Nesne hâlâ keşfedilebilir ve bir kullanıcı ya da kod tarafından tekrar görünür hâle getirilebilir; aynı zamanda sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirme**

Üst üste binen şekiller koleksiyon sırasına göre çizilir. [reorder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) mevcut bir şekli kopyalamadan hedef indekse taşır. İndeks `0` arka, `size() - 1` ön demektir.

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

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasında durur. Son indekse taşındığında öne gelir. Tüm ilgili şekiller eklenip kopyalandıktan sonra z‑sırasını kesin, çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytların ayrı şekil koleksiyonları vardır. Bir düzen koleksiyonundaki şekil, aynı konumda bir normal slayttaki şekille aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak veya değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getFillFormat--) ve [LineFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getLineFormat--) özelliklerini okur; tüm şekillerin `AutoShape` olduğu varsayımı yapılmaz.

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

Bir düzenin düzenlenmesi, onu kullanan birden çok slaytı etkileyebilir. Normal bir slayt nesneyi devralıyor mu yoksa yerel bir geçersiz kılma mı içeriyor belirleyin ve o düzeni kullanan her slaytı test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[writeAsSvg](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) bir şeklin render edilmiş içeriğini bir akıma yazar. Sonuç yalnızca şekli içerir; tüm slayt arka planı veya komşu şekiller dahil değildir.

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

Render ederken sunumu açık tutun. Çıktı, şeklin biçimlendirmesine ve yazı tipleri, görüntüler gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, tek bir şekil yerine slaytı dışa aktarın. Çağıran, akımı yönetir ve kapatmak zorundadır.

## **Şekilleri Hizalama**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) aşırı yüklemeleri, tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapesalignmenttype/) kenarı, merkez çizgiyi veya dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarları, `false` yaparsanız seçili şekiller birbirlerine göre hizalanır.

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

Hizalama konumları değiştirir, z‑sırasını etkilemez. Göreceli hizalama genellikle en az iki şekil gerektirirken, yatay ya da dikey dağıtım için aralığı tanımlayacak yeterli şekil gerekir. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ile dönüşümleri saklar. `getFlipH` ve `getFlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/java/com.aspose.slides/nullablebool/) kullanır: `True` çevirme açar, `False` kapatır, `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumunda tek bir çevirilmemiş şekil bulunur.

![Şekil çevirme öncesi](shape_to_be_flipped.png)

Örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirilir. Bu, yeni bir [Frame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) atandığında çerçevenin tamamının değişeceği için önemlidir.

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

![Şekil çevirme sonrası](flipped_shape.png)

## **SSS**

**Bir koleksiyon indeksi şekil tanımlayıcısı olarak kullanılmalı mı?**

Sadece koleksiyonun indeks kullanımdan önce değişmeyeceği kısa süren işleme için kullanılabilir. Oluşturulmuş şablonlar için doğrulanmış bir `Name` veya `AlternativeText` konvansiyonu, slayt‑kapsamlı interop işleri için ise `OfficeInteropShapeId` tercih edilmelidir.

**Bir şekli gizlemek z‑sırasını kaldırır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Kopyalanan bir şekil neden başka bir şeklin önünde göründü?**

`addClone` kopyayı koleksiyonun sonuna ekler; bu da z‑sırasının ön kısmıdır. İlk indeksi seçmek için `insertClone` kullanın veya tüm şekiller eklendikten sonra `reorder` ile konumlandırın.