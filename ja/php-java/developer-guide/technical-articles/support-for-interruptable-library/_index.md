---
title: PHP で長時間実行されるプレゼンテーション操作の中断
linktitle: プレゼンテーション操作の中断
type: docs
weight: 120
url: /ja/php-java/support-for-interruptable-library/
keywords:
- 割り込みトークン
- キャンセル
- 変換タイムアウト
- スライドエクスポート
- PowerPoint
- PHP
- Aspose.Slides
description: "タイマーでプレゼンテーションの変換をキャンセルし、キャンセル前にエクスポートされたスライドを Aspose.Slides for PHP via Java で返す方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java は、プレゼンテーションの読み込み、保存、レンダリングなどの長時間実行される操作を中断できます。1枚ずつスライドをエクスポートするループでは、同じトークンを使用することで、次のスライドの前でアプリケーションを停止させ、完了したエクスポートの一覧を返すことができます。

両方の PHP サンプルは、ブートストラップでブリッジの `Java.inc` を読み込む前に `define("JAVA_PREFER_VALUES", 1);` を呼び出し、その後 `aspose.slides.php` をロードすることを前提としています。この設定により、呼び出し中に PHP が Java の例外を捕捉できます。サンプルはラップされた例外の原因を調べ、他の変換エラーが呼び出し元に伝わるようにしています。

## **プレゼンテーション操作の中断**

まず [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/) を作成し、[InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) でトークンを取得して、[LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken) に渡します。これらのオプションは [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) を構築する際に指定します。[InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) を呼び出すとキャンセルが要求されます。実行中の操作は要求を検知すると停止します。

### **変換タイムアウトの設定**

PHP が PHP/Java Bridge を介して同期的な読み込みや保存を待機している間に、Java のタイマーが別スレッドでキャンセルを要求できます。以下のヘルパーを `ConversionTimeout.java` として保存し、クラスパスに Aspose.Slides の JAR を置いてコンパイルし、コンパイルされたクラスをブリッジから `example.ConversionTimeout` パッケージ名で利用できるようにします。

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

ブリッジと Aspose.Slides PHP ラッパーがロードされた状態で、Java プロセスの作業ディレクトリに `sample.pptx` を置くか、プロセスからアクセス可能な絶対パスを使用して次の例を実行します。20 秒の制限は読み込みと PDF エクスポートの両方をカバーします。変換が早期に完了した場合、PHP がタイマーをキャンセルします。10 秒の制限で旧形式の PowerPoint に変換するには、`sample.ppt`、`SaveFormat::Ppt`、および `10000` ミリ秒を使用します。

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **次のスライドを処理する前に停止**

各エクスポートの前に [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) を確認します。選択したスライド用の [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) オーバーロードは、1 から始まるスライド番号を受け取ります。1 要素の配列を渡すことで、スライドごとに個別の PDF を作成できます。

`sample.pptx` にスライドが 2 枚以上含まれていることを使用してください。エクスポート間のキャンセルを示すために、例では最初のスライドを記録した直後にキャンセルを要求します。

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

例は `slide-1.pdf` を作成し、`Completed: [1]` と出力します。2 回目のループではエクスポートを開始する前にリクエストを検出します。保存中にキャンセルが発生した場合、一覧にはそれまでに確定したエクスポートのみが含まれます。中断された保存はディスク上に不完全なファイルを残すことがあります。

キャンセルを呼び出し元に伝搬させるには、ループ開始時のチェックを `$token->throwIfInterruptionRequested();` に置き換え、内部の `try`/`catch` を削除し、保存処理とその後のチェックだけを残します。同じ入力で、[InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) はスライド 2 の前に例外をスローし、呼び出し元は一覧を受け取りません。

## **よくある質問**

**キャンセルはいつ要求すべきですか?**

期限が切れたときや呼び出し元が結果を必要としなくなったときにキャンセルを要求します。操作が完了した後に行われたリクエストは、結果に影響を与えずそのまま残ります。

**ソースとトークンの違いは何ですか?**

ソースはアプリケーションがキャンセルを要求できるようにし、トークンは Aspose.Slides およびアプリケーションコードがその要求を観測できるようにします。

**複数の操作が同じソースを共有できますか?**

はい。要求はそのソースから取得したトークンを使用するすべての操作に適用されます。独立したキャンセルが必要な操作には別々のソースを作成してください。