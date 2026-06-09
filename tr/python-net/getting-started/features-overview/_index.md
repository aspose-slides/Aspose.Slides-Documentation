---
title: Özellikler Genel Bakışı
type: docs
weight: 20
url: /tr/python-net/features-overview/
keywords:
- özellikler
- desteklenen platformlar
- dosya formatı
- dönüşüm
- renderleme
- yazdırma
- biçimlendirme
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'i keşfedin: PowerPoint ve OpenDocument sunumlarını verimli bir şekilde oluşturmak, düzenlemek, otomatikleştirmek ve dönüştürmek için güçlü bir API."
---
## **Desteklenen Platformlar**
Aspose.Slides for Python via .NET, Windows x64 veya x86 ve Python 3.5 veya daha yeni sürümleri yüklü geniş bir Linux dağıtımı yelpazesinde kullanılabilir. Hedef Linux platformu için ek gereksinimler şunlardır:
- GCC-6 çalışma zamanı kitaplıkları (veya daha yenileri)
- .NET Core Runtime bağımlılıkları. .NET Core Runtime'ı kurmak GEREKMEZ
- Python 3.5-3.7 için: Python'ın `pymalloc` derlemesi gereklidir. `--with-pymalloc` Python derleme seçeneği varsayılan olarak etkindir. Genellikle `pymalloc` derlemesi dosya adında `m` ekiyle işaretlenir.
- `libpython` paylaşımlı Python kitaplığı. `--enable-shared` Python derleme seçeneği varsayılan olarak devre dışıdır, bazı Python dağıtımları `libpython` paylaşımlı kitaplığını içermez. Bazı Linux platformları için `libpython` paylaşımlı kitaplığı paket yöneticisiyle kurulabilir, örneğin: `sudo apt-get install libpython3.7`. Ortak sorun, `libpython` kitaplığının standart sistem konumundan farklı bir yerde kurulu olmasıdır. Bu sorun, Python derleme seçeneklerini kullanarak alternatif kitaplık yolları ayarlayarak ya da `libpython` kitaplık dosyasına sistem standart konumunda sembolik bir bağ oluşturularak düzeltilebilir. Genellikle `libpython` paylaşımlı kitaplık dosya adı Python 3.5-3.7 için `libpythonX.Ym.so.1.0`, Python 3.8 ve sonrası için `libpythonX.Y.so.1.0` şeklindedir (örnek: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Daha fazla platform desteği gerekiyorsa, "ikiz kardeş" ürünler Aspose.Slides for .NET veya Aspose.Slides for Java'ı inceleyin.


## **Dosya Formatları ve Dönüşümler**
Aspose.Slides for Python via .NET, çoğu PowerPoint belge formatını destekler. Ayrıca bunları kuruluşların yaygın olarak kullandığı ve birbirleri arasında değiş tokuş ettiği popüler formatlara dışa aktarmanıza olanak tanır. Aşağıdaki detaylara göz atın:

|**Özellik**|**Açıklama**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/tr/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET, bu sunum belge formatı için en hızlı işleme sağlar.|
|[PPT'den PPTX'e Dönüştürme](/slides/tr/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET, PPT'den PPTX'e dönüşümü destekler.|
|[Taşınabilir Belge Formatı (PDF)](/slides/tr/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Desteklenen tüm dosya formatlarını tek bir yöntemle Adobe Taşınabilir Belge Formatı (PDF) belgelerine dışa aktarabilirsiniz.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/tr/python-net/convert-powerpoint-to-xps/)|Desteklenen tüm dosya formatlarını tek bir yöntemle XML Parser Specification (XPS) belgelerine dışa aktarabilirsiniz.|
|[Tagged Image File Format (TIFF)](/slides/tr/python-net/convert-powerpoint-to-tiff/)|Desteklenen tüm sunum dosya formatlarını Tagged Image File Format (TIFF) biçimine dışa aktarabilirsiniz.|
|[PPTX'den HTML'e Dönüştürme](https://docs.aspose.com/slides/tr/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET, PresentationEx'in HTML formatına dönüştürülmesini destekler.|

## **Renderleme ve Yazdırma**
Aspose.Slides for Python via .NET, sunum belgelerindeki slaytların yüksek doğruluklu renderlenmesini çeşitli grafik formatlarına sağlar. Aşağıdaki detaylara göz atın:

|**Özellik**|**Açıklama**|
| :- | :- |
|.NET Destekli Görüntü Formatları|Aspose.Slides for Python via .NET ile, sunum slaytlarını ve slaytlardaki görüntüleri TIFF, PNG, BMP, JPEG, GIF ve metafile gibi .NET destekli tüm grafik formatlarında renderleyebilirsiniz.|
|SVG Formatı|Aspose.Slides for Python via .NET, sunum slaytlarını Scalable Vector Graphics (SVG) formatlarına dışa aktarmak için yerleşik yöntemler de sağlar.|
|Sunum Yazdırma|Aspose.Slides for Python via .NET'in en yeni sürümleri, farklı seçeneklerle yerleşik yazdırma yöntemleri sunar.|

## **İçerik Özellikleri**
Aspose.Slides for Python via .NET, sunum belgelerinin neredeyse tüm öğelerine veya içeriklerine erişmenize, değiştirmenize veya yeni oluşturmanıza olanak tanır. Aşağıdaki detaylara göz atın:

|**Özellik**|**Açıklama**|
| :- | :- |
|Ana Slaytlar|Ana slaytlar, normal slaytların düzenini tanımlar. Aspose.Slides for Python via .NET, sunum belgelerinin Ana Slaytlarına erişmenize ve bunları değiştirmenize olanak tanır|
|Normal Slaytlar|Aspose.Slides for Python via .NET ile, farklı tiplerde yeni slaytlar oluşturabilir; ayrıca sunumlardaki mevcut slaytlara erişebilir ve bunları değiştirebilirsiniz|
|Slaytları Klonlama / Kopyalama|Aspose.Slides for Python via .NET tarafından sağlanan yerleşik yöntemler, bir sunum içinde mevcut slaytları klonlamanıza veya kopyalamanıza izin verir. Kopyalanan ve klonlanan slaytları bir sunumdan diğerine de kullanabilirsiniz. Bir slayt, düzenini ana slayttan miras aldığından, yerleşik klonlama yöntemleri otomatik olarak ana slaytı da kopyalar|
|Slayt Bölümlerini Yönetme|Bir sunum içinde slaytları farklı bölümlere organize eden yöntemler|
|Yer Tutucular ve Metin Tutucuları|Bir slayttaki yer tutuculara ve metin tutucularına erişebilirsiniz. Ayrıca uygun yöntemi kullanarak sıfırdan metin tutucuları içeren bir slayt oluşturabilirsiniz|
|Üstbilgi ve Altbilgi|Aspose.Slides for Python via .NET, slaytlarda üstbilgi/altbilgi işlemlerini kolaylaştırır|
|Slaytlardaki Notlar|Aspose.Slides for Python via .NET ile, bir slaytla ilişkili notlara erişebilir ve bunları değiştirebilir; ayrıca yeni notlar ekleyebilirsiniz|
|Şekil Bulma|Bir şeklin alternatif metnini kullanarak slayttan belirli bir şekli bulabilirsiniz|
|Arka Planlar|Aspose.Slides for Python via .NET, bir sunumdaki ana veya normal slaytla ilişkili arka planlarla çalışmanıza olanak tanır|
|Metin Kutuları|Metin kutuları sıfırdan oluşturulabilir. Mevcut metin kutularına erişebilirsiniz. Orijinal metin biçimini kaybetmeden metinlerini değiştirebilirsiniz|
|Dikdörtgen Şekiller|Aspose.Slides for Python via .NET ile dikdörtgen şekiller oluşturabilir veya değiştirebilirsiniz|
|Çoklu Çizgi Şekilleri|Aspose.Slides for Python via .NET ile çoklu çizgi şekilleri oluşturabilir veya değiştirebilirsiniz|
|Elips Şekilleri|Aspose.Slides for Python via .NET ile elips şekilleri oluşturabilir veya değiştirebilirsiniz|
|Grup Şekilleri|Aspose.Slides for Python via .NET grup şekillerini destekler|
|Auto Şekiller|Aspose.Slides for Python via .NET auto şekilleri destekler|
|SmartArt|Aspose.Slides for Python via .NET, MS PowerPoint'teki SmartArt şekilleri için destek sağlar|
|Grafikler|Aspose.Slides for Python via .NET, PowerPoint'teki MSO Grafikler için destek sağlar|
|Şekil Serileştirme|Aspose.Slides for Python via .NET, çok sayıda şekli destekler. Aspose.Slides for Python via .NET bir şekli desteklemediğinde, mevcut bir slayttan o şekli serileştirmenizi sağlayan bir serileştirme yöntemi kullanabilirsiniz. Böylece şekli ihtiyacınıza göre daha sonra kullanabilirsiniz|
|Resim Çerçeveleri|Aspose.Slides for Python via .NET ile resim çerçevelerindeki resimleri yönetebilirsiniz|
|Ses Çerçeveleri|Aspose.Slides for Python via .NET ile ses çerçevelerinde ses dosyalarını bağlayabilir veya gömebilirsiniz|
|Video Çerçeveleri|Video dosyalarını video çerçevelerinde yönetebilirsiniz. Aspose.Slides for Python via .NET, bağlanmış ve gömülü videolar için de destek sunar|
|OLE Çerçevesi|Aspose.Slides for Python via .NET ile OLE çerçevelerindeki OLE Nesnelerini yönetebilirsiniz|
|Tablolar|Aspose.Slides for Python via .NET, slaytlardaki tabloları destekler|
|ActiveX Kontrolleri|ActiveX kontrolleri desteği|
|VBA Makroları|Sunumlar içinde VBA makrolarını yönetme desteği|
|Metin Çerçevesi|Herhangi bir şekille ilişkili metin çerçevesi aracılığıyla metne erişebilirsiniz|
|Metin Tarama|Yerleşik tarama yöntemleriyle bir sunumun sunum veya slayt seviyesinde metni tarayabilirsiniz|
|Animasyonlar|Şekiller üzerinde animasyonlar uygulayabilirsiniz|
|Slayt Gösterileri|Aspose.Slides for Python via .NET, slayt gösterileri ve slayt geçişlerini destekler|

## **Biçimlendirme Özellikleri**
Aspose.Slides for Python via .NET ile, sunumlardaki slaytlarda metin ve şekilleri biçimlendirebilirsiniz. Aşağıdaki detaylara göz atın:

|**Özellik**|**Açıklama**|
| :- | :- |
|Metin Biçimlendirme|<p>Aspose.Slides for Python via .NET'te, şekillerle ilişkili metin çerçeveleri aracılığıyla metinleri yönetebilirsiniz. Bu sayede, metin çerçevelerine bağlı paragraflar ve bölümlerle metinleri biçimlendirebilirsiniz. Bu metin öğeleri Aspose.Slides for Python via .NET ile biçimlendirilebilir.</p><p>- Yazı Tipi</p><p>- Yazı Boyutu</p><p>- Yazı Rengi</p><p>- Yazı Gölgeleri</p><p>- Paragraf Hizalaması</p><p>- Paragraf Madde İşaretleri</p><p>- Paragraf Yönlendirmesi</p>|
|Şekil Biçimlendirme|<p>Aspose.Slides for Python via .NET'te, bir slaytın temel öğesi bir şekildir. Bu şekil öğelerini Aspose.Slides for Python via .NET ile biçimlendirebilirsiniz:</p><p>- Konum</p><p>- Boyut</p><p>- Çizgi</p><p>- Dolgu (Desen, Gradyan, Katı)</p><p>- Metin</p><p>- Resim</p>|

## **SSS**

**Kütüphanenin çalışması için sunucu/PC'ye Microsoft PowerPoint yüklemem gerekiyor mu?**

Hayır. PowerPoint gerekli değildir; Aspose.Slides, sunumları oluşturmak, düzenlemek, dönüştürmek ve renderlemek için bağımsız bir motorudur.

**Çok iş parçacığı (multithreading) nasıl çalışır? İşleme paralelleştirilebilir mi?**

Farklı belgeleri farklı iş parçacıklarında işlemek güvenlidir; aynı [sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi aynı anda [birden fazla iş parçacığı](/slides/tr/python-net/multithreading/) tarafından kullanılmamalıdır.

**Dosya şifreleri ve şifreleme destekleniyor mu?**

Evet. [Şifreli sunumları](/slides/tr/python-net/password-protected-presentation/) açabilir, açma ve yazma şifresi belirleyebilir veya kaldırabilir ve koruma durumunu kontrol edebilirsiniz.

**Linux konteynerlerinde font paketlerine dikkat etmem gerekiyor mu?**

Evet. Beklenmeyen yedeklemelerden kaçınmak için ortak font paketlerini kurmanız ve/veya uygulamanızda font dizinlerini açıkça [belirtmeniz](/slides/tr/python-net/custom-font/) önerilir.

**Değerlendirme sürümünde sınırlamalar var mı?**

Değerlendirme modunda [/slides/tr/python-net/licensing/], çıktı üzerine bir filigran eklenir ve belirli sınırlamalar geçerlidir; tam özellikli test için [30 günlük geçici lisans](https://purchase.aspose.com/temporary-license/) mevcuttur.

**Sunuma dış formatları (PDF/HTML → PPTX) aktarmak destekleniyor mu?**

Evet. Sunuma [PDF sayfaları ve HTML içeriği](/slides/tr/python-net/import-presentation/) ekleyebilir, bunları slaytlara dönüştürebilirsiniz.