---
title: C++'ta Sunumları Açma
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/cpp/open-presentation/
keywords:
- PowerPoint aç
- OpenDocument aç
- sunum aç
- PPTX aç
- PPT aç
- ODP aç
- sunum yükle
- PPTX yükle
- PPT yükle
- ODP yükle
- korumalı sunum
- büyük sunum
- harici kaynak
- ikili nesne
- C++
- Aspose.Slides
description: "C++ için Aspose.Slides kullanarak PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma parolası eklemeyi, kaynak yüklemeyi kontrol etmeyi ve bellek kullanımını azaltmayı öğrenin."
---
## **Giriş**

[Aspose.Slides for C++](https://products.aspose.com/slides/tr/cpp/) dosyalar ve akışlardan PowerPoint ve OpenDocument sunumlarını yükleyebilir. Bir sunum yüklendikten sonra, yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka desteklenen bir formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma parolası sağlayabilir, büyük ikili nesneleri bellek dışına tutabilir, dış kaynakları kontrol edebilir veya gömülü ikili verileri atlayabilirsiniz.

## **Sunumları Açma**

Mevcut bir sunumu açmak için, dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) yapıcısına geçirin. Sunumu kullandıktan sonra, dosya tutamaçları, geçici veriler ve diğer kaynakların hemen serbest bırakılması için dispose edin.

Aşağıdaki C++ örneği, bir sunumu nasıl açacağınızı ve slayt sayısını nasıl alacağınızı gösterir:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Parola Koruması Olan Sunumları Açma**

Açma parolası, sunum içeriğini şifreler. Sunumu tamamen yüklemek için, doğru parolayı [LoadOptions::set_Password](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) metoduna geçirin ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) yapıcısına gönderin. Parola eksik veya yanlış olduğunda yükleme başarısız olur.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

Parola algılama, doğrulama ve şifreleme iş akışları için, [Password-Protect Presentations](/slides/tr/cpp/password-protected-presentation/) sayfasına bakın. Şifreli bir sunum, kasıtlı olarak genel belge özellikleriyle kaydedildiyse, bu özellikler parola olmadan okunabilir; [Manage Presentation Properties](/slides/tr/cpp/presentation-properties/) bölümüne bakın.

## **Büyük Sunumları Açma**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) Aspose.Slides'in görüntüler, ses ve video gibi büyük ikili nesneleri nasıl yönettiğini kontrol eder. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulan BLOB veri miktarını sınırlayabilirsiniz.

Aşağıdaki C++ kodu, büyük bir sunumun (örneğin 2 GB) nasıl yükleneceğini gösterir:

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior::KeepLocked` ile, kaynak dosya `Presentation` nesnesi dispose edilene kadar kilitli kalır. Bu nesne hâlâ mevcutken kaynak dosyayı taşımayın, üzerine yazmayın veya silmeyin.

Aspose.Slides, yükleme sırasında bir giriş akışının içeriğini kopyalayabilir. Büyük sunumlar için, dosya yolu genellikle akıştan daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [Manage BLOBs](/slides/tr/cpp/manage-blob/) sayfasına bakın.
{{% /alert %}}

## **Harici Kaynakları Kontrol Etme**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) bir [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iresourceloadingcallback/) uygulamasını kabul eder. Geri arama, yerine geçecek veri sağlayabilir, bir kaynağı yönlendirebilir, varsayılan yükleyiciyi kullanabilir veya kaynağı atlayabilir. Bu, sunumların uygulamaya özgü güvenlik veya depolama kurallarına göre çözülmesi gereken harici görüntüler içermesi durumunda faydalıdır.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Gömülü İkili Nesneler Olmadan Sunumları Yükleme**

Bir sunum, uygulamanın ihtiyaç duymadığı veya tutmak istemediği gömülü ikili veriler içerebilir. Örnekler:

- VBA projeleri, [IPresentation::get_VbaProject](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_vbaproject/) üzerinden erişilebilir;
- gömülü OLE verileri, [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) üzerinden erişilebilir;
- ActiveX kontrol verileri, [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) üzerinden erişilebilir.

Bu ikili verileri yükleme sırasında kaldırmak için [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) metoduna `true` gönderin. Temizlenmiş sonucu korumak için yüklü sunumu kaydedin.

Bu seçenek, istenmeyen gömülü yüklemelere maruziyeti azaltır, ancak tam bir kötü amaçlı yazılım tespiti veya içerik temizleme sistemi değildir.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**

Aspose.Slides, yükleme sırasında bir ayrıştırma veya format istisnası fırlatır. Bu hatayı yanlış parola hatasından ayrı ele alın, böylece uygulama nedeni doğru bir şekilde raporlayabilir.

**Gerekli yazı tipleri eksikse ne olur?**

Sunum yine de yüklenebilir, ancak renderleme ve dışa aktarma yazı tiplerini değiştirebilir. Çıktıyı daha öngörülebilir hâle getirmek için [configure font substitution](/slides/tr/cpp/font-substitution/) ya da [provide custom fonts](/slides/tr/cpp/custom-font/) sayfalarını kullanabilirsiniz.

**Bir sunumu yüklemek aynı zamanda gömülü medyasını da yükler mi?**

Gömülü ses ve video, sunum nesne modeli üzerinden kullanılabilir hâle gelir. Harici kaynaklar, yapılandırılmış kaynak yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılamaz olabilir.