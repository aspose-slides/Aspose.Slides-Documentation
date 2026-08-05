---
title: C++ Kullanarak Sunumlarda Halka Grafiklerini Özelleştirme
linktitle: Halka Grafik
type: docs
weight: 30
url: /tr/cpp/doughnut-chart/
keywords:
- halka grafik
- merkez boşluğu
- delik boyutu
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'da halka grafiklerini oluşturma ve özelleştirme, dinamik sunumlar için PowerPoint formatlarını destekleme hakkında keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta bir halka grafiği ile nasıl çalışılacağını, grafiği bir slayta ekleyerek, merkez boşluğunun boyutunu ayarlayarak ve sunumu kaydederek gösterir. `set_DoughnutHoleSize` metoduna odaklanır ve bu grafik türünü kod içinde özelleştirmek için gereken temel adımları gösterir.

## **Bir Halka Grafiğinde Merkez Boşluğunu Belirleme**
Bir halka grafiğinin boşluğunun boyutunu belirlemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfını örnekleyin.
- Slayta bir halka grafik ekleyin.
- Halka grafiğinin boşluğunun boyutunu belirtin.
- Sunumu diske yazın.

Aşağıdaki örnekte, halka grafiğinin boşluğunun boyutunu ayarladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **SSS**

**Birden çok halka ile çok seviyeli bir halka oluşturabilir miyim?**

Evet. Tek bir halka grafiğine birden çok seri ekleyin—her seri ayrı bir halka olur. Halka sırası, serilerin koleksiyon içindeki sırasına göre belirlenir.

**"Patlatılmış" bir halka (ayrılmış dilimler) destekleniyor mu?**

Evet. Bir Patlatılmış Halka [chart type](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/charttype/) vardır ve veri noktalarında bir patlama özelliği vardır; bireysel dilimleri ayırabilirsiniz.

**Bir rapor için halka grafiğinin (PNG/SVG) görüntüsünü nasıl alabilirim?**

Bir grafik bir şekildir; onu bir [raster image](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getimage/) olarak render edebilir veya grafiği bir [SVG image](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/writeassvg/) olarak dışa aktarabilirsiniz.