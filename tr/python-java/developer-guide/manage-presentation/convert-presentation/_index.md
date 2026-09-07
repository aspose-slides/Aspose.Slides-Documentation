---
title: Python'da Sunumları Birden Çok Formata Dönüştürme
linktitle: Sunumu Dönüştür
type: docs
weight: 70
url: /tr/python-java/convert-presentation/
keywords:
- sunumu dönüştür
- sunumu dışa aktar
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint ve OpenDocument sunumlarını PPTX, PDF, HTML, görüntüler, XPS, TIFF ve daha fazlasına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, Microsoft PowerPoint, OpenOffice veya LibreOffice olmadan PowerPoint ve OpenDocument sunumlarını yükleyebilir ve bunları birçok başka formata kaydedebilir veya işleyebilir. Eski PPT dosyalarını modern PPTX formatına dönüştürebilir, sunumları PDF ve XPS gibi sabit düzenli belgelere dışa aktarabilir, slaytları HTML olarak yayınlayabilir veya slaytları önizlemeler, küçük resimler ve arşivler için görüntü dosyalarına işleyebilirsiniz.

Çoğu belge dönüşümü aynı genel iş akışını kullanır: kaynak dosyayı yükleyin, gerekli çıktıyı seçin ve gerektiğinde format‑spesifik seçenekleri uygulayın. Görüntü formatları için her slayt ayrı ayrı işlenir ve ardından raster veya vektör görüntüsü olarak kaydedilir. Aşağıda bağlı olan makaleler her durum için uygulama ayrıntılarını sunar.

## **Dönüştürme Senaryosu Seçin**

Aşağıdaki makaleler tam Python örnekleri ve format‑spesifik seçenekler için kullanılabilir.

| Senaryo | İhtiyacınız olduğunda | Makale |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Legacy PPT dosyalarını modernize edin, mevcut PPTX dosyalarını normalleştirin veya OpenDocument sunumlarını PowerPoint PPTX’e dönüştürün. | [PPT'yi PPTX'e Dönüştür](/slides/tr/python-java/convert-ppt-to-pptx/), [ODP'yi PPTX'e Dönüştür](/slides/tr/python-java/convert-odp-to-pptx/), [Sunumları Kaydet](/slides/tr/python-java/save-presentation/) |
| PPTX to PPT | Modern PowerPoint sunumunu eski ikili PPT formatına kaydederek eski iş akışlarıyla uyumluluğu sağlayın. | [PPTX'i PPT'ye Dönüştür](/slides/tr/python-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Paylaşım, baskı veya arşivleme için taşınabilir, aranabilir sabit‑düzen belgeleri oluşturun. | [PowerPoint'i PDF'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Sunum içeriğiyle birlikte konuşmacı notlarını da dışa aktarın. | [PowerPoint'i Notlarla PDF'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Sunumları HTML sayfaları olarak yayınlayın ve görüntüler, yazı tipleri, notlar ve duyarlı düzen seçeneklerini kontrol edin. | [PowerPoint'i HTML'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Biçimlendirme ve etkileşimi koruyarak tarayıcı tabanlı görüntüleme için slaytları HTML5’e dışa aktarın. | [Sunumları HTML5'e Dönüştür](/slides/tr/python-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Önizlemeler, küçük resimler veya web çıktısı için her slaytı PNG görüntüsüne işleyin. | [PowerPoint'i PNG'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Slaytları JPG görüntülerine işleyin ve boyut ile kaliteyi kontrol edin. | [PowerPoint'i JPG'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Tek tek slaytları ölçeklenebilir vektör grafikleri (SVG) olarak dışa aktarın. | [Slaytı SVG Olarak İşle](/slides/tr/python-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Sabit‑düzen XPS belgeleri oluşturun. | [PowerPoint'i XPS'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Sunumu çok sayfalı TIFF dosyası olarak kaydederek baskı, tarama, faks veya arşiv iş akışlarını destekleyin. | [PowerPoint'i TIFF'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Konuşmacı notlarıyla birlikte slaytları TIFF olarak kaydedin. | [PowerPoint'i Notlarla TIFF'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Sunumları belge‑stili çıktı gerektiğinde Word belgesine dönüştürün. | [PowerPoint'i Word'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Dokümantasyon ve metin‑tabanlı iş akışları için sunum içeriğini Markdown’a aktarın. | [PowerPoint'i Markdown'a Dönüştür](/slides/tr/python-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | İnceleme, karşılaştırma, sorun giderme veya XML‑tabanlı iş akışları için metin‑tabanlı PowerPoint XML sunumu oluşturun. | [PowerPoint'i XML'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Slaytlardan hareketli GIF oluşturun. | [PowerPoint'i Animasyonlu GIF'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Sunum slaytlarından video dışa aktarma iş akışı oluşturun. | [PowerPoint'i Videoya Dönüştür](/slides/tr/python-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Slaytları WPF uygulamalarında kullanılmak üzere XAML’e dışa aktarın. | [Sunumları XAML'e Dönüştür](/slides/tr/python-java/export-to-xaml/) |

Daha geniş bir giriş ve çıkış formatları listesi için, [Desteklenen Dosya Formatları](/slides/tr/python-java/supported-file-formats/) bölümüne bakın.

## **PowerPoint ve OpenDocument Dönüştürmesi**

Aspose.Slides for Python via Java, PPT, PPTX, PPS, PPSX, POT, POTX ve ODP gibi yaygın kullanılan sunum formatlarından dönüşümü destekler. PowerPoint ve OpenDocument dosyaları aynı dönüşüm API’siyle işlenir; bu nedenle bir PPTX dosyasını PDF’ye kaydeden iş akışı, sadece giriş dosyasını değiştirerek ODP dosyası için de uygulanabilir.

ODP dosyalarını dönüştürürken, PowerPoint ve OpenDocument uygulamalarının her layout ve biçimlendirme özelliğini tam olarak aynı şekilde desteklemediğini unutmayın. ODP dosyası LibreOffice veya OpenOffice Impress ile oluşturulmuşsa, çıktıyı gözden geçirin ve [OpenDocument Sunumları Dönüştür](/slides/tr/python-java/convert-openoffice-odp/) maddesinde açıklanan format‑spesifik seçenekleri kullanın.

## **PPT'den PPTX'e Dönüştürme**

PPT, eski ikili PowerPoint formatıyken, PPTX modern Office Open XML formatıdır. Aspose.Slides for Python via Java, master’lar, layout’lar, slaytlar, grafikler, gruplandırılmış şekiller, yer tutucular, metin çerçeveleri, dokular ve resim doldurmaları gibi karmaşık sunum yapılarını koruyarak yüksek doğrulukta PPT‑den PPTX‑e dönüşümü destekler.

Ayrıntılar için, [PPT'yi PPTX'e Dönüştür](/slides/tr/python-java/convert-ppt-to-pptx/) ve [PPT vs PPTX](/slides/tr/python-java/ppt-vs-pptx/) makalelerine bakın.

## **Sabit‑Düzen Dışa Aktarma**

PDF, XPS ve TIFF, çıktının cihazlar arasında aynı görünmesini ve sunum olarak düzenlenmemesini istediğiniz durumlarda faydalıdır. İlgili PDF, XPS ve TIFF makaleleri, uyumluluk, gizli slaytlar, notlar, görüntü kalitesi, sıkıştırma, piksel formatı ve çıktı boyutu kontrolünü açıklar.

## **HTML ve Görüntü Dışa Aktarma**

HTML ve HTML5 dışa aktarma, tarayıcı görüntüleme, web yayıncılığı ve hafif paylaşım için faydalıdır. Görüntü dışa aktarma, her slaytın ayrı bir önizleme, küçük resim veya raster varlığı olmasını gerektirdiğinde kullanılır. PNG, JPG ve SVG makaleleri, format‑spesifik işleme kılavuzları sunar.

## **SSS**

**Sunumları dönüştürmek için Microsoft PowerPoint'e ihtiyacım var mı?**  
Hayır. Aspose.Slides for Python via Java bağımsız bir kütüphanedir ve Microsoft PowerPoint ya da Office otomasyonu gerektirmez.

**Birden çok sunumu toplu olarak dönüştürebilir miyim?**  
Evet. Her bir sunumu yükleyin, gerekli formata kaydedin ve işleme sonrası sunum nesnesini serbest bırakın. Paralel işleme için ayrı sunum örnekleri kullanın ve [çoklu iş parçacığı](/slides/tr/python-java/multithreading/) yönergelerini izleyin.

**Yalnızca seçili slaytları dışa aktarabilir miyim?**  
Evet. Çıktı formatına bağlı olarak slayt indekslerini geçirebilir veya tek tek slaytları işleyebilirsiniz. Hedef format için ilgili makaleye bakın.

**PDF veya XPS dışa aktarırken gizli slaytları dahil edebilir miyim?**  
Evet. Gizli‑slayt dışa aktarma ayarları, [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) ve [XPS](/slides/tr/python-java/convert-powerpoint-to-xps/) dönüşüm makalelerinde açıklanmıştır.

**PDF/A çıktısı oluşturabilir miyim?**  
Evet. PDF dışa aktarımı için uyumluluk ayarları mevcuttur. Ayrıntılar için [PowerPoint'i PDF'e Dönüştür](/slides/tr/python-java/convert-powerpoint-to-pdf/) bölümüne bakın.

**Dönüşüm sırasında yazı tipleri nasıl işlenir?**  
Aspose.Slides, gömülü yazı tipleri, yedekleme (fallback) ve yazı tipi ikame (substitution) ayarlarını destekler. Ayrıntılar için [Gömülü Yazı Tipi](/slides/tr/python-java/embedded-font/), [Yedek Yazı Tipi](/slides/tr/python-java/fallback-font/) ve [Yazı Tipi İkamesi](/slides/tr/python-java/font-substitution/) makalelerine göz atın.