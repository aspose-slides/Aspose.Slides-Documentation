---
title: Excel Grafikleri Oluşturun ve Sunumlarda OLE Nesneleri Olarak Gömün
type: docs
weight: 30
url: /tr/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafiği
- grafiği göm
- OLE nesnesi
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Java aracılığıyla Node.js için Aspose.Cells kullanarak bir Excel grafiği oluşturun ve çalışma kitabını Aspose.Slides ile bir PowerPoint sunumuna, grafik önizlemesi dahil olmak üzere, gömün."
---
## **Genel Bakış**

Bu makale, Java aracılığıyla Node.js için Aspose.Cells kullanarak bir Excel sütun grafiği oluşturmayı ve çalışma kitabını Java aracılığıyla Node.js için Aspose.Slides kullanarak bir PowerPoint sunumuna yerleştirmeyi gösterir. Yerleştirilen çalışma kitabı hem kaynak verileri hem de grafiği içerir. Ayrı bir PNG önizleme, OLE nesnesi etkinleştirilmeden önce slaytta grafiği gösterir.

Sonuç, yerel bir PowerPoint grafiği değil, yerleştirilmiş bir Excel nesnesidir. OLE aracılığıyla çalışma kitabını düzenlemek, OLE etkinleştirmesini destekleyen bir masaüstü uygulaması ve uyumlu bir Excel kurulumunu gerektirir.

## **Ön Koşullar**

`aspose.cells`, `aspose.slides.via.java` ve `java` Node.js paketlerini kurun. Örnekleri iki CommonJS betiği olarak ayrı Node.js işlemlerinde çalıştırın: önce `create-chart.js`, ardından `embed-chart.js`, aynı çalışma dizinini kullanarak. Her iki Aspose paketi de yükleme sırasında Java köprüsünü başlattığından, bu örnekler paketleri ayrı işlemlerde tutar. Bu kütüphanelerle sunum oluşturmak için Microsoft Office gerekmez.

Mevcut bir çalışma kitabı veya resim gerekmiyor. İlk betik `ChartWorkbook.xlsx` ve `ChartPreview.png` oluşturur; ikincisi bu dosyaları okur ve `OutputChart.pptx` dosyasını mevcut çalışma dizinine yazar. Değerlendirme modunun dışındaysanız, her iki ürün için de lisansları uygulayın.

## **Gömmenin Nasıl Çalıştığı**

1. Veri çalışma sayfası ve grafik sayfası içeren bir çalışma kitabı oluşturun.  
1. Grafik sayfasını aktif hâle getirin, böylece çalışma kitabı grafiğiyle açılır.  
1. Çalışma kitabının OLE görüntüleme aralığını ayarlayın ve grafiği PNG olarak render edin.  
1. Çalışma kitabını XLSX olarak kaydedin ve baytlarını ayrı bir Node.js işleminde bir slayta gömün.  
1. PNG'yi OLE nesnesinin önizlemesi olarak atayın ve sunumu PPTX olarak kaydedin.  

Çalışma kitabı görüntüleme aralığı ve slayt çerçevesi farklı rollere sahiptir. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) sıfır‑tabanlı başlangıç/bitiş satır ve sütun indekslerini alır. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) ise üst satırı, sol sütunu, alt satırı ve sağ sütunu alır. Örnek, alt‑sağ sınır olarak satır indeksi 55 ve sütun indeksi 25 kullanır; bu değerler düzen tercihleridir, veri satır veya sütun sayısını göstermez.

Slayt çerçevesi puan (point) biriminde ölçülür. Örnek, çerçeveyi slayt içinde sığdırır, ortalar ve PNG'nin en‑boy oranını korur; önizleme slaytı doldurmak için gerilmez.

## **Grafiği Oluşturma ve Yerleştirme**

İlk örneği `create-chart.js` olarak kaydedin. `DataSheet`i dört satır ve beş sütun değerle doldurur. Her satır bir grafik serisi olur. `ChartSheet`, çalışma kitabı kaydedilmeden önce aktif sayfa olarak seçilir.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Grafik önizlemesini oluştur ve düzenlenebilir çalışma kitabını ayrı ayrı serileştir.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Tüm eşzamanlı işlemler tamamlandı; Java köprü sürecini durdur.
process.exit(0);
```

Aşağıdaki örneği `embed-chart.js` olarak kaydedin. `create-chart.js` iki giriş dosyasını oluşturduktan sonra çalıştırın. OLE çerçevesini ortalar ve önizleme görüntüsünün en‑boy oranını korur.

İkinci betik, kaydedilen çalışma kitabını yerleştirir ve PNG'yi önizleme olarak kullanır. Çalışma kitabı açıkça XLSX olarak kaydedilir ve `xlsx` uzantısı [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/) aracılığıyla geçirilir. PNG, ara bir bitmap dönüşümü olmadan doğrudan baytlarından yüklenir. Java köprüsü, görüntü ve çalışma kitabı verileri için açık Java byte dizileri, slayt çerçevesi koordinatları için ise Java float değerleri gerektirir. [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) aracılığıyla atanması, varsayılan OLE yer tutucusunu değiştirir.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Önizlemeyi slayt içinde en‑boy oranını değiştirmeden sığdır.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Tüm eşzamanlı işlem tamamlandı; Java köprü sürecini durdur.
process.exit(0);
```

## **Beklenen Sonuç**

`OutputChart.pptx` bir slayt içerir; bu slaytta yerleştirilmiş bir Excel çalışma kitabı ve bir grafik önizlemesi bulunur. Çalışma kitabı orijinal verileri ve dört serili bir sütun grafiğini içerir. Önizleme slayt ortasında konumlanır ve oranını korur.

![Yerleştirilmiş bir çalışma kitabının önizlemesi olarak gösterilen Excel sütun grafiği](excel-chart-ole-preview.png)

Uyumlu bir masaüstü PowerPoint ortamında Excel kuruluysa, nesneye çift tıklayarak yerleştirilmiş çalışma kitabını etkinleştirip düzenleyebilirsiniz. Etkinleştirme ve düzenleme, ana uygulamanın OLE desteği ve güvenlik ayarlarına bağlıdır.

## **SSS**

**Neden bir önizleme resmi gerekir?**

Yerleştirilmiş çalışma kitabı ve slayt önizlemesi ayrı içeriklerdir. Slaytta varsayılan “EMBEDDED OLE OBJECT” yer tutucusu yerine grafiği göstermek için bir grafik resmi sağlayın. bkz. [OleObjectFrame Ekleme Sırasında Nesne Önizleme Sorunu](/slides/tr/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**Kod içinde çalışma kitabını değiştirdiğimde önizleme otomatik olarak güncellenir mi?**

Önizleme bir anlık görüntü olarak değerlendirilir. Çalışma kitabı verileri programatik olarak güncellendiğinde, grafik resmi yeniden oluşturulmalı ve hem önizleme hem de yerleştirilmiş çalışma kitabı verileri yeniden yerleştirilmelidir.

**XLS yerine XLSX kullanabilir miyim?**

Evet. Çalışma kitabını XLS formatında kaydedin ve `xls` uzantısını yerleştirilmiş veri uzantısı olarak kullanın. Uzantı gerçek çalışma kitabı formatıyla eşleşmelidir; yalnızca uzantıyı değiştirmek veriyi dönüştürmez.

**Nesne etkinleştirildikten sonra boyutu neden değişebilir?**

Ana uygulama, çalışma kitabı etkinleştirildiğinde OLE nesnesinin sunumunu güncelleyebilir. Çalışma kitabının OLE görüntüleme aralığı ve slayt çerçevesi boyutları her ikisi de önem taşır. bkz. [PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm](/slides/tr/java/working-solution-for-chart-resizing-in-pptx/).

## **İlgili Bölümler**

- [PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm](/slides/tr/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame Ekleme Sırasında Nesne Önizleme Sorunu](/slides/tr/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)