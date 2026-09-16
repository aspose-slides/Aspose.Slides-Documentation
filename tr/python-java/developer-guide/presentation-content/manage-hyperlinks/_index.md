---
title: Python üzerinden Java ile Sunum Köprülerini Yönetme
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
description: "Python üzerinden Java ile Aspose.Slides kullanarak PowerPoint ve OpenDocument sunumlarında köprü ekleme, biçimlendirme, güncelleme ve kaldırma, Python örnekleri ile."
---
## **Giriş**

Bir köprü (hyperlink), sunum içeriğini bir web sitesine veya sunum içindeki bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaçla kullanılır:

* Metin, şekil veya medya çerçevesinden bir web sitesini açar.
* Başka bir slayta gider, örneğin bir içerik tablosundan.

Aspose.Slides for Python via Java, bu bağlantıları eklemenize, görünümlerini ve seslerini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, bireysel öğelerde köprülerle nasıl çalışılacağını ve köprülere sunum, slayt veya metin çerçevesi düzeyinde nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}
Sunumları aynı zamanda [ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/tr/editor) ile düzenleyebilirsiniz.
{{% /alert %}} 

## **URL Köprüleri Ekle**

Bir web sitesi URL'sini metne, şekle veya medya çerçevesine atayabilirsiniz. Köprüyü atadığınız öğe, tıklanabilir alanı belirler: bir metin bölümü seçili metni bağlarken, bir şekil veya çerçeve slayt nesnesini bağlar.

### **Metne URL Köprüleri Ekle**

Metni bir web sitesine bağlamak için, aşağıda gösterildiği gibi metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/#setHyperlinkClick) metoduna bir [Hyperlink](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/) gönderin. Yalnızca bu metin bölümü tıklanabilir olur.

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

### **Şekillere ve Medya Çerçevelerine URL Köprüleri Ekle**

Bir şekil veya çerçeveyi tıklanabilir yapmak için, onun [setHyperlinkClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#setHyperlinkClick) metodunu çağırın. Köprü, içindeki bir metin bölümüne değil, nesnenin kendisine aittir.

Aynı yöntem resim, ses ve video çerçevelerine de uygulanır: köprüyü çerçeveye atayın ve gerekirse [setTooltip](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setTooltip) metodunu çağırın.

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

## **Köprüleri Kullanarak İçindekiler Tablosu Oluşturma**

Dahili köprüler, okuyucuların içerik tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slaydın “Page 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) metodunu kullanır.

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

### **Renk**

[setColorSource](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setColorSource) metodu, [Hyperlink](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/) nesnesinin, köprünün sunumun köprü rengi mi yoksa metin bölümünün biçimlendirmesini mi kullanacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkcolorsource/) seçin ve bölümün dolgu rengini ayarlayın. Bu özellik PowerPoint 2019'da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayda iki metin köprüsü ekler. İlkinde kırmızı metin dolgu kullanılırken, ikincisi varsayılan köprü rengini korur.

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

Bir köprü, etkinleştirildiğinde bir ses çalabilir veya zaten çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [Hyperlink.setSound](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setSound) köprü ile ilişkilendirilen sesi belirtir.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) köprünün etkinleştirilmesinin önceki sesi durdurup durdurmayacağını kontrol eder.

#### **Bir Köprü Sesini Ekle**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve ilk slaydın üzerindeki bir düğmeyle ilişkilendirir. Düğmeye tıklamak sesi çalar ve bir sonraki slayta geçer. Aynı slaydaki ikinci bir şekil tıklandığında önceki sesi durdurur, ancak bir gezinme işlemi yapmaz.

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

#### **Bir Köprü Sesini Çıkarma**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin köprü sesini [getSound](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#getSound) ve [getBinaryData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audio/#getBinaryData) aracılığıyla belleğe okur.

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

### **Araç İpucu ve Etkileşim Ayarları**

Metne veya şekle bir köprü atadıktan sonra aşağıdaki [Hyperlink](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/) metodlarını çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setTooltip) bağlantı için izleyicinin gösterebileceği ipucu metnini ayarlar.
- [setTargetFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setTargetFrame) gerektiğinde, üst HTML çerçeve seti içinde hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setHistory) bağlantının etkinleştirilmesinin hedefini görüntülenen köprüler listesine ekleyip eklemeyeceğini kontrol eder.
- [setHighlightClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setHighlightClick) köprünün tıklandığında vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Köprüleri Kaldırma**

[getAnyHyperlinks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) metodunu, değiştirmeden önce metin bölümü köprüleri dahil tüm köprü kapsayıcılarını toplamak için kullanın. Aşağıdaki örnek ilk slayttan her iki etkinleştirme tipini de kaldırır. Yalnızca bir tipi kaldırmak için sadece [removeHyperlinkClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) veya [removeHyperlinkMouseOver](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) çağırın; bir tıklama eylemini kaldırmak, fare üzerine eylemini kaldırmaz.

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

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) seçilen kapsamda bir çağrıyla her iki etkinleştirme tipini de kaldırır. Seçimli temizlik ve ana slaytlar, düzenler ve notlar kapsamı için [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluşturma**

Sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [getAnyHyperlinks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) köprü kapsayıcılarını, örneğin [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) ve [PortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) nesnelerini döndürür; düz bir URL listesi vermez. Her kapsayıcıda hem [getHyperlinkClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getHyperlinkClick) hem de [getHyperlinkMouseOver](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getHyperlinkMouseOver) metodlarını inceleyin. Bunlar bağımsızdır: aynı kapsayıcı her iki eylemi de sunabilir, bu yüzden tam bir rapor için her kapsayıcıda iki satır gerekebilir.

Yalnızca şekil düzeyindeki köprüleri taramak, metin bölümlerine eklenmiş bağlantıları kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve döndürülen kapsayıcıları saklayın, böylece daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin Çerçevesi Kapsamlarını Sorgulama**

[HyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/) sınıfı, [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getHyperlinkQueries) ve [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#getHyperlinkQueries) aracılığıyla kullanılabilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) tıklama eylemi içeren kapsayıcıları döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) fare üzerine eylemi içeren kapsayıcıları döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) ya birini ya da her ikisini içeren kapsayıcıları döndürür.

Aşağıdaki örnek, dış tıklama bağlantısı, dosya fare üzerine bağlantısı, dahili slayt navigasyonu, metin fare üzerine bağlantısı ve bir makro eylemi içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Bu eylemlerden hiçbiri yürütülmez. Aynı üç sorgu her kapsamda çalışır; sayılar kapsayıcıları, eylem toplamlarını değil, tanımlar. Metin çerçevesi kapsamı, içeren şeklin kendi bağlantılarını içermez.

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

Bu örnek için, sunum ve slayt sorguları her biri üç tıklama kapsayıcısı, iki fare üzerine kapsayıcısı ve bir eylemi olan üç kapsayıcı raporlar. Metin çerçevesi sorgusu her kategoride bir kapsayıcı raporlar.

### **Eylemleri ve Hedefleri Sınıflandırma**

[Hyperlink.getActionType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#getActionType) metodunu kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkactiontype/) değerleri web gezinmesinin ötesinde pek çok durumu kapsar:

| Values | Denetim İçin Anlamı |
| --- | --- |
| `Hyperlink` | Harici köprü; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta iç navigasyon. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Slayt gösterisi içinde dahili gezinme; slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandırır veya özel bir gösteri başlatır. |
| `StartMacro` | Bir makroyu çalıştırır. |
| `StartProgram` | Bir programı başlatır. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunumu açar; web URL'lerinden ayrı olarak incelenmelidir. |
| `StartStopMedia` | Medya çalmasını başlatır veya durdurur. |
| `NoAction`, `Unknown` | Navigasyon eylemi yoktur veya inceleme gerektiren tanınmayan bir eylem. |

[getExternalUrl](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#getExternalUrl) ile dış hedefleri, [getTargetSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#getTargetSlide) ile belirli iç hedefleri okuyun. İç eylemler ve yerleşik komutların dış URL'si olmayabilir; boş bir URL, kapsayıcının eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklı olduğunda [getExternalUrlOriginal](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) tarafından döndürülen değeri koruyun ve mevcut olduğunda [getTooltip](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#getTooltip) tarafından döndürülen araç ipucunu ekleyin.

### **Köprüleri Raporlama, Temizleme ve Doğrulama**

Aşağıdaki Python örneği, mevcut bir sunumu okur (yukarıda oluşturulan dosyayı kullanın), `hyperlink-audit.json` yazar, bir politika uygular, `hyperlink-sanitized.pptx` kaydeder ve her iki etkinleştirme tipini tekrar kontrol etmek için yeniden açar. Kapsayıcıları değiştirmeden önce toplar ve aynı kapsayıcıyı iki kez işlememek için referans eşitliğini kullanır. Sunum sorguları normal slaytları kapsar; paket çapında bir envanter için, ayrıca ana slaytları, düzenleri, notları ve mevcut olduğunda not ve el ilanı ana slaytlarını açıkça sorgular.

Rapor, mevcut olduğunda bir bazlı slayt indeksini ve [getSlideId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getSlideId) kaydeder. [getSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getSlide) desteklenen kapsayıcılar için sahip slaytı sağlar. Ana slaytlar, düzenler ve notlar normal slayt indeksine sahip değildir ve kapsamlarıyla tanımlanır. Şekil kapsayıcıları ve metin bölümü biçimlendirme kapsayıcıları ayrı ayrı etiketlenir; diğer kapsayıcı tipleri çalışma zamanındaki tip adını korur. Her kapsayıcı, iki eylemini ilişkilendirebilmek için rapor içinde yerel bir kimlik alır. Rapor, eylem türlerini Java enum'unda tanımlı tam sayı sabitleri olarak saklar.

Bu kasıtlı olarak kısıtlayıcı uygulama politikası yalnızca mutlak HTTPS URL'lerini ve geçerli iç slayt hedeflerini kabul eder. Makroları, programları, dosya eylemlerini, diğer slayt gösterisi eylemlerini, bilinmeyen eylemleri ve diğer URL şemalarını reddeder. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. Yalnızca HTTPS güven oluşturmaz: uygulamanız için host beyaz listeleri ve diğer kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL'ler kontrol edilir. Örnek, bağlantıları izlemeksizin veya eylemleri çalıştırmaksızın meta verileri denetler.

Düzeltme için, kapsayıcının [getHyperlinkManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getHyperlinkManager) şu metodları destekler: [setExternalHyperlinkClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Burada, yasaklanan dış tıklama bağlantıları sabit bir HTTPS giriş sayfasıyla değiştirilir; diğer yasak tıklamalar ve yasak fare üzerine eylemler bağımsız olarak kaldırılır. Tüm politika ihlallerini kaldırmak için `replace_external_clicks` değerini `False` olarak ayarlayın. Dağıtımdan önce uygulama sahipli bir değiştirme sayfası seçin.

Raporun dışa aktarım bayrağı, temkinli bir PDF inceleme politikası kullanır: fare üzerine eylemleri ve dış bağlantı ya da belirli slayt atlaması dışındaki her şeyi potansiyel olarak desteklenmeyen olarak işaretler. Bu bir inceleme ipucu olup, bir yetenek testi veya işaretlenmemiş bağlantıların dışa aktarımda kalacağına dair bir garanti değildir. Desteklenen [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/python-java/convert-powerpoint-to-html/) dışa aktarımları, eyleme, dışa aktarım seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir. Raster [images](/slides/tr/python-java/convert-powerpoint-to-png/) ve [video](/slides/tr/python-java/convert-powerpoint-to-video/) interaktif köprüleri koruyamaz; bu çıktıların denetimi sırasında her eylemi işaretleyin.

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

Yukarıda oluşturulan girdi ile, rapor beş eylem satırı içerir. Dosya fare üzerine bağlantısı ve makro tıklaması kaldırılırken, HTTPS bağlantıları ve iç slayt navigasyonu kalır. Doğrulama, sıfır yasak eylem çıktılar. Yasak bir dış tıklama URL'si içeren bir girdi, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir fare üzerine eylemi olan bir kapsayıcı tıklama eylemini korur.

Bu seçici temizlik, politika ne olursa olsun seçilen kapsamda her iki etkinleştirme tipini de kaldıran [removeAllHyperlinks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) metodundan farklıdır. Buradaki doğrulama yalnızca köprü eylemlerini kontrol eder; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içeriği kaldırmaz ve dışa aktarılan PDF veya HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme ya da o bölümün ilk slaytına nasıl bağlanabilirim?**

PowerPoint'teki bölümler slaytları gruplayarak düzenler, ancak dahili bir köprü yalnızca tek bir slaytı hedefler. Bir bölüme gezinme oluşturmak için, o bölümün ilk slaytına bağlanın.

**Ana slayt (master slide) öğelerine köprü ekleyebilir ve tüm slaytlarda çalışmasını sağlayabilir miyim?**

Evet. Ana slayt ve düzen (layout) öğeleri köprüleri destekler. Bu öğelerdeki köprüler, ilgili ana slayt veya düzeni kullanan slayt gösterileri sırasında kullanılabilir.

**Köprüler PDF, HTML, görüntüler veya video olarak dışa aktarılırken korunur mu?**

Desteklenen PDF ve HTML dışa aktarımları köprüleri koruyabilir; raster görüntüler ve video koruyamaz. Dışa aktarım hususları için [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.