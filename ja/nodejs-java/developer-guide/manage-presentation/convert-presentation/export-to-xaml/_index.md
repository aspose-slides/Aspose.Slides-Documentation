---
title: JavaScript でプレゼンテーションを XAML にエクスポート
linktitle: プレゼンテーションから XAML へ
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
- プレゼンテーションから XAML へ
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
description: "Aspose.Slides を使用して JavaScript で PowerPoint および OpenDocument のスライドを XAML に変換します—レイアウトをそのまま保つ高速で Office 不要のソリューションです。"
---
## **概要**

このドキュメントでは、Aspose.Slides を使用して PowerPoint プレゼンテーションを XAML にエクスポートする方法を説明します。XAML の簡単な概要、デフォルト設定でプレゼンテーションを XAML に保存する方法、そして非表示スライドのエクスポートを含むカスタマイズ方法を [XamlOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/xamloptions/) を使って示します。また、フォントのフォールバック、XAML スタックの互換性、非表示スライドのエクスポート動作に関する一般的な質問にも答えています。

## **XAML について**

XAML は XML ベースのマークアップ言語で、WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin.Forms などのフレームワークでユーザーインターフェイスを記述するために使用されます。

ビジュアル デザイナーで XAML ファイルを操作することも、マークアップを直接記述・編集することもできます。

## **デフォルト オプションでプレゼンテーションを XAML にエクスポートする**

以下の JavaScript サンプルは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています。

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

デフォルトでは、エクスポートされたスライドはプロセスのカレント ワーキング ディレクトリ内の `input` サブフォルダーに保存されます。フォルダーは自動的に作成され、必要な画像も同じ場所に保存されます。

出力フォルダー名は、拡張子を除いたソース ファイル名から取得されます。Aspose.Slides for Node.js via Java 26.8 では、`input.pptx` をエクスポートすると `input/input/Slide_1.xaml` のような入れ子パスが生成されます。出力を処理する際は、生成された完全なパスを保持してください。デフォルトの出力はカレント ワーキング ディレクトリに対して相対的であり、必ずしも入力ファイルと同じ場所にあるわけではありません。

## **カスタム オプションでプレゼンテーションを XAML にエクスポートする**

[IXamlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloptions/) インターフェイスを使用して、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を制御できます。

出力をカスタム ロケーションに保存するには、[IXamlOutputSaver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloutputsaver/) を実装し、そのインスタンスを [setOutputSaver](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) メソッドに渡します。

非表示スライドを XAML 出力に含めるには、以下の JavaScript サンプルのように `true` を指定して [setExportHiddenSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) を呼び出します。

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

XAML エクスポートは、エクスポートされた各スライドの XAML ドキュメントに加えて、個別の画像やサポート リソースを生成することがあります。デフォルトのファイルシステム セーバーの代わりに、カスタム [IXamlOutputSaver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloutputsaver/) を [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) に割り当てて、これらのアーティファクトを受け取ります。エクスポートは、XAML オプションを受け取る XAML 固有の [Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) オーバーロードで開始します。

Node.js では、Aspose.Slides が使用する `java` パッケージの `java.newProxy` を使って Java インターフェイスを実装します。エクスポートが完了するまでプロキシを保持してください。

### **コールバック ライフサイクルの理解**

エクスポーターは、生成された各アーティファクトに対して次のように [IXamlOutputSaver.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) を個別に呼び出します。

- `path` はアーティファクトを識別し、相対ディレクトリを含むことがあります。XAML が相対パスでリソースを参照する可能性があるため、この情報は保持してください。
- `data` はアーティファクトのバイト列です。画像やその他のバイナリ リソースをテキストとしてデコードしてはいけません。
- セーバーはデータを保持または永続化した後に戻り値を返す責任があります。サンプルでは各 Java バイト配列をアプリケーション所有の Node.js バッファにコピーしています。
- エクスポートは、プレゼンテーションの保存操作が戻り、すべてのコールバックが正常に完了したときにのみ成功と見なします。ストレージ エラーを無視したり、未監視のバックグラウンド書き込みを開始したりしないでください。永続化が後で行われる場合は、そのステップが成功した後に全体の成功を報告してください。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) はカスタム セーバーにも適用されます。デフォルト設定 `false` は非表示スライドの XAML ドキュメントを除外します。`true` を渡すと、非表示スライドとそれらのエクスポートに必要なリソースが含まれます。リソース数はプレゼンテーションに依存するため、スライドごとに 1 コールバックがあるとか、固定順序があるとか想定しないでください。

### **メモリ上にエクスポートしアーティファクトを検査する**

この完全なサンプルは `input.pptx` を読み込み、名前とバッファのマップにすべてのアーティファクトを収集し、名前・タイプ・バイト数を出力します。提供された名前はそのまま保持します。重複した名前がある場合は、アーティファクトを上書きせずにコレクションを無効とします。結果を使用する前にこのチェックを行います。

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

        // XAML のみをデコードし、テキスト検査が必要なときだけ実行します。
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

拡張子チェックは検査に有用です。未知のリソースタイプも含めてすべてのアーティファクトを保持してください。バイト列は保存・転送時に変更しないでください。テキスト処理が必要な XAML のみ UTF-8 デコードを使用します。

### **収集したアーティファクトを ZIP アーカイブにパッケージ化する**

この独立したサンプルはエクスポートを収集し、名前を検証した上で Java ブリッジを使って ZIP アーカイブに書き込みます。ZIP はメモリ上で組み立てられ、ディスクに保存されます。ユニークなアーカイブ名で同時エクスポート ジョブを分離します。ZIP エントリはスラッシュ (/) を使用し、相対ディレクトリを保持します。正規化後に衝突する危険な名前や不正な名前は、書き込み前にパッケージ全体を拒否します。

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
    const options = new aspose.slides.Xtra

Options();
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
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // ZIP ディレクトリを確定し、アーカイブが永続化される前に閉じます。
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

サンプルは [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) を使用してローカル アーカイブを書き込みます。エクスポーター自体は個別の XAML や画像ファイルを書き出しません。リモート ストレージの場合は、アーカイブ書き込み段階を収集したバイト配列のアップロードに置き換えてください。エクスポート ジョブ ID と相対アーティファクト名をブロブ キーに使用するか、ジョブ ID、相対名、バイナリ データをデータベース行に保存します。すべてのアップロードが完了し、データベース トランザクションがコミットされた後にジョブを公開し、永続化に失敗した場合は部分出力をクリーンアップします。

大規模なプレゼンテーションでは、カスタム セーバーが各アーティファクトを直接アプリケーション ストレージに永続化し、全エクスポートの追加コピーをメモリに保持しないようにできます。エクスポーターの観点から各コールバックは同期的に扱い、宛先がバイトを受け取った後にのみ戻り、失敗は呼び出し元に伝播させます。

### **リソース名を保持し参照を検証する**

- 宛先が要求する場合はパス区切り文字を正規化しますが、相対ディレクトリは保持してください。すべての生成名が一意でありリソース参照が有効であると確信できない限り、ベース名だけを使用しないでください。
- 宛先固有の名前検証を適用します。ファイルを書き出す場合は、ルート パスやディレクトリ トラバーサル セグメントを拒否し、宛先を絶対パスに解決して、エクスポート ディレクトリ以下に収まっていることを確認します。シンボリック リンクのないアプリケーション管理ディレクトリを使用してください。
- エクスポート ジョブごとに別々のセーバーとストレージ 名前空間を使用します。セパレータ正規化後および宛先の大文字小文字規則に従って衝突を検出します。
- 公開前に各 XAML ドキュメントを XML としてパースし、`Source` や `ImageSource` 属性などのファイルベースのリソース参照を調べます。各相対 URI をその XAML アーティファクトのディレクトリに対して解決し、正規化したストレージ名とマップ キー、ZIP エントリ、または保存オブジェクトが存在することを確認します。外部 URI と XAML マークアップ式は、相対ファイル名とは別に扱ってください。

例えば、`input/Slide_1.xaml` が `images/image1.png` を参照している場合、保存されたリソースは `input/images/image1.png` として利用可能でなければなりません。`image1.png` だけを保存すると関係が壊れます。オブジェクト ストレージの場合は、ジョブ プレフィックス配下に同じレイアウトを保持し、これらのリソース URL を XAML コンシューマが取得できるようにします。完成した ZIP を再度開き、エントリ名とリソース バイトを確認し、対象 XAML 環境で代表的なスライドをロードして画像が正しく解決することを検証してください。

## **FAQ**

**元のフォントがマシンに存在しない場合、フォントを予測可能にするにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/xamloptions/) の [setDefaultRegularFont](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) を呼び出します。これは、元のフォントが見つからない場合にエクスポート時のフォールバック フォントとして使用されます。ただし、生成された XAML がフォールバック フォントを参照することや、ターゲット マシンにそのフォントが存在することを保証するものではありません。XAML が表示される環境に、参照されるフォントが確実にインストールされていることを確認してください。

**エクスポートされた XAML は WPF 専用ですか、それとも他の XAML スタックでも使用できますか？**

Aspose.Slides はパブリック API を介して WPF 用 XAML をエクスポートします。UWP や Xamarin.Forms など他の XAML スタックとの互換性は保証されていません。生成されたマークアップは、対象環境でテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにする方法は？**

デフォルトでは非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) でこの動作を制御できます。エクスポートが不要な場合は無効のままにしてください。