---
title: SmartArtの管理
type: docs
weight: 10
url: /ja/androidjava/manage-smartart/
---

## **SmartArtからテキストを取得する**
現在、TextFrameメソッドが[ISmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtShape)インターフェースおよび[SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape)クラスに追加されました。このプロパティを使用すると、ノードのテキストだけでなく[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)からすべてのテキストを取得できます。以下のサンプルコードは、SmartArtノードからテキストを取得するのに役立ちます。

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
[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)のレイアウトタイプを変更するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockListを追加します。
- [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-)をBasicProcessに変更します。
- プレゼンテーションをPPTXファイルとして書き出します。
  以下の例では、2つの図形の間にコネクタを追加しました。

```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcessを追加
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // LayoutTypeをBasicProcessに変更
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // プレゼンテーションを保存
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArtの隠しプロパティを確認する**
注意: メソッド[ISmartArtNode.isHidden()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--)は、このノードがデータモデル内の隠しノードである場合、trueを返します。[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)の任意のノードの隠しプロパティを確認するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
- [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycleを追加します。
- SmartArtにノードを追加します。
- [isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--)プロパティを確認します。
- プレゼンテーションをPPTXファイルとして書き出します。

以下の例では、2つの図形の間にコネクタを追加しました。

```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcessを追加
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // SmartArtにノードを追加
    ISmartArtNode node = smart.getAllNodes().addNode();

    // isHiddenプロパティを確認
    boolean hidden = node.isHidden(); // trueを返します

    if (hidden)
    {
        // 何らかのアクションや通知を行う
    }
    // プレゼンテーションを保存
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **組織図タイプの取得または設定**
メソッド[ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--)、[setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)を使用して、現在のノードに関連付けられた組織図タイプを取得または設定できます。組織図タイプを取得または設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
- スライドに[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)を追加します。
- 組織図タイプを[取得](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--)または[設定](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)します。
- プレゼンテーションをPPTXファイルとして書き出します。
  以下の例では、2つの図形の間にコネクタを追加しました。

```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcessを追加
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // 組織図タイプを取得または設定
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // プレゼンテーションを保存
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **画像組織図の作成**
Aspose.Slides for Android via Javaは、簡単にチャートを作成するためのシンプルなAPIを提供しています。スライドにチャートを作成するには:

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータを持つチャートを追加し、希望のタイプ（ChartType.PictureOrganizationChart）を指定します。
4. 修正したプレゼンテーションをPPTXファイルに書き出します。

以下のコードは、チャートを作成するために使用されます。

```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArtの状態の取得または設定**
[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)のレイアウトタイプを変更するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. スライドに[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)を追加します。
3. SmartArt Diagramの状態を[取得](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--)または[設定](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-)します。
4. プレゼンテーションをPPTXファイルとして書き出します。

以下のコードは、チャートを作成するために使用されます。

```java
// PPTXファイルを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcessを追加
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // SmartArt Diagramの状態を取得または設定
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // プレゼンテーションを保存
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```