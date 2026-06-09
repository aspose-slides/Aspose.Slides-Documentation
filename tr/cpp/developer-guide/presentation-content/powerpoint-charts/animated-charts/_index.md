---
title: C++'ta PowerPoint Grafiklerini Animasyonlayın
linktitle: Animasyonlu Grafikler
type: docs
weight: 80
url: /tr/cpp/animated-charts/
keywords:
- grafik
- animasyonlu grafik
- grafik animasyonu
- grafik serisi
- grafik kategorisi
- seri öğesi
- kategori öğesi
- efekt ekle
- efekt türü
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++'ta çarpıcı animasyonlu grafikler oluşturun. PPT ve PPTX dosyalarında dinamik görsellerle sunumları güçlendirin—şimdi başlayın."
---
## **Giriş**

Aspose.Slides grafik öğelerinin animasyonunu destekler. **Seriler**, **Kategoriler**, **Seri Öğeleri**, **Kategori Öğeleri** [ISequence::AddEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/addeffect/) yöntemi ve iki enum olan [EffectChartMajorGroupingType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effectchartmajorgroupingtype/) ve [EffectChartMinorGroupingType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effectchartminorgroupingtype/) ile animasyonlandırılabilir.

## **Grafik Serisi Animasyonu**
Bir grafik serisini animasyonlamak istiyorsanız, aşağıdaki adımlara göre kod yazın:

1. Bir sunumu yükleyin.
1. Grafik nesnesine referans alın.
1. Seriyi animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte grafik serilerini animasyonladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Bir Seri Öğesinde Animasyon**
Seri öğelerini animasyonlamak istiyorsanız, aşağıdaki adımlara göre kod yazın:

1. Bir sunumu yükleyin.
1. Grafik nesnesine referans alın.
1. Seri öğelerini animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte seri öğelerini animasyonladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Grafik Kategori Animasyonu**
Bir grafik kategorisini animasyonlamak istiyorsanız, aşağıdaki adımlara göre kod yazın:

1. Bir sunumu yükleyin.
1. Grafik nesnesine referans alın.
1. Kategoriyi animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte grafik kategorisini animasyonladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Bir Kategori Öğesinde Animasyon**
Kategori öğelerini animasyonlamak istiyorsanız, aşağıdaki adımlara göre kod yazın:

1. Bir sunumu yükleyin.
1. Grafik nesnesine referans alın.
1. Kategori öğelerini animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte kategori öğelerini animasyonladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **SSS**

**Grafikler için (giriş, vurgu, çıkış gibi) farklı efekt türleri destekleniyor mu?**

Evet. Bir grafik bir şekil olarak ele alınır, bu nedenle giriş, vurgu ve çıkış dahil olmak üzere standart animasyon efekt türlerini destekler ve slaytın zaman çizelgesi ve animasyon dizileri üzerinden tam kontrol sağlar.

**Grafik animasyonunu slayt geçişleriyle birleştirebilir miyim?**

Evet. [Geçişler](/slides/tr/cpp/slide-transition/) slayta uygulanırken, animasyon efektleri slayttaki nesnelere uygulanır. İkisini aynı sunumda birlikte kullanabilir ve bağımsız olarak kontrol edebilirsiniz.

**Grafik animasyonları PPTX olarak kaydedildiğinde korunur mu?**

Evet. PPTX olarak kaydettiğinizde (/slides/tr/cpp/save-presentation/) tüm animasyon efektleri ve sıralamaları, sunumun yerel animasyon modelinin bir parçası olduğu için korunur.

**Mevcut bir sunumdan grafik animasyonlarını okuyup değiştirebilir miyim?**

Evet. [API](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/) slayt zaman çizelgesi, diziler ve efektlere erişim sağlar; böylece mevcut grafik animasyonlarını inceleyebilir ve her şeyi baştan yaratmadan ayarlayabilirsiniz.

**Aspose.Slides ile grafik animasyonlarını içeren bir video üretebilir miyim?**

Evet. Sunumu video olarak dışa aktarabilirsiniz (/slides/tr/cpp/convert-powerpoint-to-video/); animasyonlar, zamanlamalar ve diğer dışa aktarma ayarları korunarak elde edilen klip animasyonlu oynatımı yansıtır.