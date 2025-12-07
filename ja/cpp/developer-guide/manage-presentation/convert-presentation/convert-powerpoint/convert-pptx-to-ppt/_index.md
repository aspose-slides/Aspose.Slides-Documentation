---
title: C++ で PPTX を PPT に変換する
linktitle: PPTX から PPT へ
type: docs
weight: 21
url: /ja/cpp/convert-pptx-to-ppt/
keywords:
- PowerPoint を変換する
- プレゼンテーションを変換する
- スライドを変換する
- PPTX を変換する
- PPTX から PPT
- PPTX を PPT として保存する
- PPTX を PPT にエクスポートする
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PPTX を PPT に簡単に変換し、PowerPoint 形式とのシームレスな互換性を確保しながら、プレゼンテーションのレイアウトと品質を維持します。"
---

## **概要**

この記事では、C++ を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックがカバーされています。

- C++ で PPTX を PPT に変換する

## **C++ で PPTX を PPT に変換する**

C++ のサンプルコードで PPTX を PPT に変換する方法については、以下のセクション[Convert PPTX to PPT](#convert-pptx-to-ppt)をご覧ください。PPTX ファイルを読み込み、PPT 形式で保存するだけです。保存形式を変更すれば、PDF、XPS、ODP、HTML などの他の形式にも保存できます（これらの記事で詳しく説明しています）。

- [C++ PPTX を PDF に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ PPTX を XPS に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ PPTX を HTML に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ PPTX を ODP に変換](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ PPTX を画像に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **PPTX を PPT に変換する**
PPTX を PPT に変換するには、[**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスの **Save** メソッドにファイル名と保存形式を渡すだけです。以下の C++ コードサンプルは、デフォルトオプションで Presentation を PPTX から PPT に変換します。
```cpp
// PPTX をロードします。
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// PPT 形式で保存します。
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **よくある質問**

**すべての PPTX エフェクトや機能は、レガシー PPT（97–2003）形式で保存しても維持されますか？**

必ずしも維持されません。PPT 形式は新しい機能（特定のエフェクト、オブジェクト、動作など）に対応していないため、変換時に機能が簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存するとプレゼンテーション全体が対象となります。特定のスライドだけを変換したい場合は、対象スライドだけで新しいプレゼンテーションを作成し、PPT として保存します。または、スライド単位の変換パラメータをサポートするサービス/API を使用してください。

**パスワード保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードを指定して開くことができます。また、保存する PPT の[保護/暗号化設定](/slides/ja/cpp/password-protected-presentation/)を構成することも可能です。