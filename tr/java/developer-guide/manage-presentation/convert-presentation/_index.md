---
title: Java'da Sunumları Çoklu Formatlara Dönüştür
linktitle: Sunumu Dönüştür
type: docs
weight: 70
url: /tr/java/convert-presentation/
keywords:
- sunumu dönüştür
- sunumu dışa aktar
- PPT'den PPTX'e
- PPTX'ten PPT'ye
- ODP'den PPTX'e
- PPT'den PDF'e
- PPTX'ten PDF'e
- ODP'den PDF'e
- PPT'den HTML'e
- PPTX'ten HTML'e
- ODP'den HTML'e
- PPT'den PNG'e
- PPTX'ten PNG'e
- ODP'den PNG'e
- PPTX'ten JPG'e
- ODP'den JPG'e
- PPT'den XPS'e
- PPTX'ten XPS'e
- ODP'den XPS'e
- PPT'den TIFF'e
- PPTX'ten TIFF'e
- ODP'den TIFF'e
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument sunumlarını PPTX, PDF, HTML, görüntüler, XPS, TIFF ve daha fazlasına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for Java, PowerPoint ve OpenDocument sunumlarını yükleyebilir ve Microsoft PowerPoint, OpenOffice veya LibreOffice olmadan birçok başka formata kaydedebilir veya oluşturabilir. Eski PPT dosyalarını modern PPTX formatına dönüştürebilir, sunumları PDF ve XPS gibi sabit sayfa düzeni belgelerine dışa aktarabilir, slaytları HTML olarak yayımlayabilir veya slaytları önizlemeler, küçük resimler ve arşivler için görüntü dosyaları olarak oluşturabilirsiniz.

Çoğu belge dönüşümü aynı genel iş akışını kullanır: kaynak dosyayı yükleyin, gereken çıktı formatını seçin ve ihtiyaç duyulduğunda format‑specific seçenekleri uygulayın. Görüntü formatları için her slayt ayrı ayrı işlenir ve ardından raster veya vektör görüntü olarak kaydedilir. Aşağıda bağlantı verilen özel makaleler her durum için uygulama detaylarını sunar.

## **Bir Dönüşüm Senaryosu Seçin**

Aşağıdaki makaleleri, tam Java örnekleri ve format‑specific seçenekler için kullanın.

| Senaryo | İhtiyacınız olduğunda | Makale |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Eski PPT dosyalarını modernize edin, mevcut PPTX dosyalarını normalleştirin veya OpenDocument sunumlarını PowerPoint PPTX'e dönüştürün. | [Convert PPT to PPTX](/slides/tr/java/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/tr/java/convert-odp-to-pptx/), [Save Presentations](/slides/tr/java/save-presentation/) |
| PPTX to PPT | Modern bir PowerPoint sunumunu, eski ikili PPT formatına kaydederek eski iş akışlarıyla uyumluluğu sağlayın. | [Convert PPTX to PPT](/slides/tr/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Paylaşım, baskı veya arşivleme için taşınabilir, aranabilir, sabit‑sayfa düzeni belgeleri oluşturun. | [Convert PowerPoint to PDF](/slides/tr/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Sunucu notlarını slayt içeriğiyle birlikte dışa aktarın. | [Convert PowerPoint to PDF with Notes](/slides/tr/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Sunumları HTML sayfaları olarak yayımlayın ve görüntüler, yazı tipleri, notlar ve duyarlı düzen seçeneklerini kontrol edin. | [Convert PowerPoint to HTML](/slides/tr/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Slaytları, biçimlendirme ve etkileşim korunarak tarayıcı tabanlı görüntüleme için HTML5'e dışa aktarın. | [Convert Presentations to HTML5](/slides/tr/java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Her slaytı önizleme, küçük resim veya web çıktısı için PNG görüntüsüne dönüştürün. | [Convert PowerPoint to PNG](/slides/tr/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Slaytları JPG görüntülerine dönüştürün ve görüntü boyutları ile kalitesini kontrol edin. | [Convert PowerPoint to JPG](/slides/tr/java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Tek tek slaytları ölçeklenebilir vektör grafikleri olarak dışa aktarın. | [Render Slide as SVG](/slides/tr/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Sabit‑sayfa düzeni XPS belgeleri oluşturun. | [Convert PowerPoint to XPS](/slides/tr/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Sunumu, baskı, tarama, faks veya arşiv iş akışları için çok sayfalı TIFF dosyası olarak kaydedin. | [Convert PowerPoint to TIFF](/slides/tr/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Slaytları, konuşmacı notlarıyla birlikte TIFF olarak kaydedin. | [Convert PowerPoint to TIFF with Notes](/slides/tr/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Belge‑stili çıktı gerektiğinde slaytları Word belgesine dönüştürün. | [Convert PowerPoint to Word](/slides/tr/java/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Sunum içeriğini dokümantasyon ve metin‑tabanlı iş akışları için Markdown olarak çıkarın. | [Convert PowerPoint to Markdown](/slides/tr/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Slaytlardan animasyonlu GIF oluşturun. | [Convert PowerPoint to Animated GIF](/slides/tr/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Sunum slaytlarından video dışa aktarım iş akışı oluşturun. | [Convert PowerPoint to Video](/slides/tr/java/convert-powerpoint-to-video/) |
| Presentation to XAML | Slaytları, Java UI senaryoları için XAML olarak dışa aktarın. | [Export Presentations to XAML](/slides/tr/java/export-to-xaml/) |

Giriş ve çıkış formatlarının daha geniş bir listesi için, [Supported File Formats](/slides/tr/java/supported-file-formats/) sayfasına bakın.

## **PowerPoint ve OpenDocument Dönüşümü**

Aspose.Slides for Java, PPT, PPTX, PPS, PPSX, POT, POTX ve ODP gibi yaygın kullanılan sunum formatlarından dönüşümü destekler. Aynı dönüşüm API'si PowerPoint ve OpenDocument dosyaları için kullanılır; bu yüzden bir PPTX dosyasını PDF'ye kaydeden iş akışı, sadece girdi dosyasını değiştirerek genellikle bir ODP dosyasına da uygulanabilir.

ODP dosyalarını dönüştürürken, PowerPoint ve OpenDocument uygulamalarının her düzen ve biçimlendirme özelliğini aynı şekilde desteklemediğini unutmayın. Bir ODP dosyası LibreOffice veya OpenOffice Impress'te oluşturulmuşsa, çıktıyı gözden geçirin ve format‑specific rehbere ihtiyacınız olduğunda [Convert OpenDocument Presentations](/slides/tr/java/convert-openoffice-odp/) makalesinde açıklanan seçenekleri kullanın.

## **PPT'den PPTX'e Dönüşüm**

PPT, eski ikili PowerPoint formatıdır, PPTX ise modern Office Open XML formatıdır. Aspose.Slides for Java, masterlar, düzenler, slaytlar, grafikler, gruplanmış şekiller, placeholder'lar, metin çerçeveleri, dokular ve resim dolguları gibi karmaşık sunum yapılarını koruyarak yüksek doğrulukta PPT'den PPTX'e dönüşümü destekler.

Ayrıntılar için [Convert PPT to PPTX](/slides/tr/java/convert-ppt-to-pptx/) ve [PPT vs PPTX](/slides/tr/java/ppt-vs-pptx/) sayfalarına bakın.

## **Sabit‑Sayfa Dışa Aktarım**

PDF, XPS ve TIFF, çıktının cihazlar arasında aynı görünmesi ve bir sunum olarak düzenlenmemesi gerektiğinde faydalıdır. Özel PDF, XPS ve TIFF makaleleri, uyumluluk, gizli slaytlar, notlar, görüntü kalitesi, sıkıştırma, piksel formatı ve çıktı boyutunu nasıl kontrol edeceğinizi açıklar.

## **HTML ve Görüntü Dışa Aktarımı**

HTML ve HTML5 dışa aktarım, tarayıcıda görüntüleme, web yayını ve hafif paylaşım için faydalıdır. Görüntü dışa aktarımı, her slaytın ayrı bir önizleme, küçük resim veya raster varlık olmasını gerektirdiğinde kullanışlıdır. Format‑specific render rehberi için PNG, JPG ve SVG makalelerini kullanın.

## **SSS**

**Sunumları dönüştürmek için Microsoft PowerPoint gerekli mi?**

Hayır. Aspose.Slides for Java bağımsız bir kütüphanedir ve Microsoft PowerPoint ya da Office otomasyonuna ihtiyaç duymaz.

**Birçok sunumu toplu olarak dönüştürebilir miyim?**

Evet. Her sunumu yükleyin, gerekli formata kaydedin ve işlem sonrası sunum nesnesini serbest bırakın. Paralel işleme için ayrı sunum örnekleri kullanın ve [multithreading](/slides/tr/java/multithreading/) rehberindeki yönergeleri izleyin.

**Sadece seçili slaytları dışa aktarabilir miyim?**

Evet. Çıktı formatına bağlı olarak, birkaç dışa aktarım yöntemi slayt indekslerini geçirmenize veya tek tek slaytları oluşturmanıza izin verir. Hedef format için özel makaleye bakın.

**PDF veya XPS'ye dışa aktarırken gizli slaytları dahil edebilir miyim?**

Evet. [PDF](/slides/tr/java/convert-powerpoint-to-pdf/) ve [XPS](/slides/tr/java/convert-powerpoint-to-xps/) dönüşüm makalelerinde tanımlanan gizli slayt dışa aktarım ayarlarını kullanın.

**PDF/A çıktısı oluşturabilir miyim?**

Evet. PDF dışa aktarımında PDF uyumluluk ayarları mevcuttur. Ayrıntılar için [Convert PowerPoint to PDF](/slides/tr/java/convert-powerpoint-to-pdf/) sayfasına bakın.

**Dönüşüm sırasında yazı tipleri nasıl ele alınır?**

Aspose.Slides, gömülü yazı tiplerini, yedek yazı tiplerini ve yazı tipi ikame ayarlarını kullanabilir. Ayrıntılar için [Embedded Font](/slides/tr/java/embedded-font/), [Fallback Font](/slides/tr/java/fallback-font/) ve [Font Substitution](/slides/tr/java/font-substitution/) sayfalarına bakın.