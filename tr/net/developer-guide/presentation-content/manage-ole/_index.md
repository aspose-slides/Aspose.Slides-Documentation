---
title: ".NET’te Sunumlarda OLE Nesnelerini Yönetme"
linktitle: "OLE Yönetimi"
type: docs
weight: 40
url: /tr/net/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlama ve Gömme
- OLE ekle
- OLE göm
- nesne ekle
- nesne göm
- dosya ekle
- dosya göm
- bağlanmış nesne
- bağlanmış dosya
- OLE değiştir
- OLE simgesi
- OLE başlığı
- OLE çıkar
- nesne çıkar
- dosya çıkar
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument dosyalarındaki OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) Microsoft teknolojisidir ve bir uygulamada oluşturulan veri ve nesnelerin, başka bir uygulamaya bağlama veya gömme yoluyla yerleştirilmesini sağlar. 

{{% /alert %}} 

MS Excel'de oluşturulan bir grafiği düşünün. Grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi bir simge olarak görünebilir. Bu durumda, simgeye çift tıkladığınızda grafik, ilişkili uygulamasında (Excel) açılır veya nesneyi açmak ya da düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi gerçek içeriğini, örneğin bir grafiğin içeriğini gösterebilir. Bu durumda grafik PowerPoint içinde etkinleştirilir, grafik arayüzü yüklenir ve PowerPoint içinde grafiğin verilerini değiştirebilirsiniz. 

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) slaytlara OLE nesnelerini OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)) olarak eklemenizi sağlar.

## **Slaytlara OLE Nesne Çerçeveleri Ekleme**

Microsoft Excel'de zaten bir grafik oluşturduğunuzu ve bunu Aspose.Slides for .NET kullanarak bir slayta OLE nesne çerçevesi olarak gömmek istediğinizi varsayarsak, bunu şu şekilde yapabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) sınıfından bir örnek oluşturun.
2. Slaytın referansını indeksine göre alın.
3. Excel dosyasını bayt dizisi olarak okuyun.
4. OLE nesnesi hakkında bayt dizisi ve diğer bilgileri içeren [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) çerçevesini slayta ekleyin.
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, bir Excel dosyasından bir grafiği Aspose.Slides for .NET kullanarak bir slayta [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) olarak ekledik.  
**Not**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) yapıcı, ikinci parametre olarak gömülebilir nesne uzantısını alır. Bu uzantı, PowerPoint'in dosya türünü doğru şekilde yorumlamasını ve bu OLE nesnesini açmak için doğru uygulamayı seçmesini sağlar.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // OLE nesnesi için veriyi hazırlayın.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // OLE nesne çerçevesini slayta ekleyin.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Bağlantılı OLE Nesne Çerçeveleri Ekleme**

Aspose.Slides for .NET, verileri gömmeden yalnızca dosyaya bir bağlantı ile bir [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) eklemenizi sağlar.

Bu C# kodu, bir slayta bağlantılı bir Excel dosyasıyla [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) eklemenin nasıl yapılacağını gösterir:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Bağlantılı bir Excel dosyasıyla OLE nesne çerçevesi ekleyin.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE Nesne Çerçevelerine Erişim**

Eğer bir OLE nesnesi zaten bir slayta gömülmüşse, onu bu şekilde kolaylıkla bulabilir veya erişebilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) sınıfından bir örnek oluşturarak yükleyin.
2. Slaytın referansını indeksini kullanarak alın.
3. [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) şekline erişin.
   Örneğimizde, yalnızca ilk slaytta bir şekli olan daha önce oluşturulmuş PPTX'i kullandık. Daha sonra bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) olarak *cast* ettik. Bu, erişilmesi gereken OLE nesne çerçevesiydi.
4. OLE nesne çerçevesine erişildiğinde, üzerinde herhangi bir işlem yapabilirsiniz.

Aşağıdaki örnekte, bir OLE nesne çerçevesine (bir slayta gömülmüş Excel grafik nesnesi) ve dosya verilerine erişilir.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // İlk şekli OLE nesne çerçevesi olarak al.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Gömülü dosya verisini al.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Gömülü dosyanın uzantısını al.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Bağlantılı OLE Nesne Çerçevesi Özelliklerine Erişim**

Aspose.Slides, bağlantılı OLE nesne çerçevesi özelliklerine erişmenizi sağlar.

Bu C# kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol etmeyi ve ardından bağlantılı dosyanın yolunu almayı gösterir:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // İlk şekli OLE nesne çerçevesi olarak alın.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // OLE nesnesinin bağlı olup olmadığını kontrol edin.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Bağlantılı dosyanın tam yolunu yazdır.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Var ise bağlantılı dosyanın göreli yolunu yazdır.
        // Yalnızca PPT sunumları göreli yolu içerebilir.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE Nesne Verilerini Değiştirme**

{{% alert color="info" title="Note" %}}

Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/) kullanmaktadır.

{{% /alert %}}

Eğer bir OLE nesnesi zaten bir slayta gömülmüşse, ona kolaylıkla erişebilir ve verilerini şu şekilde değiştirebilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) sınıfından bir örnek oluşturarak yükleyin.
2. Slaytın referansını indeksini kullanarak alın.
3. [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) şeklinde erişin.
   Örneğimizde, ilk slaytta bir şekli olan daha önce oluşturulmuş PPTX'i kullandık. Daha sonra bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) olarak *cast* ettik. Bu, erişilmesi gereken OLE nesne çerçevesiydi.
4. OLE nesne çerçevesine erişildiğinde, üzerinde herhangi bir işlem yapabilirsiniz.
5. Bir `Workbook` nesnesi oluşturun ve OLE verilerine erişin.
6. İstediğiniz `Worksheet`'a erişin ve verileri değiştirin.
7. Güncellenmiş `Workbook`'u bir akışta (stream) kaydedin.
8. Akıştan OLE nesne verilerini değiştirin.

Aşağıdaki örnekte, bir OLE nesne çerçevesine (bir slayta gömülmüş Excel grafik nesnesi) erişilir ve dosya verileri, grafik verilerini güncellemek için değiştirilir.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // İlk şekli OLE nesne çerçevesi olarak al.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // OLE nesne verisini bir Workbook nesnesi olarak okuyun.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Workbook verisini değiştirin.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // OLE çerçeve nesnesi verisini değiştirin.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Diğer Dosya Türlerini Slaytlara Gömme**

Excel grafiklerinin yanı sıra, Aspose.Slides for .NET slaytlara başka dosya türlerini de gömmenizi sağlar. Örneğin, HTML, PDF ve ZIP dosyalarını nesne olarak ekleyebilirsiniz. Bir kullanıcı eklenen nesneye çift tıkladığında, ilgili programda otomatik olarak açılır veya kullanıcıdan uygun bir program seçmesi istenir.

Bu C# kodu, bir slayta HTML ve ZIP'in nasıl gömüleceğini gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Gömülü Nesneler İçin Dosya Türlerini Ayarlama**

Sunumlarla çalışırken, eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for .NET, gömülü bir nesne için dosya türünü ayarlamanızı sağlar ve bu sayede OLE çerçeve verilerini veya uzantısını güncelleyebilirsiniz.

Bu C# kodu, gömülü bir OLE nesnesi için dosya türünü `zip` olarak ayarlamayı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Dosya türünü ZIP olarak değiştir.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Gömülü Nesneler İçin Simge Görüntüleri ve Başlıkları Ayarlama**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsü içeren bir ön izleme eklenir. Bu ön izleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Ön izlemede belirli bir görüntü ve metin kullanmak isterseniz, Aspose.Slides for .NET kullanarak simge görüntüsü ve başlığı ayarlayabilirsiniz.

Bu C# kodu, gömülü bir nesne için simge görüntüsü ve başlığı ayarlamayı gösterir: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Sunum kaynaklarına bir resim ekleyin.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // OLE ön izlemesi için bir başlık ve resmi ayarlayın.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önleme**

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, sunumu PowerPoint'te açtığınızda bağlantıları güncellemeniz istenen bir mesaj görebilirsiniz. "Update Links" (Bağlantıları Güncelle) düğmesine tıklamak, PowerPoint'in bağlantılı OLE nesnesinden verileri güncellemesi ve nesne ön izlemesini yenilemesi nedeniyle OLE nesne çerçevesinin boyut ve konumunu değiştirebilir. PowerPoint'in nesne verilerini güncelleme isteğini önlemek için, [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) arayüzünün `UpdateAutomatic` özelliğini `false` olarak ayarlayın:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // PowerPoint bağlantıyı güncellediğinde OLE nesne çerçevesinin boyut ve konumunu koruyun.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Gömülü Dosyaları Çıkarma**

Aspose.Slides for .NET, slaytlara gömülü dosyaları OLE nesneleri olarak şu şekilde çıkarmanıza olanak tanır:
1. Çıkarmak istediğiniz OLE nesnelerini içeren bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) sınıfının örneğini oluşturun.
2. Sunumdaki tüm şekillerde döngü yapın ve [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) şekillerine erişin.
3. OLE nesne çerçevelerindeki gömülü dosya verilerine erişin ve bunları diske yazın.

Bu C# kodu, bir slayta gömülü dosyaları OLE nesneleri olarak çıkarmayı gösterir:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **SSS**

**Slaytlar PDF/görsellere dışa aktarılırken OLE içeriği renderlanacak mı?**

Slaytta görünen şey renderlanır—ikon/değiştirici görüntü (ön izleme). "Canlı" OLE içeriği renderleme sırasında çalıştırılmaz. Gerekirse, dışa aktarılmış PDF'de beklenen görünümü sağlamak için kendi ön izleme görüntünüzü ayarlayın.  
Gömülü dosyayı PDF eki olarak da korumak için, [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) özelliğini `true` olarak ayarlayın. Bu seçenek varsayılan olarak devre dışıdır. Bir örnek ve eki kontrol etme talimatları için, bakınız [Preserve Embedded OLE Files as PDF Attachments](/slides/tr/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Bir OLE nesnesini bir slaytta kilitleyerek kullanıcıların PowerPoint'te taşımasını/düzenlemesini nasıl engelleyebilirim?**

Şekli kilitleyin: Aspose.Slides, [shape-level locks](/slides/tr/net/applying-protection-to-presentation/) sağlar. Bu şifreleme değildir, ancak kazara düzenlemeleri ve hareketi etkili bir şekilde önler.

**Bağlantılı bir Excel nesnesi, sunumu açtığımda neden "atlıyor" ya da boyutu değişiyor?**

PowerPoint, bağlantılı OLE'nin ön izlemesini yenileyebilir. Kararlı bir görünüm için, [Working Solution for Worksheet Resizing](/slides/tr/net/working-solution-for-worksheet-resizing/) uygulamalarını izleyin—ya çerçeveyi aralığa uydurun, ya da aralığı sabit bir çerçeveye ölçekleyin ve uygun bir değiştirici görüntü ayarlayın.

**Bağlantılı OLE nesneleri için göreli yollar PPTX formatında korunacak mı?**

PPTX formatında "göreli yol" bilgisi bulunmaz—yalnızca tam yol vardır. Göreli yollar, eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI'lar veya gömme tercih edin.