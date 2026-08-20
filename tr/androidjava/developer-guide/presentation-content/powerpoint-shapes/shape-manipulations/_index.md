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
- şekil klonlama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini al
- şekil alternatif metni
- şekil düzen formatları
- şekil SVG olarak
- şekli SVG'ye dönüştür
- şekli hizalama
- şekli çevirme
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile sunum şekillerini tanımlamayı, klonlamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, bir slayttaki şekilleri sıralı bir [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirildiğiniz yer olduğu gibi, yığın sırasının da kaynağıdır: `0` indeksindeki şekil en arka taraftadır, son indeks ise en ön taraftadır.

Bu makale aynı modeli izler. Önce bir şekli güvenilir şekilde nasıl tanımlayacağınızı açıklar, ardından şekilleri klonlama, kaldırma, gizleme ve yeniden sıralama yöntemlerini gösterir. Son bölümler, düzen seviyesindeki biçimlendirme, SVG dışa aktarma, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır; böylece yalnızca iş akışınızın gerektirdiği işlemleri kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri, bilinen bir dosya işlenirken kullanışlıdır, ancak sabit tanımlayıcılar değildir. Bir şeklin eklenmesi, kaldırılması veya yeniden sıralanması indeksini değiştirebilir. Sunumun nasıl oluşturulduğuna ve korunduğuna göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getName--) geliştiricinin kontrolündeki şablonlar için yararlıdır ve PowerPoint’in Seçim Bölmesi’nde kolayca incelenebilir. İsimler düzenlenebilir ve benzersiz olması garanti edilmez; bu yüzden kodun buna bağlı olması durumunda bir isimlendirme standartı oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getAlternativeText--) bir erişilebilirlik açıklaması veya yazar tarafından sağlanan bir etiket zaten şekli tanımlıyorsa faydalıdır. Kullanıcılar tarafından görülür, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti edilmez. Anlamlı erişilebilirlik metnini sessizce bir veri tabanı anahtarı olarak kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) bir slayt içinde benzersiz olan, yalnızca okunabilen bir tanımlayıcıdır ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile bütünleştirirken veya bir şeklin ömrü boyunca net bir referansa ihtiyaç duyduğunuzda kullanın. Klonlanmış veya yeniden oluşturulmuş bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [getUniqueId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getUniqueId--) yöntemi sunum kapsamlı bir tanımlayıcı döner, ancak bu tanımlayıcı eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar olarak görülmemelidir. Uzun vadeli kimlik önemliyse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek, adı tam eşleşme ile arar ve slayt kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde, kod yanlış nesneyle devam etmek yerine bu sonucu bildirir.

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

Bir işlem belirli bir şekil türüne özgüyse, tür‑özel üyelere erişmeden önce arayüzü kontrol edin. Bu örnek, adlandırılmış nesne bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ise yalnızca metin ve alternatif metni günceller.

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

Ekle, klonla, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde hemen çalışır. Bir işlem şekil sayısını veya sırasını değiştiriyorsa, o işlemden önce yakalanmış indekslere güvenmeye devam etmeyin.

### **Bir Şekli Kopyalama**

[addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) de bir kopya oluşturur ancak belirtilen z‑sırası indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler, kopyayı boyutunu değiştirmeden taşır; genişlik ve yükseklik kabul edenler ise yeniden boyutlandırabilir.

Örnek, bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne klonlar ve ikinci bir klonu arkaya ekler. Her iki klon üzerindeki değişiklikler kaynak şekli etkilemez.

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

Klonlama, şeklin içeriğini ve biçimlendirmesini, adı ve alternatif metni dahil, kopyalar. Bu değerlerin benzersiz olması gerekiyorsa, klona yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak bir klon yeni bir koleksiyon öğesi ve yeni bir şekil kimliği olur.

### **Şekilleri Kaldırma**

[remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) belirli bir şekil nesnesini koleksiyonundan siler. İndeksli yineleme sırasında birden fazla eşleşme kaldırıyorsanız, her kalan indeksin geçerli kalması için sondan itibaren dolaşın.

Bu örnek, belirli bir isimle eşleşen her şekli kaldırır. Sabit bir koleksiyon öğesi yerine mevcut indekste şekli okur ve şekli gereksiz yere tip dönüşümü yapmaz.

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

Kaldırma işleminden sonra şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmemiş şekillere yapılan referanslar, kaydedilmiş indekslerden daha güvenilirdir. Ayrıca bağlayıcılar, animasyonlar ve kaldırılan nesneye referans verebilecek diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şekli kaldırmak slaydın görünümünden daha fazlasını değiştirebilir.

### **Bir Şekli Gizleme**

[Hidden](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) özelliğini `true` olarak ayarlamak, şekli koleksiyonda tutar ancak normal slayt gösterisinde görünmesini engeller. İndeksi, biçimlendirmesi ve içeriği koda hâlâ ulaşılabilir olduğu için, daha sonra geri getirilebilecek isteğe bağlı öğeler için gizleme uygundur.

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

Gizleme bir silme veya güvenlik işlemi değildir. Nesne hâlâ keşfedilebilir ve bir kullanıcı ya da kod tarafından gizlilikten çıkarılabilir; ayrıca sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirme**

Üst üste binen şekiller koleksiyon sırasına göre çizilir. [reorder](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) var olan bir şekli klonlamadan hedef indeksine taşır. `0` indeksi arka, `size() - 1` indeksi ön taraftır.

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

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasında durur. Son indekse taşındığında ön tarafta görünür. Tüm ilgili şekiller eklendikten veya klonlandıktan sonra z‑sırasını kesin, çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytların ayrı şekil koleksiyonları vardır. Bir düzen koleksiyonundaki şekil, normal bir slayttaki benzer konumlu şekil ile aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak veya değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getFillFormat--) ve [LineFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getLineFormat--) özelliklerini, her şeklin bir `AutoShape` olduğu varsayımı olmadan okur.

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

Bir düzeni düzenlemek, onu kullanan birden fazla slaytı etkileyebilir. Normal bir slayt nesneyi devralıyor mu yoksa yerel bir geçersiz kılma içeriyor mu belirleyin ve o düzeni kullanan her slaytı test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[writeAsSvg](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) bir şeklin render edilmiş içeriğini akıma yazar. Sonuç, tüm slayt arka planını veya komşu şekilleri değil yalnızca o şekli içerir.

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

Render ederken sunumu açık tutun. Çıktı, şeklin biçimlendirmesine ve yazı tipleri ile görüntüler gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, tek bir şekil yerine slaytı dışa aktarın. Akışı çağıran tarafın sorumluluğunda olup, kapatılması gerekir.

## **Şekilleri Hizalama**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) aşırı yüklemeleri, ya tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapesalignmenttype/) kenarı, merkez hattını veya dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarları kullanılır; `false` yaparsanız seçili şekiller birbirlerine göre hizalanır.

Bu örnek, üç şekli slaydın üst kenarına hizalar. Döndürülen şekil referansları, hizalamadan hemen önce mevcut indekslerine dönüştürülür.

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

Hizalama konumları değiştirir, z‑sırasını değiştirmez. Göreceli hizalama genellikle en az iki şekil gerektirir, yatay veya dikey dağıtım ise boşluk tanımlayacak yeterli sayıda şekil gerekir. Yöntemi çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ile dönüş açılarını saklar. `getFlipH` ve `getFlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/nullablebool/) kullanır: `True` çevirme etkin, `False` devre dışı, `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki sunum, çevirilmemiş bir şekil içerir.

![Çevirme öncesi şekil](shape_to_be_flipped.png)

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

Kaydedilen şekil, konumu, boyutu ve dönüşü korunurken yatay ve dikey olarak yansıtılır.

![Çevirme sonrası şekil](flipped_shape.png)

## **SSS**

**Bir koleksiyon indeksini şekil tanımlayıcı olarak kullanmalı mıyım?**

Sadece indeksin kullanılmadan önce koleksiyonun değişmeyeceği kısa vadeli işlemler için. Şablonlar için doğrulanmış bir `Name` ya da `AlternativeText` standartı, slayt‑kapsamlı interop işleri için `OfficeInteropShapeId` tercih edin.

**Bir şekli gizlemek, onu z‑sırasından kaldırır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Neden kopyalanan bir şekil diğerinin önünde göründü?**

`addClone` klonu koleksiyonun sonuna ekler; bu da z‑sırasının ön kısmıdır. Başlangıç indeksini seçmek için `insertClone` kullanın veya tüm şekiller eklendikten sonra `reorder` ile konumunu ayarlayın.