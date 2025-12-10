---
title: Java で PPTX を PPT に変換
linktitle: PPTX から PPT
type: docs
weight: 21
url: /ja/java/convert-pptx-to-ppt/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPTX を変換
- PPTX から PPT
- PPTX を PPT として保存
- PPTX を PPT にエクスポート
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PPTX を PPT に簡単に変換できます。PowerPoint 形式とのシームレスな互換性を確保し、プレゼンテーションのレイアウトと品質を保持します。"
---

## **概要**

このドキュメントでは、Java を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックを取り上げます。

- Java で PPTX を PPT に変換

## **Java で PPTX を PPT に変換**

PPTX を PPT に変換する Java のサンプルコードについては、以下のセクション、すなわち[Convert PPTX to PPT](#convert-pptx-to-ppt)をご覧ください。このコードは PPTX ファイルを読み込み、PPT 形式で保存します。異なる保存形式を指定することで、PDF、XPS、ODP、HTML などの他の多数の形式でも PPTX ファイルを保存できます。これらの記事で説明されています。

- [Java PPTX を PDF に変換](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java PPTX を XPS に変換](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java PPTX を HTML に変換](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java PPTX を ODP に変換](https://docs.aspose.com/slides/java/save-presentation/)
- [Java PPTX を画像に変換](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **PPTX を PPT に変換**

PPTX を PPT に変換するには、ファイル名と保存形式を **Save** メソッド（[**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラス）に渡すだけです。以下の Java コードサンプルは、デフォルトオプションを使用して PPTX から PPT にプレゼンテーションを変換します。
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation presentation = new Presentation("template.pptx");

// プレゼンテーションを PPT として保存します
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**PPTX のすべてのエフェクトや機能は、レガシー PPT (97–2003) 形式に保存する際に保持されますか？**

必ずしもそうではありません。PPT 形式には newer な機能の一部（例: 特定のエフェクト、オブジェクト、動作）が欠けているため、変換時に機能が簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存するとプレゼンテーション全体が対象になります。特定のスライドだけを変換するには、そのスライドだけを含む新しいプレゼンテーションを作成して PPT として保存します。あるいは、スライド単位の変換パラメータをサポートするサービスや API を使用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードで開くことができます。また、保存する PPT の[保護/暗号化設定を構成](/slides/ja/java/password-protected-presentation/)することも可能です。