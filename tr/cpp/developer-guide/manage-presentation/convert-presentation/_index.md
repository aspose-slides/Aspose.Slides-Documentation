---
title: C++'ta Sunumları Birden Çok Formata Dönüştür
linktitle: Sunumu Dönüştür
type: docs
weight: 70
url: /tr/cpp/convert-presentation/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument sunumlarını PPTX, PDF, HTML, görüntüler, XPS, TIFF ve daha fazlasına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for C++ Microsoft PowerPoint, OpenOffice veya LibreOffice olmadan PowerPoint ve OpenDocument sunumlarını yükleyebilir ve birçok başka formata kaydedebilir ya da render edebilir. Eski PPT dosyalarını modern PPTX'e dönüştürebilir, sunumları PDF ve XPS gibi sabit‑düzen belgelerine dışa aktarabilir, slaytları HTML olarak yayımlayabilir veya slaytları önizleme, küçük resim ve arşivleme için görüntü dosyaları olarak render edebilirsiniz.

Çoğu belge dönüşümü aynı genel iş akışını izler: kaynak dosyayı yükle, istenen çıkış formatını seç ve gerektiğinde formata özgü seçenekleri uygula. Görüntü formatları için her slayt ayrı ayrı render edilir ve raster ya da vektör görüntüsü olarak kaydedilir. Aşağıdaki ilgili makaleler her durum için uygulama ayrıntılarını sağlar.

## **Bir Dönüşüm Senaryosu Seçin**

Aşağıdaki makaleler tam C++ örnekleri ve format‑özel seçenekler sunar.

| Senaryo | İhtiyacınız olduğunda | Makale |
| --- | --- | --- |
| PPT/PPTX/ODP'den PPTX'e | Eski PPT dosyalarını modern PPTX'e dönüştürmek, mevcut PPTX dosyalarını normalleştirmek veya OpenDocument sunumlarını PowerPoint PPTX'e dönüştürmek. | [PPT'yi PPTX'e Dönüştür](/slides/tr/cpp/convert-ppt-to-pptx/), [ODP'yi PPTX'e Dönüştür](/slides/tr/cpp/convert-odp-to-pptx/), [Sunumları Kaydet](/slides/tr/cpp/save-presentation/) |
| PPTX'den PPT'ye | Modern PowerPoint sunumunu daha eski ikili PPT formatında kaydetmek, eski iş akışlarıyla uyumluluk sağlamak. | [PPTX'i PPT'ye Dönüştür](/slides/tr/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP'den PDF'e | Paylaşım, baskı veya arşivleme için taşınabilir, aranabilir, sabit‑düzen belgeleri oluşturmak. | [PowerPoint'i PDF'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP'den Notlarla PDF'e | Slayt içeriğiyle birlikte konuşmacı notlarını dışa aktarmak. | [PowerPoint'i Notlu PDF'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP'den HTML'e | Sunumları HTML sayfaları olarak yayımlamak ve resimler, yazı tipleri, notlar ve duyarlı düzen seçeneklerini kontrol etmek. | [PowerPoint'i HTML'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP'den HTML5'e | Slaytları tarayıcı tabanlı görüntüleme için formatlamayı ve etkileşimi koruyarak HTML5'e dışa aktarmak. | [Sunumları HTML5'e Dönüştür](/slides/tr/cpp/export-to-html5/) |
| PPT/PPTX/ODP'den PNG'ye | Önizlemeler, küçük resimler veya web çıktısı için her slaytı bir PNG görüntüsü olarak render etmek. | [PowerPoint'i PNG'ye Dönüştür](/slides/tr/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP'den JPG'ye | Slaytları JPG görüntülerine render etmek ve görüntü boyutları ile kalitesini kontrol etmek. | [PowerPoint'i JPG'ye Dönüştür](/slides/tr/cpp/convert-powerpoint-to-jpg/) |
| Slaytı SVG'ye | Tek tek slaytları ölçeklenebilir vektör grafiği olarak dışa aktarmak. | [Slaytı SVG olarak Oluştur](/slides/tr/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP'den XPS'e | Sabit‑düzen XPS belgeleri oluşturmak. | [PowerPoint'i XPS'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP'den TIFF'e | Sunumu çok sayfalı TIFF dosyası olarak kaydetmek, baskı, tarama, faks veya arşiv iş akışları için. | [PowerPoint'i TIFF'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP'den Notlu TIFF'e | Konuşmacı notlarıyla birlikte slaytları TIFF'e kaydetmek. | [PowerPoint'i Notlu TIFF'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX'den Word'e | Belge biçiminde çıktı gerektiğinde slaytları Word belgesine dönüştürmek. | [PowerPoint'i Word'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX'den Markdown'a | Sunum içeriğini belgeler ve metin tabanlı iş akışları için Markdown'a çıkarmak. | [PowerPoint'i Markdown'a Dönüştür](/slides/tr/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX'den animasyonlu GIF'e | Slaytlardan animasyonlu GIF oluşturmak. | [PowerPoint'i Animasyonlu GIF'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX'den videoya | Sunum slaytlarından video ihracat iş akışı oluşturmak. | [PowerPoint'i Videoya Dönüştür](/slides/tr/cpp/convert-powerpoint-to-video/) |
| Sunumu XAML'e | Slaytları C++ UI senaryoları için XAML'e dışa aktarmak. | [Sunumları XAML'e Dışa Aktar](/slides/tr/cpp/export-to-xaml/) |

Daha kapsamlı giriş ve çıkış formatları listesi için [Desteklenen Dosya Formatları](/slides/tr/cpp/supported-file-formats/) sayfasına bakın.

## **PowerPoint ve OpenDocument Dönüşümü**

Aspose.Slides for C++ PPT, PPTX, PPS, PPSX, POT, POTX ve ODP gibi yaygın kullanılan sunum formatlarından dönüşümü destekler. PowerPoint ve OpenDocument dosyaları için aynı dönüşüm API’si kullanılır; bu nedenle bir PPTX dosyasını PDF’ye kaydeden iş akışı, yalnızca giriş dosyasını ODP olarak değiştirerek aynı şekilde ODP dosyası için de uygulanabilir.

ODP dosyalarını dönüştürürken, PowerPoint ve OpenDocument uygulamalarının her düzen ve biçimlendirme özelliğini aynı şekilde desteklemediğini unutmayın. ODP dosyası LibreOffice veya OpenOffice Impress ile oluşturulduysa, çıktıyı inceleyin ve format‑özel yönlendirme için [OpenDocument Sunumları Dönüştür](/slides/tr/cpp/convert-openoffice-odp/) makalesinde açıklanan seçenekleri kullanın.

## **PPT'den PPTX'e Dönüştürme**

PPT eski ikili PowerPoint formatıdır, PPTX ise modern Office Open XML formatıdır. Aspose.Slides for C++ karmaşık sunum yapıları (masterlar, düzenler, slaytlar, grafikler, gruplanmış şekiller, yer tutucular, metin çerçeveleri, doku ve resim dolgu) korunarak yüksek doğruluklu PPT‑den PPTX‑e dönüşüm sağlar.

Ayrıntılar için [PPT'yi PPTX'e Dönüştür](/slides/tr/cpp/convert-ppt-to-pptx/) makalesine bakın.

## **Sabit Düzen Dışa Aktarımı**

PDF, XPS ve TIFF, çıktının cihazlar arasında aynı görünmesini ve bir sunum gibi düzenlenmemesini istediğiniz durumlarda faydalıdır. Ayrı PDF, XPS ve TIFF makaleleri uyumluluk, gizli slaytlar, notlar, görüntü kalitesi, sıkıştırma, piksel formatı ve çıktı boyutu gibi ayarların nasıl kontrol edileceğini açıklar.

## **HTML ve Görüntü Dışa Aktarımı**

HTML ve HTML5 dışa aktarımı tarayıcı görüntüleme, web yayımlama ve hafif paylaşım için uygundur. Görüntü dışa aktarımı ise her slaytın ayrı bir önizleme, küçük resim veya raster varlık olmasını sağlar. PNG, JPG ve SVG makaleleri format‑özel render kılavuzları içerir.

## **SSS**

**Sunumları dönüştürmek için Microsoft PowerPoint'e ihtiyacım var mı?**

Hayır. Aspose.Slides for C++ bağımsız bir kütüphanedir ve Microsoft PowerPoint veya Office otomasyonu gerektirmez.

**Birçok sunumu toplu olarak dönüştürebilir miyim?**

Evet. Her sunumu yükleyin, gereken formata kaydedin ve işleme sonrası sunum nesnesini serbest bırakın. Paralel işleme için ayrı sunum örnekleri kullanın ve [multithreading](/slides/tr/cpp/multithreading/) yönergelerini izleyin.

**Sadece seçili slaytları dışa aktarabilir miyim?**

Evet. Çeşitli dışa aktarma yöntemleri slayt indekslerini geçirmenize veya bireysel slaytları render etmenize izin verir; hedef formata göre ilgili makaleye bakın.

**PDF veya XPS'e dışa aktarırken gizli slaytları dahil edebilir miyim?**

Evet. [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/) ve [XPS](/slides/tr/cpp/convert-powerpoint-to-xps/) dönüşüm makalelerinde açıklanan gizli‑slayt dışa aktarım ayarlarını kullanın.

**PDF/A çıktısı oluşturabilir miyim?**

Evet. PDF dışa aktarımı için uyumluluk ayarları mevcuttur. Ayrıntılar için [PowerPoint'i PDF'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-pdf/) bakın.

**Dönüşüm sırasında yazı tipleri nasıl ele alınır?**

Aspose.Slides gömülü yazı tiplerini, yedek yazı tiplerini ve yazı tipi ikame ayarlarını kullanabilir. Ayrıntılar için [Embedded Font](/slides/tr/cpp/embedded-font/), [Fallback Font](/slides/tr/cpp/fallback-font/) ve [Font Substitution](/slides/tr/cpp/font-substitution/) sayfalarına bakın.