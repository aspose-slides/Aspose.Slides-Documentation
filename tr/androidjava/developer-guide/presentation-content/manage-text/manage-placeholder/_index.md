---
title: Android'de Sunum Yer Tutucularını Yönetme
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/androidjava/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- resim yer tutucu
- grafik yer tutucu
- içerik yer tutucu
- ipucu metni
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'i Java aracılığıyla kullanarak metin, resim, grafik ve içerik yer tutucularını incelemeyi, düzenlemeyi ve yer tutucu kalıtımını anlamayı öğrenin."
---
## **Genel Bakış**

Yer tutucu, bir sunum şablonunda belirli bir içerik türü için bir konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Olağan bir şekilden farklı olarak, yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarlarını bir düzen slaytı veya ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) yöntemi aracılığıyla ortaya çıkarır. Bu yöntem, normal bir şekil için `null` dönen bir [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) nesnesi döndürür. Yer tutucunun ne içermesi amaçlandığını belirlemek için [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) kullanın.

Şekil arayüzü, yer tutucu tipini öğrendikten sonra da önemlidir:

- Boş bir metin, resim, grafik veya içerik yer tutucusu genellikle bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ile temsil edilir.
- Dolu bir resim yer tutucusu bir [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucusu bir [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) ile temsil edilebilir.
- Bir içerik yer tutucusu çeşitli içerik türlerini barındırabilir. Her yer tutucunun bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) olduğunu varsaymak yerine hem [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) hem de çalışma zamanı şekil arayüzünü kontrol edin.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) bir yer tutucunun rolünü tanımlar; şeklin çalışma zamanı tipini garanti etmez. Metin, resim, grafik, tablo veya medya‑özgü üyelere erişmeden önce her zaman bir tip kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Kalıtımını Anlamak**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stilleri tanımlar ve bazı durumlarda ana‑seviyesindeki yer tutucuları belirler.
2. Bir düzen slaytı, bir veya daha fazla normal slayt tarafından kullanılan düzeni tanımlar ve ana slayttan kalıtım alabilir.
3. Normal bir slayt, o slayt için yer tutucuları içerir ve düzeninden kalıtım alabilir.

Bu hiyerarşide bir seviye yukarı çıkmak için [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) çağırın. Bir slayt yer tutucusu genellikle kendi düzen yer tutucusunu döndürür; bir düzen yer tutucusu kendi ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu olmadığında yöntem `null` döndürür.

Aşağıdaki örnek, ilk slayttaki yer tutucuları listeler ve temel yer tutucularını rapor eder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma yaratır veya değiştirir. İlgili düzeni veya ana slaytı düzenlemek, bu ayarı hâlâ miras alan tüm slaytları etkileyebilir. Yerel bir olağan şeklin temel yer tutucusu yoktur ve aynı koordinatları kapladığı için miras almaya başlamaz.

## **Yer Tutucu Durumunu Kaldırma**

Bir şablonu uyarlarken, mevcut bir nesneyi olağan bir şekil olarak tutmak için [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) kullanın. Bunun [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) yöntemi `null` döndürür, ancak şekil slaytın koleksiyonunda kalır. Buna karşılık, [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) şekli o koleksiyondan siler.

İlk slaytta en az bir slayt ve boş olmayan bir metin yer tutucusu içeren `template.pptx` dosyası gereklidir. İlişkinin kaldırılmasının etkisini görmek için düzen veya ana slayttan miras alınan biçimlendirmeye sahip bir yer tutucu kullanın. Örnek, aynı şeklin kaldığını doğrular, yöntemi artık olağan şekil üzerinde yeniden çağırır ve sonucu kaydeder.

{{% alert color="warning" title="Warning" %}}
Yer tutucu durumunun kaldırılması, miras alınan görünüm ayarlarını otomatik olarak korumaz. Aşağıdaki örnek bu ayarları kasıtlı olarak değiştirmez, bu yüzden çıktı farklı görünebilir. Konumu ve boyutu tamamen miras alınan bir şekil, çağrı sonrası sıfır koordinat ve boyutlara sahip olabilir ve koleksiyonda kalmasına rağmen görünmez hâle gelir.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // Yöntemi normal bir şekil üzerinde çağırmak hiçbir etki yapmaz.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Ara uyumlu bir yer tutucu için üç kontrol de `true` yazdırır. Metin kalır, ancak yer tutucu ilişkisi kaldırıldığında miras alınan konum, boyut, döndürme, yazı tipi, paragraf hizalaması, metin‑çerçeve kenar boşlukları, dikey yerleştirme, dolgu ve çizgi ayarları değişebilir. Örneğin, miras alınan başlık biçimlendirmesi olağan metin biçimlendirmesine geri dönebilir. Düzenler hakkında daha fazla bilgi için [Slide Layout](/slides/tr/androidjava/slide-layout/) sayfasına bakın.

İstenilen görünümü korumak için, çağrıdan önce hesaplanmış konum, boyut ve döndürmeyi yakalayın ve gerekli etkili biçimlendirme değerlerini ayrı değişkenlere kopyalayın. Bu değerleri [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--) ve [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) aracılığıyla alın. Yalnızca etkili‑format nesnelerine güvenmeyin; çünkü ilişki kaldırıldıktan sonra metin‑biçimleme değerleri değişebilir. Yakalanan değerleri, şablonunuzun kullandığı yazı tipi ailesi, boyutu, stili, rengi, paragraf ayarları, metin‑çerçeve ayarları, dolgu ve çizgi dahil olmak üzere, olağan şekle açıkça uygulayın.

Miras alınan şekil geometrisi, [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-) aracılığıyla da açıkça atanabilir. Dikdörtgen bir metin yer tutucusu için bu, [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle) atanması anlamına gelir; yalnızca dolgu ve çizgiyi geri yüklemek görünür dikdörtgeni geri getirmeyebilir. Ek efektler veya daha karmaşık biçimlendirme içeren şablonlar da bu ayarların ele alınmasını gerektirir.

## **Yer Tutucudaki Metni Değiştirme**

Başlık, ortalanmış‑başlık, alt‑başlık, gövde ve metin yer tutucuları normalde metni destekler. [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) olup olmadığını kontrol edin, ardından [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) metodunu kullanın.

Bu örnek, ilk slayttaki ilk başlık yer tutucusunu günceller ve sonucu kaydeder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu desen, resim, grafik, tablo veya medya yer tutucularını [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) tipine dökümden kaçınır. Ayrıca yer tutucuyu kırılgan bir şekil indeksine dayanmak yerine amacına göre tanımlar.

## **Düzen Üzerinde İpucu Metni Ayarlama**

İpucu metni, *Başlık eklemek için tıklayın* gibi boş bir yer tutucuda görüntülenen tasarım‑zamanı talimatıdır. Normal bir slaydın şekil koleksiyonundan erişmeye çalışmak yerine, düzen yer tutucusunda özel bir ipucu metni ayarlayın. Düzeni, [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) aracılığıyla alın ve [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/) tarafından döndürülen koleksiyonu döngüyle gezinin.

İşte aşağıdaki örnek, ilk slayt tarafından kullanılan düzende başlık ve alt‑başlık ipuçlarını değiştirir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

İpucu metni normal bir slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarında boş yer tutucular için tasarlanmıştır. Bir kullanıcı veya program gerçek içerik sağladığında, ipucu artık gösterilmez. Bir ipucunu değiştirmek, düzeni kullanan slaytlardaki mevcut metni de değiştirmez.

## **Resim Yer Tutucusunu Güncelleme**

İki durum ele alınmalıdır:

- Resim yer tutucusu zaten doldurulmuş ve bir [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) ile temsil ediliyorsa, görüntüyü [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) ve [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) aracılığıyla değiştirin.
- Hâlâ boş bir yer tutucuysa, [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) ile yer tutucunun koordinatlarında bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Sonraki örnek her iki durumu da destekler ve sunumu kaydeder:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Boş bir yer tutucu için oluşturulan değiştirme, yeni bir yer tutucu değil, yerel bir resim çerçevesidir, çünkü [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) bir ayarlayıcı sağlamaz. Ayrılmış konumu korur ancak artık yer tutucu‑spesifik davranışı devralmaz. Yer tutucu ilişkisinin korunması kritikse, önce PowerPoint’te yer tutucuyu hazırlayıp doldurun, ardından Aspose.Slides ile ortaya çıkan [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) öğesini güncelleyin.

Görüntü şeffaflığı, kırpma ve diğer resim‑spesifik etkiler için [Manage Picture Frames](/slides/tr/androidjava/picture-frame/) sayfasına bakın. Bu işlemler resim çerçevesi veya resim dolgusuna aittir, yer tutucu meta verilerine değil.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucusu bir [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) ile temsil edilebilir. Bu örnek, yer tutucu türü ve çalışma zamanı arayüzü ile böyle bir grafiği bulur, başlığını değiştirir ve dosyayı kaydeder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Genel bir içerik yer tutucusu genellikle [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) tipine sahiptir. PowerPoint’te bu, grafikler, tablolar, diyagramlar, resimler ve medya gibi çeşitli içerik türlerini başlatan bir tetikleyici işlevi görür. Doldurulduktan sonra, içinde ne olduğunu öğrenmek için gerçek şekil arayüzünü inceleyin. Özelleştirilmiş düzenler ayrıca [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) veya [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) tiplerini ortaya koyabilir.

Aspose.Slides, bir boş [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) yer tutucusunu yalnızca [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) değiştirmekle bir [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) nesnesine dönüştürmez; tip arayüz üzerinden değiştirilemez. Boş bir grafik veya içerik alanını programlı olarak doldurmak için gereken nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bir grafik için bunu gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eklenen grafik, olağan bir yerel grafiktir. Yer tutucunun alanını kaplar ancak düzen yer tutucusundan kalıtım almaz. Kategorileri, serileri veya çalışma kitabı verilerini değiştirmek gerektiğinde özel [chart management articles](/slides/tr/androidjava/powerpoint-charts/) sayfalarını kullanın.

## **Tam Örnek: Metin veya Görsel İçeriği Güncelleme**

Aşağıdaki uçtan uca örnek bir şablonu açar, ilk slaytta bir başlık veya resim yer tutucusunu arar, yer tutucu ve şekil tiplerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, şekil indeksini varsaymaktan veya her yer tutucuyu aynı arayüze dökmekten bilinçli olarak kaçınır:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Temel yer tutucu nedir?**

Temel bir yer tutucu, başka bir yer tutucunun miras aldığı düzen veya ana slayttaki ilgili şekildir. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) ile alınabilir. Olağan bir yerel şekil, yer tutucu hiyerarşisinin bir parçası olmadığı için `null` döndürür.

**Tüm slayt başlıklarını bir düzen yer tutucusunu düzenleyerek değiştirebilir miyim?**

Bir düzen üzerinden miras alınan biçimlendirmeyi veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda depolanır. Sunum boyunca gerçek başlık metnini değiştirmek için slaytları döngüyle gezip her başlık yer tutucusunu güncelleyin.

**Tarih, slayt‑numarası, başlık ve altbilgi yer tutucularını nasıl yönetirim?**

Uygun slayt, düzen, ana, not veya dağıtım kapsamında başlık ve altbilgi yöneticilerini kullanın. Tam örnekler için [Manage Presentation Header and Footer](/slides/tr/androidjava/presentation-header-and-footer/) sayfasına bakın.