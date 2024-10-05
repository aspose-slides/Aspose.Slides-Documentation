---
title: ポーション
type: docs
weight: 70
url: /java/portion/
---

## **ポーションの位置座標を取得する**
[**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) メソッドが [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPortion) および [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) クラスに追加され、ポーションの開始位置の座標を取得できるようになりました。

```java
// PPTXを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // プレゼンテーションのコンテキストを再形成
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```