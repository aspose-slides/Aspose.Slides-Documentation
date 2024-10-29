---
title: プレゼンテーションのローカリゼーション
type: docs
weight: 100
url: /ja/java/presentation-localization/
---

## **プレゼンテーションと図形のテキストの言語変更**
- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) の [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) タイプを追加します。
- テキストフレームにテキストを追加します。
- テキストに [Setting Language Id](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) を設定します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記のステップの実装は、以下の例で示されています。

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("スペルチェックの言語を適用するテキスト");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```