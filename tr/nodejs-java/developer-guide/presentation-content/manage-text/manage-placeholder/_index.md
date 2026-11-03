---
title: Sunum Yer Tutucularını JavaScript'te Yönetme
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/nodejs-java/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- görsel yer tutucu
- grafik yer tutucu
- içerik yer tutucu
- istem metni
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile Java üzerinden metin, resim, grafik ve içerik yer tutucularını incelemeyi ve düzenlemeyi ve yer tutucu kalıtımını anlamayı öğrenin."
---
## **Genel Bakış**

Bir yer tutucu, bir sunum şablonunda belirli bir içerik türü için bir konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Sıradan bir şekilden farklı olarak, yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarlarını bir yerleşim slaytından veya ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) yöntemi aracılığıyla sunar. Yöntem, normal bir şekil için `null` döndürmek yerine bir [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) nesnesi döndürür. Yer tutucunun ne amaçla kullanılacağını belirlemek için [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) metodunu kullanın.

Yer tutucu tipini öğrendikten sonra şekil sınıfı hâlâ önemlidir:

- Boş bir metin, resim, grafik veya içerik yer tutucusu genellikle bir [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ile temsil edilir.
- Dolu bir resim yer tutucusu bir [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucusu bir [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) ile temsil edilebilir.
- Bir içerik yer tutucusu çeşitli içerik türlerini içerebilir. Her yer tutucunun bir [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) olduğunu varsaymak yerine hem [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) hem de çalışma zamanındaki şekil sınıfını kontrol edin.

{{% alert color="warning" title="Uyarı" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) bir yer tutucunun rolünü tanımlar; şeklin çalışma zamanındaki tipini garanti etmez. Metin, resim, grafik, tablo veya medya‑özel üyelerine erişmeden önce her zaman tip kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Kalıtımını Anlama**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stilleri tanımlar ve bazı durumlarda ana düzeyinde yer tutucular içerir.
2. Bir yerleşim slaytı, bir veya daha fazla normal slayt tarafından kullanılan düzeni tanımlar ve ana slayttan devralabilir.
3. Bir normal slayt, o slayt için yer tutucuları içerir ve yerleşiminden devralabilir.

Bu hiyerarşide bir seviye yukarı çıkmak için [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) metodunu çağırın. Bir slayt yer tutucusu normalde yerleşim yer tutucusunu döndürür; bir yerleşim yer tutucusu ise ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu yoksa yöntem `null` döndürür.

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

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma oluşturur veya değiştirir. İlgili yerleşim veya ana slaytı düzenlemek, hâlâ bu ayarı devralan tüm slaytları etkileyebilir. Yerel bir sıradan şeklin temel yer tutucusu yoktur ve sadece aynı koordinatları kapladığı için devralmaya başlamaz.

## **Yer Tutucu Durumunu Kaldırma**

Bir şablonu uyarlarken, mevcut bir nesneyi sıradan bir şekil olarak tutmak için [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) metodunu kullanın. Bunun [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) metodu `null` döndürür, ancak şekil slayt koleksiyonunda kalır. Buna karşılık, [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) şekli o koleksiyondan siler.

Aşağıdaki örnek, en az bir slaytı ve ilk slaytta boş olmayan bir metin yer tutucusunu içeren bir `template.pptx` dosyası gerektirir. İlişkiyi kaldırmanın etkisini görmek için yerleşim veya ana slayttan devralınan biçimlendirmeye sahip bir yer tutucu kullanın. Örnek aynı şeklin kaldığını kontrol eder, şimdi sıradan bir şekil olan aynı nesne üzerinde yöntemi yeniden çağırır ve sonucu kaydeder.

{{% alert color="warning" title="Uyarı" %}}
Yer tutucu durumunu kaldırmak, devralınan görünüm ayarlarını otomatik olarak korumaz. Aşağıdaki örnek bu ayarları özellikle değiştirmeden bırakır, bu nedenle çıktı farklı görünebilir. Pozisyonu ve boyutu tamamen devralınan bir şekil, çağrıdan sonra sıfır koordinat ve boyuta sahip olabilir ve koleksiyonda kalmasına rağmen görünmez hâle gelebilir.
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // Yöntemi sıradan bir şekle çağırmak bir etkisi yoktur.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Eşleşen bir yer tutucu için üç kontrol de `true` çıktılar. Metin kalır, ancak devralınan konum, boyut, dönüş, yazı tipi, paragraf hizalaması, metin‑çerçeve kenar boşlukları, dikey sabitleme, dolgu ve çizgi ayarları yer tutucu ilişkisi kaldırıldığında değişebilir. Örneğin, devralınan başlık biçimlendirmesi sıradan metin biçimlendirmesine geri dönebilir. Daha fazla yerleşim bilgisi için [Slide Layout](/slides/tr/nodejs-java/slide-layout/) sayfasına bakın.

İstenen görünümü korumak için, çağrıdan önce çözülmüş konum, boyut ve dönüşü yakalayın ve gerekli etkili biçimlendirme değerlerini ayrı değişkenlere kopyalayın. Bu değerleri [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) ve [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective) aracılığıyla alın. Sadece etkili‑format nesnelerine güvenmeyin; ilişki kaldırıldıktan sonra metin‑biçimleme değerleri değişebilir. Yakalanan değerleri daha sonra sıradan şekle açıkça uygulayın; şablonunuzun kullandığı yazı tipi ailesi, boyutu, stili, rengi, paragraf ayarları, metin‑çerçeve ayarları, dolgu ve çizgi de dahil.

Devralınan şekil geometrisi ayrıca [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType) ile açıkça atanabilir. Dikdörtgen bir metin yer tutucusu için bu, [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle) atanması anlamına gelir; sadece dolgu ve çizgiyi geri yüklemek görünür dikdörtgeni geri getirmeyebilir. Ek efektlere veya daha karmaşık biçimlendirmeye sahip şablonlar bu ayarların da ele alınmasını gerektirir.

## **Yer Tutucudaki Metni Değiştirme**

Başlık, ortalanmış‑başlık, alt‑başlık, gövde ve metin yer tutucuları genellikle metin destekler. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) olup olmadığını kontrol ettikten sonra [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) metodunu kullanın.

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

Bu desen, resim, grafik, tablo veya medya yer tutucularını [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) nesneleri gibi işlemeyi önler. Ayrıca, kırılgan bir şekil indeksine güvenmek yerine yer tutucuyu amacına göre tanımlar.

## **Yerleşimde İpucu Metni Ayarlama**

İpucu metni, boş bir yer tutucuda gösterilen tasarım‑zamanı talimatıdır; örneğin *Başlık eklemek için tıklayın*. Normal bir slayttaki şekil koleksiyonundan ulaşmaya çalışmak yerine yerleşim yer tutucusunda özel bir ipucu metni ayarlayın. Yerleşime [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) ile erişin ve [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) tarafından döndürülen koleksiyonu dolaşın.

Aşağıdaki örnek, ilk slaytın kullandığı yerleşimde başlık ve alt‑başlık ipuçlarını değiştirir:

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

İpucu metni normal slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarındaki boş yer tutucular için tasarlanmıştır. Bir kullanıcı veya program gerçek içerik sağladığında ipucu artık gösterilmez. İpucu değiştirmek, yerleşimi kullanan slaytlardaki mevcut metni de değiştirmez.

## **Resim Yer Tutucusunu Güncelleme**

Ele alınacak iki durum vardır:

- Resim yer tutucusu zaten doluysa ve bir [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) ile temsil ediliyorsa, görüntüyü [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) ve [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) aracılığıyla değiştirin.
- Hâlâ boş bir yer tutucuysa, yer tutucunun koordinatlarında bir resim çerçevesi eklemek için [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) metodunu kullanın ve boş yer tutucuyu kaldırın.

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

Boş bir yer tutucu için oluşturulan değişiklik, yeni bir yer tutucu değil, yerel bir resim çerçevesidir; çünkü [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) bir ayarlayıcı sağlamaz. Ayrılan konumu korur ancak artık yer tutucu‑özel davranışı devralmaz. Yer tutucu ilişkisini korumak önemliyse, önce PowerPoint’te yer tutucuyu hazırlayıp doldurun, ardından Aspose.Slides ile oluşan [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) nesnesini güncelleyin.

Resim şeffaflığı, kırpma ve diğer resim‑özel etkiler için [Manage Picture Frames](/slides/tr/nodejs-java/picture-frame/) sayfasına bakın. Bu işlemler resim çerçevesi veya resim doldurmasıyla ilgilidir, yer tutucu meta verileriyle değil.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucusu bir [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) ile temsil edilebilir. Bu örnek, yer tutucu tipi ve çalışma zamanındaki sınıfı kullanarak böyle bir grafiği bulur, başlığını değiştirir ve dosyayı kaydeder:

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

Genel bir içerik yer tutucusu genellikle [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object) tipine sahiptir. PowerPoint’te bu, grafikler, tablolar, diyagramlar, resimler ve medya dahil olmak üzere çeşitli içerik türleri için bir başlatıcı görevi görür. Dolu hâle getirildikten sonra, ne içerdiğini öğrenmek için gerçek şekil sınıfını inceleyin. Özelleştirilmiş yerleşimler ayrıca [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) veya [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram) tiplerini de ortaya çıkarabilir.

Aspose.Slides, bir boş [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) yer tutucusunu yalnızca [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) değiştirerek bir [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) nesnesine dönüştürmez; tip nesne üzerinden değiştirilemez. Boş bir grafik veya içerik alanını programatik olarak doldurmak için gereken nesneyi yer tutucunun koordinatlarında ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bunu bir grafik için yapar:

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

Eklenen grafik sıradan bir yerel grafiktir. Yer tutucunun alanını kaplar ancak yerleşim yer tutucusundan devralmaz. Kategorilerini, serilerini veya çalışma kitabı verilerini değiştirmek zorunda olduğunuzda ilgili [chart management articles](/slides/tr/nodejs-java/powerpoint-charts/) sayfalarını kullanın.

## **Tam Örnek: Metin veya Resim İçeriğini Güncelleme**

Aşağıdaki uçtan‑uza örnek bir şablonu açar, ilk slaytta bir başlık ya da resim yer tutucusunu arar, yer tutucu ve şekil tiplerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, şekil indeksine dayanmayı ya da her yer tutucuyu aynı sınıf gibi işlemeyi bilinçli olarak önler.

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

Temel yer tutucu, başka bir yer tutucunun devraldığı yerleşim veya ana slayttaki karşılık gelen şekildir. Onu elde etmek için [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) metodunu kullanın. Sıradan bir yerel şekil, yer tutucu hiyerarşisinin bir parçası olmadığı için `null` döndürür.

**Tüm slayt başlıklarını bir yerleşim yer tutucusunu düzenleyerek değiştirebilir miyim?**

Bir yerleşim aracılığıyla devralınan biçimlendirmeyi veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda depolanır. Sunum genelinde gerçek başlık metinlerini değiştirmek için slaytları dolaşmalı ve her başlık yer tutucusunu güncellemelisiniz.

**Tarih, slayt numarası, üst bilgi ve alt bilgi yer tutucularını nasıl yönetirim?**

Bu öğeleri uygun slayt, yerleşim, ana, not veya dağıtım kapsamında başlık ve alt bilgi yöneticileri üzerinden yönetin. Ayrıntılı örnekler için [Manage Presentation Header and Footer](/slides/tr/nodejs-java/presentation-header-and-footer/) sayfasına bakın.