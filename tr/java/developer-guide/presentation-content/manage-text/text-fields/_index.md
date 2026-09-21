---
title: PowerPoint Sunumlarında Metin Alanlarını Java ile Yönetme
linktitle: Metin Alanları
type: docs
weight: 52
url: /tr/java/text-fields/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarında metin alanlarını oluşturun, inceleyin, değiştirin ve kaldırın. Biçimlendirmeyi koruyun ve kaydedilen PPTX ve PPT dosyalarını doğrulayın."
---
## **Genel Bakış**

Metin paragrafı bölümlerden oluşur. Normal bir [IPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/) gerçek metin içerir; bir alan bölümü ayrıca bir [IField](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifield/) içerir ve türü, slayt numarası veya tarih gibi otomatik olarak güncellenen bir değeri tanımlar. İki bölüm aynı karakterleri gösterebilir ancak sadece biri alan içerir.

Bu bölümleri ayırt etmek için [IPortion.getField](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/#getField--) kullanın: normal metin için `null` döner. [IPortion.addField](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) mevcut bir bölümü alana dönüştürür. Etiketi ve dinamik değerini ayrı bölümlerde tutun, böylece değeri dönüştürmek etiketin de değiştirilmesine yol açmaz.

Bu kılavuz, metin içindeki alanları, bunların biçimlendirilmesini ve PPTX ve PPT olarak kaydedilmesini kapsar. Metin çerçeveleri ve paragraflar için, bkz. [Manage Text](/slides/tr/java/manage-text/).

## **Slayt Numarası Alanı Oluştur**

Aşağıdaki tam örnek, `Slide ` etiketini literal olarak içeren ve ardından otomatik olarak güncellenen bir sayı ekleyen bir metin kutusu oluşturur. Alanı eklemeden önce sayının boyutunu, kalınlığını ve rengini ayarlar, ardından kaydedilen sunumu yeniden açar ve alan türünü, metni ve biçimlendirmeyi kontrol eder. Girdi dosyası gerekmez.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

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

Yeni sunum, slayt numarası 1 ile başlar, bu yüzden metin `Slide 1` olur ve her iki kontrol de `true` yazar. Sayı yeniden açıldıktan sonra da bir alan olarak kalır; literal `1` değildir. Doğrulamadaki tip dönüştürmeler ve indeksler, bu örnek tarafından oluşturulan şekil ve bölümlere işaret eder.

## **Bir Alan Türü Seçin**

[FieldType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fieldtype/) [IFieldType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifieldtype/) uygular ve önceden tanımlı değerleri elde etmek için aşağıdaki yöntemleri sunar. Uygun değeri [addField](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) metoduna aktarın.

| Yöntem | Amaç |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Mevcut slayt numarası. |
| [getDateTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fieldtype/#getDateTime--) | Görselleştirme uygulamasının varsayılan biçimindeki tarih/saat. |
| [getDateTime1](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fieldtype/#getDateTime9--) | Önceden tanımlı tarih ya da birleşik tarih/saat biçimleri. |
| [getDateTime10](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fieldtype/#getDateTime13--) | Saniye ve 12 saatli saat seçenekleri içeren önceden tanımlı zaman biçimleri. |
| [getHeader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fieldtype/#getHeader--) | Başlık alanı; aşağıdaki yer tutucu ve biçim sınırlamalarına bakın. |
| [getFooter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fieldtype/#getFooter--) | Altbilgi alanı. |

Örneğin, [getDateTime3](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fieldtype/#getDateTime3--) bir günü, tam ay adını ve yılı İngilizce olarak temsil eder. Bunlar önceden tanımlı alan biçimleridir, rastgele Java tarih‑biçimi dizgileri değildir. [setLanguageId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ile ayarlanan dil ve sunumu işleyen uygulama, görünen sonucu etkileyebilir.

## **Dahili Dizeden Alan Oluşturma**

[addField](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/#addField-java.lang.String-) metodunun dize aşırı yüklemesi, dahili bir alan tanımlayıcısını kabul eder. Önceden tanımlı bir değeri olmayan, başka bir uygulama tarafından sağlanan tanımlayıcıyı korurken bunu kullanın. Ayrıca tanımlayıcıdan bir [FieldType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) oluşturabilirsiniz. [IFieldType.getInternalString](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifieldtype/#getInternalString--) bu tanımlayıcıyı inceleme için ortaya çıkarır.

Bu örnek, `custom-report-id` adlı uygulamaya özgü bir alanı yedek metin `Report-042` ile saklar. Tanımlayıcı bir hesaplama kaydetmez: Aspose.Slides bilinmeyen tür için rapor kimliği üretmez. Bu tanımlayıcıyı anlayan uygulama, anlamını sağlamalı ve değerini güncellemelidir.

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

Bu PPTX dönüşümünden sonra, tür `custom-report-id` ve metin `Report-042` olur. `yyyy-MM-dd` gibi bir dize geçmek bir alan türü adlandırır; özel bir tarih biçimi ayarlamaz. İstediğiniz formatta sabit bir tarih için normal metin kullanın.

## **Tarih/Saat Alanlarını İnceleme, Değiştirme ve Kaldırma**

Mevcut bir alanı [IField.setType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) ile değiştirin. Türüne erişmeden önce alanın varlığını kontrol edin. Otomatik güncellemeleri durdurmak için [IPortion.removeField](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/#removeField--) çağırın. Bu, alan ilişkilendirmesini kaldırırken bölümü ve mevcut metni korur. Belirli sabit bir değere ihtiyacınız varsa, alanı kaldırdıktan sonra metni atayın.

Tarih/saat alanı işleme ile ilgili API ayarı için, bkz. [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Aşağıdaki örnek, bir alanı normal metne dönüştürürken açık bir onay tarihi kullanır.

[sample.pptx](sample.pptx) dosyasını indirin ve çalışma dizinine koyun. Dosyada `UpdatedAt` ve `ApprovedDate` adlı iki metin şekli bulunur; her biri bir tarih/saat alanına ve ayrıca normal metin etiketlerine sahiptir. Aşağıdaki örnek, normal slaytlardaki üst düzey metin şekillerinde dolaşır. Tarih/saat alanlarını uzun tarih biçimine dönüştürür ve italik yapar, diğer biçimlendirmelerini korur. Yalnızca `ApprovedDate` içindeki alanlar sabit metin olur.

Örnek, yerleşik dahili tanımlayıcıları `datetime` ve `datetime1` ile `datetime13` arasında tanır. Gruplar, tablolar, notlar, düzenler ve ana sayfalar kendi metin kapsayıcılarının gezilmesini gerektirir ve bu örnek kapsamında değildir.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

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
                        String fixedDate = approvalDate.format(dateFormat);
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

Yeniden açtıktan sonra, `UpdatedAt` türü `datetime3` ve dinamik kalır. `ApprovedDate` alan içermez ve `05 April 2030` içerir. Her iki tarih bölümü de italik, özgün yazı tipi boyutu, kalın ayarı ve rengi korunur. Normal metin etiketleri değişmemiştir. Doğrulama, sağlanan örnekteki iki bilinen şeklin ilk bölümünü okur.

## **Metin Biçimlendirmesini Koru**

Bir alan eklerken, türünü değiştirirken veya kaldırırken mevcut bölümle çalışın. Bu işlemler bölümün biçimlendirmesini korur. Renk ya da italik gibi yalnızca gerekli özellikleri değiştirmek için [IPortion.getPortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/#getPortionFormat--) kullanın; örneklerde olduğu gibi.

Tek bir alanı güncellemek için bütün bir metin çerçevesini yeniden oluşturmakdan kaçının: bu, özgün bölüm sınırlarını ve bireysel biçimlendirmeyi kaybetmenize neden olabilir. Ayrıca açıkça ayarlanmış biçimlendirmeyi paragraftan, düzenden veya temadan miras alınan biçimlendirmeden ayırın. Daha geniş biçimlendirme seçenekleri için [Text Formatting](/slides/tr/java/text-formatting/) bölümüne bakın.

## **Alanlar ve Üstbilgi/Altbilgi Yer Tutucuları**

Bir alan, bir metin bölümünün parçasıdır. Yer tutucu, altbilgi ya da slayt numarası gibi bir sunum rolü olan bir şekildir. Normal bir metin kutusuna alan eklemek, şekli yer tutucuya dönüştürmez.

Üstbilgi/altbilgi yöneticileri, slaytlarda, düzenlerde ve ana slaytlarda yer tutucu metni ve görünürlüğü kontrol eder, bağımlı slaytlara da yayar. Özel bir metin kutusundaki numara alanı, slayt numarası yer tutucusunu kullanmasanız bile faydalı olabilir. Aksine, yer tutucu görünürlüğünü değiştirmek, alakasız bir metin kutusundaki alanı kaldırmaz.

Önceden tanımlı üstbilgi ve altbilgi türleri, ilgili yer tutucuları oluşturmaz veya içeriklerini sağlamaz. Özellikle, normal bir PowerPoint slaytının üstbilgi yer tutucusu yoktur; üstbilgiler not sayfalarına ve el kitaplarına aittir. Rastgele bir şekildeki üstbilgi ya da altbilgi alanının, yer tutucu yöneticisi tarafından ayarlanan metni otomatik olarak alacağını varsaymayın. Bu iş akışı için bkz. [Presentation Headers and Footers](/slides/tr/java/presentation-header-and-footer/).

## **PPTX ve PPT Kısıtlamaları**

Kaydedip yeniden açtıktan sonra hem alan türünü hem de ortaya çıkan metni kontrol edin. Bir tanımlayıcının korunması, bir uygulamanın değerini hesaplayabileceğini veya gösterebileceğini kanıtlamaz.

| Biçim | Alan davranışı ve sınırlamaları |
|---|---|
| PPTX | İç alan tanımlayıcıları, alan metniyle birlikte saklanır. Çift yönlü kontrollerde, önceden tanımlı türler ve yukarıda kullanılan özel tanımlayıcı kaydedilip yeniden açıldıktan sonra da varlığını korur. Bilinmeyen özel tür, yedek metnini korur; otomatik hesaplama mantığı kazanmaz. Başka bir uygulama, desteklenmeyen tanımlayıcıları farklı ele alabilir. |
| PPT | Eski alan temsillerini kullanır ve daha sınırlı uyumluluğa sahiptir. Çift yönlü kontrollerde, slayt numarası ve önceden tanımlı tarih/saat alanları kaydedilip yeniden açıldıktan sonra da varlığını korur. Normal bir slayt metin kutusundaki özel alan, tanımlayıcısı ile yeniden açılır ancak metni `*` olur; aynı bağlamda bir üstbilgi alanı da `*` üretir. Özel alanların veya desteklenmeyen alan bağlamlarının görünen metni koruyacağına güvenmeyin. |

Taşınabilir, sabit çıktı için, desteklenmeyen alanları normal metne dönüştürün ve kaydetmeden önce istediğiniz değeri açıkça atayın. Bu, seçilen metni korur ancak otomatik güncellemeleri kasıtlı olarak durdurur. İş akışınızın bir parçası olarak hedef uygulamanın kendi alan yeniden hesaplamasını da test edin.

## **SSS**

**Görüntülenen bir sayı ya da tarihin alan olup olmadığını nasıl anlayabilirim?**

[IPortion.getField](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/#getField--) inceleyin. `null` olmayan bir değer bir alanı tanımlar; sadece görüntülenen metin bunu söylemez.

**Bir alanı kaldırmak, metni ya da biçimlendirmeyi kaldırır mı?**

Hayır. [removeField](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/#removeField--) mevcut bölümü normal metne dönüştürür. Belirli bir dondurulmuş tarih ya da yedek değer gerekiyorsa, ardından açık bir değer atayın.

**Bir dahili dize yeni bir tarih biçimi ya da formül tanımlayabilir mi?**

Hayır. Bu bir alan türünü tanımlar. Bilinmeyen bir tanımlayıcı bir değerlendirmeci ya da Java tarih‑biçimi deseni sağlamaz. Desteklenen önceden tanımlı bir tür kullanın veya değeri kendiniz normal metin olarak biçimlendirin.

**Kaydettikten sonra bir sunumu tekrar kontrol etmek neden önemlidir?**

Alan tanımlayıcıları, hesaplanan metin ve biçimlendirme, doğrulanması gereken ayrı şeylerdir. Biçim dönüşümü, alan tanımlayıcısı hâlâ mevcut olsa bile görünen sonucu değiştirebilir.