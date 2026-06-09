---
title: Aspose.Slides for .NET 14.8.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 14.8.0
type: docs
weight: 100
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizin sorunsuz bir şekilde taşınmasını sağlayın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for .NET 14.8.0 API'siyle tanıtılan eklenen [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) veya [çıkarılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
### **Değiştirilen Özellikler**
#### **IVbaProject Arayüzü Eklendi, Presentation.VbaProject Özelliği Değiştirildi**
Presentation sınıfının VbaProject özelliği değiştirilmiştir. VBA projesinin ham bayt temsili yerine yeni IVbaProject arayüzü uygulanmıştır.

VBA projelerini sunum içinde yönetmek için IVbaProject özelliğini kullanın. Yeni proje referansları ekleyebilir, mevcut modülleri düzenleyebilir ve yeni modüller oluşturabilirsiniz.

Ayrıca, IVbaProject arayüzünü uygulayan VbaProject sınıfını kullanarak yeni bir VBA projesi oluşturabilirsiniz.

Aşağıdaki örnek, bir modül içeren basit bir VBA projesi oluşturulmasını ve kütüphanelere iki gerekli referans eklenmesini gösterir.

``` csharp

 using (Presentation pres = new Presentation())

{

    // Yeni VBA Projesi Oluştur

    pres.VbaProject = new VbaProject();

    // VBA projesine boş modül ekle

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Modül kaynak kodunu ayarla

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // <stdole> referansı oluştur

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Office referansı oluştur

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // VBA projesine referanslar ekle

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

Bu örnek, mevcut bir sunumdan yeni bir sunuma VBA projesinin nasıl kopyalanacağını gösterir.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Arayüzler, Özellikler ve Sıralama Seçenekleri Eklendi**
#### **Aspose.Slides.Charts.IChartSeries.Overlap Özelliği Eklendi**
Aspose.Slides.Charts.IChartSeries.Overlap özelliği, 2D grafiklerde çubukların ve sütunların ne kadar üst üste geleceğini (-100 ile 100 arasında) belirler.

Bu özellik yalnızca bu seriye değil, üst seriler grubundaki tüm serilere uygulanır; yani uygun grup özelliğinin bir yansımasıdır. Bu nedenle özellik yalnızca okunabilir durumdadır.

- Üst seriler grubuna erişmek için ParentSeriesGroup özelliğini kullanın.
- Değeri değiştirmek için ParentSeriesGroup.Overlap okuma/yazma özelliğini kullanın.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}

``` 
#### **Aspose.Slides.Charts.IChartSeriesGroup.Overlap Özelliği Eklendi**
Aspose.Slides.Charts.IChartSeriesGroup.Overlap özelliği, 2D grafiklerde çubukların ve sütunların ne kadar üst üste geleceğini (-100 ile 100 arasında) belirler.

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **ShapeThumbnailBounds.Appearance Enum Değeri Eklendi**
Bu şekil küçük resim oluşturma yöntemi, küçük resmi şeklin görünüm sınırları içinde üretmenizi sağlar. Tüm şekil efektlerini dikkate alır. Oluşturulan küçük resim slayt sınırlarıyla kısıtlanır.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```