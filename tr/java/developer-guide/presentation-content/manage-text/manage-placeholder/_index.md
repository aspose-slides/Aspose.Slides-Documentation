---
title: Java'da Sunum Yer Tutucularını Yönet
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
- ipucu metni
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile metin, resim, grafik ve içerik yer tutucularını nasıl inceleyeceğinizi ve düzenleyeceğinizi ve yer tutucu mirasını nasıl anlayacağınızı öğrenin."
---
## **Genel Bakış**

Bir yer tutucu, bir sunum şablonunda belirli bir içerik türü için bir konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, bir yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarlarını bir yerleşim slaytından veya ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [IShape.getPlaceholder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) yöntemiyle sunar. Yöntem, normal bir şekil için `null` ya da bir [IPlaceholder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholder/) nesnesi döndürür. Yer tutucunun ne içerdiğini belirlemek için [IPlaceholder.getType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholder/) kullanın.

Şekil arabirimi, yer tutucu türünü öğrendikten sonra hâlâ önemlidir:

- Boş bir metin, resim, grafik veya içerik yer tutucusu genellikle bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ile temsil edilir.
- Dolu bir resim yer tutucusu bir [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucusu bir [IChart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/) ile temsil edilebilir.
- Bir içerik yer tutucusu birçok içerik türü içerebilir. Her yer tutucunun bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) olduğunu varsaymak yerine hem [IPlaceholder.getType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholder/) hem de çalışma zamanı şekil arabirimini kontrol edin.

{{% alert color="warning" title="Uyarı" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholder/) bir yer tutucunun rolünü tanımlar; şeklin çalışma zamanı türünü garanti etmez. Metin, resim, grafik, tablo veya medya‑özel üyelerine erişmeden önce her zaman bir tür kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Mirasını Anlayın**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stiller ve bazı durumlarda ana‑seviye yer tutucular tanımlar.
2. Bir yerleşim slaytı, bir veya daha fazla normal slaytın kullandığı düzeni tanımlar ve ana slayttan devralabilir.
3. Bir normal slayt, o slayt için yer tutucuları içerir ve yerleşiminden devralabilir.

Bu hiyerarşide bir seviye yukarı çıkmak için [IShape.getBasePlaceholder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) çağırın. Bir slayt yer tutucusu genellikle yerleşim yer tutucusunu döndürür; bir yerleşim yer tutucusu ana yer tutucusunu döndürebilir. Şeklin temel bir yer tutucusu yoksa yöntem `null` döndürür.

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

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma oluşturur veya değiştirir. İlgili yerleşim ya da ana slaytı düzenlemek, hâlâ bu ayarı devralan tüm slaytları etkileyebilir. Yerel bir normal şeklin temel bir yer tutucusu yoktur ve aynı koordinatları kullandığı için miras almaya başlamaz.

## **Yer Tutucuda Metni Değiştir**

Başlık, ortalanmış‑başlık, alt‑başlık, gövde ve metin yer tutucuları genellikle metni destekler. Kullanım öncesinde [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) olup olmadığını kontrol edin ve ardından [getTextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) yöntemini kullanın.

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

Bu desen, resim, grafik, tablo veya medya yer tutucularını [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) olarak dönüştürmekten kaçınır. Ayrıca, kırılgan bir şekil indeksine güvenmek yerine yer tutucuyu amacına göre tanımlar.

## **Bir Yerleşimde İpucu Metni Ayarla**

İpucu metni, boş bir yer tutucuda gösterilen tasarım‑zamanı talimatıdır; örneğin *Başlık eklemek için tıklayın*. İpucu metnini normal bir slaytın şekil koleksiyonundan almaya çalışmak yerine yerleşim yer tutucusunda özelleştirin. Yerleşime [ISlide.getLayoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/) ile erişin ve [ILayoutSlide.getShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/) tarafından döndürülen koleksiyonu döngüye alın.

Aşağıdaki örnek, ilk slayt tarafından kullanılan yerleşimdeki başlık ve alt‑başlık ipuçlarını değiştirir:

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

İpucu metni normal slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarında boş yer tutucular için tasarlanmıştır. Kullanıcı ya da program gerçek içerik sağladığında ipucu artık gösterilmez. Bir ipucu değiştirmek, yerleşimi kullanan slaytlardaki mevcut metni değiştirmez.

## **Resim Yer Tutucusunu Güncelle**

Ele alınacak iki durum vardır:

- Resim yer tutucusu zaten doluysa ve bir [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) ile temsil ediliyorsa, resmi [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/) ve [ISlidesPicture.setImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidespicture/) ile değiştirin.
- Hâlâ boş bir yer tutucuysa, [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/) ile yer tutucunun koordinatlarında bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Aşağıdaki örnek her iki durumu da destekler ve sunumu kaydeder:

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

Boş bir yer tutucu için oluşturulan değiştirme, yeni bir yer tutucu değil, yerel bir resim çerçevesidir; çünkü [IShape.getPlaceholder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) bir ayarlayıcı sağlamaz. Rezerv edilmiş konumu korur ancak artık yer tutucu‑özel davranışı devralmaz. Yer tutucu ilişkisini korumak kritikse, önce PowerPoint’te yer tutucuyu hazırlayıp doldurun, ardından Aspose.Slides ile ortaya çıkan [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) güncelleyin.

Görsel şeffaflığı, kırpma ve diğer resim‑özel etkiler için [Resim Çerçevelerini Yönet](/slides/tr/java/picture-frame/) bölümüne bakın. Bu işlemler resim çerçevesi ya da resim doldurmasıyla ilgilidir, yer tutucu meta verileriyle değil.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucusu bir [IChart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/) ile temsil edilebilir. Bu örnek, hem yer tutucu türüne hem de çalışma zamanı arabirimine göre bir grafik bulur, başlığını değiştirir ve dosyayı kaydeder:

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

Genel bir içerik yer tutucusu genellikle [PlaceholderType.Object](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholdertype/) tipindedir. PowerPoint’te bu, grafik, tablo, diyagram, resim ve medya gibi çeşitli içerik türlerinin başlatıcısı olarak çalışır. İçerik doldurulduktan sonra, ne içerdiğini öğrenmek için gerçek şekil arabirimini inceleyin. Özelleştirilmiş yerleşimler ayrıca [PlaceholderType.Chart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholdertype/), veya [PlaceholderType.Diagram](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholdertype/) tiplerini ortaya koyabilir.

Aspose.Slides, bir boş [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) yer tutucusunu yalnızca [IPlaceholder.getType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholder/) değiştirerek bir [IChart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/) tipine dönüştürmez; tip arabirim üzerinden değiştirilemez. Boş bir grafik veya içerik alanını programatik olarak doldurmak için, gerekli nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bir grafik için bunu yapar:

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

Eklenen grafik, yerel bir standart grafiktir. Yer tutucunun alanını doldurur ancak yerleşim yer tutucusundan miras almaz. Kategorileri, serileri veya çalışma kitabı verilerini değiştirmek gerektiğinde özel [grafik yönetimi makalelerini](/slides/tr/java/powerpoint-charts/) kullanın.

## **Tam Örnek: Metin veya Görüntü İçeriğini Güncelle**

Aşağıdaki uçtan uca örnek bir şablonu açar, ilk slaytta bir başlık ya da resim yer tutucusunu arar, yer tutucu ve şekil türlerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, şekil indeksi varsaymak ya da her yer tutucuyu aynı arabirime dönüştürmekten kaçınmak için tasarlanmıştır:

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

Temel bir yer tutucu, başka bir yer tutucunun miras aldığı yerleşim ya da ana slayttaki karşılık gelen şekildir. Onu elde etmek için [IShape.getBasePlaceholder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) kullanın. Normal bir yerel şekil, yer tutucu hiyerarşisinin bir parçası olmadığı için `null` döndürür.

**Bir yer tutucu düzenleyerek tüm slayt başlıklarını değiştirebilir miyim?**

Bir yerleşim aracılığıyla devralınan biçimlendirme ya da ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda depolanır. Sunum genelinde gerçek başlık metnini değiştirmek için slaytlar üzerinden döngüye girip her başlık yer tutucusunu güncelleyin.

**Tarih, slayt numarası, başlık ve alt bilgi yer tutucularını nasıl yönetirim?**

Uygun slayt, yerleşim, ana, notlar veya el ilanı kapsamındaki başlık ve alt bilgi yöneticilerini kullanın. Tam örnekler için [Sunum Başlık ve Alt Bilgilerini Yönet](/slides/tr/java/presentation-header-and-footer/) bölümüne bakın.