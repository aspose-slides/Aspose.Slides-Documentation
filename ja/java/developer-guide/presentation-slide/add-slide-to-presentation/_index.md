---
title: Java でプレゼンテーションにスライドを追加
linktitle: スライドを追加
type: docs
weight: 10
url: /ja/java/add-slide-to-presentation/
keywords:
- スライド追加
- スライド作成
- 空白スライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のプレゼンテーションにスライドを簡単に追加できます。シームレスで効率的なスライド挿入をわずか数秒で実現します。"
---

## **プレゼンテーションにスライドを追加する**
{{% alert color="primary" %}} 

プレゼンテーション ファイルにスライドを追加することについて説明する前に、スライドに関するいくつかの事実を確認しましょう。各 PowerPoint プレゼンテーション ファイルには **Master / Layout** スライドとその他の **Normal** スライドが含まれます。つまり、プレゼンテーション ファイルには少なくとも 1 つ以上のスライドが含まれます。スライドがないプレゼンテーション ファイルは Aspose.Slides for Java ではサポートされていないことに注意してください。各スライドには一意の Id があり、すべての Normal スライドは 0 ベースのインデックスで指定された順序で配置されます。

{{% /alert %}} 

Aspose.Slides for Java は開発者がプレゼンテーションに空のスライドを追加できるようにします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。  
  `new Presentation()` などを使用します。
- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) オブジェクトが公開する [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) (コンテンツ スライド オブジェクトのコレクション) プロパティへの参照を設定して、[ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) クラスのインスタンスを作成します。
- [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) オブジェクトが提供する [**addEmptySlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) メソッドを呼び出して、コンテンツ スライド コレクションの末尾に空のスライドをプレゼンテーションに追加します。
- 新しく追加された空のスライドで何らかの操作を行います。
- 最後に、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) オブジェクトを使用してプレゼンテーション ファイルを書き出します。

```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // SlideCollection クラスのインスタンスを作成
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // 空のスライドを Slides コレクションに追加
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 追加された新しいスライドで作業を行う

    // PPTX ファイルをディスクに保存
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **よくある質問**

**スライドを末尾ではなく特定の位置に挿入できますか？**

はい。ライブラリはスライド コレクションと [insert](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 操作をサポートしているため、末尾だけでなく必要なインデックスにスライドを追加できます。

**レイアウトに基づいてスライドを追加すると、テーマ/スタイルは保持されますか？**

はい。レイアウトはマスターから書式設定を継承し、新しいスライドは選択したレイアウトとそれに関連付けられたマスターから継承します。

**スライドを追加する前の新しい「空」プレゼンテーションにはどのスライドが存在しますか？**

新しく作成されたプレゼンテーションには、インデックス 0 の空白スライドがすでに 1 枚含まれています。これは、挿入インデックスを計算する際に考慮すべき重要な点です。

**マスターに多くのオプションがある場合、新しいスライドに「適切な」レイアウトをどう選択しますか？**

通常は、必要な構造（[Title and Content, Two Content, etc.](https://reference.aspose.com/slides/java/com.aspose.slides/slidelayouttype/)）に一致する [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) を選択します。もしそのようなレイアウトが存在しない場合は、[add it to the master](/slides/ja/java/slide-layout/) でマスターに追加し、使用してください。