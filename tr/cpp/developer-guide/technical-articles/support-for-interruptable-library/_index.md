---
title: Kesintiye Uğrayabilen Kütüphane Desteği
type: docs
weight: 150
url: /tr/cpp/support-for-interruptable-library/
keywords:
- kesintiye uğrayabilen kütüphane
- kesinti tokeni
- iptal tokeni
- uzun süren görev
- görevi kesintiye uğrat
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile uzun süren görevleri iptal edilebilir hale getirin. PowerPoint ve OpenDocument için renderleme ve dönüştürmeleri güvenli bir şekilde kesintiye uğratın, örneklerle."
---
## **Genel Bakış**

Aspose.Slides, serileştirme, deseralize etme ve renderleme gibi uzun süren sunum görevleri için kesintiye uğrayabilen bir işleme mekanizması sağlar. Bu mekanizma `InterruptionToken` ve `InterruptionTokenSource` sınıflarına dayanır.

`InterruptionToken`, `LoadOptions`'a atanabilir ve `Presentation` yapıcısına geçirilebilir. `InterruptionTokenSource::Interrupt()` çağrıldığında, ilgili uzun süren görev kesintiye uğrar.

## **Kesintiye Uğrayabilen Kütüphane**

[Aspose.Slides 18.4](https://releases.aspose.com/slides/tr/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/) sürümünde [InterruptionToken](https://reference.aspose.com/slides/tr/cpp/aspose.slides/interruptiontoken/) ve [InterruptionTokenSource](https://reference.aspose.com/slides/tr/cpp/aspose.slides/interruptiontokensource/) sınıflarını tanıttık. Bu sınıflar, serileştirme, deseralize etme ve renderleme gibi uzun süren görevleri kesintiye uğratmanıza olanak tanır.

- [InterruptionTokenSource](https://reference.aspose.com/slides/tr/cpp/aspose.slides/interruptiontokensource/) , [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_interruptiontoken/)’a geçirilen token(ler)in kaynağıdır.
- [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_interruptiontoken/) ayarlandığında ve [LoadOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/) örneği [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) yapıcısına geçirildiğinde, [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/interruptiontokensource/interrupt/) çağrısı o [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) ile ilişkilendirilmiş herhangi bir uzun süren görevi kesintiye uğratır.

Aşağıdaki kod parçacığı, çalışan bir görevin nasıl kesintiye uğratılacağını gösterir:

```cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto threadFunction = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(threadFunction);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        auto options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        auto presentation = System::MakeObject<Presentation>(dataDir + u"sample.pptx", options);
        presentation->Save(dataDir + u"sample.ppt", Export::SaveFormat::Ppt);
    });

    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);
    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    
    Run(action, tokenSource->get_Token()); // eylemi ayrı bir iş parçacığında çalıştır
    Threading::Thread::Sleep(10000);       // zaman aşımı
    tokenSource->Interrupt();              // dönüşümü durdur
}
```

## **SSS**

**Aspose.Slides kesinti kütüphanesinin amacı nedir?**

Bu, uzun süren işlemleri—sunumları yükleme, kaydetme veya renderleme gibi—tamamlanmadan kesintiye uğratmak için bir mekanizma sağlar. İşlem süresinin sınırlı olması gerektiğinde veya görevin artık gereksiz olduğu durumlarda faydalıdır.

**[InterruptionToken](https://reference.aspose.com/slides/tr/cpp/aspose.slides/interruptiontoken/) ve [InterruptionTokenSource](https://reference.aspose.com/slides/tr/cpp/aspose.slides/interruptiontokensource/) arasındaki fark nedir?**

- `InterruptionToken`, Aspose.Slides API'sine geçirilir ve uzun süren işlemler sırasında kontrol edilir.
- `InterruptionTokenSource`, kodunuzda token oluşturmak ve `Interrupt()` çağrısı yaparak kesintileri tetiklemek için kullanılır.

**Hangi görevler kesintiye uğrayabilir?**

`InterruptionToken` kabul eden herhangi bir Aspose.Slides görevi—örneğin `Presentation(path, loadOptions)` ile bir sunumu yüklemek veya `Presentation::Save(...)` ile kaydetmek—kesintiye uğrayabilir.

**Kesinti hemen gerçekleşir mi?**

Hayır. Kesinti iş birliğine dayalıdır: işlem periyodik olarak token'ı kontrol eder ve [Interrupt()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/interruptiontokensource/interrupt/) çağrıldığını algıladığı anda durur.

**Bir görev zaten tamamlandıktan sonra [Interrupt()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/interruptiontokensource/interrupt/) çağırırsam ne olur?**

Hiçbir şey—ilgili görev zaten tamamlanmışsa çağrı hiçbir etki yaratmaz.

**Aynı [InterruptionTokenSource](https://reference.aspose.com/slides/tr/cpp/aspose.slides/interruptiontokensource/) birden fazla görev için yeniden kullanılabilir mi?**

Evet—ancak o kaynakta [Interrupt()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/interruptiontokensource/interrupt/) çağrısından sonra, token'larını kullanan tüm görevler kesintiye uğrar. Görevleri bağımsız yönetmek için ayrı token kaynakları kullanın.