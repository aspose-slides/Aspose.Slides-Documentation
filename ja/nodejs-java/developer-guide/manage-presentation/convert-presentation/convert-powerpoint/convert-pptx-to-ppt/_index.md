---
title: JavaScript で PPTX を PPT に変換する
linktitle: PPTX を PPT に変換
type: docs
weight: 21
url: /ja/nodejs-java/convert-pptx-to-ppt/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用して PPTX を PPT に簡単に変換し、PowerPoint 形式とのシームレスな互換性を確保しながら、プレゼンテーションのレイアウトと品質を保持します。"
---

## **概要**

このドキュメントでは、JavaScript を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックを扱います。

- JavaScript で PPTX を PPT に変換する

## **JavaScript で PPTX を PPT に変換する**

JavaScript のサンプルコードは以下のセクション、[Convert PPTX to PPT](#convert-pptx-to-ppt) を参照してください。サンプルは PPTX ファイルを読み込み、PPT 形式で保存します。保存形式を変更すれば、PDF、XPS、ODP、HTML など他の形式にも変換できます（これらの形式は別記事で解説しています）。

- [Convert PPTX to PDF in JavaScript](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in JavaScript](/slides/ja/nodejs-java/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in JavaScript](/slides/ja/nodejs-java/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in JavaScript](/slides/ja/nodejs-java/save-presentation/)
- [Convert PPTX to PNG in JavaScript](/slides/ja/nodejs-java/convert-powerpoint-to-png/)

## **PPTX を PPT に変換する**

PPTX を PPT に変換するには、[**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスの **Save** メソッドにファイル名と保存形式を渡します。以下の JavaScript サンプルはデフォルトオプションで PPTX から PPT に変換します。
```javascript
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
var presentation = new aspose.slides.Presentation("template.pptx");
// プレゼンテーションを PPT として保存します
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **FAQ**

**PPTX のすべての効果や機能は、レガシー PPT（97–2003）形式で保存しても維持されますか？**

必ずしも維持されません。PPT 形式は新しい機能（特定の効果、オブジェクト、動作）をサポートしていないため、変換時に機能が簡略化またはラスター化されることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

**Save** メソッドはプレゼンテーション全体を対象とします。特定のスライドだけを変換するには、対象スライドだけで新しいプレゼンテーションを作成し、PPT として保存してください。または、スライド単位の変換パラメータをサポートするサービス／API を利用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードで開くことができます。また、保存した PPT のために [保護／暗号化設定を構成](/slides/ja/nodejs-java/password-protected-presentation/) することも可能です。