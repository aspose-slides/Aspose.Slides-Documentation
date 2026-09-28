---
title: Desteklenen Dosya Biçimleri
type: docs
weight: 96
url: /tr/net/supported-file-formats/
keywords:
- desteklenen dosya biçimleri
- sunum yükle
- PDF içe aktar
- HTML içe aktar
- sunumu kaydet
- slaytları oluştur
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in hangi dosya biçimlerini yükleyebileceğini, içe aktarabileceğini, kaydedebileceğini ve oluşturabileceğini, ve her birini hangi API'nin okuduğunu ya da yazdığını görün."
---
## **Genel Bakış**

Aspose.Slides for .NET, PowerPoint ve OpenDocument sunumlarını açar ve kaydeder. Ayrıca PDF ve HTML içeriğini slaytlara aktarır, sunumları belge, web ve görüntü biçimlerinde kaydeder ve tek tek slaytları ve şekilleri resim olarak oluşturur. Bu makale, desteklenen her biçimi listeler ve onu okuyan veya yazan API'yi adlandırır.

Aspose.Slides.NET ve Aspose.Slides.NET6.CrossPlatform NuGet paketlerinin ikisi aynı biçimleri destekler; aralarından seçim yapmak için [Kurulum](/slides/tr/net/installation/) bölümüne bakın. Düzenleme özelliklerinin genel bir bakışı için [Özellikler Genel Bakışı](/slides/tr/net/features-overview/) bölümüne bakın.

## **Desteklenen Microsoft PowerPoint Sürümleri**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (eskiden Office 365)

{{% alert color="info" title="Note" %}}
PowerPoint 95 ve önceki sürümlerle kaydedilmiş sunumlar açılamaz. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) bir PowerPoint 95 dosyasını tanır ve `LoadFormat.Ppt95` raporlar, ancak [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) yapıcı bu dosya için [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) hatası verir.
{{% /alert %}}

## **Desteklenen Dosya Biçimleri**

Tablo dört işlem kullanır:

- **Yükle**: [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) yapıcı, dosyayı düzenlenebilir bir sunum olarak açar.
- **İçe Aktar**: bir [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) yöntemi, dosyanın içeriğinden slaytlar oluşturarak mevcut bir sunuma ekler. Presentation yapıcı bu dosyaları sunum olarak yüklemez.
- **Kaydet**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) sunumu bir dosyaya veya akışa yazar. XAML dışındaki tüm biçimler bir [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) değeriyle seçilir.
- **Oluştur**: bir oluşturma yöntemi, bir slaytı veya şekli resim olarak çizer. Sadece oluşturulan biçimler SaveFormat değeri içermez.

|**Biçim**|**Açıklama**|**Yükle / İçe Aktar**|**Kaydet / Oluştur**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 Sunumu|Yükle|Kaydet|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 Şablonu|Yükle|Kaydet|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 Slayt Gösterisi|Yükle|Kaydet|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint Sunumu|Yükle|Kaydet|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint Şablonu|Yükle|Kaydet|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint Slayt Gösterisi|Yükle|Kaydet|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint Makro Destekli Sunum|Yükle|Kaydet|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint Makro Destekli Şablon|Yükle|Kaydet|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint Makro Destekli Slayt Gösterisi|Yükle|Kaydet|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument Sunumu|Yükle|Kaydet|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Düz XML OpenDocument Sunumu|Yükle|Kaydet|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument Sunum Şablonu|Yükle|Kaydet|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML Sunumu|Yükle|Kaydet|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|Taşınabilir Belge Biçimi|İçe Aktar|Kaydet|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hipermetin İşaretleme Dili|İçe Aktar|Kaydet|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Kağıt Spesifikasyonu|—|Kaydet|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Etiketli Görüntü Dosyası Biçimi|—|Kaydet, Oluştur|`SaveFormat.Tiff`; `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Grafik Değişim Biçimi|—|Kaydet, Oluştur|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Küçük Web Biçimi (Flash)|—|Kaydet|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Kaydet|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Genişletilebilir Uygulama İşaretleme Dili|—|Kaydet|`Presentation.Save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Taşınabilir Ağ Grafiği|—|Oluştur|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Görüntüsü|—|Oluştur|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bit Eşlem Görüntüsü|—|Oluştur|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Geliştirilmiş MetadoS|—|Oluştur|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Ölçeklenebilir Vektör Grafikleri|—|Oluştur|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Yükle ve İçe Aktar**

- **Yükle:** Dosya yolunu ya da bir akışı [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) yapıcısına gönderin. Biçim içerikten algılanır; [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) şifre gibi ayarları sağlar. Bir dosyayı açmadan önce kontrol etmek için [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) çağırın; bu, bir [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/) değeri raporlar. PowerPoint XML için `LoadFormat.Unknown` rapor eder, ancak yapıcı bu dosyayı açar ve ardından [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) `SourceFormat.Xml` döndürür. Bkz. [Sunumları Aç](/slides/tr/net/open-presentation/) ve [Orijinal Sunum Biçimini Belirle](/slides/tr/net/detect-presentation-source-format/).
- **İçe Aktar:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) bir PDF sayfası başına bir slaytı sunumun sonuna ekler. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) HTML'den oluşturulan slaytları ekler ve [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) bunları belirtilen konuma yerleştirir. Presentation yapıcı içe aktarmaz: bir PDF dosyası için [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) hatası verir ve HTML işaretlemesini slayt içeriğine dönüştürmez. Bkz. [PDF veya HTML'den Sunum İçe Aktar](/slides/tr/net/import-presentation/).

## **Kaydet ve Oluştur**

- **Kaydet:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) sunumu bir [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) değeriyle belirtilen biçimde yazar. Bir seçenek nesnesi alan aşırı yüklemeler çıktıyı kontrol eder; örneğin [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), ve [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). Bir dizi slayt konumu (1'den başlayarak) alan aşırı yüklemeler sadece bu slaytları yazar; PDF, XPS, TIFF, HTML, HTML5, SWF, GIF ve Markdown desteklenir, ancak sunum biçimleri ya da PowerPoint XML desteklenmez. XAML için kendi aşırı yüklemesi vardır ve [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/) alır. Bkz. [Sunumları Kaydet](/slides/tr/net/save-presentation/), [Sunumları Dönüştür](/slides/tr/net/convert-presentation/), ve [Sunumları XAML'e Dışa Aktar](/slides/tr/net/export-to-xaml/).
- **Oluştur:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) ve [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) bir [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) döndürür; [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) bu resmi PNG, JPEG, BMP, GIF veya TIFF olarak, bir [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) değeriyle yazar. [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) tüm slaytları ya da seçili slaytları bir kerede oluşturur. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) ve [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) SVG yazar, ve [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) EMF yazar. Bkz. [Slaytları Görüntülere Dönüştür](/slides/tr/net/convert-slide/) ve [Slaytı SVG Görüntüsü Olarak Oluştur](/slides/tr/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}
ImageFormat ayrıca `Emf`, `Wmf`, `Icon`, `Exif` ve `MemoryBmp` değerlerine sahiptir, ancak IImage.Save bu biçimleri üretmez: yazdığı dosya PNG verisi içerir. Bir slaydın EMF görüntüsü için Slide.WriteAsEmf kullanın.
{{% /alert %}}

## **SSS**

**PPT sunumunu PPTX veya ODP'ye dönüştürebilir miyim?**

Evet. PPT dosyasını Presentation yapıcı ile açın ve `SaveFormat.Pptx` ya da `SaveFormat.Odp` ile kaydedin. Bkz. [PPT'yi PPTX'e Dönüştür](/slides/tr/net/convert-ppt-to-pptx/).

**PDF veya HTML dosyasını sunum olarak açabilir miyim?**

Hayır. Bir sunum oluşturun ya da açın, PDF sayfalarını ya da HTML içeriğini yukarıda açıklanan slayt koleksiyonu yöntemleriyle içe aktarın ve ardından istediğiniz desteklenen biçimde kaydedin.

**Dışa aktarılmış PNG veya SVG görüntüsünü düzenlenebilir bir sunum olarak yükleyebilir miyim?**

Hayır. Görüntü çıktısı bir slaydın nasıl göründüğünü kaydeder, metnini, şekillerini veya çizelgelerini kaydetmez. Daha sonra düzenlemeniz gerekirse kaynak sunumu saklayın.

**PDF/A veya PDF/UA belgelerini kaydedebilir miyim?**

Evet. [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) özelliğini bir [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) değeriyle ayarlayın: PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b veya PDF/UA.

**Bir dosyanın şifre korumalı olup olmadığını açmadan önce kontrol edebilir miyim?**

Evet. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) bir dosyayı Presentation nesnesi oluşturmadan inceler ve [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) özelliği şifre gerekip gerekmediğini raporlar. Bkz. [Şifre Koruması ile Sunumlar](/slides/tr/net/password-protected-presentation/).

**İki NuGet paketi farklı biçimleri destekliyor mu?**

Hayır. Aspose.Slides.NET ve Aspose.Slides.NET6.CrossPlatform aynı LoadFormat ve SaveFormat değerlerine ve aynı içe aktarım ve oluşturma yöntemlerine sahiptir. Çalıştıkları platformlar ve bu platformların gereksinimleri farklıdır; bkz. [Kurulum](/slides/tr/net/installation/).