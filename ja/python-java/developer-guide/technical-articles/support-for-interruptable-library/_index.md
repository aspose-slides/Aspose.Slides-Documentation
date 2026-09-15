---
title: 中断可能ライブラリのサポート
type: docs
weight: 120
url: /ja/python-java/support-for-interruptable-library/
keywords:
- 中断可能ライブラリ
- 中断トークン
- キャンセルトークン
- 長時間タスク
- タスクの中断
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して長時間タスクをキャンセル可能にします。PowerPoint および OpenDocument のレンダリングや変換を安全に中断でき、サンプル付きです。"
---
## **概要**

Aspose.Slides は、デシリアライズ、シリアライズ、レンダリングなどの長時間実行されるプレゼンテーション タスクに対して中断可能な処理メカニズムを提供します。このメカニズムは、[InterruptionToken](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontokensource/) クラスに基づいています。

[InterruptionToken](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontoken/) は [LoadOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/) に割り当てて、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) コンストラクターに渡すことができます。[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontokensource/#interrupt) が呼び出されると、関連付けられた長時間タスクが中断されます。

## **中断可能ライブラリ**

Aspose.Slides for Python via Java は、[InterruptionToken](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontokensource/) クラスを提供します。これらを使用すると、デシリアライズ、シリアライズ、レンダリングなどの長時間タスクを中断できます。

- [InterruptionTokenSource](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontokensource/) は、[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setInterruptionToken) に渡されるトークンのソースです。
- [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setInterruptionToken) が呼び出され、[LoadOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/) インスタンスが [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) コンストラクターに渡されると、[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontokensource/#interrupt) を呼び出すことで、その [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) に関連付けられた長時間タスクがすべて中断されます。

以下のコード スニペットは、実行中のタスクを中断する方法を示しています。

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # 別スレッドでアクションを実行します。
    time.sleep(10)  # タイムアウト。
    token_source.interrupt()  # 変換を停止します。
    conversion_task.result()
```

## **FAQ**

**Aspose.Slides の中断ライブラリの目的は何ですか？**

ロード、保存、レンダリングなどの長時間操作を完了する前に中断できるメカニズムを提供します。処理時間を制限する必要がある場合や、タスクが不要になった場合に便利です。

**[InterruptionToken](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontokensource/) の違いは何ですか？**

- [InterruptionToken](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontoken/) は Aspose.Slides API に渡され、長時間操作中にチェックされます。
- [InterruptionTokenSource](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontokensource/) はコード内でトークンを生成し、[interrupt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontokensource/#interrupt) を呼び出すことで中断をトリガーします。

**どのタスクを中断できますか？**

[InterruptionToken](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontoken/) を受け取るすべての Aspose.Slides タスク、たとえば [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) でのプレゼンテーションのロードや、[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) での保存などは中断可能です。

**中断はすぐに行われますか？**

いいえ。中断は協調的に行われます。操作は定期的にトークンをチェックし、[interrupt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontokensource/#interrupt) が呼び出されたことを検出した時点で停止します。

**タスクがすでに完了した後に [interrupt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontokensource/#interrupt) を呼び出すとどうなりますか？**

何も起きません。対象のタスクがすでに完了している場合、呼び出しは影響を与えません。

**同じ [InterruptionTokenSource](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontokensource/) を複数のタスクで再利用できますか？**

可能です。ただし、そのソースで [interrupt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/interruptiontokensource/#interrupt) を呼び出すと、そのトークンを使用しているすべてのタスクが中断されます。タスクを個別に管理したい場合は、別々のトークン ソースを使用してください。