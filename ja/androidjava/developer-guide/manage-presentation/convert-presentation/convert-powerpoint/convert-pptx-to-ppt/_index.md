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
description: "Aspose.Slides for Android を Java で使用して、PPTX を PPT に簡単に変換し、PowerPoint 形式とのシームレスな互換性を保ちつつ、プレゼンテーションのレイアウトと品質を維持します。"
---

## **概要**

この記事では、Java を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックが対象です。

- Java で PPTX を PPT に変換

## **Android で PPTX を PPT に変換**

PPTX を PPT に変換する Java のサンプルコードについては、以下のセクション、すなわち[Convert PPTX to PPT](#convert-pptx-to-ppt)をご参照ください。サンプルは PPTX ファイルを読み込み、PPT 形式で保存します。保存形式を変更すれば、PDF、XPS、ODP、HTML など他の多数の形式にも変換できることは、これらの記事で説明されています。

- [Convert PPTX to PDF on Android](/slides/ja/androidjava/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS on Android](/slides/ja/androidjava/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML on Android](/slides/ja/androidjava/convert-powerpoint-to-html/)
- [Convert PPTX to ODP on Android](/slides/ja/androidjava/save-presentation/)
- [Convert PPTX to PNG on Android](/slides/ja/androidjava/convert-powerpoint-to-png/)

## **PPTX を PPT に変換**
PPTX を PPT に変換するには、ファイル名と保存形式を **Save** メソッドに渡すだけです。このメソッドは [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスにあります。以下の Java コードサンプルは、デフォルトオプションで PPTX から PPT へプレゼンテーションを変換します。
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation presentation = new Presentation("template.pptx");

// プレゼンテーションを PPT として保存します
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**PPT (97‑2003) 形式に保存した場合、PPTX のすべての効果や機能は保持されますか？**

必ずしも保持されません。PPT 形式は新しい機能（特定の効果、オブジェクト、動作など）をサポートしていないため、変換時に機能が簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存するとプレゼンテーション全体が対象になります。特定のスライドだけを変換したい場合は、対象スライドだけで新しいプレゼンテーションを作成し、それを PPT として保存してください。もしくは、スライド単位の変換パラメータをサポートするサービス/APIを利用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードで開くことができます。また、保存した PPT のために[configure protection/encryption settings](/slides/ja/androidjava/password-protected-presentation/) を設定することも可能です。