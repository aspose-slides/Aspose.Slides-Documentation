---
title: JavaでPowerPointのSmartArt図形ノードを作成または管理する
linktitle: SmartArt図形ノードを管理する
type: docs
weight: 30
url: /java/manage-smartart-shape-node/
keywords: smartart powerpoint, smartart nodes, smartart position, remove smartart, smartart nodes add, powerpoint presentation, powerpoint java, powerpoint java api
description: JavaでPowerPointプレゼンテーションのスマートアートノードおよび子ノードを管理します
---

## **Javaを使用してPowerPointプレゼンテーションにSmartArtノードを追加する**
Aspose.Slides for Javaは、SmartArt図形を最も簡単な方法で管理するためのシンプルなAPIを提供しています。以下のサンプルコードは、SmartArt図形内にノードと子ノードを追加するのに役立ちます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべての図形を走査します。
1. 図形が[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)タイプであるかを確認し、SmartArtである場合は選択した図形を[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)に型変換します。
1. SmartArt図形の[**NodeCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#getAllNodes--)に[新しいノードを追加](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)し、TextFrameにテキストを設定します。
1. 次に、[新しく追加された](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)[**子ノード**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--)を新たに追加した[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)ノードに追加し、TextFrameにテキストを設定します。
1. プレゼンテーションを保存します。

```java
// 必要なプレゼンテーションをロードする
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライド内のすべての図形を走査
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 図形がSmartArtタイプであるか確認
        if (shape instanceof SmartArt) 
        {
            // 図形をSmartArtに型変換
            SmartArt smart = (SmartArt) shape;
    
            // 新しいSmartArtノードを追加
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // テキストを追加
            TemNode.getTextFrame().setText("テスト");
    
            // 親ノードに新しい子ノードを追加します。コレクションの末尾に追加されます
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // テキストを追加
            newNode.getTextFrame().setText("新しいノードが追加されました");
        }
    }
    
    // プレゼンテーションを保存
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **特定の位置にSmartArtノードを追加する**
以下のサンプルコードでは、特定の位置にSmartArt図形のそれぞれのノードに属する子ノードを追加する方法を説明します。

1. Presentationクラスのインスタンスを作成します。
1. インデックスを使用して最初のスライドの参照を取得します。
1. アクセスしたスライドに[**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList)タイプの[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)図形を追加します。
1. 追加したSmartArt図形の最初のノードにアクセスします。
1. 現在、選択した[**ノード**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode)の位置2に[**子ノード**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--)を追加し、テキストを設定します。
1. プレゼンテーションを保存します。

```java
// プレゼンテーションのインスタンスを作成
Presentation pres = new Presentation();
try {
    // プレゼンテーションスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShapeを追加
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // インデックス0のSmartArtノードにアクセス
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // 親ノードの位置2に新しい子ノードを追加
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // テキストを追加
    chNode.getTextFrame().setText("サンプルテキストが追加されました");

    // プレゼンテーションを保存
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Javaを使用してPowerPointプレゼンテーションのSmartArtノードにアクセスする**
以下のサンプルコードは、SmartArt図形内のノードにアクセスするのに役立ちます。SmartArtのレイアウトタイプは読み取り専用であり、SmartArt図形が追加されたときのみ設定されることに注意してください。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべての図形を走査します。
1. 図形が[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)タイプであるかを確認し、SmartArtである場合は選択した図形を[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)に型変換します。
1. SmartArt図形内のすべての[**ノード**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--)を走査します。
1. SmartArtノードの位置、レベル、テキストの情報をアクセスして表示します。

```java
// Presentationクラスのインスタンス化
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべての図形を走査
    for (IShape shape : slide.getShapes()) 
    {
        // 図形がSmartArtタイプであるか確認
        if (shape instanceof ISmartArt) 
        {
            // 図形をSmartArtに型変換
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt内のすべてのノードを走査
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // インデックスiのSmartArtノードにアクセス
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // SmartArtノードのパラメーターを印刷
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt子ノードにアクセスする**
以下のサンプルコードは、SmartArt図形のそれぞれのノードに属する子ノードにアクセスするのに役立ちます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべての図形を走査します。
1. 図形が[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)タイプであるかを確認し、SmartArtである場合は選択した図形を[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)に型変換します。
1. SmartArt図形内のすべての[**ノード**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--)を走査します。
1. 選択したSmartArt図形の[**ノード**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode)のすべての[**子ノード**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#getChildNodes--)を特定のノード内で走査します。
1. [**子ノード**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--)の位置、レベル、テキストの情報をアクセスして表示します。

```java
// Presentationクラスのインスタンス化
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべての図形を走査
    for (IShape shape : slide.getShapes()) 
    {
        // 図形がSmartArtタイプであるか確認
        if (shape instanceof ISmartArt) 
        {
            // 図形をSmartArtに型変換
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt内のすべてのノードを走査
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // インデックスiのSmartArtノードにアクセス
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // インデックスiのSmartArtノード内の子ノードを走査
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // SmartArtノードの子ノードにアクセス
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // SmartArt子ノードのパラメーターを印刷
                    System.out.print("j = " + j + ", テキスト = " + node.getTextFrame().getText() + ", レベル = " + node.getLevel() + ", 位置 = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **特定の位置にSmartArt子ノードにアクセスする**
この例では、SmartArt図形のそれぞれのノードに属する特定の位置に子ノードにアクセスする方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用して最初のスライドの参照を取得します。
1. [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList)タイプのSmartArt図形を追加します。
1. 追加したSmartArt図形にアクセスします。
1. アクセスしたSmartArt図形のインデックス0のノードにアクセスします。
1. 現在、アクセスポイントにおいて親ノードの位置1で[**子ノード**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--)を**get_Item()**メソッドを使用してアクセスします。
1. [**子ノード**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--)の位置、レベル、テキストの情報をアクセスして表示します。

```java
// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライドにSmartArt図形を追加
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // インデックス0のSmartArtノードにアクセス
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // 親ノードの位置1の子ノードにアクセス
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // SmartArt子ノードのパラメーターを印刷
    System.out.print("テキスト = " + chNode.getTextFrame().getText() + ", レベル = " + chNode.getLevel() + ", 位置 = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **JavaでPowerPointプレゼンテーションのSmartArtノードを削除する**
この例では、SmartArt図形の内部にノードを削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべての図形を走査します。
1. 図形が[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)タイプであるかを確認し、SmartArtである場合は選択した図形を[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)に型変換します。
1. [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)が0より多くのノードを持っているか確認します。
1. 削除対象のSmartArtノードを選択します。
1. 選択したノードを[**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)メソッドを使用して削除します。
1. プレゼンテーションを保存します。

```java
// 必要なプレゼンテーションをロードする
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 最初のスライド内のすべての図形を走査
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 図形がSmartArtタイプであるか確認
        if (shape instanceof ISmartArt) 
        {
            // 図形をSmartArtに型変換
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // インデックス0のSmartArtノードにアクセス
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // 選択したノードを削除します
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // プレゼンテーションを保存
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **特定の位置にSmartArtノードを削除する**
この例では、SmartArt図形の特定の位置にノードを削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべての図形を走査します。
1. 図形が[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)タイプであるかを確認し、SmartArtである場合は選択した図形を[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)に型変換します。
1. インデックス0のSmartArt形状ノードを選択します。
1. 選択したSmartArtノードが2つ以上の子ノードを持っているか確認します。
1. [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-)メソッドを使用して位置1のノードを削除します。
1. プレゼンテーションを保存します。

```java
// 必要なプレゼンテーションをロードする
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 最初のスライド内のすべての図形を走査
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 図形がSmartArtタイプであるか確認
        if (shape instanceof SmartArt) 
        {
            // 図形をSmartArtに型変換
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // インデックス0のSmartArtノードにアクセス
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // 位置1の子ノードを削除
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // プレゼンテーションを保存
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArtの子ノードにカスタム位置を設定する**
Aspose.Slides for Javaは、[SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape)の[X](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setX-float-)および[Y](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setY-float-)プロパティの設定をサポートします。以下のコードスニペットは、カスタムSmartArtShapeの位置、サイズ、回転を設定する方法を示しています。また、新しいノードを追加すると、すべてのノードの位置とサイズの再計算が発生することに注意してください。また、カスタム位置設定を使用すると、ユーザーは要件に応じてノードを設定できます。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt図形を新しい位置に移動
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // SmartArt図形の幅を変更
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // SmartArt図形の高さを変更
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // SmartArt図形の回転を変更
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **アシスタントノードを確認する**
{{% alert color="primary" %}} 

この記事では、Aspose.Slides for Javaを使用してプログラムでプレゼンテーションスライドに追加されたSmartArt図形の機能についてさらに調査します。

{{% /alert %}} 

以下のソースSmartArt図形を使用して、この記事の異なるセクションで調査を行います。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**図: スライド内のソースSmartArt図形**|

以下のサンプルコードでは、SmartArtノードコレクション内の**アシスタントノード**を特定し、それを変更する方法を調査します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
1. インデックスを使用して2番目のスライドの参照を取得します。
1. 最初のスライド内のすべての図形を走査します。
1. 図形が[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)タイプであるかを確認し、SmartArtである場合は選択した図形を[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)に型変換します。
1. SmartArt図形内のすべてのノードを走査し、それらが[**アシスタントノード**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#isAssistant--)であるかを確認します。
1. アシスタントノードの状態を通常のノードに変更します。
1. プレゼンテーションを保存します。

```java
// プレゼンテーションのインスタンスを作成
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // 最初のスライド内のすべての図形を走査
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 図形がSmartArtタイプであるか確認
        if (shape instanceof ISmartArt) 
        {
            // 図形をSmartArtに型変換
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt図形のすべてのノードを走査
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // ノードがアシスタントノードであるか確認
                if (node.isAssistant()) 
                {
                    // アシスタントノードをfalseに設定し、通常のノードにします
                    node.isAssistant();
                }
            }
        }
    }
    
    // プレゼンテーションを保存
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**図: SmartArt図形内のアシスタントノードが変更されました**|

## **ノードの塗りつぶし形式を設定する**
Aspose.Slides for Javaを使用すると、カスタムSmartArt図形を追加し、その塗りつぶし形式を設定できます。この記事では、Aspose.Slides for Javaを使用してSmartArt図形を作成し、アクセスし、塗りつぶし形式を設定する方法について説明します。

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)図形を追加し、その[**LayoutType**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess)を設定します。
1. SmartArt図形ノードの[**FillFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getFillFormat--)を設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

```java
// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();
try {
    // スライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt図形とノードを追加
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("テキストの一部");
    
    // ノードの塗りつぶし色を設定
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // プレゼンテーションを保存
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt子ノードのサムネイルを生成する**
開発者は、以下の手順に従ってSmartArtの子ノードのサムネイルを生成できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)を追加します。
1. インデックスを使用してノードの参照を取得します。
1. サムネイル画像を取得します。
1. 任意の形式でサムネイル画像を保存します。

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // SmartArtを追加
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // インデックスを使用してノードの参照を取得  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // サムネイルを取得
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // サムネイルを保存
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```