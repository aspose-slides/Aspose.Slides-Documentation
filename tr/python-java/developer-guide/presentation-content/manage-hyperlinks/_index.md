---
title: Python aracılığıyla Java'da Sunum Köprülerini Yönetme
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/python-java/manage-hyperlinks/
keywords:
- URL ekle
- Köprü ekle
- Köprü oluştur
- Köprüyü biçimlendir
- Köprüyü kaldır
- Köprüyü güncelle
- Metin köprüsü
- Slayt köprüsü
- Şekil köprüsü
- Görsel köprüsü
- Video köprüsü
- Değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Python aracılığıyla Java'da Aspose.Slides ile PowerPoint ve OpenDocument sunumlarında köprüleri ekleme, biçimlendirme, güncelleme ve kaldırma, Python örnekleri kullanarak."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine veya sunum içinde bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaçla kullanılır:

* Metinden, bir şekilden veya bir medya çerçevesinden bir web sitesini açar.
* Örneğin bir içerik tablosundan başka bir slayta gider.

Aspose.Slides for Python via Java, bu bağlantıları eklemenizi, görünüm ve seslerini kontrol etmenizi, özelliklerini güncellemenizi ve kaldırmanızı sağlar. Aşağıdaki örnekler, bireysel öğelerde köprülerle nasıl çalışılacağını ve sunum, slayt veya metin‑çerçevesi düzeyinde köprülere nasıl erişileceğini gösterir.

{{% alert color="info" title="Not" %}}
Sunumları ayrıca ücretsiz çevrimiçi [Aspose PowerPoint editörü](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.
{{% /alert %}}

## **URL Köprüleri Ekleme**

Metne, bir şekle veya bir medya çerçevesine bir web sitesi URL'si atayabilirsiniz. Köprüyü atadığınız öğe tıklanabilir alanı belirler: bir metin bölümü seçili metni bağlarken, bir şekil veya çerçeve slayt nesnesini bağlar.

Bağıl köprüler içeren sunumlar için, belge‑seviyesi temeli okumak, değiştirmek veya temizlemek amacıyla [Köprü Temelini Yönet](/slides/tr/python-java/presentation-properties/#manage-the-hyperlink-base) bölümüne bakın.

### **Metne URL Köprüleri Ekleme**

Metni bir web sitesine bağlamak için, aşağıda gösterildiği gibi metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) yöntemine bir [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) geçin. Yalnızca bu metin bölümü tıklanabilir hâle gelir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Şekillere ve Medya Çerçevelerine URL Köprüleri Ekleme**

Dikdörtgenin tüm alanını tıklanabilir hâle getirmek için [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) metodunu çağırın. Kullanıcı dikdörtgenin üzerine geldiğinde hedef hakkında bir ipucu göstermek için [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) metodunu kullanın. Her iki yöntem de resim, ses ve video çerçevelerine de uygulanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **İçindekiler Tablosu Oluşturmak için Köprüler Kullanma**

Dahili köprüler, okuyucuların bir içerik tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slaydın “Page 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) metodunu kullanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Köprüleri Biçimlendirme**

Bağlı metnin rengini değiştirebilir, bir okuyucu bir köprüyü etkinleştirdiğinde ses çalabilir veya durdurabilir ve fare üzerine gelindiğinde görünen ipucu metnini ayarlayabilirsiniz.

### **Renk**

[Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) sınıfının [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) yöntemi, bir köprünün sunumun köprü rengini mi yoksa metin bölümünün biçimlendirmesini mi kullandığını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) seçin ve bölümün dolgu rengini ayarlayın. Bu özellik PowerPoint 2019’da tanıtıldı; daha eski sürümler bu ayarı uygulamaz.

Bu örnekte, [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) ilk bağlantının metin bölümünün kırmızı dolgusunu kullanmasını sağlar. İkinci bağlantı ise sunumun köprü rengini korur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ses**

Bir köprü etkinleştirildiğinde bir ses çalabilir veya hâlihazırda çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) köprüyle ilişkili sesi belirtir.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) köprünün etkinleştirilmesiyle önceki sesin durdurulup durdurulmayacağını kontrol eder.

#### **Köprüye Ses Ekleme**

İlk slaydın düğmesi, okuyucu ilerlemek için tıkladığında `sampleaudio.wav` dosyasından ses çalmak için [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) metodunu kullanır. İkinci slayttaki ayrı bir düğme ise çalmayı durdurmak ve okuyucuyu o slaytta tutmak için [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) metodunu kullanır.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Köprü Sesini Çıkarma**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin köprü sesini [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) ve [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) aracılığıyla belleğe okur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **İpucu ve Etkileşim Ayarları**

Metne veya şekle bir köprü atadıktan sonra aşağıdaki [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) yöntemlerini çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) izleyicinin link için bir ipucu olarak gösterebileceği metni ayarlar.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) uygulanabilir olduğunda bir ebeveyn HTML çerçeve kümesindeki hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) linkin etkinleştirilmesinin hedefini görüntülenmiş köprüler listesine ekleyip eklemeyeceğini denetler.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) tıklandığında köprünün vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Köprüleri Kaldırma**

Değiştirmeden önce metin‑bölümü bağlantılarını da içeren köprü konteynerlerini toplamak için [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) metodunu kullanın. Aşağıdaki örnek, ilk slayttan her iki etkinleştirme türünü de kaldırır. Yalnızca bir türü kaldırmak için yalnızca [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) ya da [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) metodunu çağırın; bir tıklama eylemini kaldırmak, fare‑üstü eşdeğerini kaldırmaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Şartsız kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) seçili kapsamda iki etkinleştirme türünü tek bir çağrıyla kaldırır. Seçimli temizlik ve ana düzen, düzenler ve notlar kapsamasını kapsamak için [Köprüleri Raporlama, Temizleme ve Doğrulama](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

### **SmartArt Metnini Değiştirmeden Önce Köprüleri Temizleme**

Mevcut bir SmartArt düğümünde bir paragrafı değiştirirken, metin bölümlerini temizlemek eski bir köprünün etkili kalmasına neden olabilir. Paragrafı [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getTextFrame) üzerinden alın. Bölümleri temizlemeden önce, düğümün şeklinin metin çerçevesinde [getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) metodunu çağırın ve ardından döndürülen nesnede [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) metodunu çalıştırın. Bu, çerçevedeki tüm köprüleri, diğer paragraf bağlantılarını da içerecek şekilde kaldırır.

Örnek, `SmartArtHyperlink.pptx` dosyasının ilk slaydındaki üçüncü şeklin bir SmartArt grafiği olduğunu varsayar. Dördüncü düğümün ilk paragrafını değiştirir. Bu sunumda, düğümün ilk şekli o paragrafı gösterir.

Her iki bölümü ekledikten sonra örnek, [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) ile etkili biçimlendirmeyi okur. Bu biçimlendirmede, `getHyperlinkClick` ilk bölüm için yeni köprüyü, ikinci bölüm için ise `None` döndürür.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Portion, Presentation

presentation = Presentation("SmartArtHyperlink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    smart_art = slide.getShapes().get_Item(2)
    node = smart_art.getAllNodes().get_Item(3)
    paragraph = node.getTextFrame().getParagraphs().get_Item(0)

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks()
    paragraph.getPortions().clear()

    link = Portion("New reference")
    link.getPortionFormat().setHyperlinkClick(Hyperlink("https://example.com/new"))
    paragraph.getPortions().add(link)
    text = Portion(" (updated)")
    paragraph.getPortions().add(text)

    print(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl())  # https://example.com/new
    print(text.getPortionFormat().getEffective().getHyperlinkClick())  # None
finally:
    presentation.dispose()
```

## **Tam Bir Köprü Envanteri Oluşturma**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) yönteminin döndürdüğü nesneler, URL dizesi listesi yerine [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) ve [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) gibi köprü konteynerleridir. Her konteynerde hem [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) hem de [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) metodlarını inceleyin. Bunlar bağımsızdır: aynı konteyner hem tıklama hem fare‑üstü eylemlerini sunabilir, bu yüzden eksiksiz bir rapor her konteyner için iki satır gerektirebilir.

Sadece şekil‑seviyesindeki köprüleri taramak, metin bölümlerine eklenmiş bağlantıları kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve döndürülen konteynerleri saklayarak ileride eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin Çerçevesi Kapsamlarını Sorgulama**

[HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) sınıfına [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) ve [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) üzerinden erişilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) tıklama eylemi olan konteynerleri döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) fare‑üstü eylemi olan konteynerleri döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) her iki eylemden birine veya ikisine sahip konteynerleri döndürür.

Bu örnek, bir şeklin ve metninin tıklama ve fare‑üstü eylemlerini, ayrı bir düğmenin makro eylemini atar. [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) ile dönen konteyner sayısını her eylem türünün sayısıyla karşılaştırır. Metin‑çerçevesi sorgusu yalnızca metindeki bağlantıları sayar. İçeren şeklin kendi eylemleri slayt ve sunum sorgularında görülür.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu örnek için, sunum ve slayt sorguları üç tıklama konteyneri, iki fare‑üstü konteyneri ve her iki eyleme sahip üç konteyner rapor eder. Metin‑çerçevesi sorgusu her kategoride bir konteyner rapor eder.

### **Eylemleri ve Hedefleri Sınıflandırma**

Bir eylemi yorumlamadan önce hedefini yorumlamak için [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) metodunu kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) değerleri web gezinmesinden çok daha fazlasını kapsar:

| Değerler | Denetim için Anlamı |
| --- | --- |
| `Hyperlink` | Harici köprü; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta içsel gezinme. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Yerleşik slayt gösterisi gezinmesi, slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandırır veya özel bir gösteri başlatır. |
| `StartMacro` | Bir makroyu çalıştırır. |
| `StartProgram` | Bir programı başlatır. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunumu açar; web URL'lerinden ayrı olarak incelenmelidir. |
| `StartStopMedia` | Ortam oynatmayı başlatır veya durdurur. |
| `NoAction`, `Unknown` | Gezinme eylemi yok veya incelenmesi gereken tanınmayan bir eylem. |

Harici hedefleri [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) ile, belirli içsel hedefleri ise [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide) ile okuyun. İçsel eylemler ve yerleşik komutlar harici bir URL içermeyebilir; boş bir URL, konteynerin hiç eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) değerini koruyun ve mevcutsa [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) tarafından döndürülen ipucunu ekleyin.

### **Köprüleri Raporlama, Temizleme ve Doğrulama**

Bu örnek, önceki örnekten sunumu açar ve her eylem için bir JSON kaydı yazar. Normal slaytların, ana düzenlerin, düzenlerin ve notların yanı sıra mevcutsa not ve el ilanı ana düzenlerini de kapsayan konteynerleri toplamak için [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) kullanır. Her konteyneri yalnızca bir kez saymak için referans eşitliğini kullanır, aşağıda tanımlanan politikayı uygular ve kaydedilen sunumu yeniden açarak hem tıklama hem fare‑üstü eylemlerini kontrol eder.

Rapor, kullanılabilir olduğunda bir‑baz‑bir slayt indeksini ve [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) değerini içerir. [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) desteklenen konteynerler için sahip slaytı sağlar. Ana düzenler, düzenler ve notlar normal bir slayt indeksine sahip olmaz; kapsamlarıyla tanımlanırlar. Şekil konteynerleri ve metin‑bölüm biçimlendirme konteynerleri ayrı ayrı etiketlenir; diğer konteyner tipleri çalışma zamanı tip adlarını korur. Her konteyner, iki eylemini ilişkilendirebilmek için rapor içinde yerel bir kimlik alır. Rapor, eylem türlerini Java enum'unda tanımlı tam sayı sabitleri olarak saklar.

Bu kısıtlayıcı uygulama politikası, yalnızca mutlak HTTPS URL'lerini ve geçerli iç slayt hedeflerini izin verir. Makrolar, programlar, dosya eylemleri, diğer slayt gösterisi eylemleri, bilinmeyen eylemler ve diğer URL şemaları reddedilir. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenliği kararı değildir. HTTPS tek başına güven oluşturmaz: uygulamanız için host izin listeleri ve ek kontroller ekleyin. Hem orijinal hem de normalleştirilmiş harici URL'ler denetlenir. Örnek, bağlantılara gidip eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, konteynerin [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) yöntemi [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) metodlarını destekler. Burada, yasaklanmış dış tıklama bağlantıları sabit bir HTTPS açılış sayfası ile değiştirilir; diğer yasak tıklama ve fare‑üstü eylemler bağımsız olarak kaldırılır. Tüm politika ihlallerini kaldırmak için `replace_external_clicks` değerini `False` olarak ayarlayın. Dağıtıma geçmeden önce uygulama sahipli bir yedek sayfa seçin.

Raporun dışa aktarım bayrağı, temkinli bir PDF inceleme politikasını kullanır: fare‑üstü eylemler ve harici bir bağlantı ya da belirli slayt atlaması olmayan her şey potansiyel olarak desteklenmez olarak işaretlenir. Bu bir inceleme ipucu olup, bir yetenek testi ya da işaretlenmemiş bağlantıların dışa aktarımda kalacağı garantisi değildir. Desteklenen [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/python-java/convert-powerpoint-to-html/) dışa aktarmaları, eyleme, dışa aktarım seçeneklerine ve izleyiciye bağlı olarak köprüleri koruyabilir. Raster [görüntüler](/slides/tr/python-java/convert-powerpoint-to-png/) ve [videolar](/slides/tr/python-java/convert-powerpoint-to-video/) etkileşimli köprüleri koruyamaz; bu çıktılar için denetleme yaparken tüm eylemler işaretlenmelidir.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

Yukarıda oluşturulan girdi ile rapor beş eylem satırı içerir. Dosya fare‑üstü bağlantısı ve makro tıklaması kaldırılırken, HTTPS bağlantıları ve iç slayt gezinmesi kalır. Doğrulama, sıfır yasaklı eylem yazdırır. Yasak bir dış tıklama URL'si içeren bir girdi, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir fare‑üstü eyleme sahip bir konteyner, tıklama eylemini korur.

Bu seçici temizlik, [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) metodunun aksine, politika göz önünde bulundurulmadan seçili kapsamda hem tıklama hem fare‑üstü eylemleri kaldırır. Buradaki doğrulama yalnızca köprü eylemlerini kontrol eder; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içeriği kaldırmaz ve dışa aktarılmış PDF ya da HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme veya onun ilk slaytına nasıl bağlanabilirim?**  
PowerPoint’te bölümler slaytları gruplar, ancak iç köprüler tek bir slaytı hedefler. Bir bölüme gezinme oluşturmak için o bölümün ilk slaytına bağlanın.

**Ana slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**  
Evet. Ana slayt ve düzen öğeleri köprüleri destekler. Bu öğelere eklenen köprüler, ilgili ana slayt veya düzeni kullanan slayt gösterisi sırasında kullanılabilir.

**PDF, HTML, görüntüler veya video olarak dışa aktarırken köprüler korunur mu?**  
Desteklenen PDF ve HTML dışa aktarmaları köprüleri koruyabilir; raster görüntüler ve videolar ise koruyamaz. Detaylı dışa aktarım değerlendirmesi için [Köprüleri Raporlama, Temizleme ve Doğrulama](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.