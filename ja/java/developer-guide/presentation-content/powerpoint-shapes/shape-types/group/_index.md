---
title: グループ
type: docs
weight: 40
url: /ja/java/group/
---

## **グループシェイプの追加**
Aspose.Slidesはスライド上のグループシェイプと作業することをサポートしています。この機能は、開発者がよりリッチなプレゼンテーションをサポートするのに役立ちます。Aspose.Slides for Javaは、グループシェイプの追加またはアクセスをサポートしています。追加されたグループシェイプにシェイプを追加して内容を充填することや、グループシェイプの任意のプロパティにアクセスすることが可能です。Aspose.Slides for Javaを使用してスライドにグループシェイプを追加するには：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにグループシェイプを追加します。
1. 追加されたグループシェイプにシェイプを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、スライドにグループシェイプを追加します。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // スライドのシェイプコレクションにアクセス
    IShapeCollection slideShapes = sld.getShapes();

    // スライドにグループシェイプを追加
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // 追加されたグループシェイプ内にシェイプを追加
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // グループシェイプフレームを追加
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // PPTXファイルをディスクに書き込む
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **AltTextプロパティへのアクセス**
このトピックでは、グループシェイプを追加し、スライド上のグループシェイプのAltTextプロパティにアクセスするための簡単な手順をコード例と共に示します。Aspose.Slides for Javaを使用してスライド上のグループシェイプのAltTextにアクセスするには：

1. PPTXファイルを表す[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスをインスタンス化します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドのシェイプコレクションにアクセスします。
1. グループシェイプにアクセスします。
1. [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--)プロパティにアクセスします。

以下の例では、グループシェイプの代替テキストにアクセスします。

```java
// PPTXファイルを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation("AltText.pptx");
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // スライドのシェイプコレクションにアクセス
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // グループシェイプにアクセス
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // AltTextプロパティにアクセス
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```