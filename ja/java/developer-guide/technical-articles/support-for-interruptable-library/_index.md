---
title: 割り込み可能ライブラリのサポート
type: docs
weight: 120
url: /ja/java/support-for-interruptable-library/
keywords:
- 割り込み可能ライブラリ
- 割り込みトークン
- キャンセルトークン
- 長時間実行タスク
- タスクの割り込み
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、長時間実行タスクをキャンセル可能にします。PowerPoint および OpenDocument のレンダリングと変換を安全に割り込み可能にし、サンプルとともに提供します。"
---

## **割り込み可能ライブラリ**

[Aspose.Slides 18.4](https://releases.aspose.com/slides/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/)で、[InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/)および[InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)クラスを導入しました。これらを使用すると、デシリアライズ、シリアライズ、レンダリングなどの長時間実行タスクを中断できます。

- [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) は、[ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) に渡すトークンのソースです。
- [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) が設定され、[LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) インスタンスが [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) コンストラクタに渡されると、[InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) を呼び出すことで、その [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) に関連付けられた長時間タスクが中断されます。

以下のコードスニペットは、実行中のタスクを中断する例です。
```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // 別スレッドでアクションを実行
Thread.sleep(10000);     // タイムアウト
tokenSource.interrupt(); // 変換を停止
```


## **FAQ**

**Aspose.Slides の割り込みライブラリの目的は何ですか？**

プレゼンテーションのロード、保存、レンダリングなど、長時間かかる操作を完了する前に中断できる仕組みを提供します。処理時間を制限したい場合やタスクが不要になった場合に便利です。

**[InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) の違いは何ですか？**

- `InterruptionToken` は Aspose.Slides API に渡され、長時間実行される操作中にチェックされます。
- `InterruptionTokenSource` はコード側でトークンを生成し、`Interrupt()` を呼び出すことで割り込みをトリガーします。

**どのようなタスクを中断できますか？**

[InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) を受け取るすべての Aspose.Slides タスク、たとえば `Presentation(path, loadOptions)` でのプレゼンテーションのロードや `Presentation.save(...)` での保存などが中断対象となります。

**割り込みはすぐに発生しますか？**

いいえ。割り込みは協調的に行われます。操作は定期的にトークンをチェックし、`Interrupt()` が呼び出されたことを検出した時点で停止します。

**タスクが既に完了した後に [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) を呼び出した場合はどうなりますか？**

何も起こりません。対応するタスクがすでに完了している場合、呼び出しは効果を持ちません。

**同じ [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) を複数のタスクで再利用できますか？**

はい。ただし、そのソースで `Interrupt()` を呼び出すと、そのトークンを使用しているすべてのタスクが中断されます。タスクを独立して管理したい場合は、別々のトークンソースを使用してください。