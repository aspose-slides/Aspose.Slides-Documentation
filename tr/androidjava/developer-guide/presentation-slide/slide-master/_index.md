---
title: Android'de Sunum Slide Master'larını Yönet
linktitle: Slide Master
type: docs
weight: 70
url: /tr/androidjava/slide-master/
keywords:
- slide master
- master slayt
- PPT master slayt
- çoklu master slaytlar
- master slaytları karşılaştır
- arkaplan
- yer tutucu
- master slaytı klonla
- master slaytı kopyala
- master slaytı çoğalt
- kullanılmayan master slayt
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da slide master'ları yönetin: PowerPoint ve OpenDocument sunumlarında master slaytları erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slide master**, bir grup slayt için paylaşılan tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve alt bilgi ayarları içerebilir. PowerPoint’te bir slide master’ı düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for Android via Java aynı modeli destekler. Bir sunum bir veya daha fazla master slayt içerebilir ve her master slayt birkaç layout slaytı barındırabilir. Normal slaytlar genellikle doğrudan bir master slayta başvurmaz. Bunun yerine, normal bir slayt bir layout slaytını kullanır ve bu layout slayt bir master slayta ait olur.

Hiyerarşi şudur:

1. **Slide master** – paylaşılan tasarımı ve temayı tanımlar.  
1. **Layout slide** – yer tutucuların ve layout‑seviyesi biçimlendirmenin belirli bir düzenini tanımlar.  
1. **Normal slide** – gerçek sunum içeriğini barındırır ve bir layout slaytını kullanır.

![Ana slaytların, düzen slaytlarının ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides’te bir slide master, [IMasterSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/) arayüzüyle temsil edilir. Bir sunumdaki tüm master slaytlara, [Presentation.getMasters](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getMasters--) koleksiyonu üzerinden erişilir; bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslidecollection/) arayüzünü uygular. Tam Android via Java API yüzeyi için [com.aspose.slides API referansına](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/) bakın.

{{% alert color="info" title="Inheritance" %}}
Aynı özellik birden fazla seviyede tanımlandığında, daha özel seviye kazanır. Örneğin, bir master slayt ve bir layout slayt aynı arka planı tanımlıyorsa, o layout’a dayalı slaytlar layout arka planını kullanır. Layout slaytları hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/slides/tr/androidjava/slide-layout/) sayfasına bakın.
{{% /alert %}}

## **Slide Master’lara Erişim**

PowerPoint’te **View** > **Slide Master** menüsünden Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides’te master slaytlara erişmek için `getMasters()` koleksiyonunu kullanın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Ayrıca normal bir slaytın kullandığı master slaytı, onun layout’u üzerinden alabilirsiniz:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Bir Slide Master’ın İçeriği**

Bir master slayt, slayt benzeri bir nesnedir. [IBaseSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/) arayüzünü uygular, bu yüzden normal ve layout slaytlarda kullanılan birçok slayt özelliğine sahiptir.

Sık kullanılan master slayt üyeleri şunlardır:

| Üye | Açıklama |
| --- | --- |
| `getBackground()` | Master seviyesindeki slayt arka planını ayarlar. |
| `getShapes()` | Logolar, resim çerçeveleri ve paylaşılan metin gibi master’a yerleştirilen şekilleri depolar. |
| `getLayoutSlides()` | Master’a ait layout slaytlarını depolar. |
| `getThemeManager()` | Master tema API’lerine erişim sağlar. |
| `getHeaderFooterManager()` | Master ve onun alt layoutları için üst bilgi, alt bilgi, tarih ve slayt numaralarını kontrol eder. |
| `getDependingSlides()` | Layoutları aracılığıyla master’a bağlı normal slaytları döndürür. |

## **Slide Master’a Görsel Ekleme**

Bir master slayta görsel eklediğinizde, o master’dan layout kullanan slaytlarda görünür. Bu, logolar, filigranlar, dekoratif bantlar ve diğer tekrarlanan görsel öğeler için faydalıdır.

Aşağıdaki örnek, ilk master slayta bir logo ekler:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/slides/tr/androidjava/picture-frame/) sayfasına bakın.

## **Master Grafiklerinin Görünürlüğünü Kontrol Etme**

[Miras alınan master grafiklerini (ör. logolar veya dekoratif şekiller) silmeden gizlemek] için [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) kullanılabilir. Görselleri gizlemek istediğiniz slaytta `false` değerini `Slide.setShowMasterShapes` (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) metoduna geçin ve görüntülenmesini istediğiniz slaytlarda `true` tutun.

Aşağıdaki bağımsız örnek, bir master’da mavi dekoratif bir bant oluşturur ve aynı boş layout’u kullanan iki slaytta farklı görünürlük ayarları uygular. İlk slaytta bant görünür, ikincisinde gizlidir. Giriş sunumu veya görsel gerekmez.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Örnek, yeni bir sunumla birlikte gelen **Blank** layout’unu kullanır ve başlangıç slaytının kendi yer tutucularını kaldırır.

### **Ayarın Kapsamını Seçme**

Normal bir slayt, master’ına `[ISlide.getLayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getLayoutSlide--)` ve `[ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--)` aracılığıyla erişir. Özelliği bireysel bir slaytta ayarlamak yalnız o slaytı etkiler. `false` değerini `[LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-)` metoduna geçirerek, paylaşılan layout’u kullanan tüm slaytlarda master grafiklerini gizleyebilirsiniz; kendi ayarları `true` olsa bile. Tek bir slaytta grafikleri gizlemek istiyorsanız, slayt özelliğini değiştirin ve ortak layout’u değiştirmeyin.

Bu ayar master slaytın kendisi üzerinde bir görünürlük kontrolü olarak desteklenmez. Bir master’da `getShowMasterShapes` her zaman `false` döner ve `setShowMasterShapes`’a `true` geçirildiğinde bir istisna oluşur. Bunu normal bir slayt ya da layout üzerinde uygulayın.

### **Grafikleri Arka Plandan Ayırma**

| İşlem | Etki |
| --- | --- |
| Master grafikleri gizle | Miras alınan master şekillerini silmeden veya slaytın kendi şekillerini değiştirmeden görünürlüğünü kontrol eder. |
| Slayt arka plan doldurmasını değiştir | Arka plan rengini, geçişini veya resmini değiştirir. Master grafikleri ayrı şekiller olduğundan, bu arka plan üzerine hâlâ görünebilir. [Presentation Background](/slides/tr/androidjava/presentation-background/) bakın. |
| Master’dan bir şekli sil | Paylaşılan kaynak şekli kaldırır, böylece o master’ı kullanan hiçbir slayt artık bu şekle erişemez. |

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle layout slaytlarda tanımlanır. Master slayt, bu layoutların devraldığı paylaşılan stil ve temayı sağlar; her layout ise hangi yer tutucuların mevcut olduğunu ve nerede konumlandığını belirler.

PowerPoint’te yer tutucu komutları Slide Master görünümünde mevcuttur.

![PowerPoint Slide Master görünümündeki Insert Placeholder komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için master’a ait layout slaytıyla çalışın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ayrıca bir master slaytta zaten var olan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve lineer degrade doldurma uygular:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Normal slaytlar tarafından devralınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/slides/tr/androidjava/manage-placeholder/) ve [Text Formatting](/slides/tr/androidjava/text-formatting/) sayfalarına bakın.

## **Slide Master Arka Planını Değiştirme**

Bir master arka planı, bunu geçersiz kılmayan layout ve slaytlar tarafından devralınır. Aşağıdaki örnek, ilk master slayt için katı bir arka plan rengi ayarlar:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

İlgili konular için [Presentation Background](/slides/tr/androidjava/presentation-background/) ve [Presentation Theme](/slides/tr/androidjava/presentation-theme/) sayfalarına bakın.

## **Bir Slide Master’ı Başka Bir Sunuma Kopyalama**

[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) metodunu kullanarak bir master slaytı başka bir sunuma kopyalayabilirsiniz. Kopyalanan master, hedef sunumdaki layout ve slaytlar tarafından kullanılabilir.

```java
import com.aspose.slides.*;

Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Normal slaytları masterlarıyla birlikte kopyalamanız gerekiyorsa, [Clone Slides](/slides/tr/androidjava/clone-slides/) sayfasına bakın.

## **Birden Çok Slide Master Ekleme**

Bir sunum birden çok master slayt içerebilir. Bu, farklı bölümlerin farklı marka kimliği, sayfa yapısı veya tema ayarları gerektirdiği durumlarda faydalıdır.

![PowerPoint’te master slayt ekleme ve yönetme komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan master’ı klonlar, klona farklı bir arka plan verir, o klonlanmış master altına bir layout oluşturur ve bu layout’a dayalı yeni bir slayt ekler:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slide Master’ları Karşılaştırma**

Master slaytlar, [IBaseSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/) tarafından devralınan `equals` yöntemiyle karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği inceler. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya geçerli tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

```java
import com.aspose.slides.*;

Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Daha fazla bilgi için [Compare Presentation Slides](/slides/tr/androidjava/compare-slides/) sayfasına bakın.

## **Slide Master Görünümünü Varsayılan Görünüm Olarak Ayarlama**

PowerPoint’in ilk açtığı görünümü kontrol etmek için [ViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewproperties/) üzerindeki `setLastView` metodunu kullanın. Aşağıdaki örnek sunumu Slide Master görünümünde açar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/androidjava/save-presentation/) sayfasına bakın.

## **Kullanılmayan Master Slaytları Kaldırma**

Bazen bir sunum, herhangi bir normal slayt tarafından artık kullanılmayan master slaytlar içerir. Kullanılmayan masterları kaldırmak dosya boyutunu azaltır ve şablon bakımını basitleştirir.

`removeUnused` metodunu kullanarak `getMasters()` koleksiyonundaki kullanılmayan masterları kaldırın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ayrıca düşük kodlu [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) metodunu da kullanabilirsiniz:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Slide master ile layout slide arasındaki fark nedir?**

Slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi paylaşılan tasarım ayarlarını tanımlar. Layout slide, bir master slayta ait olup yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir layout slide kullanır, böylece hem layout hem de master’dan devralır.

**Bir sunum birden fazla slide master içerebilir mi?**

Evet. Bir sunum birden fazla slide master barındırabilir. Farklı bölümlerin farklı görsel sistemler veya marka kimliği gerektirdiği durumlarda birden çok master kullanın.

**Yer tutucuları master slayta mı yoksa layout slayta mı eklemeliyim?**

Çoğu durumda yer tutucuları layout slaytlara ekleyin. Ortak görsel öğeleri ve ortak biçimlendirmeyi master slayta, içerik yer tutucularını ise normal slaytların kullanacağı layout’lara koyun.

**Kullanılan bir master slaytı silebilir miyim?**

Hayır. Bağımlı slaytları olan bir master slaytı doğrudan güvenli bir şekilde kaldırılamaz. Önce o slaytları başka bir master altındaki layout’lara taşıyın veya yalnızca kullanılmayan masterları temizleyen bir yöntem uygulayın.