---
title: Android で長時間実行されるプレゼンテーション操作を中断する
linktitle: プレゼンテーション操作の中断
type: docs
weight: 120
url: /ja/androidjava/support-for-interruptable-library/
keywords:
- 中断可能な操作
- 中断トークン
- キャンセルトークン
- 長時間タスク
- タスクの中断
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java で長時間実行されるプレゼンテーション操作をキャンセルし、スライドをループでエクスポートする際に部分結果を返す方法を学びます。"
---
## **概要**

Aspose.Slides for Android via Java は、プレゼンテーションの読み込み、保存、レンダリングなど、長時間実行される操作を中断できます。アプリケーションは同じ中断トークンを使用して、次のスライドの処理を開始する前にループを停止できます。

## **プレゼンテーション操作の中断**

[InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) を作成し、[getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--) でトークンを取得し、そのトークンを [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) に渡します。ロードオプションを [Presentation コンストラクタ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) に渡します。キャンセルを要求するには、ソース上で [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) を呼び出します。中断可能な操作は要求を検知すると停止します。

この例はバックグラウンドスレッドで `sample.pptx` を `sample.ppt` に変換します。呼び出し元スレッドは変換が完了するまで最大10秒待機します。変換がまだ実行中の場合、キャンセルを要求し、ワーカーの終了を待ちます。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // バックグラウンドスレッドから呼び出し、sample.pptx が含まれる context.getFilesDir() を渡します。
    public static void run(File directory) throws InterruptedException {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.ppt");
        InterruptionTokenSource source = new InterruptionTokenSource();
        Thread worker = new Thread(() -> {
            LoadOptions options = new LoadOptions();
            options.setInterruptionToken(source.getToken());
            try {
                Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                try {
                    presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
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
    }
}
```

## **Java のタイムアウトを Aspose.Slides に接続する**

プレゼンテーション操作に時間制限を設定するには、[ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) を使用してタイムアウトが期限切れになったときに [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) を呼び出します。この例では `sample.pptx` のロードと `sample.pdf` へのエクスポートに最大20秒を許容します。エクスポートが早期に完了した場合、アプリケーションはスケジュールされた要求をキャンセルします。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // バックグラウンドスレッドから呼び出し、sample.pptx が含まれる context.getFilesDir() を渡します。
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```

## **次のスライドを処理する前に停止する**

プレゼンテーションとスライドをエクスポートするループの両方で同じ [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) を使用します。各エクスポートの前に [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) を確認します。呼び出し側が部分結果を使用できる場合、正常に完了したエクスポートのスライド番号を返します。

`sample.pptx` という名前のプレゼンテーションを使用し、少なくとも2枚のスライドがあることを前提とします。スライド番号の配列を受け取る [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) のオーバーロードは 1 からカウントします。この例では各スライドを個別の PDF に保存し、最初の成功したエクスポートを記録した直後にキャンセルを要求します。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
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

    // バックグラウンドスレッドから呼び出し、sample.pptx が含まれる context.getFilesDir() を渡します。
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

この例では `slide-1.pdf` を書き込み、`Starting slide 1` を表示し、その後 `Completed: [1]` と出力します。ループはスライド2の開始前に要求を検知します。保存中にキャンセルが発生した場合、ループはそのスライドを完了として記録する前に終了します。

呼び出し側がキャンセルを処理する必要がある場合、ループ先頭のチェックと `break` を `token.throwIfInterruptionRequested()` に置き換えます。エクスポート中のキャンセルも呼び出し側へ伝わるように、保存周りの `try`/`catch` を削除します。同じ入力で、この例は `Starting slide 1` だけを出力し、`slide-1.pdf` を書き込みます。2回目のイテレーション開始時に、[throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) が次のエクスポートが始まる前に `com.aspose.slides.exceptions.OperationCanceledException` をスローします。このメソッドはリストを返しません。

## **よくある質問**

**キャンセルはいつ要求すべきですか？**

操作が時間制限を超えた場合や、アプリケーションが結果をもはや必要としない場合にキャンセルを要求します。

**[InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) と [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) の違いは何ですか？**

ソースはアプリケーションがキャンセルを要求できるようにし、トークンは Aspose.Slides とアプリケーションがその要求を確認できるようにします。

**Java のタイマーから操作をキャンセルできますか？**

はい。プレゼンテーションに関連付けられたソースに対して [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) を呼び出すようスケジュールします。

**どの操作を中断できますか？**

ロード、保存、レンダリングを中断できます。トークンは [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) を通じて [Presentation コンストラクタ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) に渡します。これにより、プレゼンテーションは PDF への保存など、以降の操作中にキャンセルを検知できるようになります。

**操作はすぐに停止しますか？**

キャンセルは協調的です。操作は定期的にトークンをチェックし、要求を検知した時点で停止します。

**操作が完了した後に [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) を呼び出すとどうなりますか？**

完了した操作はその結果を保持したままです。

**複数の操作が同じ [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) を共有できますか？**

はい。[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) を呼び出すと、そのソースから取得したトークンを使用するすべての操作に対してキャンセルが要求されます。個別にキャンセルしたい操作ごとに別々のソースを使用してください。