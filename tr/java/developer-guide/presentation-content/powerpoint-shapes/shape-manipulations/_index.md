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
- şekli klonlama
- şekli kaldırma
- şekli gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini al
- şekil alternatif metni
- şekil düzen biçimleri
- SVG olarak şekil
- şekli SVG'ye dönüştür
- şekli hizalama
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da şekilleri oluşturmayı, düzenlemeyi ve optimize etmeyi öğrenin ve yüksek performanslı PowerPoint sunumları sunun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunumlarda şekillerle nasıl çalışılacağını açıklar. Bir slaytta şekil bulma, klonlama, kaldırma, gizleme, sırasını değiştirme, Interop şekil kimliğini alma ve tanımlama ile sonraki işlemler için alternatif metin ayarlama süreçlerini gösterir.

Ayrıca şekiller için düzen biçimlerine nasıl erişileceği, bir şekli SVG olarak render etme, bir slayttaki şekilleri hizalama ve yatay ve dikey yansıtma için flip özelliklerini kullanma konularını kapsar. Ek olarak, makale şekil birleştirme, yığın sırası ve şekil kilitleme hakkında kısa bir SSS içerir.

## **Bir Slaytta Şekil Bulma**
Bu konu, geliştiricilerin bir şekli dahili Id’sini kullanmadan daha kolay bulabilmesi için basit bir teknik açıklayacaktır. PowerPoint sunum dosyalarının bir slayttaki şekilleri dahili benzersiz Id dışındaki bir yolla tanımlama imkanı olmadığını bilmek önemlidir. Geliştiricilerin dahili benzersiz Id’siyle bir şekli bulması zor görünebilir. Slaytlara eklenen tüm şekillerin bir Alt Metni vardır. Geliştiricilere, belirli bir şekli bulmak için alternatif metin kullanmalarını öneriyoruz. Gelecekte değiştirmeyi planladığınız nesneler için alternatif metni tanımlamak üzere MS PowerPoint’i kullanabilirsiniz.

İstediğiniz herhangi bir şeklin alternatif metnini ayarladıktan sonra, Aspose.Slides for Java ile bu sunumu açabilir ve bir slayta eklenen tüm şekiller arasında döngü yapabilirsiniz. Her yinelemede, şeklin alternatif metnini kontrol edebilir ve eşleşen alternatif metne sahip şekil, ihtiyaç duyduğunuz şekil olacaktır. Bu tekniği daha iyi göstermek için, bir slayttaki belirli bir şekli bulup doğrudan o şekli döndüren bir yöntem oluşturduk: [findShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-).

```java
// Sunum dosyasını temsil eden bir Presentation sınıfı örneği oluşturur
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
// Bir slaytta alternatif metni kullanarak şekil bulma yöntemi uygulanması
public static IShape findShape(ISlide slide, String alttext)
{
    // Slayt içindeki tüm şekiller üzerinde iterasyon
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Slaytın alternatif metni istenenle eşleşirse
        // Şekli döndür
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Şekli Klonlama**
Aspose.Slides for Java kullanarak bir şekli bir slayta klonlamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayt referansı edinin.
1. Kaynak slaytın şekil koleksiyonuna erişin.
1. Sunuma yeni bir slayt ekleyin.
1. Kaynak slayt şekil koleksiyonundaki şekilleri yeni slayta klonlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek bir grup şekli slayta ekler.

```java
// Presentation sınıfını örnekle
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // PPTX dosyasını diske kaydet
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Şekli Kaldırma**
Aspose.Slides for Java, geliştiricilerin herhangi bir şekli kaldırmasına izin verir. Şekli herhangi bir slayttan kaldırmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Belirli bir AlternativeText’e sahip şekli bulun.
1. Şekli kaldırın.
1. Dosyayı diske kaydedin.

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

## **Şekli Gizleme**
Aspose.Slides for Java, geliştiricilerin herhangi bir şekli gizlemesine izin verir. Şekli herhangi bir slayttan gizlemek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Belirli bir AlternativeText’e sahip şekli bulun.
1. Şekli gizleyin.
1. Dosyayı diske kaydedin.

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

## **Şekil Sırasını Değiştirme**
Aspose.Slides for Java, geliştiricilerin şekillerin sırasını yeniden düzenlemesine izin verir. Şekil sıralaması, hangi şeklin ön planda, hangi şeklin arkada olduğunu belirler. Şekli herhangi bir slaytta yeniden sıralamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Bir şekil ekleyin.
1. Şeklin metin çerçevesine bir metin ekleyin.
1. Aynı koordinatlarla başka bir şekil ekleyin.
1. Şekilleri yeniden sıralayın.
1. Dosyayı diske kaydedin.

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

## **Interop Şekil Kimliğini Alma**
Aspose.Slides for Java, geliştiricilerin bir sunum kapsamı yerine bir slayt kapsamı içinde benzersiz bir şekil tanımlayıcısı almasına izin verir. [getUniqueId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#getUniqueId--) yöntemi sunum kapsamında benzersiz bir tanımlayıcı sağlar. [getOfficeInteropShapeId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) yöntemi ise [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape) arayüzüne ve [Shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Shape) sınıfına eklenmiştir. [getOfficeInteropShapeId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) yöntemi tarafından döndürülen değer, Microsoft.Office.Interop.PowerPoint.Shape nesnesinin Id değerine karşılık gelir. Aşağıda örnek bir kod verilmiştir.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Slayt kapsamındaki benzersiz şekil tanımlayıcısını alıyor
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Şekle Alternatif Metin Ayarlama**
Aspose.Slides for Java, geliştiricilerin herhangi bir şeklin AlternateText’ini ayarlamasına izin verir.
Bir sunumdaki şekiller, [AlternativeText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) veya [Shape Name](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#setName-java.lang.String-) yöntemiyle ayırt edilebilir.
[setAlternativeText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) ve [getAlternativeText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#getAlternativeText--) yöntemleri Aspose.Slides ve Microsoft PowerPoint tarafından da okunup ayarlanabilir.
Bu yöntemi kullanarak bir şekli etiketleyebilir ve Şekil Kaldırma,
Şekil Gizleme veya Slaytta Şekil Yeniden Sıralama gibi farklı işlemler gerçekleştirebilirsiniz.
Bir şeklin AlternateText’ini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Slayta herhangi bir şekil ekleyin.
1. Yeni eklenen şekille bazı işlemler yapın.
1. Şekiller arasında dolaşarak bir şekil bulun.
1. AlternativeText’i ayarlayın.
1. Dosyayı diske kaydedin.

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

## **Bir Şekil İçin Düzen Biçimlerine Erişim**
Aspose.Slides for Java, bir şekil için düzen biçimlerine erişmek için basit bir API sağlar. Bu makale, düzen biçimlerine nasıl erişileceğini gösterir.

Aşağıda örnek kod verilmiştir.

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

## **Şekli SVG Olarak Render Etme**
Artık Aspose.Slides for Java, bir şekli SVG olarak render etmeyi desteklemektedir. [writeAsSvg](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (ve aşırı yüklenmiş sürümü) yöntemi [Shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Shape) sınıfına ve [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape) arayüzüne eklenmiştir. Bu yöntem, şeklin içeriğini bir SVG dosyası olarak kaydetmeye olanak tanır. Aşağıdaki kod parçacığı, bir slaydın şeklinin SVG dosyasına nasıl dışa aktarılacağını gösterir.

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

## **Şekli Hizalama**
Aspose.Slides, şekilleri ya slayt kenar boşluklarına göre ya da birbirlerine göre hizalamaya olanak tanır. Bu amaçla, aşırı yüklenmiş [SlidesUtil.alignShape()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) yöntemi eklenmiştir. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ShapesAlignmentType) enumeration’ı olası hizalama seçeneklerini tanımlar.

**Örnek 1**

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

**Örnek 2**

Aşağıdaki örnek, şekil koleksiyonundaki en alttaki şekle göre tüm koleksiyonun nasıl hizalanacağını gösterir.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Flip Özellikleri**

Aspose.Slides’ta, [ShapeFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapeframe/) sınıfı, şekillerin yatay ve dikey yansıtılmasını `flipH` ve `flipV` özellikleri aracılığıyla kontrol eder. Her iki özellik de `byte` türündedir; `1` bir yansıma, `0` yansıma yok ve `-1` varsayılan davranışı kullan anlamına gelir. Bu değerler bir şeklin [Frame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getFrame--) özelliğinden elde edilebilir.

Flip ayarlarını değiştirmek için, şeklin mevcut konumu ve boyutu, istenen `flipH` ve `flipV` değerleri ve dönüş açısını içeren yeni bir [ShapeFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapeframe/) örneği oluşturulur. Bu örnek şeklin [Frame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getFrame--) özelliğine atanır ve sunum kaydedildiğinde yansıtma dönüşümleri uygulanır ve çıktıya yazılır.

Örneğin, aşağıdaki şekli içeren bir sample.pptx dosyamız var; ilk slayt, varsayılan flip ayarlarına sahip tek bir şekil içerir.

![The shape to be flipped](shape_to_be_flipped.png)

Aşağıdaki kod örneği, şeklin mevcut flip özelliklerini alır ve hem yatay hem de dikey olarak ters çevirir.

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

![The flipped shape](flipped_shape.png)

## **SSS**

**Bir slaytta şekilleri (birleştirme/kesişim/çıkarma) masaüstü düzenleyicideki gibi birleştirebilir miyim?**

Yerleşik bir Boolean işlemi API’si yoktur. İstediğiniz konturu kendiniz oluşturarak – örneğin, sonuç geometrisini ([GeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/geometrypath/)) hesaplayıp bu konturla yeni bir şekil oluşturup orijinal olanları isteğe bağlı olarak kaldırabilirsiniz.

**Z‑order’ı (katman sırasını) kontrol edip bir şeklin her zaman “üstte” kalmasını nasıl sağlayabilirim?**

Şekiller koleksiyonundaki ekleme/taşıma sırasını değiştirin. Öngörülebilir sonuçlar için tüm diğer slayt değişikliklerinden sonra z‑order’ı kesinleştirin.

**PowerPoint’te bir şekli kullanıcıların düzenlemesini engellemek için “kilitleyebilir” miyim?**

Evet. [şekil‑seviyesi koruma bayraklarını](/slides/tr/java/applying-protection-to-presentation/) (ör. seçim, hareket, yeniden boyutlandırma, metin düzenleme kilidi) ayarlayın. Gerekirse bu kısıtlamaları master veya düzen üzerine de uygulayın. Bunun bir UI‑seviyesi koruma olduğunu, güvenlik özelliği olmadığını unutmayın; daha güçlü koruma için dosya‑seviyesi kısıtlamalarla (ör. yalnızca‑okunur önerileri veya parolalar) birleştirin.