---
title: Java'da Sunumlardan Gelişmiş Metin Çıkarma
linktitle: Metni Çıkar
type: docs
weight: 90
url: /tr/java/extract-text-from-presentation/
keywords:
- metin çıkarma
- slayttan metin çıkarma
- sunumdan metin çıkarma
- PowerPoint'tan metin çıkarma
- OpenDocument'ten metin çıkarma
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument sunumlarından hızlı bir şekilde metin çıkarın. Zamandan tasarruf etmek için basit, adım adım rehberimizi izleyin."
---
## **Genel Bakış**

Sunumlardan metin çıkarma, slayt içeriğiyle çalışan geliştiriciler için yaygın ama önemli bir görevdir. Microsoft PowerPoint dosyaları PPT veya PPTX formatında ya da OpenDocument sunumları (ODP) ile çalışıyorsanız, metinsel verilere erişmek ve bunları almak analiz, otomasyon, indeksleme veya içerik taşıma amaçları için kritik olabilir.

Bu makale, Aspose.Slides for Java kullanarak PPT, PPTX ve ODP dahil çeşitli sunum formatlarından metni verimli bir şekilde çıkarmak için kapsamlı bir rehber sunar. Sunum öğeleri üzerinden sistematik olarak dolaşarak ihtiyacınız olan metin içeriğini doğru şekilde elde etmeyi öğreneceksiniz.

## **Bir Slayttan Metin Çıkarma**

Aspose.Slides for Java, [SlideUtil](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideutil/) sınıfını sağlar. Bu sınıf, bir sunum ya da slayttan tüm metni çıkarmak için birkaç aşırı yüklenmiş statik yöntem sunar. Bir sunumdaki bir slayttan metin çıkarmak için [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) yöntemini kullanın. Bu yöntem, parametre olarak [IBaseSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/) türünde bir nesne alır. Çalıştırıldığında, yöntem tüm slaytı metin için tarar ve [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) türünde nesneler dizisini, metin biçimlendirmesini koruyarak döndürür.

Aşağıdaki kod parçacığı, sunumun ilk slaytındaki tüm metni çıkarır:

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

## **Bir Sunumdan Metin Çıkarma**

Tüm sunumun metnini taramak için, [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) statik yöntemini kullanın. Bu yöntem iki parametre alır:

1. İlk olarak, metni çıkarılacak bir PowerPoint ya da OpenDocument sunumunu temsil eden bir [IPresentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/) nesnesi.
2. İkinci olarak, sunumdan metin taranırken ana slaytların (master slides) dahil edilip edilmeyeceğini belirten bir `boolean` değeri.

Yöntem, [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) türünde nesneler dizisini, metin biçimlendirme bilgisiyle birlikte döndürür. Aşağıdaki kod, sunumun metnini ve biçimlendirme ayrıntılarını, ana slaytları da dahil ederek tarar:

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

[PresentationFactory](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/) sınıfı da sunumlardan tüm metni çıkarmak için yöntemler sunar:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textextractionarrangingmode/) enum argümanı, metin çıkarma sonucunun düzenleme modunu belirler ve şu değerlerden birine ayarlanabilir:

- `Unarranged` - Slayttaki konumuna bakılmaksızın ham metin.
- `Arranged` - Metin, slayttaki aynı sırada düzenlenir.

Düzenlenmemiş (Unarranged) mod, hız kritik olduğunda kullanılabilir; düzenli (Arranged) moddan daha hızlıdır.

[IPresentationText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationtext/) sunumdan çıkarılan ham metni temsil eder. `getSlidesText` yöntemi, [ISlideText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidetext/) türünde nesneler dizisini döndürür. Her nesne ilgili slaydın metnini temsil eder. [ISlideText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidetext/) türündeki nesnenin aşağıdaki yöntemleri vardır:

- `getText` - Slayt şekilleri içindeki metin.
- `getMasterText` - Bu slaytla ilişkili ana slayt şekilleri içindeki metin.
- `getLayoutText` - Bu slaytla ilişkili yerleşim slaytı şekilleri içindeki metin.
- `getNotesText` - Bu slaytla ilişkili not slaytı şekilleri içindeki metin.
- `getCommentsText` - Bu slaytla ilişkili yorumlarda bulunan metin.

```java
String presentationPath = "presentation.ppt";
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

Aspose.Slides yüksek performans için optimize edilmiştir ve [büyük sunumları](/slides/tr/java/open-presentation/) işleyebilir, bu da gerçek zamanlı veya toplu işleme senaryoları için uygundur.

**Aspose.Slides sunumlardaki tablolar ve grafiklerden metin çıkarabilir mi?**

Evet. Aspose.Slides, tablolar ve grafikle ilgili nesneler dahil olmak üzere birçok slayt öğesinden metin çıkarabilir, böylece yaygın sunum yapılarına ait metin içeriğine erişebilir ve analiz edebilirsiniz.

**Sunumlardan metin çıkarmak için özel bir Aspose.Slides lisansına ihtiyacım var mı?**

Metin çıkarma işlemini ücretsiz deneme sürümüyle yapabilirsiniz, ancak [belirli sınırlamalar](/slides/tr/java/licensing/) bulunur; örneğin yalnızca sınırlı sayıda slayt işlenebilir. Sınırsız kullanım ve daha büyük sunumları işlemek için tam lisans satın almanız önerilir.