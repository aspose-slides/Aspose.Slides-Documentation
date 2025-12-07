---
title: C++ で PPTX を PPT に変換
linktitle: PPTX から PPT
type: docs
weight: 21
url: /ja/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PPTX を PPT に簡単に変換し、PowerPoint 形式とのシームレスな互換性を確保しながら、プレゼンテーションのレイアウトと品質を保持します。"
---

## **概要**

この記事では、C++ を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法について説明します。以下のトピックを取り上げます。

- C++ で PPTX を PPT に変換

## **C++ で PPTX を PPT に変換**

C++ のサンプルコードで PPTX を PPT に変換する方法については、以下のセクション、[Convert PPTX to PPT](#convert-pptx-to-ppt) を参照してください。コードは PPTX ファイルを読み込み、PPT 形式で保存します。保存形式を変更すれば、PDF、XPS、ODP、HTML など、さまざまな形式にも変換できます（これらの記事で詳しく説明しています）。

- [C++ PPTX を PDF に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ PPTX を XPS に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ PPTX を HTML に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ PPTX を ODP に変換](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ PPTX を画像に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **PPTX を PPT に変換**
PPTX を PPT に変換するには、[**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスの **Save** メソッドにファイル名と保存形式を指定します。以下の C++ コードサンプルは、デフォルトオプションで PPTX から PPT にプレゼンテーションを変換します。
```cpp
// PPTX を読み込みます。
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// PPT 形式で保存します。
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **よくある質問**

**すべての PPTX エフェクトや機能は、レガシー PPT（97–2003）形式に保存したときに保持されますか？**

必ずしも保持されません。PPT 形式は新しい機能（特定のエフェクト、オブジェクト、動作など）をサポートしていないため、変換時に機能が単純化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存するとプレゼンテーション全体が対象になります。特定のスライドだけを変換したい場合は、対象スライドだけで新しいプレゼンテーションを作成し、PPT として保存してください。または、スライド単位の変換パラメータをサポートするサービスや API を利用してください。

**パスワード保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているか検出し、パスワードで開くことができます。また、保存する PPT に対して[保護/暗号化設定を構成](/slides/ja/cpp/password-protected-presentation/)することも可能です。