---
title: Android'de PowerPoint Sunumlarında Metin Alanlarını Yönetme
linktitle: Metin Alanları
type: docs
weight: 52
url: /tr/androidjava/text-fields/
keywords:
- metin alanı
- otomatik metin
- slayt numarası
- tarih ve saat
- üstbilgi
- altbilgi
- metin bölümü
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint sunumlarında metin alanlarını oluşturun, inceleyin, değiştirin ve kaldırın. Biçimlendirmeyi koruyun ve kaydedilen PPTX ve PPT dosyalarını doğrulayın."
---
## **Genel Bakış**

Bir metin paragrafı bölümlerden oluşur. Normal bir [IPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/) literal metin içerir; bir alan bölümü ayrıca bir [IField](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifield/) içerir ve türü otomatik olarak güncellenen bir değeri, örneğin bir slayt numarasını veya tarihi tanımlar. İki bölüm aynı karakterleri gösterebilir ancak yalnızca biri alan içerir.

Bu bölümleri ayırt etmek için [IPortion.getField](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/#getField--) kullanın: normal metin için `null` döner. [IPortion.addField](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) mevcut bir bölümü alana dönüştürür. Etiketi ve dinamik değerini ayrı bölümlerde tutun, böylece değeri dönüştürmek etiketin de değiştirilmesine neden olmaz.

Bu kılavuz, metin içindeki alanları, bunların biçimlendirmesini ve PPTX ve PPT'de kaydedilmesini kapsar. Metin çerçeveleri ve paragrafları için [Manage Text](/slides/tr/androidjava/manage-text/) sayfasına bakın.

## **Slayt Numarası Alanı Oluşturma**

Aşağıdaki tam örnek, `Slide ` etiketini ve ardından otomatik olarak güncellenen bir numarayı içeren bir metin kutusu oluşturur. Alanı eklemeden önce sayının boyutunu, kalınlığını ve rengini ayarlar, ardından kaydedilen sunumu yeniden açar ve alan türünü, metni ve biçimlendirmeyi kontrol eder. Giriş dosyası gerekmez.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Yeni sunum slayt numarası 1 ile başlar, bu yüzden metin `Slide 1` olur ve iki kontrol de `true` çıktısı verir. Yeniden açıldıktan sonra sayı bir alan olarak kalır; literal `1` değildir. Doğrulamadaki dönüşümler ve indeksler bu örnek tarafından oluşturulan şekil ve bölümlere referans verir.

## **Bir Alan Türü Seçme**

[FieldType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fieldtype/) [IFieldType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifieldtype/) uygular ve önceden tanımlı değerleri elde etmek için aşağıdaki yöntemleri sağlar. Uygun değeri [addField](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) yöntemine aktarın.

| Yöntem | Açıklama |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | Geçerli slayt numarası. |
| [getDateTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | Render uygulamasının varsayılan biçimindeki tarih/saat. |
| [getDateTime1](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | Önceden tanımlı tarih veya birleştirilmiş tarih/saat biçimleri. |
| [getDateTime10](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | Saniye ve 12 saatli saat seçenekleri içeren önceden tanımlı zaman biçimleri. |
| [getHeader](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fieldtype/#getHeader--) | Üstbilgi alanı; aşağıdaki yer tutucu ve biçim sınırlamalarına bakın. |
| [getFooter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fieldtype/#getFooter--) | Altbilgi alanı. |

Örneğin, [getDateTime3](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) bir günü, tam ay adını ve yılı İngilizce olarak temsil eder. Bunlar önceden tanımlı alan biçimleridir, rastgele Java tarih biçimi dizgileri değildir. [setLanguageId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ile ayarlanan dil ve sunumu işleyen uygulama görüntülenen sonucu etkileyebilir.

## **Dahili Dizeden Bir Alan Oluşturma**

[addField](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) metodunun dize aşırı yüklemesi dahili bir alan tanımlayıcısını kabul eder. Önceden tanımlı değeri olmayan başka bir uygulama tarafından sağlanan bir tanımlayıcıyı korurken bunu kullanın. Tanımlayıcıdan bir [FieldType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) da oluşturabilirsiniz. [IFieldType.getInternalString](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) bu tanımlayıcıyı inceleme için ortaya çıkarır.

Bu örnek, `custom-report-id` adlı uygulamaya özgü bir alanı `Report-042` yedek metniyle depolar. Tanımlayıcı bir hesaplama kaydetmez: Aspose.Slides, bilinmeyen bir tür için rapor kimliği üretmez. Bu tanımlayıcıyı anlayan uygulama, anlamını sağlamalı ve değerini güncellemelidir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Bu PPTX dönüşünden sonra, tür `custom-report-id` ve metin `Report-042` olur. `yyyy-MM-dd` gibi bir dize geçirmek bir alan türü adlandırır; özel bir tarih biçimi yapılandırmaz. Rastgele bir biçimde sabit bir tarih için normal metin kullanın.

## **Tarih/Saat Alanlarını İnceleme, Değiştirme ve Kaldırma**

Mevcut bir alanı [IField.setType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) ile değiştirin. Türüne erişmeden önce alanın var olduğunu kontrol edin. Otomatik güncellemeleri durdurmak için [IPortion.removeField](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/#removeField--) çağırın. Bu, alan ilişkilendirmesini kaldırırken bölümü ve mevcut metni korur. Belirli bir sabit değere ihtiyacınız varsa, alanı kaldırdıktan sonra o metni atayın.

Tarih/saat alanı işleme ile ilgili API ayarı için [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-) bakın. Aşağıdaki örnek, bir alanı normal metne dönüştürürken açık bir onay tarihi kullanır.

[ sample.pptx ](sample.pptx) dosyasını indirin ve çalışma dizinine koyun. İçinde `UpdatedAt` ve `ApprovedDate` adlı iki metin şekli vardır; her biri bir tarih/saat alanı ve ayrıca normal metin etiketleri içerir. Aşağıdaki örnek, normal slaytlardaki üst düzey metin şekillerini dolaşır. Tarih/saat alanlarını uzun tarih biçimine çevirir ve italik yapar, diğer biçimlendirmelerini korur. Sadece `ApprovedDate` içindeki alanlar sabit metin olur.

Örnek, yerleşik dahili tanımlayıcıları `datetime` ve `datetime1` ile `datetime13` arasında tanır. Gruplar, tablolar, notlar, düzenler ve masterlar kendi metin konteynerlerinin dolaşımını gerektirir ve bu örnek kapsamı dışındadır.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Yeniden açtıktan sonra, `UpdatedAt` alan türü `datetime3` ve dinamik kalır. `ApprovedDate` alanı yoktur ve `05 April 2030` içerir. Her iki tarih bölümü de italik olup, orijinal yazı tipi boyutu, kalınlık ve renkleri korunur. Normal metin etiketleri değişmez. Doğrulama, sağlanan örnekteki iki bilinen şeklin ilk bölümünü okur.

## **Metin Biçimlendirmesini Koru**

Bir alan eklerken, türünü değiştirirken veya kaldırırken mevcut bölümle çalışın. Bu işlemler bölümün biçimlendirmesini korur. Renk veya italik gibi sadece gerekli özellikleri değiştirmek için [IPortion.getPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/#getPortionFormat--) kullanın.

Tek bir alanı güncellemek için bütün bir metin çerçevesini yeniden inşa etmekten kaçının: bu, orijinal bölüm sınırlarını ve bireysel biçimlendirmeyi kaybettirebilir. Ayrıca, paragraftan, düzenden veya temadan miras alan biçimlendirmeden açıkça ayarlanmış biçimlendirmeyi ayırın. Daha geniş biçimlendirme seçenekleri için [Text Formatting](/slides/tr/androidjava/text-formatting/) bölümüne bakın.

## **Alanlar ve Üstbilgi/Altbilgi Yer Tutucuları**

Bir alan bir metin bölümünün parçasıdır. Yer tutucu, altbilgi veya slayt numarası gibi bir sunum rolü taşıyan bir şekildir. Normal bir metin kutusuna alan eklemek o şekli bir yer tutucuya dönüştürmez.

Üstbilgi/altbilgi yöneticileri, slaytlar, düzenler ve masterlar üzerindeki yer tutucu metni ve görünürlüğünü kontrol eder, bağımlı slaytlara yayılımını da içerir. Özel bir metin kutusundaki bir sayı alanı, slayt numarası yer tutucusunu kullanmasanız bile faydalı olabilir. Aksine, yer tutucu görünürlüğünü değiştirmek, alâksız bir metin kutusundaki alanı kaldırmaz.

Önceden tanımlı üstbilgi ve altbilgi türleri, karşılık gelen yer tutucuları oluşturmaz veya içerik sağlamaz. Özellikle, normal bir PowerPoint slaytının üstbilgi yer tutucusu yoktur; üstbilgiler not sayfalarına ve el ilanlarına aittir. Rastgele bir şekildeki üstbilgi veya altbilgi alanının, yer tutucu yöneticisi aracılığıyla yapılandırılmış metni otomatik olarak alacağını varsaymayın. Bu iş akışı için [Presentation Headers and Footers](/slides/tr/androidjava/presentation-header-and-footer/) sayfasına bakın.

## **PPTX ve PPT Sınırlamaları**

Kaydedip yeniden açtıktan sonra hem alan türünü hem de ortaya çıkan metni kontrol edin. Bir tanımlayıcının korunması, bir uygulamanın değerini hesaplayabileceği veya görüntüleyebileceği anlamına gelmez.

| Biçim | Alan davranışı ve sınırlamaları |
|---|---|
| PPTX | İç alan tanımlayıcılarını alan metniyle birlikte depolar. Dönüşüm kontrollerinde, yukarıda kullanılan önceden tanımlı tipler ve özel tanımlayıcı kaydedilip yeniden açıldıktan sonra da var oldu. Bilinmeyen özel tip yedek metnini korudu; otomatik hesaplama mantığı kazanmadı. Başka bir uygulama desteklenmeyen tanımlayıcıları farklı işleyebilir. |
| PPT | Eski alan temsillerini kullanır ve daha sınırlı uyumluluğa sahiptir. Dönüşüm kontrollerinde, slayt numarası ve önceden tanımlı tarih/saat alanları kaydedilip yeniden açıldıktan sonra da var oldu. Normal bir slayt metin kutusundaki özel bir alan, tanımlayıcıyla açıldı ancak metni `*` oldu; aynı bağlamda bir üstbilgi alanı da `*` üretti. Özel alanların veya desteklenmeyen alan bağlamlarının görünür metinlerini koruyacağına güvenmeyin. |

Taşınabilir, sabit çıktı için, desteklenmeyen alanları normal metne dönüştürün ve kaydetmeden önce istediğiniz değeri açıkça atayın. Bu, seçilen metni korur ancak otomatik güncellemeleri kasıtlı olarak durdurur. Kendi alan yeniden hesaplaması iş akışınızın bir parçasıysa hedef uygulamayı da test edin.

## **SSS**

**Görüntülenen bir sayı ya da tarihin alan olup olmadığını nasıl anlayabilirim?**

[IPortion.getField](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/#getField--) inceleyin. Null olmayan bir değer alanı tanımlar; yalnızca görüntülenen metin bunu söylemez.

**Bir alanı kaldırmak metnini veya biçimini kaldırır mı?**

Hayır. [removeField](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/#removeField--) mevcut bölümü normal metne dönüştürür. Belirli bir dondurulmuş tarih veya yedek değer gerekiyorsa, sonrasında açık bir değer atayın.

**Bir dahili dize yeni bir tarih biçimi ya da formül tanımlayabilir mi?**

Hayır. Bir alan türünü tanımlar. Bilinmeyen bir tanımlayıcı bir değerlendirme mekanizması veya Java tarih biçim dizgesi sağlamaz. Desteklenen önceden tanımlı bir tip kullanın veya değeri normal metin olarak kendiniz biçimlendirin.

**Kaydettikten sonra bir sunumu tekrar kontrol etmek neden gerekir?**

Alan tanımlayıcıları, hesaplanan metin ve biçimlendirme, doğrulanması gereken ayrı öğelerdir. Biçim dönüştürmesi, alan tanımlayıcısı hâlazırda olsa bile görünür sonucu değiştirebilir.