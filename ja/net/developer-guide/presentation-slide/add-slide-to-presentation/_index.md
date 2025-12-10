---
title: .NET でプレゼンテーションにスライドを追加
linktitle: スライドを追加
type: docs
weight: 10
url: /ja/net/add-slide-to-presentation/
keywords:
- スライドを追加
- スライドを作成
- 空のスライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションにスライドを簡単に追加できます—シームレスで効率的なスライド挿入を数秒で実現します。"
---

## **プレゼンテーションにスライドを追加する**
プレゼンテーションファイルにスライドを追加する前に、スライドに関するいくつかの事実を説明します。各 PowerPoint プレゼンテーション ファイルにはマスター/レイアウト スライドとその他の標準スライドが含まれます。つまり、プレゼンテーション ファイルには少なくとも 1 つ以上のスライドが含まれます。スライドがまったくないプレゼンテーション ファイルは Aspose.Slides for .NET ではサポートされていないことに注意してください。各スライドは一意の Id を持ち、すべての標準スライドはゼロベースのインデックスで指定された順序で配置されます。Aspose.Slides for .NET は開発者がプレゼンテーションに空のスライドを追加できるようにします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- Presentation オブジェクトが公開する Slides（スライド オブジェクトのコレクション）プロパティへの参照を設定して、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) クラスのインスタンスを取得します。
- ISlideCollection オブジェクトが公開する AddEmptySlide メソッドを呼び出して、コンテンツ スライド コレクションの末尾に空のスライドを追加します。
- 新しく追加した空のスライドで作業を行います。
- 最後に、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトを使用してプレゼンテーション ファイルを書き出します。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **FAQ**

**新しいスライドを末尾ではなく特定の位置に挿入できますか？**

はい。ライブラリはスライド コレクションと [insert](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertclone/) 操作をサポートしているため、末尾だけでなく任意のインデックスにスライドを追加できます。

**レイアウトに基づいてスライドを追加すると、テーマ/スタイルは保持されますか？**

はい。レイアウトはマスターから書式設定を継承し、新しいスライドは選択したレイアウトとそれに関連付けられたマスターから継承します。

**スライドを追加する前の「空」のプレゼンテーションにはどのスライドが存在しますか？**

新しく作成されたプレゼンテーションにはインデックス 0 の空白スライドが 1 枚既に含まれています。挿入インデックスを計算する際にこの点を考慮する必要があります。

**マスターに多数のオプションがある場合、適切なレイアウトをどのように選択しますか？**

通常は、必要な構造（[Title and Content、Two Content など](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/)）に一致する [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) を選択します。そのようなレイアウトが存在しない場合は、[master に追加](/slides/ja/net/slide-layout/) してから使用してください。