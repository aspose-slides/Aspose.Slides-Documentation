---
title: Python で長時間実行されるプレゼンテーション操作の中断
linktitle: プレゼンテーション操作の中断
type: docs
weight: 120
url: /ja/python-java/support-for-interruptable-library/
keywords:
- 中断可能な操作
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
description: "Aspose.Slides for Python via Java で長時間実行されるプレゼンテーション操作をキャンセルし、スライドをループでエクスポートする際に部分結果を返す方法を学びます。"
---
## **概要**

Aspose.Slides for Python via Java は、プレゼンテーションの読み込み、保存、レンダリングなどの長時間実行される操作を中断できます。アプリケーションは同じインタラプショントークンを使用して、次のスライドの処理を開始する前にループを停止できます。

## **プレゼンテーション操作の中断**

[InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) を作成し、[getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken) でトークンを取得し、トークンを [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) に渡します。ロードオプションを [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) に渡します。キャンセルを要求するには、ソース上で [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) を呼び出します。インタラプト可能な操作は要求を検知した時点で停止します。`jpype.JClass` を使用して、Python で Java 例外 `com.aspose.slides.exceptions.OperationCanceledException` を捕捉します。

この例はバックグラウンドスレッドで `sample.pptx` を `sample.ppt` に変換します。呼び出し側スレッドは変換完了を最大 10 秒待機します。変換がまだ実行中の場合はキャンセルを要求し、ワーカーの終了を待ちます。

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Python のタイムアウトを Aspose.Slides に接続**

プレゼンテーション操作に時間制限を設定するには、[threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) を使用して、タイムアウトが切れたときに [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) を呼び出します。この例は `sample.pptx` のロードと `sample.pdf` へのエクスポートに 20 秒を許容します。エクスポートが早期に完了した場合、アプリケーションはスケジュールされたリクエストをキャンセルします。

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **次のスライドを処理する前に停止**

プレゼンテーションとスライドをエクスポートするループで同じ [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) を使用します。各エクスポート前に [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) をチェックします。呼び出し側が部分結果を利用できる場合、正常に完了したエクスポートのスライド番号を返します。

少なくとも 2 枚のスライドがある `sample.pptx` を使用します。Java の `int[]` を受け取る [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) のオーバーロードは、スライド番号を 1 から開始します。Python で `jpype.JArray(jpype.JInt)` を使用して配列を作成します。この例は各スライドを個別の PDF に保存し、最初の成功したエクスポートが記録された直後にキャンセルを要求します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

例は `slide-1.pdf` を書き出し、`Starting slide 1` を出力し、続いて `Completed: [1]` を表示します。ループはスライド 2 を開始する前にリクエストを検知します。保存中にキャンセルが発生した場合、ループはそのスライドを完了として記録せずに終了します。

呼び出し側がキャンセルを処理する必要がある場合、ループ冒頭のチェックと `break` を `token.throwIfInterruptionRequested()` に置き換えます。保存処理の周囲にある `try`/`except` を削除し、エクスポート中のキャンセルも呼び出し側に伝搬させます。同じ入力で例は `Starting slide 1` のみを出力し、`slide-1.pdf` を書き出します。2 回目のイテレーション開始時に [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) が `com.aspose.slides.exceptions.OperationCanceledException` をスローし、次のエクスポートが始まる前に例外が呼び出し側へ伝搬します。関数はリストを返す前に終了します。

## **FAQ**

**いつキャンセルを要求すべきですか？**

操作が設定した時間制限を超えたとき、またはアプリケーションが結果をもはや必要としないときにキャンセルを要求します。

**[InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) の違いは何ですか？**

ソースはアプリケーションがキャンセルを要求できるようにし、トークンは Aspose.Slides とアプリケーションがその要求をチェックできるようにします。

**Python のタイマーから操作をキャンセルできますか？**

はい。プレゼンテーションに関連付けられたソースに対して [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) を呼び出すようスケジュールします。

**どの操作を中断できますか？**

読み込み、保存、レンダリングを中断できます。トークンを [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) に渡し、[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) で設定します。その後、PDF への保存などの後続操作でもプレゼンテーションはキャンセルを検知できます。

**操作はすぐに停止しますか？**

キャンセルは協調的に行われます。操作はトークンを定期的にチェックし、要求を検知した時点で停止します。

**操作完了後に [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) を呼び出すとどうなりますか？**

完了した操作は結果を保持します。

**複数の操作が同じ [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) を共有できますか？**

はい。同じソースから取得したトークンを使用するすべての操作に対して、[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) がキャンセルを要求します。個別にキャンセルしたい操作ごとに別のソースを使用してください。