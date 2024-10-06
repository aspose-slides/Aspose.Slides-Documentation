---
title: スマートアートの管理
type: docs
weight: 10
url: /ja/java/manage-smartart/
---

## **SmartArtからテキストを取得する**
現在、テキストフレームメソッドが[ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape)インターフェースと[SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape)クラスに追加されました。このプロパティを使用すると、ノードにテキストが含まれていない場合、[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)からすべてのテキストを取得できます。以下のサンプルコードは、SmartArtノードからテキストを取得するのに役立ちます。

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    ISmartArt smartArt = (ISmartArt)slide.getShapes().get_Item(0);

    ISmartArtNodeCollection smartArtNodes = smartArt.getAllNodes();
    for (ISmartArtNode smartArtNode : smartArtNodes)
    {
        for (ISmartArtShape nodeShape : smartArtNode.getShapes())
        {
            if (nodeShape.getTextFrame() != null)
                System.out.println(nodeShape.getTextFrame().getText());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArtのレイアウトタイプを変更する**
[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)のレイアウトタイプを変更するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockListを追加します。
- [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-)をBasicProcessに変更します。
- プレゼンテーションをPPTXファイルとして保存します。
  以下の例では、2つの図形の間にコネクタを追加しました。

```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcessの追加
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // LayoutTypeをBasicProcessに変更
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // プレゼンテーションの保存
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArtの隠しプロパティを確認する**
注意してください：メソッド[ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--))は、このノードがデータモデル内の隠しノードである場合、trueを返します。任意の[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)ノードの隠しプロパティを確認するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
- [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycleを追加します。
- SmartArtにノードを追加します。
- [isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--)プロパティを確認します。
- プレゼンテーションをPPTXファイルとして保存します。

以下の例では、2つの図形の間にコネクタを追加しました。

```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcessの追加 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // SmartArtにノードを追加 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // isHiddenプロパティを確認
    boolean hidden = node.isHidden(); // trueを返します

    if (hidden)
    {
        // 何らかのアクションや通知を実行
    }
    // プレゼンテーションの保存
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **組織図タイプを取得または設定する**
メソッド[ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--)、 [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)は、現在のノードに関連する組織図タイプを取得または設定します。組織図タイプを取得または設定するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
- スライドに[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)を追加します。
- [組織図タイプを取得または設定します](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)。
- プレゼンテーションをPPTXファイルとして保存します。
  以下の例では、2つの図形の間にコネクタを追加しました。

```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcessの追加
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // 組織図タイプを取得または設定
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // プレゼンテーションの保存
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ピクチャー組織図を作成する**
Aspose.Slides for Javaは、簡単な方法でピクチャー組織図を作成するためのシンプルなAPIを提供します。スライドにチャートを作成するには：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを用いてスライドの参照を取得します。
1. デフォルトデータとともに希望のタイプ（ChartType.PictureOrganizationChart）のチャートを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下のコードはチャートを作成するために使用されます。

```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArtの状態を取得または設定する**
[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)のレイアウトタイプを変更するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドに[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)を追加します。
1. [SmartArtダイアグラムの状態を取得](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--)または[設定します](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-)。
1. プレゼンテーションをPPTXファイルとして保存します。

以下のコードはチャートを作成するために使用されます。

```java
// PPTXファイルを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcessの追加
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // SmartArtダイアグラムの状態を取得または設定
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // プレゼンテーションの保存
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```