---
title: PowerPoint Sunumlarını C++ ile Markdown'a Dönüştürme
linktitle: PowerPoint'ten Markdown'a
type: docs
weight: 140
url: /tr/cpp/convert-powerpoint-to-markdown/
keywords:
- PowerPoint'ı dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten MD'ye
- sunumdan MD'ye
- slayttan MD'ye
- PPT'den MD'ye
- PPTX'den MD'ye
- PowerPoint'ı Markdown olarak kaydet
- sunumu Markdown olarak kaydet
- slaytı Markdown olarak kaydet
- PPT'yi MD olarak kaydet
- PPTX'i MD olarak kaydet
- PPT'yi MD'ye dışa aktar
- PPTX'yi MD'ye dışa aktar
- PowerPoint
- sunum
- Markdown
- C++
- Aspose.Slides
description: "PowerPoint slaytlarını—PPT, PPTX—Aspose.Slides for C++ ile temiz Markdown'a dönüştürün, belgelendirmeyi otomatikleştirin ve biçimlendirmeyi koruyun."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını Markdown'a dönüştürmenizi sağlar; bu, belge iş akışları, statik site oluşturma, içerik taşıma ve sürüm kontrollü metin yayınlamada faydalı olabilir. API, PPT ve PPTX sunumlarından MD dosyalarına doğrudan dışa aktarmayı destekler ve oluşturulan Markdown belgesinde slayt içeriğinin nasıl temsil edileceğini kontrol eden ek seçenekler sunar.

Sunumları düz Markdown olarak dışa aktarabilir, CommonMark ve GitHub Flavored Markdown gibi birden fazla Markdown çeşidinden birini seçebilir ve dışa aktarma sırasında görsellerin nasıl işleneceğini yapılandırabilirsiniz. Görsel içeren sunumlar için Aspose.Slides, görselleri ayrı bir klasöre kaydetmenize ve oluşturulan Markdown dosyasından bunlara referans vermenize olanak tanır.

{{% alert color="warning" %}} 

PowerPoint'ten markdown dışa aktarımı varsayılan olarak **görseller olmadan** gerçekleşir. Görseller içeren bir PowerPoint belgesini dışa aktarmak istiyorsanız, `SaveOptions::MarkdownExportType::Visual)` ayarını yapmalı ve markdown belgesinde referans verilen görsellerin kaydedileceği `BasePath` değerini de belirlemelisiniz.

{{% /alert %}} 

## **PowerPoint'ı Markdown'a Dönüştürme**

1. Bir sunum nesnesini temsil etmek için [Sunum](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Nesneyi bir markdown dosyası olarak kaydetmek için [Kaydet](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) methodunu kullanın.

Bu C++ kodu, PowerPoint'i markdown'a nasıl dönüştüreceğinizi gösterir:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **PowerPoint'ı Markdown Çeşidine Dönüştürme**

Aspose.Slides, PowerPoint'i temel sözdizimi içeren markdown, CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab ve 17 diğer markdown çeşidine dönüştürmenize olanak tanır.

Bu C++ kodu, PowerPoint'i CommonMark'a nasıl dönüştüreceğinizi gösterir:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

23 desteklenen markdown çeşidi, [Flavor enumeration](https://reference.aspose.com/slides/tr/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) altında [MarkdownSaveOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) sınıfından listelenmiştir.

## **Görseller İçeren Bir Sunumu Markdown'a Dönüştürme**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) sınıfı, ortaya çıkan markdown dosyası için belirli seçenekler veya ayarlar kullanmanıza olanak tanıyan özellikler ve enumarasyonlar sağlar. Örneğin, [MarkdownExportType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) enumu, görsellerin nasıl işleneceğini belirleyen `Sequential`, `TextOnly`, `Visual` değerlerine ayarlanabilir.

### **Görselleri Sıralı Olarak Dönüştürme**

Görsellerin sonuç markdown içinde birbirini takip eden tek tek görünümesini istiyorsanız sıralı seçeneği seçmelisiniz. Bu C++ kodu, görseller içeren bir sunumu markdown'a nasıl dönüştüreceğinizi gösterir:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```

### **Görselleri Görsel Olarak Dönüştürme**

Görsellerin sonuç markdown içinde birlikte görünmesini istiyorsanız görsel seçeneği seçmelisiniz. Bu durumda görseller, uygulamanın geçerli dizinine kaydedilir (ve markdown belgesinde bunlar için göreli bir yol oluşturulur) veya tercih ettiğiniz yolu ve klasör adını belirtebilirsiniz.

Bu C++ kodu işlemi gösterir:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **SSS**

**Hipermetin bağlantıları Markdown'a dışa aktarmada korunur mu?**

Evet. Metin [hiperbağlantılar](/slides/tr/cpp/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [geçişler](/slides/tr/cpp/slide-transition/) ve [animasyonlar](/slides/tr/cpp/powerpoint-animation/) dönüştürülmez.

**Çoklu iş parçacığında çalıştırarak dönüşümü hızlandırabilir miyim?**

Dosyalar arasında paralelleştirme yapabilirsiniz, ancak aynı [Sunum](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğini iş parçacıkları arasında [paylaşmayın](/slides/tr/cpp/multithreading/). Çakışmayı önlemek için dosya başına ayrı örnekler/prosesler kullanın.

**Görseller ne olur—nerede kaydedilir ve yollar göreli mi?**

[Görseller](/slides/tr/cpp/image/) ayrı bir klasöre dışa aktarılır ve Markdown dosyası varsayılan olarak onlara göreli yollarla referans verir. Temel çıkış yolunu ve varlık klasör adını yapılandırarak öngörülebilir bir depo yapısı koruyabilirsiniz.