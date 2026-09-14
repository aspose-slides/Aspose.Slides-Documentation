---
title: Python üzerinden Java ile Slayt Düzenlerini Uygulama veya Değiştirme
linktitle: Slayt Düzeni
type: docs
weight: 60
url: /tr/python-java/slide-layout/
keywords:
- slayt düzeni
- içerik düzeni
- yer tutucu
- sunum tasarımı
- slayt tasarımı
- kullanılmayan düzen
- alt bilgi görünürlüğü
- başlık slaytı
- başlık ve içerik
- bölüm başlığı
- iki içerik
- karşılaştırma
- sadece başlık
- boş düzen
- başlıklı içerik
- başlıklı resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile slayt düzenlerini uygulama, oluşturma ve değiştirme, yer tutucular ekleme, kullanılmayan düzenleri kaldırma ve alt bilgi görünürlüğünü kontrol etme."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzenin uygulanması, slaytlara tutarlı bir yapı kazandırırken her slaydın kendi içeriğini barındırmasına izin verir.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Boş**: İçerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlarda kullanışlıdır.

## **Düzen Mirasını Anlama**

Bir sunum üç ilgili seviyeye sahiptir:

1. Bir [master slayt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/) temayı, paylaşılan biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
2. Bir [düzen slaytı](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/) bir mastera aittir ve yer tutucuların belirli bir düzenlemesini tanımlar.
3. Bir [normal slayt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) bir düzeni kullanır ve o slayt için girilen içeriği depolar.

Bir normal slayt, temayı ve biçimlendirmeyi düzeninden miras alır ve düzen de masterından miras alır. Normal bir slaytta doğrudan ayarlanan bir değer, o seviyedeki miras alınan değeri geçersiz kılar. Bir normal slayt oluşturulduğunda, yer tutucu şekilleri seçilen düzenden oluşturulur, bu yer tutuculara girilen içerik ise normal slayta aittir.

Bir slayt oluşturulmadan önce bir düzene gerekli yer tutucular ekleyin. Daha sonra bir düzene başka bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişki iki önemli sonuca sahiptir:

- Bir düzen üzerindeki miras alınan biçimlendirme veya mevcut yer tutucu geometrisinin değiştirilmesi, ona bağlı tüm slaytları güncelleyebilir. Zaten kullanımda olan bir düzeni düzenlemeden önce, bağlı slaytlarını inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt tarafından hâlâ kullanılan bir düzen kaldırılamaz. Önce bağlı slaytlarını başka bir düzenle yeniden ilişkilendirin veya yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst seviyesi hakkında daha fazla bilgi için [Slide Master](/slides/tr/python-java/slide-master/) sayfasına bakın.

## **Bir Slayt Düzeni Seçme ve Uygulama**

Sunum standart PowerPoint düzen tanımlarını izlediğinde bir düzen türü kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu yüzden ad temelli seçim, kaynak şablonu kontrol etmediğiniz sürece daha az güvenilirdir.

Aşağıdaki örnek, ilk masterda **Başlık ve İçerik** düzenini arar. Bu düzen bulunamazsa, kasıtlı olarak **Boş** düzenine geri döner. `None` kontrolünün ikinci kez yapılması gereklidir çünkü bir sunum yalnızca özel düzenler içerebilir. Seçilen düzen daha sonra ilk normal slayta [Slide.setLayoutSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#setLayoutSlide) yöntemiyle uygulanır.

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

Bir slaydın düzenini değiştirmek, slayta doğrudan eklenen normal şekilleri kaldırmaz. Ancak, yer tutucu konumları, miras alınan biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki eşleşme değişebilir; bu yüzden önemli ölçüde farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Bir Düzen Slaytı Ekleme**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; bir tane oluşturmaz. Bir düzen oluşturmak için hedef masterın düzen koleksiyonunda [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterlayoutslidecollection/#add) yöntemini çağırın.

Aşağıdaki örnek her zaman `Report Title and Content` adlı yeni bir **Başlık ve İçerik** düzeni ekler, ardından buna dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

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

Şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda sadece bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopya oluşturmak yerine onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucu Ekleme**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#getPlaceholderManager) yöntemi, bir düzene yer tutucu şekilleri eklemek için bir [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/) sağlar.

| PowerPoint Yer Tutucu | [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/) Yöntemi |
| --------------------- | ---------------------------------- |
| ![Content](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Aşağıdaki örnek, **Boş** düzeninin mevcut olduğunu doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıra kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slaytta karşılık gelen yer tutucu şekillerini oluşturabilir.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Miras alınan biçimlendirme veya mevcut düzen yer tutucularının geometrisinin değiştirilmesi, bağlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara otomatik olarak eklenmez. Düzen değişikliklerini bir sunum kopyası üzerinde test edin ve her bağlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini, hiçbir normal slaytın referans göstermediği düzenleri kaldırmak için kullanın. Yöntem hâlâ kullanımda olan düzenleri olduğu gibi bırakır.

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

Belirli bir düzeni kaldırmak için önce onun [hasDependingSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#hasDependingSlides) veya [getDependingSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#getDependingSlides) yöntemini kullanın. [LayoutSlide.remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#remove) metodunu çağırmadan önce bağlı slaytları yeniden atayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxeditexception/) hatası oluşturur.

## **Bir Düzen Slaytında Alt Bilgi Görünürlüğünü Kontrol Etme**

Bir düzenin kendi alt bilgi, slayt numarası ve tarih-saat yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek üzere [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) metodunu kullanın. Bu, örneğin içerik düzenlerinin alt bilgiler göstermesi, başlık düzenlerinin ise göstermemesi gerektiğinde faydalıdır.

Aşağıdaki örnek, bir düzeni güvenle seçer ve alt bilgi öğelerini görünür kılar:

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

## **Bir Master ve Alt Düzenlerinde Alt Bilgi Görünürlüğünü Kontrol Etme**

Bir master hiyerarşisi boyunca tutarlı alt bilgi ayarları uygulamak için [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#getHeaderFooterManager) metodunu kullanın. [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslideheaderfootermanager/) yöntemlerinin yayılımı, master ve onun bağlı düzen slaytları ile normal slaytlar üzerinde çalışır; yalnızca bir normal slaytı hedeflemez.

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

**Master Slayt ile Layout Slayt Arasındaki Fark Nedir?**

Bir master slayt, sunumun temasını ve paylaşılan biçimlendirmesini tanımlar. Bir layout slaytı bir mastera aittir ve yer tutucuların yeniden kullanılabilir bir düzenini tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği depolar.

**Bir Layout Slaytını Bir Sunumdan Başkasına Kopyalayabilir miyim?**

Evet. Hedef koleksiyona bir kopya eklemek için [addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/globallayoutslidecollection/#addClone) metodunu kullanın. Sunumlar arasında kopyalarken, kaynak düzenin kullandığı yazı tipleri, temalar, resimler ve diğer kaynakları da doğrulayın.

**Zaten Kullanımda Olan Bir Layoutu Değiştirdiğimde Ne Olur?**

Bağlı slaytlar, yerel olarak etkilenen biçimlendirmeyi veya nesneleri geçersiz kılmadıkları sürece layout değişikliklerini miras alır. Bu yüzden yer tutucu geometrisi ve miras alınan stil birçok slaytta aynı anda değişebilir. Layoutu düzenlemeden önce etkilenen slaytları belirlemek için [getDependingSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#getDependingSlides) yöntemini kullanın.

**Hâlâ Kullanımda Olan Bir Layoutu Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxeditexception/) hatası fırlatır. Önce bağlı slaytları yeniden atayın veya yalnızca referans edilmeyen düzenleri kaldırmak için [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini kullanın.