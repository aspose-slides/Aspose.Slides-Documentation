---
title: Özellikler Genel Bakış
type: docs
weight: 20
url: /tr/python-net/features-overview/
keywords:
- özellikler
- desteklenen platformlar
- dosya formatı
- dönüşüm
- işleme
- biçimlendirme
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'ı keşfedin: PowerPoint ve OpenDocument sunumlarını verimli bir şekilde oluşturmak, düzenlemek, otomatikleştirmek ve dönüştürmek için güçlü bir API."
---
## **Desteklenen Platformlar**
Aspose.Slides for Python via .NET'ün kullanılabileceği platformlar Windows x64 veya x86 ve Python 3.5 veya daha yeni bir sürümü yüklü geniş bir Linux dağıtımı yelpazesidir. Hedef Linux platformu için ek gereksinimler şunlardır:
- GCC-6 çalışma zamanı kitaplıkları (veya daha yenileri)
- .NET Core Runtime bağımlılıkları. .NET Core Runtime'ı kendisinin kurulması GEREKMEZ
- Python 3.5-3.7 için: Python'ın `pymalloc` derlemesi gereklidir. `--with-pymalloc` Python derleme seçeneği varsayılan olarak etkindir. Genellikle, Python'ın `pymalloc` derlemesi dosya adının sonunda `m` eki bulunur.
- `libpython` paylaşımlı Python kitaplığı. `--enable-shared` Python derleme seçeneği varsayılan olarak devre dışıdır, bazı Python dağıtımları `libpython` paylaşımlı kitaplığı içermez. Bazı Linux platformları için `libpython` paylaşımlı kitaplığı paket yöneticisiyle kurulabilir, örnek: `sudo apt-get install libpython3.7`. Yaygın sorun, `libpython` kitaplığının standart sistem paylaşımlı kitaplık konumundan farklı bir yere kurulmuş olmasıdır. Bu sorun, Python derlerken alternatif kitaplık yolları ayarlamak için Python derleme seçenekleri kullanılarak ya da `libpython` kitaplığı dosyasına sistemin standart paylaşımlı kitaplık konumunda sembolik bir bağlantı oluşturarak düzeltilebilir. Genellikle, `libpython` paylaşımlı kitaplık dosya adı Python 3.5-3.7 için `libpythonX.Ym.so.1.0`, Python 3.8 ve sonrası için `libpythonX.Y.so.1.0` şeklindedir (örnek: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Daha fazla platform desteği gerekiyorsa, “ikiz kardeş” ürünler Aspose.Slides for .NET veya Aspose.Slides for Java'ı inceleyin.


## **Dosya Biçimleri ve Dönüşümler**
Aspose.Slides for Python via .NET, çoğu PowerPoint belge biçimini destekler. Ayrıca bunları kuruluşların sıkça kullandığı ve birbirleriyle paylaştığı popüler biçimlere dışa aktarmanıza olanak tanır. Aşağıdaki detaylara göz atın:

|**Özellik**|**Açıklama**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/tr/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET, bu sunum belge biçimi için en hızlı işleme performansını sağlar.|
|[PPT'den PPTX'e dönüşüm](/slides/tr/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET, PPT'den PPTX'e dönüşümü destekler.|
|[Taşınabilir Belge Formatı (PDF)](/slides/tr/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Tüm desteklenen dosya biçimlerini tek bir yöntemle Adobe Taşınabilir Belge Formatı (PDF) belgelerine dışa aktarabilirsiniz.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/tr/python-net/convert-powerpoint-to-xps/)|Tüm desteklenen dosya biçimlerini tek bir yöntemle XML Parser Specification (XPS) belgelerine dışa aktarabilirsiniz.|
|[Tagged Image File Format (TIFF)](/slides/tr/python-net/convert-powerpoint-to-tiff/)|Tüm desteklenen sunum dosya biçimlerini Tagged Image File Format (TIFF) olarak dışa aktarabilirsiniz.|
|[PPTX'den HTML Dönüşümü](https://docs.aspose.com/slides/tr/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET, PresentationEx dosyasının HTML formatına dönüştürülmesini destekler.|

## **Sunum İşleme**
Aspose.Slides for Python via .NET, sunum belgelerindeki slaytları yüksek doğrulukta çeşitli grafik biçimlerine işleyebilir. Aşağıdaki detaylara göz atın:

|**Özellik**|**Açıklama**|
| :- | :- |
|.NET Destekli Görüntü Biçimleri|Aspose.Slides for Python via .NET ile tüm .NET destekli grafik biçimleri (TIFF, PNG, BMP, JPEG, GIF ve metafile'lar) üzerine slaytları ve slaytlardaki görüntüleri işleyebilirsiniz.|
|SVG Biçimi|Aspose.Slides for Python via .NET ayrıca sunum slaytlarını Scalable Vector Graphics (SVG) biçimlerine dışa aktarmanıza olanak tanıyan yerleşik yöntemler sağlar.|

## **İçerik Özellikleri**
Aspose.Slides for Python via .NET, sunum belgelerindeki neredeyse tüm öğelere erişmenize, değiştirmenize veya yeni öğeler oluşturmanıza izin verir. Aşağıdaki detaylara göz atın:

|**Özellik**|**Açıklama**|
| :- | :- |
|Ana Slaytlar|Ana slaytlar normal slaytların düzenini tanımlar. Aspose.Slides for Python via .NET, sunum belgelerinin Ana slaytlarına erişmenizi ve bunları değiştirmenizi sağlar.|
|Normal Slaytlar|Aspose.Slides for Python via .NET ile farklı tiplerde yeni slaytlar oluşturabilir; ayrıca sunumlardaki mevcut slaytlara erişebilir ve bunları değiştirebilirsiniz.|
|Slaytların Kopyalanması / Klonlanması|Aspose.Slides for Python via .NET tarafından sağlanan yerleşik yöntemler, bir sunum içinde mevcut slaytları klonlamanıza veya kopyalamanıza olanak tanır. Kopyalanan ve klonlanan slaytları bir sunumdan diğerine de kullanabilirsiniz. Bir slayt, düzenini ana slayttan devraldığından, yerleşik klonlama yöntemleri klonlama sırasında ana slaytı otomatik olarak kopyalar.|
|Slayt Bölümlerinin Yönetimi|Sunum içinde slaytları farklı bölümlerde düzenlemek için yöntemler.|
|Yer tutucular ve Metin Tutucular|Bir slayttaki yer tutuculara ve metin tutucularına erişebilirsiniz. Ayrıca uygun yöntemi kullanarak sıfırdan metin tutucularıyla bir slayt oluşturabilirsiniz.|
|Üstbilgi ve Altbilgi|Aspose.Slides for Python via .NET, slaytlarda üstbilgi/altbilgi yönetimini kolaylaştırır.|
|Slaytlardaki Notlar|Aspose.Slides for Python via .NET ile bir slayta ait notlara erişebilir, bunları değiştirebilir ve yeni notlar ekleyebilirsiniz.|
|Şekil Bulma|Bir şeklin alternatif metnini kullanarak slayttan belirli bir şekli bulabilirsiniz.|
|Arka Planlar|Aspose.Slides for Python via .NET, bir ana slayt ya da normal slayt ile ilişkili arka planlarla çalışmanıza olanak tanır.|
|Metin Kutuları|Metin kutuları sıfırdan oluşturulabilir. Mevcut metin kutularına erişebilir ve orijinal metin biçimini kaybetmeden metinlerini değiştirebilirsiniz.|
|Dikdörtgen Şekiller|Aspose.Slides for Python via .NET ile dikdörtgen şekiller oluşturabilir veya değiştirebilirsiniz.|
|Poliçizgi Şekilleri|Aspose.Slides for Python via .NET ile çoklu çizgi şekilleri oluşturabilir veya değiştirebilirsiniz.|
|Elips Şekilleri|Aspose.Slides for Python via .NET ile elips şekilleri oluşturabilir veya değiştirebilirsiniz.|
|Grup Şekilleri|Aspose.Slides for Python via .NET grup şekillerini destekler.|
|Otomatik Şekiller|Aspose.Slides for Python via .NET otomatik şekilleri destekler.|
|SmartArt|Aspose.Slides for Python via .NET, MS PowerPoint'teki SmartArt şekilleri için destek sağlar.|
|Grafikler|Aspose.Slides for Python via .NET, PowerPoint'teki MSO Grafikler için destek sağlar.|
|Şekil Serileştirme|Aspose.Slides for Python via .NET çok sayıda şekli destekler. Aspose.Slides for Python via .NET bir şekli desteklemediğinde, mevcut bir slayttan o şekli serileştirmenize olanak tanıyan bir serileştirme yöntemi kullanabilirsiniz. Böylece şekli gereksinimlerinize göre daha sonra kullanabilirsiniz.|
|Resim Çerçeveleri|Aspose.Slides for Python via .NET ile resim çerçevelerindeki resimleri yönetebilirsiniz.|
|Ses Çerçeveleri|Aspose.Slides for Python via .NET ile slaytlardaki ses çerçevelerine ses dosyaları bağlayabilir veya gömebilirsiniz.|
|Video Çerçeveleri|Video dosyalarını video çerçevelerinde işleyebilirsiniz. Aspose.Slides for Python via .NET ayrıca bağlanmış ve gömülü videolar için destek sağlar.|
|OLE Çerçevesi|Aspose.Slides for Python via .NET ile OLE çerçevelerindeki OLE Nesnelerini yönetebilirsiniz.|
|Tablolar|Aspose.Slides for Python via .NET, slaytlardaki tabloları destekler.|
|ActiveX Kontrolleri|ActiveX kontrolleri için destek.|
|VBA Makroları|Sunumlar içinde VBA makrolarını yönetmek için destek.|
|Metin Çerçevesi|Herhangi bir şeklin ilişkili metin çerçevesi aracılığıyla metnine erişebilirsiniz.|
|Metin Taraması|Sunum seviyesinde veya slayt seviyesinde yerleşik tarama yöntemleriyle metin tarayabilirsiniz.|
|Animasyonlar|Şekillere animasyonlar uygulayabilirsiniz.|
|Slayt Gösterileri|Aspose.Slides for Python via .NET slayt gösterileri ve slayt geçişlerini destekler.|

## **Biçimlendirme Özellikleri**
Aspose.Slides for Python via .NET ile sunumlardaki slaytların üzerindeki metin ve şekilleri biçimlendirebilirsiniz. Aşağıdaki detaylara göz atın:

|**Özellik**|**Açıklama**|
| :- | :- |
|Metin Biçimlendirme|<p>Aspose.Slides for Python via .NET içinde, şekillerle ilişkili metin çerçeveleri aracılığıyla metinleri yönetebilirsiniz. Böylece metin çerçevelerine bağlı paragraflar ve kısımlar aracılığıyla metinleri biçimlendirebilirsiniz. Bu metin öğeleri Aspose.Slides for Python via .NET ile biçimlendirilebilir.</p><p>- Yazı Tipi</p><p>- Yazı Boyutu</p><p>- Yazı Rengi</p><p>- Yazı Tonları</p><p>- Paragraf Hizalaması</p><p>- Paragraf Madde İşaretleri</p><p>- Paragraf Yönelimi</p>|
|Şekil Biçimlendirme|<p>Aspose.Slides for Python via .NET içinde bir slaytın temel öğesi bir şekildir. Bu şekil öğelerini aşağıdaki özelliklerle biçimlendirebilirsiniz:</p><p>- Konum</p><p>- Boyut</p><p>- Çizgi</p><p>- Dolgu (Pattern, Gradient, Solid dahil)</p><p>- Metin</p><p>- Resim</p>|

## **FAQ**

### Kütüphanenin çalışması için sunucu/PC üzerine Microsoft PowerPoint yüklemem gerekir mi?

Hayır. PowerPoint gerekli değildir; Aspose.Slides, sunumlar oluşturmak, düzenlemek, dönüştürmek ve işlemek için bağımsız bir motor sağlar.

### Çoklu iş parçacığı (multithreading) nasıl çalışıyor? İşlem paralelleştirilebilir mi?

Farklı belgeleri farklı iş parçacıklarında işlemek güvenlidir; aynı [presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi aynı anda [multiple threads](/slides/tr/python-net/multithreading/) tarafından kullanılmamalıdır.

### Dosya parolaları ve şifreleme destekleniyor mu?

Evet. [You can](/slides/tr/python-net/password-protected-presentation/) şifrelenmiş sunumları açabilir, açma ve yazma parolası ekleyebilir veya kaldırabilir ve koruma durumunu kontrol edebilirsiniz.

### Linux konteynerlerinde font paketlerine dikkat etmeli miyim?

Evet. Beklenmedik font ikamelerinden kaçınmak için yaygın font paketlerini kurmanız ve/veya uygulamanızda açıkça [specify font directories](/slides/tr/python-net/custom-font/) belirtmeniz önerilir.

### Değerlendirme sürümünde sınırlamalar var mı?

[Evaluation mode](/slides/tr/python-net/licensing/) içinde çıktı üzerine bir filigran eklenir ve belirli sınırlamalar geçerli olur; tam özellikli testler için bir [30-day temporary license](https://purchase.aspose.com/temporary-license/) mevcuttur.

### Sunuma dış formatların (PDF/HTML → PPTX) aktarılması destekleniyor mu?

Evet. Sunuma [PDF pages and HTML content](/slides/tr/python-net/import-presentation/) ekleyebilir, bunları slaytlara dönüştürebilirsiniz.