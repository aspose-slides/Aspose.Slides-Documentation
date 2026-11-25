---
title: Node.jsで長時間実行されるプレゼンテーション操作を中断する
linktitle: プレゼンテーション操作の中断
type: docs
weight: 120
url: /ja/nodejs-java/support-for-interruptable-library/
keywords:
- 中断可能な操作
- 中断トークン
- キャンセルトークン
- 変換タイムアウト
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java における長時間実行されるプレゼンテーション操作をキャンセルし、変換タイムアウトを設定し、キャンセル前にエクスポートされたスライドを追跡します。"
---
## **概要**

Aspose.Slides for Node.js via Java は、プレゼンテーションの読み込み、保存、またはレンダリング時にキャンセルをサポートします。独自のエクスポートループで同じトークンを確認し、次のスライドの前で停止して、すでに保存されたスライドの番号を返すこともできます。

## **プレゼンテーション操作の中断**

[InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/) を作成し、[getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) でトークンを取得し、[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken) に渡します。これらのオプションは [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) を構築するときに使用します。ソースで [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) を呼び出すと現在の操作のキャンセルが要求されます。Aspose.Slides は次にトークンをチェックしたときに停止します。

### **変換タイムアウトの設定**

次の例は `sample.pptx` を開き `sample.pdf` として保存するのに 20 秒を許容します。コンストラクターと保存の両方が Java ブリッジを介して非同期に実行されるため、Node.js タイマーはどちらの操作中でも発火できます。例ではロード後と保存後にトークンを確認します。これは、ライブラリ呼び出しがキャンセル要求後に戻る可能性があるためです。操作が完了したらプレゼンテーションを解放し、変換が早期に終了した場合はタイマーをクリアします。保存中にキャンセルが発生した場合、出力ファイルは既に存在していて不完全になる可能性があります。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

古い PowerPoint 形式に変換し 10 秒の制限を設けるには、最後の 3 つの引数として `"sample.ppt"`、`slides.SaveFormat.Ppt`、および `10000` を渡します。

## **次のスライドを処理する前に停止**

エクスポートごとに、呼び出し側が部分結果を使用できる場合は [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) を使用してチェックします。選択したスライド用の [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) オーバーロードは、1 から始まるスライド番号の Java `int[]` を受け取ります。PDF が正常に保存された後にのみ、各番号を記録します。

プレゼンテーション名が `sample.pptx` で少なくとも 2 枚のスライドが含まれている例を実行します。エクスポート間のキャンセルをデモするために、最初のスライドを保存した直後にキャンセルを要求します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

例は `slide-1.pdf` を書き込み、`Starting slide 1` と出力してから `Completed: [1]` を表示します。ループはスライド 2 を開始する前にキャンセルを検知します。保存自体が中断された場合、返されるリストにはそれ以前に成功したエクスポートのみが含まれます。

呼び出し側がキャンセルをエラーとして処理できるようにするには、ループ冒頭のチェックと `break` を [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) に置き換えます。呼び出しは `token.throwIfInterruptionRequested()` とします。保存後にも同じ例外チェックを行い、周囲の `try`/`catch` を削除します。同じ入力で、最初の PDF はまだ書き込まれ、2 番目のイテレーションは関数がリストを返す前に例外をスローします。

## **FAQ**

**キャンセルはいつ要求すべきですか？**

期限が切れたときやアプリケーションが結果をもはや必要としないときにキャンセルを要求します。ロード、保存、レンダリングのすべてで、プレゼンテーション構築時に渡したトークンを使用できます。

**ソースとトークンはどのように異なりますか？**

ソースはアプリケーションがキャンセルを要求できるようにします。トークンは Aspose.Slides と独自コードがその要求を確認できるようにします。

**Node.js タイマーは同期保存を中断できますか？**

同期保存は呼び出しスレッド上で JavaScript をブロックします。タイムアウト例で示した非同期 Java ブリッジ呼び出しを使用すれば、保存中にタイマーがキャンセルを要求できます。

**キャンセルはすぐに有効になりますか？**

キャンセルは協調的です。実行中の操作は要求を確認したときに停止します。既に完了した操作はその結果を保持します。

**複数の操作が同じソースを共有できますか？**

はい。`interrupt()` を呼び出すと、そのソースから取得したトークンを使用するすべての操作がキャンセルされます。個別にキャンセルしたい操作ごとに別々のソースを使用してください。