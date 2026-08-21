---
title: Android'te Sunumlarda Çizim Kılavuzlarını Yönetme
linktitle: Çizim Kılavuzları
type: docs
weight: 85
url: /tr/androidjava/drawing-guides/
keywords:
- çizim kılavuzu
- yatay kılavuz
- dikey kılavuz
- hizalama kılavuzu
- slayt görünümü
- master slayt
- yerleşim slaytı
- not master
- el ilanı master
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint sunumlarında yatay ve dikey çizim kılavuzlarını ekleyin, erişin ve temizleyin."
---
## **Genel Bakış**

Çizim kılavuzları, PowerPoint'te bir sunumu düzenlerken kullanıcıların şekilleri tutarlı bir şekilde hizalamasına yardımcı olan ayarlanabilir yatay ve dikey çizgilerdir. Özellikle bir uygulama, daha sonra manuel olarak iyileştirilecek bir sunum oluşturduğunda faydalıdır: uygulama, yazarların içerik eklerken veya taşırken takip etmesi gereken aynı hizalama yardımcılarını kaydedebilir.

Çizim kılavuzları, slayt içeriği değil, düzenleme yardımcılarıdır. Bir slayt gösterisinde veya oluşturulan çıktıda görünmezler. Aspose.Slides for Android via Java, bunları [IDrawingGuidesCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idrawingguidescollection/) arayüzü aracılığıyla sunar. Bir kılavuz, [IDrawingGuide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idrawingguide/) ile temsil edilir ve bir yönelim, bir konum ve bir renge sahiptir.

Konum, ilgili slayt ya da master'ın sol üst köşesinden nokta cinsinden ölçülür. Dikey bir kılavuz, genellikle sıfır ile slayt genişliği arasında olan yatay bir koordinat kullanır. Yatay bir kılavuz, genellikle sıfır ile slayt yüksekliği arasında olan dikey bir koordinat kullanır.

## **Kılavuzları Slayt Görünümüne Ekleyin**

Normal slaytları düzenlerken görüntülenen kılavuzları yönetmek için [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) kullanın. [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) metodunu bir [Orientation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/orientation/) değeri ve nokta cinsinden bir konum ile çağırın.

Aşağıdaki örnek, slayt ortasının sağ tarafına bir dikey kılavuz ve altına bir yatay kılavuz ekler:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Çizim Kılavuzlarına Erişim**

Mevcut kılavuzlara erişim sağlayan [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) ve [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) yöntemleridir. [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idrawingguide/#getPosition--) ve [IDrawingGuide.getColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idrawingguide/#getColor--) yöntemleri, ilgili ayarlayıcı (setter) yöntemleriyle değiştirilebilen değerler döndürür.

Aşağıdaki örnek, yukarıda oluşturulan sunumdan slayt‑görünümü kılavuzlarını okur:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Master ve Yerleşim Slaytlarına Kılavuz Eklemek**

Bir slide master ve her bir yerleşim slaytı kendi çizim‑kılavuz koleksiyonlarına sahip olabilir. Master slayt için [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) ve yerleşim slaytı için [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) kullanın.

Aşağıdaki örnek, ilk master slayta bir dikey kılavuz ve ilk yerleşim slayta bir yatay kılavuz ekler:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Not ve El İlanı Master'larına Kılavuz Eklemek**

Not master'ları ve el ilanı master'ları da çizim kılavuzlarını destekler. Koleksiyonlarına erişmek için [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) ve [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) kullanın. Bir sunum bu master'lardan birini içermiyorsa, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) veya [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) varsayılan master'ı oluşturur ve döndürür.

Aşağıdaki örnek, bir not master'ına yatay bir kılavuz ve bir el ilanı master'ına dikey bir kılavuz ekler:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Çizim Kılavuzlarını Temizlemek**

Belirli bir koleksiyondaki tüm kılavuzları kaldırmak için [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) metodunu çağırın. Bir koleksiyonun temizlenmesi, başka bir kapsamda depolanan kılavuzları etkilemez.

Aşağıdaki örnek, eksik master'lar oluşturulmadan slayt‑görünümü kılavuzlarını ve slayt master'ları, yerleşim slaytları, not master'ı ve el ilanı master'ındaki tüm kılavuzları temizler:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Çizim kılavuzları bir slayt gösterisinde veya dışa aktarılan görüntülerde görülür mü?**

Hayır. Çizim kılavuzları, düzenleme için hizalama yardımcılarıdır ve sunum içeriği olarak render edilmez.

**Bir çizim kılavuzu doğrudan bireysel normal bir slayta eklenebilir mi?**

Normal slayt düzenleme kılavuzları, sunumun slayt‑görünümü özelliklerinde depolanır. Slide master'ları, yerleşim slaytları, not master'ları ve el ilanı master'ları için ayrı kılavuz koleksiyonları mevcuttur.

**Kılavuz konumları için hangi birimler kullanılır?**

Konumlar, 72 noktanın bir inç olduğu noktalar cinsinden belirtilir. Dikey konumlar sol kenardan, yatay konumlar ise üst kenardan ölçülür.

**Çizim kılavuzlarını temizlemek şekilleri kaldırır veya slayt içeriğini değiştirir mi?**

Hayır. [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) yöntemi, yalnızca seçilen koleksiyondaki kılavuzları kaldırır. Şekiller ve diğer slayt içerikleri değişmeden kalır.