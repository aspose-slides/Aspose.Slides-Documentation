---
title: 割り込み可能なライブラリのサポート
type: docs
weight: 150
url: /ja/cpp/support-for-interruptable-library/
---

## **割り込み可能なライブラリ**
[InterruptionToken](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token)および[InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source)クラスがAspose.Slides for C++に追加されました。これらの型は、デシリアライズ、シリアライズ、またはレンダリングなどの長時間実行されるタスクの割り込みをサポートします。[InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source)は、[LoadOptions.set_InterruptionToken()](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options#a9caea79d46cd939505687fdf634530a5)メソッドに渡されるトークンまたは複数のトークンのソースを表します。割り込みトークンが設定され、[LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options)インスタンスが[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)コンストラクタに渡されると、このプレゼンテーションに関連する長時間実行されるタスクは、[InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source#a98ba5fd8badce28a63b5d30a2cfa1e83)メソッドが呼び出されるときに割り込まれます。

以下のコードスニペットは、実行中のタスクを割り込む方法を示しています。

``` cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto thread_function = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(thread_function);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        SharedPtr<LoadOptions> options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"pres.pptx", options);
        presentation->Save(dataDir + u"pres.ppt", Export::SaveFormat::Ppt);
    });
    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);

    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    // 別スレッドでアクションを実行する
    Run(action, tokenSource->get_Token());
    // タイムアウト
    Threading::Thread::Sleep(5000);
    // 変換を停止
    tokenSource->Interrupt();
}
```