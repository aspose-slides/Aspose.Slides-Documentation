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
description: "Aspose.Slides for C++ を使用して PPTX を PPT に簡単に変換できます—プレゼンテーションのレイアウトと品質を保持しながら、PowerPoint 形式とのシームレスな互換性を確保します。"
---

## **概要**

このドキュメントでは、C++ を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックをカバーしています。

- C++ で PPTX を PPT に変換

## **C++ で PPTX を PPT に変換**

C++ のサンプルコードは、以下のセクション [PPTX を PPT に変換](#convert-pptx-to-ppt) を参照してください。PPTX ファイルを読み込み、PPT 形式で保存します。保存形式を変更することで、PDF、XPS、ODP、HTML などの他の形式にも保存できます。これらの記事で詳しく説明しています。

- [C++ で PPTX を PDF に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ で PPTX を XPS に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ で PPTX を HTML に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ で PPTX を ODP に変換](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ で PPTX を画像に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **PPTX を PPT に変換**
PPTX を PPT に変換するには、[**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスの **Save** メソッドにファイル名と保存形式を渡すだけです。以下の C++ コードサンプルは、デフォルトオプションで PPTX から PPT へプレゼンテーションを変換します。
```cpp
// PPTX を読み込む。
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// PPT 形式で保存。
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **よくある質問**

**すべての PPTX のエフェクトや機能は、旧形式の PPT（97–2003）で保存したときに保持されますか？**

必ずしも保持されません。PPT 形式には新しい機能の一部（特定のエフェクト、オブジェクト、動作など）がなく、変換時に機能が簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

保存はプレゼンテーション全体を対象とします。特定のスライドだけを変換するには、対象スライドだけで新しいプレゼンテーションを作成し、PPT として保存します。あるいは、スライド単位の変換パラメータをサポートするサービス／API を利用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードを指定して開くことができます。また、保存する PPT の [保護／暗号化設定を構成](/slides/ja/cpp/password-protected-presentation/) も可能です。