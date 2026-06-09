---
title: С++ kullanarak Sunumlarda Halka Grafiklerini Özelleştirme
linktitle: Halka Grafiği
type: docs
weight: 30
url: /tr/cpp/doughnut-chart/
keywords:
- halka grafik
- merkez boşluğu
- delik boyutu
- PowerPoint
- sunum
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ kullanarak halka grafiklerini oluşturma ve özelleştirme, dinamik sunumlar için PowerPoint formatlarını destekleme."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir halka grafiği ile nasıl çalışılacağını, grafiği bir slayta ekleyerek, ortasındaki deliğin boyutunu ayarlayarak ve sunumu kaydederek göstermektedir. `set_DoughnutHoleSize` yöntemine odaklanır ve bu grafik türünü kod içinde özelleştirmek için gerekli temel adımları gösterir.

## **Halka Grafiğinde Merkez Boşluğunu Belirleme**
Halka grafiğindeki deliğin boyutunu belirtmek için. Lütfen aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- Slayta bir halka grafik ekleyin.
- Halka grafiğindeki deliğin boyutunu belirtin.
- Sunumu diske yazın.

Aşağıdaki örnekte, halka grafiğindeki deliğin boyutunu ayarladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **SSS**

**Birden çok halka içeren çok seviyeli bir halka grafiği oluşturabilir miyim?**

Evet. Tek bir halka grafiğine birden fazla seri ekleyin—her seri ayrı bir halka olur. Halkaların sırası, serilerin koleksiyondaki sırasına göre belirlenir.

**'Patlamış' bir halka (ayrılmış dilimler) destekleniyor mu?**

Evet. Patlamış Halka [grafik türü](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/charttype/) ve veri noktalarında bir patlama özelliği vardır; bireysel dilimleri ayırabilirsiniz.

**Rapor için bir halka grafiğinin (PNG/SVG) görüntüsünü nasıl alabilirim?**

Bir grafik bir şekildir; onu bir [raster görüntüsüne](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getimage/) render edebilir ya da grafiği bir [SVG görüntüsüne](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/writeassvg/) dışa aktarabilirsiniz.