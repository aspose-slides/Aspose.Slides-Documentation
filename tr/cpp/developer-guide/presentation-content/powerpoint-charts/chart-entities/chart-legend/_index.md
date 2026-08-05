---
title: C++ Kullanarak Sunumlarda Grafik Açıklamalarını Özelleştir
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
description: "Aspose.Slides for C++ ile grafik açıklamalarını özelleştirerek, özelleştirilmiş açıklama biçimlendirmesiyle PowerPoint sunumlarını optimize edin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki grafik açıklamalarını kişiselleştirme seçenekleri sunar. Bu makale, bir açıklamanın konumunu ve boyutunu nasıl ayarlayacağınızı, tüm açıklama için yazı tipi boyutunu nasıl belirleyeceğinizi ve tek bir açıklama girişine nasıl biçimlendirme uygulayacağınızı gösterir.

Ayrıca SSS bölümünde ilgili pek çok davranışı kapsar; açıklama için alan ayırmak amacıyla örtüşme dışı modu kullanma, uzun açıklama etiketlerinin satır başına kaydırılmasına veya satır sonu eklenmesine izin verme ve açıklama biçimlendirmesinin, açıkça metin ve dolgu ayarları uygulanmadığında sunum temasından kalıtım almasını sağlama.

## **Açıklama Konumlandırması**
Açıklama özelliklerini ayarlamak için lütfen aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun.
- Slaytın referansını alın.
- Slayta bir grafik ekleyin.
- Açıklamanın özelliklerini ayarlayın.
- Sunumu PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, Grafik açıklamasının konumunu ve boyutunu ayarladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Açıklamanın Yazı Tipi Boyutunu Ayarlama**
Aspose.Slides for C++, geliştiricilerin açıklamanın yazı tipi boyutunu ayarlamasına olanak tanır. Lütfen aşağıdaki adımları izleyin:

- Presentation sınıfını örnekleyin.
- Varsayılan grafiği oluşturun.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Bireysel Açıklamanın Yazı Tipi Boyutunu Ayarlama**
Aspose.Slides for C++, geliştiricilerin tek tek açıklama girişlerinin yazı tipi boyutunu ayarlamasına imkan verir. Lütfen aşağıdaki adımları izleyin:

- Presentation sınıfını örnekleyin.
- Varsayılan grafiği oluşturun.
- Açıklama girişine erişin.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **SSS**

**Açıklamayı, grafiğin üzerine bindirmek yerine otomatik olarak yer ayıracak şekilde etkinleştirebilir miyim?**

Evet. Örtüşme dışı modu kullanın ([set_Overlay(false)](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/legend/set_overlay/)); bu durumda, çizim alanı açıklamayı barındıracak şekilde küçülecektir.

**Çok satırlı açıklama etiketleri oluşturabilir miyim?**

Evet. Uzun etiketler, alan yetersiz olduğunda otomatik olarak satır sonunda kaydırılır; zorunlu satır sonları, seri adındaki yeni satır karakterleriyle desteklenir.

**Açıklamayı, sunum temasının renk şemasına göre nasıl ayarlayabilirim?**

Açıklama veya metni için açık renkler/dolgu/yazı tipleri belirlemeyin. Böylece tema tarafından devralınır ve tasarım değiştiğinde doğru şekilde güncellenir.