---
title: Java を使用したプレゼンテーションの SmartArt シェイプノードの管理
linktitle: SmartArt シェイプノード
type: docs
weight: 30
url: /ja/java/manage-smartart-shape-node/
keywords:
- SmartArt ノード
- 子ノード
- ノードの追加
- ノード位置
- ノードへのアクセス
- ノードの削除
- カスタム位置
- アシスタントノード
- 塗りつぶし形式
- ノードのレンダリング
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PPT および PPTX の SmartArt シェイプノードを管理します。分かりやすいコードサンプルとヒントでプレゼンテーションを効率化しましょう。"
---
## **概要**

PowerPoint プレゼンテーションの SmartArt グラフィックは、テキストを含むノードによって構成され、図の構造を定義します。Aspose.Slides を使用すると、これらの SmartArt ノードをプログラムで操作できます。新しいノードや子ノードの追加、特定の位置への子ノードの挿入、既存ノードへのアクセス、テキスト、レベル、位置の取得が可能です。

この記事では、SmartArt シェイプのノード管理方法を説明します。ノードの削除、インデックスや位置による子ノードの操作、アシスタントノードを通常ノードに変更、SmartArt ノードシェイプの位置・サイズ・回転の調整、ノードの塗りつぶし形式の設定、SmartArt 子ノードのサムネイル画像生成方法を示します。

## **SmartArt ノードの追加**
Aspose.Slides for Java は、SmartArt シェイプを最も簡単に管理できる API を提供しています。以下のサンプルコードは、SmartArt シェイプ内にノードと子ノードを追加する方法を示します。

1. Presentation クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
1. [Add a new Node](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) を SmartArt シェイプの [**NodeCollection**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArt#getAllNodes--) に追加し、TextFrame にテキストを設定します。
1. 次に、[Add](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) で新しく追加した [SmartArt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArt) ノードに [**Child Node**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArtNode#getChildNodes--) を追加し、TextFrame にテキストを設定します。
1. プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

// 目的のプレゼンテーションをロードします
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査します
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプが SmartArt タイプか確認します
        if (shape instanceof SmartArt) 
        {
            // シェイプを SmartArt に型変換します
            SmartArt smart = (SmartArt) shape;
    
            // 新しい SmartArt ノードを追加します
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // テキストを追加します
            TemNode.getTextFrame().setText("Test");
    
            // 親ノードに新しい子ノードを追加します。コレクションの末尾に追加されます
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // テキストを追加します
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // プレゼンテーションを保存します
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **特定の位置に SmartArt ノードを追加**
以下のサンプルコードでは、SmartArt シェイプの各ノードに属する子ノードを特定の位置に追加する方法を説明しています。

1. Presentation クラスのインスタンスを作成します。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 取得したスライドに、[**StackedList**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArtLayoutType#StackedList) タイプの [SmartArt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArt) シェイプを追加します。
1. 追加した SmartArt シェイプの最初のノードにアクセスします。
1. 次に、選択した [**Node**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArtNode) の位置 2 に [**Child Node**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArtNode#getChildNodes--) を追加し、テキストを設定します。
1. プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

// プレゼンテーション インスタンスを作成します
Presentation pres = new Presentation();
try {
    // プレゼンテーション スライドにアクセスします
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape を追加します
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // インデックス 0 の SmartArt ノードにアクセスします
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // 親ノードの位置 2 に新しい子ノードを追加します
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // テキストを追加します
    chNode.getTextFrame().setText("Sample Text Added");

    // プレゼンテーションを保存します
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt ノードへのアクセス**
以下のサンプルコードは、SmartArt シェイプ内のノードにアクセスする方法を示します。SmartArt の LayoutType は読み取り専用で、SmartArt シェイプを追加したときにのみ設定されるため、変更できないことに注意してください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
1. SmartArt シェイプ内のすべての [**Nodes**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArt#getAllNodes--) を走査します。
1. SmartArt ノードの位置、レベル、テキストなどの情報にアクセスして表示します。

```java
import com.aspose.slides.*;

// プレゼンテーション クラスのインスタンスを作成します
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // 最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべてのシェイプを走査します
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプが SmartArt タイプか確認します
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArt に型変換します
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt 内のすべてのノードを走査します
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // インデックス i の SmartArt ノードにアクセスします
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // SmartArt ノードのパラメータを出力します
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt 子ノードへのアクセス**
以下のサンプルコードは、SmartArt シェイプの各ノードに属する子ノードにアクセスする方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
1. SmartArt シェイプ内のすべての [**Nodes**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArt#getAllNodes--) を走査します。
1. 選択した SmartArt シェイプの各 [**Node**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArtNode) について、該当ノード内のすべての [**Child Nodes**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArtNode#getChildNodes--) を走査します。
1. [**Child Node**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArtNode#getChildNodes--) の位置、レベル、テキストなどの情報にアクセスして表示します。

```java
import com.aspose.slides.*;

// プレゼンテーション クラスのインスタンスを作成します
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // 最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべてのシェイプを走査します
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプが SmartArt タイプか確認します
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArt に型変換します
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt 内のすべてのノードを走査します
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // インデックス i の SmartArt ノードにアクセスします
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // インデックス i の SmartArt ノード内の子ノードを走査します
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // SmartArt ノードの子ノードにアクセスします
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // SmartArt 子ノードのパラメータを出力します
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **特定の位置にある SmartArt 子ノードへのアクセス**
この例では、SmartArt シェイプの各ノードに属する子ノードの特定の位置にアクセスする方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用して最初のスライドの参照を取得します。
1. [**StackedList**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArtLayoutType#StackedList) タイプの SmartArt シェイプを追加します。
1. 追加した SmartArt シェイプにアクセスします。
1. インデックス 0 のノードにアクセスします。
1. 次に、**get_Item()** メソッドを使用して、アクセスした SmartArt ノードの位置 1 にある [**Child Node**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArtNode#getChildNodes--) にアクセスします。
1. [**Child Node**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArtNode#getChildNodes--) の位置、レベル、テキストなどの情報にアクセスして表示します。

```java
import com.aspose.slides.*;

// プレゼンテーションのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライドに SmartArt シェイプを追加します
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // インデックス 0 の SmartArt ノードにアクセスします
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // 親ノードの位置 1 の子ノードにアクセスします
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // SmartArt 子ノードのパラメータを出力します
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt ノードの削除**
この例では、SmartArt シェイプ内のノードを削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
1. SmartArt に 0 以上のノードがあるか確認します。
1. 削除する SmartArt ノードを選択します。
1. [**RemoveNode**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) メソッドを使用して選択したノードを削除します。
1. プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

// 目的のプレゼンテーションをロードします
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査します
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプが SmartArt タイプか確認します
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArt に型変換します
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // インデックス 0 の SmartArt ノードにアクセスします
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // 選択したノードを削除します
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // プレゼンテーションを保存します
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **特定の位置から SmartArt ノードを削除**
この例では、SmartArt シェイプ内の特定の位置にあるノードを削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
1. インデックス 0 の SmartArt シェイプノードを選択します。
1. 選択した SmartArt ノードに 2 つ以上の子ノードがあるか確認します。
1. [**RemoveNode**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) メソッドを使用して、位置 **1** のノードを削除します。
1. プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

// 目的のプレゼンテーションをロードします
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査します
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプが SmartArt タイプか確認します
        if (shape instanceof SmartArt) 
        {
            // シェイプを SmartArt に型変換します
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // インデックス 0 の SmartArt ノードにアクセスします
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // 位置 1 の子ノードを削除します
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // プレゼンテーションを保存します
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt オブジェクト内の子ノードのカスタム位置設定**
現在、Aspose.Slides for Java は [SmartArtShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArtShape) の [X](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShape#setX-float-) および [Y](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShape#setY-float-) プロパティの設定をサポートしています。以下のコードスニペットは、SmartArtShape のカスタム位置、サイズ、回転を設定する方法を示します。また、新しいノードを追加するとすべてのノードの位置とサイズが再計算されることに注意してください。カスタム位置設定により、ユーザーは要件に合わせてノードを配置できます。

```java
import com.aspose.slides.*;

// プレゼンテーション クラスのインスタンスを作成します
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt シェイプを新しい位置に移動します
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // SmartArt シェイプの幅を変更します
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // SmartArt シェイプの高さを変更します
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // SmartArt シェイプの回転を変更します
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **アシスタントノードの確認**
{{% alert color="info" %}} 
この記事では、Aspose.Slides for Java を使用してプログラムでプレゼンテーション スライドに追加された SmartArt シェイプの機能をさらに検証します。  
{{% /alert %}} 

本稿では、以下のソース SmartArt シェイプを使用して各セクションを検証します。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**図: スライド内の元の SmartArt シェイプ**|

以下のサンプルコードでは、SmartArt ノードコレクション内の **Assistant Nodes** を特定し、それらを変更する方法を調査します。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して2番目のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
1. SmartArt シェイプ内のすべてのノードを走査し、[**Assistant Nodes**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArtNode#isAssistant--) かどうかを確認します。
1. アシスタントノードのステータスを通常ノードに変更します。
1. プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

// プレゼンテーション インスタンスを作成します
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査します
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプが SmartArt タイプか確認します
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArt に型変換します
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt シェイプのすべてのノードを走査します
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // ノードがアシスタントノードか確認します
                if (node.isAssistant()) 
                {
                    // アシスタントノードを false に設定し、通常ノードにします
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // プレゼンテーションを保存します
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**図: スライド内の SmartArt シェイプで変更されたアシスタントノード**|

## **ノードの塗りつぶし形式の設定**
Aspose.Slides for Java を使用すると、カスタム SmartArt シェイプを追加し、その塗りつぶし形式を設定できます。この記事では、SmartArt シェイプの作成とアクセス、および Aspose.Slides for Java を使用した塗りつぶし形式の設定方法を解説します。

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [**LayoutType**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) を設定して SmartArt シェイプを追加します。
1. SmartArt シェイプノードの [**FillFormat**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShape#getFillFormat--) を設定します。
1. 変更したプレゼンテーションを書き出して PPTX ファイルとして保存します。

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーションのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // スライドにアクセスします
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt シェイプとノードを追加します
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // ノードの塗りつぶし色を設定します
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // プレゼンテーションを保存します
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt 子ノードのサムネイル生成**
開発者は以下の手順で SmartArt の子ノードのサムネイルを生成できます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Add SmartArt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) を実行します。
1. インデックスを使用してノードの参照を取得します。
1. サムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```java
import com.aspose.slides.*;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // SmartArt を追加します
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // インデックスを使用してノードの参照を取得します  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // サムネイルを取得します
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // サムネイルを保存します
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### SmartArt のアニメーションはサポートされていますか？

はい。SmartArt は通常のシェイプとして扱われるため、[標準のアニメーション](/slides/ja/java/shape-animation/)（出現、退出、強調、動きパス）を適用したり、タイミングを調整したりできます。必要に応じて SmartArt ノード内のシェイプにもアニメーションを付けることが可能です。

### 内部 ID が不明な場合、スライド上の特定の SmartArt を確実に見つける方法は？

[代替テキスト](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getAlternativeText--) を設定して検索します。SmartArt に特徴的な AltText を付与すれば、内部識別子に依存せずにプログラムで見つけられます。

### プレゼンテーションを PDF に変換するとき、SmartArt の外観は保持されますか？

はい。Aspose.Slides は [PDF エクスポート](/slides/ja/java/convert-powerpoint-to-pdf/) 時に SmartArt を高い視覚忠実度でレンダリングし、レイアウト・色・効果を保持します。

### SmartArt 全体の画像（プレビューやレポート用）を抽出できますか？

はい。SmartArt シェイプを [ラスタ形式](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getImage-int-float-float-) または [SVG](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) にレンダリングでき、サムネイルやレポート、Web 用にスケーラブルなベクトル出力として利用できます。