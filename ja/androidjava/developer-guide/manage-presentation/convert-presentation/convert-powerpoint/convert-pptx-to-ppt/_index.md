---
title: AndroidでPPTXをPPTに変換
linktitle: PPTXからPPTへ
type: docs
weight: 21
url: /ja/androidjava/convert-pptx-to-ppt/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPTX を変換
- PPTX から PPT へ
- PPTX を PPT として保存
- PPTX を PPT にエクスポート
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides で PPTX を PPT に簡単に変換し、PowerPoint 形式とのシームレスな互換性を保ちつつ、プレゼンテーションのレイアウトと品質を維持します。"
---

## **概要**

この記事では、Java を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法について説明します。以下のトピックが取り上げられています。

- Java で PPTX を PPT に変換する

## **Android で PPTX を PPT に変換する**

PPTX を PPT に変換する Java のサンプルコードについては、以下のセクション、つまり [Convert PPTX to PPT](#convert-pptx-to-ppt) を参照してください。このサンプルは PPTX ファイルを読み込み、PPT 形式で保存します。保存形式を変更することで、PDF、XPS、ODP、HTML などのさまざまな形式に PPTX ファイルを保存することもできます（これらの記事で説明されています）。

- [Java PPTX を PDF に変換](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java PPTX を XPS に変換](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java PPTX を HTML に変換](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java PPTX を ODP に変換](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java PPTX を画像に変換](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **PPTX を PPT に変換**

PPTX を PPT に変換するには、ファイル名と保存形式を **Save** メソッドに渡すだけです。[**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスを使用します。以下の Java コードサンプルは、デフォルトオプションで PPTX から PPT にプレゼンテーションを変換します。
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化
Presentation presentation = new Presentation("template.pptx");

// プレゼンテーションを PPT として保存
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**PPTX のすべてのエフェクトや機能は、レガシーな PPT (97–2003) 形式で保存するときに保持されますか？**

必ずしもそうではありません。PPT 形式は一部の新しい機能（例：特定のエフェクト、オブジェクト、動作）をサポートしていないため、変換時に機能が簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存するとプレゼンテーション全体が対象になります。特定のスライドだけを変換するには、対象スライドだけの新しいプレゼンテーションを作成して PPT として保存します。または、スライド単位の変換パラメータをサポートするサービス/APIを使用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードで開くことができます。また、保存した PPT の [protection/encryption 設定を構成](/slides/ja/androidjava/password-protected-presentation/) することも可能です。