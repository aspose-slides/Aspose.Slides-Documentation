---
title: Android のプレゼンテーションで SmartArt シェイプノードを管理
linktitle: SmartArt シェイプノード
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
- アシスタントノード
- 塗りつぶし形式
- ノードのレンダリング
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PPT および PPTX の SmartArt シェイプノードを管理します。明確な Java コードサンプルとヒントでプレゼンテーションを効率化しましょう。"
---

## **SmartArt ノードの追加**
Aspose.Slides for Android via Java は、SmartArt シェイプを最も簡単に管理できる API を提供しています。以下のサンプルコードは、SmartArt シェイプ内にノードと子ノードを追加する方法を示します。

1. SmartArt シェイプを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. 最初のスライド内のすべてのシェイプを走査します。  
4. シェイプが [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) 型であるか確認し、SmartArt であれば選択したシェイプを [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) にキャストします。  
5. SmartArt シェイプの [**NodeCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) に **新しいノードを追加**([Add a new Node](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--))し、TextFrame にテキストを設定します。  
6. 新しく追加した SmartArt ノードに **子ノード**([Add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)) を追加し、TextFrame にテキストを設定します。  
7. プレゼンテーションを保存します。  
```java
// 必要なプレゼンテーションを読み込む
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプが SmartArt タイプか確認
        if (shape instanceof SmartArt) 
        {
            // シェイプを SmartArt に型キャスト
            SmartArt smart = (SmartArt) shape;
    
            // 新しい SmartArt ノードを追加
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // テキストを設定
            TemNode.getTextFrame().setText("Test");
    
            // 親ノードに新しい子ノードを追加。コレクションの末尾に追加されます
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // テキストを設定
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // プレゼンテーションを保存
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **特定の位置に SmartArt ノードを追加**
以下のサンプルコードでは、SmartArt シェイプの各ノードに属する子ノードを特定の位置に追加する方法を説明します。

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. アクセスしたスライドに [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) タイプの [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) シェイプを追加します。  
4. 追加した SmartArt シェイプの最初のノードにアクセスします。  
5. 選択した **ノード**([**Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode)) の位置 2 に **子ノード**([**Child Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)) を追加し、テキストを設定します。  
6. プレゼンテーションを保存します。  
```java
// プレゼンテーション インスタンスを作成
Presentation pres = new Presentation();
try {
    // プレゼンテーション スライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape を追加
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // インデックス 0 の SmartArt ノードにアクセス
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // 親ノードの位置 2 に新しい子ノードを追加
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // テキストを追加
    chNode.getTextFrame().setText("Sample Text Added");

    // プレゼンテーションを保存
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **SmartArt ノードへのアクセス**
以下のサンプルコードは、SmartArt シェイプ内のノードにアクセスする方法を示します。SmartArt の LayoutType は読み取り専用で、SmartArt シェイプを追加したときにのみ設定されることに注意してください。

1. SmartArt シェイプを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. 最初のスライド内のすべてのシェイプを走査します。  
4. シェイプが [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) 型であるか確認し、SmartArt であれば選択したシェイプを [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) にキャストします。  
5. SmartArt シェイプ内のすべての [**Nodes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) を走査します。  
6. SmartArt ノードの位置、レベル、テキストなどの情報にアクセスして表示します。  
```java
// プレゼンテーション クラスをインスタンス化
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべてのシェイプを走査
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプが SmartArt タイプか確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArt に型キャスト
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt 内のすべてのノードを走査
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // インデックス i の SmartArt ノードにアクセス
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // SmartArt ノードのパラメータを出力
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

1. SmartArt シェイプを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. 最初のスライド内のすべてのシェイプを走査します。  
4. シェイプが [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) 型であるか確認し、SmartArt であれば選択したシェイプを [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) にキャストします。  
5. SmartArt シェイプ内のすべての [**Nodes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) を走査します。  
6. 各選択した SmartArt シェイプの [**Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode) について、該当ノード内のすべての [**Child Nodes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) を走査します。  
7. 子ノードの位置、レベル、テキストなどの情報にアクセスして表示します。  
```java
// プレゼンテーション クラスをインスタンス化
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべてのシェイプを走査
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプが SmartArt タイプか確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArt に型キャスト
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt 内のすべてのノードを走査
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // インデックス i の SmartArt ノードにアクセス
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // インデックス i の SmartArt ノード内の子ノードを走査
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // SmartArt ノードの子ノードにアクセス
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // SmartArt 子ノードのパラメータを出力
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
この例では、SmartArt シェイプの各ノードに属する子ノードを特定の位置で取得する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) タイプの SmartArt シェイプを追加します。  
4. 追加した SmartArt シェイプにアクセスします。  
5. インデックス 0 のノードにアクセスします。  
6. **get_Item()** メソッドを使用して、取得した SmartArt ノードの位置 1 にある **子ノード**([**Child Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)) にアクセスします。  
7. 子ノードの位置、レベル、テキストなどの情報にアクセスして表示します。  
```java
// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライドに SmartArt シェイプを追加
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // インデックス 0 の SmartArt ノードにアクセス
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // 親ノードの位置 1 にある子ノードにアクセス
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // SmartArt 子ノードのパラメータを出力
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```


## **SmartArt ノードの削除**
この例では、SmartArt シェイプ内のノードを削除する方法を学びます。

1. SmartArt シェイプを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. 最初のスライド内のすべてのシェイプを走査します。  
4. シェイプが [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) 型であるか確認し、SmartArt であれば選択したシェイプを [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) にキャストします。  
5. SmartArt にノードが 0 以上あるか確認します。  
6. 削除対象の SmartArt ノードを選択します。  
7. [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) メソッドを使用して選択したノードを削除します。  
8. プレゼンテーションを保存します。  
```java
// 必要なプレゼンテーションを読み込む
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプが SmartArt タイプか確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArt に型キャスト
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // インデックス 0 の SmartArt ノードにアクセス
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


## **特定の位置にある SmartArt ノードの削除**
この例では、SmartArt シェイプ内のノードを特定の位置で削除する方法を学びます。

1. SmartArt シェイプを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. 最初のスライド内のすべてのシェイプを走査します。  
4. シェイプが [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) 型であるか確認し、SmartArt であれば選択したシェイプを [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) にキャストします。  
5. インデックス 0 の SmartArt シェイプノードを選択します。  
6. 選択した SmartArt ノードに 2 つ以上の子ノードがあるか確認します。  
7. **位置 1** のノードを [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) メソッドで削除します。  
8. プレゼンテーションを保存します。  
```java
// 目的のプレゼンテーションを読み込む
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプが SmartArt タイプか確認
        if (shape instanceof SmartArt) 
        {
            // シェイプを SmartArt に型キャスト
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // インデックス 0 の SmartArt ノードにアクセス
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // 位置 1 の子ノードを削除
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


## **SmartArt オブジェクトの子ノードにカスタム位置を設定**
現在、Aspose.Slides for Android via Java は [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) の [X](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setX-float-) および [Y](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setY-float-) プロパティの設定をサポートしています。以下のコードスニペットは、カスタム位置、サイズ、回転を設定する方法を示します。新しいノードを追加すると、すべてのノードの位置とサイズが再計算されることに注意してください。カスタム位置設定により、要件に合わせてノードを配置できます。  
```java
// プレゼンテーション クラスをインスタンス化
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt シェイプを新しい位置に移動
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // SmartArt シェイプの幅を変更
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // SmartArt シェイプの高さを変更
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // SmartArt シェイプの回転を変更
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```


## **アシスタント ノードのチェック**
{{% alert color="primary" %}} 

この記事では、Aspose.Slides for Android via Java を使用してプログラムでプレゼンテーションスライドに追加された SmartArt シェイプの機能をさらに調査します。

{{% /alert %}} 

以下のソース SmartArt シェイプを使用して、この記事の各セクションで調査を行います。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**図: スライド内のソース SmartArt シェイプ**|

以下のサンプルコードでは、SmartArt ノード コレクション内の **Assistant Nodes** を特定し、変更する方法を調べます。

1. SmartArt シェイプを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して 2 番目のスライドの参照を取得します。  
3. 最初のスライド内のすべてのシェイプを走査します。  
4. シェイプが [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) 型であるか確認し、SmartArt であれば選択したシェイプを [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) にキャストします。  
5. SmartArt シェイプ内のすべてのノードを走査し、[**Assistant Nodes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#isAssistant--) であるか確認します。  
6. アシスタント ノードのステータスを通常ノードに変更します。  
7. プレゼンテーションを保存します。  
```java
// プレゼンテーション インスタンスを作成
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // シェイプが SmartArt タイプか確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArt に型キャスト
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt シェイプのすべてのノードを走査
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // ノードがアシスタントノードか確認
                if (node.isAssistant()) 
                {
                    // アシスタントノードを false に設定し、通常ノードに変更
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
|**図: スライド内の SmartArt シェイプで変更されたアシスタント ノード**|

## **ノードの塗りつぶし形式の設定**
Aspose.Slides for Android via Java は、カスタム SmartArt シェイプを追加し、その塗りつぶし形式を設定できるようにしました。本記事では、SmartArt シェイプを作成およびアクセスし、塗りつぶし形式を設定する方法を説明します。

以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. [**LayoutType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) を設定して [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) シェイプを追加します。  
4. SmartArt シェイプのノードに対して [**FillFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getFillFormat--) を設定します。  
5. 変更したプレゼンテーションを PPTX ファイルとして書き出します。  
```java
// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();
try {
    // スライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt シェイプとノードを追加
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


## **SmartArt 子ノードのサムネイル生成**
開発者は以下の手順に従って、SmartArt の子ノードのサムネイルを生成できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. [SmartArt を追加](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)します。  
3. インデックスを使用してノードの参照を取得します。  
4. サムネイル画像を取得します。  
5. 任意の画像形式でサムネイル画像を保存します。  
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // SmartArt を追加
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


## **FAQ**

**SmartArt のアニメーションはサポートされていますか？**

はい。SmartArt は通常のシェイプとして扱われるため、[標準アニメーション](/slides/ja/androidjava/shape-animation/)（入場、退出、強調、モーション パス）を適用したり、タイミングを調整したりできます。必要に応じて SmartArt ノード内のシェイプにもアニメーションを付与できます。

**スライド内の特定の SmartArt を内部 ID が不明な場合、確実に見つける方法は？**

[代替テキスト](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getAlternativeText--) を設定して検索します。SmartArt に固有の AltText を付与すれば、内部識別子に依存せずにプログラムで取得できます。

**プレゼンテーションを PDF に変換した際、SmartArt の外観は保持されますか？**

はい。Aspose.Slides は [PDF エクスポート](/slides/ja/androidjava/convert-powerpoint-to-pdf/) 時に SmartArt を高い視覚的忠実度でレンダリングし、レイアウト、色、エフェクトを保持します。

**SmartArt 全体の画像を抽出してプレビューやレポートに使用できますか？**

はい。SmartArt シェイプを [ラスタ形式](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) または [SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) にレンダリングできるため、サムネイル、レポート、Web 用に適した形式で取得可能です。