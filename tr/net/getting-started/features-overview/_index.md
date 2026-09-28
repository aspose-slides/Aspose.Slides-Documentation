---
title: Özellikler Genel Bakışı
type: docs
weight: 94
url: /tr/net/features-overview/
keywords:
- özellikler
- desteklenen platformlar
- dosya biçimleri
- dönüşüm
- renderleme
- sunum içeriği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in neleri kapsadığını değerlendirmeden önce gözden geçirin: desteklenen platformlar, dosya biçimleri, slayt renderleme ve oluşturup düzenleyebileceğiniz içerik."
---
## **Genel Bakış**

Aspose.Slides for .NET, PowerPoint ve OpenDocument sunumlarını oluşturmak, okumak, düzenlemek, dönüştürmek ve render etmek için bir sınıf kitaplığıdır. Kendi kullanıcı arayüzüne sahip değildir ve Microsoft PowerPoint ya da Office gerektirmez, bu yüzden konsol uygulamalarında, Windows Forms gibi masaüstü uygulamalarında, web uygulamalarında ve web servislerinde kullanabilirsiniz. Bu makale, kütüphanenin neler kapsadığını özetler ve her alanı açıklayan makalelere bağlantılar sağlar.

## **Desteklenen Platformlar**

Aspose.Slides for .NET, aynı API'ye sahip iki NuGet paketi olarak dağıtılır:

|**Paket**|**Paketteki Derlemeler**|**İşletim Sistemleri**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0 ve .NET 6. .NET Framework 4.6.2 veya daha yeni bir sürümle, ya da .NET 6 veya daha yeni bir sürümle kullanabilirsiniz.|Windows. `libgdiplus` kütüphanesi ve `System.Drawing.EnableUnixSupport` anahtarıyla Linux ve macOS.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. .NET 6 veya daha yeni bir sürümle kullanabilirsiniz.|Windows (x86, x64), Linux (x64 ve glibc 2.23 veya daha yeni, ARM64 ve glibc 2.39 veya daha yeni), ve macOS (x64, ARM64).|

[Kurulum](/slides/tr/net/installation/) hangi paketin seçileceğini ve her birinin Linux'ta neye ihtiyacı olduğunu açıklar. [Sistem Gereksinimleri](/slides/tr/net/system-requirements/) desteklenen platformları ayrıntılı olarak listeler.

## **Dosya Biçimleri ve Dönüşümler**

Aspose.Slides, PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP ve PowerPoint XML sunumlarını açar ve kaydeder. PDF ve HTML içeriğini slaytlara aktarır ve sunumları PDF, XPS, HTML, HTML5, TIFF, animasyonlu GIF, SWF, Markdown ve XAML olarak kaydeder. [Desteklenen Dosya Biçimleri](/slides/tr/net/supported-file-formats/) her formatı, onu okuyan veya yazan API ile listeler.

|**Özellik**|**Açıklama**|
| :- | :- |
|[PPT ve PPTX](/slides/tr/net/ppt-vs-pptx/)|Hem ikili PowerPoint 97-2003 formatını hem de Office Open XML formatını okuyup yazabilir.|
|[PPT'den PPTX dönüşümü](/slides/tr/net/convert-ppt-to-pptx/)|Eski PPT sunumlarını PPTX'e dönüştürür.|
|[Taşınabilir Belge Biçimi (PDF)](/slides/tr/net/convert-powerpoint-to-pdf/)|Sunumları PDF'ye, PDF/A ve PDF/UA belgeleri dahil olmak üzere dışa aktarır.|
|[XML Kağıt Spesifikasyonu (XPS)](/slides/tr/net/convert-powerpoint-to-xps/)|Sunumları XPS belgelerine dışa aktarır.|
|[Etiketli Görüntü Dosyası Biçimi (TIFF)](/slides/tr/net/convert-powerpoint-to-tiff/)|Sunumları TIFF görüntülerine dışa aktarır.|
|[HTML](/slides/tr/net/convert-powerpoint-to-html/)|Sunumları HTML ve HTML5'e dışa aktarır.|
|[PDF ve HTML içe aktarımı](/slides/tr/net/import-presentation/)|PDF sayfalarından ve HTML içeriğinden slaytlar oluşturur.|

## **Sunum Görüntüleme**

Aspose.Slides, slaytları ve tek tek şekilleri PNG, JPEG, BMP, GIF, TIFF ve SVG görüntüleri olarak ve slaytları EMF metafile olarak render eder. Bakınız [Sunum Slaytlarını Görsellere Dönüştür](/slides/tr/net/convert-slide/), [Bir Slaytı SVG Görseli Olarak Render Et](/slides/tr/net/render-a-slide-as-an-svg-image/), ve [Şekil Küçük Resimleri Oluştur](/slides/tr/net/create-shape-thumbnails/).

## **İçerik Özellikleri**

Aspose.Slides, bir sunumun neredeyse tüm içeriğini oluşturmanıza, okumanıza ve değiştirmenize olanak tanır:

|**Alan**|**Yapabilecekleriniz**|
| :- | :- |
|[Slaytlar](/slides/tr/net/presentation-slide/)|Slayt ekle, kopyala, yeniden sırala ve sil; düzen ve ana temaları uygula; slaytları bölümlere organize et; slayt boyutunu değiştir.|
|[Tasarım](/slides/tr/net/presentation-design/)|Arka planları, tema renklerini, üstbilgi ve altbilgileri ve yazı tiplerini ayarla.|
|[Metin](/slides/tr/net/manage-text/)|Metin çerçeveleri, paragraflar ve bölümler oluştur ve düzenle; yazı tiplerini, renkleri, madde işaretlerini ve hizalamayı ayarla; metni bul ve değiştir.|
|[Şekiller](/slides/tr/net/powerpoint-shapes/)|AutoShape'ler, çizgiler, bağlayıcılar, grup şekilleri ve resim çerçeveleri oluştur; konum, boyut, çizgi ve düz, degradeli ya da desen dolgusu ayarla; bir şekli alternatif metniyle bul.|
|[Tablolar](/slides/tr/net/powerpoint-table/), [grafikler](/slides/tr/net/powerpoint-charts/), ve [SmartArt](/slides/tr/net/powerpoint-smartart/)|Tablolar, Microsoft Office grafikleri ve SmartArt diyagramları oluştur ve düzenle.|
|[Medya](/slides/tr/net/manage-media-files/), [OLE nesneleri](/slides/tr/net/manage-ole/), ve [ActiveX denetimleri](/slides/tr/net/activex/)|Gömülü veya bağlanmış ses ve video çerçeveleri ekle, OLE nesnelerini göm, ve ActiveX denetimlerini ekle, değiştir veya kaldır.|
|[Notlar](/slides/tr/net/presentation-notes/) ve [yorumlar](/slides/tr/net/presentation-comments/)|Sunum notları ve inceleme yorumları ekle, oku ve düzenle.|
|[Animasyon](/slides/tr/net/powerpoint-animation/) ve [geçişler](/slides/tr/net/slide-transition/)|Şekillere animasyon efektleri uygula, slayt geçişlerini ayarla ve slayt gösterisi ayarlarını yapılandır.|
|[Güvenlik](/slides/tr/net/presentation-security/)|Sunumları şifreyle şifrele, yazma koruması ayarla ve dijital imzalarla çalış.|
|[VBA makroları](/slides/tr/net/presentation-via-vba/)|Makro etkin sunumlarda VBA modüllerini ekle, çıkar ve kaldır.|
|[Özellikler](/slides/tr/net/presentation-properties/)|Belge özelliklerini oku ve düzenle.|

## **SSS**

**Kütüphanenin çalışması için sunucu ya da PC'ye Microsoft PowerPoint kurmam gerekir mi?**

Hayır. PowerPoint gerekli değildir; Aspose.Slides, sunumları oluşturmak, düzenlemek, dönüştürmek ve render etmek için bağımsız bir motor sağlar.

**Çok iş parçacığı (multithreading) nasıl çalışır? İşlem paralelleştirilebilir mi?**

Farklı belgeleri farklı iş parçacıklarında işlemek güvenlidir; aynı [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) nesnesi aynı anda [çoklu iş parçacıkları](/slides/tr/net/multithreading/) tarafından kullanılmamalıdır.

**Dosya şifreleri ve şifreleme destekleniyor mu?**

Evet. [Bunu yapabilirsiniz](/slides/tr/net/password-protected-presentation/) şifreli sunumları açabilir, açma ve yazma şifresi ayarlayabilir veya kaldırabilir ve koruma durumunu kontrol edebilirsiniz.

**Linux konteynerlerinde yazı tiplerine (font) dikkat etmem gerekir mi?**

Evet. Sunumlarınızda kullanılan yazı tipleri veya uygun alternatifleri, metnin doğru görüntülenebilmesi için sistemde yüklü olmalıdır. Ayrıca uygulamanızda [yazı tipi dizinlerini belirtebilir](/slides/tr/net/custom-font/) irsiniz. [Kurulum](/slides/tr/net/installation/) her paketin Linux önkoşullarını listeler.

**Değerlendirme sürümünde sınırlamalar var mı?**

Evet. Bir [lisans](/slides/tr/net/licensing/) olmadan, Aspose.Slides kaydettiği her slayta bir değerlendirme filigranı ekler ve sunumlardan okunan metni kısaltır. Tam özellikli test için bir [30 günlük geçici lisans](https://purchase.aspose.com/temporary-license/) mevcuttur.

**Harici formatların (PDF veya HTML'den PPTX'e) bir sunuma içe aktarılması destekleniyor mu?**

Evet. Bir sunuma [PDF sayfaları ve HTML içeriği](/slides/tr/net/import-presentation/) ekleyebilir, bunları slaytlara dönüştürebilirsiniz.