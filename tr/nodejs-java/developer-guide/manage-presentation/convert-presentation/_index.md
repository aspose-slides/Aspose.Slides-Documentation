---
title: JavaScript ile Sunumları Çoklu Formata Dönüştür
linktitle: Sunumu Dönüştür
type: docs
weight: 70
url: /tr/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile PowerPoint ve OpenDocument sunumlarını PPTX, PDF, HTML, görüntüler, XPS, TIFF ve daha fazlasına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, Microsoft PowerPoint, OpenOffice veya LibreOffice olmadan PowerPoint ve OpenDocument sunumlarını yükleyebilir ve bunları birçok başka formata kaydedebilir veya işleyebilir. Eski PPT dosyalarını modern PPTX formatına dönüştürebilir, sunumları PDF ve XPS gibi sabit‑düzen dökümanlara dışa aktarabilir, slaytları HTML olarak yayımlayabilir veya ön izlemeler, küçük resimler ve arşivler için slaytları görüntü dosyaları olarak işleyebilirsiniz.

Çoğu belge dönüşümü aynı genel iş akışını izler: kaynak dosyayı yükleyin, gerekli çıkış formatını seçin ve gerektiğinde format‑özel seçenekleri uygulayın. Görüntü formatları için her slayt ayrı ayrı işlenir ve ardından raster veya vektör görüntüsü olarak kaydedilir. Aşağıda bağlantı verilen özel makaleler, her durum için uygulama detaylarını sunar.

## **Bir Dönüştürme Senaryosu Seçin**

Aşağıdaki makaleler, tam JavaScript örnekleri ve format‑özel seçenekler içerir.

| Senaryo | Ne zaman ihtiyacınız var | Makale |
| --- | --- | --- |
| PPT/PPTX/ODP'dan PPTX'e | Eski PPT dosyalarını modernleştirmek, mevcut PPTX dosyalarını normalleştirmek veya OpenDocument sunumlarını PowerPoint PPTX'e dönüştürmek. | [PPT'yi PPTX'e Dönüştür](/slides/tr/nodejs-java/convert-ppt-to-pptx/), [ODP'yi PPTX'e Dönüştür](/slides/tr/nodejs-java/convert-odp-to-pptx/), [Sunumları Kaydet](/slides/tr/nodejs-java/save-presentation/) |
| PPTX'den PPT'ye | Modern bir PowerPoint sunumunu daha eski ikili PPT formatına kaydederek eski iş akışlarıyla uyumluluğu sağlamak. | [PPTX'i PPT'ye Dönüştür](/slides/tr/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP'dan PDF'e | Paylaşım, baskı veya arşivleme için taşınabilir, aranabilir, sabit‑düzen dökümanlar oluşturmak. | [PowerPoint'i PDF'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP'dan notlarla PDF'e | Sunum içeriğiyle birlikte sunucu notlarını dışa aktarmak. | [PowerPoint'i Notlarla PDF'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP'dan HTML'e | Sunumları HTML sayfaları olarak yayımlamak ve görüntüler, yazı tipleri, notlar ve duyarlı düzen seçeneklerini kontrol etmek. | [PowerPoint'i HTML'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP'dan HTML5'e | Biçimlendirme ve etkileşim korunarak tarayıcı tabanlı görüntüleme için slaytları HTML5'e dışa aktarmak. | [Sunumları HTML5'e Dönüştür](/slides/tr/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP'dan PNG'e | Ön izlemeler, küçük resimler veya web çıktısı için her slaytı PNG görüntüsü olarak işlemek. | [PowerPoint'i PNG'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP'dan JPG'e | Slaytları JPG görüntüsü olarak işlemek ve görüntü boyutları ile kalitesini kontrol etmek. | [PowerPoint'i JPG'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-jpg/) |
| Slaytı SVG olarak dışa aktar | Tek tek slaytları ölçeklenebilir vektör grafiği (SVG) olarak dışa aktarmak. | [Slaytı SVG olarak İşle](/slides/tr/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP'dan XPS'e | Sabit‑düzen XPS dökümanları oluşturmak. | [PowerPoint'i XPS'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP'dan TIFF'e | Baskı, tarama, faks veya arşiv akışları için çok sayfalı TIFF dosyası olarak sunumu kaydetmek. | [PowerPoint'i TIFF'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP'dan notlarla TIFF'e | Slaytları sunucu notlarıyla birlikte TIFF olarak kaydetmek. | [PowerPoint'i Notlarla TIFF'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX'den Markdown'a | Dokümantasyon ve metin‑tabanlı iş akışları için sunum içeriğini Markdown olarak çıkarmak. | [PowerPoint'i Markdown'a Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP'den XML'e | İnceleme, karşılaştırma, sorun giderme veya XML‑tabanlı iş akışları için metin‑tabanlı PowerPoint XML sunumu oluşturmak. | [PowerPoint'i XML'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX'den animasyonlu GIF'e | Slaytlardan animasyonlu GIF oluşturmak. | [PowerPoint'i Animasyonlu GIF'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX'den video'ya | Sunum slaytlarından bir video ihracat iş akışı oluşturmak. | [PowerPoint'i Video'ya Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-video/) |
| Sunumu XAML'e | JavaScript veya Java UI senaryoları için slaytları XAML'e dışa aktarmak. | [Sunumları XAML'e Dışa Aktar](/slides/tr/nodejs-java/export-to-xaml/) |

Daha geniş bir giriş ve çıkış formatı listesi için, [Desteklenen Dosya Formatları](/slides/tr/nodejs-java/supported-file-formats/) sayfasına bakın.

## **PowerPoint ve OpenDocument Dönüştürme**

Aspose.Slides for Node.js via Java, PPT, PPTX, PPS, PPSX, POT, POTX ve ODP gibi yaygın kullanılan sunum formatlarından dönüşümü destekler. Aynı dönüşüm API'si PowerPoint ve OpenDocument dosyaları için kullanılır; bu nedenle bir PPTX dosyasını PDF'e kaydeden bir iş akışı, yalnızca giriş dosyasını değiştirerek ODP dosyasına da uygulanabilir.

ODP dosyalarını dönüştürürken, PowerPoint ve OpenDocument uygulamalarının her düzen ve biçimlendirme özelliğini aynı şekilde desteklemediğini unutmayın. Bir ODP dosyası LibreOffice veya OpenOffice Impress ile oluşturulmuşsa, çıktıyı inceleyin ve format‑özel rehberlik için [OpenDocument Sunumlarını Dönüştür](/slides/tr/nodejs-java/convert-openoffice-odp/) makalesindeki seçenekleri kullanın.

## **PPT'den PPTX'e Dönüştürme**

PPT, eski ikili PowerPoint formatıyken, PPTX modern Office Open XML formatıdır. Aspose.Slides for Node.js via Java, kompleks sunum yapıları (masterlar, düzenler, slaytlar, grafikler, gruplanmış şekiller, yer tutucular, metin çerçeveleri, doku ve resim doldurulması) korunarak yüksek doğruluklu PPT'den PPTX'e dönüşümü destekler.

Ayrıntılar için [PPT'yi PPTX'e Dönüştür](/slides/tr/nodejs-java/convert-ppt-to-pptx/) ve [PPT vs PPTX](/slides/tr/nodejs-java/ppt-vs-pptx/) makalelerine bakın.

## **Sabit Düzen Dışa Aktarma**

PDF, XPS ve TIFF, çıktının cihazlar arasında aynı görünmesini ve sunum olarak düzenlenmemesini istediğinizde faydalıdır. Ayrı PDF, XPS ve TIFF makaleleri, uyumluluk, gizli slaytlar, notlar, görüntü kalitesi, sıkıştırma, piksel formatı ve çıktı boyutu nasıl kontrol edileceğini açıklar.

## **HTML ve Görüntü Dışa Aktarma**

HTML ve HTML5 dışa aktarma, tarayıcıda görüntüleme, web yayımlama ve hafif paylaşım için yararlıdır. Görüntü dışa aktarma, her slaytın ayrı bir ön izleme, küçük resim veya raster varlık haline gelmesi gerektiğinde kullanılır. Format‑özel işleme rehberi için PNG, JPG ve SVG makalelerini inceleyin.

## **SSS**

**Sunumları dönüştürmek için Microsoft PowerPoint gerekir mi?**

Hayır. Aspose.Slides for Node.js via Java bağımsız bir kütüphanedir ve Microsoft PowerPoint ya da Office otomasyonu gerektirmez.

**Birçok sunumu toplu olarak dönüştürebilir miyim?**

Evet. Her sunumu yükleyin, gerekli formata kaydedin ve işlemden sonra sunum nesnesini serbest bırakın. Paralel işleme için ayrı sunum örnekleri kullanın ve [çoklu iş parçacığı](/slides/tr/nodejs-java/multithreading/) yönergelerini izleyin.

**Yalnızca seçili slaytları dışa aktarabilir miyim?**

Evet. Birkaç dışa aktarma yöntemi, slayt indekslerini geçirmenize veya çıktı formatına bağlı olarak tek tek slayt işlemenize izin verir. Hedef format için özel makaleye bakın.

**PDF veya XPS'e dışa aktarırken gizli slaytları ekleyebilir miyim?**

Evet. Gizli‑slayt dışa aktarma ayarlarını, [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) ve [XPS](/slides/tr/nodejs-java/convert-powerpoint-to-xps/) dönüşüm makalelerinde açıklanan şekilde kullanın.

**PDF/A çıktısı oluşturabilir miyim?**

Evet. PDF dışa aktarma için uyumluluk ayarları mevcuttur. Ayrıntılar için [PowerPoint'i PDF'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) sayfasına bakın.

**Dönüştürme sırasında yazı tipleri nasıl işlenir?**

Aspose.Slides, gömülü yazı tiplerini, yedekleme (fallback) yazı tiplerini ve yazı tipi ikamesi ayarlarını kullanabilir. Şu makalelere göz atın: [Gömülü Yazı Tipi](/slides/tr/nodejs-java/embedded-font/), [Yedek Yazı Tipi](/slides/tr/nodejs-java/fallback-font/), ve [Yazı Tipi İkamesi](/slides/tr/nodejs-java/font-substitution/).