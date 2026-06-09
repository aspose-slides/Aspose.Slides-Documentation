---
title: PowerPoint Sunumlarını .NET'te Markdown'a Dönüştür
linktitle: PowerPoint'tan Markdown'a
type: docs
weight: 140
url: /tr/net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan MD'ye
- sunumdan MD'ye
- slayttan MD'ye
- PPT'den MD'ye
- PPTX'ten MD'ye
- PowerPoint'ı Markdown olarak kaydet
- sunumu Markdown olarak kaydet
- slaytı Markdown olarak kaydet
- PPT'yi MD olarak kaydet
- PPTX'i MD olarak kaydet
- PPT'yi MD'ye dışa aktar
- PPTX'i MD'ye dışa aktar
- PowerPoint
- sunum
- Markdown
- .NET
- C#
- Aspose.Slides
description: "PowerPoint slaytlarını—PPT, PPTX—Aspose.Slides for .NET ile temiz Markdown'a dönüştürün, belgeleri otomatikleştirin ve biçimlendirmeyi koruyun."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını Markdown'a dönüştürmenize olanak tanır; bu, belge iş akışları, statik site oluşturma, içerik taşıma ve sürüm kontrolü altında metin yayınlama için faydalı olabilir. API, PPT ve PPTX sunumlarından MD dosyalarına doğrudan dışa aktarmayı destekler ve ortaya çıkan Markdown belgesinde slayt içeriğinin nasıl temsil edileceğini kontrol etmek için ek seçenekler sunar.

Sunumları düz Markdown olarak dışa aktarabilir, CommonMark ve GitHub Flavored Markdown gibi birden fazla Markdown çeşidinden seçim yapabilir ve dışa aktarma sırasında görsellerin nasıl işleneceğini yapılandırabilirsiniz. Görsel içerik içeren sunumlar için Aspose.Slides, görselleri ayrı bir klasöre kaydetmenize ve oluşan Markdown dosyasından referans vermenize de olanak tanır.

{{% alert color="warning" %}}
PowerPoint'tan Markdown'a dışa aktarım varsayılan olarak **görseller olmadan** gerçekleşir. Görseller içeren bir PowerPoint belgesini dışa aktarmak istiyorsanız, `ExportType = MarkdownExportType.Visual` ayarını yapmalı ve `BasePath` belirlemelisiniz; böylece Markdown belgesinde referans verilen görseller kaydedilir.
{{% /alert %}}

## **PowerPoint'u Markdown'a Dönüştür**

1. Bir sunum nesnesini temsil etmek için [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Nesneyi bir markdown dosyası olarak kaydetmek için [Save ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/methods/save) metodunu kullanın.

Bu C# kodu, PowerPoint'u markdown'a nasıl dönüştüreceğinizi gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **PowerPoint'u Markdown Çeşidine Dönüştür**

Aspose.Slides, PowerPoint'u temel sözdizimi içeren markdown, CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab ve diğer 17 markdown çeşidine dönüştürmenize olanak tanır.

Bu C# kodu, PowerPoint'u CommonMark'a nasıl dönüştüreceğinizi gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

Desteklenen 23 markdown çeşidi, [MarkdownSaveOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) sınıfının [Flavor enumarasyonu](https://reference.aspose.com/slides/tr/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) altında listelenmiştir.

## **Görseller İçeren Bir Sunumu Markdown'a Dönüştür**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) sınıfı, ortaya çıkan markdown dosyası için belirli seçenekleri veya ayarları kullanmanızı sağlayan özellikler ve enumlar sunar. Örneğin, [MarkdownExportType](https://reference.aspose.com/slides/tr/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) enumu, görsellerin nasıl işleneceğini veya render edileceğini belirleyen değerler alabilir: `Sequential`, `TextOnly`, `Visual`.

### **Görselleri Sıralı Olarak Dönüştür**

Eğer görsellerin ortaya çıkan markdown'da tek tek, birbiri ardına görünmesini istiyorsanız, sıralı seçeneği seçmelisiniz. Bu C# kodu, görseller içeren bir sunumu markdown'a nasıl dönüştüreceğinizi gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **Görselleri Görsel Olarak Dönüştür**

Eğer görsellerin ortaya çıkan markdown'da bir arada görünmesini istiyorsanız, görsel seçeneği seçmelisiniz. Bu durumda, görseller uygulamanın geçerli dizinine kaydedilir (ve markdown belgesinde onlar için göreceli bir yol oluşturulur) veya tercih ettiğiniz yol ve klasör adını belirtebilirsiniz.

Bu C# kodu işlemi gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **FAQ**

**Hipernizolar Markdown'a dışa aktarmada korunur mu?**

Evet. Metin [hyperlinks](/slides/tr/net/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [transitions](/slides/tr/net/slide-transition/) ve [animations](/slides/tr/net/powerpoint-animation/) dönüştürülmez.

**Dönüştürmeyi birden fazla iş parçacığında çalıştırarak hızlandırabilir miyim?**

Dosyalar arasında paralelleştirme yapabilirsiniz, ancak aynı [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneğini iş parçacıkları arasında [don’t share](/slides/tr/net/multithreading/) etmeyin. Çakışmayı önlemek için dosya başına ayrı örnekler/süreçler kullanın.

**Görseller ne olur—nerede kaydedilir ve yollar göreceli mi?**

[Images](/slides/tr/net/image/) ayrı bir klasöre dışa aktarılır ve Markdown dosyası varsayılan olarak onları göreceli yollarla referans verir. Temel çıktı yolunu ve varlık klasör adını yapılandırarak öngörülebilir bir depo yapısı sürdürebilirsiniz.