---
title: C++ Kullanarak Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/cpp/manage-ole/
keywords:
- OLE nesnesi
- Obje Bağlama ve Gömme
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

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding), bir uygulamada oluşturulan veri ve nesnelerin başka bir uygulamaya bağlama ya da gömme yoluyla yerleştirilebilmesini sağlayan bir Microsoft teknolojisidir. 
{{% /alert %}} 

MS Excel'de oluşturulan bir grafiği düşünün. Bu grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi ikon olarak görünebilir. Bu durumda, ikona çift tıkladığınızda grafik ilişkili uygulamasında (Excel) açılır ya da nesneyi açmak veya düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi grafiğin içeriği gibi gerçek içeriğini gösterebilir. Bu durumda, grafik PowerPoint içinde etkinleşir, grafik arabirimi yüklenir ve grafiğin verilerini PowerPoint içinde değiştirebilirsiniz. 

[Aspose.Slides for C++](https://products.aspose.com/slides/tr/cpp/) OLE nesnelerini slaytlara OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/)) olarak eklemenizi sağlar.

## **Slaytlara OLE Nesne Çerçeveleri Ekle**

Microsoft Excel'de zaten bir grafik oluşturduğunuzu ve bunu Aspose.Slides for C++ kullanarak bir OLE nesne çerçevesi olarak bir slayta gömmek istediğinizi varsayalım, bunu şu şekilde yapabilirsiniz:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.  
2. İndeksi aracılığıyla bir slaytın referansını alın.  
3. Excel dosyasını bir bayt dizisi olarak okuyun.  
4. [OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) öğesini, bayt dizisini ve OLE nesnesiyle ilgili diğer bilgileri içeren slayta ekleyin.  
5. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.  

Aşağıdaki örnekte, bir Excel dosyasından bir grafiği Aspose.Slides for C++ kullanarak bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) olarak ekledik. **Not**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) yapıcı ikinci parametre olarak gömülebilir bir nesne uzantısı alır. Bu uzantı, PowerPoint'in dosya türünü doğru yorumlamasını ve bu OLE nesnesini açmak için doğru uygulamayı seçmesini sağlar.  

``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// OLE nesnesi için verileri hazırlayın.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// OLE nesne çerçevesini slayta ekleyin.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Bağlantılı OLE Nesne Çerçeveleri Ekle**

Aspose.Slides for C++ veri gömmeden yalnızca dosyaya bir bağlantı ile bir [OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) eklemenizi sağlar.

Bu C++ kodu, bir bağlantılı Excel dosyasıyla bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) eklemenin nasıl yapılacağını gösterir:  

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Bağlantılı bir Excel dosyasıyla OLE nesne çerçevesi ekleyin.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE Nesne Çerçevelerine Erişim**

Eğer bir OLE nesnesi zaten bir slayta gömülmüşse, onu aşağıdaki şekilde kolayca bulabilir veya erişebilirsiniz:

1. Gömülü OLE nesnesine sahip bir sunumu, bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturarak yükleyin.  
2. İndeksini kullanarak slaytın referansını alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) şekline erişin.  
   Örneğimizde, ilk slaytta yalnızca bir şekil bulunan daha önce oluşturulmuş PPTX'i kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleobjectframe/) olarak *dönüştürdük*. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildiğinde, üzerinde istediğiniz herhangi bir işlemi yapabilirsiniz.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (bir slayta gömülmüş bir Excel grafik nesnesi) ve dosya verileri erişildi.  

``` cpp
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

Bu C++ kodu, bir OLE nesnesinin bağlantılı olup olmadığını nasıl kontrol edeceğinizi ve ardından bağlantılı dosyanın yolunu nasıl alacağınızı gösterir:  

```cpp
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

        // Bağlantılı dosyanın göreceli yolunu (varsa) yazdır.
        // Yalnızca PPT sunumları göreceli yolu içerebilir.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE Nesne Verisini Değiştir**

{{% alert color="primary" %}} 
Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for C++](/cells/cpp/) kullanır. 
{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülü ise, nesneye erişebilir ve verisini aşağıdaki gibi değiştirebilirsiniz:

1. Gömülü OLE nesnesine sahip bir sunumu, bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturarak yükleyin.  
2. İndeksini kullanarak slaytın referansını alın.  
3. [OLEObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) şekline erişin.  
   Örneğimizde, ilk slaytta bir şekil bulunan daha önce oluşturulmuş PPTX'i kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleobjectframe/) olarak *dönüştürdük*. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildiğinde, üzerinde istediğiniz herhangi bir işlemi yapabilirsiniz.  
5. `Workbook` nesnesi oluşturun ve OLE verisine erişin.  
6. İstenen `Worksheet` nesnesine erişin ve veriyi değiştirin.  
7. Güncellenmiş `Workbook`'ı bir akışta kaydedin.  
8. Akıştan OLE nesne verisini değiştirin.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (bir slayta gömülmüş bir Excel grafik nesnesi) erişilir ve dosya verileri, grafik verilerini güncellemek için değiştirilir.  

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// İlk şekli OLE nesne çerçevesi olarak al.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // OLE nesne verisini Workbook nesnesi olarak oku.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Workbook verisini değiştir.
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
```

## **Diğer Dosya Türlerini Slaytlara Göm**

Excel grafiklerine ek olarak, Aspose.Slides for C++ slaytlara diğer dosya türlerini de gömmenizi sağlar. Örneğin, HTML, PDF ve ZIP dosyalarını nesne olarak ekleyebilirsiniz. Kullanıcı eklenen nesneye çift tıkladığında, otomatik olarak ilgili programda açılır veya kullanıcı uygun bir program seçmesi istenir.  

Bu C++ kodu, HTML ve ZIP dosyalarını bir slayta nasıl gömeceğinizi gösterir:  

``` cpp
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

## **Gömülü Nesneler için Dosya Türlerini Ayarla**

Sunumlarla çalışırken, eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for C++, gömülü bir nesne için dosya türünü ayarlamanıza olanak tanır; böylece OLE çerçeve verisini veya uzantısını güncelleyebilirsiniz.  

Bu C++ kodu, gömülü bir OLE nesnesinin dosya türünü `zip` olarak nasıl ayarlayacağınızı gösterir:  

``` cpp
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

## **Gömülü Nesneler için Simge Görüntüsü ve Başlık Ayarla**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsünden oluşan bir önizleme eklenir. Bu önizleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Belirli bir görüntü ve metni önizleme öğeleri olarak kullanmak istiyorsanız, Aspose.Slides for C++ ile simge görüntüsü ve başlığı ayarlayabilirsiniz.  

Bu C++ kodu, gömülü bir nesne için simge görüntüsü ve başlığı nasıl ayarlayacağınızı gösterir:  

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Sunuma bir görüntü kaynağı ekleyin.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önle**

Bir bağlantılı OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint'te sunumu açtığınızda bağlantıların güncellenmesi istenen bir mesaj görebilirsiniz. "Update Links" düğmesine tıklamak, PowerPoint'in bağlantılı OLE nesnesinden verileri güncellemesi ve nesne önizlemesini yenilemesi nedeniyle OLE nesne çerçevesinin boyut ve konumunu değiştirebilir. PowerPoint'in nesnenin verilerini güncelleme talebinde bulunmasını önlemek için, [IOleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleobjectframe/) arabiriminin `set_UpdateAutomatic` metodunu `false` olarak ayarlayın:  

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **Gömülü Dosyaları Çıkar**

Aspose.Slides for C++, slaytlara OLE nesnesi olarak gömülmüş dosyaları şu şekilde çıkarabilir:

1. Çıkarmak istediğiniz OLE nesnelerini içeren bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.  
2. Sunumdaki tüm şekiller üzerinde döngü yapın ve [OLEObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) şekillerine erişin.  
3. OLE nesne çerçevelerinden gömülü dosyaların verilerine erişin ve diske yazın.  

Bu C++ kodu, bir slayta OLE nesnesi olarak gömülmüş dosyaları nasıl çıkaracağınızı gösterir:  

``` cpp
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

**Slaytlar PDF/görsellere dışa aktarılırken OLE içeriği işlenecek mi?**  
Slaytta görülen şey (ikon/değiştirme resmi) işlenir. "Canlı" OLE içeriği renderleme sırasında çalıştırılmaz. Gerekirse, dışa aktarılan PDF'de beklenen görünümü sağlamak için kendi önizleme resminizi ayarlayın.  

**PowerPoint'te bir slayttaki OLE nesnesini kullanıcıların taşımasını/düzenlemesini nasıl kilitleyebilirim?**  
Şekli kilitleyin: Aspose.Slides, [şekil‑seviyesi kilitler](/slides/tr/cpp/applying-protection-to-presentation/) sunar. Bu bir şifreleme değildir, ancak kazara düzenleme ve taşıma işlemlerini etkili bir şekilde engeller.  

**Bağlantılı bir Excel nesnesi, sunumu açtığımda neden "atlıyor" ya da boyutu değişiyor?**  
PowerPoint, bağlantılı OLE'nin önizlemesini yenileyebilir. Kararlı bir görünüm için, [Çalışma Sayfası Yeniden Boyutlandırma için Çözüm](/slides/tr/cpp/working-solution-for-worksheet-resizing/) uygulamalarını izleyin—ya çerçeveyi aralığa uydurun, ya da aralığı sabit bir çerçeveye ölçekleyin ve uygun bir değiştirme resmi ayarlayın.  

**Bağlantılı OLE nesneleri için göreceli yollar PPTX formatında korunacak mı?**  
PPTX formatında "göreceli yol" bilgisi mevcut değildir—yalnızca tam yol bulunur. Göreceli yollar eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yolları/erişilebilir URI'leri ya da gömmeyi tercih edin.