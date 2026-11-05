---
title: Android'de PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/androidjava/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- eskiz efekti
- şekil çizgi eskizi
- birleştirme stili biçimlendirme
- gradyan doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- katı renk doldurma
- şekil şeffaflığı
- siyah-beyaz şekil işleme
- gri tonlamalı şekil işleme
- şekil döndürme
- 3D kırbıyık efekti
- 3D döndürme efekti
- biçimlendirmeyi sıfırlama
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Android'de PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT ve PPTX dosyaları için doldurma, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'te şekilleri kenarlıklarını, doldurmalarını ve efektlerini ayarlayarak biçimlendirin. Aspose.Slides for Android via Java, bu ayarları programlı olarak, şeffaflık, dönüş ve 3D biçimlendirme dahil olmak üzere kontrol etmenizi sağlar.

![PowerPoint'te şekil biçimlendirme seçenekleri](format-shape-powerpoint.png)

Aspose.Slides for Android via Java, PowerPoint'te mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arayüzler ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Bir şeklin kenarlığını kontrol etmek için [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) kullanın. Bu örnek, mavi kesikli bir kenarlığa sahip doldurulmamış bir dikdörtgen oluşturur. [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) kalın-ince birleşik bir çizgi seçer, [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) genişliğini 7 puana ayarlar ve [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) kesik desenini seçer.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Sunumda biçimlendirilmiş çizgiler](formatted-lines.png)

### **Özel Çizgi Kesik Desenlerini Ayarlama**

Önceden tanımlı çizgi stilleri ihtiyacınız olan kesik uzunluklarını ve boşlukları sağlamadığında, örneğin marka kenarlıkları veya teknik diyagramlar için, [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) kullanın. Bir desen atandığında, çizgi kesik stili otomatik olarak [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) olarak değişir.

Dizi elemanları, kesikle başlayarak, kesik ve boşluk uzunlukları arasında, aynı yön içinde değişir. Her değer, çizgi genişliğinin bir katıdır: `{ 4, 2 }` değeri, 3 puan genişliğinde olduğunda, 12 puanlık bir kesik ve ardından 6 puanlık bir boşluk üretir. Tam kesik-boşluk segmentlerini tanımlamak için sonlu, negatif olmayan değer çiftlerini kullanın. Örnek, her kesik ve boşluğun görünür kalmasını sağlamak için pozitif değerler kullanır.

Bu örnek, aynı uzunlukta ve düz uçlu beş mavi çizgi oluşturur. İlk üç, 3 puan genişliğinde desenleri karşılaştırır. Dördüncüsü, ilk deseni iki kat genişlikte tekrar eder, kesik ve boşluk uzunluklarını iki katına çıkarır. Beşincisi, özel bir desenden düz bir çizgiye geçer.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Son çizgiyi katı bir stile döndür.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Önceden tanımlı bir kesikli stile geri dönmek için, [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-)’e [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) parametresini geçirin. Seçilen stil, çizginin görünümünü kontrol eder.

PowerPoint'te sonuç, yukarıdan aşağıya: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; ve **Solid, 3 pt**.

![PowerPoint'te üç özel kesik desen, ilk deseni kullanan daha geniş bir çizgi ve düz bir çizgi](custom-dash-patterns.png)

### **Çizgi Uçlarını Ayarlama**

Açık bir çizginin uçlarını ayarlamak için [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) kullanın. [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) sınıfı üç açık uç stilini sağlar:

- `Flat`: Çizgi uç noktasında durur.
- `Round`: Yarım dairesel uç, uç noktasının yarı çizgi genişliği kadar ötesine uzanır.
- `Square`: Kare uç, uç noktasının yarı çizgi genişliği kadar ötesine uzanır.

Sınıf ayrıca `NotDefined` değerini içerir; bu, açıkça bir uç stili atanmadığı anlamına gelir.

Uçlar, çizgi uçlarına sembol ekleyen ok uçlarından ve çizgi segmentleri arasındaki köşeleri kontrol eden birleşimlerden farklıdır. Bu örnek, yalnızca uç şekillerinin karşılaştırılmasını sağlamak için [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) ve [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) ile ok uçlarını devre dışı bırakır.

Aşağıdaki örnek, diğer yönleri aynı olan, 20 puan genişliğinde üç yatay çizgi oluşturur. Yukarıdan aşağıya, düz, yuvarlak ve kare uçlar kullanılır. Uç noktalarının yatay koordinatları aynıdır; yuvarlak ve kare uçlar her bir uç noktasının 10 puan ötesine uzanır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint'te sonuç, yukarıdan aşağıya: **Flat**, **Round** ve **Square**.

![PowerPoint'te aynı kalın çizgilerde düz, yuvarlak ve kare uçlar](line-caps.png)

## **Şekil Çizgilerine Eskiz Efektleri Uygulama**

Eskiz efekti, bir şekil çizgisini el çizimi gibi gösterir. Çizgi ayarlarına erişmek için [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) kullanın, eskiz ayarlarına erişmek için [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) kullanın ve [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) sınıfındaki bir değeri seçmek için [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) kullanın.

Aşağıdaki Java kodu, [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) etkisini nasıl uygulayacağınızı, açıkça atanmış değeri nasıl okuyacağınızı ve [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) ile etkisi nasıl kaldıracağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya düzen slaytından devralınabiliyorsa, [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--)'i, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) erişin ve [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--) okuyun. Etkin değer, devralmanın çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır. Bu örnek, ilk slaydında en az bir şekil bulunan mevcut bir sunum gerektirir ve her iki değeri de yazdırır:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Birleştirme Stilleri Biçimlendirme**

İşte üç birleştirme türü seçeneği:

* Round
* Miter
* Bevel

Birleştirme stili, iki kenar segmentinin bir köşede nasıl buluştuğunu kontrol eder. Yuvarlatılmış köşeler için **Round**, keskin köşeler için **Miter**, düzleştirilmiş köşeler için **Bevel** kullanın.

![Sunumda birleştirme stili](join-style-powerpoint.png)

Bu örnek, 15 puan genişliğinde mavi kenarlıklı üç siyah dikdörtgen oluşturur. Köşelerin nasıl çizildiğini karşılaştırmak için, sırasıyla [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) sınıfının miter, bevel ve round değerlerini uygulamak üzere [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) kullanır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Keskin Köşelerde Miter Birleştirmeleri Sınırlama**

[ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-)'i [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) olarak ayarlayarak ve [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) kullanarak keskin bir köşenin ne kadar uzayabileceğini sınırlayın.

Sınır, birleştirmenin iç ve dış köşeleri arasındaki mesafenin çizgi genişliğine oranıdır. Örneğin, `8` değeri, çizgi genişliğinin sekiz katına kadar bir miter uzunluğuna izin verir; bu puan cinsinden bir ölçü değildir. Köşe bu sınırı aşarsa, PowerPoint o köşede kesikli bir birleştirme (bevel) kullanır. Daha büyük bir sınır, daha keskin noktalar sağlar. Bu ayar yalnızca miter birleştirmelerini etkiler ve köşe her iki sınır içinde kaldığında değişiklik görünür bir etki yaratmaz.

Bu örnek, 20 puan genişliğinde kenarlıklı iki aynı, doldurulmamış üçgen oluşturur. Sol üçgen `2` sınırı kullanır, sağ üçgen `8` kullanır. Her üçgen 80 puan genişliğinde ve 160 puan yüksekliğindedir; üst köşesinin miter uzunluğu ile çizgi genişliği oranı yaklaşık `4.12`'dir. Sonuç olarak, PowerPoint sol tepeyi kesik (bevel) yapar ve sağ tepeyi korur.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint'te sonuç: solda **Miter limit 2**, sağda **miter limit 8**.

![PowerPoint'te miter limit 2 ile kesik tepe ve miter limit 8 ile sivri tepe](miter-limits.png)

## **Gradyan Doldurma**

Gradyan doldurma, bir şekil boyunca renkleri karıştırır. Bu örnek, kırmızıdan mor renge 45 derece açıyla lineer bir gradyan kullanarak bir elips doldurur; [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--) kullanılır. [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) yöntemi, renk duraklarını 0 ve 1 konumlarına, yani gradyanın başlangıcı ve sonuna yerleştirir. Mevcut durakları temizlemek, yalnızca bu iki rengin kullanılmasını sağlar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gradyan dolgu ile elips](gradient-fill.png)

Eğer bir gradyan, PowerPoint'te göründüğü gibi dışa aktarılan bir görüntüde farklı görünüyorsa, [Choose a Gradient Rendering Style](/slides/tr/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) başlığına bakın. Sunumda saklanan gradyan doldurmayı değiştirmeden bir renderleme stili seçebilirsiniz.

### **Lineer Gradyan Açısını Ayarlama**

[IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) kullanarak bir [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) doldurmanın yönünü kontrol edin. Açı derece cinsinden ölçülür ve saat yönünde artar: `0` soldan sağa, `90` üstten alta, `180` sağdan sola, `270` alttan üste gider. Kesirli açılar desteklenir. `[0, 360)` aralığının dışındaki sonlu açılar bir devir için normalleştirilir; örneğin, `-45` `315`, `360` ise `0` olur.

Bu örnek, `0`, `0.5` ve `1` konumlarında aynı kırmızı, yeşil ve mavi durakları olan altı dikdörtgen oluşturur. Ölçeklendirme devre dışı bırakılmıştır, böylece açı dikdörtgenlerin oranlarından bağımsız olarak karşılaştırılabilir. Açılar, soldan sağa doğru, ilk satırda `0`, `45` ve `90`; ikinci satırda ise `135`, `180` ve `270`'dir.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint'te sonuç:

![Üst satırda 0, 45 ve 90 derece, alt satırda 135, 180 ve 270 derece lineer gradyanlar](linear-gradient-angles.png)

### **Şekille Lineer Gradyanı Ölçeklendirme**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) bir [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) değeri kabul eder. Şeklin oranları değiştikçe geometrik gradyan açısını korumak için açıkça `False`, gradyanı şeklin genişliği ve yüksekliğiyle ölçeklendirmek için `True` olarak ayarlayın. Ölçeklendirme etkin olduğunda, görünür açı, kare olmayan bir şekilde atanmış açıdan farklı olabilir.

Aşağıdaki örnek, `45` derece açı ve açı karşılaştırmasıyla aynı renk duraklarını kullanır. Sol sütun `False`, sağ sütun `True` kullanır. Her sütun, geniş bir dikdörtgenin üstünde yüksek bir dikdörtgen içerir. İkisi de aynı geniş boyutlarla başlar; ikinci dikdörtgenin genişlik ve yüksekliğini değiştirmek, doldurmanın gradyan ayarlarını değiştirmeden yeniden boyutlandırmaya nasıl yanıt verdiğini gösterir.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint'te sonuç, solda ölçeklendirme devre dışı ve sağda etkin:

![Sol tarafta LinearGradientScaled False, sağ tarafta True olan 45 derecelik gradyanı olan geniş ve yüksek dikdörtgenler](linear-gradient-scaling.png)

Ölçeklendirme devre dışı olduğunda, diyagonal renk şeritleri her iki dikdörtgende aynı yönü korur. Ölçeklendirme etkin olduğunda, şeritler şeklin oranlarıyla uzar. Bu, bir şekli farklı bir boyuta uyarlarken şablonun gradyanını yeniden üretmeye yardımcı olur. Kare bir şekilde, ölçeklendirme etkinleştirilmesi bu `45` derece gradyanın görünümünü değiştirmez.

Açı ve ölçeklendirme ayarları her iki lineer gradyana da uygulanır. [GradientShape.Radial veya GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) doldurmalarını kontrol etmezler.

### **Açıyı Gradyan Yönüyle Birleştirme**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/) sınıfından bir gradyan stili seçer; bu, sayısal bir açının yerini tutmaz. Lineer bir gradyan için, köşe stilleri, [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) ile atanan açıyı değiştirmeden renklerin dağıtıldığı alanı değiştirebilir. Açıları veya ölçeklendirmeyi karşılaştırırken yönü aynı tutun.

Aşağıdaki örnek, aynı ayarları ters sırayla uygular. İki dikdörtgen aynı görünüme sahiptir: yönü açıdan önce ya da sonra atamak sonucu değiştirmez.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Desen Doldurma**

Desen doldurma, nokta, çizgi veya kare gibi iki renkli bir tasarım uygular. Bu örnek, bir çit deseni seçmek için [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) kullanır. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) açık gri arka planı, [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) ise sarı desen rengini sağlar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Desenli doldurulmuş dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

Resim doldurma, bir şekil içinde bir görüntü kullanır. Bu örnek, yerel bir görüntü gerektirir ve [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) kullanarak sunumun görüntü koleksiyonına yükler. [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-)'u döşeli moda ayarlamak, görüntüyü dikdörtgen içinde tekrar eder. Burada kullanılan kaynak görüntü aşağıda gösterilmiştir:

![Lotus resmi](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Resim doldurulmuş şekil](picture-fill.png)

### **Resmi Doku Olarak Döşeme**

Döşeli bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, aşağıdaki [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) arabirimi ve [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) sınıfı yöntemlerini kullanabilirsiniz:

- `[setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Resim doldurma modunu ayarlar—`Tile` veya `Stretch`.
- `[setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Döşemelerin şekil içinde hizalanmasını belirtir.
- `[setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- `[setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Döşemenin şeklin kökeninden (puan cinsinden) yatay ofsetini ayarlar.
- `[setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Döşemenin şeklin kökeninden (puan cinsinden) dikey ofsetini ayarlar.
- `[setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- `[setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Bu örnek, yerel bir görüntü gerektirir ve [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/)’yi orijinal boyutunun %50'si kadar tekrar edecek şekilde yapılandırır. −32 puan ofsetler, döşemeleri yatay ve dikey olarak kaydırır; alt-sağ hizalama ve iki yönde çevirme, tekrar edilen dokunun nasıl düzenleneceğini belirler.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Döşeme seçenekleri](tile-options.png)

## **Katı Renk Doldurma**

Katı doldurma, bir şekle tek, tekdüze bir renk verir. Bu örnek, katı doldurma modunu seçmek için [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) kullanır, sarı rengi [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) aracılığıyla atar ve ardından dikdörtgeni bir sunumda kaydeder.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Katı renk dolgulu şekil](solid-color-fill.png)

### **Tema Referanslarını Koruyarak Renkleri Kopyalama**

[IColorFormat.copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) kullanarak bir renk tanımını, renk türü, tema referansı ve dönüşümler dahil, kopyalayın. Bu, doldurma rengini sunum temasına bağlı kalması gereken şekiller arasında aktarırken faydalıdır. Yöntem yalnızca rengi kopyalar; doldurma tipini, kenarlığı veya diğer şekil biçimlendirmelerini kopyalamaz. Hedefin doldurma tipini açıkça [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) ile ayarlayın.

Bu örnek, soldan sağa üç dikdörtgen oluşturur: kaynak, tema farkında bir kopya ve sabit RGB kopyası. Kaynak, ilk vurgu rengini referanslamak için [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setSchemeColor-int-) kullanır ve [IColorOperationCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icoloroperationcollection/#add-int-float-) ile bir ton ekler. RGB kopyası, kaynağın etkin doldurma rengini kullanır, böylece üçü başlangıçta aynı görünür. [IColorFormat.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setColor-java.lang.Integer-) çağırmak, sabit bir RGB değeri ayarlar ve mevcut renk dönüşümlerini temizler.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Tema referansları yeni vurgu rengini izler; sabit RGB değeri bunu yapmaz.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tema değişikliğinden önce, üç doldurma eşleşir:

![Kaynak, copyFrom hedefi ve sabit RGB hedefi aynı mavi doldurmalarla](color-copy-before.png)

Tema değişikliğinden sonra, kaynak ve tema farkında kopya yeni vurgu rengini izler ve tonlarını korur. Sabit RGB kopyası mavi kalır:

![Kaynak ve copyFrom hedefi turuncu doldurmalarla, sabit RGB hedefi ise mavi kalır](color-copy-after.png)

Kopyalanan tanım, kaynaktan bağımsızdır. Daha sonra kaynağın tema referansını değiştirmek, başka bir renk atamak veya dönüşümlerini eklemek/çıkarmak hedefi etkilemez. Tema değişikliği, her iki şekli de etkiler çünkü her biri aynı tema rengine bağımsız olarak referans verir.

PPTX dosyasını kaydedip yeniden açmak, [IColorFormat.getColorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorType--) tarafından döndürülen kopyalanan renk tipini, tema referansını ve [IColorFormat.getColorTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorTransform--) tarafından döndürülen dönüşüm koleksiyonunu korur. Tanımı RGB'ye dönüştürmez.

Farklı tema bağlamları arasında kopyalama yaparken, örneğin farklı vurgu paletlerine sahip sunumlarda, kopyalanan referans hedefin temasına göre çözülür. Aynı referans ve dönüşümler, bu nedenle farklı bir görünür renk üretebilir. Tema renklerini yapılandırma hakkında daha fazla bilgi için [Presentation Theme](/slides/tr/androidjava/presentation-theme/) sayfasına bakın.

## **Slayt Arka Planını Şekil Doldurması Olarak Kullanma**

Bir şeklin slayt arka planıyla eşleşmesi gerektiğinde, örneğin bir sunum şablonunda, [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) kullanın. Herhangi bir açık doldurmayı kaldırmak için önce doldurma tipini [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) ile [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) olarak ayarlayın. Bu kombinasyonla, şekil stil doldurması yerine slayt arka planını kullanır. Bayrağı etkinleştirmek yalnızca mevcut açık doldurmayı kaldırmaz.

Bu, [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/)’den farklıdır: arka plan doldurması, şeklin arkasındaki nesneleri slayt arka planının ilgili alanı ile kapatırken, doldurma yok bırakma bu nesneleri görünür tutar. Bir gradyan, her şeklin içinde yeniden başlamaz; slayt ile hizalı kalır.

Aşağıdaki örnek, slayt tarafından devralınan bir ana arka plan oluşturur ve üç dikdörtgenin arkasına magenta bir bant yerleştirir. Sol dikdörtgen arka planı kullanır, orta dikdörtgen doldurması yoktur ve sağ dikdörtgen arka plan doldurmasından açık turuncu doldurmaya geçer.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Gradyanı ustadan devral.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // Bu nesneyi önce ekle, böylece dikdörtgenlerin arkasında görünür.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Açık bir doldurma uygulamadan önce arka plan doldurmayı devre dışı bırak.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç, soldan sağa: **background fill**, **no fill**, ve **explicit fill**. Magenta bant, sol ve sağ dikdörtgenler tarafından gizlenir ancak orta dikdörtgen üzerinden görünür kalır.

![Magenta bant üzerine arka plan doldurma, doldurma yok ve açık turuncu doldurma](background-fill.png)

Aynı davranış, slayt üzerinde doğrudan tanımlanan veya bir yerleşimden devralınan bir arka plana da uygulanır. Şekil, slaytın çözümlenmiş arka planını kullanır; örnek, slayt ve yerleşim arka planlarını tanımsız bırakır, böylece ana temin eder.

## **Şeffaflığı Ayarlama**

Katı doldurma için, renk alfa bileşeni opaklığı kontrol eder: 0 tamamen şeffaf, 255 tamamen opaktır. Bu örnek, sarı bir dikdörtgen için 128 alfa değeri kullanır; bu, yaklaşık %50 şeffaflık sağlar ve altındaki dikdörtgenin görünür kalmasını sağlar. Renk, [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) aracılığıyla atanır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

[IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) kullanarak bir şekli slayt düzleminde döndürün. Açı derece cinsinden ölçülür; bu örnek, bir dikdörtgeni 5 derece saat yönünde döndürür ve sunumu kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şekil döndürmesi](shape-rotation.png)

## **3D Kırbıyık Efektleri Ekleme**

[IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) kullanarak bir şekle derinlik ve kırbıyıklı kenarlar verin. Bu örnek, turuncu kenarlıklı yeşil bir elips oluşturur, derinliği 4 puan olarak ayarlamak için [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) kullanır, ve genişliği ve yüksekliği 6 puan olan dairesel bir üst kırbıyık uygulamak için [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) kullanır. Ön taraftan bir ortografik kamera ve üç noktalı aydınlatma, kırbıyığı görünür kılar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![3D kırbıyık efekti](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekleme**

Bir şeklin 3D görünümü, kamera ayarlarıyla kontrol edilir. Bu örnek, enlem, boylam ve devrim açıları sırasıyla 40, 35 ve 20 derece olmak üzere [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) kullanır. İzometrik bir kamera seçmek için [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) kullanılır, dengeli aydınlatma için [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) seçilir ve ardından biçimlendirilmiş dikdörtgen kaydedilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![3D döndürme efekti](3D-rotation-effect.png)

## **Şekiller İçin Siyah-Beyaz İşleme Kontrolü**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) yöntemi, bir sunum siyah-beyaz modunda görüntülendiğinde veya işlendiğinde bireysel bir şeklin nasıl işlendiğini belirler. Tek başına siyah-beyaz görüntüyü etkinleştirmez ve normal renk modunda şeklin dolgusunu, çizgisini veya diğer biçimlendirmelerini değiştirmez.

İstenen davranışı seçmek için [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) sınıfından bir değer kullanın. Örneğin, `Automatic` işleme uygulamasının dönüşümü seçmesine izin verir, `Gray` ve `LightGray` gri renklendirme kullanır, `BlackWhite` sadece siyah ve beyazı, `Black` ve `White` tek renk zorlar, `Color` normal renklendirmeyi korur ve `Hidden` şekli siyah-beyaz modunda atar. `NotDefined`, şekil düzeyinde bir modun atanmadığı anlamına gelir.

Bu örnek, turuncu bir dikdörtgen oluşturur ve gri renklendirme seçmek için [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) kullanır. Kaydedilen şekil, normal renk gösteriminde turuncu dolgusunu korur ve siyah-beyaz gösterim ayarlarını dikkate alan uygulamalardan gri renklendirme ister:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normal renk modunda, dikdörtgen turuncu dolgusunu korur. Siyah-beyaz görüntüleme iş akışında, modu `Gray` olduğu için gri renklendirme kullanır. Bu, tam renkli bir slaytı korurken, yazdırma, ön izleme veya sunumun siyah-beyaz gösterim ayarlarını dikkate alan diğer iş akışları için farklı bir görünüm tanımlamanızı sağlar.

## **Biçimlendirmeyi Sıfırlama**

[ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) kullanarak slayt yer tutucularının konumunu, boyutunu ve biçimlendirmesini ilgili düzen yer tutucularından geri yükleyin. Bu örnek, düzen bağlantılı yer tutuculara sahip mevcut bir sunum gerektirir ve kaydetmeden önce her slaytı sıfırlar. İlgili düzen yer tutucusu olmayan şekiller sıfırlanmaz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi son sunum dosya boyutunu etkiler mi?**

Renkler, çizgi stilleri ve efekt ayarları, gömülü görüntüler ve medyaya kıyasla genellikle çok az veri ekler. Resim dolguları, görüntüleri sunumda depoladığı için dosya boyutunu artırabilir.

**Bir slayttaki aynı biçimlendirmeye sahip şekilleri nasıl tespit edip gruplayabilirim?**

Her şeklin temel biçimlendirme özelliklerini—doldurma, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerinin bir kümesini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyaya kaydedebilir miyim?**

Evet. İstenilen stillere sahip örnek şekilleri bir şablon slayt destesi veya .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri kopyalayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.