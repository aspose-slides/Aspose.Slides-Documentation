---
title: Java’da Sunum Yer Tutucularını Yönetin
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/java/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- görsel yer tutucu
- grafik yer tutucu
- içerik yer tutucu
- prompt metni
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile metin, görsel, grafik ve içerik yer tutucularını incelemeyi ve düzenlemeyi ve yer tutucu kalıtımını anlamayı öğrenin."
---
## **Genel Bakış**

Yer tutucu, bir sunum şablonunda belirli bir içerik türü için konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarlarını bir yerleşim slaytından veya ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) yöntemi aracılığıyla ortaya çıkarır. Bu yöntem normal bir şekil için `null` döndüren bir [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) nesnesi döndürür. Yer tutucunun neyi içermesi amaçlandığını belirlemek için [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) kullanın.

Şekil arayüzü, yer tutucu türünü öğrendikten sonra da önemlidir:

- Boş bir metin, resim, grafik veya içerik yer tutucu genellikle bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ile temsil edilir.
- Dolu bir resim yer tutucu bir [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucu bir [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) ile temsil edilebilir.
- Bir içerik yer tutucu birden fazla içerik türü içerebilir. Her yer tutucunun bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) olduğunu varsaymak yerine hem [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) hem de çalışma zamanındaki şekil arayüzünü kontrol edin.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) bir yer tutucunun rolünü açıklar; şeklin çalışma zamanı türünü garanti etmez. Metin, resim, grafik, tablo veya medya spesifik üyelerine erişmeden önce her zaman tür kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Mirasını Anlamak**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stilleri ve bazı durumlarda ana düzeyde yer tutucuları tanımlar.
2. Bir yerleşim slaytı, bir veya daha fazla normal slayt tarafından kullanılan düzeni tanımlar ve ana slayttan devralabilir.
3. Normal bir slayt, o slayt için yer tutucuları içerir ve yerleşiminden devralabilir.

Bu hiyerarşide bir seviye yukarı çıkmak için [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) yöntemini çağırın. Bir slayt yer tutucu genellikle yerleşim yer tutucusunu döndürür; bir yerleşim yer tutucu ise ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu olmadığında yöntem `null` döndürür.

İlk slayttaki yer tutucuları listeleyen ve temel yer tutucularını raporlayan aşağıdaki örnek:

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

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma oluşturur veya değiştirir. İlgili yerleşim veya ana slaytı düzenlemek, bu ayarı hâlâ devralan tüm slaytları etkileyebilir. Yerel bir normal şeklin temel yer tutucusu yoktur ve aynı koordinatları kapladığı için otomatik olarak devralmaya başlamaz.

## **Yer Tutucu Durumunu Kaldırma**

Bir şablonu uyarlarken, mevcut bir nesneyi normal bir şekil olarak tutmak için [IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) kullanın. Bunun [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--) yöntemi `null` döndürür, ancak şekil slaytın koleksiyonunda kalır. Buna karşılık, [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) şekli o koleksiyondan siler.

Aşağıdaki örnek, en az bir slaytı ve ilk slaytta boş olmayan bir metin yer tutucusu bulunan `template.pptx` dosyasını gerektirir. Etkiyi görmek için yerleşim veya ana slayttan miras alınan biçimlendirmeye sahip bir yer tutucu kullanın. Örnek, aynı şeklin kalmasını kontrol eder, yöntemi artık normal bir şekil üzerinde tekrar çağırır ve sonucu kaydeder.

{{% alert color="warning" title="Warning" %}}
Yer tutucu durumunu kaldırmak, kalıtlama ayarlarının otomatik olarak korunmasını sağlamaz. Aşağıdaki örnek bu ayarları kasıtlı olarak değiştirmeden bırakır, bu nedenle çıktı farklı görünebilir. Pozisyon ve boyutu tamamen miras alan bir şekil, çağrı sonrası sıfır koordinat ve boyuta sahip olabilir ve koleksiyonda kalmasına rağmen görünmez hâle gelebilir.
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

        // Normal bir şekil üzerinde yöntemi çağırmak hiçbir etki yapmaz.
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

Uygun bir yer tutucu için, üç kontrol de `true` yazdırır. Metin kalır, ancak miras alınan konum, boyut, dönüş, yazı tipi, paragraf hizalaması, metin çerçevesi kenar boşlukları, dikey tutturma, doldurma ve çizgi ayarları yer tutucu ilişkisi kaldırıldığında değişebilir. Örneğin, miras alınan başlık biçimlendirmesi normal metin biçimlendirmesine geri dönebilir. Yerleşimler hakkında daha fazla bilgi için [Slide Layout](/slides/tr/java/slide-layout/) sayfasına bakın.

İstenen görünümü korumak için, çağrıdan önce çözülen konum, boyut ve dönüşü yakalayın ve gerekli etkili biçimleme değerlerini ayrı değişkenlere kopyalayın. Bu değerleri [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--), ve [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--) aracılığıyla alın. Yalnızca etkili‑format nesnelerini tutmaya güvenmeyin, çünkü ilişki kaldırıldıktan sonra metin‑biçimlendirme değerleri değişebilir. Yakalanan değerleri daha sonra normal şekle açıkça uygulayın; buna şablonunuzdaki yazı tipi ailesi, boyutu, stili, rengi, paragraf ayarları, metin‑çerçeve ayarları, doldurma ve çizgi dahildir.

Miras alınan şekil geometrisi de [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-) aracılığıyla açıkça atanabilir. Dikdörtgen bir metin yer tutucu için bu, [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle) atanması anlamına gelir; yalnızca doldurma ve çizgiyi geri yüklemek görünür dikdörtgeni geri getirmeyebilir. Ek efektler veya daha karmaşık biçimlendirmeye sahip şablonlar, bu ayarların da işlenmesini gerektirir.

## **Yer Tutucuda Metni Değiştirme**

Başlık, ortalanmış‑başlık, alt‑başlık, gövde ve metin yer tutucuları normalde metni destekler. [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) olup olmadığını kontrol edin, ardından [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) yöntemini kullanın.

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

Bu desen, resim, grafik, tablo veya medya yer tutucularını [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)‘e dönüştürmekten kaçınır. Ayrıca yer tutucuyu kırılgan bir şekil indeksine dayanmak yerine amacına göre tanımlar.

## **Yerleşimde İpucu Metni Ayarlama**

İpucu metni, boş bir yer tutucuda gösterilen tasarım zamanı talimatıdır; örneğin *Başlık eklemek için tıklayın*. Normal bir slaydın şekil koleksiyonundan ulaşmaya çalışmak yerine, yerleşim yer tutucusunda özel ipucu metni ayarlayın. Yerleşime, [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) ile erişin ve [ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/) tarafından döndürülen koleksiyonu döngüyle gezinin.

Aşağıdaki örnek, ilk slayt tarafından kullanılan yerleşimde başlık ve alt‑başlık ipuçlarını değiştirir:

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

İpucu metni normal slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarında boş yer tutucular için tasarlanmıştır. Bir kullanıcı veya program gerçek içeriği sağladığında, ipucu artık gösterilmez. Bir ipucunu değiştirmek, yerleşimi kullanan slaytlardaki mevcut metni değiştirmez.

## **Resim Yer Tutucusunu Güncelleme**

İki durum ele alınmalıdır:

- Resim yer tutucu zaten doldurulmuş ve bir [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) ile temsil ediliyorsa, resmi [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) ve [ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) kullanarak değiştirin.
- Eğer hâlâ boş bir yer tutucu ise, [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) ile yer tutucunun koordinatlarında bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Sonraki örnek her iki durumu da destekler ve sunumu kaydeder:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

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

Boş bir yer tutucu için oluşturulan değiştirme, yeni bir yer tutucu değil, yerel bir resim çerçevesidir; çünkü [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) bir ayarlayıcı içermez. Ayrılan konumu korur ancak yer tutucu‑özel davranışı artık devralmaz. Yer tutucu ilişkisini korumak kritikse, önce PowerPoint'te yer tutucuyu hazırlayıp doldurun, ardından ortaya çıkan [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) Aspose.Slides ile güncelleyin.

Görünürlük, kırpma ve diğer resim‑özel etkiler için [Manage Picture Frames](/slides/tr/java/picture-frame/) sayfasına bakın. Bu işlemler resim çerçevesi veya resim doldurmasıyla ilgilidir, yer tutucu meta verisiyle değil.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucu bir [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) ile temsil edilebilir. Bu örnek, yer tutucu türü ve çalışma zamanı arayüzü ile böyle bir grafiği bulur, başlığını değiştirir ve dosyayı kaydeder:

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

Genel bir içerik yer tutucusu genellikle [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/) değerine sahiptir. PowerPoint'te bu, grafikler, tablolar, diyagramlar, resimler ve medya gibi çeşitli içerik türleri için bir başlatıcı görevi görür. Doldurulduktan sonra, ne içerdiğini öğrenmek için gerçek şekil arayüzünü inceleyin. Özel yerleşimler ayrıca [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), veya [PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/) değerlerini ortaya koyabilir.

Aspose.Slides, yalnızca [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) değiştirerek boş bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) yer tutucusunu bir [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/)‘a dönüştürmez; tür arayüz üzerinden değiştirilemez. Boş bir grafik veya içerik alanını programlı olarak doldurmak için, gerekli nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bir grafik için bunu yapar:

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

Eklenti grafik, normal bir yerel grafiktir. Yer tutucunun alanını kaplar ancak yerleşim yer tutucusundan devralmaz. Kategorileri, serileri veya çalışma kitabı verilerini değiştirmek gerektiğinde özel [chart management articles](/slides/tr/java/powerpoint-charts/) sayfalarını kullanın.

## **Tam Örnek: Metin veya Görsel İçeriği Güncelleme**

Aşağıdaki uçtan uca örnek bir şablonu açar, ilk slaytta bir başlık veya resim yer tutucusunu arar, yer tutucu ve şekil türlerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, şekil indeksini varsaymaktan veya her yer tutucuyu aynı arayüze dönüştürmekten kasıtlı olarak kaçınır.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

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

Temel bir yer tutucu, başka bir yer tutucunun devraldığı yerleşim veya ana üzerindeki karşılık gelen şekildir. Onu almak için [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) kullanın. Normal bir yerel şekil, yer tutucu hiyerarşisinin bir parçası olmadığından `null` döndürür.

**Tüm slayt başlıklarını bir yerleşim yer tutucusunu düzenleyerek değiştirebilir miyim?**

Bir yerleşim üzerinden miras alınan biçimlendirmeyi veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda depolanır. Sunum boyunca gerçek başlık metnini değiştirmek için slaytları döngüyle gezip her başlık yer tutucusunu güncelleyin.

**Tarih, slayt‑numarası, üstbilgi ve altbilgi yer tutucularını nasıl yönetirim?**

Uygun slayt, yerleşim, ana, notlar veya el ilanı kapsamındaki üstbilgi ve altbilgi yöneticilerini kullanın. Tam örnekler için [Manage Presentation Header and Footer](/slides/tr/java/presentation-header-and-footer/) sayfasına bakın.