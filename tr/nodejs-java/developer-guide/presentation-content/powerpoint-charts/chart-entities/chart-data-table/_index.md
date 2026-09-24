---
title: JavaScript Kullanarak Sunumlarda Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/nodejs-java/chart-data-table/
keywords:
- grafik verisi
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint sunumlarında grafik veri tablo yazı tiplerini, kenarlıkları ve efsane anahtarlarını özelleştirin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, bir grafiğin veri tablosunu görüntülemenizi ve metin biçimlendirmesini, kenarlıkları ve efsane anahtarlarını özelleştirmenizi sağlar. Bu makale, tabloyu nasıl etkinleştireceğinizi, metnini nasıl biçimlendireceğinizi, her kenarlık tipini nasıl kontrol edeceğinizi ve efsane anahtarlarını nasıl göstereceğinizi veya gizleyeceğinizi açıklar. Örnekler, yapılandırılmış grafikleri PPTX dosyalarına kaydeder.

## **Yazı Tipi Özelliklerini Ayarla**

Bir grafiğin veri tablosunu görüntülemek için `true` değerini [setDataTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/setdatatable/) metoduna iletin. Tabloya erişmek ve metin biçimlendirmesini yapılandırmak için [getChartDataTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/getchartdatatable/) metodunu kullanın.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. İlk slayta bir clustered column grafiği ekleyin.
1. Grafiğin veri tablosunu etkinleştirin.
1. [setFontBold](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setfontbold) ile kalın metni etkinleştirin ve 20 puanlık metin için `20` değerini [setFontHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setfontheight) metoduna iletin.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, çalışma dizininde en az bir slayt içeren `input.pptx` dosyasını gerektirir. (50, 50) konumunda, 600 puan genişliğinde ve 400 puan yüksekliğinde, varsayılan verilerle bir grafik ekler. Kaydedilen `output.pptx`, veri tablosu etkinleştirilmiş grafik ve belirtilen yazı tipi ayarlarını içerir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Veri Tablosu Kenarlıklarını Özelleştir**

Tabloyu [Chart.setDataTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/setdatatable/) ile etkinleştirin ve [Chart.getChartDataTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/getchartdatatable/) ile erişin. Üç kenarlık türünü bağımsız olarak kontrol edebilirsiniz:

- [setBorderHorizontal](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/datatable/setborderhorizontal/) yatay hücre kenarlıklarını kontrol eder.
- [setBorderVertical](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/datatable/setbordervertical/) dikey hücre kenarlıklarını kontrol eder.
- [setBorderOutline](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/datatable/setborderoutline/) tablonun dış kenarlığını kontrol eder.

`true` değerini her metoda ileterek kenarlıkları görüntüleyebilir veya `false` ile gizleyebilirsiniz. Aşağıdaki örnek, varsayılan verilerle bir clustered column grafiği oluşturur, yatay kenarlıkları ve dış kenarlığı gösterir ve dikey kenarlıkları gizler. Herhangi bir giriş dosyası gerekmez. Grafiğin konumu ve boyutu puan cinsinden belirtilir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki karşılaştırma, dört durumda da aynı grafik verilerini ve efsane anahtarı ayarını kullanır. Tüm kenarlıklar etkinleştirilmiş olarak başlanır, kalan her varyant sadece bir kenarlık ayarını devre dışı bırakır. Sol alt varyant, örnekteki kenarlık ayarlarıyla eşleşir.

![Tüm kenarlıkları etkin, yatay kenarlık yok, dikey kenarlık yok ve dış kenarlık yok olan grafik veri tabloları](data-table-borders.png)

## **Efsane Anahtarlarını Göster veya Gizle**

Efsane anahtarları, veri tablosundaki seri adlarının yanındaki küçük renkli işaretçilerdir. Okuyucuların her tablo satırını bir grafik serisine eşleştirmesine yardımcı olur. Bu işaretçileri göstermek için [setShowLegendKey](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/datatable/setshowlegendkey/) metoduna `true` değerini, gizlemek için `false` değerini iletin.

Grafiğin ayrı efsanesi, [Chart.setLegend](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/setlegend/) ile kontrol edilir. Bu ayarlar bağımsızdır: ayrı efsaneyi gizlemek, veri tablosundaki anahtarları gizlemez ve tablodaki anahtarları gizlemek, ayrı efsaneyi gizlemez.

Aşağıdaki örnek, varsayılan verilerle bir grafik oluşturur, veri tablosunu etkinleştirir ve ayrı efsaneyi gizlerken içinde efsane anahtarlarını gösterir. Tüm tablo kenarlıkları açıkça etkinleştirilir. Giriş sunumu gerekmez. Sadece tablonun anahtarlarını gizlemek için [setShowLegendKey](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/datatable/setshowlegendkey/) metoduna `false` değerini iletin.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki karşılaştırma, aynı tabloyu efsane anahtarları etkin ve devre dışı olarak gösterir. Tüm kenarlıklar etkin kalır ve ayrı grafik efsanesi her iki durumda da gizlidir.

![Sol tarafta efsane anahtarları gösterilen ve sağ tarafta gizlenen grafik veri tabloları](data-table-legend-keys.png)

## **SSS**

**Grafiğin veri tablosunda efsane anahtarlarını gösterebilir miyim?**  
Evet. Efsane anahtarlarını görüntülemek için [setShowLegendKey](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/datatable/setshowlegendkey/) metoduna `true`, gizlemek için `false` değerini iletin.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunur mu?**  
Evet. Aspose.Slides, grafiği ve görüntülenen veri tablosunu slaytın bir parçası olarak [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/) veya [images](/slides/tr/nodejs-java/convert-powerpoint-to-png/) dışa aktarırken işler.

**Şablondan yüklenen grafiklerde veri tablolarıyla çalışabilir miyim?**  
Evet. Mevcut bir sunumdan veya şablondan yüklenen bir grafik için, veri tablosunun görüntülenip görüntülenmediğini kontrol etmek veya değiştirmek amacıyla [hasDataTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/hasdatatable/) ve [setDataTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/setdatatable/) metodlarını kullanın.

**Veri tablosu etkin olan grafikleri nasıl bulabilirim?**  
Her slayttaki şekilleri döngüyle gezerek, grafikleri belirleyin ve onların [hasDataTable](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/hasdatatable/) metodunu çağırın. `true` değeri, veri tablosunun etkin olduğunu gösterir.