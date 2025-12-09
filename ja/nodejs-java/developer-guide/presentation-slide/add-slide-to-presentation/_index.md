---
title: プレゼンテーションにスライドを追加
type: docs
weight: 10
url: /ja/nodejs-java/add-slide-to-presentation/
---

## **プレゼンテーションにスライドを追加**
{{% alert color="primary" %}} 

スライドをプレゼンテーション ファイルに追加する前に、スライドに関するいくつかの事実を説明します。各 PowerPoint プレゼンテーション ファイルには **Master / Layout** スライドと他の **Normal** スライドが含まれます。つまり、プレゼンテーション ファイルには少なくとも 1 枚以上のスライドが含まれます。スライドがないプレゼンテーション ファイルは Aspose.Slides for Node.js via Java ではサポートされていないことに注意してください。各スライドには一意の Id が割り当てられ、すべての Normal スライドはゼロベースのインデックスで指定された順序で配置されます。

{{% /alert %}} 

Aspose.Slides for Node.js via Java は開発者がプレゼンテーションに空のスライドを追加できるようにします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- Presentation オブジェクトが公開する Slides（コンテンツ スライド オブジェクトのコレクション）プロパティへの参照を設定して、SlideCollection クラスのインスタンスを作成します。
- SlideCollection オブジェクトが提供する **addEmptySlide** メソッドを呼び出して、コンテンツ スライド コレクションの末尾に空のスライドをプレゼンテーションに追加します。
- 新しく追加された空のスライドで何らかの操作を行います。
- 最後に、Presentation オブジェクトを使用してプレゼンテーション ファイルを書き出します。
```javascript
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します
var pres = new aspose.slides.Presentation();
try {
    // SlideCollection クラスをインスタンス化します
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Slides コレクションに空のスライドを追加します
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 新しく追加されたスライドで何らかの操作を行います
    // PPTX ファイルをディスクに保存します
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **よくある質問**

**スライドを末尾だけでなく、特定の位置に挿入できますか？**

はい。ライブラリはスライドコレクションと [insert](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertclone/) 操作をサポートしているため、末尾だけでなく必要なインデックスにスライドを追加できます。

**レイアウトに基づくスライドを追加する際に、テーマ/スタイルは保持されますか？**

はい。レイアウトはマスターから書式設定を継承し、新しいスライドは選択したレイアウトとそれに関連付けられたマスターから継承します。

**スライドを追加する前の新しい「空」のプレゼンテーションにはどのスライドが存在しますか？**

新しく作成されたプレゼンテーションには、インデックス 0 の空白スライドが既に 1 枚含まれています。これは挿入インデックスを計算する際に考慮すべき重要な点です。

**マスターに多数のオプションがある場合、新しいスライドに「適切な」レイアウトをどのように選択すればよいですか？**

通常は、必要な構造（[Title and Content, Two Content, etc.](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidelayouttype/)）に一致する LayoutSlide を選択します。そのようなレイアウトが存在しない場合は、[add it to the master](/slides/ja/nodejs-java/slide-layout/) でマスターに追加し、使用できます。