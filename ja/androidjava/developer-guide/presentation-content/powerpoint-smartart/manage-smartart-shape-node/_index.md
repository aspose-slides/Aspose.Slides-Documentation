---
title: Android でプレゼンテーションの SmartArt シェイプ ノードを管理する
linktitle: SmartArt シェイプ ノード
type: docs
weight: 30
url: /ja/androidjava/manage-smartart-shape-node/
keywords:
- SmartArt ノード
- 子ノード
- ノードの追加
- ノード位置
- ノードへのアクセス
- ノードの削除
- カスタム位置
- アシスタント ノード
- 塗りつぶし形式
- ノードのレンダリング
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PPT および PPTX の SmartArt シェイプ ノードを管理します。プレゼンテーションを効率化するための明確な Java コードサンプルとヒントをご覧ください。"
---
## **概要**

PowerPoint プレゼンテーションの SmartArt グラフィックは、テキストを含むノードによって構成され、図の構造を定義します。Aspose.Slides を使用すると、これらの SmartArt ノードをプログラムで操作できます。新しいノードや子ノードの追加、特定の位置への子ノードの挿入、既存ノードへのアクセス、テキスト、レベル、位置の取得が可能です。

本記事では SmartArt シェイプ ノードの管理方法を説明します。ノードの削除、インデックスまたは位置での子ノード操作、アシスタント ノードを通常ノードに変更、SmartArt ノード シェイプの位置・サイズ・回転の調整、ノードの塗りつぶし形式の設定、SmartArt ノードのサムネイル画像生成方法を示します。

## **SmartArt ノードの追加**
Aspose.Slides for Android via Java は、SmartArt シェイプを最も簡単に管理できる API を提供しています。以下のサンプルコードは、SmartArt シェイプ内にノードと子ノードを追加する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) 型か確認し、SmartArt の場合は選択したシェイプを [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) にキャストします。
5. [Add a new Node](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) を使用して SmartArt シェイプの [**NodeCollection**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) に新しいノードを追加し、TextFrame にテキストを設定します。
6. 今度は、[Add](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) を使用して新しく追加した [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) ノードに [**Child Node**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) を追加し、TextFrame にテキストを設定します。
7. プレゼンテーションを保存します。

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
            // シェイプを SmartArt にキャストします
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
以下のサンプルコードでは、SmartArt シェイプのそれぞれのノードに属する子ノードを特定の位置に追加する方法を説明します。

1. Presentation クラスのインスタンスを作成します。
2. インデックスを使用して最初のスライドの参照を取得します。
3. 取得したスライドに [**StackedList**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) タイプの [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArt) シェイプを追加します。
4. 追加した SmartArt シェイプの最初のノードにアクセスします。
5. 選択した [**Node**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArtNode) の位置 2 に [**Child Node**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) を追加し、テキストを設定します。
6. プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

// プレゼンテーション インスタンスを作成しています
Presentation pres = new Presentation();
try {
    // プレゼンテーションのスライドにアクセスします
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
以下のサンプルコードは、SmartArt シェイプ内のノードにアクセスする方法を示します。SmartArt の LayoutType はシェイプ追加時に選択され、**setLayout** で後から変更すると全体の図が再構築されるため、設定したノードの位置やサイズは再計算されますのでご注意ください。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) 型か確認し、SmartArt の場合は選択したシェイプを [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) にキャストします。
5. SmartArt シェイプ内のすべての [**Nodes**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArt#getAllNodes--) を走査します。
6. SmartArt ノードの位置、レベル、テキストなどの情報にアクセスして表示します。

```java
import com.aspose.slides.*;

// プレゼンテーション クラスのインスタンス化
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべてのシェイプを走査します
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプが SmartArt タイプか確認します
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArt にキャストします
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
以下のサンプルコードは、SmartArt シェイプのそれぞれのノードに属する子ノードにアクセスする方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) 型か確認し、SmartArt の場合は選択したシェイプを [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) にキャストします。
5. SmartArt シェイプ内のすべての [**Nodes**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArt#getAllNodes--) を走査します。
6. 各選択された SmartArt シェイプの [**Node**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArtNode) について、該当ノード内のすべての [**Child Nodes**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) を走査します。
7. 子ノードの位置、レベル、テキストなどの情報にアクセスして表示します。

```java
import com.aspose.slides.*;

// プレゼンテーション クラスのインスタンス化
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべてのシェイプを走査します
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプが SmartArt タイプか確認します
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArt にキャストします
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt 内のすべてのノードを走査します
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // インデックス i の SmartArt ノードにアクセスします
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // インデックス i の SmartArt ノードの子ノードを走査します
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
この例では、SmartArt シェイプのそれぞれのノードに属する子ノードを特定の位置で取得する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用して最初のスライドの参照を取得します。
3. [**StackedList**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) タイプの SmartArt シェイプを追加します。
4. 追加した SmartArt シェイプにアクセスします。
5. アクセスした SmartArt シェイプのインデックス 0 のノードにアクセスします。
6. **get_Item()** メソッドを使用して、アクセスした SmartArt ノードの位置 1 にある [**Child Node**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) にアクセスします。
7. 子ノードの位置、レベル、テキストなどの情報にアクセスして表示します。

```java
import com.aspose.slides.*;

// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライドに SmartArt シェイプを追加します
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // インデックス 0 の SmartArt ノードにアクセスします
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // 親ノードの位置 1 にある子ノードにアクセスします
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

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) 型か確認し、SmartArt の場合は選択したシェイプを [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) にキャストします。
5. [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) に 0 個より多くのノードがあるか確認します。
6. 削除対象の SmartArt ノードを選択します。
7. 選択したノードを [**RemoveNode**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) メソッドで削除します。
8. プレゼンテーションを保存します。

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
            // シェイプを SmartArt にキャストします
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
この例では、SmartArt シェイプ内のノードを特定の位置から削除する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) 型か確認し、SmartArt の場合は選択したシェイプを [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) にキャストします。
5. インデックス 0 の SmartArt シェイプ ノードを選択します。
6. 選択した SmartArt ノードに 2 個以上の子ノードがあるか確認します。
7. **Position 1** にあるノードを [**RemoveNode**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) メソッドで削除します。
8. プレゼンテーションを保存します。

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
            // シェイプを SmartArt にキャストします
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

## **SmartArt オブジェクト内の子ノードにカスタム位置を設定**
現在、Aspose.Slides for Android via Java は [SmartArtShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArtShape) の [X](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShape#setX-float-) および [Y](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShape#setY-float-) プロパティ設定をサポートしています。以下のコードスニペットは、カスタム位置、サイズ、回転を設定する方法を示します。新しいノードを追加するとすべてのノードの位置とサイズが再計算される点に注意してください。カスタム位置設定により、ユーザーは要件に合わせてノードを配置できます。

```java
import com.aspose.slides.*;

// プレゼンテーション クラスをインスタンス化
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

## **アシスタント ノードの確認**
{{% alert color="info" %}} 

本記事では、Aspose.Slides for Android via Java を使用してプレゼンテーション スライドにプログラムで追加された SmartArt シェイプの機能をさらに調査します。

{{% /alert %}} 

以下の表で使用するソース SmartArt シェイプを示します。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**図: スライド内の元の SmartArt シェイプ**|

以下のサンプルコードでは、SmartArt ノード コレクション内の **Assistant Nodes** を特定し、変更する方法を調査します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) 型か確認し、SmartArt の場合は選択したシェイプを [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) にキャストします。
5. SmartArt シェイプ内のすべてのノードを走査し、[**Assistant Nodes**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArtNode#isAssistant--) かどうかを確認します。
6. アシスタント ノードのステータスを通常ノードに変更します。
7. プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

// プレゼンテーション インスタンスを作成しています
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査します
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプが SmartArt タイプか確認します
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArt にキャストします
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt シェイプのすべてのノードを走査します
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // ノードがアシスタント ノードか確認します
                if (node.isAssistant()) 
                {
                    // アシスタント ノードを false に設定し、通常ノードにします
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
|**図: スライド内の SmartArt シェイプで変更されたアシスタント ノード**|

## **ノードの塗りつぶし形式を設定**
Aspose.Slides for Android via Java を使用すると、カスタム SmartArt シェイプを追加し、その塗りつぶし形式を設定できます。本記事では、SmartArt シェイプを作成・アクセスし、塗りつぶし形式を設定する手順を説明します。

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [**LayoutType**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) を指定して [SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArt) シェイプを追加します。
4. SmartArt シェイプ ノードの [**FillFormat**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShape#getFillFormat--) を設定します。
5. 修正したプレゼンテーションを書き出して PPTX ファイルとして保存します。

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーションをインスタンス化
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

## **SmartArt ノードのサムネイル生成**
開発者は以下の手順で SmartArt のノードのサムネイルを生成できます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Add SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) を実行します。
3. インデックスを使用してノードの参照を取得します。
4. サムネイル画像を取得します。
5. 任意の画像形式でサムネイル画像を保存します。

```java
import com.aspose.slides.*;

// PPTX ファイルを表す Presentation クラスをインスタンス化
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

### SmartArt アニメーションはサポートされていますか？

はい。SmartArt は通常のシェイプとして扱われるため、[標準アニメーション](/slides/ja/androidjava/shape-animation/)（出現、退出、強調、モーション パス）を適用したり、タイミングを調整したりできます。必要に応じて SmartArt ノード内のシェイプにもアニメーションを付けられます。

### スライド上の特定の SmartArt を内部 ID が不明な場合、確実に見つける方法は？

[代替テキスト](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getAlternativeText--) を設定して検索します。SmartArt に固有の AltText を付与すれば、内部識別子に依存せずにプログラム上で取得できます。

### プレゼンテーションを PDF に変換したとき、SmartArt の外観は維持されますか？

はい。Aspose.Slides は [PDF エクスポート](/slides/ja/androidjava/convert-powerpoint-to-pdf/) 時に SmartArt を高いビジュアル忠実度でレンダリングし、レイアウト、色、エフェクトを保持します。

### SmartArt 全体の画像を抽出してプレビューやレポートに使用できますか？

はい。SmartArt シェイプを [ラスタ形式](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) または [SVG](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) にレンダリングでき、サムネイル、レポート、Web 用にスケーラブルなベクタ出力として利用可能です。