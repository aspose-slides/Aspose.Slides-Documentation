---
title: Java'da PowerPoint Sunumlarını Markdown'a Dönüştür
linktitle: PowerPoint'ten Markdown'a
type: docs
weight: 140
url: /tr/java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten MD'ye
- sunumdan MD'ye
- slayttan MD'ye
- PPT'den MD'ye
- PPTX'ten MD'ye
- PowerPoint'i Markdown olarak kaydet
- sunumu Markdown olarak kaydet
- slaytı Markdown olarak kaydet
- PPT'yi MD olarak kaydet
- PPTX'i MD olarak kaydet
- PPT'yi MD'ye aktar
- PPTX'i MD'ye aktar
- PowerPoint
- sunum
- Markdown
- Java
- Aspose.Slides
description: "PowerPoint slaytlarını—PPT, PPTX—Aspose.Slides for Java ile temiz Markdown'a dönüştürün, belgeleri otomatikleştirin ve biçimlendirmeyi koruyun."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını Markdown'a dönüştürmenizi sağlar; bu, belge akışları, statik site oluşturma, içerik taşıma ve sürüm kontrollü metin yayıncılığı için yararlı olabilir. API, PPT ve PPTX sunumlarını doğrudan MD dosyalarına dışa aktarmayı destekler ve elde edilen Markdown belgesinde slayt içeriğinin nasıl temsil edileceğini kontrol eden ek seçenekler sunar.

Sunumları düz Markdown olarak dışa aktarabilir, CommonMark ve GitHub Flavored Markdown gibi birden fazla Markdown çeşidinden seçebilir ve dışa aktarım sırasında görsellerin nasıl ele alınacağını yapılandırabilirsiniz. Görsel içeriği olan sunumlar için Aspose.Slides, görselleri ayrı bir klasöre kaydetmenize ve üretilen Markdown dosyasından bu görsellere referans vermenize olanak tanır.

{{% alert color="warning" %}}

PowerPoint'ten markdown dışa aktarımı varsayılan olarak **görseller olmadan**dır. Görseller içeren bir PowerPoint belgesini dışa aktarmak istiyorsanız, `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` kullanmalı ve ayrıca görsellerin markdown belgesinde referans gösterileceği yeri belirlemek için `setBasePath` kullanmalısınız.

{{% /alert %}}

## **PowerPoint'i Markdown'a Dönüştür**

1. Sunumu temsil eden bir nesne oluşturmak için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Nesneyi markdown dosyası olarak kaydetmek için [Save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)metodunu kullanın.

Bu Java kodu, PowerPoint'i markdown'a nasıl dönüştüreceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint'i Markdown Çeşidine Dönüştür**

Aspose.Slides, PowerPoint'i markdown (temel sözdizimi içeren), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab ve 17 diğer markdown çeşidine dönüştürmenize olanak tanır.

Bu Java kodu, PowerPoint'i CommonMark'a nasıl dönüştüreceğinizi gösterir:

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

Desteklenen 23 markdown çeşidi, [Flavor enumeration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/flavor/) altında [MarkdownSaveOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) sınıfından listelenmiştir.

## **Görseller İçeren Bir Sunumu Markdown'a Dönüştür**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) sınıfı, elde edilen markdown dosyası için belirli seçenekleri veya ayarları kullanmanıza olanak tanıyan özellikler ve enumlar sağlar. Örneğin, [MarkdownExportType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownexporttype/) enumu, görsellerin nasıl işleneceğini belirleyen değerler alabilir: `Sequential`, `TextOnly`, `Visual`.

### **Görselleri Sıralı Olarak Dönüştür**

Görsellerin sonuç markdown dosyasında tek tek, birbiri ardına görünmesini istiyorsanız, sıralı seçeneği seçmeniz gerekir. Bu Java kodu, görseller içeren bir sunumu markdown'a nasıl dönüştüreceğinizi gösterir:

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

Görsellerin sonuç markdown dosyasında birlikte görünmesini istiyorsanız, görsel seçeneği seçmeniz gerekir. Bu durumda, görseller uygulamanın geçerli dizinine kaydedilir (ve markdown belgesinde onlar için göreceli bir yol oluşturulur) veya tercih ettiğiniz yol ve klasör adını belirtebilirsiniz.

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

**Hipermetinler Markdown'a dışa aktarıldıktan sonra korunur mu?**

Evet. Metin [hiperbağlantılar](/slides/tr/java/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [geçişler](/slides/tr/java/slide-transition/) ve [animasyonlar](/slides/tr/java/powerpoint-animation/) dönüştürülmez.

**Dönüşümü birden çok iş parçacığıyla çalıştırarak hızlandırabilir miyim?**

Dosyalar arasında paralel işleyebilirsiniz, ancak aynı [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneğini iş parçacıkları arasında [paylaşmayın](/slides/tr/java/multithreading/). Çakışmayı önlemek için dosya başına ayrı örnekler/süreçler kullanın.

**Görseller ne olur—nerede kaydedilir ve yollar göreceli mi?**

[Görseller](/slides/tr/java/image/) ayrı bir klasöre aktarılır ve Markdown dosyası varsayılan olarak onları göreceli yollarla referans verir. Temel çıktı yolunu ve varlık klasör adını yapılandırarak öngörülebilir bir depo yapısı oluşturabilirsiniz.