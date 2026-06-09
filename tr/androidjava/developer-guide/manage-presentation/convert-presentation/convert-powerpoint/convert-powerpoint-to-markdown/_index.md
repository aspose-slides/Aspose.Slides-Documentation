---
title: Android'de PowerPoint Sunumlarını Markdown'a Dönüştür
linktitle: PowerPoint'ten Markdown'a
type: docs
weight: 140
url: /tr/androidjava/convert-powerpoint-to-markdown/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten MD'ye
- sunumdan MD'ye
- slayttan MD'ye
- PPT'den MD'ye
- PPTX'den MD'ye
- PowerPoint'i Markdown olarak kaydet
- sunumu Markdown olarak kaydet
- slaytı Markdown olarak kaydet
- PPT'yi MD olarak kaydet
- PPTX'i MD olarak kaydet
- PPT'yi MD'ye dışa aktar
- PPTX'i MD'ye dışa aktar
- PowerPoint
- sunum
- Markdown
- Android
- Java
- Aspose.Slides
description: "PowerPoint slaytlarını—PPT, PPTX—Aspose.Slides for Android ile Java kullanarak temiz Markdown'a dönüştür, dokümantasyonu otomatikleştir ve biçimlendirmeyi koru."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını Markdown formatına dönüştürmenizi sağlar; bu, dokümantasyon iş akışları, statik site oluşturma, içerik taşıma ve sürüm kontrollü metin yayınlamada faydalı olabilir. API, PPT ve PPTX sunumlarından MD dosyalarına doğrudan dışa aktarmayı destekler ve sonuç Markdown belgesinde slayt içeriğinin nasıl temsil edileceğini kontrol eden ek seçenekler sunar.

Sunumları düz Markdown olarak dışa aktarabilir, CommonMark ve GitHub Flavored Markdown gibi birden fazla Markdown çeşidinden seçim yapabilir ve dışa aktarım sırasında görüntülerin nasıl işleneceğini yapılandırabilirsiniz. Görsel içerik içeren sunumlar için Aspose.Slides, görüntüleri ayrı bir klasöre kaydetmenize ve oluşturulan Markdown dosyasından onlara referans vermenize de olanak tanır.

Aspose.Slides, sunumdan markdown’a dönüşümünü destekler.

{{% alert color="warning" %}} 
PowerPoint’ten markdown’a dışa aktarma varsayılan olarak **görseller olmadan**dır. Görseller içeren bir PowerPoint belgesini dışa aktarmak istiyorsanız, `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` ayarlamanız ve ayrıca markdown belgesinde referans verilen görsellerin kaydedileceği `BasePath` değerini belirlemeniz gerekir.
{{% /alert %}} 

## **PowerPoint’i Markdown’a Dönüştür**

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturarak bir sunum nesnesi temsili yapın.
2. Nesneyi bir markdown dosyası olarak kaydetmek için [Kaydet ](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) metodunu kullanın.

Bu Java kodu, PowerPoint’i markdown’a nasıl dönüştüreceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint’i Markdown Çeşidine Dönüştür**

Aspose.Slides, PowerPoint’i temel sözdizimi içeren markdown, CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab ve 17 başka markdown çeşidine dönüştürmenizi sağlar.

Bu Java kodu, PowerPoint’i CommonMark’a nasıl dönüştüreceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

Desteklenen 23 markdown çeşidi, [Flavor enumarasyonu altında listelenmiştir](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/flavor/) ve [MarkdownSaveOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) sınıfı içinde bulunur.

## **Görseller İçeren Bir Sunumu Markdown’a Dönüştür**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) sınıfı, sonuç markdown dosyası için belirli seçenekleri veya ayarları kullanmanıza izin veren özellikler ve enumarasyonlar sağlar. Örneğin, [MarkdownExportType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownexporttype/) enumu, görüntülerin nasıl işleneceğini veya render edileceğini belirleyen `Sequential`, `TextOnly`, `Visual` değerlerine ayarlanabilir.

### **Görselleri Sıralı Olarak Dönüştür**

Görsellerin sonuç markdown’da tek tek, birbiri ardına görünmesini istiyorsanız, sıralı seçeneği seçmelisiniz. Bu Java kodu, görseller içeren bir sunumu markdown’a nasıl dönüştüreceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Görselleri Görsel Olarak Dönüştür**

Görsellerin sonuç markdown’da bir arada görünmesini istiyorsanız, görsel seçeneği seçmelisiniz. Bu durumda, görseller uygulamanın geçerli dizinine kaydedilir (ve markdown belgesinde onlar için bir göreceli yol oluşturulur) veya tercih ettiğiniz yolu ve klasör adını belirtebilirsiniz.

Bu Java kodu, işlemi göstermektedir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Hipermetinler Markdown dışa aktarımında korunur mu?**

Evet. Metin [hipermetinler](/slides/tr/androidjava/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [geçişler](/slides/tr/androidjava/slide-transition/) ve [animasyonlar](/slides/tr/androidjava/powerpoint-animation/) dönüştürülmez.

**Dönüştürmeyi birden fazla iş parçacığında çalıştırarak hızlandırabilir miyim?**

Dosyalar arasında paralelleştirme yapabilirsiniz, ancak aynı [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneğini iş parçacıkları arasında [paylaşmayın](/slides/tr/androidjava/multithreading/). Çakışmayı önlemek için dosya başına ayrı örnekler/prosesler kullanın.

**Görsellerle ne olur—nerede kaydedilir ve yollar göreceli mi?**

[Görseller](/slides/tr/androidjava/image/) ayrılmış bir klasöre dışa aktarılır ve Markdown dosyası varsayılan olarak onları göreceli yollarla referans alır. Temel çıktı yolunu ve varlık klasör adını yapılandırarak öngörülebilir bir depo yapısını koruyabilirsiniz.