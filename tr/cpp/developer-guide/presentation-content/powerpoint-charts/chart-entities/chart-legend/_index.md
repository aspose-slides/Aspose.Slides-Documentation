---
title: Sunumlarda Grafik Açıklamalarını C++ Kullanarak Özelleştirme
linktitle: Grafik Açıklaması
type: docs
url: /tr/cpp/chart-legend/
keywords:
- grafik açıklaması
- açıklama konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile grafik açıklamalarını özelleştirerek, PowerPoint sunumlarını özel açıklama biçimlendirmesiyle optimize edin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki grafik açıklamalarını özelleştirmek için seçenekler sunar. Bu makale, bir açıklamanın konumunu ve boyutunu nasıl ayarlayacağınızı, tüm açıklama için yazı tipi boyutunu nasıl belirleyeceğinizi ve tek bir açıklama girişine nasıl biçimlendirme uygulayacağınızı gösterir.

Ayrıca SSS bölümünde, grafik alanının açıklama için yer açması amacıyla üzerine bindirme olmayan (non‑overlay) modun kullanılmasını, uzun açıklama etiketlerinin otomatik olarak satır başına kaydırılmasını veya satır sonları kullanılmasını, ve açıklama biçimlendirmesinin açık metin ve dolgu ayarları belirtilmediğinde sunum temasından devralınmasını kapsayan birkaç ilgili davranışı ele alır.

## **Açıklama Konumlandırması**
Aşağıdaki adımları izleyerek açıklama özelliklerini ayarlayın:

- Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- Slayt referansını alın.
- Slayta bir grafik ekleyin.
- Açıklamanın özelliklerini ayarlayın.
- Sunumu bir PPTX dosyası olarak yazın.

Aşağıdaki örnekte, Grafik açıklamasının konumunu ve boyutunu ayarladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Bir Açıklamanın Yazı Tipi Boyutunu Ayarlama**
Aspose.Slides for C++ geliştiricilerin açıklamanın yazı tipi boyutunu ayarlamasına olanak tanır. Lütfen aşağıdaki adımları izleyin:

- Presentation sınıfını örnekleyin.
- Varsayılan grafiği oluşturun.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Tek Bir Açıklamanın Yazı Tipi Boyutunu Ayarlama**
Aspose.Slides for C++ geliştiricilerin tek tek açıklama girişlerinin yazı tipi boyutunu ayarlamasına olanak tanır. Lütfen aşağıdaki adımları izleyin:

- Presentation sınıfını örnekleyin.
- Varsayılan grafiği oluşturun.
- Açıklama girişine erişin.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **SSS**

**Grafiğin açıklamayı otomatik olarak yer ayıracak şekilde etkinleştirebilir miyim, böylece üzerine bindirme olmaz?**

Evet. Üzerine bindirme olmayan modu kullanın ([set_Overlay(false)](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/legend/set_overlay/)); bu durumda, grafik alanı açıklamayı alacak şekilde küçülecektir.

**Çok satırlı açıklama etiketleri oluşturabilir miyim?**

Evet. Uzun etiketler, boşluk yetersiz olduğunda otomatik olarak satır başına kaydırılır; zorunlu satır sonları, seri adındaki yeni satır karakterleriyle desteklenir.

**Açıklamanın sunum temasının renk şemasını takip etmesini nasıl sağlarım?**

Açıklama veya metni için açık renkler/dolgular/yazı tipleri belirlemeyin. Böylece tema tarafından devralınacak ve tasarım değiştiğinde doğru şekilde güncelleneceklerdir.