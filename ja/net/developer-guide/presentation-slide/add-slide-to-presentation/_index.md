---
title: プレゼンテーションにスライドを追加
type: docs
weight: 10
url: /ja/net/add-slide-to-presentation/
keywords: "プレゼンテーションにスライドを追加, C#, Csharp, .NET, Aspose.Slides"
description: "C#または.NETでプレゼンテーションにスライドを追加"
---

## **プレゼンテーションにスライドを追加**
プレゼンテーションファイルにスライドを追加することについて話す前に、スライドに関するいくつかの事実を説明します。各PowerPointプレゼンテーションファイルには、マスター/レイアウトスライドと他の通常のスライドが含まれています。つまり、プレゼンテーションファイルには少なくとも1つ以上のスライドが含まれています。スライドのないプレゼンテーションファイルは、Aspose.Slides for .NETによってサポートされていないことを知っておくことが重要です。各スライドにはユニークなIdがあり、すべての通常のスライドはゼロベースのインデックスで指定された順序で配置されます。Aspose.Slides for .NETは、開発者がプレゼンテーションに空のスライドを追加することを可能にします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
- Presentationオブジェクトによって公開されるSlides（コンテンツスライドオブジェクトのコレクション）プロパティへの参照を設定して、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)クラスのインスタンスを作成します。
- ISlideCollectionオブジェクトによって公開されるAddEmptySlideメソッドを呼び出して、コンテンツスライドコレクションの末尾に空のスライドを追加します。
- 新しく追加した空のスライドで何らかの作業を行います。
- 最後に、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトを使用してプレゼンテーションファイルを書き込みます。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}