---
title: JavaScript でプレゼンテーションを XAML にエクスポート
linktitle: プレゼンテーションを XAML に変換
type: docs
weight: 30
url: /ja/nodejs-java/export-to-xaml/
keywords:
- PowerPoint をエクスポート
- OpenDocument をエクスポート
- プレゼンテーションをエクスポート
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- PowerPoint から XAML へ
- OpenDocument から XAML へ
- プレゼンテーションを XAML に変換
- PPT から XAML へ
- PPTX から XAML へ
- ODP から XAML へ
- PPT を XAML として保存
- PPTX を XAML として保存
- ODP を XAML として保存
- PPT を XAML にエクスポート
- PPTX を XAML にエクスポート
- ODP を XAML にエクスポート
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用して JavaScript で PowerPoint および OpenDocument のスライドを XAML に変換します — 迅速で Office 不要のソリューションで、レイアウトをそのまま保持します。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションを XAML にエクスポートする方法を説明します。XAML の簡単な概要を示し、デフォルト設定でプレゼンテーションを XAML に保存する方法と、[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) を使用してエクスポートをカスタマイズする方法（非表示スライドのエクスポートを含む）を説明します。また、フォールバック フォント、XAML スタックの互換性、非表示スライドのエクスポート動作に関する一般的な質問にも回答します。

## **XAML について**

XAML は、WPF（Windows Presentation Foundation）や UWP（Universal Windows Platform）、Xamarin.Forms などのフレームワークでユーザー インターフェイスを記述するために使用される XML ベースのマークアップ言語です。

XAML ファイルはビジュアル デザイナーで操作したり、マークアップを直接記述・編集したりできます。

## **デフォルト オプションでプレゼンテーションを XAML にエクスポートする**

次の JavaScript の例は、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

既定では、エクスポートされたスライドはプロセスの現在の作業ディレクトリの `input` サブフォルダーに保存されます。フォルダーは自動的に作成され、必要な画像も同じ場所に保存されます。

出力フォルダー名は、拡張子を除いた元ファイル名から取得されます。Aspose.Slides for Node.js via Java 26.8 では、`input.pptx` をエクスポートすると `input/input/Slide_1.xaml` のような階層パスが生成されます。出力を処理するときは、生成された完全なパスを保持してください。既定の出力は現在の作業ディレクトリに対して相対的であり、必ずしも入力ファイルと同じ場所になるわけではありません。

## **カスタム オプションでプレゼンテーションを XAML にエクスポートする**

[IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) インターフェイスを使用して、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を制御します。

出力先をカスタム場所に保存するには、[IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) を実装し、そのインスタンスを [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) の [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) メソッドに渡します。

XAML 出力に非表示スライドを含めるには、以下の JavaScript の例のように `true` を指定して [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) を呼び出します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **生成されたすべての XAML アーティファクトを取得する**

XAML エクスポートは、エクスポートされた各スライド用の XAML ドキュメントに加えて、個別の画像やサポート リソースを生成することがあります。デフォルトのファイル システム セーバーの代わりに、これらのアーティファクトを受け取るためにカスタム [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) を [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) に割り当てます。エクスポートは、XAML オプションを受け取る [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) のオーバーロードで開始します。

Node.js では、Aspose.Slides が使用する `java` パッケージの `java.newProxy` を使って Java インターフェイスを実装します。エクスポートが完了するまでプロキシを保持してください。

### **コールバック ライフサイクルの理解**

エクスポーターは、生成された各アーティファクトに対して [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) を個別に呼び出します。

- `path` はアーティファクトを識別し、相対ディレクトリを含むことがあります。XAML は相対パスでリソースを参照できるため、この情報は保持してください。
- `data` はアーティファクトのバイト列です。画像やその他のバイナリ リソースはテキストとしてデコードしないでください。
- セーバーはデータを保持または永続化した上で戻り値を返す責任があります。例では各 Java バイト配列をアプリケーション所有の Node.js バッファにコピーしています。
- プレゼンテーションの保存操作が返り、すべてのコールバックが正常に完了したときにのみエクスポートを成功とみなします。保存エラーを無視したり、バックグラウンド書き込みを監視せずに開始したりしないでください。永続化が後で行われる場合は、そのステップが成功した後に全体の成功を報告します。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) はカスタム セーバーにも適用されます。既定設定の `false` は非表示スライドの XAML ドキュメントを除外します。`true` を渡すと、非表示スライドとそれらのエクスポートに必要なリソースが含まれます。リソース数はプレゼンテーションに依存するため、スライドごとに 1 コールバックがあるとか、固定順序があるとか想定しないでください。

### **メモリにエクスポートし、アーティファクトを検査する**

以下の完全な例は `input.pptx` を読み込み、すべてのアーティファクトを名前 → バッファのマップに収集し、名前、タイプ、バイト数を出力します。名前は提供されたまま正確に保持します。重複名がある場合はコレクションを無効として扱い、黙って上書きしません。例は結果を使用する前にこのチェックを行います。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // XAML のみをデコードし、テキストの検査が必要なときだけ行います。
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

拡張子チェックは検査に有用です。すべてのアーティファクト（見慣れないリソース型も含む）を保持し、バイト列は保存または転送時に変更しないでください。テキスト処理が必要な XAML のみ UTF-8 デコードを使用してください。

### **収集したアーティファクトを ZIP アーカイブにパッケージ化する**

この独立した例はエクスポートを収集し、名前を検証したうえで、Java ブリッジを使用して元のバイト列を ZIP アーカイブに書き込みます。ZIP はメモリ内で組み立てられ、ディスクに保存されます。ユニークなアーカイブ名により同時エクスポート ジョブが分離されます。ZIP エントリはスラッシュ (/) を使用し、相対ディレクトリを保持します。正規化後に衝突する名前や安全でない名前は、書き込み前にパッケージ全体を拒否します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // クローズすると、アーカイブが永続化される前に ZIP ディレクトリが確定します。
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

例では [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) を使用してローカル アーカイブを作成しています。エクスポーター自体は個別の XAML や画像ファイルを書き込みません。リモート ストレージの場合は、アーカイブ書き込み段階を収集したバイト配列のアップロードに置き換えてください。エクスポート ジョブ ID と完全な相対アーティファクト名をブロブ キーとして使用するか、ジョブ ID、相対名、バイナリ データをデータベースの行に保存します。すべてのアップロードが完了し、データベース トランザクションがコミットされた後にジョブを公開します。永続化が失敗した場合は部分的な出力をクリーンアップしてください。

大規模なプレゼンテーションでは、カスタム セーバーが各アーティファクトを直接アプリケーション ストレージに永続化し、エクスポート全体をメモリに保持しないようにできます。エクスポーターの観点からは各コールバックを同期的に扱い、宛先がバイトを受け取った後にのみ戻り、失敗は呼び出し元に伝播させます。

### **リソース名を保持し、参照を検証する**

- 宛先が要求する場合はパス区切り文字を正規化しますが、相対ディレクトリは保持してください。すべての生成名が一意でリソース参照が有効であると確信できない限り、ベース名だけを使用しないでください。
- 宛先固有の名前検証を適用します。ファイルを書き込む際は、ルート パスや相対遡りセグメントを拒否し、宛先を絶対パスに解決し、エクスポート ディレクトリ以下に収まっていること（ディレクトリ区切り文字を含む）を確認してください。シンボリック リンクが書き込み先をリダイレクトしないよう、アプリケーション制御のディレクトリを使用します。
- エクスポート ジョブごとに別々のセーバーとストレージ名前空間を使用します。区切り文字正規化後および宛先の大文字小文字感度ルールに従って衝突を検出します。
- 公開前に各 XAML ドキュメントを XML として解析し、`Source` や `ImageSource` 属性などファイルベースのリソース参照を検査します。各相対 URI を含む XAML アーティファクトのディレクトリに対して解決し、得られたストレージ名を正規化して、対応するマップキー、ZIP エントリ、または保存オブジェクトが存在することを確認してください。外部 URI と XAML のマークアップ式は、相対ファイル名とは別に扱います。

たとえば、`input/Slide_1.xaml` が `images/image1.png` を参照している場合、保存されたリソースは `input/images/image1.png` として利用可能でなければなりません。`image1.png` だけを保持すると関係が壊れます。オブジェクト ストレージの場合はジョブ プレフィックス以下に同じレイアウトを保持し、これらのリソース URL を XAML コンシューマがアクセスできるようにします。完成した ZIP を再度開き、エントリ名とリソース バイトを検証し、対象 XAML 環境で代表的なスライドをロードして画像が正しく解決されることを確認してください。

## **FAQ**

**元のフォントがマシンに存在しない場合、予測可能なフォントを確保するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) の [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) を呼び出します。エクスポート時に元のフォントが見つからない場合のフォールバック フォントとして使用されます。ただし、生成された XAML が必ずフォールバック フォントを参照することや、ターゲット マシンにそのフォントが存在することを保証するものではありません。XAML が表示される環境に、参照されるフォントが配置されていることを確認してください。

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

Aspose.Slides は公開 API を通じて WPF 用 XAML をエクスポートします。UWP や Xamarin.Forms など他の XAML スタックとの互換性は保証されません。生成されたマークアップはターゲット 環境でテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) でこの動作を制御できます。非表示スライドをエクスポートする必要がない場合は、該当オプションを無効のままにしてください。