---
title: プレゼンテーションにスライドを追加
type: docs
weight: 10
url: /cpp/add-slide-to-presentation/
---

## **プレゼンテーションにスライドを追加**
プレゼンテーションファイルにスライドを追加することについて話す前に、スライドに関するいくつかの事実を議論しましょう。各PowerPointプレゼンテーションファイルにはマスター/レイアウトスライドと他の通常スライドが含まれています。つまり、プレゼンテーションファイルには少なくとも1つ以上のスライドが含まれているということです。スライドのないプレゼンテーションファイルはAspose.Slides for C++ではサポートされていないことを知っておくことが重要です。各スライドにはユニークなIDがあり、すべての通常スライドはゼロベースのインデックスによって指定された順序で配置されています。Aspose.Slides for C++は、開発者がプレゼンテーションに空のスライドを追加できるようにします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
- Presentationオブジェクトが公開しているSlides（コンテンツスライドオブジェクトのコレクション）プロパティへの参照を設定することで、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)クラスのインスタンスを作成します。
- ISlideCollectionオブジェクトが公開しているAddEmptySlideメソッドを呼び出して、コンテンツスライドコレクションの最後に空のスライドを追加します。
- 新たに追加した空のスライドで作業を行います。
- 最後に、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトを使用してプレゼンテーションファイルを書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}