---
title: "Python üzerinden Java ile Slayt Düzenlerini Uygulama veya Değiştirme"
linktitle: "Slayt Düzeni"
type: docs
weight: 60
url: /tr/python-java/slide-layout/
keywords:
- "slayt düzeni"
- "içerik düzeni"
- "yer tutucu"
- "sunum tasarımı"
- "slayt tasarımı"
- "kullanılmayan düzen"
- "altbilgi görünürlüğü"
- "başlık slaytı"
- "başlık ve içerik"
- "bölüm başlığı"
- "iki içerik"
- "karşılaştırma"
- "yalnızca başlık"
- "boş düzen"
- "başlıklı içerik"
- "başlıklı resim"
- "başlık ve dikey metin"
- "dikey başlık ve metin"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java içinde slayt düzenlerini uygulama, oluşturma ve değiştirme, yer tutucular ekleme, kullanılmayan düzenleri kaldırma ve altbilgi görünürlüğünü kontrol etme."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzen uygulanması, slaytlara tutarlı bir yapı kazandırır ve aynı zamanda her slaytın kendi içeriğini içermesine olanak tanır.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Boş**: İçerik yer tutucusu içermez ve her şeklin elle konumlandırılacağı durumlarda faydalıdır.

## **Düzen Mirasını Anlamak**

Bir sunum üç ilgili seviyeye sahiptir:

1. Bir [master slayt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/) temayı, paylaşılan biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
1. Bir [düzen slaytı](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/) bir mastera aittir ve belirli bir yer tutucu düzeni tanımlar.
1. Bir [normal slayt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) bir düzeni kullanır ve o slayt için girilen içeriği depolar.

Bir normal slayt temayı ve biçimlendirmeyi düzeninden, düzen ise masterından devralır. Normal bir slaytta doğrudan ayarlanan bir değer, bu seviyedeki devralınan değeri geçersiz kılar. Bir normal slayt oluşturulduğunda, yer tutucu şekilleri seçilen düzenlerden oluşturulur, ancak bu yer tutuculara girilen içerik normal slayta aittir.

Bir düzenten slayt oluşturmadan önce gerekli yer tutucuları ekleyin. Daha sonra bir düzene başka bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişkinin iki önemli sonucu vardır:

- Bir düzen üzerindeki devralınan biçimlendirme veya mevcut yer tutucu geometrisinin değiştirilmesi, ona bağlı tüm slaytları güncelleyebilir. Zaten kullanılan bir düzeni düzenlemeden önce, ona bağlı slaytları inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt tarafından hâlâ kullanılan bir düzen kaldırılamaz. Önce bağlı slaytlarını başka bir düzene atayın veya yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin en üst seviyesi hakkında daha fazla bilgi için [Slide Master](/slides/tr/python-java/slide-master/) sayfasına bakın.

Bir slaytta veya ortak bir düzen üzerinden devralınan logoları veya süsleyici master şekillerini gizlemek için [Control the Visibility of Master Graphics](/slides/tr/python-java/slide-master/) bölümüne bakın. Örnek, aynı masterı kullanan iki slaytı karşılaştırır.

## **Bir Slayt Düzeni Seçme ve Uygulama**

Sunum standart PowerPoint düzen tanımlarını izliyorsa bir düzen türü kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu nedenle ad temelli seçim, kaynak şablon üzerinde kontrolünüz olmadıkça daha az güvenilirdir.

Aşağıdaki örnek, ilk masterda **Title and Content** düzenini arar. Bu düzen mevcut değilse, kasıtlı olarak **Blank** düzenine geri döner. `None` için ikinci kontrol, bir sunumun yalnızca özel düzenler içerebilmesi nedeniyle gereklidir. Seçilen düzen, ardından [Slide.setLayoutSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#setLayoutSlide) yöntemiyle ilk normal slayta uygulanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bir slaytın düzeninin değiştirilmesi, slayta doğrudan eklenen sıradan şekilleri kaldırmaz. Ancak, yer tutucu konumları, devralınan biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki ilişki değişebilir; bu nedenle, önemli ölçüde farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Düzen Slaytı Ekleme**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; yeni bir tane oluşturmaz. Bir düzen oluşturmak için, hedef masterın düzen koleksiyonunda [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterlayoutslidecollection/#add) yöntemini çağırın.

Aşağıdaki örnek her zaman `Report Title and Content` adıyla yeni bir **Title and Content** düzeni ekler, ardından buna dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bir şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda yalnızca bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopya oluşturmak yerine onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucular Eklemek**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#getPlaceholderManager) yöntemi, bir düzene yer tutucu şekilleri eklemek için bir [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/) sağlar.

| PowerPoint Yer Tutucu              | [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/) Yöntemi |
| ----------------------------------- | ---------------------------------- |
| ![İçerik](content.png)             | [addContentPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![İçerik (Dikey)](contentV.png)    | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Metin](text.png)                 | [addTextPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Metin (Dikey)](textV.png)        | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Resim](picture.png)              | [addPicturePlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Grafik](chart.png)               | [addChartPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tablo](table.png)                | [addTablePlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)          | [addSmartArtPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Ortam](media.png)                | [addMediaPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Çevrimiçi Görüntü](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Aşağıdaki örnek, **Blank** düzeninin varlığını doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıra kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slaytta ilgili yer tutucu şekillerini oluşturabilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Düzen slaydındaki yer tutucular](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Devralınan biçimlendirme veya mevcut düzen yer tutucularının geometrisinin değiştirilmesi, bağımlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara geriye doğru eklenmez. Düzen değişikliklerini sunumun bir kopyasında test edin ve her bağımlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini, hiçbir normal slaytın referans vermediği düzenleri kaldırmak için kullanın. Yöntem hâlâ kullanılan düzenleri aynı bırakır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bir belirli düzeni kaldırmak için önce onun [hasDependingSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#hasDependingSlides) veya [getDependingSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#getDependingSlides) yöntemini kullanın. [LayoutSlide.remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#remove) çağırmadan önce tüm bağımlı slaytları yeniden atayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxeditexception/) üretir.

## **Bir Düzen Slaytında Altbilgi Görünürlüğünü Kontrol Etme**

Bir düzenin kendi altbilgi, slayt numarası ve tarih‑zaman yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek üzere [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) yöntemini kullanın. Örneğin içerik düzenlerinin altbilgi göstermesi, başlık düzenlerinin göstermemesi gerektiğinde bu yararlıdır.

Aşağıdaki örnek bir düzeni güvenli bir şekilde seçer ve altbilgi öğelerini görünür kılar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Master ve Çocuk Düzenlerde Altbilgi Görünürlüğünü Kontrol Etme**

Master hiyerarşisi boyunca tutarlı altbilgi ayarları uygulamak için [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#getHeaderFooterManager) yöntemini kullanın. [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslideheaderfootermanager/) yöntemlerinin yayılımı master ve ona bağlı düzen slaytları ile normal slaytlar üzerinde çalışır; sadece tek bir normal slaytı hedeflemez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Master Slayt ile Layout Slayt arasındaki fark nedir?**

Bir master slayt, sunumun temasını ve paylaşılan biçimlendirmesini tanımlar. Bir layout slayt, bir mastera aittir ve yer tutucuların yeniden kullanılabilir bir düzenini tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği depolar.

**Bir Layout Slaytı bir sunumdan başka birine kopyalayabilir miyim?**

Evet. Hedef koleksiyona bir kopya eklemek için [addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/globallayoutslidecollection/#addClone) yöntemini kullanın. Sunumlar arasında kopyalama yaparken, kaynak düzenin kullandığı yazı tiplerini, temaları, görselleri ve diğer kaynakları da doğrulayın.

**Zaten kullanımdaki bir düzeni değiştirdiğimde ne olur?**

Bağımlı slaytlar, yerel olarak etkilenilen biçimlendirme veya nesneleri geçersiz kılmadıkça, düzen değişikliklerini devralır. Yer tutucu geometrisi ve devralınan stil bu nedenle birçok slaytta aynı anda değişebilir. Düzeni düzenlemeden önce etkilenen slaytları belirlemek için [getDependingSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#getDependingSlides) yöntemini kullanın.

**Hâlâ kullanımda olan bir düzeni kaldırırsam ne olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxeditexception/) fırlatır. Önce bağımlı slaytları yeniden atayın veya yalnızca referans edilmeyen düzenleri kaldırmak için [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini kullanın.