---
title: "JavaScript'te Sunumlardan Gelişmiş Metin Çıkarma"
linktitle: "Metin Çıkar"
type: docs
weight: 90
url: /tr/nodejs-java/extract-text-from-presentation/
keywords:
- "metin çıkarma"
- "slayttan metin çıkarma"
- "sunumdan metin çıkarma"
- "PowerPoint'tan metin çıkarma"
- "OpenDocument'ten metin çıkarma"
- "PPT'den metin çıkarma"
- "PPTX'ten metin çıkarma"
- "ODP'den metin çıkarma"
- "metin alma"
- "slayttan metin alma"
- "sunumdan metin alma"
- "PowerPoint'tan metin alma"
- "OpenDocument'ten metin alma"
- "PPT'den metin alma"
- "PPTX'ten metin alma"
- "ODP'den metin alma"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint ve OpenDocument sunumlardan metni hızlı bir şekilde çıkarın. Zaman kazanmak için basit, adım adım rehberimizi izleyin."
---
## **Genel Bakış**

Sunumlardan metin çıkarmak, slayt içeriğiyle çalışan geliştiriciler için yaygın ancak önemli bir görevdir. Microsoft PowerPoint dosyaları PPT veya PPTX biçiminde olsun ya da OpenDocument sunumları (ODP) olsun, metinsel verilere erişmek ve bunları almak analiz, otomasyon, indeksleme veya içerik taşıma amaçları için kritik olabilir.

Bu makale, Aspose.Slides for Node.js via Java kullanarak PPT, PPTX ve ODP dahil çeşitli sunum formatlarından metni verimli bir şekilde çıkarmanın kapsamlı bir rehberini sunar. Sunum öğeleri üzerinde sistematik olarak döngü yaparak ihtiyacınız olan metin içeriğini doğru bir şekilde almayı öğreneceksiniz.

## **Bir Slayttan Metin Çıkarma**

Aspose.Slides for Node.js via Java, [SlideUtil](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideutil/) sınıfını sağlar. Bu sınıf, bir sunum veya slayttan tüm metni çıkarmak için çeşitli aşırı yüklü statik yöntemler sunar. Bir sunumdaki bir slayttan metin çıkarmak için [getAllTextBoxes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) yöntemini kullanın. Bu yöntem, bir slayt nesnesini parametre olarak alır. Çalıştırıldığında, yöntem slayt genelinde metni tarar ve metin biçimlendirmesini koruyan [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) nesnelerinden bir dizi döndürür.

Aşağıdaki kod snippet'i, sunumun ilk slaydındaki tüm metni çıkarır:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Bir Sunumdan Metin Çıkarma**

Sunumun tamamındaki metni taramak için, [SlideUtil](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideutil/) sınıfı tarafından sunulan [getAllTextFrames](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) statik yöntemini kullanın. Bu yöntem iki parametre alır:
1. İlk olarak, metnin çıkarılacağı PowerPoint veya OpenDocument sunumunu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) nesnesi.
1. İkinci olarak, sunumdan metin taranırken ana slaytların (master slides) dahil edilip edilmeyeceğini belirten bir `boolean` değeri.

Yöntem, metin biçimlendirme bilgilerini içeren [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) nesnelerinden bir dizi döndürür. Aşağıdaki kod, ana slaytlar dahil olmak üzere bir sunumdan metin ve biçimlendirme ayrıntılarını tarar.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kategorize ve Hızlı Metin Çıkarma**

[PresentationFactory](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/) sınıfı da sunumlardan tüm metni çıkarmak için yöntemler sağlar:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textextractionarrangingmode/) enum argümanı, metin çıkarma sonucunun düzenlenme modunu gösterir ve aşağıdaki değerlere ayarlanabilir:
- `Unarranged` - Slayttaki konumuna bakılmaksızın ham metin.
- `Arranged` - Metin, slayttaki sıraya aynı şekilde düzenlenir.

Hız kritik olduğunda düzenlenmemiş (unarranged) mod kullanılabilir; bu, düzenlenmiş (arranged) moddan daha hızlıdır.

[PresentationText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationtext/) sunumdan çıkarılan ham metni temsil eder. `getSlidesText` yöntemi, ilgili slayttaki metni temsil eden nesnelerden oluşan bir dizi döndürür. Her slayt metin nesnesi aşağıdaki yöntemlere sahiptir:
- `getText` yöntemi, slaydın şekilleri içindeki metni döndürür.
- `getMasterText` yöntemi, bu slaytla ilişkili ana slaydın (master slide) şekilleri içindeki metni döndürür.
- `getLayoutText` yöntemi, bu slaytla ilişkili düzen slaydının (layout slide) şekilleri içindeki metni döndürür.
- `getNotesText` yöntemi, bu slaytla ilişkili not slaydının (notes slide) şekilleri içindeki metni döndürür.
- `getCommentsText` yöntemi, bu slaytla ilişkili yorumlardaki metni döndürür.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **FAQ**

**Aspose.Slides büyük sunumları metin çıkarma sırasında ne kadar hızlı işler?**

Aspose.Slides yüksek performans için optimize edilmiştir ve [large presentations](/slides/tr/nodejs-java/open-presentation/) gibi büyük sunumları bile işleyebilir, bu da gerçek zamanlı veya toplu işleme senaryoları için uygundur.

**Aspose.Slides sunumlardaki tablolar ve grafiklerden metin çıkarabilir mi?**

Evet. Aspose.Slides, tablolar ve grafikle ilgili nesneler dahil olmak üzere birçok slayt öğesinden metin çıkarabilir, böylece yaygın sunum yapılarındaki metinsel içeriğe erişebilir ve analiz edebilirsiniz.

**Sunumlardan metin çıkarmak için özel bir Aspose.Slides lisansına ihtiyacım var mı?**

Metni, Aspose.Slides'ın ücretsiz deneme sürümüyle çıkarabilirsiniz, ancak bu sürüm [certain limitations](/slides/tr/nodejs-java/licensing/) gibi sınırlamalara sahiptir; örneğin sadece sınırlı sayıda slayt işleyebilir. Kısıtlama olmaksızın kullanım ve daha büyük sunumları işlemek için tam bir lisans satın almanız önerilir.