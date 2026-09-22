---
title: Androidで元のプレゼンテーション形式を判断する
linktitle: ソース形式
type: docs
weight: 35
url: /ja/androidjava/detect-presentation-source-format/
keywords:
- ソース形式
- プレゼンテーション形式の検出
- PowerPoint
- OpenDocument
- プレゼンテーション
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用し、Android 上でロードされたプレゼンテーションの元の形式を読み取り、検出 API を比較し、ファイル、ストリーム、およびレガシーフォーマットを処理します。"
---
## **概要**

プレゼンテーションをロードした後、元の形式を判定するために [Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSourceFormat--) メソッドを呼び出します。このメソッドは [IPresentation.getSourceFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) でも利用できます。現在のインスタンスがロードされた形式に依存した後続の処理が必要な場合に使用します。

ソース形式は、出力ファイルに選択された [SaveFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) とは別物です。別の形式で保存しても、既存のインスタンスのソース形式は変更されません。

例では Java とファイルパスを使用しています。Android では、サンプルパスをアプリがアクセスできるストレージ（例: アプリの内部ファイルディレクトリ）内のパスに置き換えてください。

## **ファイルのソース形式を読み取る**

この例は既存の `sample.pptx` ファイルを必要とします。ファイル名ではなく [Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSourceFormat--) を使用してアプリケーションの処理ポリシーを選択します。入力パスを変更すれば他の形式を試すことができます。例では選択されたポリシーを出力していますので、メッセージは自身のアプリケーションロジックに置き換えてください。

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

## **サポートされている値を認識する**

[SourceFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sourceformat/) クラスは、以下のプレゼンテーション形式を区別する整数定数を定義しています。以下の拡張子は慣例的な拡張子であり、元のファイル名を復元したものではありません。

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
| `Fodp` | `.fodp` | フラット XML ODF プレゼンテーション |
| `Xml` | `.xml` | PowerPoint XML プレゼンテーション |

## **ストリームのソース形式を読み取る**

この例は既存の `sample.pps` ファイルを必要とします。そのバイト列をメモリストリームに読み込むことで、データベースの値やアップロードされたバイト配列など、ファイル名なしで受け取った入力をシミュレートします。[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) コンストラクタはストリームのみを受け取ります。

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

PPT、PPS、POT は同じ基礎バイナリ形式を使用します。ファイルパスでロードする場合、拡張子によりスライドショーやテンプレートを区別できます。ファイル名がない場合、レガシーな PPS や POT のコンテンツは `SourceFormat.Ppt` として報告されることがあります；上記の PPS の例では `SourceFormat.Ppt` の整数値が出力されています。

アプリケーションでこの区別を保持する必要がある場合は、元のファイル名またはサブタイプメタデータを別途保持してください。拡張子はこれらレガシーサブタイプの有用な手がかりですが、任意のプレゼンテーションコンテンツを識別する唯一の根拠にすべきではありません。

## **ロード前後の検出を比較する**

ファイルの完全なプレゼンテーションオブジェクトモデルをロードする前に内容を検査する必要がある場合は、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) と [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) を使用します。インスタンスが既に存在する場合は、[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSourceFormat--) を使用してください。

この例は `sample.pptx` を必要とし、`LoadFormat.Pptx` と `SourceFormat.Pptx` の整数値をそれぞれ出力します。実運用では処理段階に適した API を選択してください。既にロードされたプレゼンテーションについては、ソース形式を取得するためだけに再度検査する必要はありません。

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

結果は異なるクラスの定数、[LoadFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadformat/) と [SourceFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sourceformat/) を使用しています。数値を比較したり、すべての形式が同一の検出結果を持つと仮定したりしないでください。PowerPoint XML はロード前に `LoadFormat.Unknown` と報告され、ロード後は `SourceFormat.Xml` と報告されることがあります。

## **ソース形式と出力形式を分離する**

この例は `sample.pptx` を必要とし、`converted.odp` に書き出します。元のインスタンスを保存する前後で `SourceFormat.Pptx` の整数値を出力します。ODP 出力からロードされた新しいインスタンスだけが `Odp` を報告します。

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

`new Presentation()` で新規作成したプレゼンテーションは `SourceFormat.Pptx` と報告します。入力ファイルがないため、これは新規インスタンスのデフォルト値であり、PPTX ファイルがロードされたことを示すものではありません。区別が重要な場合は、アプリケーションがインスタンスを作成したのかロードしたのかを別途追跡してください。

## **ソース形式を拡張子にマッピングする**

以下の例は `sample.pptx` が必要です。現在サポートされているすべての [SourceFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sourceformat/) の値を、入力ファイル名を解析せずに慣例的な拡張子へマッピングします。フォールバックにより、認識できない値に対して拡張子が黙って割り当てられることを防ぎます。

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

このマッピングはファイルを変換したり、ストリームロード中に失われたレガシー PPS/POT サブタイプを復元したりするものではありません。実際に保存する場合は、[SaveFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) を明示的に選択するか、[元の形式でプレゼンテーションを保存](/slides/ja/androidjava/save-presentation/#save-presentations-in-their-original-format) に示された変換を使用してください。

## **保存と再オープンで形式を検証する**

この単体例はプレゼンテーションを作成し、作業ディレクトリに 3 つのファイルを書き込みます（同名のファイルは上書きされます）。各出力をパス経由とメモリストリームの両方で再度開きます。PPTX と ODP では両経路とも保存された形式を報告します。PPS の場合、パスでロードすると `Pps` を報告しますが、ファイル名なしで同じバイト列をロードすると `Ppt` を報告します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

以下の表は、拡張子が一致するプレゼンテーションに対するソース形式の識別結果をまとめたものです。名前は定数を示し、Java の例ではその整数値が出力されます。

| 保存形式 | ファイルパスからの SourceFormat | ファイル名なしストリームからの SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` それぞれ | ファイルパスと同じ |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` それぞれ | ファイルパスと同じ |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` それぞれ | ファイルパスと同じ |
| ODP, OTP | `Odp`, `Otp` それぞれ | ファイルパスと同じ |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

ファイル名なしストリームの場合、PPS/POT のコンテンツは `Ppt` と識別されます。この表は形式の識別結果を示すものであり、変換時にすべてのプレゼンテーション機能が保持されることを保証するものではありません。

## **よくある質問**

**PPTX からロードしたプレゼンテーションを ODP に保存すると、ソース形式は変わりますか？**

いいえ。既存のインスタンスは依然として `Pptx` を報告します。保存された ODP ファイルからロードしたインスタンスは `Odp` を報告します。

**ストリームだけでレガシーなプレゼンテーション、スライドショー、テンプレートを常に区別できますか？**

いいえ。PPT、PPS、POT は同じバイナリ形式を共有します。区別が必要な場合は、ファイル名またはサブタイプのメタデータを別途保持してください。

**プレゼンテーションが既にロードされている場合、どの API を使用すべきですか？**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSourceFormat--) を読み取ります。ロード前に検査する場合は [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用してください。