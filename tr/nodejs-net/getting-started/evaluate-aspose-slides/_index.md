---
title: "Aspose.Slides'i Değerlendir"
type: docs
weight: 120
url: /tr/nodejs-net/evaluate-aspose-slides/
keywords:
- "Aspose.Slides'i değerlendir"
- "değerlendirme sürümü"
- "değerlendirme su işareti"
- "deneme sınırlamaları"
- "geçici lisans"
- "PowerPoint"
- "sunum"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via .NET'in değerlendirme sürümünün sınırlamaları, her iki sınırlamayı gösteren bir betik ve lisans ile bunların nasıl kaldırılacağını gösterir."
---
## **Genel Bakış**

Aspose.Slides for Node.js via .NET'in değerlendirme sürümü, lisanslı sürümle aynı npm paketidir. Lisans olmadan değerlendirme modunda çalışır: tüm özellikler çalışır, ancak kaydedilen sunumlar ve çoğu dışa aktarma su işareti içerir ve kodunuzun geri okuduğu metin kırpılır. Bu makale her iki sınırlamayı da açıklar ve bunların nasıl kaldırılacağını gösterir.

## **Değerlendirme Sınırlamaları**

**Her slaytta bir değerlendirme su işareti.** Lisansa sahip olmadan bir sunumu kaydettiğinizde, Aspose.Slides kaydedilen dosyanın her slaydının ortasına bir metin kutusu ekler. Metin kutusu kilitlidir ve "Evaluation only." ifadesinin ardından bir ürün satırı ve bir telif hakkı satırı bulunur. Su işareti kaydedilen dosyaya eklenir, hafızadaki sunuma eklenmez ve bir sunumu açmak su işareti eklemez. Ancak değerlendirme modunda kaydedilen bir dosyada zaten metin kutusu bulunduğu için, dosyayı açıp tekrar kaydettiğinizde her slayta ikinci bir su işareti eklenir.

PDF, XPS veya HTML'ye dışa aktardığınızda veya slaytları görüntü olarak renderladığınızda aynı su işareti çıktıya eklenir. Değerlendirme modunda zaten kaydedilmiş bir sunumu renderlarsanız, görüntü kaydedilen su işareti ile renderlanan su işaretini birden gösterir.

**Koddunuz metni okurken kırpılır.** `text` özelliği üzerinden bir metin çerçevesi, paragraf veya bölümden kodunuzun okuduğu metin ilk beş karakterine kesilir ve ardından "... text has been truncated due to evaluation version limitation." uyarısı eklenir. Beş karakter veya daha az uzunluktaki metin tam olarak döndürülür. Bu durum her slaytta geçerlidir ve kodunuzun yeni atadığı metinlere bile uygulanır. Markdown ve HTML5 dışa aktarmaları da aynı şekilde kırpılır.

Kodunuzun yazdığı metin tam olarak kaydedilir: PPTX dosyaları, PDF sayfaları ve slayt görüntüleri metnin tamamını içerir.

## **Sınırlamaları Bir Betikte Görün**

Aşağıdaki betik her iki sınırlamayı gösterir. Paketi [Installation](/slides/tr/nodejs-net/installation/) bölümünde açıklandığı gibi kurduğunuzu ve betiği proje klasöründen çalıştırdığınızı varsayar. İlk slayta bir cümle içeren bir dikdörtgen ekler, cümleyi geri okur, sunumu `evaluation.pptx` olarak kaydeder ve ardından dosyayı yeniden açarak slayttaki şekilleri sayar.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Lisans olmadan, yalnızca ilk beş karakter döndürülür.
    console.log("Text read back:", rectangle.textFrame.text);

    // Kaydetme, dosyanın her slaytına değerlendirme su işareti ekler.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // Slayt artık dikdörtgeni ve su işareti metin kutusunu içeriyor.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Lisans olmadan betik şunu yazdırır:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

İkinci şekil su işareti metin kutusudur. Dikdörtgendeki tam cümleyi ve slaydın ortasındaki su işaretini görmek için `evaluation.pptx` dosyasını açın.

## **Sınırlamaları Kaldırın**

Her iki sınırlamayı da kaldırmak için, herhangi bir `Presentation` nesnesi oluşturmadan önce bir lisans uygulayın. [Licensing](/slides/tr/nodejs-net/licensing/) lisans dosyasının nasıl uygulanacağını gösterir.

{{% alert color="success" title="Tip" %}}
Satın almadan önce Aspose.Slides'i değerlendirme sınırlamaları olmadan test etmek için ücretsiz **30 günlük geçici lisans** isteyin. Ayrıntılar için [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) sayfasına bakın.
{{% /alert %}}

## **SSS**

**Değerlendirme modu slayt sayısını sınırlar mı?**  
Hayır. Sunumlar tüm slaytlarıyla oluşturulur, açılır ve kaydedilir. Su işareti ve metin kırpma her slayta aynı şekilde uygulanır.

**Neden dışa aktarılan slayt görüntülerim su işaretini iki kez gösteriyor?**  
Sunum, renderlamadan önce değerlendirme modunda kaydedildiği için zaten bir su işareti metin kutusu içerir ve lisans olmadan renderlama üzerine bir tane daha çizer.

**Değerlendirme modundayken kodumun doğru metni ürettiğini kontrol edebilir miyim?**  
Evet. Kaydedilen dosyayı veya dışa aktarılan PDF'i açın: metnin tamamını içerirler. Sadece kodunuzun geri okuduğu metin ve Markdown ya da HTML5 çıktısı kırpılır.