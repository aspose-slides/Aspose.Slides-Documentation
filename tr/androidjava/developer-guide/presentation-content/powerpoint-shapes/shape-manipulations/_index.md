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
- interop şekil kimliğini alma
- şekil alternatif metni
- şekil düzen formatları
- şekil SVG olarak
- şekli SVG'ye dönüştürme
- şekli hizalama
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android için Java aracılığıyla Aspose.Slides'de şekiller oluşturmayı, düzenlemeyi ve optimize etmeyi öğrenin ve yüksek performanslı PowerPoint sunumları sunun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunumlarda şekillerle nasıl çalışılacağını açıklar. Bir slaytta bir şekli bulma, kopyalama, kaldırma, gizleme, sırasını değiştirme, Interop şekil kimliğini alma ve tanımlama ve sonraki işlemler için alternatif metin ayarlama işlemlerini gösterir.

Ayrıca şekiller için düzen formatlarına nasıl erişileceği, bir şeklin SVG olarak render edilmesi, bir slaytta şekillerin hizalanması ve yatay ile dikey aynalama için çevirme özelliklerinin kullanılması konularını da kapsar. Ek olarak, makale şekil birleştirme, yığılma sırası ve şekil kilitleme üzerine kısa bir SSS bölümü içerir.

## **Bir Slaytta Şekil Bulma**
Bu konu, geliştiricilerin bir slayttaki belirli bir şekli dahili kimliğini (Id) kullanmadan bulmalarını kolaylaştıran basit bir teknik tanımlar. PowerPoint Sunum dosyalarının, bir slayttaki şekilleri dahili benzersiz Id dışındaki bir yolla tanımlamanın mümkün olmadığını bilmek önemlidir. Geliştiricilerin dahili benzersiz Id'yi kullanarak bir şekli bulması zor görünebilir. Slaytlara eklenen tüm şekillerin bir Alt Metni vardır. Geliştiricilere belirli bir şekli bulmak için alternatif metin kullanmalarını öneririz. Gelecekte değiştirmeyi planladığınız nesneler için alternatif metni MS PowerPoint ile tanımlayabilirsiniz.

İstediğiniz herhangi bir şeklin alternatif metni ayarlandıktan sonra, bu sunumu Aspose.Slides for Android via Java kullanarak açabilir ve bir slayta eklenen tüm şekillerde döngü yapabilirsiniz. Her döngüde, şeklin alternatif metnini kontrol edebilir ve eşleşen alternatif metne sahip şekil sizin ihtiyaç duyduğunuz şekil olacaktır. Bu tekniği daha iyi göstermek için, bir slaytta belirli bir şekli bulup doğrudan o şekli döndüren bir yöntem oluşturduk: [findShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-).

```java
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekleyin
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Bulunacak şeklin alternatif metni
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Bir slaytta şekli alternatif metniyle bulmak için yöntem implementasyonu
public static IShape findShape(ISlide slide, String alttext)
{
    // Slayt içindeki tüm şekiller üzerinde döngü
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Slaytın alternatif metni gerekenle eşleşiyorsa
        // Şekli döndür
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Bir Şekli Kopyalamak**
Bir şekli bir slayta kopyalamak için Aspose.Slides for Android via Java kullanarak:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Slaydın indeksini kullanarak referansını alın.
3. Kaynak slaydın şekil koleksiyonuna erişin.
4. Sunuma yeni bir slayt ekleyin.
5. Kaynak slaydın şekil koleksiyonundaki şekilleri yeni slayta kopyalayın.
6. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek bir grup şekli slayta ekler.

```java
// Presentation sınıfını örnekleyin
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Write the PPTX file to disk
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Şekli Kaldırmak**
Aspose.Slides for Android via Java, geliştiricilerin herhangi bir şekli kaldırmasına olanak tanır. Bir şekli herhangi bir slayttan kaldırmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Belirli AlternativeText değerine sahip şekli bulun.
4. Şekli kaldırın.
5. Dosyayı diske kaydedin.

```java
// Presentation nesnesi oluştur
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);

    // Dikdörtgen tipinde otomatik şekil ekle
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Sunumu diske kaydet
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Şekli Gizlemek**
Aspose.Slides for Android via Java, geliştiricilerin herhangi bir şekli gizlemesine olanak tanır. Bir şekli herhangi bir slayttan gizlemek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Belirli AlternativeText değerine sahip şekli bulun.
4. Şekli gizleyin.
5. Dosyayı diske kaydedin.

```java
// PPTX'i temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);

    // Dikdörtgen tipinde otomatik şekil ekle
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Sunumu diske kaydet
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Şekil Sırasını Değiştirmek**
Aspose.Slides for Android via Java, geliştiricilerin şekilleri yeniden sıralamasına olanak tanır. Şekilleri yeniden sıralamak, hangi şeklin ön yüzde, hangisinin arka yüzde olacağını belirler. Bir slayttaki şekilleri yeniden sıralamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Bir şekil ekleyin.
4. Şeklin metin çerçevesine bazı metinler ekleyin.
5. Aynı koordinatlarla başka bir şekil ekleyin.
6. Şekilleri yeniden sıralayın.
7. Dosyayı diske kaydedin.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Interop Şekil Kimliğini Almak**
Aspose.Slides for Android via Java, geliştiricilerin slayt kapsamında benzersiz bir şekil tanımlayıcısı almasını sağlayan bir yöntemi, sunum kapsamında benzersiz bir tanımlayıcı sağlayan [getUniqueId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#getUniqueId--) yöntemine karşı olarak sunar. [getOfficeInteropShapeId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) yöntemi, [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape) arayüzüne ve [Shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Shape) sınıfına eklenmiştir. [getOfficeInteropShapeId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) yöntemi tarafından döndürülen değer, Microsoft.Office.Interop.PowerPoint.Shape nesnesinin Id değerine karşılık gelir. Aşağıda örnek bir kod verilmiştir.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Slayt kapsamındaki benzersiz şekil tanımlayıcısını alıyor
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Şekil İçin Alternatif Metin Ayarlama**
Aspose.Slides for Android via Java, geliştiricilerin herhangi bir şeklin AlternateText'ini ayarlamasına olanak tanır. Bir sunumdaki şekiller, [AlternativeText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) veya [Shape Name](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#setName-java.lang.String-) yöntemiyle ayırt edilebilir. [setAlternativeText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) ve [getAlternativeText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#getAlternativeText--) yöntemleri, Aspose.Slides ve Microsoft PowerPoint kullanılarak okunabilir veya ayarlanabilir. Bu yöntemi kullanarak bir şekli etiketleyebilir ve şekli kaldırma, gizleme veya slayttaki şekilleri yeniden sıralama gibi farklı işlemler gerçekleştirebilirsiniz. Bir şeklin AlternateText'ini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Slayta herhangi bir şekil ekleyin.
4. Yeni eklenen şekille bazı işlemler yapın.
5. Şekilleri gezerek bir şekil bulun.
6. AlternativeText'i ayarlayın.
7. Dosyayı diske kaydedin.

```java
// PPTX'i temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);

    // Dikdörtgen tipinde otomatik şekil ekle
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Sunumu diske kaydet
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Şekil İçin Düzen Formatlarına Erişim**
Aspose.Slides for Android via Java, bir şekil için düzen formatlarına erişmek için basit bir API sağlar. Bu makale, düzen formatlarına nasıl erişileceğini göstermektedir.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Şekli SVG Olarak Render Etmek**
Artık Aspose.Slides for Android via Java, bir şekli SVG olarak render etmeyi destekliyor. [writeAsSvg](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (ve aşırı yüklemesi) [Shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Shape) sınıfına ve [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape) arayüzüne eklenmiştir. Bu yöntem, şeklin içeriğini bir SVG dosyası olarak kaydetmeye olanak tanır. Aşağıdaki kod parçacığı, slaytın şeklinin bir SVG dosyasına nasıl dışa aktarılacağını gösterir.

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Şekli Hizalamak**
Aspose.Slides, şekilleri slayt kenar boşluklarına ya da birbirlerine göre hizalamayı sağlar. Bu amaçla, aşırı yüklenmiş [SlidesUtil.alignShape()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) yöntemi eklenmiştir. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ShapesAlignmentType) enum'ı olası hizalama seçeneklerini tanımlar.

**Example 1**

Aşağıdaki kaynak kod, 1, 2 ve 4 indeksli şekilleri slaydın üst kenarı boyunca hizalar.

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**Example 2**

Aşağıdaki örnek, şekil koleksiyonundaki en alttaki şekle göre tüm koleksiyonun nasıl hizalanacağını gösterir.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Çevirme Özellikleri**
Aspose.Slides'ta, [ShapeFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapeframe/) sınıfı, şekillerin yatay ve dikey aynalanmasını `flipH` ve `flipV` özellikleri aracılığıyla kontrol eder. Her iki özellik de `byte` tipindedir; `1` değeri çevirme, `0` çevirme yok ve `-1` varsayılan davranışı kullanır. Bu değerler, bir şeklin [Frame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getFrame--) özelliğinden erişilebilir.

Çevirme ayarlarını değiştirmek için, şeklin mevcut konumu ve boyutu, istenen `flipH` ve `flipV` değerleri ve dönüş açısı ile yeni bir [ShapeFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapeframe/) örneği oluşturulur. Bu örnek şeklin [Frame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getFrame--) özelliğine atanıp sunum kaydedildiğinde, ayna dönüşümleri uygulanır ve çıktı dosyasına yansıtılır.

Diyelim ki, bir sample.pptx dosyamız var ve ilk slayt, aşağıda gösterildiği gibi varsayılan çevirme ayarlarına sahip tek bir şekil içeriyor.

![Çevrilecek şekil](shape_to_be_flipped.png)

Aşağıdaki kod örneği, şeklin mevcut çevirme özelliklerini alır ve hem yatay hem de dikey olarak çevirir.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Şeklin yatay çevirme özelliğini al.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Şeklin dikey çevirme özelliğini al.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Yatay olarak çevir.
    byte flipV = NullableBool.True; // Yatay olarak çevir.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Çevrilmiş şekil](flipped_shape.png)

## **SSS**

**Bir slaytta şekilleri (birleşim/kesişim/çıkarma) masaüstü editöründeki gibi birleştirebilir miyim?**

Yerleşik bir Boolean işlem API'si yoktur. İstediğiniz konturu kendiniz oluşturarak (ör. sonuç geometrisini [GeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/geometrypath/) ile hesaplayıp o konturla yeni bir şekil oluşturup, isteğe bağlı olarak orijinal şekilleri kaldırarak) buna yakın bir sonuç elde edebilirsiniz.

**Yığılma sırasını (z-order) nasıl kontrol edebilirim ki bir şekil her zaman "üstte" kalsın?**

Slaydın [shapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslide/#getShapes--) koleksiyonundaki ekleme/taşıma sırasını değiştirin. Öngörülebilir sonuçlar için, diğer tüm slayt değişikliklerinden sonra z-sırasını sonlandırın.

**Bir şekli PowerPoint'te kullanıcıların düzenlemesini engellemek için "kilitleyebilir" miyim?**

Evet. Şekil seviyesinde koruma bayrakları ayarlayın (ör. seçim, hareket, yeniden boyutlandırma, metin düzenleme kilidi). Gerekirse, master veya layout üzerine aynı kısıtlamaları uygulayın. Bunun bir UI seviyesi koruma olduğunu, güvenlik özelliği olmadığını unutmayın; daha güçlü koruma için dosya seviyesinde sınırlamaları, ör. [salt okunur önerileri veya parolalar](/slides/tr/androidjava/password-protected-presentation/) ile birleştirin.