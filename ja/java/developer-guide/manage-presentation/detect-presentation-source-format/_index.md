---
title: Java で元のプレゼンテーション形式を判定する
linktitle: ソース形式
type: docs
weight: 35
url: /ja/java/detect-presentation-source-format/
keywords:
- ソース形式
- プレゼンテーション形式の検出
- PowerPoint
- OpenDocument
- プレゼンテーション
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して Java で読み込んだプレゼンテーションの元の形式を取得し、検出 API を比較し、ファイル、ストリーム、レガシーフォーマットを処理します。"
---
## **概要**

プレゼンテーションを読み込んだ後、[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSourceFormat--) メソッドを呼び出して、元の形式を判定します。このメソッドは [IPresentation.getSourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getSourceFormat--) でも利用できます。現在のインスタンスがロードされた形式に依存した後続の処理が必要な場合に使用します。

ソース形式は、出力ファイルに対して選択する [SaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) とは別物です。別の形式で保存しても、既存インスタンスのソース形式は変わりません。

## **ファイルのソース形式を読み取る**

この例では既存の `sample.pptx` ファイルが必要です。ファイルをロードし、ファイル名ではなく [Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSourceFormat--) を使用してアプリケーションの処理ポリシーを選択します。入力パスを変更すれば他の形式も試せます。例は選択されたポリシーを出力します。メッセージはご自身のロジックに置き換えてください。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **サポートされている値を確認する**

[SourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sourceformat/) クラスは、以下のプレゼンテーション形式を区別する整数定数を定義しています。下記の拡張子は慣例的なもので、元のファイル名を再構築したものではありません。

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

この例では既存の `sample.pps` ファイルが必要です。バイト列をメモリストリームに読み込むことで、データベースの値やアップロードされたバイト配列など、ファイル名なしで受け取る入力をシミュレートします。[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) コンストラクタはストリームのみを受け取ります。

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT、PPS、POT は同じ基礎バイナリ形式を使用します。ファイルパスでロードする場合、拡張子でスライドショーやテンプレートを区別できることがあります。ファイル名がない場合、レガシーな PPS や POT の内容は `SourceFormat.Ppt` と報告されることがあります。上記の PPS の例は `SourceFormat.Ppt` の整数値を出力します。

アプリケーションでこの区別を保持する必要がある場合は、元のファイル名またはサブタイプメタデータを別途保持してください。拡張子はレガシーサブタイプの有用なヒントになりますが、任意のプレゼンテーションコンテンツを識別する唯一の根拠にすべきではありません。

## **ロード前後の検出結果を比較する**

ファイル全体をロードせずに事前に検査したい場合は、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) と [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) を使用します。インスタンスが既に存在する場合は、[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSourceFormat--) を使用します。

この例では `sample.pptx` が必要で、`LoadFormat.Pptx` と `SourceFormat.Pptx` の整数値をそれぞれ出力します。実運用では処理段階に合わせた API を選択してください。既にロード済みのプレゼンテーションでは、ソース形式取得のために再度検査する必要はありません。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

結果に使用されている定数は別クラスから取得しています: [LoadFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadformat/) と [SourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sourceformat/)。それらの数値を比較したり、すべての形式で同一の検出結果が得られると想定しないでください。PowerPoint XML は、ロード前は `LoadFormat.Unknown` と報告され、ロード後は `SourceFormat.Xml` になることがあります。

## **ソース形式と出力形式を分離して扱う**

この例では `sample.pptx` を読み込み、`converted.odp` に書き出します。元のインスタンスの `SourceFormat.Pptx` の整数値を保存前後の両方で出力します。ODP 出力からロードした新しいインスタンスは `Odp` と報告します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

`new Presentation()` でゼロから作成したプレゼンテーションは `SourceFormat.Pptx` を報告します。入力ファイルがないため、これは新規インスタンスのデフォルト値であり、PPTX ファイルがロードされたことを示すものではありません。作成かロードかの区別が重要な場合は、別途追跡してください。

## **ソース形式を拡張子にマッピングする**

以下の例は `sample.pptx` が必要です。現在サポートされているすべての [SourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sourceformat/) の値を、入力ファイル名を解析せずに慣例的な拡張子へマッピングします。認識できない値に対しては、拡張子を黙って割り当てないようフォールバックしています。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

このマッピングはファイルを変換したり、ストリームロード時に失われたレガシー PPS/POT サブタイプを復元したりはしません。実際に保存する場合は、[SaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) を明示的に指定するか、[Save Presentations in Their Original Format](/slides/ja/java/save-presentation/#save-presentations-in-their-original-format) に示す変換を使用してください。

## **保存と再オープンで形式を検証する**

この自己完結型の例はプレゼンテーションを作成し、作業ディレクトリに 3 つのファイルを書き込みます（同名ファイルがある場合は上書き）。各出力をパス経由とメモリストリームの両方で再オープンします。PPTX と ODP は両経路で保存形式を報告しますが、PPS はパス経由でロードすると `Pps`、ファイル名なしで同じバイト列をロードすると `Ppt` と報告します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

以下の表は、拡張子が一致するプレゼンテーションのソース形式識別をまとめたものです。名前は定数を示し、Java の例では整数値が出力されます。

| 保存形式 | ファイルパスからの SourceFormat | ファイル名なしストリームからの SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm`（それぞれ） | ファイルパスと同じ |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm`（それぞれ） | ファイルパスと同じ |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm`（それぞれ） | ファイルパスと同じ |
| ODP, OTP | `Odp`, `Otp`（それぞれ） | ファイルパスと同じ |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT コンテンツはファイル名なしストリームでは `Ppt` と識別されます。この表は形式の識別を示すものであり、変換時にすべてのプレゼンテーション機能が保持されることを保証するものではありません。

## **FAQ**

**ODP に保存すると、PPTX からロードしたプレゼンテーションのソース形式は変わりますか？**

いいえ。既存のインスタンスは依然として `Pptx` を報告します。保存した ODP ファイルからロードしたインスタンスは `Odp` を報告します。

**ストリームだけでレガシーなプレゼンテーション、スライドショー、テンプレートを区別できますか？**

できません。PPT、PPS、POT は同じバイナリ形式を共有します。区別が必要な場合は、ファイル名またはサブタイプメタデータを別途保持してください。

**プレゼンテーションが既にロード済みの場合、どの API を使用すべきですか？**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSourceFormat--) を使用してください。ロード前の検査が必要な場合は、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用します。