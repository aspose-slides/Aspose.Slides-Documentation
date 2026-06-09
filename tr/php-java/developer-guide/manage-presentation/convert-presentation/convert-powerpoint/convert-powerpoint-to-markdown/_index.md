---
title: PHP ile PowerPoint Sunumlarını Markdown'a Dönüştürme
linktitle: PowerPoint'tan Markdown'a
type: docs
weight: 140
url: /tr/php-java/convert-powerpoint-to-markdown/
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
- PowerPoint'i Markdown olarak kaydet
- sunumu Markdown olarak kaydet
- slaytı Markdown olarak kaydet
- PPT'yi MD olarak kaydet
- PPTX'i MD olarak kaydet
- PPT'yi MD'ye dışa aktar
- PPTX'yi MD'ye dışa aktar
- PowerPoint
- sunum
- Markdown
- PHP
- Aspose.Slides
description: "PowerPoint slaytlarını — PPT, PPTX — Aspose.Slides for PHP via Java ile temiz Markdown'a dönüştürün, belge oluşturmayı otomatikleştirin ve biçimlendirmeyi koruyun."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını Markdown'a dönüştürmenizi sağlar; bu, belge iş akışları, statik site oluşturma, içerik göçü ve sürüm kontrollü metin yayıncılığı için faydalı olabilir. API, PPT ve PPTX sunumlarından MD dosyalarına doğrudan dışa aktarmayı destekler ve oluşturulan Markdown belgesinde slayt içeriğinin nasıl temsil edileceğini kontrol eden ek seçenekler sunar.

Sunumları düz Markdown olarak dışa aktarabilir, CommonMark ve GitHub Flavored Markdown gibi çeşitli Markdown çeşitlerinden seçim yapabilir ve dışa aktarma sırasında görsellerin nasıl işlendiğini yapılandırabilirsiniz. Görsel içerik içeren sunumlar için Aspose.Slides ayrıca görselleri ayrı bir klasöre kaydetmenize ve oluşturulan Markdown dosyasından referans vermenize olanak tanır.

{{% alert color="warning" %}}
PowerPoint'ten Markdown'a dışa aktarma varsayılan olarak **görseller olmadan** yapılır. Görseller içeren bir PowerPoint belgesini dışa aktarmak istiyorsanız, `ExportType = MarkdownExportType::Visual` ayarlamanız ve `BasePath` belirtmeniz gerekir; bu, Markdown belgesinde referans verilen görsellerin kaydedileceği yerdir.
{{% /alert %}}

## **Sunumu Markdown'a Dönüştürme**

Bu bölüm, Aspose.Slides'ın PowerPoint ve OpenDocument sunumlarını (PPT, PPTX, ODP) temiz Markdown'a nasıl dönüştürdüğünü açıklar; orijinal slayt hiyerarşisini, metni ve temel biçimlendirmeyi bozmadan tutar, böylece içeriği belgelemelerde veya sürüm kontrollü iş akışlarında ekstra manuel çaba harcamadan yeniden kullanabilirsiniz.

1. Sunumu temsil etmek için [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. [save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) metodunu kullanarak onu bir Markdown dosyası olarak dışa aktarın.

Bu PHP kodu, bir PowerPoint sunumunun Markdown'a nasıl dönüştürüleceğini gösterir:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Sunumu Markdown Çeşidine Dönüştürme**

Aspose.Slides, PowerPoint sunumlarını temel sözdizimiyle Markdown'a, ayrıca CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab ve diğer on yedi Markdown çeşidine dönüştürmenizi sağlar.

Aşağıdaki PHP kodu, bir PowerPoint sunumunun CommonMark'a nasıl dönüştürüleceğini gösterir:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

Desteklenen 23 Markdown çeşidi, [Flavor enumeration](https://reference.aspose.com/slides/tr/php-java/aspose.slides/flavor/) içinde listelenmiştir.

## **Görseller İçeren Sunumu Markdown'a Dönüştürme**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownsaveoptions/) sınıfı, ortaya çıkan Markdown dosyasını yapılandırmanızı sağlayan özellikler ve enum'lar sunar. Örneğin, [MarkdownExportType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownexporttype/) enum'ı görsellerin nasıl işleneceğini belirtir: `Sequential`, `TextOnly` veya `Visual`.

{{% alert color="warning" %}}
Varsayılan olarak, PowerPoint‑to‑Markdown dışa aktarımı **görselleri içermez**. Görselleri eklemek için `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` çağırın ve Markdown dosyasında referans verilen görsellerin kaydedileceği yeri belirten `BasePath` değerini ayarlayın.
{{% /alert %}}

### **Görselleri Sıralı Olarak Dönüştürme**

Görsellerin sonuç Markdown'ta tek tek, birbiri ardına görünmesini istiyorsanız, `Sequential` seçeneğini seçmelisiniz. Aşağıdaki PHP kodu, görseller içeren bir sunumun Markdown'a nasıl dönüştürüleceğini gösterir:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **Görselleri Görsel Olarak Dönüştürme**

Görsellerin sonuç Markdown'ta birlikte görünmesini istiyorsanız, `Visual` seçeneğini seçmelisiniz. Bu durumda, görseller uygulamanın geçerli dizinine kaydedilir (ve Markdown belgesinde onlar için bir göreli yol oluşturulur) veya istediğiniz dizin ve klasör adını belirtebilirsiniz. Aşağıdaki PHP kodu, işlemi gösterir:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Hipermetin bağlantıları Markdown'a dışa aktarmada korunur mu?**  
Evet. Metin [hyperlinks](/slides/tr/php-java/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [transitions](/slides/tr/php-java/slide-transition/) ve [animations](/slides/tr/php-java/powerpoint-animation/) dönüştürülmez.

**Dönüşümü birden fazla iş parçacığında çalıştırarak hızlandırabilir miyim?**  
Dosyalar arasında paralelleştirme yapabilirsiniz, ancak aynı [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneğini iş parçacıkları arasında [paylaşmayın](/slides/tr/php-java/multithreading/). Çakışmayı önlemek için dosya başına ayrı örnekler/süreçler kullanın.

**Görseller ne olur—nerede kaydedilir ve yollar göreli midir?**  
[Images](/slides/tr/php-java/image/) özel bir klasöre dışa aktarılır ve Markdown dosyası varsayılan olarak onları göreli yollarla referans verir. Öngörülebilir bir depo yapısı için temel çıktı yolunu ve varlık klasör adını yapılandırabilirsiniz.