---
title: Java'da Sunum Slide Master'larını Yönetme
linktitle: Slayt Master
type: docs
weight: 70
url: /tr/java/slide-master/
keywords:
- slayt master
- master slayt
- PPT master slaytı
- çoklu master slaytlar
- master slaytları karşılaştır
- arka plan
- yer tutucu
- master slaytı klonla
- master slaytı kopyala
- master slaytı çoğalt
- kullanılmayan master slayt
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da slide master'ları yönetin: PowerPoint ve OpenDocument sunumlarında master slaytlara erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slide master** bir grup slayt için paylaşılan tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve altbilgi ayarlarını içerebilir. PowerPoint'te, bir slide master'ı düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan bir sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for Java aynı modeli destekler. Bir sunum bir veya daha fazla master slayt içerebilir ve her master slayt birkaç layout slayt içerebilir. Normal slaytlar genellikle bir master slayta doğrudan başvurmaz. Bunun yerine, normal bir slayt bir layout slayt kullanır ve bu layout slayt bir master slayta aittir.

Hiyerarşi şudur:

1. **Slide master** - paylaşılan tasarımı ve temayı tanımlar.
1. **Layout slide** - yer tutucuların ve düzen düzeyindeki biçimlendirmenin belirli bir düzenlemesini tanımlar.
1. **Normal slide** - gerçek sunum içeriğini içerir ve bir layout slide kullanır.

![master slaytların, layout slaytların ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides'te bir slide master, [IMasterSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/) arayüzüyle temsil edilir. Bir sunumdaki tüm master slaytlar, [Presentation.getMasters](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getMasters--) koleksiyonu aracılığıyla erişilebilir ve bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslidecollection/) arayüzünü uygular.

{{% alert color="info" title="Inheritance" %}}
Aynı özellik birden fazla seviyede tanımlandığında, daha spesifik seviye geçerli olur. Örneğin, bir master slayt ve bir layout slayt aynı arka planı tanımlarsa, o layout'a dayalı slaytlar layout arka planını kullanır. Layout slaytları hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/slides/tr/java/slide-layout/) bölümüne bakın.
{{% /alert %}}

## **Slide Master'lara Erişim**

PowerPoint'te, Slide Master görünümünü **View** > **Slide Master** menüsünden açabilirsiniz.

![PowerPoint View sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides'te, master slaytlara erişmek için `getMasters()` koleksiyonunu kullanın:

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

Ayrıca bir normal slaytın kullandığı master slaytı, layout'u üzerinden elde edebilirsiniz:

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

## **Slide Master'ında Neler Bulunur**

Bir master slayt, slayt benzeri bir nesnedir. [IBaseSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/) arayüzünü uygular, bu nedenle normal ve layout slaytların kullandığı birçok aynı slayt özelliğine sahiptir. Master'a özgü üyeler [IMasterSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/) API sayfasında listelenmiştir.

Yaygın olarak kullanılan master slayt üyeleri şunlardır:

| Üye | Amaç |
| --- | --- |
| `getBackground()` | Master düzeyindeki slayt arka planını ayarlar. |
| `getShapes()` | Master üzerine yerleştirilen şekilleri (logolar, resim çerçeveleri ve paylaşılan metin gibi) depolar. |
| `getLayoutSlides()` | Master'a ait layout slaytları depolar. |
| `getThemeManager()` | Master tema API'lerine erişim sağlar. |
| `getHeaderFooterManager()` | Master ve alt layoutları için üstbilgi, altbilgi, tarihler ve slayt numaralarını kontrol eder. |
| `getDependingSlides()` | Layoutları aracılığıyla master'a bağımlı olan normal slaytları döndürür. |

## **Slide Master'a Resim Ekleme**

Bir master slayta bir resim eklediğinizde, o master'ın layoutlarını kullanan slaytlarda görünür. Bu, logolar, filigranlar, süs bantları ve diğer yinelenen görsel öğeler için faydalıdır.

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

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/slides/tr/java/picture-frame/) sayfasına bakın.

## **Master Grafiklerin Görünürlüğünü Kontrol Etme**

Kalıtılan master grafiklerini (örneğin logolar veya süs şekilleri) silmeden gizlemek için [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) yöntemini kullanın. Bu grafiklerin gizlenmesi gereken slaytta [Slide.setShowMasterShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) metoduna `false` gönderin ve gösterilmesi gereken slaytlarda `true` tutun.

Aşağıdaki bağımsız örnek, bir master üzerinde mavi bir süs bandı oluşturur ve aynı boş layoutu kullanan iki slaytta bu bandı farklı şekilde gösterir. İlk slaytta görünür, ikincisinde gizlidir. Giriş sunumu veya resim gerektirmez.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
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

Örnek, yeni bir sunumla birlikte verilen **Blank** layoutunu kullanır ve ilk slaytın kendi yer tutucularını kaldırır.

### **Ayarın Kapsamını Seçin**

Normal bir slayt, masterını [ISlide.getLayoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getLayoutSlide--) ve [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#getMasterSlide--) aracılığıyla kullanır. Özelliği bireysel bir slayta ayarlamak yalnızca o slaytı etkiler. `false` değeri [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) metoduna gönderilirse, ortak layoutu kullanan tüm slaytlarda master grafikleri gizlenir, kendi ayarları `true` olsa bile. Tek bir slaytta grafik gizlemek için slayt özelliğini değiştirin ve ortak layoutu değiştirmeyin.

Bu ayar, master slaytın kendisinde görünürlük kontrolü olarak desteklenmez. Bir master üzerinde [getShowMasterShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/masterslide/#getShowMasterShapes--) her zaman `false` döndürür ve [setShowMasterShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) metoduna `true` gönderildiğinde bir istisna fırlatır. Bunun yerine normal bir slayta veya layouta uygulayın.

### **Grafikleri Arka Plandan Ayırma**

| İşlem | Etki |
| --- | --- |
| Master grafiklerini gizle | Kalıtılan master şekillerinin görünürlüğünü silmeden (ve slaytın kendi şekillerini değiştirmeden) kontrol eder. |
| Slayt arka plan doldurmasını değiştir | Arka plan rengini, geçişini veya resmini değiştirir. Master grafikler ayrı şekiller olduğundan bu arka planın üzerinde görünür kalabilir. [Presentation Background](/slides/tr/java/presentation-background/) sayfasına bakın. |
| Master'dan bir şekil sil | Paylaşılan kaynak şekli siler, böylece o master'ı kullanan hiçbir slayt artık bu şekle erişemez. |

## **Yer Tutucularla Çalışmak**

Yer tutucular genellikle layout slaytlarda tanımlanır. Master slayt, bu layoutların miras aldığı ortak stil ve temayı sağlar; her layout ise hangi yer tutucuların mevcut olduğunu ve nerede konumlandırılacağını belirler.

PowerPoint'te yer tutucu komutları Slide Master görünümünde bulunur.

![PowerPoint Slide Master görünümünde Yer Tutucu Ekle komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için, master'a ait layout slaytı üzerinde çalışın:

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

Ayrıca master slayt üzerinde zaten var olan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve lineer bir geçiş doldurması uygular:

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

![Normal slaytlar tarafından kalıtılan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/slides/tr/java/manage-placeholder/) ve [Text Formatting](/slides/tr/java/text-formatting/) bölümlerine bakın.

## **Slide Master Arka Planını Değiştir**

Master arka planı, üzerine yazılmadığı sürece layoutlar ve slaytlar tarafından miras alınır. Aşağıdaki örnek, ilk master slayt için katı bir arka plan rengi ayarlar:

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

İlgili konular için [Presentation Background](/slides/tr/java/presentation-background/) ve [Presentation Theme](/slides/tr/java/presentation-theme/) bölümlerine bakın.

## **Slide Master'ı Başka Bir Sunuma Kopyalama**

Bir master slaytı başka bir sunuma kopyalamak için [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) yöntemini kullanın. Kopyalanan master, hedef sunumdaki layoutlar ve slaytlar tarafından kullanılabilir.

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

Normal slaytları ve masterlarını birlikte kopyalamanız gerekiyorsa, [Clone Slides](/slides/tr/java/clone-slides/) bölümüne bakın.

## **Birden Çok Slide Master Ekleme**

Bir sunum birden çok master slayt içerebilir. Bu, farklı bölümlerin farklı marka, sayfa yapısı veya tema ayarları gerektirdiği durumlarda faydalıdır.

![Master slayt ekleme ve yönetme için PowerPoint komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan master'ı klonlar, klona farklı bir arka plan verir, bu klon master altında bir layout oluşturur ve o layout temelinde yeni bir slayt ekler:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

## **Slide Master'ları Karşılaştırma**

Master slaytlar, [IBaseSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/) tarafından miras alınan `equals` yöntemiyle karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya o anki tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

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

Daha fazla bilgi için [Compare Presentation Slides](/slides/tr/java/compare-slides/) bölümüne bakın.

## **Slide Master Görünümünü Varsayılan Görünüm Olarak Ayarlama**

PowerPoint'in ilk açtığı görünümü kontrol etmek için [ViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewproperties/) üzerindeki `setLastView` metodunu kullanın. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

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

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/java/save-presentation/) bölümüne bakın.

## **Kullanılmayan Master Slaytları Kaldırma**

Bazen bir sunumda, hiçbir normal slayt tarafından kullanılmayan master slaytlar bulunur. Kullanılmayan masterları kaldırmak dosya boyutunu küçültebilir ve şablon bakımını basitleştirebilir.

`removeUnused` metodunu kullanarak `getMasters()` koleksiyonundan kullanılmayan masterları kaldırın:

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

Ayrıca düşük kodlu [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) metodunu da kullanabilirsiniz:

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

Slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi paylaşılan tasarım ayarlarını tanımlar. Layout slide, bir master slayta ait olup belirli bir yer tutucu düzenini tanımlar. Normal bir slayt bir layout slide kullanır; böylece hem layouttan hem de masterdan miras alır.

**Bir sunum birden fazla slide master içerebilir mi?**

Evet. Bir sunum birden fazla slide master içerebilir. Farklı bölümlerin farklı görsel sistemler veya marka kimlikleri gerektirdiği durumlarda birden çok master kullanın.

**Yer tutucuları master slayta mı yoksa layout slayta mı eklemeliyim?**

Çoğu durumda yer tutucuları layout slaytlara ekleyin. Paylaşılan görsel öğeler ve ortak biçimlendirmeyi master slayta koyun, ardından normal slaytların kullanacağı layoutlarda içerik yer tutucularını yerleştirin.

**Kullanılan bir master slaytı silebilir miyim?**

Hayır. Bağımlı slaytları olan bir master slaytı doğrudan silmek güvenli değildir. Önce bu slaytları başka bir master altındaki layoutlara taşıyın veya kullanılmayan masterları temizleyen bir yöntemle sadece kullanılmayan masterları kaldırın.