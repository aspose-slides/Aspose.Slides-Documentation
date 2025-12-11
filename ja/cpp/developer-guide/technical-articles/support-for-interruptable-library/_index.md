---
title: 割り込み可能ライブラリのサポート
type: docs
weight: 150
url: /ja/cpp/support-for-interruptable-library/
keywords:
- 割り込み可能ライブラリ
- 割り込みトークン
- キャンセルトークン
- 長時間実行タスク
- タスクの割り込み
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: Aspose.Slides for C++ を使用して長時間実行タスクをキャンセル可能にします。PowerPoint および OpenDocument のレンダリングや変換を安全に割り込み、サンプルと共に提供します。
---

## **割り込み可能ライブラリ**

[Aspose.Slides 18.4](https://releases.aspose.com/slides/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/) では、[InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) クラスを導入しました。これらは、デシリアライズ、シリアライズ、レンダリングなどの長時間実行タスクを中断できるようにします。

- [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) は、[ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) に渡されるトークンの元です。
- [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) が設定され、[LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) インスタンスが [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) コンストラクターに渡されると、[InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) を呼び出すことで、その [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) に関連付けられた長時間実行タスクが中断されます。

以下のコードスニペットは、実行中のタスクを中断する方法を示しています。
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
    
    Run(action, tokenSource->get_Token()); // 別スレッドでアクションを実行する
    Threading::Thread::Sleep(10000);       // タイムアウト
    tokenSource->Interrupt();              // 変換を停止する
}
```


## **FAQ**

**Aspose.Slides の割り込みライブラリの目的は何ですか？**

ロード、保存、プレゼンテーションのレンダリングなど、長時間実行される操作を完了前に中断できる仕組みを提供します。処理時間を制限したい場合やタスクが不要になった場合に便利です。

**[InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) の違いは何ですか？**

- `InterruptionToken` は Aspose.Slides API に渡され、長時間実行される操作中にチェックされます。
- `InterruptionTokenSource` はコード側でトークンを作成し、`Interrupt()` を呼び出すことで中断をトリガーします。

**どのようなタスクを中断できますか？**

`InterruptionToken` を受け取るすべての Aspose.Slides タスク、たとえば `Presentation(path, loadOptions)` でのプレゼンテーションのロードや `Presentation::Save(...)` での保存などが中断可能です。

**中断はすぐに行われますか？**

いいえ。中断は協調的に行われます。操作は定期的にトークンをチェックし、`Interrupt()` が呼び出されたことを検出した時点で停止します。

**タスクがすでに完了した後に [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) を呼び出すとどうなりますか？**

何も起こりません。該当タスクがすでに完了している場合、呼び出しは効果を持ちません。

**複数のタスクで同じ [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) を再利用できますか？**

はい。ただし、そのソースで `Interrupt()` を呼び出すと、そのトークンを使用しているすべてのタスクが中断されます。タスクを個別に管理したい場合は、別々のトークンソースを使用してください。