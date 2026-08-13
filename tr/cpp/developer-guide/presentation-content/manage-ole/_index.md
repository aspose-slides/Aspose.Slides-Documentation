---
title: C++ Kullanarak Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/cpp/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlantısı ve Gömülmesi
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
- nesneyi çıkar
- dosyayı çıkar
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding), bir uygulamada oluşturulan veri ve nesnelerin bağlantı ya da gömme yoluyla başka bir uygulamaya yerleştirilmesini sağlayan bir Microsoft teknolojisidir. 
{{% /alert %}} 

MS Excel'de oluşturulan bir grafik düşünün. Bu grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi bir simge olarak görünebilir. Bu durumda, simgeye çift‑tıkladığınızda grafik ilişkili uygulamasında (Excel) açılır veya nesneyi açmak/ düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi gerçek içeriğini, örneğin bir grafiğin içeriğini gösterebilir. Bu durumda grafik PowerPoint içinde etkinleşir, grafik arayüzü yüklenir ve grafiğin verilerini PowerPoint içinde değiştirebilirsiniz. 

[Aspose.Slides for C++](https://products.aspose.com/slides/tr/cpp/) OLE Nesnelerini slaytlara OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/)) olarak eklemenize olanak tanır. 

## **Slaytlara OLE Nesne Çerçeveleri Ekleme**

Microsoft Excel’de zaten bir grafik oluşturduğunuzu ve bunu Aspose.Slides for C++ kullanarak bir OLE nesne çerçevesi olarak slayta gömmek istediğinizi varsayalım; bunu şu şekilde yapabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.  
2. İndeksi aracılığıyla bir slayt referansı alın.  
3. Excel dosyasını bayt dizisi olarak okuyun.  
4. [OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) öğesini, bayt dizisi ve OLE nesnesi hakkında diğer bilgileri içerecek şekilde slayta ekleyin.  
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Aşağıdaki örnekte, bir Excel dosyasındaki grafik, Aspose.Slides for C++ kullanılarak bir [OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) olarak slayta eklenmiştir.  
**Note** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) yapıcısının ikinci parametre olarak gömülebilir nesne uzantısını almasına dikkat edin. Bu uzantı, PowerPoint’in dosya türünü doğru yorumlamasını ve OLE nesnesini açacak doğru uygulamayı seçmesini sağlar.  

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

### **Bağlantılı OLE Nesne Çerçeveleri Ekleme**

Aspose.Slides for C++ veri gömmeden yalnızca dosyaya bir bağlantı ile bir [OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) eklemenize olanak tanır.  

Bu C++ kodu, bir Excel dosyasına bağlantılı bir [OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) nasıl eklenir gösterir:  

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

// Bağlantılı bir Excel dosyasıyla OLE nesne çerçevesi ekle.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE Nesne Çerçevelerine Erişim**

Bir OLE nesnesi zaten bir slayta gömülmüşse, ona bu şekilde kolayca ulaşabilir ya da bulabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturarak gömülü OLE nesnesi içeren bir sunumu yükleyin.  
2. İndeksini kullanarak slayt referansını alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) şekline erişin.  
   Örneğimizde, yalnızca bir şekli bulunan ilk slayttaki PPTX’i kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleobjectframe/) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine eriştiğinizde, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (slayta gömülmüş bir Excel grafik nesnesi) ve dosya verileri erişilmiştir.  

```cpp
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

Bu C++ kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol etmeyi ve bağlantılı dosyanın yolunu elde etmeyi gösterir:  

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

    // OLE nesnesinin bağlantılı olup olmadığını kontrol et.
    if (oleFrame->get_IsObjectLink())
    {
        // Bağlantılı dosyanın tam yolunu yazdır.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Bağlantılı dosyanın göreli yolunu varsa yazdır.
        // Yalnızca PPT sunumları göreli yolu içerebilir.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE Nesne Verilerini Değiştirme**

{{% alert color="info" %}} 
Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for C++](/cells/cpp/) kullanmaktadır.  
{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülmüşse, o nesneye erişip verilerini şu şekilde değiştirebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturarak gömülü OLE nesnesi içeren bir sunumu yükleyin.  
2. İndeksini kullanarak slayt referansını alın.  
3. [OLEObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) şekline erişin.  
   Örneğimizde, ilk slaytta yalnızca bir şekli bulunan PPTX’i kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleobjectframe/) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine eriştiğinizde, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.  
5. Bir `Workbook` nesnesi oluşturun ve OLE verisine erişin.  
6. İstenen `Worksheet`’i alıp verileri değiştirin.  
7. Güncellenen `Workbook`’u bir akışa (stream) kaydedin.  
8. OLE nesne verisini akıştan değiştirin.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (slayta gömülmüş bir Excel grafiği) erişilmiş ve dosya verileri grafiğin verilerini güncelleyecek şekilde değiştirilmiştir.  

```cpp
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

// Aspose.Cells for C++ tipleri kullanılmadan önce başlatılmalıdır.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // OLE nesnesi verisini Workbook nesnesi olarak oku.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Modify the workbook data.
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

    // OLE çerçeve nesnesi verisini değiştir.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Diğer Dosya Türlerini Slaytlara Gömme**

Excel grafikleri dışında, Aspose.Slides for C++ slaytlara HTML, PDF ve ZIP gibi farklı dosya türlerini nesne olarak gömmenize izin verir. Kullanıcı eklenen nesneye çift‑tıkladığında, ilgili program otomatik olarak açılır ya da kullanıcıdan uygun bir program seçmesi istenir.  

Bu C++ kodu, bir slayta HTML ve ZIP dosyalarının nasıl gömüleceğini gösterir:  

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

## **Gömülü Nesneler İçin Dosya Türlerini Ayarlama**

Sunumlarla çalışırken eski OLE nesnelerini yenileriyle değiştirmek ya da desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for C++ gömülü bir nesnenin dosya türünü ayarlamanıza olanak tanır; böylece OLE çerçeve verisini ya da uzantısını güncelleyebilirsiniz.  

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

## **Gömülü Nesneler İçin Simge Görüntüsü ve Başlık Ayarlama**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsü içeren bir ön izleme eklenir. Bu ön izleme, kullanıcıların OLE nesnesine erişmeden ya da açmadan önce gördükleri şeydir. Belirli bir görüntü ve metni ön izlemede kullanmak istiyorsanız, Aspose.Slides for C++ ile simge görüntüsü ve başlığı ayarlayabilirsiniz.  

Bu C++ kodu, gömülü bir nesne için simge görüntüsü ve başlık ayarlamayı gösterir:  

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

// Sunum kaynaklarına bir resim ekle.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önleme**

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint’te sunumu açtığınızda “Bağlantıları Güncelle” mesajı görebilirsiniz. “Bağlantıları Güncelle” düğmesine tıkladığınızda, PowerPoint bağlantılı OLE nesnesinden verileri günceller ve nesne ön izlemesini yeniler; bu da OLE nesne çerçevesinin boyut ve konumunun değişmesine yol açabilir. PowerPoint’in nesne verilerini güncelleme isteğini önlemek için, [IOleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleobjectframe/) arayüzünün `set_UpdateAutomatic` metodunu `false` olarak ayarlayın:  

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

## **Gömülü Dosyaları Çıkarma**

Aspose.Slides for C++ aşağıdaki adımlarla slaytlara OLE nesnesi olarak gömülmüş dosyaları çıkarmanıza olanak tanır:

1. Gömülü OLE nesnelerini içeren bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı örneği oluşturun.  
2. Sunumdaki tüm şekilleri döngüyle gezerek [OLEObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) şekillerine erişin.  
3. OLE nesne çerçevelerinden gömülü dosya verilerini alın ve diske yazın.  

Bu C++ kodu, bir slayta OLE nesnesi olarak gömülmüş dosyaların nasıl çıkarılacağını gösterir:  

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

## **SSS**

### Slaytları PDF/görsellere dışa aktarırken OLE içeriği render edilecek mi?

Slaytta görünen şey render edilir – simge/ikame görüntüsü (ön izleme). “Canlı” OLE içeriği render sırasında çalıştırılmaz. Gerekirse, dışa aktarılan PDF’de beklenen görünümü sağlamak için kendi ön izleme görüntünüzü ayarlayın.  

### Bir OLE nesnesini slaytta kilitleyerek kullanıcıların PowerPoint’te taşımasını/düzenlemesini nasıl engelleyebilirim?

Şekli kilitleyin: Aspose.Slides, [şekil‑seviyesi kilitler](/slides/tr/cpp/applying-protection-to-presentation/) sağlar. Bu şifreleme değildir, ancak kazara düzenlemeleri ve taşımaları etkili bir şekilde önler.  

### Bağlantılı bir Excel nesnesi sunumu açtığımda “atlıyor” ya da boyutu değişiyor, neden?

PowerPoint, bağlantılı OLE ön izlemesini yenileyebilir. Stabil bir görünüm için, [Çalışma Sayfası Yeniden Boyutlandırma için Çalışan Çözüm](/slides/tr/cpp/working-solution-for-worksheet-resizing/) yönergelerini izleyin – ya çerçeveyi aralığa göre ayarlayın ya da aralığı sabit bir çerçeveye ölçekleyip uygun bir ikame görüntüsü belirleyin.  

### Bağlantılı OLE nesneleri için göreli yollar PPTX formatında korunur mu?

PPTX’de “göreli yol” bilgisi bulunmaz; yalnızca tam yol kaydedilir. Göreli yollar eski PPT formatında mevcuttur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI’lar veya gömme yöntemini tercih edin.  