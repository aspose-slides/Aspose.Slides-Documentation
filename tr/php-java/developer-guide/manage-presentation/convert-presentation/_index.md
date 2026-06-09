---
title: "PHP ile Sunumları Çeşitli Formata Dönüştürme"
linktitle: "Sunumu Dönüştür"
type: docs
weight: 70
url: /tr/php-java/convert-presentation/
keywords:
- "sunumu dönüştür"
- "sunumu dışa aktar"
- "PPT'den PPTX'e"
- "PPTX'ten PPT'ye"
- "ODP'den PPTX'e"
- "PPT'den PDF'e"
- "PPTX'ten PDF'e"
- "ODP'den PDF'e"
- "PPT'den HTML'e"
- "PPTX'ten HTML'e"
- "ODP'den HTML'e"
- "PPT'den PNG'e"
- "PPTX'ten PNG'e"
- "ODP'den PNG'e"
- "PPTX'ten JPG'e"
- "ODP'den JPG'e"
- "PPT'den XPS'e"
- "PPTX'ten XPS'e"
- "ODP'den XPS'e"
- "PPT'den TIFF'e"
- "PPTX'ten TIFF'e"
- "ODP'den TIFF'e"
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint ve OpenDocument sunumlarını PPTX, PDF, HTML, görüntüler, XPS, TIFF ve daha fazlasına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, Microsoft PowerPoint, OpenOffice veya LibreOffice olmadan PowerPoint ve OpenDocument sunumlarını yükleyebilir ve bunları birçok başka formata kaydedebilir veya işleyebilir. Eski PPT dosyalarını modern PPTX'e dönüştürebilir, sunumları PDF ve XPS gibi sabit düzenli belgeler olarak dışa aktarabilir, slaytları HTML olarak yayımlayabilir veya slaytları ön izleme, küçük resim ve arşivler için görüntü dosyaları olarak işleyebilirsiniz.

Çoğu belge dönüştürmesi aynı genel iş akışını kullanır: kaynak dosyayı yükle, gerekli çıkış formatını seç ve gerektiğinde formata özgü seçenekleri uygula. Görüntü formatları için her slayt ayrı ayrı işlenir ve ardından raster ya da vektör görüntü olarak kaydedilir. Aşağıdaki özel makaleler her durum için uygulama ayrıntılarını sunar.

## **Bir Dönüştürme Senaryosu Seçin**

Aşağıdaki makaleleri tam PHP örnekleri ve formata özgü seçenekler için kullanın.

| Senaryo | Ne zaman ihtiyacınız olursa | Makale |
| --- | --- | --- |
| PPT/PPTX/ODP'den PPTX'e | Legacy PPT dosyalarını modernleştirin, mevcut PPTX dosyalarını normalleştirin veya OpenDocument sunumlarını PowerPoint PPTX'e dönüştürün. | [PPT'yi PPTX'e Dönüştür](/slides/tr/php-java/convert-ppt-to-pptx/), [ODP'yi PPTX'e Dönüştür](/slides/tr/php-java/convert-odp-to-pptx/), [Sunumları Kaydet](/slides/tr/php-java/save-presentation/) |
| PPTX'den PPT'ye | Modern bir PowerPoint sunumunu, eski iş akışlarıyla uyumluluk için daha eski ikili PPT formatına kaydedin. | [PPTX'yi PPT'ye Dönüştür](/slides/tr/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP'den PDF'ye | Paylaşım, baskı veya arşivleme için taşınabilir, aranabilir, sabit düzenli belgeler oluşturun. | [PowerPoint'i PDF'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP'den Notlarla PDF'ye | Sunucu notlarını slayt içeriğiyle birlikte dışa aktarın. | [PowerPoint'i Notlarla PDF'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP'den HTML'ye | Sunumları HTML sayfaları olarak yayınlayın ve görüntüler, yazı tipleri, notlar ve duyarlı düzen seçeneklerini kontrol edin. | [PowerPoint'i HTML'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP'den HTML5'e | Slaytları, biçimlendirme ve etkileşim korunarak tarayıcı tabanlı görüntüleme için HTML5'e aktarın. | [Sunumları HTML5'e Dönüştür](/slides/tr/php-java/export-to-html5/) |
| PPT/PPTX/ODP'den PNG'ye | Her slaytı ön izleme, küçük resim veya web çıktısı için PNG görüntüsüne işleyin. | [PowerPoint'i PNG'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP'den JPG'ye | Slaytları JPG görüntülerine işleyin ve görüntü boyutları ile kalitesini kontrol edin. | [PowerPoint'i JPG'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-jpg/) |
| Slaytı SVG'ye | Tek tek slaytları ölçeklenebilir vektör grafikleri olarak dışa aktarın. | [Slaytı SVG Olarak İşle](/slides/tr/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP'den XPS'ye | Sabit düzen XPS belgeleri oluşturun. | [PowerPoint'i XPS'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP'den TIFF'e | Sunumu baskı, tarama, faks veya arşiv iş akışları için çok sayfalı TIFF dosyası olarak kaydedin. | [PowerPoint'i TIFF'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP'den Notlarla TIFF'e | Slaytları konuşmacı notlarıyla birlikte TIFF'e kaydedin. | [PowerPoint'i Notlarla TIFF'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX'den Markdown'a | Sunum içeriğini belgeleme ve metin tabanlı iş akışları için Markdown'a çıkarın. | [PowerPoint'i Markdown'a Dönüştür](/slides/tr/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX'den animasyonlu GIF'e | Slaytlardan animasyonlu GIF oluşturun. | [PowerPoint'i Animasyonlu GIF'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX'den videoya | Sunum slaytlarından video dışa aktarma iş akışı oluşturun. | [PowerPoint'i Videoya Dönüştür](/slides/tr/php-java/convert-powerpoint-to-video/) |
| Sunumu XAML'e | Slaytları PHP veya Java UI senaryoları için XAML'e dışa aktarın. | [Sunumları XAML'e Dışa Aktar](/slides/tr/php-java/export-to-xaml/) |

Daha geniş bir giriş ve çıkış formatları listesi için [Desteklenen Dosya Formatları](/slides/tr/php-java/supported-file-formats/) sayfasına bakın.

## **PowerPoint ve OpenDocument Dönüştürme**

Aspose.Slides for PHP via Java, PPT, PPTX, PPS, PPSX, POT, POTX ve ODP gibi yaygın olarak kullanılan sunum formatlarından dönüşümü destekler. PowerPoint ve OpenDocument dosyaları için aynı dönüşüm API'si kullanılır; bu nedenle bir PPTX dosyasını PDF'ye kaydeden bir iş akışı, yalnızca giriş dosyasını değiştirerek ODP dosyası için de uygulanabilir.

ODP dosyalarını dönüştürürken, PowerPoint ve OpenDocument uygulamalarının her bir düzen ve biçimlendirme özelliğini tam olarak aynı şekilde desteklemediğini unutmayın. ODP dosyası LibreOffice ya da OpenOffice Impress ile oluşturulmuşsa, çıktıyı gözden geçirin ve format‑özel rehberlik gerektiğinde [Convert OpenDocument Presentations](/slides/tr/php-java/convert-openoffice-odp/) bölümündeki seçenekleri kullanın.

## **PPT'den PPTX'e Dönüştürme**

PPT, eski ikili PowerPoint formatıdır; PPTX ise modern Office Open XML formatıdır. Aspose.Slides for PHP via Java, karmaşık sunum yapıları (master'lar, düzenler, slaytlar, grafikler, gruplanmış şekiller, tutucu öğeler, metin çerçeveleri, dokular ve resim dolguları) korunarak yüksek sadakatli PPT'den PPTX'e dönüşümü destekler.

Ayrıntılar için [PPT'yi PPTX'e Dönüştür](/slides/tr/php-java/convert-ppt-to-pptx/) ve [PPT vs PPTX](/slides/tr/php-java/ppt-vs-pptx/) makalelerine bakın.

## **Sabit Düzen Dışa Aktarma**

PDF, XPS ve TIFF, çıktının cihazlar arasında aynı görünmesini sağlamak ve bir sunum olarak düzenlenmemesini istemek gerektiğinde kullanışlıdır. Özel PDF, XPS ve TIFF makaleleri, uyumluluk, gizli slaytlar, notlar, görüntü kalitesi, sıkıştırma, piksel formatı ve çıktı boyutu kontrolünü açıklar.

## **HTML ve Görüntü Dışa Aktarma**

HTML ve HTML5 dışa aktarma, tarayıcı görüntüleme, web yayınlama ve hafif paylaşım için faydalıdır. Görüntü dışa aktarma, her slaytın ayrı bir ön izleme, küçük resim veya raster varlığı olması gerektiğinde kullanılır. Format‑özel işleme yönergeleri için PNG, JPG ve SVG makalelerini inceleyin.

## **SSS**

**Sunumları dönüştürmek için Microsoft PowerPoint gerekir mi?**

Hayır. Aspose.Slides for PHP via Java bağımsız bir kütüphanedir ve Microsoft PowerPoint ya da Office otomasyonuna ihtiyaç duymaz.

**Birçok sunumu toplu olarak dönüştürebilir miyim?**

Evet. Her sunumu yükleyin, istediğiniz formata kaydedin ve işlendikten sonra sunum nesnesini serbest bırakın. Paralel işleme için ayrı sunum örnekleri kullanın ve [multithreading](/slides/tr/php-java/multithreading/) rehberini izleyin.

**Yalnızca seçili slaytları dışa aktarabilir miyim?**

Evet. Çeşitli dışa aktarma yöntemleri, slayt indekslerini geçirmenize veya çıktı formatına bağlı olarak tek tek slaytları işlemenize olanak tanır. Hedef format için özel makaleye bakın.

**PDF veya XPS'e dışa aktarırken gizli slaytları dahil edebilir miyim?**

Evet. Gizli‑slayt dışa aktarma ayarlarını [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/) ve [XPS](/slides/tr/php-java/convert-powerpoint-to-xps/) dönüşüm makalelerinde açıklandığı gibi kullanın.

**PDF/A çıktısı oluşturabilir miyim?**

Evet. PDF dışa aktarma için PDF uyumluluk ayarları mevcuttur. Ayrıntılar için [PowerPoint'i PDF'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-pdf/) sayfasına bakın.

**Dönüştürme sırasında yazı tipleri nasıl ele alınır?**

Aspose.Slides gömülü yazı tiplerini, yedekleme (fallback) ve yazı tipi ikamesi ayarlarını kullanabilir. Ayrıntılar için [Embedded Font](/slides/tr/php-java/embedded-font/), [Fallback Font](/slides/tr/php-java/fallback-font/) ve [Font Substitution](/slides/tr/php-java/font-substitution/) sayfalarına göz atın.