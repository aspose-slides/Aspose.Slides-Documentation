---
title: Python üzerinden Java ile Sunum Köprülerini Yönet
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/python-java/manage-hyperlinks/
keywords:
- URL ekle
- köprü ekle
- köprü oluştur
- köprü biçimlendir
- köprü kaldır
- köprü güncelle
- metin köprüsü
- slayt köprüsü
- şekil köprüsü
- resim köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile Aspose.Slides kullanarak PowerPoint ve OpenDocument sunumlarındaki köprüleri ekleyin, biçimlendirin, güncelleyin ve kaldırın, Python örnekleriyle."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine ya da sunum içindeki bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaçla kullanılır:

* Metinden, bir şekilden veya medya çerçevesinden bir web sitesini açar.
* Örneğin bir içindekiler tablosundan başka bir slayta gider.

Aspose.Slides for Python via Java, bu bağlantıları eklemenize, görünüm ve seslerini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, tek tek öğelerde köprülerle nasıl çalışılacağını ve sunum, slayt ya da metin çerçevesi düzeyinde köprülere nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}
Ayrıca sunumları [Ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.
{{% /alert %}} 

## **URL Köprüleri Ekle**

Metne, bir şekle veya bir medya çerçevesine bir web sitesi URL'si atayabilirsiniz. Köprüyü atadığınız öğe, tıklanabilir alanı belirler: bir metin bölümü seçilen metni bağlarken, bir şekil veya çerçeve slayt nesnesini bağlar.

Göreceli köprüler içeren sunumlar için, belge düzeyindeki temeli okumak, değiştirmek veya temizlemek amacıyla [Köprü Temelini Yönet](/slides/tr/python-java/presentation-properties/#manage-the-hyperlink-base) bölümüne bakın.

### **Metne URL Köprüsü Ekle**

Metni bir web sitesine bağlamak için, metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) metoduna bir [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) nesnesi gönderin; yalnızca o metin bölümü tıklanabilir hâle gelir.

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

### **Şekillere ve Medya Çerçevelerine URL Köprüsü Ekle**

Bir şekli veya çerçeveyi tıklanabilir hâle getirmek için, onun [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) metodunu çağırın. Köprü nesneye kendisine aittir, içindeki metin bölümüne değil.

Aynı yaklaşım resim, ses ve video çerçeveleri için de geçerlidir: köprüyü çerçeveye atayın ve gerekirse [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) metodunu çağırın.

Aşağıdaki örnek bir dikdörtgeni tıklanabilir hâle getirir:

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

## **İçindekiler Tablosu Oluşturmak İçin Köprüleri Kullan**

Dahili köprüler, okuyucuların içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slaydın “Page 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) metodunu kullanır.

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

## **Köprüleri Biçimlendir**

### **Renk**

[Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) sınıfının [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) yöntemi, bir köprünün sunumun köprü rengi mi yoksa metin bölümünün biçimlendirmesi mi kullanacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) seçilir ve bölümün dolgu rengi ayarlanır. Bu özellik PowerPoint 2019’da tanıtıldı; eski sürümlerde bu ayar uygulanmaz.

Aşağıdaki örnek aynı slayta iki metin köprüsü ekler. İlki kırmızı metin dolgusu kullanırken, ikincisi varsayılan köprü rengini korur.

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

Bir köprü etkinleştirildiğinde bir ses çalabilir ya da hâlihazırda çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) köprüyle ilişkili ses dosyasını belirtir.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) köprünün tıklanmasıyla önceki sesin durdurulup durdurulmayacağını kontrol eder.

#### **Köprü Sesi Ekle**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve ilk slayttaki bir düğmeye ilişkilendirir. Düğmeye tıklandığında ses çalar ve sonraki slayta geçiş yapılır. Aynı slayttaki ikinci bir şekil, tıklandığında önceki sesi durdurur; ancak bir gezinme eylemi gerçekleştirmez.

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

#### **Köprü Sesini Çıkar**

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

Bir köprüyü metne ya da şekle atadıktan sonra aşağıdaki [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) yöntemlerini çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) izleyicinin bağlantı için ipucu olarak görüntüleyebileceği metni belirler.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) uygulanabilir olduğunda, bir ana HTML çerçeve kümesindeki hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) bağlantının etkinleştirilmesinin hedefini görüntülenen köprüler listesine ekleyip eklemeyeceğini kontrol eder.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) tıklanırken köprünün vurgulanıp vurgulanmayacağını belirler.

## **Sunumlardan Köprüleri Kaldır**

[Köprüleri toplamak] için [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) metodunu kullanın; böylece değiştirmeden önce metin‑bölümü bağlantıları da dahil tüm köprü kapsayıcılarını alabilirsiniz. Aşağıdaki örnek, ilk slayttan her iki etkinleştirme türünü de kaldırır. Sadece bir türü kaldırmak isterseniz, yalnızca [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) ya da [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) metodunu çağırın; bir tıklama eylemini kaldırmak, fare‑üstü eylemini kaldırmaz.

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

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) seçili kapsamda her iki etkinleştirme türünü tek bir çağrıyla kaldırır. Öğretmenler, düzenler ve notlar dahil olmak üzere kapsamlı bir temizlik ve kapsama için [Köprüleri Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluştur**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerinin ve web bağlantılarının envanterini çıkarın. [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) metoduyla, [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) ve [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) gibi köprü kapsayıcıları alınır; düz bir URL listesi döndürülmez. Her kapsayıcıda hem [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) hem de [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) metodlarını inceleyin. Bu iki eylem bağımsızdır: aynı kapsayıcı her iki eylemi de sergileyebilir, bu yüzden tam bir rapor için kapsayıcı başına iki satır gerekebilir.

Yalnızca şekil‑seviyesi köprüleri taramak, metin bölümlerine eklenmiş köprüleri kaçırabilir. Uygun kapsamı sorgulayın ve dönen kapsayıcıları tutun; böylece daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin‑Çerçeve Kapsamlarını Sorgula**

[HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) sınıfına, [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) ve [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) üzerinden erişilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) tıklama eylemi olan kapsayıcıları döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) fare‑üstü eylemi olan kapsayıcıları döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) bir veya her iki eylemi de içeren kapsayıcıları döndürür.

Aşağıdaki örnek, dış tıklama bağlantısı, dosya fare‑üstü bağlantısı, dahili slayt yönlendirmesi, metin fare‑üstü bağlantısı ve bir makro eylemi içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Bu eylemlerden hiçbiri yürütülmez. Aynı üç sorgu her kapsamda çalışır; sayılar kapsayıcıları ifade eder, eylem toplamını değil. Metin‑çerçeve kapsamı, içinde bulunduğu şeklin kendi bağlantılarını içermez.

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

Bu örnek için, sunum ve slayt sorguları her biri üç tıklama kapsayıcısı, iki fare‑üstü kapsayıcısı ve üç toplam kapsayıcı rapor eder. Metin‑çerçeve sorgusu her kategori için bir kapsayıcı raporlar.

### **Eylemleri ve Hedefleri Sınıflandır**

Bir eylemi yorumlamadan önce, hedefini yorumlamak için [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) metodunu kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) değerleri web gezinmesinden çok daha fazlasını kapsar:

| Değerler | Denetim Anlamı |
| --- | --- |
| `Hyperlink` | Dış köprü; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta dahili yönlendirme. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Slayt gösterisi içinde yerleşik gezinme, slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandır veya özel bir gösteri başlat. |
| `StartMacro` | Bir makro çalıştır. |
| `StartProgram` | Bir program başlat. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunum aç; web URL’lerinden ayrı inceleyin. |
| `StartStopMedia` | Medya oynatımını başlat veya durdur. |
| `NoAction`, `Unknown` | Navigasyon eylemi yok veya tanınmayan eylem; incelenmeli. |

Dış hedefleri [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) ile, belirli dahili hedefleri ise [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide) ile okuyun. Dahili eylemler ve yerleşik komutlar dış URL içermeyebilir; boş bir URL, kapsayıcının eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL’den farklıysa, [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) tarafından döndürülen değeri koruyun ve mevcutsa [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) tarafından döndürülen ipucunu ekleyin.

### **Köprüleri Raporla, Temizle ve Doğrula**

Aşağıdaki Python örneği mevcut bir sunumu okur (yukarıda oluşturulan dosyayı kullanın), `hyperlink-audit.json` dosyasına yazar, bir politika uygular, `hyperlink-sanitized.pptx` dosyasını kaydeder ve tekrar açarak hem tıklama hem de fare‑üstü eylemlerini yeniden kontrol eder. Değiştirmeden önce kapsayıcıları toplar ve aynı kapsayıcıyı iki kez işlememek için referans eşitliğini kullanır. Sunum sorguları normal slaytları kapsar; paket‑geneli envanter için aynı zamanda öğretmenler, düzenler, notlar ve var ise not ve el ilanı öğretmenleri de açıkça sorgulanır.

Rapor, bir‑tabanlı slayt indeksini ve mevcut olduğunda [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) değerini kaydeder. [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) desteklenen kapsayıcılar için sahip slaytı sağlar. Öğretmenler, düzenler ve notların normal bir slayt indeksi yoktur; kapsamlarıyla tanımlanırlar. Şekil kapsayıcıları ve metin‑bölümü biçimlendirme kapsayıcıları ayrı ayrı etiketlenir; diğer kapsayıcı türleri çalışma zamanı tip adlarını korur. Her kapsayıcı, iki eylemi ilişkilendirebilmek için rapor‑yerel bir kimlik alır. Rapor, eylem türlerini Java sayımının tanımladığı tamsayı sabitleri olarak saklar.

Bu kasıtlı olarak kısıtlayıcı uygulama politikası yalnızca mutlak HTTPS URL’lerini ve geçerli dahili slayt hedeflerini kabul eder. Makrolar, programlar, dosya eylemleri, diğer slayt gösterisi eylemleri, bilinmeyen eylemler ve diğer URL şemaları reddedilir. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS yalnızca güven oluşturmaz: uygulamanız için host izin listeleri ve ek kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL’ler kontrol edilir. Örnek, bağlantıları takip etmeden ya da eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, kapsayıcının [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) nesnesi [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) metodlarını destekler. Burada, yasak dış tıklama bağlantıları sabit bir HTTPS açılış sayfasıyla değiştirilir; diğer yasak tıklama ve fare‑üstü eylemleri bağımsız olarak kaldırılır. `replace_external_clicks` değerini `False` yaparak tüm politika ihlallerini kaldırabilirsiniz. Dağıtıma başlamadan önce uygulama‑sahibi bir yedekleme sayfası seçin.

Raporun dışa aktarım bayrağı, ihtiyatlı bir PDF inceleme politikası kullanır: fare‑üstü eylemler ve dış bağlantı olmayan ya da belirli slayt atlaması olmayan her şey potansiyel olarak desteklenmeyen olarak işaretlenir. Bu bir inceleme ipucu olup, desteklenmeyen bağlantıların dışa aktarımda hayatta kalacağını garanti etmez. Desteklenen [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/python-java/convert-powerpoint-to-html/) dışa aktarımlar, eyleme, dışa aktarım seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir. Raster [görseller](/slides/tr/python-java/convert-powerpoint-to-png/) ve [videolar](/slides/tr/python-java/convert-powerpoint-to-video/) etkileşimli köprüleri koruyamaz; bu çıktılar için denetleme yaparken her eylemi işaretleyin.

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

Yukarıda oluşturulan giriş ile rapor beş eylem satırı içerir. Dosya fare‑üstü bağlantısı ve makro tıklaması kaldırılırken, HTTPS bağlantıları ve dahili slayt gezinmesi korunur. Doğrulama, sıfır yasaklı eylem çıktılar. Yasak bir dış tıklama URL’si içeren bir giriş, değiştirme dalını da gösterir. İzin verilen bir tıklama ve yasak bir fare‑üstü eylemi olan bir kapsayıcı, tıklama eylemini tutar.

Bu seçici temizlik, [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) metodundan farklıdır; bu metod, politika gözetmeksizin seçili kapsam içinde her iki etkinleştirme türünü de kaldırır. Buradaki doğrulama yalnızca köprü eylemlerini kontrol eder; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içeriği kaldırmaz ve dışa aktarılmış PDF ya da HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme ya da onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint’te bölümler slaytları gruplar, ancak dahili bir köprü yalnızca tek bir slayta yönelir. Bir bölüme yönlendirme oluşturmak için, o bölümün ilk slaytına bağlanın.

**Köprüleri tüm slaytlarda çalışması için ana slayt öğelerine ekleyebilir miyim?**

Evet. Ana slayt ve düzen öğeleri köprüleri destekler. Bu öğeler üzerindeki bağlantılar, ilgili ana slaytı ya da düzeni kullanan slayt gösterisi sırasında kullanılabilir.

**Köprüler PDF, HTML, görseller veya video olarak dışa aktarılırken korunur mu?**

Desteklenen PDF ve HTML dışa aktarımlar köprüleri koruyabilir; raster görseller ve video koruyamaz. Detaylı dışa aktarım hususlarına [Köprüleri Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks) bölümünden bakın.