---
title: PHP'de Sunumları Birden Çok Formata Dönüştürme
linktitle: Sunumu Dönüştür
type: docs
weight: 70
url: /tr/php-java/convert-presentation/
keywords:
- sunumu dönüştür
- sunumu dışa aktar
- PPT'den PPTX'e
- PPTX'den PPT'e
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument sunumlarını PPTX, PDF, HTML, görüntüler, XPS, TIFF ve daha fazlasına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, Microsoft PowerPoint, OpenOffice veya LibreOffice olmadan PowerPoint ve OpenDocument sunumlarını yükleyebilir ve birçok başka formata kaydedebilir veya işleyebilir. Eski PPT dosyalarını modern PPTX'e dönüştürebilir, sunumları PDF ve XPS gibi sabit‑düzen belgelerine aktarabilir, slaytları HTML olarak yayımlayabilir veya ön izlemeler, küçük resimler ve arşivler için slaytları görsel dosyalar olarak işleyebilirsiniz.

Çoğu belge dönüşümü aynı genel iş akışını izler: kaynak dosyayı yükle, istenen çıktı formatını seç ve gerektiğinde format‑özel seçenekleri uygula. Görsel formatları için her slayt ayrı ayrı işlenir ve ardından raster ya da vektör görsel olarak kaydedilir. Aşağıdaki bağlantılı makaleler her durum için uygulama ayrıntılarını sunar.

## **Bir Dönüştürme Senaryosu Seçin**

Aşağıdaki makaleleri tam PHP örnekleri ve format‑özel seçenekler için kullanın.

| Senaryo | Şu durumlarda kullanın | Makale |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Eski PPT dosyalarını modernleştirin, mevcut PPTX dosyalarını normalleştirin veya OpenDocument sunumlarını PowerPoint PPTX'e dönüştürün. | [PPT'yi PPTX'e Dönüştür](/slides/tr/php-java/convert-ppt-to-pptx/), [ODP'yi PPTX'e Dönüştür](/slides/tr/php-java/convert-odp-to-pptx/), [Sunumları Kaydet](/slides/tr/php-java/save-presentation/) |
| PPTX to PPT | Modern PowerPoint sunumunu daha eski ikili PPT formatına kaydederek eski iş akışlarıyla uyumluluğu sağlayın. | [PPTX'i PPT'ye Dönüştür](/slides/tr/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Paylaşım, yazdırma veya arşivleme için taşınabilir, aranabilir, sabit‑düzen belgeler oluşturun. | [PowerPoint'i PDF'ye Dönüştür](/slides/tr/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Konuşmacı notlarını slayt içeriğiyle birlikte dışa aktarın. | [PowerPoint'i Notlarla PDF'ye Dönüştür](/slides/tr/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Sunumları HTML sayfaları olarak yayımlayın ve görseller, yazı tipleri, notlar ve duyarlı düzen seçeneklerini kontrol edin. | [PowerPoint'i HTML'ye Dönüştür](/slides/tr/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Biçimlendirme ve etkileşimi koruyarak tarayıcıda görüntülenebilen HTML5'e dışa aktarın. | [Sunumları HTML5'e Dışa Aktar](/slides/tr/php-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Ön izlemeler, küçük resimler veya web çıktısı için her slaytı PNG görsele işleyin. | [PowerPoint'i PNG'ye Dönüştür](/slides/tr/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Slaytları JPG görsellere işleyin ve görsel boyutları ile kalitesini yönetin. | [PowerPoint'i JPG'ye Dönüştür](/slides/tr/php-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Tek tek slaytları ölçeklenebilir vektör grafiği (SVG) olarak dışa aktarın. | [Slaytı SVG Olarak İşle](/slides/tr/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Sabit‑düzen XPS belgeleri oluşturun. | [PowerPoint'i XPS'ye Dönüştür](/slides/tr/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Baskı, tarama, faks veya arşivleme iş akışları için çok sayfalı TIFF dosyası olarak kaydedin. | [PowerPoint'i TIFF'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Konuşmacı notlarıyla birlikte slaytları TIFF olarak kaydedin. | [PowerPoint'i Notlarla TIFF'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Dokümantasyon ve metin‑tabanlı iş akışları için sunum içeriğini Markdown'a çıkartın. | [PowerPoint'i Markdown'a Dönüştür](/slides/tr/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Denetleme, karşılaştırma, sorun giderme veya XML‑tabanlı iş akışları için metin‑tabanlı PowerPoint XML Sunumu oluşturun. | [PowerPoint'i XML'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Slaytlardan animasyonlu GIF oluşturun. | [PowerPoint'i Animasyonlu GIF'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Sunum slaytlarından video dışa aktarma iş akışı oluşturun. | [PowerPoint'i Videoya Dönüştür](/slides/tr/php-java/convert-powerpoint-to-video/) |
| Presentation to XAML | PHP veya Java UI senaryoları için slaytları XAML'e dışa aktarın. | [Sunumları XAML'e Dışa Aktar](/slides/tr/php-java/export-to-xaml/) |

Daha geniş bir giriş ve çıkış formatı listesi için [Desteklenen Dosya Formatları](/slides/tr/php-java/supported-file-formats/) sayfasına bakın.

## **PowerPoint ve OpenDocument Dönüşümü**

Aspose.Slides for PHP via Java, PPT, PPTX, PPS, PPSX, POT, POTX ve ODP gibi yaygın kullanılan sunum formatlarından dönüşümü destekler. Aynı dönüşüm API'si PowerPoint ve OpenDocument dosyaları için kullanılır; bu nedenle bir PPTX dosyasını PDF'ye kaydeden iş akışı, yalnızca giriş dosyasını ODP olarak değiştirerek ODP dosyasına da uygulanabilir.

ODP dosyalarını dönüştürürken, PowerPoint ve OpenDocument uygulamalarının her düzen ve biçimlendirme özelliğini tam olarak aynı şekilde desteklemediğini unutmayın. Bir ODP dosyası LibreOffice veya OpenOffice Impress ile oluşturulmuşsa, çıktıyı gözden geçirin ve format‑özel rehberlik için [OpenDocument Sunumları Dönüştür](/slides/tr/php-java/convert-openoffice-odp/) makalesinde açıklanan seçenekleri kullanın.

## **PPT'den PPTX'e Dönüştürme**

PPT eski ikili PowerPoint formatıdır, PPTX ise modern Office Open XML formatıdır. Aspose.Slides for PHP via Java, master'lar, düzenler, slaytlar, grafikler, gruplanmış şekiller, yer tutucular, metin çerçeveleri, dokular ve resim doldurmaları gibi karmaşık sunum yapılarını koruyarak yüksek doğrulukta PPT'den PPTX'e dönüşümü destekler.

Ayrıntılar için [PPT'yi PPTX'e Dönüştür](/slides/tr/php-java/convert-ppt-to-pptx/) ve [PPT vs PPTX](/slides/tr/php-java/ppt-vs-pptx/) makalelerine bakın.

## **Sabit‑Düzen Dışa Aktarım**

PDF, XPS ve TIFF, çıktının cihazlar arasında aynı görünmesini sağlamak ve bir sunum olarak düzenlenmemesini istendiğinde kullanışlıdır. Ayrı PDF, XPS ve TIFF makaleleri, uyumluluk, gizli slaytlar, notlar, görsel kalitesi, sıkıştırma, piksel formatı ve çıktı boyutu gibi ayarların nasıl kontrol edileceğini açıklar.

## **HTML ve Görsel Dışa Aktarım**

HTML ve HTML5 dışa aktarım, tarayıcı görüntüleme, web yayını ve hafif paylaşım için uygundur. Görsel dışa aktarım, her slaytın ayrı bir ön izleme, küçük resim veya raster varlık haline gelmesi gerektiğinde faydalıdır. Format‑özel işleme rehberi için PNG, JPG ve SVG makalelerini kullanın.

## **SSS**

**Sunumları dönüştürmek için Microsoft PowerPoint gerekir mi?**

Hayır. Aspose.Slides for PHP via Java bağımsız bir kütüphanedir ve Microsoft PowerPoint ya da Office otomasyonuna ihtiyaç duymaz.

**Birçok sunumu toplu olarak dönüştürebilir miyim?**

Evet. Her sunumu yükleyin, gereken formata kaydedin ve işlem sonrası sunum nesnesini serbest bırakın. Paralel işleme için ayrı sunum örnekleri kullanın ve [çoklu iş parçacığı](/slides/tr/php-java/multithreading/) yönergelerini izleyin.

**Yalnızca seçili slaytları dışa aktarabilir miyim?**

Evet. Çıktı formatına bağlı olarak slayt indekslerini iletebilir veya tek tek slaytları işleyebilirsiniz. Hedef format için ayrılmış makaleye bakın.

**PDF veya XPS'e dışa aktarırken gizli slaytları dahil edebilir miyim?**

Evet. Gizli‑slayt dışa aktarma ayarları, [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/) ve [XPS](/slides/tr/php-java/convert-powerpoint-to-xps/) dönüşüm makalelerinde açıklanmıştır.

**PDF/A çıktısı oluşturabilir miyim?**

Evet. PDF dışa aktarımında uyumluluk ayarları mevcuttur. Ayrıntılar için [PowerPoint'i PDF'ye Dönüştür](/slides/tr/php-java/convert-powerpoint-to-pdf/) sayfasına bakın.

**Dönüştürme sırasında yazı tipleri nasıl işlenir?**

Aspose.Slides, gömülü yazı tipleri, yazı tipi geri dönüşü ve yazı tipi ikamesi ayarlarını kullanabilir. Ayrıntılar için [Gömülü Yazı Tipi](/slides/tr/php-java/embedded-font/), [Geri Dönüş Yazı Tipi](/slides/tr/php-java/fallback-font/) ve [Yazı Tipi İkamesi](/slides/tr/php-java/font-substitution/) makalelerine göz atın.