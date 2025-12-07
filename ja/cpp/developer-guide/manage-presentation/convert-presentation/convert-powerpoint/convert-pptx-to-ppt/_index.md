---
title: C++でPPTXをPPTに変換
linktitle: PPTXをPPTに変換
type: docs
weight: 21
url: /ja/cpp/convert-pptx-to-ppt/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTXを変換
- PPTXをPPTに変換
- PPTXをPPTとして保存
- PPTXをPPTにエクスポート
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PPTX を PPT に簡単に変換できます。PowerPoint 形式とのシームレスな互換性を確保し、プレゼンテーションのレイアウトと品質を保ちます。"
---

## **概要**

この記事では、C++ を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックがカバーされています。

- C++ で PPTX を PPT に変換

## **C++ で PPTX を PPT に変換**

C++ のサンプルコードで PPTX を PPT に変換する方法については、下記セクション [PPTX を PPT に変換](#convert-pptx-to-ppt) を参照してください。これは PPTX ファイルを読み込み、PPT 形式で保存するだけのシンプルな処理です。保存形式を変更すれば、PDF、XPS、ODP、HTML など、他の多くの形式にも変換できます（これらの記事をご参照ください）。

- [C++ PPTX を PDF に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ PPTX を XPS に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ PPTX を HTML に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ PPTX を ODP に変換](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ PPTX を画像に変換](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **PPTX を PPT に変換**
PPTX を PPT に変換するには、ファイル名と保存形式を **Save** メソッドに渡すだけです。対象は [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスです。以下の C++ コードサンプルは、デフォルトオプションで PPTX から PPT に変換する例です。
```cpp
// PPTX を読み込みます。
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// PPT 形式で保存します。
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**すべての PPTX のエフェクトや機能は、レガシー PPT (97–2003) 形式に保存した際に残りますか？**

必ずしも残りません。PPT 形式は新しい機能の一部（特定のエフェクトやオブジェクト、動作など）をサポートしていないため、変換時に機能が簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存するとプレゼンテーション全体が対象になります。特定のスライドだけを変換したい場合は、対象スライドだけを含む新しいプレゼンテーションを作成してから PPT として保存するか、スライド単位の変換パラメータをサポートするサービス／API を利用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードを指定して開くことができます。また、保存する PPT に対して [保護／暗号化設定](/slides/ja/cpp/password-protected-presentation/) を構成することも可能です。