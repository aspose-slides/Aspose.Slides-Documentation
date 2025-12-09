---
title: プレゼンテーションへのスライド追加
type: docs
weight: 10
url: /ja/net/add-slide-to-presentation/
keywords: "プレゼンテーションへのスライド追加, C#, Csharp, .NET, Aspose.Slides"
description: "C# または .NET でプレゼンテーションにスライドを追加する"
---

## **プレゼンテーションへのスライド追加**
スライドをプレゼンテーション ファイルに追加することについて説明する前に、スライドに関するいくつかの事実を確認しましょう。各 PowerPoint プレゼンテーション ファイルには Master / Layout スライドとその他の Normal スライドが含まれます。つまり、プレゼンテーション ファイルには少なくとも 1 つ以上のスライドが含まれます。スライドがまったくないプレゼンテーション ファイルは Aspose.Slides for .NET ではサポートされていないことに注意してください。各スライドには一意の Id が付与され、すべての Normal スライドはゼロベースのインデックスで指定された順序で配置されます。Aspose.Slides for .NET は開発者がプレゼンテーションに空のスライドを追加できるようにします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) クラスのインスタンスを作成し、Presentation オブジェクトが公開する Slides（コンテンツ スライド オブジェクトのコレクション）プロパティへの参照を設定します。
- ISlideCollection オブジェクトが公開する AddEmptySlide メソッドを呼び出して、コンテンツ スライド コレクションの末尾に空のスライドをプレゼンテーションに追加します。
- 新しく追加された空のスライドで何らかの処理を行います。
- 最後に、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトを使用してプレゼンテーション ファイルを書き出します。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **よくある質問**

**スライドを末尾だけでなく、特定の位置に挿入できますか？**

はい。ライブラリはスライド コレクションと [insert](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertclone/) 操作をサポートしているため、末尾だけでなく、必要なインデックスにスライドを追加できます。

**レイアウトに基づくスライドを追加すると、テーマ/スタイルは保持されますか？**

はい。レイアウトはマスターから書式設定を継承し、新しいスライドは選択したレイアウトとその関連するマスターから継承します。

**スライドを追加する前の新しい「空」プレゼンテーションには、どのスライドが存在しますか？**

新しく作成されたプレゼンテーションには、インデックス0の空白スライドがすでに1枚含まれています。挿入インデックスを計算するときに考慮すべき重要な点です。

**マスターに多くのオプションがある場合、新しいスライドに「適切な」レイアウトをどのように選択しますか？**

通常は、必要な構造（[Title and Content, Two Content, etc.](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/)）に一致する [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) を選択します。そのようなレイアウトがない場合は、[add it to the master](/slides/ja/net/slide-layout/) でマスターに追加し、使用できます。