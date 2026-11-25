---
title: C++ で長時間実行されるプレゼンテーション操作を中断する
linktitle: プレゼンテーション操作の中断
type: docs
weight: 150
url: /ja/cpp/support-for-interruptable-library/
keywords:
- 割り込み可能な操作
- 割り込みトークン
- キャンセルトークン
- 長時間タスク
- タスクの中断
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ における長時間実行されるプレゼンテーション操作のキャンセル方法と、スライドをループでエクスポートする際に部分結果を返す方法を学びます。"
---
## **概要**

Aspose.Slides for C++ は、プレゼンテーションの読み込み、保存、レンダリングなどの長時間実行される操作を割り込み可能です。アプリケーションは同じ割り込みトークンを使用して、次のスライドの処理を開始する前にループを停止できます。

## **プレゼンテーション操作の割り込み**

[InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) を作成し、[get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/) でトークンを取得し、そのトークンを [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) に渡し、ロードオプションを [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) に渡します。キャンセルを要求するには、ソース上で [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) を呼び出します。割り込み可能な操作は要求を検知した時点で停止します。

この例はバックグラウンド タスクで `sample.pptx` を `sample.ppt` に変換し始め、10 秒後にタスクがまだ実行中であればキャンセルを要求します。変換がそれより早く完了した場合、出力はすでに完了しています。

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

## **アプリケーションのキャンセルを Aspose.Slides に接続する**

アプリケーションが [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) を使用している場合、[Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) を使ってキャンセル要求を [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) に転送します。この例はバックグラウンド タスクで `sample.pptx` を `sample.pdf` にエクスポートします。エクスポートが 20 秒後も実行中であれば、アプリケーションは [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/) を呼び出し、登録されたコールバックが実行されます。

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

## **次のスライドの処理前に停止する**

プレゼンテーションとスライドをエクスポートするループの両方で同じ [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) を使用します。各エクスポートを開始する前に [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) をチェックします。呼び出し元が部分結果を使用できる場合は、正常に完了したエクスポートのスライド番号を返します。

少なくとも 2 枚のスライドがある `sample.pptx` プレゼンテーションを使用します。この例は最初のエクスポートが成功した直後にキャンセルを要求します。

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

例は `slide-1.pdf` を書き込み、`Starting slide 1` と出力した後に `Completed: [1]` を表示します。ループはスライド 2 を開始する前に要求を検知します。キャンセルが [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 中に発生した場合、`catch` ブロックがループを抜け、現在のスライドを完了として記録しません。

呼び出し元がキャンセルを処理する必要がある場合は、ループ先頭の `if` チェックと `break` をトークン上の [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) 呼び出しに置き換えます。エクスポート周りの `try`/`catch` を削除し、保存中のキャンセルも呼び出し元に伝わるようにします。同じ入力で例は `Starting slide 1` のみを出力し、`slide-1.pdf` を書き込みます。2 回目のイテレーション開始時に、呼び出し元はエクスポート開始前に [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) を受け取り、完了したスライドのリストは取得できません。

## **FAQ**

**キャンセルはいつ要求すべきですか？**

操作が時間制限を超えた場合や、アプリケーションが結果をもはや必要としなくなった場合にキャンセルを要求します。

**[InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) の違いは何ですか？**

ソースはアプリケーションがキャンセルを要求できるようにし、トークンは Aspose.Slides とアプリケーションがその要求を確認できるようにします。

**[System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) を Aspose.Slides と併用できますか？**

はい。アプリケーションのトークンがキャンセルを示したときに、プレゼンテーションに関連付けられたソース上で [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) を呼び出します。

**どの操作を割り込むことができますか？**

読み込み、保存、レンダリングを割り込むことができます。トークンを [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) に渡す際に [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) を使用します。その後、プレゼンテーションは [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) などの後続操作中にキャンセルを検知できます。

**操作はすぐに停止しますか？**

キャンセルは協調的です。操作はトークンを定期的にチェックし、要求を検知した時点で停止します。

**操作が終了した後に [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) を呼び出すとどうなりますか？**

完了した操作はその結果を保持します。

**複数の操作が同じ [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) を共有できますか？**

はい。[InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) を呼び出すと、そのソースから取得したトークンを使用するすべての操作に対してキャンセルが要求されます。個別にキャンセルしたい操作ごとに別のソースを使用してください。