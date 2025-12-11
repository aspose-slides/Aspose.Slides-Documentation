---
title: Android で PPTX を PPT に変換
linktitle: PPTX から PPT
type: docs
weight: 21
url: /ja/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides で PPTX を PPT に簡単に変換し、PowerPoint 形式とのシームレスな互換性を確保しながら、プレゼンテーションのレイアウトと品質を保持します。"
---

## **概要**

この記事では、Java を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックを扱います。

- Java で PPTX を PPT に変換

## **Android で PPTX を PPT に変換**

Java で PPTX を PPT に変換するサンプルコードについては、以下のセクション「[Convert PPTX to PPT](#convert-pptx-to-ppt)」をご参照ください。これは PPTX ファイルを読み込み、PPT 形式で保存するだけの処理です。保存形式を変更すれば、PDF、XPS、ODP、HTML など、さまざまな形式に変換することもできます（これらは別記事で解説しています）。

- [Java Convert PPTX to PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Convert PPTX to XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Convert PPTX to HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Convert PPTX to ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Convert PPTX to Image](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**
PPTX を PPT に変換するには、[**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスの **Save** メソッドにファイル名と保存形式を渡すだけです。以下の Java コードサンプルは、既定のオプションで PPTX から PPT へプレゼンテーションを変換します。
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation presentation = new Presentation("template.pptx");

// プレゼンテーションを PPT として保存します
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**すべての PPTX のエフェクトや機能は、レガシー PPT（97–2003）形式で保存してもそのまま残りますか？**

必ずしも残りません。PPT 形式には新しい機能の一部（特定のエフェクト、オブジェクト、動作など）が欠けているため、変換時に機能が簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存はプレゼンテーション全体を対象とします。特定のスライドだけを変換したい場合は、対象スライドだけで新しいプレゼンテーションを作成し、PPT として保存してください。あるいは、スライド単位の変換パラメータをサポートするサービス/API を使用します。

**パスワード保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかどうかを検出し、パスワードを使用して開くことができます。また、保存する PPT の [保護/暗号化設定](/slides/ja/androidjava/password-protected-presentation/) を構成することも可能です。