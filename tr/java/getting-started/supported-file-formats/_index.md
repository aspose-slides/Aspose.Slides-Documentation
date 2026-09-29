---
title: Desteklenen Dosya Formatları
type: docs
weight: 106
url: /tr/java/supported-file-formats/
keywords:
- desteklenen dosya formatları
- sunum yükle
- PDF içe aktar
- HTML içe aktar
- sunum kaydet
- slaytları işle
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java hangi dosya formatlarını yükleyebileceğini, içe aktarabileceğini, kaydedebileceğini ve işleyebileceğini ve her biri için hangi API'nin okuduğunu veya yazdığını görün."
---
## **Genel Bakış**

Aspose.Slides for Java PowerPoint ve OpenDocument sunumlarını açar ve kaydeder. Ayrıca PDF ve HTML içeriğini slaytlara aktarır, sunumları belge, web ve görüntü formatlarında kaydeder ve tek tek slaytları ve şekilleri görüntü olarak oluşturur. Bu makale, desteklenen her formatı listeler ve onu okuyan ya da yazan API’yi belirtir.

Düzenleme özelliklerinin genel bakışı için, [Özellikler Genel Bakış](/slides/tr/java/features-overview/) bölümüne bakın.

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
- PowerPoint for Microsoft 365 (eski adıyla Office 365)

{{% alert color="info" title="Not" %}}

PowerPoint 95 ve öncesi sürümlerle kaydedilmiş sunumlar açılamaz. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) bir PowerPoint 95 dosyasını tanır ve `LoadFormat.Ppt95` rapor eder, ancak [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) yapıcısı bunun için [PptUnsupportedFormatException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptunsupportedformatexception/) fırlatır.

{{% /alert %}}

## **Desteklenen Dosya Formatları**

Tablo dört işlemi gösterir:

- **Yükle**: [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) yapıcısı dosyayı düzenlenebilir bir sunum olarak açar.
- **İçe Aktar**: bir [SlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/) metodu, dosyanın içeriğinden slaytlar oluşturur ve mevcut bir sunuma ekler. Presentation yapıcısı bu dosyaları slayta dönüştürmez.
- **Kaydet**: [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) sunumu bir dosyaya veya akışa yazar. XAML dışındaki her format bir [SaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) değeriyle seçilir.
- **İşle**: bir işleme metodu bir slaytı veya şekli görüntü olarak çizer. Yalnızca işlenen formatlar SaveFormat değeri değildir.

|**Biçim**|**Açıklama**|**Yükle / İçe Aktar**|**Kaydet / İşle**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97‑2003 Sunumu|Yükle|Kaydet|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97‑2003 Şablonu|Yükle|Kaydet|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97‑2003 Slayt Gösterisi|Yükle|Kaydet|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint Sunumu|Yükle|Kaydet|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint Şablonu|Yükle|Kaydet|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint Slayt Gösterisi|Yükle|Kaydet|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Makro‑Etkin PowerPoint Sunumu|Yükle|Kaydet|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Makro‑Etkin PowerPoint Şablonu|Yükle|Kaydet|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Makro‑Etkin PowerPoint Slayt Gösterisi|Yükle|Kaydet|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument Sunumu|Yükle|Kaydet|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Düz XML OpenDocument Sunumu|Yükle|Kaydet|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument Sunum Şablonu|Yükle|Kaydet|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML Sunumu|Yükle|Kaydet|`SaveFormat.Xml`; yüklü dosyalar `SourceFormat.Xml` rapor eder (bir `LoadFormat` değeri yoktur)|
|[PDF](https://docs.fileformat.com/pdf/)|Taşınabilir Belge Biçimi|İçe Aktar|Kaydet|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hipermetin İşaretleme Dili|İçe Aktar|Kaydet|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Kağıt Özelliği|—|Kaydet|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Etiketli Görüntü Dosyası Biçimi|—|Kaydet, İşle|`SaveFormat.Tiff` (slayt başına bir sayfa); `ImageFormat.Tiff` (tek slayt)|
|[GIF](https://docs.fileformat.com/image/gif/)|Grafik Değişim Biçimi|—|Kaydet, İşle|`SaveFormat.Gif` (animasyonlu, tüm slaytlar); `ImageFormat.Gif` (tek slayt)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Küçük Web Biçimi (Flash)|—|Kaydet|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Kaydet|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Genişletilebilir Uygulama İşaretleme Dili|—|Kaydet|`Presentation.save(IXamlOptions)`, slayt başına bir XAML dosyası; `SaveFormat` değeri yok|
|[PNG](https://docs.fileformat.com/image/png/)|Taşınabilir Ağ Görüntüsü|—|İşle|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Görüntüsü|—|İşle|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Görüntüsü|—|İşle|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Gelişmiş Metafile|—|İşle|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Ölçeklenebilir Vektör Grafiği|—|İşle|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Yükle ve İçe Aktar**

- **Yükle:** Dosya yolunu ya da akışı [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) yapıcısına geçirin. Biçim içerikten algılanır; [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) bir şifre gibi ayarları sağlar. Bir dosyayı açmadan önce kontrol etmek için [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) çağırın; bu bir [LoadFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadformat/) değeri rapor eder. PowerPoint XML için `LoadFormat.Unknown` raporlanır, ancak yapıcı bu dosyayı açar ve ardından [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSourceFormat--) `SourceFormat.Xml` döndürür. Bkz. [Sunumları Aç](/slides/tr/java/open-presentation/) ve [Orijinal Sunum Biçimini Belirle](/slides/tr/java/detect-presentation-source-format/).
- **İçe Aktar:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) bir PDF sayfası başına bir slayt ekler ve sunumun sonuna ekler. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) HTML'den oluşturulan slaytları ekler, ve [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) onları belirtilen konuma yerleştirir. Presentation yapıcısı bu dosyaları içe aktarmaz: bir PDF dosyası için [PptUnsupportedFormatException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptunsupportedformatexception/) fırlatır ve HTML işaretlemesini slayt içeriğine dönüştürmez. Bkz. [PDF veya HTML'den Sunum İçe Aktar](/slides/tr/java/import-presentation/).

## **Kaydet ve İşle**

- **Kaydet:** [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) sunumu bir [SaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) değeriyle belirtilen biçimde yazar. Ayrıca bir seçenek nesnesi alan aşırı yüklemeler çıktıyı kontrol eder; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/), ve [GifOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/gifoptions/). Bir dizi slayt konumu (1'den başlayarak) alan aşırı yüklemeler yalnızca bu slaytları yazar; PDF, XPS, TIFF, HTML, HTML5, SWF, GIF ve Markdown desteklenir, ancak sunum biçimleri ya da PowerPoint XML desteklenmez. XAML’in kendi aşırı yüklemesi vardır: [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) ve bu [IXamlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloptions/) alır. Bkz. [Sunumları Kaydet](/slides/tr/java/save-presentation/), [Sunumları Dönüştür](/slides/tr/java/convert-presentation/), ve [Sunumları XAML Olarak Dışa Aktar](/slides/tr/java/export-to-xaml/).
- **İşle:** [Slide.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#getImage-float-float-) ve [Shape.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getImage--) bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) döndürür ve [IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) PNG, JPEG, BMP, GIF veya TIFF olarak yazar; bu bir [ImageFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imageformat/) değeriyle seçilir. [Presentation.getImages](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) tüm slaytları ya da seçili slaytları bir kerede işler. [Slide.writeAsSvg](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) ve [Shape.writeAsSvg](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) SVG yazar, ve [Slide.writeAsEmf](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) EMF yazar. Bkz. [Slaytları Görüntülere Dönüştür](/slides/tr/java/convert-slide/) ve [Slaytları SVG Görüntüsü Olarak İşle](/slides/tr/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Uyarı" %}}

ImageFormat ayrıca `Emf`, `Wmf`, `Icon`, `Exif` ve `MemoryBmp` değerlerine sahiptir, ancak IImage.save bu formatları üretmez: yazdığı dosya PNG verisi içerir. Bir slaytın EMF görüntüsünü almak için Slide.writeAsEmf kullanın.

{{% /alert %}}

## **SSS**

**Bir PPT sunumunu PPTX ya da ODP’ye dönüştürebilir miyim?**

Evet. PPT dosyasını Presentation yapıcısı ile açın ve `SaveFormat.Pptx` ya da `SaveFormat.Odp` ile kaydedin. Bkz. [PPT’yi PPTX’e Dönüştür](/slides/tr/java/convert-ppt-to-pptx/).

**Bir PDF ya da HTML dosyasını sunum olarak açabilir miyim?**

Hayır. Presentation yapıcısı bir PDF dosyası için PptUnsupportedFormatException fırlatır ve HTML işaretlemesini slaytlara dönüştürmez. Bir sunum oluşturun ya da açın, PDF sayfalarını veya HTML içeriğini yukarıda açıklanan slide collection metodlarıyla içe aktarın ve ardından istediğiniz desteklenen formatta kaydedin.

**Dışa aktarılan bir PNG ya da SVG görüntüsünü düzenlenebilir bir sunum olarak yükleyebilir miyim?**

Hayır. Görüntü çıktısı bir slaytın nasıl göründüğünü kaydeder, metin, şekil ya da grafiğini içermez. Daha sonra düzenlemeniz gerekirse kaynak sunumu saklayın.

**PDF/A ya da PDF/UA belgelerini kaydedebilir miyim?**

Evet. [PdfOptions.setCompliance](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/#setCompliance-int-) metoduna bir [PdfCompliance](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfcompliance/) değeri geçirin: PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b veya PDF/UA.

**Bir dosyanın şifre korumalı olup olmadığını açmadan önce kontrol edebilir miyim?**

Evet. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) bir Presentation nesnesi oluşturmadan dosyayı inceler ve [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) şifre gerektiğini rapor eder. Bkz. [Sunumları Şifreyle Koruma](/slides/tr/java/password-protected-presentation/).