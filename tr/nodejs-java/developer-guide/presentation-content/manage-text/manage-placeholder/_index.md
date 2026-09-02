---
title: Sunum Yer Tutucularını JavaScript ile Yönet
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/nodejs-java/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- resim yer tutucu
- grafik yer tutucu
- içerik yer tutucu
- ipucu metni
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile Java üzerinden metin, resim, grafik ve içerik yer tutucularını incelemeyi ve düzenlemeyi, ayrıca yer tutucu kalıtımını öğrenin."
---
## **Genel Bakış**

Bir yer tutucu, bir sunum şablonunda belirli bir içerik türü için bir konumu ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarları bir yerleşim slaytından veya ana slayttan miras alabilir.

Aspose.Slides, yer tutucu bilgilerini [Shape.getPlaceholder](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getPlaceholder) yöntemiyle sunar. Yöntem, normal bir şekil için `null` döndürür ve bir [Placeholder](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/placeholder/) nesnesi döndürür. Yer tutucunun ne içerdiğini belirlemek için [Placeholder.getType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/placeholder/#getType) yöntemini kullanın.

Yer tutucu türünü öğrendikten sonra şekil sınıfı hâlâ önemlidir:

- Boş bir metin, resim, grafik veya içerik yer tutucusu genellikle bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ile temsil edilir.
- Dolu bir resim yer tutucusu bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucusu bir [Chart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/) ile temsil edilebilir.
- Bir içerik yer tutucusu çeşitli içerik türlerini barındırabilir. Her yer tutucunun bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) olduğunu varsaymak yerine hem [Placeholder.getType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/placeholder/#getType) hem de çalışma zamanı şekil sınıfını kontrol edin.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/placeholder/#getType) bir yer tutucunun rolünü tanımlar; şeklin çalışma zamanı tipini garanti etmez. Metin, resim, grafik, tablo veya medya öğelerine erişmeden önce her zaman bir tip kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Mirasını Anlama**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stiller ve bazı durumlarda ana‑seviye yer tutucular tanımlar.
2. Bir yerleşim slaytı, bir veya daha fazla normal slayt tarafından kullanılan düzeni tanımlar ve ana slayttan miras alabilir.
3. Normal bir slayt, o slayt için yer tutucuları içerir ve yerleşiminden miras alabilir.

Bu hiyerarşide bir seviye yukarı çıkmak için [Shape.getBasePlaceholder](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getBasePlaceholder) yöntemini çağırın. Bir slayt yer tutucusu genellikle yerleşim yer tutucusunu döndürür; bir yerleşim yer tutucusu ise ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu yoksa yöntem `null` döndürür.

Aşağıdaki örnek, ilk slayttaki yer tutucuları listeler ve temel yer tutucularını raporlar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma oluşturur veya değiştirir. İlgili yerleşim veya ana slaydı düzenlemek, hâlâ bu ayarı miras alan tüm slaytları etkileyebilir. Yerel bir normal şeklin temel yer tutucusu yoktur ve aynı koordinatları kapsaması nedeniyle miras almaya başlamaz.

## **Yer Tutucudaki Metni Değiştirme**

Başlık, ortalanmış‑başlık, alt‑başlık, gövde ve metin yer tutucuları genellikle metin destekler. [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) olup olmadığını kontrol ettikten sonra [getTextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/#getTextFrame) yöntemini kullanın.

Bu örnek, ilk slayttaki ilk başlık yer tutucusunu günceller ve sonucu kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu desen, resim, grafik, tablo veya medya yer tutucularını [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) nesneleri olarak ele almayı önler. Ayrıca yer tutucuyu kırılgan bir şekil indeksine dayanmak yerine amacına göre tanımlar.

## **Yerleşimde İpucu Metni Ayarlama**

İpucu metni, boş bir yer tutucuda gösterilen tasarım‑zamanı talimatıdır; örneğin *Başlık eklemek için tıklayın*. Normal bir slaytın şekil koleksiyonundan ulaşmaya çalışmak yerine, yerleşim yer tutucusunda özel bir ipucu metni ayarlayın. Yerleşime, [Slide.getLayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getLayoutSlide) yöntemiyle erişin ve [BaseSlide.getShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/#getShapes) tarafından döndürülen koleksiyon üzerinde döngü kurun.

Aşağıdaki örnek, ilk slayt tarafından kullanılan yerleşimde başlık ve alt‑başlık ipuçlarını değiştirir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

İpucu metni normal bir slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarında boş yer tutucular için tasarlanmıştır. Bir kullanıcı veya program gerçek içerik sağladığında ipucu artık gösterilmez. Bir ipucu değiştirmek, yerleşimi kullanan slaytlardaki mevcut metni değiştirmez.

## **Resim Yer Tutucusunu Güncelleme**

İki durum ele alınmalıdır:

- Resim yer tutucusu zaten doluysa ve bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) ile temsil ediliyorsa, resmi [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#getPicture) ve [Picture.setImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picture/#setImage) yöntemleriyle değiştirin.
- Hâlâ boş bir yer tutucuysa, [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) yöntemiyle yer tutucunun koordinatlarında bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Sonraki örnek her iki durumu da destekler ve sunumu kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Boş bir yer tutucu için oluşturulan değiştirme, yeni bir yer tutucu değil, yerel bir resim çerçevesidir; çünkü [Shape.getPlaceholder](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getPlaceholder) bir ayarlayıcı sağlamaz. Ayrılmış konumu korur ancak artık yer tutucu‑özel davranışı miras almaz. Yer tutucu ilişkisi kritikse, önce PowerPoint’te yer tutucuyu hazırlayıp doldurun, ardından Aspose.Slides ile ortaya çıkan [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) nesnesini güncelleyin.

Görsel şeffaflığı, kırpma ve diğer resim‑özel efektler için [Manage Picture Frames](/slides/tr/nodejs-java/picture-frame/) bölümüne bakın. Bu işlemler resim çerçevesi veya resim doldurmasıyla ilgilidir, yer tutucu meta verisiyle değil.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucusu bir [Chart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/) ile temsil edilebilir. Bu örnek, yer tutucu türü ve çalışma zamanı sınıfı ile bir grafiği bulur, başlığını değiştirir ve dosyayı kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Genel bir içerik yer tutucusu genellikle [PlaceholderType.Object](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/placeholdertype/#Object) değerine sahiptir. PowerPoint’te, grafik, tablo, diyagram, resim ve medya gibi çeşitli içerik türleri için bir başlatıcı görevi görür. Doldurulduktan sonra, ne içerdiğini öğrenmek için gerçek şekil sınıfını inceleyin. Özelleştirilmiş yerleşimler ayrıca [PlaceholderType.Chart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/placeholdertype/#Media) veya [PlaceholderType.Diagram](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/placeholdertype/#Diagram) değerlerini sergileyebilir.

Aspose.Slides, boş bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) yer tutucusunu yalnızca [Placeholder.getType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/placeholder/#getType) değiştirmekle bir [Chart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/) haline getirmez; tip nesne üzerinden değiştirilemez. Boş bir grafik veya içerik alanını programlı olarak doldurmak için, gerekli nesneyi yer tutucunun koordinatlarına ekleyip boş yer tutucuyu kaldırın. Aşağıdaki örnek bunu bir grafik için gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eklenen grafik, yerel bir sıradan grafiktir. Yer tutucunun alanını kaplar ancak yerleşim yer tutucusundan miras almaz. Kategorileri, serileri veya çalışma kitabı verilerini değiştirmek gerektiğinde ilgili [chart management articles](/slides/tr/nodejs-java/powerpoint-charts/) bölümünü kullanın.

## **Tam Örnek: Metin veya Görsel İçeriği Güncelleme**

Aşağıdaki uç‑uç örnek bir şablonu açar, ilk slaytta bir başlık veya resim yer tutucusu arar, yer tutucu ve şekil tiplerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, şekil indeksine dayanmaktan veya her yer tutucuyu aynı sınıf olarak işlemekten kaçınmak için kasıtlı olarak tasarlanmıştır:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Temel yer tutucu nedir?**

Temel yer tutucu, başka bir yer tutucunun miras aldığı yerleşim veya ana slayttaki ilgili şekildir. Onu almak için [Shape.getBasePlaceholder](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getBasePlaceholder) yöntemini kullanın. Normal bir yerel şekil `null` döndürür çünkü yer tutucu hiyerarşisinin bir parçası değildir.

**Tüm slayt başlıklarını bir yerleşim yer tutucusunu düzenleyerek değiştirebilir miyim?**

Bir yerleşim üzerinden kalıtsal biçimlendirme veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda depolanır. Sunumda gerçek başlık metnini değiştirmek için slaytları döngüyle gezip her başlık yer tutucusunu güncellemeniz gerekir.

**Tarih, slayt‑numarası, üst‑bilgi ve alt‑bilgi yer tutucularını nasıl yönetirim?**

Uygun slayt, yerleşim, ana, notlar veya dağıtım kapsamındaki üst‑bilgi ve alt‑bilgi yöneticilerini kullanın. Tam örnekler için [Manage Presentation Header and Footer](/slides/tr/nodejs-java/presentation-header-and-footer/) bölümüne bakın.