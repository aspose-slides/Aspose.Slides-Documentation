---
title: JavaScript ile Sunumlarda Çizim Kılavuzlarını Yönetme
linktitle: Çizim Kılavuzları
type: docs
weight: 85
url: /tr/nodejs-java/drawing-guides/
keywords:
- çizim kılavuzu
- yatay kılavuz
- dikey kılavuz
- hizalama kılavuzu
- slayt görünümü
- master slayt
- düzen slaytı
- not master
- el kitabı master
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint sunumlarında yatay ve dikey çizim kılavuzlarını ekleyin, erişin ve temizleyin."
---
## **Genel Bakış**

Çizim kılavuzları, PowerPoint'te bir sunumu düzenlerken kullanıcıların şekilleri tutarlı bir şekilde hizalamasına yardımcı olan ayarlanabilir yatay ve dikey çizgilerdir. Özellikle bir uygulama sunumu otomatik olarak oluşturup daha sonra manuel olarak iyileştirilecekse faydalıdır: uygulama, yazarların içerik eklerken veya taşırken takip etmesi gereken aynı hizalama yardımlarını kaydedebilir.

Çizim kılavuzları düzenleme yardımcılarıdır, slayt içeriği değildir. Slayt gösterisinde veya oluşturulan çıktıda görünmezler. Aspose.Slides for Node.js via Java, bunları [DrawingGuidesCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/drawingguidescollection/) sınıfı aracılığıyla sunar. Bir kılavuz, [DrawingGuide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/drawingguide/) ile temsil edilir ve bir yönelim, bir konum ve bir renge sahiptir.

Konum, ilgili slayt ya da master'ın sol üst köşesinden ölçülen nokta biriminde ifade edilir. Dikey bir kılavuz, genellikle sıfır ile slayt genişliği arasında değişen bir yatay koordinat kullanır. Yatay bir kılavuz, genellikle sıfır ile slayt yüksekliği arasında değişen bir dikey koordinat kullanır.

## **Kılavuzları Slayt Görünümüne Ekle**

Normal slaytları düzenlerken görüntülenen kılavuzları yönetmek için [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) kullanın. [DrawingGuidesCollection.add](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/drawingguidescollection/#add) metodunu bir [Orientation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/orientation/) değeri ve nokta biriminde bir konum ile çağırın.

Aşağıdaki örnek, slayt merkezinin sağına bir dikey kılavuz ve altına bir yatay kılavuz ekler:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Çizim Kılavuzlarına Erişme**

[DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/drawingguidescollection/#getCount) ve [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) metodları mevcut kılavuzlara erişim sağlar. [DrawingGuide.getOrientation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/drawingguide/#getPosition) ve [DrawingGuide.getColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/drawingguide/#getColor) metodları, ilgili setter metodları aracılığıyla değiştirilebilen değerler döndürür.

Aşağıdaki örnek, yukarıda oluşturulan sunumdan slayt‑görünüm kılavuzlarını okur:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Kılavuzları Master ve Düzen Slaytlarına Ekle**

Bir slayt master'ı ve her bir düzen slaytı kendi çizim kılavuzu koleksiyonlarına sahip olabilir. Bir master slayt için [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/#getDrawingGuides), bir düzen slaytı için ise [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) kullanın.

Aşağıdaki örnek, ilk master slayta bir dikey kılavuz ve ilk düzen slayta bir yatay kılavuz ekler:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kılavuzları Not ve El Kitabı Master'larına Ekle**

Not master'ları ve el kitabı master'ları da çizim kılavuzlarını destekler. Koleksiyonlarına erişmek için [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) ve [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) kullanın. Bir sunum bu master'lardan birini içermiyorsa, `MasterNotesSlideManager.setDefaultMasterNotesSlide` veya `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` varsayılan master'ı oluşturur ve döndürür.

Aşağıdaki örnek, bir not master'ına bir yatay kılavuz ve bir el kitabı master'ına bir dikey kılavuz ekler:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Çizim Kılavuzlarını Temizle**

Belirli bir koleksiyondan tüm kılavuzları kaldırmak için [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/drawingguidescollection/#clear) metodunu çağırın. Bir koleksiyonun temizlenmesi, başka bir kapsamda depolanan kılavuzları etkilemez.

Aşağıdaki örnek, eksik master'lar oluşturulmadan slayt‑görünüm kılavuzlarını ve slayt master'ları, düzen slaytları, not master'ı ve el kitabı master'ı üzerindeki tüm kılavuzları temizler:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Çizim kılavuzları slayt gösterisinde veya dışa aktarılan görüntülerde görülür mü?**

Hayır. Çizim kılavuzları düzenleme için hizalama yardımlarıdır ve sunum içeriği olarak render edilmez.

**Bir çizim kılavuzu doğrudan bireysel bir normal slayta eklenebilir mi?**

Normal slayt düzenleme kılavuzları, sunumun slayt‑görünüm özelliklerinde saklanır. Slayt master'ları, düzen slaytları, not master'ları ve el kitabı master'ları için ayrı kılavuz koleksiyonları mevcuttur.

**Kılavuz konumları için hangi birimler kullanılır?**

Konumlar nokta biriminde belirtilir; 72 nokta bir inçe eşittir. Dikey konumlar sol kenardan, yatay konumlar üst kenardan ölçülür.

**Çizim kılavuzlarını temizlemek şekilleri kaldırır ya da slayt içeriğini değiştirir mi?**

Hayır. [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/drawingguidescollection/#clear) metodu yalnızca seçili koleksiyondaki kılavuzları kaldırır. Şekiller ve diğer slayt içeriği değişmeden kalır.