---
title: JavaScript で PowerPoint SmartArt シェイプノードを作成または管理
linktitle: SmartArt シェイプノードの管理
type: docs
weight: 30
url: /ja/nodejs-java/manage-smartart-shape-node/
keywords: SmartArt PowerPoint, SmartArt ノード, SmartArt の位置, SmartArt の削除, SmartArt ノードの追加, PowerPoint プレゼンテーション, PowerPoint Java, PowerPoint JavaScript API
description: JavaScript で PowerPoint プレゼンテーションの SmartArt ノードと子ノードを管理
---

## **JavaScript を使用した PowerPoint プレゼンテーションへの SmartArt ノードの追加**
Aspose.Slides for Node.js via Java は、SmartArt シェイプを最も簡単に管理できる API を提供しています。以下のサンプルコードは、SmartArt シェイプ内にノードと子ノードを追加する方法を示します。

1. SmartArt シェイプを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. 最初のスライド内のすべてのシェイプを走査します。  
4. シェイプが [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 型か確認し、SmartArt であれば [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) に型キャストします。  
5. SmartArt シェイプの **NodeCollection** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) に新しいノードを [Add a new Node](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) し、TextFrame にテキストを設定します。  
6. 追加した [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) ノードに対して、[**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) を [Add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) し、TextFrame にテキストを設定します。  
7. プレゼンテーションを保存します。  
```javascript
// 必要なプレゼンテーションをロードします
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査します
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // シェイプが SmartArt タイプか確認します
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // シェイプを SmartArt に型キャストします
            var smart = shape;
            // 新しい SmartArt ノードを追加します
            var TemNode = smart.getAllNodes().addNode();
            // テキストを追加します
            TemNode.getTextFrame().setText("Test");
            // 親ノードに新しい子ノードを追加します。コレクションの末尾に追加されます
            var newNode = TemNode.getChildNodes().addNode();
            // テキストを追加します
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // プレゼンテーションを保存します
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **特定の位置に SmartArt ノードを追加**
以下のサンプルコードでは、SmartArt シェイプの各ノードに属する子ノードを任意の位置に追加する方法を説明します。

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. アクセスしたスライドに [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) タイプの [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) シェイプを追加します。  
4. 追加した SmartArt シェイプの最初のノードにアクセスします。  
5. 選択した **Node** の位置 2 に [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) を追加し、テキストを設定します。  
6. プレゼンテーションを保存します。  
```javascript
// プレゼンテーション インスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションのスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // SmartArt IShape を追加
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // インデックス 0 の SmartArt ノードにアクセス
    var node = smart.getAllNodes().get_Item(0);
    // 親ノードの位置 2 に新しい子ノードを追加
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // テキストを追加
    chNode.getTextFrame().setText("Sample Text Added");
    // プレゼンテーションを保存
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **JavaScript を使用した PowerPoint プレゼンテーションの SmartArt ノードへのアクセス**
以下のサンプルコードは、SmartArt シェイプ内のノードにアクセスする方法を示します。SmartArt の LayoutType は読み取り専用で、SmartArt シェイプを追加したときにのみ設定される点に注意してください。

1. SmartArt シェイプを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. 最初のスライド内のすべてのシェイプを走査します。  
4. シェイプが [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 型か確認し、SmartArt であれば [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) に型キャストします。  
5. SmartArt シェイプ内のすべての **Nodes** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) を走査します。  
6. SmartArt ノードの位置、レベル、テキストなどの情報を取得して表示します。  
```javascript
// プレゼンテーション クラスをインスタンス化
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // 最初のスライドを取得
    var slide = pres.getSlides().get_Item(0);
    // 最初のスライド内のすべてのシェイプを走査
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // シェイプが SmartArt タイプか確認
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // シェイプを SmartArt に型キャスト
            var smart = shape;
            // SmartArt 内のすべてのノードを走査
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // インデックス i の SmartArt ノードにアクセス
                var node = smart.getAllNodes().get_Item(j);
                // SmartArt ノードのパラメータを出力
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt 子ノードへのアクセス**
以下のサンプルコードは、SmartArt シェイプ内の各ノードに属する子ノードにアクセスする方法を示します。

1. SmartArt シェイプを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. 最初のスライド内のすべてのシェイプを走査します。  
4. シェイプが [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 型か確認し、SmartArt であれば [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) に型キャストします。  
5. SmartArt シェイプ内のすべての **Nodes** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) を走査します。  
6. 各選択された SmartArt **Node** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode) に対し、特定ノード内のすべての **Child Nodes** (https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) を走査します。  
7. 子ノードの位置、レベル、テキストなどの情報を取得して表示します。  
```javascript
// プレゼンテーション クラスをインスタンス化
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // 最初のスライドを取得
    var slide = pres.getSlides().get_Item(0);
    // 最初のスライド内のすべてのシェイプを走査
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // シェイプが SmartArt タイプか確認
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // シェイプを SmartArt に型キャスト
            var smart = shape;
            // SmartArt 内のすべてのノードを走査
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // インデックス i の SmartArt ノードにアクセス
                var node0 = smart.getAllNodes().get_Item(i);
                // インデックス i の SmartArt ノード内の子ノードを走査
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // SmartArt ノードの子ノードにアクセス
                    var node = node0.getChildNodes().get_Item(j);
                    // SmartArt 子ノードのパラメータを出力
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **特定の位置にある SmartArt 子ノードへのアクセス**
この例では、SmartArt シェイプの各ノードに属する子ノードを特定の位置で取得する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) タイプの SmartArt シェイプを追加します。  
4. 追加した SmartArt シェイプにアクセスします。  
5. インデックス 0 のノードにアクセスします。  
6. **get_Item()** メソッドを使用して、アクセスした SmartArt ノードの位置 1 にある [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) にアクセスします。  
7. 子ノードの位置、レベル、テキストなどの情報を取得して表示します。  
```javascript
// プレゼンテーションをインスタンス化
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // 最初のスライドに SmartArt シェイプを追加
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // インデックス 0 の SmartArt ノードにアクセス
    var node = smart.getAllNodes().get_Item(0);
    // 親ノードの位置 1 の子ノードにアクセス
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // SmartArt 子ノードのパラメータを出力
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **JavaScript を使用した PowerPoint プレゼンテーションの SmartArt ノードの削除**
この例では、SmartArt シェイプ内のノードを削除する方法を学びます。

1. SmartArt シェイプを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. 最初のスライド内のすべてのシェイプを走査します。  
4. シェイプが [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 型か確認し、SmartArt であれば [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) に型キャストします。  
5. SmartArt に 0 以上のノードが存在するか確認します。  
6. 削除する SmartArt ノードを選択します。  
7. 選択したノードを [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-) メソッドで削除します。  
8. プレゼンテーションを保存します。  
```javascript
// 必要なプレゼンテーションをロード
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // シェイプが SmartArt タイプか確認
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // シェイプを SmartArt に型キャスト
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // インデックス 0 の SmartArt ノードにアクセス
                var node = smart.getAllNodes().get_Item(0);
                // 選択したノードを削除
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // プレゼンテーションを保存
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **特定の位置にある SmartArt ノードの削除**
この例では、特定の位置にある SmartArt シェイプ内のノードを削除する方法を学びます。

1. SmartArt シェイプを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. 最初のスライド内のすべてのシェイプを走査します。  
4. シェイプが [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 型か確認し、SmartArt であれば [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) に型キャストします。  
5. インデックス 0 の SmartArt シェイプノードを選択します。  
6. 選択した SmartArt ノードが 2 つ以上の子ノードを持つか確認します。  
7. **Position 1** のノードを [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-) メソッドで削除します。  
8. プレゼンテーションを保存します。  
```javascript
// 目的のプレゼンテーションをロード
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // シェイプが SmartArt タイプか確認
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // シェイプを SmartArt に型キャスト
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // インデックス 0 の SmartArt ノードにアクセス
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // 位置 1 の子ノードを削除
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // プレゼンテーションを保存
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt の子ノードにカスタム位置を設定**
現在、Aspose.Slides for Node.js via Java は [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) の [X](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setX-float-) および [Y](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setY-float-) プロパティの設定をサポートしています。以下のコードスニペットは、カスタム位置・サイズ・回転を設定する方法を示します。新しいノードを追加すると、すべてのノードの位置とサイズが再計算される点に留意してください。カスタム位置設定により、ユーザーは要件に合わせてノードを配置できます。  
```javascript
// Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // SmartArt シェイプを新しい位置に移動
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // SmartArt シェイプの幅を変更
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // SmartArt シェイプの高さを変更
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // SmartArt シェイプの回転を変更
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Assistant ノードの確認**
{{% alert color="primary" %}} 

この記事では、Aspose.Slides for Node.js via Java を使用してプログラムでスライドに追加した SmartArt シェイプの機能をさらに調査します。  
{{% /alert %}} 

以下のソース SmartArt シェイプを使用して、記事の各セクションで調査を行います。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**図: スライド内のソース SmartArt シェイプ**|

以下のサンプルコードで、SmartArt ノードコレクション内の **Assistant Nodes** を特定し、変更する方法を調査します。

1. SmartArt シェイプを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して 2 番目のスライドの参照を取得します。  
3. 最初のスライド内のすべてのシェイプを走査します。  
4. シェイプが [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 型か確認し、SmartArt であれば [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) に型キャストします。  
5. SmartArt シェイプ内のすべてのノードを走査し、[**Assistant Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isAssistant--) かどうかを確認します。  
6. Assistant ノードのステータスを通常ノードに変更します。  
7. プレゼンテーションを保存します。  
```javascript
// プレゼンテーション インスタンスを作成
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // シェイプが SmartArt タイプか確認
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // シェイプを SmartArt に型キャスト
            var smart = shape;
            // SmartArt シェイプのすべてのノードを走査
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // ノードがアシスタントノードか確認
                if (node.isAssistant()) {
                    // アシスタントノードを false に設定し、通常ノードにします
                    node.isAssistant();
                }
            }
        }
    }
    // プレゼンテーションを保存
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**図: スライド内の SmartArt シェイプで変更された Assistant ノード**|

## **ノードの Fill Format の設定**
Aspose.Slides for Node.js via Java を使用すると、カスタム SmartArt シェイプを追加し、塗りつぶし形式を設定できます。この記事では、SmartArt シェイプを作成・アクセスし、塗りつぶし形式を設定する手順を説明します。

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. [**LayoutType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) を設定して [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) シェイプを追加します。  
4. SmartArt シェイプのノードに対して [**FillFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getFillFormat--) を設定します。  
5. 変更したプレゼンテーションを PPTX ファイルとして書き出します。  
```javascript
// プレゼンテーションをインスタンス化
var pres = new aspose.slides.Presentation();
try {
    // スライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // SmartArt シェイプとノードを追加
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // ノードの塗りつぶし色を設定
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // プレゼンテーションを保存
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt 子ノードのサムネイル生成**
開発者は以下の手順で SmartArt の子ノードのサムネイルを生成できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. [SmartArt を追加](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) します。  
3. インデックスを使用してノードの参照を取得します。  
4. サムネイル画像を取得します。  
5. 任意の画像形式でサムネイル画像を保存します。  
```javascript
// PPTX ファイルを表す Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation();
try {
    // SmartArt を追加
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // インデックスを使用してノードの参照を取得
    var node = smart.getNodes().get_Item(1);
    // サムネイルを取得
    var slideImage = node.getShapes().get_Item(0).getImage();
    // サムネイルを保存
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**SmartArt のアニメーションはサポートされていますか？**

はい。SmartArt は通常のシェイプとして扱われるため、[標準アニメーション](/slides/ja/nodejs-java/shape-animation/)（入口、退出、強調、動きのパス）を適用したり、タイミングを調整したりできます。必要に応じて SmartArt ノード内のシェイプにもアニメーションを付与できます。

**内部 ID が不明な場合、スライド上の特定の SmartArt を確実に見つける方法は？**

[代替テキスト](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getalternativetext/) を設定し、検索に使用します。SmartArt に固有の AltText を付与すれば、内部識別子に依存せずに取得可能です。

**プレゼンテーションを PDF に変換した際、SmartArt の外観は保持されますか？**

はい。Aspose.Slides は [PDF エクスポート](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) 時に SmartArt を高い視覚忠実度でレンダリングし、レイアウト、色、エフェクトを保持します。

**SmartArt 全体の画像を抽出してプレビューやレポートに使用できますか？**

はい。SmartArt シェイプを [ラスタ形式](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) または [SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) にレンダリングでき、サムネイル、レポート、Web 用の画像として利用できます。