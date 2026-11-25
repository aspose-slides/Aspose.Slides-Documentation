---
title: Python での長時間実行プレゼンテーション操作の中断
linktitle: プレゼンテーション操作の中断
type: docs
weight: 150
url: /ja/python-net/support-for-interruptable-library/
keywords:
- 中断可能な操作
- 割り込みトークン
- PDF エクスポートのキャンセル
- PowerPoint
- Python
- Aspose.Slides
description: "Python でプレゼンテーション変換をキャンセルし、キャンセル前にエクスポートが完了したスライドのリストを返す方法を学びます。"
---
## **概要**

Aspose.Slides for Python via .NET は、読み込み、保存、プレゼンテーションのレンダリングなどの長時間実行される操作中に協調的なキャンセルをサポートします。スライドを個別にエクスポートする場合、スライド間でキャンセルをチェックし、エクスポートが完了したスライドの番号を返すこともできます。

## **プレゼンテーション変換のキャンセル**

[InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/) を作成し、その [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) を [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/) に割り当て、オプションを [Presentation コンストラクタ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/) に渡します。トークンはプレゼンテーションのライフタイム全体に適用されます。アプリケーションからキャンセルを要求するには、[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/) を呼び出します。

この例は `sample.pptx` を `sample.pdf` に変換します。 [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) が 20 秒後に `source.interrupt` を呼び出します。ファイルを開く前にタイマーを開始すると、タイムアウトが読み込みと保存の両方に適用されます。Cancel ボタンを持つアプリケーションは、イベントハンドラから同じメソッドを呼び出すことができます。

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

読み込み後の明示的なチェックは、タイムアウトがすでに経過している場合、エクスポートをスキップします。読み込みまたは保存が要求を検知した場合、キャンセル例外が呼び出し元に伝わります。保存が要求を検知する前に完了した場合は、PDF は完全な状態になります。

## **次のスライドを処理する前に停止**

各エクスポートの前に [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) をチェックします。 [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) は 1 から始まるスライド番号のリストを受け取ります。PDF が正常に保存された後にのみ、その番号を完了リストに追加します。

少なくとも 2 枚のスライドがある `sample.pptx` ファイルを使用します。結果を再現可能にするため、例ではスライド 1 が完了した時点でキャンセルを要求します。アプリケーションでは、スライドが保存されている間に別スレッドから要求が来ることがあります。

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

例は `slide-1.pdf` を書き出し、`Starting slide 1` を表示したあと `Completed: [1]` を出力します。次のイテレーションはスライド 2 を開始する前に要求を検知します。キャンセルが保存を中断した場合、例外ハンドラは前のイテレーションで記録された番号を返します。他のエクスポートエラーは呼び出し元に伝わります。

呼び出し元がキャンセルを例外として処理すべき場合、ループ先頭のチェックとその `break` を [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/) に置き換えます。また、保存周りの `try`/`except` を削除します。同じ入力で、スライド 1 は保存され、2 回目のイテレーションはスライド 2 を開始する前にキャンセル例外をスローします。

## **FAQ**

**キャンセル要求はいつ有効になりますか？**

割り込み可能な操作はトークンを定期的にチェックします。要求を検知した時点で停止します。すでに完了した操作はその結果を保持します。

**ソースとトークンの違いは何ですか？**

ソースはアプリケーションがキャンセルを要求できるようにします。トークンはプレゼンテーションと独自のコードの両方がその要求をチェックできるようにします。

**複数の操作が同じソースを共有できますか？**

はい。`interrupt` を呼び出すと、そのソースから取得したトークンを使用するすべての操作に対してキャンセルが要求されます。個別にキャンセルしたい場合は、各操作に独自のソースを与えてください。