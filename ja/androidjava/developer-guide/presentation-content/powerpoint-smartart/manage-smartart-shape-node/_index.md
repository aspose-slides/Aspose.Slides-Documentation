---
title: JavaでPowerPoint SmartArtシェイプノードを作成または管理する
linktitle: SmartArtシェイプノードを管理する
type: docs
weight: 30
url: /androidjava/manage-smartart-shape-node/
keywords: smartart powerpoint, smartart nodes, smartart position, remove smartart, smartart nodes add, powerpoint presentation, powerpoint java, powerpoint java api
description: JavaでPowerPointプレゼンテーション内のスマートアートノードと子ノードを管理する
---

## **Javaを使用してPowerPointプレゼンテーションにSmartArtノードを追加する**
Aspose.Slides for Android via Javaは、最も簡単な方法でSmartArtシェイプを管理するための最もシンプルなAPIを提供しています。以下のサンプルコードは、SmartArtシェイプ内にノードと子ノードを追加するのに役立ちます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成し、SmartArtシェイプでプレゼンテーションをロードします。
1. インデックスを使って最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをトラバースします。
1. シェイプが[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)タイプであるか確認し、SmartArtであれば選択したシェイプを[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)に型変換します。
1. SmartArtシェイプの[**NodeCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#getAllNodes--)に[新しいノードを追加](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)し、TextFrameにテキストを設定します。
1. 次に、新しく追加した[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)ノードに[**子ノード**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)を[追加](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)し、TextFrameにテキストを設定します。
1. プレゼンテーションを保存します。

```java
// 目的のプレゼンテーションをロードする
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライド内のすべてのシェイプをトラバースする
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプがSmartArtタイプであるか確認
        if (shape instanceof SmartArt) 
        {
            // シェイプをSmartArtに型変換
            SmartArt smart = (SmartArt) shape;
    
            // 新しいSmartArtノードを追加
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // テキストを追加
            TemNode.getTextFrame().setText("Test");
    
            // 親ノードに新しい子ノードを追加します。コレクションの最後に追加されます
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // テキストを追加
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // プレゼンテーションを保存
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **特定の位置にSmartArtノードを追加する**
以下のサンプルコードでは、特定の位置にSmartArtシェイプのそれぞれのノードに属する子ノードを追加する方法を説明します。

1. Presentationクラスのインスタンスを作成します。
1. インデックスを使って最初のスライドの参照を取得します。
1. アクセスしたスライドに[**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)タイプの[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)シェイプを追加します。
1. 追加したSmartArtシェイプ内の最初のノードにアクセスします。
1. 次に、選択した[**ノード**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode)の位置2に[**子ノード**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)を追加し、そのテキストを設定します。
1. プレゼンテーションを保存します。

```java
// プレゼンテーションインスタンスを作成
Presentation pres = new Presentation();
try {
    // プレゼンテーションスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShapeを追加
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // 追加したSmartArtシェイプのインデックス0のノードにアクセス
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // 親ノードの位置2に新しい子ノードを追加
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // テキストを追加
    chNode.getTextFrame().setText("Sample Text Added");

    // プレゼンテーションを保存
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Javaを使ってPowerPointプレゼンテーション内のSmartArtノードにアクセスする**
以下のサンプルコードは、SmartArtシェイプ内のノードにアクセスするのに役立ちます。SmartArtのLayoutTypeは読み取り専用であり、SmartArtシェイプが追加されたときだけ設定されることに注意してください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成し、SmartArtシェイプでプレゼンテーションをロードします。
1. インデックスを使って最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをトラバースします。
1. シェイプが[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)タイプであるか確認し、SmartArtであれば選択したシェイプを[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)に型変換します。
1. SmartArtシェイプ内のすべての[**ノード**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--)をトラバースします。
1. SmartArtノードの位置、レベル、テキストのような情報にアクセスして表示します。

```java
// プレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべてのシェイプをトラバース
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプがSmartArtタイプであるか確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプをSmartArtに型変換
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt内のすべてのノードをトラバース
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // インデックスiのSmartArtノードにアクセス
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // SmartArtノードのパラメータを印刷
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt子ノードにアクセスする**
以下のサンプルコードは、SmartArtシェイプのそれぞれのノードに属する子ノードにアクセスするのに役立ちます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成し、SmartArtシェイプでプレゼンテーションをロードします。
1. インデックスを使って最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをトラバースします。
1. シェイプが[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)タイプであるか確認し、SmartArtであれば選択したシェイプを[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)に型変換します。
1. SmartArtシェイプ内のすべての[**ノード**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--)をトラバースします。
1. 選択したSmartArtシェイプの[**ノード**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode)について、特定のノード内のすべての[**子ノード**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--)をトラバースします。
1. [**子ノード**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)の位置、レベル、テキストのような情報にアクセスして表示します。

```java
// プレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべてのシェイプをトラバース
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプがSmartArtタイプであるか確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプをSmartArtに型変換
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt内のすべてのノードをトラバース
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // インデックスiのSmartArtノードにアクセス
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // インデックスiのSmartArtノード内の子ノードをトラバース
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // SmartArtノード内の子ノードにアクセス
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // SmartArt子ノードのパラメータを印刷
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **特定の位置のSmartArt子ノードにアクセスする**
この例では、SmartArtシェイプのそれぞれのノードに属する特定の位置にある子ノードにアクセスする方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使って最初のスライドの参照を取得します。
1. [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)タイプのSmartArtシェイプを追加します。
1. 追加したSmartArtシェイプにアクセスします。
1. アクセスしたSmartArtシェイプのインデックス0でノードにアクセスします。
1. 次に、**get_Item()**メソッドを使用してアクセスしたSmartArtノードで位置1の[**子ノード**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)にアクセスします。
1. [**子ノード**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)の位置、レベル、テキストのような情報にアクセスして表示します。

```java
// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライドにSmartArtシェイプを追加
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // インデックス0のSmartArtノードにアクセス
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // 親ノードの位置1の子ノードにアクセス
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // SmartArt子ノードのパラメータを印刷
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Javaを使ってPowerPointプレゼンテーション内のSmartArtノードを削除する**
この例では、SmartArtシェイプ内のノードを削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成し、SmartArtシェイプでプレゼンテーションをロードします。
1. インデックスを使って最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをトラバースします。
1. シェイプが[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)タイプであるか確認し、SmartArtであれば選択したシェイプを[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)に型変換します。
1. [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)が0ノード以上を持っているか確認します。
1. 削除するSmartArtノードを選択します。
1. 選択したノードを[**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)メソッドを使って削除します。
1. プレゼンテーションを保存します。

```java
// 目的のプレゼンテーションをロードする
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 最初のスライド内のすべてのシェイプをトラバースする
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプがSmartArtタイプであるか確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプをSmartArtに型変換
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // インデックス0のSmartArtノードにアクセス
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // 選択したノードを削除
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

## **特定の位置でSmartArtノードを削除する**
この例では、特定の位置のSmartArtシェイプ内のノードを削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成し、SmartArtシェイプでプレゼンテーションをロードします。
1. インデックスを使って最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをトラバースします。
1. シェイプが[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)タイプであるか確認し、SmartArtであれば選択したシェイプを[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)に型変換します。
1. インデックス0のSmartArtシェイプノードを選択します。
1. 次に、選択したSmartArtノードが2つ以上の子ノードを持っているか確認します。
1. **位置1**でノードを削除し、[**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-)メソッドを使用します。
1. プレゼンテーションを保存します。

```java
// 目的のプレゼンテーションをロードする
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 最初のスライド内のすべてのシェイプをトラバースする
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプがSmartArtタイプであるか確認
        if (shape instanceof SmartArt) 
        {
            // シェイプをSmartArtに型変換
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

## **SmartArt内の子ノードのカスタム位置を設定する**
Aspose.Slides for Android via Javaでは、[SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape)の[X](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setX-float-)および[Y](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setY-float-)プロパティを設定することがサポートされています。以下のコードスニペットでは、カスタムSmartArtShapeの位置、サイズ、回転を設定する方法を示しています。また、新しいノードを追加すると、すべてのノードの位置とサイズが再計算されることにも注意してください。カスタム位置設定により、ユーザーは要件に応じてノードを設定できます。

```java
// プレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArtシェイプを新しい位置に移動
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // SmartArtシェイプの幅を変更
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // SmartArtシェイプの高さを変更
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // SmartArtシェイプの回転を変更
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **アシスタントノードをチェックする**
{{% alert color="primary" %}} 

この記事では、Aspose.Slides for Android via Javaを使用してプログラムでプレゼンテーションスライドに追加されたSmartArtシェイプの機能をさらに調査します。

{{% /alert %}} 

以下のソースSmartArtシェイプを使って、この記事の異なるセクションで調査を行います。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**図: スライド内のソースSmartArtシェイプ**|

以下のサンプルコードでは、SmartArtノードコレクション内の**アシスタントノード**を識別し、それを変更する方法を調査します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成し、SmartArtシェイプでプレゼンテーションをロードします。
1. インデックスを使って2番目のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをトラバースします。
1. シェイプが[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)タイプであるか確認し、SmartArtであれば選択したシェイプを[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)に型変換します。
1. SmartArtシェイプ内のすべてのノードをトラバースし、それらが[**アシスタントノード**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#isAssistant--)かどうかを確認します。
1. アシスタントノードのステータスを通常のノードに変更します。
1. プレゼンテーションを保存します。

```java
// プレゼンテーションインスタンスを作成
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // 最初のスライド内のすべてのシェイプをトラバースする
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプがSmartArtタイプであるか確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプをSmartArtに型変換
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArtシェイプのすべてのノードをトラバース
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // ノードがアシスタントノードか確認
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
|**図: スライド内のSmartArtシェイプで変更されたアシスタントノード**|

## **ノードの塗りつぶし形式を設定する**
Aspose.Slides for Android via Javaでは、カスタムSmartArtシェイプを追加し、その塗りつぶし形式を設定することが可能です。このセクションでは、Aspose.Slides for Android via Javaを使用してSmartArtシェイプを作成およびアクセスし、その塗りつぶし形式を設定する方法を説明します。

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使ってスライドの参照を取得します。
1. [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)シェイプを[**LayoutType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess)を設定して追加します。
1. SmartArtシェイプノードの[**FillFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getFillFormat--)を設定します。
1. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

```java
// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();
try {
    // スライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArtシェイプとノードを追加
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
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

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)を追加します。
1. インデックスを使ってノードの参照を取得します。
1. サムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```java
// PPTXファイルを表すプレゼンテーションクラスをインスタンス化
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