---
title: C++ でプレゼンテーションにスライドを追加
linktitle: スライドを追加
type: docs
weight: 10
url: /ja/cpp/add-slide-to-presentation/
keywords:
- スライド追加
- スライド作成
- 空白スライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションにスライドを簡単に追加できます — 数秒でシームレスかつ効率的にスライドを挿入できます。"
---

## **スライドをプレゼンテーションに追加する**
スライドをプレゼンテーション ファイルに追加することについて説明する前に、スライドに関するいくつかの事実を確認しましょう。各 PowerPoint プレゼンテーション ファイルにはマスター/レイアウト スライドとその他の通常スライドが含まれます。つまり、プレゼンテーション ファイルには少なくとも 1 枚以上のスライドが存在します。スライドがないプレゼンテーション ファイルは Aspose.Slides for C++ ではサポートされていないことに注意してください。各スライドには固有の Id があり、すべての通常スライドはゼロベースのインデックスで指定された順序で配置されます。Aspose.Slides for C++ は開発者が空のスライドをプレゼンテーションに追加することを可能にします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
- Presentation オブジェクトが公開する Slides（コンテンツ スライド オブジェクトのコレクション）プロパティへの参照を設定して、[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) クラスのインスタンスを作成します。
- ISlideCollection オブジェクトが公開する AddEmptySlide メソッドを呼び出して、コンテンツ スライド コレクションの末尾に空のスライドをプレゼンテーションに追加します。
- 新しく追加した空のスライドで何らかの処理を行います。
- 最後に、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) オブジェクトを使用してプレゼンテーション ファイルを書き出します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **よくある質問**

**スライドを末尾だけでなく、特定の位置に挿入できますか？**

はい。ライブラリはスライド コレクションと [insert](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertclone/) 操作をサポートしているため、末尾だけでなく必要なインデックスにスライドを追加できます。

**レイアウトに基づいてスライドを追加する際に、テーマ/スタイルは保持されますか？**

はい。レイアウトはマスターから書式設定を継承し、新しいスライドは選択したレイアウトとその関連マスターから継承します。

**スライドを追加する前の新しい「空」プレゼンテーションにはどのスライドが含まれていますか？**

新しく作成されたプレゼンテーションには、インデックス0の空白スライドがすでに1枚含まれています。挿入インデックスを計算する際に重要です。

**マスターに多数のオプションがある場合、どのレイアウトを新しいスライドに選べばよいですか？**

通常は、必要な構造（[Title and Content, Two Content, etc.](https://reference.aspose.com/slides/cpp/aspose.slides/slidelayouttype/)）に一致する [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) を選択します。該当するレイアウトが存在しない場合は、[add it to the master](/slides/ja/cpp/slide-layout/) でマスターに追加してから使用できます。