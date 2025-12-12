---
title: AndroidでPowerPointプレゼンテーションをMarkdownに変換
linktitle: PowerPointからMarkdownへ
type: docs
weight: 140
url: /ja/androidjava/convert-powerpoint-to-markdown/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからMDへ
- プレゼンテーションからMDへ
- スライドからMDへ
- PPTからMDへ
- PPTXからMDへ
- PowerPointをMarkdownとして保存
- プレゼンテーションをMarkdownとして保存
- スライドをMarkdownとして保存
- PPTをMDとして保存
- PPTXをMDとして保存
- PPTをMDにエクスポート
- PPTXをMDにエクスポート
- PowerPoint
- プレゼンテーション
- Markdown
- Android
- Java
- Aspose.Slides
description: "Javaを使用してAndroid向けAspose.SlidesでPowerPointスライド（PPT、PPTX）をクリーンなMarkdownに変換し、ドキュメントを自動化し、書式を保持します。"
---

{{% alert color="info" %}}

PowerPointからmarkdownへの変換サポートは[Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/)で実装されました。

{{% /alert %}}

{{% alert color="warning" %}}

PowerPointからmarkdownへのエクスポートはデフォルトで**画像なし**です。画像を含むPowerPointドキュメントをエクスポートしたい場合は、`markdownSaveOptions.setExportType(MarkdownExportType.Visual)` を設定し、markdownドキュメントで参照される画像の保存先となる`BasePath`も設定する必要があります。

{{% /alert %}}

## **PowerPoint を Markdown に変換**

1. プレゼンテーションオブジェクトを表すために、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. オブジェクトを markdown ファイルとして保存するために、[Save ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)メソッドを使用します。

この Java コードは PowerPoint を markdown に変換する方法を示しています：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint を Markdown フレーバーに変換**

Aspose.Slides を使用すると、PowerPoint を markdown（基本構文を含む）、CommonMark、GitHub フレーバーの markdown、Trello、XWiki、GitLab、その他 17 種類の markdown フレーバーに変換できます。

この Java コードは PowerPoint を CommonMark に変換する方法を示しています：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


サポートされている 23 の markdown フレーバーは、[listed under the Flavor enumeration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) と、[MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) クラスから確認できます。

## **画像を含むプレゼンテーションを Markdown に変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) クラスは、生成された markdown ファイルに対して特定のオプションや設定を使用できるプロパティと列挙体を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) 列挙体は、画像のレンダリングや扱い方を決定する `Sequential`、`TextOnly`、`Visual` のいずれかの値に設定できます。

### **画像を順次変換**

結果の markdown で画像が個別に順番に表示されるようにしたい場合は、sequential オプションを選択する必要があります。この Java コードは、画像を含むプレゼンテーションを markdown に変換する方法を示しています：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


### **画像を視覚的に変換**

結果の markdownで画像がまとめて表示されるようにしたい場合は、visual オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（markdown ドキュメント内で相対パスが作成されます）、あるいは任意のパスとフォルダー名を指定することもできます。

この Java コードは操作を示しています：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**ハイパーリンクは Markdown へのエクスポート後も残りますか？**

はい。テキストの[hyperlinks](/slides/ja/androidjava/manage-hyperlinks/)は標準的な Markdown リンクとして保持されます。スライドの[transitions](/slides/ja/androidjava/slide-transition/)と[animations](/slides/ja/androidjava/powerpoint-animation/)は変換されません。

**複数スレッドで実行して変換を高速化できますか？**

ファイルごとに並列化は可能ですが、同じ[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)インスタンスをスレッド間で[don’t share](/slides/ja/androidjava/multithreading/)ようにしてください。ファイルごとに別々のインスタンスまたはプロセスを使用して競合を回避します。

**画像はどうなりますか—保存場所はどこで、パスは相対ですか？**

[Images](/slides/ja/androidjava/image/)は専用のフォルダーにエクスポートされます。ベース出力パスとアセットフォルダー名を構成することで、予測可能なリポジトリ構造を維持できます。