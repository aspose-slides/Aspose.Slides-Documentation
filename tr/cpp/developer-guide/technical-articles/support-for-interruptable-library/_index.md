---
title: C++'ta Uzun Süreli Sunum İşlemlerini Kesintiye Uğratma
linktitle: Sunum İşlemlerini Kesintiye Uğratma
type: docs
weight: 150
url: /tr/cpp/support-for-interruptable-library/
keywords:
- kesintiye uğrayabilen işlemler
- kesinti token'ı
- iptal token'ı
- uzun süren görev
- görevi kesintiye uğrat
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta uzun süren sunum işlemlerini nasıl iptal edeceğinizi ve döngü içinde slaytları dışa aktarırken kısmi bir sonuç döndürebileceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for C++ uzun süren işlemleri, örneğin sunumların yüklenmesi, kaydedilmesi ve render edilmesi gibi, kesintiye uğratabilir. Uygulamanız aynı kesinti token'ını, bir sonraki slaytı işlemeye başlamadan döngüyü durdurmak için kullanabilir.

## **Sunum İşlemini Kesintiye Uğratma**

Bir [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) oluşturun, token'ını [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/) ile alın, token'ı [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) yöntemine gönderin ve yükleme seçeneklerini [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) yöntemine geçirin. İptal talep etmek için kaynak üzerinde [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) metodunu çağırın. Kesintiye uğrayabilen bir işlem, talebi gördüğünde durur.

Örnek, arka plan görevinde `sample.pptx` dosyasını `sample.ppt` dosyasına dönüştürmeye başlar ve görev 10 saniye sonra hâlâ çalışıyorsa iptal talep eder. Dönüştürme daha erken tamamlanırsa çıktı zaten tamdır.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.ppt", Export::SaveFormat::Ppt);
});

if (conversion.wait_for(std::chrono::seconds(10)) == std::future_status::timeout)
    source->Interrupt();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
```

## **Uygulama İptalini Aspose.Slides ile Bağlama**

Eğer uygulamanız bir [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) kullanıyorsa, iptal isteklerini [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) metoduna yönlendirmek için [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) kullanın. Örnek, `sample.pptx` dosyasını bir arka plan görevinde `sample.pdf` dosyasına dışa aktarır. Dışa aktarma 20 saniye sonra hâlâ çalışıyorsa, uygulama [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/) metodunu çağırır ve bu kayıtlı geri çağırma işlevini tetikler.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <system/threading/cancellation_token.h>
#include <system/threading/cancellation_token_source.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto cancellation = MakeObject<Threading::CancellationTokenSource>();
auto cancellationToken = cancellation->get_Token();
auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto interrupt = Action<>([source]() { source->Interrupt(); });
auto registration = cancellationToken.Register(interrupt);

auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.pdf", Export::SaveFormat::Pdf);
});

if (conversion.wait_for(std::chrono::seconds(20)) == std::future_status::timeout)
    cancellation->Cancel();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
registration.Dispose();
```

## **Sonraki Slaytı İşleme Almadan Durdurma**

Sunum ve slaytlarını dışa aktaran döngü için aynı [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) kullanın. Her dışa aktarmaya başlamadan önce [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) kontrol edin. Çağıran kısmi bir sonuç kullanabiliyorsa, başarılı bir şekilde tamamlanan dışa aktarımların slayt numaralarını döndürün.

En az iki slaytı olan `sample.pptx` adlı bir sunum kullanın. Örnek, ilk başarılı dışa aktarmayı kaydettikten hemen sonra iptal talep eder.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <DOM/ISlideCollection.h>
#include <system/array.h>
#include <iostream>
#include <vector>

using namespace Aspose::Slides;
using namespace System;

auto exportSlides = [](String path, SharedPtr<InterruptionTokenSource> source)
{
    std::vector<int32_t> completed;
    auto token = source->get_Token();
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(path, options);
    auto slideCount = presentation->get_Slides()->get_Count();

    for (auto number = 1; number <= slideCount; ++number)
    {
        if (token->get_IsInterruptionRequested())
            break;

        std::cout << "Starting slide " << number << '\n';
        auto filename = String::Format(u"slide-{0}.pdf", number);
        auto slides = MakeArray<int32_t>({number});
        try
        {
            presentation->Save(filename, slides, Export::SaveFormat::Pdf);
        }
        catch (const OperationCanceledException&)
        {
            if (!token->get_IsInterruptionRequested())
                throw;
            break;
        }

        completed.push_back(number);
        if (number == 1)
            source->Interrupt();
    }
    return completed;
};

auto source = MakeObject<InterruptionTokenSource>();
auto completed = exportSlides(u"sample.pptx", source);
std::cout << "Completed: [";
for (size_t i = 0; i < completed.size(); ++i)
    std::cout << (i == 0 ? "" : ", ") << completed[i];
std::cout << "]\n";
```

Örnek `slide-1.pdf` dosyasını yazar ve `Starting slide 1` ardından `Completed: [1]` mesajını basar. Döngü, slayt 2'ye başlamadan önce isteği görür. Eğer iptal, bir dışa aktarma sırasında [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) metodunu kesintiye uğratırsa, `catch` bloğu kodun mevcut slaytı tamamlandığı gibi kaydetmesinden önce döngüyü sonlandırır.

Eğer çağıran iptali işlemesi gerekiyorsa, döngünün başındaki `if` kontrolünü ve `break` ifadesini token üzerinde [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) çağrısı ile değiştirin. Dışa aktarma etrafındaki `try`/`catch` bloğunu kaldırın, böylece kaydetme sırasında oluşan iptal de çağırana ulaşır. Aynı girişle örnek yalnızca `Starting slide 1` mesajını basar ve `slide-1.pdf` yazar. İkinci yinelemenin başında, dışa aktarım başlamadan önce çağıran bir [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) alır. Çağıran tamamlanan slaytların bir listesini almaz.

## **SSS**

**İptali ne zaman talep etmeliyim?**  
İşlem zaman sınırınızı aştığında veya uygulamanız sonucun artık gerekli olmadığını belirttiğinde iptal talep edin.

**[InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) ve [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) arasındaki fark nedir?**  
Kaynak, uygulamanızın iptal talep etmesine olanak tanır. Token ise Aspose.Slides ve uygulamanızın bu talebi kontrol etmesini sağlar.

**[System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) ile Aspose.Slides kullanabilir miyim?**  
Evet. Uygulamanızın token'ı iptali işaret ettiğinde, sunumla ilişkilendirilmiş kaynak üzerinde [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) metodunu çağırın.

**Hangi işlemleri kesintiye uğratabilirim?**  
Yükleme, kaydetme ve renderleme işlemlerini kesintiye uğratabilirsiniz. Token'ı [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) aracılığıyla [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) metoduna geçirin. Sunum, ardından gelen işlemler sırasında, örneğin [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) gibi, iptali gözlemleyebilir.

**Bir işlem hemen durur mu?**  
İptal işbirliğine dayalıdır. Bir işlem token'ı periyodik olarak kontrol eder ve talebi gördüğünde durur.

**Bir işlem bittikten sonra [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) çağrısı yaparsam ne olur?**  
Tamamlanan işlem sonucunu korur.

**Birden fazla işlem aynı [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) kaynakını paylaşabilir mi?**  
Evet. [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) metodunu çağırmak, o kaynaktan alınan token'ı kullanan tüm işlemler için iptal talep eder. Bağımsız olarak iptal etmek istediğiniz her işlem için ayrı bir kaynak kullanın.