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
description: "Aspose.Slides for C++ を使用して PPTX を PPT に簡単に変換できます。PowerPoint 形式とのシームレスな互換性を確保し、プレゼンテーションのレイアウトと品質を維持します。"
---

## **概要**

本記事では、C++ を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックを取り上げます。

- C++ で PPTX を PPT に変換

## **C++でPPTXをPPTに変換**

C++ のサンプルコードで PPTX を PPT に変換する方法については、以下のセクション [PPTXをPPTに変換](#convert-pptx-to-ppt) をご参照ください。コードは PPTX ファイルを読み込んで PPT 形式で保存します。保存形式を変更すれば、PDF、XPS、ODP、HTML など他の多数の形式にも変換できます。

- [C++でPPTXをPDFに変換](/slides/ja/cpp/convert-powerpoint-to-pdf/)
- [C++でPPTXをXPSに変換](/slides/ja/cpp/convert-powerpoint-to-xps/)
- [C++でPPTXをHTMLに変換](/slides/ja/cpp/convert-powerpoint-to-html/)
- [C++でPPTXをODPに変換](/slides/ja/cpp/save-presentation/)
- [C++でPPTXをPNGに変換](/slides/ja/cpp/convert-powerpoint-to-png/)

## **PPTXをPPTに変換**
PPTX を PPT に変換するには、[**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスの **Save** メソッドにファイル名と保存形式を渡すだけです。以下の C++ コードサンプルは、デフォルトオプションで PPTX から PPT へプレゼンテーションを変換します。
```cpp
// PPTX を読み込みます。
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// PPT 形式で保存します。
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **よくある質問**

**すべての PPTX エフェクトや機能は、レガシー PPT（97–2003）形式で保存したときに保持されますか？**

必ずしも保持されません。PPT 形式は新しい機能（特定のエフェクト、オブジェクト、動作など）に対応していないため、変換時に機能が単純化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

保存はプレゼンテーション全体を対象とします。特定のスライドだけを変換したい場合は、対象スライドだけで新しいプレゼンテーションを作成し、PPT として保存してください。または、スライド単位の変換パラメータに対応したサービス/APIを使用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードを指定して開くことができます。また、保存する PPT の [保護/暗号化設定](/slides/ja/cpp/password-protected-presentation/) を構成することも可能です。