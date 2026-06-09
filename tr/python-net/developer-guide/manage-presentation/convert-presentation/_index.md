---
title: Python'da Sunumları Çoklu Formatta Dönüştürme
linktitle: Sunumları Dönüştür
type: docs
weight: 70
url: /tr/python-net/convert-presentation/
keywords:
- sunum dönüştürme
- sunum dışa aktarım
- PPT'den PPTX'e
- PPTX'den PPT'ye
- ODP'den PPTX'e
- PPT'den PDF'e
- PPTX'den PDF'e
- ODP'den PDF'e
- PPT'den HTML'e
- PPTX'den HTML'e
- ODP'den HTML'e
- PPT'den PNG'e
- PPTX'den PNG'e
- ODP'den PNG'e
- PPTX'den JPG'e
- ODP'den JPG'e
- PPT'den XPS'e
- PPTX'den XPS'e
- ODP'den XPS'e
- PPT'den TIFF'e
- PPTX'den TIFF'e
- ODP'den TIFF'e
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarını PPTX, PDF, HTML, görüntüler, XPS, TIFF ve daha fazlasına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, Microsoft PowerPoint, OpenOffice veya LibreOffice gerektirmeden PowerPoint ve OpenDocument sunumlarını yükleyebilir ve birçok başka formata kaydedebilir veya render edebilir. Eski PPT dosyalarını modern PPTX formatına dönüştürebilir, sunumları PDF ve XPS gibi sabit‑düzen belgelerine dışa aktarabilir, slaytları HTML olarak yayımlayabilir veya önizleme, küçük resim ve arşiv oluşturmak için slaytları görüntü dosyaları olarak render edebilirsiniz.

Çoğu belge dönüşümü aynı genel iş akışını izler: kaynak dosyayı yükleyin, istenen çıkış formatını seçin ve gerektiğinde format‑özel seçenekleri uygulayın. Görüntü formatları için her slayt ayrı ayrı render edilip raster ya da vektör görüntüsü olarak kaydedilir. Aşağıdaki ilgili makaleler her durum için uygulama ayrıntılarını sunar.

## **Bir Dönüştürme Senaryosu Seçin**

Aşağıdaki makaleler tam Python örnekleri ve format‑özel seçenekler içerir.

| Senaryo | Bunu ne zaman kullanmalısınız | Makale |
| --- | --- | --- |
| PPT/PPTX/ODP'dan PPTX'e | Eski PPT dosyalarını modernleştirin, mevcut PPTX dosyalarını normalleştirin veya OpenDocument sunumlarını PowerPoint PPTX formatına dönüştürün. | [PPT'yi PPTX'e Dönüştür](/slides/tr/python-net/convert-ppt-to-pptx/), [ODP'yi PPTX'e Dönüştür](/slides/tr/python-net/convert-odp-to-pptx/), [Sunumları Kaydet](/slides/tr/python-net/save-presentation/) |
| PPTX'den PPT'ye | Modern bir PowerPoint sunumunu eski ikili PPT formatına kaydederek eski iş akışlarıyla uyumluluğu sağlayın. | [PPTX'i PPT'ye Dönüştür](/slides/tr/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP'dan PDF'e | Paylaşım, baskı veya arşivleme için taşınabilir, aranabilir, sabit‑düzen belgeler oluşturun. | [PowerPoint'i PDF'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP'dan notlarla PDF'e | Konuşmacı notlarını slayt içeriğiyle birlikte dışa aktarın. | [PowerPoint'i Notlarla PDF'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP'dan HTML'e | Sunumları HTML sayfaları olarak yayımlayın ve görüntüler, yazı tipleri, notlar ve duyarlı düzen seçeneklerini kontrol edin. | [PowerPoint'i HTML'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP'dan HTML5'e | Biçimlendirme ve etkileşimi korunmuş şekilde tarayıcı tabanlı görüntüleme için slaytları HTML5'e dışa aktarın. | [Sunumları HTML5'e Dışa Aktar](/slides/tr/python-net/export-to-html5/) |
| PPT/PPTX/ODP'dan PNG'e | Önizleme, küçük resim veya web çıktısı için her slaytı PNG görüntüsü olarak render edin. | [PowerPoint'i PNG'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP'dan JPG'e | Slaytları JPG görüntüleri olarak render edin ve görüntü boyutları ile kaliteyi kontrol edin. | [PowerPoint'i JPG'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-jpg/) |
| Slaytı SVG'ye | Tek tek slaytları ölçeklenebilir vektör grafik olarak dışa aktarın. | [Slaytı SVG Olarak Render Et](/slides/tr/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP'dan XPS'e | Sabit‑düzen XPS belgeleri oluşturun. | [PowerPoint'i XPS'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP'dan TIFF'e | Sunumu çok sayfalı TIFF dosyası olarak kaydedin; baskı, tarama, faks veya arşiv iş akışları için uygundur. | [PowerPoint'i TIFF'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP'dan notlarla TIFF'e | Slaytları konuşmacı notlarıyla birlikte TIFF dosyasına kaydedin. | [PowerPoint'i Notlarla TIFF'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP'dan Word'e | Belge‑stilinde çıktı gerektiğinde slaytları Word belgesine dönüştürün. | [PowerPoint'i Word'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP'dan Markdown'a | Sunum içeriğini dokümantasyon ve metin‑tabanlı iş akışları için Markdown formatına aktarın. | [PowerPoint'i Markdown'a Dönüştür](/slides/tr/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP'dan animasyonlu GIF'e | Slaytlardan animasyonlu GIF oluşturun. | [PowerPoint'i Animasyonlu GIF'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP'dan videoya | Sunum slaytlarından video dışa aktarım iş akışı oluşturun. | [PowerPoint'i Videoya Dönüştür](/slides/tr/python-net/convert-powerpoint-to-video/) |
| Sunumu XAML'e | Python veya .NET UI senaryoları için slaytları XAML olarak dışa aktarın. | [Sunumları XAML'e Dışa Aktar](/slides/tr/python-net/export-to-xaml/) |

Daha geniş bir giriş ve çıkış formatı listesi için [Desteklenen Dosya Biçimleri](/slides/tr/python-net/supported-file-formats/) bölümüne bakın.

## **PowerPoint ve OpenDocument Dönüştürme**

Aspose.Slides for Python via .NET, PPT, PPTX, PPS, PPSX, POT, POTX ve ODP gibi yaygın kullanılan sunum formatlarından dönüşümü destekler. PowerPoint ve OpenDocument dosyaları aynı dönüşüm API'si ile işlenir; bu yüzden bir PPTX dosyasını PDF'ye kaydeden iş akışı, yalnızca giriş dosyasını ODP olarak değiştirerek ODP dosyası için de uygulanabilir.

ODP dosyalarını dönüştürürken, PowerPoint ve OpenDocument uygulamalarının her düzen ve biçimlendirme özelliğini aynı şekilde desteklemediğini unutmayın. ODP dosyası LibreOffice veya OpenOffice Impress ile oluşturulmuşsa, çıktıyı gözden geçirin ve format‑özel rehberlik için [OpenDocument Sunumlarını Dönüştür](/slides/tr/python-net/convert-openoffice-odp/) bölümündeki seçenekleri kullanın.

## **PPT'den PPTX'e Dönüştürme**

PPT, eski ikili PowerPoint formatıdır; PPTX ise modern Office Open XML formatıdır. Aspose.Slides for Python via .NET, karmaşık sunum yapıları (master'lar, düzenler, slaytlar, grafikler, gruplandırılmış şekiller, yer tutucular, metin çerçeveleri, dokular ve resim dolguları) korunarak yüksek sadakatli PPT'den PPTX'e dönüşümü destekler.

Ayrıntılar için [PPT'yi PPTX'e Dönüştür](/slides/tr/python-net/convert-ppt-to-pptx/) ve [PPT vs PPTX](/slides/tr/python-net/ppt-vs-pptx/) bölümlerine bakın.

## **Sabit‑Düzen Dışa Aktarma**

PDF, XPS ve TIFF, çıktının cihazlar arasında aynı görünmesini ve bir sunum olarak düzenlenmemesini istediğiniz durumlarda faydalıdır. Özel PDF, XPS ve TIFF makaleleri, uyumluluk, gizli slaytlar, notlar, görüntü kalitesi, sıkıştırma, piksel formatı ve çıktı boyutu kontrolünü açıklar.

## **HTML ve Görüntü Dışa Aktarma**

HTML ve HTML5 dışa aktarma, tarayıcı görüntüleme, web yayımlama ve hafif paylaşım için uygundur. Görüntü dışa aktarma, her slaytın ayrı bir önizleme, küçük resim veya raster varlık haline gelmesi gerektiğinde yararlıdır. PNG, JPG ve SVG makaleleri, format‑özel render kılavuzları sunar.

## **SSS**

**Sunumları dönüştürmek için Microsoft PowerPoint'e ihtiyacım var mı?**

Hayır. Aspose.Slides for Python via .NET, bağımsız bir kütüphanedir ve Microsoft PowerPoint ya da Office otomasyonuna ihtiyaç duymaz.

**Birçok sunumu toplu olarak dönüştürebilir miyim?**

Evet. Her sunumu yükleyin, gerekli formata kaydedin ve işleme sonrası sunum nesnesini serbest bırakın. Paralel işleme için ayrı sunum örnekleri kullanın ve [çoklu iş parçacığı](/slides/tr/python-net/multithreading/) yönergelerini izleyin.

**Yalnızca seçili slaytları dışa aktarabilir miyim?**

Evet. Çıktı formatına bağlı olarak slayt indekslerini geçirerek veya tek tek slaytları render ederek çeşitli dışa aktarma yöntemleri mevcuttur. Hedef format için özel makaleye bakın.

**PDF ya da XPS'e dışa aktarırken gizli slaytları dahil edebilir miyim?**

Evet. Gizli‑slayt dışa aktarma ayarları [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/) ve [XPS](/slides/tr/python-net/convert-powerpoint-to-xps/) dönüşüm makalelerinde açıklanmıştır.

**PDF/A çıktısı oluşturabilir miyim?**

Evet. PDF dışa aktarımı için uyumluluk ayarları bulunur. Ayrıntılar için [PowerPoint'i PDF'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-pdf/) bölümüne bakın.

**Dönüştürme sırasında yazı tipleri nasıl ele alınır?**

Aspose.Slides, gömülü yazı tiplerini, yedek (fallback) yazı tiplerini ve yazı tipi ikamesi ayarlarını kullanabilir. Ayrıntılar için [Gömülü Yazı Tipi](/slides/tr/python-net/embedded-font/), [Yedek Yazı Tipi](/slides/tr/python-net/fallback-font/) ve [Yazı Tipi İkamesi](/slides/tr/python-net/font-substitution/) bölümlerine göz atın.