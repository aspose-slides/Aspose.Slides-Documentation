---
title: C++'ta Sunum Açma
linktitle: Sunum Aç
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
- sunumu yükle
- PPTX yükle
- PPT yükle
- ODP yükle
- korumalı sunum
- büyük sunum
- harici kaynak
- ikili nesne
- C++
- Aspose.Slides
description: "C++'ta PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma parolalarını nasıl sağlayacağınızı, kaynak yüklemesini nasıl kontrol edeceğinizi ve Aspose.Slides for C++ ile bellek kullanımını nasıl azaltacağınızı öğrenin."
---
## **Giriş**

[Aspose.Slides for C++](https://products.aspose.com/slides/tr/cpp/) PowerPoint ve OpenDocument sunumlarını dosyalardan ve akışlardan yükleyebilir. Bir sunum yüklendikten sonra, yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka desteklenen bir formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma parolası sağlayabilir, büyük ikili nesneleri belleğin dışında tutabilir, harici kaynakları kontrol edebilir ya da gömülü ikili verileri dışlayabilirsiniz.

## **Sunumları Açma**

Bir dosya veya akış yüklendikten sonra, uygulamanızın nasıl işleyeceğini seçmek için [orijinal sunum formatını belirleyebilirsiniz](/slides/tr/cpp/detect-presentation-source-format/).

Mevcut bir sunumu açmak için, dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) oluşturucusuna geçirin. Kullanım sonrası sunumu dispose edin, böylece dosya tanıtıcıları, geçici veriler ve diğer kaynaklar hızla serbest bırakılır.

Aşağıdaki C++ örneği, bir sunumu nasıl açıp slayt sayısını alacağınızı gösterir:

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

Açma parolası, sunum içeriğini şifreler. Tam sunumu yüklemek için doğru parolayı [LoadOptions::set_Password](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) metoduna geçirin ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) oluşturucusuna iletin. Parola eksik veya hatalı olduğunda yükleme başarısız olur.

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

Parola algılama, doğrulama ve şifreleme iş akışları için [Password-Protect Presentations](/slides/tr/cpp/password-protected-presentation/) bölümüne bakın. Şifrelenmiş bir sunum, kasıtlı olarak genel belge özellikleriyle kaydedildiyse, bu özellikler parola olmadan okunabilir; [Manage Presentation Properties](/slides/tr/cpp/presentation-properties/) bölümüne bakın.

## **Büyük Sunumları Açma**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) Aspose.Slides'in resimler, ses ve video gibi büyük ikili nesneleri nasıl yönettiğini denetler. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulacak BLOB verisi miktarını sınırlayabilirsiniz.

Aşağıdaki C++ kodu, büyük bir sunumu (örneğin 2 GB) yüklemeyi gösterir:

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
`PresentationLockingBehavior::KeepLocked` ile kaynak dosya, `Presentation` nesnesi dispose edilene kadar kilitli kalır. Bu nesne yaşadığı sürece kaynak dosyayı taşımayın, üzerine yazmayın veya silmeyin.

Aspose.Slides, yükleme sırasında bir giriş akışının içeriğini kopyalayabilir. Büyük sunumlar için dosya yolu, genellikle bir akıştan daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [Manage BLOBs](/slides/tr/cpp/manage-blob/) bölümüne bakın.
{{% /alert %}}

## **Harici Kaynakları Kontrol Etme**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) bir [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iresourceloadingcallback/) uygulamasını kabul eder. Geri arama, yerine geçecek veri sağlayabilir, bir kaynağı yeniden yönlendirebilir, varsayılan yükleyiciyi kullanabilir veya kaynağı atlayabilir. Bu, sunumların uygulamaya özgü güvenlik veya depolama kurallarına göre çözülmesi gereken harici görseller içerdiği durumlarda yararlıdır.

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

Bir sunum, uygulamanın ihtiyacı olmayan veya tutmak istemediği gömülü ikili veri içerebilir. Örnekler:
- VBA projeleri, [IPresentation::get_VbaProject](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_vbaproject/) aracılığıyla kullanılabilir;
- gömülü OLE verileri, [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) aracılığıyla kullanılabilir;
- ActiveX kontrol verileri, [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) aracılığıyla kullanılabilir.

Bu ikili verileri yükleme sırasında kaldırmak için [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) metoduna `true` geçirin. Temizlenmiş sonucu kalıcı kılmak için yüklenen sunumu kaydedin.

Bu seçenek, istenmeyen gömülü yüklemelere maruziyeti azaltır, ancak tam bir kötü amaçlı yazılım tespit veya içerik temizleme sistemi değildir.

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
Aspose.Slides, yükleme sırasında bir ayrıştırma veya format istisnası fırlatır. Uygulamanın nedeni doğru şekilde raporlayabilmesi için bu hatayı yanlış parola hatasından ayrı şekilde ele alın.

**Gerekli yazı tipleri eksikse ne olur?**  
Sunum yine de yüklenebilir, ancak renderleme ve dışa aktarma sırasında yazı tipleri değiştirilebilir. Çıktıyı daha öngörülebilir hâle getirmek için [font ikamesini yapılandırabilir](/slides/tr/cpp/font-substitution/) veya [özel yazı tipleri sağlayabilirsiniz](/slides/tr/cpp/custom-font/).

**Bir sunumu yüklemek gömülü medyasını da yükler mi?**  
Gömülü ses ve video, sunum nesne modeli üzerinden kullanılabilir hâle gelir. Harici kaynaklar, yapılandırılmış kaynak yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılabilir olmayabilir.