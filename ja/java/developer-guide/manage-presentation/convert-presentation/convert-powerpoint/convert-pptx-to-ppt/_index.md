---
title: JavaでPPTXをPPTに変換
linktitle: PPTXからPPTへ
type: docs
weight: 21
url: /ja/java/convert-pptx-to-ppt/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTXを変換
- PPTXからPPTへ
- PPTXをPPTとして保存
- PPTXをPPTにエクスポート
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PPTX を PPT に簡単に変換し、PowerPoint 形式とのシームレスな互換性を確保しながら、プレゼンテーションのレイアウトと品質を保持します。"
---

## **Overview**

この記事では、Java を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックが扱われます。

- Java で PPTX を PPT に変換

## **Convert PPTX to PPT in Java**

Java 用の PPTX から PPT への変換サンプルコードについては、以下のセクション [Convert PPTX to PPT](#convert-pptx-to-ppt) をご参照ください。サンプルは PPTX ファイルを読み込み、PPT 形式で保存するだけです。保存形式を変更すれば、PDF、XPS、ODP、HTML などの他の形式にも変換できます（これらの形式に関する記事は別途参照）。

- [Convert PPTX to PDF in Java](/slides/ja/java/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in Java](/slides/ja/java/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in Java](/slides/ja/java/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in Java](/slides/ja/java/save-presentation/)
- [Convert PPTX to PNG in Java](/slides/ja/java/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**
PPTX を PPT に変換するには、ファイル名と保存形式を **Save** メソッドに渡すだけです。対象クラスは [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) です。以下の Java コードサンプルは、デフォルトオプションで PPTX から PPT への変換を行います。
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
Presentation presentation = new Presentation("template.pptx");

// プレゼンテーションを PPT として保存する
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**Do all PPTX effects and features survive when saving to the legacy PPT (97–2003) format?**

必ずしもすべて残るわけではありません。PPT 形式には新しい機能（特定のエフェクト、オブジェクト、動作など）が一部欠けているため、変換時に機能が単純化またはラスタライズされることがあります。

**Can I convert only selected slides to PPT instead of the entire presentation?**

保存はプレゼンテーション全体を対象に行われます。特定のスライドだけを変換したい場合は、対象スライドだけで構成された新しいプレゼンテーションを作成し、それを PPT として保存してください。または、スライド単位の変換パラメータをサポートするサービス／API を利用してください。

**Are password-protected presentations supported?**

はい。ファイルが保護されているかどうかを検出し、パスワードを使用して開くことができます。また、保存する PPT に対して [configure protection/encryption settings](/slides/ja/java/password-protected-presentation/) を設定することも可能です。