---
title: ".NET'te Sunumlarda OLE Nesnelerini Yönetme"
linktitle: "OLE Yönet"
type: docs
weight: 40
url: /tr/net/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlantısı ve Gömülmesi
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
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini en üst düzeye çıkarın. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding), bir uygulamada oluşturulan veri ve nesnelerin başka bir uygulamaya bağlantı veya gömme yoluyla yerleştirilmesini sağlayan bir Microsoft teknolojisidir. 
{{% /alert %}} 

MS Excel’de oluşturulmuş bir grafiği düşünün. Bu grafik daha sonra bir PowerPoint slaytına yerleştirilir. Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi simge olarak görünebilir. Bu durumda simgeye çift‑tıkladığınızda grafik ilişkili uygulamasında (Excel) açılır veya nesneyi açmak/düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi gerçek içeriğini, örneğin grafiğin kendisini, gösterebilir. Bu durumda grafik PowerPoint içinde etkinleşir, grafik arayüzü yüklenir ve grafiğin verilerini PowerPoint içinde değiştirebilirsiniz. 

[Aspose.Slides for .NET](https://products.aspose.com/slides/tr/net/) OLE Nesnelerini slaytlara OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe)) olarak eklemenizi sağlar. 

## **Slaytlara OLE Nesne Çerçeveleri Ekleme**

Microsoft Excel’de bir grafik oluşturduğunuzu ve Aspose.Slides for .NET kullanarak bu grafiği bir OLE nesne çerçevesi olarak slayta gömmek istediğinizi varsayalım; bunu aşağıdaki şekilde yapabilirsiniz:

1. **[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)** sınıfının bir örneğini oluşturun.  
2. Slaydın referansını diziniyle alın.  
3. Excel dosyasını bayt dizisi olarak okuyun.  
4. Bayt dizisini ve OLE nesnesiyle ilgili diğer bilgileri içeren **[OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe)** öğesini slayta ekleyin.  
5. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Aşağıdaki örnekte, bir Excel dosyasındaki grafiği Aspose.Slides for .NET kullanarak bir **[OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe)** olarak slayta ekledik.  
**Not**: **[OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/net/aspose.slides.dom.ole/oleembeddeddatainfo/)** yapıcı, ikinci parametre olarak gömülebilir nesnenin uzantısını alır. Bu uzantı, PowerPoint’in dosya tipini doğru şekilde yorumlamasını ve OLE nesnesini açacak doğru uygulamayı seçmesini sağlar.

```csharp
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

Aspose.Slides for .NET, veri gömmeden yalnızca dosyaya bir bağlantı içeren bir **[OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe)** eklemenizi sağlar.

Bu C# kodu, bir Excel dosyasına bağlantılı bir **[OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe)** nasıl ekleyeceğinizi gösterir:

```csharp
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Bağlantılı bir Excel dosyasıyla OLE nesne çerçevesi ekleyin.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE Nesne Çerçevelerine Erişim**

Bir OLE nesnesi zaten bir slayta gömülmüşse, aşağıdaki şekilde kolayca bulabilir veya erişebilirsiniz:

1. **[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)** sınıfının bir örneğini oluşturarak gömülü OLE nesnesine sahip bir sunumu yükleyin.  
2. Slaydın referansını diziniyle alın.  
3. **[OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe)** şekline erişin.  
   Örneğimizde, yalnızca bir şekli olan ilk slaytın PPTX dosyasını kullandık. Ardından bu nesneyi **[IOleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ioleobjectframe)** tipine *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine eriştikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (bir slayta gömülmüş Excel grafik nesnesi) ve dosya verisi erişilir.

```csharp
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

### **Bağlantılı OLE Nesne Çerçeve Özelliklerine Erişim**

Aspose.Slides, bağlantılı OLE nesne çerçeve özelliklerine erişmenizi sağlar.

Bu C# kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol eder ve ardından bağlı dosyanın yolunu elde eder:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // İlk şekli OLE nesne çerçevesi olarak alın.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // OLE nesnesinin bağlantılı olup olmadığını kontrol edin.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Bağlantılı dosyanın tam yolunu yazdır.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Mevcutsa bağlantılı dosyanın göreli yolunu yazdır.
        // Yalnızca PPT sunumları göreli yolu içerebilir.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE Nesne Verisini Değiştirme**

{{% alert color="primary" %}} 
Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for .NET](/cells/net/) kullanmaktadır. 
{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülmüşse, bu nesneye erişip verisini aşağıdaki şekilde değiştirebilirsiniz:

1. **[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)** sınıfının bir örneğini oluşturarak gömülü OLE nesnesine sahip bir sunumu yükleyin.  
2. Slaydın referansını diziniyle alın.  
3. **[OLEObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe)** şekline erişin.  
   Örneğimizde, birinci slaytta bir şekli olan PPTX dosyasını kullandık. Ardından bu nesneyi **[IOleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ioleobjectframe)** tipine *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine eriştikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.  
5. Bir `Workbook` nesnesi oluşturun ve OLE verisine erişin.  
6. İstenen `Worksheet` öğesine ulaşın ve verileri değiştirin.  
7. Güncellenmiş `Workbook` nesnesini bir akışa kaydedin.  
8. OLE nesne verisini akıştan değiştirin.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (slayta gömülmüş bir Excel grafik nesnesi) erişilir ve dosya verisi, grafik verilerini güncellemek üzere değiştirilir.

```csharp 
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
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Workbook verisini değiştirin.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
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

Excel grafiklerinin yanı sıra, Aspose.Slides for .NET slaytlara HTML, PDF ve ZIP gibi diğer dosya türlerini nesne olarak gömme imkanı sağlar. Kullanıcı eklenen nesneye çift‑tıkladığında, ilgili program otomatik olarak açılır; ya da kullanıcı uygun bir program seçmek üzere yönlendirilir.

Bu C# kodu, bir slayta HTML ve ZIP dosyalarını nasıl gömeceğinizi gösterir:

```c#
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

Sunumlarla çalışırken eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for .NET, gömülü bir nesnenin dosya türünü ayarlamanıza izin verir; böylece OLE çerçeve verisini veya uzantısını güncelleyebilirsiniz.

Bu C# kodu, gömülü bir OLE nesnesinin dosya türünü `zip` olarak nasıl ayarlayacağınızı gösterir:

```c#
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

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsü önizlemesi eklenir. Bu önizleme, kullanıcıların OLE nesnesine erişmeden ya da açmadan önce gördükleri şeydir. Önizlemede belirli bir görüntü ve metin kullanmak istiyorsanız, Aspose.Slides for .NET ile simge görüntüsünü ve başlığı ayarlayabilirsiniz.

Bu C# kodu, gömülü bir nesne için simge görüntüsü ve başlığın nasıl ayarlanacağını gösterir: 

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Sunum kaynaklarına bir görüntü ekleyin.
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

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint’te sunumu açtığınızda “Bağlantıları Güncelle” mesajı görebilirsiniz. “Bağlantıları Güncelle” düğmesine tıklamak, PowerPoint’in bağlantılı OLE nesnesinden verileri güncellemesi ve önizlemeyi yenilemesi nedeniyle OLE nesne çerçevesinin boyut ve konumunu değiştirebilir. PowerPoint’in nesne verisini güncelleme istemini engellemek için **[IOleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ioleobjectframe/)** arayüzünün `UpdateAutomatic` özelliğini `false` olarak ayarlayın:

```cs
oleFrame.UpdateAutomatic = false;
```

## **Gömülü Dosyaları Çıkarma**

Aspose.Slides for .NET, slaytlara OLE nesnesi olarak gömülmüş dosyaları aşağıdaki adımlarla çıkarabilir:

1. Çıkarmak istediğiniz OLE nesnelerini içeren bir **[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)** örneği oluşturun.  
2. Sunumdaki tüm şekilleri döngüye alarak **[OLEObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe)** şekillerine erişin.  
3. Gömülü dosyaların verisine OLE nesne çerçevelerinden ulaşın ve diske yazın.  

Bu C# kodu, bir slaytta OLE nesnesi olarak gömülü dosyaları nasıl çıkaracağınızı gösterir:

```c#
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

**OLE içeriği PDF/görüntülere dışa aktarılırken render edilir mi?**  
Slaytta görülen şey render edilir – simge/yerine geçici görüntü (önizleme). “Canlı” OLE içeriği render sırasında yürütülmez. Gerekirse, dışa aktarılan PDF’de beklenen görünümü sağlamak için kendi önizleme görüntünüzü ayarlayın.  

**Bir OLE nesnesini slaytta kilitleyerek kullanıcıların PowerPoint’te taşımalarını/düzenlemelerini nasıl engelleyebilirim?**  
Şekli kilitleyin: Aspose.Slides, **[shape-level locks](/slides/tr/net/applying-protection-to-presentation/)** sağlar. Bu şifreleme değildir, ancak istem dışı düzenlemeleri ve hareketi etkili bir şekilde önler.  

**Bağlantılı bir Excel nesnesi “atlıyor” ya da sunumu açtığımda boyutu değişiyor, neden?**  
PowerPoint, bağlantılı OLE nesnesinin önizlemesini yenileyebilir. Stabil bir görünüm için **[Worksheet Resizing için Çalışma Çözümü](/slides/tr/net/working-solution-for-worksheet-resizing/)** pratiğini izleyin – çerçeveyi aralığa göre ayarlayın ya da aralığı sabit bir çerçeveye ölçeklendirin ve uygun bir yer tutucu görüntü belirleyin.  

**Bağlantılı OLE nesneleri için göreli yollar PPTX formatında korunur mu?**  
PPTX içinde “göreli yol” bilgisi bulunmaz; yalnızca tam yol kaydedilir. Göreli yollar eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI’ler veya gömme tercih edilmelidir.  