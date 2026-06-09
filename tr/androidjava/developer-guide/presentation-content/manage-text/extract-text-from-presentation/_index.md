---
title: Android'de Sunumlardan Gelişmiş Metin Çıkarma
linktitle: Metin Çıkar
type: docs
weight: 90
url: /tr/androidjava/extract-text-from-presentation/
keywords:
- metin çıkarma
- slayttan metin çıkarma
- sunumdan metin çıkarma
- PowerPoint'tan metin çıkarma
- OpenDocument'tan metin çıkarma
- PPT'den metin çıkarma
- PPTX'ten metin çıkarma
- ODP'den metin çıkarma
- metin alma
- slayttan metin alma
- sunumdan metin alma
- PowerPoint'tan metin alma
- OpenDocument'tan metin alma
- PPT'den metin alma
- PPTX'ten metin alma
- ODP'den metin alma
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument sunumlardan hızlı bir şekilde metin çıkarın. Zaman kazanmak için basit, adım adım rehberimizi izleyin."
---
## **Genel Bakış**

Sunumlardan metin çıkarmak, slayt içeriğiyle çalışan geliştiriciler için yaygın ancak önemli bir görevdir. Microsoft PowerPoint dosyaları PPT veya PPTX formatında olsun ya da OpenDocument sunumları (ODP) olsun, metinsel verilere erişmek ve bunları almak analiz, otomasyon, indeksleme veya içerik taşıma amaçları için kritik olabilir.

Bu makale, PPT, PPTX ve ODP dahil çeşitli sunum formatlarından metni verimli bir şekilde çıkarmak için Aspose.Slides for Android via Java kullanarak kapsamlı bir rehber sunar. Sunum öğeleri üzerinde sistematik olarak döngü oluşturmayı ve ihtiyacınız olan metin içeriğini doğru bir şekilde almayı öğreneceksiniz.

## **Slayttan Metin Çıkarma**

Aspose.Slides for Android via Java, [SlideUtil](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/) sınıfını sağlar. Bu sınıf, bir sunum veya slayttan tüm metni çıkarmak için birkaç aşırı yüklü statik yöntem sunar. Bir sunumdaki slayttan metin çıkarmak için, [getAllTextBoxes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) yöntemini kullanın. Bu yöntem, parametre olarak [IBaseSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/) türünde bir nesne alır. Çalıştırıldığında, yöntem tüm slaytı metin için tarar ve metin biçimlendirmesini koruyan [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) türünde nesneler dizisini döndürür.

Aşağıdaki kod parçacığı, sunumun ilk slaytındaki tüm metni çıkartır:
```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Sunumdan Metin Çıkarma**

Tam bir sunumdan metni taramak için, [SlideUtil](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/) sınıfı tarafından sunulan [getAllTextFrames](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) statik yöntemini kullanın. Bu yöntem iki parametre alır:

1. İlk olarak, metnin çıkarılacağı PowerPoint veya OpenDocument sunumunu temsil eden bir [IPresentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/) nesnesi.
2. İkinci olarak, sunumdan metin taranırken ana slaytların (master slides) dahil edilip edilmeyeceğini belirten bir `boolean` değer.

Yöntem, metin biçimlendirme bilgilerini içeren [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) türünde nesneler dizisini döndürür. Aşağıdaki kod, ana slaytlar dahil olmak üzere bir sunumdan metin ve biçimlendirme detaylarını tarar.
```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kategorize ve Hızlı Metin Çıkarma**

[PresentationFactory](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationfactory/) sınıfı da sunumlardan tüm metni çıkarmak için yöntemler sağlar:
```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textextractionarrangingmode/) enum argümanı, metin çıkarma sonucunun düzenlenme modunu gösterir ve aşağıdaki değerlerden birine ayarlanabilir:
- `Unarranged` - Slayt üzerindeki konumuna bakılmadan ham metin.
- `Arranged` - Metin, slayttaki aynı sırada düzenlenir.

Hızın kritik olduğu durumlarda düzenlenmemiş (unarranged) mod kullanılabilir; bu mod, düzenli (arranged) moddan daha hızlıdır.

[IPresentationText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationtext/) sunumdan çıkarılan ham metni temsil eder. `getSlidesText` yöntemi, [ISlideText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidetext/) türünde nesneler dizisini döndürür. Her nesne ilgili slayttaki metni temsil eder. [ISlideText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidetext/) türündeki nesnenin aşağıdaki yöntemleri vardır:

- `getText` - Slayt şekilleri içindeki metin.
- `getMasterText` - Bu slaytla ilişkili ana slaytın şekilleri içindeki metin.
- `getLayoutText` - Bu slaytla ilişkili düzen slaytının şekilleri içindeki metin.
- `getNotesText` - Bu slaytla ilişkili not slaytının şekilleri içindeki metin.
- `getCommentsText` - Bu slaytla ilişkili yorumlardaki metin.

```java
String presentationPath = "presentation.pptx";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **SSS**

**Aspose.Slides büyük sunumları metin çıkarma sırasında ne kadar hızlı işler?**

Aspose.Slides yüksek performans için optimize edilmiştir ve [büyük sunumları](/slides/tr/androidjava/open-presentation/) bile işleyebilir, bu da gerçek zamanlı veya toplu işlem senaryoları için uygundur.

**Aspose.Slides sunumlardaki tablolar ve grafiklerden metin çıkarabilir mi?**

Evet. Aspose.Slides, tablolar ve grafikle ilgili nesneler dahil olmak üzere birçok slayt öğesinden metin çıkarabilir; böylece yaygın sunum yapılarındaki metin içeriğine erişebilir ve analiz edebilirsiniz.

**Sunumlardan metin çıkarmak için özel bir Aspose.Slides lisansına ihtiyacım var mı?**

Metni, Aspose.Slides'ın ücretsiz deneme sürümünü kullanarak çıkarabilirsiniz, ancak bu sürüm [belirli kısıtlamalara](/slides/tr/androidjava/licensing/) sahiptir; örneğin yalnızca sınırlı sayıda slaytı işleyebilir. Sınırsız kullanım ve daha büyük sunumları yönetmek için tam bir lisans satın almanız önerilir.