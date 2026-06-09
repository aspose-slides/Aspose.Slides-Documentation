---
title: PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm
type: docs
weight: 60
url: /tr/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafik yeniden boyutlandırma
- Excel grafiği
- OLE nesnesi
- grafik gömme
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile gömülü Excel OLE nesneleri kullanıldığında PPTX'te beklenmeyen grafik yeniden boyutlandırmayı düzeltin. Boyutların tutarlı kalmasını sağlayan iki yöntemi kod örnekleriyle öğrenin."
---
## **Arka Plan**

Aspose bileşenleri aracılığıyla bir PowerPoint sunumuna OLE nesnesi olarak gömülen Excel grafiklerinin, ilk etkinleştirilmelerinden sonra belirtilmemiş bir ölçeğe yeniden boyutlandırıldığı gözlemlenmiştir. Bu davranış, grafiğin etkinleştirilmiş öncesi ve sonrası durumları arasında belirgin bir görsel farklılığa yol açar. Aspose ekibi sorunu ayrıntılı olarak inceledi ve bir çözüm buldu. Bu makale sorunun nedenlerini ve ilgili düzeltmeyi açıklamaktadır.

[önceki makale](/slides/tr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)nde, Aspose.Cells for C++ ile bir Excel grafiği oluşturup Aspose.Slides for C++ kullanarak bu grafiği bir PowerPoint sunumuna OLE nesnesi olarak nasıl gömeceğinizi anlattık. [nesne önizleme sorunu](/slides/tr/cpp/object-preview-issue-when-adding-oleobjectframe/)nu gidermek için grafiğin resmini OLE nesnesi çerçevesine atadık. Çıktı sunumunda, grafiği gösteren OLE nesnesi çerçevesine çift‑tıkladığınızda Excel grafiği etkinleştirilir. Son kullanıcılar, temel Excel çalışma kitabında istedikleri değişiklikleri yapıp ardından etkinleştirilen çalışma kitabının dışına tıklayarak ilgili slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesnesi çerçevesinin boyutu değişir ve yeniden boyutlandırma faktörü, OLE nesnesi çerçevesinin ve gömülü Excel çalışma kitabının orijinal boyutlarına bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğundan, ilk etkinleştirilmesinde orijinal boyutunu korumaya çalışır. OLE nesnesi çerçevesinin ise kendi boyutu vardır. Microsoft’a göre, Excel çalışma kitabı etkinleştirildiğinde Excel ve PowerPoint boyutu müzakere eder ve gömme işleminin bir parçası olarak doğru oranları korur. Excel penceresi ile OLE nesnesi çerçevesinin boyut veya konum farklarına bağlı olarak yeniden boyutlandırma gerçekleşir.

## **Çözüm**

Aspose.Slides for C++ kullanarak PowerPoint sunumları oluşturmak için iki olası senaryo vardır.

**Senaryo 1:** Mevcut bir şablona dayalı bir sunum oluşturma.

**Senaryo 2:** Sıfırdan bir sunum oluşturma.

Burada sunulan çözüm her iki senaryoya da uygulanabilir. Tüm çözüm yaklaşımlarının temeli aynıdır: **gömülü OLE nesnesinin pencere boyutu, PowerPoint slaytındaki OLE nesnesi çerçevesiyle aynı olmalıdır**. Şimdi bu çözümün iki yaklaşımını tartışacağız.

## **Birinci Yaklaşım**

Bu yaklaşımda, gömülü Excel çalışma kitabının pencere boyutunu, PowerPoint slaydındaki OLE nesnesi çerçevesinin boyutuna eşit olacak şekilde ayarlamayı öğreneceğiz.

**Senaryo 1**

Bir şablon tanımladığımızı ve bu şablona dayalı sunumlar oluşturmak istediğimizi varsayalım. Şablonda, indeks 2'de bir şekil olduğunu ve bu şekle gömülü bir Excel çalışma kitabı içeren bir OLE çerçevesi yerleştirmek istediğimizi düşünelim. Bu senaryoda OLE nesnesi çerçevesinin boyutu önceden tanımlanmıştır — şablondaki indeks 2'deki şeklin boyutuna eşittir. Tek yapmamız gereken, çalışma kitabının pencere boyutunu bu şeklin boyutuna eşitlemektir. Aşağıdaki kod parçacığı bu amacı sağlar:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Pencere ile grafik boyutunu tanımla. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Çalışma kitabının pencere genişliğini inç cinsinden ayarla (PowerPoint 72 piksel/inç kullandığı için 72'ye bölünür).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Çalışma kitabının pencere yüksekliğini inç cinsinden ayarla.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Çalışma kitabını bir bellek akışına kaydet.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Gömülü Excel verisiyle bir OLE nesne çerçevesi oluştur.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**Senaryo 2**

Sıfırdan bir sunum oluşturmak ve gömülü bir Excel çalışma kitabı içeren istediğimiz boyutta bir OLE nesnesi çerçevesi eklemek istediğimizi düşünelim. Aşağıdaki kod parçacığında, slaytta x = 0.5 inç ve y = 1 inç konumunda, yüksekliği 4 inç ve genişliği 9,5 inç olan bir OLE nesnesi çerçevesi oluşturuyoruz. Ardından Excel çalışma kitabı penceresini aynı boyuta — yüksekliği 4 inç ve genişliği 9,5 inç — ayarlıyoruz.

```cpp
// İstediğimiz yükseklik.
int32_t desiredHeight = 288; // 4 inç (4 * 72)

// İstediğimiz genişlik.
int32_t desiredWidth = 684; // 9.5 inç (9.5 * 72)

// Pencere ile grafik boyutunu tanımla. 
chart->SetSizeWithWindow(true);

// Çalışma kitabının pencere genişliğini inç cinsinden ayarla.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Çalışma kitabının pencere yüksekliğini inç cinsinden ayarla.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Çalışma kitabını bir bellek akışına kaydet.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Gömülü Excel verisiyle bir OLE nesne çerçevesi oluştur.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **İkinci Yaklaşım**

Bu yaklaşımda, gömülü Excel çalışma kitabındaki grafiğin boyutunu, PowerPoint slaydındaki OLE nesnesi çerçevesinin boyutuna eşitlemeyi öğreneceğiz. Bu yaklaşım, grafik boyutu önceden biliniyorsa ve değişmeyecekse kullanışlıdır.

**Senaryo 1**

Bir şablon tanımladığımızı ve bu şablona dayalı sunumlar oluşturmak istediğimizi varsayalım. Şablonda, indeks 2'de bir şekil olduğunu ve bu şekle gömülü bir Excel çalışma kitabı içeren bir OLE çerçevesi yerleştirmek istediğimizi düşünelim. Bu senaryoda OLE çerçevesi boyutu önceden tanımlanmıştır — şablondaki indeks 2'deki şeklin boyutuna eşittir. Tek yapmamız gereken, çalışma kitabındaki grafiğin boyutunu bu şeklin boyutuna eşitlemektir. Aşağıdaki kod parçacığı bu amacı sağlar:

```cpp
// Pencere olmadan grafik boyutunu tanımla. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Grafiğin genişliğini piksel cinsinden ayarla (Excel inç başına 96 piksel kullandığı için 96 ile çarpın).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Grafiğin yüksekliğini piksel cinsinden ayarla.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Grafik baskı boyutunu tanımla.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Çalışma kitabını bir bellek akışına kaydet.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Gömülü Excel verisiyle bir OLE nesne çerçevesi oluştur.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**Senaryo 2**

Sıfırdan bir sunum oluşturmak ve gömülü bir Excel çalışma kitabı içeren istediğimiz boyutta bir OLE nesnesi çerçevesi eklemek istediğimizi düşünelim. Aşağıdaki kod parçacığında, slaytta x = 0.5 inç ve y = 1 inç konumunda, yüksekliği 4 inç ve genişliği 9,5 inç olan bir OLE nesnesi çerçevesi oluşturuyoruz. Ayrıca ilgili grafik boyutunu da aynı boyutlara — yüksekliği 4 inç ve genişliği 9,5 inç — ayarlıyoruz.

```cpp
// İstediğimiz yükseklik.
int32_t desiredHeight = 288; // 4 inç (4 * 576)

// İstediğimiz genişlik.
int32_t desiredWidth = 684; // 9.5 inç (9.5 * 576)

// Pencere olmadan grafik boyutunu tanımla. 
chart->SetSizeWithWindow(false);

// Grafiğin genişliğini piksel cinsinden ayarla.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Grafiğin yüksekliğini piksel cinsinden ayarla.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Çalışma kitabını bir bellek akışına kaydet.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Gömülü Excel verisiyle bir OLE nesne çerçevesi oluştur.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Sonuç**

Grafik yeniden boyutlandırma sorununu çözmek için iki yaklaşım vardır. Yaklaşım seçimi gereksinimlere ve kullanım senaryosuna bağlıdır. Her iki yaklaşım da şablondan veya sıfırdan oluşturulan sunumlarda aynı şekilde çalışır. Ayrıca bu çözümde OLE nesnesi çerçevesinin boyutu için bir sınırlama yoktur.

## **SSS**

**Gömülü Excel grafiğim PowerPoint’te etkinleştirildikten sonra neden boyut değiştiriyor?**

Bu, Excel’in ilk etkinleştirildiğinde orijinal pencere boyutunu geri yüklemeye çalışması, PowerPoint’teki OLE nesnesi çerçevesinin ise kendi boyutlarına sahip olmasından kaynaklanır. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder ve bu da yeniden boyutlandırmaya yol açabilir.

**Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?**

Evet. Excel çalışma kitabı pencere boyutunu veya grafik boyutunu OLE nesnesi çerçevesi boyutuna eşitleyerek, grafik boyutlarını tutarlı tutabilirsiniz.

**Hangi yaklaşımı tercih etmeliyim, pencere boyutunu mu yoksa grafik boyutunu mu ayarlamalıyım?**

**Yaklaşım 1 (pencere boyutu)**’nu, çalışma kitabının en‑boy oranını korumak ve daha sonra yeniden boyutlandırma olanağı sağlamak istiyorsanız kullanın.  
**Yaklaşım 2 (grafik boyutu)**’nu, grafik boyutları sabit ise ve gömülmeden sonra değişmeyecekse kullanın.

**Bu yöntemler şablon‑tabanlı sunumlar ve yeni oluşturulan sunumlar için de çalışır mı?**

Evet. Her iki yaklaşım da şablonlardan oluşturulan ve sıfırdan oluşturulan sunumlarda aynı şekilde çalışır.

**OLE nesnesi çerçevesinin boyutu için bir sınırlama var mı?**

Hayır. OLE çerçevesini, çalışma kitabı veya grafik boyutuna uygun şekilde ölçeklendirebildiğiniz sürece istediğiniz boyutta ayarlayabilirsiniz.

**Bu yöntemleri diğer elektronik tablo programlarıyla oluşturulan grafiklerde kullanabilir miyim?**

Örnekler, Aspose.Cells ile oluşturulan Excel grafikleri için tasarlanmıştır, ancak aynı boyutlandırma seçeneklerini destekleyen diğer OLE‑uyumlu elektronik tablo programları için de prensipler geçerlidir.

## **İlgili Bölümler**

- [Excel Grafiklerini Oluşturma ve Sunumlarda OLE Nesnesi Olarak Gömme](/slides/tr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)