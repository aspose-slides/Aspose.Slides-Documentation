---  
title: Android でプレゼンテーションにスライドを追加  
linktitle: スライドを追加  
type: docs  
weight: 10  
url: /ja/androidjava/add-slide-to-presentation/  
keywords:  
- スライドを追加  
- スライドを作成  
- 空のスライド  
- PowerPoint  
- OpenDocument  
- プレゼンテーション  
- Android  
- Java  
- Aspose.Slides  
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションにスライドを簡単に追加できます。シームレスで効率的なスライド挿入が数秒で可能です。"  
---

## **プレゼンテーションにスライドを追加**
{{% alert color="primary" %}}

スライドをプレゼンテーション ファイルに追加する前に、スライドに関するいくつかの事実を説明します。各 PowerPoint プレゼンテーション ファイルには **マスター / レイアウト** スライドとその他の **標準** スライドが含まれます。つまり、プレゼンテーション ファイルには少なくとも 1 つ以上のスライドが含まれます。スライドのないプレゼンテーション ファイルは Aspose.Slides for Android via Java ではサポートされていないことに注意してください。各スライドには一意の Id があり、すべての標準スライドはゼロベースのインデックスで指定された順序で配置されます。

{{% /alert %}}

Aspose.Slides for Android via Java は開発者がプレゼンテーションに空のスライドを追加できるようにします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) オブジェクトが公開する [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)（スライド オブジェクトのコレクション）プロパティへの参照を設定して、[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) クラスのインスタンスを作成します。
- [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) オブジェクトが公開する [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) メソッドを呼び出し、コンテンツ スライド コレクションの末尾に空のスライドを追加します。
- 新しく追加された空のスライドで作業を行います。
- 最後に、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) オブジェクトを使用してプレゼンテーション ファイルを書き込みます。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // SlideCollection クラスのインスタンスを作成する
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Slides コレクションに空のスライドを追加する
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 新しく追加されたスライドで何らかの処理を行う

    // PPTX ファイルをディスクに保存する
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **FAQ**

**新しいスライドを最後ではなく特定の位置に挿入できますか？**

はい。ライブラリはスライド コレクションと [insert](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 操作をサポートしているため、末尾だけでなく必要なインデックスにスライドを追加できます。

**レイアウトに基づくスライドを追加するとテーマ/スタイルは保持されますか？**

はい。レイアウトはマスターから書式設定を継承し、新しいスライドは選択したレイアウトとその関連マスターから継承します。

**スライドを追加する前の新しい「空」プレゼンテーションにはどのスライドが存在しますか？**

新しく作成されたプレゼンテーションにはインデックス0の空白スライドが既に 1 枚含まれています。これは挿入インデックスを計算する際に考慮すべき重要な点です。

**マスターに多くのオプションがある場合、どのレイアウトを新しいスライドに選択すべきですか？**

一般的には、必要な構造（[タイトルと内容、2 つのコンテンツ、など](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidelayouttype/)）に一致する [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) を選択します。そのようなレイアウトが存在しない場合は、[マスターに追加](/slides/ja/androidjava/slide-layout/) してから使用できます。