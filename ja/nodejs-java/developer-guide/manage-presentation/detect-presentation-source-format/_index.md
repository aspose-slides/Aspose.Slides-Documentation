---
title: Node.js で元のプレゼンテーション形式を判定する
linktitle: ソース形式
type: docs
weight: 35
url: /ja/nodejs-java/detect-presentation-source-format/
keywords:
- ソース形式
- プレゼンテーション形式の検出
- PowerPoint
- OpenDocument
- プレゼンテーション
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して Node.js で読み込まれたプレゼンテーションの元の形式を取得し、検出 API を比較し、ファイル、ストリーム、レガシーフォーマットを処理します。"
---
## **概要**

プレゼンテーションを読み込んだ後、[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSourceFormat) メソッドを呼び出して元の形式を判定します。現在のインスタンスが読み込まれた形式に依存する後続の処理がある場合に使用します。

ソース形式は、出力ファイル用に選択された[SaveFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/)とは別物です。別の形式で保存しても、既存インスタンスのソース形式は変わりません。

## **ファイルのソース形式を読み取る**

この例では既存の `sample.pptx` ファイルが必要です。ファイル名ではなく[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSourceFormat) を使用してアプリケーションの処理ポリシーを選択します。入力パスを変更すれば他の形式を試せます。例は選択されたポリシーを出力しますので、メッセージはご自身のアプリケーション ロジックに置き換えてください。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **サポートされている値を認識する**

[SourceFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sourceformat/) クラスは、以下のプレゼンテーション形式を区別する整数定数を定義しています。以下の拡張子は慣例的なもので、元のファイル名を再現したものではありません。

| SourceFormat 値 | 拡張子 | 形式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 プレゼンテーション |
| `Pptx` | `.pptx` | Office Open XML プレゼンテーション |
| `Pptm` | `.pptm` | マクロ対応 Office Open XML プレゼンテーション |
| `Pps` | `.pps` | PowerPoint 97–2003 スライドショー |
| `Ppsx` | `.ppsx` | Office Open XML スライドショー |
| `Ppsm` | `.ppsm` | マクロ対応 Office Open XML スライドショー |
| `Pot` | `.pot` | PowerPoint 97–2003 テンプレート |
| `Potx` | `.potx` | Office Open XML テンプレート |
| `Potm` | `.potm` | マクロ対応 Office Open XML テンプレート |
| `Odp` | `.odp` | OpenDocument プレゼンテーション |
| `Otp` | `.otp` | OpenDocument プレゼンテーションテンプレート |
| `Fodp` | `.fodp` | Flat XML ODF プレゼンテーション |
| `Xml` | `.xml` | PowerPoint XML プレゼンテーション |

## **ストリームのソース形式を読み取る**

この例では既存の `sample.pps` ファイルが必要です。バイトをメモリストリームに読み込むことで、データベースの値やアップロードされたバイト配列など、ファイル名なしで受け取った入力をシミュレートします。[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) コンストラクタはストリームだけを受け取ります。

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT、PPS、POT は同じ基礎バイナリ形式を使用します。ファイルパスで読み込む場合、拡張子でスライドショーやテンプレートを区別できます。ファイル名がない場合、レガシーな PPS や POT のコンテンツは `SourceFormat.Ppt` と報告されることがあります。上記の PPS の例では `SourceFormat.Ppt` の整数値を出力しています。

アプリケーションでこの区別を保持する必要がある場合は、元のファイル名やサブタイプメタデータを別途保存してください。拡張子はこれらレガシーサブタイプの有用なヒントですが、任意のプレゼンテーションコンテンツを識別する唯一の根拠にすべきではありません。

## **読み込み前後の検出を比較する**

ファイルを完全なプレゼンテーションオブジェクトモデルとして読み込む前に検査する必要がある場合は、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) と [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) を使用します。インスタンスが既に存在する場合は、[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSourceFormat) を使用します。

この例では `sample.pptx` が必要で、`LoadFormat.Pptx` と `SourceFormat.Pptx` の整数値をそれぞれ出力します。本番環境では処理段階に適した API を選択してください。既に読み込まれたプレゼンテーションは、ソース形式を取得するだけのために二度目の検査を行う必要はありません。

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

結果は異なるクラスの定数、[LoadFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadformat/) と [SourceFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sourceformat/) を使用しています。その数値を比較したり、すべての形式が同一の検出結果になると想定したりしないでください。PowerPoint XML は、読み込み前は `LoadFormat.Unknown`、読み込み後は `SourceFormat.Xml` と報告されることがあります。

## **ソース形式と出力形式を分離する**

この例では `sample.pptx` が必要で、`converted.odp` に書き出します。元のインスタンスを保存する前後で `SourceFormat.Pptx` の整数値を出力します。ODP 出力から読み込んだ新しいインスタンスだけが `Odp` と報告します。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

`new Presentation()` でゼロから作成したプレゼンテーションは `SourceFormat.Pptx` を報告します。入力ファイルがないため、これは新しく作成されたインスタンスのデフォルト値であり、PPTX ファイルが読み込まれた証拠ではありません。区別が重要な場合は、アプリケーション側でインスタンスが作成されたか読み込まれたかを別途追跡してください。

## **ソース形式を拡張子にマッピングする**

以下の例では `sample.pptx` が必要です。[SourceFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sourceformat/) の現在サポートされているすべての値を、入力ファイル名を解析せずに慣例的な拡張子へマッピングします。フォールバックにより、認識できない値に対して黙って拡張子を割り当てることを防ぎます。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

このマッピングはファイルを変換したり、ストリーム読み込み時に失われたレガシー PPS/POT サブタイプを復元したりはしません。実際に保存する場合は、[SaveFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/) を明示的に選択するか、[Save Presentations in Their Original Format](/slides/ja/nodejs-java/save-presentation/#save-presentations-in-their-original-format) に示された変換を使用してください。

## **保存と再オープンで形式を検証する**

この自己完結型の例ではプレゼンテーションを作成し、作業ディレクトリに 3 つのファイルを書き出します（同名のファイルは上書き）。各出力をパスからとメモリストリームの両方で再度開きます。PPTX と ODP では、どちらの方法でも保存された形式が報告されます。PPS の場合、パスからの読み込みは `Pps` を、ファイル名なしで同じバイト列を読み込むと `Ppt` を報告します。

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

以下の表は、拡張子が一致するプレゼンテーションのソース形式識別をまとめたものです。名前は定数を示し、JavaScript の例ではその整数値が出力されます。

| 保存形式 | ファイルパスからの SourceFormat | 名前なしストリームからの SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | ファイルパスと同じ |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | ファイルパスと同じ |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | ファイルパスと同じ |
| ODP, OTP | `Odp`, `Otp` respectively | ファイルパスと同じ |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

名前なしストリームでは PPS/POT のコンテンツは `Ppt` と識別されます。この表は形式の識別を示すものであり、変換時にすべてのプレゼンテーション機能が保持されることを保証するものではありません。

## **FAQ**

**Does saving to ODP change the source format of a presentation loaded from PPTX?**  
いいえ。既存のインスタンスは依然として `Pptx` を報告します。保存された ODP ファイルから読み込んだインスタンスは `Odp` と報告します。

**Can a stream always distinguish a legacy presentation, slide show, and template?**  
いいえ。PPT、PPS、POT は同じバイナリ形式を共有します。区別が必要な場合は、ファイル名またはサブタイプメタデータを別途保持してください。

**Which API should I use if the presentation is already loaded?**  
[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSourceFormat) を使用してください。読み込み前の検査が必要な場合は、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用します。