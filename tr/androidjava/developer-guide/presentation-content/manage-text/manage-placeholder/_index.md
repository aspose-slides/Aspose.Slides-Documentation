---
title: Android'de Sunum Yer Tutucularını Yönet
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/androidjava/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- görsel yer tutucu
- grafik yer tutucu
- içerik yer tutucu
- istem metni
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile metin, resim, grafik ve içerik yer tutucularını nasıl inceleyeceğinizi ve düzenleyeceğinizi ve yer tutucu mirasını nasıl anlayacağınızı öğrenin."
---
## **Genel Bakış**

Yer tutucu, bir sunum şablonunda belirli bir içerik türü için konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarlarını bir yerleşim slaytı veya ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [IShape.getPlaceholder](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) yöntemi aracılığıyla ortaya koyar. Bu yöntem, normal bir şekil için `null` veya bir [IPlaceholder](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholder/) nesnesi döndürür. Yer tutucunun ne içerdiğini belirlemek için [IPlaceholder.getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholder/) kullanın.

Şekil arabirimi, yer tutucu tipini öğrendikten sonra da önemlidir:

- Boş bir metin, resim, grafik veya içerik yer tutucusu genellikle bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ile temsil edilir.
- Dolu bir resim yer tutucusu bir [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucusu bir [IChart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/) ile temsil edilebilir.
- Bir içerik yer tutucusu çeşitli içerik türlerini barındırabilir. Her yer tutucunun bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) olduğunu varsaymak yerine hem [IPlaceholder.getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholder/) hem de çalışma zamanındaki şekil arabirimini kontrol edin.

{{% alert color="warning" title="Uyarı" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholder/) bir yer tutucunun rolünü tanımlar; şeklin çalışma zamanındaki tipini garanti etmez. Metin, resim, grafik, tablo veya medya‑özel üyelerine erişmeden önce her zaman tip kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Mirasını Anlama**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stilleri ve bazı durumlarda ana‑seviye yer tutucuları tanımlar.
2. Bir yerleşim slaytı, bir veya daha fazla normal slayt tarafından kullanılan düzeni tanımlar ve ana slayttan miras alabilir.
3. Normal bir slayt, o slayt için yer tutucuları içerir ve yerleşiminden miras alabilir.

[IShape.getBasePlaceholder](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) metodunu çağırarak bu hiyerarşide bir seviye yukarı çıkabilirsiniz. Bir slayt yer tutucusu genellikle onun yerleşim yer tutucusunu döndürür; bir yerleşim yer tutucusu ise ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu yoksa yöntem `null` döndürür.

Aşağıdaki örnek, ilk slayttaki yer tutucuları listeler ve bunların temel yer tutucularını raporlar:

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

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma yaratır veya değiştirir. İlgili yerleşim ya da ana slaytı düzenlemek, bu ayarı hâlâ miras alan tüm slaytları etkileyebilir. Yerel bir normal şeklin temel yer tutucusu yoktur ve aynı koordinatları kaplaması, miras almaya başlamasını sağlamaz.

## **Yer Tutucudaki Metni Değiştirme**

Başlık, ortalanmış‑başlık, alt‑başlık, gövde ve metin yer tutucuları normalde metni destekler. [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) olup olmadığını kontrol ettikten sonra [getTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) metodunu kullanın.

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

Bu desen, resim, grafik, tablo veya medya yer tutucularını [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/)’a dökmekten kaçınır. Ayrıca kırılgan bir şekil indeksine dayanmak yerine yer tutucuyu amacına göre tanımlar.

## **Yerleşimde İpucu Metni Ayarlama**

İpucu metni, boş bir yer tutucuda görüntülenen tasarım‑zamanı talimatıdır; örneğin *Başlık eklemek için tıklayın*. Normal bir slaytın şekil koleksiyonundan ulaşmaya çalışmak yerine, yerleşim yer tutucusunda özel bir ipucu metni ayarlayın. Yerleşime [ISlide.getLayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) ile erişin ve [ILayoutSlide.getShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/) tarafından döndürülen koleksiyon üzerinde yineleme yapın.

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

İpucu metni normal bir slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarındaki boş yer tutucular için tasarlanmıştır. Bir kullanıcı ya da program gerçek içerik sağladığında, ipucu artık gösterilmez. Bir ipucu metnini değiştirmek, yerleşimi kullanan slaytlardaki mevcut metni de değiştirmez.

## **Resim Yer Tutucusunu Güncelleme**

İki durum ele alınmalıdır:

- Resim yer tutucusu zaten dolu ve bir [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) ile temsil ediliyorsa, görüntüyü [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/) ve [ISlidesPicture.setImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidespicture/) ile değiştirin.
- Eğer hâlâ boş bir yer tutucuysa, [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/) ile yer tutucunun koordinatlarında bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Aşağıdaki örnek her iki durumu da destekler ve sunumu kaydeder:

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

Boş bir yer tutucu için oluşturulan değişiklik, [IShape.getPlaceholder](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) bir ayarlayıcı sağlamadığı için yeni bir yer tutucu değil, yerel bir resim çerçevesidir. Ayrılmış konumu korur ancak artık yer tutucu‑özel davranışı devralmaz. Yer tutucu ilişkisinin korunması önemliyse, önce PowerPoint'te yer tutucuyu hazırlayıp doldurun, ardından ortaya çıkan [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) nesnesini Aspose.Slides ile güncelleyin.

Görüntü şeffaflığı, kırpma ve diğer resim‑özel etkiler için [Resim Çerçevelerini Yönetme](/slides/tr/androidjava/picture-frame/) bölümüne bakın. Bu işlemler yer tutucu meta verilerine değil, resim çerçevesine veya resim doldurmaya aittir.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucusu bir [IChart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/) ile temsil edilebilir. Bu örnek, yer tutucu tipine ve çalışma zamanı arabirimine göre böyle bir grafik bulur, başlığını değiştirir ve dosyayı kaydeder:

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

Genel bir içerik yer tutucusu genellikle [PlaceholderType.Object](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholdertype/) tipindedir. PowerPoint'te, grafik, tablo, diyagram, resim ve medya gibi çeşitli içerik türlerini başlatan bir araç olarak görev yapar. Doldurulduktan sonra, ne içerdiğini öğrenmek için gerçek şekil arabirimini inceleyin. Özelleştirilmiş yerleşimler ayrıca [PlaceholderType.Chart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholdertype/), veya [PlaceholderType.Diagram](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholdertype/) tiplerini de ortaya çıkarabilir.

Aspose.Slides, sadece [IPlaceholder.getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholder/) değiştirerek boş bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) yer tutucusunu [IChart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/) haline getirmez; tip arayüz üzerinden değiştirilemez. Boş bir grafik ya da içerik alanını programlı olarak doldurmak için, gerekli nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bir grafik için bunu yapar:

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

Eklenen grafik, sıradan bir yerel grafiktir. Yer tutucunun alanını kaplar ancak yerleşim yer tutucusundan miras almaz. Kategorilerini, serilerini veya çalışma kitabı verilerini değiştirmek gerektiğinde özel olarak [grafik yönetimi makalelerini](/slides/tr/androidjava/powerpoint-charts/) kullanın.

## **Tam Örnek: Metin veya Görüntü İçeriğini Güncelleme**

Aşağıdaki uçtan uca örnek bir şablonu açar, ilk slaytta bir başlık ya da resim yer tutucusunu arar, yer tutucu ve şekil tiplerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, şekil indeksini varsaymaktan veya her yer tutucuyu aynı arabirime dönüştürmekten kaçınmak üzere tasarlanmıştır:

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

Temel yer tutucu, başka bir yer tutucunun miras aldığı, yerleşim ya da ana slayttaki karşılık gelen şekildir. Onu almak için [IShape.getBasePlaceholder](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) kullanın. Normal bir yerel şekil, yer tutucu hiyerarşisinin bir parçası olmadığı için `null` döndürür.

**Tüm slayt başlıklarını bir yerleşim yer tutucusunu düzenleyerek değiştirebilir miyim?**

Bir yerleşim üzerinden miras alınan biçimlendirmeyi veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda depolanır. Sunum genelinde gerçek başlık metnini değiştirmek için slaytlar üzerinde yineleme yapıp her başlık yer tutucusunu güncelleyin.

**Tarih, slayt‑numarası, üstbilgi ve altbilgi yer tutucularını nasıl yönetirim?**

Uygun slayt, yerleşim, ana, notlar veya dağıtım kapsamında üstbilgi ve altbilgi yöneticilerini kullanın. Tam örnekler için [Sunum Üstbilgi ve Altbilgi Yönetimi](/slides/tr/androidjava/presentation-header-and-footer/) bölümüne bakın.