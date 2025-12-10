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
description: "Aspose.Slides for C++ を使用して PPTX を PPT に簡単に変換できます—PowerPoint 形式とのシームレスな互換性を確保し、プレゼンテーションのレイアウトと品質を保ちます。"
---

## **概要**

この記事では、C++ を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックがカバーされています。

- C++ で PPTX を PPT に変換する

## **C++ で PPTX を PPT に変換する**

C++ のサンプルコードで PPTX を PPT に変換する方法については、以下のセクション、すなわち [Convert PPTX to PPT](#convert-pptx-to-ppt) を参照してください。コードは PPTX ファイルを読み込み、PPT 形式で保存します。保存形式を変更することで、PDF、XPS、ODP、HTML などの他の多くの形式にも PPTX ファイルを保存できます。これらの記事で説明されています。

- [C++ PPTX を PDF に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ PPTX を XPS に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ PPTX を HTML に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ PPTX を ODP に変換](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ PPTX を画像に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **PPTX を PPT に変換**

PPTX を PPT に変換するには、ファイル名と保存形式を [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスの **Save** メソッドに渡すだけです。以下の C++ コードサンプルは、デフォルトオプションを使用して PPTX から PPT にプレゼンテーションを変換します。
```cpp
// PPTX を読み込みます。
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// PPT 形式で保存します。
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**PPTX のすべてのエフェクトや機能は、従来の PPT (97–2003) 形式で保存したときに保持されますか？**

必ずしも保持されるわけではありません。PPT 形式は新しい機能の一部（例: 特定のエフェクト、オブジェクト、動作）をサポートしていないため、変換時に機能が簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存するとプレゼンテーション全体が対象になります。特定のスライドだけを変換するには、そのスライドだけを含む新しいプレゼンテーションを作成して PPT として保存します。あるいは、スライド単位の変換パラメータに対応したサービス/APIを利用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードで開くことができます。また、保存する PPT の保護/暗号化設定を [保護/暗号化設定を構成する](/slides/ja/cpp/password-protected-presentation/) で構成することも可能です。