---
title: プレゼンテーションにスライドを追加する
type: docs
weight: 10
url: /java/add-slide-to-presentation/
---

## **プレゼンテーションにスライドを追加する**
{{% alert color="primary" %}} 

プレゼンテーションファイルにスライドを追加することについて話す前に、スライドに関するいくつかの事実を説明しましょう。各PowerPointプレゼンテーションファイルには**マスター / レイアウト**スライドと他の**通常**スライドが含まれています。つまり、プレゼンテーションファイルには少なくとも1つ以上のスライドが含まれているということです。スライドのないプレゼンテーションファイルはAspose.Slides for Javaによってサポートされていないことを知っておくことが重要です。各スライドには一意のIDがあり、すべての通常スライドはゼロベースのインデックスによって指定された順序で配置されています。

{{% /alert %}} 

Aspose.Slides for Javaは、開発者がプレゼンテーションに空のスライドを追加できるようにします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)オブジェクトによって公開されている[Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)（コンテンツスライドオブジェクトのコレクション）プロパティに参照を設定することで[ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection)クラスのインスタンスを作成します。
- [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection)オブジェクトによって公開されている[**addEmptySlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-)メソッドを呼び出して、コンテンツスライドコレクションの最後に空のスライドを追加します。
- 新しく追加した空のスライドで作業を行います。
- 最後に、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)オブジェクトを使用してプレゼンテーションファイルを書き込みます。

```java
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化する
Presentation pres = new Presentation();
try {
    // SlideCollectionクラスをインスタンス化する
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Slidesコレクションに空のスライドを追加する
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 新しく追加したスライドで作業を行う

    // PPTXファイルをディスクに保存する
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```