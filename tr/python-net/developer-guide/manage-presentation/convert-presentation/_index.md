---
title: "Python'da Sunumları Çoklu Formata Dönüştürme"
linktitle: Sunumları Dönüştür
type: docs
weight: 70
url: /tr/python-net/convert-presentation/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarını PPTX, PDF, HTML, görüntüler, XPS, TIFF ve daha fazlasına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, Microsoft PowerPoint, OpenOffice veya LibreOffice kullanmadan PowerPoint ve OpenDocument sunumlarını yükleyebilir ve bunları birçok diğer formata kaydedebilir veya işleyebilir. Eski PPT dosyalarını modern PPTX'e dönüştürebilir, sunumları PDF ve XPS gibi sabit‑düzenli belgelere dışa aktarabilir, slaytları HTML olarak yayınlayabilir veya ön izlemeler, küçük resimler ve arşivler için slaytları görüntü dosyalarına işleyebilirsiniz.

Çoğu belge dönüşümü aynı genel iş akışını izler: kaynak dosyayı yükleyin, istenen çıkış formatını seçin ve gerektiğinde format‑spesifik seçenekleri uygulayın. Görüntü formatları için her slayt ayrı ayrı işlenir ve ardından raster veya vektör görüntüsü olarak kaydedilir. Aşağıdaki ilgili makaleler, her durum için uygulama detaylarını sağlar.

## **Bir Dönüştürme Senaryosu Seçin**

Aşağıdaki makaleleri tam Python örnekleri ve format‑spesifik seçenekler için kullanın.

| Senaryo | Bunu şu zamanlarda kullanın | Makale |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Eski PPT dosyalarını modernize edin, mevcut PPTX dosyalarını normalleştirin veya OpenDocument sunumlarını PowerPoint PPTX'e dönüştürün. | [Convert PPT to PPTX](/slides/tr/python-net/convert-ppt-to-pptx/),[Convert ODP to PPTX](/slides/tr/python-net/convert-odp-to-pptx/),[Save Presentations](/slides/tr/python-net/save-presentation/) |
| PPTX to PPT | Modern bir PowerPoint sunumunu, eski iş akışlarıyla uyumluluk için eski ikili PPT formatına kaydedin. | [Convert PPTX to PPT](/slides/tr/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Paylaşım, yazdırma veya arşivleme için taşınabilir, aranabilir, sabit‑düzenli belgeler oluşturun. | [Convert PowerPoint to PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Sunucu notlarını slayt içeriğiyle birlikte dışa aktarın. | [Convert PowerPoint to PDF with Notes](/slides/tr/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Sunumları HTML sayfaları olarak yayınlayın ve görüntüler, yazı tipleri, notlar ve duyarlı düzen seçeneklerini kontrol edin. | [Convert PowerPoint to HTML](/slides/tr/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Slaytları, biçimlendirme ve etkileşim korunarak tarayıcıda görüntülenmek üzere HTML5'e dışa aktarın. | [Convert Presentations to HTML5](/slides/tr/python-net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Her slaytı önizleme, küçük resim veya web çıktısı için PNG görüntüsüne işleyin. | [Convert PowerPoint to PNG](/slides/tr/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Slaytları JPG görüntülerine işleyin ve görüntü boyutları ile kalitesini kontrol edin. | [Convert PowerPoint to JPG](/slides/tr/python-net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Tek tek slaytları ölçeklenebilir vektör grafik (SVG) olarak dışa aktarın. | [Render Slide as SVG](/slides/tr/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Sabit‑düzenli XPS belgeleri oluşturun. | [Convert PowerPoint to XPS](/slides/tr/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Bir sunumu, yazdırma, tarama, faks veya arşiv iş akışları için çok sayfalı TIFF dosyası olarak kaydedin. | [Convert PowerPoint to TIFF](/slides/tr/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Slaytları konuşmacı notlarıyla birlikte TIFF'e kaydedin. | [Convert PowerPoint to TIFF with Notes](/slides/tr/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP to Word | Belge‑stili çıktı gerektiğinde slaytları Word belgesine dönüştürün. | [Convert PowerPoint to Word](/slides/tr/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP to Markdown | Sunum içeriğini belgeleme ve metin‑tabanlı iş akışları için Markdown'a çıkarın. | [Convert PowerPoint to Markdown](/slides/tr/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | İnceleme, karşılaştırma, sorun giderme veya XML‑tabanlı iş akışları için metin‑tabanlı bir PowerPoint XML Sunumu oluşturun. | [Convert PowerPoint to XML](/slides/tr/python-net/convert-powerpoint-to-xml/) |
| PPT/PPTX/ODP to animated GIF | Slaytlardan hareketli GIF oluşturun. | [Convert PowerPoint to Animated GIF](/slides/tr/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP to video | Sunum slaytlarından bir video dışa aktarım iş akışı oluşturun. | [Convert PowerPoint to Video](/slides/tr/python-net/convert-powerpoint-to-video/) |
| Presentation to XAML | Python veya .NET UI senaryoları için slaytları XAML'e dışa aktarın. | [Export Presentations to XAML](/slides/tr/python-net/export-to-xaml/) |

Daha kapsamlı bir giriş ve çıkış formatları listesi için [Supported File Formats](/slides/tr/python-net/supported-file-formats/) bölümüne bakın.

## **PowerPoint ve OpenDocument Dönüştürme**

Aspose.Slides for Python via .NET, PPT, PPTX, PPS, PPSX, POT, POTX ve ODP gibi yaygın kullanılan sunum formatlarından dönüşüm destekler. Aynı dönüşüm API'si PowerPoint ve OpenDocument dosyaları için kullanıldığı için, bir PPTX dosyasını PDF olarak kaydeden iş akışı, yalnızca giriş dosyasını değiştirerek ODP dosyasına da genellikle uygulanabilir.

ODP dosyalarını dönüştürürken, PowerPoint ve OpenDocument uygulamalarının her düzen ve biçimlendirme özelliğini tam olarak aynı şekilde desteklemediğini unutmayın. Bir ODP dosyası LibreOffice veya OpenOffice Impress'te oluşturulduysa, çıktıyı inceleyin ve format‑spesifik rehberliğe ihtiyaç duyduğunuzda [Convert OpenDocument Presentations](/slides/tr/python-net/convert-openoffice-odp/) bölümünde açıklanan seçenekleri kullanın.

## **PPT'den PPTX'e Dönüştürme**

PPT, eski ikili PowerPoint formatıdır, PPTX ise modern Office Open XML formatıdır. Aspose.Slides for Python via .NET, masterlar, yerleşimler, slaytlar, grafikler, gruplandırılmış şekiller, yer tutucular, metin çerçeveleri, dokular ve resim doldurmalar gibi karmaşık sunum yapılarını koruyarak yüksek doğruluklu PPT'den PPTX'e dönüşümü destekler.

Ayrıntılar için [Convert PPT to PPTX](/slides/tr/python-net/convert-ppt-to-pptx/) ve [PPT vs PPTX](/slides/tr/python-net/ppt-vs-pptx/) bölümlerine bakın.

## **Sabit‑Düzen Dışa Aktarım**

PDF, XPS ve TIFF, çıktının cihazlar arasında aynı görünmesi ve sunum olarak düzenlenmemesi gerektiğinde faydalıdır. Ayrı ayrı PDF, XPS ve TIFF makaleleri, uyumluluk, gizli slaytlar, notlar, görüntü kalitesi, sıkıştırma, piksel formatı ve çıktı boyutunu nasıl kontrol edeceğinizi açıklar.

## **HTML ve Görüntü Dışa Aktarımı**

HTML ve HTML5 dışa aktarma, tarayıcıda görüntüleme, web yayınlama ve hafif paylaşım için yararlıdır. Görüntü dışa aktarma, her slaytın ayrı bir önizleme, küçük resim veya raster varlık olmasını gerektirdiğinde kullanışlıdır. Format‑spesifik işleme kılavuzu için PNG, JPG ve SVG makalelerini kullanın.

## **SSS**

**Sunumları dönüştürmek için Microsoft PowerPoint'e ihtiyacım var mı?**

Hayır. Aspose.Slides for Python via .NET bağımsız bir kütüphanedir ve Microsoft PowerPoint veya Office otomasyonu gerektirmez.

**Birçok sunumu toplu olarak dönüştürebilir miyim?**

Evet. Her bir sunumu yükleyin, gerekli formata kaydedin ve işlemden sonra sunum nesnesini serbest bırakın. Paralel işleme için ayrı sunum örnekleri kullanın ve [multithreading](/slides/tr/python-net/multithreading/) yönergelerini izleyin.

**Sadece seçili slaytları dışa aktarabilir miyim?**

Evet. Çıktı formatına bağlı olarak slayt indekslerini belirtebilen veya tek tek slaytları işleyebilen birden fazla dışa aktarma yöntemi vardır. Hedef format için ilgili makaleye bakın.

**PDF veya XPS'ye dışa aktarırken gizli slaytları dahil edebilir miyim?**

Evet. [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/) ve [XPS](/slides/tr/python-net/convert-powerpoint-to-xps/) dönüşüm makalelerinde açıklanan gizli slayt dışa aktarma ayarlarını kullanın.

**PDF/A çıktısı oluşturabilir miyim?**

Evet. PDF dışa aktarımı için PDF uyumluluk ayarları mevcuttur. Ayrıntılar için [Convert PowerPoint to PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/) bölümüne bakın.

**Dönüşüm sırasında yazı tipleri nasıl işlenir?**

Aspose.Slides, gömülü yazı tipleri, yedek yazı tipleri ve yazı tipi ikame ayarlarını kullanabilir. [Embedded Font](/slides/tr/python-net/embedded-font/), [Fallback Font](/slides/tr/python-net/fallback-font/) ve [Font Substitution](/slides/tr/python-net/font-substitution/) bölümlerine bakın.