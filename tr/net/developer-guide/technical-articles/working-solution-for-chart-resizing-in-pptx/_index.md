---
title: PPTX'te Grafik Yeniden Boyutlandırma İçin Çalışan Çözüm
type: docs
weight: 60
url: /tr/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafik yeniden boyutlandırma
- Excel grafiği
- OLE nesnesi
- grafik gömme
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile gömülü Excel OLE nesneleri kullanıldığında PPTX'te beklenmeyen grafik yeniden boyutlandırmayı düzeltin. Boyutların tutarlı kalmasını sağlayan iki yöntemi kod örnekleriyle öğrenin."
---
## **Arka Plan**

Aspose bileşenleri aracılığıyla PowerPoint sunumuna OLE nesneleri olarak gömülen Excel grafiklerinin ilk etkinleştirilmelerinden sonra belirlenmemiş bir ölçeğe yeniden boyutlandırıldığı gözlemlenmiştir. Bu davranış, grafiğin etkinleştirilmeden önceki ve sonraki durumları arasında sunumda fark edilir bir görsel fark oluşturur. Aspose ekibi sorunu ayrıntılı bir şekilde araştırdı ve bir çözüm buldu. Bu makale sorunun nedenlerini ve ilgili çözümü açıklamaktadır.

Önceki makalede[önceki makale](/slides/tr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), Aspose.Cells for .NET ile bir Excel grafiği oluşturup Aspose.Slides for .NET kullanarak bir PowerPoint sunumuna nasıl gömeceğimizi açıkladık. [nesne önizleme sorunu](/slides/tr/net/object-preview-issue-when-adding-oleobjectframe/) ele almak için grafiğin resmini grafik OLE nesne çerçevesine atadık. Çıktı sunumda, grafik görüntüsü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel grafiği etkinleştirilir. Son kullanıcılar, alttaki Excel çalışma kitabında istedikleri değişiklikleri yapabilir ve ardından etkinleştirilen çalışma kitabının dışına tıklayarak ilgili slayta geri dönebilir. Kullanıcı slayta geri döndüğünde OLE nesne çerçevesinin boyutu değişir ve yeniden boyutlandırma faktörü, OLE nesne çerçevesi ile gömülü Excel çalışma kitabının orijinal boyutlarına bağlı olarak değişir.

## **Yeniden Boyutlandırma Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğu için, ilk etkinleştirildiğinde özgün boyutunu korumaya çalışır. Ancak OLE nesne çerçevesinin de kendine özgü bir boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint boyutu müzakere eder ve gömme sürecinin bir parçası olarak doğru oranları korur. Excel pencere boyutu ile OLE nesne çerçevesinin boyutu ya da konumu arasındaki farklara bağlı olarak yeniden boyutlandırma gerçekleşir.

## **Çözüm**

Aspose.Slides for .NET kullanarak PowerPoint sunumları oluşturmak için iki olası senaryo vardır.

**Senaryo 1:** Mevcut bir şablona dayanarak bir sunum oluşturun.

**Senaryo 2:** Sıfırdan bir sunum oluşturun.

Burada sunduğumuz çözüm her iki senaryoya da uygulanabilir. Tüm çözüm yaklaşımlarının temeli aynı: **gömülü OLE nesnesinin pencere boyutu, PowerPoint slaytındaki OLE nesne çerçevesiyle eşleşmelidir**. Şimdi bu çözüme yönelik iki yaklaşımı tartışacağız.

## **İlk Yaklaşım**

Bu yaklaşımda, gömülü Excel çalışma kitabının pencere boyutunu, PowerPoint slaydındaki OLE nesne çerçevesinin boyutuyla eşleşecek şekilde nasıl ayarlayacağımızı öğreneceğiz.

**Senaryo 1**

Bir şablon tanımladığımızı ve buna göre sunumlar oluşturmak istediğimizi varsayalım. Şablonda indeks 2'de, gömülü bir Excel çalışma kitabı içeren bir OLE çerçevesi yerleştirmek istediğimiz bir şeklin olduğunu kabul edelim. Bu senaryoda, OLE nesne çerçevesinin boyutu önceden tanımlanmıştır—şeklin indeks 2'deki boyutuyla eşleşir. Tek yapmamız gereken, çalışma kitabının pencere boyutunu o şeklin boyutuna eşitlemektir. Aşağıdaki kod parçacığı bu amacı hizmet eder:

```cs
// Pencere ile grafik boyutunu tanımla.
chart.SizeWithWindow = true;

// Çalışma kitabının pencere genişliğini inç olarak ayarla (PowerPoint 72 piksel/inç kullandığından 72'ye bölünür).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Çalışma kitabının pencere yüksekliğini inç olarak ayarla.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Çalışma kitabını bir bellek akışına kaydet.
MemoryStream workbookStream = workbook.SaveToStream();

// Gömülü Excel verisiyle bir OLE nesne çerçevesi oluştur.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Senaryo 2**

Başlangıçtan bir sunum oluşturmak ve gömülü bir Excel çalışma kitabı içeren herhangi bir boyutta OLE nesne çerçevesi eklemek istediğimizi varsayalım. Aşağıdaki kod parçacığında, slayt üzerindeki x = 0.5 inç ve y = 1 inç konumunda, yüksekliği 4 inç ve genişliği 9.5 inç olan bir OLE nesne çerçevesi oluşturuyoruz. Ardından Excel çalışma kitabı penceresini aynı boyuta, yani yüksekliği 4 inç ve genişliği 9.5 inç olarak ayarlarız.

```cs
// İstediğimiz yükseklik.
int desiredHeight = 288; // 4 inç (4 * 72)

// İstediğimiz genişlik.
int desiredWidth = 684;//9.5 inç (9.5 * 72)

// Pencere ile grafik boyutunu tanımla.
chart.SizeWithWindow = true;

// Çalışma kitabının pencere genişliğini inç olarak ayarla.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Çalışma kitabının pencere yüksekliğini inç olarak ayarla.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Çalışma kitabını bir bellek akışına kaydet.
MemoryStream workbookStream = workbook.SaveToStream();

// Gömülü Excel verisiyle bir OLE nesne çerçevesi oluştur.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **İkinci Yaklaşım**

Bu yaklaşımda, gömülü Excel çalışma kitabındaki grafiğin boyutunu PowerPoint slaydındaki OLE nesne çerçevesinin boyutuyla eşleşecek şekilde nasıl ayarlayacağımızı öğreneceğiz. Bu yaklaşım, grafik boyutu önceden biliniyorsa ve hiçbir zaman değişmeyecekse kullanışlıdır.

**Senaryo 1**

Bir şablon tanımladığımızı ve buna göre sunumlar oluşturmak istediğimizi varsayalım. Şablonda indeks 2'de, gömülü bir Excel çalışma kitabı içeren bir OLE çerçevesi yerleştirmek istediğimiz bir şeklin olduğunu kabul edelim. Bu senaryoda, OLE çerçevesinin boyutu önceden tanımlanmıştır—şeklin indeks 2'deki boyutuyla eşleşir. Tek yapmamız gereken, çalışma kitabındaki grafiğin boyutunu o şeklin boyutuna eşitlemektir. Aşağıdaki kod parçacığı bu amacı hizmet eder:

```cs
// Pencere olmadan grafik boyutunu tanımla.
chart.SizeWithWindow = false;

// Grafiğin genişliğini piksel olarak ayarla (Excel'in inç başına 96 piksel kullandığını göz önünde bulundurarak 96 ile çarpın).
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Grafiğin yüksekliğini piksel olarak ayarla.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Grafik baskı boyutunu tanımla.
chart.PrintSize = PrintSizeType.Custom;

// Çalışma kitabını bir bellek akışına kaydet.
MemoryStream workbookStream = workbook.SaveToStream();

// Gömülü Excel verisiyle bir OLE nesne çerçevesi oluştur.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Senaryo 2**

Sıfırdan bir sunum oluşturmak ve gömülü bir Excel çalışma kitabı içeren herhangi bir boyutta OLE nesne çerçevesi eklemek istediğimizi varsayalım. Aşağıdaki kod parçacığında, slayt üzerindeki x = 0.5 inç ve y = 1 inç konumunda, yüksekliği 4 inç ve genişliği 9.5 inç olan bir OLE nesne çerçevesi oluşturuyoruz. Ayrıca ilgili grafik boyutunu aynı ölçülere ayarlıyoruz: yüksekliği 4 inç ve genişliği 9.5 inç.

```cs
 // İstediğimiz yükseklik.
int desiredHeight = 288; // 4 inç (4 * 576)

// İstediğimiz genişlik.
int desiredWidth = 684; // 9.5 inç (9.5 * 576)

// Pencere olmadan grafik boyutunu tanımla.
chart.SizeWithWindow = false;

// Grafiğin genişliğini piksel olarak ayarla.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Grafiğin yüksekliğini piksel olarak ayarla.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Çalışma kitabını bir bellek akışına kaydet.
MemoryStream workbookStream = workbook.SaveToStream();

// Gömülü Excel verisiyle bir OLE nesne çerçevesi oluştur.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Sonuç**

Grafik yeniden boyutlandırma sorununu gidermek için iki yaklaşım vardır. Yaklaşım seçimi gereksinimlere ve kullanım senaryosuna bağlıdır. Her iki yaklaşım da şablondan oluşturulan ya da sıfırdan oluşturulan sunumlarda aynı şekilde çalışır. Ayrıca bu çözümde OLE nesne çerçevesinin boyutu için bir sınırlama yoktur.

## **SSS**

**PowerPoint'te etkinleştirdikten sonra gömülü Excel grafiğim neden boyut değiştiriyor?**  
Bu, Excel'in ilk etkinleştirildiğinde özgün pencere boyutunu geri getirmeye çalışması, PowerPoint'teki OLE nesne çerçevesinin ise kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder, bu da yeniden boyutlandırmaya yol açabilir.

**Bu yeniden boyutlandırma sorununu tamamen önlemek mümkün mü?**  
Evet. OLE nesne çerçevesi boyutuna göre Excel çalışma kitabı pencere boyutunu veya grafik boyutunu eşleştirerek, grafik boyutlarının tutarlı kalmasını sağlayabilirsiniz.

**Hangi yaklaşımı seçmeliyim, çalışma kitabı pencere boyutunu ayarlamayı mı yoksa grafik boyutunu mu?**  
**Yaklaşım 1 (pencere boyutu)**, çalışma kitabının en boy oranını korumak ve ileride yeniden boyutlandırma izni vermek istiyorsanız.  
**Yaklaşım 2 (grafik boyutu)**, grafik boyutları sabit ise ve gömüldükten sonra değişmeyecekse.

**Bu yöntemler hem şablon tabanlı hem de yeni sunumlarda çalışır mı?**  
Evet. Her iki yaklaşım da şablondan oluşturulan ve sıfırdan oluşturulan sunumlar için aynı şekilde çalışır.

**OLE nesne çerçevesinin boyutu için bir limit var mı?**  
Hayır. OLE çerçevesini, çalışma kitabı veya grafik boyutuna uygun şekilde ölçeklendirebildiğiniz sürece istediğiniz boyuta ayarlayabilirsiniz.

**Bu yöntemleri başka tablo programlarıyla oluşturulan grafiklerde kullanabilir miyim?**  
Örnekler, Aspose.Cells ile oluşturulan Excel grafikleri için tasarlanmıştır, ancak aynı boyutlandırma seçeneklerini destekleyen diğer OLE uyumlu tablo programları için de aynı prensipler geçerlidir.

## **İlgili Bölümler**

- [Excel Grafiklerini Oluşturma ve Sunumlarda OLE Nesneleri Olarak Gömme](/slides/tr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelleme](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)