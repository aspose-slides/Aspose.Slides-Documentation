---
title: "C++'ta Sunumları Açma"
linktitle: "Sunumu Aç"
type: docs
weight: 20
url: /tr/cpp/open-presentation/
keywords:
- PowerPoint'i Aç
- OpenDocument'i Aç
- Sunumu Aç
- PPTX'i Aç
- PPT'yi Aç
- ODP'yi Aç
- Sunumu Yükle
- PPTX'yi Yükle
- PPT'yi Yükle
- ODP'yi Yükle
- Korunan Sunum
- Büyük Sunum
- Harici Kaynak
- İkili Nesne
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint (.pptx, .ppt) ve OpenDocument (.odp) sunumlarını zahmetsizce açın—hızlı, güvenilir, tam özellikli."
---
## **Giriş**

Sıfırdan PowerPoint sunumları oluşturmanın yanı sıra, Aspose.Slides mevcut sunumları da açmanıza olanak tanır. Bir sunumu yükledikten sonra, onun hakkında bilgi alabilir, slayt içeriğini düzenleyebilir, yeni slaytlar ekleyebilir, mevcut slaytları kaldırabilir ve daha fazlasını yapabilirsiniz.

## **Sunumları Açma**

Mevcut bir sunumu açmak için, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve dosya yolunu yapıcıya geçirin.

Aşağıdaki C++ örneği, bir sunumu nasıl açıp slayt sayısını nasıl alacağınızı gösterir:

```cpp
// Presentation sınıfının bir örneğini oluşturun ve dosya yolunu yapıcıya geçiriniz.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Sunumdaki toplam slayt sayısını yazdır.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Şifreli Sunumları Açma**

Şifre korumalı bir sunumu açmanız gerektiğinde, şifreyi [LoadOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/) sınıfının [set_Password](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) yöntemiyle geçirerek çözebilir ve yükleyebilirsiniz. Aşağıdaki C++ kodu bu işlemi gösterir:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Şifrelenmiş sunum üzerinde işlemler gerçekleştir.

presentation->Dispose();
```

## **Büyük Sunumları Açma**

Aspose.Slides, büyük sunumları yüklemenize yardımcı olmak için seçenekler—özellikle [LoadOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/) sınıfındaki [get_BlobManagementOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) yöntemi—sağlar.

Aşağıdaki C++ kodu, büyük bir sunumu (örneğin 2 GB) nasıl yükleyeceğinizi gösterir:

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// KeepLocked davranışını seçin—sunum dosyası yaşam süresi boyunca kilitli kalacaktır
// Presentation örneği için, ancak belleğe yüklenmesi veya geçici bir dosyaya kopyalanması gerekmez.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// Büyük sunum yüklendi ve kullanılabilir, bellek tüketimi düşük kalır.

// Sunumda değişiklikler yapın.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Sunumu başka bir dosyaya kaydedin. Bu işlem sırasında bellek tüketimi düşük kalır.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Bunu yapmayın! Dosya, sunum nesnesi bertaraf edilene kadar kilitli olduğu için bir I/O istisnası fırlatılacak.
File::Delete(filePath);

presentation->Dispose();

// Burada yapmak uygundur. Kaynak dosya artık sunum nesnesi tarafından kilitli değil.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Akışlarla çalışırken belirli kısıtlamaları aşmak için Aspose.Slides, akışın içeriğini kopyalayabilir. Bir akıştan büyük bir sunumu yüklemek, sunumun kopyalanmasına neden olur ve yükleme süresini yavaşlatabilir. Bu nedenle, büyük bir sunumu yüklemeniz gerektiğinde, akış yerine sunum dosya yolunu kullanmanızı şiddetle öneririz.

Büyük nesneler (video, ses, yüksek çözünürlüklü resimler vb.) içeren bir sunum oluştururken, bellek tüketimini azaltmak için [BLOB yönetimi](/slides/tr/cpp/manage-blob/) kullanabilirsiniz.
{{%/alert %}}

## **Harici Kaynakları Kontrol Etme**

Aspose.Slides, harici kaynakları yönetmenizi sağlayan [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iresourceloadingcallback/) arabirimini sunar. Aşağıdaki C++ kodu, `IResourceLoadingCallback` arabirimini nasıl kullanacağınızı gösterir:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Yerine geçen bir resmi yükleyin.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Yerine geçen bir URL ayarlayın.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Diğer tüm resimleri atlayın.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **Gömülü İkili Nesneler Olmadan Sunumları Yükleme**

PowerPoint sunumu aşağıdaki türde gömülü ikili nesneler içerebilir:

- VBA projesi ([IPresentation::get_VbaProject](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_vbaproject/) aracılığıyla erişilebilir);
- OLE nesnesi gömülü verileri ([IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) aracılığıyla erişilebilir);
- ActiveX kontrol ikili verileri ([IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) aracılığıyla erişilebilir).

[ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) yöntemini kullanarak, gömülü ikili nesneler içermeyen bir sunumu yükleyebilirsiniz.

Bu yöntem, potansiyel olarak kötü amaçlı ikili içeriği kaldırmak için faydalıdır. Aşağıdaki C++ kodu, gömülü ikili içerik olmadan bir sunumu nasıl yükleyeceğinizi gösterir:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Sunum üzerinde işlemler gerçekleştirin.

presentation->Dispose();
```

## **SSS**

**Bir dosyanın bozuk ve açılamaz olduğunu nasıl anlayabilirim?**

Yükleme sırasında bir ayrıştırma/format doğrulama istisnası alırsınız. Bu tür hatalar genellikle geçersiz bir ZIP yapısı veya bozuk PowerPoint kayıtlarını belirtir.

**Açarken gerekli yazı tipleri eksikse ne olur?**

Dosya açılacaktır, ancak daha sonra [rendering/export](/slides/tr/cpp/convert-presentation/) yazı tiplerini değiştirebilir. Çalışma zamanına [yazı tipi ikamelerini yapılandırın](/slides/tr/cpp/font-substitution/) veya [gerekli yazı tiplerini ekleyin](/slides/tr/cpp/custom-font/).

**Açarken gömülü medya (video/ses) ne olur?**

Bunlar sunum kaynakları olarak kullanılabilir hale gelir. Medya dış yollarla referanslanıyorsa, bu yolların ortamınızda erişilebilir olduğundan emin olun; aksi takdirde [rendering/export](/slides/tr/cpp/convert-presentation/) medya dosyalarını atlayabilir.