---
title: C++ Kullanarak Sunumlarda OLE'yi Yönet
linktitle: OLE'yi Yönet
type: docs
weight: 40
url: /tr/cpp/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlama ve Gömme
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding), bir uygulamada oluşturulan veri ve nesnelerin başka bir uygulamaya bağlanarak veya gömülerek yerleştirilmesini sağlayan Microsoft teknolojisidir. 
{{% /alert %}} 

MS Excel’de oluşturulmuş bir grafiği düşünün. Bu grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi simge olarak görünebilir. Bu durumda, simgeye çift‑tıkladığınızda grafik ilişkili uygulamasında (Excel) açılır veya nesneyi açmak/düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi gerçek içeriğini, örneğin bir grafiğin içeriğini gösterebilir. Bu durumda grafik PowerPoint içinde etkinleşir, grafik arabirimi yüklenir ve grafiğin verilerini PowerPoint içinde değiştirebilirsiniz.

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) slaytlara OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)) olarak OLE Nesneleri eklemenizi sağlar.

## **OLE Nesne Çerçevelerini Slaytlara Ekle**

Microsoft Excel’de zaten bir grafik oluşturduğunuzu ve bu grafiği Aspose.Slides for C++ kullanarak bir OLE nesne çerçevesi olarak slayta gömmek istediğinizi varsayalım; bunu şu şekilde yapabilirsiniz:

1. bir [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
2. Slaytın referansını indeksine göre alın.  
3. Excel dosyasını bir bayt dizisi olarak okuyun.  
4. Bayt dizisini ve OLE nesnesiyle ilgili diğer bilgileri içeren [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) çerçevesini slayta ekleyin.  
5. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.  

Aşağıdaki örnekte, bir Excel dosyasından bir grafik ekleyerek bir slayta [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) ekledik. **Not** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) yapıcı metodunun ikinci parametresi olarak gömülebilir nesne uzantısı alır. Bu uzantı, PowerPoint’in dosya türünü doğru şekilde yorumlamasını ve OLE nesnesini açmak için doğru uygulamayı seçmesini sağlar.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Bağlantılı OLE Nesne Çerçevelerini Ekle**

Aspose.Slides for C++ bir dosyaya bağlanarak, veri gömmeden bir [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) eklemenizi sağlar.

Bu C++ kodu, bir slayta bağlantılı bir Excel dosyasıyla bir [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) eklemenizi gösterir:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add an OLE object frame with a linked Excel file.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE Nesne Çerçevelerine Erişim**

Bir OLE nesnesi zaten bir slayta gömülmüşse, bu nesneyi aşağıdaki şekilde kolayca bulabilir veya erişebilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, bir [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturarak yükleyin.  
2. Slaytın referansını indeksini kullanarak alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) şekline erişin. Örneğimizde, yalnızca bir şekli olan ilk slayttaki önceden oluşturulmuş PPTX’i kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildiğinde, üzerinde istediğiniz işlemi gerçekleştirebilirsiniz.  

Aşağıdaki örnekte bir OLE nesne çerçevesi (slayta gömülmüş bir Excel grafiği) ve dosya verileri erişilmektedir.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Gömülü dosya verisini al.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Gömülü dosyanın uzantısını al.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Bağlantılı OLE Nesne Çerçevesi Özelliklerine Erişim**

Aspose.Slides, bağlantılı OLE nesne çerçevesi özelliklerine erişmenizi sağlar.

Bu C++ kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol etmeyi ve ardından bağlantılı dosyanın yolunu elde etmeyi gösterir:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // OLE nesnesinin bağlantılı olup olmadığını kontrol edin.
    if (oleFrame->get_IsObjectLink())
    {
        // Bağlantılı dosyanın tam yolunu yazdır.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Varsa bağlantılı dosyanın göreli yolunu yazdır.
        // Yalnızca PPT sunumları göreli yolu içerebilir.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE Nesne Verilerini Değiştir**

{{% alert color="info" title="Note" %}}
Bu bölümde aşağıdaki kod örneği [Aspose.Cells for C++](https://docs.aspose.com/cells/cpp/) kullanmaktadır.
{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülmüşse, bu nesneye kolayca erişebilir ve verisini şu şekilde değiştirebilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, bir [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturarak yükleyin.  
2. Slaytın referansını indeksini kullanarak alın.  
3. [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) şekline erişin. Örneğimizde, ilk slaytta bir şekli olan önceden oluşturulmuş PPTX’i kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildiğinde, üzerinde istediğiniz işlemi gerçekleştirebilirsiniz.  
5. bir `Workbook` nesnesi oluşturun ve OLE verisine erişin.  
6. İstenen `Worksheet`e erişin ve veriyi düzenleyin.  
7. Güncellenmiş `Workbook`u bir akışta kaydedin.  
8. OLE nesne verisini akıştan değiştirin.  

Aşağıdaki örnekte bir OLE nesne çerçevesi (slayta gömülmüş bir Excel grafiği) erişilmiş ve dosya verileri, grafik verilerini güncellemek üzere değiştirilmiştir.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells for C++ herhangi bir türü kullanılmadan önce başlatılmalıdır.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // OLE nesnesi verisini Workbook nesnesi olarak okuyun.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Workbook verisini değiştirin.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // OLE çerçeve nesnesinin verisini değiştirin.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Diğer Dosya Türlerini Slaytlara Göm**

Excel grafiklerinin yanı sıra, Aspose.Slides for C++ slaytlara diğer dosya türlerini de gömmenize izin verir. Örneğin HTML, PDF ve ZIP dosyalarını nesne olarak ekleyebilirsiniz. Kullanıcı eklenen nesneye çift‑tıkladığında, ilgili program otomatik olarak açılır veya kullanıcı uygun bir program seçmesi için yönlendirilir.

Bu C++ kodu, bir slayta HTML ve ZIP nasıl gömülür gösterir:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gömülü Nesneler İçin Dosya Türlerini Ayarla**

Sunumlarla çalışırken eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek gerekebilir. Aspose.Slides for C++ gömülü bir nesne için dosya türünü ayarlamanıza olanak tanır; bu sayede OLE çerçeve verisini veya uzantısını güncelleyebilirsiniz.

Bu C++ kodu, gömülü bir OLE nesnesinin dosya türünü `zip` olarak ayarlamayı gösterir:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Dosya türünü ZIP olarak değiştir.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gömülü Nesneler İçin Simge Görüntüleri ve Başlıkları Ayarla**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsü içeren bir ön izleme eklenir. Bu ön izleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Ön izlemede belirli bir görüntü ve metin kullanmak istiyorsanız, Aspose.Slides for C++ ile simge görüntüsünü ve başlığı ayarlayabilirsiniz.

Bu C++ kodu, gömülü bir nesne için simge görüntüsü ve başlığın nasıl ayarlanacağını gösterir: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Sunum kaynaklarına bir görüntü ekleyin.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// OLE ön izlemesi için bir başlık ve görüntü ayarlayın.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bir OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önle**

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint’te sunumu açtığınızda bağlantıları güncellemek isteyip istemediğinizi soran bir mesaj görebilirsiniz. “Update Links” (Bağlantıları Güncelle) düğmesine tıkladığınızda, PowerPoint bağlantılı OLE nesnesinden verileri günceller ve ön izlemeyi yenilediği için OLE nesne çerçevesinin boyutu ve konumu değişebilir. PowerPoint’in nesnenin verilerini güncelleme istemesini önlemek için, `false` ile [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) metodunu [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) arayüzünden çağırın:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **Gömülü Dosyaları Çıkar**

Aspose.Slides for C++ aşağıdaki şekilde slaytlara OLE nesnesi olarak gömülmüş dosyaları çıkarabilir:

1. Çıkarılacak OLE nesnelerini içeren bir [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
2. Sunumdaki tüm şekiller üzerinde döngü oluşturun ve [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) şekillerine erişin.  
3. Gömülü dosyaların verilerine OLE nesne çerçevelerinden erişin ve diske yazın.  

Bu C++ kodu, bir slayta OLE nesnesi olarak gömülmüş dosyaları nasıl çıkaracağınızı gösterir:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **FAQ**

**OLE içeriği PDF/görüntülere dışa aktarılırken işlenecek mi?**

Slaytta görülen şey işlenir—simge/yer tutucu görüntüsü (ön izleme). “Canlı” OLE içeriği oluşturma sırasında çalıştırılmaz. Gerekirse, dışa aktarılmış PDF’de beklenen görünümü sağlamak için kendi ön izleme görüntünüzü ayarlayın.

Gömülü dosyayı PDF eki olarak da korumak için, `true` ile [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) metodunu çağırın. Bu seçenek varsayılan olarak devre dışıdır. Bir örnek ve ekin kontrolü için, [Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru](/slides/tr/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) bölümüne bakın.

**Bir OLE nesnesini slaytta kilitleyerek kullanıcıların PowerPoint’te nesneyi taşımasını/düzenlemesini nasıl engelleyebilirim?**

Şekli kilitleyin: Aspose.Slides [şekil düzeyinde kilitler](/slides/tr/cpp/applying-protection-to-presentation/) sağlar. Bu şifreleme değildir, ancak kazara düzenlemeleri ve hareketi etkili bir şekilde önler.

**Bağlantılı bir Excel nesnesi, sunumu açtığımda “atlıyor” ya da boyutu değişiyor; neden?**

PowerPoint bağlantılı OLE’nin ön izlemesini yenileyebilir. Kararlı bir görünüm için, çerçeveyi aralığa sığdırma ya da aralığı sabit bir çerçeveye ölçeklendirme ve uygun bir yer tutucu görüntüsü ayarlama uygulamalarını izleyin ([Worksheet Resizing için Çalışan Çözüm](/slides/tr/cpp/working-solution-for-worksheet-resizing/)).

**Bağlantılı OLE nesneleri için göreli yollar PPTX formatında korunacak mı?**

PPTX içinde “göreli yol” bilgisi bulunmaz—yalnızca tam yol mevcuttur. Göreli yollar, eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI’ler veya gömme tercih edin.