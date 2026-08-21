---
title: Java’da Sunumlarda Çizim Kılavuzlarını Yönetme
linktitle: Çizim Kılavuzları
type: docs
weight: 85
url: /tr/java/drawing-guides/
keywords:
- çizim kılavuzu
- yatay kılavuz
- dikey kılavuz
- hizalama kılavuzu
- slayt görünümü
- master slayt
- yerleşim slaytı
- not master
- el dağıtım master
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint sunumlarında yatay ve dikey çizim kılavuzlarını ekleyin, erişin ve temizleyin."
---
## **Genel Bakış**

Çizim kılavuzları, PowerPoint'te bir sunumu düzenlerken kullanıcıların şekilleri tutarlı bir şekilde hizalamasına yardımcı olan ayarlanabilir yatay ve dikey çizgilerdir. Uygulamanın daha sonra manuel olarak düzeltilmesi planlanan bir sunum oluşturduğu durumlarda özellikle yararlıdır: uygulama, yazarların içerik eklerken veya taşırken uygulamaları gereken aynı hizalama yardımlarını kaydedebilir.

Çizim kılavuzları, slayt içeriği değil, düzenleme yardımcılarıdır. Slayt gösterisinde veya oluşturulan çıktıda görünmezler. Aspose.Slides for Java, bunları [IDrawingGuidesCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idrawingguidescollection/) arayüzü üzerinden sunar. Bir kılavuz, [IDrawingGuide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idrawingguide/) ile temsil edilir ve bir yönelim, konum ve renk içerir.

Konum, ilgili slayt ya da master'ın sol üst köşesinden itibaren puan cinsinden ölçülür. Dikey bir kılavuz, genellikle sıfır ile slayt genişliği arasında bir yatay koordinat kullanır. Yatay bir kılavuz ise genellikle sıfır ile slayt yüksekliği arasında bir dikey koordinat kullanır.

## **Slayt Görünümüne Kılavuz Ekleme**

Normal slaytları düzenlerken görüntülenen kılavuzları yönetmek için [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) yöntemini kullanın. Bir [Orientation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/orientation/) değeri ve puan cinsinden bir konum ile [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) çağrısı yapın.

Aşağıdaki örnek, slayt merkezinin sağ tarafına bir dikey kılavuz ve altına bir yatay kılavuz ekler:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Çizim Kılavuzlarına Erişim**

Mevcut kılavuzlara erişim sağlamak için [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idrawingguidescollection/#getCount--) ve [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) yöntemleri kullanılır. [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idrawingguide/#getPosition--), ve [IDrawingGuide.getColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idrawingguide/#getColor--) yöntemleri, ilgili ayarlayıcı (setter) yöntemleriyle değiştirilebilen değerleri döndürür.

Aşağıdaki örnek, yukarıda oluşturulan sunumdan slayt-görünümü kılavuzlarını okur:

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

## **Master ve Layout Slaytlarına Kılavuz Ekleme**

Bir slayt master'ı ve her bir yerleşim slaytı, kendi çizim kılavuzu koleksiyonlarına sahip olabilir. Master slaytı için [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/#getDrawingGuides--) ve yerleşim slaytı için [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) yöntemlerini kullanın.

Aşağıdaki örnek, ilk master slayta bir dikey kılavuz ve ilk yerleşim slayta bir yatay kılavuz ekler:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Not ve El Dağıtım Master'larına Kılavuz Ekleme**

Not master'ları ve el dağıtım master'ları da çizim kılavuzlarını destekler. Koleksiyonlarına erişmek için [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) ve [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) yöntemlerini kullanın. Sunum bu master'lardan birini içermiyorsa, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) veya [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) varsayılan master'ı oluşturur ve döndürür.

Aşağıdaki örnek, bir not master'ına yatay bir kılavuz ve bir el dağıtım master'ına dikey bir kılavuz ekler:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Çizim Kılavuzlarını Temizleme**

Belirli bir koleksiyondaki tüm kılavuzları kaldırmak için [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idrawingguidescollection/#clear--) yöntemini çağırın. Bir koleksiyonun temizlenmesi, başka bir kapsamda saklanan kılavuzları etkilemez.

Aşağıdaki örnek, eksik master'lar oluşturulmadan slayt-görünümü kılavuzlarını ve slayt master'ları, yerleşim slaytları, not master'ı ve el dağıtım master'ı üzerindeki tüm kılavuzları temizler:

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

**Çizim kılavuzları bir slayt gösterisinde veya dışa aktarılan görüntülerde görünür mü?**

Hayır. Çizim kılavuzları düzenleme için hizalama yardımcılarıdır ve sunum içeriği olarak işlenmez.

**Bir çizim kılavuzu doğrudan bireysel normal bir slayta eklenebilir mi?**

Normal slayt düzenleme kılavuzları, sunumun slayt-görünüm özelliklerinde saklanır. Slayt master'ları, yerleşim slaytları, not master'ları ve el dağıtım master'ları için ayrı kılavuz koleksiyonları mevcuttur.

**Kılavuz konumları için hangi birimler kullanılır?**

Konumlar puan cinsinden belirtilir; 72 puan bir inçtir. Dikey konumlar sol kenardan, yatay konumlar üst kenardan ölçülür.

**Çizim kılavuzlarını temizlemek şekilleri kaldırır veya slayt içeriğini değiştirir mi?**

Hayır. [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idrawingguidescollection/#clear--) yöntemi yalnızca seçilen koleksiyondaki kılavuzları kaldırır. Şekiller ve diğer slayt içerikleri değişmeden kalır.