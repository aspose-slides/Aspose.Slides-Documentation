---
title: .NET ile Sunumlarda OLE Nesnelerini Yönetme
linktitle: OLE'yi Yönet
type: docs
weight: 40
url: /tr/net/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlantısı ve Gömme
- OLE ekle
- OLE göm
- nesne ekle
- nesne göm
- dosya ekle
- dosya göm
- bağlantılı nesne
- bağlantılı dosya
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
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding), bir uygulamada oluşturulan veri ve nesnelerin başka bir uygulamaya bağlantı veya gömme yoluyla yerleştirilmesini sağlayan bir Microsoft teknolojisidir. 

{{% /alert %}} 

Microsoft Excel'de oluşturulan bir grafiği düşünün. Bu grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi bir simge olarak görünebilir. Bu durumda simgeye çift‑tıkladığınızda grafik, ilişkili uygulamasında (Excel) açılır ya da nesneyi açmak veya düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi gerçek içeriğini, örneğin bir grafiğin içeriğini gösterebilir. Bu durumda grafik PowerPoint içinde etkinleştirilir, grafik arayüzü yüklenir ve grafiğin verilerini PowerPoint içinde değiştirebilirsiniz.

[Aspose.Slides for .NET](https://products.aspose.com/slides/tr/net/) slaytlara OLE nesnelerini OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe)) olarak eklemenize olanak tanır.

## **Slaytlara OLE Nesne Çerçeveleri Ekleme**

Microsoft Excel'de zaten bir grafik oluşturduğunuzu ve bunu Aspose.Slides for .NET kullanarak bir OLE nesne çerçevesi olarak slayta gömmek istediğinizi varsayalım; bunu şu şekilde yapabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. İndeksini kullanarak bir slaytın referansını alın.  
3. Excel dosyasını bir bayt dizisi olarak okuyun.  
4. Bayt dizisini ve OLE nesnesiyle ilgili diğer bilgileri içeren [OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe) öğesini slayta ekleyin.  
5. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Aşağıdaki örnekte, bir Excel dosyasından grafiği Aspose.Slides for .NET kullanarak bir [OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe) olarak slayta ekledik.  
**Not**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/net/aspose.slides.dom.ole/oleembeddeddatainfo/) yapıcı, ikinci parametre olarak gömülebilir bir nesne uzantısı alır. Bu uzantı, PowerPoint'in dosya türünü doğru yorumlamasını ve OLE nesnesini açmak için uygun uygulamayı seçmesini sağlar.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // OLE nesnesi için verileri hazırlayın.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // OLE nesne çerçevesini slayta ekleyin.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Bağlantılı OLE Nesne Çerçeveleri Ekleme**

Aspose.Slides for .NET, verileri gömmeden yalnızca dosyaya bir bağlantı içeren bir [OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe) eklemenize olanak tanır.

Bu C# kodu, bir Excel dosyasına bağlantılı bir [OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe) eklemeyi gösterir:

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

Bir OLE nesnesi zaten bir slayta gömülmüşse, ona şu şekilde kolayca ulaşabilir ve erişebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturarak gömülü OLE nesnesine sahip bir sunumu yükleyin.  
2. İndeksini kullanarak slaytın referansını alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe) şekline erişin.  
   Örneğimizde, ilk slaytta yalnızca bir şekil bulunan önceden oluşturulmuş PPTX dosyasını kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ioleobjectframe) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine eriştikten sonra, üzerinde istediğiniz işlemi gerçekleştirebilirsiniz.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (bir slayta gömülmüş Excel grafiği nesnesi) ve dosya verileri erişilmektedir.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // İlk şekli OLE nesne çerçevesi olarak alın.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Gömülü dosya verisini alın.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Gömülü dosyanın uzantısını alın.
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

    // OLE nesnesinin bağlantılı olup olmadığını kontrol edin.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Bağlantılı dosyanın tam yolunu yazdırın.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Var ise bağlantılı dosyanın göreceli yolunu yazdırın.
        // Sadece PPT sunumları göreceli yolu içerebilir.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE Nesne Verilerini Değiştirme**

{{% alert color="info" %}} 

Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for .NET](/cells/net/) kullanmaktadır.

{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülmüşse, bu nesneye kolayca erişebilir ve verilerini şu şekilde değiştirebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturarak gömülü OLE nesnesine sahip bir sunumu yükleyin.  
2. İndeksini kullanarak slaytın referansını alın.  
3. [OLEObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe) şekline erişin.  
   Örneğimizde, ilk slaytta bir şekil bulunan önceden oluşturulmuş PPTX dosyasını kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ioleobjectframe) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine eriştikten sonra, üzerinde istediğiniz işlemi gerçekleştirebilirsiniz.  
5. Bir `Workbook` nesnesi oluşturun ve OLE verilerine erişin.  
6. İstenen `Worksheet` öğesine erişin ve verileri düzenleyin.  
7. Güncellenmiş `Workbook` nesnesini bir akışa kaydedin.  
8. Akıştan OLE nesne verisini değiştirin.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (slayta gömülmüş bir Excel grafik nesnesi) erişilir ve dosya verileri, grafik verilerini güncellemek üzere değiştirilir.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // İlk şekli OLE nesne çerçevesi olarak alın.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // OLE nesne verisini Workbook nesnesi olarak okuyun.
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

                // OLE çerçeve nesnesi verisini değiştir.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Diğer Dosya Türlerini Slaytlara Gömme**

Excel grafiklerinin yanı sıra, Aspose.Slides for .NET slaytlara HTML, PDF ve ZIP gibi diğer dosya türlerini nesne olarak gömmenize olanak tanır. Kullanıcı eklenen nesneye çift‑tıkladığında, ilgili program otomatik olarak açılır veya kullanıcıdan uygun bir program seçmesi istenir.

Bu C# kodu, bir slayta HTML ve ZIP dosyalarını nasıl gömeceğinizi gösterir:

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

Sunumlarla çalışırken, eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for .NET, gömülü bir nesnenin dosya türünü ayarlamanıza izin vererek OLE çerçeve verisini veya uzantısını güncellemenizi sağlar.

Bu C# kodu, gömülü bir OLE nesnesinin dosya türünü `zip` olarak ayarlamayı gösterir:

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

## **Gömülü Nesneler İçin Simge Görüntüsü ve Başlık Ayarlama**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsü içeren bir önizleme eklenir. Bu önizleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Önizlemede belirli bir görüntü ve metin kullanmak istiyorsanız, Aspose.Slides for .NET ile simge görüntüsü ve başlığı ayarlayabilirsiniz.

Bu C# kodu, gömülü bir nesne için simge görüntüsü ve başlığı nasıl ayarlayacağınızı gösterir: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Sunuma kaynak olarak bir görüntü ekleyin.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // OLE önizlemesi için bir başlık ve görüntü ayarlayın.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Bir OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önleme**

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint’te sunumu açtığınızda bağları güncellemeniz istenebilir. “Bağları Güncelle” düğmesine tıkladığınızda, PowerPoint bağlantılı OLE nesnesinden verileri güncellediği ve nesne önizlemesini yenilediği için OLE nesne çerçevesinin boyutu ve konumu değişebilir. Nesnenin verilerinin güncellenmesi için PowerPoint’e sormasını önlemek amacıyla, [IOleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ioleobjectframe/) arayüzünün `UpdateAutomatic` özelliğini `false` olarak ayarlayın:

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

Aspose.Slides for .NET, slaytlara OLE nesneleri olarak gömülmüş dosyaları şu şekilde çıkarma imkanı sunar:
1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun; bu sınıf OLE nesnelerini içerir.  
2. Sunumdaki tüm şekillerde döngü yaparak [OLEObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe) şekillerine erişin.  
3. OLE nesne çerçevelerindeki gömülü dosya verilerine ulaşın ve diske yazın.  

Bu C# kodu, bir slayta OLE nesnesi olarak gömülmüş dosyaları nasıl çıkaracağınızı gösterir:

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

### Slaytları PDF/görsellere dışa aktarırken OLE içeriği renderlanacak mı?

Slaytta görünen şey renderlanır—simge/yer tutucu görüntüsü (önizleme). “Canlı” OLE içeriği renderleme sırasında çalıştırılmaz. Gerekiyorsa, dışa aktarılan PDF’de beklenen görünümü sağlamak için kendi önizleme görüntünüzü ayarlayın.

### Bir OLE nesnesini slaytta kilitleyerek kullanıcıların PowerPoint’te taşımasını/düzenlemesini nasıl engelleyebilirim?

Şekli kilitleyin: Aspose.Slides, [şekil‑düzeyi kilitler](/slides/tr/net/applying-protection-to-presentation/) sağlar. Bu şifreleme değildir, ancak yanlışlıkla düzenleme ve hareketi etkin bir şekilde önler.

### Bağlantılı bir Excel nesnesi, sunumu açtığımda “atlıyor” ya da boyutu değişiyor, neden?

PowerPoint, bağlantılı OLE’nin önizlemesini yenileyebilir. Kararlı bir görünüm için, [Çalışma Sayfası Yeniden Boyutlandırma için Çözüm](/slides/tr/net/working-solution-for-worksheet-resizing/) uygulamalarını izleyin—ya çerçeveyi aralığa göre ayarlayın ya da aralığı sabit bir çerçeveye ölçeklendirin ve uygun bir yer tutucu görüntü belirleyin.

### Bağlantılı OLE nesneleri için göreceli yollar PPTX formatında korunacak mı?

PPTX içinde “göreceli yol” bilgisi bulunmaz—yalnızca tam yol vardır. Göreceli yollar eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI’lar veya gömme tercih edin.