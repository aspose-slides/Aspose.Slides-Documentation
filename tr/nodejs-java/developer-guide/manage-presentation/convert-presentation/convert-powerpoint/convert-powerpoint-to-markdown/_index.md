---
title: JavaScript'te PowerPoint Sunumlarını Markdown'a Dönüştür
linktitle: PowerPoint'ten Markdown'a
type: docs
weight: 140
url: /tr/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'tan MD'ye
- sunumdan MD'ye
- slayttan MD'ye
- PPT'den MD'ye
- PPTX'den MD'ye
- PowerPoint'u Markdown olarak kaydet
- sunumu Markdown olarak kaydet
- slaytı Markdown olarak kaydet
- PPT'yi MD olarak kaydet
- PPTX'i MD olarak kaydet
- PPT'yi MD'ye dışa aktar
- PPTX'i MD'ye dışa aktar
- PowerPoint
- sunum
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te PowerPoint slaytlarını—PPT, PPTX—Aspose.Slides for Node.js ile Java aracılığıyla temiz Markdown'a dönüştürün, belgeleri otomatikleştirin ve biçimlendirmeyi koruyun."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını Markdown'a dönüştürmenizi sağlar; bu, dokümantasyon iş akışları, statik site üretimi, içerik göçü ve sürüm kontrollü metin yayıncılığı için faydalı olabilir. API, PPT ve PPTX sunumlarından MD dosyalarına doğrudan dışa aktarmayı destekler ve kaydırı içeriğinin oluşturulan Markdown belgesinde nasıl temsil edileceğini kontrol eden ek seçenekler sunar.

Sunumları düz Markdown olarak dışa aktarabilir, CommonMark ve GitHub Flavored Markdown gibi birçok Markdown türünden seçim yapabilir ve dışa aktarım sırasında görsellerin nasıl işleneceğini yapılandırabilirsiniz. Görsel içeriği olan sunumlar için Aspose.Slides, görselleri ayrı bir klasöre kaydetmenize ve oluşturulan Markdown dosyasından bunlara referans vermenize de olanak tanır.

{{% alert color="warning" %}} 
PowerPoint'ten markdown'a dışa aktarma varsayılan olarak **görseller olmadan** yapılır. Görseller içeren bir PowerPoint belgesini dışa aktarmak istiyorsanız, `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` çağırmanız ve markdown belgesinde referans verilen görsellerin kaydedileceği `BasePath` değerini ayarlamanız gerekir.
{{% /alert %}} 

## **PowerPoint'i Markdown'a Dönüştür**

1. Bir sunum nesnesini temsil edecek şekilde [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Nesneyi markdown dosyası olarak kaydetmek için [save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) yöntemini kullanın.

Bu JavaScript kodu, PowerPoint'i markdown'a nasıl dönüştüreceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint'i Markdown Türüne Dönüştür**

Aspose.Slides, PowerPoint'i temel sözdizimi içeren bir markdown, CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab ve 17 başka markdown türüne dönüştürmenize olanak tanır.

Bu JavaScript kodu, PowerPoint'i CommonMark'a nasıl dönüştüreceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Desteklenen 23 markdown türü, [MarkdownSaveOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) sınıfındaki [Flavor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/flavor/) enumarasyonunda [listelenmiştir](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/flavor/).

## **Görseller İçeren Sunumu Markdown'a Dönüştür**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) sınıfı, oluşturulan markdown dosyası için belirli seçenekler veya ayarlar kullanmanıza olanak tanıyan özellikler ve enumarasyonlar sağlar. Örneğin, [MarkdownExportType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownexporttype/) enumu, görsellerin nasıl işleneceğini belirleyen değerler alabilir: `Sequential`, `TextOnly`, `Visual`.

### **Görselleri Sıralı Olarak Dönüştür**

Görsellerin sonuç markdown içinde birer birer, sırasıyla görünmesini istiyorsanız sıralı seçeneği seçmelisiniz. Bu JavaScript kodu, görseller içeren bir sunumu markdown'a nasıl dönüştüreceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Görselleri Görsel Olarak Dönüştür**

Görsellerin sonuç markdown içinde birlikte görünmesini istiyorsanız görsel seçeneği seçmelisiniz. Bu durumda görseller, uygulamanın geçerli dizinine kaydedilir (ve markdown belgesinde onlara göreceli bir yol oluşturulur) ya da tercih ettiğiniz yol ve klasör adını belirtebilirsiniz.

Bu JavaScript kodu işlemi göstermek için örneklenmiştir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Hipermetin bağlantıları Markdown'a dışa aktarımda korunur mu?**

Evet. Metin [hyperlinks](/slides/tr/nodejs-java/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Kaydırı [transitions](/slides/tr/nodejs-java/slide-transition/) ve [animations](/slides/tr/nodejs-java/powerpoint-animation/) dönüştürülmez.

**Dönüştürmeyi birden çok iş parçacığında çalıştırarak hızlandırabilir miyim?**

Dosyalar arasında paralelleştirme yapabilirsiniz, ancak aynı [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneğini iş parçacıkları arasında [paylaşmayın](/slides/tr/nodejs-java/multithreading/). Çakışmayı önlemek için dosya başına ayrı örnekler/prosesler kullanın.

**Görseller ne olur—nerede kaydedilir ve yollar göreceli mi?**

[Görseller](/slides/tr/nodejs-java/image/) özel bir klasöre dışa aktarılır ve Markdown dosyası varsayılan olarak onlara göreceli yollarla referans verir. Temel çıkış yolunu ve varlık klasör adını yapılandırarak tutarlı bir depo yapısı oluşturabilirsiniz.