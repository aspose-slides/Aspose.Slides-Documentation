---
title: プレゼンテーションにスライドを追加する
type: docs
weight: 10
url: /ja/androidjava/add-slide-to-presentation/
---

## **プレゼンテーションにスライドを追加する**
{{% alert color="primary" %}} 

プレゼンテーションファイルにスライドを追加することについて話す前に、スライドに関するいくつかの事実を考察しましょう。各PowerPointプレゼンテーションファイルには**マスター/レイアウト**スライドと他の**通常**スライドが含まれています。これは、プレゼンテーションファイルが少なくとも1つ以上のスライドを含むことを意味します。スライドのないプレゼンテーションファイルは、Aspose.Slides for Android via Javaによってサポートされないことを知っておくことが重要です。各スライドにはユニークなIdがあり、すべての通常のスライドはゼロベースのインデックスによって指定された順序で配置されています。

{{% /alert %}} 

Aspose.Slides for Android via Javaは、開発者がプレゼンテーションに空のスライドを追加することを可能にします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)オブジェクトによって公開される[Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)（コンテンツスライドオブジェクトのコレクション）プロパティへの参照を設定して[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)クラスのインスタンスを生成します。
- [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)オブジェクトによって公開される[**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-)メソッドを呼び出して、コンテンツスライドコレクションの最後に空のスライドを追加します。
- 新しく追加された空のスライドで作業を行います。
- 最後に、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)オブジェクトを使用してプレゼンテーションファイルを書き込みます。

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // SlideCollectionクラスをインスタンス化
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Slidesコレクションに空のスライドを追加
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 新しく追加されたスライドで作業を行う

    // PPTXファイルをディスクに保存
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```