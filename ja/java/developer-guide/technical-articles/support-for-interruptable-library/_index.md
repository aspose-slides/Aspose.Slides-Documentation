---
title: "Java で長時間実行されるプレゼンテーション操作を中断する"
linktitle: "プレゼンテーション操作の中断"
type: docs
weight: 120
url: /ja/java/support-for-interruptable-library/
keywords:
- "中断可能な操作"
- "割り込みトークン"
- "キャンセルトークン"
- "長時間タスク"
- "タスクの中断"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java で長時間実行されるプレゼンテーション操作をキャンセルする方法と、スライドをループでエクスポートする際に部分的な結果を返す方法を学びます。"
---
## **概要**

Aspose.Slides for Java は、プレゼンテーションの読み込み、保存、レンダリングなどの長時間実行される操作を中断できます。アプリケーションは同じ interruption token を使用して、次のスライドの処理を開始する前にループを停止できます。

## **プレゼンテーション操作の中断**

[InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) を作成し、[getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--) でトークンを取得し、[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) にそのトークンを渡します。ロードオプションを [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) に渡します。キャンセルを要求するには、ソース上で [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) を呼び出します。割り込み可能な操作は、要求を検出した時点で停止します。

例では、`sample.pptx` をバックグラウンドスレッドで `sample.ppt` に変換します。呼び出し側スレッドは変換完了を最大 10 秒待機します。変換がまだ実行中の場合、キャンセルを要求し、ワーカーが終了するのを待ちます。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **Java のタイムアウトを Aspose.Slides に接続する**

プレゼンテーション操作に時間制限を設定するには、[ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) を使用し、タイムアウトが期限切れになると [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) を呼び出します。例では、`sample.pptx` のロードと `sample.pdf` へのエクスポートに 20 秒を許可します。エクスポートが早期に完了した場合、アプリケーションはスケジュールされた要求をキャンセルします。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **次のスライドを処理する前に停止する**

プレゼンテーションとスライドのエクスポートループの両方で同じ [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) を使用します。各エクスポート前に [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) を確認します。呼び出し側が部分結果を使用できる場合、正常に完了したエクスポートのスライド番号を返します。

少なくとも 2 枚のスライドがある `sample.pptx` を使用します。スライド番号の配列を受け取る [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) のオーバーロードは 1 からカウントします。例では各スライドを個別の PDF に保存し、最初の成功したエクスポートを記録した直後にキャンセルを要求します。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

例は `slide-1.pdf` を書き込み、`Starting slide 1` と出力し、続いて `Completed: [1]` と表示します。ループはスライド 2 の開始前に要求を検出します。保存中にキャンセルが到来した場合、ループはそのスライドを完了として記録する前に終了します。

呼び出し側がキャンセルを処理する必要がある場合、ループ先頭のチェックと `break` を `token.throwIfInterruptionRequested()` に置き換えます。保存処理周りの `try`/`catch` を削除すると、エクスポート中のキャンセルも呼び出し側に伝搬します。同じ入力で、例は `Starting slide 1` のみを出力し、`slide-1.pdf` を書き込みます。2 回目のイテレーション開始時に [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) が `com.aspose.slides.exceptions.OperationCanceledException` をスローし、次のエクスポートは開始されません。メソッドはリストを返しません。

## **FAQ**

**キャンセルはいつ要求すべきですか？**

操作が設定した時間制限を超えたとき、またはアプリケーションが結果を不要としたときにキャンセルを要求します。

**[InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) の違いは何ですか？**

ソースはアプリケーションがキャンセルを要求できるようにします。トークンは Aspose.Slides とアプリケーションがその要求を確認できるようにします。

**Java のタイマーから操作をキャンセルできますか？**

はい。プレゼンテーションに関連付けられたソースに対して [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) をスケジュールしてください。

**どの操作を中断できますか？**

読み込み、保存、レンダリングを中断できます。トークンを [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) に渡す際に [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) で設定します。これにより、PDF 保存などの以降の操作中にキャンセルを検出できます。

**操作はすぐに停止しますか？**

キャンセルは協調的です。操作はトークンを定期的にチェックし、要求を検出した時点で停止します。

**操作完了後に [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) を呼び出すとどうなりますか？**

完了した操作はその結果を保持します。

**複数の操作で同じ [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) を共有できますか？**

はい。[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) を呼び出すと、そのソースから取得したトークンを使用するすべての操作がキャンセル要求を受けます。個別にキャンセルしたい操作ごとに別のソースを使用してください。