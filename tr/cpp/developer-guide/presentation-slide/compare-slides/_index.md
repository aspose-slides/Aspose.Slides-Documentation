---
title: C++'te Sunum Slaytlarını Karşılaştır
linktitle: Slaytları Karşılaştır
type: docs
weight: 50
url: /tr/cpp/compare-slides/
keywords:
- slaytları karşılaştır
- slayt karşılaştırması
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument sunumlarını programlı olarak karşılaştırın. Kod içinde slayt farklarını hızlı bir şekilde tespit edin."
---
## **Genel Bakış**

Aspose.Slides, `IBaseSlide` arayüzü ve `BaseSlide` sınıfı tarafından sağlanan `Equals` metodunu kullanarak slaytları, düzen slaytlarını ve ana slaytları karşılaştırmanıza olanak tanır. Bu metod, karşılaştırılan slaytlar yapı ve statik içerik açısından aynı olduğunda `true` döndürür.

## **İki Slaytı Karşılaştır**
`Equals` metodu IBaseSlide arayüzüne ve BaseSlide sınıfına eklenmiştir. Yapı ve statik içerik açısından aynı olan slaytlar / düzen slaytları / ana slaytlar için `true` döndürür.

İki slayt, tüm şekiller, stiller, metinler, animasyonlar ve diğer ayarlar aynıysa eşittir. vb. Karşılaştırma, SlideId gibi benzersiz tanımlayıcı değerleri ve Tarih Yer Tutucu içindeki mevcut tarih değeri gibi dinamik içeriği dikkate almaz.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **SSS**

**Bir slaytın gizli olması, slaytların kendisinin karşılaştırmasını etkiler mi?**

[Hidden status](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/get_hidden/) bir sunum/oynatım düzeyi özelliğidir, görsel içerik değildir. İki belirli slaytın eşitliği, yapı ve statik içerikleriyle belirlenir; bir slaytın gizli olması sadece slaytları farklı kılmaz.

**Köprüler ve parametreleri dikkate alınıyor mu?**

Evet. Bağlantılar bir slaytın statik içeriğinin bir parçasıdır. URL veya köprü eylemi farklıysa, bu genellikle statik içerikte bir fark olarak değerlendirilir.

**Bir grafik harici bir Excel dosyasına referans verirse, dosyanın içeriği dikkate alınır mı?**

Hayır. Karşılaştırma, slaytların kendileri üzerinden yapılır. Harici veri kaynakları genellikle karşılaştırma sırasında okunmaz; yalnızca slaytın yapısında ve statik durumunda bulunanlar dikkate alınır.