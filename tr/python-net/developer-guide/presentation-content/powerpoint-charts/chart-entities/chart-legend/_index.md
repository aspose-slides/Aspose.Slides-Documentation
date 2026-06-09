---
title: Python ile Sunumlarda Grafik Lejantlarını Özelleştirin
linktitle: Grafik Lejantı
type: docs
url: /tr/python-net/chart-legend/
keywords:
- grafik lejanti
- lejant konumu
- yazı tipi boyutu
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python ile .NET üzerinden grafik lejantlarını özelleştirerek, PowerPoint ve OpenDocument sunumlarını özel lejant biçimlendirmesi ile optimize edin."
---
## **Genel Bakış**

Aspose.Slides for Python, grafik lejantları üzerinde tam kontrol sağlayarak veri etiketlerini net ve sunuma hazır hâle getirmenizi sağlar. Lejantı gösterip gizleyebilir, slayt üzerindeki konumunu seçebilir ve grafik alanıyla çakışmayı önlemek için yerleşimini ayarlayabilirsiniz. API, metin ve işaretçileri stillendirme, dolgu ve arka planı ince ayar yapma, kenarlık ve doldurmayı temanızla eşleştirme imkanı sunar. Geliştiriciler ayrıca tek tek lejant girişlerine erişerek adlarını değiştirebilir veya filtreleyebilir, böylece yalnızca en ilgili seriler görüntülenir. Bu özelliklerle grafikleriniz okunabilir, tutarlı ve sunum tasarım standartlarınızla uyumlu kalır.

## **Lejant Konumlandırma**

Aspose.Slides kullanarak grafik lejantının slayt düzeninizde nerede görüneceğini ve nasıl yerleştirileceğini hızlıca kontrol edebilirsiniz. Lejantı tam olarak nasıl konumlandıracağınızı öğrenin.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayta referans alın.
1. Slayta bir grafik ekleyin.
1. Lejant özelliklerini ayarlayın.
1. Sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte grafik lejantının konumu ve boyutu ayarlanmıştır:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:

    # Slayta referans alın.
    slide = presentation.slides[0]

    # Slayta bir kümeleme sütun grafiği ekleyin.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Lejant özelliklerini ayarlayın.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Sunumu diske kaydedin.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Lejant Yazı Tipi Boyutunu Ayarlama**

Bir grafiğin lejanti, açıkladığı veriler kadar okunaklı olmalıdır. Bu bölüm, lejantın yazı tipi boyutunu nasıl ayarlayarak sunumunuzun tipografisiyle eşleşeceğini ve erişilebilirliği artıracağını gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Bir grafik oluşturun.
1. Yazı tipi boyutunu ayarlayın.
1. Sunumu diske kaydedin.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Lejant Girdisinin Yazı Tipi Boyutunu Ayarlama**

Aspose.Slides, grafik lejantının görünümünü bireysel girişleri biçimlendirerek ince ayar yapmanıza olanak tanır. Aşağıdaki örnek, belirli bir lejant öğesini hedefleyip diğer lejant öğelerini etkilemeden özelliklerini nasıl ayarlayacağınızı gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Bir grafik oluşturun.
1. Bir lejant girişine erişin.
1. Giriş özelliklerini ayarlayın.
1. Sunumu diske kaydedin.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Lejantı etkinleştirerek grafiğin onu örtmek yerine otomatik olarak alan tahsis etmesini sağlayabilir miyim?**

Evet. Üst üste bindirme modunu devre dışı bırakın ([overlay](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/legend/overlay/) = `false`); bu durumda grafik alanı lejantı karşılayacak şekilde küçülür.

**Çok satırlı lejant etiketleri oluşturabilir miyim?**

Evet. Uzun etiketler, alan yetersiz olduğunda otomatik olarak satır sonuna girer; serinin adındaki yeni satır karakterleriyle zorunlu satır sonları da desteklenir.

**Lejant, sunum temasının renk şemasını nasıl takip eder?**

Lejant veya metni için açık renk/dolgu/yazı tipi ayarlamayın. Böylece tema tarafından devralınır ve tasarım değiştiğinde doğru şekilde güncellenir.