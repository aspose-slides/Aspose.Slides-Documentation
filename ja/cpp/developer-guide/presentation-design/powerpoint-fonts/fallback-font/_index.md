---
title: C++ のプレゼンテーションにおけるフォールバックフォントの管理
linktitle: フォールバックフォント
type: docs
weight: 50
url: /ja/cpp/fallback-font/
keywords:
- フォールバックフォント
- 利用可能なフォント
- グリフ置換
- フォントの指定
- ルールの指定
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "元のフォントが利用できない場合に、PowerPoint および OpenDocument のプレゼンテーションでテキストを読みやすく保つために、Aspose.Slides for C++ がフォールバックフォントをどのように利用するかを確認してください。"
---
## **Introduction**

フォールバックフォントは、テキストに指定されたフォントがシステムに存在するものの、必要なグリフが含まれていない場合に使用されます。この場合、Aspose.Slides は指定されたフォールバックフォントのいずれかを使用して欠落したグリフを置き換えることができます。

## **Fallback Font**
フォールバックフォントは、テキストに指定されたフォントがシステムに存在するものの、そのフォントに必要なグリフが含まれていないときに使用されます。この場合、指定されたフォールバックフォントのいずれかを使用してグリフの置き換えを行うことが可能です。

Aspose.Slides はフォールバックフォントの作成、フォールバックフォントコレクションへの追加、特定のプレゼンテーションに対するフォールバックフォントコレクションの設定、プレゼンテーションからのフォールバックフォントの削除、フォールバックフォントを適用するルールの指定などをサポートしています。

これらの機能に慣れるために、以下のリンクをご利用ください。

- [Create Fallback Font](/slides/ja/cpp/create-fallback-font)
- [Create Fallback Fonts Collection](/slides/ja/cpp/create-fallback-fonts-collection)
- [Render Presentation with Fallback Font](/slides/ja/cpp/render-presentation-with-fallback-font)

## **FAQ**

**How do fallback fonts differ from font substitution?**

フォールバックは、主フォントに特定のグリフが無い場合に、文字単位または Unicode の範囲単位で適用され、欠落した文字だけを埋めます。[Substitution](/slides/ja/cpp/font-substitution/) は、欠落または利用できないフォント全体を別のフォントに置き換えるもので、テキストの走査全体や一部に適用されます。両者は組み合わせて使用できるものの、適用範囲と選択ロジックは異なります。

**Are fallback settings saved inside the presentation file?**

いいえ。フォールバックの設定はライブラリ内で処理/レンダリング時に保持され、PPTX にはシリアライズされません。プレゼンテーション自体はフォールバックルールを保存しません。

**Does fallback affect elements created by PowerPoint objects (SmartArt, charts, WordArt)?**

はい。これらのオブジェクト内のテキストも同じレンダリングパイプラインを通るため、通常のテキストと同様にフォールバックルールが適用されます。